using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Middle
{
    public class ProductofArrayExceptSelf
    {
        public static int[] Calc(int[] nums)
        {
            //思路 申请一个长度一样的数组
            //初始化法方式第一个数字初始化为1，第二个数字= f1 第三个数组= f1*f2
            //第n个数字是 f1*f2 ----- fn-2* fn-1
            // 然后再反向算一下

            var res = new int[nums.Length ];
            res[0] = 1;
            for (var i = 1; i <= nums.Length -1; i++)
            {
                res[i] = res[i - 1] * nums[i - 1];
            }

            //现在res[i]代表 i之前的数字的积，right代表i之后的数字的积
            var right = 1;
            for (var i = nums.Length - 1; i >= 0; i--)
            {
                res[i] = res[ i ]*right;
                right = right*nums[i];
            }

            return res;
        }
    }
}
