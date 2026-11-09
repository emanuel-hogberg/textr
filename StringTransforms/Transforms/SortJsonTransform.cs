using StringTransforms.Interfaces;
using System;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace StringTransforms.Transforms
{
    internal class SortJsonTransform : ITransform
    {
        public string Transform(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return text;

            JsonDocument doc;
            try
            {
                doc = JsonDocument.Parse(text);
            }
            catch (Exception ex)
            {
                return $"Unable to parse JSON: {ex.Message}" + Environment.NewLine + text;
            }

            using (doc)
            {
                var options = new JsonWriterOptions { Indented = true };
                using (var stream = new MemoryStream())
                {
                    using (var writer = new Utf8JsonWriter(stream, options))
                    {
                        WriteElementSorted(doc.RootElement, writer);
                    }
                    return System.Text.Encoding.UTF8.GetString(stream.ToArray());
                }
            }
        }

        private static void WriteElementSorted(JsonElement element, Utf8JsonWriter writer)
        {
            switch (element.ValueKind)
            {
                case JsonValueKind.Object:
                    writer.WriteStartObject();
                    foreach (var property in element.EnumerateObject().OrderBy(p => p.Name, StringComparer.Ordinal))
                    {
                        writer.WritePropertyName(property.Name);
                        WriteElementSorted(property.Value, writer);
                    }
                    writer.WriteEndObject();
                    break;

                case JsonValueKind.Array:
                    writer.WriteStartArray();
                    foreach (var item in element.EnumerateArray())
                        WriteElementSorted(item, writer);
                    writer.WriteEndArray();
                    break;

                default:
                    element.WriteTo(writer);
                    break;
            }
        }

        public override string ToString() => "Sort JSON by key";
    }
}
