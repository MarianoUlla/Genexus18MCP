using GxMcp.Worker.Helpers;
using System.Linq;
using Xunit;

namespace GxMcp.Worker.Tests
{
    public class RuntimeIdParserTests
    {
        [Fact]
        public void ParseSource_ExtractsInternalnameAssignments()
        {
            string cs = @"
                protected GXButton BtnConfirmar;
                protected GXGroup GrpNumRegProf;
                protected GXAttribute vNumRegProf;
                public void InitializeDynEvents() {
                    this.BtnConfirmar._Internalname = ""BTT58"";
                    this.GrpNumRegProf._Internalname = ""GRPNUMREGPROF"";
                    this.vNumRegProf._Internalname = ""vNUMREGPROF"";
                }
            ";
            var entries = RuntimeIdParser.ParseSource(cs);
            Assert.Equal(3, entries.Count);

            var btn = entries.First(e => e.DesignId == "BtnConfirmar");
            Assert.Equal("BTT58", btn.HtmlId);
            Assert.Equal("gxButton", btn.Kind, ignoreCase: true);

            var grp = entries.First(e => e.DesignId == "GrpNumRegProf");
            Assert.Equal("GRPNUMREGPROF", grp.HtmlId);
        }

        [Fact]
        public void ParseSource_NullOrEmpty_ReturnsEmpty()
        {
            Assert.Empty(RuntimeIdParser.ParseSource(null));
            Assert.Empty(RuntimeIdParser.ParseSource(""));
        }

        [Fact]
        public void ParseSource_NoInternalnameLines_ReturnsEmpty()
        {
            string cs = @"public class Foo { void Bar() { var x = 1; } }";
            Assert.Empty(RuntimeIdParser.ParseSource(cs));
        }

        [Fact]
        public void ParseSource_HiddenFieldType_FlagsHiddenTrue()
        {
            string cs = @"
                protected GXHidden vSomeHidden;
                public void Init() { this.vSomeHidden._Internalname = ""vSOMEHIDDEN""; }
            ";
            var entries = RuntimeIdParser.ParseSource(cs);
            var hit = Assert.Single(entries);
            Assert.True(hit.Hidden ?? false);
        }
    }
}
