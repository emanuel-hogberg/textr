namespace StringTransforms.Interfaces
{
    public interface ITransformService
    {
        ITransformService AddTransform(ITransform transform, ITransformCollection transforms);
        ITransformService EditTranform(ITransformCollection transforms);
        ITransformService RemoveTranform(ITransformCollection transforms);
        ITransformService RemoveAllTransforms(ITransformCollection transforms);
        string ApplyTransforms(ITransformCollection transforms, string text);
        TransformCollection GetNewTransformCollection();
        ITransformService Undo(ITransformCollection transformCollection);
        ITransformService MoveSelectedTransform(ITransformCollection transformCollection, bool up);
    }
}
