using System;

namespace Leetcode.Area
{
    public class LargestRectangleInHistogram
    {
        public static int Find(int[] heights)
        {
            //假设我们能知道以某个坐标扩展出来的长方形面积，就能获结果
            //某个点向左右如何扩展。如果左右高度上升或者不变，则可以继续扩展。直到高度下降了,那么向左向右扩展思路是一样的
            // 现在需要用较小的复杂度，来求所有点向左扩展的极限
            //数组 left[] ，数组下标=点坐标，值=第一个比我小的值的下标
            //在计算下一个点的时候，可以重复利用前一个点的计算结果，下标可以直接跳到left[i-1]的值

            var left = new int[heights.Length];
            var right = new int[heights.Length];
            right[heights.Length - 1] = heights.Length;
            left[0] = -1;
            for (var i = 1; i < heights.Length; i++)
            {
                //和前一个柱子比较高度,如果失败这就是扩展的边界（不包含）
                var l = i - 1;
                //左边的柱子比我高，我还能向左扩展
                while (l >=  0 && heights[l] >= heights[i])
                {
                    l = left[l]; //至少能扩展到我前一个柱子的边界
                }
                left[i] = l;
            }

            for (var i = heights.Length - 2; i > 0; i--)
            {
                var r = i + 1;
                while (r < heights.Length && heights[r] >= heights[i])
                {
                    r = right[r];
                }
                right[i] = r;
            }

            var maxArea = 0;
            for (var i = 0; i < heights.Length; i++)
            {
                var width = right[i] - left[i] - 1;
                var area = width*heights[i];
                maxArea = Math.Max(area, maxArea);
            }

            return maxArea;
        }
    }
}
