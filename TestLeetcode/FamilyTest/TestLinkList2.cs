using System;
using System.Diagnostics;
using Leetcode.DataStructure;
using Leetcode.Easy;
using Leetcode.LinkList;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLeetcode.FamilyTest
{
    [TestClass]
    public class TestLinkList2
    {
        [TestMethod]
        public void TestReverseLinkedList()
        {
            var r = ReverseLinkedList.Reserve(MyLinkList.BuildListNodeFromArray(new[] {1, 2, 3, 4, 5}));
            Assert.AreEqual(r.Next.Val,5);
            Assert.AreEqual(r.Next.Next.Val, 4);
            Assert.AreEqual(r.Next.Next.Next.Next.Next.Val, 1);

            r = ReverseLinkedList.Reserve_Recursive(MyLinkList.BuildListNodeFromArray(new[] { 1, 2, 3, 4, 5 }));
            Assert.AreEqual(r.Next.Val, 5);
            Assert.AreEqual(r.Next.Next.Val, 4);
            Assert.AreEqual(r.Next.Next.Next.Next.Next.Val, 1);
        }

        [TestMethod]
        public void TestReserverInMtoN()
        {
            var r = ReverseLinkedList.ReserverInMtoN(MyLinkList.BuildListNodeFromArray(new[] { 1, 2, 3, 4, 5,6,7 }),3,6);
            Assert.AreEqual(r.Next.Next.Next.Val, 6);
            Assert.AreEqual(r.Next.Next.Next.Next.Next.Next.Val, 3);
        }

        [TestMethod]
        public void TestLinkListCycle_notcycle()
        {
            var head = MyLinkList.BuildListNodeFromArray(new[] { 1, 2, 3, 4, 5, 6, 7 });
            var result = LinkListCycle.IsCycle(head);
            Assert.AreEqual(result, false);

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

        [TestMethod]
        public void TestRecordList()
        {
            var head = MyLinkList.BuildListNodeFromArray(new[] { 1, 2, 3, 4, 5, 6, 7 });

            RecordList.Record(head);
            Assert.AreEqual(head.Next.Next.Val,7);
            Assert.AreEqual(head.Next.Next.Next.Next.Val, 6);
            Assert.AreEqual(head.Next.Next.Next.Next.Next.Next.Val, 5);
            Assert.AreEqual(head.Next.Next.Next.Next.Next.Next.Next.Val, 4);

        }
    }
}
