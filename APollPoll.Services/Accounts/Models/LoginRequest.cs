using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APollPoll.Services.Accounts.Models
{
    public class LoginRequest
    {
        [Required]
        [DisplayName("Email")]
        [JsonProperty("email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 4)]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
