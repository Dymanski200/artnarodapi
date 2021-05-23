using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.ViewModels
{
    public class UserViewModel
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string Description { get; set; }
        public string Avatar { get; set; }
        public bool VerificationStatus { get; set; }

        public UserViewModel(User model)
        {
            ID = model.ID;
            Email = model.Email;
            Name = model.Name;
            Role = model.Role;
            Description = model.Description;
            Avatar = model.Avatar;
            VerificationStatus = model.VerificationStatus;
        }
    }
}
