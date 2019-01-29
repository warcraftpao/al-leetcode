using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Easy
{
    public class FactorialTrailingZeroes
    {
        //纯数学问题
        //1 只需要2的因子和5的因子数
        //2 但是5一定要比2少，所以只要统计5的数量
        //3 计算每个数是否能除尽5，没有余数一直除到有余数为止，计算因子5的数量
        //4 还能优化，比如100的阶乘，能除尽5的只有20个数，没问题。漏掉了25这个特殊情况（就是5的指数）
        //
        //
        public static int Count(int n)
        {
            var count = 0;
            while (n >= 5)
            {
                count = count + n/5; //n含有几个5
                //理解为一个数可以提供多个5的因子（25的倍数，125的倍数等）
                n = n/5; 
            }
            return count;
        }
    }
}
