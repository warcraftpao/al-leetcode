using System;
using Leetcode.BinaryTree;
using Leetcode.DataStructure;
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

        [TestMethod]
        public void TestConstructBinaryTreeFromInorderAndPostorderTraversal()
        {
            var root = ConstructTree.ConstructBinaryTreeFromInorderAndPostorderTraversal(new[] { 9, 15, 7, 20, 3 },
                new[] { 9, 3, 15, 20, 7 });

            Assert.AreEqual(root.Val, 3);
            Assert.AreEqual(root.Right.Val, 20);
            Assert.AreEqual(root.Right.Left.Val, 15);
            Assert.AreEqual(root.Right.Right.Val, 7);
        }

        [TestMethod]
        public void TestConvertSortedArrayToBST()
        {
            var root = ConstructTree.ConvertSortedArrayToBST(new[] {-10, -3, 0, 5, 9});
            //因为可以有多个结果可能，所以只是调用了isvalid方法验证是否是bst 和root不为null
            var r = ValidateBinarySearchTree.IsValid(root);
            Assert.AreEqual(r, true);
            Assert.IsNotNull(root);
        }


        [TestMethod]
        public void TestConvertSortedListToBST()
        {
            var root = ConstructTree.ConvertSortedListToBST(MyLinkList.BuildListNodeFromArray(new []{ -10, -3, 0, 5, 9 }));
            //因为可以有多个结果可能，所以只是调用了isvalid方法验证是否是bst 和root不为null
            var r = ValidateBinarySearchTree.IsValid(root);
            Assert.AreEqual(r, true);
            Assert.IsNotNull(root);
        }
    }
}
