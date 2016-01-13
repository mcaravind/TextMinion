using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TextMinion.Test
{
    [TestClass]
    public class StemmerTest
    {
        [TestMethod]
        public void Verify_Basic()
        {
            var input = "caresses";
            var stemmed = Stemmer.GetStem(input);
            Assert.AreEqual(stemmed,"caress");
        }
    }
}
