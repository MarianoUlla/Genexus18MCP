using BenchmarkDotNet.Attributes;
using GxMcp.Gateway;
using System;

namespace GxMcp.Benchmarks
{
    [MemoryDiagnoser]
    public class WorkerSpawnSimulationBenchmark
    {
        private OperationTracker _tracker = null!;

        [GlobalSetup]
        public void Setup()
        {
            _tracker = new OperationTracker(TimeSpan.FromMinutes(5));
            var rng = new Random(42);
            for (int i = 0; i < 256; i++)
            {
                _tracker.RegisterSpawnSample("bench-kb", 800 + rng.NextDouble() * 1200);
            }
        }

        [Benchmark]
        public (int, double, double) PercentileSnapshot()
        {
            return _tracker.GetSpawnStats("bench-kb");
        }

        [Benchmark]
        public void RegisterSample()
        {
            _tracker.RegisterSpawnSample("bench-kb", 1234);
        }
    }
}
