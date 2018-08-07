using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Middle
{
    public class Sudoku
    {
        //1个方块，有的地方填数字，其他是点
        //验证数独
        //每行每列每个方块申明一个数组，数组下标标识每个行列块对应的0-9数字，值代表是否出现过
        public static bool Validate(char[,] input)
        {
            var rows = new bool[9, 9]; //第几行某个数字是否出现过
            var cols = new bool[9, 9];//第几列某个数字是否出现过
            var cubes = new bool[9, 9];//第几个方块某个数字是否出现过
            for (var i = 0; i < rows.GetLength(0); i++)
            {
                for (var j = 0; j < rows.GetLength(0); j++)
                {
                    if (input[i, j] == '.')
                        continue;
                    var num = input[i, j] - '0' -1;
                    if (rows[i, num])
                        return false;

                    rows[i, num] = true;

                    if (cols[j, num])
                        return false;

                    cols[j, num] = true;

                    //计算当前点属于哪个cube
                    //感觉大神的思路精华就是这里，(j/3)*3 + (i/3) 也可以的。无非是序号先横后竖，或者先竖后横
                    //第一行的格子，i都是0，j 012，第二行的格子i=3 j012
                    if (cubes[(i/3)*3 + (j/3), num])
                        return false;

                    cubes[(i/3)*3 + (j/3), num] = true;
                }
                
            }
            return true;
        }

        //判定valid也有些地方不对，既然不带入比较数字，就必须特定指出当前格子不判断，否则自己和自己比较，一直是相等造成返回无解
        private static bool ValidateForSolver(char[,] input, int row, int col)
        {
            for (int i = 0; i < 9; i++)
            {
                if (i != col && input[row,i] == input[row,col])
                    return false;
            }
            for (int i = 0; i < 9; i++)
            {
                if (i != row && input[i,col] == input[row,col])
                    return false;
            }
            int beginRow = 3 * (row / 3);
            int beginCol = 3 * (col / 3);
            for (int i = beginRow; i < beginRow + 3; i++)
            {
                for (int j = beginCol; j < beginCol + 3; j++)
                {
                    if (i != row && j != col && input[i,j] == input[row,col])
                        return false;
                }
            }
            return true;
        }

      
        public static bool Solver(char[,] input)
        {
            var r = ValidateBoard(input);
            return r;
        }

        //这个问题拖了很久，犯了一些错误，就是要么先给没数字的位置赋值在判定，要么判定的时候要带入数字
        //还有某个位置所有数字都测试完成，说明是不合法的。需要先return错误
        private static bool ValidateBoard(char[,] input)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (input[i,j] == '.')
                    {
                        for (var num = '1'; num <= '9'; num++)// 所有的数字都测试过，没有返回true的，一定挂了
                        {
                            input[i, j] = num;//先赋值
                            if (ValidateForSolver(input, i, j)) //验证当前点新加的数字是否合法
                            {
                                if (ValidateBoard(input))//继续验证下一个格子
                                    return true;
                            }
                            input[i, j] = '.';//回退
                        }
                        return false;
                    }
                }
            }
            //跑到这里算成功的
            return true;
        }
    }
}
