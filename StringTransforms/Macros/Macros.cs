using System.Collections.Generic;
using StringTransforms.Interfaces;

namespace StringTransforms.Macros
{
    internal class Macros
    {
        List<ITransform> transforms = new List<ITransform>();

        public Macros AddTransform(ITransform transform)
        {
            transforms.Add(transform);
            return this;
        }

        public Macros AddTransforms(List<ITransform> transforms)
        {
            this.transforms.AddRange(transforms);
            return this;
        }

        public List<ITransform> ToList() => transforms;
    }
}
