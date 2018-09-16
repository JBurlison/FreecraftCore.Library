using System;
using System.Collections.Generic;

namespace FreecraftCore
{
    public partial class RbacLinkedPermissions
    {
        public uint Id { get; set; }
        public uint LinkedId { get; set; }

        public RbacPermissions IdNavigation { get; set; }
        public RbacPermissions Linked { get; set; }
    }
}
