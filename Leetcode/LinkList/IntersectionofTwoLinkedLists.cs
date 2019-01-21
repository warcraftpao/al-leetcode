using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leetcode.DataStructure;

namespace Leetcode.LinkList
{
    //这类题关键是要理解英文原意
    //就是说俩链表要么有交集，在交集发生后后面的元素都相同的，要么就干脆没有交集
    //abc 和 xyz 或者 abcdefg和xyzefg的意思，e就是最早的公共元素，之后的相同
    public class IntersectionofTwoLinkedLists
    {
        //假设他们有交集，他们交集的长度必相同的，所以len1和len2的差值是len的话，较长链表的长度-len后，长度肯定还是大于等于公共部分
        //所以让长的那个链表先多走len步后，每一步判定2个链表的值是否相同就行了
        public static MyLinkList GetIntersection1(MyLinkList node1, MyLinkList node2)
        {
            var len1 = node1.Length();
            var len2 = node2.Length();
            
            if(len1>  len2)
            {
                while (len1 > len2)
                {
                    node1 = node1.Next;
                    len1--;
                }
            }
            else if( len1 < len2)
            {
                while (len1 < len2)
                {
                    node2 = node2.Next;
                    len2--;
                }
            }

            while (node1 != null)
            {
                if (node1 == node2)
                    return node1;

                node1 = node1.Next;
                node2 = node2.Next;
            }

            return null;
        }
    }
}
