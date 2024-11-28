using ClassLibrary;
using Newtonsoft.Json;
using RestSharp;
using System.Net;

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




            Assert.That(Convert.ToInt64(response.Data.Id), Is.GreaterThan(0), "Id not found.");
            Assert.That(response.Data.Text, Is.EqualTo(randomText), "Tweet content is not as expected.");
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created), "Unexpected status code.");


        }

        [Test]
        public void Test_CreatePost_WithoutText()
        {
            var randomText = "Hello, this is a tweet from my RestSharp project" + random.Next(1, 1000);



            var response = client.CreatePost(" ");




            Assert.That(response.Data, Is.Null, "Data should be null in this request.");
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest), "Not the expected status code.");
            Assert.That(response.Errors[0].Message, Is.EqualTo("Please include either text or media in your Tweet."), "Message is not as expected.");
            Assert.That(response.Title, Is.EqualTo("Invalid Request"), "Title is not as expected.");

        }

        [Test]
        public void Test_CreatePost_WithTheSameText()
        {
            var Text = "Hello, this is a tweet from my RestSharp project" + random.Next(1, 1000);



            var response = client.CreatePost(Text);

            var response2 = client.CreatePost(Text);


            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
            Assert.That(response2.StatusCode, Is.EqualTo(HttpStatusCode.Forbidden));
            Assert.That(response2.Status, Is.EqualTo(403));
            Assert.That(response2.Detail, Is.EqualTo("You are not allowed to create a Tweet with duplicate content."));



            


        }

        [Test]
        public void Test_GetValidPost()
        {
            var randomText = "Hello, this is a tweet from my RestSharp project" + random.Next(1, 1000);
            var postResponse = client.CreatePost(randomText);

            var responseFromPost = client.GetPost(postResponse.Data.Id);

            
            Assert.That(postResponse.Data.Id, Is.EqualTo(responseFromPost.Data.Id));
            Assert.That(responseFromPost.Data.Text, Is.EqualTo(randomText));
            Assert.That(responseFromPost.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        }




    }
}