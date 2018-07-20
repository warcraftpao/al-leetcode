using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Middle
{
    public class PowXy
    {
        //int最小值绝对值比in
        public static double Calc(double x, int y)
        {
            if (y == 0)
                return 1;

            if (y == 1)
            {
                return x;
            }
             
            if (y < 0)
            {
                return 1/Calc(x, -y);
            }

            var half = Calc(x, y/2); //这个地方注意，其实也就最第一次（从递归执行效果来看可以认为是最后一次返回的时候）可能执行到y%2有余数的情况
            //加入9次方，相当于拿到了4次方*4次方的值后，判断是不是要多乘一个x
            if (y%2 == 0)
                return half*half;
            return half*half*x;
        }
         
    }
}
