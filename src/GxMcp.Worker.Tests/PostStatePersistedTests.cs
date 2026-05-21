using GxMcp.Worker.Services;
using Newtonsoft.Json.Linq;
using Xunit;

namespace GxMcp.Worker.Tests
{
    /// <summary>
    /// v2.6.6 FR#12 — return_post_state must reflect persisted bytes, not the
    /// in-memory write buffer. The v2.6.4 regression captured the buffer BEFORE
    /// the SDK commit flushed and emitted slices[].content as empty.
    /// </summary>
    public class PostStatePersistedTests
    {
        [Fact]
        public void BuildPostState_WithPersistedAfter_SlicesReflectPersisted()
        {
            string before = "old\nstuff\n";
            string after = "new\nstuff\n";
            string persisted = "new\nstuff\n"; // bytes that landed on disk
            var ps = JsonPatchService.BuildPostState(before, after, verbose: true, persistedAfter: persisted);
            var slices = ps["slices"] as JArray;
            Assert.NotNull(slices);
            Assert.Single(slices);
            Assert.Equal(persisted, slices[0]["content"]?.ToString());
            Assert.Equal("persisted", slices[0]["source"]?.ToString());
            Assert.NotNull(ps["persistedAfterHash"]);
            Assert.StartsWith("sha256:", ps["persistedAfterHash"].ToString());
        }

        [Fact]
        public void BuildPostState_WithPersistedAfter_NotEmpty_RegressionFromV264()
        {
            // Direct regression for the v2.6.4 bug: a successful save returned
            // slices[].content = "" because the in-memory buffer was read before
            // the SDK commit. With persistedAfter passed, the slice content must
            // never be empty when persisted content exists.
            string after = "successful\nedit\n";
            string persisted = "successful\nedit\n";
            var ps = JsonPatchService.BuildPostState("", after, verbose: true, persistedAfter: persisted);
            var slices = ps["slices"] as JArray;
            Assert.NotNull(slices);
            string sliceContent = slices[0]["content"]?.ToString();
            Assert.False(string.IsNullOrEmpty(sliceContent),
                "post_state slices[].content must be populated from persisted bytes on successful save (FR#12).");
        }

        [Fact]
        public void BuildPostState_PersistedAfterDiffersFromBuffer_SliceUsesPersisted()
        {
            // The SDK sometimes normalizes content on save (CRLF folding, trailing
            // whitespace, attribute reordering). The slice MUST reflect what's on
            // disk so callers see the truth, not the pre-normalization input.
            string after = "Name : NUMERIC(4,0)\n";
            string persistedNormalized = "Name : NUMERIC(4)\n";
            var ps = JsonPatchService.BuildPostState("", after, verbose: true, persistedAfter: persistedNormalized);
            var slices = ps["slices"] as JArray;
            Assert.Equal(persistedNormalized, slices[0]["content"]?.ToString());
        }

        [Fact]
        public void BuildPostState_NullPersistedAfter_FallsBackToInMemoryAfter()
        {
            // Backwards compat: callers that didn't re-read still get the legacy
            // in-memory after value (no breaking change).
            var ps = JsonPatchService.BuildPostState("a", "b", verbose: true, persistedAfter: null);
            var slices = ps["slices"] as JArray;
            Assert.Equal("b", slices[0]["content"]?.ToString());
            Assert.Null(slices[0]["source"]);
            Assert.Null(ps["persistedAfterHash"]);
        }

        [Fact]
        public void BuildPostState_PersistedAfterHash_MatchesComputeSha256OfRead()
        {
            // The hash advertised under post_state.persistedAfterHash must be the
            // SHA256 of the same bytes a fresh genexus_read of the part would
            // return — otherwise verification across calls is meaningless.
            string persisted = "line1\nline2\n";
            var ps = JsonPatchService.BuildPostState("", "x", verbose: true, persistedAfter: persisted);
            string advertised = ps["persistedAfterHash"]?.ToString();
            string recomputed = WriteService.ComputeSha256(persisted);
            Assert.Equal(recomputed, advertised);
        }

        [Fact]
        public void BuildPostState_LegacyTwoArgOverload_StillWorks()
        {
            // Existing call sites that didn't migrate must keep their behavior.
            var ps = JsonPatchService.BuildPostState("a", "b", verbose: true);
            var slices = ps["slices"] as JArray;
            Assert.NotNull(slices);
            Assert.Equal("b", slices[0]["content"]?.ToString());
        }
    }
}
