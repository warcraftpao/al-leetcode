using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Middle
{
    public  class MaxGap
    {
        //这题因为时间复杂度的要求本质上是要排序。。。基数排序
        /// <summary>
        /// n代表最大位数是多少
        /// 原理就 个位 十位 百位 排序 
        /// 个位是1的有几个，2的有几个，把把数字复制回去，再排10位以此类推
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="n"></param>
        public static void RadixSort(int[] arr, int n)
        {
            //某次排序的时候，key代表0-9的数字，value代表一组数字
            var dic = new Dictionary<int, List<int>>();

            var radix = 1;

            //四位数就循环四次
            for (var i = 1; i <= n; i++)
            {
                //数字分配进桶
                for (var j = 0; j < arr.Length; j++)
                {
                    var index = (arr[j]/radix)%10;
                    if(dic.ContainsKey(index))
                        dic[index].Add(arr[j]);
                    else
                    {
                        dic.Add(index, new List<int> {arr[j]});
                    }
                }
                //桶里的数据复制回数组
                var count = 0;
                for (var k = 0; k <= 9; k++)
                {
                    if (dic.ContainsKey(k))
                    {
                        foreach (var num in dic[k])
                        {
                            arr[count] = num;
                            count ++;
                        }
                    }
                }
                dic.Clear();
                radix *= 10;
            }

        }


        public static int GetGap(int[] arr)
        {
            var max = 0;
            for (var i = 0; i < arr.Length; i++)
            {
                max = Math.Max(max, arr[i]);
            }
            var radix = 1;
            while (max /10 > 0)
            {
                max = max/10;
                radix++;
            }
            RadixSort(arr, radix);
            var gap = 0;
            for (var i = 1; i < arr.Length; i++)
            {
                gap = Math.Max(gap, Math.Abs(arr[i] - arr[i - 1]));
            }

            return gap;
        }
      
        
      
    }
}
