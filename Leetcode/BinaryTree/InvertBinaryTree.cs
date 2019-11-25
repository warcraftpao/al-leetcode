using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leetcode.DataStructure;

namespace Leetcode.BinaryTree
{
    //左右翻转
    public class InvertBinaryTree
    {
        public static TreeNode Invent(TreeNode root)
        {
            if (root == null)
                return null;

            var temp = root.Left;
            root.Left = root.Right;
            root.Right = temp;

            Invent(root.Left);
            Invent(root.Right);

            return root;
        }
    }
}
