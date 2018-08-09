using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Middle
{
    public  class Combinations
    {
        //n个自然数里（1到n）取 k个数字的 组合, k<n
        public static List<List<int>> Generate(int n, int k)
        {
            var results = new List<List<int>>();
 
            var curr = new List<int>();
            Do(results, n, k, 1, curr);//注意从1开始，这里不是数组
            return results;
        }

        private static void Do(List<List<int>> results, int n, int k, int index, List<int> curr)
        {
            if (curr.Count == k)
            {
                var tmp = new List<int>();
                for(var i =0; i < k; i++)
                    tmp.Add(curr[i]);
                results.Add(tmp);
                return;
            }

            for (var i = index; i <= n; i++)
            {
                curr.Add(i);
                Do(results, n, k, i + 1, curr);
                //  curr.RemoveAt(curr.Count -1); 这两句效果一样
                curr.Remove(i);
            }
        }

        //求子集, arr值唯一
        public static List<List<int>> Subsets(int[] arr)
        {
            var results = new List<List<int>>();
            var curr = new List<int>();
            Do_Subsets(results,arr, curr, 0);
            return results;

        }

        private static void Do_Subsets(List<List<int>> results, int[] arr, List<int> curr, int index)
        {
            var tmp = new List<int>();
            for (var i = 0; i < curr.Count; i++)
                tmp.Add(curr[i]);
            results.Add(tmp);
            
            for (var i = index; i < arr.Length; i++)
            {
                curr.Add(arr[i]);
                Do_Subsets(results, arr, curr, i + 1);
                curr.RemoveAt(curr.Count -1);
            }
        }

        //一个元素在子集中要么出现要么不出现，所以一共2的n次方个子集，
        //子集中每个元素出现的位置就是一个二进制数表达，是1的位，这个数字出现，是0，就不出现
        public static List<List<int>> Subsets_S2(int[] arr)
        {
            var list = new List<List<int>>();
            var max = 1 << arr.Length;
            for (var i = 0; i < max; i++)
            {
                list.Add(GetListByInt(i, arr));
            }
            return list;
        }

        //从int得到一个二进制数，然后根据对应数组的位得到List<int>
        private static List<int> GetListByInt(int k, int[] arr)
        {
            var sub = new List<int>();
            int idx = 0;
            for (int i = k; i > 0; i >>= 1)//向左位移
            {
                if ((i & 1) == 1) // 1的二进制就是1 ，用k的最后一位去和1做&操作，是1就要当前元素，是0就不要
                {
                    sub.Add(arr[idx]);
                }
                ++idx;
            }
            return sub;
        }


        public static List<List<int>> SubsetsWithDuplicate(int[] arr)
        {
            Array.Sort(arr);
            var results = new List<List<int>>();
            var curr = new List<int>();
            Do_SubsetsWithDuplicate(results, arr, curr, 0);
            return results;
        }

        private static void Do_SubsetsWithDuplicate(List<List<int>> results, int[] arr, List<int> curr, int index)
        {
            var tmp = new List<int>();
            for (var i = 0; i < curr.Count; i++)
                tmp.Add(curr[i]);
            results.Add(tmp);

            for (var i = index; i < arr.Length; i++)
            {
                //if (i > 0 && arr[i] == arr[i - 1]) break;
                //不能写上面这句，单个结果里可以重复，只是结果集不允许重复

                curr.Add(arr[i]);
                Do_SubsetsWithDuplicate(results, arr, curr, i + 1);
                curr.RemoveAt(curr.Count - 1);
                while (i + 1 < arr.Length && arr[i] == arr[i + 1])
                    i++;
                //这里的思路有重复的数字可以进入递归，但是主循环里剔除重复数字
            }
        }

        //用在原有结果集上插入新元素的方法
        //增加第n个元素， n-1的结果集 和 n-1结果集每个后面加上加新元素 合并即可
        public static List<List<int>> SubsetsWithDuplicate_S2(int[] arr)
        {
            var results = new List<List<int>>();
            //增加第一个集合的情况
            results.Add(new List<int>());

            //上次添加了几个元素
            var lastAddNumber = 1;
            for (var i = 0; i < arr.Length; i++)
            {
                var count = results.Count;
                //和上一个元素相同，需要全部复制一次，否则上次循环添加了几个元素还是加几个
                if (i > 0 && arr[i] != arr[i - 1])
                    lastAddNumber = count;
               
                
                for (var j = count - lastAddNumber; j < count; j++)
                {
                    var tmp = new List<int>();
                    tmp.Add(arr[i]);
                    foreach (var k in results[j])
                    {
                        tmp.Add(k);
                    }
                    results.Add(tmp);
                }
            }

            return results;
        }
    }
}
