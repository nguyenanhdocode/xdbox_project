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
    public class User
    {
        public string UserID { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string ActivateToken { get; set; }
        public string AvatarPath { get; set; }
        public bool IsActivated { get; set; }
        public bool IsDisabled { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string Twitter { get; set; }
        public DateTime JoinedDate { get; set; }
        public ICollection<Permission> Permissions { get; set; }
        public ICollection<Group> Groups { get; set; }
        public UserSession UserSession { get; set; }
    }
}
