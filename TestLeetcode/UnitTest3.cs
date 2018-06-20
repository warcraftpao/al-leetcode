using System;
using Leetcode.Middle;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLeetcode
{
    [TestClass]
    public class UnitTest3
    {
        [TestMethod]
        public void TestZigzag()
        {
            var r= ZigZag.Zigzag1("PAYPALISHIRING", 4);
            Assert.AreEqual(r, "PINALSIGYAHRPI");
        }
    }
}
