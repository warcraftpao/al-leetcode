using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Middle
{
    public class OneEditDistance
    {
        //if 2 string is one edit distance
        //there are 3 sinarios,
        //1: length diff>1 false
        //2: the length is same and each position only 1 char is different true，otherwise false
        //3: the lenght diff is 1, the longer string remove 1 char will change to shorter string.
        //s1 is easy。 s2 ： compare each position is same ,all same or the second difference means false.
        //s3:compare each position, if find  difference,then the longer string's left(not contain current char) part should equal the short string's left part

        //强烈注意坑爹的地方，既然是一步编辑，所以相同和2步都是不对的！
        public static bool IsOneEdit(string a, string b)
        {
            var len1 = a.Length;
            var len2 = b.Length;
            var diff = Math.Abs(len1 - len2);
            if (diff > 1)
                return false;

            if (diff == 0)
            {
                var count = 0;
                for (var i = 0; i < len1; i++)
                {
                    if (a[i] != b[i])
                    {
                        count++;
                    }
                }
                return count == 1;
            }

            //diff ==1的情况
            for (var i = 0; i < Math.Min(len1, len2) ; i++)
            {
                if (a[i] != b[i])
                {
                    if (len1 > len2)
                        return a.Substring(i + 1) == b.Substring(i);
                    else
                        return b.Substring(i + 1) == a.Substring(i);
                }
                
            }
            return true;
        }
    }
}
