using System;
using System.Collections.Generic;

namespace FreecraftCore.Server.Database.Authentication.Models
{
    public partial class IpBanned
    {
        public string Ip { get; set; }
        public int Bandate { get; set; }
        public int Unbandate { get; set; }
        public string Bannedby { get; set; }
        public string Banreason { get; set; }
    }
}
