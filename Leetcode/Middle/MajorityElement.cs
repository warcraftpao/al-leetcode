using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Middle
{
    public class MajorityElement
    {

        //摩尔投票法 Moore Voting
        //设定一个计数器，循环数组，某个元素出现加+1 不出现减1，计数器再次变成零的时候，下一个元素成为候选元素
        //这样循环结束的时候当前候选元素一定是主要元素
        // 因为题意是说一定有主要元素，那么意味着当计数器清零，说明目前为止当前候选元素出现的次数和非候选元素平分秋色，他不够强大，完全可能被替代
        // 这样循环到最后，当前候选元素一定战胜了所有非候选元素之和，他就是主要元素


        //位操作法
        //因为题意是说一定有主要元素!!!! 一个整数转可以换成2进制，int的二进制最长32位
        //那么循环32次，大循环检查所有数字的某一位的值，因为主要元素一定存在，所以某位的0或者1出现次数不会相等，1出现的多 那主要元素的这个位必然是1，反之亦然。
        public static int Level1_BitCalc(int[] nums)
        {
            var res = 0;
            var n = nums.Length;
            for (var i = 0; i < 32; i++)
            {
                var ones = 0;
                var zeros = 0;
                foreach (int num in nums)
                {
                    if (ones > n/2 || zeros > n/2)
                        break;
                    //每次num和1 10 100 1000按位与，从最低位开始取得每一位的值
                    if ((num & (1 << i)) != 0)
                        ones++;
                    else
                        zeros++;
                }
                if (ones > zeros)
                    //每次和1，10，100 ，1000按位或，生成更高位的值
                    res |= 1 << i;
            }
            return res;
        }

        /// <summary>
        /// 找到数组里出现次数大于数组长度3分之1的数字
        /// 如果数组长度小于等于2，就没啥意义了
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static List<int> Level2(int[] nums)
        {
            //规定了时间复杂O（n） 空间O（1），所以只能用摩尔投票了
            //数学推论，超过3分之1的数字肯定不会超过2个， 所以思路是找出数量最多的2个数字，再检查他们出现次数是否大于三分之一
            //使用4个变量，2个记录数字，2个记录数字出现的次数，还是+1 -1的操作
            //每次出现次数归0的时候，说明记录的数字不够强大，可以被代替
            //这样投票结束后 这俩数字肯定是出现次数最多的2个，最后再验证他们是否出现了超过三分之一

            var num1 = 0; //其实等于任何数字都可以
            var num2 = 0;
            var count1 = 0; //计数器
            var count2 = 0;

            for (var i = 0; i < nums.Length; i++)
            {
                //当前数字等于num1后者num2的时候，另外一个数字的计数器不用-1，因为要找的数量排名前2的数字，即使某个数字只出现1次也可能是第二名多
                //所以只有当前数字不等num1和num2的时候，2个计数器才同时-1
                if (nums[i] == num1)
                {
                    count1 ++;
                }
                else if (nums[i] == num2)
                {
                    count2++;
                }
                else if (count1 == 0)
                {
                    num1 = nums[i];
                    count1=1;
                }
                else if (count2 == 0)
                {
                    num2 = nums[i];
                    count2 =1;
                }
                else
                {
                    count1--;
                    count2--;
                }
            }

            count1 = 0;
            count2 = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                if (nums[i] == num1)
                    count1++;
                else if (nums[i] == num2)
                    count2++;

            }

            var list = new List<int>();
            if (count1 > nums.Length/3) list.Add(num1);
            if (count2 > nums.Length/3) list.Add(num2);
            return list;
        }
    }
}
