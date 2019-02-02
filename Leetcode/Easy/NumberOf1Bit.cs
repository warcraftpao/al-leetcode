using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Easy
{
    public class NumberOf1Bit
    {
        public static int Count(uint num)
        {
            var count = 0;
            for (var i = 0; i < 32; i++)
            {
                count += (int) (num & 1);
                num = num >> 1;
            }

            return count;
        }
    }
}
