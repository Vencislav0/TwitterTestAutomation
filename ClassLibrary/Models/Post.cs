using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    public class Post
    {
        public Data Data { get; set; }
        public string Title { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public int Status { get; set; }

        public string Detail { get; set; }

        public List<ErrorDetails> Errors { get; set; }

    }

    public class ErrorDetails
    {
        public string Message { get; set; }
    }

    public class Data
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("text")]
        public string? Text { get; set; }
        [JsonProperty("edit_history_tweet_ids")]
        public List<string> EditHistoryTweetIds { get; set; }

    }

    
}
