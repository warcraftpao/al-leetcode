using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Middle
{
    public class SpiralMatrix
    {
        public static int[] Convert(int[,] matrix)
        {
            var list = new List<int>();
            var row = matrix.GetLength(0);
            var col = matrix.GetLength(1);
            var repeat = Math.Max(row, col) /2;
             
            for (var i = 0; i < repeat; i++)
            {
                //左上角的顶点00开始
                var x = i;
                var y = i;
                //从左到右
                while (y < col - i -1)
                {
                    list.Add(matrix[x,y]);
                    y++;
                }
                //从上到下
                while (x < row - i -1)
                {
                    list.Add(matrix[x, y]);
                    x++;
                }

                //从左到右
                while (y >= i + 1)
                {
                    list.Add(matrix[x, y]);
                    y--;
                }

                //从上到下
                while (x >= i +1)
                {
                    list.Add(matrix[x, y]);
                    x--;
                }
            }

            return list.ToArray();
        }
    }
}
