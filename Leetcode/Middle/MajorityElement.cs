using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Middle
{
    public class MajorityElement
    {
        //public static int Get(int[] arr)
        //{

        //}

        //摩尔投票法 Moore Voting
        //设定一个计数器，循环数组，某个元素出现加+1 不出现减1，计数器再次变成零的时候，下一个元素成为候选元素
        //这样循环结束的时候当前候选元素一定是主要元素
        // 因为题意是说一定有主要元素，那么意味着当计数器清零，说明目前为止当前候选元素出现的次数和非候选元素平分秋色，他不够强大，完全可能被替代
        // 这样循环到最后，当前候选元素一定战胜了所有非候选元素之和，他就是主要元素


        //位操作法
        //因为题意是说一定有主要元素!!!! 一个整数转可以换成2进制，int的二进制最长32位
        //那么循环32次，大循环检查所有数字的某一位的值，因为主要元素一定存在，所以某位的0或者1出现次数不会相等，1出现的多 那主要元素的这个位必然是1，反之亦然。
        public static int BitCalc(int[] nums)
        {
            var res = 0;
            var n = nums.Length;
            for (var i = 0; i < 32; i++)
            {
                var ones = 0;
                var zeros = 0;
                foreach (int num in nums)
                {
                    if (ones > n / 2 || zeros > n / 2)
                        break;
                    //每次num和1 10 100 1000按位与，从最低位开始取得每一位的值
                    if ((num & (1 << i)) != 0)
                        ones++;
                    else
                        zeros++;
                }
                if (ones > zeros)
                    //每次和1，10，100 ，1000按位或，生成更高位的值
                    res |= 1 << i ;
            }
            return res;
        }
    }
}
