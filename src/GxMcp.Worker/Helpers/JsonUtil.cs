using Newtonsoft.Json.Linq;

namespace GxMcp.Worker.Helpers
{
    public static class JsonUtil
    {
        /// Returns parsed JToken, or a JValue wrapping the raw string when parse fails.
        /// JValue.CreateNull() for null/empty input. Never throws.
        public static JToken SafeParse(string raw)
        {
            if (string.IsNullOrEmpty(raw)) return JValue.CreateNull();
            try { return JToken.Parse(raw); }
            catch { return new JValue(raw); }
        }
    }
}
