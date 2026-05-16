using System;
using Newtonsoft.Json.Linq;
using Xunit;

namespace GxMcp.Gateway.Tests
{
    public class OperationTrackerTests
    {
        [Fact]
        public void RegisterSpawnSample_ReturnsP50AndP95_AfterEnoughSamples()
        {
            var tracker = new OperationTracker(System.TimeSpan.FromMinutes(5));

            for (int i = 1; i <= 100; i++)
            {
                tracker.RegisterSpawnSample("test-kb", 100.0 + i);
            }

            var (count, p50, p95) = tracker.GetSpawnStats("test-kb");
            Assert.Equal(100, count);
            Assert.InRange(p50, 145, 155);
            Assert.InRange(p95, 190, 200);
        }

        [Fact]
        public void GetSpawnStats_ReturnsZeros_ForUnknownKb()
        {
            var tracker = new OperationTracker(System.TimeSpan.FromMinutes(5));
            var (count, p50, p95) = tracker.GetSpawnStats("never-seen");
            Assert.Equal(0, count);
            Assert.Equal(0, p50);
            Assert.Equal(0, p95);
        }

        [Fact]
        public void CompleteFromWorker_ShouldHandleArrayResultPayload()
        {
            var tracker = new OperationTracker(TimeSpan.FromMinutes(5));
            string requestId = Guid.NewGuid().ToString("N");
            string operationId = tracker.StartOperation(
                requestId,
                "genexus_list_objects",
                new JObject { ["limit"] = 20 },
                Guid.NewGuid().ToString("N"));

            var workerPayload = new JObject
            {
                ["id"] = requestId,
                ["result"] = new JArray(
                    new JObject
                    {
                        ["name"] = "ACADEMICOS",
                        ["type"] = "Folder"
                    })
            };

            tracker.CompleteFromWorker(requestId, workerPayload);
            JObject status = tracker.BuildOperationStatus(operationId);

            Assert.Equal("Completed", status["status"]?.ToString());
            Assert.False(status["timedOut"]?.Value<bool>() ?? true);
        }
    }
}

