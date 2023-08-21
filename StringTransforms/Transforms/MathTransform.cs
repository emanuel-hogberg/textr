using StringTransforms.Interfaces;

namespace StringTransforms.Transforms
{
    internal class MathTransform : ITransform
    {
        private readonly IMathService _mathService;

        public MathTransform(IMathService mathService)
            => _mathService = mathService;

        public string Transform(string text)
            => _mathService.SplitOutHooks(text) +
               " = " +
               (_mathService.MathExpression(text, out string error, out double calculation)
                   ? calculation.ToString()
                   : error);

        public override string ToString()
            => "Math expression (use <> for partial expression)";
    }
}
