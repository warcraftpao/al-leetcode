using Leetcode.DataStructure;

namespace Leetcode.LinkList
{
    public class RemoveNthFromEnd
    {
        //双指针
        //链表长度L，要得到倒数第N个节点，就是正数第L-N个
        //第一个指针指向head，第二个指向第N个节点，同时向前移动，直到第二个指针到底
        //第二个指针正好移动了L-N个，那么第一个元素正好就是倒数N个，因为他们的间隔总是Length-N
        //注意，我自己的写的head只是指针，so指针要多走1步才能到null 
        //先走n+1步的原因，两个指针间隔了n个元素，所以先走的指正指向了null的时候，第一个指针指向了倒数第n个元素的爸爸
        public static MyLinkList S1(MyLinkList head, int n)
        {
            var first = head;
            var second = head;
            var i = 0;
            while (second != null)
            {
                if (i >= n + 1)
                {
                    first = first.Next;
                }
                second = second.Next;
                i++;
            }

            first.Next = first.Next.Next;

            return head;
        }
    }
}
