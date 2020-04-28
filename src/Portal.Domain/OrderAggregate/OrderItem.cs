using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Portal.Domain.OrderAggregate
{
    public class OrderItem:BaseEntity
    {

        public int OrderId { get; set; }
        public int FoodId { get; set; }

        public int Count { get; set; }
        public int UnitPrice { get; set; }
        public int TotalPrice { get; set; }
    }
}
