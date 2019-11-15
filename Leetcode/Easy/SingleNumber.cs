using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Easy
{
    public class SingleNumber1
    {
        public static int GetNumber_hashtable(int[] nums)
        {
            var dic =new HashSet<int>();
            for (var i = 0; i < nums.Length; i++)
            {
                if (dic.Contains(nums[i]))
                    dic.Remove(nums[i]);
                else
                    dic.Add(nums[i]);
            }
             
            return dic.First();
        }

        //异或操作 ，相同返回0，不同返回1
        //0和任何数异或返回任何数
        //1和任何数异或等于任何数取反
        //任何数和自己异或=0
        public static int GetNumber_bit(int[] nums)
        {
            var a = 0;
            //有相同的数字最终都变成0，0和唯一的数字异或=要求的数字
            foreach (var num in nums)
            {
                a = a ^ num;
            }
            return a;
        }
    }



    public class SingleNumber2
    {/// <summary>
    /// 每个数字出现3次。有一个不是
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
        public static int GetNumber(int[] nums)
        {
            var bits = new int[32];
            //循环数组里的所有数字
            for (var i = 1; i < nums.Length; i++)
            {
                //把单个数字当成2进制看待，先计算最低位，每次 >> 就是把一个高位移到最低位比较
                //数组0是二进制最低位的计数
                for (var j = 0; j < 32; j++)
                {
                    //和1按位与
                    //位移优先级大于按位与，注意&当成取地址的时候优先级比较高，此处不是
                    if ((nums[i] >> j & 1) == 1)
                    {
                        bits[j]++;
                    }
                }

                 
            }
            var result = 0;
            for (var j = 0; j < 32; j++)
            {
                //对3取余数，就是唯一的那个数字标识成2进制后，该位上的值（不是0就是1）
                //j在扩大的时候，说明在提取二进制更高位的0和1，所以需要左移操作
                result += bits[j] % 3 << j; //取余优先级大于位移
            }

            return result;
        }
    }
}
