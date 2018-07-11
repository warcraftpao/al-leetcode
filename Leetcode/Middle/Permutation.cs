using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Middle
{
    public class Permutation
    {
        //lexicographically ，比如“1，2，3”的全排列，依次是：
        //1 2 3
        //1 3 2
        //2 1 3
        //2 3 1
        //3 1 2
        //3 2 1
        //3 2 1的下一个就是 123

        //找到当前组合的下一个组合，就是只比当前组合大，如果到底，就返回最小值
        //从右向左查找，找到第一个降序的数字a[i]，然后找到这个数字右边仅比a[i]大的数字a[j],交换a[i] a[j]
        //因为a[i]右边的数字都是降序排列的，交换a[i] a[j]不会改变a[i]右边的大小顺序。所以再把a[i]右边数字反转就可以（改成升序）
        public static void NextPermutation(int[] arr)
        {
            var dePoint = -1;
            for (var i = arr.Length - 2; i >= 0; i--)
            {
                //找到了第一个降序的a[i]
                if (arr[i] < arr[i + 1])
                {
                    dePoint = i;
                    break;
                }
            }

            if (dePoint == -1)
            {
                Array.Reverse(arr);
                return;
            }

            var swap = 0;
            //从depoint的右边开始找
            for (var i = dePoint + 2; i <= arr.Length - 1; i++)
            {
                //找到了右边第一个比depoint小的，那他的左边那个肯定比depoint大
                if (arr[i] <= arr[dePoint])
                {
                    swap = i - 1;
                    break;
                }
                    
            }
            Swap(arr, dePoint, swap);
            ParReverse(arr, dePoint + 1);
        }

        private static void ParReverse(int[] nums, int start)
        {
            int i = start, j = nums.Length - 1;
            while (i < j)
            {
                Swap(nums, i, j);
                i++;
                j--;
            }
        }

        private static void Swap(int[] arr, int x, int y)
        {
            var temp = arr[x];
            arr[x] = arr[y];
            arr[y] = temp;
        }
    }
}
