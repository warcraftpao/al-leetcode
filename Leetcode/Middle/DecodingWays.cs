using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Middle
{
    public class DecodingWays
    {
        //A=1，B=2 until Z=26  A message containing letters from A-Z is being encoded to numbers using the following mapping:
        //Given a non-empty string containing only digits, determine the total number of ways to decode it.
        //不明白网上的一些例子，既然是解码，字符串必须合法，非法字符串情况为什么要考虑呢？
        //开头是0 ，或者中间有连续2个0，30等是不合法情况，我认为出现非法字符串就是return 0；
        public static int GetWayNum(string s)
        {
            var dp = new int[s.Length];

            if (SingleCharIsValid(s[0]))
                dp[0] = 1;
            else
                return 0;

            if (TwoCharIsValid(s[0], s[1]) && SingleCharIsValid(s[1]))
            {
                dp[1] = 2;
            }
            else if (TwoCharIsValid(s[0], s[1]))
            {
                dp[1] = 1;
            }
            else
            {
                return 0;
            }

            for (var i = 2; i < s.Length; i++)
            {
                if (SingleCharIsValid(s[i]))
                    dp[i] += dp[i - 1];
                if(TwoCharIsValid(s[i -1], s[i]))
                    dp[i] += dp[i - 2];

                if (dp[i] == 0)
                    return 0;
            }

            return dp[s.Length - 1];
        }

        //单个数字合法 1-9, 0不合法
        private static bool SingleCharIsValid(char c)
        {
            var num = c - '0'; 
            return num >= 1 && num <= 9;
        }

        //c1 十位数，c2个位数
        private static bool TwoCharIsValid(char c1, char c2)
        {
            var num1 = c1 - '0';
            var num2 = c2 - '0';
            var num = num1 * 10 + num2;
            return num >= 10 && num <= 26;
        }
    }
}
