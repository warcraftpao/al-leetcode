using System;
using System.Collections;
using System.Collections.Generic;
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


        #region test root to leaf sum

        [TestMethod]
        public void TestListToInt()
        {
            var r = SumRootToLeafNumbers.ListToInt(new List<int> {1, 2, 3});
            Assert.AreEqual(r, 123);

            r = SumRootToLeafNumbers.ListToInt(new List<int> { 9,8,9,6 });
            Assert.AreEqual(r, 9896);
        }


        [TestMethod]
        public void TestSumRootToLeafNumbers()
        {

            var root1 = new TreeNode(1);
            root1.Left = new TreeNode(2);
            root1.Right = new TreeNode(3);
            var r = SumRootToLeafNumbers.GetSum(root1);
            Assert.AreEqual(r, 25);


            var root2 = new TreeNode(4);
            root2.Left = new TreeNode(9);
            root2.Right = new TreeNode(0);

            root2.Left.Left = new TreeNode(5);
            root2.Left.Right = new TreeNode(1);

            r = SumRootToLeafNumbers.GetSum(root2);
            Assert.AreEqual(r, 1026);
        }
        #endregion

        [TestMethod]
        public void TestInvent()
        {
            //完整的情况
            var root = new TreeNode(4);
            root.Left = new TreeNode(2);
            root.Right = new TreeNode(7);
            root.Left.Left = new TreeNode(1);
            root.Left.Right = new TreeNode(3);
            root.Right.Left = new TreeNode(6);
            root.Right.Right = new TreeNode(9);

            root = InvertBinaryTree.Invent(root);

            Assert.AreEqual(root.Left.Val, 7);
            Assert.AreEqual(root.Right.Val, 2);
            Assert.AreEqual(root.Left.Left.Val, 9);
            Assert.AreEqual(root.Left.Right.Val, 6);
            Assert.AreEqual(root.Right.Left.Val, 3);
            Assert.AreEqual(root.Right.Right.Val, 1);

            //不完整的情况
            root = new TreeNode(1);
            root.Left = new TreeNode(2);
            root.Right = new TreeNode(3);
            root.Left.Left = new TreeNode(4);
            root.Left.Right = new TreeNode(5);
            root.Right.Right = new TreeNode(6);
            root.Left.Right.Left = new TreeNode(7);


            root = InvertBinaryTree.Invent(root);

            Assert.AreEqual(root.Left.Val, 3);
            Assert.AreEqual(root.Right.Val, 2);
            Assert.AreEqual(root.Left.Left.Val, 6);
            Assert.AreEqual(root.Right.Left.Val,5);
            Assert.AreEqual(root.Right.Right.Val, 4);
            Assert.AreEqual(root.Right.Left.Right.Val, 7);
        }


        [TestMethod]
        public void TestKthSmallestElementInBST()
        {
            var root = TreeNode.BuildBSTFromArray(new[] {3, 1, 4, 2});
            var result = KthSmallestElementInBST.Find(root,1);
            Assert.AreEqual(result, 1); 

            root = TreeNode.BuildBSTFromArray(new[] { 5, 3, 6, 2, 4,   1 });
            result = KthSmallestElementInBST.Find(root, 3);
            Assert.AreEqual(result, 3);
        }
        

        [TestMethod]
        public void TestLowestCommonAncestorofBST()
        {
            var root = TreeNode.BuildBSTFromArray(new[] { 6, 2, 8, 0, 4, 7, 9,   3, 5 });
            var result = LowestCommonAncestorofBST.Search(root,new TreeNode(2), new TreeNode(8) );
            Assert.AreEqual(result.Val, 6);

            root = TreeNode.BuildBSTFromArray(new[] { 6, 2, 8, 0, 4, 7, 9,  3, 5 });
            result = LowestCommonAncestorofBST.Search(root, new TreeNode(2), new TreeNode(4));
            Assert.AreEqual(result.Val, 2);
        }
    }
}
