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
            //如果left 赋值退出循环说明，mid测试值太小，但是+1后超过right，说明mid跟right一样大了，因为舍弃小数，所以right-1
            //如果right赋值退出循环说明，mid太大了，left也赶上right了，一样right-1
            return right - 1;
        }

        //我喜欢这个方法，因为这种情况下2分法不好理解。暴力循环比较好理解，性能没差距
        public static int SimpleSqrt_w2(int x)
        {
            if (x == 0) return 0;
            for (int i = 1; i <= x / i; i++) //i平方小于x 但是 （i+1）的平方大于x，i就是解 i.xxx是解
                if (i <= x / i && (i + 1) > x / (i + 1))// Look for the critical point: i*i <= x && (i+1)(i+1) > x
                    return i;
            return -1;
        }
    }
}
