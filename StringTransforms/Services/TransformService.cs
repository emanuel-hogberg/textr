using StringTransforms.Extensions;
using StringTransforms.Interfaces;
using System;

namespace StringTransforms.Services
{
    public class TransformService : ITransformService
    {
        private void IfValidIndexSelected(ITransformCollection transforms, Action action)
        {
            if (transforms.Concrete().IsValidIndexSelected())
            {
                action();
            }
        }
        public ITransformService AddTransform(ITransform transform, ITransformCollection transforms)
        {
            throw new NotImplementedException();
        }

        public string ApplyTransforms(ITransformCollection transforms, string text)
        {
            throw new NotImplementedException();
        }

        public void Clear(ITransformCollection transformCollection)
        {
            throw new NotImplementedException();
        }

        public ITransformService EditTranform(ITransform transform, ITransformCollection transforms)
        {
            throw new NotImplementedException();
        }

        public ITransformService EditTranform(ITransformCollection transforms)
        {
            throw new NotImplementedException();
        }

        public ITransformCollection GetNewTransformCollection()
        {
            throw new NotImplementedException();
        }

        public ITransformService MoveSelectedTransform(ITransformCollection transforms, bool up)
        {
            IfValidIndexSelected(transforms, () =>
            {
                transforms.Concrete().MoveSelectedTransform(up);
            });

            return this;
        }

        public ITransformService RemoveAllTransforms(ITransformCollection transforms)
        {
            transforms.Concrete().Clear();

            return this;
        }

        public ITransformService RemoveTranform(ITransformCollection transforms)
        {
            IfValidIndexSelected(transforms, () =>
            {
                transforms.Concrete().RemoveSelectedTransform();
            });

            return this;
        }

        public ITransformService Undo(ITransformCollection transforms)
        {
            transforms.Concrete().RemoveLast();

            return this;
        }

        TransformCollection ITransformService.GetNewTransformCollection()
        => new TransformCollection(new TransformCollectionSelector());
    }
}
