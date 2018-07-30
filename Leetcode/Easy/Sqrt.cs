using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Easy
{
    public  class Sqrt
    {
        //x >= 1，舍弃小数点部分
        public static int SimpleSqrt(int x)
        {
            if (x <= 1) return x;

            int left = 0, right = x/2 + 1 ; // x/2 +1意思就是 x的平方根不会大于这个值，可以在0 到这个值之间二分查找
            while (left < right)
            {
                int mid = left + (right - left) / 2;//每次还是取中间值，注意，这里不是下标是值本身
                if (x / mid >= mid) //测试值太小，注意这里没小数点
                    left = mid + 1;
                else// 测试值太大，right缩到mid
                    right = mid;

            }
            return right - 1;
        }
    }
}
