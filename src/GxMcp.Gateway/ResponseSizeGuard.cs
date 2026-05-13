using Newtonsoft.Json.Linq;
using System.Text;

namespace GxMcp.Gateway
{
    public class ResponseSizeGuard
    {
        public const int DefaultMaxBytes = 220_000; // ~55k tokens

        private readonly int _maxBytes;

        public ResponseSizeGuard(int maxBytes = DefaultMaxBytes) => _maxBytes = maxBytes;

        public (JObject result, bool truncated) Apply(JObject payload, string toolName, JObject args)
        {
            int size = Encoding.UTF8.GetByteCount(payload.ToString(Newtonsoft.Json.Formatting.None));
            if (size <= _maxBytes) return (payload, false);

            var sentinel = new JObject
            {
                ["_meta"] = new JObject
                {
                    ["truncated"] = new JObject
                    {
                        ["reason"] = "response_exceeded_cap",
                        ["original_size"] = size,
                        ["cap_bytes"] = _maxBytes,
                        ["follow_up"] = BuildFollowUp(toolName, args)
                    }
                }
            };

            Program.Log($"[Gateway] OVERSIZE tool={toolName} size={size}");
            return (sentinel, true);
        }

        private static JObject BuildFollowUp(string tool, JObject args)
        {
            var followArgs = args != null ? (JObject)args.DeepClone() : new JObject();
            followArgs["page"] = 1;
            followArgs["page_size"] = 25;
            return new JObject { ["tool"] = tool, ["args"] = followArgs };
        }
    }
}
