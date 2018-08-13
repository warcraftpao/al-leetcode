using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Middle
{
    public class RestoreIpAddresses
    {
        //注意看提，其实就一组ip地址。刚开始以为是非常长的一段字符串，里面包含诺干个IP地址的情况
        //既然就这么短，暴力求解也不难
        public static List<string> Restore(string s)
        {
            var results = new List<string>();
            Helper(results, 0, s, "");
            return results;
        }

        private static void Helper(List<string> results, int section, string s, string curr)
        {
            if (section == 4  )
            {
                //到第四段了必须结束，进入下一个循环，但是必须字符串被用完了才是解
                if (s.Length == 0)
                    results.Add(curr);
                //return; //写不写return只是效率差别
            }
                

            for (var i = 1; i <= 3; i++)//一个段最多3个数字
            {
                if (s.Length < i) break;
                int num;
                //当前段截取出来的数字合法小于2等于255才可以，而且注意，011回截取出来11也是不合法的
                if (int.TryParse(s.Substring(0, i), out num) && num <= 255 &&  i == num.ToString().Length)
                {
                    //段数+1，当前字符串前截掉i位，当前结果根据段数加上i位和点
                    Helper(results, section + 1, s.Substring(i), curr + s.Substring(0, i) + (section == 3 ? "" : "."));
                }
            }

        }
    }
}
