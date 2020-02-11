using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Super.EWalletCore.PersonDataManagement.Bootstrap.Providers;

namespace Api.ServicesConfiguration
{
    public class ServiceConfiguration
    {
        //private readonly MvcConfiguration mvcConfiguration = new MvcConfiguration();
        //private readonly SwaggerConfiguration swaggerConfiguration = new SwaggerConfiguration();
        private readonly IConfiguration configuration;

        public ServiceConfiguration(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddAccountServiceClient(configuration);
            new PersonConfiguration().ConfigureServices(services);

            // services.AddMvc();
            // services.AddHealthChecks();
            // services.Configure<KestrelServerOptions>(configuration.GetSection("Kestrel"));
            //services.AddGrpc();
            // services.ConfigureMediatrServices();
            // mvcConfiguration.ConfigureServices(services);
            // swaggerConfiguration.ConfigureServices(services);
            // new PersistanceConfiguration(configuration).ConfigureServices(services);      

        }

        public void Configure(IApplicationBuilder app, bool isDevelopnment)
        {
            //mvcConfiguration.Configure(app, isDevelopnment);
            //swaggerConfiguration.Configure(app);
        }

    }
}
