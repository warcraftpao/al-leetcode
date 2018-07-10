using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Middle
{
    public class DivideTwoIntegers
    {
        //-2147483648,2147483647
        //注意int负的时候绝对值比正数大1，要注意负数最小值除以-1的时候会溢出。。。
        //代码没加判断

        //这种方法性能不行，比如intmax 除以 1要运行 intmax次
        public static int S1(int dividend, int divisor)
        {
            //divisor wont be 0;
            if (dividend == 0)
            {
                return 0;
            }
            var isdividendPositive = 1;
            var isDivisorPositive = 1;
            if (dividend < 0)
            {
                isdividendPositive = -1;
                dividend *= -1;
            }


            if (divisor < 0)
            {
                isDivisorPositive = -1;
                divisor *= -1;
            }

            var ret = 0;
            while (dividend - divisor >= 0)
            {
                dividend = dividend - divisor;
                ret++;
            }

            return ret*isDivisorPositive*isdividendPositive;
        }

        //s2用位移做，如果除数小于被除数，那么就不停将除数向左位移（*2），如果位移2次，还小于除数，但是第三次位移大于除数，那结果就是4

        public static int S2(int dividend, int divisor)
        {
            //divisor wont be 0;
            if (dividend == 0)
            {
                return 0;
            }
            var isdividendPositive = 1;
            var isDivisorPositive = 1;
            if (dividend < 0)
            {
                isdividendPositive = -1;
                dividend *= -1;
            }


            if (divisor < 0)
            {
                isDivisorPositive = -1;
                divisor *= -1;
            }

            var ret = 0;
            while (dividend >= divisor)
            {
                var bitOptimes = 1;
                var divisorSum = divisor;
                while (dividend >= divisorSum)
                {
                    bitOptimes <<= 1;
                    divisorSum <<= 1;
                }
                //循环结束，总是多做一个操作了
                dividend = dividend - ( divisorSum >> 1);  //注意运算符优先级
                ret = ret + (bitOptimes >> 1);
            }

            return ret * isDivisorPositive * isdividendPositive;
        }
    }
}
