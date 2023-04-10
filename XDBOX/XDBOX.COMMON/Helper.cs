using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace XDBOX.COMMON
{
    public class Helper
    {
        /// <summary>
        /// Xử lí hash chuỗi ra md5
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string MD5Hash(string input)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                return Convert.ToHexString(hashBytes); 
            }
        }

        /// <summary>
        /// Kiểm tra độ mạnh của mật khẩu
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool CheckValidPassword(string password)
        {
            string defaultRegex = @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$";
            var regex = !string.IsNullOrEmpty(AppSettings.PasswordRegex) ? AppSettings.PasswordRegex : defaultRegex;
            return Regex.IsMatch(password, regex);
        }

        /// <summary>
        /// Xử lí check email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool CheckValidEmail(string email)
        {
            string pattern = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            return Regex.IsMatch(email, pattern);
        }

        /// <summary>
        /// Xử lí lấy ReturnURL từ QueryString
        /// </summary>
        /// <param name="queryString"></param>
        /// <returns></returns>
        public static string GetReturnURL(string queryString)
        {
            string returnURL = string.Empty;
            var splited = queryString.Split('=');
            if (splited.Length < 2)
            {
                returnURL = "/Home/Index";
                return returnURL;
            }

            return HttpUtility.UrlDecode(splited[1]);
        }
    }
}
