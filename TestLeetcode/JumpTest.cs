using System;
using Leetcode.Middle;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLeetcode
{
    [TestClass]
    public class JumpTest
    {
        [TestMethod]
        public void TestJumpGame1()
        {
            var r = JumpGame.Jump1_S1(new[] { 2, 3, 1, 1, 4 });
            Assert.AreEqual(r, true);

            r = JumpGame.Jump1_S1(new[] { 3, 2, 1, 0, 4 });
            Assert.AreEqual(r, false);

            r = JumpGame.Jump1_S2(new[] { 2, 3, 1, 1, 4 });
            Assert.AreEqual(r, true);

            r = JumpGame.Jump1_S2(new[] { 3, 2, 1, 0, 4 });
            Assert.AreEqual(r, false);

        }
    }
}
