using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        //第二种思路，波峰波谷，上升段长度，下降段长度（和leetcode上的方案4差不多）
        //上升段不管，还是要额外处理下降段，如果知道下降段的长度，并且知道进入下降段长度时候分配的糖数量，就可以计算了
        //如果进入下降序列，计算下降序列长度，从右往左考虑，下降序列的也是从1个糖开始递增的，
        //下降序列长度+1，总糖数也加上这个下降序列的长度，当下降序列长度超过“进入下降段长度时候分配的糖数量”（下降段长度超过了上升段）
        //总数还是照样累积，那么要给处于进入下降段的那个孩子（峰顶）一些补偿，长度每超过一次补偿+1
        //这样理解，峰顶的那个孩子只考虑左面的话是正确的，随着波谷不断延伸，另外一面的山坡在慢慢隆起扩展，他的地位也在上升，每比上升段多1，就要额外补偿1

        public static int Way_peak_valley(int[] ratings)
        {
            var total = 1; //从第二个开始算
            var len = ratings.Length;
            var decreacingLength = 1;//下降段长度
            var increasingLength = 1;//上升段长度
            var peak = 1;  //峰顶，进入下降段之前的最大糖果数

            //第二个点开始循环
            //不管出现上升还是下降，波段长度至少有2，即为顶端的那个点既属于上升段也属于下降段
            for (var i = 1; i < len; i++)
            {
                //上升，这个比较简单，每次+1，波峰在增长
                if (ratings[i] > ratings[i - 1])
                {
                    increasingLength++;
                    peak = increasingLength;
                    total = total + increasingLength;
                    decreacingLength = 1;
                }
                //下降，因为decreacingLength至少有1，先加上decreacingLength，如果下降段和上升段一样长，就要给peak一些补偿
                //最后再增加 decreacingLength，
                else if (ratings[i] < ratings[i - 1])
                {
                    total = total + decreacingLength;
                    if (decreacingLength >= peak)
                        total++;
                    decreacingLength++;
                    increasingLength = 1;
                }
                else //持平 ，持平意味着所有都归1，这个点既可能成为下一波的peak也可能成为valley
                {
                    decreacingLength = 1;
                    increasingLength = 1;
                    peak = 1;
                    total++;
                }
            }

            return total;
        }
    }
}
