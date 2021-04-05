using System;
using hoge;
namespace ConsoleAppTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Convert(
            "ｱ ｲ ｳ ｴ ｵ ｶ ｷ ｸ ｹ ｺ ｻ ｼ ｽ ｾ ｿ ﾀ ﾁ ﾂ ﾃ ﾄ ﾅ ﾆ ﾇ ﾈ ﾉ ﾊ ﾋ ﾌ ﾍ ﾎ ﾏ ﾐ ﾑ ﾒ ﾓ ﾔ ﾕ ﾖ ﾗ ﾘ ﾙ ﾚ ﾛ ﾜ ｦ ﾝ"+

"ｳﾞ ｶﾞ ｷﾞ ｸﾞ ｹﾞ ｺﾞ ｻﾞ ｼﾞ ｽﾞ ｾﾞ ｿﾞ ﾀﾞ ﾁﾞ ﾂﾞ ﾃﾞ ﾄﾞ ﾊﾞ ﾋﾞ ﾌﾞ ﾍﾞ ﾎﾞ ﾊﾟ ﾋﾟ ﾌﾟ ﾍﾟ ﾎﾟ ｧ ｨ ｩ ｪ ｫ ｬ ｭ ｮ ｯ"+

"ｰ ﾞ ﾟ ､ ｡ ･ ｢ ｣");
            

            Convert( "⦅ ⦆ ¢ £ ¬ ¯ ¦ ¥ ₩ ￨ ￩ ￪ ￫ ￬ ￭ ￮");

        }
        static void Convert(string temp)
        {
            Console.WriteLine($"From =={temp}");
            temp = HankakuUtil.ConsolidateTextToFullWidth(temp);
            Console.WriteLine($"To =={temp}");
        }

        //  https://so-zou.jp/web-app/text/fullwidth-halfwidth/
    }
}
