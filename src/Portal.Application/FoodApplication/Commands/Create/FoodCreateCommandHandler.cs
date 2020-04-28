using MediatR;
using Portal.Application.Common;
using Portal.Application.FoodApplication.Validation;
using Portal.Domain;
using Portal.Domain.Common;
using Portal.Domain.FoodAggregate;
using Portal.Persisatance;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Portal.Application.FoodApplication.Commands.Create
{
    public class FoodCreateCommandHandler : IRequestHandler<FoodCreateCommand, OperationResult<FoodCreateCommandResult>>
    {
        private readonly PortalDbContext _db;
        public FoodCreateCommandHandler(PortalDbContext db)
        {
            _db = db;
        }

        public async Task<OperationResult<FoodCreateCommandResult>> Handle(FoodCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                    var food = new Food(request.Name, new Mony(request.Price), request.FoodType)
                    {
                        Description = request.Description 
                        
                        
                    };
                    food.UpdatePrice(new Mony(request.Price));
                    var newfood =await _db.Foods.AddAsync(food);
                // await _db.SaveChangesAsync();
                var result = OperationResult<FoodCreateCommandResult>
                    .BuildSuccessResult(new FoodCreateCommandResult
                    { 
                        FoodId = newfood.Entity.ID
                    });
                return result;
            }
            catch (Exception ex)
            {

                var exResult = OperationResult<FoodCreateCommandResult>.BuildFailure(ex);
                return exResult;
            }   
        }   
    }
}
