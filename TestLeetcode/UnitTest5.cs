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
    }
}
