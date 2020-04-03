using System;
using Leetcode.Easy;
using Leetcode.Hard;
using Leetcode.Middle;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLeetcode
{
    [TestClass]
    public class UnitTest15
    {
        [TestMethod]
        public void TestPowerofTwo()
        {
            var r = PowerofTwo.S1(2);
            Assert.AreEqual(r,true);

            r = PowerofTwo.S1(1024);
            Assert.AreEqual(r, true);

            r = PowerofTwo.S1(1025);
            Assert.AreEqual(r, false);

            r = PowerofTwo.S1(2088);
            Assert.AreEqual(r, false);

            r = PowerofTwo.S3(2);
            Assert.AreEqual(r, true);

            r = PowerofTwo.S3(1024);
            Assert.AreEqual(r, true);

            r = PowerofTwo.S3(1025);
            Assert.AreEqual(r, false);

            r = PowerofTwo.S3(2088);
            Assert.AreEqual(r, false);
        }

        [TestMethod]
        public void TestNumberofDigitOne()
        {
            var r = NumberofDigitOne.Calc(13);
            Assert.AreEqual(r, 6);

            r = NumberofDigitOne.Calc(20555);
            Assert.AreEqual(r, 18216);

            r = NumberofDigitOne.Calc(21555);
            Assert.AreEqual(r, 19072);

            r = NumberofDigitOne.Calc(22555);
            Assert.AreEqual(r, 19816);


            var r1 = NumberofDigitOne.Calc_copyway(20555);
            Assert.AreEqual(r1, 18216);

            r1 = NumberofDigitOne.Calc_copyway(21555);
            Assert.AreEqual(r1, 19072);

            r1 = NumberofDigitOne.Calc_copyway(22555);
            Assert.AreEqual(r1, 19816);
        }

        [TestMethod]
        public void TestProductofArrayExceptSelf()
        {
            var res = ProductofArrayExceptSelf.Calc(new int[] {1, 2, 3, 4});
            Assert.AreEqual(res[0],24);
            Assert.AreEqual(res[1], 12);
            Assert.AreEqual(res[2], 8);
            Assert.AreEqual(res[3], 6);
        }
    }
}
