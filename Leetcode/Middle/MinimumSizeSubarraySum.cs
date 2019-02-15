using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Middle
{
    //相加之和>= target的连续子数组的长度, 数组都是正数
    public class MinimumSizeSubarraySum
    {
        public static int GetMinLength(int[] arr, int target)
        {
            var result = int.MaxValue;
            var left = 0;
            var right = 0;
            var sum = 0;
            for (var i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
                //当sum满足条件后，先计算最小长度，然后尝试把left+1，这是否也算是hi滑动窗口的模式呢
                while (sum >= target)
                {
                    result = Math.Min(result, i - left + 1);//子数组长度2，2-1=1，但是得算2个元素
                    //是1不用再继续循环了，不可能更小
                    if (result == 1) return 1;
                    //left+1后再计算sum值，如果不满足，就会回到大循环
                    sum -= arr[left++];
                }
            }
            return result == int.MaxValue ? 0 : result;
        }
    }
}
