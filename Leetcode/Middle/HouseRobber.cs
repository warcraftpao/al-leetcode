using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Middle
{
    public class HouseRobber
    { 
         //动态规划思路 dp的某个值代表打劫某个屋子时能获得最大钱数
         //因为必须不能挨着抢，所以dp[i]只依赖2个情况，如果抢了i-1 就不能抢i如果抢了i-2就可以抢i
         //有点像跳格子每次只能跳1或者2格，求跳到终点的方法
        public static int Rob(int[] nums)
        {
            if (nums.Length == 1)
                return nums.First();
            
            var dp = new int[nums.Length];
            dp[0] = nums.First();
            dp[1] = Math.Max(nums[0], nums[1]);
            for (var i = 2; i < nums.Length; i++)
            {
                dp[i] = Math.Max(nums[i] + dp[i - 2], dp[i - 1]);
            }

            return dp[nums.Length - 1];
        }

        public static int HouseRobber2(int[] nums)
        {
            return Math.Max(Rob(nums.Skip(1).ToArray()), Rob(nums.Take(nums.Length - 1).ToArray()));
        }
    }
}
