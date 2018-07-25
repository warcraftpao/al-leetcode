using System;
using Leetcode.Middle;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLeetcode.FamilyTest
{
    [TestClass]
    public class TestMatrix
    {

        [TestMethod]
        public void TestConvert()
        {
            var r = SpiralMatrix.Convert(new [,]
            {
                {1,  2,  3,  4,  5},
                {6,  7,  8,  9,  10},
                {11, 12, 13, 14, 15},

                {16, 17, 18, 19, 20},
                {21, 22, 23, 24, 25}
            });
            Assert.AreEqual(string.Join("", r), "12345101520252423222116116789141918171213");
        }

         [TestMethod]
        public void TestGenerate()
        {
            var r = SpiralMatrix.Generate(5);
            Assert.AreEqual(r[2, 2], 25);
            Assert.AreEqual(r[1, 1], 17);
            Assert.AreEqual(r[3, 3], 21);
        }
    }
}
