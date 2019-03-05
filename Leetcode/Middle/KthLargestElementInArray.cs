using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Middle
{
    //肯定使用排序做的，看网上的思路就是快速排序最适合
    //但是因为只要第k大数字，所以不需要全部排序完成
    //快排的精华在于每次大循环结束，找出一个中间点，前半部分都比它小，后半部分都比它大（这次要反一反，因为是找第k大，当然要是找第length-k 小的数字也可以）
    //那么原来每次快速排序大循环结束后，看看中间点的序号是不是k，是k返回，大于k说明k左边的还需要继续排序，小于k则左边继续排序（好像有带点2分），不需要分治了
    public   class KthLargestElementInArray
    {
        public static int Get(int[] arr , int k)
        {
            var left = 0;
            var right = arr.Length - 1;
            while (true)
            {
                var p = GetPivot(arr, left, right);
                if (p  == k- 1) return arr[p];// 第二大元素下标是1
                else if (p > k - 1) right = p - 1;
                else left = p + 1;
            }
        }

        //网上的例子是从小到大排，我这里是从大往小排，但只要算法思路是pivot取数组第一个元素，排序方式就不变（除非变成是用最后一个元素做pivot）
        //先保证high总是指向比pivot大，当low遇上high之后，他们总是可以和第一个元素交换
        //极端情况high直接移动到了第一个元素(pivot和自己交换），或者low直接移动到了末尾（pivot搬到了末尾）说明快速排序是不稳定的
        public  static int GetPivot(int[] arr, int low, int high)
        {
            var pivotIndex = low;
            var pivot = arr[low];
            //可能在某一次循环后low high相遇，有可能low大于high了
            while (low <  high)
            {
                while (arr[high] <= pivot && low < high)
                {
                    high--;
                }

                while (arr[low] >= pivot && low < high)
                {
                    low++;
                }

                

                if (low < high)
                {
                    Swap(arr, low  , high );
                }
            }

            
            Swap(arr, pivotIndex, high);
            return high;

        }
            
        private static void Swap(int[] arr, int x, int y)
        {
            var t = arr[x];
            arr[x] = arr[y];
            arr[y] = t;
        }
    }
}
