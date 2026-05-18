using System.Collections.Generic;
using Xunit;

namespace GxMcp.Gateway.Tests
{
    public class McpDiscoveryContractTests
    {
        public static IEnumerable<object[]> DiscoveryCases =>
            new[]
            {
                new object[] { "initialize.request.json" },
                new object[] { "tools-list.request.json" },
                new object[] { "resources-list.request.json" }
            };

        [Theory]
        [MemberData(nameof(DiscoveryCases))]
        public void DiscoverySurface_ShouldMatchGolden(string requestFixtureRelativePath)
        {
            ContractGoldenHarness.AssertMatchesGolden(requestFixtureRelativePath);
        }
    }
}
