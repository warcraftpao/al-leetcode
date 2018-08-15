﻿using System;
using Leetcode.BinaryTree;
using Leetcode.DataStructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLeetcode.BinaryTree
{
    [TestClass]
    public class TestBinaryTreeTravle
    {
        [TestMethod]
        public void TestUniqueBinarySearchTrees_Num()
        {
            var r = UniqueBinarySearchTrees.GetNum(5);
            Assert.AreEqual(r,42);

            r = UniqueBinarySearchTrees.GetNum(10);
            Assert.AreEqual(r, 16796);
        }

        [TestMethod]
        public void TestUniqueBinarySearchTrees_Tree()
        {
            var r = UniqueBinarySearchTrees.GetTrees(5);
            Assert.AreEqual(r.Count, 42);

        }



        [TestMethod]
        public void TestInorderTraversal()
        {
            var root = TreeNode.BuildFromArray(new int[] {3, 5, 8, 4, 1, 2, 9});
            var r = BinaryTreeTravle.InorderTraversal_Recursive(root);
            Assert.AreEqual(r[0] ,1);
            Assert.AreEqual(r[3], 4);
            Assert.AreEqual(r[6], 9);


            root = TreeNode.BuildFromArray(new int[] { 3, 5, 8, 4, 1, 2, 7 });
            r = BinaryTreeTravle.InorderTraversal_Stack(root);
            Assert.AreEqual(r[0], 1);
            Assert.AreEqual(r[3], 4);
            Assert.AreEqual(r[6], 8);
        }
    }
}