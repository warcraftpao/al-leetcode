using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Middle
{
    public class ArrarSearch
    {
        //关键点 旋转过得数组，随便怎么切，总有一半是有序的(只升序），所以只是判断条件增加，还是没次砍掉一半
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

                if (target < arr[mid])
                {
                    if (arr[mid] < arr[right]) //右边有序
                        right = mid - 1;
                    else//左边有序
                    {
                        if (target < arr[left])//不在左边
                            left = mid + 1;
                        else
                            right = mid - 1;
                    }
                }
                else // target > mid
                {
                    if (arr[left] < arr[mid]) //左边有序
                        left = mid + 1;
                    else//右边有序
                    {
                        if (target > arr[right])//不在右边
                            right = mid - 1;
                        else
                            left = mid + 1;
                    }
                }
            }
            return -1;
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
    }
}
