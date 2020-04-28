using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portal.Application.OrderApplication.Create;
using Portal.Domain;
using Portal.Domain.OrderAggregate;
using Portal.Infrastructure.Persistance;
using Portal.UI.Models;

namespace Portal.UI.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
       private readonly IMediator _mediator;
       private readonly IUnitOfWork _uow;
        public OrderController(IMediator mediator, IUnitOfWork uow)
        {
            _mediator = mediator;
           _uow = uow;
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(OrderBasketModel orderBasket)
        {
            try
            {
                var result =await _mediator.Send(new OrderCreateCommand
                {
                    UserId=orderBasket.UserId,
                    Items= orderBasket.Items.Select(o => new OrderItem { FoodId = o.FoodId, Count = o.Count }).ToList()

                });
                return Ok(result.Result.OrderId);
            }
            catch (Exception)
            {

                throw;
            }
           
        }
        public async Task<IActionResult> editorder(Order order)
        {
            var result = await _uow.OrderRepository.EditOrder(order);
            await _uow.CommitAsync();
            return Ok(result);
        }
    }
}