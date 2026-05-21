using System.Collections.Generic;
using GxMcp.Worker.Helpers;
using Newtonsoft.Json.Linq;
using Xunit;

namespace GxMcp.Worker.Tests
{
    // FR#16 (Stream G, v2.6.6) — GxFormDriver parses a GX-rendered WebPanel
    // HTML snapshot and emits ready-to-paste JS for fill / click. These tests
    // drive the driver against a synthetic dani.aspx-shaped fragment so the
    // parser + selector resolution + script builders are exercised without a
    // real browser.
    public class GxFormDriverTests
    {
        // Representative GeneXus-generated HTML — covers FormCaption, three
        // typed inputs (with gx-FullName), and an anchor whose href fires
        // gx.evt.execLink('Confirm', ...). Hand-trimmed from a dani.aspx
        // snapshot so casing/attribute order matches a real GX skin.
        private const string SampleHtml = @"
<html><body>
<form action=""dani.aspx"" method=""post"" id=""MAINFORM"">
  <div class=""gx_FormCaption"">Aluno - Consulta</div>
  <table>
    <tr><td>
      <input id=""vALUCOD"" name=""vALUCOD"" type=""text""
             gx-FullName=""AluCod"" gx-Format=""Z(9)9""
             gx-MaxLength=""10"" gx-Required=""true"" value="""" />
    </td></tr>
    <tr><td>
      <input id=""vALUNOME"" name=""vALUNOME"" type=""text""
             gx-FullName=""AluNome"" gx-Format="""" gx-MaxLength=""80""
             gx-Required=""false"" value="""" />
    </td></tr>
    <tr><td>
      <select id=""vSITUACAO"" name=""vSITUACAO"" gx-FullName=""Situacao"">
        <option value=""A"">Ativo</option>
        <option value=""I"">Inativo</option>
      </select>
    </td></tr>
    <tr><td>
      <a id=""BTNCONFIRM"" name=""BTNCONFIRM""
         href=""javascript:gx.evt.execLink('Confirm', [], [], '', 0, '', 0)"">
        Confirmar</a>
      <button id=""BTNCANCEL"" onclick=""executeServerEvent('Cancel');"">Cancelar</button>
    </td></tr>
  </table>
</form>
</body></html>
";

        [Fact]
        public void Parse_DiscoversFormCaptionInputsAndClickables()
        {
            var d = GxFormDriver.Parse(SampleHtml);

            Assert.Equal("dani.aspx", d.FormAction);
            Assert.Equal("Aluno - Consulta", d.FormCaption);
            Assert.Equal(3, d.Inputs.Count);

            // FullName selectors should be preferred over raw ids.
            var aluCod = d.Inputs.Find(i => i.FullName == "AluCod");
            Assert.NotNull(aluCod);
            Assert.Equal("vALUCOD", aluCod.Id);
            Assert.Equal("[gx-fullname=\"AluCod\"]", aluCod.Selector);
            Assert.True(aluCod.Required);

            // Two clickables (Confirm via execLink + Cancel via executeServerEvent).
            Assert.Equal(2, d.Clickables.Count);
            var confirm = d.Clickables.Find(c => c.Event == "Confirm");
            Assert.NotNull(confirm);
            Assert.Equal("#BTNCONFIRM", confirm.Selector);
        }

        [Fact]
        public void BuildFillScript_ResolvesKnownAttrsAndReportsMisses()
        {
            var d = GxFormDriver.Parse(SampleHtml);

            var values = new Dictionary<string, string>
            {
                ["&AluCod"] = "12345",      // leading & must be trimmed
                ["AluNome"] = "MARIA SILVA",
                ["NaoExiste"] = "X"         // miss → error path
            };
            var js = d.BuildFillScript(values, out var errors);

            // One unresolved key → single entry on errors list.
            Assert.Single(errors);
            Assert.Contains("NaoExiste", errors[0]);

            // Resolved selectors must appear in the emitted JS, miss must be
            // recorded into r.err on the browser side.
            Assert.Contains("[gx-fullname=\\\"AluCod\\\"]", js);
            Assert.Contains("\"MARIA SILVA\"", js);
            Assert.Contains("r.err.push(\"NaoExiste\")", js);

            // The script must always self-wrap so chrome-devtools-axi can eval it
            // as an expression and read back the JSON result.
            Assert.StartsWith("(function(){", js);
            Assert.EndsWith("})()", js);
        }

        [Fact]
        public void BuildClickScript_PrefersExecLinkAndFallsBackToMatchedSelector()
        {
            var d = GxFormDriver.Parse(SampleHtml);
            string js = d.BuildClickScript("Confirm");

            // execLink path
            Assert.Contains("window.gx.evt.execLink(\"Confirm\"", js);
            // matched clickable's selector is the fallback
            Assert.Contains("\"#BTNCONFIRM\"", js);
        }

        [Fact]
        public void ResolveSelector_VConventionAndIdFallback()
        {
            var d = GxFormDriver.Parse(SampleHtml);

            // Stripping & + uppercase id convention (vALUCOD).
            string sel1 = d.ResolveSelector("&AluCod", out var e1);
            Assert.Null(e1);
            Assert.Equal("[gx-fullname=\"AluCod\"]", sel1);

            // Unknown attr — error filled, selector null.
            string sel2 = d.ResolveSelector("Nope", out var e2);
            Assert.Null(sel2);
            Assert.False(string.IsNullOrEmpty(e2));
        }
    }
}
