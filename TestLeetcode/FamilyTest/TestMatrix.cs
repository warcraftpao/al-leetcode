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
    }
}
