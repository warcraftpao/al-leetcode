using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Hard
{
     public  class TextJustification
    {
        //maxWidth应该大于最长的单词长度，单词至少有个一个字母
        //尽量不用trim和padright
        public static List<string> Do(string[] words, int maxWidth)
         {
            var list =new List<string>();
            var len = 0;
            var lineWords = new List<string>();
            var i = 0;
            while(i< words.Length)
            {
                //当前行还能塞个词进去,如果是最后一行不会操作，在循环外加，反正空格规则不同
                if (maxWidth - len >=  words[i].Length)
                {
                    lineWords.Add(words[i]);
                    len = len + words[i].Length;
                    //还有长度可以塞空格，就要塞空格
                    if (maxWidth - len > 1)
                        len = len  + 1; 
                    i++;
                }
                else//塞不进词了 生成当前行
                {
                    var sb1 = new StringBuilder();
                    if (lineWords.Count == 1) //一行就一个单词
                    {
                        sb1.Append(lineWords[0]);
                        for (var a = sb1.Length; a < maxWidth; a++)
                            sb1.Append(" ");
                        list.Add(sb1.ToString());
                    }
                    else //一行多个单次
                    {
                        len = 0; //单词总长度
                        for (var j = 0; j < lineWords.Count; j++)
                            len = len + lineWords[j].Length;

                        var space = maxWidth - len;
                        var additionalSpace = space%(lineWords.Count - 1); //单词之间的空格平均分配后多出来的空格，要分给靠左的单词之间的空格合并在一起  
                        var spaceBetweenWords = space/(lineWords.Count - 1); //两个单次之间最少空格
                        for (var k = 0; k < lineWords.Count; k++)
                        {
                            sb1.Append(lineWords[k]);
                            if (k < lineWords.Count - 1) //不是最后一个单词，之后要加空格
                            {
                                for (var l = 0; l < spaceBetweenWords; l++)
                                {
                                    sb1.Append(" ");
                                }
                                if (additionalSpace > 0)
                                {
                                    sb1.Append(" ");
                                    additionalSpace--;
                                }
                            }
                        }
                        list.Add(sb1.ToString());
                    }
 
                    len = 0;
                    lineWords.Clear();
                    //这里没有i++ 当前单词放在下一次循环处理
                }
                    
            }

            //处理最后一行，反正规则不同分开写没关系
            var sb = new StringBuilder();
            for (var j = 0; j < lineWords.Count; j++)
            {
                sb = sb.Append(lineWords[j]);
                if (sb.Length < maxWidth)
                    sb.Append(" ");
            }

            for (var k = sb.Length; k < maxWidth; k++)
            {
                sb.Append(" ");
            }
            list.Add(sb.ToString());
             
            return list;
         }
    }
}
