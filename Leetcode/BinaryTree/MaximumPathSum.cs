using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leetcode.DataStructure;
using Leetcode.Matrix;

namespace Leetcode.BinaryTree
{
    //Given a non-empty binary tree, find the maximum path sum.
    // For this problem, a path is defined as any sequence of nodes from some starting node to any node in the tree along the parent-child connections.
    //The path must contain at least one node and does not need to go through the root.
    public class MaximumPathSum
    {
        //任何路径，总有一个最高层的节点（因为从某个节点出发，可以往上走，也可以往下走，但是一旦往下走了后就不能再往上走了；所以总能找到一个路径的最高层节点）
        //既然有了最高层节点，那题目就变为求每个节点的左子树路径最大值和右孩子路径最大值
        //任意子树maxPathSum 为负数就算路径值是0（不纳入路径），每层都统计max值，逐层返回
        public static int GetSum(TreeNode root)
        {
            var max = int.MinValue;//这里不能用0，因为节点本身可以是负数，而且最后必须包括一个节点的，是0，节点都是负数的case过不了
            Helper(root, ref max);
            return max;
        }

        //又是看了答案才理解的记录一下方法
        public static int Helper(TreeNode root, ref int max)
        {
            if (root == null) return 0;
            var leftMax = Helper(root.Left, ref max) ;
            var rightMax = Helper(root.Right, ref max);
            leftMax = Math.Max(leftMax, 0);//如果是负数就不如不要这条路径，right相同
            rightMax = Math.Max(rightMax, 0);
            max = Math.Max(max, root.Val + leftMax + rightMax);//这里比较当前节点为最高层节点的路径值和max，更新max值
            return root.Val + Math.Max(leftMax, rightMax);
            //为啥是+ max(left, right)？ 因为对于以当前节点的为最高层节点的路径已经计算过了，这个计算的时候需要同时考虑left 和right
            //但是当前节点作为路径非最高层节点的时候，其左右子树不可能同时存在于高层节点的路径内  最多只能选一条路
        }
    }
}
