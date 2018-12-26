using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Easy
{
    public class PalindromeNumber
    {
        public static bool Solution(int num)
        {
            //负数不是，整除10（0结尾）不是，0本身是。
            if (num < 0 ||( num % 10 == 0 && num != 0))
                return false;

            var numStr = num.ToString();
            var i = 0;
            var len = numStr.Length;
            while (i <= len/2)
            {
                if (numStr[i] != numStr[len - i -1])
                    return false;

                i++;
            }

            return true;
        }

        //这个不难，直接复制下来当一个解法
        public static bool IsPalindrome(int x)
        {
            // Special cases:
            // As discussed above, when X < 0, X is not a palindrome.
            // Also if the last digit of the number is 0, in order to be a palindrome,
            // the first digit of the number also needs to be 0.
            // Only 0 satisfy this property.
            if (x < 0 || (x % 10 == 0 && x != 0))
            {
                return false;
            }

            int revertedNumber = 0;
            while (x > revertedNumber)
            {
                revertedNumber = revertedNumber * 10 + x % 10;
                x /= 10;
            }

            // When the length is an odd number, we can get rid of the middle digit by revertedNumber/10
            // For example when the input is 12321, at the end of the while loop we get X = 12, revertedNumber = 123,
            // since the middle digit doesn't matter in palidrome(it will always equal to itself), we can simply get rid of it.
            //长度偶数123321最终变成x123=revert123
            //长度奇数1234321最终变成 x123 revert1234，revert多一位（中间那位去小数点了）
            //思路和ReverseInteger一样，先%取得个位数，还有循环就*10往上顶进位
            return x == revertedNumber || x == revertedNumber / 10;
        }
    }
}
