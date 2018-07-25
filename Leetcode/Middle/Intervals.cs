using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Middle
{
    public class Intervals
    {
        public static List<Interval> Merge(Interval[] intervals)
        {
            //先排序
            Array.Sort(intervals);
            var list = new List<Interval>();
            list.Add(intervals[0]);
            for (var i = 1; i < intervals.Length; i++)
            {
                if (intervals[i].Start <= list[list.Count - 1].End )
                {
                    //这里需要考虑 某个interval完全被包含在当前merge里的情况
                    if ( intervals[i].End >= list[list.Count - 1].End) 
                        list[list.Count - 1].End = intervals[i].End;
                }
                else
                {
                    list.Add(intervals[i]);
                }
            }
            return list;
        }

        //设定为当前interval都不重叠
        public static List<Interval> Insert(Interval[] intervals,Interval newInterval)
        {
            //先排序
            Array.Sort(intervals);
            var list = new List<Interval>();
            var i = 0;
            //先找到比新区间起点还小的，直接加入
            while (i < intervals.Length && intervals[i].End < newInterval.Start)
            {
                list.Add(intervals[i]);
                i++;
            }

            //如果数组没结束，重叠部分出现,先定起点，end没关系，下次while会判
            if (i < intervals.Length)
            {
                list.Add(new Interval(Math.Min(newInterval.Start, intervals[i].Start), newInterval.End));
            }

            //往后继续扫描直到新节点的end还是大于某个区间开始的，还是重叠的，扩展end
            while (i < intervals.Length && newInterval.End >= intervals[i].Start)
            {
                list[list.Count - 1].End = Math.Max(newInterval.End, intervals[i].End);
                i++;
            }

            while (i < intervals.Length)
            {
                list.Add(intervals[i]);
                i++;
            }

            return list;
        }

        public static Interval[] Sort()
        {
            var v1= new Interval(3,5);
            var v2 = new Interval(1, 4);
            var v3 = new Interval(9, 11);
            var v4 = new Interval(2, 5);
            var vs = new [] {v1,v2,v3,v4};
            Array.Sort(vs);
            return vs;
        }

    }

    
    //Definition for an interval. end should > start
    public class Interval: IComparable
    {
        public int Start;
        public int End;
         
        public Interval(int s, int e)
        {
            Start = s;
            End = e;
        }

        public int CompareTo(object o)
        {
            var other = o as Interval;
            if (Start >= other.Start) return 1;
            return -1;
        }

    }

}
