using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using System;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace RequestLoggerMiddleware.Loggers
{
    public class PlainRequestLogger : IRequestLogger
    {
        public RequestDelegate Next { get; }

        public PlainRequestLogger(RequestDelegate next)
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

            StringBuilder sb = new StringBuilder();
            sb.Append(time.ToString("MM/dd/yyy hh:MM:ss"));
            sb.Append(" \"");
            sb.Append(context.Request.Method);
            sb.Append(" ");
            sb.Append(context.Request.GetDisplayUrl());
            sb.Append(" ");
            sb.Append(context.Request.Protocol);
            sb.Append("\" from [");
            sb.Append(context.Connection.RemoteIpAddress);
            sb.Append("]:");
            sb.Append(context.Connection.RemotePort);
            sb.Append(" - ");
            sb.Append(context.Response.StatusCode);
            sb.Append(" ");
            //sb.Append(await ResponseLength(context).ConfigureAwait(false));
            sb.Append(" in ");
            sb.Append(stopwatch.ElapsedMilliseconds);
            sb.Append("ms");

            Console.WriteLine(sb);
        }
    }
}