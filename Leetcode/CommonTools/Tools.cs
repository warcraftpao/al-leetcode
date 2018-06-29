using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.CommonTools
{
    public class Tools
    {
        /// <summary>
        /// 打印一个确定值的2维数组
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="nums">nums length should be row*col</param>
        /// <returns></returns>
        public static int[,] MakeBooked2DArr(int row, int col, int[] nums)
        {
            var k = 0;
            var arr = new int[row, col];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    arr[i, j] = nums[k];
                    k++;
                }
            }

            return arr;
        }

        /// <summary>
        /// 随机打印一个2维数组
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static int[,] Make2DArr(int row, int col, int min, int max)
        {
            var r = new Random();
            var arr = new int[row, col];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    arr[i, j] = r.Next(min, max);
                }
            }

            return arr;
        }

        /// <summary>
        /// 随机打印一个三角形，空置的一半不去用就行了
        /// </summary>
        /// <param name="row"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static int[,] MakeTriangle(int row, int min, int max)
        {
            var r = new Random();
            var triangle = new int[row, row];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    triangle[i, j] = r.Next(min, max);
                }
            }

            return triangle;
        }
    }
}
