using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Middle
{
    public  class LargestNumber 
    {
        
        public static string GetLargest(int[] arr)
        {
            var list = arr.OrderByDescending(l => l.ToString(), new NumberCombineCompare());
            return string.Join("", list);
        } 
    }

    public class NumberCombineCompare : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return string.CompareOrdinal($"{x}{y}", $"{y}{x}");
        }
    }
}
