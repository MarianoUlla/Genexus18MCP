using System;
using System.IO;
using System.Linq;
using GxMcp.Gateway;
using Newtonsoft.Json.Linq;
using Xunit;

// FR#20 (v2.6.6 Stream B): soft-reload must persist BackgroundJobRegistry entries
// across the worker restart so an in-flight task_id stays valid for lifecycle calls.
// These tests stand in for the full round-trip (worker exit → gateway respawn →
// worker startup notification) by exercising SaveTo / LoadFrom directly.
public class BackgroundJobRegistryPersistenceTests
{
    private static string TempPath()
    {
        string dir = Path.Combine(Path.GetTempPath(), "gxmcp-jobs-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(dir);
        return Path.Combine(dir, "jobs.json");
    }

    [Fact]
    public void SaveTo_PersistsRunningJobs()
    {
        var r = new BackgroundJobRegistry(600);
        var j = r.Start("session-A", "build", 30);
        j.Summary = "snapshot in flight";

        string path = TempPath();
        try
        {
            r.SaveTo(path);
            Assert.True(File.Exists(path));
            string raw = File.ReadAllText(path);
            Assert.Contains(j.Id, raw);
            Assert.Contains("running", raw);
            Assert.Contains("session-A", raw);
        }
        finally { try { Directory.Delete(Path.GetDirectoryName(path)!, true); } catch { } }
    }

    [Fact]
    public void LoadFrom_RehydratesIntoFreshRegistry()
    {
        var src = new BackgroundJobRegistry(600);
        var jA = src.Start("s1", "build", 60);
        var jB = src.Start("s2", "edit", 10);
        src.Complete(jB.Id, true, "done", new JObject { ["ok"] = true });

        string path = TempPath();
        try
        {
            src.SaveTo(path);

            var dst = new BackgroundJobRegistry(600);
            int loaded = dst.LoadFrom(path, deleteAfterRead: true);
            Assert.Equal(2, loaded);

            var aRestored = dst.Get(jA.Id);
            Assert.NotNull(aRestored);
            Assert.Equal("running", aRestored!.Status);
            Assert.Equal("s1", aRestored.Session);

            var bRestored = dst.Get(jB.Id);
            Assert.NotNull(bRestored);
            Assert.Equal("succeeded", bRestored!.Status);
            Assert.NotNull(bRestored.Result);
            Assert.True((bool)bRestored.Result!["ok"]!);

            // deleteAfterRead=true means consumer file gone.
            Assert.False(File.Exists(path));
        }
        finally { try { Directory.Delete(Path.GetDirectoryName(path)!, true); } catch { } }
    }

    [Fact]
    public void LoadFrom_MissingFileReturnsZero()
    {
        var dst = new BackgroundJobRegistry(600);
        int loaded = dst.LoadFrom(Path.Combine(Path.GetTempPath(), "definitely-not-there-" + Guid.NewGuid().ToString("N"), "jobs.json"));
        Assert.Equal(0, loaded);
    }

    [Fact]
    public void SaveTo_IsAtomicAgainstPartialWrites()
    {
        // Surface the .tmp-then-move pattern: after SaveTo, no .tmp leftovers.
        var r = new BackgroundJobRegistry(600);
        r.Start("s1", "build", 30);
        string path = TempPath();
        try
        {
            r.SaveTo(path);
            Assert.True(File.Exists(path));
            Assert.False(File.Exists(path + ".tmp"));
        }
        finally { try { Directory.Delete(Path.GetDirectoryName(path)!, true); } catch { } }
    }

    [Fact]
    public void LifecycleStatus_RemainsAddressableAfterSoftReloadRoundTrip()
    {
        // Simulates a soft reload: snapshot → fresh registry → Get(jobId) still works.
        // This is the user-visible quality bar — "Lifecycle status calls for those
        // taskIds continue working across the restart."
        var pre = new BackgroundJobRegistry(600);
        var j = pre.Start("session-X", "build", 45);
        string preserved = j.Id;
        string path = TempPath();
        try
        {
            pre.SaveTo(path);
            var post = new BackgroundJobRegistry(600);
            post.LoadFrom(path);

            var found = post.Get(preserved);
            Assert.NotNull(found);
            Assert.Equal("running", found!.Status);

            // Subsequent Complete on the rehydrated entry promotes status as expected.
            post.Complete(preserved, true, "post-restart");
            Assert.Equal("succeeded", post.Get(preserved)!.Status);
        }
        finally { try { Directory.Delete(Path.GetDirectoryName(path)!, true); } catch { } }
    }
}
