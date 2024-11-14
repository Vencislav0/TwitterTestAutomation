using ClassLibrary;
using Newtonsoft.Json;
using RestSharp;

namespace TestProject1
{
    public class Tests
    {


        Random random;
        TwitterApiClient client;
        string consumerKey = Environment.GetEnvironmentVariable("CONSUMER_KEY");
        string consumerSecret = Environment.GetEnvironmentVariable("CONSUMER_SECRET");
        string accessToken = Environment.GetEnvironmentVariable("ACCESS_TOKEN");
        string accessTokenSecret = Environment.GetEnvironmentVariable("ACCESS_TOKEN_SECRET");

        [SetUp]
        public void Setup()
        {
            

            

            client = new TwitterApiClient("https://api.x.com", consumerKey, consumerSecret, accessToken, accessTokenSecret);

            random = new Random();
        }


        [Test]
        public void Test1()
        {
            var randomText = "Hello, this is a tweet from my RestSharp project" + random.Next(1, 1000);



            var response = client.CreatePost(randomText);


            Assert.That(Convert.ToInt64(response.data.Id), Is.GreaterThan(0));
            Assert.That(response.data.Text, Is.EqualTo(randomText));


        }
    }
}