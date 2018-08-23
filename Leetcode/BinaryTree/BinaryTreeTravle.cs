using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Activation;
using System.Text;
using System.Threading.Tasks;
using Leetcode.DataStructure;

namespace Leetcode.BinaryTree
{
    //左 根节点 右
    public class BinaryTreeTravle
    {
        //https://www.cnblogs.com/grandyang/p/4297300.html
        // https://leetcode.com/problems/binary-tree-inorder-traversal/solution/#  还是leetcode本身清晰 threaded binary tree
        #region inorder
        public static List<int> InorderTraversal_Recursive(TreeNode root)
        {
            var list = new List<int>();
            InorderTraversal_Helper_Recursive(list, root);
            return list;
        }

        private static void InorderTraversal_Helper_Recursive(List<int> results, TreeNode root)
        {
            //节点为空return
            if (root == null) return;
            if(root.Left != null) //不停找左孩子
                InorderTraversal_Helper_Recursive(results, root.Left);
            //没左孩子了，加入结果集
            results.Add(root.Val);

            //最后找右孩子
            if(root.Right!= null)
                InorderTraversal_Helper_Recursive(results, root.Right);

        }


        public static List<int> InorderTraversal_Stack(TreeNode root)
        {
            var list = new List<int>();
            var stack = new Stack<TreeNode>();
            var node = root;
            while (node != null || stack.Count > 0)
            {
                //持续左孩子入栈
                if (node != null)
                {
                   stack.Push(node);
                   node = node.Left;
                }
                else
                {
                    //左孩子为空，出栈
                    var t = stack.Pop();
                    list .Add(t.Val);
                    node = t.Right;
                }
            }
            return list;
        }

        public static List<int> InorderTraversal_Morris(TreeNode root)
        {
            var list = new List<int>();
            var curr = root;
            while (curr != null)
            {
                //没左孩子
                if (curr.Left == null)
                {
                    list.Add(curr.Val);
                    curr = curr.Right;
                }
                //有左孩子
                else
                {
                    var mostRight = curr.Left;
                    while (mostRight.Right != null)
                    {
                        mostRight = mostRight.Right;
                    }
                    var tmp = curr;
                    mostRight.Right = curr;//curr放到mostright 后面
                    curr = curr.Left;//curr 挪到左孩子  这几句绕了半天才对
                    tmp.Left = null;//本来的左孩子88
                }
            }

            return list;
        }

        #endregion

        #region level order

        public static List<List<int>> LevelOrderTraversal_loop(TreeNode root)
        {
            var list = new List<List<int>>();
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                //当前queue里有几个元素，说明本层有几个node
                var size = queue.Count;
                //先进先出，所以一边出一边加没关系，n层出完，里面都是n+1的节点
                var  tmp = new List<int>();
                for (var i = 1; i <= size; i++)
                {
                    var node = queue.Dequeue();
                    if (node != null)
                    {
                        tmp.Add(node.Val);
                        if(node.Left != null) queue.Enqueue(node.Left);
                        if(node.Right != null) queue.Enqueue(node.Right);
                    }
                }
                list.Add(tmp);
            }

            return list;
        }

        //思路，深度几层，返回结果外面那层list就应该有几个元素
        public static List<List<int>> LevelOrderTraversal_recursive(TreeNode root)
        {
            var list = new List<List<int>>();
            LevelOrderTraversal_recursive_helper(list, 1, root);
            return list;
        }

        private static void LevelOrderTraversal_recursive_helper(List<List<int>> result, int level, TreeNode node)
        {
            if (node == null)
                return;//空啥都不做 88

             //当前node不为空，加入list结果集
            if (result.Count < level)
            {
                var currLevelList = new List<int> {node.Val};
                result.Add(currLevelList);
            }
            else
            {
                result[level -1].Add(node.Val);
            }

            if (node.Left != null) LevelOrderTraversal_recursive_helper(result, level + 1, node.Left);
            if (node.Right != null) LevelOrderTraversal_recursive_helper(result, level + 1, node.Right);
        }
        #endregion

        #region zigzag levelorder

        public static List<List<int>> AddZigzagLevelOrderTraversal(TreeNode root)
        {
            var list = new List<List<int>>();
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            var level = 1; //奇数从左向右，偶数从右向左
            while (queue.Count > 0)
            {
                //当前queue里有几个元素，说明本层有几个node
                var size = queue.Count;
                //先进先出，所以一边出一边加没关系，n层出完，里面都是n+1的节点
                var tmp = new List<int>();
                for (var i = 1; i <= size; i++)
                {
                    var node = queue.Dequeue();
                    if (node != null)
                    {
                        tmp.Add(node.Val);
                        if (level%2 == 0)// 本行偶数，入队列的都是应该是奇数行的
                        {
                            if (node.Left != null) queue.Enqueue(node.Left);
                            if (node.Right != null) queue.Enqueue(node.Right);
                        }
                        else
                        {
                            if (node.Right != null) queue.Enqueue(node.Right);
                            if (node.Left != null) queue.Enqueue(node.Left);
                        }
                        
                    }
                }
                list.Add(tmp);
                level++;
            }

            return list;
        }

        #endregion

        #region level order traversal bottom to top

        //这题好像没啥意思，都是用层序遍历1的方法把结果集倒叙排一下
        //还有一个用stack的方法，就是在LevelOrderTraversal_loop里不用 list.Add(tmp);
        //把tmp压入stack，和其他方法没本质区别

        #endregion

        #region  Flatten Binary Tree to Linked List


        //结果还是树的存储结构，不过按照preorder那样排列
        //不会写， 笨办法因该是preorder先转成数组，然后重新构建树，这个网上抄的
        public static void FlattenBinaryTreeToLinkedList(TreeNode root)
        {
            if (root == null) return;
            if (root.Left != null)
            {
                TreeNode cur = root.Left;
                //找到左子树里mostright节点，这是左子树里preorder最后一个节点
                while (cur.Right != null)
                {
                    cur = cur.Right;
                }
                //把root的右子树连到curr后
                cur.Right = root.Right;
                //左娃挪到右娃上，左娃null
                root.Right = root.Left;
                root.Left = null;
            }
            //右娃完成了搬迁，左娃变成右娃，进入下层递归
            FlattenBinaryTreeToLinkedList(root.Right);
        }

        
        #endregion

    }
}
