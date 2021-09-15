using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.NewStart2
{
    public  class Search_a_2D_Matrix2_240
    {
        //懒的写的，比较合理的思路是

        //way1 一行一行，或者一列一列舍弃

        //way2 对行数（或者列数）做2分，最后筛选剩下一行（一列）后，再二分
        //比如横向切割，分成上下两块，如果目标比上面那块的右下角大，则舍弃上半部分，如果目标比下面那块的左上角小，则舍弃下半部分
        //因为顶角的值都有特殊性，是最大或者最小值，纵向切割同理


        //way3 一下切两刀，比如平均分四块，每个单独一块都可以用顶角值的判断，如果目标不在范围内，这块舍弃，如果目标在范围内，则继续切割该块
    }
}
