using Authentication.Models.Repositories.Abstract;
using Authentication.Models.Repositories.Real;
using Microsoft.Extensions.DependencyInjection;

namespace Authentication.Api.Injection
{
    public static class DependencyInjectionResolver
    {
        public static void DependecyInjection(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRefreshHandler, RefreshHandler>();
        }
    }
}
