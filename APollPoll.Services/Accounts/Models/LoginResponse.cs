using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APollPoll.Services.Accounts.Models
{
    public class LoginResponse
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("firstLogin")]
        public bool FirstLogin { get; set; }

        [JsonProperty("first")]
        public string First { get; set; }

        [JsonProperty("last")]
        public string Last { get; set; }

        [JsonProperty("resetting")]
        public bool Resetting { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
