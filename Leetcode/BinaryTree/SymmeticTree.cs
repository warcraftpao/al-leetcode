using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Leetcode.DataStructure;

namespace Leetcode.BinaryTree
{
    public class SymmeticTree
    {
        public static bool IsSymmetic_recursive(TreeNode root)
        {
            return Helper_recursive(root,root);
        }

        private static bool Helper_recursive(TreeNode left, TreeNode right)
        {
            if (left  == null && right == null)
                return true;
            if (right == null || left == null)
                return false;

            if (left.Val != right.Val)
                return false;

            return Helper_recursive(left.Left, right.Right) && Helper_recursive(left.Right, right.Left);
        }

        public static bool IsSymmetic_loop(TreeNode root)
        {
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                var left = queue.Dequeue();
                var right = queue.Dequeue();
                if(left == null && right == null)
                    continue;

                if (left == null || right == null)
                    return false;
                if (left.Val != right.Val)
                    return false;

                //顺序不能颠倒，对称的入队
                queue.Enqueue(left.Left);
                queue.Enqueue(right.Right);

                queue.Enqueue(left.Right);
                queue.Enqueue(right.Left);
            }

            return true;
        }
    }
}
