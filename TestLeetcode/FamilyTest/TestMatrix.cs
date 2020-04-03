using System;
using Leetcode.Matrix;
using Leetcode.Middle;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLeetcode.FamilyTest
{
	[TestClass]
	public class TestMatrix
	{

        [TestMethod]
        public void TestSetMatrixZero()
        {
            var arr = new int[,]
            {
                {1, 1, 1, 1, 1},
                {1, 0, 1, 1, 1},
                {1, 1, 1, 1, 1},
                {1, 1, 1, 0, 1},
                {1, 1, 1, 1, 1},
                {1, 1, 1, 1, 1},
                {1, 1, 1, 1, 0},
                {1, 1, 1, 1, 0},
            };
            SetMatrixZero.Set(arr);

            Assert.AreEqual(arr[0, 1], 0);
            Assert.AreEqual(arr[0, 2], 1);
            Assert.AreEqual(arr[6, 0], 0);
            Assert.AreEqual(arr[7, 3], 0);
        }

        [TestMethod]
        public void TestRotateImage()
        {
            var arr = new int[3, 3]
            {
                {1, 2, 3,},
                {4, 5, 6,},
                {7, 8, 9,},


            };
            RotateImage.Rotate(arr);

            Assert.AreEqual(arr[0, 0], 7);

            arr = new int[4, 4]
            {
                {1, 2, 3, 4},
                {5, 6, 7, 8},
                {9, 10, 11, 12},

                {13, 14, 15, 16},
            };
            RotateImage.Rotate(arr);

            Assert.AreEqual(arr[2, 2], 7);
            Assert.AreEqual(arr[2, 3], 3);
            Assert.AreEqual(arr[3, 2], 8);
            Assert.AreEqual(arr[3, 3], 4);
        }


	    [TestMethod]
	    public void TestSearcha2dMatrix()
	    {
	        var arr = new int[,]
	        {
	            {1, 3, 5, 7},
	            {10, 11, 16, 20},
	            {23, 30, 34, 50},
	            {51, 52, 53, 60},
	            {100, 101, 102, 180},
	        };
	        var r = Searcha2dMatrix.Search(arr, 53);

	        Assert.AreEqual(r, true);
	    }


        [TestMethod]
        public void TestSearcha2dMatrixLevel2()
        {
            var arr = new int[,]
            {
                {1, 4, 7, 11,15},
                {2,   5,  8, 12, 19},
                {3,   6,  9, 16, 22},
                {10, 13, 14, 17, 24},
                {18, 21, 23, 26, 30},
            };
            var r = Searcha2dMatrix.SearchLevel2(arr, 5);

            Assert.AreEqual(r, true);

            r = Searcha2dMatrix.SearchLevel2(arr, 20);

            Assert.AreEqual(r, false);
        }
    }
}
