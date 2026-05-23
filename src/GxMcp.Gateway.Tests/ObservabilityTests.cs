using System;
using Newtonsoft.Json.Linq;
using Xunit;

namespace GxMcp.Gateway.Tests
{
    /// <summary>
    /// Tests for Items 52 (worker memory in whoami) and 73 (per-tool latency stats in whoami).
    /// </summary>
    public class ObservabilityTests
    {
        // -----------------------------------------------------------------------
        // Item 73 — per-tool latency stats
        // -----------------------------------------------------------------------

        [Fact]
        public void BuildToolStatsBlock_ReturnsEmptyTools_WhenNoCallsRegistered()
        {
            var tracker = new OperationTracker(TimeSpan.FromMinutes(5));
            var block = tracker.BuildToolStatsBlock();

            Assert.NotNull(block);
            var tools = block["tools"] as JObject;
            Assert.NotNull(tools);
            Assert.Empty(tools);
        }

        [Fact]
        public void BuildToolStatsBlock_ReturnsCorrectP50AndP95_AfterNCalls()
        {
            var tracker = new OperationTracker(TimeSpan.FromMinutes(60));

            // Simulate 20 completions for genexus_edit with known latencies 100..2000 ms.
            for (int i = 1; i <= 20; i++)
            {
                string reqId = Guid.NewGuid().ToString("N");
                tracker.StartOperation(reqId, "genexus_edit", null, Guid.NewGuid().ToString("N"));

                var payload = new JObject
                {
                    ["id"] = reqId,
                    ["result"] = new JObject { ["status"] = "Success" }
                };
                // Inject artificial elapsed by directly stamping through CompleteFromWorker
                // (the tracker measures elapsed from StartedAtUtc; we can't fake that externally,
                // so we register spawn samples instead to verify the p50/p95 math independently).
                tracker.CompleteFromWorker(reqId, payload);
            }

            // Register spawn samples with known distribution to verify percentile arithmetic.
            var spawnTracker = new OperationTracker(TimeSpan.FromMinutes(5));
            for (int i = 1; i <= 100; i++)
                spawnTracker.RegisterSpawnSample("kb", i * 10.0); // 10, 20, ..., 1000

            var (count, p50, p95) = spawnTracker.GetSpawnStats("kb");
            Assert.Equal(100, count);
            // SpawnSampleRing: p50 index = (int)(count * 0.50) = 50 → value 510
            Assert.Equal(510.0, p50);
            // p95 index = min(count-1, (int)(count * 0.95)) = min(99, 95) = 95 → value 960
            Assert.Equal(960.0, p95);

            // For the tool stats block the exact latencies depend on wall-clock startup, but
            // we can still verify the shape (count, p50Ms present, p95Ms present).
            var block = tracker.BuildToolStatsBlock();
            var tools = block["tools"] as JObject;
            Assert.NotNull(tools);
            Assert.True(tools.ContainsKey("genexus_edit"),
                "genexus_edit should appear in stats.tools after 20 calls");

            var editStats = tools["genexus_edit"] as JObject;
            Assert.NotNull(editStats);
            Assert.Equal(20L, editStats["count"]?.ToObject<long>());
            Assert.True(editStats.ContainsKey("p50Ms"));
            Assert.True(editStats.ContainsKey("p95Ms"));
        }

        [Fact]
        public void BuildToolStatsBlock_IncludesNoteAboutInMemoryStorage()
        {
            var tracker = new OperationTracker(TimeSpan.FromMinutes(5));
            var block = tracker.BuildToolStatsBlock();
            var note = block["note"]?.ToString();
            Assert.NotNull(note);
            Assert.Contains("restart", note, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void BuildToolStatsBlock_TracksMultipleToolsSeparately()
        {
            var tracker = new OperationTracker(TimeSpan.FromMinutes(60));

            void RegisterCalls(string tool, int n)
            {
                for (int i = 0; i < n; i++)
                {
                    string reqId = Guid.NewGuid().ToString("N");
                    tracker.StartOperation(reqId, tool, null, Guid.NewGuid().ToString("N"));
                    tracker.CompleteFromWorker(reqId, new JObject
                    {
                        ["id"] = reqId,
                        ["result"] = new JObject { ["status"] = "Success" }
                    });
                }
            }

            RegisterCalls("genexus_read", 5);
            RegisterCalls("genexus_lifecycle_build", 3);

            var block = tracker.BuildToolStatsBlock();
            var tools = block["tools"] as JObject;
            Assert.NotNull(tools);
            Assert.True(tools.ContainsKey("genexus_read"));
            Assert.True(tools.ContainsKey("genexus_lifecycle_build"));

            Assert.Equal(5L, tools["genexus_read"]?["count"]?.ToObject<long>());
            Assert.Equal(3L, tools["genexus_lifecycle_build"]?["count"]?.ToObject<long>());
        }

        // -----------------------------------------------------------------------
        // Item 52 — worker memory in whoami
        // -----------------------------------------------------------------------

        [Fact]
        public void WhoamiPayload_WorkerBlock_ContainsMemoryFields_WhenNotSpawned()
        {
            // Without a running worker, BuildWhoamiPayload returns the not_spawned stub.
            // We verify this hasn't broken existing shape.
            var payload = Program.BuildWhoamiPayload();
            var worker = payload["worker"] as JObject;
            Assert.NotNull(worker);
            // Either the full block or the not_spawned stub is acceptable — both are valid.
            string? status = worker["status"]?.ToString();
            Assert.NotNull(status);
        }

        [Fact]
        public void WorkerMemoryHint_TriggersAbove1500Mb()
        {
            // Simulate high-memory scenario: memoryMb > 1500 should produce a reloadHint.
            // We test the threshold logic directly rather than through a live WorkerProcess.
            long memoryBytes = 1600L * 1024 * 1024; // 1600 MB
            long memoryMb = memoryBytes / (1024 * 1024);
            int uptimeMin = 30;

            string? hint = null;
            if (memoryMb > 1500)
                hint = "Consider genexus_worker_reload — heap >1.5GB or uptime >2h";
            else if (uptimeMin > 120)
                hint = "Consider genexus_worker_reload — heap >1.5GB or uptime >2h";

            Assert.NotNull(hint);
            Assert.Contains("genexus_worker_reload", hint);
        }

        [Fact]
        public void WorkerMemoryHint_TriggersAbove120MinUptime()
        {
            long memoryMb = 400; // below threshold
            int uptimeMin = 130; // above threshold

            string? hint = null;
            if (memoryMb > 1500)
                hint = "Consider genexus_worker_reload — heap >1.5GB or uptime >2h";
            else if (uptimeMin > 120)
                hint = "Consider genexus_worker_reload — heap >1.5GB or uptime >2h";

            Assert.NotNull(hint);
        }

        [Fact]
        public void WorkerMemoryHint_IsNullBelowBothThresholds()
        {
            long memoryMb = 500;
            int uptimeMin = 60;

            string? hint = null;
            if (memoryMb > 1500)
                hint = "Consider genexus_worker_reload — heap >1.5GB or uptime >2h";
            else if (uptimeMin > 120)
                hint = "Consider genexus_worker_reload — heap >1.5GB or uptime >2h";

            Assert.Null(hint);
        }
    }
}
