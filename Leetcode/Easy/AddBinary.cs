using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Easy
{
    public class AddBinary
    {
        //输入字符串肯定是1和0了
        public static string Get(string a, string b)
        {
            var result = "";
            var alen = a.Length;
            var blen = b.Length;
            var carry = 0;

            //循环长的那个
            for (var i = Math.Max(alen, blen) - 1; i >= 0; i--)
            {
                var aa = 0;
                var bb = 0;
                if (alen - 1 >= 0)
                {
                    aa = a[alen - 1] - '0';
                }
                if (blen - 1 >= 0)
                {
                    bb = b[blen - 1] - '0';
                }
                alen--;
                blen--;

                var cc = aa + bb + carry;
                carry = cc/2;  //2和3需要进位，也不会出现4， 1和0不进位
                result = cc%2 + result; //余数就是当前位
            }

            return carry == 0 ? result : "1" + result;
        }
    }
}
