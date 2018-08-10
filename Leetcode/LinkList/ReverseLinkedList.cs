using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leetcode.DataStructure;

namespace Leetcode.LinkList
{
    public  class ReverseLinkedList
    {
        public static MyLinkList Reserve(MyLinkList head)
        {
            //没有节点或者只有1个节点，直接return
            if (head.Next == null || head.Next.Next == null)
            {
                return head;
            }

            var curr = head.Next;
            var dummy = head;

            while (curr.Next != null)
            {
                var tmp = curr.Next;  // 当前节点下一节点
                curr.Next = tmp.Next; //当前节点指向下下个节点
                tmp.Next = dummy.Next;//当前节点指向头
                dummy.Next = tmp;//dummy指向头
                //此时current的next被搬到了最开始，等于current向后移动了
                //所以检查current.next是否为null就行了
            }
            return dummy;
        }

        public static MyLinkList Reserve_Recursive(MyLinkList head)
        {
            var newHead = Reserve_Recursive_helper(head.Next);
            head.Next = newHead;//这里只是因为我自己的定义的head总是dummyhead
            return head;
        }

        private static MyLinkList Reserve_Recursive_helper(MyLinkList head)
        {
            //到最后一个节点了，返回该节点
            if (head.Next == null)
                return head;

            //进入递归
            var node = Reserve_Recursive_helper(head.Next);
            head.Next.Next = head; //这样写就是 自己的下个节点指向了自己，自己指向null，和直接写node.next =head 还是不同的
            head.Next = null; 
            return node;//return的总是是node，所以最后一个元素总是头节点了
        }


    }
}
