using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.CommonTools
{
    public class MyMath
    {
        // greatest common divisor 最大公约数
        public static int GetGcd(int x, int y)
        {
            return (y == 0) ? x : GetGcd(y, x % y);
        }
    }
}
