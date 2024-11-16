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
        public void Test_CreateValidPost()
        {
            var randomText = "Hello, this is a tweet from my RestSharp project" + random.Next(1, 1000);



            var response = client.CreatePost(randomText);




            Assert.That(Convert.ToInt64(response.data.Id), Is.GreaterThan(0));
            Assert.That(response.data.Text, Is.EqualTo(randomText));


        }

        [Test]
        public void Test_CreatePost_WithoutText()
        {
            var randomText = "Hello, this is a tweet from my RestSharp project" + random.Next(1, 1000);



            var response = client.CreatePost(" ");




            Assert.That(response.data, Is.Null);            

        }

        [Test]
        public void Test_CreatePost_WithTheSameText()
        {
            var Text = "Hello, this is a tweet from my RestSharp project" + random.Next(1, 1000);



            var response = client.CreatePost(Text);

            var response2 = client.CreatePost(Text);


            Assert.Pass("Passes for now, for implementation later.");



            


        }

        [Test]
        public void Test_GetValidPost()
        {
            var randomText = "Hello, this is a tweet from my RestSharp project" + random.Next(1, 1000);
            var postResponse = client.CreatePost(randomText);

            var responseFromPost = client.GetPost(postResponse.data.Id);

            
            Assert.That(postResponse.data.Id, Is.EqualTo(responseFromPost.data.Id));
            Assert.That(responseFromPost.data.Text, Is.EqualTo(randomText));

        }




    }
}