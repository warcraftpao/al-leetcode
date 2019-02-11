using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Leetcode.Middle
{
    //遍历整个数组，如果是1，那就不断找它的上下左右，直到次递归结束，岛数量+1
    //遍历的同时记录一个点是否已经被访问过，被访问过的肯决无需在下次递归中访问。
    public class IslandNumber
    {
        public static int Count(char[,] grid)
        {
            var count = 0;
            var visited = new bool[grid.GetLength(0), grid.GetLength(1)];
            for (var i = 0; i < grid.GetLength(0); i++)
            {
                for (var j = 0; j < grid.GetLength(1); j++)
                {
                    //当前是岛屿且未访问过
                    if (grid[i, j] == '1' && !visited[i, j])
                    {
                        GothroughOneIsland(grid, visited, i, j);
                        count++;
                    }
                }
            }

            return count;
        }

        //如果遇到岛屿是遍历他的四周，否则就退出，函数最终退出说明一个岛走全了
        private static void GothroughOneIsland(char[,] grid, bool[,] visited, int x, int y)
        {
            //走出grid边界了，不做判定
            if (x < 0 || x >= grid.GetLength(0) || y < 0 || y >= grid.GetLength(1))
                return;
            //不是岛屿或者已经访问过
            if (grid[x, y] == '0' || visited[x,y])
                return;
            //是岛屿
            visited[x, y] = true;

            GothroughOneIsland(grid, visited, x+1, y);
            GothroughOneIsland(grid, visited, x, y+1);
            GothroughOneIsland(grid, visited, x-1, y);
            GothroughOneIsland(grid, visited, x, y -1);

        }
    }
}
  