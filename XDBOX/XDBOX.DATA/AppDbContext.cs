//####################################################
//   XDBOX PROJECT
//   Date				Updater				Content
//   06/04/2023         Anh Đô              Create new 
//####################################################

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XDBOX.DATA.Entities;

namespace XDBOX.DATA
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options) {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var user = builder.Entity<User>();
            user.HasKey(p => p.UserID);
            user.Property(p => p.UserID).HasColumnType("varchar(50)");
            user.Property(p => p.Email).HasColumnType("varchar(300)").IsRequired();
            user.Property(p => p.FirstName).HasColumnType("nvarchar(50)").IsRequired(false);
            user.Property(p => p.LastName).HasColumnType("nvarchar(50)").IsRequired(false);
            user.Property(p => p.Password).HasColumnType("varchar(1000)").IsRequired(true);
            user.Property(p => p.ActivateToken).HasColumnType("varchar(50)").IsRequired(false);
            user.Property(p => p.AvatarPath).IsRequired(false);
            user.Property(p => p.IsActivated).IsRequired(true).HasDefaultValue(false);
            user.Property(p => p.IsDisabled).IsRequired(true).HasDefaultValue(false);
            user.Property(p => p.Facebook).IsRequired(false);
            user.Property(p => p.Instagram).IsRequired(false);
            user.Property(p => p.Twitter).IsRequired(false);
            user.Property(p => p.JoinedDate).IsRequired(true).HasDefaultValue(DateTime.Now);
            user.HasMany(p => p.Permissions).WithMany(p => p.Users);
            user.HasMany<Group>(p => p.Groups).WithMany(p => p.Users);
            user.HasOne(p => p.UserSession).WithOne(p => p.User).HasForeignKey<UserSession>(p => p.UserID);

            var permission = builder.Entity<Permission>();
            permission.HasKey(p => p.PermissionID);
            permission.Property(p => p.PermissionID).HasColumnType("varchar(100)");
            permission.Property(p => p.PermissionName).HasColumnType("nvarchar(300)").IsRequired();
            permission.Property(p => p.PermissionNameE).HasColumnType("nvarchar(300)").IsRequired(false);
            permission.Property(p => p.IsDisabled).IsRequired(true).HasDefaultValue(false);
            permission.HasMany(p => p.Groups).WithMany(p => p.Permissions);

            var group = builder.Entity<Group>();
            group.HasKey(p => p.GroupID);
            group.Property(p => p.GroupID).HasColumnType("varchar(300)");
            group.Property(p => p.GroupName).HasColumnType("nvarchar(300)");
            group.Property(p => p.GroupNameE).HasColumnType("nvarchar(300)");
            group.Property(p => p.IsDisabled).IsRequired(true).HasDefaultValue(false);

            var systemSettings = builder.Entity<SystemSettings>();
            systemSettings.HasKey(p => p.Key);
            systemSettings.Property(p => p.Key).HasColumnType("varchar(200)");
            systemSettings.Property(p => p.Value).HasColumnType("nvarchar(500)").IsRequired(false);

            var userSession = builder.Entity<UserSession>();
            userSession.HasKey(p => p.UserID);
            userSession.Property(p => p.UserID).HasColumnType("varchar(50)").IsRequired();
            userSession.Property(p => p.SessionID).HasColumnType("varchar(1000)").IsRequired();
            userSession.Property(p => p.ExpiredTime).IsRequired();

            var passwordResetToken = builder.Entity<PasswordResetToken>();
            passwordResetToken.HasKey(p => p.Email);
            passwordResetToken.Property(p => p.TokenID).IsRequired(true).HasColumnType("varchar(50)");
            passwordResetToken.Property(p => p.ExpiredTime).IsRequired(true);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<SystemSettings> SystemSettings { get; set; }
        public DbSet<UserSession> UserSessions { get; set; }
        public DbSet<PasswordResetToken> PasswordResetTokens { get; set; }
    }
}
