using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leetcode.DataStructure;

namespace Leetcode.BinaryTree
{
    /// <summary>
    ///Assume a BST is defined as follows:
    ///The left subtree of a node contains only nodes with keys less than the node's key.
    ///The right subtree of a node contains only nodes with keys greater than the node's key.
    ///Both the left and right subtrees must also be binary search trees.
    ///less than great than 没有equal
    /// </summary>
    public  class ValidateBinarySearchTree
    {
        //必须考虑一个特殊情况，即局部二叉树符合要求，但是整体不符合，跨层后不符合情况
        public static bool IsValid(TreeNode root)
        {
            if (root == null)
                return true;

            return Helper(root, int.MinValue, int.MaxValue);

        }

        private static bool Helper(TreeNode root, int nodeMinVal, int nodeMaxVal)
        {
            if (root == null)
                return true;
            if (root.Val <= nodeMinVal || root.Val >= nodeMaxVal)
                return false;
                    //左子树最小永远是intmin，最大值在缩小   右子树最大永远是intmax, 最小值在变大
            return Helper(root.Left, nodeMinVal, root.Val) && Helper(root.Right, root.Val, nodeMaxVal);
        }

        //this is a wrong version
        //必须考虑一个特殊情况，即局部二叉树符合要求，但是整体不符合，跨层后不符合情况
        //public static bool IsValid(TreeNode root)
        //{
        //    if (root == null)
        //        return true;

        //    //左娃是null 或者 左娃值合法且递归左娃合法
        //    //&& 右娃同理
        //    return (root.Left == null || (root.Left.Val < root.Val && IsValid(root.Left)))
        //           && (root.Right == null || (root.Right.Val > root.Val && IsValid(root.Right)));

        //}
    }
}
