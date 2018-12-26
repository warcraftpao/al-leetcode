using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leetcode.DataStructure;

namespace Leetcode.LinkList
{
    public class PartitionList
    {
        //Given a linked list and a value X, partition it such that all nodes less than X come before nodes greater than or equal to X.
        // You should preserve the original relative order of the nodes in each of the two partitions.
        public static MyLinkList Do(MyLinkList head, int x)
        {
            //dummy 和head作为较小值新链表的头和结尾
            var dummy = head;
            var curr = head.Next;
            //bLink和 bLinkDummy作为较大值新链表的头
            var bLink = new MyLinkList();
            var bLinkDummy = bLink;
            while (curr != null)
            {
                if (curr.Val < x)
                {
                    head.Next = curr;
                    head = head.Next;
                }
                   
                else
                {
                    bLink.Next = curr;
                    bLink = bLink.Next;
                }
                curr = curr.Next;
            }
            //小链表的尾巴指向新链表的第一个值
            head.Next = bLinkDummy.Next;

            return dummy;
        }
    }
}
