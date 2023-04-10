using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XDBOX.DATA.Entities
{
    public class PasswordResetToken
    {
        public string Email { get; set; }
        public string TokenID { get; set; }
        public DateTime ExpiredTime { get; set; }
    }
}
