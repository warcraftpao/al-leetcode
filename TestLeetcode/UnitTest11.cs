using System;
using Leetcode.Middle;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLeetcode
{
    [TestClass]
    public class UnitTest11
    {
        [TestMethod]
        public void TestEvaluateReversePolishNotation()
        {
            var tokens = new[] {"2", "1", "+", "3", "*"};
            var r = EvaluateReversePolishNotation.EvalRPN(tokens);
            Assert.AreEqual(r, 9);

            tokens = new[] { "4", "13", "5", "/", "+" };
            r = EvaluateReversePolishNotation.EvalRPN(tokens);
            Assert.AreEqual(r, 6);

            tokens = new[] { "10", "6", "9", "3", "+", "-11", "*", "/", "*", "17", "+", "5", "+" };
            r = EvaluateReversePolishNotation.EvalRPN(tokens);
            Assert.AreEqual(r, 22d);
        }

        [TestMethod]
        public void TestReverseWordsInString()
        {
            var r = ReverseWordsInString.ReserveWords("  I am the   king  ");
            Assert.AreEqual(r, "king the am I");
        }

        [TestMethod]
        public void TestMaximumProductSubarray()
        {
            var r = MaximumProductSubarray.Calc(new[] {2, 3, -2, 4});
            Assert.AreEqual(r,6);

            r = MaximumProductSubarray.Calc(new[] { -2, 0, -1 });
            Assert.AreEqual(r, 0);


            r = MaximumProductSubarray.Calc(new[] { 6,5, -1,-100,0,2,49 ,22});
            Assert.AreEqual(r, 3000);
        }


    }
}
