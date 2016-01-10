using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TextMinion.Test
{
    [TestClass]
    public class WordTokenizerTest
    {
        [TestMethod]
        public void VerifySingleSentence()
        {
            string input =
                "Basically, this issue is not restricted to NVidia GPUs or specific operating systems - This can be reproduced on Windows, Linux and OSX. Basically the concept of memory safety does not exist in the gpu space - which is the reason why the webgl standard is so strict about always zeroing buffers.";
            var wordList = WordTokenizer.GetWords(input);
            Assert.IsTrue(wordList.Count>0);
        }
    }
}
