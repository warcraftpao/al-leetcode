using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Easy
{
   public  class ContainsDulicate
    {
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
    }
}
