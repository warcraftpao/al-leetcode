using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leetcode.DataStructure;

namespace Leetcode.BinaryTree
{
    //左 根节点 右
    public class BinaryTreeTravle
    {
        //https://www.cnblogs.com/grandyang/p/4297300.html
        #region inorder
        public static List<int> InorderTraversal_Recursive(TreeNode root)
        {
            var list = new List<int>();
            InorderTraversal_Helper_Recursive(list, root);
            return list;
        }

        private static void InorderTraversal_Helper_Recursive(List<int> results, TreeNode root)
        {
            //节点为空return
            if (root == null) return;
            if(root.Left != null) //不停找左孩子
                InorderTraversal_Helper_Recursive(results, root.Left);
            //没左孩子了，加入结果集
            results.Add(root.Val);

            //最后找右孩子
            if(root.Right!= null)
                InorderTraversal_Helper_Recursive(results, root.Right);

        }


        public static List<int> InorderTraversal_Stack(TreeNode root)
        {
            var list = new List<int>();
            var stack = new Stack<TreeNode>();
            var node = root;
            while (node != null || stack.Count > 0)
            {
                //持续左孩子入栈
                if (node != null)
                {
                   stack.Push(node);
                   node = node.Left;
                }
                else
                {
                    //左孩子为空，出栈
                    var t = stack.Pop();
                    list .Add(t.Val);
                    node = t.Right;
                }
            }
            return list;
        }

        #endregion
    }
}
