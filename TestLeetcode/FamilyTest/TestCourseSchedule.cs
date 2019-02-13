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
        public void TestLevel1()
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

         
    }
}
