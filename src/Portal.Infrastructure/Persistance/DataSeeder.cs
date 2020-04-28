using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using Portal.Domain;
using Portal.Domain.Common;
using Portal.Domain.FoodAggregate;
using Portal.Persisatance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Portal.Infrastructure.Persistance
{
  public static  class DataSeeder
    {
     
        public static void Initialize(PortalDbContext context)
        {
        context.Database.EnsureCreated();
            if (!context.Foods.Any())
            {
                context.Foods.Add(new Food("Desert",new Mony(1000),FoodType.Desert) { TimeCreated = DateTime.Now, IsEnable = true, Description = "Description1" });
                context.Foods.Add(new Food("kola", new Mony(2000), FoodType.Drink) { TimeCreated = DateTime.Now, IsEnable = true, Description = "Description2" });
                context.Foods.Add(new Food("chicken", new Mony(3000), FoodType.Meal) { TimeCreated = DateTime.Now, IsEnable = true, Description = "Description3" });
                context.SaveChanges();
            }
            if(!context.Users.Any())
            {
                context.Users.Add(new User
                {
                    Email = "admin@gmail.com",
                    FirstName = "admin",
                    LastName = "admin",
                    IsEnable = true,
                    Password = "123",
                    Phone = "999999",
                    TimeCreated = DateTime.Now,
                    UserName = "admin",
                    SocialAddress = new SocialMedia(instageram: "ins_admin", telegramCanal: "telchanal_admin", telegramGroup: "telgroup_admin"),
                    Address = new Domain.Address(street:"monzeviler",city:"cankaya",state:"ankara",country:"Turkiye",zipcode:"12345")
                    
                });
                context.SaveChanges();
            }
          
        }

    }
}
