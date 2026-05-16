using BenchmarkDotNet.Attributes;
using Newtonsoft.Json.Linq;
using System.Reflection;

namespace GxMcp.Benchmarks
{
    [MemoryDiagnoser]
    public class EnvelopeProjectionBenchmark
    {
        private JObject _payload = null!;
        private MethodInfo _method = null!;

        [GlobalSetup]
        public void Setup()
        {
            var arr = new JArray();
            for (int i = 0; i < 500; i++)
            {
                arr.Add(new JObject
                {
                    ["name"] = $"Obj{i}",
                    ["type"] = "Procedure",
                    ["path"] = $"Folder/Obj{i}",
                    ["parentPath"] = "Folder",
                    ["description"] = "Lorem ipsum dolor sit amet, consectetur adipiscing elit."
                });
            }
            _payload = new JObject { ["results"] = arr };

            _method = typeof(GxMcp.Gateway.Program).GetMethod(
                "NormalizeToolPayloadForAxi",
                BindingFlags.NonPublic | BindingFlags.Static)!;
        }

        [Benchmark]
        public object? CompactProjection_500Rows()
        {
            var args = new JObject { ["axiCompact"] = true };
            return _method.Invoke(null, new object?[] { _payload, "genexus_list_objects", args, false });
        }

        [Benchmark(Baseline = true)]
        public object? FullPayload_500Rows()
        {
            var args = new JObject { ["axiCompact"] = false };
            return _method.Invoke(null, new object?[] { _payload, "genexus_list_objects", args, false });
        }
    }
}
