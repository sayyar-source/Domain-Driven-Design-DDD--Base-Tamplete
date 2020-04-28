using MediatR;
using Portal.Application.Common;
using Portal.Domain;
using Portal.Domain.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Application.OrderApplication.Create
{
   public class OrderCreateCommand:IRequest<OperationResult<OrderCreateCommandResult>>
    {
        public int UserId { get; set; }
        public ICollection<OrderItem> Items { get; set; }
    }
}
