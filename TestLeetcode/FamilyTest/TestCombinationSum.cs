﻿using Leetcode.Middle;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLeetcode.FamilyTest
{
    [TestClass]
    public class TestCombinationSum
    {

        [TestMethod]
        public void TestWithNumRepeat()
        {
            var r = CombinationSum.WithCandidatesNoRepeat(new[] { 2, 7, 3 }, 7);
            Assert.AreEqual(r.Count, 2);

            r = CombinationSum.WithCandidatesNoRepeat(new[] { 2, 3, 5 }, 8);
            Assert.AreEqual(r.Count, 3);

        }




        [TestMethod]
        public void TestWithNoRepeat()
        {
            var r = CombinationSum.WithNoRepeat(new[] { 10, 1, 2, 7, 6, 1, 5 }, 8);
            Assert.AreEqual(r.Count, 4);

            r = CombinationSum.WithNoRepeat(new[] { 2, 5, 2, 1, 2 },5);
            Assert.AreEqual(r.Count, 2);

        }

        [TestMethod]
        public void TestSum3()
        {
            var r = CombinationSum.Sum3(3, 7);
            Assert.AreEqual(r.Count ,1);

            r = CombinationSum.Sum3(3, 9);
            Assert.AreEqual(r.Count, 3);
        }
    }
}
