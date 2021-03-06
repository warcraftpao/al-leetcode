﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.DataStructure
{
    public class MyLinkList
    {
        public int Val { get; set; }
        public MyLinkList Next;


        /// <summary>
        /// head默认不存值，只是一个指针
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static MyLinkList BuildListNodeFromArray(int[] arr)
        {
            var head = new MyLinkList();
            var current = head;
            foreach (var i in arr)
            {
                current.Next = new MyLinkList { Val = i };
                current = current.Next;
            }

            return head;
        }

        /// <summary>
        /// 计算链表长度，传进来的是head，不计算长度
        /// Next 不为空的时候才+1
        /// </summary>
        /// <returns></returns>
        public int Length()
        {
            int i = 0;
            var curr = Next;
            while (curr != null)
            {
                i++;
                curr = curr.Next;
            }
            return i;
        }
    }
}
