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
        //思路1 每行每列每个方块申明一个list，数字直接往里面加,
        //思路2 每行每列每个方块申明一个数组，数组下标标识每个行列块对应的0-9数字，值代表是否出现过
        //感觉思路2好，因为思路1还需要初始化27次list，而2维数组只要申明3次就行了
        public static bool Validate(char[,] input)
        {
            var len = input.Length;
            var rows = new bool[9, 9];
            var cols = new bool[9, 9];
            var cubes = new bool[9, 9];
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

        //solver在循环的时候不需要判断全图，当前填入一个新数字，只影响所在的行列和方块
        private static bool ValidateForSolver(char[,] input, int i, int j)
        {
            var len = input.GetLength(1);
            for (var m = 0; m < len; m++)
            {
                //要拿出当前cube的所有点，cube内任意一点 i/3*3 决定左上点坐标，横坐标每3次循环+1，竖坐标123轮换
                if (input[i, j] == input[i, m] 
                    || input[i, j] == input[m, j]
                    || input[i, j] == input[i/3*3 + m/3, j/3*3 + m%3]) //写成input[j/3*3 + m/3, i/3*3 + m%3] 也一样，就是先竖后横
                    return false;
            }
            return true;
        }

        //dfs简单粗暴的思路，不考虑状态重复利用
        //直到行列都到最大值的时候，按照0到9填值，再验证
        //注意，多重循环和dfs是不同的
        public static void Solver(char[,] input)
        {
            ValidateBoard(input);
        }

        private static bool ValidateBoard(char[,] input)
        {

            var len = input.GetLength(1);
            
            for (var m = 0; m < len ; m++)
            {
                for (var n = 0; n < len ; n++)
                {
                    if (input[m, n] == '.')
                    {
                        for (var k = 1; k <= len; k++)
                        {
                            input[m, n] = (char)(k + '0');
                            if (ValidateBoard(input))
                            {
                                if (ValidateBoard(input))
                                    return true;
                            }
                            else
                                input[m, n] = '.';
                             
                        }
                        return false;
                    }
                   
                }
            }
            //所有的点都测试过了所有数字组合，到这里算有解
            return true;
        }
    }
}
