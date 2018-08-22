﻿using System;
using Leetcode.BinaryTree;
using Leetcode.DataStructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLeetcode.BinaryTree
{
    [TestClass]
    public class TestMoreTree
    {
        [TestMethod]
        public void TestIsSymmetic()
        {
            var root = BuildMirror();
            var r = SymmeticTree.IsSymmetic_recursive(root);
            Assert.AreEqual(r, true);

            root = BuildNotMirror();
            r = SymmeticTree.IsSymmetic_recursive(root);
            Assert.AreEqual(r, false);
        }

        [TestMethod]
        public void TestIsSymmetic_loop()
        {
            var root = BuildMirror();
            var r = SymmeticTree.IsSymmetic_loop(root);
            Assert.AreEqual(r, true);

            root = BuildNotMirror();
            r = SymmeticTree.IsSymmetic_recursive(root);
            Assert.AreEqual(r, false);
        }


        private TreeNode BuildMirror()
        {
            var root = new TreeNode(1);
            root.Right= new TreeNode(2);
            root.Left = new TreeNode(2);

            root.Left.Left = new TreeNode(3);
            root.Left.Right = new TreeNode(4);

            root.Right.Left = new TreeNode(4);
            root.Right.Right = new TreeNode(3);
            return root;
        }

        private TreeNode BuildNotMirror()
        {
            var root = new TreeNode(1);
            root.Right = new TreeNode(2);
            root.Left = new TreeNode(2);

            root.Left.Right = new TreeNode(3);
            root.Right.Right = new TreeNode(3);
            return root;
        }

        [TestMethod]
        public void TestGetMaxDepthofBinaryTree()
        {
            var root = TreeNode.BuildBSTFromArray(new int[] {3, 1, 2, 4, 5, 6, 7, 8, 20, 11, 12, 13, 14, 15});
            var r = MaximumDepthofBinaryTree.GetDepth(root);
            Assert.AreEqual(r, 12);
        }


        [TestMethod]
        public void TestGetMinDepthofBinaryTree()
        {
            var root = TreeNode.BuildBSTFromArray(new int[] { 3, 1, 2, 4, 5, 6, 7, 8, 20, 11, 12, 13, 14, 15 });
            var r = MinimumDepth.GetDepth(root);
            Assert.AreEqual(r, 3);

            root = TreeNode.BuildBSTFromArray(new int[] { 1, 2 });
            r = MinimumDepth.GetDepth(root);
            Assert.AreEqual(r, 2);
        }

        [TestMethod]
        public void TesBalancedTree()
        {
            var root = new TreeNode(3);
            root.Left = new TreeNode(9);
            root.Right = new TreeNode(20);
            root.Right.Left = new TreeNode(15);
            root.Right.Right = new TreeNode(7);

            var r = BalancedTree.IsBalanced(root);
            Assert.AreEqual(r, true);


            root = new TreeNode(1);
            root.Left = new TreeNode(2);
            root.Right = new TreeNode(2);

            root.Left.Left = new TreeNode(3);
            root.Left.Right = new TreeNode(3);

            root.Left.Left.Left = new TreeNode(4);
            root.Left.Left.Right = new TreeNode(4);
            r = BalancedTree.IsBalanced(root);
            Assert.AreEqual(r, false);
        }
    }
}
