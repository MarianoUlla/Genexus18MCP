using System.Collections.Generic;
using System.Linq;
using GxMcp.Worker.Helpers;
using Xunit;

namespace GxMcp.Worker.Tests
{
    /// <summary>
    /// v2.6.6 Stream C FR#23 — collapse repeating MSBuild/GeneXus warnings into
    /// per-code groups so the agent sees N×spc0022 as one row, not 12 separate
    /// lines that blow the token budget.
    /// </summary>
    public class WarningAggregationTests
    {
        [Fact]
        public void AggregateWarnings_MixedCodes_GroupsByCodeSortedDesc()
        {
            // Arrange — 12 spc0022, 8 spc0158, 5 CS0246 from realistic-looking GX object names.
            var warnings = new List<string>();
            for (int i = 0; i < 12; i++)
                warnings.Add("warning spc0022: Attribute X not referenced in object 'Trn" + i + "'");
            for (int i = 0; i < 8; i++)
                warnings.Add("warning spc0158: Deprecated call in object 'Proc" + i + "'");
            for (int i = 0; i < 5; i++)
                warnings.Add("warning CS0246: The type or namespace 'ws' could not be found in object 'WebP" + i + "'");

            // Act
            var groups = BuildOutputShaper.AggregateWarnings(warnings);

            // Assert — exactly 3 codes, sorted by count desc.
            Assert.Equal(3, groups.Count);
            Assert.Equal("spc0022", groups[0].code);
            Assert.Equal(12, groups[0].count);
            Assert.Equal("spc0158", groups[1].code);
            Assert.Equal(8, groups[1].count);
            Assert.Equal("cs0246", groups[2].code);
            Assert.Equal(5, groups[2].count);
        }

        [Fact]
        public void AggregateWarnings_Sample_IsFirstOccurrenceOfCode()
        {
            // Arrange
            var warnings = new List<string>
            {
                "warning spc0022: first sample in object 'TrnAlpha'",
                "warning spc0022: second occurrence in object 'TrnBeta'",
                "warning spc0022: third occurrence in object 'TrnGamma'"
            };

            // Act
            var groups = BuildOutputShaper.AggregateWarnings(warnings);

            // Assert
            Assert.Single(groups);
            Assert.Equal("warning spc0022: first sample in object 'TrnAlpha'", groups[0].sample);
            Assert.Equal(3, groups[0].count);
        }

        [Fact]
        public void AggregateWarnings_Objects_PreserveUniqueGxNamesAcrossOccurrences()
        {
            // Arrange — each line embeds a different GX object name via the
            // "in object 'X'" / "on object 'Y'" patterns the shaper recognizes.
            var warnings = new List<string>
            {
                "warning spc0022: foo in object 'TrnAlpha'",
                "warning spc0022: foo in object 'TrnBeta'",
                "warning spc0022: foo in object 'TrnAlpha'", // duplicate — should not appear twice
                "warning spc0022: foo on object 'TrnGamma'"
            };

            // Act
            var groups = BuildOutputShaper.AggregateWarnings(warnings);

            // Assert
            Assert.Single(groups);
            var objects = groups[0].objects;
            Assert.Equal(3, objects.Count);
            Assert.Contains("TrnAlpha", objects);
            Assert.Contains("TrnBeta", objects);
            Assert.Contains("TrnGamma", objects);
        }

        [Fact]
        public void AggregateWarnings_NullOrEmpty_ReturnsEmptyList()
        {
            // Arrange + Act
            var fromNull = BuildOutputShaper.AggregateWarnings(null);
            var fromEmpty = BuildOutputShaper.AggregateWarnings(new List<string>());

            // Assert
            Assert.Empty(fromNull);
            Assert.Empty(fromEmpty);
        }

        [Fact]
        public void AggregateWarnings_UncodedWarning_BucketsIntoUncodedGroup()
        {
            // Arrange — lines without a recognized code (no spc/gen/CS/MSB prefix)
            // bucket into a single "(uncoded)" group so they aren't silently dropped.
            var warnings = new List<string>
            {
                "warning : something fuzzy happened in object 'TrnX'",
                "warning : another fuzzy thing in object 'TrnY'"
            };

            // Act
            var groups = BuildOutputShaper.AggregateWarnings(warnings);

            // Assert
            Assert.Single(groups);
            Assert.Equal("(uncoded)", groups[0].code);
            Assert.Equal(2, groups[0].count);
        }
    }
}
