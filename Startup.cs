using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.EntityFrameworkCore;
using ASPNETCore.SPADemo.Models;
using ASPNETCore.SPADemo.Controllers;

namespace ASPNETCore.SPADemo
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public void ConfigureDevelopmentServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            var svc = Environment.GetEnvironmentVariable("SQLDB_SVC_NAME"); //SQLSERVER_RHEL_DEV
            var server = Environment.GetEnvironmentVariable($"{svc}_SERVICE_HOST");
            var port = Environment.GetEnvironmentVariable($"{svc}_SERVICE_PORT");
            var user = Environment.GetEnvironmentVariable($"SQLDB_USER");
            var password = Environment.GetEnvironmentVariable($"SQLDB_PASSWORD");
            var connection = $@"Server={server},{port};Database=ASPNETCore_SPA_Demo_Dev;User Id={user};Password={password}";
            services.AddDbContext<ItemContext>(options => options.UseSqlServer(connection));

            services.Configure<Config>(config =>
            {
                config.Env = "Demo on Development";
            });
        }

        public void ConfigureProductionServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            var svc = Environment.GetEnvironmentVariable("SQLDB_SVC_NAME"); //SQLSERVER_RHEL_DEV
            var server = Environment.GetEnvironmentVariable($"{svc}_SERVICE_HOST");
            var port = Environment.GetEnvironmentVariable($"{svc}_SERVICE_PORT");
            var user = Environment.GetEnvironmentVariable($"SQLDB_USER");
            var password = Environment.GetEnvironmentVariable($"SQLDB_PASSWORD");
            var connection = $@"Server={server},{port};Database=ASPNETCore_SPA_Demo_Dev;User Id={user};Password={password}";
            services.AddDbContext<ItemContext>(options => options.UseSqlServer(connection));

            services.Configure<Config>(config =>
            {
                config.Env = "DEMO on Production";
            });
        }

        public void ConfigurServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            var svc = Environment.GetEnvironmentVariable("SQLDB_SVC_NAME"); //SQLSERVER_RHEL_DEV
            var server = Environment.GetEnvironmentVariable($"{svc}_SERVICE_HOST");
            var port = Environment.GetEnvironmentVariable($"{svc}_SERVICE_PORT");
            var user = Environment.GetEnvironmentVariable($"SQLDB_USER");
            var password = Environment.GetEnvironmentVariable($"SQLDB_PASSWORD");
            var connection = $@"Server={server},{port};Database=ASPNETCore_SPA_Demo_Dev;User Id={user};Password={password}";
            services.AddDbContext<ItemContext>(options => options.UseSqlServer(connection));

            services.Configure<Config>(config =>
            {
                config.Env = "Unkown";
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                // app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions {
                //     HotModuleReplacement = true
                // });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}