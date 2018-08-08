using System;
using System.Linq;
using Leetcode.DataStructure;
using Leetcode.Easy;
using Leetcode.Hard;
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


        [TestMethod]
        public void TestTextJustification()
        {
            var r = TextJustification.Do(new [] {"Science","is","what","we","understand","well","enough","to","explain",
                                                    "to","a","computer.","Art","is","everything","else","we","do"} , 20);
            Assert.AreEqual(r[0], "Science  is  what we");
            Assert.AreEqual(r[3], "a  computer.  Art is");
            Assert.AreEqual(r[5], "do                  ");


            r = TextJustification.Do(new[] { "What", "must", "be", "acknowledgment", "shall", "be" }, 16);
            Assert.AreEqual(r[0], "What   must   be");
            Assert.AreEqual(r[1], "acknowledgment  ");
            Assert.AreEqual(r[2], "shall be        ");
        }

        [TestMethod]
        public void TestSqrt()
        {
            var r = Sqrt.SimpleSqrt(100);
            Assert.AreEqual(r, 10);

            r = Sqrt.SimpleSqrt_w2(731026);
            Assert.AreEqual(r, 855);
        }

        [TestMethod]
        public void TestMergeSortedArray()
        {
            var a1 = new[] {1, 2, 3, 0, 0, 0};
            var a2 = new[] {2, 5, 6};
            MergeSortedArray.Merge(a1, 3, a2, 3);
            Assert.AreEqual(a1[4],5);
            Assert.AreEqual(a1[0], 1);
        }
    }
}
