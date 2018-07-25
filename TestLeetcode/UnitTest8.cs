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
        public void TestRotateImage()
        {
            var arr = new int[3, 3]
            {
                {1, 2, 3,},
                {4, 5, 6,},
                {7, 8, 9,},


            };
            RotateImage.Rotate(arr);

            Assert.AreEqual(arr[0, 0], 7);

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
        public void TestSpiralMatrix()
        {
            var r = SpiralMatrix.Convert(new int[,]
            {
                {1, 2, 3, 4, 4},
                {5, 6, 7, 8, 4},
                {9, 10, 11, 12, 4},

                {13, 14, 15, 16, 5},
            });
            Assert.AreEqual(string.Join("", r), "123444451615141395678121110");
        }

        [TestMethod]
        public void TestIcompare()//test a c# feature
        {
            var  r  = Intervals.Sort();
            Assert.AreEqual(r[0].Start ,1);
        }

        [TestMethod]
        public void TestMergeIntervals()
        {
            var v5 = new Interval(1, 3);
            var v1 = new Interval(2, 6);
            var v3 = new Interval(5, 10);
            var v4 = new Interval(15,21);
            var v2 = new Interval(18, 19);
            var v6 = new Interval(22, 23);
            var vs = new[] { v1, v2, v3, v4 ,v5, v6};

            var r = Intervals.Merge(vs);
            Assert.AreEqual(r.Count,3);
            Assert.AreEqual(r[0].Start, 1);
            Assert.AreEqual(r[1].End, 21);
        }

        [TestMethod]
        public void TestInsertIntervals()
        {
            var v1 = new Interval(1, 2);
            var v2 = new Interval(3, 5);
            var v3 = new Interval(6, 7);
            var v4 = new Interval(8, 10);
            var v5 = new Interval(12, 16);
            var vs = new[] { v1, v2, v3, v4, v5 };

            var r = Intervals.Insert(vs, new Interval(4,8));
            Assert.AreEqual(r.Count, 3);
            Assert.AreEqual(r[0].Start, 1);
            Assert.AreEqual(r[1].End, 10);
            Assert.AreEqual(r[2].End, 16);
        }
    }
}
