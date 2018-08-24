using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Hard
{
    //s,t 从s里抠掉1或这多个字符，不改变相对顺序，形成t，求数量
    public  class DistinctSubsequences
    {
        // t增加字符的情况不用在dp里考虑，因为单纯t增长不会增加匹配，只需要考虑s增长，和st一起增长的情况（dp的时候就是依赖s-1 和st一起-1）
        public static int NumDistinct(string s, string t)
        {
            //要考虑取0个字符的情况   dp的下标 1对应数组的下标0
            var dp = new int[s.Length + 1, t.Length + 1];
            //t取0个字符，s随便几个都匹配一种情况
            for (var i = 0; i <= s.Length; i++)
            {
                dp[i, 0] = 1;
            }

            //s取0个字符，t只要不是0个字符，其他都一定0匹配，0-0匹配1
            for (var i = 1; i <= t.Length; i++)
            {
                dp[0, i] = 0;
            }

            for (var i = 1; i <= s.Length; i++)
            {
                for (var j = 1; j <= t.Length; j++)
                {
                    //dp[i,j]依赖两个情况，一种是 dp[i-1, j]，就是s多取了一个字符后，假设这个字符删掉后，可以+dp[i-1, j]
                    //另外一种是dp[i-1, j-1]，如果当前的2个字符相同，那么说明可以+dp[i-1, j-1]
                    //t多取一个字符的情况不需要考虑，不可能t多一个字母反而多出来匹配次数的情况
                    dp[i, j] += dp[i - 1, j];
                    if (s[i - 1] == t[j - 1])//注意这是数组下标，比较的是当前字符，不是上一个字符
                    {
                        dp[i, j] += dp[i - 1, j -1];
                    }
                }
            }

            return dp[s.Length, t.Length];
        }
    }
}
