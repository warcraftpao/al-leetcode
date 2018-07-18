using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Middle
{
    public class CombinationSum
    {
        // 都是正数，candidates可以重复，单个数字可以重复
        public  static List<List<int>> S1(int[] candidates, int target)
        {
            Array.Sort(candidates);
            var results = new List<List<int>>();
            var currAnswer = new List<int>();
            Calc(candidates, target , results, currAnswer, 0);
            return results;
        }

        //dfs顺序 2，3，7=> 7
        //2 ;22;222;222尝试3失败，222回退到22，223成功
        //22回退到2，23，233失败，2回退，元素2的循环结束
        //3开始以此类推
        private static void Calc(int[] candidates, int target, List<List<int>> results, List<int> currAnswer, int index)
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
                Calc(candidates, target - candidates[i], results, currAnswer, i);
                //回退方法放在递归之后说明，说明到某个数字不能再尝试的时候，再上一次的结果里回退，并且尝试下一个数字
                //因为循环条件里每次target值变小了
                currAnswer.RemoveAt(currAnswer.Count - 1);
            }

        }
    }
}
