using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leetcode.DataStructure;

namespace Leetcode.Middle
{
    public class CloneGraph
    {
        //lable当key处理,为啥不用hashcode 或者md5一下 
        //queue里加入老数据，dic里加新数据.
        //考察图的遍历，这是bfs，一个个往队列里塞，关键不能塞重复了 
        public static UndirectedGraphNode Clone(UndirectedGraphNode node)
        {
            if (node == null)
                return null;

            var graph = new UndirectedGraphNode(node.Label);
            var dic = new Dictionary<int, UndirectedGraphNode>();
            dic.Add(graph.Label,graph);

            var queue = new Queue<UndirectedGraphNode>();
            queue.Enqueue(node);

            while (queue.Count > 0)
            {
                var curr = queue.Dequeue();
                foreach (var neighbour in curr.Neighbors)
                {
                    if (!dic.ContainsKey(neighbour.Label))
                    {
                        dic.Add(neighbour.Label, new UndirectedGraphNode(neighbour.Label));
                        queue.Enqueue(neighbour);
                    }
                    //新节点里的连接关系肯定要加
                    dic[curr.Label].Neighbors.Add(dic[neighbour.Label]);
                }
            }


           return graph;

        }


    }
}
