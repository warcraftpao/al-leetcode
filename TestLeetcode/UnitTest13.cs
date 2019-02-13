using System;
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

        [TestMethod]
        public void TestReverseBits()
        {
            var r = ReverseBits.Reserve(43261596);
            Assert.AreEqual(r, 964176192u);
        }


        [TestMethod]
        public void TestNumberOf1Bit()
        {
            var r = NumberOf1Bit.Count(4294967293);
            Assert.AreEqual(r, 31);


            r = NumberOf1Bit.Count(819);
            Assert.AreEqual(r, 6);
        }

        [TestMethod]
        public void TestHouseRobber()
        {
            var r = HouseRobber.Rob(new [] { 2, 7, 9, 3, 1 });
            Assert.AreEqual(r, 12);

            r = HouseRobber.Rob(new[] { 3, 5, 1, 9, 20 });
            Assert.AreEqual(r, 25);
        }

        


        //只要连续长度稍微大一点肯定结果都是0了
        [TestMethod]
        public void TestBitwiseANDofNumbersRange()
        {
            var r = BitwiseANDofNumbersRange.Calc(5, 7);
            Assert.AreEqual(r, 4);

            r = BitwiseANDofNumbersRange.Calc(100, 154);
            Assert.AreEqual(r, 0);


            r = BitwiseANDofNumbersRange.Calc(1000, 1015);
            Assert.AreEqual(r, 992);
        }


        [TestMethod]
        public void TestHappyNumber()
        {
            var r = HappyNumber.IsHappy(19);
            Assert.AreEqual(r, true);

            r = HappyNumber.IsHappy(381);
            Assert.AreEqual(r, false);
        }

        [TestMethod]
        public void TestPrimeNumber()
        {
            var r = PrimeNumber.Count(10000);
            Assert.AreEqual(r, 1229);

            r = PrimeNumber.Count(100);
            Assert.AreEqual(r, 25);
        }

        [TestMethod]
        public void TestIsomorphicStrings()
        {
            var r = IsomorphicStrings.YesOrNo("paperi", "txtyic");
            Assert.AreEqual(r, true);

            r = IsomorphicStrings.YesOrNo("paperia", "txtyicy");
            Assert.AreEqual(r, false);
        }
    }
}
