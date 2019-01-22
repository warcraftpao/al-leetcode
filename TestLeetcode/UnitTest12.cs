﻿using System;
using System.Linq;
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


        [TestMethod]
        public void TestFindPeakElement()
        {
            var r = FindPeakElement.Find(new[] {1, 2, 3, 2, 1, 2, 4, 5, 3, 1, 10});
            Assert.AreEqual(new int[] {2,7,10}.Contains(r), true);

             r = FindPeakElement.Find(new[] { 1, 2, 3});
            Assert.AreEqual(r, 2);

            r = FindPeakElement.Find(new[] { 1,2 });
            Assert.AreEqual(r, 1);


            r = FindPeakElement.Find(new[] { 1, 2,3,10,5,4 });
            Assert.AreEqual(r, 3);
        }

    }
}