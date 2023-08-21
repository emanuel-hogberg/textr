using emanuel.Extensions;
using StringTransforms.Interfaces;
using System;
using Expression = org.mariuszgromada.math.mxparser.Expression;

namespace StringTransforms.Transforms
{
    public class MathTransform : ITransform
    {
        public string Transform(string text)
            => SplitOutHooks(text) +
               " = " +
               (MathExpression(text, out string error, out double calculation)
                   ? calculation.ToString()
                   : error);

        public override string ToString()
            => "Math expression (use <> for partial expression)";
        public static bool MathExpression(string stringExpression, out string error, out double calculation)
        {
            var expression = stringExpression
                .Forward(t => SplitOutHooks(t))
                .Forward(t => t.Replace(" ", ""))
                .Forward(t => new Expression(t));

            error = string.Empty;
            calculation = default;

            try
            {
                if (expression.checkSyntax())
                {
                    calculation = expression.calculate();

                    return true;
                }
                else
                {
                    error = expression.getErrorMessage()
                        .Forward(e =>
                            "Math error: " +
                            e.Substring(0, Math.Min(e.Length, 30)) +
                            " - write your expression within < and > if you want.");
                }

            }
            catch (Exception e)
            {
                error = "Unexpected error: " + e.Message;
            }

            return false;
        }

        public static string SplitOutHooks(string t)
            => t.Contains("<") && t.Contains(">")
                ? t.Split('<', '>')[1]
                : t;
    }
}
