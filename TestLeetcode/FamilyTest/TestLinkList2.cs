using System;
using System.Diagnostics;
using Leetcode.DataStructure;
using Leetcode.LinkList;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLeetcode.FamilyTest
{
    [TestClass]
    public class TestLinkList2
    {
        [TestMethod]
        public void TestReverseLinkedList()
        {
            var r = ReverseLinkedList.Reserve(MyLinkList.BuildListNodeFromArray(new[] {1, 2, 3, 4, 5}));
            Assert.AreEqual(r.Next.Val,5);
            Assert.AreEqual(r.Next.Next.Val, 4);
            Assert.AreEqual(r.Next.Next.Next.Next.Next.Val, 1);

            r = ReverseLinkedList.Reserve_Recursive(MyLinkList.BuildListNodeFromArray(new[] { 1, 2, 3, 4, 5 }));
            Assert.AreEqual(r.Next.Val, 5);
            Assert.AreEqual(r.Next.Next.Val, 4);
            Assert.AreEqual(r.Next.Next.Next.Next.Next.Val, 1);
        }

        [TestMethod]
        public void TestReserverInMtoN()
        {
            var r = ReverseLinkedList.ReserverInMtoN(MyLinkList.BuildListNodeFromArray(new[] { 1, 2, 3, 4, 5,6,7 }),3,6);
            Assert.AreEqual(r.Next.Next.Next.Val, 6);
            Assert.AreEqual(r.Next.Next.Next.Next.Next.Next.Val, 3);
        }
    }
}
