using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Leetcode.DataStructure;

namespace Leetcode.BinaryTree
{
    public class ConstructTree
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
            var root = Helper_pre_in(preorder, inorder, 0, preorder.Length - 1, 0, inorder.Length - 1);
            return root;
        }

        private static TreeNode Helper_pre_in(int[] preorder, int[] inorder, int preBegin, int preEnd, int inBegin,
            int inEnd)
        {
            //当就剩下一个元素的时候，rootindex 就等于 begin，再次切分begin就会大于end
            if (preBegin > preEnd || inBegin > inEnd)
                return null;
            //root是先序的第一个元素
            var root = new TreeNode(preorder[preBegin]);
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
            root.Left = Helper_pre_in(preorder, inorder, preBegin + 1, preBegin + rootIndex - inBegin, inBegin,
                rootIndex - 1);
            root.Right = Helper_pre_in(preorder, inorder, preBegin + rootIndex - inBegin + 1, preEnd, rootIndex + 1,
                inEnd);
            return root;
        }


        //postorder 后序，右根左
        //思路跟之前一样，区别在于后序列的情况下，root总是在数组的最后一个
        //从后序中找到root，还是去先序找到root的index能确定左右子树长度，其左右子树的根还是在最后，具体模式和 inorder+preorder相同
        public static TreeNode ConstructBinaryTreeFromInorderAndPostorderTraversal(int[] postorder, int[] inorder)
        {
            var root = Helper_post_in(postorder, inorder, 0, postorder.Length - 1, 0, inorder.Length - 1);
            return root;
        }

        private static TreeNode Helper_post_in(int[] postorder, int[] inorder, int postBegin, int postEnd, int inBegin,
            int inEnd)
        {
            if (postBegin > postEnd || inBegin > inEnd)
                return null;
            //root是后序的最后一个元素
            var root = new TreeNode(postorder[postEnd]);
            var rootIndex = 0;
            //在inorder里找到root的index
            for (var i = 0; i < inorder.Length; i++)
            {
                if (postorder[postEnd] == inorder[i])
                {
                    rootIndex = i;
                    break;
                }
            }
            //rootindex - inbegin左子树长度
            root.Left = Helper_post_in(postorder, inorder, postBegin, postBegin + rootIndex - inBegin - 1, inBegin,
                rootIndex - 1);
            root.Right = Helper_post_in(postorder, inorder, postBegin + rootIndex - inBegin, postEnd - 1, rootIndex + 1,
                inEnd);
            return root;
        }


        //Given an array where elements are sorted in ascending order, convert it to a height balanced BST.
        //For this problem, a height-balanced binary tree is defined as a binary tree in which the depth of the two subtrees of every node never differ by more than 1.
        //可以生成多个合法的bst的
        public static TreeNode ConvertSortedArrayToBST(int[] arr)
        {
            return ConvertSortedArrayToBST_helper(arr, 0, arr.Length - 1);
        }

        private static TreeNode ConvertSortedArrayToBST_helper(int[] arr, int left, int right)
        {
            if (left > right) return null;
            //如果是长度是偶数，用  (right + left)/2 和  (right + left)/2 +1 都可以，就成了不同的搜索树
            var mid = (right + left)/2;
            var root = new TreeNode(arr[mid]);
            root.Left = ConvertSortedArrayToBST_helper(arr, left, mid - 1);
            root.Right = ConvertSortedArrayToBST_helper(arr, mid + 1, right);
            return root;
        }

        //快慢指针的方式感觉好麻烦
        //list先转成arry，不就和上面一题一样 了
        public static TreeNode ConvertSortedListToBST(MyLinkList linkList)
        {
            var list = new List<int>();
            var curr = linkList.Next;
            while (curr != null)
            {
                list.Add(curr.Val);
                curr = curr.Next;
            }
            var arr = list.ToArray();
            return ConvertSortedArrayToBST_helper(arr, 0, arr.Length - 1);
        }
    }
}
