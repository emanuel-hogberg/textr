using StringTransforms.Interfaces;
using StringTransforms.Transforms;

namespace StringTransforms.Services
{
    public class TransformFactoryService : ITransformFactoryService
    {
        public ITransform CreateBase64DecodeTransform()
            => new Base64DecodeTransform();
        public ITransform CreateBase64EncodeTransform()
            => new Base64EncodeTransform();
        public ITransform CreateDistinctTransform()
            => new DistinctTransform();
        public ITransform CreateFindReplaceTransform(string find, string replace, bool isChecked)
            => new FindReplaceTransform(find, replace, isChecked);
        public IJsonXmlTransform CreateJsonXmlTransform(bool pascalCasing)
            => new JsonXmlTransform()
            {
                PascalCasing = pascalCasing
            };
        public ITransform CreateMathTransform(IMathService mathService)
            => new MathTransform(mathService);
        public ITransform CreateNewLineAfterXOccurencesOfY(int occurences, string text, bool caseSensitive, bool before)
            => new NewLineAfterXOccurencesOfY(occurences, text, caseSensitive, before);
        public ITransform CreateNewLineCharFix()
            => new NewLineCharFix();
        public ITransform CreateRemoveBlankLinesTransform()
            => new RemoveBlankLinesTransform();
        public ITransform CreateRemoveNewLineTransform()
            => new RemoveNewLineTransform();
        public ITransform CreateTruncateTransform(bool fromStart, bool ignoreCase, string truncate)
            => new TruncateTransform()
            {
                FromStart = fromStart,
                IgnoreCase = ignoreCase,
                Truncate = truncate
            };
        public ITransform CreateXmlJsonTransform()
            => new XmlJsonTransform();
    }
}
