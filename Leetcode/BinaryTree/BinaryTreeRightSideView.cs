using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leetcode.DataStructure;

namespace Leetcode.BinaryTree
{
    public   class BinaryTreeRightSideView
    {
        //层级遍历，每层结束的时候获得最右边的那个
        public static List<int> LevelOrderWay(TreeNode root)
        {
            var list = new  List<int>();
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                //当前queue里有几个元素，说明本层有几个node
                var size = queue.Count;
                for (var i = 1; i <= size; i++)
                {
                    var node = queue.Dequeue();
                    if (node != null)
                    {
                        if (node.Left != null) queue.Enqueue(node.Left);
                        if (node.Right != null) queue.Enqueue(node.Right);
                    }
                    if (i == size)
                    {
                        list.Add(node.Val);
                    }
                }
                 
            }

            return list;
        }
    }
}
