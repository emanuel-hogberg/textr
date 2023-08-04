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
            //if (_editing != null && transform is EditableTransform && EditEventController.Instance.Save((transform as EditableTransform).GetEditableProperties()))
            //{
            //    StopEditing();
            //}
            //else
            //{
            transforms.Concrete().AddTransform(transform);
            

            return this;
        }

        public string ApplyTransforms(ITransformCollection transforms, string text)
            => transforms.Concrete().ApplyTransforms(text);

        public void Clear(ITransformCollection transforms)
        {
            transforms.Concrete().Clear();
        }

        public ITransformService EditTransform(ITransform transform, ITransformCollection transforms)
        {
            throw new NotImplementedException();
        }

        public ITransformService EditTransform(ITransformCollection transforms)
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

        ITransformCollection ITransformService.GetNewTransformCollection()
            => new TransformCollection(new TransformCollectionSelector());
    }
}
