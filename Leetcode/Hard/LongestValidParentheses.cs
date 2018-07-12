﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Hard
{
    //只有 （ ）左右括号
    public class LongestValidParentheses
    {
        //统计括号数量的思路，因为只有含有括号
        //统计到任何时候，右括号都不能比左括号多，对吧
        //如果左右括号数量相等的时候，当前某个括号数量*2 肯定就是最大长度了
        //因为统计的是子串，所以只统计一边是不行的
        public static int S1(string s)
        {
            var left = 0;
            var right = 0;
            var maxLength = 0;
            //left to right
            for (var i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                    left++;
                else
                    right++;

                if (left == right)
                    maxLength = Math.Max(maxLength, right*2);
                else if (right > left)
                {
                    left = 0;
                    right = 0;
                }
            }
            left = 0;
            right = 0;
            //right to left
            for (var i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == ')')
                    right++;
                else
                    left++;

                if (left == right)
                    maxLength = Math.Max(maxLength, right*2);
                else if (right < left)
                {
                    left = 0;
                    right = 0;
                }
            }

            return maxLength;
        }



        public static int S2(string s)
        {
            var maxLength = 0;
            var stack = new Stack();
            var start =  -1;//前2个元素合法的话，1-（-1） =2
            for (var i = 0; i < s.Length; i++)
            {
                //记录左括号的下标
                if (s[i] == '(')
                {
                    stack.Push(i);
                }
                else//遇到右括号
                {
                    //有对应右括号
                    if (stack.Count > 0)
                    {
                        stack.Pop();
                        //其实在匹配到左括号的情况下，start不变，无非是要计算当前点到上个括号的长度
                        //要注意2种计算方式的下标
                        if (stack.Count > 0)//还有更多的左括号，所以当前位置减掉栈里第一个左括号的位置就是最大长度
                        {
                            maxLength = Math.Max(i - (int)stack.Peek(), maxLength);
                        }
                        else //没有剩余左括号了，之前的元素都是算在长度里的
                        {
                            maxLength = Math.Max(i - start, maxLength);// 从start开始到现在都是当前长度里的，并且当前长度还可能能继续增加
                        }
                    }
                    else//没有对应左括号，起点更新
                    {
                        start = i;
                    }
                }
            }
            return maxLength;
        }
    }
}
