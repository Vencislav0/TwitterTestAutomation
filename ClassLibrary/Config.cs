using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Config
    {
        [JsonProperty("consumerKey")]
        public string? ConsumerKey { get; set; }

        [JsonProperty("consumerSecret")]
        public string? ConsumerSecret { get; set; }

        [JsonProperty("accessToken")]
        public string AccessToken { get; set; }

        [JsonProperty("accessTokenSecret")]
        public string AccessTokenSecret { get; set; }

        [JsonProperty("bearerToken")]
        public string BearerToken { get; set; }
    }
}
