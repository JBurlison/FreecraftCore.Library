using System;
using System.Collections.Generic;

namespace FreecraftCore.Server.Database.Authentication.Models
{
    public partial class RbacDefaultPermissions
    {
        public int SecId { get; set; }
        public int PermissionId { get; set; }
        public int RealmId { get; set; }

        public virtual RbacPermissions Permission { get; set; }
    }
}
