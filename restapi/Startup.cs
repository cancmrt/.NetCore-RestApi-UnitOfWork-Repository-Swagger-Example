using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using restapi.Connection.Abstract;
using restapi.Connection.Concrete;
using Swashbuckle.AspNetCore.Swagger;

namespace restapi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            /*services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });*/
            services.AddSingleton<IConnectionFactory, ConnectionFactory>();
            services.AddSwaggerGen(swag =>
            {
                swag.SwaggerDoc("v0.1", new Info
                {
                    Version = "v0.1",
                    Title = ".NetCore and Dapper Useful Pattern Example",
                    Description = "Using Generic Repository Pattern and Repository Pattern With Unit Of Work Pattern and Dapper with using Swagger In.Net Core Rest Api => Example",
                    TermsOfService = "None",
                    Contact = new Contact()
                    {
                        Name = "Can Cömert",
                        Email = "cancm91@gmail.com"
                    }

                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(swag =>
            {
                swag.SwaggerEndpoint("/swagger/v0.1/swagger.json", ".NetCore and Dapper Useful Pattern Example v0.1");
            });
        }
    }
}
