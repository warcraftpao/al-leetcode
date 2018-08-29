using System;
using Leetcode.DP;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLeetcode.DP
{
    [TestClass]
    public class TestPascalTriangle
    {
        [TestMethod]
        public void TestMethod1()
        {
            var r = PascalTriangle.Generate(5);
            Assert.AreEqual(r.Count, 5);
            Assert.AreEqual(r[4][0], 1);
            Assert.AreEqual(r[4][1], 4);
            Assert.AreEqual(r[4][2], 6);
        }

        [TestMethod]
        public void TestGetRow()
        {
            var r = PascalTriangle.GetRow(5);
            Assert.AreEqual(r[0], 1);
            Assert.AreEqual(r[1], 4);
            Assert.AreEqual(r[2], 6);

            //C(32,16) 
             r = PascalTriangle.GetRow(33);
             Assert.AreEqual(r[16], 601080390);


        }
    }
}
