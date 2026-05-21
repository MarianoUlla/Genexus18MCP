using System.Linq;
using System.Reflection;
using GxMcp.Worker.Services;
using Xunit;

namespace GxMcp.Worker.Tests
{
    /// <summary>
    /// v2.6.6 Stream C FR#21 — when MSBuild surfaces an error at the synthetic
    /// "GxBuild_xxx.msbuild(N,M)" location, the worker must rewrite the line to
    /// embed the actual GX object being processed + the current phase, so the
    /// agent gets an actionable target instead of a temp-file coordinate.
    /// </summary>
    public class GxObjectMappingTests
    {
        // HandleLine is private; route through reflection so the test exercises the
        // exact production path (status update + error capture + rewrite) without
        // requiring a real MSBuild process.
        private static void InvokeHandleLine(BuildService svc, BuildService.BuildTaskStatus status, string line, bool isError)
        {
            var mi = typeof(BuildService).GetMethod(
                "HandleLine",
                BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.NotNull(mi);
            mi.Invoke(svc, new object[] { status, line, isError });
        }

        [Fact]
        public void HandleLine_GxBuildLocation_RewritesToGxObjectPhaseTag()
        {
            // Arrange
            var svc = new BuildService();
            var status = new BuildService.BuildTaskStatus
            {
                TaskId = "test1234",
                CurrentObject = "MyTrn",
                Phase = "Specifying"
            };
            string raw = @"C:\Temp\GxBuild_abc.msbuild(5,5): error spc0022: missing X";

            // Act
            InvokeHandleLine(svc, status, raw, isError: true);

            // Assert — the captured error MUST be the rewritten form with the
            // gx-object + phase tag substituted for the temp msbuild location.
            Assert.Single(status.Errors);
            string captured = status.Errors[0];
            Assert.Contains("[gx-object=MyTrn phase=Specifying]", captured);
            Assert.DoesNotContain("GxBuild_abc.msbuild(5,5)", captured);
            Assert.Contains("error spc0022", captured);
        }

        [Fact]
        public void HandleLine_GxBuildLocation_ErrorsDetailed_KeepsRawAndRewritten()
        {
            // Arrange
            var svc = new BuildService();
            var status = new BuildService.BuildTaskStatus
            {
                TaskId = "test5678",
                CurrentObject = "ProcFoo",
                Phase = "Generating"
            };
            string raw = @"C:\Temp\GxBuild_xyz.msbuild(10,3): error CS0246: type missing";

            // Act
            InvokeHandleLine(svc, status, raw, isError: true);

            // Assert — ErrorsDetailed (FR#21) preserves both the raw MSBuild line
            // and the rewritten "[gx-object=... phase=...]" form for debugging.
            Assert.Single(status.ErrorsDetailed);
            var detail = status.ErrorsDetailed[0];
            Assert.Contains("GxBuild_xyz.msbuild(10,3)", detail.raw);
            Assert.Contains("[gx-object=ProcFoo phase=Generating]", detail.rewritten);
            Assert.Equal("ProcFoo", detail.gxObject);
            Assert.Equal("Generating", detail.phase);
        }

        [Fact]
        public void HandleLine_NonGxBuildErrorLine_PassesThroughUnchanged()
        {
            // Arrange — a "normal" error line without the GxBuild_*.msbuild marker
            // must NOT be rewritten; rewriting unrelated errors would lose location.
            var svc = new BuildService();
            var status = new BuildService.BuildTaskStatus
            {
                TaskId = "test9999",
                CurrentObject = "SomeObject",
                Phase = "Compiling"
            };
            string raw = @"C:\Project\Source.cs(42,17): error CS1001: Identifier expected";

            // Act
            InvokeHandleLine(svc, status, raw, isError: true);

            // Assert
            Assert.Single(status.Errors);
            Assert.Equal(raw.Trim(), status.Errors[0]);
            Assert.DoesNotContain("[gx-object=", status.Errors[0]);
        }
    }
}
