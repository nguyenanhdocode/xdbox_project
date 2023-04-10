using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XDBOX.COMMON;
using XDBOX.DATA;
using XDBOX.DATA.Entities;
using XDBOX.DATA.RepositoryBase;

namespace XDBOX.WEB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                var uw = services.GetRequiredService<UnitOfWork>();

                LoadSystemSettings(uw.SystemSettingsRep);
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        public static void LoadSystemSettings(IRepository<SystemSettings> rep)
        {
            AppSettings.MailHost = rep.Get(p => p.Key.Equals("MailHost"))?.Value ?? string.Empty;
            AppSettings.MailPort = rep.Get(p => p.Key.Equals("MailPort")) != null
                ? Convert.ToInt32(rep.Get(p => p.Key.Equals("MailPort")).Value)
                : 0;
            AppSettings.MailPassword = rep.Get(p => p.Key.Equals("MailPassword"))?.Value ?? string.Empty;
            AppSettings.MailAddress = rep.Get(p => p.Key.Equals("MailAddress"))?.Value ?? string.Empty;
            AppSettings.ResetTokenExpiredMinutes = rep.Get(p => p.Key.Equals("ResetTokenExpiredMinutes")) != null
                ? Convert.ToInt32(rep.Get(p => p.Key.Equals("ResetTokenExpiredMinutes")).Value)
                : 30;
        }
    }
}
