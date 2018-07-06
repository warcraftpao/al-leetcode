using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Leetcode.DataStructure;

namespace Leetcode.Middle
{
    public class SwapNodeInPair
    {
        //这道有难度吗？
        public static void Swap(LinkedList head)
        {
            if (head.Next == null)
            {
                return;
            }
         
            var curr = head;
            //假设当前指针后是123 go
            while (curr.Next != null && curr.Next.Next != null)
            {
                var tmp2 = curr.Next.Next;
                var tmp1 = curr.Next;
                //2后面存在3
                if (curr.Next.Next.Next != null)
                {
                    //1指向 3，现在12都指向3
                    tmp1.Next = curr.Next.Next.Next;
                }
                else
                {
                    tmp1.Next = null;
                }
                //头指向2
                curr.Next = tmp2;
                //2指向1
                tmp2.Next = tmp1;
                
                curr = curr.Next.Next;
            }
        }
    }
}
