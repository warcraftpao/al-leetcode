using System;
using Leetcode.Easy;
using Leetcode.Hard;
using Leetcode.Matrix;
using Leetcode.Middle;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLeetcode
{
    [TestClass]
    public class UnitTest8
    {
        [TestMethod]
        public void TestCountAndSay()
        {
            var r = CountAndSay.BabySay(3);
            Assert.AreEqual(r, "21");

            r = CountAndSay.BabySay(5);
            Assert.AreEqual(r, "111221");

            r = CountAndSay.BabySay(6);
            Assert.AreEqual(r, "312211");

            r = CountAndSay.BabySay(7);
            Assert.AreEqual(r, "13112221");

            r = CountAndSay.BabySay(8);
            Assert.AreEqual(r, "1113213211");
        }

        

        [TestMethod]
        public void TestGroupAnagrams()
        {
            var r = GroupAnagrams.Group(new[] {"eat", "tea", "tan", "ate", "nat", "bat"});
            Assert.AreEqual(r.Count, 3);
        }

        [TestMethod]
        public void TestPowXy()
        {
            var r = PowXy.Calc(3, 9);
            Assert.AreEqual(r, 19683);

            r = PowXy.Calc(3.1, 2);
            Assert.AreEqual(r, 9.61, 0.01);//注意重载，精度问题
        }


        [TestMethod]
        public void TestMaximumSubarray()
        {
            var r = MaximumSubarray.GetMs(new [] { -2, 1, -3, 4, -1, 2, 1, -5, 4 });
            Assert.AreEqual(r, 6);
        }


        [TestMethod]
        public void TestLengthOfLastWord()
        {
            var r = LengthOfLastWord.Calc("hello wwwoddd    ");
            Assert.AreEqual(r, 7);
        }

        [TestMethod]
        public void TestSortColors()
        {
            var arr = new[] {2, 1, 1, 0, 2, 2, 1, 0, 0, 2, 1, 2, 0, 1, 2, 0};
            SortColors.Sort(arr);
            Assert.AreEqual(arr[4], 0);
            Assert.AreEqual(arr[5], 1);
            Assert.AreEqual(arr[10], 2);
        }

        [TestMethod]
        public void TestMinimumWindowSubstring()
        {
            var r = MinimumWindowSubstring.Get("ADOBECODEBANC", "ABC");
            Assert.AreEqual(r, "BANC");

            r = MinimumWindowSubstring.Get("ADOBECODEBANC", "ABCZ");
            Assert.AreEqual(r, "");

            r = MinimumWindowSubstring.Get("klasjdajdakk12312klas11111111d", "lds");
            Assert.AreEqual(r, "lasjd");
        }
    }
}
