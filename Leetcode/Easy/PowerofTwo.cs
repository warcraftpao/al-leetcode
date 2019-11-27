using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Easy
{
    public  class PowerofTwo
    {
        /// <summary>
        /// 自己写的不停做除法
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool S1(int i)
        {
            if (i < 1) return false;
            if (i == 1) return true;

            //不停除以2
            while (i > 1)
            {
                if (i%2 == 0)
                {
                    i = i/2;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 更好的除法思路
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>

        public static bool S2(int i)
        {
            if (i < 1) return false;

            while (i % 2 == 0)
            {
                i= i / 2;
            }
            return i == 1;
        }

        public static bool S3(int i)
        {
            return (i & (i - 1)) == 0;
        }
    }
}
