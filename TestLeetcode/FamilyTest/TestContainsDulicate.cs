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
    }
}
