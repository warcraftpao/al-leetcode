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
        //关于斜线的判定，我自己写的比较傻，分成左右两个斜线分开算的
        //最后注意，因为按行防止，当前行之后的行无需判定
        private static bool IsValid(int[,] arr, int row, int col)
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
                     curr[row, col] = 0;//这里必须回退，当前列标注的皇后去掉否则不会有解
                    //这里不需要else,否则就不是backtracing了，下层递归结束的时候上层回退
                }
                    
            }
        }


        //另外一种1d数组判定皇后合法思路的，数组下标代表行数，值代表第几列是皇后
        //斜线判定提升在于，在一条斜线上的2个点，其横坐标之差绝对值=纵坐标之差绝对值
        //正好用来做N皇后解数量的验证方法
        private static bool IsValidByD1array(int[] arr, int row, int col)
        {
            for (var i = 0; i < row; i++)
            {
                if (arr[i] == col || Math.Abs(i - row) == Math.Abs(arr[i] - col))
                    return false;
            }
            return true;
        }

        public static int NqueenResultNumber(int n)
        {
            var num = 0;
            var queenPostion = new int[n];
            ResultNumber(ref num, n, queenPostion, 0);
            return num;
        }

        //注意引用传递值类型
        private static void ResultNumber( ref int num, int n, int[] queenPostion, int row)
        {
            if (row == n)//n-1坐标最大值，n的时候直接加入结果
            {
                num++;
                return;
            }

            for (var col = 0; col < n; col++)
            {
                if (IsValidByD1array(queenPostion, row, col))
                {
                    queenPostion[row] = col;
                    ResultNumber(ref num, n, queenPostion, row + 1);
                  //  queenPostion[row] = 0; 其实这里连回退都用不着到，因为一行只有一个值，进入下一次递归上层必然有确定值
                }

            }
        }

    }
}
