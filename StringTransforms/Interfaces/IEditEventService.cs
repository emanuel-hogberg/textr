using System;

namespace StringTransforms.Interfaces
{
    public interface IEditEventService
    {
        void CancelEdit();
        void NewTransformAdded(ITransformCollection transforms);
        void RegisterEditableType(Type editableTransformType, Action<IEditableProperties> editFunction);
        bool Save(IEditableProperties props);
        void SetEditingEvent(EventHandler editingEventHandler);
    }
}
