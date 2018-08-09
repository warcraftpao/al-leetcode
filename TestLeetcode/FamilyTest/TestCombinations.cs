using Leetcode.Hard;
using Leetcode.Middle;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLeetcode.FamilyTest
{
    [TestClass]
    public class TestCombinations
    {
        [TestMethod]
        public void TestCombination()
        {
            var r = Combinations.Generate(10,6);  //    10!/ (4!*6!)
            Assert.AreEqual(r.Count, 210);
        }

        [TestMethod]
        public void TestSubsets()
        {
            var r = Combinations.Subsets(new [] {1,2,3,4,5,6,7,8,9,10});
            Assert.AreEqual(r.Count, 1024);

            r = Combinations.Subsets_S2(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
            Assert.AreEqual(r.Count, 1024);
        }

        [TestMethod]
        public void TestSubsetsWithDuplicate()
        {
            var r = Combinations.SubsetsWithDuplicate(new[] { 1, 2, 2 });
            Assert.AreEqual(r.Count, 6);

            
        }
    }
}

