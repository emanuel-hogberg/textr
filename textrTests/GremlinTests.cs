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

        [TestMethod]
        public void Gremlin_Skip()
        {
            const string expectedSkipped = ".as('s').limit(1)";
            const string expectedRest = ".out()";
            const string testQuery = expectedSkipped + expectedRest;

            var skippers = new[]
            {
                "as",
                "limit"
            };

            GremlinBuilder.Skip(testQuery, skippers, out var skipped, out var rest);

            Assert.AreEqual(expectedRest, rest);
            Assert.AreEqual(expectedSkipped, skipped);
        }

        [TestMethod]
        public void Gremlin_GetInner()
        {
            const string expectedOuter = "by";
            const string expectedInner = "select('s').id()";
            const string expectedRest = ".by(...)";
            const string testQuery = "." + expectedOuter + "("+ expectedInner + ")" + expectedRest;

            var inner = GremlinBuilder.GetInner(testQuery, out var prefix, out var outer, out var rest);

            Assert.AreEqual(".", prefix);
            Assert.AreEqual(expectedRest, rest);
            Assert.AreEqual(expectedInner, inner);
            Assert.AreEqual(expectedOuter, outer);
        }
    }
}
