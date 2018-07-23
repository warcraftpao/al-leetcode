using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Hard
{
    public class NQueen
    {
        //当前棋盘是一个2维数组，因为按照行放置，所以新加的皇后不用判定行,需要判定列
        //关于斜线的判定，核心思路就是一条斜线上的格子，纵横坐标绝对值之差相等
        //最后注意，因为按行防止，当前行之后的行无需判定
        public static bool IsValid(int[,] arr, int row, int col)
        {
            //某行的特定列是Q  | 竖的
            for (var i = 0; i < row; i++)
                if (arr[i, col] == 1) return false;

            var x = row -1;
            var y = col - 1;
            while (x >= 0 && y >= 0)//  \这样的斜线
            {
                if (arr[x, y] == 1)
                    return false;

                x--;
                y--;
            }

            x = row - 1;
            y = col + 1;
            while (x >= 0 && y < arr.GetLength(1))//  /这样的斜线
            {
                if (arr[x, y] == 1)
                    return false;

                x--;
                y++;
            }

            return true;
        }

        public static List<List<string>> NqueenSolver(int n)
        {
            var results = new List<List<string>>();
            var curr = new int[n, n];
            Solver(results, n, curr, 0);
            return results;
        }

        private static void Solver(List<List<string>>  results, int n, int[,] curr, int row)
        {
            if (row  == n )//n-1坐标最大值，n的时候直接加入结果
            {
                var list = new List<string>();
                for (var i = 0; i < n; i++)
                {
                    var sb = new StringBuilder();
                    for (var j = 0; j < n; j++)
                    {
                        sb.Append(curr[i, j] == 0 ? "." : "Q");
                    }
                    list.Add(sb.ToString());
                }
                results.Add(list);
                return;
            }

            for (var col = 0; col < n; col++)
            {
                if (IsValid(curr, row, col))
                {
                    curr[row, col] = 1;
                    Solver(results, n, curr, row + 1);
                    curr[row, col] = 0;
                    //这里不需要else
                }
                    
            }
        }
    }
}
