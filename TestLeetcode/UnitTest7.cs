using System;
using Leetcode.Hard;
using Leetcode.Middle;
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

        [TestMethod]
        public void TestSearchinRotatedSortedArray()
        {
            var r = ArrarSearch.SearchinRotatedSortedArray(new [] {6,7, 1,2,3,4,5}, 9);
            Assert.AreEqual(r, -1);


            r = ArrarSearch.SearchinRotatedSortedArray(new[] { 6, 7, 1, 2, 3, 4, 5 }, 4);
            Assert.AreEqual(r, 5);
        }
    }
}
