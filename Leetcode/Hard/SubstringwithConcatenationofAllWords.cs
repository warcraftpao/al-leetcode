using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Hard
{
    /// <summary>
    /// You are given a string, s, and a list of words, words, that are all of the same length. 
    /// Find all starting indices of substring(s) in s that is 
    /// a concatenation of each word in words exactly once and without any intervening characters.
    /// words本身是有重复的
    /// </summary>
    public class SubstringwithConcatenationofAllWords
    {
        //因为words里单词是定长的，所以单词有多长就遍历几次，每次遍历按照单词长度跳间隔
        //假设单词长度是x，那么s的第x+1个字符开始拿x个字符的情况，包含在第一次循环里了

        //每次初始化一个字典表，一旦字典表内找不到单词（说明这个单词本来就不在字典表内，或者已经出现过需要的次数了），index前进，字典表重新初始化
        //每次找到匹配的单次，从字典表里扣减，字典表为空的情况下，说明找到单词了，保存index，注意，此时仍然需要急需查找
        public static int[] S1(string s, string[] words)
        {
            //假设words长度大于1，s长度也大于words里单词长度，这种就不在验证了
            var ret  = new List<int>();
            var wordLen = words[0].Length;
            var len = s.Length;
            for (var i = 0; i < wordLen; i++)
            {
                var dic  = InitDic(words);
                int index =i;
                for (var j = i; j < len; j += wordLen)
                {
                    if (len < j + wordLen)
                        break;

                    var curword = s.Substring(j, wordLen);
                    if (dic.ContainsKey(curword))//当前单词存在，放入临时字典表
                    {
                        if (dic[curword] > 1)
                            dic[curword] -= 1;
                        else
                            dic.Remove(curword);

                        //字典变空，说明匹配
                        if (dic.Count == 0)
                        {
                            ret.Add(index);
                            dic = InitDic(words);
                            index = index + wordLen* words.Length;
                        }
                            
                    }
                    else// 没有当前单词,index前进,重新初始化字典
                    {
                        dic = InitDic(words);
                        index = index + wordLen;
                    }
                }
            }

            return ret.ToArray();
        }

        private static Dictionary<string, int> InitDic(string[] words)
        {
            var dic = new Dictionary<string, int>();
            for (var d = 0; d < words.Length; d++)
            {
                if (dic.ContainsKey(words[d]))
                    dic[words[d]] = dic[words[d]] + 1;
                else
                    dic.Add(words[d], 1);
            }
            return dic;
        }

        //s2  应该是有一个标准字典表，每次循环去生成一个临时字典表，去比对临时字典表和标准字典表是否相同，思路差不多，不如上面的清晰
    }
}
