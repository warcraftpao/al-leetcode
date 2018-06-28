using System;
using Leetcode.DP;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLeetcode.DP
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCoins()
        {
            var r = Coins.MinCoinNumber(new[] { 1, 2, 5 }, 11);
            Assert.AreEqual(r, 3);

            r = Coins.MinCoinNumber(new[] { 3, 5, 7 ,19}, 23);
            Assert.AreEqual(r,5);

            r = Coins.MinCoinNumber(new[] { 4, 5 }, 11);
            Assert.AreEqual(r, -1);

            r = Coins.MinCoinNumber(new[] {1, 3, 7, 18 }, 23);
            Assert.AreEqual(r,4);
        }

        [TestMethod]
        public void TestLIS()
        {
            var r = LIS.S1(new[] {7, 3, 4, 1, 5, 6, 2, 6, 7});
            Assert.AreEqual(r, 6);
        }
    }
}
