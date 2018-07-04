using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using Leetcode.DataStructure;

namespace Leetcode.Middle
{
    public  class AddTwoNumbers
    {

        //You are given two non-empty linked lists representing two non-negative integers.
        //The digits are stored in reverse order and each of their nodes contain a single digit.Add the two numbers and return it as a linked list.
        //You may assume the two numbers do not contain any leading zero, except the number 0 itself.
        //Input: (2 -> 4 -> 3) + (5 -> 6 -> 4)
        //Output: 7 -> 0 -> 8
        //Explanation: 342 + 465 = 807.



        //链表先转成数字，再相加的思路
        public static int AddTwoNumbers1(LinkedList node1, LinkedList node2)
        {
            return GetNumberFromListNode(node1) + GetNumberFromListNode(node2);
        }

        public static int AddTwoNumbers2(LinkedList node1, LinkedList node2)
        {
            var nodeList = GetNewNodeListFrom2NodeLists(node1, node2);
            return GetNumberFromListNode(nodeList);
        }

        //链表相加的思路，因为是从个位数开始对齐的
        //某位相加如果不产生进位，新链表当前位置就是这个值
        // 产生进位的话，这个值%10 余数就是当前的值，这个值/10 =进位值
        private static LinkedList GetNewNodeListFrom2NodeLists(LinkedList node1, LinkedList node2)
        {
            var resultNode = new LinkedList();
            var current = resultNode;
            var i = node1.Next;
            var j = node2.Next;
            int carry = 0;
            while (i != null || j != null)
            {
                var ivalue = i != null ? i.Val : 0;
                var jvalue = j != null ? j.Val : 0;
                var sum = carry + ivalue + jvalue;
                carry = sum/10;
                current.Next = new LinkedList { Val = sum % 10 };
                current = current.Next;
                

                if (i != null)
                    i = i.Next;

                if (j != null)
                    j = j.Next;
            }

            if(carry > 0)
                current.Next =new LinkedList { Val =  carry};


            return resultNode;
        }

        private static int GetNumberFromListNode(LinkedList node)
        {
            var i =0;
            var value = 0;
            var currentNode = node.Next;
            while (currentNode != null)
            {
                var currentValue = currentNode.Val;
                 
                value += currentValue * (int) Math.Pow(10, i);
                currentNode = currentNode.Next;
                i++;
            }

            return value;
        }
    }
     
}
