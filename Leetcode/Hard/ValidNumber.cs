using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Hard
{
    public class ValidNumber
    {
        //字符分为6个情况，空格，数字，e/E, 点, +/-号，其他字符
        //其他字符over，允许的字符每个单独处理，需要一堆标志位
        public static bool IsValid(string s)
        {
            //去空格，中间空格就是非法字符
            s = s.Trim();
            if (s.Length < 1)
                return false;

            //找到分割点，知道字符串不存在e，或者分割成2部分（也没e）
            //复杂度大幅降低
            var indexe = s.IndexOf("e");
            var indexE = s.IndexOf("E");

            var index = -1;
            if (indexe != -1)
            {
                index = indexe;//e分割
            }
            else if (indexE != -1)
            {
                index = indexE;//E 分割
            }

            if (index == -1)  //没有e
            {
                return Check(s, true);
            }
            //注意，e是不要的，所以e是第4个字符，index=3，前面从0开始截取3（0，1，2），后面从4开始截取（4开始）
            return Check(s.Substring(0, index), true) && Check(s.Substring(index + 1), false);
        }

        //有e的情况下，后半部分不能出现dot 只能有数字正负号
        //有e的情况下，前半部分可以出现dot 和数字正负号
        //没e的情况下，可以出现dot 和数字正负号
        private static bool Check(string s, bool allowDot)
        {
            bool numAppear = false;
            bool signAppear = false;
            bool dotAppear = false;

            for (var i = 0; i < s.Length; i++)
            {
                if (s[i] >= '0' && s[i] <= '9')
                {
                    //任何时候数字都可以出现
                    numAppear = true;
                }
                else if (s[i] == '+' || s[i] == '-') 
                {
                    //正负号必须最早出现
                    if (numAppear || signAppear || dotAppear)
                        return false;

                    signAppear = true;

                }
                else if (s[i] == '.')
                {
                    //不让出现点或者还没出现数字或者点是最后一个字符，over
                    if (allowDot == false || numAppear == false || i == s.Length -1)
                        return false;

                    dotAppear = true;
                }
                else//非法字符此时空格也是非法的
                {
                    return false;
                }
            }
            return true;
        }


    }
}
