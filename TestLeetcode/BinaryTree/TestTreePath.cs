using System;
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
    }
}
