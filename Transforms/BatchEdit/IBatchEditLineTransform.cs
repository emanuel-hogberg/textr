using StringTransforms.Interfaces;

namespace emanuel.Transforms
{
    public interface IBatchEditLineTransform : ITransform
    {
        string Line { get; }
        string Selection { get; }
        string Result { get; }
        bool Match { get; }
        IBatchEditLineTransform Select(string selection);
        IBatchEditLineTransform SetTransform(string transform);
        IBatchEditLineTransform CopyTo(IBatchEditLineTransform newTransform);

        bool OnlyViewAffectedLines { get; set; }

        string GetDescription();
        string GetTransformDescription();
        string GetTransformHint();
        ITransform Predecessor { get; set; }
    }
}