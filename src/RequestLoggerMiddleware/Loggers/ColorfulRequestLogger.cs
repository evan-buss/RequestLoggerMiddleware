using Colorful;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using Console = Colorful.Console;

namespace RequestLoggerMiddleware.Loggers
{
    public class ColorfulRequestLogger : IRequestLogger
    {
        public RequestDelegate Next { get; }

        private const string template = "{0} \"{1} {2} {3}\" from [{4}]:{5} - {6} in {7}ms";

        public ColorfulRequestLogger(RequestDelegate next)
        {
            Next = next;
        }

        public async Task LogAsync(HttpContext context)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var time = DateTime.Now;

            await Next(context).ConfigureAwait(false);

            stopwatch.Stop();

            var parameters = new Formatter[]
            {
                new Formatter(time.ToString("MM/dd/yyy hh:MM:ss"), Color.White),
                new Formatter(context.Request.Method, Color.WhiteSmoke),
                new Formatter(context.Request.GetDisplayUrl(), Color.Cyan),
                new Formatter(context.Request.Protocol, Color.Cyan),
                new Formatter(context.Connection.RemoteIpAddress, Color.White),
                new Formatter(context.Connection.RemotePort, Color.White),
                new Formatter(context.Response.StatusCode, StatusColor(context.Response.StatusCode)),
                new Formatter(stopwatch.ElapsedMilliseconds, ResponseTimeColor(stopwatch.ElapsedMilliseconds))
            };

            Console.WriteLineFormatted(template, Color.Gray, parameters);
        }

        private Color StatusColor(in int statusCode) => statusCode switch
        {
            int n when n < 200 => Color.Blue,
            int n when n < 300 => Color.Green,
            int n when n < 400 => Color.Cyan,
            int n when n < 500 => Color.Yellow,
            _ => Color.Red
        };

        private Color ResponseTimeColor(in long responseTimeMs) => responseTimeMs switch
        {
            long ms when ms < 500 => Color.Green,
            long ms when ms < TimeSpan.FromSeconds(5).TotalMilliseconds => Color.Yellow,
            _ => Color.Red
        };
    }
}