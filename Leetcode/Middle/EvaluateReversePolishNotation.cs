using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Middle
{
    public class EvaluateReversePolishNotation
    {
        private static List<string> Operator = new List<string> {"+","-","*","/"};
        public static int EvalRPN(string[] tokens)
        {
            var stack = new Stack<string>();
             
            int lastCalcResult = 1 ; //  这只是为了初始化，什么值没关系
            for (var i = 0; i < tokens.Length; i++)
            {
                //是操作符
                if (Operator.Contains(tokens[i]))
                {
                    var b = Convert.ToInt32(stack.Pop());
                    var a = Convert.ToInt32(stack.Pop());
                    lastCalcResult = Calc(a, b, tokens[i]);
                    //把结果也入栈，简化操作，因为一开始总归有2个数字，之后可以只有一个数字需要用到上次结算的结果
                    stack.Push(lastCalcResult.ToString());
                }
                else //不是操作符
                {
                    stack.Push(tokens[i]);
                }
            }

            return lastCalcResult;
        }

        private static int Calc(int a, int b, string op)
        {
            switch (op)
            {
                case "+":
                    return a + b;
                case "-":
                    return a - b;
                case "*":
                    return a*b;
                default:
                    return a/b;
            }
        }
    }
}
