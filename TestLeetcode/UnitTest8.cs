using System;
using Leetcode.Easy;
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
            Assert.AreEqual(r,"21");

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
        public void TestRotateImage()
        {
            var arr = new int[3, 3]
            {
                {1, 2, 3,},
                {4, 5, 6,},
                {7, 8, 9,},


            };
            RotateImage.Rotate( arr);

            Assert.AreEqual(arr[0,0], 7);

            arr = new int[4, 4]
            {
                {1, 2, 3, 4},
                {5, 6, 7, 8},
                {9, 10, 11, 12},

                {13, 14, 15, 16},
            };
            RotateImage.Rotate(arr);

            Assert.AreEqual(arr[2, 2], 7);
            Assert.AreEqual(arr[2, 3], 3);
            Assert.AreEqual(arr[3, 2], 8);
            Assert.AreEqual(arr[3, 3], 4);
        }

        [TestMethod]
        public void TestGroupAnagrams()
        {
            var r = GroupAnagrams.Group(new[] {"eat", "tea", "tan", "ate", "nat", "bat"});
            Assert.AreEqual(r.Count, 3);

        }
    }


}
