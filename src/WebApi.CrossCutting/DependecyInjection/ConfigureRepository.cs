using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Data.Context;
using WebApi.Data.Implementations;
using WebApi.Data.Repository;
using WebApi.Domain.Interfaces;
using WebApi.Domain.Repository;

namespace WebApi.CrossCutting.DependecyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<IUserRepository, UserImplementation>();

            serviceCollection.AddDbContext<MyContext>(
                options => options.UseMySql("server=localhost;userid=root;password='';database=dbWebApi")    
            );
        }       
    }
}