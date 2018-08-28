using System.Collections.Generic;
using Leetcode.DataStructure;

namespace Leetcode.TreeLinkNodeRelated
{
    //把TreeLinkNode的每个节点Next指向图形结构里的右边的节点，没有右边就指向null
    //题目说可以假设是完美二叉树
    public  class PopulatingNextToRight
    {
        public static void Connect_loop(TreeLinkNode root)
        {
            if (root == null) return;
            var queue = new Queue<TreeLinkNode>();
            queue.Enqueue(root);
            root.Next = null;
            while (queue.Count > 0)
            {
                var size = queue.Count;
                var list= new List<TreeLinkNode>();
                for (var i = 1; i <= size; i++)
                {
                    var node = queue.Dequeue();
                    list.Add(node);
                    if(node.Left != null)  queue.Enqueue(node.Left);
                    if (node.Right != null) queue.Enqueue(node.Right);
                }
                for (var i = 0; i < size; i++)
                {
                    if (i < size - 1)
                        list[i].Next = list[i + 1];
                    else
                        list[i].Next =  null;
                }
            }
        }

        //left指向right很简单；right需要指向爸爸的next的left
        //必须自己画个图，画一下递归流程，再计算某个节点的right的时候，在上层递归中，这个节点的next肯定已经被计算过了
        public static void Connect_recursive(TreeLinkNode root)
        {
            if (root == null) return;
            if (root.Left != null)
                root.Left.Next = root.Right;
            if (root.Right != null)
                root.Right.Next = root.Next == null ? null : root.Next.Left;

            Connect_recursive(root.Left);
            Connect_recursive(root.Right);
        }
    }
}
