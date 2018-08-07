using System;
using Leetcode.Hard;
using Leetcode.Middle;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLeetcode
{
    [TestClass]
    public class UnitTest7
    {
        [TestMethod]
        public void TestLongestValidParentheses()
        {
            var r = LongestValidParentheses.S1("()((())()");
            Assert.AreEqual(r,6);


            r = LongestValidParentheses.S2("()((())()");
            Assert.AreEqual(r, 6);
        }

        [TestMethod]
        public void TestSearchinRotatedSortedArray()
        {
            var r = ArrarSearch.SearchinRotatedSortedArray(new [] {6,7, 1,2,3,4,5}, 9);
            Assert.AreEqual(r, -1);


            r = ArrarSearch.SearchinRotatedSortedArray(new[] { 6, 7, 1, 2, 3, 4, 5 }, 4);
            Assert.AreEqual(r, 5);
        }

        [TestMethod]
        public void TestSearchinRotatedSortedArray2()
        {
            var r = ArrarSearch.SearchinRotatedSortedArray2(new[] { 2, 5, 6, 0, 0, 1, 2 }, 0);
            Assert.AreEqual(r, true);


            r = ArrarSearch.SearchinRotatedSortedArray2(new[] { 2, 5, 6, 0, 0, 1, 2 }, 3);
            Assert.AreEqual(r, false);
        }


        [TestMethod]
        public void FindFirstAndLastInSortedArr()
        {
            var r = ArrarSearch.FindFirstAndLastInSortedArr(new[] { 5, 7, 7, 8, 8, 10 }, 7);
            Assert.AreEqual(r[0], 1);
            Assert.AreEqual(r[1], 2);

            r = ArrarSearch.FindFirstAndLastInSortedArr(new[] { 1,2, 3, 4, 5, 6, 8 }, 9);
            Assert.AreEqual(r[0], -1);
            Assert.AreEqual(r[1], -1);
        }

        [TestMethod]
        public void TestSearchInsertPosition()
        {
            var r = ArrarSearch.SearchInsertPosition(new[] {1, 3, 5, 6}, 5);
            Assert.AreEqual(r, 2);

            r = ArrarSearch.SearchInsertPosition(new[] { 1, 3, 5, 6 }, 2);
            Assert.AreEqual(r, 1);

            r = ArrarSearch.SearchInsertPosition(new[] { 1, 3, 5, 6 }, 7);
            Assert.AreEqual(r, 4);

            r = ArrarSearch.SearchInsertPosition(new[] { 1, 3, 5, 6 }, 0);
            Assert.AreEqual(r, 0);
        }

        [TestMethod]
        public void TestValidSudoku()
        {
            var arr = new char[9, 9]
            {
                {'5', '3', '.', '.', '7', '.', '.', '.', '.'},
                {'6', '.', '.', '1', '9', '5', '.', '.', '.'},
                {'.', '9', '8', '.', '.', '.', '.', '6', '.'},
                {'8', '.', '.', '.', '6', '.', '.', '.', '3'},
                {'4', '.', '.', '8', '.', '3', '.', '.', '1'},
                {'7', '.', '.', '.', '2', '.', '.', '.', '6'},
                {'.', '6', '.', '.', '.', '.', '2', '8', '.'},
                {'.', '.', '.', '4', '1', '9', '.', '.', '5'},
                {'.', '.', '.', '.', '8', '.', '.', '7', '9'},

            };
            var r = Sudoku.Validate(arr);
            Assert.AreEqual(r, true);
            //////////////////////////////////////////////////////////
            arr = new char[9, 9]
            {
                {'8','3','.','.','7','.','.','.','.'},
                {'6','.','.','1','9','5','.','.','.'},
                {'.','9','8','.','.','.','.','6','.'},
                {'8','.','.','.','6','.','.','.','3'},
                {'4','.','.','8','.','3','.','.','1'},
                {'7','.','.','.','2','.','.','.','6'},
                {'.','6','.','.','.','.','2','8','.'},
                {'.','.','.','4','1','9','.','.','5'},
                {'.','.','.','.','8','.','.','7','9'},

            };
            r = Sudoku.Validate(arr);
            Assert.AreEqual(r, false);

        }

        [TestMethod] 
        public void TestSudokuSolver()
        {
            var arr = new char[9, 9]
            {
                {'5', '3', '.', '.', '7', '.', '.', '.', '.'},
                {'6', '.', '.', '1', '9', '5', '.', '.', '.'},
                {'.', '9', '8', '.', '.', '.', '.', '6', '.'},
                {'8', '.', '.', '.', '6', '.', '.', '.', '3'},
                {'4', '.', '.', '8', '.', '3', '.', '.', '1'},
                {'7', '.', '.', '.', '2', '.', '.', '.', '6'},
                {'.', '6', '.', '.', '.', '.', '2', '8', '.'},
                {'.', '.', '.', '4', '1', '9', '.', '.', '5'},
                {'.', '.', '.', '.', '8', '.', '.', '7', '9'},

            };
            var r = Sudoku.Solver(arr);
            Assert.AreEqual(r, true);
        }

    }
}
