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
    }
}
