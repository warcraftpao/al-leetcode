using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.DP
{
    public class Triangle
    {
        public static int GetMax(int[,] triangle)
        {
            var maxArr = new int[triangle.GetLength(1)];
            for (var x = triangle.GetLength(1) -1; x >= 0; x--)//最后一行开始循环
            {
                for (var j = 0; j <= x; j++)//列从投开始循环
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
