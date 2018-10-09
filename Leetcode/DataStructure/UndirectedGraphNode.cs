using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.DataStructure
{
    /// <summary>
    /// 对应下面的格式 {0,1,2#1,2#2,2} 0号节点可以连到1和，2；1号节点可以连接到2；2号节点可连到自己玩。。。。
    /// 1号节点不需要在体现出可以连接到0了。2号节点也不需要再体现出能连接到0和1
    /// </summary>
    public class UndirectedGraphNode
    {
        public int Label;
        public IList<UndirectedGraphNode> Neighbors;

        public UndirectedGraphNode(int x)
        {
            Label = x;
            Neighbors = new List<UndirectedGraphNode>();
        }
    }
}
