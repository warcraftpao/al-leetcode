using System.Collections.Generic;
using Leetcode.DataStructure;

namespace Leetcode.TreeLinkNodeRelated
{
    //把TreeLinkNode的每个节点Next指向图形结构里的右边的节点，没有右边就指向null
    //题目说可以假设是完美二叉树
    public  class PopulatingNextToRight
    {
        public static void Connect_perfact_loop(TreeLinkNode root)
        {
            if (root == null) return;
            var queue = new Queue<TreeLinkNode>();
            queue.Enqueue(root);
            root.Next = null;
            while (queue.Count > 0)
            {
                var size = queue.Count;
               // var list= new List<TreeLinkNode>();

                for (var i = 1; i <= size; i++)
                {
                    var node = queue.Peek();
                    queue.Dequeue();
                    if (i <= size - 1)
                        node.Next = queue.Peek();

                    if (node.Left != null) queue.Enqueue(node.Left);
                    if (node.Right != null) queue.Enqueue(node.Right);
                }

                //for (var i = 1; i <= size; i++)
                //{
                //    var node = queue.Dequeue();
                //    list.Add(node);
                //    if(node.Left != null)  queue.Enqueue(node.Left);
                //    if (node.Right != null) queue.Enqueue(node.Right);
                //}
                //for (var i = 0; i < size; i++)
                //{
                //    if (i < size - 1)
                //        list[i].Next = list[i + 1];
                //    else
                //        list[i].Next =  null;
                //}
            }
        }

        //left指向right很简单；right需要指向爸爸的next的left
        //必须自己画个图，画一下递归流程，再计算某个节点的right的时候，在上层递归中，这个节点的next肯定已经被计算过了
        public static void Connect_perfact_recursive(TreeLinkNode root)
        {
            if (root == null) return;
            if (root.Left != null)
                root.Left.Next = root.Right;
            if (root.Right != null)
                root.Right.Next = root.Next == null ? null : root.Next.Left;

            Connect_perfact_recursive(root.Left);
            Connect_perfact_recursive(root.Right);
        }

        //  另外一种解法 ，自己是想不出来的，看看就行了 https://www.cnblogs.com/grandyang/p/4288151.html
        //其实只有这个符合提议，空间使用是常量


        #region 非完美二叉树的情况
        
        //loop方法不需要改任何代码的, 因为是按层扫描，缺子节点没关系，
        public static void Connect_notperfact_loop(TreeLinkNode root)
        {
            Connect_perfact_loop(root);
        }

        //递归扫描思路差不多，就是当某个节点的next是null了，说明这一层到底了，首先root肯定符合这个规定
        //扫描思路就是不停去找当前节点的next，记住这个节点后，给left和right的next赋值，然后进入下层递归
        public static void Connect_notperfact_recursive(TreeLinkNode root)
        {
            if (root == null) return;
            //找root节点的next
            var nextNode = root.Next;
            //如果这个时候nextNode是null，说明root的子节点也指向null
            //但是如果nodeNext不是null，还得继续看他的子节点，有任意子节点就退出循环，如果没子节点，还得平行继续扫描nextNode的Next
            //意思就是要么next为空，要么找到某个next的子树
            while (nextNode != null)
            {
                if (nextNode.Left != null)
                {
                    nextNode = nextNode.Left;
                    break;
                }
                if (nextNode.Right != null)
                {
                    nextNode = nextNode.Right;
                    break;
                }
                nextNode = nextNode.Next;
            }
            //必须先处理右节点
            if (root.Right != null)
                root.Right.Next = nextNode  ;
            if (root.Left != null)
                root.Left.Next = root.Right ?? nextNode;

            Connect_notperfact_recursive(root.Left);
            Connect_notperfact_recursive(root.Right);
        }
        

        //还有个简洁的常量空间的看不懂~~
        #endregion

    }
}
