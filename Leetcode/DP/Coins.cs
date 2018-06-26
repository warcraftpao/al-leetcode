using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.DP
{
    public class Coins
    {
        //有一组硬币，比如xyz，凑到value值的最小硬币数
        //value必须>=1吧
        //这个算法网上解法有个小问题，就是必须给出每个value的值必须有解（硬币必须有面值1的硬币，换言之这个问题肯定是有解的），否则某个value的解是不存在的
        //我的改进是最后=-1 代表无解
        //arr[0] 必然是0，arr[1]开始可能是-1，如果是-1说明无法达成这个值。依赖于arr[i]=-1也是无解
        public static int MinCoinNumber(int[] coins, int value)
        {
            Array.Sort(coins);
            var arr = new int[value+1];
            arr[0] = 0;
            for (var i = 1; i <= value; i++) //1块钱到value块钱的循环
            {
                if (i == 1)
                {
                    arr[i] = i == coins[0] ? 1 : -1;
                    continue;
                }

                var list = new List<int>();
                foreach (var coin in coins)
                {
                    if ((i - coin) >= 0 && arr[i - coin] != -1)
                    { 
                        list.Add(arr[i -coin]);
                    }
                }
                if (list.Any())
                {
                    arr[i] = list.Min() + 1;
                }
                else
                {
                    arr[i] = -1;
                }
            }

            return arr[value];
        }
    }
}
