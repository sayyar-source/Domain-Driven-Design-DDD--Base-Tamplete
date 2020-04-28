﻿using MediatR;
using Portal.Application.Common;
using Portal.Domain.Common;
using Portal.Domain.FoodAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Application.FoodApplication.Commands.Create
{
   public class FoodCreateCommand:IRequest<OperationResult<FoodCreateCommandResult>>
    {
        public int Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public FoodType FoodType { get; set; }
    }
}
