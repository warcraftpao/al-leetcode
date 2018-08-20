using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Leetcode.DataStructure;

namespace Leetcode.BinaryTree
{
   public  class ConstructTree
    {
        //preorder 先序 根左右
        //inorder 中序 左根右

            //思路，先序 根节点是no1 ，后面的元素，肯定左子树并称一坨，右子树一坨
            //中序，中间的是跟节点，左右分别是左右子树节点，从先序里找到root，从中序里切割root，可以得到左右子树元素数量
            //那么又可以从先序里得到左右2个子树的元素，从而知道他们的root是谁，循环之
            //结束条件应该是root 不能再分割了 
            //每次inorder 按照root切分成左右两块进入下层，preorder需要算出来左右子树长度切分进入下层循环
       public static TreeNode ConstructBinaryTreeFromPreorderAndInorderTraversal(int[] preorder, int[] inorder)
       {
           var root = Helper(preorder, inorder, 0, preorder.Length - 1, 0, inorder.Length - 1);
           return root;
       }

       private static TreeNode Helper(int[] preorder, int[] inorder,int preBegin, int preEnd, int inBegin, int inEnd)
       {
            //当就剩下一个元素的时候，rootindex 就等于 begin，再次切分begin就会大于end
           if (preBegin > preEnd || inBegin > inEnd)
               return null;
           //root是先序的第一个元素
           var root  = new TreeNode(preorder[preBegin]);
           var rootIndex = 0;
           //在inorder里找到root的index
           for (var i = 0; i < inorder.Length; i++)
           {
               if (preorder[preBegin] == inorder[i])
               {
                    rootIndex = i;
                    break;
                }
                   
           }
           //rootindex= 多少，说明左子树有几个元素
           //rootindex - inbegin说明左子树有几个元素 inorder要跳过root的位置
           root.Left = Helper(preorder, inorder, preBegin + 1, preBegin + rootIndex - inBegin, inBegin,  rootIndex - 1);
           root.Right = Helper(preorder, inorder, preBegin + rootIndex - inBegin + 1, preEnd,  rootIndex + 1, inEnd);
           return root;
       }
    }
}
