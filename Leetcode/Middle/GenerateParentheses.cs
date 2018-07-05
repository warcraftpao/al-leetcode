using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Middle
{
    public class GenerateParentheses
    {
        //肯定要用dfs的思路
        //肯定要先输入一个左括号，剩余的左括号数不能大于剩余的右括号，满足这些条件的时候，随意输入
        public static List<string> Generate(int n)
        {
            var result = new List<string>();
            GenerateDfs(result, 0, 0, n, "");
            return result;
        }

        private static void GenerateDfs(List<string> result, int left, int right, int max, string currStr)
        {
            if (max*2 == currStr.Length)
            {
                result.Add(currStr);
            }

            //能先出现左括号就先出现左括号，实在不行再出现右括号
            if (left < max )//左括号还有
                GenerateDfs(result, left+1, right, max, currStr + "(");
            if(right < left)//右括号数量比左括号多
                GenerateDfs(result, left, right+1, max, currStr + ")");
        }


    }
}
