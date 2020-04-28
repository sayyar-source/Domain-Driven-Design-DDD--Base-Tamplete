using Portal.Domain.OrderAggregate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Portal.Domain
{
   public class User:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public SocialMedia SocialAddress { get; set; }
        public Address Address { get; set; }
        [ForeignKey("UserId")]
        public List<Order> Orders { get; set; }
    }
}
