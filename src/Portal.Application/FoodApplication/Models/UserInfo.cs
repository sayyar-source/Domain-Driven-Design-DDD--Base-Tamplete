using Portal.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Application.FoodApplication.Models
{
   public class UserInfo
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public SocialMedia SocialAddress { get; set; }
        public Address Address { get; set; }
    }
}
