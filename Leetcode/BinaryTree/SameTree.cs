using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leetcode.DataStructure;

namespace Leetcode.BinaryTree
{
    public class SameTree
    {
        //按照解释，必须2个树完全一样才算same
        //也没说二叉树本身是否合法
        public static bool IsSame(TreeNode t1, TreeNode t2)
        {
            if (t1 == null && t2 == null)
                return true;

            if (t1 != null && t2 != null && t1.Val == t2.Val)
            {
                return IsSame(t1.Left, t2.Left) && IsSame(t1.Right, t2.Right);
            }

            return false;
        }

        //迭代循环版本
        public static bool IsSame_loop(TreeNode t1, TreeNode t2)
        {
            var stack1 = new Stack<TreeNode>();
            var stack2 = new Stack<TreeNode>();

            if(t1!= null) stack1.Push(t1);
            if(t2!= null) stack2.Push(t2);

            //2个stack都还有元素才继续 ，只有个一为空说明肯定有节点不同，都空可能循环正好结束
            //相同位置值不相等的或者缺一个节点的在while里判定
            while (stack1.Count > 0 && stack2.Count > 0)
            {
                //空不入栈，所以不用检查pop出的元素是否为null
                //总是可以pop一次，孩子节点下次循环再比较
                var n1 = stack1.Pop();
                var n2 = stack2.Pop();
                if ( n1.Val != n2.Val)
                    return false;

                if (n1.Left != null) stack1.Push(n1.Left);
                if (n2.Left != null) stack2.Push(n2.Left);
                if (stack1.Count != stack2.Count) return false;

                if (n1.Right != null) stack1.Push(n1.Right);
                if (n2.Right != null) stack2.Push(n2.Right);
                if (stack1.Count != stack2.Count) return false;
            }

            return stack1.Count == stack2.Count;
        }
    }
}
