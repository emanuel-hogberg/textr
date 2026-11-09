using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringTransforms.Interfaces;
using StringTransforms.Services;

namespace textrTests
{
    [TestClass]
    public class SortJsonTests
    {
        private readonly ITransformFactoryService _transformFactoryService = new TransformFactoryService();

        [TestMethod]
        public void SortJsonTransform_NestedObjectsInArray_SortsKeysKeepsArrayOrder()
        {
            var transform = _transformFactoryService.CreateSortJsonTransform();

            var result = transform.Transform("{\"b\":[{\"z\":1,\"y\":2},3],\"a\":{\"d\":true,\"c\":null}}");

            var compact = result.Replace(" ", "").Replace("\r", "").Replace("\n", "");
            Assert.AreEqual("{\"a\":{\"c\":null,\"d\":true},\"b\":[{\"y\":2,\"z\":1},3]}", compact);
        }

        [TestMethod]
        public void SortJsonTransform_InvalidJson_ReturnsMessageAndOriginalText()
        {
            var transform = _transformFactoryService.CreateSortJsonTransform();

            var result = transform.Transform("{not json");

            StringAssert.StartsWith(result, "Unable to parse JSON:");
            StringAssert.EndsWith(result, "{not json");
        }
    }
}
