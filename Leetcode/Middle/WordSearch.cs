using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Middle
{
    //Given a 2D board and a word, find if the word exists in the grid.
    //The word can be constructed from letters of sequentially adjacent cell, where "adjacent" cells are those horizontally or vertically neighboring.
    //The same letter cell may not be used more than once.
    //1 单个字母不可重复使用，2字母必须响铃，必须向同行或者同列扩展（一个点的上下左右都可以延伸）
    public class WordSearch
    {
        public static bool Search(char[,] matrix, string word)
        {
            var used = new bool[matrix.GetLength(0), matrix.GetLength(1)];
            return Dfs(matrix, word, 0, 0, used, 0);
        }

        private  static  bool Dfs(char[,] matrix, string word, int row, int col, bool[,] used, int index)
        {
            if (index == word.Length)//index =单词长度，数组越界了，搜索成功
                return true;

            //
            //if(row > matrix.GetLength(0) && col > matrix.GetLength(1))
            for (var i = row; i < matrix.GetLength(0); i++)
            {
                for (var j = col; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == word[index])//当前字母匹配，进行深度搜索
                    {
                        used[i, j] = true;
                        //如果可以向某个方向延伸且那个元素没被用过 深度搜索之
                        if ((i > 0 && used[i-1, j] == false && Dfs(matrix, word, i - 1, j, used, index + 1)) ||
                            (i < matrix.GetLength(0) - 1 && used[i + 1, j] == false && Dfs(matrix, word, i + 1, j, used, index + 1)) ||
                            (j > 0 &&  used[i , j -1] == false && Dfs(matrix, word, i, j - 1, used, index + 1)) ||
                            (j < matrix.GetLength(1) - 1 && used[i , j + 1] == false && Dfs(matrix, word, i, j + 1, used, index + 1)))
                        {
                            return true;
                        }
                        used[i, j] = false;
                    }
                    //不匹配不要写return啊。。。。还得继续循环，就这里卡了1小时
                }
            }
            return false;
        }
    }
}
