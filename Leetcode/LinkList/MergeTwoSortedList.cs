using Leetcode.DataStructure;

namespace Leetcode.LinkList
{
    public class MergeTwoSortedList
    {
        //https://www.cnblogs.com/EdwardLiu/p/3718025.html
        //改进就是不new 新节点 新链表指向已有节点

        public static MyLinkList Merge(MyLinkList head1, MyLinkList head2)
        {
            if (head1.Next == null)
                return head2;

            if (head2.Next == null)
                return head1;

            var head3 = new MyLinkList();
            var dummy = head3;
            while (head1.Next != null  || head2.Next != null)
            {
                if (head1.Next != null && head2.Next != null)
                {
                    if (head1.Next.Val <= head2.Next.Val)
                    {
                        head3.Next = new MyLinkList() {Val = head1.Next.Val};
                        head3 = head3.Next;
                        head1 = head1.Next;
                    }
                    else
                    {
                        head3.Next = new MyLinkList() { Val = head2.Next.Val };
                        head3 = head3.Next;
                        head2 = head2.Next;
                    }
                }
                else if (head1.Next != null && head2.Next == null)
                {
                    head3.Next = new MyLinkList() {Val = head1.Next.Val};
                    head3 = head3.Next;
                    head1 = head1.Next;
                }
                else if (head1.Next == null && head2.Next != null)
                {
                    head3.Next = new MyLinkList() { Val = head2.Next.Val };
                    head3 = head3.Next;
                    head2 = head2.Next;
                }
                 
            }

            return dummy;

        }

        //两两比较，这个是跳间隔的
        //interval是每次比较的间隔数，interval*2是循环每次跳的间隔数
        //为啥结束条件是i + interval <  len（这样写容易理解），要保证 i+interval 不能溢出 
        public static MyLinkList MergeKSortedMyLinkList(MyLinkList[] arr)
        {
            var len = arr.Length;
            var interval = 1;
            while (interval < len)
            {
                for (var i = 0; i + interval <  len ; i += interval*2 )
                {
                    arr[i] = Merge(arr[i], arr[i + interval]);
                }
                interval *= 2;
            }

            return arr[0];
        }

    }
}
