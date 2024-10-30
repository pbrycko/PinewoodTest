using System.Net;

namespace PinewoodTest.API.Middlewares
{
    public class CustomValidationExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomValidationExceptionMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await this._next(context);
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
