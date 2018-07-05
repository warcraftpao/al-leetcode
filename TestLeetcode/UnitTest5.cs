using System;
using System.Text;
using System.Collections.Generic;
using Leetcode.DataStructure;
using Leetcode.Easy;
using Leetcode.Middle;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLeetcode
{
 
    [TestClass]
    public class UnitTest5
    { 
        [TestMethod]
        public void TestRemoveNthFromEnd()
        {
            var head = LinkedList.BuildListNode(new[] {1, 2, 3, 4, 5});
            head = RemoveNthFromEnd.S1(head, 2);
            Assert.AreEqual(head.Length(), 4);
        }

        [TestMethod]
        public void TestValidParentheses()
        {
            var r = ValidParentheses.Valid("()");
            Assert.AreEqual(r, true);

            r = ValidParentheses.Valid("()[]{}");
            Assert.AreEqual(r, true);

            r = ValidParentheses.Valid("(]");
            Assert.AreEqual(r, false);

            r = ValidParentheses.Valid("([)]");
            Assert.AreEqual(r, false);

            r = ValidParentheses.Valid("{[]}");
            Assert.AreEqual(r, true);
        }


        [TestMethod]
        public void TestMergeTwoSortedList()
        {
            var head1 = LinkedList.BuildListNode(new[] { 1, 2, 4 });
            var head2 = LinkedList.BuildListNode(new[] { 1, 3, 4 });
            var head3 = MergeTwoSortedList.Merge(head1, head2);
            Assert.AreEqual(head3.Length(), 6);
        }


        [TestMethod]
        public void TestGenerateParentheses()
        {
            var r = GenerateParentheses.Generate(3);
            
            Assert.IsTrue(r.Contains("(())()"));
        }
    }
}
