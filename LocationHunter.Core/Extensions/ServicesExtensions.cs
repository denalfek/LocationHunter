using System;
using System.Collections.Generic;
using System.Text;

namespace LocationHunter.Core.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceProvider ServicesRegistration(this IServiceProvider services)
        {
            services.AddHttpClient()
        }
    }
}
