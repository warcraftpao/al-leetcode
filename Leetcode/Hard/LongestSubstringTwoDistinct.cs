using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Hard
{
    public class LongestSubstringTwoDistinct
    {
        //需要一个字段表，一个当前滑动窗口的start位置
        //每次循环一个字符，把这个字符作为key加入字典表
        //当字典数量<3的时候，算一下当前子字符串的长度，和最大值比较后更新
        //当字典数量=3的时候，必须要用某个方法减小字典数量：
         
        //简单说，有一个滑动窗口表达了当前子字符串 当出现第3种字符的时候，总归要使子字符串的start前进，直到他只包含2种字符
        //所以就从start开始的字符删除，直到某个字符出现次数变为0，删除这个key，start到循环点就是当前子字符串的长度
        public static int GetLenght(string input)
        {
            var dic = new Dictionary<char, int>();
            var start = 0;
            var max = 0;
            for (var i = 0; i < input.Length; i++)
            {
                var c = input[i];
                if (dic.ContainsKey(c))
                    dic[c]++;
                else
                    dic.Add(c, 1);

                while (dic.Count == 3)
                {
                    var f = input[start];
                    //先减后判断，看看是不是变成0了
                    if (--dic[f] == 0)
                        dic.Remove(f);
                    start++;
                }

                max = Math.Max(max, i - start + 1);//5-4=1 长度是2
            }

            return max;
        }
 
    }
}
