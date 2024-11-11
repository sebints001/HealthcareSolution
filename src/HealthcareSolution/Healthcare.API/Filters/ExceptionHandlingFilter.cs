using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace Healthcare.API.Filters
{
    public class ExceptionHandlingFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            // Log the exception (logging can be added here if required)
            var exception = context.Exception;

            // Handle specific exception types if needed, or handle generic exceptions
            if (exception is UnauthorizedAccessException)
            {
                context.Result = new ObjectResult(new { message = "Unauthorized access." })
                {
                    StatusCode = (int)HttpStatusCode.Unauthorized
                };
            }
            else if (exception is InvalidOperationException)
            {
                context.Result = new ObjectResult(new { message = "An invalid operation occurred." })
                {
                    StatusCode = (int)HttpStatusCode.BadRequest
                };
            }
            else
            {
                // For other unhandled exceptions
                context.Result = new ObjectResult(new { message = "An unexpected error occurred." })
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }

            // Mark the exception as handled to prevent it from being re-thrown
            context.ExceptionHandled = true;
        }
    }
}