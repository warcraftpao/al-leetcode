using System;
using Leetcode.Hard;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLeetcode
{
    [TestClass]
    public class UnitTest7
    {
        [TestMethod]
        public void TestLongestValidParentheses()
        {
            var r = LongestValidParentheses.S1("()((())()");
            Assert.AreEqual(r,6);


            r = LongestValidParentheses.S2("()((())()");
            Assert.AreEqual(r, 6);
        }
    }
}
