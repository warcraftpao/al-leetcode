using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leetcode.DataStructure;

namespace Leetcode.LinkList
{
    public class PalindromeLinkedList
    {

        public static bool Check(MyLinkList head)
        {
            //快慢指针 慢指针会指向链表的中间  反转一半链表（理论上反转前后都可以吧）
            //一开始有个点没想明白，长度奇数怎么处理
            //不管是奇数还是偶数 慢针总是到len/2低的地方（长度是7还是6总是到3），然后从slow前进一个开始反转
            //如果是计数，比较 123 765 4不用比较 如果是奇数比较123 654
            if (head.Next == null || head.Next.Next == null)
                return true;

            var slow = head.Next;
            var fast = head.Next;
            while (fast.Next != null && fast.Next.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }

            //不管7个还是6个元素，这里都是第3个，总是从slow的Next开始翻转
            var mid = slow;//当head处理
            //翻转
            var curr = slow.Next;
            while (curr.Next != null)
            {
                var tmp = curr.Next;
                curr.Next = tmp.Next;
                tmp.Next = mid.Next;
                mid.Next = tmp;
            }

           //此时从head.next 和 slow.next开始比较
            var one = head.Next;
            var two = slow.Next;
            while (two != null)// 用tow.next当前元素就不判断了
            {
                if (one.Val != two.Val) return false;

                one = one.Next;
                two = two.Next;
            }

            return true;
        }
    }
}

