using Data.Models.DB;
using Implementations;
using Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using RepositoryInterfaces;
using ServiceInterfaces;
using Services;
using System;

namespace UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Logger.LogInitialize(configuration);
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSession(options =>
            {
                options.Cookie.HttpOnly = true;
                options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                options.IdleTimeout = TimeSpan.FromMinutes(15);
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSingleton<ILoggers, Logger>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddDbContext<IOTContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("IOT"),
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.UseRowNumberForPaging();
                    });
            });
            services.AddTransient<ICountrySignalsRepository, CountrySignalsRepository>();
            services.AddTransient<IGetSignals, GetSignals>();
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
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=ScanningApp}/{action=Login}/{id?}");
            });
        }
    }
}
