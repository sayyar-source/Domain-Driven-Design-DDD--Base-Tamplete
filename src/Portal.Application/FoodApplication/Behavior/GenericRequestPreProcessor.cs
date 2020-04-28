using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Portal.Application.FoodApplication.Behavior
{
    public class GenericRequestPreProcessor<T> : IRequestPreProcessor<T>
    {
        public async Task Process(T request, CancellationToken cancellationToken)
        {
            Console.WriteLine("PreProcessor");
        }
    }
}
