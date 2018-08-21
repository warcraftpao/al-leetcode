using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leetcode.DataStructure;

namespace Leetcode.BinaryTree
{
    public  class BalancedTree
    {
        public static bool IsBalanced(TreeNode root)
        {
            if (root == null)
                return true;

            if(GetDepth_diff(root) == - 1)
                return false;
            return true;
        }

        //这个方法名觉得叫什么都有点别扭，在return的时候返回的是高度
        //在abs(left - right)的时候算的又是高度差,即使正常情况下返回高度，返回-1代表不平衡
        private static int GetDepth_diff(TreeNode root)
        {
            //null给爸爸提供了0层深度
            if (root == null)
                return 0;

            var leftHeight = GetDepth_diff(root.Left);
            var rightHeihgt = GetDepth_diff(root.Right);

            //这句要注意，想了一会，如果只有绝对值判定那行
            //假设有一个节点的左子树不平衡了，程序还是会去判右子树,它的爸爸还是会再去多余的判定左（右）子树
            //多了这行后，看到-1就逐层向上传递-1，省略了不必要的判断
            if (leftHeight == -1 || rightHeihgt == -1)
                return -1;

            if (Math.Abs(leftHeight - rightHeihgt) > 1)
                return -1;

            return Math.Max(rightHeihgt, leftHeight) + 1;
        }
    }
}
