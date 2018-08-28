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
        // t比s长的情况不可能有匹配；本质上只有s里有和t一样的字符并且多出来重复字符（t是aa，s是aaa，才能有3个情况各删除一个a的匹配）才能多出来匹配情况，只是比t字符多如果不相同，都是在一种情况下删除，不增加匹配情况
        //所以只要一路向前循环匹配就可以了，之前的匹配情况会传递过来
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
                    //dp[i,j]依赖两个情况，一种是 dp[i-1, j]，就是s延伸一个字符后，这个字符删掉总是能还原到s取i-1个字符的情况，可以+dp[i-1, j]
                    //另外一种是dp[i-1, j-1]，如果当前的2个字符相同，那么说明新加的2个字符都去掉，可以还原到s取i-1，t取j-1个字符的情况，可以+dp[i-1, j-1]
                    //t多取一个字符的情况不需要考虑，不可能t多一个字符s不变反而增加匹配数
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
