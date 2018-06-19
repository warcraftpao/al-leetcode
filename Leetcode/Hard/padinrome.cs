using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Hard
{
    public  class Palindrome
    {
        // https://blog.csdn.net/qq_39630587/article/details/79405536
        /// <summary>
        /// 所有特定都是基于某个回文点上左右是对称的，其左右内部的子串也是对称的
        /// 这个要仔细思考
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string LongestPalindrome(string input)
        {
            var s = ProcessString(input);
            var center = 0;//当前最大回文字符串的中心位置
            var right = 0;//当前最大回文字符串的右边界
            var len = new int[s.Length]; //某个字符的回文延伸半径，包含自身
            var maxLength = 0;
            var maxCenter = 0;
            for (var i = 1; i < s.Length ; i++)
            {
                //情况1 要判断的点在当前最大回文右边界的外边或者右边界上，长度肯定是1
                //请款2 要判断的点在当前最大回文右边界内或者边界上，那就是 对称点的回文半径 和 最大回文右边界减去当前点的位置 的较小值
                //情况3-1 因为如果对称点完全包含在最大回文内部的话（就是对称点的左边界大于最大回文的左边界)，那len[i]一定就是len[i-mirror]
                //情况3-2就是对称点的左边界=最大回文的左边界 我们只能判断出p[i] 至少有 最大回文右边界减去当前点的位置 那么大
                //情况3-3就是对称点的左边界<最大回文的左边界 可以同上考虑
                len[i] = right > i ? Math.Min(len[2 * center - i], right - i ) : 1;

                //从i+-len[i]的地方开始逐一比较，跳出条件是不匹配或者 +-len[]数组要超出索引了
                while (i-len[i] >= 0 &&  i+len[i] <  s.Length && s[i + len[i]] == s[i - len[i]]) len[i]++;
                if (i + len[i] -1  > right)//长度包含自己要-1, 长度是2才扩展到下一位嘛
                {
                    right = i + len[i] -1;
                    center = i;
                }
                if (maxLength < len[i])
                {
                    maxLength = len[i];
                    maxCenter = i;
                }
            }

            var rt = new StringBuilder();
            for (var k = maxCenter -maxLength +1; k < maxCenter + maxLength -1; k++)
            {
                if (k%2 == 0)
                {
                    rt.Append(s[k]);
                }
            }

            return rt.ToString();
        }

        private static string ProcessString(string input)
        {
            var sb = new StringBuilder("$#");
            foreach (var t in input)
            {
                sb.Append(t);
                sb.Append("#");
            }

            return sb.ToString();
        }
    }
}
