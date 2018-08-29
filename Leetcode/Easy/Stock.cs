using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Easy
{
    public class Stock
    {
        //一天只能卖或者买一手，所以某一天要么找到一个最低点要么就计算最大利润
        //找到最低的那天肯定不可能卖（所以不可能去计算利润，第一天也肯定不能卖），那么在不是最低点的那天，就要尝试计算利润（最低点肯定在他前面）
        public static int MaxProfit(int[] arr)
        {
            var minPrice = int.MaxValue;
            var maxProfit = 0;
            for (var i = 0; i < arr.Length; i++)
            {
                if (minPrice > arr[i])
                    minPrice = arr[i];
                else
                    maxProfit = Math.Max(maxProfit, arr[i] - minPrice);
            }

            return maxProfit;
        }

        //https://blog.csdn.net/ithomer/article/details/7107968 数组中 数字对之差最大值（必须都是考察左减右，或者右减左，否则没实际意义） stock只是加个包装
        //比较逗的是，题意说不能必须买了才能卖，当天也必须买了后再卖，不过
        //https://leetcode.com/problems/best-time-to-buy-and-sell-stock-ii/solution/ 的解法3，反而只是用了最简单的上升趋势直接累加得出答案的方法。。。。
        public static int MaxProfit_multitransaction(int[] arr)
        {
            var profit = 0;
            var buyIndex = 0;
            var sellIndex = 0;
            //第一天可能可以买但绝不会卖
            for (var i = 1; i < arr.Length; i++)
            {
                //a[i] < arr[i-1]保持循环，结束while说明找到一个比之前大的点,即为出现了上升趋势
                //注意虽然是要找上升趋势，但是循环要反过来写
                while (i < arr.Length && arr[i] <= arr[i - 1])
                {
                    i++;
                }
                //找到买入点
                buyIndex = i-1;
                ////a[i] >  arr[i-1]保持循环,结束while 说明找到找到一个比之前小的点的，出现了下降趋势
                while (i < arr.Length && arr[i] >= arr[i - 1])
                {
                    i++;
                }
                sellIndex = i - 1;
                profit += arr[sellIndex] - arr[buyIndex];
            }

            return profit;
        }


    }
}
