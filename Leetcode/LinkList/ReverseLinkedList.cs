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

            while (curr.Next != null)
            {
                var tmp = curr.Next;  // 当前节点下一节点
                curr.Next = tmp.Next; //当前节点指向下下个节点
                tmp.Next = head.Next;//当前节点指向头
                head.Next = tmp;//dummy指向头
                //此时current的next被搬到了最开始，等于current向后移动了
                //所以检查current.next是否为null就行了
            }
            return head;
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
            head.Next = null; //5和4翻转，5指向4，4指向null；这时候返回上层递归时，返回了5，head是3，3还指向了4，再4和3翻转
            return node;//return的总是是node，所以最后一个元素总是头节点了
        }

        //Reverse a linked list from position m to n. Do it in one-pass.
        //Note: 1 ≤ m ≤ n ≤ length of list.
        public static MyLinkList ReserverInMtoN(MyLinkList head, int m, int n)
        {
            if (head.Next == null || head.Next.Next == null)
                return head;

            var count = 1;
            var curr = head.Next;
            while (count <  m -1 )//前进到要翻转的节点之前，要从第四个节点开始翻转，前进到3就行了，起始是1，所以只要走2步
            {
                count++;
                curr = curr.Next;
            }
            //curr下一个元素就是要开始倒置的节点
            var tmphead = curr;
            curr = curr.Next;
            while (count < n -1)//前进到最后一个要翻转的节点之前就行了，他之前那个节点的操作会把它转到最前面去
            {
                var tmp = curr.Next;
                curr.Next = tmp.Next;
                tmp.Next = tmphead.Next;
                tmphead.Next = tmp;
                count++;
            }

            return head;
        }
    }
}
