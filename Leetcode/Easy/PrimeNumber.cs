using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Easy
{
    public class PrimeNumber
    {
        //剔除2的倍数，再剔除3的倍数，一次类推，但是只需要循环到根号n
        //As you can see, calculations of 4 × 3 and 6 × 2 are not necessary. 
        //Therefore, we only need to consider factors up to √n because, if n is divisible by some number p,
        // then n = p × q and since p ≤ q, we could derive that p ≤ √n.
        //意思就是大于根号n的数字，肯定在小于根号n数字的循环中作为较大因子使用掉了，不用再判断
        public static int Count(int n)
        {
            int res = 0;
            var prime = new bool[n];//c#默认是fasle
            for (var i = 2; i < n; ++i)
            {
                if (!prime[i])
                {
                    ++res;
                    for (int j = 2; i * j < n; ++j)
                    {
                        prime[i * j] = true;
                    }
                }
            }
            return res;
        }
    }
}
