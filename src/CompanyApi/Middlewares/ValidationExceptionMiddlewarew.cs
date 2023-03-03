using Company.Interface.Common;
using System.Net;

namespace CompanyApi.Middlewares
{


    public class ValidationExceptionMiddleware

    {
        private readonly RequestDelegate _request;


        public ValidationExceptionMiddleware(RequestDelegate request) =>
            _request = request;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _request.Invoke(context);
            }
            catch (ModelValidationException ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Response.Headers.Clear();
                await context.Response.WriteAsync(ex.Message ?? "Validation exception!");
            }
            catch (NotFoundException ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                context.Response.Headers.Clear();
                await context.Response.WriteAsync(ex.Message ?? "Entity not found");
            }
        }
    }
}
