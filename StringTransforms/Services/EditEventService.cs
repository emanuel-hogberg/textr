using emanuel.Extensions;
using StringTransforms.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StringTransforms.Services
{
    public class EditEventService : IEditEventService
    {
        private Dictionary<Type, Action<IEditableProperties>> types = new Dictionary<Type, Action<IEditableProperties>>();
        private EditableTransform editing = null;
        private event EventHandler Editing;

        public EditEventService()
        {

        }

        public void NewTransformAdded(ITransformCollection transforms)
            => (transforms as TransformCollection)
                .GetEditableTransforms()
                .Do(t =>
                {
                    if (types.ContainsKey(t.GetType()))
                    {
                        t.Editing += EditingTransform;
                    }
                });

        public void SetEditingEvent(EventHandler editingEventHandler)
            => Editing += editingEventHandler;

        private void EditingTransform(object sender, EventArgs e)
        {
            editing = (EditableTransform)sender;
            types[sender.GetType()](editing.GetEditableProperties());
            Editing?.Invoke(this, new EventArgs());
        }

        public bool Save(IEditableProperties props)
        {
            if (props.GetType().Equals(editing.GetEditableProperties()))
                return false;

            editing.Save(props);
            editing = null;

            return true;
        }

        public void RegisterEditableType(Type editableTransformType, Action<IEditableProperties> editFunction)
        {
            if (!types.ContainsKey(editableTransformType))
            {
                types.Add(editableTransformType, editFunction);
            }
        }

        public void CancelEdit() => editing = null;
    }
}
