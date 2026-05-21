using System.Collections.Generic;
using GxMcp.Worker.Models;
using GxMcp.Worker.Services;
using Newtonsoft.Json.Linq;
using Xunit;

namespace GxMcp.Worker.Tests
{
    /// <summary>
    /// v2.6.6 FR#13 — per-op apply with strict / best-effort / only modes.
    /// </summary>
    public class SemanticOpsValidateModeTests
    {
        private const string TransactionXml =
            "<Transaction><Structure>" +
            "<Attribute><Name>Id</Name><Type>NUMERIC(4)</Type></Attribute>" +
            "<Attribute><Name>Name</Name><Type>CHARACTER(50)</Type></Attribute>" +
            "</Structure></Transaction>";

        [Fact]
        public void NormalizeMode_DefaultsToStrict()
        {
            Assert.Equal("strict", SemanticOpsService.NormalizeMode(null));
            Assert.Equal("strict", SemanticOpsService.NormalizeMode(""));
            Assert.Equal("strict", SemanticOpsService.NormalizeMode("garbage"));
        }

        [Fact]
        public void NormalizeMode_AcceptsKnownTokens()
        {
            Assert.Equal("strict", SemanticOpsService.NormalizeMode("strict"));
            Assert.Equal("best-effort", SemanticOpsService.NormalizeMode("best-effort"));
            Assert.Equal("best-effort", SemanticOpsService.NormalizeMode("best_effort"));
            Assert.Equal("best-effort", SemanticOpsService.NormalizeMode("BestEffort"));
            Assert.Equal("only", SemanticOpsService.NormalizeMode("only"));
            Assert.Equal("only", SemanticOpsService.NormalizeMode("validate-only"));
        }

        [Fact]
        public void ApplyWithResults_AllSucceed_RecordsEachOpOk()
        {
            var ops = new List<SemanticOp>
            {
                MakeOp("set_attribute", new JObject { ["name"] = "Id", ["type"] = "NUMERIC(8)" }),
                MakeOp("add_attribute", new JObject { ["name"] = "Email", ["type"] = "CHARACTER(80)" })
            };
            var outcome = new SemanticOpsService().ApplyWithResults(TransactionXml, "Transaction", ops, "strict");
            Assert.False(outcome.Aborted);
            Assert.Equal(2, outcome.Results.Count);
            Assert.True(outcome.Results[0].Ok);
            Assert.True(outcome.Results[1].Ok);
            Assert.Contains("NUMERIC(8)", outcome.Xml);
            Assert.Contains("Email", outcome.Xml);
        }

        [Fact]
        public void ApplyWithResults_StrictMode_AbortsOnFirstFailure()
        {
            var ops = new List<SemanticOp>
            {
                MakeOp("set_attribute", new JObject { ["name"] = "Id", ["type"] = "NUMERIC(8)" }),
                MakeOp("set_attribute", new JObject { ["name"] = "NopeNotThere", ["type"] = "X" }),
                MakeOp("add_attribute", new JObject { ["name"] = "Email", ["type"] = "CHARACTER(80)" })
            };
            var outcome = new SemanticOpsService().ApplyWithResults(TransactionXml, "Transaction", ops, "strict");
            Assert.True(outcome.Aborted);
            // Third op must NOT have run in strict mode.
            Assert.Equal(2, outcome.Results.Count);
            Assert.True(outcome.Results[0].Ok);
            Assert.False(outcome.Results[1].Ok);
            Assert.DoesNotContain("Email", outcome.Xml);
        }

        [Fact]
        public void ApplyWithResults_BestEffortMode_ContinuesPastFailure()
        {
            var ops = new List<SemanticOp>
            {
                MakeOp("set_attribute", new JObject { ["name"] = "Id", ["type"] = "NUMERIC(8)" }),
                MakeOp("set_attribute", new JObject { ["name"] = "NopeNotThere", ["type"] = "X" }),
                MakeOp("add_attribute", new JObject { ["name"] = "Email", ["type"] = "CHARACTER(80)" })
            };
            var outcome = new SemanticOpsService().ApplyWithResults(TransactionXml, "Transaction", ops, "best-effort");
            Assert.False(outcome.Aborted);
            Assert.Equal(3, outcome.Results.Count);
            Assert.True(outcome.Results[0].Ok);
            Assert.False(outcome.Results[1].Ok);
            Assert.True(outcome.Results[2].Ok);
            // The good ops applied, the bad one did not.
            Assert.Contains("NUMERIC(8)", outcome.Xml);
            Assert.Contains("Email", outcome.Xml);
        }

        [Fact]
        public void ApplyWithResults_OnlyMode_ReturnsDiagnostics_LikeBestEffort()
        {
            // "only" mode is best-effort at this layer; the persist gate is at
            // the WriteService dispatch site.
            var ops = new List<SemanticOp>
            {
                MakeOp("add_attribute", new JObject { ["name"] = "Phone", ["type"] = "CHARACTER(30)" })
            };
            var outcome = new SemanticOpsService().ApplyWithResults(TransactionXml, "Transaction", ops, "only");
            Assert.Equal("only", outcome.Mode);
            Assert.False(outcome.Aborted);
            Assert.Single(outcome.Results);
            Assert.True(outcome.Results[0].Ok);
        }

        [Fact]
        public void OpResult_ToJson_OkResult_OmitsReasonAndCode()
        {
            var r = new SemanticOpsService.OpResult { Index = 0, Op = "set_attribute", Ok = true };
            var json = r.ToJson();
            Assert.True((bool)json["ok"]);
            Assert.Null(json["reason"]);
            Assert.Null(json["code"]);
        }

        [Fact]
        public void OpResult_ToJson_FailResult_IncludesReasonAndCode()
        {
            var r = new SemanticOpsService.OpResult
            {
                Index = 2,
                Op = "set_attribute",
                Ok = false,
                Reason = "attribute 'X' not found",
                Code = "usage_error"
            };
            var json = r.ToJson();
            Assert.False((bool)json["ok"]);
            Assert.Equal(2, (int)json["index"]);
            Assert.Equal("attribute 'X' not found", json["reason"].ToString());
            Assert.Equal("usage_error", json["code"].ToString());
        }

        private static SemanticOp MakeOp(string op, JObject args)
        {
            var raw = new JObject { ["op"] = op };
            foreach (var kv in args) raw[kv.Key] = kv.Value;
            return SemanticOp.From(raw);
        }
    }
}
