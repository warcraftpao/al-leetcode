using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leetcode.BinaryTree;

namespace Leetcode.Middle
{
    //Rotated就是数组被对着， 1234567，从3，4这里对折，变成5671234
    public class FindMinimumInRotatedSortedArray
    {

        //假设没有重复数字,不用考虑等于

        //这样的数组，从中间切一下，总有一部分是排序，一部分是还是乱的
        //先判断left<right，成立可以直接返回
        //如果left> right:那么得到mid，
        //如果left小于mid，说明左边是排序的，反转点在右边，所以最小值必然在右边；反之亦然
        public static int Level1(int[] arr)
        {
           
            var left = 0;
            var right = arr.Length - 1;

            while (left < right)
            {
                //特殊情况,某一段左边更小了，肯定可以返回
                if (arr[left] <= arr[right])
                    return arr[left];

                var mid = (left + right)/2;

                //剩下2个元素的时候，mid会等于left，但是旋转数组，必然是最大值贴着最小值的，除非是没有旋转的情况会被先排除也走不到这里
                //这时候right是最小值
                if (arr[left] <= arr[mid] )
                    left = mid + 1; //因为既然值比mid小，那说明mid肯定不是最小值。。。。
                else
                    right = mid;//舍弃右边的时候，因为mid是较小值，不能+1舍弃，看就是最小值
            }

            return arr[left];
        }
    }
}
