//####################################################
//   XDBOX PROJECT
//   Date				Updater				Content
//   06/04/2023         Anh Đô              Create new 
//####################################################

using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XDBOX.COMMON
{
    public class AppSettings
    {
        public static string DevConnectionString;
        public static string CookieName { get; set; }
        public static int DefaultExpiredDays { get; set; }
        public static int MaxExpiredDays { get; set; }
        public static string PasswordRegex { get; set; }
        public static string MailHost { get; set; }
        public static int MailPort { get; set; }
        public static string MailPassword { get; set; }
        public static string MailAddress { get; set; }
        public static int ResetTokenExpiredMinutes { get; set; }

        public static void Initialize(IConfiguration configuration)
        {
            DevConnectionString = configuration.GetConnectionString("Dev");

            CookieName = configuration["Cookie:Name"];

            if (!string.IsNullOrEmpty(configuration.GetSection("Cookie:DefaultExpiredDays").Value))
            {
                DefaultExpiredDays = Convert.ToInt32(configuration.GetSection("Cookie:DefaultExpiredDays").Value);
            }
            else
            {
                DefaultExpiredDays = 1;
            }

            if (!string.IsNullOrEmpty(configuration.GetSection("Cookie:MaxExpiredDays").Value))
            {
                MaxExpiredDays = Convert.ToInt32(configuration.GetSection("Cookie:MaxExpiredDays").Value);
            }
            else
            {
                MaxExpiredDays = 7;
            }
        }

    }
}
