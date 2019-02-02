using System;
using Leetcode.BinaryTree;
using Leetcode.DataStructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLeetcode.BinaryTree
{
    [TestClass]
    public class TestBinaryTreeRightView
    {
        [TestMethod]
        public void TestMethod1()
        {
            var node1 = new TreeNode(1);
            var node2 = new TreeNode(2);
            var node3 = new TreeNode(3);
            var node4 = new TreeNode(4);
            var node5 = new TreeNode(5);
            var node6 = new TreeNode(6);


            node1.Left = node2;
            node1.Right = node3;

            node2.Left = node5;
            node3.Left = node4;

            node5.Right = node6;

            var r = BinaryTreeRightSideView.LevelOrderWay(node1);
            Assert.AreEqual(string.Join("", r), "1346");
        }
    }
}
