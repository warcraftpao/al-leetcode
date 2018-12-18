using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leetcode.DataStructure;

namespace Leetcode.LinkList
{
    public  class InsertionSortList
    {
        public static MyLinkList Sort(MyLinkList head)
        {
            //一个新链表的头
            var dummy = new MyLinkList {Val = -1};
            //当前链表循环的头
            var  curr =head.Next;

            while (curr != null)
            {
                //每次都从新链表的头开始循环，每次开始的时候新链表都是排序的（第一次只有一个元素的时候不用排序）
                //新链表循环的标志
                var pre = dummy;
                //新链表都是排序过的，而且每个值都需要比较，停留的位置，就是curr需要在之后插入的位置
                while (pre.Next != null && pre.Next.Val < curr.Val)
                {
                    pre = pre.Next;
                }
                 
                var tmp = curr.Next;
                // 把curr插到pre之后，所以其实这时候有两个链表了，老链表curr在后移，新链表在增加，而且不用考虑是不是插入在最后或者中间
                curr.Next = pre.Next;
                pre.Next = curr;
                 
                curr = tmp;
            }

            return dummy;
        }
    }
}
