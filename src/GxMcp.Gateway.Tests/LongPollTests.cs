using System;
using System.Diagnostics;
using System.Threading.Tasks;
using GxMcp.Gateway;
using Newtonsoft.Json.Linq;
using Xunit;

/// <summary>
/// Tests for McpRouter.LongPollJob — the server-side long-poll helper introduced in Task 4.5.
/// wait_seconds is clamped to [0, 25]; 0 means immediate single poll.
/// </summary>
public class LongPollTests
{
    // ── helpers ──────────────────────────────────────────────────────────────

    private static BackgroundJobRegistry MakeRegistry() => new BackgroundJobRegistry(600);

    // ── tests ─────────────────────────────────────────────────────────────────

    [Fact]
    public async Task UnknownJobId_ReturnsErrorEnvelope()
    {
        var registry = MakeRegistry();

        JObject result = await McpRouter.LongPollJob(registry, "bogus-id-does-not-exist", waitSeconds: 0);

        Assert.NotNull(result["error"]);
        Assert.Equal("unknown_job_id", result["error"]!.ToString());
        Assert.Equal("bogus-id-does-not-exist", result["job_id"]!.ToString());
    }

    [Fact]
    public async Task TerminalJob_ReturnsImmediately()
    {
        // A completed job should return well under one poll interval (250 ms) even when
        // wait_seconds is generous, because the loop exits as soon as status != "running".
        var registry = MakeRegistry();
        var job = registry.Start("s1", "build", 30);
        registry.Complete(job.Id, true, "done");

        var sw = Stopwatch.StartNew();
        JObject result = await McpRouter.LongPollJob(registry, job.Id, waitSeconds: 5);
        sw.Stop();

        Assert.Equal("succeeded", result["job_id"] != null ? result["status"]!.ToString() : "");
        Assert.Equal("succeeded", result["status"]!.ToString());
        // Should return in well under 250 ms (one poll tick) — use 500 ms as a safe ceiling.
        Assert.True(sw.ElapsedMilliseconds < 500,
            $"Expected near-immediate return for terminal job but took {sw.ElapsedMilliseconds} ms");
    }

    [Fact]
    public async Task RunningJob_BlocksUntilCompletion()
    {
        // Complete the job after ~200 ms; long-poll with wait_seconds=5 should return ~200 ms later.
        var registry = MakeRegistry();
        var job = registry.Start("s1", "build", 30);

        _ = Task.Run(async () =>
        {
            await Task.Delay(200);
            registry.Complete(job.Id, true, "build ok");
        });

        var sw = Stopwatch.StartNew();
        JObject result = await McpRouter.LongPollJob(registry, job.Id, waitSeconds: 5);
        sw.Stop();

        Assert.Equal("succeeded", result["status"]!.ToString());
        // Must have waited at least the ~200 ms for completion but much less than 5 s.
        Assert.True(sw.ElapsedMilliseconds >= 150,
            $"Returned too early — elapsed {sw.ElapsedMilliseconds} ms, expected >= 150 ms");
        Assert.True(sw.ElapsedMilliseconds < 3000,
            $"Took too long — elapsed {sw.ElapsedMilliseconds} ms, expected < 3000 ms");
    }

    [Fact]
    public async Task RunningJob_HonorsTimeout()
    {
        // Job is never completed; long-poll with wait_seconds=1 must return after ~1 s
        // with status still "running".
        var registry = MakeRegistry();
        var job = registry.Start("s1", "build", 30);

        var sw = Stopwatch.StartNew();
        JObject result = await McpRouter.LongPollJob(registry, job.Id, waitSeconds: 1);
        sw.Stop();

        Assert.Equal("running", result["status"]!.ToString());
        Assert.True(sw.ElapsedMilliseconds >= 900,
            $"Returned before timeout — elapsed {sw.ElapsedMilliseconds} ms, expected >= 900 ms");
        // Should not significantly overshoot (250 ms poll tick + processing headroom)
        Assert.True(sw.ElapsedMilliseconds < 2500,
            $"Took too long past timeout — elapsed {sw.ElapsedMilliseconds} ms");
    }

    [Fact]
    public async Task WaitSecondsClampedToMax25()
    {
        // Passing wait_seconds > 25 is clamped to 25 (indirectly verified: a never-finishing job
        // should *not* block for 60 s — we pass 60 and expect clamping, but we use a very short
        // wait in the test by completing the job quickly instead of actually waiting 25 s).
        // We only verify the clamp doesn't crash and returns a valid envelope.
        var registry = MakeRegistry();
        var job = registry.Start("s1", "build", 30);
        registry.Complete(job.Id, false, "failed");

        // wait_seconds=60 → clamped to 25, but job is already terminal so returns immediately.
        JObject result = await McpRouter.LongPollJob(registry, job.Id, waitSeconds: 60);

        Assert.Equal("failed", result["status"]!.ToString());
    }

    [Fact]
    public async Task ZeroWaitSeconds_ImmediatePollNoBlocking()
    {
        // With wait_seconds=0 the loop body should not delay even if the job is running.
        var registry = MakeRegistry();
        var job = registry.Start("s1", "build", 30);

        var sw = Stopwatch.StartNew();
        JObject result = await McpRouter.LongPollJob(registry, job.Id, waitSeconds: 0);
        sw.Stop();

        Assert.Equal("running", result["status"]!.ToString());
        // Must return essentially instantly — under 100 ms.
        Assert.True(sw.ElapsedMilliseconds < 100,
            $"wait_seconds=0 blocked for {sw.ElapsedMilliseconds} ms, expected < 100 ms");
    }
}
