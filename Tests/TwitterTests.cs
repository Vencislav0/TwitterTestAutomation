using ClassLibrary;
using Newtonsoft.Json;
using RestSharp;

namespace TestProject1
{
    public class Tests
    {


        Random random;
        TwitterApiClient client;


        [SetUp]
        public void Setup()
        {
            

            var config = JsonConvert.DeserializeObject<Config>(File.ReadAllText("config.json"));

            client = new TwitterApiClient("https://api.x.com", config.ConsumerKey, config.ConsumerSecret, config.AccessToken, config.AccessTokenSecret);

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