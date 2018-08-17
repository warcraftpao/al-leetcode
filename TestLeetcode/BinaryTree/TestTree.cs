using System;
using Leetcode.BinaryTree;
using Leetcode.DataStructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLeetcode.BinaryTree
{
    [TestClass]
    public class TestTree
    {
        [TestMethod]
        public void TestSameTree()
        {
            var t1 = Build1();
            var t2 = Build1();
            var r = SameTree.IsSame(t1, t2);
            Assert.AreEqual(r, true);


            t1 = Build2();
            t2 = Build3();
            r = SameTree.IsSame(t1, t2);
            Assert.AreEqual(r, false);
        }


        [TestMethod]
        public void TestSameTree_loop()
        {
            var t1 = Build1();
            var t2 = Build1();
            var r = SameTree.IsSame_loop(t1, t2);
            Assert.AreEqual(r, true);


            t1 = Build2();
            t2 = Build3();
            r = SameTree.IsSame_loop(t1, t2);
            Assert.AreEqual(r, false);

            t1 = Build3();
            t2 = Build4();
            r = SameTree.IsSame_loop(t1, t2);
            Assert.AreEqual(r, false);
        }


        #region 建立一些树，不一定是合法的二叉搜索树，所以只能手工建立
        private TreeNode Build1()
        {
            var root = new TreeNode(1);
            root.Left = new TreeNode(2);
            root.Right = new TreeNode(2);
            return root;
        }

        private TreeNode Build2()
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


        //3和2 有一个值不同
        private TreeNode Build3()
        {
            var root = new TreeNode(10);
            root.Left = new TreeNode(4);
            root.Right = new TreeNode(15);

            var parent = root.Left;
            parent.Left = new TreeNode(2);
            parent.Right = new TreeNode(5);

            parent = root.Right;
            parent.Left = new TreeNode(17);
            parent.Right = new TreeNode(6);


            return root;
        }

        //4和3比少一个节点
        private TreeNode Build4()
        {
            var root = new TreeNode(10);
            root.Left = new TreeNode(4);
            root.Right = new TreeNode(15);

            var parent = root.Left;
            parent.Left = new TreeNode(2);
            parent.Right = new TreeNode(5);

            parent = root.Right;
            parent.Left = new TreeNode(17);

            return root;
        }


        private TreeNode Build5()
        {
            var root = new TreeNode(3);
            root.Left = new TreeNode(1);
            root.Right = new TreeNode(4);

            root.Right.Left = new TreeNode(2);
            return root;
        }

        private TreeNode Build6()
        {
            var root = new TreeNode(3);
            root.Left = new TreeNode(1);
            root.Right = new TreeNode(5);

            root.Left.Right = new TreeNode(2);
            root.Right.Left= new TreeNode(4);
            root.Right.Right = new TreeNode(6);
            return root;
        }
        #endregion

        [TestMethod]
        public void TestRecoverTree()
        {
            var root = Build5();
            RecoverTree.Recover(root);
            Assert.AreEqual(root.Val, 2);

            root = Build6();
            RecoverTree.Recover(root);
            Assert.AreEqual(root.Val, 3);
            Assert.AreEqual(root.Right.Left.Val, 4);
        }
    }
}
