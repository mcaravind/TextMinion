using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextMinion
{
    public static class Summary
    {
        public static List<string> GetSummary(string input)
        {
            var summarySentences = new List<string>();
            Dictionary<string,List<int>> wordSentenceMap = new Dictionary<string, List<int>>();
            List<string> sentenceList = SentenceTokenizer.GetSentences(input);
            for (int i = 0;i<sentenceList.Count;i++)
            {
                string sentence = sentenceList[i];
                List<string> wordList = WordTokenizer.GetWords(sentence);
                foreach (string word in wordList)
                {
                    string stemmedWord = Stemmer.GetStem(word);
                    List<int> mapList = wordSentenceMap.ContainsKey(stemmedWord)? wordSentenceMap[stemmedWord] : new List<int>();
                    mapList.Add(i);
                    wordSentenceMap[stemmedWord] = mapList;
                }
            }
            foreach (var kvp in wordSentenceMap)
            {
                List<int> mapList = kvp.Value;
                int median = mapList[mapList.Count/2];
                List<int> medianDiff = new List<int>();
                for (int j = 0; j < mapList.Count; j++)
                {
                    medianDiff.Add(Math.Abs(median-mapList[j]));
                }
                int medianOfMedian = medianDiff[medianDiff.Count/2];

            }
            return summarySentences;
        } 
    }
}
