using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Hard
{
    public class ScrambleString
    {
        // 既然是用各种方式拆成二叉树，那么总归要先切一刀
        //然后还可以交换位置，那么可以2个字符串的前后段分别继续比较IsScramble，或者前后交叉比较IsScramble
        //那么子节点本身还是递归调用IsScramble
        //最初一次分割的左右子树的值，再怎么交换，不会穿插在隔壁子树的子串里
        public static bool IsScramble(string s1, string s2)
        {
            //先判定长度
            if (s1.Length != s2.Length)
                return false;
            //相等返回true;
            if (s1 == s2) return true;

            var str1 = SortString(s1);
            var str2 = SortString(s2);
            //ScrambleString排序后肯定是相同的字符串！但是相同不一定是ScrambleString
            if (str1 != str2) return false;

            var len = s1.Length;
            //注意从第一位后开始切，从0开始切没意义。
            for (var i = 1; i < len; i++)
            {
                var s11 = s1.Substring(0, i);
                var s12 = s1.Substring(i);
                var s21 = s2.Substring(0, i);
                var s22 = s2.Substring(i);
                if (IsScramble(s11, s21) && IsScramble(s12, s22)) return true;
                //s2从后面算i位切
                s21 = s2.Substring(len - i);
                s22 = s2.Substring(0, len - i);
                if (IsScramble(s11, s21) && IsScramble(s12, s22)) return true;
            }
            return false;
        }


        //字符串自己排序
        private static string SortString(string input)
        {
            var characters = input.ToArray();
            Array.Sort(characters);
            return new string(characters);
        }
    }


    
}
