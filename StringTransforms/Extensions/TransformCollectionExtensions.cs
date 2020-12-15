using StringTransforms.Interfaces;

namespace StringTransforms.Extensions
{
    static internal class TransformCollectionExtensions
    {
        internal static TransformCollection Concrete(this ITransformCollection self)
            => (TransformCollection)self;
    }
}
