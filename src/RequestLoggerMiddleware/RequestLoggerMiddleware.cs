using Microsoft.AspNetCore.Http;
using RequestLoggerMiddleware.Loggers;
using System.Threading.Tasks;

namespace RequestLoggerMiddleware
{
    public class RequestLoggerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly RequestLoggerOptions _options;
        private readonly IRequestLogger _logger;

        public RequestLoggerMiddleware(RequestDelegate next, RequestLoggerOptions options = null)
        {
            _next = next;
            _options = options ?? new RequestLoggerOptions();

            if (_options.ShouldUseColor)
            {
                _logger = new ColorfulRequestLogger(_next);
            }
            else
            {
                _logger = new PlainRequestLogger(_next);
            }
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _logger.LogAsync(context).ConfigureAwait(false);
        }
    }
}