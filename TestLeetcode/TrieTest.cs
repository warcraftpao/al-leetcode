using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leetcode.TrieTree;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLeetcode
{
    [TestClass]
    public  class TrieTest
    {
        [TestMethod]
        public void TestEnglishTireTree()
        {
            bool res;
            var trie = new ImplementTrie();

            trie.Insert("apple");
            res = trie.Search("apple");   // returns true
            Assert.AreEqual(res, true);

            res = trie.Search("app");     // returns false
            Assert.AreEqual(res, false);

            res = trie.StartWith("app"); // returns true
            Assert.AreEqual(res, true);

            trie.Insert("app");
            res = trie.Search("app");     // returns true
            Assert.AreEqual(res, true);
        }

        [TestMethod]
        public void TestEnglishTireTree2()
        {
            bool res;
            var trie = new ImplementTrie();

            trie.Insert("aa");
            res = trie.Search("a");    
            Assert.AreEqual(res, false);

            trie.Insert("a");      
            res = trie.Search("a");
            Assert.AreEqual(res, true);

            res = trie.Search("aaaa");
            Assert.AreEqual(res, false);

            res = trie.StartWith("aa");
            Assert.AreEqual(res, true);

        }

        [TestMethod]
        public void TestWordDictionary()
        {
        //    addWord("bad")
        //    addWord("dad")
        //    addWord("mad")
        //    search("pad")-> false
        //    search("bad")-> true
        //    search(".ad")-> true
        //    search("b..")-> true
            var dic= new WordDictionary();
            dic.AddWord("bad");
            dic.AddWord("dad");
            dic.AddWord("mad");
            var r = dic.Search("pad");
            Assert.AreEqual(r, false);

            r = dic.Search("bad");
            Assert.AreEqual(r, true);

            r = dic.Search(".ad");
            Assert.AreEqual(r, true);

            r = dic.Search("b..");
            Assert.AreEqual(r, true);

            r = dic.Search("..");
            Assert.AreEqual(r, false);

            r = dic.Search("bad.");
            Assert.AreEqual(r, false);

            r = dic.Search("b.d");
            Assert.AreEqual(r, true);

            r = dic.Search("b.d.");
            Assert.AreEqual(r, false);

            r = dic.Search("ba..");
            Assert.AreEqual(r, false);

            dic.AddWord("abc");
            dic.AddWord("axy");
            r = dic.Search("a.y");
            Assert.AreEqual(r, true);
        }
    }
}
