using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leetcode.DataStructure;

namespace Leetcode.BinaryTree
{
    public class PathSum
    {
        public static bool HasPathSum(TreeNode root, int sum)
        {
            if (root == null) return false;
            var left = sum - root.Val;
            if (root.Left == null && root.Right == null && left == 0)
                return true;
            return HasPathSum(root.Left, left) || HasPathSum(root.Right, left);
        }

        public static List<List<int>> GetPathSum(TreeNode root, int sum)
        {
            var result = new List<List<int>>();
            var curr = new List<int>();
            curr.Add(root.Val);
            GetPathSum(result, root, sum -root.Val, curr);
            return result;
        }

        private static void GetPathSum(List<List<int>> result, TreeNode root, int sum, List<int> curr)
        {
            //null不判断
            if (root == null)
                return;

             
            //符合条件的加入结果集
            if (root.Left == null && root.Right == null && sum == 0)
            {

                var tmp = new List<int>();
                foreach (var item in curr)
                {
                    tmp.Add(item);
                }
                result.Add(tmp);

                return;
            }

            if(root.Left  != null)
            {
                curr.Add(root.Left.Val);
                GetPathSum(result, root.Left, sum- root.Left.Val, curr);
                curr.RemoveAt(curr.Count - 1);
            }

            if (root.Right != null)
            {
                curr.Add(root.Right.Val);
                GetPathSum(result, root.Right, sum - root.Right.Val, curr);
                curr.RemoveAt(curr.Count - 1);
            }
        }
    }
}
