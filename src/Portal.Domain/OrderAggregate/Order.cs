
using Portal.Domain.OrderAggregate.Specs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Portal.Domain.OrderAggregate
{

    public class Order:BaseEntity
    {
     
        public int UserId { get; set; }
        public OrderState State { get; set; }
       // [ForeignKey("UserId")]
        public User Users { get; set; }
        public ICollection<OrderItem> Items { get; set; }
        public bool IsPremiumUser { get; set; }
        public int Score { get; set; }

        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }
        public void RemoveItem(OrderItem item)
        {
            Items.Remove(item);
        }
        public void Cancel()
        {
            var s1 = new CanBeCanceledBeforeCooking();
            var s2 = new PremiumUserCanCancelBeforeDelivery();

            if (s1.Or(s2).IsSatisfiedBy(this))
            {
                State = OrderState.Canceled;
            }
        }
    }
}
