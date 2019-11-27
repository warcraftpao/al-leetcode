using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Easy
{
    public  class MyQueue
    {
        private Stack<int> s1;
        private Stack<int> s2;
        public MyQueue()
        {
            s1= new Stack<int>();
            s2= new Stack<int>();
        }

        /** Push element x to the back of queue. */
        public void Push(int x)
        {
            s1.Push(x);
        }

        /** Removes the element from in front of queue and returns that element. */
        public int Pop()
        {
            if(Empty())
                throw new Exception("queue is empty");

            if (s2.Count > 0)
                return s2.Pop();
            else
            {
                MoveS1toS2();
                return s2.Pop();
            }

        }

        /** Get the front element. */
        public int Peek()
        {
            if (Empty())
                throw new Exception("queue is empty");

            if (s2.Count > 0)
                return s2.Peek();
            else
            {
                MoveS1toS2();
                return s2.Peek();
            }
        }

        /** Returns whether the queue is empty. */
        public bool Empty()
        {
            return s1.Count == 0 && s2.Count == 0;
        }

        private void MoveS1toS2()
        {
            while (s1.Count > 0)
            {
                s2.Push(s1.Pop());
            }
        }
    }
}
