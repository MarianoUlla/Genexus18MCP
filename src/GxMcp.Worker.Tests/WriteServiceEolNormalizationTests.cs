using Xunit;
using GxMcp.Worker.Services;

namespace GxMcp.Worker.Tests
{
    public class WriteServiceEolNormalizationTests
    {
        const string CRLF = "\r\n";
        const string LF = "\n";

        [Fact]
        public void Replace_MultilineContext_MixedCrlf_Matches()
        {
            var source = "line1" + CRLF + "    Where IdAgenda = &IdAgenda" + CRLF +
                         "    Where ParecerFinal <> 3" + CRLF + CRLF +
                         "    &ListaIdsPareceres.Add(IdParecer)" + CRLF + "end";
            var ctxLF =
                "    Where IdAgenda = &IdAgenda" + LF +
                "    Where ParecerFinal <> 3" + LF + LF +
                "    &ListaIdsPareceres.Add(IdParecer)";
            var result = WriteService.TryMatch(source, ctxLF, out var startIdx, out var endIdx);
            Assert.True(result);
            Assert.True(startIdx >= 0);
            Assert.True(endIdx > startIdx);
        }

        [Fact]
        public void Replace_MultilineContext_TrailingWhitespace_Matches()
        {
            var source = "    Where ParecerFinal <> 3   \r\n    next line";
            var ctx = "    Where ParecerFinal <> 3\n    next line";
            var result = WriteService.TryMatch(source, ctx, out _, out _);
            Assert.True(result);
        }
    }
}
