using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace GxMcp.Worker.Helpers
{
    /// <summary>
    /// Parses GeneXus-generated .cs files to extract the design-time → runtime
    /// HTML-ID mapping. The generator emits lines of the form:
    ///
    ///   this.BtnConfirmar._Internalname = "BTT58";
    ///   this.GrpNumRegProf._Internalname = "GRPNUMREGPROF";
    ///
    /// This class is intentionally SDK-free and file-system agnostic so that it
    /// can be unit-tested with synthetic strings and is independently testable.
    /// </summary>
    public static class RuntimeIdParser
    {
        // Matches:   this.<DesignId>._Internalname = "<HtmlId>";
        // or:        <DesignId>._Internalname = "<HtmlId>";
        private static readonly Regex InternalnameRe = new Regex(
            @"(?:this\.)?(\w+)\._Internalname\s*=\s*""([^""]+)""",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);

        // Matches type declarations such as:
        //   protected GXButton BtnConfirmar;
        //   protected GXGroup GrpNumRegProf;
        //   protected GXAttribute vNumRegProf;
        private static readonly Regex FieldDeclRe = new Regex(
            @"protected\s+(\w+)\s+(\w+)\s*;",
            RegexOptions.Compiled);

        public sealed class RuntimeIdEntry
        {
            public string DesignId { get; set; }
            public string HtmlId   { get; set; }
            /// <summary>
            /// Kind resolved from the C# field type declaration, e.g. "gxButton",
            /// "fieldset", "gxAttribute". Empty when the type declaration wasn't found.
            /// </summary>
            public string Kind     { get; set; }
            /// <summary>
            /// true when the C# field type is GXHidden or contains "Hidden".
            /// null when unknown.
            /// </summary>
            public bool?  Hidden   { get; set; }
        }

        /// <summary>
        /// Parses a single .cs file text and returns all detected runtime-ID entries.
        /// Safe to call with an empty / null string.
        /// </summary>
        public static List<RuntimeIdEntry> ParseSource(string csSource)
        {
            if (string.IsNullOrEmpty(csSource)) return new List<RuntimeIdEntry>();

            // 1) Collect field type declarations for kind resolution.
            var fieldTypes = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            foreach (Match m in FieldDeclRe.Matches(csSource))
            {
                string typeName = m.Groups[1].Value;
                string fieldName = m.Groups[2].Value;
                fieldTypes[fieldName] = typeName;
            }

            // 2) Collect Internalname assignments.
            var entries = new List<RuntimeIdEntry>();
            var seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (Match m in InternalnameRe.Matches(csSource))
            {
                string designId = m.Groups[1].Value;
                string htmlId   = m.Groups[2].Value;
                if (!seen.Add(designId)) continue;

                string kind = null;
                bool? hidden = null;
                if (fieldTypes.TryGetValue(designId, out var csharpType))
                {
                    kind   = MapCsharpTypeToKind(csharpType);
                    hidden = csharpType.IndexOf("Hidden", StringComparison.OrdinalIgnoreCase) >= 0;
                }

                entries.Add(new RuntimeIdEntry
                {
                    DesignId = designId,
                    HtmlId   = htmlId,
                    Kind     = kind,
                    Hidden   = hidden
                });
            }

            return entries;
        }

        /// <summary>
        /// Walks the KB directory for generated .cs files that correspond to the
        /// given object name and returns the union of all parsed entries. Looks in
        /// the same GXSPC*/GEN* directory structure used by NavigationService.
        /// Returns an empty list (never throws) when no files are found.
        /// </summary>
        public static List<RuntimeIdEntry> ParseFromKbDirectory(string kbPath, string objectName)
        {
            var all = new List<RuntimeIdEntry>();
            try
            {
                if (string.IsNullOrWhiteSpace(kbPath) || string.IsNullOrWhiteSpace(objectName))
                    return all;

                // kb.Location is the .gkb file; normalise to the directory.
                string dir = File.Exists(kbPath) ? Path.GetDirectoryName(kbPath) : kbPath;
                if (string.IsNullOrWhiteSpace(dir) || !Directory.Exists(dir))
                    return all;

                // Candidate sub-paths relative to the GEN* folder used by GeneXus .NET generator.
                // "web" is the default output folder; "CSharp" exists in full-framework builds.
                string[] candidateSubDirs = { "web", Path.Combine("web", "CSharp"), "CSharp", "" };

                // Enumerate GXSPC* directories, newest first (same ordering as NavigationService).
                var specFolders = Directory.EnumerateDirectories(dir, "GXSPC*", SearchOption.TopDirectoryOnly);
                foreach (var specFolder in specFolders)
                {
                    foreach (var genFolder in Directory.EnumerateDirectories(specFolder, "GEN*", SearchOption.TopDirectoryOnly))
                    {
                        foreach (var sub in candidateSubDirs)
                        {
                            string searchDir = string.IsNullOrEmpty(sub)
                                ? genFolder
                                : Path.Combine(genFolder, sub);
                            if (!Directory.Exists(searchDir)) continue;

                            // The generator outputs <ObjectName>.cs (case-insensitive on Windows).
                            string candidate = Path.Combine(searchDir, objectName + ".cs");
                            if (File.Exists(candidate))
                            {
                                string src = SafeReadFile(candidate);
                                var parsed = ParseSource(src);
                                if (parsed.Count > 0)
                                    return parsed; // take the first file that yields results
                            }
                        }
                    }
                }
            }
            catch { /* best-effort — caller surfaces the empty list gracefully */ }

            return all;
        }

        // ----------------------------------------------------------------
        // Helpers
        // ----------------------------------------------------------------

        private static string SafeReadFile(string path)
        {
            try
            {
                using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (var sr = new StreamReader(fs))
                    return sr.ReadToEnd();
            }
            catch { return null; }
        }

        private static string MapCsharpTypeToKind(string csharpType)
        {
            // GeneXus .NET generator type names → MCP kind labels
            if (csharpType.Equals("GXButton",    StringComparison.OrdinalIgnoreCase)) return "gxButton";
            if (csharpType.Equals("GXGroup",     StringComparison.OrdinalIgnoreCase)) return "fieldset";
            if (csharpType.Equals("GXAttribute", StringComparison.OrdinalIgnoreCase)) return "gxAttribute";
            if (csharpType.Equals("GXTextBlock", StringComparison.OrdinalIgnoreCase)) return "gxTextBlock";
            if (csharpType.Equals("GXImage",     StringComparison.OrdinalIgnoreCase)) return "gxImage";
            if (csharpType.Equals("GXHidden",    StringComparison.OrdinalIgnoreCase)) return "gxHidden";
            if (csharpType.Equals("GXGrid",      StringComparison.OrdinalIgnoreCase)) return "gxGrid";
            if (csharpType.Equals("GXTab",       StringComparison.OrdinalIgnoreCase)) return "gxTab";
            if (csharpType.StartsWith("GX",      StringComparison.OrdinalIgnoreCase)) return csharpType.ToLowerInvariant();
            return csharpType;
        }
    }
}
