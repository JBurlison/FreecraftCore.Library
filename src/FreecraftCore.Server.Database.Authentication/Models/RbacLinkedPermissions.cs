using System;
using System.Collections.Generic;

namespace FreecraftCore.Server.Database.Authentication.Models
{
    public partial class RbacLinkedPermissions
    {
        public int Id { get; set; }
        public int LinkedId { get; set; }

        public virtual RbacPermissions IdNavigation { get; set; }
        public virtual RbacPermissions Linked { get; set; }
    }
}
