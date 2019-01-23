using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Middle
{
    public class MissingRanges
    {
        //arr已经排序，arr元素在lower
        //潜在要求：arr 的头大于等于lower arr的尾小于等于upper ，arr排序，lower小于upper
        //暂时不考虑int溢出？
        public static List<string> GetRanges(int[] arr, int lower, int upper)
        {
            var list = new List<string>();
            if (arr.Length == 0)
            {
                return new List<string> {BuildSingleMissingRange(lower, upper)};
            }
            var curr = lower;
            //每次先比较curr和当前值，然后更新curr值，最后判断是不是最后一个元素即可
            for (var i = 0; i < arr.Length; i++)
            {
                //差值至少大于2才缺失，因为只差1是连续存在的数字也就不缺失了
                if (arr[i] - curr> 1 )
                {
                    list.Add(BuildSingleMissingRange(curr + 1, arr[i] -1));
                   
                }
                curr = arr[i];
                //最后一个元素差upper2或者更大
                if (i == arr.Length - 1 && curr +1 <upper)
                {
                   list.Add( BuildSingleMissingRange(curr+1, upper));
                    
                }
            }

            return list;
        }


       //lower upper本身是缺失的
        private static string BuildSingleMissingRange(int lower, int upper)
        {
            if (lower == upper)
                return lower.ToString();

            return string.Format("{0}->{1}", lower, upper);
        }
    }
}
