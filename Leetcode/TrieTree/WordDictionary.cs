using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leetcode.DataStructure;

namespace Leetcode.TrieTree
{
    public class WordDictionary
    {
        private EnglishTrieNode Root;

        public WordDictionary()
        {
            Root= new EnglishTrieNode(); 
        }

        /** Adds a word into the data structure. */
        //这里和ImplementTrie完全一样
        public void AddWord(string word)
        {
            var curr = Root;
            for (var i = 0; i < word.Length; i++)
            {
                curr.AddKey(word[i]);
                curr.TryGet(word[i], out curr);
            }
            curr.MakeEnd();
        }

        /** Returns if the word is in the data structure. A word could contain the dot character '.' to represent any one letter. */
        //这里有点不同了，.可以代表任意字符，说明本层只要任意一个字符串就是合法的，意味着当前children的26条路径都是可能的,需要dfs
        public bool Search(string word)
        {
            return SearchDfs(Root, word, 0);
        }

        private bool SearchDfs(EnglishTrieNode node, string word, int index)
        {
            var curr = node;
            for (var i = index; i < word.Length; i++)
            {
                //是点要递归
                if (word[i] == '.')
                {
                    //不能再这里提前返回false，在递归调用前返回的话，因为我们认为深层递归失败只是一条路失败，不会返回false，会造成超长字符串永远匹配成功的情况
                    var flag = 0;
                    foreach (var child in curr.Children)
                    {
                        if (child != null)
                            //能找到一条路径才是true，但是没找到不能算false，因为其他路径可能还没尝试过
                            if (SearchDfs(child, word, i + 1))
                                return true;
                            else
                                flag++;
                        else
                            flag++;
                    }
                    if (flag == 26)
                        return false;
                }
                else
                {
                    if (!curr.TryGet(word[i], out curr))
                    {
                        return false;
                    }
                }

            }

            return curr.IsEnd;
        }
    }
}
