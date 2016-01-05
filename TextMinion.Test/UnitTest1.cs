using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextMinion;

namespace TextMinion.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            SentenceTokenizer st = new SentenceTokenizer();
            var sentences = st.GetSentences("This is a test sentence. In addition there is a second sentence.");
            Assert.AreEqual(sentences.Count, 0);
        }
    }
}
