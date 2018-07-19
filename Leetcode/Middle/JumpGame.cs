using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Middle
{
    public class JumpGame
    {
        //Given an array of non-negative integers, you are initially positioned at the first index of the array.
        //Each element in the array represents your maximum jump length at that position.
        //Determine if you are able to reach the last index.
        //注意，步数是可以随意选的比如3，可以选择走1or2or3步，是0就不能走


        //leetcode的方法4，从右向左跳，定义一个last是最右边的点
        //如果当前index+value >= last，更新last，说明从i点可以跳到last(也肯定可以调到实际上最后一位），逐步把last像左推进
        //遍历结束，last=0说明从右到左找到了一条路径
        public static bool Jump1_S1(int[] arr)
        {
            var last = arr.Length - 1;
            for (var i = arr.Length - 1; i>=0; i--)
            {
                if (i + arr[i] >= last)
                {
                    last = i;
                }
            }

            return last == 0;
        }

        //从左往右，因为只能往右前进，维护一个mostright值，在遍历数组是更新这个值代表当前能达到的最右边的点
        //这个点能超过数组长度就成功，否则失败
        public static bool Jump1_S2(int[] arr)
        {
            var mostRight = 0;
            for (var i = 0; i < arr.Length - 1; i++)//最后一个点不用判断，他是目的地
            {
                if (i + arr[i] <= mostRight)//提前失败的情况就是当前点正好最右点上，且值是0
                    return false;

                if (i + arr[i] >= arr.Length - 1)
                    return true;

                mostRight = Math.Max(mostRight, i + arr[i]);
            }

            return mostRight > arr.Length - 1;
        }
    }
}
