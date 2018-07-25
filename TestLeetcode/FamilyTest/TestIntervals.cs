using Leetcode.Middle;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLeetcode.FamilyTest
{
    [TestClass]
    public class TestIntervals
    {
        [TestMethod]
        public void TestIcompare()//test a c# feature
        {
            var r = Intervals.Sort();
            Assert.AreEqual(r[0].Start, 1);
        }

        [TestMethod]
        public void TestMergeIntervals()
        {
            var v5 = new Interval(1, 3);
            var v1 = new Interval(2, 6);
            var v3 = new Interval(5, 10);
            var v4 = new Interval(15, 21);
            var v2 = new Interval(18, 19);
            var v6 = new Interval(22, 23);
            var vs = new[] { v1, v2, v3, v4, v5, v6 };

            var r = Intervals.Merge(vs);
            Assert.AreEqual(r.Count, 3);
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

            var r = Intervals.Insert(vs, new Interval(4, 8));
            Assert.AreEqual(r.Count, 3);
            Assert.AreEqual(r[0].Start, 1);
            Assert.AreEqual(r[1].End, 10);
            Assert.AreEqual(r[2].End, 16);
        }
    }
}
