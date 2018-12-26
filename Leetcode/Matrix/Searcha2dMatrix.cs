using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Matrix
{
    public class Searcha2dMatrix
    {
        //Write an efficient algorithm that searches for a value in an m X n matrix. This matrix has the following properties:
        //Integers in each row are sorted from left to right.
        //The first integer of each row is greater than the last integer of the previous row.
        //就是矩阵有序的，第n行比n-1行大，每行本身也排序
        public static bool Search(int[,] matrix, int target)
        {
            var row = matrix.GetLength(0);
            var col = matrix.GetLength(1);

            var up = 0;
            var down = row - 1;
            while (up <= down)
            {
                var rowMiddle = (up + down)/2;
                if (matrix[rowMiddle, 0] == target) return true;

                if (matrix[rowMiddle, 0] > target)
                    down = rowMiddle - 1;
                else
                    up = rowMiddle + 1;
            }

            var row1 = down;
            var left = 0;
            var right = col - 1;
            while (left <= right)
            {
                var colMiddle = (left + right) / 2;
                if (matrix[row1, colMiddle] == target) return true;

                if (matrix[row1, colMiddle] > target)
                    right = colMiddle - 1;
                else
                    left = colMiddle + 1;
            }

            return false;
        }
    }
}
