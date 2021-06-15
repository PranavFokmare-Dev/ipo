using Contracts;
using Entitites;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ipo.Middlewares
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly LoggerManager _logger;

        public GlobalExceptionMiddleware(RequestDelegate next, LoggerManager logger)
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
            catch(Exception ex)
            {
                _logger.LogError($"EXCEPTION Something went wrong :{ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }
        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            ErrorDetails errorDetails = new ErrorDetails() { Message = "Internal Server Error", StatusCode = context.Response.StatusCode };
            await context.Response.WriteAsync(errorDetails.ToString());
        }
    }
}
