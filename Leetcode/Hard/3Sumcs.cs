using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Hard
{
    public class ThreeSum
    {
        public static List<List<int>> S1(int[] arr, int target)
        {
            var r = new List<List<int>>();
            Array.Sort(arr);
            for (var i = 0; i < arr.Length-2; i++)//最后2位不用循环
            {
                //已经排序了，所以i已经比target大了就别玩了（等于是可以的，都是0的特殊情况）
                if (arr[i] > target)
                    break;

                //如果和上一个元素相同，比如10个数字， a1和a2相等：
                //比较情况有 a1，a2，a10--- a1，a3，a10-- a1,a4,a10
                //a2,a3,a10,--- a2,a4,a10
                //因为a1，a2相同，所以可以忽略a2
                if (i > 0 && arr[i] == arr[i - 1])
                    continue;

                var left  = target - arr[i];
                var begin = i + 1;
                var end = arr.Length - 1;
                while (begin < end)//双指针，分别指向剩下2个值的最大最小可能
                { 
                    if (arr[begin] + arr[end] == left)
                    {
                        r.Add(new List<int>() {arr[i], arr[begin], arr[end]});
                        begin++;
                        end--;
                    }
                    else if(arr[begin] + arr[end] > left)
                    {
                        end--;
                    }
                    else
                    {
                        begin++;
                    }
                }
            }
            return r;
        }
    }

    public class ThreeSumClosest
    {
        public static int S1(int[] arr, int target)
        {
            //和target差多少
            var distanceClosest = int.MaxValue;
            var sumClosest = 0;
            Array.Sort(arr);
            for (var i = 0; i < arr.Length - 2; i++)//最后2位不用循环
            {
                var left = target - arr[i];
                var begin = i + 1;
                var end = arr.Length - 1;
                while (begin < end)//双指针，分别指向剩下2个值的最大最小可能
                {
                    var sum = arr[i] + arr[begin] + arr[end];
                    var distance = Math.Abs(sum - target);

                    if (sum < target)
                    {
                        begin++;
                    }
                    else if (sum > target)
                    {

                        end--;
                    }
                    else
                    {
                        return sum;
                    }

                    if (distance < distanceClosest)
                    {
                        sumClosest = sum;
                        distanceClosest = distance;
                    }

                }
            }
            return sumClosest;
        }


    }

    public class FourSum
    {
        public static List<List<int>> S1(int[] arr, int target)
        {
            var ret = new List<List<int>>();
            Array.Sort(arr);
            var len = arr.Length;
            for (var i = 0; i < len -3 ; i++)
            {
                //第二个元素开始
                if(i >0 && arr[i] == arr[i -1])
                    continue;

                for (var j = i + 1; j < len -2; j++)
                {
                    //理由同上
                    if(j > i + 1 && arr[j] == arr[j-1])
                        continue;

                   
                    var begin = j + 1;
                    var end = len - 1;
                    while (begin < end)
                    {
                        var sum = arr[i] + arr[j] + arr[begin] + arr[end];
                        if (sum < target)
                        {
                            begin++;
                        }
                        else if (sum > target)
                        {
                            end--;
                        }
                        else
                        {
                            ret.Add(new List<int> {arr[i], arr[j], arr[begin], arr[end]});
                            begin++;
                            end--;
                        }
                    }
                }
            }

            return ret;
        }
    }
}
