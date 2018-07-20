using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Middle
{
    public class RotateImage
    {
        //自己写的
        //必须是n*n 的数组
        //像剥皮一样一层层往里剥，所以大循环只要lenght/2,层数奇数最里面那层（1个值）不用动
        //每层大循环四个数字一组循环复制。
        public static void Rotate(int[,] arr)
        {
            var len = arr.GetLength(1);
            var reduce = 1;
            for (var i = 0; i < len / 2; i++)
            {
                for (var j = i; j < len - reduce; j++)
                {
                    var tmp = arr[i, j];
                    arr[i, j] = arr[len -j -1, i];
                    arr[len - j - 1, i] = arr[len - i -1, len - j -1];
                    arr[len - i -1, len - j -1] = arr[j, len -i -1];
                    arr[j, len - i - 1]  = tmp;
                }
                reduce++;
            }
        }
    }
}
