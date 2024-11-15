using ClassLibrary.Models;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;

namespace ClassLibrary
{
    public class TwitterApiClient
    {
        private RestClient client;
        public TwitterApiClient(string baseUrl, string consumerKey, string consumerSecret, string accessToken, string accessTokenSecret)
        {
            var options = new RestClientOptions(baseUrl)
            {
                MaxTimeout = 10000,
                Authenticator = OAuth1Authenticator.ForAccessToken(consumerKey, consumerSecret, accessToken, accessTokenSecret)
            };

            client = new RestClient(options);
        }



        public Post CreatePost(string postContent)
        {
            var tweetRequest = new RestRequest("/2/tweets", Method.Post);

            tweetRequest.AddHeader("Content-Type", "application/json");
            tweetRequest.AddJsonBody(new { text = postContent });

            RestResponse tweetResponse = client.Execute(tweetRequest);            

            if (tweetResponse.IsSuccessful)
            {
                Console.WriteLine("Created Post!");
            }
            else
            {
                Console.WriteLine(tweetResponse.ErrorMessage);
            }

            return tweetResponse != null ? JsonConvert.DeserializeObject<Post>(tweetResponse.Content) : null;



        }

        public Post GetPost(string id)
        {
            var tweetRequest = new RestRequest($"/2/tweets/{id}", Method.Get);

            tweetRequest.AddHeader("Content-Type", "application/json");

            var tweetResponse = client.Execute(tweetRequest);

            return tweetResponse.IsSuccessful ? JsonConvert.DeserializeObject<Post>(tweetResponse.Content) : null;



        }





    }
}
