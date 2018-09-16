using System;
using System.Collections.Generic;

namespace FreecraftCore
{
    public partial class RbacPermissions
    {
        public RbacPermissions()
        {
            RbacAccountPermissions = new HashSet<RbacAccountPermissions>();
            RbacDefaultPermissions = new HashSet<RbacDefaultPermissions>();
            RbacLinkedPermissionsIdNavigation = new HashSet<RbacLinkedPermissions>();
            RbacLinkedPermissionsLinked = new HashSet<RbacLinkedPermissions>();
        }

        public uint Id { get; set; }
        public string Name { get; set; }

        public ICollection<RbacAccountPermissions> RbacAccountPermissions { get; set; }
        public ICollection<RbacDefaultPermissions> RbacDefaultPermissions { get; set; }
        public ICollection<RbacLinkedPermissions> RbacLinkedPermissionsIdNavigation { get; set; }
        public ICollection<RbacLinkedPermissions> RbacLinkedPermissionsLinked { get; set; }
    }
}
