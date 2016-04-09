using System.Collections.Generic;
using Tweetinvi;
using Tweetinvi.Core.Credentials;
using Tweetinvi.Core.Interfaces;
using Tweet = Xeromatic.Models.Tweet;
using System.Linq;

namespace Xeromatic.Services
{
    public class TwitterApiService
    {
        // Get keys from: https://apps.twitter.com
        // Wiki for tweetinvi: https://github.com/linvi/tweetinvi/wiki

        readonly TwitterCredentials _creds;

        public TwitterApiService()
        {
            _creds = new TwitterCredentials
            {
                ConsumerKey = "oWJRRpt6ldpK5Yom2EtyKFJBJ",
                ConsumerSecret = "gnciy0PESo5gKHnaOg6eNdac2PDLT5EVjWki6ta1vO8TocWEhu",
                AccessToken = "700489843487322112-Ig4yUfbIHEJ9jRC6GdeNSUsHxUKxGYd",
                AccessTokenSecret = "N0zqFKyVvoFVdxzLv3PCE1ddoVyrU8P9RzZ1y2p1T0QU8"
            };
        }

        public IEnumerable<Tweet> GetTweets()
        {
            var tweets = Auth.ExecuteOperationWithCredentials(_creds, () => Timeline.GetUserTimeline("xero", 10)).ToList();
            

                if (tweets.Any())
                {
                    return tweets.Select(t => new Tweet
                    {
                        Id = t.Id,
                        Text = t.Text

                    });

                }
                return new List<Tweet>();
           
           
        }

    }
}