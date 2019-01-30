using System;
using Leetcode.BinaryTree;
using Leetcode.DataStructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLeetcode.BinaryTree
{
    [TestClass]
    public class TestBinarySearchTreeIterator
    {
        [TestMethod]
        public void TestMethod1()
        {
            var node1 = new TreeNode(7);
            var node2 = new TreeNode(3);
            var node3 = new TreeNode(15);
            var node4 = new TreeNode(9);
            var node5 = new TreeNode(20);

            node1.Left = node2;
            node1.Right = node3;
            node3.Left = node4;
            node3.Right = node5;

            var iterator = new BinarySearchTreeIterator(node1);
            Assert.AreEqual(iterator.Next(), 3); // return 3
            Assert.AreEqual(iterator.Next(), 7); // return 7
            Assert.AreEqual(iterator.HasNext(), true); // return true
            Assert.AreEqual(iterator.Next(), 9); // return 9
            Assert.AreEqual(iterator.HasNext(), true); // return true
            Assert.AreEqual(iterator.Next(), 15); // return 15
            Assert.AreEqual(iterator.HasNext(),true); // return true
            Assert.AreEqual(iterator.Next(), 20); // return 20
            Assert.AreEqual(iterator.HasNext(), false); // return false
        }
    }
}
