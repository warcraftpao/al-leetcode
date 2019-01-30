using System;
using System.Linq;
using Leetcode.Easy;
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


        [TestMethod]
        public void TestMissingRanges()
        {
            var r = MissingRanges.GetRanges(new[] { 0, 1, 3, 50, 75 },0, 99);
            Assert.AreEqual(r[0], "2");
            Assert.AreEqual(r[1], "4->49");
            Assert.AreEqual(r[2], "51->74");
            Assert.AreEqual(r[3], "76->99");

            r = MissingRanges.GetRanges(new int[] {}, 0, 99);
            Assert.AreEqual(r[0], "0->99");

            r = MissingRanges.GetRanges(new int[] { 1,5,44,98 }, 0, 99);
            Assert.AreEqual(r[0], "2->4");
            Assert.AreEqual(r[1], "6->43");
            Assert.AreEqual(r[2], "45->97");

            r = MissingRanges.GetRanges(new int[] { 1, 5, 44, 99}, 0, 99);
            Assert.AreEqual(r[0], "2->4");
            Assert.AreEqual(r[1], "6->43");
            Assert.AreEqual(r[2], "45->98");
        }

        [TestMethod]
        public void TestRadixSort()
        {
            var arr = new[] {122, 39, 42, 547, 79, 48, 61, 62, 965, 55, 232};
            MaxGap.RadixSort(arr, 3);
            Assert.AreEqual(arr[0],39);
        }


        [TestMethod]
        public void TestMaxGap()
        {
            var arr = new[] { 4,10,3,100,44 };
            var r =  MaxGap.GetGap(arr);
            Assert.AreEqual(r, 56);
        }


        [TestMethod]
        public void TestCompareVersionNumbers()
        {
            var r =CompareVersionNumbers.Compare("0.1", "1.1");
            Assert.AreEqual(r, -1);

            r = CompareVersionNumbers.Compare("1.0.1", "1");
            Assert.AreEqual(r, 1);

            r = CompareVersionNumbers.Compare("7.5.2.4", "7.5.3");
            Assert.AreEqual(r, -1);

            r = CompareVersionNumbers.Compare("1.01.1", "1.0001.1");
            Assert.AreEqual(r, 0);

            r = CompareVersionNumbers.Compare("1.0.0", "1.0");
            Assert.AreEqual(r, 0);
        }

        [TestMethod]
        public void TestExcelSheetColumnTitle()
        {
            var r = ExcelSheetColumnTitle.GetTitle(701);
            Assert.AreEqual(r, "ZY");

            r = ExcelSheetColumnTitle.GetTitle(28);
            Assert.AreEqual(r, "AB");


            r = ExcelSheetColumnTitle.GetTitle(2317);
            Assert.AreEqual(r, "CKC");
        }

        [TestMethod]
        public void TestMajorityElement()
        {
            var r= MajorityElement.BitCalc(new[] {1000, 30, 30,1000, 10001,1000,30,1000,1000});
            Assert.AreEqual(r, 1000);
        }

        [TestMethod]
        public void TestFactorialTrailingZeroes()
        {
            var r = FactorialTrailingZeroes.Count(135);
            Assert.AreEqual(r, 33);

            r = FactorialTrailingZeroes.Count(631);
            Assert.AreEqual(r, 157);
            
            ////////////way2////////////////////////
            r = FactorialTrailingZeroes.Count2(135);
            Assert.AreEqual(r, 33);

            r = FactorialTrailingZeroes.Count2(631);
            Assert.AreEqual(r, 157);
        }
    }
}
