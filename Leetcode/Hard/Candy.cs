using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Hard
{
    //所有孩子至少得1个糖，如果比邻居得分高，糖就要比他们多。
    //如果只考虑非降序序列（左往右，右往左没区别），糖肯定是从１开始分，每次递增１个，如果相等就回复到１个糖
    //关键是出现了降序序列后，我们不知道降序序列有多少，从N减1肯定是不对的（比如降序序列很短，从N每次减1不是解）
    public class Candy
    {
        //先从左到右，保证右边的比左边高的，得分比左边高的孩子的糖是左边的+1(只考虑了左往右的升序序列）
        //这时候所有的升序段都正确处理了，为了处理降序段，用相同的逻辑从右往左再计算一次，把降序段（对本次循环来说是升序段）计算了
        //比如升序段长度4，降序段是3，那么结果就是1234111，最后反向扫描过来变成1234321
        //先保证升序正确，到了最高点肯定是降序，再反过来计算降序（计算的时候当作升序处理，因为默认分配1个糖）
        public static int Way_2pass(int[] ratings)
        {
            var len = ratings.Length;
            var candies = new int[len];

            for (var i = 0; i < len; i++)
            {
                candies[i] = 1;
            }

            for (var i = 1; i < len; i++)
            {
                if ((ratings[i] > ratings[i - 1]) && (candies[i] <= candies[i - 1]))
                    candies[i] = candies[i - 1] + 1;
            }

            for (var i = len -2; i >=0; i--)
            {
                if ((ratings[i] > ratings[i + 1]) && (candies[i] <= candies[i + 1]))
                    candies[i] = candies[i + 1] + 1;
            }

            return candies.Sum();
        }
    }
}
