using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Middle
{
     public class IntegerAndRoman
    {
        //只能标识1到3999，因为任意字符不能重复3次
         public static string ItoR(int i)
         {
             var mod = new[] {1000, 100, 10, 1};
             var a1 = new[] {"M", "C", "X","I"}; //thousand hundred ten one
             var a2 = new[] {"", "D", "L", "V"}; //empty 5hundred 5ten 5one
             var roman = new StringBuilder();
            for(var j=0; j< mod.Length; j++) // 分别mod 10 100 1000 10000
             {
                //求当前位数上的值
                 var num = i / mod[j];
                 switch(num) 
                 {
                    case 1:
                         roman.Append(a1[j]); //I
                        break;
                    case 2:
                        roman.Append(a1[j]+a1[j]);//II
                        break;
                    case 3:
                        roman.Append(a1[j] + a1[j] + a1[j]);//III
                        break;
                    case 4:
                        roman.Append(a1[j] + a2[j]); //IV
                        break;
                    case 5:
                        roman.Append(a2[j]); //V
                        break;
                    case 6:
                        roman.Append(a2[j]+ a1[j]); //VI
                        break;
                    case 7:
                        roman.Append(a2[j] + a1[j] + a1[j]);//VII
                        break;
                    case 8:
                        roman.Append(a2[j] + a1[j] + a1[j] + a1[j]);//VIII
                        break;
                    case 9:
                        roman.Append(a1[j] + a1[j-1]); //IX
                        break;
                }
                 i = i% mod[j];
             }

             return roman.ToString();
         }

        //I 可以出现在 VX前一次，X可以出现再ＬＣ前一次，Ｃ可以出现在DM前一次
        // 只能转换1到3999对应的罗马数
        public static int RtoI(string s)
         {
             var a1 = new char[] {'I', 'V', 'X', 'L', 'C', 'D', 'M'};
            var a2 = new int[] { 1, 5, 10, 50, 100, 500, 1000 };

             var dic = new Dictionary<char, int>
             {
                 {'I', 1},
                 {'V', 5},
                 {'X', 10},
                 {'L', 50},
                 {'C', 100},
                 {'D', 500},
                 {'M', 1000}
             };
            var sum = 0;
             for (var i = 0; i < s.Length; i++)
             {
                //判一下0只是担心数组下标变-1
                if(i == 0)
                    sum +=  dic[s[i]];
                else
                    //小数字在大数字前面,减掉2次
                    sum += dic[s[i - 1]] < dic[s[i]] ? -2*dic[s[i - 1]] + dic[s[i]] : dic[s[i]];
  
             }
             return sum;
         }

         
    }
}
