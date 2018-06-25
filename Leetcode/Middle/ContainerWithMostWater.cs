using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Middle
{
    public class ContainerWithMostWater
    {
        //s= width *height, ，可以先取width的最大值 就是第一个和组后一个元素的下标值的差
        //当下标缩小的时候，高度更小的无需判定,即哪边的高度小，向中间前进。
        //不考虑数组空null这些情况
        public static int GetMax(int[] arr)
        {
            var max = 0;
            var i = 0;
            var j = arr.Length - 1;
            while (i < j)
            {
                var sum = (j - i)*Math.Max(arr[i], arr[j]);
                if (arr[i] > arr[j])
                    j--;
                else
                    i++;

                max = Math.Max(max, sum);
            }

            return max;
        }
    }
}
