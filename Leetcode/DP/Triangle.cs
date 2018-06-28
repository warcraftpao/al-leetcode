using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.DP
{
    public class Triangle
    {
        public static void GetMax(int[,] triangle)
        {
            var maxArr = new int[triangle.Length];
            for (int i = 0; i < triangle.Length; i++)
            {
                
            }
        }

        public static int[,] MakeTriangle(int row)
        {
            Random r= new Random();
            var triangle = new int[row, row];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    triangle[i, j] = r.Next(1, 100);
                }
            }

            return triangle;
        }
    }
}
