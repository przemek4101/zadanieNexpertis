using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using zadanieNexpertis.Exceptions;

namespace zadanieNexpertis.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {

        public async Task InvokeAsync( HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch(BadRequestException badRequestException)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync(badRequestException.Message);
            }
            catch (NotFoundException notFoundException)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync(notFoundException.Message);
            }
        }
    }
}
