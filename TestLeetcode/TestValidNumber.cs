using System;
using Leetcode.Hard;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLeetcode
{
    [TestClass]
    public class TestValidNumber
    {
        [TestMethod]
        public void TestSuccCase()
        {
            var r1 = ValidNumber.IsValid(" 1e2 ");
            Assert.AreEqual(r1, true);

            var r2 = ValidNumber.IsValid(" -1.1e2 ");
            Assert.AreEqual(r2, true);

            var r3 = ValidNumber.IsValid(" +1e3");
            Assert.AreEqual(r3, true);

            var r4 = ValidNumber.IsValid("11");
            Assert.AreEqual(r4, true);

            var r5 = ValidNumber.IsValid("99  ");
            Assert.AreEqual(r5, true);

            var r6 = ValidNumber.IsValid("1.55");
            Assert.AreEqual(r6, true);

            var r7 = ValidNumber.IsValid("+22E10");
            Assert.AreEqual(r7, true);

        }

        [TestMethod]
        public void TestFailCase()
        {
            var r1 = ValidNumber.IsValid("a 1e2 ");
            Assert.AreEqual(r1, false);

            var r2 = ValidNumber.IsValid(" 11 1 ");
            Assert.AreEqual(r2, false);

            var r3 = ValidNumber.IsValid(" +1.e3");
            Assert.AreEqual(r3, false);

            var r4 = ValidNumber.IsValid(" 11+e");
            Assert.AreEqual(r4, false);

            var r5 = ValidNumber.IsValid("1.55e1.3");
            Assert.AreEqual(r5, false);

            var r6 = ValidNumber.IsValid("1.e3");
            Assert.AreEqual(r6, false);

            var r7 = ValidNumber.IsValid("1.5e5e1.3");
            Assert.AreEqual(r7, false);

            var r8 = ValidNumber.IsValid("e1.3");
            Assert.AreEqual(r8, false);

            var r9 = ValidNumber.IsValid(" ");
            Assert.AreEqual(r9, false);

            var r10 = ValidNumber.IsValid("1.");
            Assert.AreEqual(r10, false);
        }
    }
}
