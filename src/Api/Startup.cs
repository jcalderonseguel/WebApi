<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Common;
=======
>>>>>>> parent of 033f538... get de genders listo e insert de person incompleto
=======
>>>>>>> parent of 033f538... get de genders listo e insert de person incompleto
=======
>>>>>>> parent of 033f538... get de genders listo e insert de person incompleto
using Application;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
            services.AddPersistence(Configuration);
            services.AddApplication();
            services.AddHealthChecks().AddDbContextCheck<PersonDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
            app.UseHealthChecks("/health");
=======

>>>>>>> parent of 033f538... get de genders listo e insert de person incompleto
=======

>>>>>>> parent of 033f538... get de genders listo e insert de person incompleto
            app.UseRouting();
=======

            app.UseRouting();

>>>>>>> parent of 033f538... get de genders listo e insert de person incompleto
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
