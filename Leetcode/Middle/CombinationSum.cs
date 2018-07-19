using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Middle
{
    public class CombinationSum
    {
        // 都是正数，candidates本身没有重复，但是可以重复利用
        // 结果集本身不允许重复
        public  static List<List<int>> WithNumRepeat(int[] candidates, int target)
        {
            Array.Sort(candidates);
            var results = new List<List<int>>();
            var currAnswer = new List<int>();
            CalcWithNumRepeat(candidates, target , results, currAnswer, 0);
            return results;
        }

        //dfs顺序 2，3，7=> 7
        //2 ;22;222;222尝试3失败，222回退到22，223成功
        //22回退到2，23，233失败，2回退，元素2的循环结束
        //3开始以此类推
        private static void CalcWithNumRepeat(int[] candidates, int target, List<List<int>> results, List<int> currAnswer, int index)
        {
            if (target == 0)
            {
                var tmp = new List<int>();
                foreach (var i in currAnswer)//好久没遇到深浅拷贝问题了，上次dfs传的是字符串，没这个问题
                {
                    tmp.Add(i);
                }
                results.Add(tmp);
                return;
            }

            //因为数组是排序的，大循环只有在包含一个数字所有可能情况都尝试完后才进入下一个数字
            for (var i = index; i < candidates.Length && candidates[i] <= target; i++)
            {
                currAnswer.Add(candidates[i]);
                CalcWithNumRepeat(candidates, target - candidates[i], results, currAnswer, i);
                //回退方法放在递归之后说明，说明到某个数字不能再尝试的时候，再上一次的结果里回退，并且尝试下一个数字
                //因为循环条件里每次target值变小了
                currAnswer.RemoveAt(currAnswer.Count - 1);
            }
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // 都是正数，candidates本身可以重复，但是单个结果集里只能被使用一次
        // 结果集本身不允许重复
        public static List<List<int>> WithNoRepeat(int[] candidates, int target)
        {
            Array.Sort(candidates);
            var results = new List<List<int>>();
            var currAnswer = new List<int>();
            CalcWithNoRepeat(candidates, target, results, currAnswer, 0);
            return results;
        }

         
        private static void CalcWithNoRepeat(int[] candidates, int target, List<List<int>> results, List<int> currAnswer, int index)
        {
            if (target == 0)
            {
                var tmp = new List<int>();
                foreach (var i in currAnswer) 
                {
                    tmp.Add(i);  
                }
                results.Add(tmp);
                return;
            }

            
            for (var i = index; i < candidates.Length && candidates[i] <= target; i++)
            {
                //i>index,这里要考虑下，有多个相同的数字时候： 不管这个数字需要出现在结果集里1次or多次，那第一个相同数字大循环的时候，会递归调用到第2，第n个相同数字
                //所以这个数字不管最终需要重复多少次，大循环再次看到相同数字的时候可以跳出，一定包含在相同数字第一次出现的时候了
                //本来写的i>0 ,candidates 里本身重复的元素也不能利用了； i > index，因为i从=index开始运行，所以递归到下一个相同数字可以运行，本身大循环相同数字无需运行（递归到下一个数字开始了一次新的for循环）
                if (i > index && candidates[i] ==  candidates[i-1]) continue;
                currAnswer.Add(candidates[i]);
                CalcWithNoRepeat(candidates, target - candidates[i], results, currAnswer, i+1);//当前数字本身不允许重复，直接进入下一个数字的情况
                currAnswer.RemoveAt(currAnswer.Count - 1);
            }
        }

    }
}
