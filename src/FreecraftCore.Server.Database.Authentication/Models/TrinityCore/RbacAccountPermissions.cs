using System;
using System.Collections.Generic;

namespace FreecraftCore
{
    public partial class RbacAccountPermissions
    {
        public uint AccountId { get; set; }
        public uint PermissionId { get; set; }
        public sbyte Granted { get; set; }
        public int RealmId { get; set; }

        public Account Account { get; set; }
        public RbacPermissions Permission { get; set; }
    }
}
