using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RefreshToken { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string Description { get; set; }
        public string Avatar { get; set; }
        public bool VerificationStatus { get; set; }
        public bool ActivationStatus { get; set; }
        public string ConfirmationCode { get; set; }

        public List<Post> Posts { get; set; }
    }
}
