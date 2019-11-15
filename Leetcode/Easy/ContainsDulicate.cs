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
    }
}
