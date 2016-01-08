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
            
            var sentences = SentenceTokenizer.GetSentences("This is a test sentence. In addition there is a second sentence.");
            Assert.AreEqual(sentences.Count, 2);
        }

        [TestMethod]
        public void VerifyParseForExampleAbbreviation()
        {
            
            var sentences =
                SentenceTokenizer.GetSentences(
                    "I know this sounds speculative and vague, because honestly I have no idea what I'm talking about. But China certainly has the motive to manipulate American markets. And since the foreign investment is asymmetrical (e.g. the Chinese can invest in NYSE, but Americans cannot invest in Shanghai), China has an opportunity to play both sides of a Shanghai market crash and any corresponding American market drop.");
            Assert.AreEqual(sentences.Count,3);
        }
    }
}
