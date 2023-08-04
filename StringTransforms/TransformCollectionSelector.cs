using StringTransforms.Interfaces;
using System;

namespace StringTransforms
{
    public class TransformCollectionSelector : ITransformCollectionSelector
    {
        public int SelectedIndex { get; internal set; }

        internal void UpdateResult()
        {
            // throw new NotImplementedException();
        }
    }
}
