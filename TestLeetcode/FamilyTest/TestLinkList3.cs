using System;
using Leetcode.DataStructure;
using Leetcode.LinkList;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLeetcode.FamilyTest
{
    [TestClass]
    public class TestLinkList3
    {
        [TestMethod]
        public void TestInsertionSortList()
        {
            var head = MyLinkList.BuildListNodeFromArray(new[] {3, 5, 2, 6, 7, 4, 1 });
            var dummy = InsertionSortList.Sort(head);
            Assert.AreEqual(dummy.Next.Val,1);
            Assert.AreEqual(dummy.Next.Next.Next.Val, 3);
            Assert.AreEqual(dummy.Next.Next.Next.Next.Next.Val, 5);
            Assert.AreEqual(dummy.Next.Next.Next.Next.Next.Next.Next.Val, 7);
             
        }
    }
}
