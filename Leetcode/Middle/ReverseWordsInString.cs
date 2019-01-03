using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Middle
{
    public  class ReverseWordsInString
    {
        public static string ReserveWords(string input)
        {
            var word = new StringBuilder();
            var list = new List<string>();
            for (var i = 0; i < input.Length; i++)
            {
                //空格
                if (input[i] == ' ')
                {
                    //形成新单词
                    if (word.Length <= 0) continue;
                    list.Add(word.ToString());
                    word.Clear();
                }
                //字符
                else
                {
                    word.Append(input[i]);
                }
            }

            list.Reverse();
            return string.Join(" ", list);
        }
    }
}
