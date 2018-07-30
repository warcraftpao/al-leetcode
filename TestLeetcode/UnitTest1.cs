using System;
using System.Linq;
using Leetcode.DataStructure;
using Leetcode.Easy;
using Leetcode.Middle;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLeetcode
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestTwoSum()
        {
            //diffent way leads different result
            var target = 12;
            var arr = new int[] {1, 3, 4, 5, 6, 7, 9};
            var result = TwoSum.TwoSum2(arr, target);
            Assert.IsTrue(result.Contains(5) && result.Contains(7));

            result = TwoSum.TwoSum1(arr, target);
            Assert.IsTrue(result.Contains(3) && result.Contains(9));
        }

       

        [TestMethod]
        public void TestMaxSubstringWithoutRepeatChar()
        {
            var r = MaxSubstringWithoutRepeatChar.GetMaxSubstringWithoutRepeatChar("stvbxxxxkcsst");
            Assert.AreEqual(r, 5);
        }

        [TestMethod]
        public void TestPlusOne()
        {
            var r = PlusOne.Calc(new [] {1,2,3,4});
            Assert.AreEqual(r.Length, 4);

            r = PlusOne.Calc(new[] { 9, 9, 9, 9});
            Assert.AreEqual(r.Length, 5);

            r = PlusOne.Calc(new[] { 9, 4, 9, 9 });
            Assert.AreEqual(r.Length, 4);
        }


        [TestMethod]
        public void TestAddBinary()
        {
            var r = AddBinary.Get("1010", "1011");
            Assert.AreEqual(r , "10101");

            r = AddBinary.Get("111", "111111");
            Assert.AreEqual(r, "1000110");
        }
    }
}
