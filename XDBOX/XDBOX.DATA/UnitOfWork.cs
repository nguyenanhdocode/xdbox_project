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
using XDBOX.DATA.Entities;
using XDBOX.DATA.RepositoryBase;

namespace XDBOX.DATA
{
    public class UnitOfWork : IDisposable
    {
        public AppDbContext DbContext { get; }

        public IRepository<User> UserRep { get; }
        public IRepository<Permission> PermissionRep  { get; }
        public IRepository<Group> GroupRep  { get; }
        public IRepository<UserSession> UserSessionRep  { get; }
        public IRepository<SystemSettings> SystemSettingsRep  { get; }
        public IRepository<PasswordResetToken> PasswordResetTokenRep { get; set; }

        public UnitOfWork(AppDbContext context,
             IRepository<User> users,
             IRepository<Permission> permissions,
             IRepository<Group> groups,
             IRepository<UserSession> userSessions,
             IRepository<SystemSettings> systemSettings,
             IRepository<PasswordResetToken> passwordResetToken
            )
        {
            DbContext = context;

            UserRep = users;
            UserRep.DbContext = DbContext;

            PermissionRep = permissions;
            PermissionRep.DbContext = DbContext;

            GroupRep = groups;
            GroupRep.DbContext = DbContext;

            UserSessionRep = userSessions;
            UserSessionRep.DbContext = DbContext;

            SystemSettingsRep = systemSettings;
            SystemSettingsRep.DbContext = DbContext;

            PasswordResetTokenRep = passwordResetToken;
            PasswordResetTokenRep.DbContext = DbContext;
        }

        public int SaveChanges()
        {
            var iResult = DbContext.SaveChanges();
            return iResult;
        }

        public async Task<int> SaveChangesAsync()
        {
            var iResult = await DbContext.SaveChangesAsync();
            return iResult;
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}
