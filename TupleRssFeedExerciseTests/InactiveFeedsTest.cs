using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TupleRssFeedExercise;
using CollectionAssert = NUnit.Framework.CollectionAssert;

namespace TupleRssFeedExerciseTests
{
    [TestClass]
    public class TuplesRssFeed
    {

        [TestMethod]
        public void GetHiatusFeeds_WithValidParameter_ReturnsListOfTuples()
        {
            //ARRANGE

            //Mimicking a database tuples of RSS feeds: Company Name, Article Title, Url, Publish Date, Description.
            Tuple<string, string, string, DateTime, string>[] rssFeeds =
            {
                Tuple.Create("Opinionated Citizens","Top Ten Restaurants In Raleigh, NC",
                    "WWW.OpinionatedBlog.com/article/top-ten-restaurants-in-raleigh-nc/", DateTime.Today.AddDays(-7),
                    "An opinionated article about the best restaurants in Raleigh, NC that you probably already heard of ."),

                Tuple.Create("Marvel" ,"Why SpiderMan is the best Marvel hero",
                    "WWW.IntellectualBlog.com/article/why-spiderman-is-the-best-marvel-hero/", DateTime.Today,
                    "A totally unbiased, factual, and pe."),

                Tuple.Create("TopSecret","Mystery Article X",
                    "WWW.TopSecret.com/article/mystery-article-x/", DateTime.Today.AddDays(-1),
                    "Ran out of website ideas, so let's call this one a mystery.")
            };

            TupleAccountRss tupleAccount = new TupleAccountRss();

            //ACT
            List<Tuple<string, int>> actual = new List<Tuple<string, int>>(tupleAccount.GetInactiveFeeds(rssFeeds));

            //ASSERT
            List<Tuple<string, int>> expected = new List<Tuple<string, int>>
            {
                new Tuple<string, int>("Opinionated Citizens", 7), new Tuple<string, int>("TopSecret", 1)
            };

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetOldFeedSummaries_WithValidParameter_PrintsCorrectInfo()
        {
            TupleAccountRss tupleAccount = new TupleAccountRss();

            List<string> actualSummaries;

            //ARRANGE
            List<Tuple<string, int>> oldFeeds = new List<Tuple<string, int>>();

            oldFeeds.Add(new Tuple<string, int>("Opinionated Citizens", 7));
            oldFeeds.Add(new Tuple<string, int>("TopSecret", 1));

            //ACT
            actualSummaries = tupleAccount.GetOldFeedSummaries(oldFeeds);

            //ASSERT
            var expectedSummaries = new List<string>()
            {
                "Opinionated Citizens's last updated feed was 7 day(s) ago.",
                "TopSecret's last updated feed was 1 day(s) ago."
            };
            CollectionAssert.AreEqual(expectedSummaries, actualSummaries);
        }
    }
}
