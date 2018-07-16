using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Middle
{
    public class ValidSudoku
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

                    //感觉大神的思路精华就是这里，(j/3)*3 + (i/3) 也可以的。无非是序号先横后竖，或者先竖后横
                    //第一行的格子，i都是0，j 012，第二行的格子i=3 j012
                    if (cubes[(i/3)*3 + (j/3), num])
                        return false;

                    cubes[(i/3)*3 + (j/3), num] = true;
                }
                
            }
            return true;
        }
    }
}
