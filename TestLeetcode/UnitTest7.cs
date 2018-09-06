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

        [TestMethod]
        public void TestSearchinRotatedSortedArray2()
        {
            var r = ArrarSearch.SearchinRotatedSortedArray2(new[] { 2, 5, 6, 0, 0, 1, 2 }, 0);
            Assert.AreEqual(r, true);


            r = ArrarSearch.SearchinRotatedSortedArray2(new[] { 2, 5, 6, 0, 0, 1, 2 }, 3);
            Assert.AreEqual(r, false);
        }


        [TestMethod]
        public void FindFirstAndLastInSortedArr()
        {
            var r = ArrarSearch.FindFirstAndLastInSortedArr(new[] { 5, 7, 7, 8, 8, 10 }, 7);
            Assert.AreEqual(r[0], 1);
            Assert.AreEqual(r[1], 2);

            r = ArrarSearch.FindFirstAndLastInSortedArr(new[] { 1,2, 3, 4, 5, 6, 8 }, 9);
            Assert.AreEqual(r[0], -1);
            Assert.AreEqual(r[1], -1);
        }

        [TestMethod]
        public void TestSearchInsertPosition()
        {
            var r = ArrarSearch.SearchInsertPosition(new[] {1, 3, 5, 6}, 5);
            Assert.AreEqual(r, 2);

            r = ArrarSearch.SearchInsertPosition(new[] { 1, 3, 5, 6 }, 2);
            Assert.AreEqual(r, 1);

            r = ArrarSearch.SearchInsertPosition(new[] { 1, 3, 5, 6 }, 7);
            Assert.AreEqual(r, 4);

            r = ArrarSearch.SearchInsertPosition(new[] { 1, 3, 5, 6 }, 0);
            Assert.AreEqual(r, 0);
        }

        [TestMethod]
        public static void TestLongestConsectiveSequence()
        {
            var r = LongestConsecutiveSequence.GetLength(new[] {100, 4, 200, 1, 3, 2});
            Assert.AreEqual(r, 4);

            r = LongestConsecutiveSequence.GetLength(new[] { 9,1,4,7,3,-1,0,5,8,-1,6 });
            Assert.AreEqual(r, 7);
        }

    }
}
