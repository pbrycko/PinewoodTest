using System.Net;

namespace PinewoodTest.API.Middlewares
{
    public class CustomValidationExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomValidationExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (EmailConflictException e)
            {
                context.Response.Clear();
                context.Response.StatusCode = (int)HttpStatusCode.Conflict;
                await context.Response.WriteAsync(e.Message, context.RequestAborted);
            }
            catch (NotFoundException e)
            {
                context.Response.Clear();
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                await context.Response.WriteAsync(e.Message, context.RequestAborted);
            }
        }
    }
}
