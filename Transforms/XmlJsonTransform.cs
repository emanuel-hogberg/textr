using emanuel.Transforms;
using Newtonsoft.Json;
using System;
using System.Xml;

namespace textr.Transforms
{
    class XmlJsonTransform : ITransform
    {
        public override string ToString() => "xml => json";

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
                return JsonConvert.SerializeXmlNode(node);
            }
            catch (Exception ex)
            {
                return $"Unable to write json: {ex.Message}" + Environment.NewLine + text;
            }
        }
    }
}
