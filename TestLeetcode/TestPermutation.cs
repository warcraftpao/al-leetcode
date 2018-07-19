using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leetcode.Middle;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLeetcode
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
            var r = Permutation.AllPermutations(new[] { 1, 2, 3, 4 });
            Assert.AreEqual(r.Count,   4 * 3 * 2);

            //this passed test
            //var r = Permutation.AllPermutations(new[] {1, 2, 3, 4,5,6,7,8,9,10});
            //Assert.AreEqual(r.Count, 10*9*8*7*6*5*4*3*2);
        }
    }
}
