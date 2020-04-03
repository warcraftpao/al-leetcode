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


        /// <summary>
        ///  行左小右大升序
        ///  列从上到下升序
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool SearchLevel2(int[,] matrix, int target)
        {
            //可以从左下角开始查，因为如果目标比这个值大就往右，比他小就往上，这样就可以一行一列的切割掉矩阵
            //同理 也可以从右上角开始
            var row = matrix.GetLength(0) -1 ;
            var col = 0;
            while (true)
            {
                if (target == matrix[row, col])
                {
                    return true;
                }

                if (target > matrix[row, col] )
                {
                    col++;
                }
                else if(target < matrix[row, col]  )
                {
                    row--;
                }

                if (row < 0 || col > matrix.GetLength(1) - 1) break;
            }

            return false;
        }
    }
}
