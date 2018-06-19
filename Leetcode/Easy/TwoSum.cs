using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Easy
{
    //Given an array of integers, return indices of the two numbers such that they add up to a specific target.
    //You may assume that each input would have exactly one solution, and you may not use the same element twice.
    //Given nums = [2, 7, 11, 15], target = 9,
    //Because nums[0] + nums[1] = 2 + 7 = 9,
    //return [0, 1].
    public class TwoSum
    {
        //最简单的2重循环
        public static int[] TwoSum1(int[] nums, int target)
        {
            for (var i = 0; i < nums.Length -1; i++)
            {
                for (var j = i + 1; j <= nums.Length-1; j++)
                {
                    if(nums[i]  + nums[j] == target)
                        return new [] { nums[i], nums[j] };
                }
            }

            throw new Exception("not matched");
        }

        //每次循环开始，把当前目标减去当前数字，得到的是需要"缺"的数字
        //用缺的数字当key加入字典表，比如目标12，当前是5，key=7
        //以后某次循环的数字是7的时候，发现字典里有值，那肯定之前有个成员值是5，那5和7一定是符合要求的
        //字典的value没用。
        public static int[] TwoSum2(int[] nums, int target)
        {
            var dic = new Dictionary<int,int>();
            foreach (var  i  in nums)
            {
                var left = target - i;
                int current;
                if (dic.TryGetValue(i, out current))
                {
                    return new[] { i, current };
                }
                dic.Add(left,i);
            }
            throw new Exception("not matched");
        }
    }
}
