using emanuelib.Gremlin;

namespace emanuel.Transforms
{
    public class GremlinTransform : ITransform
    {
        public string Transform(string text)
            => GremlinBuilder.Start(text);
    }
}