using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Middle
{
    public class MaxSubstringWithoutRepeatChar
    {
        public static int GetMaxSubstringWithoutRepeatChar(string str)
        {
            
            var dic = new Dictionary<char, int>();
            int sum = 0;
            int max = 0;
            int start = 0;
            for (var i = 0; i < str.Length; i++)
            {
                char c = str[i];
                if (dic.ContainsKey(c))//该字符曾经出现过
                {
                    var idx = dic[str[i]];//该字符之前出现的位置
                    
                    if (idx >= start)//该字符之前的位置在当前子串中，比如 abcdb，当b第二次出现的时候，start是0，b的位置是1
                        //那么当前子串的最大长度就是2次位置出现的之差，并且起始位置是之前出现位置+1
                    {
                        //新子串的长度
                        sum = i - idx;
                        //新子串的起点  
                        start = idx + 1;
                    }
                    else//该字符之前的位置比当前子串更前面
                    //那没关系，对子串长度增加
                    {
                        sum++;
                    }
                    //最终总是要更新字符串出现的位置
                    dic[c] = i;
                }
                else //该字符从没出现过，加入该字符在string的位置,这种情况起始位置不用变，且最当前的子串的长度在怎加
                {
                    dic.Add(c, i);
                    sum++;
                }
                max = Math.Max(sum, max);
            }
            return max;
        }
    }
}
