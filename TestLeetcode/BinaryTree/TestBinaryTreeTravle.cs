using System;
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

            root = TreeNode.BuildFromArray(new int[] { 6, 3, 8, 4, 1, 2, 7 });
            r = BinaryTreeTravle.InorderTraversal_Morris(root);
            Assert.AreEqual(r[0], 1);
            Assert.AreEqual(r[3], 4);
            Assert.AreEqual(r[6], 8);
        }

        [TestMethod]
        public void TestValidateBinarySearchTree()
        {
            var tree = Build1();
            var r = ValidateBinarySearchTree.IsValid(tree);
            Assert.AreEqual(r, false);

            tree = Build2();
            r = ValidateBinarySearchTree.IsValid(tree);
            Assert.AreEqual(r, true);

            tree = Build3();
            r = ValidateBinarySearchTree.IsValid(tree);
            Assert.AreEqual(r, false);

        }

        //try to build a tree might be valid or not valid binary tree
        private TreeNode Build1()
        {
            var root = new TreeNode(5);
            root.Left= new TreeNode(1);
            root.Right = new TreeNode(4);

            var parent = root.Right;
            parent.Left = new TreeNode(3);
            parent.Right = new TreeNode(6);

            return root;
        }

        //try to build a tree might be valid or not valid binary tree
        private TreeNode Build2()
        {
            var root = new TreeNode(2);
            root.Left = new TreeNode(1);
            root.Right = new TreeNode(3);

            return root;
        }

        //一个特殊例子，局部符合二叉树特性，但是整体不符合，就是跳开一层后不符合了
        private TreeNode Build3()
        {
            var root = new TreeNode(10);
            root.Left = new TreeNode(4);
            root.Right = new TreeNode(15);

            var parent = root.Left;
            parent.Left = new TreeNode(2);
            parent.Right = new TreeNode(5);

            parent = root.Right;
            parent.Left = new TreeNode(6);
            parent.Right = new TreeNode(17);


            return root;
        }
    }
}
