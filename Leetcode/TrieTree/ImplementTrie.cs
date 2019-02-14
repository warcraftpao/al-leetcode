using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leetcode.DataStructure;

namespace Leetcode.TrieTree
{
    public class ImplementTrie
    {
        EnglishTrieNode Root;
        public ImplementTrie()
        {
            Root= new EnglishTrieNode();
        }

        //注意：到结尾的地方才标注IsEnd
        public void Insert(string word)
        {
            var curr = Root;
            for (var i = 0; i < word.Length; i++)
            {
                curr.AddKey(word[i]);
                curr.TryGet(word[i], out curr);
            }
            curr.MakeEnd();
        }

        public bool Search(string word)
        {
            var curr = Root;
            for (var i = 0; i < word.Length; i++)
            {
                if (!curr.TryGet(word[i], out curr))
                {
                    return false;
                }
            }

            return curr.IsEnd;
        }

        public bool StartWith(string prefix)
        {
            var curr = Root;
            for (var i = 0; i < prefix.Length; i++)
            {
                if(!curr.TryGet(prefix[i], out curr))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
