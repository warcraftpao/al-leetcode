using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace Leetcode.Hard
{
    public  class BasicCalculator
    {
        /// <summary>
        /// level1 只有数字+-（）和空格
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        public static int Level1(string exp)
        {
            //思路一参考leetcode，倒转字符串

            //思路二 循环表达式
            //总有一个记录当前处理的结果result，一个记录正负号的sign
            //跳过空格 
            //遇到数字要考虑数字是否是连续的； 当前数字是加减取决于sign，更新result的值
            //主要是处理减号问题 ,减号可以在左括号前，减号也可以在数字前
            //在遇到加减号的时候，更新sign
            //在遇到（的时候，说明一个新的表达式开始了，把result和sign入栈，新的表达式开始了(因为新的表达式的结果还不知道），括号里面的result和sign要重新开始算
            //在遇到）的时候说明一个表达式结束了，出栈两次，把当前表达式开始之前存的reuslt和sign取出来操作
            var result = 0;
            var sign = 1;
            var stack = new Stack<int>();
            for (var i = 0; i < exp.Length; i++)
            {
                var c = exp[i];
                if (c >='0' && c <='9' )
                {
                    var number = c - '0';
                    while (i + 1 < exp.Length && exp[i+ 1] >= '0' && exp[i+1] <= '9')
                    {
                        number = number*10 + exp[i + 1] -'0';
                        i++;
                    }
                    result = result + sign*number;
                }
                else if (c == '+')
                {
                    sign = 1;
                }
                else if (c == '-')
                {
                    sign = -1;
                }
                else if (c == '(')
                {
                    //先入 之前的结果集，再入 符号
                    stack.Push(result);
                    stack.Push(sign);
                    result = 0;
                    sign = 1;
                }
                else if (c == ')')
                {
                    //result * 栈里的符号
                    var curr = result*stack.Pop();
                    result = curr + stack.Pop();

                }
            }

            return result;
        }

        /// <summary>
        /// level2  字符串表达式仅包含非负整数，+， - ，*，/ 四种运算符和空格  。 整数除法仅保留整数部分。
        /// 没有括号 第一有效字符不会是 符号，且不会有 * -5 这样的表达式？
        /// +号很容易处理，主要是处理负号和乘除，用一个变量记录当前符号，遇到数字的时候，如果之前的符号是加减号，入栈一个正数或者负数
        /// 当遇到一个乘除号的时候，出栈一个数字，做乘除法，然后再入栈
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        public static int Level2(string exp)
        {
            var result = 0;
            var sign = '+';
            var stack = new Stack<int>();
            for (var i = 0; i < exp.Length; i++)
            {
                var c = exp[i];
                //遇到数字入栈,且需要考虑之前的操作符
                if (c >= '0' && c <= '9')
                {
                    var number = c - '0';
                    while (i + 1 < exp.Length && exp[i + 1] >= '0' && exp[i + 1] <= '9')
                    {
                        number = number * 10 + exp[i + 1] - '0';
                        i++;
                    }
                    if(sign == '+')
                        stack.Push(number);
                    else if (sign == '-')
                        stack.Push(-number);
                    else if (sign == '*')
                    {
                        var pre = stack.Pop();
                        stack.Push(pre * number);
                    }
                    else if (sign == '/')
                    {
                        var pre = stack.Pop();
                        stack.Push(pre / number);
                    }

                }
                else if (c != ' ')
                {
                    sign = c;
                }
            }

            while (stack.Count > 0)
            {
                result += stack.Pop();
            }

            return result;
        }
    }
}

