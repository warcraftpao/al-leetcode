using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.DataStructure
{
    public class EngishTrieNodeSimple
    {

        public string Word { get; private set; }
        public EngishTrieNodeSimple[] Children;

        public EngishTrieNodeSimple()
        {
            Children = new EngishTrieNodeSimple[26];
            Word = null;
        }

        //标记当前节点是最后是结尾
        public void MakeNull()
        {
            Word = null;
        }

        public void SetWord(string word)
        {
            Word = word;
        }
         
        public void AddKey(char key)
        {
            if (Children[key - 'a'] == null)
                Children[key - 'a'] = new EngishTrieNodeSimple();
        }

        public bool TryGet(char key, out EngishTrieNodeSimple node)
        {
            node = null;
            if (Children[key - 'a'] == null)
                return false;

            node = Children[key - 'a'];
            return true;
        }
    }
}
