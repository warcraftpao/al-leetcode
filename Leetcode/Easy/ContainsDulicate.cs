using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Easy
{
   public  class ContainsDulicate
    {
        //包含重复值
       public static bool Level1(int[] nums)
       {
           var dic= new Dictionary<int, int>();
           foreach (var num in nums)
           {
               if (dic.ContainsKey(num))
                   return true;
               else 
                    dic.Add(num,1);
           }

           return false;
       }


        //包含重复值，且坐标差不超过给定值
        public static bool Level2(int[] nums, int k)
        {
            //value=某值第一次出现的坐标
            var dic = new Dictionary<int, int>();


            for (var i = 0; i < nums.Length; i++)
            {
                if (dic.ContainsKey(nums[i]) &&  (i -dic[nums[i]]) <= k)
                {
                    return true;
                }
                else
                {
                    if (dic.ContainsKey(nums[i]))
                        dic[nums[i]] = i;
                    else
                    {
                        dic.Add(nums[i], i);
                    }
                }
            }

            return false;
        }


        /// <summary>
        /// //k坐标差值，t是2个元素的差值绝对值上限
        ///在数组里，是否存在2个元素坐标差小于k且差值绝对值小于t
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k">坐标差</param>
        /// <param name="t">值差</param>
        /// <returns></returns>
        public static bool Level3(int[] nums, int k, int t)
        {
            //思路网上看的滑动窗口
            //2个指针 x保持不动，y前进，保持xy差值小于k，并且y前进的时候把元素加入排序集合（sortedSet)，并且判断当前集合是否有满足要求的结果
            //没有y继续前进，xy差值大于k的时候，x前进，并且队集合删掉坐标x的元素。

            //现在问题变为 集合里面是否有有一个值满足和当前元素差的绝对值小于t
            //找到当前集合里比x小的最大值，他们的差绝对值满足条件返回true(这个时候更小的值不用测试了）
            //找到当前集合里比x大的最小值，他们的差绝对值满足条件返回true(这个时候更大的值不用测试了）

            if (t < 0) return false; // 绝对值不会小于0
            if (k < 0) return false; //坐标差至少是1
            if (k > nums.Length -1) return false;//长度不可能超过数组长度-1 ，长度为4，差值最多为3

            //排序集合
            var set = new SortedSet<int>();
            //遍历数组
            for (var i = 0; i < nums.Length; i++)
            {
                var curr = nums[i];
                //包含这个元素差绝对值是0，肯定符合要求
                if (set.Contains(curr)) return true;

                //找到比当前元素小的最大值
                if (set.Any(s => s < curr))
                {
                    var small = set.Where(s => s < curr).Max();
                    if (Math.Abs(small - curr) < t)
                        return true;
                }

                //找到比当前元素大的最小值
                if (set.Any(s => s > curr))
                {
                    var big = set.Where(s => s  > curr).Min();
                    if (Math.Abs(big - curr) < t)
                        return true;
                }

                //当期元素加入集合
                set.Add(curr);

                //坐标差不超过k，说明最多允许k+1个连续元素一起比较
                //比如k=2 当坐标值是2的时候 （坐标值大于等于k），说明已经3个元素（第1，2，3个元素参）加过比较了，
                //下次循环的时候第一个元素用不到了（第i-k个元素删除，更早的肯定已经删除了）
                if (i >= k)
                {
                    set.Remove(nums[i - k]);
                }


            }

            return false;

        }


    }
}
