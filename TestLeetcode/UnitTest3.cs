using System;
using Leetcode.Easy;
using Leetcode.Middle;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLeetcode
{
    [TestClass]
    public class UnitTest3
    {
        [TestMethod]
        public void TestZigzag()
        {
            var r= ZigZag.Zigzag1("PAYPALISHIRING", 4);
            Assert.AreEqual(r, "PINALSIGYAHRPI");

            r = ZigZag.Zigzag2("PAYPALISHIRING", 3);
            Assert.AreEqual(r, "PAHNAPLSIIGYIR");
        }

        [TestMethod]
        public void TestReverseInteger()
        {
            var r = ReverseInteger.Reverse(123);
            Assert.AreEqual(r, 321);

            r = ReverseInteger.Reverse(-123);
            Assert.AreEqual(r,-321);

            r = ReverseInteger.Reverse(120);
            Assert.AreEqual(r, 21);

            r = ReverseInteger.Reverse(2147483647);
            Assert.AreEqual(r, 0);

            r = ReverseInteger.Reverse(-2147483648);
            Assert.AreEqual(r, 0);
        }

        [TestMethod]
        public void TestStringToInteger()
        {
            var r = StringToInteger.Atoi("123213123");
            Assert.AreEqual(r, 123213123);

            r = StringToInteger.Atoi("  -123213123");
            Assert.AreEqual(r, -123213123);

            r = StringToInteger.Atoi("asd 222");
            Assert.AreEqual(r, 0);

            r = StringToInteger.Atoi(" 444 asadasdsa");
            Assert.AreEqual(r, 444);
           
            r = StringToInteger.Atoi("111111111111111");
            Assert.AreEqual(r, 0);
        }

        [TestMethod]
        public void TestPalindromeNumber()
        {
            var r = PalindromeNumber.Solution(-123);
            Assert.AreEqual(r, false);
            
            r = PalindromeNumber.Solution(10);
            Assert.AreEqual(r, false);

            r = PalindromeNumber.IsPalindrome(1234321);
            Assert.AreEqual(r, true);

            r = PalindromeNumber.IsPalindrome(123321);
            Assert.AreEqual(r, true);

            r = PalindromeNumber.Solution(0);
            Assert.AreEqual(r, true);
        }

    }
}
