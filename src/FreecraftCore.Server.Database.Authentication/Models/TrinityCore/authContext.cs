using Microsoft.EntityFrameworkCore;

namespace FreecraftCore
{
    public partial class authContext : DbContext
    {
        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<AccountAccess> AccountAccess { get; set; }
        public virtual DbSet<AccountBanned> AccountBanned { get; set; }
        public virtual DbSet<AccountMuted> AccountMuted { get; set; }
        public virtual DbSet<Autobroadcast> Autobroadcast { get; set; }
        public virtual DbSet<Ip2nationcountries> Ip2nationcountries { get; set; }
        public virtual DbSet<IpBanned> IpBanned { get; set; }
        public virtual DbSet<LogsIpActions> LogsIpActions { get; set; }
        public virtual DbSet<RbacAccountPermissions> RbacAccountPermissions { get; set; }
        public virtual DbSet<RbacDefaultPermissions> RbacDefaultPermissions { get; set; }
        public virtual DbSet<RbacLinkedPermissions> RbacLinkedPermissions { get; set; }
        public virtual DbSet<RbacPermissions> RbacPermissions { get; set; }
        public virtual DbSet<Realmcharacters> Realmcharacters { get; set; }
        public virtual DbSet<Realmlist> Realmlist { get; set; }
        public virtual DbSet<Updates> Updates { get; set; }
        public virtual DbSet<UpdatesInclude> UpdatesInclude { get; set; }
        public virtual DbSet<Uptime> Uptime { get; set; }

        // Unable to generate entity type for table 'auth.ip2nation'. Please see the warning messages.
        // Unable to generate entity type for table 'auth.logs'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseMySQL(@"server=localhost;port=3306;user=root;password=test;database=auth");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("account", "auth");

                entity.HasIndex(e => e.Username)
                    .HasName("idx_username")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255);

                entity.Property(e => e.Expansion)
                    .HasColumnName("expansion")
                    .HasColumnType("tinyint(3) unsigned")
                    .HasDefaultValueSql("2");

                entity.Property(e => e.FailedLogins)
                    .HasColumnName("failed_logins")
                    .HasColumnType("int(10) unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Joindate)
                    .HasColumnName("joindate")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.LastAttemptIp)
                    .IsRequired()
                    .HasColumnName("last_attempt_ip")
                    .HasColumnType("varchar(15)")
                    .HasMaxLength(15)
                    .HasDefaultValueSql("127.0.0.1");

                entity.Property(e => e.LastIp)
                    .IsRequired()
                    .HasColumnName("last_ip")
                    .HasColumnType("varchar(15)")
                    .HasMaxLength(15)
                    .HasDefaultValueSql("127.0.0.1");

                entity.Property(e => e.LastLogin)
                    .HasColumnName("last_login")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("0000-00-00 00:00:00");

                entity.Property(e => e.Locale)
                    .HasColumnName("locale")
                    .HasColumnType("tinyint(3) unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.LockCountry)
                    .IsRequired()
                    .HasColumnName("lock_country")
                    .HasColumnType("varchar(2)")
                    .HasMaxLength(2)
                    .HasDefaultValueSql("00");

                entity.Property(e => e.Locked)
                    .HasColumnName("locked")
                    .HasColumnType("tinyint(3) unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Muteby)
                    .IsRequired()
                    .HasColumnName("muteby")
                    .HasColumnType("varchar(50)")
                    .HasMaxLength(50);

                entity.Property(e => e.Mutereason)
                    .IsRequired()
                    .HasColumnName("mutereason")
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255);

                entity.Property(e => e.Mutetime)
                    .HasColumnName("mutetime")
                    .HasColumnType("bigint(20)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Online)
                    .HasColumnName("online")
                    .HasColumnType("tinyint(3) unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Os)
                    .IsRequired()
                    .HasColumnName("os")
                    .HasColumnType("varchar(3)")
                    .HasMaxLength(3);

                entity.Property(e => e.Recruiter)
                    .HasColumnName("recruiter")
                    .HasColumnType("int(10) unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RegMail)
                    .IsRequired()
                    .HasColumnName("reg_mail")
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255);

                entity.Property(e => e.S)
                    .IsRequired()
                    .HasColumnName("s")
                    .HasColumnType("varchar(64)")
                    .HasMaxLength(64);

                entity.Property(e => e.Sessionkey)
                    .IsRequired()
                    .HasColumnName("sessionkey")
                    .HasColumnType("varchar(80)")
                    .HasMaxLength(80);

                entity.Property(e => e.ShaPassHash)
                    .IsRequired()
                    .HasColumnName("sha_pass_hash")
                    .HasColumnType("varchar(40)")
                    .HasMaxLength(40);

                entity.Property(e => e.TokenKey)
                    .IsRequired()
                    .HasColumnName("token_key")
                    .HasColumnType("varchar(100)")
                    .HasMaxLength(100);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasColumnType("varchar(32)")
                    .HasMaxLength(32);

                entity.Property(e => e.V)
                    .IsRequired()
                    .HasColumnName("v")
                    .HasColumnType("varchar(64)")
                    .HasMaxLength(64);
            });

            modelBuilder.Entity<AccountAccess>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.RealmId })
                    .HasName("PRIMARY");

                entity.ToTable("account_access", "auth");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.RealmId)
                    .HasColumnName("RealmID")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("-1");

                entity.Property(e => e.Gmlevel)
                    .HasColumnName("gmlevel")
                    .HasColumnType("tinyint(3) unsigned");
            });

            modelBuilder.Entity<AccountBanned>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Bandate })
                    .HasName("PRIMARY");

                entity.ToTable("account_banned", "auth");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Bandate)
                    .HasColumnName("bandate")
                    .HasColumnType("int(10) unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("tinyint(3) unsigned")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Bannedby)
                    .IsRequired()
                    .HasColumnName("bannedby")
                    .HasColumnType("varchar(50)")
                    .HasMaxLength(50);

                entity.Property(e => e.Banreason)
                    .IsRequired()
                    .HasColumnName("banreason")
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255);

                entity.Property(e => e.Unbandate)
                    .HasColumnName("unbandate")
                    .HasColumnType("int(10) unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<AccountMuted>(entity =>
            {
                entity.HasKey(e => new { e.Guid, e.Mutedate })
                    .HasName("PRIMARY");

                entity.ToTable("account_muted", "auth");

                entity.Property(e => e.Guid)
                    .HasColumnName("guid")
                    .HasColumnType("int(10) unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Mutedate)
                    .HasColumnName("mutedate")
                    .HasColumnType("int(10) unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Mutedby)
                    .IsRequired()
                    .HasColumnName("mutedby")
                    .HasColumnType("varchar(50)")
                    .HasMaxLength(50);

                entity.Property(e => e.Mutereason)
                    .IsRequired()
                    .HasColumnName("mutereason")
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255);

                entity.Property(e => e.Mutetime)
                    .HasColumnName("mutetime")
                    .HasColumnType("int(10) unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<Autobroadcast>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Realmid })
                    .HasName("PRIMARY");

                entity.ToTable("autobroadcast", "auth");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("tinyint(3) unsigned");

                entity.Property(e => e.Realmid)
                    .HasColumnName("realmid")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("-1");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasColumnName("text")
                    .HasColumnType("longtext")
                    .HasMaxLength(-1);

                entity.Property(e => e.Weight)
                    .HasColumnName("weight")
                    .HasColumnType("tinyint(3) unsigned")
                    .HasDefaultValueSql("1");
            });

            modelBuilder.Entity<Ip2nationcountries>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("code");

                entity.ToTable("ip2nationcountries", "auth");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasColumnType("varchar(4)")
                    .HasMaxLength(4);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("country")
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255);

                entity.Property(e => e.IsoCode2)
                    .IsRequired()
                    .HasColumnName("iso_code_2")
                    .HasColumnType("varchar(2)")
                    .HasMaxLength(2);

                entity.Property(e => e.IsoCode3)
                    .HasColumnName("iso_code_3")
                    .HasColumnType("varchar(3)")
                    .HasMaxLength(3);

                entity.Property(e => e.IsoCountry)
                    .IsRequired()
                    .HasColumnName("iso_country")
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255);

                entity.Property(e => e.Lat)
                    .HasColumnName("lat")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Lon)
                    .HasColumnName("lon")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<IpBanned>(entity =>
            {
                entity.HasKey(e => new { e.Ip, e.Bandate })
                    .HasName("PRIMARY");

                entity.ToTable("ip_banned", "auth");

                entity.Property(e => e.Ip)
                    .HasColumnName("ip")
                    .HasColumnType("varchar(15)")
                    .HasMaxLength(15)
                    .HasDefaultValueSql("127.0.0.1");

                entity.Property(e => e.Bandate)
                    .HasColumnName("bandate")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Bannedby)
                    .IsRequired()
                    .HasColumnName("bannedby")
                    .HasColumnType("varchar(50)")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("[Console]");

                entity.Property(e => e.Banreason)
                    .IsRequired()
                    .HasColumnName("banreason")
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("no reason");

                entity.Property(e => e.Unbandate)
                    .HasColumnName("unbandate")
                    .HasColumnType("int(10) unsigned");
            });

            modelBuilder.Entity<LogsIpActions>(entity =>
            {
                entity.ToTable("logs_ip_actions", "auth");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.AccountId)
                    .HasColumnName("account_id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.CharacterGuid)
                    .HasColumnName("character_guid")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .HasMaxLength(65535);

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasColumnName("ip")
                    .HasColumnType("varchar(15)")
                    .HasMaxLength(15)
                    .HasDefaultValueSql("127.0.0.1");

                entity.Property(e => e.Systemnote)
                    .HasColumnName("systemnote")
                    .HasMaxLength(65535);

                entity.Property(e => e.Time)
                    .HasColumnName("time")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("tinyint(3) unsigned");

                entity.Property(e => e.Unixtime)
                    .HasColumnName("unixtime")
                    .HasColumnType("int(10) unsigned");
            });

            modelBuilder.Entity<RbacAccountPermissions>(entity =>
            {
                entity.HasKey(e => new { e.AccountId, e.PermissionId, e.RealmId })
                    .HasName("PRIMARY");

                entity.ToTable("rbac_account_permissions", "auth");

                entity.HasIndex(e => e.PermissionId)
                    .HasName("fk__rbac_account_roles__rbac_permissions");

                entity.Property(e => e.AccountId)
                    .HasColumnName("accountId")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.PermissionId)
                    .HasColumnName("permissionId")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.RealmId)
                    .HasColumnName("realmId")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("-1");

                entity.Property(e => e.Granted)
                    .HasColumnName("granted")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("1");

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
                entity.HasKey(e => new { e.SecId, e.PermissionId, e.RealmId })
                    .HasName("PRIMARY");

                entity.ToTable("rbac_default_permissions", "auth");

                entity.HasIndex(e => e.PermissionId)
                    .HasName("fk__rbac_default_permissions__rbac_permissions");

                entity.Property(e => e.SecId)
                    .HasColumnName("secId")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.PermissionId)
                    .HasColumnName("permissionId")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.RealmId)
                    .HasColumnName("realmId")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("-1");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.RbacDefaultPermissions)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk__rbac_default_permissions__rbac_permissions");
            });

            modelBuilder.Entity<RbacLinkedPermissions>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.LinkedId })
                    .HasName("PRIMARY");

                entity.ToTable("rbac_linked_permissions", "auth");

                entity.HasIndex(e => e.Id)
                    .HasName("fk__rbac_linked_permissions__rbac_permissions1");

                entity.HasIndex(e => e.LinkedId)
                    .HasName("fk__rbac_linked_permissions__rbac_permissions2");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.LinkedId)
                    .HasColumnName("linkedId")
                    .HasColumnType("int(10) unsigned");

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
                entity.ToTable("rbac_permissions", "auth");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(100)")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Realmcharacters>(entity =>
            {
                entity.HasKey(e => new { e.Realmid, e.Acctid })
                    .HasName("PRIMARY");

                entity.ToTable("realmcharacters", "auth");

                entity.HasIndex(e => e.Acctid)
                    .HasName("acctid");

                entity.Property(e => e.Realmid)
                    .HasColumnName("realmid")
                    .HasColumnType("int(10) unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Acctid)
                    .HasColumnName("acctid")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Numchars)
                    .HasColumnName("numchars")
                    .HasColumnType("tinyint(3) unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<Realmlist>(entity =>
            {
                entity.ToTable("realmlist", "auth");

                entity.HasIndex(e => e.Name)
                    .HasName("idx_name")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("127.0.0.1");

                entity.Property(e => e.AllowedSecurityLevel)
                    .HasColumnName("allowedSecurityLevel")
                    .HasColumnType("tinyint(3) unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Flag)
                    .HasColumnName("flag")
                    .HasColumnType("tinyint(3) unsigned")
                    .HasDefaultValueSql("2");

                entity.Property(e => e.Gamebuild)
                    .HasColumnName("gamebuild")
                    .HasColumnType("int(10) unsigned")
                    .HasDefaultValueSql("12340");

                entity.Property(e => e.Icon)
                    .HasColumnName("icon")
                    .HasColumnType("tinyint(3) unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.LocalAddress)
                    .IsRequired()
                    .HasColumnName("localAddress")
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("127.0.0.1");

                entity.Property(e => e.LocalSubnetMask)
                    .IsRequired()
                    .HasColumnName("localSubnetMask")
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("255.255.255.0");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(32)")
                    .HasMaxLength(32);

                entity.Property(e => e.Port)
                    .HasColumnName("port")
                    .HasColumnType("smallint(5) unsigned")
                    .HasDefaultValueSql("8085");

                entity.Property(e => e.Timezone)
                    .HasColumnName("timezone")
                    .HasColumnType("tinyint(3) unsigned")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<Updates>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("PRIMARY");

                entity.ToTable("updates", "auth");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(200)")
                    .HasMaxLength(200);

                entity.Property(e => e.Hash)
                    .HasColumnName("hash")
                    .HasColumnType("char(40)")
                    .HasMaxLength(40);

                entity.Property(e => e.Speed)
                    .HasColumnName("speed")
                    .HasColumnType("int(10) unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasColumnName("state")
                    .HasColumnType("enum('RELEASED','ARCHIVED')")
                    .HasMaxLength(8)
                    .HasDefaultValueSql("RELEASED");

                entity.Property(e => e.Timestamp)
                    .HasColumnName("timestamp")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<UpdatesInclude>(entity =>
            {
                entity.HasKey(e => e.Path)
                    .HasName("PRIMARY");

                entity.ToTable("updates_include", "auth");

                entity.Property(e => e.Path)
                    .HasColumnName("path")
                    .HasColumnType("varchar(200)")
                    .HasMaxLength(200);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasColumnName("state")
                    .HasColumnType("enum('RELEASED','ARCHIVED')")
                    .HasMaxLength(8)
                    .HasDefaultValueSql("RELEASED");
            });

            modelBuilder.Entity<Uptime>(entity =>
            {
                entity.HasKey(e => new { e.Realmid, e.Starttime })
                    .HasName("PRIMARY");

                entity.ToTable("uptime", "auth");

                entity.Property(e => e.Realmid)
                    .HasColumnName("realmid")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Starttime)
                    .HasColumnName("starttime")
                    .HasColumnType("int(10) unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Maxplayers)
                    .HasColumnName("maxplayers")
                    .HasColumnType("smallint(5) unsigned")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Revision)
                    .IsRequired()
                    .HasColumnName("revision")
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("Trinitycore");

                entity.Property(e => e.Uptime1)
                    .HasColumnName("uptime")
                    .HasColumnType("int(10) unsigned")
                    .HasDefaultValueSql("0");
            });
        }
    }
}