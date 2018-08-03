using Leetcode.DataStructure;

namespace Leetcode.LinkList
{
    //给一个链表，把末尾元素指向头元素，算一次操作，求k次操作后的结果
    public  class RotateLinkedList
    {
        public static MyLinkList Rotate(MyLinkList head ,int k)
        {
            var len = head.Length();
            k = k% len;

            if (k == 0)//无需操作
                return head;

            //末尾k次，正向就是len-k个的下个元素
            var ahead = len - k + 1;
            var curr = head;
            var mid = head;
           for(var i= 1; i <=len; i++)
            {
                curr = curr.Next;
                if (i == ahead)
                {
                    mid = curr;
                }
            }
            //此时  curr 是 end元素，mid 是翻转后的第一个元素
            var first = head.Next;
            head.Next = mid;
            curr.Next = first;
            return head;
        }
    }
}
