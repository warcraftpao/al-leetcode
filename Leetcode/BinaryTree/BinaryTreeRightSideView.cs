using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leetcode.DataStructure;
using Leetcode.LinkList;

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

        //先判断右子树的深度优先，如果层数小于list个数，说明需要加一个元素
        //因为没有右子树，左子树就会被考察，如果这时候左子树层数不够，就不会被记录，直到层数超过list数
        public static List<int> DfsWay(TreeNode root)
        {
            var list=  new List<int>();
            DfsWayHelper(root, 1, list);
            return list;
        }

        private static void DfsWayHelper(TreeNode node, int level, List<int> list )
        {
            if (node == null)
                return;

            if(level> list.Count)
                list.Add(node.Val);

            DfsWayHelper(node.Right, level + 1, list);
            DfsWayHelper(node.Left, level + 1, list);
        }
    }
}
