using System;
using Leetcode.BinaryTree;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLeetcode.BinaryTree
{
    [TestClass]
    public class TestBinaryTreeConstructor
    {
        [TestMethod]
        public void TestConstructBinaryTreeFromPreorderAndInorderTraversal()
        {
            var  root = ConstructTree.ConstructBinaryTreeFromPreorderAndInorderTraversal(new[] {3, 9, 20, 15, 7},
                new[] {9, 3, 15, 20, 7});

            Assert.AreEqual(root.Val, 3);
            Assert.AreEqual(root.Right.Val, 20);
            Assert.AreEqual(root.Right.Left.Val, 15);
            Assert.AreEqual(root.Right.Right.Val, 7);
        }
    }
}
