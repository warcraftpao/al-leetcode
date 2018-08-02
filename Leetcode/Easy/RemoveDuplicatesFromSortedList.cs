using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leetcode.DataStructure;

namespace Leetcode.Easy
{
    public class RemoveDuplicatesFromSortedList
    {
        public static LinkedList KeepOnly1(LinkedList head)
        {
            if (head.Next == null || head.Next.Next == null)
                return head;

            //从第二个值开始往前比较
            var curr = head.Next.Next;
            var pre = head.Next;
            while (curr != null)
            {
                if (curr.Val == pre.Val)
                {
                    pre.Next = curr.Next;
                }
                else
                {
                    pre = curr;
                }
                curr = curr.Next;
            }
            return head;
        }

        public static LinkedList RemoveAllIfDuplicated(LinkedList head)
        {
            if (head.Next == null || head.Next.Next == null)
                return head;

            var curr = head.Next.Next;
            var pre = head.Next;
            var value = head.Next.Val;
            var exist = head; //上一个没被删除的节点
            while (curr != null)
            {
                if (curr.Val == value) // 值重 jump
                {
                    exist.Next = curr.Next;
                }
                else//不重复
                {
                    value = curr.Val;
                    exist = pre;
                }
                pre = curr;
                curr = curr.Next;
            }
            return head;
        }
    }
}
