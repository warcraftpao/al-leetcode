using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Middle
{
    //注意 对数时间复杂度
    public class FindPeakElement
    {
        //还是得binary search，因为只需要找到任意一个点就行了
        //找到中间点，如果mid比 mid-1大，说明mid之后（含mid）肯定有peak，mid比mid-1小，说明min之前有个peak
        public static int Find(int[] arr)
        {
            var left = 0;
            var right = arr.Length - 1;
            //满足条件至少还有两个元素吧，这时候left=mid，要么right减小了要么left+1了，退出循环
            while (left < right)
            {
                var mid = (right + left)/2;
                if (arr[mid] > arr[mid + 1]) //下降
                    right = mid;
                else //上升
                    left = mid + 1;
            }

            return left;
        }
    }
}
