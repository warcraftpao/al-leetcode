using System;
using System.Collections.Generic;
using System.Configuration;
using Leetcode.DataStructure;
using Leetcode.Easy;
using Leetcode.Middle;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLeetcode
{
    [TestClass]
    public class UnitTest10
    {
        [TestMethod]
        public void TestSingleNumber1_hashtable()
        {
            var r = SingleNumber1.GetNumber_hashtable(new[] {2, 2, 3, 3, 4, 4, 1, 5, 5, 6, 7, 8, 8, 7, 6});
            Assert.AreEqual(r, 1);
        }

        [TestMethod]
        public void TestSingleNumber1_bit()
        {
            var r = SingleNumber1.GetNumber_bit(new[] { 2, 2, 3, 3, 4, 4, 1, 5, 5, 6, 7, 8, 8, 7, 6 });
            Assert.AreEqual(r, 1);
        }

        [TestMethod]
        public void TestSingleNumber2()
        {
            //1100011=99
            var r = SingleNumber2.GetNumber(new[] { 0, 1, 0, 1, 0, 1, 99,98,98,98 });
            Assert.AreEqual(r, 99);
        }

        private RandomListNode BuildList()
        {
            var head = new RandomListNode(0);
            var node1= new RandomListNode(1);
            var node2 = new RandomListNode(2);
            var node3 = new RandomListNode(3);
            var node4 = new RandomListNode(4);
            var node5 = new RandomListNode(5);

            head.Next = node1;
            head.Random = node2;

            node1.Next = node2;
            node1.Random = null;

            node2.Next = node3;
            node2.Random = node5;

            node3.Next = node4;
            node3.Random = node3;

            node4.Next = node5;
            node5.Random = node2;
           

            return head;
        }

        [TestMethod]
        public void TestCopyListWithRandomPointer()
        {
            var head = BuildList();
            var newNode = CopyListwithRandomPointer.Clone(head);
            Assert.AreEqual(newNode.Next.Next.Random.Val, 5);
        }


        [TestMethod]
        public void TestWordBreak()
        {
            var r = WordBreak.Isvalid("leetcode", new List<string> {"leet", "code"});
            Assert.AreEqual(r, true);
            r = WordBreak.Isvalid("applepenapple", new List<string> { "apple", "pen" });
            Assert.AreEqual(r, true);
            r = WordBreak.Isvalid("catsandog", new List<string> { "cats", "dog", "sand", "and", "cat" });
            Assert.AreEqual(r, false);
        }

        [TestMethod]
        public void TestWordBreak2()
        {
            var result = WordBreak2.Isvalid("catsanddog", new List<string> {"cat", "cats", "and", "sand", "dog"});
            Assert.AreEqual(result.Contains("cats and dog"),true);
            Assert.AreEqual(result.Contains("cat sand dog"), true);
        }

        [TestMethod]
        public void TestLinkListCycle_notcycle()
        {
            var head = MyLinkList.BuildListNodeFromArray(new[] { 1, 2, 3, 4, 5, 6, 7 });
            var result = LinkListCycle.IsCycle(head);
            Assert.AreEqual(result,false);
          
        }

        
        [TestMethod]
        //大回环的环形
        public void TestLinkListCycle_iscycle_round()
        {
            var head = BuildCycle_round();
            var result = LinkListCycle.IsCycle(head);
            Assert.AreEqual(result, true);

        }

        [TestMethod]
        //6字形的环形
        public void TestLinkListCycle_iscycle_six()
        {
            var head = BuildCycle_six();
            var result = LinkListCycle.IsCycle(head);
            Assert.AreEqual(result, true);

        }


        private MyLinkList BuildCycle_round()
        {
            var head = new MyLinkList();
            var node1 = new MyLinkList { Val = 1 };
            var node2 = new MyLinkList { Val = 2 };
            var node3 = new MyLinkList { Val = 3 };
            var node4 = new MyLinkList { Val = 4 };
            var node5 = new MyLinkList { Val = 5 };
            var node6 = new MyLinkList { Val = 6 };
            var node7 = new MyLinkList { Val = 7 };
            head.Next = node1;
            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;
            node4.Next = node5;
            node5.Next = node6;
            node6.Next = node7;
            node7.Next = node1;

            return head;
        }


        private MyLinkList BuildCycle_six()
        {
            var head = new MyLinkList();
            var node1 = new MyLinkList { Val = 1 };
            var node2 = new MyLinkList { Val = 2 };
            var node3 = new MyLinkList { Val = 3 };
            var node4 = new MyLinkList { Val = 4 };
            var node5 = new MyLinkList { Val = 5 };
            var node6 = new MyLinkList { Val = 6 };
            var node7 = new MyLinkList { Val = 7 };
            head.Next = node1;
            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;
            node4.Next = node5;
            node5.Next = node6;
            node6.Next = node7;
            node7.Next = node3;

            return head;
        }
    }
}
