using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using GxMcp.Worker.Models;
using Newtonsoft.Json.Linq;

namespace GxMcp.Worker.Services
{
    public sealed class SemanticOpsService
    {
        public string Apply(string xml, string objectKind, IEnumerable<SemanticOp> ops)
        {
            var doc = XDocument.Parse(xml);
            foreach (var op in ops)
                Dispatch(doc, objectKind, op);
            return doc.ToString(SaveOptions.DisableFormatting);
        }

        /// <summary>
        /// v2.6.6 FR#13 — per-op apply that records success/failure per index. In
        /// <c>strict</c> mode the first failure aborts (mirrors legacy
        /// <see cref="Apply(string,string,System.Collections.Generic.IEnumerable{SemanticOp})"/>).
        /// In <c>best-effort</c> mode failing ops are skipped and the doc retains
        /// the successful ones. <c>only</c> mode is identical to <c>best-effort</c>
        /// at this layer — the caller decides not to persist.
        /// </summary>
        public OpsApplyOutcome ApplyWithResults(string xml, string objectKind, IList<SemanticOp> ops, string validate)
        {
            var doc = XDocument.Parse(xml);
            var results = new List<OpResult>(ops.Count);
            string mode = NormalizeMode(validate);
            bool aborted = false;

            for (int i = 0; i < ops.Count; i++)
            {
                var op = ops[i];
                try
                {
                    Dispatch(doc, objectKind, op);
                    results.Add(new OpResult { Index = i, Op = op.Op, Ok = true });
                }
                catch (UsageException ux)
                {
                    results.Add(new OpResult { Index = i, Op = op.Op, Ok = false, Reason = ux.Message, Code = ux.Code });
                    if (mode == "strict") { aborted = true; break; }
                }
                catch (Exception ex)
                {
                    results.Add(new OpResult { Index = i, Op = op.Op, Ok = false, Reason = ex.Message, Code = "internal_error" });
                    if (mode == "strict") { aborted = true; break; }
                }
            }

            return new OpsApplyOutcome
            {
                Xml = doc.ToString(SaveOptions.DisableFormatting),
                Results = results,
                Aborted = aborted,
                Mode = mode
            };
        }

        internal static string NormalizeMode(string validate)
        {
            if (string.IsNullOrWhiteSpace(validate)) return "strict";
            string v = validate.Trim().ToLowerInvariant();
            switch (v)
            {
                case "strict":
                case "best-effort":
                case "best_effort":
                case "besteffort":
                    return v == "best_effort" || v == "besteffort" ? "best-effort" : v;
                case "only":
                case "validate-only":
                case "validate_only":
                    return "only";
                default:
                    return "strict";
            }
        }

        public sealed class OpResult
        {
            public int Index;
            public string Op;
            public bool Ok;
            public string Reason;
            public string Code;

            public JObject ToJson()
            {
                var j = new JObject
                {
                    ["index"] = Index,
                    ["op"] = Op,
                    ["ok"] = Ok
                };
                if (!Ok)
                {
                    if (!string.IsNullOrEmpty(Reason)) j["reason"] = Reason;
                    if (!string.IsNullOrEmpty(Code)) j["code"] = Code;
                }
                return j;
            }
        }

        public sealed class OpsApplyOutcome
        {
            public string Xml;
            public List<OpResult> Results;
            public bool Aborted;
            public string Mode;
        }

        private static void Dispatch(XDocument doc, string kind, SemanticOp op)
        {
            switch (op.Op)
            {
                case "set_attribute" when kind == "Transaction":
                    SetAttribute(doc, op);
                    break;
                case "add_attribute" when kind == "Transaction":
                    AddAttribute(doc, op);
                    break;
                case "remove_attribute" when kind == "Transaction":
                    RemoveAttribute(doc, op);
                    break;
                case "add_rule" when kind == "Transaction" || kind == "Procedure" || kind == "WebPanel":
                    AddRule(doc, op);
                    break;
                case "remove_rule" when kind == "Transaction" || kind == "Procedure" || kind == "WebPanel":
                    RemoveRule(doc, op);
                    break;
                case "set_property":
                    SetProperty(doc, op);
                    break;
                default:
                    throw new UsageException("usage_error",
                        "op '" + op.Op + "' not supported for " + kind);
            }
        }

        private static void SetAttribute(XDocument doc, SemanticOp op)
        {
            string name = op.Args["name"]?.ToString();
            if (string.IsNullOrEmpty(name))
                throw new UsageException("usage_error", "set_attribute: name required");

            var attr = doc.Descendants("Attribute")
                .FirstOrDefault(a => (string)a.Element("Name") == name);
            if (attr == null)
                throw new UsageException("usage_error",
                    "attribute '" + name + "' not found");

            string type = op.Args["type"]?.ToString();
            if (type != null)
                attr.SetElementValue("Type", type);
        }

        private static void AddAttribute(XDocument doc, SemanticOp op)
        {
            string name = op.Args["name"]?.ToString();
            if (string.IsNullOrEmpty(name))
                throw new UsageException("usage_error", "add_attribute: name required");
            string type = op.Args["type"]?.ToString();
            if (string.IsNullOrEmpty(type))
                throw new UsageException("usage_error", "add_attribute: type required");

            var structure = doc.Descendants("Structure").FirstOrDefault();
            if (structure == null)
                throw new UsageException("usage_error", "add_attribute: <Structure> not found");

            structure.Add(new XElement("Attribute",
                new XElement("Name", name),
                new XElement("Type", type)));
        }

        private static void RemoveAttribute(XDocument doc, SemanticOp op)
        {
            string name = op.Args["name"]?.ToString();
            if (string.IsNullOrEmpty(name))
                throw new UsageException("usage_error", "remove_attribute: name required");

            var attr = doc.Descendants("Attribute")
                .FirstOrDefault(a => (string)a.Element("Name") == name);
            if (attr == null)
                throw new UsageException("usage_error",
                    "attribute '" + name + "' not found");
            attr.Remove();
        }

        private static void AddRule(XDocument doc, SemanticOp op)
        {
            string text = op.Args["text"]?.ToString();
            if (string.IsNullOrEmpty(text))
                throw new UsageException("usage_error", "add_rule: text required");

            var rules = doc.Descendants("Rules").FirstOrDefault();
            if (rules == null)
            {
                rules = new XElement("Rules");
                doc.Root?.Add(rules);
            }
            rules.Add(new XElement("Rule", new XElement("Text", text)));
        }

        private static void RemoveRule(XDocument doc, SemanticOp op)
        {
            var rulesContainer = doc.Descendants("Rules").FirstOrDefault();
            if (rulesContainer == null)
                throw new UsageException("usage_error", "remove_rule: <Rules> not found");

            var rules = rulesContainer.Elements("Rule").ToList();
            var indexToken = op.Args["index"];
            if (indexToken != null)
            {
                int idx = (int)indexToken;
                if (idx < 0 || idx >= rules.Count)
                    throw new UsageException("usage_error",
                        "remove_rule: index " + idx + " out of range");
                rules[idx].Remove();
                return;
            }

            string match = op.Args["match"]?.ToString();
            if (string.IsNullOrEmpty(match))
                throw new UsageException("usage_error", "remove_rule: match or index required");

            var target = rules.FirstOrDefault(r =>
            {
                string t = (string)r.Element("Text");
                return t != null && t.Contains(match);
            });
            if (target == null)
                throw new UsageException("usage_error",
                    "remove_rule: no rule matching '" + match + "'");
            target.Remove();
        }

        private static void SetProperty(XDocument doc, SemanticOp op)
        {
            string path = op.Args["path"]?.ToString();
            if (string.IsNullOrEmpty(path))
                throw new UsageException("usage_error", "set_property: path required");
            string value = op.Args["value"]?.ToString() ?? "";
            string name = path.TrimStart('/');
            var elem = doc.Root?.Element(name);
            if (elem == null)
                throw new UsageException("usage_error",
                    "set_property: path '" + path + "' not found");
            elem.Value = value;
        }
    }
}
