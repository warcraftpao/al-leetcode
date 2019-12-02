using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leetcode.DataStructure;

namespace Leetcode.BinaryTree
{
    /// <summary>
    /// 二叉搜索树的最近公共祖先
    /// 假设 bst 值都不重复，且p q存在
    /// </summary>
    public class LowestCommonAncestorofBST
    {
        public static TreeNode Search(TreeNode root, TreeNode p, TreeNode q)
        {
             //两个都在左边
            if (p.Val < root.Val && q.Val < root.Val)
            {
                return Search(root.Left, p, q);
            }
            //两个都在右边
            else if (p.Val > root.Val && q.Val > root.Val)
            {
                return Search(root.Right, p, q);
            }
            else  //跑到这里说明两个分别在root两边，或者有一个等于root，那这时候root就是解

            {
                return root;
            }
        }
    }
}
