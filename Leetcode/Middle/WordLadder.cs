using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Middle
{
    public class WordLadder
    {
        //找到word的ladder（差一个字符），循环word长度，每个字符用a-z替换（排除本身），用新字符去字典匹配
        //把单词和单次想象成一个图，begin在第一层，所有和他差一个字母的单词在第二层（注意是所有，不能找到一个匹配就结束，因为这条不一定是最短路径）
        //有几种情况，
        //1找到了end，直接返回结果
        //2字典里找到匹配单词，但不是end，这是下一层路径之一
        //3啥都没找到（相当于没有路径了），本次循环不处理，因为没有给queue加入数据，所以while会结束循环
        //当begin本身变换一个字符所有情况都循环完之后，肯定也找到了所有位于第二层的单词，这个时候就进入第三层循环
        //关键点，字典表本身要删除已经找到的单词，否则就死循环了
        //层和层之间需要分割点，意思就是n层循环的单词，变换一个字符找到的匹配单词都是begin通向end的可能路径，当遇到分割符的时候，说明本层循环结束，如果分割符后队列还有元素，说明本层有路径通往下层
        public static int LadderLength(string beginWord, string endWord, List<string> wordList)
        {
            var len = beginWord.Length;
            var levelMark = "****";
            var changeNumber = 1; //beginWord自己也算一次，好奇怪的设定
            var queue = new Queue<string>();
            queue.Enqueue(beginWord);
            queue.Enqueue(levelMark);
            while (queue.Any())
            {
                var currStr = queue.Dequeue();
                if (currStr != levelMark)
                {
                    var currStrCharArr = currStr.ToCharArray();
                    for (var i = 0; i < len; i++)
                    {
                        var curr = currStrCharArr[i];
                        for (var c = 'a'; c <= 'z'; c++)
                        {
                            if (curr == c) continue;
                            currStrCharArr[i] = c;
                            //https://www.cnblogs.com/brightgalaxy/p/7580806.html 注意c# char[]怎么转成string 卡了1天。。。。
                            var changedStr = new string(currStrCharArr);
                            //"each transformed words must be in the wordList"
                            if (wordList.Contains(changedStr))
                            {
                                if (changedStr == endWord) //找到endword
                                {
                                    return changeNumber + 1;
                                }
                                queue.Enqueue(changedStr);
                                wordList.Remove(changedStr);
                            }
                        }
                        //进入下一个字母循环前还原本来的值
                        currStrCharArr[i] = curr;
                    }
                }
                else if(queue.Any())
                {
                    changeNumber++;
                    queue.Enqueue(levelMark);
                }
            }

            return 0;
        }
    }
}
