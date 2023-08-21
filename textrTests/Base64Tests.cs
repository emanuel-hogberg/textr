using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringTransforms.Interfaces;
using StringTransforms.Services;

namespace textrTests
{
    [TestClass]
    public class Base64Tests
    {
        private readonly ITransformFactoryService _transformFactoryService = new TransformFactoryService();

        [TestMethod]
        public void Base64Transform_EncodeDecode_Match()
        {
            const string TestString = "Hallå!";

            var encoder = _transformFactoryService.CreateBase64EncodeTransform();
            var decoder = _transformFactoryService.CreateBase64DecodeTransform();

            var encoded = encoder.Transform(TestString);

            Assert.IsFalse(string.IsNullOrEmpty(encoded));
            Assert.IsFalse(encoded.Contains("Exception"));

            var decoded = decoder.Transform(encoded);

            Assert.AreEqual(TestString, decoded);
        }

    }
}
