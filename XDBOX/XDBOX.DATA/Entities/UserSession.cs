//####################################################
//   XDBOX PROJECT
//   Date				Updater				Content
//   06/04/2023         Anh Đô              Create new 
//####################################################

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XDBOX.DATA.Entities
{
    public class UserSession
    {
        public string UserID { get; set; }
        public string SessionID { get; set; }
        public DateTime ExpiredTime { get; set; }
        public User User { get; set; }
    }
}
