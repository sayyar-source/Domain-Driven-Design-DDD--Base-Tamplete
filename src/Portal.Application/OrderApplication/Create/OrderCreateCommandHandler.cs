using MediatR;
using Portal.Application.Common;
using Portal.Application.OrderApplication.Notifications;
using Portal.Domain;
using Portal.Domain.OrderAggregate;
using Portal.Persisatance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Portal.Application.OrderApplication.Create
{
    public class OrderCreateCommandHandler : IRequestHandler<OrderCreateCommand, OperationResult<OrderCreateCommandResult>>
    {
        private readonly PortalDbContext _db;
        private readonly IMediator _mediator;
       // private readonly ScoreService _scoreService;
        public OrderCreateCommandHandler(PortalDbContext db, IMediator mediator/*, ScoreService scoreService*/)
        {
            _db = db;
            _mediator = mediator;
           // _scoreService = scoreService;
        }
        public async Task<OperationResult<OrderCreateCommandResult>> Handle(OrderCreateCommand request, CancellationToken cancellationToken)
        {
            var order = new Order { IsEnable = true, State = OrderState.New, TimeCreated = DateTime.Now, UserId = request.UserId };
           // order.Score = _scoreService.CalculateScore(order, new User ());
            order.Items = new List<OrderItem>();
            _db.Orders.Add(order);
            var foods = _db.Foods.ToList();
            foreach (var item in request.Items)
            {
                
                var food = foods.Single(f => f.ID == item.FoodId);
                order.Items.Add(new OrderItem
                {
                    FoodId = item.FoodId,
                    IsEnable = true,
                    Count = item.Count,
                    OrderId = order.ID,
                    TimeCreated = DateTime.Now,
                    UnitPrice = food.Price.Value,
                    TotalPrice = food.Price.Value * item.Count,
                    
                });

            }
            //---Send SMS
            //----Send Email
            await _mediator.Publish(new OrderCreatedNotification());

            var result = OperationResult<OrderCreateCommandResult>
                .BuildSuccessResult(new OrderCreateCommandResult
                {
                    OrderId = order.ID
                });
            await Task.CompletedTask;
            return result;

        }
    }
}
