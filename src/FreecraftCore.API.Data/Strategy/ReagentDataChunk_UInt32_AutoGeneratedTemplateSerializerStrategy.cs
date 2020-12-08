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
    /// code for the Type: <see cref="ReagentDataChunk<UInt32>"/>
    /// </summary>
    public sealed partial class ReagentDataChunk_UInt32_AutoGeneratedTemplateSerializerStrategy
        : BaseAutoGeneratedSerializerStrategy<ReagentDataChunk_UInt32_AutoGeneratedTemplateSerializerStrategy, ReagentDataChunk<UInt32>>
    {
        /// <summary>
        /// Auto-generated deserialization/read method.
        /// Partial method implemented from shared partial definition.
        /// </summary>
        /// <param name="value">See external doc.</param>
        /// <param name="buffer">See external doc.</param>
        /// <param name="offset">See external doc.</param>
        public override void InternalRead(ReagentDataChunk<UInt32> value, Span<byte> buffer, ref int offset)
        {
            //Type: ReagentDataChunk Field: 1 Name: One Type: UInt32;
            value.One = GenericTypePrimitiveSerializerStrategy<UInt32>.Instance.Read(buffer, ref offset);
            //Type: ReagentDataChunk Field: 2 Name: Two Type: UInt32;
            value.Two = GenericTypePrimitiveSerializerStrategy<UInt32>.Instance.Read(buffer, ref offset);
            //Type: ReagentDataChunk Field: 3 Name: Three Type: UInt32;
            value.Three = GenericTypePrimitiveSerializerStrategy<UInt32>.Instance.Read(buffer, ref offset);
            //Type: ReagentDataChunk Field: 4 Name: Four Type: UInt32;
            value.Four = GenericTypePrimitiveSerializerStrategy<UInt32>.Instance.Read(buffer, ref offset);
            //Type: ReagentDataChunk Field: 5 Name: Five Type: UInt32;
            value.Five = GenericTypePrimitiveSerializerStrategy<UInt32>.Instance.Read(buffer, ref offset);
            //Type: ReagentDataChunk Field: 6 Name: Six Type: UInt32;
            value.Six = GenericTypePrimitiveSerializerStrategy<UInt32>.Instance.Read(buffer, ref offset);
            //Type: ReagentDataChunk Field: 7 Name: Seven Type: UInt32;
            value.Seven = GenericTypePrimitiveSerializerStrategy<UInt32>.Instance.Read(buffer, ref offset);
            //Type: ReagentDataChunk Field: 8 Name: Eight Type: UInt32;
            value.Eight = GenericTypePrimitiveSerializerStrategy<UInt32>.Instance.Read(buffer, ref offset);
        }

        /// <summary>
        /// Auto-generated serialization/write method.
        /// Partial method implemented from shared partial definition.
        /// </summary>
        /// <param name="value">See external doc.</param>
        /// <param name="buffer">See external doc.</param>
        /// <param name="offset">See external doc.</param>
        public override void InternalWrite(ReagentDataChunk<UInt32> value, Span<byte> buffer, ref int offset)
        {
            //Type: ReagentDataChunk Field: 1 Name: One Type: UInt32;
            GenericTypePrimitiveSerializerStrategy<UInt32>.Instance.Write(value.One, buffer, ref offset);
            //Type: ReagentDataChunk Field: 2 Name: Two Type: UInt32;
            GenericTypePrimitiveSerializerStrategy<UInt32>.Instance.Write(value.Two, buffer, ref offset);
            //Type: ReagentDataChunk Field: 3 Name: Three Type: UInt32;
            GenericTypePrimitiveSerializerStrategy<UInt32>.Instance.Write(value.Three, buffer, ref offset);
            //Type: ReagentDataChunk Field: 4 Name: Four Type: UInt32;
            GenericTypePrimitiveSerializerStrategy<UInt32>.Instance.Write(value.Four, buffer, ref offset);
            //Type: ReagentDataChunk Field: 5 Name: Five Type: UInt32;
            GenericTypePrimitiveSerializerStrategy<UInt32>.Instance.Write(value.Five, buffer, ref offset);
            //Type: ReagentDataChunk Field: 6 Name: Six Type: UInt32;
            GenericTypePrimitiveSerializerStrategy<UInt32>.Instance.Write(value.Six, buffer, ref offset);
            //Type: ReagentDataChunk Field: 7 Name: Seven Type: UInt32;
            GenericTypePrimitiveSerializerStrategy<UInt32>.Instance.Write(value.Seven, buffer, ref offset);
            //Type: ReagentDataChunk Field: 8 Name: Eight Type: UInt32;
            GenericTypePrimitiveSerializerStrategy<UInt32>.Instance.Write(value.Eight, buffer, ref offset);
        }
    }
}