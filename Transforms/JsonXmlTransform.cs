using emanuel.Extensions;
using emanuel.Transforms;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Xml.Linq;

namespace textr.Transforms
{
    class JsonXmlTransform : ITransform
    {
        public static readonly string DeserializeRootElementName = "__Root__";
        public bool PascalCasing { get; set; }

        public string Transform(string text)
        {
            if (text == string.Empty)
            {
                return string.Empty;
            }

            try
            {
                var node = JsonConvert.DeserializeXNode(text, DeserializeRootElementName);

                if (PascalCasing)
                {
                    SetPascalCasing(node.Root);
                }

                var childNodes = node.Root.Elements();
                if (childNodes.Count() == 1 && childNodes.First().Name == DeserializeRootElementName)
                {
                    return childNodes.First().ToString();
                }

                return node.ToString();
            }
            catch (Exception ex)
            {
                return $"Unable to convert json to xml: {ex.Message}" + Environment.NewLine + text;
            }
        }

        private void SetPascalCasing(XElement node)
        {
            node.Name = node.Name.ToString()
                .Forward(name => name[0].ToString().ToUpperInvariant() + name[1..];

            var childNodes = node.Elements();
            if (childNodes.Any())
            {
                foreach (var childNode in childNodes)
                {
                    SetPascalCasing(childNode);
                }
            }
        }
    }
}
