using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Leetcode.DataStructure;

namespace Leetcode.Middle
{
    

    public class SurroundedRegions
    {

        //dfs,扫描四条边，找到o，继续查这个点四周的点是不是o
        //每条边上的每个o都是一次dfs，用stack来记录点，找到o不停入栈，直到栈为空为止，和该o相连的o都被标注成了临时符号
        public static void Solve_dfs(char[,] board)
        {
            var tmpMarker = '#';
            var removeMarker = 'o';
            var keepMarker = 'x';
            var row = board.GetLength(0);
            var col = board.GetLength(1);

            //扫描第一行和最后一行，先把自己的值给改了，dfs递归里是靠第二个点返回到第一个点再修改值的，万一只有一个点是要标记的就出错了
            for (var i = 0; i < col; i++)
            {
                if (board[0, i] == removeMarker)
                {
                    board[0, i] = tmpMarker;
                    Solve_dfs_helper(board, 0, i, row, col);
                }
                if (board[row - 1, i] == removeMarker)
                {
                    board[row - 1, i] = tmpMarker;
                    Solve_dfs_helper(board, row -1, i, row, col);
                }
            }

            //扫描第一列和最后一列，同上
            for (var i = 0; i < row; i++)
            {
                if (board[i, 0] == removeMarker)
                {
                    board[i, 0] = tmpMarker;
                    Solve_dfs_helper(board, i, 0, row, col);
                }
                if (board[i, col - 1] == 'o')
                {
                    board[i, col - 1] = tmpMarker;
                    Solve_dfs_helper(board, i, col -1, row, col);
                }
            }

            for (var i = 0; i < row; i++)
            {
                for (var j = 0; j < col; j++)
                {
                    if (board[i, j] == removeMarker)
                        board[i, j] = keepMarker;
                    else if (board[i, j] == tmpMarker)
                        board[i, j] = removeMarker;
                }
            }
        }

        //这里用queue和stack没区别的
        //想了下不对，dfs就是用stack，先进后出，所以按照下面的代码，会先往right一路向前深度搜索
        //bfs就把stack改成queue，先进先出，上下左右向环形一样一圈圈扩展
        private static void Solve_dfs_helper(char[,] board, int x, int y, int row, int col)
        {
            var stack = new Stack<Point>();
            stack.Push(new Point(x, y));
            while (stack.Count > 0)
            {
                var point = stack.Pop();
                if (point.X > 0 && board[point.X -1, point.Y] == 'o') //up
                {
                    board[point.X - 1, point.Y] = '#';
                    stack.Push(new Point(point.X - 1, point.Y));
                }

                if (point.X < row - 1 && board[point.X + 1, point.Y] == 'o') //down
                {
                    board[point.X + 1, point.Y] = '#';
                    stack.Push(new Point(point.X + 1, point.Y));
                }

                if (point.Y > 0 && board[point.X, point.Y -1] == 'o') //left
                {
                    board[point.X, point.Y - 1] = '#';
                    stack.Push(new Point(point.X, point.Y - 1));
                }

                if (point.Y < col - 1 && board[point.X, point.Y+ 1] == 'o') //right
                {
                    board[point.X , point.Y + 1] = '#';
                    stack.Push(new Point(point.X, point.Y + 1));
                }
            }
        }

    }
}
