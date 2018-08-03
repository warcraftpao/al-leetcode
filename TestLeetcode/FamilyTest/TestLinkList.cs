using System;
using Leetcode.DataStructure;
using Leetcode.LinkList;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLeetcode.FamilyTest
{
    [TestClass]
    public class TestLinkList
    {
        [TestMethod]
        public void TestRotateLinkedList()
        {
            var head = MyLinkList.BuildListNodeFromArray(new[] {1, 2, 3, 4, 5, 6, 7});
            RotateLinkedList.Rotate(head, 5);
            Assert.AreEqual(head.Next.Val, 3);
        }

        [TestMethod]
        public void TestAddTwoNumbers()
        {
            var node1 = MyLinkList.BuildListNodeFromArray(new int[] { 3, 1, 4 });
            var node2 = MyLinkList.BuildListNodeFromArray(new int[] { 9, 8, 7 });
            var val1 = AddTwoNumbers.AddTwoNumbers1(node1, node2);
            Assert.AreEqual(val1, 1202);

            var node3 = MyLinkList.BuildListNodeFromArray(new int[] { 0, 3, 4 });
            var node4 = MyLinkList.BuildListNodeFromArray(new int[] { 9, 8, 7 });
            var val2 = AddTwoNumbers.AddTwoNumbers2(node3, node4);
            Assert.AreEqual(val2, 1219);
        }

        [TestMethod]
        public void TestMergeTwoSortedList()
        {
            var head1 = MyLinkList.BuildListNodeFromArray(new[] { 1, 2, 4 });
            var head2 = MyLinkList.BuildListNodeFromArray(new[] { 1, 3, 4 });
            var head3 = MergeTwoSortedList.Merge(head1, head2);
            Assert.AreEqual(head3.Length(), 6);
        }

        [TestMethod]
        public void TestMergeKSortedList()
        {
            var head1 = MyLinkList.BuildListNodeFromArray(new[] { 1, 4, 5 });
            var head2 = MyLinkList.BuildListNodeFromArray(new[] { 1, 3, 4 });
            var head3 = MyLinkList.BuildListNodeFromArray(new[] { 2, 6 });
            var head4 = MyLinkList.BuildListNodeFromArray(new[] { 7 });
            var head5 = MyLinkList.BuildListNodeFromArray(new[] { 8 });
            var head6 = MyLinkList.BuildListNodeFromArray(new[] { 9 });
            var head7 = MyLinkList.BuildListNodeFromArray(new[] { 10 });
            var head8 = MyLinkList.BuildListNodeFromArray(new[] { 11 });
            var head9 = MyLinkList.BuildListNodeFromArray(new[] { 12 });

            var headX = MergeTwoSortedList.MergeKSortedMyLinkList(new[] { head1, head2, head3, head4, head5, head6, head7, head8, head9 });
            Assert.AreEqual(headX.Length(), 14);
        }

        [TestMethod]
        public void TestSwapNodeInPair()
        {
            var head1 = MyLinkList.BuildListNodeFromArray(new[] { 1, 2, 3, 4 });
            SwapNodeInPair.Swap(head1);

            Assert.AreEqual(head1.Next.Next.Next.Val, 4);
            Assert.AreEqual(head1.Next.Val, 2);

            var head2 = MyLinkList.BuildListNodeFromArray(new[] { 1, 2, 3, 4, 5 });
            SwapNodeInPair.Swap(head2);

            Assert.AreEqual(head2.Next.Next.Next.Val, 4);
            Assert.AreEqual(head2.Next.Next.Next.Next.Next.Val, 5);
        }

        [TestMethod]
        public void TestRemoveDuplicatedFromLinkedList()
        {
            var head = MyLinkList.BuildListNodeFromArray(new[] { 1, 1, 2, 2, 3, 3 });
            var r = RemoveDuplicatesFromSortedList.KeepOnly1(head);
            Assert.AreEqual(r.Next.Next.Val, 2);
            Assert.AreEqual(r.Length(), 3);

            head = MyLinkList.BuildListNodeFromArray(new[] { 1, 1 });
            r = RemoveDuplicatesFromSortedList.KeepOnly1(head);
            Assert.AreEqual(r.Next.Val, 1);
            Assert.AreEqual(r.Length(), 1);
        }


        [TestMethod]
        public void TestRemoveDuplicatedFromLinkedList2()
        {
            var head = MyLinkList.BuildListNodeFromArray(new[] { 1, 1, 2, 3, 3, 4, 5, 5 });
            var r = RemoveDuplicatesFromSortedList.RemoveAllIfDuplicated(head);
            Assert.AreEqual(r.Next.Next.Val, 4);
            Assert.AreEqual(r.Length(), 2);

        }

        [TestMethod]
        public void TestRemoveNthFromEnd()
        {
            var head = MyLinkList.BuildListNodeFromArray(new[] { 1, 2, 3, 4, 5 });
            head = RemoveNthFromEnd.S1(head, 2);
            Assert.AreEqual(head.Length(), 4);
        }

        [TestMethod]
        public void TestReverseNodesinkGroup()
        {
            var head1 = MyLinkList.BuildListNodeFromArray(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 });
            var r = ReverseNodesinkGroup.Reserve(head1, 3);

            Assert.AreEqual(r.Next.Next.Next.Val, 1);
            Assert.AreEqual(r.Next.Next.Next.Next.Next.Next.Next.Next.Next.Next.Next.Val, 11);
        }
    }
}
