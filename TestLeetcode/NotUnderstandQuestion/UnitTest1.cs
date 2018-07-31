﻿using System;
using Leetcode.NotUnderstandQuestion;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLeetcode.NotUnderstandQuestion
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestSimplifyPath()
        {
            var r = SimplifyPath.Simplify("/a/./b/../../c/");
            Assert.AreEqual(r, "/c");
        }
    }
}
