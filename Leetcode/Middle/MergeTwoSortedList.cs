using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leetcode.DataStructure;

namespace Leetcode.Middle
{
    public class MergeTwoSortedList
    {
        //https://www.cnblogs.com/EdwardLiu/p/3718025.html
        //改进就是不new 新节点 新链表指向已有节点

        public static LinkedList Merge(LinkedList head1, LinkedList head2)
        {
            var head3 = new LinkedList();
            var dummy = head3;
            while (head1.Next != null  || head2.Next != null)
            {
                if (head1.Next != null && head2.Next != null)
                {
                    if (head1.Next.Val <= head2.Next.Val)
                    {
                        head3.Next = new LinkedList() {Val = head1.Next.Val};
                        head3 = head3.Next;
                        head1 = head1.Next;
                    }
                    else
                    {
                        head3.Next = new LinkedList() { Val = head2.Next.Val };
                        head3 = head3.Next;
                        head2 = head2.Next;
                    }
                }
                else if (head1.Next != null && head2.Next == null)
                {
                    head3.Next = new LinkedList() {Val = head1.Next.Val};
                    head3 = head3.Next;
                    head1 = head1.Next;
                }
                else if (head1.Next == null && head2.Next != null)
                {
                    head3.Next = new LinkedList() { Val = head2.Next.Val };
                    head3 = head3.Next;
                    head2 = head2.Next;
                }
                 
            }

            return dummy;
        }
    }
}
