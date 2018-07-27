using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Middle
{
    public class MinimumPathSum
    {
        //和拿苹果反下，求到达格子右下角路径经过的格子和最小值
        public static int GetMin(int[,] arr)
        {
            var dp = new int[arr.GetLength(1)];
            dp[0] = arr[0, 0];
            for (var i = 0; i < arr.GetLength(0); i++)
            {
                for (var j = 0; j < arr.GetLength(1); j++)
                {
                    //dp[j]代表上行本列  dp[j-1]本行前列
                    if (i == 0 && j> 0) dp[j] = dp[j -1] + arr[i, j];
                    else if (j == 0 && i > 0 ) dp[j] = dp[j] + arr[i , j];
                    else if(i> 0 && j>0)//可以从2个方向来的
                    {
                        dp[j] = arr[i, j] + Math.Min(dp[j], dp[j - 1]);
                    }
                }
            }

            return dp [arr.GetLength(1) -1];
        }
    }
}
