using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization.Configuration;
using Leetcode.Easy;


namespace Leetcode.Middle
{
    /// <summary>
    /// 假定字典不重复
    /// </summary>
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

    /// <summary>
    /// 假定字典不重复
    /// </summary>
    public class WordBreak2
    {
        public static List<string> Isvalid(string s, List<string> dic)
        {
            var result = new List<string>();
            string tmp = "";
            //代表从某个位置到结尾可分割，因为dfs本质上会先递归到字符串尾的最短的情况（最后面的长度1的字符串是否在dic里），所以这些判断可以复用
            //因为总能用到后面更短的字符串是否可分的情况
            var slideable = new bool[s.Length + 1];
            for (var i = 0; i < slideable.Length; i++)
            {
                slideable[i] = true;
            }
            dfs_helper(s, dic, slideable, 0,   tmp, result);
            //回退，去掉最后的空格和单词
            return result;
        }

        //从第一位开始截取，大循环是每次多截一个字符
        //如果能匹配到一个单词，就进入深度优先递归
        private static void dfs_helper(string s, List<string> dic, bool[] slideable, int start,   string tmp, List<string> result)
        {
            if (start == s.Length)
            {
                //start=length的时候说明取到某个单词的时候正好用完了。因为假定字典不重复，不需要考虑别的单词
                //去掉最后一个空格
                result.Add(tmp.Substring(0,  tmp.Length -1 ));
                return;
            }

            //开始从第一位截取,不断截取更长的字符串
            for (var i = start; i < s.Length; i++)
            {
                var word = s.Substring(start, i - start + 1);
                if (dic.Contains(word) && slideable[i+1]) //i在变大，i之前的串都是用来被截取的，所以如果i后面的字符串可分才有意义
                {
                    //这是新的开头，前面不用加空格
                    //加上某个单词和空格，不管最终是不是解，总是要回退尝试另外下一种情况的
                    tmp = tmp + word + " ";
                     var oldSize = result.Count;
                    dfs_helper(s, dic, slideable, i + 1,   tmp, result);
                    //如果经过dfs到了回退的时候，结果数量没变化，说明某点开始到结尾是不可分的
                    //上面说过这个原因了，因为dfs总是会优先走到字符串最后面和最短的情况，再慢慢回退回来，
                    //就比如大循环第一次只截取1个字符的情况，dfs也会验证到最后1个字符是否再字典里，然后再回到倒数2个字符是否在字典里，这里可以极大减少递归次数
                     if (oldSize == result.Count)
                         slideable[i + 1] = false;
                    //回退，去掉最后的空格和单词
                    tmp = tmp.Substring(0, tmp.Length - word.Length - 1);
                }
            }
        }
        
    }
}
