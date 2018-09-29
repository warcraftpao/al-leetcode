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

        //因为要求出所有最短路径，所以在循环的时候我们还不知道哪些路径最短，使用bfs求出所有路径的方式是不合理的，空间消耗太大
        //所以先求出所有单词的前缀，即为谁能变换一个单词指向我，再用这样的字典来构建路径 
        public static List<List<string>> LadderAllMinPath(string beginWord, string endWord, List<string> wordList)
        {
            var result = new List<List<string>>();
            var preWords =  GetPreWords(beginWord, endWord, wordList);
            if (!preWords.ContainsKey(endWord))
                return result;

            var curr = new List<string> {endWord};
            BuildPathByPreWords(beginWord, endWord, preWords, result, curr);
            //在递归里反转觉得不清晰，在结果集反转次数更少
            foreach (var path in result)
            {
                path.Reverse();
            }
            return result;
        }

        private static Dictionary<string, List<string>> GetPreWords(string beginWord, string endWord,
            List<string> wordList)
        {
            var linkedToWordList = new Dictionary<string,List<string>>();

            var len = beginWord.Length;
            var levelMark = "****";
            var queue = new Queue<string>();
            //下一层出现的单词不能直接删除，可能其他路径也指向这个单词，当前层的路径全部算过再删除
            var nextLevel = new List<string>();
            //是否找到了end，但是及时找到了，本层的循环必须都做完（没有遇到levelmark之前）
            var foundEnd = false;
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
                            var changedStr = new string(currStrCharArr);
                            if (wordList.Contains(changedStr))
                            {
                                //变化后的单词在列表里，需要添加这个单词的前驱，注意前驱可能有多个
                                //因为当前层的单词不会重复，所以某个单词的前驱也不会重复
                                if (linkedToWordList.ContainsKey(changedStr))
                                {
                                    linkedToWordList[changedStr].Add(currStr);
                                }
                                else
                                {
                                    linkedToWordList.Add(changedStr, new List<string> { currStr });
                                }


                                if (changedStr == endWord) //找到endword
                                {
                                    //找到了end，当前单词不用再循环，但是本层要循环，这是跳出当前字母变换的循环
                                    foundEnd = true;
                                    break;
                                }
                                if (!nextLevel.Contains(changedStr))
                                {
                                    queue.Enqueue(changedStr);
                                    nextLevel.Add(changedStr);
                                }
                            }
                        }
                        //找到了end，当前单词不用再循环，但是本层要循环，这里是跳出下一个字母的循环
                        if (foundEnd) break;
                        //进入下一个字母循环前还原本来的值
                        currStrCharArr[i] = curr;
                    }
                }
                //下一层开始
                else if (queue.Any())
                {
                    //由于没有return语句, 某次变换找到了end，还是会有之前循环产生的下一层的值
                    if (foundEnd) break;
                    //层标记，下层循环的单词从wordlist里删除，否则死循环
                    foreach (var word in nextLevel)
                    {
                        wordList.Remove(word);
                    }
                    nextLevel.Clear();
                    queue.Enqueue(levelMark);
                }
            }

            return linkedToWordList;
        }

        //用前驱字典构建最短路径，dfs，从end开始构建，注意需要反转
        private static void BuildPathByPreWords(string beginWord, string endWord,
            Dictionary<string, List<string>> preWords, List<List<string>> result, List<string> curr)
        {
            // begin=前驱了找到结果了
            if (beginWord == endWord)
            {
                //不用在这里反转
                result.Add(new List<string>(curr));
                return;
            }


            var pre = preWords[endWord];
            for (var i = 0; i < pre.Count; i++)
            {
                //从后向前构建，所以beginword不变，endword在变化
                curr.Add(pre[i]);
                BuildPathByPreWords(beginWord, pre[i], preWords, result, curr);
                curr.RemoveAt(curr.Count - 1);
            }
        }
    }
}
