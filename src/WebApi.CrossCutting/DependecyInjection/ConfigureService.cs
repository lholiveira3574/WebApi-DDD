using Microsoft.Extensions.DependencyInjection;
using WebApi.Domain.Interfaces.Services.User;
using WebApi.Service.Services;

namespace WebApi.CrossCutting.DependecyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<ILoginService, LoginService>();
        }    
    }
}