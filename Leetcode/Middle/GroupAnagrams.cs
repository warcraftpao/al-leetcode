using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Leetcode.Middle
{
    //错位词，如果2个单词组成每种字母数量相同就是错位词，比如aattc和ttaca
    //输入字符串里只有小写字母
    public class GroupAnagrams
    {
        public static List<List<string>> Group(string[] arr)
        {
            var dic = new Dictionary<string, List<string>>();
            for (var i = 0; i < arr.Length; i++)
            {
                var word = new int[26];
                for (var j = 0; j < arr[i].Length; j++)
                {
                    word[arr[i][j] - 'a']++;    
                }
                var key = string.Join("", word);
                if (dic.ContainsKey(key))
                {
                    dic[key].Add(arr[i]);
                }
                else
                {
                    dic.Add(key, new List<string> { arr[i] });
                }
            }

            var list = new List<List<string>>();
            foreach (var item in dic.Keys)
            {
                list.Add(dic[item]);
            }

            return list;
        }
    }
}
