using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    public class Post
    {
        public Data data { get; set; }

    }

    public class Data
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("text")]
        public string? Text { get; set; }

    }
}
