using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.NotUnderstandQuestion
{
    public  class GrayCode
    {
        //给一个数字n，长度是n的所有gray code序列，（注意格雷码是2进制样子的编码，但是大小不是二进制那么排列的）
        //n序列和n-1只能一个位（bit）不同
        public static List<int> GetNLengthGrayCode(int n)
        {
            // 位移 优先级比 异或 高
            //对应的二进制码i和i+1位相同，格雷码本位是0，否则是1
            //i>> 后，再和i异或，等于 当前位和下一位比较了；第一位总是1和0比较不会变
            var result = new List<int>();
            for (int i = 0; i < 1 << n; i++)
                result.Add(i ^ i >> 1);

            return result;
        }
    }
}
