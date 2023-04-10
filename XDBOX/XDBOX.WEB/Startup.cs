using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using XDBOX.COMMON;
using XDBOX.DATA;
using XDBOX.DATA.Entities;
using XDBOX.DATA.RepositoryBase;
using static System.Net.Mime.MediaTypeNames;

namespace XDBOX.WEB
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            AppSettings.Initialize(configuration);
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(AppSettings.DevConnectionString));

            services.AddScoped<IRepository<User>, Repository<User>>();
            services.AddScoped<IRepository<Permission>, Repository<Permission>>();
            services.AddScoped<IRepository<Group>, Repository<Group>>();
            services.AddScoped<IRepository<UserSession>, Repository<UserSession>>();
            services.AddScoped<IRepository<SystemSettings>, Repository<SystemSettings>>();
            services.AddScoped<IRepository<PasswordResetToken>, Repository<PasswordResetToken>>();
            services.AddScoped<UnitOfWork>();

            services.AddControllersWithViews()
                .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env
            , ILoggerFactory loggerFactory, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            if (env.IsDevelopment())
            {
                // Cấu hình logging exception
                loggerFactory.AddLog4Net("log4net.config");
                app.UseExceptionHandler(c => c.Run(async (context) =>
                {
                    var exception = context.Features
                        .Get<IExceptionHandlerPathFeature>()
                        .Error;

                    await Task.Factory.StartNew(() => logger.LogError(exception.StackTrace));

                    context.Response.Redirect("/Notification/Error");
                }));
            }

            // Cấu hình xử lí lỗi 404, 403
            app.Use(async (context, next) =>
            {
                await next();
                if (context.Response.StatusCode == 404 && !context.Response.HasStarted)
                {
                    string originalPath = context.Request.Path.Value;
                    context.Items["originalPath"] = originalPath;
                    context.Response.Redirect("/Notification/PageNotFound");
                }
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

    }
}
