using System;
using Leetcode.DataStructure;
using Leetcode.Middle;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLeetcode.FamilyTest
{
    [TestClass]
    public class TestLinkedList
    {
        [TestMethod]
        public void TestRotateLinkedList()
        {
            var head = LinkedList.BuildListNodeFromArray(new[] {1, 2, 3, 4, 5, 6, 7});
            RotateLinkedList.Rotate(head, 5);
            Assert.AreEqual(head.Next.Val, 3);
        }

        [TestMethod]
        public void TestAddTwoNumbers()
        {
            var node1 = LinkedList.BuildListNodeFromArray(new int[] { 3, 1, 4 });
            var node2 = LinkedList.BuildListNodeFromArray(new int[] { 9, 8, 7 });
            var val1 = AddTwoNumbers.AddTwoNumbers1(node1, node2);
            Assert.AreEqual(val1, 1202);

            var node3 = LinkedList.BuildListNodeFromArray(new int[] { 0, 3, 4 });
            var node4 = LinkedList.BuildListNodeFromArray(new int[] { 9, 8, 7 });
            var val2 = AddTwoNumbers.AddTwoNumbers2(node3, node4);
            Assert.AreEqual(val2, 1219);
        }


    }
}
