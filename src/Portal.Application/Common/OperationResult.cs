﻿using Amazon.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Application.Common
{
    public class OperationResult<TResult>
    {
        public TResult Result { get; private set; }
        public bool Success { get; private set; }
        public Exception Exception { get; private set; }
       public string ErrorMessage { get; private set; }
        public static OperationResult<TResult> BuildSuccessResult(TResult result)
        {
            return new OperationResult<TResult> { Success = true,Result=result };
        }
        public static OperationResult<TResult> BuildFailure(string errorMessage)
        {
            return new OperationResult<TResult> { Success = false, ErrorMessage = errorMessage };
        }
        public static OperationResult<TResult> BuildFailure(Exception exception)
        {
            return new OperationResult<TResult> { Success = false, Exception = exception };
        }
        public static OperationResult<TResult> BuildFailure(Exception exception,string errorMessage)
        {
            return new OperationResult<TResult> { Success = false, Exception=exception,ErrorMessage=errorMessage};
        }
       
        
    }
}
