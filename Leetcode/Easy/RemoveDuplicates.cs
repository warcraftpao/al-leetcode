using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Easy
{
    public class RemoveDuplicates
    {
        //数组是已经排序的！！！
        //理解有误，的确是返回int，但是数组本身还是要去除重复元素的
        //我估计意思就是数组长度是8，有3个重复，就返回长度5，保证前5个元素都是不重复的，后面的不管
        public static int RemoveDuplicatedInSortedArray(int[] arr)
        {
            if (arr.Length < 2)
                return arr.Length;


            var len = 1;// 长度至少是1，慢指针停在第二个元素上，先交换再加1
            for (var i = 1; i < arr.Length; i++)
            {
                //和上一个元素不相同，慢指针加1，值复制过来
                if (arr[i] != arr[i - 1])
                {
                    arr[len] = arr[i];
                    len++;
                }
            }

            return len;
        }


        //每个重复元素最多可以保留2个, 感觉像个通用方法
        public static int RemoveDuplicatedInSortedArray2(int[] arr)
        {
            if (arr.Length < 3)
                return arr.Length;

            var len = 2; // 长度至少是2，慢指针停在第三个元素上，先交换再加1
            for (var i = 2; i < arr.Length; i++)
            {
                if (arr[i] != arr[i - 2])
                {
                    arr[len] = arr[i];
                    len++;
                }
            }

            return len;
        }


        public static int RemoveElementFromArray(int[] arr, int target)
        {
            var i = 0;
            var len = arr.Length;
            while (i < len)
            {
                //有相同的值，把末尾元素移到当前位置，并且数组长-1（还是老问题不是真的resize，只是不去判断最后一位了）
                if (arr[i] == target)
                {
                    arr[i] = arr[len - 1];
                    len--;
                }
                else
                    i++;
            }

            return i;
        }

    }
}
