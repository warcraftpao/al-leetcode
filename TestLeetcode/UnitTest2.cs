using System;
using System.Linq;
using Leetcode.Hard;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLeetcode
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestFindMedianSortedArrays()
        {
            var arr1 = new int[] {1, 21, 31, 41};
            var arr2 = new int[] {2, 4, 50};

            var r = FindMedianSortedArrays.FindMedianSortedArrays1(arr1, arr2);
            Assert.AreEqual(r, 21);

            var arr3 = new int[] { 1, 21, 31, 41 };
            var arr4 = new int[] { 2, 4, 50 ,100};

            r = FindMedianSortedArrays.FindMedianSortedArrays1(arr3, arr4);
            Assert.AreEqual(r, 26);
        }

        [TestMethod]
        public void TestFindMedianSortedArraysRecursive()
        {
            var arr1 = new int[] { 1, 21, 31, 41 };
            var arr2 = new int[] { 2, 4, 50 };

            var r = FindMedianSortedArrays.FindKthIn2SortedArraies(arr1, 0,arr2,0, 3);
            Assert.AreEqual(r, 4);

            var arr3 = new int[] { 1, 21, 31, 41 };
            var arr4 = new int[] { 2, 4, 50, 100 };

            r = FindMedianSortedArrays.FindKthIn2SortedArraies(arr3, 0, arr4, 0, 5);
            Assert.AreEqual(r, 31);
        }

        [TestMethod]
        public void TestLongestPalindromeSubstring()
        {
            var r = LongestPalindromeSubstring.Solution1("cabaabad");
            Assert.AreEqual(r, "abaaba");


            r = LongestPalindromeSubstring.Solution1("cabakabadddcf");
            Assert.AreEqual(r, "abakaba");
        }
    }
}
