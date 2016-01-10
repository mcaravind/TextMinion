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
        public static List<string> GetWords(string input)
        {
            var wordList = new List<string>();
            //replace all non alpha-numeric with space
            var replaced = Regex.Replace(input, "[^0-9A-Za-z]", " ");
            wordList = replaced.Split(new[]{' '}, StringSplitOptions.RemoveEmptyEntries).ToList();
            return wordList;
        } 
    }
}
