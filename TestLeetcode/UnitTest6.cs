using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Leetcode.DataStructure;
using Leetcode.Easy;
using Leetcode.Hard;
using Leetcode.LinkList;
using Leetcode.Middle;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLeetcode
{
  
    [TestClass]
    public class UnitTest6
    {
        

        [TestMethod]
        public void TestRemoveDuplicates()
        {
            var arr = new[] {0, 0, 1, 1, 1, 2, 2, 3, 3, 4};
            var r = RemoveDuplicatesInSortedArray.RemoveDuplicatedInSortedArray(arr);
            Assert.AreEqual(r, 5);
            Assert.AreEqual(arr[1], 1);
            Assert.AreEqual(arr[2], 2);
            Assert.AreEqual(arr[4], 4);
        }

        [TestMethod]
        public void TestRemoveDuplicates2()
        {
            var arr = new[] {0, 0, 1, 1, 1, 1, 2, 3, 3, 3, 4, 4, 5};
            var r = RemoveDuplicatesInSortedArray.RemoveDuplicatedInSortedArray2(arr);
            Assert.AreEqual(r, 10);
            Assert.AreEqual(arr[4], 2);
        }

        public void TestRemoveElementFromArray()
        {
            var arr = new[] { 1, 2, 1, 5, 1, 4 };
            var r = RemoveDuplicatesInSortedArray.RemoveElementFromArray(arr, 1);
            Assert.AreEqual(r, 3);
            Assert.AreEqual(arr[0], 4);
            Assert.AreEqual(arr[1], 2);
            Assert.AreEqual(arr[2], 5);
        }

        [TestMethod]
        public void TestDivideTwoIntegers1()
        {
            var r = DivideTwoIntegers.S1(10, 3);
            Assert.AreEqual(r, 3);

            r = DivideTwoIntegers.S1(10, -5);
            Assert.AreEqual(r, -2);

            r = DivideTwoIntegers.S1(-16, -5);
            Assert.AreEqual(r, 3);
        }

        [TestMethod]
        public void TestDivideTwoIntegers2()
        {
            var r = DivideTwoIntegers.S2(10, 3);
            Assert.AreEqual(r, 3);

            r = DivideTwoIntegers.S2(10, -5);
            Assert.AreEqual(r, -2);

            r = DivideTwoIntegers.S2(-28, -3);
            Assert.AreEqual(r, 9);
        }

        [TestMethod]
        public void TestSubstringwithConcatenationofAllWords()
        {
            var r = SubstringwithConcatenationofAllWords.S1("barfoothefoobarman", new [] { "foo", "bar" });
            Assert.IsTrue(r.Contains(0) && r.Contains(9) && r.Length == 2);

            r = SubstringwithConcatenationofAllWords.S1("wordgoodstudentgoodword", new[] { "word", "student" });
            Assert.IsTrue( r.Length == 0);

            r = SubstringwithConcatenationofAllWords.S1("abbbccc", new[] { "a", "b","b", "b" ,"c"});
            Assert.IsTrue(r.Length == 1);
        }

        [TestMethod]
        public void TestRestoreIpAddresses()
        {
            var r = RestoreIpAddresses.Restore("25525511135");
            Assert.AreEqual(r[0], "255.255.11.135");
            Assert.AreEqual(r[1], "255.255.111.35");
        }

        [TestMethod]
        public void TestValidPalindrome()
        {
            var r = ValidPalindrome.IsValid("A man, a plan, a canal: Panama");
            Assert.AreEqual(r , true);

            r = ValidPalindrome.IsValid("A man, a plan, a vcanal: Panama");
            Assert.AreEqual(r, false);
        }

    }
}
