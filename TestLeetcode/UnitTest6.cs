using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Leetcode.DataStructure;
using Leetcode.Easy;
using Leetcode.Hard;
using Leetcode.Middle;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLeetcode
{
  
    [TestClass]
    public class UnitTest6
    {
        [TestMethod]
        public void TestReverseNodesinkGroup()
        {
            var head1 = LinkedList.BuildListNode(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 });
            var r = ReverseNodesinkGroup.Reserve(head1, 3);

            Assert.AreEqual(r.Next.Next.Next.Val, 1);
            Assert.AreEqual(r.Next.Next.Next.Next.Next.Next.Next.Next.Next.Next.Next.Val, 11);
        }

        [TestMethod]
        public void TestRemoveDuplicates()
        {
            var arr = new[] {0, 0, 1, 1, 1, 2, 2, 3, 3, 4};
            var r = RemoveDuplicates.RemoveDuplicatedInSortedArray(arr);
            Assert.AreEqual(r, 5);
            Assert.AreEqual(arr[1], 1);
            Assert.AreEqual(arr[2], 2);
            Assert.AreEqual(arr[4], 4);
            /////////////////////////////////////////////////
            var arr2 = new[] {1, 2, 1, 5, 1, 4};
            var r2 = RemoveDuplicates.RemoveElementFromArray(arr2, 1);
            Assert.AreEqual(r2, 3);
            Assert.AreEqual(arr2[0], 4);
            Assert.AreEqual(arr2[1], 2);
            Assert.AreEqual(arr2[2], 5);
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
    }
}
