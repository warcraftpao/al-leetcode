using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Hard
{

//The demons had captured the princess(P) and imprisoned her in the bottom-right corner of a dungeon.The dungeon consists of M x N rooms laid out in a 2D grid.Our valiant knight(K) was initially positioned in the top-left room and must fight his way through the dungeon to rescue the princess.
//The knight has an initial health point represented by a positive integer.If at any point his health point drops to 0 or below, he dies immediately.
//Some of the rooms are guarded by demons, so the knight loses health (negative integers) upon entering these rooms; other rooms are either empty(0's) or contain magic orbs that increase the knight's health (positive integers).
//In order to reach the princess as quickly as possible, the knight decides to move only rightward or downward in each step.
//Write a function to determine the knight's minimum initial health so that he is able to rescue the princess.
//For example, given the dungeon below, the initial health of the knight must be at least 7 if he follows the optimal path RIGHT-> RIGHT -> DOWN -> DOWN.
    public class DungeonGame
    {


        //跟拿金币拿苹果概念差不多，但是需要考虑骑士的生命值问题，从最后一个点出发走到出发点容易解题
        //动态规划数组的里hp代表的是骑士进入某个房间时的hp，隐含条件时离开这个房间时hp至少有1，所以离开公主房间后hp至少是1
        //往回递推的时候必须满足条件 hp[当前]+dungeon[当前] = hp[来源]  推出 hp[当前] = hp[来源]-dungeon[当前]，因为来源有个2个，右边或者下面的房间，所以要取最小值
        //房间可能有怪物，此时值是负数，所以hp[当前]会大于hp[来源]；如果房间加血 会导致负数生命值也能满足来源房间的要求，必须和1比较取最大值
        public static int RescurePrincess(int[,] dungeon)
        {
             
            var width = dungeon.GetLength(0);
            var height = dungeon.GetLength(1);

            
            var hp = new int[dungeon.GetLength(0), dungeon.GetLength(1)];

           
            for (var i = dungeon.GetLength(0) - 1; i >= 0; i--)
            {
                //如果房间加血，进入时候hp1 ，如果扣血就是 1-dungeon
                for (var j = dungeon.GetLength(1) - 1; j >= 0; j--)
                {
                   //右下角
                    if (i == width - 1 && j == height - 1)
                    {
                        hp[i, j] = Math.Max(1, 1 - dungeon[i, j]);
                    }
                    //最下面,依赖前一列
                    else if (i == width -1)
                    {
                        hp[i, j] = Math.Max(1, hp[i, j +1] - dungeon[i, j]);
                    }
                    //最右面，依赖前一行
                    else if (j == height - 1)
                    {
                        hp[i, j] = Math.Max(1, hp[i + 1, j] - dungeon[i, j]);
                    }
                    else //前一行前一列的更小值
                    {
                        hp[i, j] = Math.Max(1, Math.Min(hp[i + 1, j] - dungeon[i, j], hp[i, j + 1] - dungeon[i, j]));
                    }
                }
            }

            return hp[0, 0];
        }
    }
}
