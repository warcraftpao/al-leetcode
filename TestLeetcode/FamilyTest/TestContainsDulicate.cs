using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leetcode.Easy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLeetcode.FamilyTest
{
    [TestClass]
    public class TestContainsDulicate
    {
        [TestMethod]
        public void TestLevel1()
        {
            var r = ContainsDulicate.Level1(new[] {1, 2, 3, 1});
            Assert.IsTrue(r);

            r = ContainsDulicate.Level1(new[] { 1, 2, 3,4 });
            Assert.IsFalse(r);

            r = ContainsDulicate.Level1(new[] { 1, 1, 1, 3, 3, 4, 3, 2, 4, 2 });
            Assert.IsTrue(r);
        }


        [TestMethod]
        public void TestLevel2()
        {
            var r = ContainsDulicate.Level2(new[] { 1, 2, 3, 1 },3);
            Assert.IsTrue(r);

            r = ContainsDulicate.Level2(new[] { 1, 0, 1, 1 },1);
            Assert.IsTrue(r);

            r = ContainsDulicate.Level2(new[] { 1, 2, 3, 1, 2, 3 },2);
            Assert.IsFalse(r);


            r = ContainsDulicate.Level2(new[] { 1, 2, 3, 1, 2, 3,4,5,6,7,4 }, 3);
            Assert.IsTrue(r);
        }

        [TestMethod]
        public void TestSortedSet()
        {
            var set = new SortedSet<int>();
            var r1 = set.Add(1);
            var r1Again = set.Add(1);
            set.Add(2);
            set.Add(3);
            set.Add(4);
            set.Add(6);
            set.Add(7);
            set.Add(8);

            //重复加返回false
            Assert.IsTrue(r1);
            Assert.IsFalse(r1Again);

            //where 后toList还是保持本来的顺序
            var where = set.Where(a => a < 6).ToList();
            Assert.AreEqual(where[0] ,1);

            if (set.Any(s => s < -1))
            {
                //不会执行到
                var small = set.Where(s => s < -1).Max();
            }


            if (set.Any(s => s < 6))
            {
                //where后取max min还能取到的
                var small = set.Where(s => s < 6).Max();
                Assert.AreEqual(small, 4);
            }

        }


        [TestMethod]
        public void TestLevel3()
        {
            var r = ContainsDulicate.Level3(new[] { 1, 2, 3, 1 }, 3,0);
            Assert.IsTrue(r);

            r = ContainsDulicate.Level3(new[] { 1, 0, 1, 1 }, 1, 2);
            Assert.IsTrue(r);

            r = ContainsDulicate.Level3(new[] { 1, 5, 9, 1, 5, 9 }, 2 ,3);
            Assert.IsFalse(r);


            r = ContainsDulicate.Level3(new[] { -101, 200, -300, -50, 21, 3, 4, 9, 6, 7, 4 }, 2,6);
            Assert.IsTrue(r);
        }

    }
}
