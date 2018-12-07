using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;
using Leetcode.DataStructure;

namespace Leetcode.LinkList
{
    public class RecordList
    {
        //快慢指针，把链表拆成2个，然后翻转第二个链表
        //再各自从每个链表里取一个出来。本来是奇数个元素的话，慢指针链表少一个元素
        public static void Record(MyLinkList head)
        {
            var turtle = head;
            var rabbit = head;
           
            //乌龟走一步，兔子走两步，跳出循环的时候，slow之后的节点就是快指针链表
            while (rabbit.Next != null && rabbit.Next.Next != null)
            {
                turtle = turtle.Next;
                rabbit = rabbit.Next.Next;
            }

            //直接用rabbit和turtle作为2个指针的头，head能保留
            rabbit= new MyLinkList();
            rabbit.Next = turtle.Next;
            turtle.Next = null;
            turtle = head.Next;

            //翻转快指针
            ReverseLinkedList.Reserve(rabbit);
            rabbit = rabbit.Next;

            var curr = head;
            while (turtle != null)
            {
                //这是我自己的写法可以实现, 网上的看不懂
                var rabbitTmp = rabbit;
                rabbit = rabbit.Next;

                var turtleTmp = turtle.Next;
                turtle.Next = rabbitTmp;
                rabbitTmp.Next = turtleTmp;
                curr = rabbitTmp;
                turtle = turtleTmp;

            }

            if (rabbit != null)
                curr.Next = rabbit;
        }

    }
}
