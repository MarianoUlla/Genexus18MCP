using System;
using System.Linq;
using Xunit;
using GxMcp.Worker.Helpers;

namespace GxMcp.Worker.Tests
{
    public class LayoutGotchaScannerTests
    {
        // FR#1 (friction-report 2026-05-19): gxButton custom OnClickEvent in Form type="html"
        // compiles clean but the HTML generator wires data-gx-evt=5 (Enter) regardless. Scanner
        // must surface a warning so the agent doesn't waste a build cycle discovering this.
        [Fact]
        public void Scan_GxButtonCustomEventInHtmlForm_EmitsWarning()
        {
            var xml = @"<GxMultiForm>
                <Form id=""1"" type=""html"">
                    <gxButton id=""BtnFoo"" caption=""Foo"" OnClickEvent=""'DoFoo'"" />
                </Form>
            </GxMultiForm>";
            var hits = LayoutGotchaScanner.Scan(xml, _ => null, _ => false);
            Assert.Single(hits);
            Assert.Equal("GotchaGxButtonHtmlFormCustomEvent", hits[0].Code);
            Assert.Equal("Warning", hits[0].Severity);
            Assert.Equal("BtnFoo", hits[0].ControlId);
            Assert.Contains("DoFoo", hits[0].Message);
            Assert.Contains("Enter", hits[0].Message);
            Assert.NotNull(hits[0].Workaround);
        }

        [Fact]
        public void Scan_GxButtonEnterEvent_NoWarning()
        {
            // Enter (and Cancel / Refresh) are the only events the generator wires, so they are
            // legitimate values — don't warn.
            var xml = @"<GxMultiForm>
                <Form id=""1"" type=""html"">
                    <gxButton id=""BtnConfirm"" caption=""Confirm"" eventGX=""'Enter'"" />
                </Form>
            </GxMultiForm>";
            var hits = LayoutGotchaScanner.Scan(xml, _ => null, _ => false);
            Assert.Empty(hits);
        }

        [Fact]
        public void Scan_GxButtonCustomEventInLayoutForm_NoWarning()
        {
            // Form type="layout" supports <action onClickEvent> with custom events. We only flag
            // gxButton inside html forms.
            var xml = @"<GxMultiForm>
                <Form id=""2"" type=""layout"">
                    <gxButton id=""BtnFoo"" caption=""Foo"" OnClickEvent=""'DoFoo'"" />
                </Form>
            </GxMultiForm>";
            var hits = LayoutGotchaScanner.Scan(xml, _ => null, _ => false);
            Assert.Empty(hits);
        }

        // FR#2 (friction-report 2026-05-19): gxAttribute Radio/Combo bound to a local variable
        // whose name matches a transaction attribute renders disabled even with ReadOnly="False".
        // Scanner surfaces a warning when both conditions match.
        [Fact]
        public void Scan_GxAttributeRadioShadowingTrnAttribute_EmitsWarning()
        {
            var xml = @"<GxMultiForm>
                <Form id=""1"" type=""html"">
                    <gxAttribute AttID=""var:8"" ControlType=""Radio Button"" ReadOnly=""False"" />
                </Form>
            </GxMultiForm>";
            // var:8 → &Alu2RegProf, and Alu2RegProf exists as a transaction attribute in the KB.
            var hits = LayoutGotchaScanner.Scan(
                xml,
                attId => attId == "var:8" ? "Alu2RegProf" : null,
                name => name == "Alu2RegProf");
            Assert.Single(hits);
            Assert.Equal("GotchaGxAttributeShadowReadOnly", hits[0].Code);
            Assert.Contains("Alu2RegProf", hits[0].Message);
            Assert.Contains("Radio Button", hits[0].Message);
            Assert.Contains("Resp", hits[0].Workaround);
        }

        [Fact]
        public void Scan_GxAttributeRadioNoShadowing_NoWarning()
        {
            var xml = @"<GxMultiForm>
                <Form id=""1"" type=""html"">
                    <gxAttribute AttID=""var:99"" ControlType=""Radio Button"" />
                </Form>
            </GxMultiForm>";
            var hits = LayoutGotchaScanner.Scan(
                xml,
                attId => attId == "var:99" ? "MyLocalVar" : null,
                name => false); // no shadowing
            Assert.Empty(hits);
        }

        [Fact]
        public void Scan_GxAttributeTextInputShadowing_NoWarning()
        {
            // Text input (default ControlType) is unaffected by the shadow issue. Only Radio /
            // Combo render disabled.
            var xml = @"<GxMultiForm>
                <Form id=""1"" type=""html"">
                    <gxAttribute AttID=""var:9"" ReadOnly=""False"" />
                </Form>
            </GxMultiForm>";
            var hits = LayoutGotchaScanner.Scan(
                xml,
                attId => attId == "var:9" ? "Alu2NumRegProf" : null,
                name => true); // shadows but text input is fine
            Assert.Empty(hits);
        }

        [Fact]
        public void Scan_EmptyOrInvalidXml_ReturnsEmpty()
        {
            Assert.Empty(LayoutGotchaScanner.Scan("", _ => null, _ => false));
            Assert.Empty(LayoutGotchaScanner.Scan(null, _ => null, _ => false));
            Assert.Empty(LayoutGotchaScanner.Scan("<not closed", _ => null, _ => false));
        }
    }
}
