using BenchmarkDotNet.Attributes;
using Newtonsoft.Json.Linq;
using System.IO;

namespace GxMcp.Benchmarks
{
    [MemoryDiagnoser]
    public class ToolDefinitionsLoadBenchmark
    {
        private string _path = null!;

        [GlobalSetup]
        public void Setup()
        {
            string candidate = Path.Combine(
                Path.GetDirectoryName(typeof(GxMcp.Gateway.Program).Assembly.Location)!,
                "tool_definitions.json");
            if (!File.Exists(candidate))
            {
                candidate = Path.Combine("..", "..", "..", "..", "GxMcp.Gateway", "tool_definitions.json");
            }
            _path = candidate;
        }

        [Benchmark]
        public int LoadAndParse()
        {
            string json = File.ReadAllText(_path);
            var arr = JArray.Parse(json);
            return arr.Count;
        }
    }
}
