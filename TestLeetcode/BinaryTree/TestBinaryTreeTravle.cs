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
            var root = TreeNode.BuildBSTFromArray(new int[] {3, 5, 8, 4, 1, 2, 9});
            var r = BinaryTreeTravle.InorderTraversal_Recursive(root);
            Assert.AreEqual(r[0] ,1);
            Assert.AreEqual(r[3], 4);
            Assert.AreEqual(r[6], 9);


            root = TreeNode.BuildBSTFromArray(new int[] { 3, 5, 8, 4, 1, 2, 7 });
            r = BinaryTreeTravle.InorderTraversal_Stack(root);
            Assert.AreEqual(r[0], 1);
            Assert.AreEqual(r[3], 4);
            Assert.AreEqual(r[6], 8);

            root = TreeNode.BuildBSTFromArray(new int[] { 6, 3, 8, 4, 1, 2, 7 });
            r = BinaryTreeTravle.InorderTraversal_Morris(root);
            Assert.AreEqual(r[0], 1);
            Assert.AreEqual(r[3], 4);
            Assert.AreEqual(r[6], 8);
        }

        [TestMethod]
        public void TestPreorderTraversal()
        {
            var root = TreeNode.BuildBSTFromArray(new int[] { 3, 5, 8, 4, 1, 2, 9 });
            var r = BinaryTreeTravle.Preorder_Recursive(root);
            Assert.AreEqual(r[0], 3);
            Assert.AreEqual(r[3], 5);
            Assert.AreEqual(r[6], 9);

            root = TreeNode.BuildBSTFromArray(new int[] { 3, 5, 8, 4, 1, 2, 9 });
            r = BinaryTreeTravle.Preorder_Iterations(root);
            Assert.AreEqual(r[0], 3);
            Assert.AreEqual(r[3], 5);
            Assert.AreEqual(r[6], 9);

        }

        [TestMethod]
        public void TestPostorderTraversal()
        {
            var root = TreeNode.BuildBSTFromArray(new int[] { 3, 5, 8, 4, 1, 2, 9 });
            var r = BinaryTreeTravle.PostorderTraversal_recursive(root);
            Assert.AreEqual(r[0], 2);
            Assert.AreEqual(r[3], 9);
            Assert.AreEqual(r[6], 3);

            root = TreeNode.BuildBSTFromArray(new int[] { 6, 3, 8, 4, 1, 2, 7 });
            r = BinaryTreeTravle.PostorderTraversal_Iterations(root);
            Assert.AreEqual(r[0], 2);
            Assert.AreEqual(r[3], 3);
            Assert.AreEqual(r[6], 6);
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

        [TestMethod]
        public void TestLevelOrderTraversal()
        {
            var root = new TreeNode(3);
            root.Left  = new TreeNode(9);
            root.Right = new TreeNode(20);
            root.Right.Left = new TreeNode(15);
            root.Right.Right = new TreeNode(7);

            var r = BinaryTreeTravle.LevelOrderTraversal_loop(root);
            Assert.AreEqual(r.Count ,3);
            Assert.AreEqual(r[2][0], 15);
            Assert.AreEqual(r[1][1], 20);


            r = BinaryTreeTravle.LevelOrderTraversal_recursive(root);
            Assert.AreEqual(r.Count, 3);
            Assert.AreEqual(r[2][0], 15);
            Assert.AreEqual(r[1][1], 20);
        }

        [TestMethod]
        public void TestZigzagLevelOrderTraversal()
        {
            var root = new TreeNode(3);
            root.Left = new TreeNode(9);
            root.Right = new TreeNode(20);
            root.Right.Left = new TreeNode(15);
            root.Right.Right = new TreeNode(7);

            var r = BinaryTreeTravle.AddZigzagLevelOrderTraversal(root);
            Assert.AreEqual(r.Count, 3);
            Assert.AreEqual(r[1][0], 20);
            Assert.AreEqual(r[2][0], 15);
 
        }

        [TestMethod]
        public void TestFlattenBinaryTreeToLinkedList()
        {
            var root = new TreeNode(1);
            root.Left = new TreeNode(2);
            root.Right = new TreeNode(5);

            root.Left.Left = new TreeNode(3);
            root.Left.Right = new TreeNode(4);
            root.Right.Right = new TreeNode(6);

            BinaryTreeTravle.FlattenBinaryTreeToLinkedList(root);

            Assert.AreEqual(root.Val,1);
            Assert.AreEqual(root.Right.Val, 2);
            Assert.AreEqual(root.Right.Right.Right.Val, 4);
            Assert.AreEqual(root.Right.Right.Right.Right.Right.Val, 6);
        }
    }

}
