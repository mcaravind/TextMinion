using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextMinion.Model;

namespace TextMinion
{
    public static class Grammar
    {
        public static void ParseSentence(string sentence)
        {
            //first get the list of words
            List<string> wordList = WordTokenizer.GetWords(sentence);
            //send the word list to CKY to get a parse tree
            BinaryTreeNode btn = CKY(wordList);
        }

        static BinaryTreeNode CKY(List<string> wordList)
        {
            return new BinaryTreeNode();
        }
    }
}
