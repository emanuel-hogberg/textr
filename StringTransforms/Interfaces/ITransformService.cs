namespace StringTransforms.Interfaces
{
    public interface ITransformService
    {
        ITransformService AddTransform(ITransformCollection transforms);
        ITransformService RemoveTranform(ITransformCollection transforms);
        ITransformService EditTranform(ITransformCollection transforms);
        ITransformService ApplyTransforms(ITransformCollection transforms);
    }
}
