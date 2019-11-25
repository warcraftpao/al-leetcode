using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Middle
{
    public class SummaryRanges
    {
        public static List<string> Build(int[] nums)
        {
            var summary= new List<string>();
            var temp = new List<int> { nums[0] };
             
            for (var i = 1; i < nums.Length; i++)
            { 
                //如果当前-前一个不等于1
                if(nums[i] - nums[i-1] != 1)
                {
                    if (temp.Count == 1)
                    {
                        summary.Add(temp[0].ToString());
                    }
                    else
                    {
                        summary.Add($"{temp[0]}->{temp.Last()}");
                    }
                    temp.Clear();
                    
                }
                temp.Add(nums[i]);
            }
            if (temp.Count == 1)
            {
                summary.Add(temp[0].ToString());
            }
            else
            {
                summary.Add($"{temp[0]}->{temp.Last()}");
            }
            return summary;
        }
    }
}
