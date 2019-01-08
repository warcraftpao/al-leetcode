using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Middle
{
    //最大乘积子数组（连续的）
    public  class MaximumProductSubarray
    {
        //因为是整数，不考虑零的情况，相乘的时候绝对值肯定再增大
        //这是动态规划的做法，i步只依赖i-1步的结果
        public static int Calc(int[] arr)
        {
           //这里是指上到上一步为止的最大值和最小值，只要不遇到0 , max和min的绝对值总是在增大的，preStep最大不代表全局最大
           //遇到0的时候，preStepMax会变成0，乘积绝对值相当于会中断，需要从0以后的乘积超过全局最大值才会更新最大值
            var preStepMax = arr[0];
            var preStepMin = arr[0];
            var result = arr[0];

            for (var i = 1; i < arr.Length; i++)
            {
                var tmpMax = preStepMax;
                //求最大，有可能是最小值*负数
                //求最小，有可能是最大值*负数
                preStepMax = Math.Max(Math.Max(arr[i], tmpMax * arr[i]), preStepMin*arr[i]);
                
                preStepMin = Math.Min(Math.Min(arr[i], tmpMax * arr[i]), tmpMax * arr[i]);
                result = Math.Max(result, preStepMax);
            }

            return result;
        }
    }
}
