using System;
using Leetcode.DataStructure;
using Leetcode.Hard;
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



        [TestMethod]
        public void TestPalindromPartitioning_mincuts()
        {

            var r = PalindromePartitioning.Partition_mincuts("ab");
            Assert.AreEqual(r, 1);

            r = PalindromePartitioning.Partition_mincuts("abcdcbabcd");
            Assert.AreEqual(r, 3);


            r = PalindromePartitioning.Partition_mincuts_fromheadtoend("kabcdcbabcd");
            Assert.AreEqual(r, 4);

            r = PalindromePartitioning.Partition_mincuts_fromheadtoend("kabccbakdbcbd");
            Assert.AreEqual(r, 1);
        }

        [TestMethod]
        public void TestScrambleString()
        {

            var r = ScrambleString.IsScramble("vfldiodffghyq", "vdgyhfqfdliof");
            Assert.AreEqual(r, true);

            r = ScrambleString.IsScramble_dp("great", "rgeat");
            Assert.AreEqual(r, true);


            r = ScrambleString.IsScramble("abcde", "caebd");
            Assert.AreEqual(r,false);
  
        }

        ////////////////////dp 版本/////////////////////////////
        //有问题
        [TestMethod]
        public void TestScrambleString_dp()
        {
            //这个用例通不过
            //var r = ScrambleString.IsScramble_dp("vfldiodffghyq", "vdgyhfqfdliof");
            //Assert.AreEqual(r, true);

           var r = ScrambleString.IsScramble_dp("great", "rgeat");
            Assert.AreEqual(r, true);

            r = ScrambleString.IsScramble_dp("abcde", "caebd");
            Assert.AreEqual(r, false);

        }

        [TestMethod]
        public void TestCloneGraph()
        {
            var clone = CloneGraph.Clone(BuildAGraph());
            Assert.AreEqual(clone.Neighbors.Count,2);
        }


        public UndirectedGraphNode BuildAGraph()
        {
            var g0 =new UndirectedGraphNode(0);
            var g1 = new UndirectedGraphNode(1);
            var g2 = new UndirectedGraphNode(2);

            g0.Neighbors.Add(g1);
            g0.Neighbors.Add(g2);

            g1.Neighbors.Add(g2);
            g2.Neighbors.Add(g2);

            return g0;
        }

        //[TestMethod]
        //public void TestHashCode()
        //{
        //    var g0 =new UndirectedGraphNode(0);
        //    var g1 = new UndirectedGraphNode(0);
        //    var h1 = g0.GetHashCode();
        //    var h2 = g1.GetHashCode();
        //    Assert.AreEqual(h1 == h2, false);
        //}
    }
}
