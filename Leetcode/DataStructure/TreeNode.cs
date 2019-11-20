using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.DataStructure
{
    public class TreeNode
    {
        public int Val;
        public TreeNode Left;
        public TreeNode Right;

        public TreeNode(int x)
        {
            Val = x;
        }


        /// <summary>
        /// 这是建立符合规范的二叉搜索树的代码
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static TreeNode BuildBSTFromArray(int[] arr)
        {
            if (arr.Length == 0)
                return null;
           
            var root = new TreeNode(arr[0]);

            for (var i = 1; i < arr.Length; i++)
            {
                Insert_BST(root, arr[i]);
            }
            return root;
        }

        /// <summary>
        /// 给出一个根节点，给二叉搜索树插入新节点
        /// </summary>
        /// <param name="root"></param>
        /// <param name="val"></param>
        public static void Insert_BST(TreeNode root, int val)
        {
            var  curr = root;
            while (true)
            {
                var parent = curr;
                if (curr.Val >= val)//left
                {
                    curr = curr.Left;
                    if (curr == null)
                    {
                        parent.Left = new TreeNode(val);
                        break;
                    }
                        
                }
                else//right
                {
                    curr = curr.Right;
                    if (curr == null)
                    {
                        parent.Right = new TreeNode(val);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// 建立一个Perfect二叉树
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public static TreeNode BuildPerfectTree(int height)
        {
           var root = new TreeNode(0);
           var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            //循环heigh-1次
            for (var i = 0; i < height - 1; i++)
            {
                var number = queue.Count;
                for (var j = 1; j <= number; j++)
                {
                    var node = queue.Dequeue();
                    var left = new TreeNode(0);
                    node.Left = left;
                    var right = new TreeNode(0);
                    node.Right = right;
                    queue.Enqueue(left);
                    queue.Enqueue(right);
                }
            }

            return root;
        }


        /// <summary>
        /// 建立一个随机Compelete二叉树，最后一层不一定满节点，子节点尽量靠左
        /// </summary>
        /// <param name="height"></param>
        /// <param name="lastLevelNumber">最后一层节点数，>=1 小于等于 2的height-1次方 </param>
        /// <returns></returns>
        public static TreeNode BuildRandomCompeleteTree(int height, int lastLevelNumber)
        {
            var root = new TreeNode(0);
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            //循环heigh-1次
            for (var i = 0; i < height - 1; i++)
            {
                var number = queue.Count;
                var loopTime = 1;
                if (i == height - 2)
                {
                    loopTime = lastLevelNumber;
                }
                var count = 0;
                for (var j = 1; j <= number; j++)
                {
                    var node = queue.Dequeue();
                    var left = new TreeNode(0);
                    node.Left = left;
                    count ++;
                    if (count == loopTime && i== height -2)
                        break;

                    var right = new TreeNode(0);
                    node.Right = right;
                    count++;
                    if (count == loopTime && i == height - 2)
                        break;

                    queue.Enqueue(left);
                    queue.Enqueue(right);
                }
            }

            return root;
        }
    }
}
