using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leetcode.DataStructure;

namespace Leetcode.BinaryTree
{
    public class UniqueBinarySearchTrees
    {
        public static int GetNum(int n)
        {
            //动态规划思路，bst，比root小的会在左面，大的会在右面
            //所以假设根=root的时候，会有 root-1个数字在左面，n-root个数字在右面
            //就转化成了，求 dp[root-1]和dp[n-root]。 注意只要任意连的情况，1到5和 2到6的组合情况肯定是一样多的
            //
            //比如1-20, 1让root 就是有dp[0]*dp[19]， 10当root 就是dp[9]* dp[10]，每个情况相加
            var dp = new int[n + 1];
            dp[0] = 1;//为了乘法好做
            dp[1] = 1;//1个数字1个分法

            //比如数字n个时候会依赖到dp[0] 到dp[n-1]的所有情况
            for (var stage = 2; stage <= n; stage++)
            {
                for (var root = 1; root <= stage; root++)
                {
                    dp[stage] += dp[root - 1]*dp[stage - root];
                }
            }

            return dp[n];
        }

        public static List<TreeNode> GetTrees(int n)
        {
            var res = new List<TreeNode>();
            if (n < 1)
            {
                return res;
            }

            return Helper(1, n);

        }

        private  static  List<TreeNode> Helper(int left, int right)
        {
            var  res = new List<TreeNode>();
            //最下层节点（叶子）的孩子是空，此时递归开始逐步返回
            if (left > right)
            {
                res.Add(null);
                return res;
            }

            //比如12345 的递归调用如下
            //第一层：循环12345，假设3当root的时候
            //第二层：left循环1，2 爸爸是3
            //1 当root，左孩子返回空，右孩子是2（左孩子还是进入递归后返回空，右孩子其实还有2层递归，返回的是2指向空）
            //2 当root，右孩子是1，左孩子是空
            //所以3的左孩子是1-2 和2-1 ，同理3的右孩子是4-5和5-4

            //所以只有一个元素的时候返回 a null null的模式
            //最后拆分到2个元素的时候，就返回2个情况（a<b) a null b null null 或者b a null null null
            for (var i = left; i <= right; i++)
            {
                var leftRes = Helper(left, i - 1);
                var rightRes = Helper(i + 1, right);
                //下层递归生成的子树集合给当前层的root当左右子树
                for (var m = 0; m < leftRes.Count; m++)
                {
                    for (var n = 0; n < rightRes.Count; n++)
                    {
                        var root = new TreeNode(i)
                        {
                            Left = leftRes[m],
                            Right = rightRes[n]
                        };
                        res.Add(root);
                    }
                }
            }
            return res;
        }
    }
}
