using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Middle
{
    public class RectanglArea
    {
        /// <summary>
        /// ab 长方形1 的左下点
        /// cd 长方形1 的右上点
        /// 
        /// ef 长方形2 的左下点
        /// gh 长方形2 的右上点
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="C"></param>
        /// <param name="D"></param>
        /// <param name="E"></param>
        /// <param name="F"></param>
        /// <param name="G"></param>
        /// <param name="H"></param>
        /// <returns></returns>
        public static int Calc(int A, int B, int C, int D, int E, int F, int G, int H)
        {
            //主要是判断长方形是否有重叠的部分，怎么算有重叠比较难表达
            //怎么算不重叠呢？
            //甲的右边x坐标比乙的左边的x坐标更小，（甲整体在乙左侧）
            //甲的左边x坐标比乙的右边的x坐标更大，（甲整体在乙右侧）
            //甲的上边y坐标比乙的下边的y坐标更小，（甲整体在乙下方）
            //甲的下边y坐标比乙的上边的y坐标更大，（甲整体在乙上方）

            var mostArea = Math.Abs(A - C)*Math.Abs(B - D) + Math.Abs(E - G)*Math.Abs(F - H);
            //no重叠
            if (C < E || A > G || D < F || B > H)
            {
                return mostArea;
            }
            else
            {

                //var right = Math.Min(C, G);
                //var left = Math.Max(A, E);
                //var top = Math.Min(H, D);
                //var bottom = Math.Max(F, B);
                //var overlapArea = (right -left) * (top - bottom);


                //重叠的时候，判断边的位置好麻烦，直接4个x坐标去中间个就对了
                var xList= new List<int> { A, C,E ,G};
                xList.Sort();
                var yList = new List<int> {B, D, G, H };
                yList.Sort();

                var overlapArea = (xList[2] - xList[1])*(yList[2] - yList[1]);
                return mostArea - overlapArea;

               
            }
        }
    }
}
