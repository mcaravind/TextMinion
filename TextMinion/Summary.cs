using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TextMinion
{
    public static class Summary
    {
        static string[] stopWords = { "he", "his", "which", "want", "do", "would", "more", "like", "you", "your", "very", "me", "get", "has", "i", "over", "could", "have", "what", "a", "an", "and", "are", "as", "at", "be", "but", "by", "for", "if", "in", "into", "is", "it", "no", "not", "of", "on", "or", "such", "that", "the", "their", "then", "there", "these", "they", "this", "to", "was", "will", "with" };
        public static List<string> GetSummary(string input)
        {
            var summarySentences = new List<string>();
            Dictionary<string,List<int>> wordSentenceMap = new Dictionary<string, List<int>>();
            Dictionary<string,string> actualWord = new Dictionary<string, string>();
            List<string> sentenceList = SentenceTokenizer.GetSentences(input);
            for (int i = 0;i<sentenceList.Count;i++)
            {
                string sentence = sentenceList[i];
                List<string> wordList = WordTokenizer.GetWords(sentence);
                foreach (string word in wordList)
                {
                    string stemmedWord = Stemmer.GetStem(word);
                    if (!actualWord.ContainsKey(stemmedWord)) actualWord[stemmedWord] = word;
                    List<int> mapList = wordSentenceMap.ContainsKey(stemmedWord)? wordSentenceMap[stemmedWord] : new List<int>();
                    mapList.Add(i);
                    wordSentenceMap[stemmedWord] = mapList;
                }
            }
            Dictionary<int,double> sentenceScores = new Dictionary<int, double>();
            for (int i = 0; i < sentenceList.Count; i++)
            {
                double avgScore = 0;
                string sentence = sentenceList[i];
                List<string> wordList = WordTokenizer.GetWords(sentence);
                
                int totalScore = 0;
                int numWords = 0;
                foreach (string word in wordList)
                {
                    if (!stopWords.Contains(word.ToLower()) && !string.IsNullOrWhiteSpace(word))
                    {
                        totalScore += wordSentenceMap[Stemmer.GetStem(word)].Count * (1/(1+CommonWords.GetFrequency(word.ToLower())));
                        numWords += 1;
                    }
                }
                if(numWords <= 4) continue;
                avgScore = totalScore * 1.0 /numWords;
                sentenceScores[i] = avgScore;
            }
            var ordered = sentenceScores.OrderByDescending(x => x.Value).Take(5);
            ordered = ordered.OrderBy(y => y.Key);
            List<string> top5 = new List<string>();
            foreach (var item in ordered)
            {
                top5.Add(sentenceList[item.Key]);
            }
            Dictionary<string,Tuple<int,int>> candidates = new Dictionary<string, Tuple<int, int>>();
            foreach (var kvp in wordSentenceMap)
            {
                List<int> mapList = kvp.Value;
                int median = mapList[mapList.Count/2];
                List<int> medianDiff = new List<int>();
                for (int j = 0; j < mapList.Count; j++)
                {
                    medianDiff.Add(Math.Abs(median-mapList[j]));
                }
                int numItemsBelowThreshold = medianDiff.Where(x => x <= mapList.Count).Count();
                if (numItemsBelowThreshold >= mapList.Count * 0.75 && mapList.Count >=3 && !string.IsNullOrWhiteSpace(kvp.Key) && !stopWords.Contains(kvp.Key.ToLower()))
                {
                    string key = kvp.Key;
                    int minVal = mapList.Where(x => Math.Abs(x - median) <= 3).Min();
                    int maxVal = mapList.Where(x => Math.Abs(x - median) <= 3).Max();
                    candidates[key] = new Tuple<int, int>(minVal, maxVal);
                }
            }
            return summarySentences;
        } 
    }
}
