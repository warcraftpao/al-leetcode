using System;
using System.Linq;
using Leetcode.BinaryTree;
using Leetcode.DataStructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLeetcode.BinaryTree
{
    [TestClass]
    public class TestTreePath
    {
        [TestMethod]
        public void TestPath1()
        {
            var root = new TreeNode(5);
            root.Left = new TreeNode(4);
            root.Right = new TreeNode(8);

            root.Left.Left = new TreeNode(11);
            root.Left.Left.Left = new TreeNode(7);
            root.Left.Left.Right = new TreeNode(2);

            root.Right.Left = new TreeNode(13);
            root.Right.Right = new TreeNode(4);
            root.Right.Right.Right = new TreeNode(1);

            var r = PathSum.HasPathSum(root, 22);
            Assert.AreEqual(r,true);

            r = PathSum.HasPathSum(root, 13);
            Assert.AreEqual(r, false);

        }


        [TestMethod]
        public void TestGetPathSum()
        {
            var root = new TreeNode(5);
            root.Left = new TreeNode(4);
            root.Right = new TreeNode(8);

            root.Left.Left = new TreeNode(11);
            root.Left.Left.Left = new TreeNode(7);
            root.Left.Left.Right = new TreeNode(2);

            root.Right.Left = new TreeNode(13);
            root.Right.Right = new TreeNode(4);
            root.Right.Right.Right = new TreeNode(1);
            root.Right.Right.Left = new TreeNode(5);

            var r = PathSum.GetPathSum(root, 22);
            Assert.AreEqual(r.Count, 2);
            Assert.AreEqual(r.All( i=> i.Sum() == 22), true);
        }

        [TestMethod]
        public void TestMaximumPathSum()
        {
            var root = new TreeNode(1);
            root.Left =new TreeNode(2);
            root.Right =new TreeNode(3);
            var r = MaximumPathSum.GetSum(root);
            Assert.AreEqual(r, 6);

            var root1 = new TreeNode(-10);
            root1.Left =new TreeNode(9);
            root1.Right=new TreeNode(20);

            root1.Right.Left = new TreeNode(15);
            root1.Right.Right = new TreeNode(7);
            root1.Right.Right.Right = new TreeNode(3);

            r = MaximumPathSum.GetSum(root1);
            Assert.AreEqual(r, 45);

            ////////////////////////////////////
            //this test case is for senario, all node's value is negative, so max initial value should use int.min ,not 0
            var root2= new TreeNode(-20);
            root2.Left = new TreeNode(-10);
            root2.Right = new TreeNode(-15);

            root2.Left.Left = new TreeNode(-30);

            root2.Right.Left = new TreeNode(-5);
            root2.Right.Right = new TreeNode(-25);
            root2.Right.Right.Right = new TreeNode(-50);

            r = MaximumPathSum.GetSum(root2);
            Assert.AreEqual(r, -5);
        }
    }
}
