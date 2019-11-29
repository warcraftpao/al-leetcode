using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leetcode.BinaryTree;

namespace Leetcode.Hard
{
    /// <summary>
    /// 1到n里 1出现的次数
    /// </summary>
    public class NumberofDigitOne
    {
        /// <summary>
        /// 找规律 
        /// 20555 21555 22555为例 三种情况
        /// 比方我找千位数1的个数，每个10000里出现1000个1（ x1000 到x1999 有1000个数字）， 2xxxx/10000*1000=2000, 至少有2000个1
        /// 难点在于多出来的那些零头 
        /// 当千位数正好是0的时候 20555，说明20000 以后没有更多的千位数是1的数字出来 
        /// 当千位数正好是1的时候 21555，说明20000 以后多了几个千位数是1的数字出来，具体数字是555个
        /// 当前位数>1的时候，22555，说明20000后出来了1000个千位数是1的数字，和30000没区别了
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int Calc(int i)
        {
            //当前找个位数，需要/10
            //比如四位数，分别除以 1 10 100 1000的时候还有商，除以10000的时候商就是0了
            var count = 0;
            var factor = 1;
            while (i/factor > 0)
            {
                //假设计算百位有几个1 factor =100
                //12345  求百位数  12345 / 100=123， 123mod 100=3
                var curr = i / factor % 10;

                //12345  求有几个1000  12345/1000 =12  
                var high = i/(factor*10) ;
                
                //12345  求更低位- 12345%100 = 45
                var low = i % factor;

                if (curr == 0)
                {
                    count = count + high*factor;
                }
                else if(curr == 1)
                {
                    // 21555 ： 21000到21555有 556个数字
                    count = count + high*factor + low + 1;
                }
                else
                {
                    count = count + (high +1) * factor;
                }

                factor = factor*10;
            }

            return count;
        }

        /// <summary>
        /// 复制到方法只是为了相互验证
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static long Calc_copyway(int n)
        {
            long res = 0;
            for (long k = 1; k <= n; k *= 10)
            {
                long r = n / k, m = n % k;
                res += (r + 8) / 10 * k + (r % 10 == 1 ? m + 1 : 0);
            }
            return res;
        }
    }
}
