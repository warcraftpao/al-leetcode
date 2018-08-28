using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.DP
{
    //这是自己学动态规划时候做的，是给定三角形，求路径经过格子的数字之和的最大值
    public class Triangle
    {
        public static int GetMax(int[,] triangle)
        {
            var maxArr = new int[triangle.GetLength(1)];
            for (var x = triangle.GetLength(1) -1; x >= 0; x--)//最后一行开始循环
            {
                for (var j = 0; j <= x; j++)//列从头开始循环
                {
                    if (x == triangle.GetLength(1) - 1)//最后一行
                        maxArr[j] = triangle[x, j];
                    else//当前格子的值+ 下一行两个格子maxArr的最大值
                        maxArr[j] = triangle[x, j] + Math.Max(maxArr[j], maxArr[j + 1]);
                }
            }

            return maxArr[0];
        }
 
    }
}
