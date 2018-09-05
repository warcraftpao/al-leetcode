using System;
using System.Collections.Generic;
using Leetcode.Middle;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLeetcode.FamilyTest
{
    [TestClass]
    public class TestWordLadder
    {
        [TestMethod]
        public void TestLadder1()
        {
            var r = WordLadder.LadderLength("hit", "coa", new List<string> { "hot", "dot", "dog", "lot", "log", "cog", "coa" });
            Assert.AreEqual(r,6);

            r = WordLadder.LadderLength("hit", "cog", new List<string> { "hot", "dot", "dog", "lot", "log" });
            Assert.AreEqual(r, 0);
        }
    }
}

