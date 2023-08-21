using emanuel.Extensions;
using org.mariuszgromada.math.mxparser;
using StringTransforms.Interfaces;
using System;
using System.Runtime.Serialization;
using Expression = org.mariuszgromada.math.mxparser.Expression;

namespace StringTransforms.Services
{
    public class MathService : IMathService
    {
        public MathService()
        {
            if (!License.checkIfUseTypeConfirmed())
            {
                License.iConfirmNonCommercialUse("Emanuel Högberg");
            }
        }

        public string GetLicense() => License.getUseTypeConfirmationMessage();

        public bool MathExpression(string stringExpression, out string error, out double calculation)
        {
            if (!License.checkIfUseTypeConfirmed())
            {
                throw new MathLicenseException();
            }

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

        public string SplitOutHooks(string t)
            => t.Contains("<") && t.Contains(">")
                ? t.Split('<', '>')[1]
                : t;

        [Serializable]
        private class MathLicenseException : Exception
        {
            public MathLicenseException()
            {
            }

            public MathLicenseException(string message) : base(message)
            {
            }

            public MathLicenseException(string message, Exception innerException) : base(message, innerException)
            {
            }

            protected MathLicenseException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }
        }
    }
}