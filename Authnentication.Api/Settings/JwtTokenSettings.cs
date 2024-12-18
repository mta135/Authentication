using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Authentication.Api.Settings
{
    public static class JwtTokenSettings
    {
        public static string JwtIssuer { get; private set; }

        public static string JwtKey { get; private set; }

        public static void InitializeSettings(IConfiguration config)
        {
            JwtIssuer = config.GetValue<string>("Jwt:Issuer");

            JwtKey = config.GetValue<string>("Jwt:Key");
        }
    }
}
