using System;
using Xunit;

namespace GxMcp.Worker.Tests
{
    // Conditionally-skipped fact for tests that require a live GeneXus install with
    // an open KB and (depending on the pattern) a WorkWithPlus license. CI does not
    // set GXMCP_TEST_KB, so these are skipped by default; setting the env var to the
    // KB folder path opts in to running the integration smoke locally.
    //
    // Optional: GXMCP_REQUIRE_WWP=1 additionally guards WWP-licensed tests, so a
    // KB-only contributor can still run non-WWP integration tests without seeing
    // licensing failures.
    public sealed class LiveKbFactAttribute : FactAttribute
    {
        public LiveKbFactAttribute(bool requiresWWP = false)
        {
            string kb = Environment.GetEnvironmentVariable("GXMCP_TEST_KB");
            if (string.IsNullOrEmpty(kb))
            {
                Skip = "GXMCP_TEST_KB env var not set — set to a KB folder path to run live integration tests.";
                return;
            }
            if (requiresWWP)
            {
                string wwp = Environment.GetEnvironmentVariable("GXMCP_REQUIRE_WWP");
                if (string.IsNullOrEmpty(wwp) || wwp == "0")
                {
                    Skip = "GXMCP_REQUIRE_WWP not set — set to 1 to run WorkWithPlus-licensed integration tests.";
                }
            }
        }
    }
}
