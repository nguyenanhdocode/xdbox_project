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
    public class Permission
    {
        public string PermissionID { get; set; }
        public string PermissionName { get; set; }
        public string PermissionNameE { get; set; }
        public bool IsDisabled { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Group> Groups { get; set; }
    }
}
