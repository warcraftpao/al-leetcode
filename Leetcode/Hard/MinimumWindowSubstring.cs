using System.Collections.Generic;

namespace Leetcode.Hard
{
    public  class MinimumWindowSubstring
    {
        //每次循环的时候，先看看加上当前的字符后，是否在s通过start和end找到了子串t
        //如果找到了子串t，那么看看start是否能缩减，缩减到不能缩减为止。但是此时还不一定是最终结果
        //end要继续前进，每次end前进时，继续尝试缩减start
        //重点就是找到第一个符合要求的子串后，继续往前查找的同时，要缩减start。
        public static string Get(string s, string t)
        {
            var start = 0;
            var minLen = int.MaxValue;
            var result = "";
            var found = 0;
            var charInT = new Dictionary<char, int>();
            for (var i = 0; i < t.Length; i++)
            {
                if (charInT.ContainsKey(t[i]))
                    charInT[t[i]]++;
                else
                    charInT.Add(t[i],1);
            }

            for (var i = 0; i < s.Length; i++)
            {
                //当前字符是t里的字符
                if (charInT.ContainsKey(s[i]))
                {
                    if (charInT[s[i]] > 0) //说明出现的字符是有需要的
                        found++;

                    //记录还需要出现的次数，如果这个值是负数，说明出现的次数超过需要了，缩减start的时候遇到这样的字符可以前进之
                    charInT[s[i]]--;
                    
                    //找到了一个符合要求的子串, 尝试缩减子串
                    //在不能缩减的时候，尝试获得更小的子串
                    if (found == t.Length)
                    {
                       
                        while (start < i)//start还小于当前位置
                        {
                            if (!charInT.ContainsKey(s[start])) //起始字符不是t里的
                                start++;
                            else if (charInT[s[start]] < 0) //出现次数大于需求
                            {
                                charInT[s[start]]++;
                                start++;
                            }
                            else//不能缩减了，获得子串
                            {
                                var len = i - start + 1;
                                if (len < minLen)
                                {
                                    minLen = len;
                                    result = s.Substring(start, len);
                                }
                                break;
                            }
                        }
                    }
                }
            }
            if (minLen == int.MaxValue) return "";
            return result;
        }
    }
}
