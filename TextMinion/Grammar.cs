using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextMinion
{
    public static class Grammar
    {
        public static void ParseSentence(string sentence)
        {
            //first get the list of words
            List<string> wordList = WordTokenizer.GetWords(sentence);
            //
        }

        static void CKY(List<string> wordList)
        {
            
        }
    }
}
