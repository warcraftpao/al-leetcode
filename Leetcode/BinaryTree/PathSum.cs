using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leetcode.DataStructure;

namespace Leetcode.BinaryTree
{
    public class PathSum
    {
        public static bool HasPathSum(TreeNode root, int sum)
        {
            if (root == null) return false;
            var left = sum - root.Val;
            if (root.Left == null && root.Right == null && left == 0)
                return true;
            return HasPathSum(root.Left, left) || HasPathSum(root.Right, left);
        }

         
    }
}
