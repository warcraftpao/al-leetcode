using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Hard
{

    //这题主要是参考了网上答案，注意，只需要水平线段的左端点，意思就是结尾高度总是0
    //把建筑分成左右2条边，按照x坐标从小到到排序，x坐标相同再高度高的在前
    //遍历所有边
    //每次遇到左边，如果队列没有值，或者高度比队列最大值还大，说明他肯定是凸出来的建筑需要记录左顶点
    //每次遇到右边，先删除当前高度值（说明当前建筑结束了）如果队列没有值，说明这是最后一个建筑，终点高度是0，
    //或者建筑没结束，但是高度大于队列最大高度 说明该当前建筑比较高，下面有个建筑横向凸出来了，要记录队列里最高建筑和当前建筑的交点
    // 这题关键在于排序队列，遇到左边的时候加入队列，如果队列还有值说明，有某个高度的建筑还没结束，如果当前高度低于等于队列最大高度，
    // 说明这个建筑左顶点肯定被覆盖，否则会产生一个顶点
    //遇到右边的时候把高度移出队列，说明一个建筑结束了，如果队列是0，说明这个建筑肯定某一串建筑的终点，需要有一个高度0的点
    //如果队列不是0，而且当前高度比最大高度高，说明当前建筑和某个建筑产生了交点，因为只需要左顶点，所以结果集是用的队列最大高度值

    //注意，如果有高度相同的建筑 移除高度值的时候不会产生影响，如果一串建筑高度都相同，最后一个建筑结束的时候记录高度为0的点就满足要求（本来就只需要2个点）
    public class SkylineProblem
    {
        public static List<List<int>> Calc(int[][] buildings)
        {
            var edgeList = new List<Edge>();
            foreach (var building in buildings)
            {
                //左边
                edgeList.Add(new Edge
                {
                    X = building[0],
                    Height = building[2],
                    IsLeft =true
                });
                //右边
                edgeList.Add(new Edge
                {
                    X = building[1],
                    Height = building[2],
                    IsLeft = false
                });
            }

            edgeList =  edgeList.OrderBy(e => e.X).ThenByDescending(e => e.Height).ToList();
            var heightList= new SortedSet<int>();
            var result = new List<List<int>>();

            foreach (var edge in edgeList)
            {
                if (edge.IsLeft)
                {
                    if (heightList.Count == 0 || edge.Height > heightList.Last())
                    {
                        result.Add(new List<int> {edge.X, edge.Height});
                    }
                    heightList.Add(edge.Height);
                }
                else//right
                {
                    heightList.Remove(edge.Height);
                    if (heightList.Count == 0)
                    {
                        result.Add(new List<int> { edge.X, 0 });
                    }
                    else if(edge.Height > heightList.Last())
                    {
                        result.Add(new List<int> { edge.X, heightList.Last() });
                    }
                             
                }
            }

            return result;
        }
        


        internal class Edge
        {
            public int X;
            public int Height;
            public bool IsLeft;
        }
    }
}
