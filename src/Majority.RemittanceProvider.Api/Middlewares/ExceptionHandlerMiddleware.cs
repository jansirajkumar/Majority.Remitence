using System.Net;
using System.Text.Json;
using FluentValidation;

namespace Majority.RemittanceProvider.Api.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;


        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = GetErrorStatusCode(error);

                var result = JsonSerializer.Serialize(new { errorMessage = GetErrorMessage(error) });
                await response.WriteAsync(result);
            }
        }

        private static int GetErrorStatusCode(Exception ex)
        {
            return ex switch
            {
                ValidationException _ => (int)HttpStatusCode.BadRequest,
                Exception _ => (int)HttpStatusCode.BadRequest,
                _ => (int)HttpStatusCode.InternalServerError
            };
        }

        private static string GetErrorMessage(Exception ex)
        {
            return ex switch
            {
                ValidationException exception => string.Join(", ", exception.Errors.Select(x => x.ErrorMessage)),
                Exception _ => ex.Message,
                _ => "An internal error occured"
            };
        }
    }
}
