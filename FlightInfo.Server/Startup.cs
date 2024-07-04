using FlightInfo.Common.Interfaces.Providers;
using FlightInfo.Common.Interfaces.Services;
using FlightInfo.Common.Models.Configurations;
using FlightInfo.Logic.Services;
using FlightInfo.Provider.ApiProviders;
using FlightInfo.Server.Code.Middleware;
using FlightInfo.Server.Code.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Converters;
using System;
using System.IO;
using System.Reflection;

namespace FlightInfo.Server
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
            services.Configure<ApiServicesConfiguration>(options => Configuration.GetSection("ApiServices").Bind(options));
            services.AddTransient<IFlightService, FlightService>();
            services.AddTransient<IAirportInfoByNameApiProvider, AirportInfoByNameApiProvider>();
            services.AddSwaggerGen(option =>
            {
                option.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, Assembly.GetExecutingAssembly().GetName().Name + ".xml"));
                option.SchemaFilter<EnumSchemaFilter>();
            });

            services.AddMvc()
                .AddControllersAsServices()
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.Converters.Add(new StringEnumConverter());
                });//.SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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
                app.UseHsts();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Airports API");
            });
            app.UseMiddleware(typeof(ErrorHandlingMiddleware));
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
