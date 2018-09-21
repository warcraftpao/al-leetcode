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


        //求分割成回文列表，最小切割数
        //抄的算法，自己写写思路
        public static int Partition_mincuts(string s)
        {
            var length = s.Length;
             //0和1肯定不能切
            if (length == 0 || length == 1)
                return 0;

            //isPalindrome[i,j]代表从第i个字符到j个字符形成了回文
            var isPalindrome = new bool[length, length];
            //cuts[i]代表了 从第i个字符到length-1字符串切成回文子字符串要的最小次数
            var cuts = new int[length];

            //从后往前扫描
            for (var i = length - 1; i >= 0; i--)
            {
                //因为单个字符自己是回文，所以当前字母到结尾有几个字符就最多是几种切法（每个字母切一下）
                cuts[i] = length - i - 1;
                //j逐渐变大
                for (var j = i; j < length; j++)
                {
                    //回文数组默认都是false，所以两重循环的判定，可以保证任意s[i]~s[j] （i<=j)是否是回文的情况都判定过了
                    //如果s[i] == s[j]，再满足任意一种情况i到j是回文，i和j间距小于2（只有2个字符或者3个字符） 或者 i前进1，j后退1的字符串本身也是回文
                    if (s[i] == s[j] && (j - i < 2 || isPalindrome[i + 1,j - 1]))
                    {
                        isPalindrome[i,j] = true;
                        //j是最后一个字符，那么肯定i到结尾不需要切（i到结尾整个是一个回文）
                        if (j == length - 1)
                            cuts[i] = 0;
                        //i-j是回文，那么i到j就不提供更多的切法（从j位置切断），看看第j+1个字符到结尾有几种切法？
                        //因为一开始cuts数组都是写入的最大可能切法数，所以到j位置切一刀（提供+1切法）+cuts[j+1]和当前cuts[i]取较小的更新cuts[i]
                        //随着j在增大，如果i-j继续能形成回文，cuts[j]本身在变小，cuts[i]会可能减小
                        else if (cuts[j + 1] + 1 < cuts[i])
                            cuts[i] = cuts[j + 1] + 1;
                    }
                }
            }

            return cuts[0];
        }



        //求分割成回文列表，最小切割数
        //抄的算法，自己写写思路
        //换成从头循环的玩玩看
        public static int Partition_mincuts_fromheadtoend(string s)
        {
            var length = s.Length;
            if (length == 0 || length == 1)
                return 0;

            //isPalindrome[i,j]代表从第i个字符到j个字符形成了回文
            var isPalindrome = new bool[length, length];
            //cuts[i]代表了 从第0个字符到i-1字符串切成回文子字符串要的最小次数
            var cuts = new int[length];
            //反向的思路，i主键变大，j随着i逐渐变小
            //所以每次小循环依的isPalindrome数组的j在增加（小循环j在减小），大循环依赖的isPalindrome的i在缩小（大循环本身i在增加），
            //换言之，每次i在扩张的时候，所以来的isPalindrome数组在之前的循环里肯定判定过了 
            //然后随着j在缩小，如果j-i继续能形成回文，cuts[j]本身在变小，cuts[i]会可能减小
            for (var i = 0; i < length; i++)
            {
                cuts[i] = i;
                for (var j = i; j >=0; j--)
                {
                    if (s[i] == s[j] && (i - j < 2 || isPalindrome[j + 1, i - 1]))
                    {
                        isPalindrome[j, i] = true;
                        if (j == 0)
                            cuts[i] = 0;
                        else if (cuts[j - 1] + 1 < cuts[i])
                            cuts[i] = cuts[j - 1] + 1;
                    }
                }
            }

            return cuts[length -1];
        }
    }
}
