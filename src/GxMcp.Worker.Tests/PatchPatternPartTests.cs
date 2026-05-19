using GxMcp.Worker.Services;
using Newtonsoft.Json.Linq;
using Xunit;

namespace GxMcp.Worker.Tests
{
    // Patch-mode support for PatternInstance / PatternVirtual parts (WorkWithPlus
    // and other patterns). Live read+write requires an open KB and is exercised
    // by the integration smoke tests; here we cover what is reachable as a unit:
    //
    //   1. PatternAnalysisService.IsPatternPart is the gate ReadSourceFast uses
    //      before dispatching to ReadPatternPartXml. If this drifts, patch-mode
    //      silently regresses to the reflective fallback and fails again with
    //      "Part does not expose text source".
    //   2. The {find, replace} text engine handles pattern XML payloads (multi
    //      line, CDATA-ish, attribute-heavy) the same as any other source.
    public class PatchPatternPartTests
    {
        [Fact]
        public void IsPatternPart_RecognizesPatternInstanceAndVirtual()
        {
            Assert.True(PatternAnalysisService.IsPatternPart("PatternInstance"));
            Assert.True(PatternAnalysisService.IsPatternPart("patterninstance"));
            Assert.True(PatternAnalysisService.IsPatternPart("PatternVirtual"));
            Assert.False(PatternAnalysisService.IsPatternPart("Source"));
            Assert.False(PatternAnalysisService.IsPatternPart("Variables"));
            Assert.False(PatternAnalysisService.IsPatternPart(""));
            Assert.False(PatternAnalysisService.IsPatternPart(null));
        }

        [Fact]
        public void FindReplace_OverPatternXml_RewritesAttribute()
        {
            // Shape of an editable WWP pattern fragment (simplified). CRLF on
            // purpose: live SDK reads return CRLF and the test mirrors what
            // ApplyPatch will see after the new ReadSourceFast branch.
            var patternXml =
                "<Instance>\r\n" +
                "  <Settings>\r\n" +
                "    <Setting Name=\"Caption\" Value=\"Acao\" />\r\n" +
                "    <Setting Name=\"ConfirmOnDelete\" Value=\"False\" />\r\n" +
                "  </Settings>\r\n" +
                "</Instance>\r\n";

            var patch = new JObject
            {
                ["find"] = "<Setting Name=\"ConfirmOnDelete\" Value=\"False\" />",
                ["replace"] = "<Setting Name=\"ConfirmOnDelete\" Value=\"True\" />"
            };

            var (ok, result, _) = PatchService.ApplyFindReplace(patternXml, patch);
            Assert.True(ok);
            Assert.Contains("Value=\"True\"", result);
            Assert.DoesNotContain("Value=\"False\"", result);
        }

        [Fact]
        public void FindReplace_OverPatternXml_MultiLineContext_Succeeds()
        {
            var patternXml =
                "<Instance>\r\n" +
                "  <Selection>\r\n" +
                "    <Attribute Name=\"AcaoId\" />\r\n" +
                "    <Attribute Name=\"AcaoNome\" />\r\n" +
                "  </Selection>\r\n" +
                "</Instance>\r\n";

            var patch = new JObject
            {
                ["find"] = "<Attribute Name=\"AcaoId\" />\n    <Attribute Name=\"AcaoNome\" />",
                ["replace"] = "<Attribute Name=\"AcaoId\" />\n    <Attribute Name=\"AcaoNome\" />\n    <Attribute Name=\"AcaoDescricao\" />"
            };

            var (ok, result, _) = PatchService.ApplyFindReplace(patternXml, patch);
            Assert.True(ok);
            Assert.Contains("AcaoDescricao", result);
        }
    }
}
