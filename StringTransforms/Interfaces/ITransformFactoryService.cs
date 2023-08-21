namespace StringTransforms.Interfaces
{
    public interface ITransformFactoryService
    {
        ITransform CreateBase64DecodeTransform();
        ITransform CreateBase64EncodeTransform();
        ITransform CreateDistinctTransform();
        ITransform CreateFindReplaceTransform(string find, string replace, bool caseSensitive = true);
        ITransform CreateJsonXmlTransform(bool pascalCasing);
        ITransform CreateMathTransform(IMathService mathService);
        ITransform CreateNewLineAfterXOccurencesOfY(int occurences, string text, bool caseSensitive, bool before);
        ITransform CreateNewLineCharFix();
        ITransform CreateRemoveBlankLinesTransform();
        ITransform CreateRemoveNewLineTransform();
        ITransform CreateTruncateTransform(bool fromStart, bool ignoreCase, string truncate);
        ITransform CreateXmlJsonTransform();
    }
}
