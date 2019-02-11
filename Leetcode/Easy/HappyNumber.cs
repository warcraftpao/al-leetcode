using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Easy
{
    public class HappyNumber
    {
        public static bool IsHappy(int n)
        {
            var list =new List<int>();
            while(true)
            {
                var sum = 0;
                while (n > 0)
                {
                    var number = n%10;
                    sum += number*number;
                    n = n/10;
                }

                if (sum == 1)
                    return true;

                if (list.Contains(sum))
                    return false;
                else
                    list.Add(sum);
                
                n = sum;
            }
        }
    }
}
