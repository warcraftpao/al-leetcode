using System;
using System.Collections.Generic;

namespace Leetcode.Matrix
{
    public class SpiralMatrix
    {
        //把一个矩阵按照螺旋状前进生成字符串
        public static int[] Convert(int[,] matrix)
        {
            var list = new List<int>();
            var rowNum = matrix.GetLength(0);
            var colNum = matrix.GetLength(1);
            var repeat = (Math.Max(rowNum, colNum) +1) /2;
             
            for (var i = 0; i < repeat; i++)
            {
                //从左到右  有几列加几个元素
                for (var col= i; col < rowNum - i; col++) 
                {
                    list.Add(matrix[i, col]);
                }
                //从上到下 第一行都加入了，行数要加+1
                for(var row = i + 1; row < colNum - i; row++)
                {
                    list.Add(matrix[row, colNum -i -1]);
                }

                //从左到右 左边列都被占了，数组本身下标减1，所以-2
                for(var col = colNum - i - 2 ; col >= i; col--)
                {
                    list.Add(matrix[rowNum -i -1, col]);
                }

                //从上到下 最下面行都被占了数组本身下标减1，所以-2，且第一行也被占了，结束条件也-1
                for (var row = rowNum-i -2 ; row >  i; row--)
                {
                    list.Add(matrix[row, i]);
                }
            }

            return list.ToArray();
        }

        //生成1到n平方数字的矩阵，按照螺旋状排列
        public static int[,] Generate(int n)
        {
            var matrix = new int[n,n];
            //先确定大循环几次，一次剥掉2层
            var num = 1;
            var rowNum = matrix.GetLength(0);
            var colNum = matrix.GetLength(1);
            var repeat = (Math.Max(rowNum, colNum) + 1) / 2;
            for (var i = 0; i < repeat; i++)
            {
                //从左到右
                for (var col = i; col < rowNum - i; col++)
                {
                   matrix[i, col] = num++;
                }
                //从上到下
                for (var row = i + 1; row < colNum - i; row++)
                {
                    matrix[row, colNum - i - 1] = num++;
                }

                //从左到右
                for (var col = colNum - i - 2; col >= i; col--)
                {
                    matrix[rowNum - i - 1, col] = num++;
                }

                //从上到下
                for (var row = rowNum - i - 2; row > i; row--)
                {
                    matrix[row, i] = num++;
                }
            }

            return matrix;
        }
    }
}
