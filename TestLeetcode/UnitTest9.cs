using System;
using Leetcode.Middle;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLeetcode
{
    [TestClass]
    public class UnitTest9
    {
        [TestMethod]
        public void TestSurroundedRegions()
        {
            var board1 = BuildBoard1();
            SurroundedRegions.Solve_dfs(board1);
            Assert.AreEqual(board1[1, 1], 'x');
            Assert.AreEqual(board1[1, 2], 'x');
            Assert.AreEqual(board1[1, 3], 'x');
            Assert.AreEqual(board1[2, 2], 'x');
            Assert.AreEqual(board1[5, 1], 'o');


            var board2 = BuildBoard2();
            SurroundedRegions.Solve_dfs(board2);
            Assert.AreEqual(board2[1, 1], 'x');
            Assert.AreEqual(board2[1, 2], 'x');
            Assert.AreEqual(board2[1, 3], 'x');
            Assert.AreEqual(board2[2, 2], 'x');
            Assert.AreEqual(board2[3, 1], 'o');
            Assert.AreEqual(board2[4, 1], 'o');
            Assert.AreEqual(board2[5, 1], 'o');
        }

        //边上只有一个o的情况
        private char[,] BuildBoard1()
        {
            var board = new char[,]
            {
                {'x', 'x', 'x', 'x', 'x'},
                {'x', 'o', 'o', 'o', 'x'},
                {'x', 'x', 'o', 'x', 'x'},
                {'x', 'x', 'x', 'x', 'x'},
                {'x', 'x', 'x', 'x', 'x'},
                {'x', 'o', 'x', 'x', 'x'},
            };

            return board;
        }

        //边上多个o的情况
        private char[,] BuildBoard2()
        {
            var board = new char[,]
            {
                {'x', 'x', 'x', 'x', 'x'},
                {'x', 'o', 'o', 'o', 'x'},
                {'x', 'x', 'o', 'x', 'x'},
                {'x', 'o', 'x', 'x', 'x'},
                {'x', 'o', 'x', 'x', 'x'},
                {'x', 'o', 'x', 'x', 'x'},
            };

            return board;
        }

        [TestMethod]
        public void TestPalindromPartitioning()
        {

            var r =PalindromePartitioning.Partition("aab");
            Assert.AreEqual(r.Count , 2);

            r = PalindromePartitioning.Partition("abcdcbabcd");
            Assert.AreEqual(r.Count, 8);
        }
    }
}
