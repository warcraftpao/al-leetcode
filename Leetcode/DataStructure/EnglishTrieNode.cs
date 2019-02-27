using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.DataStructure
{
    //每一个字典树节点本身没有value，只是有一个26位长度的数组，0到25的位置分别代表某个a到z开头的字母字典树
    //如果数组某一位的字典树是null说明还没这条路径
    public class EnglishTrieNode
    {
        public bool IsEnd { get; private set; }
        public EnglishTrieNode[] Children;

        public EnglishTrieNode()
        {
            Children= new EnglishTrieNode[26];
            IsEnd = false;
        }

        //标记当前节点是最后是结尾
        public void MakeEnd()
        {
            IsEnd = true;
        }
         

        //这个是否含有key，是指children里面是否有特定字符位置的字典树节点是否是null
        private bool ContainsKey(char key)
        {
            return Children[key - 'a'] != null;
        }

        public void AddKey(char key)
        {
            if(!ContainsKey(key))
                Children[key - 'a'] = new EnglishTrieNode();
        }

        public bool TryGet(char key, out EnglishTrieNode node)
        {
            node = null;
            if (!ContainsKey(key))
                return false;

            node = Children[key - 'a'];
            return true;
        }
         
    }
}
