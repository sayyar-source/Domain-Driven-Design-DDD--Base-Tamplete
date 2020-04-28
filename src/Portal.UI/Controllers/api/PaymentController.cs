using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portal.Domain;
using Portal.Persisatance;
using Portal.UI.Models;

namespace Portal.UI.Controllers.api
{
    [ApiController]
    public class PaymentController : Controller
    {
        private readonly PortalDbContext _db;
        public PaymentController(PortalDbContext db)
        {
            _db = db;
        }
        [HttpPost]
        [Route("api/payment")]
        public IActionResult AddEvent( PaymentAddModel model)
        {
            model.UserId = 4;
            _db.Payments.Add(new Domain.Payment
            {
                Amount=model.Amount,
                BankName=model.BankName,
                BankTransactionId=model.BankTransactionId,
                UserId=model.UserId,
                EventType=model.EventType,
                TimeStamp=DateTime.Now

            });
            _db.SaveChanges();
            return Ok("done");
        }
        [Route("api/payment/check")]
        public IActionResult Check(int userid)
        {
            var payments = _db.Payments.Where(u => u.UserId == userid).ToList();
            var addcredit = payments.Where(p => p.EventType == PaymentEventType.AddCredit).Sum(s => s.Amount);
            var removecredit = payments.Where(p => p.EventType == PaymentEventType.RemoveCredit).Sum(s => s.Amount);
            var result = addcredit - removecredit;
            return Ok(result);
        }
    }
}