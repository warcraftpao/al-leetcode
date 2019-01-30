using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization.Configuration;
using Leetcode.DataStructure;

namespace Leetcode.BinaryTree
{
    //way1 bst先序遍历 左中右全部入栈，next就不停出栈

    //way2 节省空间的做法，因为bst必然是左小于右，所以可以不停入栈left，此时入栈顶必然是最小的
    //next方法先出栈栈顶元素，然后再判断栈顶元素是否有right，如果有right必然是现在栈顶元素的右孩子，right入栈，再不停入栈right的left孩子


    public class BinarySearchTreeIterator
    {
        private Stack<TreeNode>  _stack = new Stack<TreeNode>();
        public BinarySearchTreeIterator(TreeNode root)
        {
            while (root != null)
            {
                _stack.Push(root);
                root = root.Left;
            }
        }
        public bool HasNext()
        {
            return _stack.Any();
        }

        public int Next()
        {
            var node = _stack.Pop();
            var tmp = node.Right;
             
            while (tmp != null)
            {
                _stack.Push(tmp);
                tmp = tmp.Left;
            }

            return node.Val;
        }
    }
}
