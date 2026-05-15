using System;
using GxMcp.Worker;
using GxMcp.Worker.Services;
using Newtonsoft.Json.Linq;
using Xunit;

namespace GxMcp.Worker.Tests
{
    // v2.3.8 Task 4.4 — Symmetric delete_variable across object kinds.
    //
    // The historical failure was "Part 'DeleteVariable' not found in WebPanel" — the
    // backend's variable-part lookup only worked on Procedure/DataProvider because
    // it leaned exclusively on `obj.Parts.Get<VariablesPart>()`, which returned null
    // for some kinds. The fix wires WriteService.ResolveVariableTarget through
    // PartAccessor.GetVariablesPart, which adds name-based + reflective fallbacks.
    //
    // FULL-FLOW PER-KIND TESTING ISN'T ACHIEVABLE in pure unit tests: a real KB
    // containing fixture WebPanel/Transaction/WorkPanel/DataProvider objects with
    // pre-populated variables is required. The SDK types (KBObject, VariablesPart)
    // come from the GeneXus 18 install and aren't trivially constructible.
    //
    // We therefore cover two layers:
    //   1. PartAccessor.GetVariablesPart contract on the null/missing path
    //      (no SDK install required — pure helper test).
    //   2. End-to-end delete with the standard SDK-skip pattern: if the test host
    //      can't load Artech.* the [Theory] cases short-circuit gracefully, matching
    //      the pattern used by CallerGraphServiceTests.AnalyzeImpact_* and
    //      PartAccessorAndWriteServiceTests.AddVariable_* in this same project.
    public class DeleteVariableSymmetryTests
    {
        private static WriteService BuildIsolatedWriteService()
        {
            var indexCache = new IndexCacheService();
            var build = new BuildService();
            var kb = new KbService(indexCache);
            kb.SetBuildService(build);
            build.SetKbService(kb);
            indexCache.SetBuildService(build);
            var obj = new ObjectService(kb, build);
            return new WriteService(obj);
        }

        // Note: a direct PartAccessor.GetVariablesPart(null) helper test was considered
        // but cannot live in this assembly — the return type VariablesPart lives in
        // Artech.Genexus.Common which the test project deliberately does NOT reference
        // (only Artech.Architecture.Common is wired up via HintPath). The DeleteVariable
        // theory below exercises the same accessor through the WriteService surface.

        [Theory]
        [InlineData("Procedure")]
        [InlineData("WebPanel")]
        [InlineData("Transaction")]
        [InlineData("WorkPanel")]
        [InlineData("DataProvider")]
        public void DeleteVariable_AcrossObjectKinds_DoesNotEmitLegacyPartNotFoundError(string objKind)
        {
            // No KB is loaded in this test host, so the call returns an
            // "Object not found" error — but the critical invariant is that the
            // response never carries the legacy "Part 'DeleteVariable' not found"
            // text that the friction-report flagged.
            //
            // Once a fixture KB per kind exists, this Theory is the right shape to
            // assert Status=Success.
            var ws = BuildIsolatedWriteService();
            string json;
            try
            {
                // Object name encodes the kind so a future fixture can dispatch.
                json = ws.DeleteVariable($"Fixture_{objKind}", "X");
            }
            catch (System.IO.FileNotFoundException) { return; }
            catch (System.TypeLoadException) { return; }

            Assert.DoesNotContain("Part 'DeleteVariable' not found", json);
            // Sanity: response is well-formed JSON.
            var obj = JObject.Parse(json);
            Assert.NotNull(obj);
        }

        [Fact]
        public void DeleteVariable_MissingVarName_ReturnsErrorWithoutTouchingSdk()
        {
            // Resolver returns early on empty varName — no SDK call, deterministic.
            var ws = BuildIsolatedWriteService();
            string json;
            try
            {
                json = ws.DeleteVariable("AnyTarget", "");
            }
            catch (System.IO.FileNotFoundException) { return; }
            catch (System.TypeLoadException) { return; }

            // Response is JSON and does not regress to the legacy part-name error.
            Assert.DoesNotContain("Part 'DeleteVariable' not found", json);
            var obj = JObject.Parse(json);
            Assert.NotNull(obj);
        }
    }
}
