namespace StringTransforms.Interfaces
{
    public interface IJsonXmlTransform : ITransform
    {
        string DeserializeRootElementName { get; }
    }
}
