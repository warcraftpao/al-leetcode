﻿using System;
using Leetcode.CommonTools;
using Leetcode.DP;
using Leetcode.Easy;
using Leetcode.Middle;
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

        [TestMethod]
        public void TestAppleGrid()
        {
            var arr = Tools.MakeBooked2DArr(4,5, new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20});
            var r = AppleGrid.GetApplesAMAP(arr);
            Assert.AreEqual(r, 108);
        }

        [TestMethod]
        public void TestTriangle()
        {
            var arr = Tools.MakeTriangle(5, new[] { 1, 3, 8, 8, 1, 0, 2, 7, 4, 4, 4, 5, 2 , 6, 5  });
            var r = Triangle.GetMax(arr);
            Assert.AreEqual(r, 24);
        }


        [TestMethod]
        public void TestUniquePaths()
        {
            var r = UniquePaths.GetPathNumer_dp(7, 3);
            Assert.AreEqual(r, 28);

            r = UniquePaths.GetPathNumer_dp_d1(8, 3);
            Assert.AreEqual(r, 36);
        }

        [TestMethod]
        public void TestUniquePathsWithObstas()
        {
            var arr = new int[7, 3]
            {
                {0, 1, 0},
                {0, 0, 0},
                {0, 0, 0},
                {0, 0, 1},
                {0, 0, 0},
                {1, 0, 0},
                {0, 0, 0},
            };
        
            var r = UniquePaths.GetPathNumerWithObstacles_dp_d1(arr);
            Assert.AreEqual(r, 12);
        }

        [TestMethod]
        public void TestMinimumPathSum()
        {
            var arr = new [, ]
            {
                {1, 3, 1},
                {1, 5, 1},
                {4, 2, 1},
            };

            var r = MinimumPathSum.GetMin(arr);
            Assert.AreEqual(r, 7);

            arr = new[,]
            {
                {1, 2, 3, 4},
                {5, 6, 7, 8},
                {1, 3, 7, 8},
                {9, 10, 1, 3},
                {3, 12, 9, 7},
            };

            r = MinimumPathSum.GetMin(arr);
            Assert.AreEqual(r, 28);
        }

        [TestMethod]
        public void TestClimbingStairs()
        {
            var r = ClimbingStairs.Climb(10);
            Assert.AreEqual(r,89);

            r = ClimbingStairs.Climb(3);
            Assert.AreEqual(r, 3);
        }
    }
}
