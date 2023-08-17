using StringTransforms.Interfaces;
using System;

namespace StringTransforms
{
    public abstract class EditableTransform : IEditableTransform
    {
        public IEditableProperties Edit()
        {
            IsBeingEdited = true;

            Editing?.Invoke(this, new EventArgs());
            return GetEditableProperties();
        }
        public abstract void Save(IEditableProperties amendments);
        public abstract IEditableProperties GetEditableProperties();

        public abstract string Transform(string text);

        public event EventHandler Editing;

        public bool IsBeingEdited { get; private set; }
    }
}
