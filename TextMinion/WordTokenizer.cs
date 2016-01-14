using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TextMinion
{
    public static class WordTokenizer
    {
        enum CharState { InWord,OutOfWord}
        public static IEnumerable<string> GetWords(string input)
        {
            var wordList = new List<string>();
            CharState charState = CharState.OutOfWord;
            string thisWord = string.Empty;
            for (int i = 0; i < input.Length; i++)
            {
                char thisChar = input[i];
                char secondChar = (i+1<input.Length)?input[i+1]: Char.MinValue;
                char thirdChar = (i + 2 < input.Length) ? input[i + 2] : Char.MinValue;
                char prevChar = (i - 1 >= 0) ? input[i - 1] : Char.MinValue;
                if (charState == CharState.OutOfWord)
                {
                    if (Char.IsLetterOrDigit(thisChar)) charState = CharState.InWord;
                }
                else
                {
                    if (!Char.IsLetterOrDigit(thisChar))
                    {
                        bool retainState = false;
                        if (thisChar == '.')
                        {
                            if (thisWord.Contains("www"))
                            {
                                retainState = true;
                            }
                            if (Char.IsNumber(prevChar) && Char.IsNumber(secondChar))
                            {
                                retainState = true;
                            }
                        }
                        if (!retainState)
                        {
                            charState = CharState.OutOfWord;
                        }
                    }
                }
                if(Char.IsLetterOrDigit(thisChar)&&charState == CharState.OutOfWord) charState = CharState.InWord;
                if (charState == CharState.InWord)
                {
                    thisWord = thisWord + thisChar;
                }
                else
                {
                    wordList.Add(thisWord);
                    thisWord = string.Empty;
                }
            }
            if (charState == CharState.InWord)
            {
                if (!string.IsNullOrWhiteSpace(thisWord))
                    wordList.Add(thisWord); //last word
            }
            return wordList;
        } 
    }
}
