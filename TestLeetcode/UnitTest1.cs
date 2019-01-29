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
            var arr = new int[] { 633, 3, 15, 6, 52, 150,1  };
           
            var    result = TwoSum.TwoSum1(arr, 67);
            Assert.IsTrue(result.Contains(2) && result.Contains(4));

            result = TwoSum.TwoSum2(arr, 67);
            Assert.IsTrue(result.Contains(2) && result.Contains(4));
        }

        [TestMethod]
        public void TestTwoSum2()
        {
            var arr = new int[] {1,3,6,15,52,150,633 };
            var result = TwoSum2.Calc(arr, 67);
            Assert.IsTrue(result.Contains(4) && result.Contains(5));
        }

        [TestMethod]
        public void TestTwoSum3()
        {
            
            var tsd =new  TwoSumDataStructure();
            tsd.Add(1);
            tsd.Add(2);
            Assert.AreEqual(tsd.Find(3), true);
            Assert.AreEqual(tsd.Find(1),false);
            tsd.Add(2);
            Assert.AreEqual(tsd.Find(4),true);
            tsd.Add(3);
            Assert.AreEqual(tsd.Find(3), true);
            Assert.AreEqual(tsd.Find(6), false);
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

        //不测试开头是0 ，或者中间有连续2个0，9090等不合法字符串情况
        [TestMethod]
        public void TestDecodingWays()
        {
            var r = DecodingWays.GetWayNum("111111111");
            Assert.AreEqual(r,55);

            r = DecodingWays.GetWayNum("12");
            Assert.AreEqual(r, 2);

            r = DecodingWays.GetWayNum("10");
            Assert.AreEqual(r, 1);

            r = DecodingWays.GetWayNum("90");
            Assert.AreEqual(r, 0);

            r = DecodingWays.GetWayNum("12390");
            Assert.AreEqual(r, 0);
        }
    }
}
