using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emanuel.Transforms
{
    public abstract class EditableTransform : ITransform
    {
        public IEditableProperties Edit()
        {
            IsBeingEdited = true;

            Editing?.Invoke(this, new EventArgs());
            return GetEditableProperties();
        }
        public abstract void Save(IEditableProperties amendments);
        internal abstract IEditableProperties GetEditableProperties();

        public abstract string Transform(string text);

        public event EventHandler Editing;

        public bool IsBeingEdited { get; private set; }
    }

    public interface IEditableProperties
    {

    }
}
