using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Middle
{
    public class SortColors
    {
        //只哟012三种颜色的情况
        public static void Sort(int[] arr)
        {
            //第一种颜色放在左边，第二种颜色放在右边
            var c0 = 0;
            var c2 = arr.Length - 1;
            for (var i = 0; i < c2; i++)
            {
                //这个时候颜色0肯定去最前面了,因为从头开始扫描，2一定去后面了，i和c0指针交换，肯定换来的是1
                if (arr[i] == 0)
                {
                    Swap(arr, i, c0);
                    c0++;
                }
                else if(arr[i]== 2) //因为结束条件是小于c2，so2到最后面去了
                {
                    Swap(arr, i , c2);
                    c2--;//交换到i位置的不是0就是1
                    i--; //后面交换过来的元素还没判断过，当前元素被交换到后面，只能保证第3个颜色指针变小了，换过来的可能是0或者2，是2继续要往后换，是1要往前换
                }
                    
            }
        }

        private static void Swap(int[] arr, int i, int j)
        {
            var tmp = arr[i];
            arr[i] = arr[j];
            arr[j] = tmp;
        }
    }
}
