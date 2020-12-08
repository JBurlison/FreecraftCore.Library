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
    /// code for the Type: <see cref="SpellTotemDataChunk<UInt32>"/>
    /// </summary>
    public sealed partial class SpellTotemDataChunk_UInt32_AutoGeneratedTemplateSerializerStrategy
        : BaseAutoGeneratedSerializerStrategy<SpellTotemDataChunk_UInt32_AutoGeneratedTemplateSerializerStrategy, SpellTotemDataChunk<UInt32>>
    {
        /// <summary>
        /// Auto-generated deserialization/read method.
        /// Partial method implemented from shared partial definition.
        /// </summary>
        /// <param name="value">See external doc.</param>
        /// <param name="buffer">See external doc.</param>
        /// <param name="offset">See external doc.</param>
        public override void InternalRead(SpellTotemDataChunk<UInt32> value, Span<byte> buffer, ref int offset)
        {
            //Type: SpellTotemDataChunk Field: 1 Name: One Type: UInt32;
            value.One = GenericTypePrimitiveSerializerStrategy<UInt32>.Instance.Read(buffer, ref offset);
            //Type: SpellTotemDataChunk Field: 2 Name: Two Type: UInt32;
            value.Two = GenericTypePrimitiveSerializerStrategy<UInt32>.Instance.Read(buffer, ref offset);
        }

        /// <summary>
        /// Auto-generated serialization/write method.
        /// Partial method implemented from shared partial definition.
        /// </summary>
        /// <param name="value">See external doc.</param>
        /// <param name="buffer">See external doc.</param>
        /// <param name="offset">See external doc.</param>
        public override void InternalWrite(SpellTotemDataChunk<UInt32> value, Span<byte> buffer, ref int offset)
        {
            //Type: SpellTotemDataChunk Field: 1 Name: One Type: UInt32;
            GenericTypePrimitiveSerializerStrategy<UInt32>.Instance.Write(value.One, buffer, ref offset);
            //Type: SpellTotemDataChunk Field: 2 Name: Two Type: UInt32;
            GenericTypePrimitiveSerializerStrategy<UInt32>.Instance.Write(value.Two, buffer, ref offset);
        }
    }
}