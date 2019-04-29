using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using emanuel.Transforms;

namespace textrTests
{
    [TestClass]
    public class BatchGroupTransformTests
    {
        IBatchEditLineTransform subject;

        private void SetLine(string line)
        {
            subject = new GroupTransform(line);
        }

        string env2 = Environment.NewLine + Environment.NewLine;

        const string testLine = "hello let's test this thing out";
        const string matchStart = "hello*";
        const string matchStart2 = "hello";
        const string transformStart = "yo hello there*";
        const string transformStartAddEnd = "yo hello there* ok";
        const string transformStart2 = "yo hello there";
        const string resultStart = "yo hello there let's test this thing out";
        const string resultStartAddedEnd = "yo hello there let's test this thing out ok";

        const string matchMid = "let's";
        const string matchMid2 = "*let's*";
        const string transformMid = "let us";
        const string transformMid2 = "*let us*";
        const string resultMid = "hello let us test this thing out";

        const string matchEnd = "*out";
        const string matchEnd2 = "out";
        const string transformEnd = "*out ok";
        const string transformEndAddStart = "hehe *out ok";
        const string transformEnd2 = "out ok";
        const string resultEnd = "hello let's test this thing out ok";
        const string resultEndAddedStart = "hehe hello let's test this thing out ok";

        const string matchMulti = "let*this";
        const string matchMulti2 = "*let*this";
        const string matchMulti3 = "let*this*";
        const string transformMulti = "leet*thiis";
        const string transformMulti2 = "*leet*thiis";
        const string transformMulti3 = "leet*thiis*";
        const string resultMulti = "hello leet's test thiis thing out";
        
        const string matchMulti4 = "he*l**out";
        const string transformMulti4 = "hey he*ll**out ok";
        const string resultMulti4= "hey helllo let's test this thing out ok";


        class Tester
        {
            TestPart _mode;
            // select, selectResult, targetName
            Action<string, string, string> SelectionAssertion;
            // select, (string)transform, transformResult, targetName
            Action<string, string, string, string> TransformAssertion;

            public Tester(TestPart mode, Action<string, string, string> selectionAssertion = null, Action<string, string, string, string> transformAssertion = null)
            {
                _mode = mode;
                SelectionAssertion = selectionAssertion;
                TransformAssertion = transformAssertion;
            }

            public enum TestPart
            {
                Selection,
                Transform
            }

            public void PerformTests()
            {
                TestMatch(matchStart, testLine.Replace("hello", "HELLO"), transformStart, resultStart, "matchStart");
                TestMatch(matchStart, testLine.Replace("hello", "HELLO"), transformStartAddEnd, resultStartAddedEnd, "matchStartAddEnd");
                TestMatch(matchStart2, testLine.Replace("hello", "HELLO"), transformStart2, resultStart, "matchStart2");

                TestMatch(matchMid, testLine.Replace("let's", "LET'S"), transformMid, resultMid, "matchMid");
                TestMatch(matchMid2, testLine.Replace("let's", "LET'S"), transformMid2, resultMid, "matchMid2");

                TestMatch(matchEnd, testLine.Replace("out", "OUT"), transformEnd, resultEnd, "matchEnd");
                TestMatch(matchEnd, testLine.Replace("out", "OUT"), transformEndAddStart, resultEndAddedStart, "matchEndAddedStart");
                TestMatch(matchEnd2, testLine.Replace("out", "OUT"), transformEnd2, resultEnd, "matchEnd2");

                TestMatch(testLine, testLine.ToUpper(), "oh ok", "oh ok", "full match");

                TestMatch(matchMulti, testLine.Replace("let", "LET").Replace("this", "THIS"), transformMulti, resultMulti, "multi1");
                TestMatch(matchMulti2, testLine.Replace("let", "LET").Replace("this", "THIS"), transformMulti2, resultMulti, "multi2");
                TestMatch(matchMulti3, testLine.Replace("let", "LET").Replace("this", "THIS"), transformMulti3, resultMulti, "multi3");
                TestMatch(matchMulti4, testLine.Replace("hel", "HEL").Replace("out", "OUT"), transformMulti4, resultMulti4, "multi4");
            }

            private void TestMatch(string select, string selectResult, object transform, string transformResult, string targetName)
            {
                if (_mode == TestPart.Selection)
                {
                    SelectionAssertion(select, selectResult, targetName);
                }
                else
                {
                    if (transform is string)
                        TransformAssertion(select, (string)transform, transformResult, targetName);
                    else
                        foreach (string s in (transform as string[]))
                            TransformAssertion(select, s, transformResult, targetName);
                }
            }
        }

        [TestMethod]
        public void GroupTransform_Selection_Match()
        {
            SetLine(testLine);

            new Tester(Tester.TestPart.Selection, selectionAssertion: (selection, selectResult, testName) =>
            {
                subject.Select(selection);
                Assert.IsTrue(subject.Match, env2 + $"{testName} did not produce subject.Match = true! subject.Selection == '{subject.Selection}'");
                Assert.AreEqual(selectResult, subject.Selection, ignoreCase: false, message: env2 + $"{testName} did not produce expected Selection: '{subject.Selection}'!");
            }).PerformTests();
        }

        [TestMethod]
        public void GroupTransform_Transform_Results()
        {
            SetLine(testLine);

            new Tester(Tester.TestPart.Transform, transformAssertion: (select, transform, result, testName) =>
                {
                    subject.Select(select)
                        .SetTransform(transform);
                    Assert.IsTrue(subject.Match, env2 + $"Selection {subject.Selection} had Match=false for transform '{transform}', {testName}.");
                    Assert.AreEqual(result, subject.Result, env2 + $"Incorrect result for transform test {testName}: exptected '{result}', found '{subject.Result}'");
                }).PerformTests();
        }

        [TestMethod]
        public void GroupTransform_SetLine_NoMatch()
        {
            SetLine(testLine);
            Assert.IsFalse(subject.Match);
            Assert.IsTrue(string.IsNullOrEmpty(subject.Result));
        }

        [TestMethod]
        public void GroupTransform_Selection_AsteriskMismatch()
        {
            SetLine(testLine);
            string sel = "*hello", transform = "";

            Func<int, string> errorMsg = i => $"Asterisk mismatch unexpectedly produced result for {env2}selection {sel}=>'{subject.Selection}', {env2}transform '{transform}'{env2}Test {i}. Result is {subject.Result}, selection is {subject.Selection}";

            // If transfrom is empty, the result is expected to be empty as well.
            Assert.IsTrue(
                subject
                    .Select(sel)
                    .SetTransform(transform)
                    .Result == string.Empty,
                "Test 1 failed: Empty transform did not produce empty result.");
            
            // If the selection and transform have a mismatch, the result should equal the selection.
            transform = "hello";
            Assert.IsTrue(
                subject
                    .Select(sel)
                    .SetTransform(transform)
                    .Result == subject.Selection,
                errorMsg(2));
            
            sel = "out"; transform = "*oout*";
            Assert.IsTrue(
                subject
                    .Select(sel)
                    .SetTransform(transform)
                    .Result == subject.Selection,
                errorMsg(3));

            sel = "let*out"; transform = "oout*leet*";
            Assert.IsTrue(
                subject
                    .Select(sel)
                    .SetTransform(transform)
                    .Result == subject.Selection,
                errorMsg(4));
        }
    }
}
