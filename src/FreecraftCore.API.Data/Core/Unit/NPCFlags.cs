using System;
using System.Collections.Generic;
using System.Text;

namespace FreecraftCore
{
    [Flags]
    public enum NPCFlags : uint
    {
        NONE = 0x00000000,

        /// <summary>
        /// TITLE has gossip menu DESCRIPTION 100%
        /// </summary>
        GOSSIP = 0x00000001,

        /// <summary>
        /// TITLE is quest giver DESCRIPTION guessed, probably ok
        /// </summary>
        QUESTGIVER = 0x00000002,

        UNK1 = 0x00000004,

        UNK2 = 0x00000008,

        /// <summary>
        /// TITLE is trainer DESCRIPTION 100%
        /// </summary>
        TRAINER = 0x00000010,

        /// <summary>
        /// TITLE is class trainer DESCRIPTION 100%
        /// </summary>
        TRAINER_CLASS = 0x00000020,

        /// <summary>
        /// TITLE is profession trainer DESCRIPTION 100%
        /// </summary>
        TRAINER_PROFESSION = 0x00000040,

        /// <summary>
        /// TITLE is vendor (generic) DESCRIPTION 100%
        /// </summary>
        VENDOR = 0x00000080,

        /// <summary>
        /// TITLE is vendor (ammo) DESCRIPTION 100%, general goods vendor
        /// </summary>
        VENDOR_AMMO = 0x00000100,

        /// <summary>
        /// TITLE is vendor (food) DESCRIPTION 100%
        /// </summary>
        VENDOR_FOOD = 0x00000200,

        /// <summary>
        /// TITLE is vendor (poison) DESCRIPTION guessed
        /// </summary>
        VENDOR_POISON = 0x00000400,

        /// <summary>
        /// TITLE is vendor (reagents) DESCRIPTION 100%
        /// </summary>
        VENDOR_REAGENT = 0x00000800,

        /// <summary>
        /// TITLE can repair DESCRIPTION 100%
        /// </summary>
        REPAIR = 0x00001000,

        /// <summary>
        /// TITLE is flight master DESCRIPTION 100%
        /// </summary>
        FLIGHTMASTER = 0x00002000,

        /// <summary>
        /// TITLE is spirit healer DESCRIPTION guessed
        /// </summary>
        SPIRITHEALER = 0x00004000,

        /// <summary>
        /// TITLE is spirit guide DESCRIPTION guessed
        /// </summary>
        SPIRITGUIDE = 0x00008000,

        /// <summary>
        /// TITLE is innkeeper
        /// </summary>
        INNKEEPER = 0x00010000,

        /// <summary>
        /// TITLE is banker DESCRIPTION 100%
        /// </summary>
        BANKER = 0x00020000,

        /// <summary>
        /// TITLE handles guild/arena petitions DESCRIPTION 100% 0xC0000 = guild petitions, 0x40000 = arena team petitions
        /// </summary>
        PETITIONER = 0x00040000,

        /// <summary>
        /// TITLE is guild tabard designer DESCRIPTION 100%
        /// </summary>
        TABARDDESIGNER = 0x00080000,

        /// <summary>
        /// TITLE is battlemaster DESCRIPTION 100%
        /// </summary>
        BATTLEMASTER = 0x00100000,

        /// <summary>
        /// TITLE is battlemaster DESCRIPTION 100%
        /// </summary>
        AUCTIONEER = 0x00200000,

        /// <summary>
        /// TITLE is stable master DESCRIPTION 100%
        /// </summary>
        STABLEMASTER = 0x00400000,

        /// <summary>
        /// TITLE is guild banker DESCRIPTION cause client to send 997 opcode
        /// </summary>
        GUILD_BANKER = 0x00800000,

        /// <summary>
        /// TITLE has spell click enabled DESCRIPTION cause client to send 1015 opcode (spell click)
        /// </summary>
        SPELLCLICK = 0x01000000,

        /// <summary>
        /// TITLE is player vehicle DESCRIPTION players with mounts that have vehicle data should have it set
        /// </summary>
        PLAYER_VEHICLE = 0x02000000,

        /// <summary>
        /// TITLE is mailbox
        /// </summary>
        MAILBOX = 0x04000000
    };
}
