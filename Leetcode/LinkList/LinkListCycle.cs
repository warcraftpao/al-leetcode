using Leetcode.DataStructure;

namespace Leetcode.LinkList
{
    public  class LinkListCycle
    {
        public static bool IsCycle(MyLinkList head)
        {
            var rabbit = head.Next;
            var turtle = head.Next;

            //如果没有回路，rabbit总是先到终点，所以rabbit变成null或者next是null，没有回路
            while (rabbit != null && rabbit.Next != null)
            {
                turtle = turtle.Next;
                //如果有回路（不管是大回环，还是6字形，rabbit和turtle早晚都会跑进回路，那么rabbit总会追上trutle
                rabbit = rabbit.Next.Next;
                if (rabbit == turtle)
                    return true;
            }

            return false;
        }
    }


    public class LinkListCycle2
    {
        
    }
}
