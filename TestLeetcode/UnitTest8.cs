using System;
using Leetcode.Easy;
using Leetcode.Middle;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLeetcode
{
    [TestClass]
    public class UnitTest8
    {
        [TestMethod]
        public void TestCountAndSay()
        {
            var r = CountAndSay.BabySay(3);
            Assert.AreEqual(r,"21");

            r = CountAndSay.BabySay(5);
            Assert.AreEqual(r, "111221");

            r = CountAndSay.BabySay(6);
            Assert.AreEqual(r, "312211");

            r = CountAndSay.BabySay(7);
            Assert.AreEqual(r, "13112221");

            r = CountAndSay.BabySay(8);
            Assert.AreEqual(r, "1113213211");
        }

        [TestMethod]
        public void TestCombinationSum()
        {
            var r = CombinationSum.S1(new[] {2,7,3},  7);
            Assert.AreEqual(r.Count, 2);

            r = CombinationSum.S1(new[] { 2, 3, 5 }, 8);
            Assert.AreEqual(r.Count, 3);

        }

    }


}
