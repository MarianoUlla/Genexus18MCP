using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Artech.Architecture.Common.Objects;

namespace GxMcp.Worker.Helpers
{
    /// <summary>
    /// Static analysis for WebForm layouts that catches patterns the GeneXus HTML
    /// generator silently breaks (or runtime renders read-only) — issues that compile
    /// cleanly but fail at user-facing behavior. Driven by friction-report 2026-05-19
    /// findings: gxButton custom OnClickEvent ignored in &lt;Form type="html"&gt;; gxAttribute
    /// Radio/Combo rendered disabled when local var shadows a transaction attribute.
    ///
    /// Returns warnings the caller can attach to inspect/edit responses so the agent
    /// learns at the failing call instead of after a build + browser smoke cycle.
    /// </summary>
    public static class LayoutGotchaScanner
    {
        public sealed class Gotcha
        {
            public string Code;       // stable identifier for grep/dedup
            public string Severity;   // "Warning" — these compile clean
            public string Element;
            public string ControlId;
            public string Message;
            public string Workaround;
        }

        /// <summary>
        /// Scans a layout XML and returns the list of detected gotchas. Empty list if
        /// none / on parse failure. KB-aware overload — uses the live model to resolve
        /// var:N bindings and check for attribute shadowing.
        /// </summary>
        public static List<Gotcha> Scan(string layoutXml, KBObject obj)
        {
            return ScanInternal(
                layoutXml,
                attId => ResolveVarName(obj, attId),
                name => AttributeExists(obj, name));
        }

        /// <summary>
        /// Testable overload: accepts delegates for var:N → variable name and for
        /// transaction-attribute existence. The tests assembly does not reference
        /// Artech.Genexus.Common, so the KBObject overload can't run in unit tests.
        /// </summary>
        public static List<Gotcha> Scan(string layoutXml, Func<string, string> varNameResolver, Func<string, bool> attributeExists)
        {
            return ScanInternal(
                layoutXml,
                varNameResolver ?? (_ => null),
                attributeExists ?? (_ => false));
        }

        private static List<Gotcha> ScanInternal(string layoutXml, Func<string, string> varNameResolver, Func<string, bool> attributeExists)
        {
            var hits = new List<Gotcha>();
            if (string.IsNullOrWhiteSpace(layoutXml)) return hits;

            XDocument doc;
            try { doc = XDocument.Parse(layoutXml); }
            catch { return hits; }

            bool isHtmlForm = doc.Descendants("Form")
                .Any(f => string.Equals((string)f.Attribute("type"), "html", StringComparison.OrdinalIgnoreCase));

            // Per-name attribute existence cache so multiple controls binding the same variable
            // only hit the KB index once.
            var attrExistsCache = new Dictionary<string, bool>(StringComparer.OrdinalIgnoreCase);

            foreach (var el in doc.Descendants())
            {
                string elName = el.Name.LocalName;

                // FR#1 — gxButton in Form type="html" only fires the Enter event; any custom
                // OnClickEvent value is dropped by the generator (renders data-gx-evt="5"). The
                // SDK accepts the XML attribute (build passes) but the wired event at runtime
                // is always Enter. ListaAti-style buttons use <action onClickEvent="'X'" /> in
                // Form type="layout"; gxBitmap eventGX="'X'" also works for custom events.
                if (isHtmlForm && elName.Equals("gxButton", StringComparison.OrdinalIgnoreCase))
                {
                    string ev = AttrAny(el, "OnClickEvent", "onClickEvent", "eventGX", "event");
                    if (!string.IsNullOrWhiteSpace(ev))
                    {
                        string normalized = ev.Trim().Trim('\'').Trim();
                        if (!normalized.Equals("Enter", StringComparison.OrdinalIgnoreCase)
                            && !normalized.Equals("Cancel", StringComparison.OrdinalIgnoreCase)
                            && !normalized.Equals("Refresh", StringComparison.OrdinalIgnoreCase)
                            && normalized.Length > 0)
                        {
                            hits.Add(new Gotcha
                            {
                                Code = "GotchaGxButtonHtmlFormCustomEvent",
                                Severity = "Warning",
                                Element = elName,
                                ControlId = (string)el.Attribute("id"),
                                Message = $"gxButton OnClickEvent=\"'{normalized}'\" will compile but the HTML generator " +
                                          "wires data-gx-evt=5 (Enter) regardless. Custom events are not supported on " +
                                          "gxButton inside <Form type=\"html\">.",
                                Workaround = "Use a <gxBitmap eventGX=\"'" + normalized + "'\" /> styled as a button, or " +
                                             "move the control to a <Form type=\"layout\"> table and use <action onClickEvent=\"'" + normalized + "'\" />."
                            });
                        }
                    }
                }

                // FR#2 — gxAttribute with ControlType="Radio Button" or "Combo Box" bound to
                // a local variable whose name matches an existing transaction attribute renders
                // disabled in the HTML output (display:none + ReadonlyAttribute span), even with
                // ReadOnly="False". The text-input default ControlType is unaffected.
                if (elName.Equals("gxAttribute", StringComparison.OrdinalIgnoreCase))
                {
                    string ctrlType = (string)el.Attribute("ControlType");
                    if (!string.IsNullOrWhiteSpace(ctrlType)
                        && (ctrlType.Equals("Radio Button", StringComparison.OrdinalIgnoreCase)
                            || ctrlType.Equals("Combo Box", StringComparison.OrdinalIgnoreCase)))
                    {
                        string attId = (string)el.Attribute("AttID");
                        if (!string.IsNullOrWhiteSpace(attId) && attId.StartsWith("var:", StringComparison.OrdinalIgnoreCase))
                        {
                            // Resolve var:N → variable name on the host object; check if a same-name
                            // transaction attribute exists in the KB.
                            string varName = varNameResolver(attId);
                            if (!string.IsNullOrEmpty(varName))
                            {
                                bool shadowsAttr;
                                if (!attrExistsCache.TryGetValue(varName, out shadowsAttr))
                                {
                                    shadowsAttr = attributeExists(varName);
                                    attrExistsCache[varName] = shadowsAttr;
                                }
                                if (shadowsAttr)
                                {
                                    hits.Add(new Gotcha
                                    {
                                        Code = "GotchaGxAttributeShadowReadOnly",
                                        Severity = "Warning",
                                        Element = elName,
                                        ControlId = (string)el.Attribute("id") ?? attId,
                                        Message = $"gxAttribute ControlType=\"{ctrlType}\" bound to &{varName} renders " +
                                                  "disabled in HTML output because the local variable name shadows the " +
                                                  $"transaction attribute '{varName}'. ReadOnly=\"False\" is honored for " +
                                                  "text inputs but ignored for Radio Button / Combo Box bindings.",
                                        Workaround = $"Rename the local variable so it does not shadow the attribute (e.g. " +
                                                     $"&Resp{varName} or &Sel{varName}), update events/parm rules, rebuild."
                                    });
                                }
                            }
                        }
                    }
                }
            }
            return hits;
        }

        private static string AttrAny(XElement el, params string[] names)
        {
            foreach (var n in names)
            {
                var a = el.Attribute(n);
                if (a != null && !string.IsNullOrWhiteSpace(a.Value)) return a.Value;
            }
            return null;
        }

        // Resolve var:N to the variable name using the object's VariablesPart. Empty/null if
        // not resolvable. NOTE: GetVariableInternalId falls back to enumeration position when
        // SDK doesn't expose a real Id, so this may map the wrong variable in objects where
        // var:N != position. Best-effort.
        private static string ResolveVarName(KBObject obj, string attId)
        {
            if (obj == null || string.IsNullOrEmpty(attId)) return null;
            if (!attId.StartsWith("var:", StringComparison.OrdinalIgnoreCase)) return null;
            if (!int.TryParse(attId.Substring(4), out var id)) return null;
            return WebFormSchemaHints.LookupVarNameById(obj, id);
        }

        // True iff the KB has a transaction Attribute with this name. Uses the model index
        // (Objects.GetByName) so it's O(log N) per lookup, not O(KB).
        private static bool AttributeExists(KBObject obj, string name)
        {
            if (obj?.Model == null || string.IsNullOrEmpty(name)) return false;
            try
            {
                foreach (var result in obj.Model.Objects.GetByName(null, null, name))
                {
                    if (result is global::Artech.Genexus.Common.Objects.Attribute) return true;
                }
            }
            catch { /* model access error */ }
            return false;
        }
    }
}
