using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Hard
{
    public class ScrambleString
    {
        //大思路理解，既然是转换成二叉树再对调左右子树，并且可以不断的对调，可以转换成下面的情况
        //那么某一次分割，总是能任意分成2个左右子树 ，假设一次切割后形成了四个子字符串，子字符串s1右Scramble s2右且s1左Scramble s2左，或者左右交叉Scramble，那么就是符合要求的
        //那么子字符串所谓Scramble，肯定是该子串还能继续切分判定子串的子串是否Scramble，这就是递归的逻辑
        //主要难点在于题目描述是二叉树的形式，实际上是转换成了切割字符串并且递归
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


        //动态规划思路 网上学习的 
        //dp[i,j,len]  分别代表 s1和s2 从位置 i和j开始的取len长度是否为scumble（不同长度不用考虑一定是否）
        //先初始化，所有len=1的情况，因为单个字母可以直接判断
        //循环每次递增len的长度，len从2开始：即为比较2个字符串分别截取2位的情况下判定是否Scramble，最后len=字符串长度，就是解
        //那么如何判定长度2的子字符串是否Scramble
        //肯定是只能分解成2个长度为1的子字符串相互比较，但是所有长度位1的情况已经计算过了；同理计算长度为3的情况，只能切割位成长度1和2的子字符串的情况，之前也计算过了
        //判定Scramble思路是一样的，还是要切割字符串
        public static bool IsScramble_dp(string s1, string s2)
        {
            //先判定长度
            if (s1.Length != s2.Length)
                return false;
            //相等返回true;
            if (s1 == s2) return true;
            var len = s1.Length;
            //第三个维度+1只是为了对应起来方便，长度是0的情况用不到
            var dp = new bool[len, len, len + 1];
            //2个字符串任意1位取长度1是否是scrumble
            for (var i = 0; i < len; i++)
            {
                for (var j = 0; j < len; j++)
                {
                    dp[i, j, 1] = s1[i] == s2[j];
                }
            }

            //长度是2开始循环
            for (var size = 2; size <= len; size++)
            {
                //比如字符串长度是5（最大index是4），现在size=2，起始下标只能到3（3，4一组）
                for (var i = 0; i <= len - size; i++)
                {
                    for (var j = 0; j <= len - size; j++)
                    {
                         //比如当前size是5，最多只能切4次
                         //此时k是 i和j点到 i+size和j+size之前的切点，分别两两交换比较。
                        for (var cut = 1; cut < size; cut++)
                        {
                            //这里需要纸上画一下，容易明白，起点是i，总长度是size，中间有个点k，前半段起点是i，长度i+cut，后半段起点是i+cut，长度是size-cut
                            var isScramble = (dp[i, j, cut] && dp[i + cut, j + cut, size - cut]) //s1 s2前半段ok且后半段ok
                                       || (dp[i + cut, j, size - cut] && dp[i, j + size - cut, cut]);
                                       //s1的后半段和s2的前半段，长度是size-cut       s1的前半段和s2的后半段，长度是cut
                            dp[i,j,size] = isScramble;
                        }
                    }
                }
            }

            return dp[0, 0, len];
        }

    }

}
