using Amazon.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Application.Common
{
   public class OperationResult1
    {
        public bool Success { get; private set; }
        public Exception Exception { get; private set; }
       public string ErrorMessage { get; private set; }
        public static OperationResult1 BuildSuccess()
        {
            return new OperationResult1 { Success = true };
        }
        public static OperationResult1 BuildFailure(string errorMessage)
        {
            return new OperationResult1 { Success = false, ErrorMessage = errorMessage };
        }
        public static OperationResult1 BuildFailure(Exception exception)
        {
            return new OperationResult1 { Success = false, Exception=exception,ErrorMessage=exception.Message};
        }
       
        
    }
}
