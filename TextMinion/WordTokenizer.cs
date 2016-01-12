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
        public static IEnumerable<string> GetWords(string input)
        {
            var wordList = new List<string>();
            //replace all non alpha-numeric with char followed by space
            var replaced = Regex.Replace(input, "[^0-9A-Za-z]", " ");
            var punctuation = input.Where(Char.IsPunctuation).Distinct().ToArray();
            var words = input.Split().Select(x => x.Trim(punctuation));
            wordList = replaced.Split(new[]{' '}, StringSplitOptions.RemoveEmptyEntries).ToList();
            return words;
        } 
    }
}
