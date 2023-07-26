using emanuelib.Gremlin;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace textrTests
{
    [TestClass]
    public class GremlinTests
    {
        [TestMethod]
        public void Gremlin_Query()
        {
            const string Query =
                "g.V('000025', '000399', '008082').as('start')" +
                ".hasLabel('item').as('i').limit(1)" +
                ".out('relatedPricelistRow').as ('r')" +
                ".out('requiresPricelistHead').as ('h')" +
                ".project('item', 'updatedWhen', 'head', 'row')" +
                ".by(select('i').id())" +
                ".by(project('head', 'row')" +
                ".by(select('h').values('updatedWhen'))" +
                ".by(select('r').values('updatedWhen'))" +
                ".by(select('h')).by(select('r').valueMap(true, 'qty', 'price'))";
            const string ExpectedPrettifiedQuery =
@"g.V('000025', '000399', '008082').as('start')
    .hasLabel('item').as('i').limit(1)
    .out('relatedPricelistRow').as ('r')
    .out('requiresPricelistHead').as ('h')
.project('item', 'updatedWhen', 'head', 'row')
    .by(select('i').id())
    .by(project('head', 'row')
        .by(select('h').values('updatedWhen'))
        .by(select('r').values('updatedWhen'))
        .by(select('h'))
    .by(select('r').valueMap(true, 'qty', 'price'))";

            var prettified = GremlinBuilder.Start(Query);

            Assert.AreEqual(ExpectedPrettifiedQuery, prettified);
        }

        [DataTestMethod]
        [DataRow(".as('s').limit(1)", ".out()")]
        [DataRow(".as('start')", ".hasLabel('item')")]
        [DataRow("", ".hasLabel('item')")]
        public void Gremlin_Skip(string expectedSkipped, string expectedRest)
        {
            var testQuery = expectedSkipped + expectedRest;

            var skippers = new[]
            {
                "as",
                "limit"
            };

            GremlinBuilder.Skip(testQuery, skippers, out var skipped, out var rest);

            Assert.AreEqual(expectedRest, rest);
            Assert.AreEqual(expectedSkipped, skipped);
        }

        [DataTestMethod]
        [DataRow("by", "", "")]
        [DataRow("by", "", ".by(...)")]
        [DataRow("by", "select('s')", "")]
        [DataRow("by", "'str'", "")]
        [DataRow("by", "'str'", ".by(...)")]
        [DataRow("by", "select('s')", ".by(...)")]
        [DataRow("by", "select('s').id()", ".by(...)")]
        public void Gremlin_GetInner(string expectedOuter, string expectedInner, string expectedRest)
        {
            var testQuery = "." + expectedOuter + "("+ expectedInner + ")" + expectedRest;

            var inner = GremlinBuilder.GetInner(testQuery, out var prefix, out var outer, out var rest);

            Assert.AreEqual(".", prefix);
            Assert.AreEqual(expectedOuter, outer);
            Assert.AreEqual(expectedInner, inner);
            Assert.AreEqual(expectedRest, rest);
        }
    }
}
