﻿using Leetcode.Middle;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLeetcode.FamilyTest
{
    [TestClass]
    public  class TestPermutation
    {

        [TestMethod]
        public void TestNextPermutation()
        {
            var arr = new[] { 1, 2, 7, 4, 3, 1 };
            Permutation.NextPermutation(arr);
            Assert.AreEqual(arr[2], 1);
            Assert.AreEqual(arr[3], 2);
            Assert.AreEqual(arr[4], 4);
            Assert.AreEqual(arr[5], 7);

            arr = new[] { 7, 6, 5, 4, 3, 2, 1 };
            Permutation.NextPermutation(arr);
            Assert.AreEqual(arr[0], 1);
            Assert.AreEqual(arr[6], 7);
        }

        [TestMethod]
        public void TestAllPermutations()
        {
            var r = Permutation.AllPermutations_S1(new[] { 1, 2, 3, 4 });
            Assert.AreEqual(r.Count,   4 * 3 * 2);

            r = Permutation.AllPermutations_S2(new[] {1, 2, 3, 4,5});
            Assert.AreEqual(r.Count, 5*4*3*2);
        }

        [TestMethod]
        public void TestGetKthPermutation()
        {
            var r = Permutation.GetKthPermutation(4,9);
            Assert.AreEqual(r , "2314");
             
        }

        [TestMethod]
        public void TestGetKthPermutationByRule()
        {
            var r = Permutation.GetKthPermutationByRule(4,6);
            Assert.AreEqual(r, "1432");

            r = Permutation.GetKthPermutation(4, 9);
            Assert.AreEqual(r, "2314");
        }

        [TestMethod]
        public void TestGenerateAllWithDupulicatedArr()
        {
            var r = Permutation.GenerateAllWithDupulicatedArr(new [] { 1, 1, 2 });
            Assert.AreEqual(r.Count, 3);
        }
        

    }
}
