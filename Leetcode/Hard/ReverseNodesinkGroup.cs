using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leetcode.DataStructure;

namespace Leetcode.Hard
{
   
    public class ReverseNodesinkGroup
    {
        //每次尝试前进k个，如果能有k个元素，说明需要反转一次，
        //那么只要知道这k个元素的第一个元素之前的head和，最后一个元素指向的tail就能翻转其中那一节
        public static LinkedList Reserve(LinkedList head, int k)
        {
            if (k < 2)//k=1不用翻转
            {
                return head;
            }

            int i = 0;
            var dummyHead = head;

            var loopHead = head;
            while (head.Next != null)
            {
                head = head.Next;
                i++;
                 
                if (i == k)
                {
                    //自己的思路，这里head不停往后移动，但是链表局部被翻转了，head.next跑最前面去了
                    //所以我知道当前loophead的next在翻转后肯定在tail之前，所以他就就是下一次looptail，循环指针也指向他
                    var nextloophead = loopHead.Next;
                    ReserveList(loopHead, head.Next);
                    i = 0;
                    head = nextloophead;
                    loopHead = nextloophead;
                }
                
            }

            return dummyHead;
        }

        /// <summary>
        /// </summary>
        /// <param name="head"></param>
        /// <param name="tail"></param>
        private static void ReserveList(LinkedList head, LinkedList tail)
        {
      
            var curr = head.Next;
            while (curr.Next != tail)
            {
                var tmp = curr.Next; 
                curr.Next = tmp.Next;
                tmp.Next = head.Next;
                head.Next = tmp;
            }
        }
    }
}
