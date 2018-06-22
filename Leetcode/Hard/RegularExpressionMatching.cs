using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Hard
{
    public class RegularExpressionMatching
    {
        /// <summary>
        /// 看了答案后的思路
        /// 假设p不会以*开头。可以以.开头。
        /// s和p都至少1位，这些异常就不判断了
        /// </summary>
        public static bool IsMatch(string s, string p)
        {
            //劲量缩减p p越短越容易匹配s

            //p空，那s空才Ok
            if (p.Length == 0)
            {
                //就是递归到这里，大家字符串都为空才匹配
                return s.Length == 0;
            }

            //p长度1，肯定就是某个字符或者'.'
            if (p.Length == 1)
            {

                //s空，不匹配
                if (s.Length < 1)
                {
                    return false;
                }

                //s不等于p 且p不是. 不匹配
                if ((p[0] != s[0]) && (p[0] != '.'))
                {
                    return false;
                }

                //都截掉一个字符匹配呗
                return IsMatch(s.Substring(1), p.Substring(1));
                
            }

            //以下p长度>=2的情况，因为可能包含通配符了
            //p的第二位不是通配符，其实和P=1的情况类似，递归目标就是能双方砍掉一个字符
            if (p[1] != '*')
            {
                //s空，不匹配
                if (s.Length < 1)
                {
                    return false;
                }
                //s不等于p 且p不是. 不匹配
                if ((p[0] != s[0]) && (p[0] != '.'))
                {
                    return false;
                }
                //都截掉一个字符匹配呗
                return IsMatch(s.Substring(1), p.Substring(1));
            }
            else
            {
                //假设p的第二位是通配符
                //假设通配符匹配0个字符的情况，即不移动s的递归，s1去匹配p后面的字符
                //倒过来思考，假设不停截掉2位最终不能匹配，那就需要移动s了
                //~~~ 不移动s 移动p
                if (IsMatch(s, p.Substring(2)))
                {
                    return true;
                }

                //通配符可以匹配1到多个字符的情况，在当前字符符合的情况下进行循环（循环去看当前s的下一个字符是否匹配通配符）
                //递归s往后移动1位，p移动2位跑
                int i = 0;
                while (i < s.Length && (s[i] == p[0] || p[0] == '.'))
                {
                    if (IsMatch(s.Substring(i + 1), p.Substring(2))) //~~~~移动s和p 判定双方的子串是否匹配
                    {
                        return true;
                    }
                    i++; //~~~移动s，不移动p
                }
                return false;
            }
        }
    }
}
