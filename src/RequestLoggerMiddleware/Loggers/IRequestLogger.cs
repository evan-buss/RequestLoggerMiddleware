using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace RequestLoggerMiddleware.Loggers
{
    public interface IRequestLogger
    {
        RequestDelegate Next { get; }

        Task LogAsync(HttpContext context);
    }
}