using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoVenture.Models
{
    public class UserWithToken
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("expires_in")]
        public double ExpiresIn { get; set; }

        [JsonProperty("userName")]
        public string UserName { get; set; }

        [JsonProperty("userData")]
        public string UserData { get; set; }
    }
}
