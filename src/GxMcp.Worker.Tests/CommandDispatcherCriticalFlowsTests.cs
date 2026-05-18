using GxMcp.Worker.Services;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Runtime.Serialization;
using Xunit;

namespace GxMcp.Worker.Tests
{
    public class CommandDispatcherCriticalFlowsTests
    {
        [Fact]
        public void IsThreadSafe_ControlCancel_True_ButOtherControlFalse()
        {
            var dispatcher = CreateDispatcherWithoutCtor();

            string cancel = @"{""method"":""control"",""action"":""Cancel""}";
            string notCancel = @"{""method"":""control"",""action"":""Pause""}";

            Assert.True(dispatcher.IsThreadSafe(cancel));
            Assert.False(dispatcher.IsThreadSafe(notCancel));
        }

        [Fact]
        public void IsThreadSafe_KbIndexReads_True_AndMalformedOrUnknown_False()
        {
            var dispatcher = CreateDispatcherWithoutCtor();

            string getStatus = @"{""method"":""kb"",""action"":""GetIndexStatus""}";
            string getState = @"{""method"":""kb"",""action"":""GetIndexState""}";
            string unknown = @"{""method"":""kb"",""action"":""Open""}";
            string malformed = @"{""method"":""kb"",";

            Assert.True(dispatcher.IsThreadSafe(getStatus));
            Assert.True(dispatcher.IsThreadSafe(getState));
            Assert.False(dispatcher.IsThreadSafe(unknown));
            Assert.False(dispatcher.IsThreadSafe(malformed));
        }

        [Fact]
        public void AppendInlineReadsCore_SearchSource_DedupesByObjectName()
        {
            string response = new JObject
            {
                ["hits"] = new JArray
                {
                    new JObject { ["objectName"] = "ProcA", ["type"] = "Procedure" },
                    new JObject { ["objectName"] = "ProcA", ["type"] = "Procedure" },
                    new JObject { ["objectName"] = "ProcB", ["type"] = "Procedure" }
                }
            }.ToString();

            string merged = CommandDispatcher.AppendInlineReadsCore(
                response,
                n: 3,
                reader: (name, type) => new JObject { ["name"] = name, ["kind"] = type }.ToString(),
                arrayKey: "hits",
                nameField: "objectName",
                dedupe: true);

            var json = JObject.Parse(merged);
            var inlineReads = Assert.IsType<JArray>(json["inline_reads"]);
            Assert.Equal(2, inlineReads.Count);

            var names = inlineReads
                .OfType<JObject>()
                .Select(x => x["name"]?.ToString())
                .ToArray();

            Assert.Equal(new[] { "ProcA", "ProcB" }, names);
        }

        private static CommandDispatcher CreateDispatcherWithoutCtor()
            => (CommandDispatcher)FormatterServices.GetUninitializedObject(typeof(CommandDispatcher));
    }
}
