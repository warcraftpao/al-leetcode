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


        [TestMethod]
        public void TestBasicCalculatorLevel2()
        {
            var r = BasicCalculator.Level2("3+2*2");
            Assert.AreEqual(r, 7);

            r = BasicCalculator.Level2("3-5 / 2");
            Assert.AreEqual(r, 1);

            r = BasicCalculator.Level2(" 3 +5*3 - 10/3 - 2   ");
            Assert.AreEqual(r, 13);

            r = BasicCalculator.Level2(" 3 -5*3 + 10/3*4 - 2   ");
            Assert.AreEqual(r, -2);
        }
    }
}
