using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GxMcp.Gateway
{
    public sealed class BackgroundJobRegistry
    {
        private readonly int _retentionSeconds;
        private readonly ConcurrentDictionary<string, JobEntry> _jobs = new();
        private readonly ConcurrentDictionary<string, HashSet<string>> _seenBySession = new();
        // v2.3.8 (Task 7.2): one CTS per running job. The async build/edit pollers
        // observe ct.IsCancellationRequested and terminate their loops; the worker
        // process may still finish its current SDK call (worker-side CT plumbing is
        // a follow-up — see CHANGELOG), but the gateway-side response is deterministic.
        private readonly ConcurrentDictionary<string, CancellationTokenSource> _cts = new();

        public BackgroundJobRegistry(int retentionSeconds = 600) => _retentionSeconds = retentionSeconds;

        public JobEntry Start(string session, string kind, int estimatedSeconds)
        {
            var job = new JobEntry
            {
                Id = Guid.NewGuid().ToString("N"),
                Session = session,
                Kind = kind,
                Status = "running",
                StartedAt = DateTime.UtcNow,
                EstimatedSeconds = estimatedSeconds
            };
            _jobs[job.Id] = job;
            return job;
        }

        public void Complete(string jobId, bool success, string? summary, JObject? result = null)
        {
            if (!_jobs.TryGetValue(jobId, out var job)) return;
            // Don't clobber a Cancelled status with succeeded/failed — the cancel
            // raced ahead of the worker's response.
            if (!string.Equals(job.Status, "cancelled", StringComparison.OrdinalIgnoreCase))
                job.Status = success ? "succeeded" : "failed";
            job.CompletedAt = DateTime.UtcNow;
            if (job.Summary == null) job.Summary = summary;
            if (job.Result == null) job.Result = result;
            DisposeCts(jobId);
        }

        // v2.3.8 (Task 7.2): cancel a running job. Signals the CTS (if any pollers
        // registered one) and flips status to "cancelled" so subsequent
        // SnapshotForSession / LongPollJob calls return a terminal envelope.
        public CancellationToken RegisterCancellation(string jobId)
        {
            var cts = _cts.GetOrAdd(jobId, _ => new CancellationTokenSource());
            return cts.Token;
        }

        public bool Cancel(string jobId, string? reason = null)
        {
            if (!_jobs.TryGetValue(jobId, out var job)) return false;
            if (_cts.TryGetValue(jobId, out var cts))
            {
                try { cts.Cancel(); } catch { /* already disposed */ }
            }
            job.Status = "cancelled";
            job.CompletedAt = DateTime.UtcNow;
            job.Summary = reason ?? "Cancelled by client";
            return true;
        }

        private void DisposeCts(string jobId)
        {
            if (_cts.TryRemove(jobId, out var cts))
            {
                try { cts.Dispose(); } catch { }
            }
        }

        public JobEntry? Get(string jobId) => _jobs.TryGetValue(jobId, out var j) ? j : null;

        public IReadOnlyList<JobEntry> SnapshotForSession(string session)
        {
            var seen = _seenBySession.GetOrAdd(session, _ => new HashSet<string>());
            lock (seen)
            {
                return _jobs.Values
                    .Where(j => j.Session == session)
                    .Where(j => j.Status == "running" || !seen.Contains(j.Id))
                    .ToList();
            }
        }

        public void MarkSeen(string session, IEnumerable<string> jobIds)
        {
            var seen = _seenBySession.GetOrAdd(session, _ => new HashSet<string>());
            lock (seen)
            {
                foreach (var id in jobIds)
                {
                    if (_jobs.TryGetValue(id, out var j) && j.Status != "running")
                        seen.Add(id);
                }
            }
        }

        public void SweepExpired()
        {
            var cutoff = DateTime.UtcNow.AddSeconds(-_retentionSeconds);
            foreach (var kvp in _jobs)
            {
                if (kvp.Value.CompletedAt != null && kvp.Value.CompletedAt < cutoff)
                    _jobs.TryRemove(kvp.Key, out _);
            }
        }

        public int Count => _jobs.Count;

        // FR#20 (v2.6.6 Stream B): persist JobEntry list across worker soft-reloads.
        // We intentionally snapshot only the value side — _seenBySession is a UI-state
        // concern bound to a session lifetime, not a job, so it's recomputed lazily.
        // Per-job CancellationTokenSources are NOT serialized (they reference live
        // pollers that wouldn't survive a restart anyway).
        public void SaveTo(string path)
        {
            if (string.IsNullOrWhiteSpace(path)) throw new ArgumentException("path required", nameof(path));
            try
            {
                string dir = Path.GetDirectoryName(path);
                if (!string.IsNullOrEmpty(dir)) Directory.CreateDirectory(dir);
                var list = _jobs.Values.ToList();
                string json = JsonConvert.SerializeObject(list, Formatting.Indented);
                // Atomic-ish write: dump to .tmp then move so a crash mid-write never
                // leaves a corrupted jobs.json that the next worker would refuse to parse.
                string tmp = path + ".tmp";
                File.WriteAllText(tmp, json, System.Text.Encoding.UTF8);
                if (File.Exists(path)) File.Delete(path);
                File.Move(tmp, path);
            }
            catch (Exception ex)
            {
                // Caller (gateway shutdown path) logs; rethrow so soft-reload metrics see it.
                throw new IOException("Failed to persist BackgroundJobRegistry to " + path + ": " + ex.Message, ex);
            }
        }

        public int LoadFrom(string path, bool deleteAfterRead = true)
        {
            if (!File.Exists(path)) return 0;
            int loaded = 0;
            try
            {
                string json = File.ReadAllText(path, System.Text.Encoding.UTF8);
                var list = JsonConvert.DeserializeObject<List<JobEntry>>(json) ?? new List<JobEntry>();
                foreach (var j in list)
                {
                    if (string.IsNullOrWhiteSpace(j?.Id)) continue;
                    _jobs[j.Id] = j;
                    loaded++;
                }
                if (deleteAfterRead)
                {
                    try { File.Delete(path); }
                    catch (Exception delEx)
                    {
                        // Non-fatal: leaving the file means a subsequent restart re-loads
                        // (idempotent — same IDs overwrite the same entries).
                        System.Diagnostics.Debug.WriteLine("[BackgroundJobRegistry] delete after load failed: " + delEx.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new IOException("Failed to rehydrate BackgroundJobRegistry from " + path + ": " + ex.Message, ex);
            }
            return loaded;
        }
    }

    public sealed class JobEntry
    {
        public string Id { get; set; } = "";
        public string Session { get; set; } = "";
        public string Kind { get; set; } = "";
        public string Status { get; set; } = "running";
        public DateTime StartedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public int EstimatedSeconds { get; set; }
        public string? Summary { get; set; }
        public JObject? Result { get; set; }
    }
}
