using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Hard
{
    //讲道理，这题能算hard。。。。
    public   class LongestConsecutiveSequence
    {
        public static int GetLength(int[] arr)
        {
            Array.Sort(arr);
            var longest = 1;
            var curr = 1;
            for (var i = 1; i < arr.Length; i++)
            {
                if (arr[i] == arr[i - 1])
                {
                    curr++;
                }
                else
                {
                    longest = Math.Max(longest, curr);
                    curr = 1;
                }
            }
            return longest;
        }
    }
}
