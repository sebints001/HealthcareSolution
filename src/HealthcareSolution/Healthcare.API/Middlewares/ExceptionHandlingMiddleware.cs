using Healthcare.Application;
using Healthcare.Application.Exceptions;
using System.Net;

namespace Healthcare.API
{
    // In the API Layer
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (PatientNotFoundException ex)
            {
                _logger.LogWarning(ex, "Patient not found");
                await HandleExceptionAsync(httpContext, ex, HttpStatusCode.NotFound);
            }
            catch (InvalidPatientDataException ex)
            {
                _logger.LogWarning(ex, "Invalid patient data");
                await HandleExceptionAsync(httpContext, ex, HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred");
                await HandleExceptionAsync(httpContext, ex, HttpStatusCode.InternalServerError);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception, HttpStatusCode statusCode)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            var response = new
            {
                statusCode = context.Response.StatusCode,
                message = exception.Message,
                details = exception.StackTrace // This is optional and can be removed in production.
            };

            return context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(response));
        }
    }

}