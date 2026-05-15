using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace GxMcp.Worker.Helpers
{
    public sealed class XmlEquivalenceDiff
    {
        public string Path { get; set; }
        public string Summary { get; set; }
        public string[] LeftAttributes { get; set; }
        public string[] RightAttributes { get; set; }
        // Rejected by SDK = present in input (right) but absent in persisted (left).
        public string[] RejectedAttributes { get; set; }
        // Added by SDK = present in persisted (left) but absent in input (right).
        public string[] AddedAttributes { get; set; }
        public string ElementName { get; set; }
    }

    public static class XmlEquivalence
    {
        public static bool AreEquivalent(string a, string b, out string diffSummary)
        {
            return AreEquivalent(a, b, out diffSummary, out _);
        }

        public static bool AreEquivalent(string a, string b, out string diffSummary, out XmlEquivalenceDiff structuredDiff)
        {
            diffSummary = null;
            structuredDiff = null;
            if (ReferenceEquals(a, b)) return true;
            if (string.IsNullOrEmpty(a) && string.IsNullOrEmpty(b)) return true;
            if (string.IsNullOrEmpty(a) || string.IsNullOrEmpty(b))
            {
                diffSummary = "One side empty.";
                structuredDiff = new XmlEquivalenceDiff { Summary = diffSummary };
                return false;
            }

            XDocument da, db;
            try { da = XDocument.Parse(a, LoadOptions.PreserveWhitespace); }
            catch (Exception ex) { diffSummary = "Left parse error: " + ex.Message; structuredDiff = new XmlEquivalenceDiff { Summary = diffSummary }; return false; }
            try { db = XDocument.Parse(b, LoadOptions.PreserveWhitespace); }
            catch (Exception ex) { diffSummary = "Right parse error: " + ex.Message; structuredDiff = new XmlEquivalenceDiff { Summary = diffSummary }; return false; }

            var ok = ElementsEqual(da.Root, db.Root, "/", out diffSummary, out structuredDiff);
            if (!ok && structuredDiff == null)
                structuredDiff = new XmlEquivalenceDiff { Summary = diffSummary };
            return ok;
        }

        private static bool ElementsEqual(XElement x, XElement y, string path, out string diff, out XmlEquivalenceDiff structured)
        {
            diff = null;
            structured = null;
            if (x == null && y == null) return true;
            if (x == null || y == null) { diff = "Missing element at " + path; return false; }
            if (x.Name != y.Name) { diff = "Element name differs at " + path + ": '" + x.Name + "' vs '" + y.Name + "'"; return false; }

            var ax = x.Attributes().OrderBy(a => a.Name.ToString(), StringComparer.Ordinal).ToList();
            var ay = y.Attributes().OrderBy(a => a.Name.ToString(), StringComparer.Ordinal).ToList();
            var lNames = ax.Select(a => a.Name.LocalName).ToArray();
            var rNames = ay.Select(a => a.Name.LocalName).ToArray();
            if (ax.Count != ay.Count)
            {
                var lSet = new HashSet<string>(lNames, StringComparer.Ordinal);
                var rSet = new HashSet<string>(rNames, StringComparer.Ordinal);
                var rejected = rNames.Where(n => !lSet.Contains(n)).ToArray(); // requested but missing after save → SDK rejected
                var added = lNames.Where(n => !rSet.Contains(n)).ToArray();    // SDK injected on persist
                diff = "Attribute count differs at " + path + x.Name + " (" + ax.Count + " vs " + ay.Count + ")"
                       + ": left=[" + string.Join(",", lNames) + "] right=[" + string.Join(",", rNames) + "]"
                       + (rejected.Length > 0 ? "; rejectedByPersist=[" + string.Join(",", rejected) + "]" : "")
                       + (added.Length > 0 ? "; addedByPersist=[" + string.Join(",", added) + "]" : "");
                structured = new XmlEquivalenceDiff
                {
                    Path = path + x.Name,
                    ElementName = x.Name.LocalName,
                    Summary = diff,
                    LeftAttributes = lNames,
                    RightAttributes = rNames,
                    RejectedAttributes = rejected,
                    AddedAttributes = added
                };
                return false;
            }
            for (int i = 0; i < ax.Count; i++)
            {
                if (ax[i].Name != ay[i].Name)
                {
                    diff = "Attribute name differs at " + path + x.Name + ": '" + ax[i].Name + "' vs '" + ay[i].Name + "'";
                    structured = new XmlEquivalenceDiff { Path = path + x.Name, ElementName = x.Name.LocalName, Summary = diff, LeftAttributes = lNames, RightAttributes = rNames };
                    return false;
                }
                if (!string.Equals(ax[i].Value, ay[i].Value, StringComparison.Ordinal))
                {
                    diff = "Attribute '" + ax[i].Name + "' differs at " + path + x.Name
                           + ": '" + Truncate(ax[i].Value) + "' vs '" + Truncate(ay[i].Value) + "'";
                    structured = new XmlEquivalenceDiff { Path = path + x.Name, ElementName = x.Name.LocalName, Summary = diff, LeftAttributes = lNames, RightAttributes = rNames };
                    return false;
                }
            }

            var cx = SignificantChildren(x).ToList();
            var cy = SignificantChildren(y).ToList();
            if (cx.Count != cy.Count)
            {
                diff = "Child count differs at " + path + x.Name + " (" + cx.Count + " vs " + cy.Count + ")";
                return false;
            }

            for (int i = 0; i < cx.Count; i++)
            {
                var nx = cx[i];
                var ny = cy[i];
                if (nx.NodeType != ny.NodeType)
                {
                    diff = "Node type differs at " + path + x.Name + "[" + i + "]: " + nx.NodeType + " vs " + ny.NodeType;
                    return false;
                }

                if (nx is XElement ex2 && ny is XElement ey2)
                {
                    if (!ElementsEqual(ex2, ey2, path + x.Name + "/", out diff, out structured)) return false;
                }
                else if (nx is XText tx && ny is XText ty)
                {
                    var vx = (tx.Value ?? string.Empty).Trim();
                    var vy = (ty.Value ?? string.Empty).Trim();
                    if (!string.Equals(vx, vy, StringComparison.Ordinal))
                    {
                        diff = "Text differs at " + path + x.Name + "[" + i + "]: '" + Truncate(vx) + "' vs '" + Truncate(vy) + "'";
                        return false;
                    }
                }
            }
            return true;
        }

        private static IEnumerable<XNode> SignificantChildren(XElement e)
        {
            foreach (var n in e.Nodes())
            {
                if (n is XText t)
                {
                    if (string.IsNullOrWhiteSpace(t.Value)) continue;
                    yield return t;
                }
                else if (n is XComment) continue;
                else yield return n;
            }
        }

        private static string Truncate(string s)
        {
            if (s == null) return string.Empty;
            return s.Length <= 80 ? s : s.Substring(0, 80) + "…";
        }
    }
}
