using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Persistance
{
   public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PersonDbContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("PersonDB")));

            services.AddScoped<IPersonDbContext>(provider => provider.GetService<PersonDbContext>());

            return services;

        }
    }
}
