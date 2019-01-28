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

                    //不喜欢这个写法，感觉含义不明确
                    //col--; 
                    //因为没有0这个概念，没有余数的时候说明当前位上必然是个Z，减掉26更合理
                    col = col - 26;
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
