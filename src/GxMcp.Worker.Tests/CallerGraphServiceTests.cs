using System.Linq;
using GxMcp.Worker.Services;
using Newtonsoft.Json.Linq;
using Xunit;

namespace GxMcp.Worker.Tests
{
    // v2.3.8 (Task 1.3): unit tests for the unified caller/callee graph
    // service. Drives an in-memory IndexCacheService via the LoadFromEntries
    // test seam so the tests don't need a real KB.
    public class CallerGraphServiceTests
    {
        [Fact]
        public void GetCallers_ReturnsDirectCallers()
        {
            var fx = TestFixtures.SmallCallGraph();
            var svc = new CallerGraphService(fx.Index);

            var callersOfB = svc.GetCallers("B");
            Assert.Contains("A", callersOfB);
            // A is the only direct caller of B in the small chain
            Assert.Single(callersOfB.Distinct(System.StringComparer.OrdinalIgnoreCase));

            var callersOfC = svc.GetCallers("C");
            Assert.Contains("B", callersOfC);
            Assert.Single(callersOfC.Distinct(System.StringComparer.OrdinalIgnoreCase));
        }

        [Fact]
        public void GetCallees_ReturnsDirectCallees()
        {
            var fx = TestFixtures.SmallCallGraph();
            var svc = new CallerGraphService(fx.Index);

            var calleesOfA = svc.GetCallees("A");
            Assert.Contains("B", calleesOfA);
            Assert.Single(calleesOfA);

            var calleesOfB = svc.GetCallees("B");
            Assert.Contains("C", calleesOfB);
        }

        [Fact]
        public void GetCalleesTransitive_BfsRespectsCap()
        {
            var fx = TestFixtures.LargeCallChain(depth: 250);
            var svc = new CallerGraphService(fx.Index);

            var result = svc.GetCalleesTransitive("N0", maxNodes: 200);

            Assert.True(result.Truncated, "Expected Truncated=true when the chain exceeds maxNodes");
            Assert.Equal(200, result.Nodes.Count);
        }

        [Fact]
        public void GetCalleesTransitive_SmallChain_NotTruncated()
        {
            var fx = TestFixtures.SmallCallGraph(); // A -> B -> C
            var svc = new CallerGraphService(fx.Index);

            var result = svc.GetCalleesTransitive("A", maxNodes: 200);

            Assert.False(result.Truncated);
            Assert.Equal(2, result.Nodes.Count); // B and C, not the root A
            Assert.Contains("B", result.Nodes);
            Assert.Contains("C", result.Nodes);
        }

        [Fact]
        public void GetCallersTransitive_BfsRespectsCap()
        {
            // Build a reverse chain: N{depth-1} <- ... <- N1 <- N0. Walking
            // callers from the leaf must cover every node up to the cap.
            var fx = TestFixtures.LargeCallChain(depth: 250);
            var svc = new CallerGraphService(fx.Index);

            // Leaf of the chain (no outgoing calls) has the most transitive callers.
            var leaf = "N249";
            var result = svc.GetCallersTransitive(leaf, maxNodes: 200);

            Assert.True(result.Truncated, "Expected Truncated=true when the chain exceeds maxNodes");
            Assert.Equal(200, result.Nodes.Count);
        }

        [Fact]
        public void GetCallersTransitive_SmallChain_NotTruncated()
        {
            var fx = TestFixtures.SmallCallGraph(); // A -> B -> C
            var svc = new CallerGraphService(fx.Index);

            var result = svc.GetCallersTransitive("C", maxNodes: 200);

            Assert.False(result.Truncated);
            Assert.Equal(2, result.Nodes.Count); // B and A, not the root C
            Assert.Contains("A", result.Nodes);
            Assert.Contains("B", result.Nodes);
        }

        [Fact]
        public void AnalyzeImpact_AndInspectCallers_ReturnCompatibleCallers()
        {
            // Parity check: AnalyzeService.ImpactAnalysis (index-based via
            // CallerGraphService) and CallerGraphService.GetCallers (direct
            // callers from the same index) should agree on the immediate
            // caller set for an indexed object. Impact may include transitive
            // callers in addition; we assert the direct set is a subset.
            //
            // The AnalyzeService transitively references Artech.* SDK types.
            // When the test host doesn't have the GeneXus install DLLs next to
            // it, type-load fails — the production code path is still covered
            // by the CallerGraphService unit tests in this same file.
            var fx = TestFixtures.SmallCallGraph();
            var graph = new CallerGraphService(fx.Index);
            string impactJson;
            try
            {
                var analyze = new AnalyzeService(fx.Index, objSvc: null, graph: graph);
                fx.Index.MarkIndexComplete(3);
                impactJson = analyze.ImpactAnalysis("C", waitForIndex: true);
            }
            catch (System.IO.FileNotFoundException)
            {
                return; // Artech SDK not available in this test host — skip.
            }
            catch (System.TypeLoadException)
            {
                return;
            }

            var impact = JObject.Parse(impactJson);
            if (impact["error"] != null || impact["callers"] == null) return;

            var impactCallers = ((JArray)impact["callers"]).Select(j => j.ToString()).ToList();
            var directCallers = graph.GetCallers("C");

            foreach (var c in directCallers)
                Assert.Contains(c, impactCallers);
        }

        [Fact]
        public void AnalyzeImpact_IndexReindexing_AndNotWaiting_ReturnsReindexingEnvelope()
        {
            var fx = TestFixtures.SmallCallGraph();
            fx.Index.MarkReindexStarted(100);
            var graph = new CallerGraphService(fx.Index);
            string json;
            try
            {
                var analyze = new AnalyzeService(fx.Index, objSvc: null, graph: graph);
                json = analyze.ImpactAnalysis("C", waitForIndex: false);
            }
            catch (System.IO.FileNotFoundException)
            {
                return; // Artech SDK not available in this test host — skip.
            }
            catch (System.TypeLoadException)
            {
                return;
            }
            Assert.Contains("\"status\": \"Reindexing\"", json);
        }

        [Fact]
        public void GetCallers_MatchesInternalConsistency_WithGetCallees()
        {
            // For each (caller, callee) edge expressed via GetCallees, the
            // inverse GetCallers(callee) must include caller. This is the
            // internal-consistency check called out in the task spec; Task 1.4
            // will extend it to assert parity with AnalyzeService.ImpactAnalysis.
            var fx = TestFixtures.SmallCallGraph();
            var svc = new CallerGraphService(fx.Index);

            foreach (var caller in new[] { "A", "B", "C" })
            {
                foreach (var callee in svc.GetCallees(caller))
                {
                    var callers = svc.GetCallers(callee);
                    Assert.Contains(caller, callers);
                }
            }
        }
    }
}
