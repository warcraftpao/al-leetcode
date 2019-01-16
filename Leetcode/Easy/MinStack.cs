using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Easy
{
    public class MinStack
    {
        Stack<int>  stack = new Stack<int>();
        private int min = int.MaxValue;
        public void Push(int x)
        {
           //插入更小的值得时候，插入两次，先min后x，所以min总是和stack里的最小值绑定
            if (x <= min)
            {
                stack.Push(min);
                min = x;
            }
            stack.Push(x);
        }

        //pop() -- Removes the element on top of the stack.
        public void Pop()
        {
            //top=min的时候，说明之前肯定入栈2次，要更新min的值
            if (Top() == min)
            {
                stack.Pop();
                min = stack.Pop();
            }
            else stack.Pop();
        }

       // Get the top element.
        public int Top()
        {
            return stack.Peek();
        }

        public int GetMin()
        {
            return min;
        }

    }
}
