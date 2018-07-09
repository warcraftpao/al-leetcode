using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Easy
{
    public class RemoveDuplicates
    {
        public static int S1(int[] arr)
        {
            var len = 0;
            for (var i = 0; i < arr.Length; i++)
            {
                if (i == 0 || arr[i] != arr[i - 1])
                {
                    len++;
                }
                 
            }

            return len;
        }
    }
}
