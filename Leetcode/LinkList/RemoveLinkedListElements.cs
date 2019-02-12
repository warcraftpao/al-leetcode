using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leetcode.DataStructure;

namespace Leetcode.LinkList
{
    public class RemoveLinkedListElements
    {
        public static MyLinkList Remove(MyLinkList head, int val)
        {
            var dummy = head;
            var curr = head.Next;
            var pre = head;
            while (curr != null)
            {
                if (curr.Val == val)
                {
                    pre.Next = curr.Next;
                    curr = curr.Next;
                }
                else
                {
                    pre = curr;
                    curr = curr.Next;
                }
            }

            return head;
        }
    }
}
