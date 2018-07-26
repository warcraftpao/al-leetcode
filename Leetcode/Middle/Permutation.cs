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
        /// arr本身不重复
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
        //arr本身不重复
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

            for (var i = 0; i < arr.Length ; i++)
            {
                if (used[i] == false)
                {
                    used[i] = true;
                    curr.Add(arr[i]);
                    GenerateAll_S2(results, arr, used, curr);
                    used[i] = false;
                    curr.RemoveAt(curr.Count - 1);
                }
            }
        }

        #region 所给的数字本身可能重复，但是结果集要唯一

        public static List<List<int>> GenerateAllWithDupulicatedArr(int[] arr)
        {
            //常规操作，有重复先排序
            Array.Sort(arr);
            var list = new List<List<int>>();
            GenerateAll_d(list, arr, 0);
            return list;
        }


        private static void GenerateAll_d(List<List<int>> results, int[] arr, int index)
        {
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

            for (var i = index; i < arr.Length; i++)
            {
                if (i == index || !FindDuplicate(arr, index, i, arr[i])) //index开始到当前元素之前，和当前元素有重复否？，看链接，因为元素交换即使排序也没用，必须每次在当前情况下查找重复
                                                                         //这个时候比较笨的used=false true好像更容易理解，和前面数字相同且前面数字被用过就88了
                {
                    Swap(arr, i, index);
                    GenerateAll_d(results, arr, index + 1);
                    Swap(arr, i, index);
                }
            }
        }
        //https://www.cnblogs.com/TenosDoIt/p/3662644.html  精华
        //从数组的[start,end）范围内寻找元素target
        private static bool FindDuplicate(int[] arr, int start, int end, int target)
        {
            for (int i = start; i < end; i++)
                if (arr[i] == target)
                    return true;
            return false;
        }

        #endregion

        #region n!第k个排列组合

        //题目说n最大9 最大n阶乘， 这里用backtracing解
        public static string GetKthPermutation(int n, int k)
        {
            int count = 0;
            var arr = new int[n];
            for (var i = 0; i <  n; i++)
            {
                arr[i] = i + 1;
            }
            string result = "";
            KthPermutation(ref count, arr, 0, ref result, k);
            return result;
        }

        private static void KthPermutation(ref int count, int[] arr, int index, ref string result, int k)
        {
            //循环到最后一个数字的时候加入结果集
            if (arr.Length - 1 == index)
            {
                count++;
                if (count == k)
                {
                    var tmp = new List<int>();
                    for (var i = 0; i < arr.Length; i++)
                    {
                        tmp.Add(arr[i]);
                    }
                    result= string.Join("", tmp);
                    return;
                }
               
            }
           
            for (var i = index; i < arr.Length; i++)
            {
                Swap(arr, i, index);
                KthPermutation(ref count, arr, index + 1, ref result, k);
                Swap(arr, i, index);
            }

        }


        //第二个方式，数学找规律。。。。无需backtracing 
        //n个数字，第一位上每个数字出现的次数是(n-1)! 那么 k / (n-1)！= 第一个数字的index值
        // k % (n-1)!  变为新的k的（既然到了第二位，前面肯定用掉了诺干个 n-1阶乘的组合次数，取余数就可以了）
        public static string GetKthPermutationByRule(int n, int k)
        {
            //注意下标问题，可以理解为1到fact个组合对应数字1 fact+1 到2*fact对应数字2，但是数组下标要减1，正好第fact* n个时候下标越界
            //所以k-1 就变成0到fact-1 对应到数字0，
            k--;
            var fact = 1;
            //n-1的阶乘
            for (var i = n -1; i >= 2; i--)
            {
                fact = fact* i;
            }
            var digits = new List<int>();
            var result = "";
            for (var i = 1; i <= n; i++)
            {
                digits.Add(i);
            }
            var times = n - 1;
            while (times>= 0)
            {
                var index = k/fact;
                result += digits[index];
                digits.RemoveAt(index);
                k = k%fact;
                if (times != 0)
                    fact = fact/ times;
                times--;
            }
            return result;
        }

        #endregion
    }
}
