using System;
using System.Text.RegularExpressions;

namespace 正则表达式
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--------------定位符--------------");
            {
                //^匹配开头，还会与\n或\r之后的位置匹配。
                //$匹配结尾，还会与\n或\r之前的位置匹配。
                //\b匹配一个单词边界，即字与空格间的位置。
                //\B非单词边界匹配。
                string str = "I am blue cat.";
                string res = Regex.Replace(str, "^", "开始:");
                Console.WriteLine(res);
                res = Regex.Replace(str, "$", "结束");
                Console.WriteLine(res);
                res = Regex.Replace(str, @"\b", "*");
                Console.WriteLine(res);
                res = Regex.Replace(str, @"\B", "*");
                Console.WriteLine(res);

            }
            Console.WriteLine("--------------基本字符--------------");
            {
                //[...]匹配 [...] 中的所有字符
                //[^ABC]匹配除了 [...] 中字符的所有字符
                //[A-Z] 表示一个区间，匹配所有大写字母
                //[a-z] 匹配所有小写字母。
                //[0-9] 匹配数字。
                //. 匹配除换行符（\n、\r）之外的任何单个字符，相等于 [^\n\r]。
                //[\s\S] 匹配所有。\s 是匹配所有空白符，包括换行，\S 非空白符，不包括换行。
                //\w 匹配字母、数字、下划线。等价于 [A-Za-z0-9_]
                //\d 匹配一个数字字符。等价于[0 - 9]

                string str = "123: I am blue cat. 456";
                //将出现的任意个abc换成..
                string res = Regex.Replace(str, "[abc]", "..");
                Console.WriteLine(res);
                //将除了abc的其他所有字符换成..
                res = Regex.Replace(str, "[^abc]", "..");
                Console.WriteLine(res);
                //将a-f之间的字符换成..
                res = Regex.Replace(str, "[a-f]", "..");
                Console.WriteLine(res);
                //将0-5之间的数字换成..
                res = Regex.Replace(str, "[0-5]", "..");
                Console.WriteLine(res);
                //所有字符换成..
                res = Regex.Replace(str, @"[\s\S]", "..");
                Console.WriteLine(res);
                //匹配字母、数字、下划线换成..
                res = Regex.Replace(str, @"[\w]", "..");
                Console.WriteLine(res);
            }

            Console.WriteLine("--------------限定符--------------");
            {
                //限定符用来指定正则表达式的一个给定组件必须要出现多少次才能满足匹配。有 * 或 + 或 ? 或 {n} 或 {n,} 或 {n,m} 共6种。
                string str = "123456: I am blue cat. 123456";

                //* 匹配前面的子表达式零次或多次
                //+ 匹配前面的子表达式一次或多次
                //? 匹配前面的子表达式零次或一次
                //{n} n 是一个非负整数。匹配确定的 n 次。
                //{n,}n 是一个非负整数。至少匹配n 次。
                //{n,m} m 和 n 均为非负整数，其中n <= m。最少匹配 n 次且最多匹配 m 次。
                //至少出现过0次
                bool isMatch = Regex.IsMatch(str, @"[9]*");
                Console.WriteLine(isMatch);
                //至少出现过1次
                isMatch = Regex.IsMatch(str, @"[9]+");
                Console.WriteLine(isMatch);
                //只出现过0次或1次  第二次不进行匹配
                string res = Regex.Replace(str, @"[5]?","9");
                Console.WriteLine(res);
                //只出现过0次或1次  第二次不进行匹配
                res = Regex.Replace(str, @"[5]+", "9");
                Console.WriteLine(res);
            }

            Console.WriteLine("--------------校验数字--------------");
            {
                //1.所有字符全部只能是数字  @"\d"
                bool isMatch = Regex.IsMatch("A11255", @"^\d*$");
                Console.WriteLine(isMatch);
            }



            Console.ReadKey();

        }
    }
}
