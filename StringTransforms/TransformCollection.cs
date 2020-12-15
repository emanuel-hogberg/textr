﻿using emanuel.Extensions;
using StringTransforms.Interfaces;
using System.Collections.Generic;

namespace StringTransforms
{
    public class TransformCollection : ITransformCollection
    {
        private readonly List<ITransform> transforms = new List<ITransform>();
        private readonly TransformCollectionSelector selector;

        public TransformCollectionSelector Selector => selector;

        public TransformCollection(TransformCollectionSelector selector)
        {
            this.selector = selector;
        }

        public void MoveSelectedTransform(bool up)
        {
            var i = selector.SelectedIndex;
            if (up)
            {
                if (i > 0)
                {
                    var t = transforms[i];
                    transforms.Remove(t);
                    transforms.Insert(i - 1, t);

                    selector.UpdateResult();
                    selector.SelectedIndex = i - 1;
                }
            }
            else
            {
                if (i < transforms.Count - 1)
                {
                    var t = transforms[i];
                    transforms.Remove(t);
                    transforms.Insert(i + 1, t);

                    selector.UpdateResult();
                    selector.SelectedIndex = i + 1;
                }
            }
        }

        public void RemoveSelectedTransform()
        {
            var transform = transforms[selector.SelectedIndex];

            transforms.Remove(transform);
        }

        public void Clear()
        {
            transforms.Clear();
        }

        public bool IsValidIndexSelected()
            => selector.SelectedIndex.Between(0, transforms.Count - 1);

        public void RemoveLast()
        {
            transforms.Remove(transforms[transforms.Count - 1]);
        }
    }
}
