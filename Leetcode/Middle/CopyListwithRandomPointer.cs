using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leetcode.DataStructure;

namespace Leetcode.Middle
{
    public class CopyListwithRandomPointer
    {
        public static RandomListNode Clone(RandomListNode head)
        {
            if (head == null) return null;
            var dic = new Dictionary<RandomListNode, RandomListNode>();

            var oldNode = head;
            var newNode = new RandomListNode(head.Val);
            dic.Add(oldNode,newNode);

            //每次oldnode 都被赋值成oldnode.next，总会到null的
            while (oldNode != null)
            {
                newNode.Random = Get(oldNode.Random, dic);
                newNode.Next= Get(oldNode.Next, dic);

                //两个指针都往下跑
                oldNode = oldNode.Next;
                newNode = newNode.Next;
            }
            return dic[head];
        }  

        //老链表中的每个节点，用自身做key，对应一个克隆节点

        private static RandomListNode Get(RandomListNode key, Dictionary<RandomListNode, RandomListNode> dic)
        {
            if (key == null)
                return null;

            if (dic.ContainsKey(key))
                return dic[key];
             
            var newNode = new RandomListNode(key.Val);
            dic[key] = newNode;
            return newNode;
             
        }
    }

}
