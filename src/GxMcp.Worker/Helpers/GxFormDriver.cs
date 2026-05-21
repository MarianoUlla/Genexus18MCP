using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace GxMcp.Worker.Helpers
{
    /// <summary>
    /// FR#16 (Stream G, v2.6.6) — GeneXus-aware DOM helper. Parses a raw HTML
    /// (or chrome-devtools-axi snapshot) string from a GX-generated WebPanel and
    /// surfaces:
    ///   - the form action / caption,
    ///   - the input attribute map (logical attr name like "&amp;AluCod" →
    ///     concrete selector),
    ///   - the clickable[] list of buttons/anchors whose JS handler reaches
    ///     <c>gx.evt.execLink(&lt;EventName&gt;, ...)</c>,
    /// and emits ready-to-paste <c>evaluate</c> scripts that fill those inputs
    /// or fire those events — so the agent never has to guess a selector.
    /// </summary>
    public class GxFormDriver
    {
        public class GxInput
        {
            public string FullName { get; set; }    // gx-FullName, e.g. "AluCod"
            public string Id { get; set; }          // raw id, e.g. "vALUCOD"
            public string Name { get; set; }        // name="" attribute when present
            public string Format { get; set; }
            public string MaxLength { get; set; }
            public bool Required { get; set; }
            /// <summary>Best-effort CSS selector for this input.</summary>
            public string Selector { get; set; }
        }

        public class GxClickable
        {
            public string Label { get; set; }
            public string Event { get; set; }      // e.g. "Confirm"
            public string Selector { get; set; }   // e.g. "a#vBTNCONFIRM" or "[name=BTNCONFIRM]"
        }

        public string FormAction { get; private set; }
        public string FormCaption { get; private set; }
        public List<GxInput> Inputs { get; private set; } = new List<GxInput>();
        public List<GxClickable> Clickables { get; private set; } = new List<GxClickable>();

        public static GxFormDriver Parse(string htmlOrSnapshot)
        {
            var d = new GxFormDriver();
            if (string.IsNullOrEmpty(htmlOrSnapshot)) return d;
            d.ParseInternal(htmlOrSnapshot);
            return d;
        }

        private void ParseInternal(string html)
        {
            // 1) form action
            var mForm = Regex.Match(html, "<form\\b[^>]*\\baction\\s*=\\s*\"([^\"]*)\"",
                RegexOptions.IgnoreCase);
            if (mForm.Success) FormAction = mForm.Groups[1].Value;

            // 2) FormCaption — class="gx_FormCaption">...<
            var mCap = Regex.Match(html,
                "class\\s*=\\s*\"[^\"]*gx_FormCaption[^\"]*\"[^>]*>([^<]+)<",
                RegexOptions.IgnoreCase);
            if (mCap.Success) FormCaption = mCap.Groups[1].Value.Trim();
            else
            {
                // alternative: gx-FormCaption attribute
                var mCap2 = Regex.Match(html, "gx-FormCaption\\s*=\\s*\"([^\"]+)\"",
                    RegexOptions.IgnoreCase);
                if (mCap2.Success) FormCaption = mCap2.Groups[1].Value.Trim();
            }

            // 3) <input>/<select>/<textarea> walk — collect every tag with id or
            //    gx-FullName. Use a tolerant tag-level regex; per-attribute parsing
            //    afterwards.
            var tagRe = new Regex("<(input|select|textarea)\\b([^>]*)>",
                RegexOptions.IgnoreCase);
            foreach (Match tm in tagRe.Matches(html))
            {
                string attrs = tm.Groups[2].Value;
                var inp = new GxInput
                {
                    FullName = GetAttr(attrs, "gx-FullName"),
                    Id = GetAttr(attrs, "id"),
                    Name = GetAttr(attrs, "name"),
                    Format = GetAttr(attrs, "gx-Format"),
                    MaxLength = GetAttr(attrs, "gx-MaxLength"),
                    Required = string.Equals(GetAttr(attrs, "gx-Required"), "true",
                        StringComparison.OrdinalIgnoreCase)
                };
                if (string.IsNullOrEmpty(inp.FullName) && string.IsNullOrEmpty(inp.Id) &&
                    string.IsNullOrEmpty(inp.Name)) continue;

                // Selector preference: gx-fullname (most stable across GX rebuilds) →
                // id (#vXXX) → name=.
                if (!string.IsNullOrEmpty(inp.FullName))
                    inp.Selector = "[gx-fullname=\"" + inp.FullName + "\"]";
                else if (!string.IsNullOrEmpty(inp.Id))
                    inp.Selector = "#" + inp.Id;
                else
                    inp.Selector = "[name=\"" + inp.Name + "\"]";

                Inputs.Add(inp);
            }

            // 4) Clickables — anchors and buttons with onclick / href firing
            //    gx.evt.execLink('<Event>', ...). Some GX skins also use
            //    gx.fn.executeServerEvent — capture both.
            var clickRe = new Regex(
                "<(a|button|input)\\b([^>]*)>([^<]{0,200})",
                RegexOptions.IgnoreCase);
            foreach (Match cm in clickRe.Matches(html))
            {
                string attrs = cm.Groups[2].Value;
                string inner = cm.Groups[3].Value.Trim();
                string onclick = GetAttr(attrs, "onclick");
                string href = GetAttr(attrs, "href");
                string handler = (onclick ?? "") + " " + (href ?? "");
                if (string.IsNullOrWhiteSpace(handler)) continue;

                var em = Regex.Match(handler,
                    "(?:gx\\.evt\\.execLink|executeServerEvent|gx\\.evt\\.post)\\s*\\(\\s*['\"]([A-Za-z0-9_]+)['\"]",
                    RegexOptions.IgnoreCase);
                if (!em.Success) continue;

                string eventName = em.Groups[1].Value;
                string label = string.IsNullOrEmpty(inner) ? GetAttr(attrs, "value") : inner;
                string id = GetAttr(attrs, "id");
                string name = GetAttr(attrs, "name");
                string sel = !string.IsNullOrEmpty(id) ? "#" + id
                           : (!string.IsNullOrEmpty(name) ? "[name=\"" + name + "\"]" : "a");

                Clickables.Add(new GxClickable
                {
                    Label = label,
                    Event = eventName,
                    Selector = sel
                });
            }
        }

        private static string GetAttr(string attrs, string name)
        {
            if (string.IsNullOrEmpty(attrs)) return null;
            // Match name="..."  (case-insensitive, tolerant of single quotes)
            var m = Regex.Match(attrs,
                "\\b" + Regex.Escape(name) + "\\s*=\\s*(?:\"([^\"]*)\"|'([^']*)')",
                RegexOptions.IgnoreCase);
            if (!m.Success) return null;
            return m.Groups[1].Success ? m.Groups[1].Value : m.Groups[2].Value;
        }

        /// <summary>
        /// Returns a (selector, error?) tuple. Selector is null + error filled when
        /// the requested logical attr has no match.
        /// </summary>
        public string ResolveSelector(string attrKey, out string error)
        {
            error = null;
            if (string.IsNullOrEmpty(attrKey)) { error = "empty key"; return null; }
            string trimmed = attrKey.TrimStart('&');

            // 1) exact FullName
            var hit = Inputs.FirstOrDefault(i => !string.IsNullOrEmpty(i.FullName) &&
                string.Equals(i.FullName, trimmed, StringComparison.OrdinalIgnoreCase));
            if (hit != null) return hit.Selector;

            // 2) v<UPPER> id convention
            string vId = "v" + trimmed.ToUpperInvariant();
            hit = Inputs.FirstOrDefault(i => !string.IsNullOrEmpty(i.Id) &&
                string.Equals(i.Id, vId, StringComparison.OrdinalIgnoreCase));
            if (hit != null) return hit.Selector;

            // 3) raw id
            hit = Inputs.FirstOrDefault(i => !string.IsNullOrEmpty(i.Id) &&
                string.Equals(i.Id, trimmed, StringComparison.OrdinalIgnoreCase));
            if (hit != null) return hit.Selector;

            // 4) name=
            hit = Inputs.FirstOrDefault(i => !string.IsNullOrEmpty(i.Name) &&
                string.Equals(i.Name, trimmed, StringComparison.OrdinalIgnoreCase));
            if (hit != null) return hit.Selector;

            error = "no input matches attr '" + attrKey + "'";
            return null;
        }

        /// <summary>
        /// Builds one JS payload that fills every (attr → value) pair, fires
        /// change + blur for each. Unresolved keys become entries on the
        /// returned errors list — caller can surface those in the tool response.
        /// </summary>
        public string BuildFillScript(IDictionary<string, string> values, out List<string> errors)
        {
            errors = new List<string>();
            if (values == null || values.Count == 0) return string.Empty;
            var sb = new StringBuilder();
            sb.Append("(function(){var r={ok:[],err:[]};");
            foreach (var kv in values)
            {
                string sel = ResolveSelector(kv.Key, out string err);
                if (sel == null)
                {
                    errors.Add(err);
                    sb.Append("r.err.push(").Append(JsonConvert.SerializeObject(kv.Key)).Append(");");
                    continue;
                }
                sb.Append("var el=document.querySelector(")
                  .Append(JsonConvert.SerializeObject(sel))
                  .Append(");");
                sb.Append("if(el){el.value=")
                  .Append(JsonConvert.SerializeObject(kv.Value ?? ""))
                  .Append(";");
                sb.Append("el.dispatchEvent(new Event('change',{bubbles:true}));");
                sb.Append("el.dispatchEvent(new Event('blur',{bubbles:true}));");
                sb.Append("r.ok.push(").Append(JsonConvert.SerializeObject(kv.Key)).Append(");");
                sb.Append("}else{r.err.push(").Append(JsonConvert.SerializeObject(kv.Key)).Append(");}");
            }
            sb.Append("return JSON.stringify(r);})()");
            return sb.ToString();
        }

        /// <summary>
        /// Builds a JS payload that fires the named GX event. Tries
        /// <c>gx.evt.execLink</c> first (the IDE-default dispatcher); if window.gx
        /// is unavailable, falls back to <c>.click()</c> on the matching anchor /
        /// button (looked up against <see cref="Clickables"/>).
        /// </summary>
        public string BuildClickScript(string eventName)
        {
            if (string.IsNullOrEmpty(eventName)) return string.Empty;
            string ev = JsonConvert.SerializeObject(eventName);
            // Try matched clickable's selector for the fallback click.
            var match = Clickables.FirstOrDefault(c =>
                string.Equals(c.Event, eventName, StringComparison.OrdinalIgnoreCase));
            string sel = match != null ? match.Selector : "a";
            string selJs = JsonConvert.SerializeObject(sel);

            var sb = new StringBuilder();
            sb.Append("(function(){try{");
            sb.Append("if(window.gx&&window.gx.evt&&window.gx.evt.execLink){");
            sb.Append("window.gx.evt.execLink(").Append(ev).Append(",[],[],'',0,'',0);");
            sb.Append("return 'execLink:'+").Append(ev).Append(";}");
            sb.Append("}catch(e){}");
            sb.Append("var el=document.querySelector(").Append(selJs).Append(");");
            sb.Append("if(el){el.click();return 'click:'+").Append(selJs).Append(";}");
            sb.Append("return 'no-handler';})()");
            return sb.ToString();
        }
    }
}
