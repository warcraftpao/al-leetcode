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
    }
}
