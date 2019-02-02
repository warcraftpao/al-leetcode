﻿using System;
using System.Runtime.Remoting.Messaging;
using Leetcode.Easy;
using Leetcode.Middle;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLeetcode
{
    [TestClass]
    public class UnitTest13
    {
        [TestMethod]
        public void TestLargestNumber()
        {
            var r = LargestNumber.GetLargest(new[] {3, 30, 34, 5, 9});
            Assert.AreEqual(r, "9534330");
        }

        [TestMethod]
        public void TestRotateArray1()
        {
            var arr = new [] { 1, 2, 3, 4, 5, 6, 7 };
            RotateArray.Reserve(arr, 4);

            Assert.AreEqual(string.Join("", arr), "4567123");
        }


        [TestMethod]
        public void TestRotateArray2()
        {
            var arr = new[] { 1, 2, 3, 4, 5 };
            RotateArray.Change(arr, 2);

            Assert.AreEqual(string.Join("", arr), "45123");
        }
    }
}
