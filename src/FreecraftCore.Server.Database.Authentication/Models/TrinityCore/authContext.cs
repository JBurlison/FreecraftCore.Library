using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FreecraftCore
{
    public partial class authContext : DbContext
    {
        public authContext()
        {
        }

        public authContext(DbContextOptions<authContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<AccountAccess> AccountAccess { get; set; }
        public virtual DbSet<AccountBanned> AccountBanned { get; set; }
        public virtual DbSet<AccountMuted> AccountMuted { get; set; }
        public virtual DbSet<Autobroadcast> Autobroadcast { get; set; }
        public virtual DbSet<IpBanned> IpBanned { get; set; }
        public virtual DbSet<LogsIpActions> LogsIpActions { get; set; }
        public virtual DbSet<QuestCompleter> QuestCompleter { get; set; }
        public virtual DbSet<RbacAccountPermissions> RbacAccountPermissions { get; set; }
        public virtual DbSet<RbacDefaultPermissions> RbacDefaultPermissions { get; set; }
        public virtual DbSet<RbacLinkedPermissions> RbacLinkedPermissions { get; set; }
        public virtual DbSet<RbacPermissions> RbacPermissions { get; set; }
        public virtual DbSet<Realmcharacters> Realmcharacters { get; set; }
        public virtual DbSet<Realmlist> Realmlist { get; set; }
        public virtual DbSet<Updates> Updates { get; set; }
        public virtual DbSet<UpdatesInclude> UpdatesInclude { get; set; }
        public virtual DbSet<Uptime> Uptime { get; set; }

        // Unable to generate entity type for table 'logs'. Please see the warning messages.
        // Unable to generate entity type for table 'quest_completer_comments'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=kurthoswow-test-db.c7tnrjczj0de.us-east-2.rds.amazonaws.com;port=3306;user=root;password=KurthosWoW;database=auth");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("account");

                entity.HasIndex(e => e.Username)
                    .HasName("idx_username")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Expansion)
                    .HasColumnName("expansion")
                    .HasDefaultValueSql("'2'");

                entity.Property(e => e.FailedLogins)
                    .HasColumnName("failed_logins")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Joindate)
                    .HasColumnName("joindate")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.LastAttemptIp)
                    .IsRequired()
                    .HasColumnName("last_attempt_ip")
                    .HasColumnType("varchar(15)")
                    .HasDefaultValueSql("'127.0.0.1'");

                entity.Property(e => e.LastIp)
                    .IsRequired()
                    .HasColumnName("last_ip")
                    .HasColumnType("varchar(15)")
                    .HasDefaultValueSql("'127.0.0.1'");

                entity.Property(e => e.LastLogin)
                    .HasColumnName("last_login")
                    .HasColumnType("timestamp");

                entity.Property(e => e.Locale)
                    .HasColumnName("locale")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.LockCountry)
                    .IsRequired()
                    .HasColumnName("lock_country")
                    .HasColumnType("varchar(2)")
                    .HasDefaultValueSql("'00'");

                entity.Property(e => e.Locked)
                    .HasColumnName("locked")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Muteby)
                    .IsRequired()
                    .HasColumnName("muteby")
                    .HasColumnType("varchar(50)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Mutereason)
                    .IsRequired()
                    .HasColumnName("mutereason")
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Mutetime)
                    .HasColumnName("mutetime")
                    .HasColumnType("bigint(20)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Online)
                    .HasColumnName("online")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Os)
                    .IsRequired()
                    .HasColumnName("os")
                    .HasColumnType("varchar(3)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Recruiter)
                    .HasColumnName("recruiter")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.RegMail)
                    .IsRequired()
                    .HasColumnName("reg_mail")
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.S)
                    .IsRequired()
                    .HasColumnName("s")
                    .HasColumnType("varchar(64)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Sessionkey)
                    .IsRequired()
                    .HasColumnName("sessionkey")
                    .HasColumnType("varchar(80)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ShaPassHash)
                    .IsRequired()
                    .HasColumnName("sha_pass_hash")
                    .HasColumnType("varchar(40)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.TokenKey)
                    .IsRequired()
                    .HasColumnName("token_key")
                    .HasColumnType("varchar(100)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasColumnType("varchar(32)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.V)
                    .IsRequired()
                    .HasColumnName("v")
                    .HasColumnType("varchar(64)")
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<AccountAccess>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.RealmId });

                entity.ToTable("account_access");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.RealmId)
                    .HasColumnName("RealmID")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'-1'");

                entity.Property(e => e.Gmlevel).HasColumnName("gmlevel");
            });

            modelBuilder.Entity<AccountBanned>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Bandate });

                entity.ToTable("account_banned");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Bandate)
                    .HasColumnName("bandate")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Bannedby)
                    .IsRequired()
                    .HasColumnName("bannedby")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Banreason)
                    .IsRequired()
                    .HasColumnName("banreason")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Unbandate)
                    .HasColumnName("unbandate")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<AccountMuted>(entity =>
            {
                entity.HasKey(e => new { e.Guid, e.Mutedate });

                entity.ToTable("account_muted");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Mutedate)
                    .HasColumnName("mutedate")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Mutedby)
                    .IsRequired()
                    .HasColumnName("mutedby")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Mutereason)
                    .IsRequired()
                    .HasColumnName("mutereason")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Mutetime)
                    .HasColumnName("mutetime")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<Autobroadcast>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Realmid });

                entity.ToTable("autobroadcast");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Realmid)
                    .HasColumnName("realmid")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'-1'");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasColumnName("text")
                    .HasColumnType("longtext");

                entity.Property(e => e.Weight)
                    .HasColumnName("weight")
                    .HasDefaultValueSql("'1'");
            });

            modelBuilder.Entity<IpBanned>(entity =>
            {
                entity.HasKey(e => new { e.Ip, e.Bandate });

                entity.ToTable("ip_banned");

                entity.Property(e => e.Ip)
                    .HasColumnName("ip")
                    .HasColumnType("varchar(15)")
                    .HasDefaultValueSql("'127.0.0.1'");

                entity.Property(e => e.Bandate).HasColumnName("bandate");

                entity.Property(e => e.Bannedby)
                    .IsRequired()
                    .HasColumnName("bannedby")
                    .HasColumnType("varchar(50)")
                    .HasDefaultValueSql("'[Console]'");

                entity.Property(e => e.Banreason)
                    .IsRequired()
                    .HasColumnName("banreason")
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("'no reason'");

                entity.Property(e => e.Unbandate).HasColumnName("unbandate");
            });

            modelBuilder.Entity<LogsIpActions>(entity =>
            {
                entity.ToTable("logs_ip_actions");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.CharacterGuid).HasColumnName("character_guid");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .HasColumnType("text");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasColumnName("ip")
                    .HasColumnType("varchar(15)")
                    .HasDefaultValueSql("'127.0.0.1'");

                entity.Property(e => e.Systemnote)
                    .HasColumnName("systemnote")
                    .HasColumnType("text");

                entity.Property(e => e.Time)
                    .HasColumnName("time")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.Property(e => e.Unixtime).HasColumnName("unixtime");
            });

            modelBuilder.Entity<QuestCompleter>(entity =>
            {
                entity.ToTable("quest_completer");

                entity.Property(e => e.Id).HasColumnName("id");
            });

            modelBuilder.Entity<RbacAccountPermissions>(entity =>
            {
                entity.HasKey(e => new { e.AccountId, e.PermissionId, e.RealmId });

                entity.ToTable("rbac_account_permissions");

                entity.HasIndex(e => e.PermissionId)
                    .HasName("fk__rbac_account_roles__rbac_permissions");

                entity.Property(e => e.AccountId).HasColumnName("accountId");

                entity.Property(e => e.PermissionId).HasColumnName("permissionId");

                entity.Property(e => e.RealmId)
                    .HasColumnName("realmId")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'-1'");

                entity.Property(e => e.Granted)
                    .HasColumnName("granted")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'1'");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.RbacAccountPermissions)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("fk__rbac_account_permissions__account");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.RbacAccountPermissions)
                    .HasForeignKey(d => d.PermissionId)
                    .HasConstraintName("fk__rbac_account_roles__rbac_permissions");
            });

            modelBuilder.Entity<RbacDefaultPermissions>(entity =>
            {
                entity.HasKey(e => new { e.SecId, e.PermissionId, e.RealmId });

                entity.ToTable("rbac_default_permissions");

                entity.HasIndex(e => e.PermissionId)
                    .HasName("fk__rbac_default_permissions__rbac_permissions");

                entity.Property(e => e.SecId).HasColumnName("secId");

                entity.Property(e => e.PermissionId).HasColumnName("permissionId");

                entity.Property(e => e.RealmId)
                    .HasColumnName("realmId")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'-1'");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.RbacDefaultPermissions)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk__rbac_default_permissions__rbac_permissions");
            });

            modelBuilder.Entity<RbacLinkedPermissions>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.LinkedId });

                entity.ToTable("rbac_linked_permissions");

                entity.HasIndex(e => e.Id)
                    .HasName("fk__rbac_linked_permissions__rbac_permissions1");

                entity.HasIndex(e => e.LinkedId)
                    .HasName("fk__rbac_linked_permissions__rbac_permissions2");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.LinkedId).HasColumnName("linkedId");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.RbacLinkedPermissionsIdNavigation)
                    .HasForeignKey(d => d.Id)
                    .HasConstraintName("fk__rbac_linked_permissions__rbac_permissions1");

                entity.HasOne(d => d.Linked)
                    .WithMany(p => p.RbacLinkedPermissionsLinked)
                    .HasForeignKey(d => d.LinkedId)
                    .HasConstraintName("fk__rbac_linked_permissions__rbac_permissions2");
            });

            modelBuilder.Entity<RbacPermissions>(entity =>
            {
                entity.ToTable("rbac_permissions");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<Realmcharacters>(entity =>
            {
                entity.HasKey(e => new { e.Realmid, e.Acctid });

                entity.ToTable("realmcharacters");

                entity.HasIndex(e => e.Acctid)
                    .HasName("acctid");

                entity.Property(e => e.Realmid)
                    .HasColumnName("realmid")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Acctid).HasColumnName("acctid");

                entity.Property(e => e.Numchars)
                    .HasColumnName("numchars")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<Realmlist>(entity =>
            {
                entity.ToTable("realmlist");

                entity.HasIndex(e => e.Name)
                    .HasName("idx_name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("'127.0.0.1'");

                entity.Property(e => e.AllowedSecurityLevel)
                    .HasColumnName("allowedSecurityLevel")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Flag)
                    .HasColumnName("flag")
                    .HasDefaultValueSql("'2'");

                entity.Property(e => e.Gamebuild)
                    .HasColumnName("gamebuild")
                    .HasDefaultValueSql("'12340'");

                entity.Property(e => e.Icon)
                    .HasColumnName("icon")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.LocalAddress)
                    .IsRequired()
                    .HasColumnName("localAddress")
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("'127.0.0.1'");

                entity.Property(e => e.LocalSubnetMask)
                    .IsRequired()
                    .HasColumnName("localSubnetMask")
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("'255.255.255.0'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(32)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Port)
                    .HasColumnName("port")
                    .HasDefaultValueSql("'8085'");

                entity.Property(e => e.Timezone)
                    .HasColumnName("timezone")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<Updates>(entity =>
            {
                entity.HasKey(e => e.Name);

                entity.ToTable("updates");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Hash)
                    .HasColumnName("hash")
                    .HasColumnType("char(40)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Speed)
                    .HasColumnName("speed")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Timestamp)
                    .HasColumnName("timestamp")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");
            });

            modelBuilder.Entity<UpdatesInclude>(entity =>
            {
                entity.HasKey(e => e.Path);

                entity.ToTable("updates_include");

                entity.Property(e => e.Path)
                    .HasColumnName("path")
                    .HasColumnType("varchar(200)");
            });

            modelBuilder.Entity<Uptime>(entity =>
            {
                entity.HasKey(e => new { e.Realmid, e.Starttime });

                entity.ToTable("uptime");

                entity.Property(e => e.Realmid).HasColumnName("realmid");

                entity.Property(e => e.Starttime)
                    .HasColumnName("starttime")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Maxplayers)
                    .HasColumnName("maxplayers")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Revision)
                    .IsRequired()
                    .HasColumnName("revision")
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("'Trinitycore'");

                entity.Property(e => e.Uptime1)
                    .HasColumnName("uptime")
                    .HasDefaultValueSql("'0'");
            });
        }
    }
}
