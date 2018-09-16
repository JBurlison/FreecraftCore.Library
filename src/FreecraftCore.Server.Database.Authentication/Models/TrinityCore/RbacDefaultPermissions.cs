using System;
using System.Collections.Generic;

namespace FreecraftCore
{
    public partial class RbacDefaultPermissions
    {
        public uint SecId { get; set; }
        public uint PermissionId { get; set; }
        public int RealmId { get; set; }

        public RbacPermissions Permission { get; set; }
    }
}
