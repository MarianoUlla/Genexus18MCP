using System;
using System.Collections.Generic;
using GxMcp.Worker.Models;
using GxMcp.Worker.Services;
using Newtonsoft.Json.Linq;
using Xunit;

namespace GxMcp.Worker.Tests
{
    // FR#18 (Stream G, v2.6.6) — analyze mode=parent_context. The service
    // walks IndexCacheService.GetIndex().Objects[target].CalledBy, then for
    // each caller scans Source / Events / Conditions for popup vs link
    // invocations and emits openedAs + actionable hint.
    public class ParentContextAnalyzeTests
    {
        // Synthetic 3-caller setup:
        //   - PopupCaller calls AlunoEdit.PopUp(...)
        //   - LinkCaller calls AlunoEdit.Link(...)
        //   - SilentCaller mentions AlunoEdit only in a comment → neither bucket
        [Fact]
        public void ParentContext_ClassifiesPopupAndLinkCallers()
        {
            var entries = new List<SearchIndex.IndexEntry>
            {
                new SearchIndex.IndexEntry {
                    Name = "AlunoEdit", Type = "WebPanel",
                    CalledBy = new List<string> { "PopupCaller", "LinkCaller", "SilentCaller" }
                },
                new SearchIndex.IndexEntry { Name = "PopupCaller", Type = "WebPanel" },
                new SearchIndex.IndexEntry { Name = "LinkCaller", Type = "WebPanel" },
                new SearchIndex.IndexEntry { Name = "SilentCaller", Type = "WebPanel" }
            };
            var index = new IndexCacheService();
            index.LoadFromEntries(entries);

            var sources = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                ["PopupCaller|Events"] = "Event 'Open'\n    AlunoEdit.PopUp(&AluCod)\nEndEvent",
                ["LinkCaller|Events"] = "Event 'Open'\n    AlunoEdit.Link(&AluCod)\nEndEvent",
                ["SilentCaller|Source"] = "// AlunoEdit is referenced but not actually invoked here.\n"
            };
            Func<string, string, string> resolver = (caller, part) =>
                sources.TryGetValue(caller + "|" + part, out var s) ? s : null;

            // Use the test-friendly ctor that takes only (index, objSvc, graph).
            var svc = new AnalyzeService(index, null, null);
            // Reflect into the internal overload that accepts the resolver.
            var mi = typeof(AnalyzeService).GetMethod("ParentContext",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance,
                null,
                new[] { typeof(string), typeof(Func<string, string, string>) },
                null);
            Assert.NotNull(mi);
            string json = (string)mi.Invoke(svc, new object[] { "AlunoEdit", resolver });

            var o = JObject.Parse(json);
            Assert.Equal("both", o["openedAs"]?.ToString());
            Assert.Equal("AlunoEdit", o["target"]?.ToString());

            var popup = (JArray)o["popupCallers"];
            var stand = (JArray)o["standaloneCallers"];
            Assert.Single(popup);
            Assert.Equal("PopupCaller", popup[0].ToString());
            Assert.Single(stand);
            Assert.Equal("LinkCaller", stand[0].ToString());

            // SilentCaller must be excluded from both lists.
            Assert.DoesNotContain("SilentCaller", popup.ToString());
            Assert.DoesNotContain("SilentCaller", stand.ToString());

            // Hint must be the "both" branch.
            string hint = o["hint"]?.ToString() ?? "";
            Assert.Contains("IsPopUp()", hint);
        }

        [Fact]
        public void ParentContext_PopupOnly_EmitsPopupHint()
        {
            var entries = new List<SearchIndex.IndexEntry>
            {
                new SearchIndex.IndexEntry {
                    Name = "ConfirmDelete", Type = "WebPanel",
                    CalledBy = new List<string> { "ListPage" }
                },
                new SearchIndex.IndexEntry { Name = "ListPage", Type = "WebPanel" }
            };
            var index = new IndexCacheService();
            index.LoadFromEntries(entries);

            // gx.PopUp("ConfirmDelete", ...) → matches the context-prefix branch.
            Func<string, string, string> resolver = (caller, part) =>
                part == "Events" ? "gx.PopUp(\"ConfirmDelete\", parms);" : null;

            var svc = new AnalyzeService(index, null, null);
            var json = svc.ParentContext("ConfirmDelete");
            // Without the resolver seam the default path tries ObjectService (null)
            // and yields unknown. Drive through the internal overload instead.
            var mi = typeof(AnalyzeService).GetMethod("ParentContext",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance,
                null,
                new[] { typeof(string), typeof(Func<string, string, string>) },
                null);
            json = (string)mi.Invoke(svc, new object[] { "ConfirmDelete", resolver });

            var o = JObject.Parse(json);
            Assert.Equal("popup", o["openedAs"]?.ToString());
            Assert.Contains("Do NOT use Link()", o["hint"]?.ToString());
        }

        [Fact]
        public void ParentContext_NoCallers_ReturnsUnknown()
        {
            var entries = new List<SearchIndex.IndexEntry>
            {
                new SearchIndex.IndexEntry {
                    Name = "OrphanPanel", Type = "WebPanel",
                    CalledBy = new List<string>()
                }
            };
            var index = new IndexCacheService();
            index.LoadFromEntries(entries);

            var svc = new AnalyzeService(index, null, null);
            var json = svc.ParentContext("OrphanPanel");
            var o = JObject.Parse(json);

            Assert.Equal("unknown", o["openedAs"]?.ToString());
            Assert.Empty((JArray)o["popupCallers"]);
            Assert.Empty((JArray)o["standaloneCallers"]);
            Assert.Contains("Re-run after", o["hint"]?.ToString());
        }

        [Fact]
        public void HintForOpenedAs_CoversAllBranches()
        {
            Assert.Contains("Do NOT use Link()", AnalyzeService.HintForOpenedAs("popup"));
            Assert.Contains("standalone (Link)", AnalyzeService.HintForOpenedAs("standalone"));
            Assert.Contains("IsPopUp()", AnalyzeService.HintForOpenedAs("both"));
            Assert.Contains("Re-run after", AnalyzeService.HintForOpenedAs("unknown"));
            // unknown branch is the default for arbitrary strings too.
            Assert.Contains("Re-run after", AnalyzeService.HintForOpenedAs("garbage"));
        }
    }
}
