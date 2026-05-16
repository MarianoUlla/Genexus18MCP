using GxMcp.Worker.Services;
using Xunit;

namespace GxMcp.Worker.Tests
{
    public class IndexStateTransitionTests
    {
        private static IndexCacheService NewService()
        {
            return new IndexCacheService();
        }

        [Fact]
        public void MarkLitePassComplete_TransitionsToLiteReady()
        {
            var cache = NewService();
            cache.MarkReindexStarted(100);
            cache.MarkLitePassComplete(100);

            Assert.Equal("LiteReady", cache.GetState().Status);
        }

        [Fact]
        public void MarkEnrichmentStarted_TransitionsToEnriching()
        {
            var cache = NewService();
            cache.MarkLitePassComplete(100);
            cache.MarkEnrichmentStarted();

            Assert.Equal("Enriching", cache.GetState().Status);
        }

        [Fact]
        public void MarkIndexComplete_FromEnriching_TransitionsToReady()
        {
            var cache = NewService();
            cache.MarkLitePassComplete(100);
            cache.MarkEnrichmentStarted();
            cache.MarkIndexComplete(100);

            Assert.Equal("Ready", cache.GetState().Status);
        }
    }
}
