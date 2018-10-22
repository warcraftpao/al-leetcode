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
}
