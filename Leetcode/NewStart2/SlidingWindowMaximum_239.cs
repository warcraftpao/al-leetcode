using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.NewStart2
{
    public class SlidingWindowMaximum_239
    {
        //每次滑动一块，都要求该区域内的最大值，每次都排序显而易见是不是最优解

        //假设有一个数据结构保存了滑块里的所有值，每次滑块移动一步，只是新加入了一个数据，删除一个了数据
        //如果这个数据结构本身支持优先级，排序就可以了


        //way1   java里有priorityQueue， .net里可以用sortedList SortedDictionary

        //SortedDictionary<int, int> 数字本身是key,出现几次是value 每次加新数字就直接addkey 或者value+1,删掉的数字value-1 或者删掉key
        //取max就取第一个就行了



        //way2  双向队列, java deque, c# PowerCollections 
        //滑块长长度是k,最多里面可以存储k个数据,  存入数据存储的是数组下标(有下标不但可以知道移动到哪里了,通过数组访问也能直接拿到值)
        //可以用队首元素去判定是第几次循环了
        //如果滑动了一下(除了前k步),删除队首元素
        //准备把新元素加入队列    
        //如果队列尾部的元素小于当前元素,则一直删除
        //在尾部加入元素
        //
        //
        //更通俗的解释，队列长度最多不超过ｋ，我只需要保存当前范围内最大一个值的坐标就行了，如果这个zuo'biao'zhi
        //队列维持数组下标,越早进入的在越前面,每次移动一次删掉最前面的,所以长度不可能超过ｋ，关键是怎么让最大的浮动到前面去
      // 如果新加入的队列的元素比队列末尾的大,那末尾的值就没意义，直接删除，最后可能就剩下新加入的元素
        //   如果没有末尾的大，那还是把他加进来，之前的出队后它可能就是最大的了，
       //     所以进队列只会循环数组一次，删除队列元素总操作数也不可能超过数组长度
        //
        //
        //
        //


    }
}
