using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringTransforms.Interfaces;
using StringTransforms.Services;
using System;

namespace textrTests
{
    [TestClass]
    public class MathTests
    {
        readonly IMathService _mathService = new MathService();
        private readonly ITransformFactoryService _transformFactoryService = new TransformFactoryService();

        [TestMethod]
        public void MathTransform_Addition_Equals()
        {
            const string Sum = "2 + 2";

            var transform = _transformFactoryService.CreateMathTransform(_mathService);

            var calculationResult = transform.Transform(Sum);

            Assert.AreEqual($"{Sum} = 4", calculationResult);
        }

        [TestMethod]
        public void MathTransform_LicenseConfirmedAndSigned()
        {
            const string ConfirmationMessage = "You \"Emanuel Högberg\" have confirmed the non-commercial use according to the License.geTermsOfAgreement(). Thank you.";

            var licenseMessage = _mathService.GetLicense()
                .TrimEnd(Environment.NewLine.ToCharArray());

            Assert.AreEqual(licenseMessage, ConfirmationMessage);
        }
    }
}
