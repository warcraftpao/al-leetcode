using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Middle
{
    public  class ReverseWordsInString
    {
        //way1 先翻转整个字符串，再逐个单词翻转，需要注意空格

        //this is way2
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

    //所以这也能这么做按照 第一阶的思路翻转做法
    //数组的局部翻转也能用那个reserve的技巧
    public class ReverseWordsInString2
    {
        public static char[] ReserveWords(char[] input)
        {
            PartlyReserve(input, 0, input.Length -1);
            var left = 0;
            //因为说了2头没有空格
            for (var i = 1; i < input.Length; i++)
            {
                if (input[i] == ' ')
                {
                    PartlyReserve(input, left, i - 1);
                    left = i + 1;
                }
                //到最后了必然不是空格
                else if (i == input.Length - 1)
                {
                    PartlyReserve(input, left, input.Length - 1);
                }
            }

            return input;
        }

        private static void PartlyReserve(char[] arr, int left, int right)
        {
            while (left < right)
            {
                var tmp = arr[left];
                arr[left] = arr[right];
                arr[right] = tmp;
                left++;
                right--;
            }
        }
    }
}
