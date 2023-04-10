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
    public class Group
    {
        public string GroupID { get; set; }
        public string GroupName { get; set; }
        public string GroupNameE { get; set; }
        public string IsDisabled { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Permission> Permissions { get; set; }
    }
}
