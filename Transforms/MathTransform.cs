using emanuel.Transforms;
using textr.Helpers;

namespace textr.Transforms
{
    public class MathTransform : ITransform
    {
        public string Transform(string text)
            => MathHelper.SplitOutHooks(text) +
               " = " +
               (MathHelper.MathExpression(text, out string error, out double calculation)
                   ? calculation.ToString()
                   : error);

        public override string ToString()
            => "Math expression (use <> for partial expression)";
    }
}
