using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Leetcode.DataStructure;

namespace Leetcode.TrieTree
{
    //这个题是字典树和wordsearch1的结合体
    //先用words建立一个字典树，然后循环board
    //假设有很多单词的话，每个单词都全部递归非常浪费，因为找不到is 也肯定找不到iss
    //反过来思考，循环boar的每个元素，从这个元素开始能找到字典树对应节点且这个节点isEnd=true说明找到一个单词，不是IsEnd则进入递归
    //为什么效率提高了，因为board里组合字符串在查找前缀树的时候，等于同时在查找多个单词了，因为当前前缀是所有单位共有的
    public  class WordSearch2
    {
        private EngishTrieNodeSimple Root;

        public WordSearch2()
        {
            Root= new EngishTrieNodeSimple();
        }

        public void BuildTrie(string[] words)
        {
     
            foreach (var word in words)
            {
                var curr = Root;
                for (var i = 0; i < word.Length; i++)
                {
                    curr.AddKey(word[i]);
                    curr.TryGet(word[i], out curr);
                }
                curr.SetWord(word);
            }
        }

        public List<string> FindWords(char[,] board, string[] words)
        {
            BuildTrie(words);
            var result = new List<string>();
            var used = new bool[board.GetLength(0), board.GetLength(1)];
            for (var i = 0; i < board.GetLength(0); i++)
            {
                for (var j = 0; j < board.GetLength(1); j++)
                {
                    var curr = Root;
                    //board里每个字符都要作为开头循环,  如果当前这个字符能在root的children里找到，进入dfs
                    if (curr.TryGet(board[i, j], out curr))
                    {
                        SearchDfs(board, curr, result, i, j, used);
                    }
                }
            }

            return result;
        }

        private void SearchDfs(char[,] board, EngishTrieNodeSimple node, List<string> result, int row, int col, bool[,] used)
        {
            //如果当前node的word不为空，说明board里走的路径形成的单词，在字典树里找到了，要加入结果集
            //不过可能2条路径形成的单词一样，所以要把单词设定成空（其实感觉判断结果集是否包含单词逻辑是一样的，而且不用写个新的EngishTrieNodeSimple，但是words数量多的时候，性能应该不如给字典树加word属性
            //找到单词还是要继续循环，就好比字典有ab还有abc和abd，必须等到node的children里找不到当前字符才结束
            if (node.Word != null)
            {
                result.Add(node.Word);
                node.MakeNull();
            }
            EngishTrieNodeSimple curr;
            used[row, col] = true;
            //向右走
            if(row < board.GetLength(0) -1 && used[row +1 , col] ==false && node.TryGet( board[row +1, col], out curr))
                SearchDfs(board, curr, result,row+1 ,col, used);

            //向左走
            if (row > 0 && used[row -1, col] == false && node.TryGet(board[row -1, col], out curr))
                SearchDfs(board, curr, result, row - 1, col, used);

            //向下走
            if (col < board.GetLength(1) - 1 && used[row , col +1] == false && node.TryGet(board[row  , col +1], out curr))
                SearchDfs(board, curr, result, row, col + 1, used);

            //向上走
            if (col > 0 && used[row  , col-1] == false && node.TryGet(board[row,  col-1], out curr))
                SearchDfs(board, curr, result, row , col -1, used);

            used[row, col] = false;
             
        }


    }

    
}
