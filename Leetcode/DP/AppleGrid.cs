using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.DP
{
    public class AppleGrid
    {
        //as much as possiable
        public static int GetApplesAMAP(int[,] arr)
        {
            var x = arr.GetLength(0);
            var y = arr.GetLength(1);
            var maxApples = new int[x, y];
            for (var i = 0; i < x; i++)
            {
                for (var j = 0; j < y; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        maxApples[i, j] = arr[i, j];
                    }
                    else if (i == 0)//上一步肯定是横着走过来的
                    {
                        maxApples[i, j] = arr[i, j] + maxApples[0, j - 1];
                    }
                    else if (j == 0)//上一步肯定是竖着走过来的
                    {
                        maxApples[i, j] = arr[i, j] + maxApples[i - 1, 0];
                    }
                    else//竖着过来横着过来都行，取上一层的最大值
                    {
                        maxApples[i, j] = arr[i, j] + Math.Max(maxApples[i - 1, j], maxApples[i, j -1]);
                    }
                }
            }

            return maxApples[x - 1, y - 1];
        }
    }
}
