using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Leetcode.Middle
{
    public  class CompareVersionNumbers
    {
       
        // Version strings are composed of numeric strings separated by dots.and this numeric strings may have leading zeroes.

        //Version strings do not start or end with dots, and they will not be two consecutive dots.

        public static int Compare(string v1, string v2)
        {
            var l1 = v1.Split('.');
            var l2 = v2.Split('.');
            var exp = "^0*";//去掉开头的0
            var reg= new Regex(exp);
            var min = Math.Min(l1.Length, l2.Length);
            for (var i = 0; i < min; i++)
            {
                int s1;
                int s2;
                int.TryParse(reg.Replace(l1[i], ""), out s1);
                int.TryParse(reg.Replace(l2[i], ""), out s2);
                if (s1 > s2)
                    return 1;
                if (s1 < s2)
                    return -1;

                //相等继续往下走
            }

            //要判断有一个版本号长的情况，但是要都是0的话，等于无效
            string[] left;
            if (l1.Length == l2.Length)
                return 0;
            else if (l1.Length > l2.Length)
            {
                for (var i = min; i < l1.Length; i++)
                {
                    var s1 = reg.Replace(l1[i], "");
                    if (s1 != "")
                        return 1;
                }
                return 0;
            }
            else
            {
                for (var i = min; i < l2.Length; i++)
                {
                    var s1 = reg.Replace(l2[i], "");
                    if (s1 != "")
                        return -1;
                }
                return 0;
            }

            
        }

         
    }
}
