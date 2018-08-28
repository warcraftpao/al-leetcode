using System;
using Leetcode.DataStructure;
using Leetcode.TreeLinkNodeRelated;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLeetcode.TreeLinkNodeRelated
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestConnect_loop()
        {
            var root = Build();
             
            PopulatingNextToRight.Connect_loop(root);

            Assert.IsNull(root.Right.Next);
            Assert.AreEqual(root.Left.Next.Val,3);
            Assert.AreEqual(root.Left.Right.Next.Val, 6);
            Assert.IsNull(root.Right.Right.Next);
        }

        [TestMethod]
        public void TestConnect_recursive()
        {
            var root = Build();

            PopulatingNextToRight.Connect_recursive(root);

            Assert.IsNull(root.Right.Next);
            Assert.AreEqual(root.Left.Next.Val, 3);
            Assert.AreEqual(root.Left.Right.Next.Val, 6);
            Assert.IsNull(root.Right.Right.Next);
        }

        private TreeLinkNode Build()
        {
            var root = new TreeLinkNode(1);
            root.Left = new TreeLinkNode(2);
            root.Right = new TreeLinkNode(3);

            root.Left.Left = new TreeLinkNode(4);
            root.Left.Right = new TreeLinkNode(5);

            root.Right.Left = new TreeLinkNode(6);
            root.Right.Right = new TreeLinkNode(7);
            return root;
        }
    }
}
