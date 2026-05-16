using Xunit;

namespace GxMcp.Gateway.Tests
{
    public class WorkerProcessLatencyTests
    {
        [Fact]
        public void SpawnMs_DefaultsToNull_BeforeStart()
        {
            var kb = new KbHandle("test", "C:\\fake\\path");
            var config = new Configuration();
            var worker = new WorkerProcess(config, kb);

            Assert.Null(worker.SpawnMs);
            Assert.Null(worker.SdkInitMs);
        }
    }
}
