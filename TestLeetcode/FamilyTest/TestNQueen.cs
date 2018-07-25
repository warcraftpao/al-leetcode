using Leetcode.Hard;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLeetcode.FamilyTest
{
    [TestClass]
    public  class TestNQueen
    {
        [TestMethod]
        public void TestQueenSolver()
        {
           var r =  NQueen.NqueenSolver(8);
            Assert.AreEqual(r.Count, 92);
        }

        [TestMethod]
        public void TestNqueenResultNumber()
        {
            var r = NQueen.NqueenResultNumber(8);
            Assert.AreEqual(r, 92);
        }
    }
}
