using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Middle
{
    public class PalindromePartitioning
    {
        public static List<List<string>> Partition(string s)
        {
            var result= new List<List<string>>();
            var curr=  new List<string>();
            Helper(result, s,  curr);
            return result;
        }

        private static void Helper(List<List<string>> result ,string s ,  List<string>  curr)
        {
          

            var len = s.Length;
            if (0 == len)
            {
                result.Add(new List<string>(curr));
                return; 
            }
            //必须是分组的，所以只能截取长度-1次
            for (var i = 0; i < len  ; i++)
            {
                var sub = s.Substring(0, i + 1 );
                if (IsPaldindrom(sub))
                {
                    curr.Add(sub);
                    Helper(result, s.Substring(i + 1),  curr);
                    curr.RemoveAt(curr.Count -1);
                }
            }
        }



        private static bool IsPaldindrom(string s)
        {
            var left = 0;
            var right = s.Length - 1;
            while (left < right)
            {
                if (s[left] != s[right])
                    return false;
                left++;
                right--;
            }
            return true;

        }
    }
}
