using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Text;
using System;

namespace hoge
{
    public static class HankakuUtil
    {
        ///
        /// https://so-zou.jp/web-app/text/fullwidth-halfwidth/
        private static ReadOnlyDictionary<char, char> DictionaryHalfWidthToFull { get; } = new ReadOnlyDictionary<char, char>(
              new Dictionary<char, char>(){
        #region  symbol ASCII
        {' ','　'},
        {'!','！'},
        {'"','“'},// “ or ” which is better
        {'#','＃'},
        {'$','＄'},
        {'%','％'},
        {'&','＆'},
        {'\'','＇'}, // same problem as double quates
        {'(','（'},
        {')','）'},
        {'*','＊'},
        {'+','＋'},
        {',','，'},
        {'-','－'},
        {'.','．'},
        {'/','／'},
        {':','：'},
        {';','；'},
        {'<','＜'},
        {'=','＝'},
        {'>','＞'},
        {'?','？'},
        {'@','＠'},
        {'\\','￥'}, // should be ￥ ＼?
        {']','］'},
        {'^','＾'},
        {'_','＿'},
        {'`','｀'},
        {'{','｛'},
        {'|','｜'},
        {'}','｝'},
        {'~','～'},
        #endregion  symbol ASCII


        #region  alphabet upper case
        {'A','Ａ'},
        {'B','Ｂ'},
        {'C','Ｃ'},
        {'D','Ｄ'},
        {'E','Ｅ'},
        {'F','Ｆ'},
        {'G','Ｇ'},
        {'H','Ｈ'},
        {'I','Ｉ'},
        {'J','Ｊ'},
        {'K','Ｋ'},
        {'L','Ｌ'},
        {'M','Ｍ'},
        {'N','Ｎ'},
        {'O','Ｏ'},
        {'P','Ｐ'},
        {'Q','Ｑ'},
        {'R','Ｒ'},
        {'S','Ｓ'},
        {'T','Ｔ'},
        {'U','Ｕ'},
        {'V','Ｖ'},
        {'W','Ｗ'},
        {'X','Ｘ'},
        {'Y','Ｙ'},
        {'Z','Ｙ'},
        #endregion  alphabet upper case
        #region  alphabet lower case
        {'a','ａ'},
        {'b','ｂ'},
        {'c','ｃ'},
        {'d','ｄ'},
        {'e','ｅ'},
        {'f','ｆ'},
        {'g','ｇ'},
        {'h','ｈ'},
        {'i','ｉ'},
        {'j','ｊ'},
        {'k','ｋ'},
        {'l','ｌ'},
        {'m','ｍ'},
        {'n','ｎ'},
        {'o','ｏ'},
        {'p','ｐ'},
        {'q','ｑ'},
        {'r','ｒ'},
        {'s','ｓ'},
        {'t','ｔ'},
        {'u','ｕ'},
        {'v','ｖ'},
        {'w','ｗ'},
        {'x','ｘ'},
        {'y','ｙ'},
        {'z','ｚ'},
        #endregion  alphabet lower case
        #region  numerics
        {'0','０'},
        {'1','１'},
        {'2','２'},
        {'3','３'},
        {'4','４'},
        {'5','５'},
        {'6','６'},
        {'7','７'},
        {'8','８'},
        {'9','９'},
        #endregion  numerics
        #region  katakana
        {'ｱ','ア'},
        {'ｲ','イ'},
        {'ｳ','ウ'},
        {'ｴ','エ'},
        {'ｵ','オ'},
        {'ｶ','カ'},
        {'ｷ','キ'},
        {'ｸ','ク'},
        {'ｹ','ケ'},
        {'ｺ','コ'},
        {'ｻ','サ'},
        {'ｼ','シ'},
        {'ｽ','ス'},
        {'ｾ','セ'},
        {'ｿ','ソ'},
        {'ﾀ','タ'},
        {'ﾁ','チ'},
        {'ﾂ','ツ'},
        {'ﾃ','テ'},
        {'ﾄ','ト'},
        {'ﾅ','ナ'},
        {'ﾆ','ニ'},
        {'ﾇ','ヌ'},
        {'ﾈ','ネ'},
        {'ﾉ','ノ'},
        {'ﾊ','ハ'},
        {'ﾋ','ヒ'},
        {'ﾌ','フ'},
        {'ﾍ','ヘ'},
        {'ﾎ','ホ'},
        {'ﾏ','マ'},
        {'ﾐ','ミ'},
        {'ﾑ','ム'},
        {'ﾒ','メ'},
        {'ﾓ','モ'},
        {'ﾔ','ヤ'},
        {'ﾕ','ユ'},
        {'ﾖ','ヨ'},
        {'ﾗ','ラ'},
        {'ﾘ','リ'},
        {'ﾙ','ル'},
        {'ﾚ','レ'},
        {'ﾛ','ロ'},
        {'ﾜ','ワ'},
        {'ｦ','ヲ'},
        {'ﾝ','ン'},
        {'ｧ','ァ'},
        {'ｨ','ィ'},
        {'ｩ','ゥ'},
        {'ｪ','ェ'},
        {'ｫ','ォ'},
        {'ｬ','ャ'},
        {'ｭ','ュ'},
        {'ｮ','ョ'},
        {'ｯ','ッ'},
        {'ｰ','ー'},
        {'ﾞ','゛'},
        {'ﾟ','゜'},
        {'､','、'},
        {'｡','。'},
        {'･','・'},
        {'｢','「'},
        {'｣','」'},
        #endregion  katakana

                  #region  symbols non ASCII
                  #endregion  symbols non ASCII
              }
          );
        ///
        /// characters need to check if the next character is  dakuten or han-dakuten
        private static IReadOnlySet<char> CharacterSetSHouldSeeNextCharacters { get; }
                = new HashSet<char>(new List<char>(){
            'ｳ','ｶ', 'ｷ', 'ｸ', 'ｹ', 'ｺ', 'ｻ', 'ｼ', 'ｽ', 'ｾ', 'ｿ',
            'ﾀ', 'ﾁ', 'ﾂ','ﾃ', 'ﾄ', 'ﾊ', 'ﾋ', 'ﾌ', 'ﾍ', 'ﾎ'
                });

        private static ReadOnlyDictionary<Tuple<char, char>, char> DakutenDict { get; } = new ReadOnlyDictionary<Tuple<char, char>, char>(
              new Dictionary<Tuple<char, char>, char>(){
            {new Tuple<char, char>('ｳ','ﾞ'),'ヴ'},
            {new Tuple<char, char>('ｶ','ﾞ'),'ガ'},
            {new Tuple<char, char>('ｷ','ﾞ'),'ギ'},
            {new Tuple<char, char>('ｸ','ﾞ'),'グ'},
            {new Tuple<char, char>('ｹ','ﾞ'),'ゲ'},
            {new Tuple<char, char>('ｺ','ﾞ'),'ゴ'},
            {new Tuple<char, char>('ｻ','ﾞ'),'ザ'},
            {new Tuple<char, char>('ｼ','ﾞ'),'ジ'},
            {new Tuple<char, char>('ｽ','ﾞ'),'ズ'},
            {new Tuple<char, char>('ｾ','ﾞ'),'ゼ'},
            {new Tuple<char, char>('ｿ','ﾞ'),'ゾ'},
            {new Tuple<char, char>('ﾊ','ﾞ'),'バ'},
            {new Tuple<char, char>('ﾋ','ﾞ'),'ビ'},
            {new Tuple<char, char>('ﾌ','ﾞ'),'ブ'},
            {new Tuple<char, char>('ﾍ','ﾞ'),'ベ'},
            {new Tuple<char, char>('ﾎ','ﾞ'),'ボ'},
            {new Tuple<char, char>('ﾊ','ﾟ'),'パ'},
            {new Tuple<char, char>('ﾋ','ﾟ'),'ピ'},
            {new Tuple<char, char>('ﾌ','ﾟ'),'プ'},
            {new Tuple<char, char>('ﾍ','ﾟ'),'ペ'},
            {new Tuple<char, char>('ﾎ','ﾟ'),'ポ'},
              }
          );

        public static string ConsolidateTextToFullWidth(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }
            StringBuilder sb = new StringBuilder();
            var index = 0;
            while (index < text.Length)
            {
                var char1 = text[index++];
                char result;
                if (DictionaryHalfWidthToFull.TryGetValue(char1, out result))
                {
                    //
                    if (index < text.Length && CharacterSetSHouldSeeNextCharacters.Contains(char1))
                    {   // char1 is needed to check if the next charcter is
                        // dakuten or han-dakuten.
                        var char2 = text[index];
                        if (DakutenDict.TryGetValue(new Tuple<char, char>(char1, char2), out char temp))
                        {
                            result = temp;
                            index++;
                        }
                    }
                }
                sb.Append(result);
            }
            return sb.ToString();

        }
    } 
}