using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Hard
{
    //又是一个光看搜单词意思连题目都看不懂的题
    //大概就是每次不是从s1就是s2里取出一个字符组成s3的情况叫 Interleaving String
    public class InterleavingString
    {
        public static bool IsInterleave(string s1, string s2, string s3)
        {
            //要考虑s1或者s2取了0个字符的情况，所以长度要+1
            var dp = new bool[s1.Length + 1, s2.Length + 1];
            dp[0,0] = true;//还没取字符算true
            //只考察s1的情况,s1出第i个字符（下标是i-1）
            for (var i = 1; i <= s1.Length; i++)
            {
                dp[i, 0] = dp[i - 1, 0] && s1[i - 1] == s3[i - 1];
            }
            //只考察s2的情况,s2出第i个字符（下标是i-1）
            for (var i = 1; i <= s2.Length; i++)
            {
                dp[0, i] = dp[0, i - 1] && s2[i - 1] == s3[i - 1];
            }
            for (var i = 1; i <= s1.Length; i++)
            {
                for (var j = 1; j <= s2.Length; j++)
                {
                    //s1 取了i 个字符，s2取了j 个字符，s3对应的是取得了 i+j 个字符，等于i+j-1位
                    //那么这个情况要符合，新加进来的无非就是s1的第i个字符或者s2的第j个字符
                    //判断 s1新加字符并且等于s3的字符 && dp[i-1][j]
                    //或者 s2新加字符并且等于s3的字符 && dp[i][j-1]
                    //我喜欢用括号表达优先级，注意下标的意思
                    dp[i, j] = (dp[i - 1, j] && s1[i - 1] == s3[i + j - 1]) ||
                               (dp[i, j - 1] && s2[j - 1] == s3[i + j - 1]);
                }
            }

            return dp[s1.Length , s2.Length ];
        }
    }
}
