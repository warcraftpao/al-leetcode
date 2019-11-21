using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leetcode.Hard;
using Leetcode.Middle;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLeetcode.FamilyTest
{
    [TestClass]
    public class TestBasicCalculator
    {
        [TestMethod]
        public void TestBasicCalculatorLevel1()
        {
            var r = BasicCalculator.Level1("(1+(4+5+2)-3)+(6+8)");
            Assert.AreEqual(r, 23);

            r = BasicCalculator.Level1("(11+(4+5+2)-3)+(6+8)");
            Assert.AreEqual(r, 33);


            r = BasicCalculator.Level1(" (11 +(4 +5+2)-3)+(   6+8  )");
            Assert.AreEqual(r, 33);

            r = BasicCalculator.Level1("( 1 -(4-5+2)-3)+(6+8)");
            Assert.AreEqual(r, 11);

            r = BasicCalculator.Level1("-( 1 -(4-5+2)-3)+(6+8)");
            Assert.AreEqual(r, 17);

            r = BasicCalculator.Level1("-112 - (-( 1 -(4-5+2)-3)+(6+8))");
            Assert.AreEqual(r, -129);
        }
    }
}
