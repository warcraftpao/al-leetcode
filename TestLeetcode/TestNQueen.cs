using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leetcode.Hard;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLeetcode
{
    [TestClass]
    public  class TestNQueen
    {
        [TestMethod]
        public void TestQueen1()
        {
           var r =  NQueen.NqueenSolver(8);
            Assert.AreEqual(r.Count, 92);
        }
    }
}
