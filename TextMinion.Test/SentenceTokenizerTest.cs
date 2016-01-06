using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextMinion;

namespace TextMinion.Test
{
    [TestClass]
    public class SentenceTokenizerTest
    {
        [TestMethod]
        public void VerifyParseForTwoSentences()
        {
            SentenceTokenizer st = new SentenceTokenizer();
            var sentences = st.GetSentences("This is a test sentence. In addition there is a second sentence.");
            Assert.AreEqual(sentences.Count, 2);
        }
    }
}
