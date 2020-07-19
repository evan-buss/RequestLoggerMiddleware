using Microsoft.AspNetCore.Builder;
using System;

namespace RequestLoggerMiddleware
{
    public static class RequestLoggerMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestLogger(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestLoggerMiddleware>();
        }

        public static IApplicationBuilder UseRequestLogger(this IApplicationBuilder builder, Action<RequestLoggerOptions> configureOptions)
        {
            var options = new RequestLoggerOptions();
            configureOptions(options);
            return builder.UseMiddleware<RequestLoggerMiddleware>(options);
        }
    }
}