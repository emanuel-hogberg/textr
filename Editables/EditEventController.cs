using emanuel.Extensions;
using emanuel.Transforms;
using System;
using System.Collections.Generic;
using System.Linq;

namespace textr.Editables
{
    public class EditEventController
    {
        private Dictionary<Type, Action<IEditableProperties>> types = new Dictionary<Type, Action<IEditableProperties>>();
        private EditableTransform editing = null;

        private EditEventController()
        {

        }

        public event EventHandler Editing;

        private static EditEventController instance = new EditEventController();
        public static EditEventController Instance { get => instance; }

        public void NewTransformAdded(List<ITransform> transforms)
        {
            transforms
                .Where(t => t is EditableTransform)
                .Select(t => t as EditableTransform)
                .Do(t =>
                {
                    if (types.ContainsKey(t.GetType()))
                    {
                        t.Editing += EditingTransform;
                    }
                });
        }

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

        internal void CancelEdit()
        {
            editing = null;
        }
    }
}
