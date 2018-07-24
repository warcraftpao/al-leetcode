using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Easy
{
    public class MaximumSubarray
    {
        //最大子数组，而非最长
        //如果之前的和加上当前数字比当前数字还小，就直接从当前数字开始重新累计
        //自己理解为，如果之前的子串起负作用，那就抛弃，直接用当前单独的值；如果当前的值起负作用，还能往后延续说不定他后面有大数
        public static int GetMs(int[] arr)
        {
            var maxSum = int.MinValue;
            var currSum = 0;
            for (var i = 0; i < arr.Length; i++)
            {
                currSum = Math.Max(currSum + arr[i], arr[i]);
                maxSum = Math.Max(maxSum, currSum);
            }

            return maxSum;
        }

        //copy paste one; not for unittest
        //计算到某个元素时和为负数，就清零，负数不会让加上后面数字的组合变得更大；如果负数本身就是最大值了，也会记录下来
        public int maxSubArray(int[] A)
        {
            int max_ending_here = 0;
            int max_so_far = int.MinValue;

            for (int i = 0; i < A.Length; i++)
            {
                if (max_ending_here < 0)
                    max_ending_here = 0;
                max_ending_here += A[i];
                max_so_far = Math.Max(max_so_far, max_ending_here);
            }
            return max_so_far;
        }

        //https://www.cnblogs.com/jimmycheng/p/7204034.html
    }
}
