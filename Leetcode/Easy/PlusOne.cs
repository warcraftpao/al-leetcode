using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Easy
{
    public  class PlusOne
    {
        //数组代表一个数字， 加1操作
        public static int[] Calc(int[] arr)
        {
            var carry = 1; //因为只加1 ，进位也是1
            for (var i = arr.Length - 1; i >= 0; i--)
            {
                if (carry == 0) break;

                var tmp = arr[i] + carry;
                if (tmp == 10) //+1最多等于10
                {
                    carry = 1;
                    arr[i] = 0;
                }
                else
                {
                    arr[i] = tmp;
                    carry = 0;
                }
            }

            if (carry == 0)
                return arr;

            var newArr = new int[arr.Length + 1];
            newArr[0] = 1;
            for (var i = 1; i < newArr.Length; i++)
            {
                newArr[i] = arr[i - 1];
            }
            return newArr;

        }
    }
}
