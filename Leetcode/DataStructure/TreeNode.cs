using System;
using System.Collections.Generic;
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

        
        public static TreeNode BuildFromArray(int[] arr)
        {
            if (arr.Length == 0)
                return null;
           
            var root = new TreeNode(arr[0]);

            for (var i = 1; i < arr.Length; i++)
            {
                Insert(root, arr[i]);
            }
            return root;
        }

        //给出一个根节点，给二叉树插入新节点
        public static void Insert(TreeNode root, int val)
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
    }
}
