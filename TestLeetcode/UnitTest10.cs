using System;
using Leetcode.Easy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLeetcode
{
    [TestClass]
    public class UnitTest10
    {
        [TestMethod]
        public void TestSingleNumber1_hashtable()
        {
            var r = SingleNumber1.GetNumber_hashtable(new[] {2, 2, 3, 3, 4, 4, 1, 5, 5, 6, 7, 8, 8, 7, 6});
            Assert.AreEqual(r, 1);
        }

        [TestMethod]
        public void TestSingleNumber1_bit()
        {
            var r = SingleNumber1.GetNumber_bit(new[] { 2, 2, 3, 3, 4, 4, 1, 5, 5, 6, 7, 8, 8, 7, 6 });
            Assert.AreEqual(r, 1);
        }
    }
}
