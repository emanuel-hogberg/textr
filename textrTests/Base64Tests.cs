using Microsoft.VisualStudio.TestTools.UnitTesting;
using textr.Transforms;

namespace textrTests
{
    [TestClass]
    public class Base64Tests
    {
        [TestMethod]
        public void Base64Transform_EncodeDecode_Match()
        {
            const string TestString = "Hallå!";

            var encoder = new Base64EncodeTransform();
            var decoder = new Base64DecodeTransform();

            var encoded = encoder.Transform(TestString);

            Assert.IsFalse(string.IsNullOrEmpty(encoded));
            Assert.IsFalse(encoded.Contains("Exception"));

            var decoded = decoder.Transform(encoded);

            Assert.AreEqual(TestString, decoded);
        }

    }
}
