using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Middle
{
    public class CombinePhoneNumber
    {
        private static string[] numLetters = new[] {"", "", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz"};
        private static List<string> combines = new List<string>();

        //这里就不纠结digit包含非法字符了，肯定都是2-9组合
        public static List<string> S1(string digit)
        {
            Combine(digit,0,"");
            return combines;
        }

        private static void Combine(string digit, int depth, string combine)
        {
            if (depth == digit.Length)
            {
                combines.Add(combine);
                return;
            }

            var currentDigit = digit[depth] - '0';
            var letters = numLetters[currentDigit];
            //外层按照当前数字对应的字母数循环
            for (var i = 0; i < letters.Length; i++)
            {
                //深度优先，先查找下一个数字
                //注意字符串的顺序
                //先走到最后一个数字，因为没有到最后一个数字，不能决定子串的长度
                //可以debug看看list里字符串的顺序
                Combine(digit, depth + 1 , combine + letters[i]);
            }
        }
    }
}
