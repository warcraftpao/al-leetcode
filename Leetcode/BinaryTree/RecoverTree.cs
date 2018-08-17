using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leetcode.DataStructure;

namespace Leetcode.BinaryTree
{
    public class RecoverTree
    {
        static TreeNode  pre ;
        static TreeNode first ;
        static TreeNode second ;

        //按照inorder排序，返回list一定是递增序列
        //如果有2个值交换错了，在遍历的时候会发生2次 pre> curr 的情况，那么记住出现这个两个情况的curr，交换他们的val就行了 
        public static void Recover(TreeNode root)
        {
           
            SpecialInorderTraversal(root);

            if (first != null && second != null)
            {
                var tmp = first.Val;
                first.Val = second.Val;
                second.Val = tmp;
            }
        }

        private static void SpecialInorderTraversal(TreeNode root)
        {
            if (root == null)
                return;
             

            if (root.Left != null)
                SpecialInorderTraversal(root.Left);

            if (pre == null)
                pre = root;
            else //有pre
            {
                //异常情况
                if (pre.Val > root.Val)
                {
                    if (first == null) //first只有第一次异常赋值
                        first = pre;
                    
                    //second总是赋值，因为有2个情况
                    //1234567 被置换成 1634527的情况，second被赋值2次
                    //1234567 被置换成 1235467的情况，注意second只被赋值了一次，因为只发生了一次pre > root
                    second = root;
                }
                //把当前值当作pre
                pre = root;
            }
            //check value

            if (root.Right != null)
                SpecialInorderTraversal(root.Right);
        }
    }
}
