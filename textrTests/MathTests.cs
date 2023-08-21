using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringTransforms.Transforms;
using textr.Transforms;

namespace textrTests
{
    [TestClass]
    public class MathTests
    {
        [TestMethod]
        public void MathTransform_Addition_Equals()
        {
            const string Sum = "2 + 2";

            var transform = new MathTransform();

            Assert.AreEqual($"{Sum} = 4", transform.Transform(Sum));
        }
    }
}
