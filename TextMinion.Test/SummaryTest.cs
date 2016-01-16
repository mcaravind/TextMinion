using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TextMinion.Test
{
    [TestClass]
    public class SummaryTest
    {
        [TestMethod]
        public void Verify_Summary()
        {
            var input =
                "FIFTEEN years ago today, on January 15th, 2001, Wikipedia was founded by two internet pioneers, Jimmy Wales and Larry Sanger, although neither had any idea how ambitious their online encyclopedia would become. Today Wikipedia is the tenth most popular website in the world, with versions available in some 280 languages containing around 35m articles. Like the ancient library of Alexandria and Denis Diderot’s encyclopedia published during the Enlightenment, Wikipedia is an ever-evolving manifestation of its creators’ desire to preserve and compile knowledge.Wikipedia was early to anticipate three important digital trends. First, people are willing to participate in global forums for nothing. Wikipedia, which is written and edited by volunteers, was an early social network. Second, Wikipedia saw that the knowledge economy was heading online. In 2012 the “Encyclopedia Britannica” stopped printing and is now only available in digital form. Third, Wikipedia showed the importance of network effects to online ventures: the more people use Wikipedia and write entries, the more helpful it has become. Younger digital firms, like Facebook and Uber, are premised on this same concept.Like any powerful and popular internet property, Wikipedia has attracted controversy, as well as accolades, over its last decade and a half of existence. Last year it was revealed that several congressional staffers were making changes to their bosses’ political biographies, including deleting sections that offered criticism. Wikipedians are alert to the dangers of outsiders’ meddling, and launched an investigation into the problem, resulting in a few IP addresses being banned. But the incident is a reminder of the encyclopedia’s authoritative role in recording history and how special interests will continue to try to exert influence. If they were to succeed, it would undermine Wikipedia’s credibility.Wikipedia has other challenges with which to reckon. Unlike for-profit social networks, it does not make money from advertising and depends on financial contributions from users to keep it running (not to mention volunteers to edit). The number of active editors has declined in the last ten years; the Wikipedia community is notoriously unwelcoming to newcomers. For years the online encyclopedia has been criticised because Wikipedians are predominantly male and English-speaking, and may carry a worldview that does not represent the collective. It remains an ongoing challenge to recruit participants from different backgrounds and countries. English-language Wikipedia is by far the most read; other sites need more attention to expand their offerings and increase their popularity. However, there is plenty of time. Wikipedia has built up a trove of information and become an invaluable resource to anyone with an internet connection. That is more than any teenager could hope for.";
            var result = Summary.GetSummary(input);
        }
    }
}
