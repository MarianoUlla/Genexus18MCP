using System;
using System.Collections.Concurrent;

namespace GxMcp.Worker.Services
{
    // v2.6.9 — Tracks which objects have been edited via MCP write endpoints
    // since their last successful BuildOne. This drives the build path branching
    // in InProcessBuildRunner:
    //
    //   - target in dirty-set  → full BuildOne (Specify+Generate+Compile)
    //   - target NOT in set    → Run.Compile (compile-only fast-fast path)
    //
    // Default for unknown (never edited via MCP this session) is DIRTY: we have
    // no record that BuildOne ever ran for it, so we can't assume the .cs is
    // current. The fast-fast path only triggers when we have an explicit
    // "edited, then successfully built since" record.
    //
    // Multi-KB safety: keyed by (kbPath, lowercased-object-name). The worker is
    // single-KB per process today, but a future shared-worker mode would still
    // be correct.
    internal static class EditDirtyTracker
    {
        // Outer: kbPath (case-insensitive). Inner: object name (lowercase).
        // The byte value is unused — we only care about set membership.
        private static readonly ConcurrentDictionary<string, ConcurrentDictionary<string, byte>> _dirty
            = new ConcurrentDictionary<string, ConcurrentDictionary<string, byte>>(StringComparer.OrdinalIgnoreCase);

        // "Has ever been successfully built by the MCP this session." Without
        // this record we treat the target as dirty even if no edit was recorded
        // — we don't know whether the .cs was generated previously.
        private static readonly ConcurrentDictionary<string, ConcurrentDictionary<string, byte>> _everBuilt
            = new ConcurrentDictionary<string, ConcurrentDictionary<string, byte>>(StringComparer.OrdinalIgnoreCase);

        private static string Normalize(string name)
        {
            return string.IsNullOrWhiteSpace(name) ? null : name.Trim().ToLowerInvariant();
        }

        private static string NormalizeKb(string kbPath)
        {
            return string.IsNullOrWhiteSpace(kbPath) ? "<no-kb>" : kbPath.Trim();
        }

        public static void MarkDirty(string kbPath, string objectName)
        {
            var n = Normalize(objectName);
            if (n == null) return;
            var bag = _dirty.GetOrAdd(NormalizeKb(kbPath),
                _ => new ConcurrentDictionary<string, byte>(StringComparer.OrdinalIgnoreCase));
            bag[n] = 1;
        }

        public static void MarkClean(string kbPath, string objectName)
        {
            var n = Normalize(objectName);
            if (n == null) return;
            var kbKey = NormalizeKb(kbPath);
            if (_dirty.TryGetValue(kbKey, out var bag))
            {
                bag.TryRemove(n, out _);
            }
            var built = _everBuilt.GetOrAdd(kbKey,
                _ => new ConcurrentDictionary<string, byte>(StringComparer.OrdinalIgnoreCase));
            built[n] = 1;
        }

        // True if the object was edited since the last successful build OR has
        // never been successfully built by the MCP this session. Safe default.
        public static bool IsDirty(string kbPath, string objectName)
        {
            var n = Normalize(objectName);
            if (n == null) return true;
            var kbKey = NormalizeKb(kbPath);
            if (_dirty.TryGetValue(kbKey, out var bag) && bag.ContainsKey(n)) return true;
            if (!_everBuilt.TryGetValue(kbKey, out var built) || !built.ContainsKey(n)) return true;
            return false;
        }
    }
}
