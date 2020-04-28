
using Portal.Domain.Common;
using Portal.Domain.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Domain.FoodAggregate
{
    public class Food:BaseEntity
    {
        private Food()
        {

        }
        public Food(string name,Mony price,FoodType foodType)
        {
            Name = name;
            Price = price;
            FoodType = foodType;
        }
        public bool UpdatePrice(Mony price)
        {
            ///validation
            ///
            Price = price;
            return true;
        }
        public Mony Price { get;private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public FoodType FoodType { get; set; }
    }
}
