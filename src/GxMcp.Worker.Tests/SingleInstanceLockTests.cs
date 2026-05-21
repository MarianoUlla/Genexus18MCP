using System;
using System.IO;
using GxMcp.Worker.Helpers;
using Xunit;

namespace GxMcp.Worker.Tests
{
    // FR#19 (v2.6.6 Stream B): verify the file-lock + Global mutex coordination so
    // a second worker against the same KB is refused instead of piling up. We can't
    // spawn an actual second worker.exe inside a unit test without a real GeneXus
    // install, so we exercise the SingleInstanceLock helper directly with two
    // overlapping acquisitions — same outcome the worker Main() would see.
    public class SingleInstanceLockTests
    {
        private static string FreshLockDir()
        {
            string p = Path.Combine(Path.GetTempPath(), "gxmcp-locktests-" + Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(p);
            return p;
        }

        [Fact]
        public void TryAcquire_FirstCallSucceeds()
        {
            string dir = FreshLockDir();
            try
            {
                using var l = SingleInstanceLock.TryAcquire(@"C:\kb\demo", @"C:\worker\GxMcp.Worker.exe", dir);
                Assert.True(l.Acquired);
                Assert.False(string.IsNullOrEmpty(l.LockPath));
                Assert.True(File.Exists(l.LockPath));
            }
            finally { try { Directory.Delete(dir, true); } catch { } }
        }

        [Fact]
        public void TryAcquire_SecondCallSameKeyIsRefused()
        {
            string dir = FreshLockDir();
            try
            {
                using var first = SingleInstanceLock.TryAcquire(@"C:\kb\demo", @"C:\worker\GxMcp.Worker.exe", dir);
                Assert.True(first.Acquired);

                using var second = SingleInstanceLock.TryAcquire(@"C:\kb\demo", @"C:\worker\GxMcp.Worker.exe", dir);
                Assert.False(second.Acquired);
                // ExistingPid should be populated (the current process holds the lock).
                Assert.True(second.ExistingPid.HasValue);
                Assert.Equal(System.Diagnostics.Process.GetCurrentProcess().Id, second.ExistingPid.Value);
            }
            finally { try { Directory.Delete(dir, true); } catch { } }
        }

        [Fact]
        public void TryAcquire_DifferentKbAllowed()
        {
            string dir = FreshLockDir();
            try
            {
                using var a = SingleInstanceLock.TryAcquire(@"C:\kb\one", @"C:\worker\GxMcp.Worker.exe", dir);
                using var b = SingleInstanceLock.TryAcquire(@"C:\kb\two", @"C:\worker\GxMcp.Worker.exe", dir);
                Assert.True(a.Acquired);
                Assert.True(b.Acquired);
                Assert.NotEqual(a.LockPath, b.LockPath);
            }
            finally { try { Directory.Delete(dir, true); } catch { } }
        }

        [Fact]
        public void Dispose_ReleasesLockSoNextCallSucceeds()
        {
            string dir = FreshLockDir();
            try
            {
                var first = SingleInstanceLock.TryAcquire(@"C:\kb\demo", @"C:\worker\GxMcp.Worker.exe", dir);
                Assert.True(first.Acquired);
                string lockPath = first.LockPath;
                first.Dispose();
                Assert.False(File.Exists(lockPath));

                using var second = SingleInstanceLock.TryAcquire(@"C:\kb\demo", @"C:\worker\GxMcp.Worker.exe", dir);
                Assert.True(second.Acquired);
            }
            finally { try { Directory.Delete(dir, true); } catch { } }
        }

        [Fact]
        public void BuildKey_IsCaseInsensitiveAndSlashNormalized()
        {
            string a = SingleInstanceLock.BuildKey(@"C:\KB\Demo\", @"C:\Worker\GxMcp.Worker.exe");
            string b = SingleInstanceLock.BuildKey(@"c:/kb/demo", @"c:/worker/gxmcp.worker.exe");
            Assert.Equal(a, b);
        }

        [Fact]
        public void Hash_IsStable()
        {
            string h1 = SingleInstanceLock.Hash("kb=x|exe=y");
            string h2 = SingleInstanceLock.Hash("kb=x|exe=y");
            Assert.Equal(h1, h2);
            Assert.Equal(64, h1.Length); // sha256 hex
        }
    }
}
