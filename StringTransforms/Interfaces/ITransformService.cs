namespace StringTransforms.Interfaces
{
    public interface ITransformService
    {
        ITransformService AddTransform(ITransform transform, ITransformCollection transforms);
        ITransformService RemoveTranform(ITransformCollection transforms);
        ITransformService RemoveAllTransforms(ITransformCollection transforms);
        string ApplyTransforms(ITransformCollection transforms, string text);
        ITransformCollection GetNewTransformCollection();
        ITransformService Undo(ITransformCollection transformCollection);
        ITransformService MoveSelectedTransform(ITransformCollection transformCollection, bool up);
    }
}
