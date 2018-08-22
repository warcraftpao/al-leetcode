using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Leetcode.DataStructure;

namespace Leetcode.BinaryTree
{
    public class MinimumDepth
    {
        //和求最大深度有区别，求最大深度的时候，max(left，right) +1就可以了，因为递归求的就是子树的深度，有一边子树不存在就是0，肯定会小于另外一边被淘汰
        //这里要最小深度，是有区别的： 如果子树完整可以仿照求最大深度的方式来做
        public static int GetDepth(TreeNode root)
        {
            if (root == null)
                return 0;

            //注意定义，如果缺少左子树或者右子树，缺少的子树的一边当然可以理解为深度是0:  但是不存在的节点根本不是一条path, 不应该进入比较阶段！
            //这是与求最大深度思路的区别
            if (root.Left == null) return GetDepth(root.Right) + 1;
            if (root.Right == null) return GetDepth(root.Left) + 1;

            return Math.Min(GetDepth(root.Left), GetDepth(root.Right)) + 1 ;
        }
    }
}
