using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.NotUnderstandQuestion
{
    public class SimplifyPath
    {
        //https://www.cnblogs.com/zuoyuan/p/3777289.html
        //   单独 /根目录 .当前目录，..上级目录，多个/合并为一个
        public static string Simplify(string path)
        {
            var s = new Stack<string>();
            var  p = path.Split('/');
            foreach(var t in p)
            {
                //栈有元素且，遇到2个点栈pop一个，因为要回退一级目录
                if (s.Count > 0 && t.Equals(".."))
                {
                    s.Pop();
                }
                //一个点，空值都忽略； 栈里没元素的时候两个点也忽略，根目录回退没意义
                else if (!t.Equals(".") && !t.Equals("") && !t.Equals(".."))
                {
                    s.Push(t);
                }
            }
            var list = new ArrayList(s);
            return "/" + string.Join("/", list.ToArray());
        }
    }
}
