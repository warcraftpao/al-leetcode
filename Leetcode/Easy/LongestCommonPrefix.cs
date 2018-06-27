using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Easy
{

    /// <summary>
    /// https://segmentfault.com/a/1190000008930426  2分法可以看看，那个分治感觉没啥区别
    /// </summary>

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

        //2分法
        public static string S2Binary(string[] arr)
        {
            var len = arr[0].Length;
            foreach (var str in arr)
            {
                len = Math.Min(len, str.Length);
            }
            //上面的逻辑一样，肯定是从最短数据开始切一半比较


            var lo =0;
            var hi = len -1;
            var mid = 0;
            while (lo <= hi)
            {
                mid = (lo + hi)/2;
                if (IsCommonPrefix(arr, mid))
                {
                    lo = mid + 1;
                }
                else
                {
                    hi = mid -1;
                }
            }
            //注意下，lo=hi的循环，操作最后一位，之后lo+1，所以截取的时候长度够的
            return arr[0].Substring(0, lo);
        }

        private static bool IsCommonPrefix(string[] arr, int len)
        {
            var prefix = arr[0].Substring(0, len);
            foreach (var str in arr)
            {
                if (!str.StartsWith(prefix))
                    return false;
            }
            return true;
        }
    }
}
