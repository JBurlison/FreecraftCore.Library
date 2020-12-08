using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using FreecraftCore.Serializer;
using FreecraftCore;

namespace FreecraftCore.Serializer
{
    //THIS CODE IS FOR AUTO-GENERATED SERIALIZERS! DO NOT MODIFY UNLESS YOU KNOW WELL!
    /// <summary>
    /// FreecraftCore.Serializer's AUTO-GENERATED (do not edit) serialization
    /// code for the Type: <see cref="NPCSoundsEntry"/>
    /// </summary>
    public sealed partial class NPCSoundsEntry_AutoGeneratedTemplateSerializerStrategy
        : BaseAutoGeneratedSerializerStrategy<NPCSoundsEntry_AutoGeneratedTemplateSerializerStrategy, NPCSoundsEntry>
    {
        /// <summary>
        /// Auto-generated deserialization/read method.
        /// Partial method implemented from shared partial definition.
        /// </summary>
        /// <param name="value">See external doc.</param>
        /// <param name="buffer">See external doc.</param>
        /// <param name="offset">See external doc.</param>
        public override void InternalRead(NPCSoundsEntry value, Span<byte> buffer, ref int offset)
        {
            //Type: NPCSoundsEntry Field: 1 Name: NpcSoundId Type: Int32;
            value.NpcSoundId = GenericTypePrimitiveSerializerStrategy<Int32>.Instance.Read(buffer, ref offset);
            //Type: NPCSoundsEntry Field: 2 Name: GreetingsSoundId Type: Int32;
            value.GreetingsSoundId = GenericTypePrimitiveSerializerStrategy<Int32>.Instance.Read(buffer, ref offset);
            //Type: NPCSoundsEntry Field: 3 Name: GoodbyeSoundId Type: Int32;
            value.GoodbyeSoundId = GenericTypePrimitiveSerializerStrategy<Int32>.Instance.Read(buffer, ref offset);
            //Type: NPCSoundsEntry Field: 4 Name: AnnoyedSoundId Type: Int32;
            value.AnnoyedSoundId = GenericTypePrimitiveSerializerStrategy<Int32>.Instance.Read(buffer, ref offset);
            //Type: NPCSoundsEntry Field: 5 Name: UnknownSoundId Type: Int32;
            value.UnknownSoundId = GenericTypePrimitiveSerializerStrategy<Int32>.Instance.Read(buffer, ref offset);
        }

        /// <summary>
        /// Auto-generated serialization/write method.
        /// Partial method implemented from shared partial definition.
        /// </summary>
        /// <param name="value">See external doc.</param>
        /// <param name="buffer">See external doc.</param>
        /// <param name="offset">See external doc.</param>
        public override void InternalWrite(NPCSoundsEntry value, Span<byte> buffer, ref int offset)
        {
            //Type: NPCSoundsEntry Field: 1 Name: NpcSoundId Type: Int32;
            GenericTypePrimitiveSerializerStrategy<Int32>.Instance.Write(value.NpcSoundId, buffer, ref offset);
            //Type: NPCSoundsEntry Field: 2 Name: GreetingsSoundId Type: Int32;
            GenericTypePrimitiveSerializerStrategy<Int32>.Instance.Write(value.GreetingsSoundId, buffer, ref offset);
            //Type: NPCSoundsEntry Field: 3 Name: GoodbyeSoundId Type: Int32;
            GenericTypePrimitiveSerializerStrategy<Int32>.Instance.Write(value.GoodbyeSoundId, buffer, ref offset);
            //Type: NPCSoundsEntry Field: 4 Name: AnnoyedSoundId Type: Int32;
            GenericTypePrimitiveSerializerStrategy<Int32>.Instance.Write(value.AnnoyedSoundId, buffer, ref offset);
            //Type: NPCSoundsEntry Field: 5 Name: UnknownSoundId Type: Int32;
            GenericTypePrimitiveSerializerStrategy<Int32>.Instance.Write(value.UnknownSoundId, buffer, ref offset);
        }
    }
}