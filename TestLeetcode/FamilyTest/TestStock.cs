using System;
using Leetcode.Easy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLeetcode.FamilyTest
{
    [TestClass]
    public class TestStock
    {
        [TestMethod]
        public void GetMax()
        {
            var arr = new int[] {7, 1, 5, 3, 4, 6};
            var r = Stock.MaxProfit(arr);
            Assert.AreEqual(r, 5);

            arr = new int[] { 7, 6, 4, 3, 1 };
            r = Stock.MaxProfit(arr);
            Assert.AreEqual(r, 0);
        }

        [TestMethod]
        public void TestMaxProfit_multitransaction()
        {
            var arr = new[] { 7, 1, 5, 3, 6, 4 };
            var r = Stock.MaxProfit_multitransaction(arr);
            Assert.AreEqual(r, 7);

            arr = new[] { 1, 2, 3, 4, 5 };
            r = Stock.MaxProfit_multitransaction(arr);
            Assert.AreEqual(r, 4);

            arr = new[] { 7, 6, 4, 3, 1 };
            r = Stock.MaxProfit_multitransaction(arr);
            Assert.AreEqual(r, 0);
        }
    }
}
