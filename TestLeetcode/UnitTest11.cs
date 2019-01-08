using System;
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
    }
}
