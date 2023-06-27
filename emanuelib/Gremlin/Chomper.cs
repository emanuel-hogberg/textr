using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace emanuelib.Gremlin
{
    /*
     *  g.V("000025", "000399", "008082").as('start') <-- start() skip()
          .hasLabel('item').as('i').limit(1) <- indent skip()
          .out('relatedPricelistRow').as('r') <-- newline pga Step
          .out('requiresPricelistHead').as('h')
        .project('item','updatedWhen','head', 'row')
          .by(select('i').id())
          .by(project('head','row')
            .by(select('h').values('updatedWhen'))
            .by(select('r').values('updatedWhen'))
          ,by(select('h'))
          .by(select('r').valueMap(true, 'qty','price'))
     *
     * ny rad efter:
     * .project()
     *
     * ny rad före:
     * .out()
     * .in()
     * .outE()...inV()
     * .inV()...outE()
     * .by()
     *
     * öka indent efter:
     * g.V() fram till step()
     *
     */

    public static class GremlinBuilder
    {
        private static readonly RegexOptions RegexOptions = RegexOptions.CultureInvariant | RegexOptions.IgnoreCase;
        private const string IndentSpace = "  ";
        private static readonly string NewLine = Environment.NewLine;
        private static readonly string[] Projections =
        {
            "project",
            "valueMap",
            "values",
        };
        private static readonly string[] Statements =
        {
            "identity",
            "limit",
            "as",
            "inject",
        };
        private static readonly string[] Steps =
        {
            "out",
            "in",
            "outE",
            "inE",
            "outV",
            "inV",
        };

        private static readonly string[] Filters =
        {
            "by",
            "has",
            "hasLabel",
            "hasId",
        };

        public static string Start(string text)
        {
            text = text
                .Replace(@"\n", string.Empty)
                .Replace(@"\r", string.Empty)
                .Replace(Environment.NewLine, string.Empty);

            // First ensure the text is in the for g.V(...)... or g.E(...)...
            var match = Regex.Match(text, @"(g\.[VE]\(.+?\))(.+)", RegexOptions);
            if (!match.Success)
            {
                return text;
            }

            var start = match.Groups[1].Value;
            // Let any of the Statements stay on the first row next to g.[VE]
            Skip(match.Groups[2].Value, Statements, out var skipped, out var rest);

            return start + skipped + NewLine + IndentUntil(rest, Projections, 1);
        }

        private static Match RegexMatchArray(string text, string[] targets)
            => targets
                .Select(s =>
                    Regex.Match(text, $@"(.*)(\.{Regex.Escape(s)})(\(.*?\))(.*)"))
                .FirstOrDefault(m => m.Success);

        private static string Indent(int indentLevel)
        {
            var sb = new StringBuilder();
            for (var i = 0; i <= indentLevel; i++)
            {
                sb.Append(IndentSpace);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Indents new lines until a stopper is found.
        /// </summary>
        public static string IndentUntil(string text, string[] stoppers, int indentLevel)
        {
            if (string.IsNullOrEmpty(text))
            {
                return string.Empty;
            }

            var match = RegexMatchArray(text, stoppers);

            if (match?.Success != true)
            {
                return InsertNewLines(text, indentLevel - 1);
            }

            var head = InsertNewLines(match.Groups[1].Value, indentLevel);
            var stopper = match.Groups[2].Value + match.Groups[3].Value;
            var rest = InsertNewLines(match.Value + match.Groups[1].Value, indentLevel);

            return Indent(indentLevel) + head + NewLine + stopper + NewLine + Indent(indentLevel) + rest;
        }

        /// <summary>
        /// Recursively identifies the first statement, then Next(next statement), adding new lines.
        /// </summary>
        public static string InsertNewLines(string text, int indentLevel)
        {
            if (text.StartsWith(@"'") && text.EndsWith(@"'") ||
                text.StartsWith("\"") && text.EndsWith("\"") ||
                string.IsNullOrEmpty(text))
            {
                return text;
            }

            Skip(text, Statements, out var skipped, out var notSkipped);

            var inner = GetInner(notSkipped, out var outerPrefix, out var outer, out var rest);

            if (Steps.Contains(outer.Replace(".", string.Empty)))
            {
                outer = NewLine + outer;
            }

            var nextInner = InsertNewLines(inner, indentLevel + 1);
            var nextRest = InsertNewLines(rest, indentLevel);

            return skipped + outerPrefix + outer + nextInner + nextRest;

        }

        /// <summary>
        /// The Skip method breaks out any parts matching a "skipper" into the skipped string,
        /// and returns the rest in the rest string.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="skippers"></param>
        /// <param name="skipped"></param>
        /// <param name="rest"></param>
        public static void Skip(string text, string[] skippers, out string skipped, out string rest)
        {
            skipped = string.Empty;
            var textRest = text;

            while (true)
            {
                var inner = GetInner(textRest, out var prefix, out var outer, out textRest);

                if (skippers.Contains(outer))
                {
                    skipped += prefix + outer + $"({inner})";
                }
                else
                {
                    rest = textRest;

                    break;
                }
            }
        }

        /// <summary>
        /// If the text is .by(select('s')).by(...), this method sets outer to .by,
        /// sets rest to .by(...), outerStartsWithDot = true and returns select('s').
        /// In essence: [prefix][outer]([inner])[rest]
        /// </summary>
        public static string GetInner(string text, out string prefix, out string outer, out string rest)
        {
            prefix = string.Empty;
            text = text.Trim();
            if (text.StartsWith("."))
            {
                prefix = ".";
                text = text.TrimStart('.');
            }

            var match = Regex.Match(text, @"(.+?)\((.*?)\)(.*)");
            outer = string.Empty;
            rest = string.Empty;

            if (match.Success != true)
            {
                return text;
            }

            outer = match.Groups[1].Value;
            rest = match.Groups[3].Value;

            return match.Groups[2].Value;
        }
    }

    /*
    internal abstract class Chomper : IChomper
    {
        public abstract string Chomp(string text);

        internal string NextOne(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return String.Empty;
            }

            var next = text[0];
            var rest = text.Skip(1);

            return next switch
            {
                "(" => Parenthesis(rest),
            };
        }
    }

    internal interface IChomper
    {
    }

    public class GremlinPrettifier : Chomper
    {
        private GremlinPrettifier()
        {

        }

        public GremlinPrettifier Prettify(string gremlinQuery)
        {

        }
    }

    public class Parenthesis : Chomper
    {

    }
    */
}
