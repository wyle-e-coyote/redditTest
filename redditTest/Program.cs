using RedditSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace redditTest
{
    class Program
    {
        private static string _clientId = "OprXolqPf2pQNw";
        private static string _clientSecret = "bKoid8i7PQRAZSSnLGx4RR-3Gww";
        private static string _redirectUrl = "https://www.reddit.com/r/curiosity_auto/";

        static void Main(string[] args)
        {
            var auth = new AuthProvider(_clientId, _clientSecret, _redirectUrl);

            var _authToken = auth.GetOAuthToken("curiosity_auto", "reddit18");
            
            var reddit = new Reddit(_authToken);
            
            var limit = reddit.RateLimit;
            
            var subreddit = reddit.GetSubreddit("/r/gaming");

            foreach (var post in subreddit.New.Take(250))
            {
                if (post.Title.ToLower().Contains("halo"))
                {
                    if (post.Liked.HasValue && post.Liked.Value)
                        continue;
                    post.Upvote();
                    post.Comment("hell yes");
                }
            }
        }
    }
}
