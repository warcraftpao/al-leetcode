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

        //只允许最多2次操作 
        //只让搞2次操作，必然有个分割点i 在0到i操作一次，i+1 到len-1这个两个区间内各操作一次。 
        //那么用2个数组 proA来描述从0到i点为止操作一次的最大利润，proB描述从i到len-1操作一次的最大利润，最后这两个数组同index值相加取最大值（实际上都可以取到极限值）
        //0-i的好处理，i到len-1的需要倒过来思考，因为不知道i截取到哪里，所以还是正向计算的话，需要动态计算从任意点做起点，之后到每个点做一次操作的最大利润
        public static int MaxProfit_2transactions(int[] arr)
        {
            var len = arr.Length;
            var proA = new int[len];
            var proB = new int[len];

           
            var min = arr[0];
            for (var i = 1; i < arr.Length; i++)
            {
                //先算出来当前点减掉min的利润，（可以是负数的）,但是会被proA[0]比较的时候淘汰掉,min肯定出现在arr[i]之前
                proA[i] = arr[i] - min;
                proA[i] = Math.Max(proA[i], proA[i -1]);
                if (arr[i] < min) min = arr[i];//后面点的才能用到更新后的min值
            }

            //proB得从后开始计算，理解为数组里右边数字减掉其左边数字之差的最大值
            var max = arr[len - 1];
            for (var i = len - 2; i >= 0; i--)
            {
                proB[i] = max - arr[i]; //max肯定在i之后
                proB[i] = Math.Max(proB[i], proB[i + 1]);
                if (arr[i] > max) max = arr[i];
            }

            var maxProfit = 0;
            for (var i = 0; i < len; i++)
            {
                maxProfit = Math.Max(proA[i] + proB[i], maxProfit);
            }

            return maxProfit;
        }

    }
}
