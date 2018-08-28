using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.DP
{
    public class PascalTriangle
    {
        public static List<List<int>> Generate(int numRows)
        {
            var list = new List<List<int>>();
            list.Add(new List<int> {1});
            if (numRows == 1) return list;
            list.Add(new List<int> {1, 1});
            if (numRows == 2) return list;

            for (var i = 2; i < numRows ; i++)
            {
                var rowList = new List<int>();
                var lastRowList = list[i - 1];
                for (var j = 0; j <= i; j++)
                {
                    if (j == 0 || j == i)
                        rowList.Add(1);
                    else
                        rowList.Add(lastRowList[j-1] + lastRowList[j]);
                }
                list.Add(rowList);
            }

            return list;
        }

        //返回第k行
        public static List<int> GetRow(int k)
        {
            //第k行有k个元素
            var list = new int[k];
            list[0] = 1;
            if (k == 1) return list.ToList();
            list[1] = 1;
            if (k == 2) return list.ToList();

            for (var i = 3; i <= k; i++)
            {
                //pay attention here, must calculate from end to head, list[j -1] wont be changed in current loop,can be used in next loop's for list[j];
                //if from head to end, list[j] will be changed in currnet loop , so next loop's list[j -1] has also been changed
                for (var j = i -1; j >= 0; j--)
                {
                    if (j == 0 || j == i - 1)
                        list[j] = 1;
                    else
                        list[j] = list[j] + list[j - 1];
                }
            }
            return list.ToList();
        }
    }
}
