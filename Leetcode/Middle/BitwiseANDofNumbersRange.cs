using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Middle
{
    public class BitwiseANDofNumbersRange
    {
       
        // 0 <= m <= n <= 2147483647
        // 这种题完全就是是找数学规律了，总结别人的思路与就是一串连续的数字的二进制
        //越是低位肯定不相同，比如只要mn不相同，连续2个数字中必然一个奇数一个偶数，最低位则有一个0和一个1，与的结果是0，而且变化总是总最低位开始累加变化的 
        //最终规律是这些连续数字只有在最高位才可能出现连续相同的位（mn都在2的 x到x+1次幂之内）（当然也可能没有，比如2到100，那不用想2从第二位开始都是0）
        //m n同时向右位移，直到mn相同
        public static int Calc(int m, int n)
        {
            var i = 0;
            while (m != n)
            {
                m >>= 1;
                n >>= 1;
                ++i;
            }
            return m << i;
        }
    }
}
