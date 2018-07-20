using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Middle
{
    //数组无重复元素
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


        /// <summary>
        /// AllPermutations_S1 交换位置的方式比较清晰
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static List<List<int>> AllPermutations_S1(int[] arr)
        {
           var list = new List<List<int>>();
            GenerateAll_S1(list, arr, 0);
            return list;
        }

        private static void GenerateAll_S1(List<List<int>> results,  int[] arr, int index)
        {
            //循环到最后一个数字的时候加入结果集
            if (arr.Length - 1 == index)
            {
                var tmp = new List<int>();
                for (var i = 0; i < arr.Length; i++)
                {
                    tmp.Add(arr[i]);
                }
                results.Add(tmp);
                return;
            }

            //不停的交换数字；
            //思路就是大循环里，第一轮每次把一个数字提到第一位（1和1交换，1和2交换，到1和n交换）
            //递归开始每次index+1,第一次递归说明第二个数字固定了，第二次递归说明第三个数字固定了
            //直到交换位置到最后了，加入结果集
            for (var i = index; i < arr.Length ; i++)
            {
                Swap(arr, i, index);
                GenerateAll_S1(results, arr, index + 1);
                Swap(arr,i, index);
            }
            
        }

        //s2的思路感觉很费时间，每次使用一个数字后，递归还是会循环所有数字尝试加入答案
        public static List<List<int>> AllPermutations_S2(int[] arr)
        {
            var used = new bool[arr.Length];
            var list = new List<List<int>>();
            var curr = new List<int>();
            GenerateAll_S2(list, arr, used, curr);
            return list;
        }

        private static void GenerateAll_S2(List<List<int>> results, int[] arr, bool[] used, List<int> curr)
        {
            if (curr.Count == arr.Length)
            {
                var tmp = new List<int>();
                for (var i = 0; i < curr.Count; i++)
                {
                    tmp.Add(curr[i]);
                }
                results.Add(tmp);
                return;
            }

            for (var i = 0; i < arr.Length - 1; i++)
            {
                if (used[i] == false)
                {
                    used[i] = true;
                    curr.Add(arr[i]);
                }
                GenerateAll_S2(results, arr, used, curr);
                used[i] = false;
                curr.RemoveAt(curr.Count -1);
            }
        }
    }
}
