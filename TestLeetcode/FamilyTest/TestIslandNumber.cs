using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leetcode.Middle;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLeetcode.FamilyTest
{
    [TestClass]
    public  class TestIslandNumber
    {
        [TestMethod]
        public void IslandNumnber1()
        {
            //11110
           // 11010
            //11000
            //00000
            var grid = new char[,]
            {
                {'1', '1', '1', '1', '0'},
                {'1', '1', '0', '1', '0'},
                {'1', '1', '0', '0', '1'},
                {'0', '0', '0', '1', '0'},

            };

            var r = IslandNumber.Count(grid);
            Assert .AreEqual(r, 3);


            grid = new char[,]
            {
                {'1', '1', '1', '1', '0','1', '1'},
                {'1', '1', '0', '1', '0','1', '1'},
                {'1', '1', '0', '0', '1','1', '1'},
                {'1', '0', '0', '1', '0','1', '1'},
                {'0', '1', '0', '1', '0','1', '1'},
                {'1', '1', '0', '1', '0','1', '1'},
                {'0', '0', '0', '1', '0','1', '1'},
                {'1', '0', '0', '1', '0','1', '1'},

            };

            r = IslandNumber.Count(grid);
            Assert.AreEqual(r, 5);
        }
    }
}
