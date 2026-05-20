using System.Collections.Generic;
using GxMcp.Worker.Helpers;
using Xunit;

namespace GxMcp.Worker.Tests
{
    public class DomainPropertyApplierTests
    {
        // Fake Domain mirroring the public surface DomainPropertyApplier writes to.
        // Type:string mirrors the test-fake path (eDBType enum on the real SDK).
        public class FakeDomain
        {
            public string Type { get; set; }
            public int Length { get; set; }
            public int Decimals { get; set; }
            public bool Signed { get; set; }
            public object DomainBasedOn { get; set; }
        }

        [Fact]
        public void ApplyPrimitive_SetsTypeLengthDecimalsSigned()
        {
            var d = new FakeDomain();
            bool ok = DomainPropertyApplier.ApplyPrimitive(d, "Character", length: 10, decimals: null, signed: null);
            Assert.True(ok);
            Assert.Equal("CHARACTER", d.Type);
            Assert.Equal(10, d.Length);
        }

        [Fact]
        public void ApplyPrimitive_NumericWithDecimalsAndSigned()
        {
            var d = new FakeDomain();
            bool ok = DomainPropertyApplier.ApplyPrimitive(d, "Numeric", length: 12, decimals: 2, signed: true);
            Assert.True(ok);
            Assert.Equal("NUMERIC", d.Type);
            Assert.Equal(12, d.Length);
            Assert.Equal(2, d.Decimals);
            Assert.True(d.Signed);
        }

        [Fact]
        public void ApplyPrimitive_UnknownType_ReturnsFalse()
        {
            var d = new FakeDomain();
            Assert.False(DomainPropertyApplier.ApplyPrimitive(d, "Nope", null, null, null));
        }

        [Fact]
        public void ApplyDomainBasedOn_SetsProperty()
        {
            var d = new FakeDomain();
            var basedOn = new FakeDomain { Type = "CHARACTER", Length = 20 };
            Assert.True(DomainPropertyApplier.ApplyDomainBasedOn(d, basedOn));
            Assert.Same(basedOn, d.DomainBasedOn);
        }

        [Fact]
        public void ApplyEnumValues_OnFakeWithoutSdk_ReturnsNegative()
        {
            // Without the real Artech.Genexus.Common.CustomTypes.EnumValues type loaded,
            // ApplyEnumValues cannot resolve the helper and must report a hard failure
            // so the caller can surface enumError. The Domain itself doesn't have a
            // direct EnumValues property on this fake.
            var d = new FakeDomain();
            var values = new List<DomainEnumValueSpec>
            {
                new DomainEnumValueSpec { Name = "Active",  Value = "\"A\"" },
                new DomainEnumValueSpec { Name = "Blocked", Value = "\"B\"" }
            };
            int applied = DomainPropertyApplier.ApplyEnumValues(d, values);
            Assert.Equal(-1, applied);
        }

        [Fact]
        public void ApplyEnumValues_EmptyList_ReturnsZero()
        {
            var d = new FakeDomain();
            Assert.Equal(0, DomainPropertyApplier.ApplyEnumValues(d, new List<DomainEnumValueSpec>()));
        }
    }
}
