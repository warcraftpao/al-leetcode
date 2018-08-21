using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leetcode.DataStructure;

namespace Leetcode.BinaryTree
{
    public  class MaximumDepthofBinaryTree
    {
        public static int GetDepth(TreeNode root)
        {
            if (root == null)
                return 0;

            return Math.Max(GetDepth(root.Left), GetDepth(root.Right)) + 1;
        }

        //way2 层序遍历的时候加个计数器
    }
}
