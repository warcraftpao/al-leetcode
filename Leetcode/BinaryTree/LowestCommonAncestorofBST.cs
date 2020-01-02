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
    /// 假设 bst 值都不重复， pq值不同且存在
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


    /// <summary>
    /// 二叉 树的最近公共祖先   ( 不是搜索树了）
    /// 假设 bst 值都不重复， pq值不同且存在
    /// </summary>
    public class LowestCommonAncestorofBinaryTree 
    {
        public static TreeNode Search(TreeNode root, TreeNode p, TreeNode q)
        {
            //因为不是二叉搜索树！！！

            //root 是pq之一，直接返回
            if(root.Val== p.Val || root.Val== q.Val)
            return root;

            //root null 返回null 其实可以和上面合并，递归的时候会发生这个情况
            if (root== null)
                return null;

            //递归左右子树，一定会有这样几个情况，左右子树返回值都不为空（pq分别在左右子树）
            //右子树为空，说明pq都在右子树
            //左子树为空同上

            //比如在左子树递归找到了pq之一，为什么可以直接返回呢，因为pq中的另外一个要么在左子树最下面，要么就在右子树！
            var left = Search(root.Left, p, q);
            var right = Search(root.Right, p, q);

            if (left != null && right != null) return root;
            if(left== null) return right;
            if (right == null) return left;

            return null;
        }
    }
}
