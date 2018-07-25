using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Easy
{
    public class LengthOfLastWord
    {
        //看别人的意思是最后可以有空格的
        public static int Calc(string s)
        {
            var len = 0;
            var i = s.Length - 1;
            while (i >= 0 && s[i] == ' ')
            {
                i--;
            }
            while (i >= 0 && s[i] != ' ')
            {
                i--;
                len++;
            }
            return len;
        }
    }
}
