using System;
using System.Linq;
using Leetcode.DataStructure;
using Leetcode.Easy;
using Leetcode.Middle;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLeetcode
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestTwoSum()
        {
            //diffent way leads different result
            var target = 12;
            var arr = new int[] {1, 3, 4, 5, 6, 7, 9};
            var result = TwoSum.TwoSum2(arr, target);
            Assert.IsTrue(result.Contains(5) && result.Contains(7));

            result = TwoSum.TwoSum1(arr, target);
            Assert.IsTrue(result.Contains(3) && result.Contains(9));
        }

        [TestMethod]
        public void TestAddTwoNumbers()
        {
            var node1 = LinkedList.BuildListNode(new int[] {3, 1, 4});
            var node2 = LinkedList.BuildListNode(new int[] {9, 8, 7});
            var val1 = AddTwoNumbers.AddTwoNumbers1(node1, node2);
            Assert.AreEqual(val1, 1202);

            var node3 = LinkedList.BuildListNode(new int[] { 0, 3, 4 });
            var node4 = LinkedList.BuildListNode(new int[] { 9, 8, 7 });
            var val2 = AddTwoNumbers.AddTwoNumbers2(node3, node4);
            Assert.AreEqual(val2, 1219);
        }

        

        [TestMethod]
        public void TestMaxSubstringWithoutRepeatChar()
        {
            var r = MaxSubstringWithoutRepeatChar.GetMaxSubstringWithoutRepeatChar("stvbxxxxkcsst");
            Assert.AreEqual(r, 5);
        }


    }
}
