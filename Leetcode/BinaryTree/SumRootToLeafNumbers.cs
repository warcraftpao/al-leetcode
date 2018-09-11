using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leetcode.DataStructure;

namespace Leetcode.BinaryTree
{
    public class SumRootToLeafNumbers
    {
        //是不是得假设root不能为0？
        public static int GetSum(TreeNode root)
        {
            var sum = 0;
            Helper(root,  ref sum, 0 );
            return sum;
        }

        //levelsum 每层递归不同的，sum 要传地址
        private static void Helper(TreeNode root ,  ref int sum , int levelSum)
        {
            if (root == null)
                return;

            //每次一个root不为null，说明上传递过来的值要*10 加上当前节点的值才是”本层的值“
            levelSum = levelSum*10 + root.Val;
            //如果是叶子了，一条路走完了
            if (root.Left == null && root.Right == null)
            {
                sum += levelSum;
            }

            Helper(root.Left, ref sum, levelSum);
            Helper(root.Right, ref sum, levelSum);
        }

        //make this public we can also test this
        //最后发现没啥用了，思路不对
        public static int ListToInt(List<int> list)
        {
            var length = list.Count ;
            var sum = 0;
            for (var i = 0; i < length; i++)
            {
                sum += list[i]* (int) Math.Pow(10, length - i -1);
            }
            return sum;
        }
 
    }
}
