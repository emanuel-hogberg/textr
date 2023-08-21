using StringTransforms.Interfaces;
using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace StringTransforms.Transforms
{
    internal class JsonXmlTransform : IJsonXmlTransform
    {
        private const string DeserializeRootElementName = "__Root__";
        public bool PascalCasing { get; set; }

        string IJsonXmlTransform.DeserializeRootElementName => DeserializeRootElementName;

        public string Transform(string text)
        {
            if (text == string.Empty)
            {
                return string.Empty;
            }

            try
            {
                var node = JsonSerializer.SerializeToNode(text);

                if (PascalCasing)
                {
                    SetPascalCasing(node);
                }

                var childNodes = node.AsArray();
                if (childNodes.Count == 1 && childNodes.First().Root.AsValue().ToString() == DeserializeRootElementName)
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

        private void SetPascalCasing(JsonNode node)
        {
            //TODO: 
            //node.Name = node.Name.ToString()
            //    .Forward(name => name[0].ToString().ToUpperInvariant() + (name.Length > 1 ? name.Substring(1) : string.Empty));

            //var childNodes = node.Elements();
            //if (childNodes.Any())
            //{
            //    foreach (var childNode in childNodes)
            //    {
            //        SetPascalCasing(childNode);
            //    }
            //}
        }
    }
}
