using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Easy
{
    public class CountAndSay
    {
        public static string BabySay(int n)
        {
            var result = "1";
            if (n == 1)
                return result;
            
            var i = 2;
            while (i <= n)
            {
                result = SayOnce(result);
                i++;
            }

            return result;
        }

        private static string SayOnce(string s)
        {
            s = s + "#";//最后加个星号，本来的最后一位肯定和他不同
            var result = "";
            var count = 1;
            for (var i = 0; i < s.Length -1; i++)
            {
                if (s[i] == s[i + 1])
                {
                    count++;
                }
                else
                {
                    result += count.ToString() + s[i]  ;
                    count = 1;
                }
            }
            return result;
        }
    }
}
