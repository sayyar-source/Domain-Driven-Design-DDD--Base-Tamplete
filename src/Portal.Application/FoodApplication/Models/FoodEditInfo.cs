
using Portal.Domain.Common;
using Portal.Domain.FoodAggregate;
using System;

namespace Portal.Application.Foods.Models
{
    public class FoodEditInfo
    {
        public int Id { get; set; }
        public Mony Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public FoodType FoodType { get; set; }
    }
}
