using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Middle
{
    //不理解的是 这个重复的意思，比如 AAAGGGAAGGAAAGGGAAGG肯定是符合的
    //但是比如 AG重复6次AGAGAGAGAGAG 这个repeat了吗，看网上的代码逻辑，这样也算的

   // 不考虑这个无非就是每次截取10个字符串，然后每次往后挪动一位，看字符串是否已经存在过
   //用位操作的好处就是本来是截取比较字符串，现在用二进制效率会提升很多，因为dna只有四个字母
    public class RepeatedDNASequences
    {
    }
    //比如二进制是20位(四个字母，用00 01 10 11 就可以表达），那么需要一个18位的掩码（19，20位不存在=0，其他1）
    // 删除最左边的一个字符： 用字符串和这个掩码 &操作，保留18位 
    // 给要新添加的字符留出位置：字符串左位移2，新增的低2位默认变成0
    //加入新的字符：字符串和新字符与  （注意：s[i] 是要转换成2位的模式的，网上s[i] & 7 的意思就是观察了四个字母后三位不同，每次提取出后3位）
    //cur = ((cur & mask) << 2) | s[i];
    //https://blog.csdn.net/To_be_to_thought/article/details/85204687
}
