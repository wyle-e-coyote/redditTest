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
        static void Main(string[] args)
        {
            var auth = new AuthProvider("lmRDkKsNZfHENQ", "4ZTAJHzD1RkVVpCgtDLpJibN9jU", "https://www.reddit.com/user/curiosity_auto/");

            var authToken = auth.GetOAuthToken("3PkoqFlnq0FiKof3JgqZQoN4PwY");

            //auth.GetOAuthToken("")

            //auth.GetAuthUrl("random", AuthProvider.Scope.submit, permanent: true);

            var reddit = new Reddit();

            var user = reddit.LogIn("curiosity_auto", "reddit18");
            
            var limit = reddit.RateLimit;
            
            var subreddit = reddit.GetSubreddit("/r/curiosity_auto");

            foreach (var post in subreddit.New.Take(25))
            {
                if (post.Title.ToLower().Contains("testing"))
                {
                    post.Upvote();
                    post.Comment("hell yes");
                }
            }
        }
    }
}
