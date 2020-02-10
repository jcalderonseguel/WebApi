using Application.Common.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SqlKata.Compilers;
using System.Data;

namespace Persistance
{
   public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("PersonDB");

            services.AddTransient<Compiler, SqlServerCompiler>();
            services.AddTransient<IDbConnection>(b =>
            {
                return new SqlConnection(connectionString);
            });

            services.AddDbContext<PersonDbContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("PersonDB")));

            services.AddScoped<IPersonDbContext>(provider => provider.GetService<PersonDbContext>());

            return services;
         

        }
    }
}
