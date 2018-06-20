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
        //这个自己写的，思路跟答案1一样
        public static string Zigzag1(string input, int row)
        {
            var len = input.Length;
            var newRows = new StringBuilder[4];
            for (int i = 0; i < row; i++)
            {
                newRows[i] =new StringBuilder();
            }
             
            //一个分支有多长呢？ 假设4行，在一个分支的长度内的行数分别属于1，2，3，4，3，2
            //down标识竖的那行，up标识斜的那行
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


        //思路2，按照行循环，第一行和最后一行肯定包含间隔row*2-2（一个zigzage的长度）位置的元素
        //其他的行还额外包含一个当前位置减掉行号的值
        public static string Zigzag2(string input, int row)
        {
            var sb = new StringBuilder();
            var len = input.Length;

            //这里的zigzag标识 每行的每个竖列元素之间间隔，注意除了第1行和最后1行的行有2个元素，这个元素是zigzig-row
            var zigzag = row*2 - 2;

            for (int i = 0; i < row; i++)
            {
                //每次跳跃一个zigzag，注意数组长度
                for (var j = 0; j + i < len; j += zigzag)
                {
                    sb.Append(input[i + j]);
                    if(i !=0 && i != row -1 && j + zigzag - i < len )
                        sb.Append(input[j + zigzag - i]);
                }
            }

            return sb.ToString();
        }
    }
}
