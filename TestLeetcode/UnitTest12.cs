using System;
using Leetcode.Middle;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLeetcode
{
    [TestClass]
    public class UnitTest12
    {
        [TestMethod]
        public void TestOneEditDistance()
        {
            var r = OneEditDistance.IsOneEdit("bbbbb", "bbbbbbb");
            Assert.AreEqual(r, false);

            r = OneEditDistance.IsOneEdit("bbbbb", "bbbb");
            Assert.AreEqual(r, true);


            r = OneEditDistance.IsOneEdit("bbbbb", "bbcbb");
            Assert.AreEqual(r, true);

            r = OneEditDistance.IsOneEdit("bbccbb", "abccbd");
            Assert.AreEqual(r, false);

            r = OneEditDistance.IsOneEdit("bbbb", "bbbcd");
            Assert.AreEqual(r, false);

        }
    }
}
