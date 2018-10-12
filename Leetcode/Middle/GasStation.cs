using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Middle
{
    //There are N gas stations along a circular route, where the amount of gas at station i is gas[i].
    // You have a car with an unlimited gas tank and it costs cost[i] of gas to travel from station i to its next station(i+1). 
    //You begin the journey with an empty tank at one of the gas stations.
    // Return the starting gas station's index if you can travel around the circuit once in the clockwise direction, otherwise return -1.

    //If there exists a solution, it is guaranteed to be unique.
    // Both input arrays are non-empty and have the same length.
    //Each element in the input arrays is a non-negative integer.

    public class GasStation
    {
        //从某个站出发，能绕一圈回来的前提是什么？总体而言每个gas[i]-cost[i]之和要大于0（总补给要大于等于总消耗）。因为满足这个条件，
        //我总能找到一个提供燃料最多的站点作为初始站点，从而弥补后面的站供给不足的情况。
        //这点很重要，否则不可能从2次方复杂度降低到常数阶。
        //那么接下来就是要确定从哪一个站出来，从任意站点开始循环是每区别的，那就从0出发，在计算过程中需要两个变量，一个计算总的差值，一个计算到当前站点的差值
        //到当前站点的差值如果小于0，那么当前站点之前的都要废弃，不可能到达本站，起始点从本站算起 ，这个变量也重新从当前站点的差值开始计算
        //最后如果gas[i]-cost[i]之和大于等于0肯定有会有解，否则无解
        public static int CanCompleteCircuit(int[] gas, int[] cost)
        {
            if (gas.Length < 1 || cost.Length < 1 || gas.Length != cost.Length)
                return -1;
            var totolBalance = 0;
            var tempBalance = 0;
            var start = 0;//起始站点
            for (var i = 0; i < gas.Length; i++)
            {
                var diff = gas[i] - cost[i];
                //计算整体盈余
                totolBalance = totolBalance + diff;

                //tempbalance此时代表还没获得本站燃料的盈余，小于零说明从之前的站点出发到不了本站
                if ( tempBalance <= 0)
                {
                    tempBalance = diff;
                    //起始点更新为本站
                    start = i;
                }
                else//从之前的站点可以达到本站，继续旅行
                {
                    tempBalance = tempBalance + diff;
                }
            }

            return totolBalance <0 ? -1:start;
        }
    }
}
