using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Leetcode.DataStructure;

namespace Leetcode.Hard
{
      
    public class MaxPointsInLine
    {
        //2点一线，斜率相同的在一条直线上
        // 循环每个点，从每个点都出发，算一下这个点到其他所有点的斜率，如有相同就+1，
        // 注意，单纯斜率相同不一定在一条直线上，他们可以平行，所以每个大循环内都要算计算同一斜率下, 因为换一个初始出发点，就不在一条直线上了
        public static int Get(Point[] points)
        {

            var max = 1;
            //大循环，从每个点出发
            for (var i = 0; i < points.Length; i++)
            {
                //不是指自己，而是指坐标重合的点
                var samePoint = 0;
                //斜率对应的数量
                var dic = new Dictionary<float,int>();
                //point i连到其他点
                for (var j = 0; j < points.Length; j++)
                {
                    //自己不连接到自己
                    if(i == j)
                        continue;

                    //坐标重合, 不用算斜率了
                    if (points[i].X == points[j].X && points[i].Y == points[j].Y)
                    {
                        samePoint++;
                        continue;
                    }

                    float slope;
                    //横坐标相同(一条竖线），斜率无限
                    if (points[i].X == points[j].X)
                    {
                        slope = float.MaxValue; 
                       
                    }
                    else
                    {
                        slope = CalcSlope(points[i], points[j]);
                    }
                   
                    if (dic.ContainsKey(slope))
                        dic[slope]++;
                    else
                    {
                        dic.Add(slope, 2);//一条线至少2个点吧
                    }
                }

                //斜率最多的那个线，再加上同坐标的数量
                var localMax = dic.Values.Max() + samePoint;
                max = Math.Max(max, localMax);
            }
            return max;
        }

        private static float CalcSlope(Point a, Point b)
        {
            var slope = (float)(a.Y - b.Y)/(a.X - b.X);
            return slope;
        }

        /// <summary>
        /// 考虑到浮点数精度的问题，最合理的做法是这样的：
        /// 考虑到坐标都是int型
        /// 斜率相同的线（包括负数），y1-y2 和 x1-y2不做除法，而是求出他们的最大公约数，并且除以最大公约数后，得到 deltaX和 deltaY这样一对值肯定相同的
        /// 用 数值对deltaX和 deltaY 作为字典的key就可以了
        /// </summary>
        /// <param name="points"></param>
        public static void Get2222(Point[] points)
        {
            
        }


    }
}
