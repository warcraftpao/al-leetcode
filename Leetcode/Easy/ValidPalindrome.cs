using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Easy
{
   // Given a string, determine if it is a palindrome, considering only alphanumeric characters and ignoring cases.

    //Note: For the purpose of this problem, we define empty string as valid palindrome.
    public  class ValidPalindrome
    {
        //这题有的意思关键是： 只考虑字母（忽略大小写）+数字（意味着看到别的字符忽略）
        //另外不明白为啥特地提到空格字符，空格不也算是别的字符吗？
        public static bool IsValid(string s)
        {
            var left = 0;
            var right = s.Length - 1;
            while (left < right)//left = right说明是奇数
            {
                if (!Is_alphanumeric(s[left])) left++;
                else if (!Is_alphanumeric(s[right])) right--;
                else if (s[right] == s[left] || Math.Abs( s[right] -s[left]) == 32)
                {
                    right--;
                    left++;
                }
                else return false;
            }
            return true;
        }

        private static bool Is_alphanumeric(char c)
        {
            if ((c >= 'a' && c <= 'z') ||
                (c >= 'A' && c <= 'Z') ||
                (c >= '0' && c <= '9'))
                return true;

            return false;
        }
    }
}
