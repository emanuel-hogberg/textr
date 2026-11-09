using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringTransforms.Interfaces;
using StringTransforms.Services;
using System;

namespace textrTests
{
    [TestClass]
    public class UrlParamsTests
    {
        private const string SearchUrl = "https://example.com/api/products/search?categoryId=7&query=%7B%22Filters%22%3A%5B%7B%22Field%22%3A%22Name%22%2C%22Operator%22%3A%22Contains%22%2C%22Value%22%3A%22Widget.Pro%22%7D%5D%2C%22Page%22%3A1%2C%22PageSize%22%3A50%2C%22From%22%3A%222026-01-01T00%3A00%3A00Z%22%2C%22IncludeArchived%22%3Afalse%7D";

        private readonly ITransformFactoryService _transformFactoryService = new TransformFactoryService();

        private string ToParams(string text) => _transformFactoryService.CreateUrlToParamsTransform().Transform(text);
        private string ToUrl(string text) => _transformFactoryService.CreateParamsToUrlTransform().Transform(text);

        [TestMethod]
        public void UrlToParams_SearchUrl_DecodesOneParameterPerLine()
        {
            var lines = ToParams(SearchUrl).Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            Assert.AreEqual(3, lines.Length);
            Assert.AreEqual("https://example.com/api/products/search", lines[0]);
            Assert.AreEqual("categoryId=7", lines[1]);
            StringAssert.StartsWith(lines[2], "query={\"Filters\":[{\"Field\":\"Name\",");
            StringAssert.Contains(lines[2], "\"From\":\"2026-01-01T00:00:00Z\"");
        }

        [TestMethod]
        public void UrlToParams_ThenParamsToUrl_RoundTripsExactly()
        {
            Assert.AreEqual(SearchUrl, ToUrl(ToParams(SearchUrl)));
        }

        [TestMethod]
        public void ParamsToUrl_EditedValue_IsEncoded()
        {
            var edited = ToParams(SearchUrl).Replace("Widget.Pro", "Widget Pro&Max");

            var url = ToUrl(edited);

            StringAssert.Contains(url, "Widget%20Pro%26Max");
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
