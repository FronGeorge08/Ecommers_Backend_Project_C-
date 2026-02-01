using FluentValidation;
using System.Net;
using System.Text.Json;

namespace Ecommers_API
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public GlobalExceptionMiddleware(RequestDelegate next)
        {
            this._next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            //Codul care sa l executam inaintea requestului
            try 
            {
                await this._next(context);
            }
            catch (ValidationException ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                var errorMessages = ex.Errors.Select(e => new
                {
                    Field = e.PropertyName,
                    Message = e.ErrorMessage,
                    Severity = e.Severity.ToString()
                });
                var response = new
                {
                    message = "Validation failed.",
                    statusCode = 400,
                    errors = errorMessages
                };
                var json = JsonSerializer.Serialize(response);
                await context.Response.WriteAsync(json);
            }
            //Codul care sa l executam dupa request
            
        }
    }
}
