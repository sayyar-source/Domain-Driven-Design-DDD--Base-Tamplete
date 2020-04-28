using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Portal.Application.OrderApplication.Notifications
{
    public class OrderCreatedSmsNotification : INotificationHandler<OrderCreatedNotification>
    {
        public Task Handle(OrderCreatedNotification notification, CancellationToken cancellationToken)
        {
            //--- send sms
            Debug.WriteLine("OrderCreatedSmsNotification");
            return Task.CompletedTask;
        }
    }
}
