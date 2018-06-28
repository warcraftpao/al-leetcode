using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.DP
{
    public class LIS
    {
        //最长非降子序列的长度,5，3，4，8，6，7==> 3 4 6 7
        //中间可以跳开几位的
        public static int S1(int[] arr)
        {
            var maxLength = new int[arr.Length];//子序列的最长非降序子序列长度
            var max = 0;
            for (var i = 0; i < arr.Length; i++)
            {
                //至少是自身=1吧
                maxLength[i] = 1;
                //循环我之前的max数组, 所有比现在小的数字里，找到子序列最长的
                for (int j = 0; j < i; j++)
                {
                    if (arr[j] <= arr[i] && maxLength[j] + 1 > maxLength[i])
                        maxLength[i] = maxLength[j] + 1;
                }
                max = Math.Max(max, maxLength[i]);
            }
            return max;
        }
    }
}
