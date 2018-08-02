using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Middle
{
    public class ArrarSearch
    {
        //关键点 旋转过得数组，随便怎么切，总有一半是有序的(只升序），所以只是判断条件增加，还是每次砍掉一半
        //left mid right
        //1 mid= target over
        //2 target<mid  
        //   2-1 如果mid的右边有序，右边可以舍弃
        //   2-2 如果mid的左边有序， mid比left小，左边舍弃，否则舍弃右边
        //3 target>mid
        //   3-1 如果mid左边有序，舍弃左边
        //   3-2 如果mid的右边有序，mid比right大，右边舍弃，否则舍弃左边
        public static int SearchinRotatedSortedArray(int[] arr, int target)
        {
            var left = 0;
            var right = arr.Length - 1;
            while (left < right)
            {
                var mid = (left + right)/2;
                if (arr[mid] == target)
                    return mid;


                //参考SearchinRotatedSortedArray2 的写法更简洁，先判断有序且在有序半区舍掉另外一半
                //左边有序
                if (arr[left] < arr[mid])
                {
                    //在左边
                    if (target < arr[mid] && target >= arr[left])//有可能target比 arr[left]更小
                    {
                        right = mid - 1;
                    }
                    //在右边
                    else
                    {
                        left = mid + 1;
                    }
              
                }
                //右边有序
                else
                {
                    //在右边
                    if (target <= arr[left] && target > arr[mid]) //有可能target比arr[right]更大
                    {
                        left = mid + 1;

                    }
                    else
                    {
                        right = mid - 1;
                    }

                }


                //if (target < arr[mid])
                //{
                //    if (arr[mid] < arr[right]) //右边有序
                //        right = mid - 1;
                //    else//左边有序
                //    {
                //        if (target < arr[left])//不在左边
                //            left = mid + 1;
                //        else
                //            right = mid - 1;
                //    }
                //}
                //else // target > mid
                //{
                //    if (arr[left] < arr[mid] ) //左边有序
                //        left = mid + 1;
                //    else//右边有序
                //    {
                //        if (target > arr[right])//不在右边
                //            right = mid - 1;
                //        else
                //            left = mid + 1;
                //    }
                //}
            }
            return -1;
        }

        //有重复数字
        public static bool SearchinRotatedSortedArray2(int[] arr, int target)
        {
            var left = 0;
            var right = arr.Length - 1;
            while (left < right)
            {
                var mid = (left + right)/2;
                if (arr[mid] == target) return true;

                if (arr[mid] == arr[left]) //多出来一种情况，无法判断是否有序。因为重复值
                    left++;
                else if (arr[mid] > arr[left]) //判断出左边有序
                {
                    //在左边
                    if (target >= arr[left] && target < arr[mid])
                    {
                        right = mid - 1;
                    }
                    else
                    {
                        left = mid + 1;
                    }

                }
                else//arr[m] > arr[left] 右边有序
                {
                    //在右边
                    if (target > arr[mid] && target <= arr[right])
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;  
                    }
                }
            }
            return false;
        }

        public static int[] FindFirstAndLastInSortedArr(int[] arr, int target)
        {
            return new[] {FindLeftIndex(arr, target), FindRightIndex(arr, target)};
        }

        private static int FindLeftIndex(int[] arr, int target)
        {
            var index = -1;
            var left = 0;
            var right = arr.Length - 1;
            while (left <= right)
            {
                var mid = (left + right)/2;
                if (arr[mid] == target)
                {
                    index = mid;
                    right = mid - 1;//继续往左找
                }
                else if (arr[mid] > target)
                    right = mid - 1;
                else
                    left = mid + 1;
            }
            return index;
        }

        private static int FindRightIndex(int[] arr, int target)
        {
            var index = -1;
            var left = 0;
            var right = arr.Length - 1;
            while (left <= right)
            {
                var mid = (left + right) / 2;
                if (arr[mid] == target)
                {
                    index = mid;
                    left = mid + 1;//继续往右找
                }
                else if (arr[mid] > target)
                    right = mid - 1;
                else
                    left = mid + 1;
            }
            return index;
        }

        //assume array sorted and with duplicate
        public static int SearchInsertPosition(int[] arr, int target)
        {
            var len = arr.Length;
            if (target > arr[len - 1])//最后
                return len;
            if (target < arr[0])//最前
                return 0;

            var left = 0;
            var right = len - 1;
            while (left <= right)
            {
                var mid = (left + right)/2;
                if (arr[mid] == target)//找到了
                    return mid;

                if (target > arr[mid])
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return target > arr[left] ? left + 1 : left;
        }
    }
}
