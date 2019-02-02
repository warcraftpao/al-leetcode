using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.NotUnderstandQuestion
{
    public  class TransposeFile
    {
        //本来是考察bash脚本的，实在无聊弄个文件读着玩
        //假设有一个文件，第一行是字段，后面的行是内容，字段用空格分隔，且一定一样多
        public static List<StringBuilder> Convert()
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "NotUnderstandQuestion\\1.txt");
            var sr = new StreamReader(filePath);
            var line = "";
            var lineNum = 1;
            var colNum = 0;
            var sbs = new List<StringBuilder>(); ;
            while (!string.IsNullOrEmpty( line = sr.ReadLine()))
            {
                var col = line.Split(' ');
                if (lineNum == 1) //header
                {
                    colNum = col.Length;
                    for (var i = 0; i < colNum; i++)
                    {
                        sbs.Add(new StringBuilder());
                        sbs[i].Append(col[i] + " ");
                    }
                }
                else
                {
                    for (var i = 0; i < colNum; i++)
                    {
                        
                        sbs[i].Append(col[i] + " ");
                    }
                }
                lineNum++;
            }

            return sbs;
        }
    }
}
