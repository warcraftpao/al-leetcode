using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Hard
{
    public class FindMedianSortedArrays
    {

        //https://blog.csdn.net/hk2291976/article/details/51107778
        public static double FindMedianSortedArrays2(int[] nums1, int[] nums2)
        {
            return 0;
        }


        //假设要第k个元素，因为都是排序的，所以A[k/2 -1]和B[k/2 -1]比较，假设前者小，那么A[k/2 -1]之前的元素肯定比第k个元素小
        //因为A[k/2] -- A[k-1]和B[k/2 -1] -- B[k-1] 之间的元素已经有K+1个了，反之依然，
        //换言之，有一个数组的当前的k/2 下标前的数据都不用判定了,该数组下标前进，我们要求的第k个数字也变成第k-k/2
        //前3个if情况 2个是下标前进到超过数组长度了，那肯定就是从下个数组开始判定了，当前另外一个数组的下标+ k的值
        //k=1说名当前2个数组的下标之一就是要的结果
          
        public static int FindKthIn2SortedArraies(int[] arr1, int a1Begin, int[] arr2, int a2Begin, int k)
        {
            if (a1Begin > arr1.Length)
                return arr2[a2Begin + k - 1];

            if (a2Begin > arr2.Length)
                return arr1[a1Begin + k - 1];

            if (k == 1)
            {
                return Math.Min(arr1[a1Begin], arr2[a2Begin]);
            }

            //累计的下标+ k的一半-1的值作为“切”点比较，来决定舍弃哪一半
            var m1 = a1Begin + k/2 - 1 > arr1.Length ? int.MaxValue : arr1[a1Begin + k/2 - 1];
            var m2 = a2Begin + k/2 - 1 > arr2.Length ? int.MaxValue : arr2[a2Begin + k/2 - 1];

            if (m1 < m2)
            {
                return FindKthIn2SortedArraies(arr1, a1Begin + k/2  , arr2, a2Begin, k - k/2);
            }
            else
            {
                return FindKthIn2SortedArraies(arr1, a1Begin, arr2, a2Begin + k / 2  , k - k / 2);
            }

        }

        public static double FindMedianSortedArrays1(int[] nums1, int[] nums2)
        {
            var i = 0;
            var j = 0;
            var l1 = nums1.Length;
            var l2 = nums2.Length;
            var arr = new List<int>();

            while (i < l1 || j < l2)//2个数组至少有一个没有遍历结束
            {
                if (i < l1 && j < l2) //2个数组都没到底.新数组+2，老数组各+1
                {
                    arr.Add(Math.Min(nums1[i], nums2[j]));
                    arr.Add( Math.Max(nums1[i], nums2[j]));
                    i++;
                    j++;
                }
                else if (i >= l1 && j < l2)
                {
                    arr.Add(nums2[j]);
                    j++;
                }
                else
                {
                    arr.Add(nums1[i]);
                    i++;
                }
                  
            }

            if (arr.Count%2 == 0) //偶数长度
            {
                return (double)(arr[arr.Count/2] + arr[arr.Count/2 - 1])/2;
            }
            else//奇数长度
            {
                return arr[arr.Count / 2];
            }
        }
    }
}
