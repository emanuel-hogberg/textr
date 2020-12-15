using StringTransforms.Interfaces;
using System;

namespace StringTransforms
{
    public class TransformCollectionSelector
    {
        public int SelectedIndex { get; internal set; }

        internal void UpdateResult()
        {
            throw new NotImplementedException();
        }

        internal IEditableTransform GetEditableTransforms()
        {
            throw new NotImplementedException();
        }
    }
}
