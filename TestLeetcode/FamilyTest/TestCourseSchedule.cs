using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Leetcode.Middle;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLeetcode.FamilyTest
{
    //注意： 题目的本来的输入就是[target, source]有些别扭
    [TestClass]
    public  class TestCourseSchedule
    {
        [TestMethod]
        public void TestCanFinish()
        {
            //无环
            var arr = new int[,]
            {
                {1, 0},
                {2, 0},
                {3, 1},
                {5, 2},
                {4, 3},
                {3, 6},

            };
            var r = CourseSchedule.CanFinish(7, arr);
            Assert.AreEqual(r,true);

            //有环
            arr = new int[,]
            {
                {1, 0},
                {2, 0},
                {3, 1},
                {5, 2},
                {4, 3},
                {3, 6},
                {6, 4},

            };
             r = CourseSchedule.CanFinish(7, arr);
            Assert.AreEqual(r, false);

        }

        [TestMethod]
        public void TestOrder()
        {
            //无环
            var arr = new int[,]
            {
                {1, 0},
                {2, 0},
                {3, 1},
                {5, 2},
                {4, 3},
                {3, 6},

            };
            var r = CourseSchedule.FindOrder(7, arr);
            //上面这图里按照我写的算法是分层次的 06最外层，12第二层，35第三层，4最后，同一层次里数组里先出现结果里也先出现
            var s = string.Join("", r);
            
            Assert.AreEqual(s.Substring(0,2) ,"06");
            Assert.AreEqual(s.Substring(2, 2), "12");
            Assert.AreEqual(s.Substring(4, 2), "35");
            Assert.AreEqual(s.Substring(6, 1), "4");


            //无环
            arr = new int[,]
            {
               { 1, 0}, { 2,0}, { 3,1}, { 3,2}

            };
            r = CourseSchedule.FindOrder(4, arr);
            //上面这图里按照我写的算法是分层次的 06最外层，12第二层，35第三层，4最后，同一层次里数组里先出现结果里也先出现
            s = string.Join("", r);

            Assert.AreEqual(s.Substring(0, 1), "0");
            Assert.AreEqual(s.Substring(1, 2), "12");
            Assert.AreEqual(s.Substring(3, 1), "3");



            //有环
            arr = new int[,]
            {
                {1, 0},
                {2, 0},
                {3, 1},
                {5, 2},
                {4, 3},
                {3, 6},
                {6, 4},

            };
            r = CourseSchedule.FindOrder(7, arr);
            Assert.AreEqual(r.Length, 0);

        }
    }
}
