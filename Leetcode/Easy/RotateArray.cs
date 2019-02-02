using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Easy
{
    public class RotateArray
    {

        //1 reserve
        public static void Reserve(int[] arr, int k)
        {
            PartlyReserveArray(arr, 0, arr.Length-1);
            PartlyReserveArray(arr,0, k-1);
            PartlyReserveArray(arr,k, arr.Length -1);
        }

        private static void PartlyReserveArray(int[] arr, int left, int right)
        {
            while (left < right)
            {
                var tmp = arr[left];
                arr[left] = arr[right];
                arr[right] = tmp;
                left++;
                right--;
            }
        }


        public static void Change(int[] arr, int k)
        {
            //一共循环length次
            //a跳转k个间隔到b，用变量记录b的值，把a赋值给b
            var next = arr[0];
            var tmp = arr[0];
            var currIndex = 0;
            for (var i = 0; i < arr.Length; i++)
            {
                //计算跳转到哪里
                var targetIndex = (currIndex + k)%arr.Length;
                tmp = next;
                //next等于targetindex对应的值
                next = arr[targetIndex];
                //a赋值给b
                arr[targetIndex] = tmp;

                //index前进
                currIndex = targetIndex;
            }
        }
    }
}
