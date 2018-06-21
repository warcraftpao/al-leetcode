using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Middle
{
    public class StringToInteger
    {
        //0 is 48;1 is 49;2 is 50;3 is 51;4 is 52;5 is 53;6 is 54;7 is 55;8 is 56;9 is 57;
        //0-9这些char 可以做减法得出是int类型

        //https://csharp.2000things.com/tag/integer-overflow/

        public static int Atoi(string input)
        {
            bool positive = true;
            //看看有几个空格？
            var i = 0;
            while (input[i] == ' ')
            {
                i++;
            }

            //看看whitespace后是否有负号
            if (input[i] == '-')
            {
                positive = false;
                i++;
            }
                
            long ret = 0;
            for (var j = i; j < input.Length; j++)
            {
                if (input[j] >= '0' && input[j] <= '9')
                {
                    //注意括号
                    ret = ret*10 + (input[j] - '0');
                    if (ret > int.MaxValue || ret < int.MinValue)
                        return 0;
                }
                else
                {
                    break;
                }
            }


             return (int)(positive ? ret :ret * -1);
        }


    }
}
