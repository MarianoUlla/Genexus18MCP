using System.Linq;
using System.Text;
using GxMcp.Worker.Helpers;
using Xunit;

namespace GxMcp.Worker.Tests
{
    /// <summary>
    /// v2.6.6 Stream C FR#22 — MSBuild output shaping. The shaper caps the
    /// envelope to head + tail so a 200 KB build log never blows the JSON-RPC
    /// frame, while the full content is pinned to disk for retrieval.
    /// </summary>
    public class BuildOutputShaperTests
    {
        [Fact]
        public void Shape_LargeInput_ReturnsHeadTailHintAndCountsDroppedLines()
        {
            // Arrange — build a payload comfortably larger than HeadBytes + TailBytes
            // so the elided middle is non-empty and contains a known newline count.
            int headBytes = BuildOutputShaper.HeadBytes;
            int tailBytes = BuildOutputShaper.TailBytes;
            var sb = new StringBuilder();
            // Head padding (no newlines so dropped_lines comes solely from the middle).
            sb.Append('H', headBytes);
            // Middle slice — 500 single-character lines = 500 newlines.
            for (int i = 0; i < 500; i++) sb.Append("M\n");
            // Tail padding to push the total over the cap.
            sb.Append('T', tailBytes + 16);
            string full = sb.ToString();

            // Act
            var shaped = BuildOutputShaper.Shape(full, totalLines: 5000, fullLogPath: @"C:\logs\build-abc.log");

            // Assert
            Assert.Equal(headBytes, shaped.head.Length);
            Assert.Equal(tailBytes, shaped.tail.Length);
            Assert.Equal(500, shaped.dropped_lines);
            Assert.Equal(5000, shaped.total_lines);
            Assert.Equal(@"C:\logs\build-abc.log", shaped.full_log_path);
            Assert.Contains("build-abc.log", shaped.hint);
        }

        [Fact]
        public void Shape_SmallInput_ReturnsFullContentInHeadAndEmptyTail()
        {
            // Arrange — payload under the cap stays whole; nothing gets elided.
            string full = "line1\nline2\nline3\n";

            // Act
            var shaped = BuildOutputShaper.Shape(full, totalLines: 3, fullLogPath: "log.txt");

            // Assert
            Assert.Equal(full, shaped.head);
            Assert.Equal(string.Empty, shaped.tail);
            Assert.Equal(0, shaped.dropped_lines);
            Assert.Equal(3, shaped.total_lines);
            Assert.Equal("log.txt", shaped.full_log_path);
        }

        [Fact]
        public void Shape_BoundaryInput_AtExactCap_StillFitsInHead()
        {
            // Arrange — exactly HeadBytes + TailBytes characters should NOT be elided
            // (the implementation uses `<=` so the boundary is inclusive).
            int capBytes = BuildOutputShaper.HeadBytes + BuildOutputShaper.TailBytes;
            string full = new string('x', capBytes);

            // Act
            var shaped = BuildOutputShaper.Shape(full, totalLines: 1, fullLogPath: "log.txt");

            // Assert
            Assert.Equal(full, shaped.head);
            Assert.Equal(string.Empty, shaped.tail);
            Assert.Equal(0, shaped.dropped_lines);
        }

        [Fact]
        public void Shape_NullInput_ReturnsEmptyHeadAndTail()
        {
            // Arrange + Act
            var shaped = BuildOutputShaper.Shape(null, totalLines: 0, fullLogPath: "log.txt");

            // Assert
            Assert.Equal(string.Empty, shaped.head);
            Assert.Equal(string.Empty, shaped.tail);
            Assert.Equal(0, shaped.dropped_lines);
            Assert.Equal("log.txt", shaped.full_log_path);
        }

        [Fact]
        public void Shape_EmptyInput_ReturnsEmptyHeadAndTail()
        {
            // Arrange + Act
            var shaped = BuildOutputShaper.Shape(string.Empty, totalLines: 0, fullLogPath: null);

            // Assert
            Assert.Equal(string.Empty, shaped.head);
            Assert.Equal(string.Empty, shaped.tail);
            Assert.Equal(0, shaped.dropped_lines);
            // Null full_log_path is allowed; hint surfaces the placeholder.
            Assert.Null(shaped.full_log_path);
            Assert.Contains("<unavailable>", shaped.hint);
        }

        [Fact]
        public void Shape_FullLogPath_PassedThroughUnchanged()
        {
            // Arrange
            string path = @"D:\some\weird path\with spaces\build-xyz.log";

            // Act
            var shapedSmall = BuildOutputShaper.Shape("tiny", 1, path);
            var shapedLarge = BuildOutputShaper.Shape(new string('z', BuildOutputShaper.HeadBytes + BuildOutputShaper.TailBytes + 100), 999, path);

            // Assert
            Assert.Equal(path, shapedSmall.full_log_path);
            Assert.Equal(path, shapedLarge.full_log_path);
            Assert.Contains(path, shapedSmall.hint);
        }
    }
}
