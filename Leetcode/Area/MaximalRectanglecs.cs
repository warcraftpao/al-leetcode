using System;

namespace Leetcode.Area
{
    //Given a 2D binary matrix filled with 0's and 1's, find the largest rectangle containing only 1's and return its area.
    public class MaximalRectanglecs
    {
        //这题需要调用 LargestRectangleInHistogram
        //开始只有第一行，就是上一题的模型，有些高度是1，有些是0，此时可以算出一个最大面积
        //现在加入第二行，需要扩展每一列上的高度，是1高度+1，是0归0，why？ 本行单行最长会在本次计算，上一行的情况都已经考虑了
        //换言之，因为求的是长方形面积，再加入新行的时候，更扁更宽的长方形面积已经计算过了，本次需要扩展的是更高的情况
        public static int Find(int[,] matrix)
        {
            var heights = new int[matrix.GetLength(1)];
            var maxArea = 0;
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 1)
                        heights[j] = heights[j] + 1;
                    else
                        heights[j] = 0;
                }

                var area = LargestRectangleInHistogram.Find(heights);
                maxArea = Math.Max(area, maxArea);
            }

            return maxArea;
        }
    }
}
