using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leetcode.Easy;

namespace Leetcode.Middle
{
    public class WordBreak
    {
        public static bool Isvalid(string s, List<string> dic)
        {
            var len = s.Length;
            var dp = new bool[len + 1];
            //长度是0就当默认肯定是对的，不影响第一个字符开始的判断
            dp[0] = true;

            //测试dp[1]到dp[len] dp[i]依赖dp[i-1]以前的所有值，肯定都会计算过（dp[0] 已经初始化为true） 
            //dp[i]代表 前i个字符可以从dic里挑出的单词组成
            for (var i = 1; i <= len; i++)
            {
                //j从i-1开始循环，之前的字符串已经合法且扣出来的字符串在字典里
                for (var j = i - 1; j >= 0; j--)
                {
                    if (dp[j])//只是为了debug方便
                    {
                        var sub = s.Substring(j, i - j);
                        if (dic.Contains(sub))
                        {
                            dp[i] = true;
                            break;
                        }
                        
                    }
                }

            }

            return dp[len];
        }
    }
}
