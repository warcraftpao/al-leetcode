using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Easy
{
    // You are climbing a stair case. It takes n steps to reach to the top.
    //Each time you can either climb 1 or 2 steps.In how many distinct ways can you climb to the top?
    public class ClimbingStairs
    {
        public static int Climb(int n)
        {
            var dp = new int[n];
            dp[0] = 1;// 一层一种爬法
            dp[1] = 2;// 两层两种爬法
            //比如爬到第七层，那么可以从第六层过来或者第五层过来，x和x-1 X-2关联
            for (var i =2; i < n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }

            return dp[n - 1];
        }
    }
}
