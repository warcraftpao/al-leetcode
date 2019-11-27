using System;
using Leetcode.Easy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLeetcode
{
    [TestClass]
    public class UnitTest15
    {
        [TestMethod]
        public void TestPowerofTwo()
        {
            var r = PowerofTwo.S1(2);
            Assert.AreEqual(r,true);

            r = PowerofTwo.S1(1024);
            Assert.AreEqual(r, true);

            r = PowerofTwo.S1(1025);
            Assert.AreEqual(r, false);

            r = PowerofTwo.S1(2088);
            Assert.AreEqual(r, false);

            r = PowerofTwo.S3(2);
            Assert.AreEqual(r, true);

            r = PowerofTwo.S3(1024);
            Assert.AreEqual(r, true);

            r = PowerofTwo.S3(1025);
            Assert.AreEqual(r, false);

            r = PowerofTwo.S3(2088);
            Assert.AreEqual(r, false);
        }
    }
}
