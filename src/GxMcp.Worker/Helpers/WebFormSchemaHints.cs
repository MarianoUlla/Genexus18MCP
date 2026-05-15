using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace GxMcp.Worker.Helpers
{
    // Best-effort element→accepted-attribute hints derived from observed SDK sanitisation
    // and publish/worker/Definitions. The SDK is the ground truth — extend when new
    // element/attribute combinations surface in friction reports.
    public static class WebFormSchemaHints
    {
        private static readonly string[] _commonCtrlAttrs = { "id", "AttID", "Class", "classref", "Width", "Height", "Visible", "Tooltip" };

        private static string[] WithCommon(params string[] extras)
        {
            var arr = new string[_commonCtrlAttrs.Length + extras.Length];
            System.Array.Copy(_commonCtrlAttrs, arr, _commonCtrlAttrs.Length);
            System.Array.Copy(extras, 0, arr, _commonCtrlAttrs.Length, extras.Length);
            return arr;
        }

        // Lookup is case-insensitive so mixed-case markup ("WIDTH" vs "Width") still resolves.
        private static readonly Dictionary<string, string[]> _accepted = new Dictionary<string, string[]>(StringComparer.OrdinalIgnoreCase)
        {
            ["table"]          = new[] { "id", "classref", "Class", "AttID", "cellPadding", "cellSpacing", "Width", "Height", "BackColor", "ForeColor", "Border", "AutoGrow", "Background", "BackgroundType" },
            ["gxAttribute"]    = WithCommon("CaptionExpression", "DataField", "ReadOnly", "ControlType", "Format"),
            ["gxTextBlock"]    = WithCommon("CaptionExpression", "Format"),
            ["gxButton"]       = WithCommon("CaptionExpression", "OnClickEvent", "Enabled"),
            ["gxBitmap"]       = WithCommon("ImageData"),
            ["gxImage"]        = WithCommon("ImageData"),
            ["gxGrid"]         = WithCommon("DataField", "Rows", "Columns", "AllowSelection", "AllowOrdering"),
            ["gxTab"]          = WithCommon("CaptionExpression"),
            ["gxCard"]         = WithCommon("CaptionExpression"),
            ["gxGroup"]        = WithCommon("CaptionExpression"),
            ["gxEmbeddedPage"] = WithCommon("ObjectCall"),
            ["row"]            = new[] { "Height" },
            ["cell"]           = new[] { "id", "ColSpan", "RowSpan", "Width", "Height", "HAlign", "VAlign", "ClassRef", "Class" },
        };

        // null = no hint registered for this element; caller treats as "SDK is authoritative".
        public static string[] GetAcceptedAttributes(string elementName)
        {
            if (string.IsNullOrEmpty(elementName)) return null;
            return _accepted.TryGetValue(elementName, out var attrs) ? attrs : null;
        }

        // Walks the XML, flags any attribute outside the element's accept-list. Silent on
        // parse failure (the writer surfaces XML errors via a more specific code path).
        public static List<SuspectAttribute> ScanForRejectedAttributes(string xml)
        {
            var hits = new List<SuspectAttribute>();
            if (string.IsNullOrWhiteSpace(xml)) return hits;
            XDocument doc;
            try { doc = XDocument.Parse(xml); }
            catch { return hits; }

            foreach (var el in doc.Descendants())
            {
                var accepted = GetAcceptedAttributes(el.Name.LocalName);
                if (accepted == null) continue; // no hint registered → can't judge
                var acceptedSet = new HashSet<string>(accepted, StringComparer.OrdinalIgnoreCase);
                foreach (var a in el.Attributes())
                {
                    if (acceptedSet.Contains(a.Name.LocalName)) continue;
                    hits.Add(new SuspectAttribute
                    {
                        Element = el.Name.LocalName,
                        Attribute = a.Name.LocalName,
                        Reason = "Attribute not in SDK schema for this element; will be sanitised on save.",
                    });
                }
            }
            return hits;
        }

        public sealed class SuspectAttribute
        {
            public string Element;
            public string Attribute;
            public string Reason;
        }
    }
}
