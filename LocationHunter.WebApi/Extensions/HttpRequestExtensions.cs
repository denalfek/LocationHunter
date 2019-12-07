using Microsoft.AspNetCore.Http;
using System.Net;

namespace LocationHunter.WebApi.Extensions
{
    public static class HttpRequestExtensions
    {
        public static IPAddress GetIp(this HttpRequest req)
        {
            const string header = "X-Real-IP";
            if (req.Headers.ContainsKey(header))
            {
                var headerValue = req.Headers[header].ToString();
                if (IPAddress.TryParse(headerValue, out var ip))
                {
                    return ip.MapToIPv4();
                }
            }

            return req.HttpContext.Connection.RemoteIpAddress.MapToIPv4();
        }
    }
}
