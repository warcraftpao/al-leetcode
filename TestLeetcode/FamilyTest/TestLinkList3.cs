using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using Leetcode.DataStructure;
using Leetcode.LinkList;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLeetcode.FamilyTest
{
    [TestClass]
    public class TestLinkList3
    {
        [TestMethod]
        public void TestInsertionSortList()
        {
            var head = MyLinkList.BuildListNodeFromArray(new[] {3, 5, 2, 6, 7, 4, 1 });
            var dummy = InsertionSortList.Sort(head);
            Assert.AreEqual(dummy.Next.Val,1);
            Assert.AreEqual(dummy.Next.Next.Next.Val, 3);
            Assert.AreEqual(dummy.Next.Next.Next.Next.Next.Val, 5);
            Assert.AreEqual(dummy.Next.Next.Next.Next.Next.Next.Next.Val, 7);
             
        }

        [TestMethod]
        public void TestIntersectionofTwoLinkedLists()
        {
            var list = BuildNode1();
            var r = IntersectionofTwoLinkedLists.GetIntersection1(list[0], list[1]);
            Assert.AreEqual(r.Val,5 );

            list = BuildNode2();
            r = IntersectionofTwoLinkedLists.GetIntersection1(list[0], list[1]);
            Assert.AreEqual(r, null);
        }

        private List<MyLinkList> BuildNode2()
        {
            var node1= new MyLinkList {Val = 1};
            var node2 = new MyLinkList { Val = 2 };
            var node3 = new MyLinkList { Val = 3 }; ;
            var node4 = new MyLinkList { Val = 4 };
            var node5 = new MyLinkList { Val = 5 };
            var node6 = new MyLinkList { Val = 6 };
            var node7 = new MyLinkList { Val = 7};
            var head1 = new MyLinkList { Val = -1 };
            var head2 = new MyLinkList { Val = -2 };


            //123567-----4567
            head1.Next = node1;
            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;


            head2.Next = node5;
             node5.Next = node6;
            node6.Next = node7;

            return new List<MyLinkList> {head1,head2};
        }

        private List<MyLinkList> BuildNode1()
        {
            var node1= new MyLinkList {Val = 1};
            var node2 = new MyLinkList { Val = 2 };
            var node3 = new MyLinkList { Val = 3 }; ;
            var node4 = new MyLinkList { Val = 4 };
            var node5 = new MyLinkList { Val = 5 };
            var node6 = new MyLinkList { Val = 6 };
            var node7 = new MyLinkList { Val = 7};
            var head1 = new MyLinkList { Val = -1 };
            var head2 = new MyLinkList { Val = -2 };


            //123567-----4567
            head1.Next = node1;
            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node5;


            head2.Next = node4;
            

            node4.Next = node5;
            node5.Next = node6;
            node6.Next = node7;

            return new List<MyLinkList> {head1,head2};
        }
    }
}
