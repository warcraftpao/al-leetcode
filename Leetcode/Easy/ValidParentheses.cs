using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Easy
{
    public class ValidParentheses
    {
        public static bool Valid(string input)
        {
  
            var dic = new Dictionary<char ,char>();
            //后出现的部分做key
            dic.Add(']', '[');
            dic.Add(')', '(');
            dic.Add('}', '{');
            var queue = new Stack();

            for (var i = 0; i < input.Length; i++)
            {
                if (dic.ContainsValue(input[i]))
                    queue.Push(input[i]);
                else if (dic.ContainsKey(input[i]))
                {
                    var c = (char) queue.Peek();
                    if (c != dic[input[i]])
                        return false;
                    
                    queue.Pop();
                }
            }

            if (queue.Count > 0)
                return false;

            return true;
        }
    }
}
