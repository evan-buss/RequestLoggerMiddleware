using Microsoft.AspNetCore.Http;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace RequestLoggerMiddleware
{
    public class RequestLoggerMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLoggerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            await _next(context).ConfigureAwait(false);

            stopwatch.Stop();
            Console.WriteLine($"{context.Request.Path} -- {stopwatch.ElapsedMilliseconds}ms");
        }
    }
}