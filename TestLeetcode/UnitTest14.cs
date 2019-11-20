using System;
using Leetcode.Hard;
using Leetcode.Matrix;
using Leetcode.Middle;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLeetcode
{
    [TestClass]
    public class UnitTest14
    {
        [TestMethod]
        public void TestQuickSort()
        {

            var arr4 = new[] { 2, 3, 4, 5, 1, 99, 98, 97, 96 };
            var r4 = KthLargestElementInArray.Get(arr4, 4);
            Assert.AreEqual(r4, 96);

            var arr1 = new[] { 3, 2, 1, 5, 6, 4 };
            var r1 = KthLargestElementInArray.Get(arr1, 2);
            Assert.AreEqual(r1, 5);


           var    arr2 = new[] { 3, 2, 3, 1, 2, 4, 5, 5, 6 };
           var  r2 = KthLargestElementInArray.Get(arr2, 4);
            Assert.AreEqual(r2, 4);


            var arr3 = new[] { 49, 27, 65, 97, 76, 13, 27 };
            var r3 = KthLargestElementInArray.Get(arr3, 4);
            Assert.AreEqual(r3, 49);


          
        }

        [TestMethod]
        public void TestSkyline()
        {
            var buildings = new int[][]
            {
                new int[] {2, 9, 10}, new int[] {3, 7, 15}, new int[] {5, 12, 12}, new int[] {15, 20, 10},
                new int[] {19, 24, 8}
            };

            var result = SkylineProblem.Calc(buildings);
            Assert.AreEqual(result.Count, 7);
            Assert.AreEqual(result[0][0],2);
            Assert.AreEqual(result[0][1], 10);


            Assert.AreEqual(result[2][0], 7);
            Assert.AreEqual(result[2][1], 12);

            Assert.AreEqual(result[6][0],24);
            Assert.AreEqual(result[6][1], 0);
        }


        [TestMethod]
        public void TestMaximalSqure()
        {
            var grid = new char[,]
            {
                {'1', '0', '1', '0', '0'},
                {'1', '0', '1', '1', '1'},
                {'1', '1', '1', '1', '1'},
                {'1', '0', '0', '1', '0'},

            };

            var result = MaximalSquare.Calc(grid);
            Assert.AreEqual(result, 4);


            grid = new char[,]
            {
                {'1', '1', '1', '0', '0'},
                {'1', '1', '1', '1', '1'},
                {'1', '0', '1', '1', '1'},
                {'1', '0', '1', '1', '1'},
                {'1', '0', '1', '1', '1'},
            };


            result = MaximalSquare.Calc(grid);
            Assert.AreEqual(result, 9);

        }


        [TestMethod]
        public void TestRectanglArea()
        {
            var r= RectanglArea.Calc(-3, 0, 3, 4, 0, -1, 9, 2);

           Assert.AreEqual(r,45);

            r = RectanglArea.Calc(2, 3, 10, 6,11, 1, 15, 5);

            Assert.AreEqual(r, 40);
        }

    }
}
