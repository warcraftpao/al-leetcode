using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BinaryTree
{
    public class UniqueBinarySearchTrees
    {
        public static int GetNum(int n)
        {
            //动态规划思路，bst，比root小的会在左面，大的会在右面
            //所以假设根=root的时候，会有 root-1个数字在左面，n-root个数字在右面
            //就转化成了，求 dp[root-1]和dp[n-root]。 注意只要任意连的情况，1到5和 2到6的组合情况肯定是一样多的
            //
            //比如1-20, 1让root 就是有dp[0]*dp[19]， 10当root 就是dp[9]* dp[10]，每个情况相加
            var dp = new int[n + 1];
            dp[0] = 1;//为了乘法好做
            dp[1] = 1;//1个数字1个分法

            //比如数字n个时候会依赖到dp[0] 到dp[n-1]的所有情况
            for (var stage = 2; stage <= n; stage++)
            {
                for (var root = 1; root <= stage; root++)
                {
                    dp[stage] += dp[root - 1]*dp[stage - root];
                }
            }

            return dp[n];
        }
    }
}
