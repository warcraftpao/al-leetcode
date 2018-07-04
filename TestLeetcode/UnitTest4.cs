using System;
using System.Linq;
using Leetcode.Easy;
using Leetcode.Hard;
using Leetcode.Middle;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLeetcode
{
    [TestClass]
    public class UnitTest4
    {
        [TestMethod]
        public void TestIntegerAndRoman()
        {
            var r = IntegerAndRoman.ItoR(18);
            Assert.AreEqual(r, "XVIII");

            r = IntegerAndRoman.ItoR(40);
            Assert.AreEqual(r, "XL");

            r = IntegerAndRoman.ItoR(99);
            Assert.AreEqual(r, "XCIX");

            r = IntegerAndRoman.ItoR(600);
            Assert.AreEqual(r, "DC");

            r = IntegerAndRoman.ItoR(1899);
            Assert.AreEqual(r, "MDCCCXCIX");

            var i = IntegerAndRoman.RtoI("III");
            Assert.AreEqual(i, 3);

            i = IntegerAndRoman.RtoI("LVIII");
            Assert.AreEqual(i, 58);

            i = IntegerAndRoman.RtoI("MCMXCIV");
            Assert.AreEqual(i, 1994);
        }

        [TestMethod]
        public void TestLongestCommonPrefix()
        {
            var r= LongestCommonPrefix.S1(new [] {"abcefg", "abcd", "ab"});
            Assert.AreEqual(r, "ab");

            r = LongestCommonPrefix.S2Binary(new[] { "abckkkkefg", "abckk", "abckkkdddd" });
            Assert.AreEqual(r, "abckk");

            r = LongestCommonPrefix.S2Binary(new[] { "", "abckk", "abckkkdddd" });
            Assert.AreEqual(r, "");
        }

        [TestMethod]
        public void Test3Sum()
        {
             var r = ThreeSum.S1(new int[] {-1, 0, 1, 2, -1, -4, -2} ,0);
            Assert.AreEqual(r.Count, 3);

        }

        [TestMethod]
        public void Test3SumClosest()
        {
            var r = ThreeSumClosest.S1(new int[] { -1, 2, 1, -4 }, 1);
            Assert.AreEqual(r, 2);
        }

        [TestMethod]
        public void Test4Sum()
        {
            var r = FourSum.S1(new int[] { 1, 0, -1, 0, -2, 2 }, 0);
            Assert.AreEqual(r.Count, 3);
        }

        [TestMethod]
        public void TestCombinePhoneNumbers()
        {
            var r = CombinePhoneNumber.S1("234");
            Assert.AreEqual(r.Count, 27);
            Assert.IsTrue(r.Contains("adg"));
        }

    }
}
