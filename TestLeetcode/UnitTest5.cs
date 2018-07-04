using System;
using System.Text;
using System.Collections.Generic;
using Leetcode.DataStructure;
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
    }
}
