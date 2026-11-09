using StringTransforms.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace StringTransforms.Transforms
{
    /// <summary>
    /// Splits a url into its base (first line) followed by one decoded key=value line per query parameter.
    /// A fragment, if any, ends up on a last line starting with '#'.
    /// </summary>
    internal class UrlToParamsTransform : ITransform
    {
        public string Transform(string text)
        {
            var url = text.Trim();

            var fragmentIndex = url.IndexOf('#');
            var fragment = fragmentIndex >= 0 ? url.Substring(fragmentIndex) : null;
            if (fragmentIndex >= 0)
            {
                url = url.Substring(0, fragmentIndex);
            }

            var queryIndex = url.IndexOf('?');
            if (queryIndex < 0)
            {
                return text;
            }

            var lines = new List<string> { url.Substring(0, queryIndex) };
            lines.AddRange(url
                .Substring(queryIndex + 1)
                .Split(new[] { '&' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(DecodeParameter));

            if (fragment != null)
            {
                lines.Add(fragment);
            }

            return string.Join(Environment.NewLine, lines);
        }

        private static string DecodeParameter(string parameter)
        {
            var equalsIndex = parameter.IndexOf('=');
            return equalsIndex < 0
                ? WebUtility.UrlDecode(parameter)
                : WebUtility.UrlDecode(parameter.Substring(0, equalsIndex))
                    + "="
                    + WebUtility.UrlDecode(parameter.Substring(equalsIndex + 1));
        }

        public override string ToString()
            => "Url to parameters, one per line";
    }

    /// <summary>
    /// Reverse of <see cref="UrlToParamsTransform"/>: first line is the base url, each following
    /// key=value line is encoded into the query string, a line starting with '#' is the fragment.
    /// </summary>
    internal class ParamsToUrlTransform : ITransform
    {
        // .NET Framework's Uri.EscapeDataString throws on long input, so escape in chunks.
        private const int EscapeChunkSize = 16000;

        public string Transform(string text)
        {
            var lines = text
                .Split('\n')
                .Select(line => line.TrimEnd('\r'))
                .Where(line => !string.IsNullOrWhiteSpace(line))
                .ToList();

            if (lines.Count == 0)
            {
                return string.Empty;
            }

            var baseUrl = lines[0].Trim();
            var fragment = lines.Skip(1).LastOrDefault(line => line.StartsWith("#"));
            var parameters = lines
                .Skip(1)
                .Where(line => !line.StartsWith("#"))
                .Select(EncodeParameter)
                .ToList();

            var url = parameters.Count == 0
                ? baseUrl
                : baseUrl + "?" + string.Join("&", parameters);

            return url + fragment;
        }

        private static string EncodeParameter(string line)
        {
            var equalsIndex = line.IndexOf('=');
            return equalsIndex < 0
                ? Escape(line)
                : Escape(line.Substring(0, equalsIndex)) + "=" + Escape(line.Substring(equalsIndex + 1));
        }

        private static string Escape(string value)
        {
            var result = new StringBuilder(value.Length);
            var start = 0;
            while (start < value.Length)
            {
                var length = Math.Min(EscapeChunkSize, value.Length - start);
                if (start + length < value.Length && char.IsHighSurrogate(value[start + length - 1]))
                {
                    length--;
                }

                result.Append(Uri.EscapeDataString(value.Substring(start, length)));
                start += length;
            }

            return result.ToString();
        }

        public override string ToString()
            => "Parameters to url, encoding each value";
    }
}
