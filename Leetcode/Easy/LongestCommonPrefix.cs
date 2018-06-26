using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Easy
{
    public class LongestCommonPrefix
    {
        //不考虑数组为空什么异常了
        public static string S1(string[] arr)
        {
            var len = arr[0].Length;
            foreach (var str in arr)
            {
                len = Math.Min(len, str.Length);
            }
            var i = 0;
            var longestPrefix = "";
            while ( i<len)
            {
                var l = arr[0][i];
                foreach (var str in arr)
                {
                    if (str[i] != l) 
                        break;
                }
                longestPrefix += l;
                i++;
            }

            return longestPrefix;
        }
    }
}
