using System;
using System.Collections.Generic;

namespace FreecraftCore.Server.Database.Authentication.Models
{
    public partial class Uptime
    {
        public int Realmid { get; set; }
        public int Starttime { get; set; }
        public int Uptime1 { get; set; }
        public short Maxplayers { get; set; }
        public string Revision { get; set; }
    }
}
