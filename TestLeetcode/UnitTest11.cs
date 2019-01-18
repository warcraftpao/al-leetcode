using System;
using Leetcode.Easy;
using Leetcode.Hard;
using Leetcode.Middle;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLeetcode
{
    [TestClass]
    public class UnitTest11
    {
        [TestMethod]
        public void TestEvaluateReversePolishNotation()
        {
            var tokens = new[] {"2", "1", "+", "3", "*"};
            var r = EvaluateReversePolishNotation.EvalRPN(tokens);
            Assert.AreEqual(r, 9);

            tokens = new[] { "4", "13", "5", "/", "+" };
            r = EvaluateReversePolishNotation.EvalRPN(tokens);
            Assert.AreEqual(r, 6);

            tokens = new[] { "10", "6", "9", "3", "+", "-11", "*", "/", "*", "17", "+", "5", "+" };
            r = EvaluateReversePolishNotation.EvalRPN(tokens);
            Assert.AreEqual(r, 22d);
        }

        [TestMethod]
        public void TestReverseWordsInString()
        {
            var r = ReverseWordsInString.ReserveWords("  I am the   king  ");
            Assert.AreEqual(r, "king the am I");
        }

        [TestMethod]
        public void TestMaximumProductSubarray()
        {
            var r = MaximumProductSubarray.Calc(new[] {2, 3, -2, 4});
            Assert.AreEqual(r,6);

            r = MaximumProductSubarray.Calc(new[] { -2, 0, -1 });
            Assert.AreEqual(r, 0);


            r = MaximumProductSubarray.Calc(new[] { 6,5, -1,-100,0,2,49 ,22});
            Assert.AreEqual(r, 3000);
        }

        [TestMethod]
        public void TestDungeonGame()
        {
            var dungeon = new int[,]
            {
                {-2, -3, 3},
                {-5, -10, 1},
                {10, 30, -5},
            };
            var r = DungeonGame.RescurePrincess(dungeon);

            Assert.AreEqual(r, 7);


            dungeon = new int[,]
            {
                {-1, -2, -3,-4,-5},
                {-6, -7, -8,-9,-10},
                {-11, -12, -13,-14,-15},
                {-16, -17, -18,-19,-20},
                {-21, -22, -23,-24,-25},

            };
            r = DungeonGame.RescurePrincess(dungeon);

            Assert.AreEqual(r, 86);
        }

        [TestMethod]
        public void TestMinInRotatedSortedArrayLevel1()
        {
            var r =  FindMinimumInRotatedSortedArray.Level1(new[] {6, 7, 8, 9, 10, 1, 2, 3, 4, 5});
            Assert.AreEqual(r, 1);

            r = FindMinimumInRotatedSortedArray.Level1(new[] {5, 6, 7, 8, 9, 10, 1, 2, 3, 4});
            Assert.AreEqual(r, 1);

            r = FindMinimumInRotatedSortedArray.Level1(new[] { 10,1,2,3,4,5,6,7,8,9 });
            Assert.AreEqual(r, 1);


            r = FindMinimumInRotatedSortedArray.Level1(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            Assert.AreEqual(r, 1);

            r = FindMinimumInRotatedSortedArray.Level1(new[] { 8, 9, 1, 2, 3, 4, 5, 6, 7 });
            Assert.AreEqual(r, 1);
        }


        //测试有重复值得情况
        [TestMethod]
        public void TestMinInRotatedSortedArrayLevel2()
        {
            var r = FindMinimumInRotatedSortedArray.Level2(new[] { 6, 6, 6, 9, 10, 1, 2, 3, 4, 6 });
            Assert.AreEqual(r, 1);

            r = FindMinimumInRotatedSortedArray.Level2(new[] { 2, 2, 2, 0, 1 });
            Assert.AreEqual(r, 0);

            r = FindMinimumInRotatedSortedArray.Level2(new[] { 2,2,2,2,2,2,1,2 });
            Assert.AreEqual(r, 1);
             

            r = FindMinimumInRotatedSortedArray.Level2(new[] { 8, 8, 1, 1, 3, 4, 4, 4, 4 });
            Assert.AreEqual(r, 1);
        }

        [TestMethod]
        public void TestMinStack()
        {
            var stack= new MinStack();
            stack.Push(-2);
            stack.Push(0);
            stack.Push(-3);
            var min = stack.GetMin();
            Assert.AreEqual(min, -3);
            stack.Pop();
            var value = stack.Top(); 
            Assert.AreEqual(value , 0);
             min = stack.GetMin();
            Assert.AreEqual(min, -2);

        }

        [TestMethod]
        public void TestLongestSubstringTwoDistinct()
        {
            var r = LongestSubstringTwoDistinct.GetLenght("aaabbbbccddddddddddd");
            Assert.AreEqual(r, 13);


            r = LongestSubstringTwoDistinct.GetLenght("acacccbbccaacc");
            Assert.AreEqual(r, 7);
        }
    }
}
