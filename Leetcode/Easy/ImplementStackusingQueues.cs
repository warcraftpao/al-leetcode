using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Easy
{
    /// <summary>
    /// Implement Stack using Queues
    /// 单个队列实现
    /// </summary>
    public class MyStatck1
    {
        private Queue<int> q;
        public MyStatck1()
        {
            q = new Queue<int>();
        }

        /** Push element x onto stack. */
        public void Push(int x)
        {
            q.Enqueue(x);
        }

        /** Removes the element on top of the stack and returns that element. */
        //循环队列长度-1次，把每个元素取出来再加入队列
        //最后再出队
        public int Pop()
        {
            var len = q.Count;
            if (len == 1)
            {
                return q.Dequeue();
            }
            else if(len >1)
            {
                for (var i = 0; i <= q.Count - 2; i++)
                {
                    var e = q.Dequeue();
                    q.Enqueue(e);
                }
                return q.Dequeue();
            }
            throw new Exception("empty stack");
        }

        /** Get the top element. */
        public int Top()
        {
            var len = q.Count;
            if (len == 1)
            {
                return q.Peek();
            }
            else if (len > 1)
            {
                for (var i = 0; i <= q.Count - 2; i++)
                {
                    var e = q.Dequeue();
                    q.Enqueue(e);
                }
                var top = q.Dequeue();
                q.Enqueue(top);
                return top;
            }
            throw new Exception("empty stack");
        }

        /** Returns whether the stack is empty. */
        public bool Empty()
        {
            return q.Count == 0;
        }
    }


    //第二种思路 2个队列，a出队n-1个到b，a再出队最后一个，此时a空，b有n-1个，下一次再从b出队n-2个到a
    //就是从非空的出队一个到不是空的，然后下次交换
    public class MyStatck2
    {
        private Queue<int> q1;
        private Queue<int> q2;
        public MyStatck2()
        {
            q1 = new Queue<int>();
            q2 = new Queue<int>();
        }

        /** Push element x onto stack. */
        public void Push(int x)
        {
             if(q1.Count == 0) 
                q2.Enqueue(x);
             else
                q1.Enqueue(x);
        }

        /** Removes the element on top of the stack and returns that element. */
        
        public int Pop()
        {
            if (q1.Count == 0 && q2.Count >0)
            {
                var len = q2.Count;
                for (var i = 0; i <= len -2; i++)
                {
                    var e = q2.Dequeue();
                    q1.Enqueue(e);
                }
                return q2.Dequeue();
            }

            if(q2.Count == 0 && q1.Count >0)
            {
                var len = q1.Count;
                for (var i = 0; i <= len - 2; i++)
                {
                    var e = q1.Dequeue();
                    q2.Enqueue(e);
                }
                return q1.Dequeue();
            }

            throw new Exception("empty stack");
        }

        /** Get the top element. */
        public int Top()
        {

            if (q1.Count == 0 && q2.Count > 0)
            {
                var len = q2.Count;
                for (var i = 0; i <= len - 2; i++)
                {
                    var e = q2.Dequeue();
                    q1.Enqueue(e);
                }
                var top = q2.Dequeue();
                q1.Enqueue(top);
                return top;
            }

            if (q2.Count == 0 && q1.Count > 0)
            {
                var len = q1.Count;
                for (var i = 0; i <= len - 2; i++)
                {
                    var e = q1.Dequeue();
                    q2.Enqueue(e);
                }
                var top = q1.Dequeue();
                q2.Enqueue(top);
                return top;
            }

            throw new Exception("empty stack");
        }

        /** Returns whether the stack is empty. */
        public bool Empty()
        {
            return q1.Count == 0 && q2.Count == 0;
        }
    }

}
