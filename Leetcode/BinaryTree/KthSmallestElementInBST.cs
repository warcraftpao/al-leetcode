using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leetcode.DataStructure;

namespace Leetcode.BinaryTree
{
    /// <summary>
    /// 二叉搜索树中
    /// </summary>
    public class KthSmallestElementInBST
    {
        //中序遍历，就左中右，从最小的开始遍历
          
        public static int Find(TreeNode root, int k)
        {
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
                    k--;
                    if (k == 0)
                        return t.Val;
                    node = t.Right;
                }
            }

            //按照题目要求这不可能跑到，这是必须有返回值
            return 0;
        }
    }
}
