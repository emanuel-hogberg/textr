using System.Collections.Generic;

namespace StringTransforms.Interfaces
{
    public interface ITransformCollection
    {
        int Count { get; }

        IList<ITransform> AsDataSource();
        void Clear();

        //void MoveSelectedTransform(bool up);
        //void RemoveSelectedTransform();
        //void Clear();
        //bool IsValidIndexSelected();
        //void RemoveLast();
        //void AddTransform(ITransform transform);
        ITransformCollectionSelector GetSelector();
    }
}
