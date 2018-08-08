using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Easy
{
    public class MergeSortedArray
    {
        //允许假设 数组1长度是大于等于m+n
        public  static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            //最后一个数字的index
            var total = m + n - 1;
            m--;
            n--;
            while (m >= 0 && n >= 0)
            {
                if (nums1[m] >= nums2[n])
                    nums1[total--] = nums1[m--];
                else
                    nums1[total--] = nums2[n--];
            }
            //因为是2合并到1，所以数组2空（n<0)什么都不用做，剩下的自然就是数组1的值
            while (n >= 0)
            {
                nums1[total--] = nums2[n--];
            }
        }
    }
}
