using System;
using System.Linq;
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
            Assert.IsTrue(wordList.ToList().Count>0);
        }

        [TestMethod]
        public void VerifyComplexSentence()
        {
            string input =
                "They have a lot more software in the works, such as Cassanda, MongoDB and Spark [1]. It's a push to have good software support for the IBM LinuxONE machine [2], essentially an IBM z Systems (z13) mainframe that will only run Linux on KVM (i.e. without expensive z/OS or z/VM 'legacy')";
            var wordlist = WordTokenizer.GetWords(input);
            Assert.IsTrue(wordlist.Contains("z13"));
        }
    }
}
