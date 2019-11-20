using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leetcode.DataStructure;

namespace Leetcode.BinaryTree
{
    public class CountCompleteTreeNodes
    {
        //最简单的就是全遍历
        //改进的方法就是先判断左右子树是否相等，相等就是直接用公式算，否则再遍历（这里面还能分递归 迭代）

        //题目本身的提示是binary search
        //因为是 只有最后一层节点不全，而且都靠左边 思路变为差找最后一层那个节点开始缺失了
        //先求出整个树的高度h，那么最后一层最多有2^h-1次方个节点，
        //那么2分法的思路就是看中间节点是否存在，不存在就往小的编号切割，存在的话往大的编号切割
        //所以现在问题在于，知道了最后一层节点的编号，比方说的第四层的 第四个节点，这不是数组，不能随机访问，必须从root遍历下来，需要找到一个从root遍历到该节点的方式
        //我自己的思路是父子节点的关系是m=2n+1和 m=2n+2 但是遍历只能从上之下，从下往上是做不到的
        //参考别人的思路： 假设第四层节点编号转换成二进制  000 001 010 011 100 101 110 111
        //每一位上的0和1 代表从跟节点开始走左子树走还是走右子树走

        
        public static int Calc(TreeNode root)
        {
            var height = Getheight(root);

            var left = 0;
            var m = 0;
            var right = (1 << (height - 1)) - 1;

            while (left <= right)
            {
                m = (left + right)/2;
                if (Exist(root, height, m))
                    left = m + 1;
                else
                    right = m - 1;
            }
            //假设有5层，前4层有 2的4次方 -1个节点，表达式前半部分多了1 
            //right是从0开始的节点编号，少1 ，正好抵消
            return (1 << (height - 1)) + right;
        }

        //num 节点编号
        //假设高度是4，那么最后一层的编号的二进制有3位，所以循环3次
        //第一次1<<2 从根节点怎么走，第二次1<<1 从第二层怎么走，第三次1<<0 从第三层怎么走

        //We use the expression (myByte & (1 << position)) != 0 to check if a bit is set. 
        //1<< position后只有position这个位置是1，& 操作符后所有0的位置都变成0了，只有被测试的那位决定最终值是否是0
        private static bool Exist(TreeNode root, int height, int num)
        {
            var node = root;
            for (var i = height - 2; i >= 0; i--)
            {
                //这里不能写 ==1 
                if ((num & 1 << i) != 0)
                    node = node.Right;
                else
                    node = node.Left;

            }

            var exist = node != null;
            return exist;
        }


        private static int Getheight(TreeNode root)
        {
            if (root == null)
                return 0;

            return Getheight(root.Left) + 1;
        }
    }
}
