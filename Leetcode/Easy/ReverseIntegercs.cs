using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Easy
{
    //123==>321,-123==>-321,120==>21
    //限制返回是 负2的31次方~ 2的31次方-1
    //反转后超限返回0
    public class ReverseInteger
    {
        //最粗糙的思路肯定是像翻转字符串那样翻转整个int，然后记录位数什么每个位数*10相加之类的
        //精巧点就是每次循环开始后，反转的数字*10 再加当前的mod 10的值
        //反转数字*10 ：本次循环执行说明上次的数字进位了，需要*10
        //注意，其实不需要考虑正负号
        public static long Reverse(int i)
        {
            long reverse = 0;
            while (i != 0)
            {
                reverse = reverse*10 + i%10;
                if (reverse > int.MaxValue || reverse  < int.MinValue)
                    return 0;
                i /= 10;
            }

            return   reverse;
        }
         
    }
}
