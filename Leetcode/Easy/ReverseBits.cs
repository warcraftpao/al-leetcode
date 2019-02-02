using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Easy
{
    public class ReverseBits
    {
        //1010111  变成 1110101
        //uint 0--2的32次方
        //题目说的32位是指uint最长用32个bit表示，c#无法直接表达二进制的，所以还是用的10进制来做参数和返回值的，只不过题目解释的时候用的二进制的展示
        public static uint Reserve(uint num)
        {
            //结果从0开始每次左位移1位，空出一个0（第一次0位移1位还是0）
            //原来的值每次和1 & 取出最低位和结果 |，最后原来的值向右位移1位
            uint result = 0;
            for (var i = 1; i <= 32; i++)
            {
                result = result << 1;
                result = result | (num & 1);
                num = num  >> 1;
            }
             
            return result;
        }

       
    }
}
