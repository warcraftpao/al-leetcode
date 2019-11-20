using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leetcode.DataStructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLeetcode.BinaryTree
{
    [TestClass]
    public class TestBasic
    {
        [TestMethod]
        public void TestBuildRandomPerfectTree()
        {
            var root = TreeNode.BuildPerfectTree(4);
            Assert.IsNotNull(root.Right.Right.Right);
            Assert.IsNotNull(root.Left.Left.Left);
        }

        [TestMethod]
        public void TestBuildRandomCompeleteTree()
        {
            var root = TreeNode.BuildRandomCompeleteTree(4,3);
            Assert.IsNotNull(root.Right.Right);
            Assert.IsNotNull(root.Left.Left);

            Assert.IsNotNull(root.Left.Right.Left);
            Assert.IsNull(root.Left.Right.Right);
        }
    }
}
