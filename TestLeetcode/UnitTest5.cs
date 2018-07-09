using System;
using System.Text;
using System.Collections.Generic;
using Leetcode.DataStructure;
using Leetcode.Easy;
using Leetcode.Hard;
using Leetcode.Middle;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLeetcode
{
 
    [TestClass]
    public class UnitTest5
    { 
        [TestMethod]
        public void TestRemoveNthFromEnd()
        {
            var head = LinkedList.BuildListNode(new[] {1, 2, 3, 4, 5});
            head = RemoveNthFromEnd.S1(head, 2);
            Assert.AreEqual(head.Length(), 4);
        }

        [TestMethod]
        public void TestValidParentheses()
        {
            var r = ValidParentheses.Valid("()");
            Assert.AreEqual(r, true);

            r = ValidParentheses.Valid("()[]{}");
            Assert.AreEqual(r, true);

            r = ValidParentheses.Valid("(]");
            Assert.AreEqual(r, false);

            r = ValidParentheses.Valid("([)]");
            Assert.AreEqual(r, false);

            r = ValidParentheses.Valid("{[]}");
            Assert.AreEqual(r, true);
        }


        [TestMethod]
        public void TestMergeTwoSortedList()
        {
            var head1 = LinkedList.BuildListNode(new[] { 1, 2, 4 });
            var head2 = LinkedList.BuildListNode(new[] { 1, 3, 4 });
            var head3 = MergeTwoSortedList.Merge(head1, head2);
            Assert.AreEqual(head3.Length(), 6);
        }

        [TestMethod]
        public void TestMergeKSortedList()
        {
            var head1 = LinkedList.BuildListNode(new[] { 1, 4, 5 });
            var head2 = LinkedList.BuildListNode(new[] { 1, 3, 4 });
            var head3 = LinkedList.BuildListNode(new[] { 2, 6 });
            var head4 = LinkedList.BuildListNode(new[] { 7 });
            var head5 = LinkedList.BuildListNode(new[] { 8 });
            var head6 = LinkedList.BuildListNode(new[] { 9 });
            var head7 = LinkedList.BuildListNode(new[] { 10 });
            var head8 = LinkedList.BuildListNode(new[] { 11 });
            var head9 = LinkedList.BuildListNode(new[] { 12 });

            var headX = MergeTwoSortedList.MergeKSortedLinkedList(new [] { head1 , head2, head3, head4, head5, head6, head7, head8, head9});
            Assert.AreEqual(headX.Length(), 14);
        }


        [TestMethod]
        public void TestGenerateParentheses()
        {
            var r = GenerateParentheses.Generate(3);
            
            Assert.IsTrue(r.Contains("(())()"));
        }

        [TestMethod]
        public void TestSwapNodeInPair()
        {
            var head1 = LinkedList.BuildListNode(new[] { 1, 2, 3, 4});
            SwapNodeInPair.Swap(head1);

            Assert.AreEqual(head1.Next.Next.Next.Val, 4);
            Assert.AreEqual(head1.Next.Val, 2);

            var head2 = LinkedList.BuildListNode(new[] { 1, 2, 3, 4, 5 });
            SwapNodeInPair.Swap(head2);

            Assert.AreEqual(head2.Next.Next.Next.Val, 4);
            Assert.AreEqual(head2.Next.Next.Next.Next.Next.Val, 5);
        }


        
    }
}
