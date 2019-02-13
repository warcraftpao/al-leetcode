using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Easy
{
    public class IsomorphicStrings
    {
        //All occurrences of a character must be replaced with another character while preserving the order of characters. 
        //No two characters may map to the same character but a character may map to itself.
        //就是我出现了a你出现了b，以后我再次出现a的时候，你也必须出现b。用一个字典表记录，key是s出现的char，value是t出现的char，如果s里面出现同样的字符，从字典表里找到value，此时t的char必须等于value
        public static bool YesOrNo(string s, string t)
        {
            var dic = new Dictionary<char,char>();
            for (var i = 0; i < s.Length; i++)
            {
                if (dic.ContainsKey(s[i]))
                {
                    var c = dic[s[i]];
                    if (c != t[i])
                        return false;
                }
                else
                {
                    dic.Add(s[i], t[i]);
                }
            }

            return true;
        }
    }
}
