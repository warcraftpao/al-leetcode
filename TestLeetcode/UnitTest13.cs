using System;
using System.Runtime.Remoting.Messaging;
using Leetcode.Middle;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLeetcode
{
    [TestClass]
    public class UnitTest13
    {
        [TestMethod]
        public void TestLargestNumber()
        {
            var r = LargestNumber.GetLargest(new[] {3, 30, 34, 5, 9});
            Assert.AreEqual(r, "9534330");
        }
    }
}
