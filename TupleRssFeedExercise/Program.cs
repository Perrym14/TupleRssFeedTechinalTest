using System;
using System.Collections.Generic;

/*Malik Perry - 05/24/19 - Junior Level Developer
 *Task: Given a tuple of RSS feed data, determine which companies had no activity for a given number of days.
 
 *Summary:
 *I assumed the RSS feed data have already been read/parsed into a data table.
 *The 'Tuple<string, string, string, DateTime, string>[] rssFeeds' represents one or more rows found in a data table of RSS Feeds.
 *I assumed the schema was 'Company Name, Article Title, Site Url, Publish Date, and Article Description'.
 
 *I'm assuming that when a RSS feed is passed in GetInactiveFeeds, it will never be null. Hopefully that's not cheating.
 * Unit test is in file 'InactiveFeedsTest'.
 
 */

namespace TupleRssFeedExercise
{
    public class TupleAccountRss
    {
        //Gets list of inactive feeds' Company Name and days inactive.
        public List<Tuple<string, int>> GetInactiveFeeds(Tuple<string, string, string, DateTime, string>[] rssFeeds)
        {
            var oldFeeds = new List<Tuple<string, int>>();

            GetOldFeedCompanyNamesAndDaysInactive(rssFeeds, oldFeeds);

            return oldFeeds;
        }

        //Prints the old company feeds and how many days inactive.
        public void PrintOldFeeds(List<Tuple<string, int>> oldFeeds)
        {
            foreach (var feed in oldFeeds)
            {
                Console.WriteLine($"{feed.Item1}'s last updated feed was {feed.Item2} day(s) ago.");
            }
        }

        //Gets list of summaries.
        //Wrote this to make sure that the strings printed
        //in 'PrintOldFeeds' is correct.
        public List<string> GetOldFeedSummaries(List<Tuple<string, int>> oldFeeds)
        {
            var oldFeedSummaries = new List<string>();
            foreach (var feed in oldFeeds)
            {

                oldFeedSummaries.Add($"{feed.Item1}'s last updated feed was {feed.Item2} day(s) ago.");
            }

            return oldFeedSummaries;
        }


        private static void GetOldFeedCompanyNamesAndDaysInactive(Tuple<string, string, string, DateTime, string>[] rssFeeds, List<Tuple<string, int>> oldFeeds)
        {
            foreach (var feed in rssFeeds)
            {
                if (feed.Item4 < DateTime.Today)
                {
                    var lastUpdate = DateTime.Today.Day - feed.Item4.Day;
                    oldFeeds.Add(new Tuple<string, int>(feed.Item1, lastUpdate));
                }
            }
        }

        public static void Main(string[] args)
        {

        }
    }
}
