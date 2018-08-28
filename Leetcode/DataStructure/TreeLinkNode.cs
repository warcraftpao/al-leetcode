using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.DataStructure
{
    public class TreeLinkNode
    {
        public TreeLinkNode Left;
        public TreeLinkNode Right;
        public TreeLinkNode Next;
        public int Val;

        public TreeLinkNode(int x)
        {
            Val = x;
        }
    }
}
