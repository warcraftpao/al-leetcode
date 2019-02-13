using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Middle
{
    public  class CourseSchedule
    {
        //用有向图解决，找出有向图里是否有环
        //看了别人的思路，有向图用2重数组表示（字典也行）代表某个点能连到那些点（某个课程是哪些课程的前置课程）
        //用一个数组表示入度，即为连到某个点的点有几个（某个课程有几门前置课程）
        //把入度为零的点加入队列开始循环
        //出栈（删除）一个入度为零的点，同时这个点连到的其他点的入度数组也减1（因为删除的这个点不可能有其他点连过来，删掉相当于简化了图本身）
        //如果有产生了新的入度为0的点，把它也加入队列
        //队列清空后，如果所有点的入度是0说明没有环
        //可以画个图看一下，如果最终没有环，所有的点都可以一个个从循环里删除的 参考 https://www.jianshu.com/p/7bd0e260c57d 
        //或者说没有环的有向图，总是可以从0入度的点开始剥洋葱，剥到所有点的入度都是0为止
        public static bool CanFinish(int numCourses, int[,] prerequisites)
        {
            //一个点可以连到哪些点
            var  graph = new Dictionary<int, List<int>>();
            //题目设定课程编号是0到n-1，某个点有几个连过来的点，入度
            var degree = new int[numCourses];

            //初始化一个图和入度
            for (var i = 0; i < prerequisites.GetLength(0); i++)
            {
                if (graph.ContainsKey(prerequisites[i, 1]))
                {
                    graph[prerequisites[i, 1]].Add(prerequisites[i, 0]);
                }
                else
                {
                    graph[prerequisites[i, 1]] = new List<int> { prerequisites[i, 0] };
                }

                degree[prerequisites[i, 0]]++;
            }
            var queue= new Queue<int>();
            //入度为0的点入栈
            for (var i = 0; i < degree.Length; i++)
            {
                if(degree[i]== 0)
                    queue.Enqueue(i);
            }

            while (queue.Any())
            {
                var point = queue.Dequeue();
                //这个点最初的时候就不连到任何其他点
                if(!graph.ContainsKey(point)) continue;
                foreach (var to in graph[point])
                {
                    degree[to]--;
                    if(degree[to] == 0)
                        queue.Enqueue(to);
                }
            }

            return !degree.Any(d => d != 0);
        }
    }
}
