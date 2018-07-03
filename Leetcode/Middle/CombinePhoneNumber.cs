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
        //深度优先，1层循环是所有数字（即对应的字符组合） 循环里递归下一个数字（假设数字3位，第一个数字第一个字母，然后第二个数字第一个字母，最后是第三个数字的第一个字母
        //循环到第四次的时候 深度=3，就退出了，然后是第三个数字的第二个字母第三个字母，再回到第二个数字的第二个字母。。。最后回到第一个数字第一个字母，再到第一个数字第二个字母
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
            //外层按照数字长度循环
            for (var i = 0; i < letters.Length; i++)
            {
                //深度优先，先查找下一个数字
                //注意字符串的顺序
                Combine(digit, depth + 1 , combine + letters[i]);
            }
        }
    }
}
