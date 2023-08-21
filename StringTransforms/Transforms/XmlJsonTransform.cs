using StringTransforms.Interfaces;
using System;
using System.Text.Json;
using System.Xml;

namespace StringTransforms.Transforms
{
    internal class XmlJsonTransform : ITransform
    {
        public string Transform(string text)
        {
            if (text == string.Empty)
            {
                return string.Empty;
            }

            XmlDocument node;
            try
            {
                node = new XmlDocument();
                node.LoadXml(text);
            }
            catch (Exception ex)
            {
                return $"Unable to parse xml: {ex.Message}" + Environment.NewLine + text;
            }

            if (node == null)
            {
                return string.Empty;
            }

            try
            {
                return JsonSerializer.Serialize(node);
            }
            catch (Exception ex)
            {
                return $"Unable to write json: {ex.Message}" + Environment.NewLine + text;
            }
        }
    }
}
