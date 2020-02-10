using Api.Presenters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Application.Common.Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Common
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            CustomResult result = new CustomResult();

            switch (exception)
            {
                case ValidateException validationException:
                    result.StatusCode = 400;
                    result.Message = "Error";
                    result.Notifications = validationException.Failures;
                    break;
            }
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 200;

            return context.Response.WriteAsync(JsonConvert.SerializeObject(result));
        }
    }
    public static class CustomExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
        }
    }
}
