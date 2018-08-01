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
            var r = Combinations.Generate(4,2 );
            Assert.AreEqual(r.Count, 6);
        }

        
    }
}

