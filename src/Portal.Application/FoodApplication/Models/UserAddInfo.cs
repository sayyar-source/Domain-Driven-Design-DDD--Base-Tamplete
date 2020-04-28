using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Application.FoodApplication.Models
{
   public class UserAddInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }

        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }

        public string Instageram { get; set; }
        public string TelegramCanal { get; set; }
        public string TelegramGroup { get; set; }
    }
}
