using System;
using System.Text;
using System.Collections.Generic;
using Leetcode.DataStructure;
using Leetcode.Easy;
using Leetcode.Hard;
using Leetcode.LinkList;
using Leetcode.Middle;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLeetcode
{
 
    [TestClass]
    public class UnitTest5
    { 
        

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
        public void TestGenerateParentheses()
        {
            var r = GenerateParentheses.Generate(3);
            
            Assert.IsTrue(r.Contains("(())()"));
        }

        
    }
}
