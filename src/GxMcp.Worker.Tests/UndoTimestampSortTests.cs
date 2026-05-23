using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Xunit;

namespace GxMcp.Worker.Tests
{
    /// <summary>
    /// Snapshot files live as <c>&lt;guid&gt;-&lt;part&gt;-&lt;yyyyMMddTHHmmssfffZ&gt;.bak</c>.
    /// Ordinal sort of the full filename is dominated by the leading guid, so
    /// the "N most recent" undo selection used to silently pick GUID-buckets
    /// instead of the actually-newest timestamps. The fix sorts by the
    /// timestamp segment via ExtractSnapshotTimestamp.
    /// </summary>
    public class UndoTimestampSortTests
    {
        [Fact]
        public void ExtractSnapshotTimestamp_ParsesTimestampSegment()
        {
            // ExtractSnapshotTimestamp is private static — reach in via reflection
            // (it's a parser helper; pure function over the filename string).
            var mi = typeof(GxMcp.Worker.Services.UndoService)
                .GetMethod("ExtractSnapshotTimestamp", BindingFlags.Static | BindingFlags.NonPublic);
            Assert.NotNull(mi);

            string a = (string)mi!.Invoke(null, new object[] { @"C:\kb\.gx\snapshots\AAAAGUID-Source-20260101T120000000Z.bak" })!;
            string b = (string)mi.Invoke(null, new object[] { @"C:\kb\.gx\snapshots\BBBBGUID-Source-20260101T120500000Z.bak.gz" })!;

            Assert.Equal("20260101T120000000Z", a);
            Assert.Equal("20260101T120500000Z", b);
            Assert.True(string.CompareOrdinal(b, a) > 0, "b is later, must sort greater");
        }

        [Fact]
        public void ExtractSnapshotTimestamp_FallsBackToFilename_OnUnexpectedShape()
        {
            var mi = typeof(GxMcp.Worker.Services.UndoService)
                .GetMethod("ExtractSnapshotTimestamp", BindingFlags.Static | BindingFlags.NonPublic);
            string fallback = (string)mi!.Invoke(null, new object[] { "weirdname.bak" })!;
            Assert.Equal("weirdname", fallback);
        }

        [Fact]
        public void SortPicksLatestTimestamp_NotLargestGuid()
        {
            var mi = typeof(GxMcp.Worker.Services.UndoService)
                .GetMethod("ExtractSnapshotTimestamp", BindingFlags.Static | BindingFlags.NonPublic);
            string[] files =
            {
                @"snap\ZZZZGUID-Source-20260101T100000000Z.bak",   // largest guid but oldest
                @"snap\AAAAGUID-Source-20260101T120000000Z.bak",   // smallest guid but newest
                @"snap\MMMMGUID-Source-20260101T110000000Z.bak",
            };
            var ordered = files
                .OrderByDescending(p => (string)mi!.Invoke(null, new object[] { p })!, StringComparer.Ordinal)
                .ToList();
            Assert.EndsWith("100000000Z.bak", ordered[2]); // oldest is last
            Assert.EndsWith("120000000Z.bak", ordered[0]); // newest is first — would be wrong under path sort
        }
    }
}
