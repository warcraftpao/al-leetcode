using System;
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
    }
}
