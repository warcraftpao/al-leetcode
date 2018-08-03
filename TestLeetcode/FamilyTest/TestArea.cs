using System;
using Leetcode.Area;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLeetcode.FamilyTest
{
    [TestClass]
    public class TestArea
    {
        [TestMethod]
        public void TestContainerWithMostWater()
        {

            var arr = new[] { 5, 7, 8, 1, 15, 3, 4 };
            var r = ContainerWithMostWater.GetMax(arr);
            Assert.AreEqual(r, 60);
        }


        [TestMethod]
        public void TestLargestRectangleInHistogram()
        {
            var r = LargestRectangleInHistogram.Find(new[] { 2, 1, 5, 6, 2, 3 });
            Assert.AreEqual(r, 10);

            r = LargestRectangleInHistogram.Find(new[] { 2, 1, 5, 6, 2, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 4, 5, 6, 7, 10000 });
            Assert.AreEqual(r, 10000);

            r = LargestRectangleInHistogram.Find(new[] { 2, 1, 5, 6, 2, 50, 51, 54, 55, 3, 3, 3, 3, 3, 3, 4, 5, 6, 7, 190 });
            Assert.AreEqual(r, 200);
        }

        [TestMethod]
        public void TestMaximalRectanglecs()
        {
            var arr = new int[,]
            {
                {1, 0, 1, 0, 0},
                {1, 0, 1, 1, 1},
                {1, 1, 1, 1, 1},
                {1, 0, 0, 1, 0},
            };
            var r = MaximalRectanglecs.Find(arr);
            Assert.AreEqual(r, 6);

            arr = new int[,]
            {
                {1, 0, 1, 0, 0, 0, 0, 0, 0},
                {1, 0, 1, 1, 1, 1, 1, 1, 1},
                {1, 1, 1, 1, 1, 0, 0, 0, 0},
                {1, 0, 0, 1, 0, 0, 0, 0, 0},
            };
            r = MaximalRectanglecs.Find(arr);
            Assert.AreEqual(r, 7);

        }
    }
}
