using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Matrix
{
    public class MaximalSquare
    {
        //https://blog.csdn.net/lym940928/article/details/90021526
        //题目标签是动态规划
        //思路基本是这样的，dp[i,j]代表以点[i,j]为右下顶点的正方形的最大边长（当然看着有些别扭，边长可能是0。。。。不存在正方形）
        //最左上顶点和最上的一条边和最左的一条边最多只能有边长是1的正方形
        //dp[i,j]依赖 dp[i,j-1], dp[i-1,j],dp[i-1,j-1],
        //反证：  假设 点[i j]衍生出了更大的正方形，设长度是n，那么以 [i,j-1], [i-1,j],[i-1,j-1]为右下顶点的正方形都必须长度达到n-1 
        //正面表达就是，点[i j]=1的时候，dp[i,j] = dp[i,j-1], dp[i-1,j],dp[i-1,j-1]中的最小值 +1 
        public static int Calc(char[,] matrix)
        {
            var dp = new int[matrix.GetLength(0), matrix.GetLength(1)];
            var max = 0;
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == '1')
                    {
                        if (i == 0 || j == 0)
                        {
                            dp[i, j] = 1;
                        }
                        else
                        {
                            dp[i, j] = Math.Min(dp[i, j - 1], Math.Min(dp[i - 1, j], dp[i - 1, j - 1])) + 1;
                            max = Math.Max(max, dp[i, j]);
                        }
                    }
                }
            }
            return max * max;
        }
    }

}
