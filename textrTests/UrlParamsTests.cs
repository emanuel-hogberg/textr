using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringTransforms.Interfaces;
using StringTransforms.Services;
using System;

namespace textrTests
{
    [TestClass]
    public class UrlParamsTests
    {
        private const string SearchUrl = "http://localhost:50001/api/Search/FlowSearch?logViewId=53&searchJson=%7B%22FilterGroups%22%3A%5B%7B%22Order%22%3A0%2C%22Operator%22%3A%22OR%22%2C%22Filters%22%3A%5B%7B%22Order%22%3A0%2C%22Id%22%3A26%2C%22Type%22%3A1%2C%22Operator%22%3A%22AND%22%2C%22MathematicalOperatorId%22%3A1%2C%22Value%22%3A%22GitBackup.Zip%22%7D%5D%7D%5D%2C%22NumberOfItems%22%3A100%2C%22Page%22%3A1%2C%22From%22%3A%222026-11-08T23%3A00%3A00Z%22%2C%22To%22%3A%222026-11-09T22%3A59%3A59Z%22%2C%22PostGroupFilterGroups%22%3A%5B%5D%2C%22DataSource%22%3A%7B%22LoadMessageTypeIds%22%3Atrue%2C%22LoadLogAgentIds%22%3Atrue%7D%2C%22GroupCountFilter%22%3A%7B%22From%22%3A0%2C%22To%22%3A0%7D%2C%22GroupSortByDescending%22%3Atrue%2C%22GroupHeaderLastEvent%22%3Afalse%2C%22DisplayGroupSummary%22%3Afalse%7D";

        private readonly ITransformFactoryService _transformFactoryService = new TransformFactoryService();

        private string ToParams(string text) => _transformFactoryService.CreateUrlToParamsTransform().Transform(text);
        private string ToUrl(string text) => _transformFactoryService.CreateParamsToUrlTransform().Transform(text);

        [TestMethod]
        public void UrlToParams_SearchUrl_DecodesOneParameterPerLine()
        {
            var lines = ToParams(SearchUrl).Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            Assert.AreEqual(3, lines.Length);
            Assert.AreEqual("http://localhost:50001/api/Search/FlowSearch", lines[0]);
            Assert.AreEqual("logViewId=53", lines[1]);
            StringAssert.StartsWith(lines[2], "searchJson={\"FilterGroups\":[{\"Order\":0,");
            StringAssert.Contains(lines[2], "\"From\":\"2026-11-08T23:00:00Z\"");
        }

        [TestMethod]
        public void UrlToParams_ThenParamsToUrl_RoundTripsExactly()
        {
            Assert.AreEqual(SearchUrl, ToUrl(ToParams(SearchUrl)));
        }

        [TestMethod]
        public void ParamsToUrl_EditedValue_IsEncoded()
        {
            var edited = ToParams(SearchUrl).Replace("GitBackup.Zip", "Git Backup&Zip");

            var url = ToUrl(edited);

            StringAssert.Contains(url, "Git%20Backup%26Zip");
            Assert.AreEqual(edited, ToParams(url));
        }

        [TestMethod]
        public void UrlToParams_ValueContainingEquals_SplitsOnFirstEqualsOnly()
        {
            const string Url = "http://host/path?filter=a%3Db&flag&empty=";

            var parameters = ToParams(Url);

            Assert.AreEqual(string.Join(Environment.NewLine, "http://host/path", "filter=a=b", "flag", "empty="), parameters);
            Assert.AreEqual(Url, ToUrl(parameters));
        }

        [TestMethod]
        public void UrlToParams_PlusInQuery_DecodesAsSpace()
        {
            Assert.AreEqual("http://host/path" + Environment.NewLine + "q=a b", ToParams("http://host/path?q=a+b"));
        }

        [TestMethod]
        public void UrlToParams_Fragment_RoundTrips()
        {
            const string Url = "http://host/path?a=1#section";

            var parameters = ToParams(Url);

            Assert.AreEqual(string.Join(Environment.NewLine, "http://host/path", "a=1", "#section"), parameters);
            Assert.AreEqual(Url, ToUrl(parameters));
        }

        [TestMethod]
        public void UrlToParams_NoQuery_ReturnsInputUnchanged()
        {
            Assert.AreEqual("http://host/path", ToParams("http://host/path"));
            Assert.AreEqual("http://host/path", ToUrl("http://host/path"));
        }

        [TestMethod]
        public void ParamsToUrl_LongValue_DoesNotThrow()
        {
            var value = new string('å', 70000) + "😀";

            var url = ToUrl("http://host/path" + Environment.NewLine + "v=" + value);

            Assert.AreEqual("http://host/path" + Environment.NewLine + "v=" + value, ToParams(url));
        }
    }
}
