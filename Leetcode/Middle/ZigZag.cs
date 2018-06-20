using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Middle
{
    public class ZigZag
    {
        //Input: s = "PAYPALISHIRING", numRows = 4
        //Output: "PINALSIGYAHRPI"
        //Explanation:

        //P    I    N
        //A  L S  I G
        //Y A  H R
        //P    I
        //如果分r行，那么每r+r-2个形成第一个分支（或者叫叶子，循环）
        //len/(2r+2)大循环，这个循环是纵向扩展的
        //用一个2维数组，r记录行数，
        public static string Zigzag1(string input, int row)
        {
            var len = input.Length;
            var newRows = new StringBuilder[4];
            for (int i = 0; i < row; i++)
            {
                newRows[i] =new StringBuilder();
            }
             
            //一个分支有多长呢？ 假设4行，在一个分支的长度内的行数分别属于1，2，3，4，3，2
            var zigzagLength = 2*row - 2;
            var current = 1;
            var down = 1;
            var up = row - 1;
            for (var i = 0; i <  len; i++)
            {
                if (down <= row)
                {
                    newRows[down - 1].Append(input[i]);
                    down++;
                }
                else if (up >= 2)
                {
                    newRows[up - 1].Append(input[i]);
                    up--;
                }

                //一个zigzag没走完
                if (current < zigzagLength)
                {
                    
                    current++;
                }
                else
                {
                    current = 1;
                    down = 1;
                    up = row - 1;
                }
                
            }

            var sb =new StringBuilder();
            foreach (var newRow in newRows)
            {
               
                    sb.Append(newRow);
                
            }

            return sb.ToString();
        }
    }
}
