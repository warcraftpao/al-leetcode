using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leetcode.BinaryTree;

namespace Leetcode.Easy
{
    public   class ExcelSheetColumnTitle
    {
        public static string GetTitle(int col)
        {
            var letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var list = new List<int>();
            while (col  > 0)
            {
                var left = col%26;
                col = col/26;
                if (left > 0)
                {
                    list.Add(left);
                }
                else//没有余数，说明
                {
                    list.Add(26);
                    col--;
                }

            }

            
            var sb = new StringBuilder();
            var radix = 1;
            for (var i = list.Count -1; i >=0 ; i--)
            {
                sb.Append(letters[list[i] -1]);
            }
            return sb.ToString();
        }
    }
}
