using System;

namespace StringTransforms.Interfaces
{
    public interface IEditableTransform : ITransform
    {
        event EventHandler Editing;
    }
}
