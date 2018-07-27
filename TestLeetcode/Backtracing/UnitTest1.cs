using System;
using Leetcode.Middle;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLeetcode.Backtracing
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestUniquePaths()
        {
            var r = UniquePaths.GetPathNumer_backtracing(7, 3);
            Assert.AreEqual(r, 28);
        }
    }
}
