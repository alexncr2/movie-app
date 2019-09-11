using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;

namespace MoVenture.Models
{
    public class ActorModel
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("picture")]
        public string PictureUrl { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("description")]
        public int Description { get; set; }

        public DateTime SavedAt { get; set; }
    }
}
