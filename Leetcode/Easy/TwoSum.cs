using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Easy
{
    //Given an array of integers, return indices of the two numbers such that they add up to a specific target.
    //You may assume that each input would have exactly one solution, and you may not use the same element twice.
    //Given nums = [2, 7, 11, 15], target = 9,
    //Because nums[0] + nums[1] = 2 + 7 = 9,
    //return [0, 1].
    public class TwoSum
    {
        //最简单的2重循环
        public static int[] TwoSum1(int[] nums, int target)
        {
            for (var i = 0; i < nums.Length -1; i++)
            {
                for (var j = i + 1; j <= nums.Length-1; j++)
                {
                    if(nums[i]  + nums[j] == target)
                        return new [] { i, j };
                }
            }

            throw new Exception("not matched");
        }

        //每次循环开始，把当前目标减去当前数字，得到的是需要"缺"的数字
        //用缺的数字当key加入字典表，比如目标12，当前是5，key=7
        //以后某次循环的数字是7的时候，发现字典里有为7的key，那肯定之前有个成员值是5，那5和7一定是符合要求的
        public static int[] TwoSum2(int[] nums, int target)
        {
            //key is value and value is index!
            var dic = new Dictionary<int,int>();
            for (var i = 0; i < nums.Length; i++)
            {
                if (dic.ContainsKey(nums[i]))
                {
                    return new[] {i, dic[nums[i]]};
                }
                dic.Add(target - nums[i], i);
            }
            throw new Exception("not matched");
        }
    }


    //跟twosum 第一题是一样的，区别在于 Your returned answers (both index1 and index2) are not zero-based. 这个只是返回值要求
    // 主要区别是  Input array is sorted，那就可以用双指针（注意，其实3sum里也是要先排序的），那就和3sum没什么区别了，这出题的先后顺序也太奇怪了
    public class TwoSum2
    {
        public static int[] Calc(int[] arr, int target)
        {
            var left = 0;
            var right = arr.Length - 1;

            while (arr[left] + arr[right] != target)
            {
                if (arr[left] + arr[right] < target)
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }

            return new [] {left+1, right+1};
        }
    }


    //two sum 数据结构，way1双指针，add的时候内部list排序，find的时候按照双指针查找

    //way2 字典，add的时候统计每个数字出现的频率，find的时候循环字典表，注意出现大于1次说明这个数字可以用2次
    public class TwoSumDataStructure
    {
        //实际上因为只有add和find，可以给find方法再加一个缓存，找到过一次下次就不用再计算了
        private Dictionary<int, int> _dic = new Dictionary<int, int>();

        public void Add(int x)
        {
            if (_dic.ContainsKey(x))
                _dic[x] = 2;
            else
                _dic.Add(x,1);  
        }
        //Find if there exists any pair of numbers which sum is equal to the value.
        public bool Find(int target)
        {
            foreach (var kv in _dic)
            {
                var left = target - kv.Key;
                foreach (var leftKv in _dic)
                {
                    if(leftKv.Key != left)
                        continue;
                    //key不同，但是剩余值在字典里找到，或者有2个相同的数字
                    if ((kv.Key != leftKv.Key ) || (kv.Key == leftKv.Key && leftKv.Value == 2))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
