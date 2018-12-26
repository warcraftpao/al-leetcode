using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Middle
{
    public class UniquePaths
    {
        //backtracing,放在这里不合适
        public static int GetPathNumer_backtracing(int m, int n)
        {
            int num = 0;
            TryGo(ref num, 1, 1, m, n);
            return num;
        }

        private static void TryGo(ref int num, int row, int col,int m , int n)
        {
            if (row == m && col == n)
            {
                num++;
                return;
            }

            if(row < m)
                TryGo(ref num, row+1, col, m, n);

            if (col < n)
                TryGo(ref num, row , col + 1, m, n);
        }

         //dp  走到某个格子的走法 =走到左边格子的走法 + 走到上面格子的走法
        public static int GetPathNumer_dp(int m, int n)
        {
            var dp = new int[m, n];
            if (m == 1 || n == 1)//这里意思 如果这有一行或者一列，肯定只有一个走法
            {
                return 1;
            }
            for (var row = 0; row < m; row++)
            {
                for (var col = 0; col < n; col++)
                {
                    if (row == 0 || col == 0) //这里意思 如果这有一行或者一列，肯定只有一个走法
                    {
                        dp[row, col] = 1;
                    }
                    else//竖着过来横着过来都行，取上一层的最大值
                    {
                        dp[row, col] = dp[row - 1, col] + dp[row, col - 1];
                    }
                }
            }
            return dp[m -1, n -1];
        }

        //只用一维度数组
        //思路就是j从1开始循环，因为第一列是1不会变
        //dp[X]的值 = dp[X] + dp[X-1]： dp[X-1]就是上一行当前列那个格子的值，dp[X]此时还代表了前一列当前行的值，还没被更新掉
        //按列扫秒，数组物尽其用。。。。
        public static int GetPathNumer_dp_d1(int m, int n)
        {
            if (m <= 0 || n <= 0)
                return 0;
            var dp = new int[n];
            dp[0] = 1;
            for (int i = 0; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    dp[j] += dp[j - 1];
                }
            }
            return dp[n - 1];
        }

        //不管怎么走，一共走n步，随便怎么走都可以，顺序无关，所以组合问题

        //数学公式法，排列组合 https://jingyan.baidu.com/article/63acb44ac60d4e61fcc17e2e.html
        //从m+n-2中取出 m-1个的组合
        //排列 6个里取4个排列 分母 6!  分子 (6-4)!  Anm= n!/(n-m)!
        //组合 6个里取4个组合 A64/4!   Cnm= Anm/m!


        #region  有障碍物的情况
        //坐标00有机器人，没有障碍吧
        public static int GetPathNumerWithObstacles_dp_d1(int[,] arr)
        {
            var x = arr.GetLength(0);
            var y = arr.GetLength(1);
            var dp = new int[arr.GetLength(1)]; //列数
            dp[0] = 1;
            for (var i = 0; i < x; i++)
            {
                for (var j = 0; j < y; j++)
                {
                    if (arr[i, j] == 1)
                    {
                        dp[j] = 0;
                        continue;
                    }
                        
                    if(j >0) //j=0的时候，如果有障碍就是0，如果没障碍，上一层的1还在
                        dp[j] += dp[j - 1];
                }
            }

            return dp[arr.GetLength(1) - 1];
        }
        #endregion
    }
}
