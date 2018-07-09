using System;
using System.Text;
using System.Collections.Generic;
using Leetcode.DataStructure;
using Leetcode.Easy;
using Leetcode.Hard;
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
            var r = RemoveDuplicates.S1(new[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 });
            Assert.AreEqual(r, 5);
        }
    }
}
