using Api.Common;
using Api.Presenters;
using Api.Presenters.Interfaces;
using Api.Presenters.Interfaces.AddressPresenters;
using Api.Presenters.Interfaces.EmailPresenters;
using Api.Presenters.Interfaces.GenderPresenters;
using Api.Presenters.Interfaces.PersonPresenters;
using Application;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Persistance;

namespace WebApi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;

        }
        public void ConfigureServices(IServiceCollection services)
        {
            //Aqui se informa en startup que es lo que debe hacer con cada 
            services.AddTransient<IAddressTypePresenter, AddressPresenter>();
            services.AddTransient<ICountryTypePresenter, CountryPresenter>();
            services.AddTransient<IEmailTypePresenter, EmailPresenter>();
            services.AddTransient<IGenderTypePresenter, GenderPresenter>();
            services.AddTransient<IPersonTypePresenter, PersonPresenter>();

            services.AddPersistence(Configuration);
            services.AddApplication();
            services.AddHealthChecks().AddDbContextCheck<PersonDbContext>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Person API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHealthChecks("/health");
            app.UseCustomExceptionHandler();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();            
            });
            app.UseSwagger();

            app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("v1/swagger.json", "Super.EWalletCore.PersonDataManagement");
                });
        }
    }
}
