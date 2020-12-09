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
    /// code for the Type: <see cref="SpellRadiusEntry"/>
    /// </summary>
    public sealed partial class SpellRadiusEntry_AutoGeneratedTemplateSerializerStrategy
        : BaseAutoGeneratedSerializerStrategy<SpellRadiusEntry_AutoGeneratedTemplateSerializerStrategy, SpellRadiusEntry>
    {
        /// <summary>
        /// Auto-generated deserialization/read method.
        /// Partial method implemented from shared partial definition.
        /// </summary>
        /// <param name="value">See external doc.</param>
        /// <param name="buffer">See external doc.</param>
        /// <param name="offset">See external doc.</param>
        public override void InternalRead(SpellRadiusEntry value, Span<byte> buffer, ref int offset)
        {
            //Type: SpellRadiusEntry Field: 1 Name: SpellRadiusId Type: Int32;
            value.SpellRadiusId = GenericTypePrimitiveSerializerStrategy<Int32>.Instance.Read(buffer, ref offset);
            //Type: SpellRadiusEntry Field: 2 Name: Radius Type: Single;
            value.Radius = GenericTypePrimitiveSerializerStrategy<Single>.Instance.Read(buffer, ref offset);
            //Type: SpellRadiusEntry Field: 3 Name: Zero Type: Int32;
            value.Zero = GenericTypePrimitiveSerializerStrategy<Int32>.Instance.Read(buffer, ref offset);
            //Type: SpellRadiusEntry Field: 4 Name: Radius2 Type: Single;
            value.Radius2 = GenericTypePrimitiveSerializerStrategy<Single>.Instance.Read(buffer, ref offset);
        }

        /// <summary>
        /// Auto-generated serialization/write method.
        /// Partial method implemented from shared partial definition.
        /// </summary>
        /// <param name="value">See external doc.</param>
        /// <param name="buffer">See external doc.</param>
        /// <param name="offset">See external doc.</param>
        public override void InternalWrite(SpellRadiusEntry value, Span<byte> buffer, ref int offset)
        {
            //Type: SpellRadiusEntry Field: 1 Name: SpellRadiusId Type: Int32;
            GenericTypePrimitiveSerializerStrategy<Int32>.Instance.Write(value.SpellRadiusId, buffer, ref offset);
            //Type: SpellRadiusEntry Field: 2 Name: Radius Type: Single;
            GenericTypePrimitiveSerializerStrategy<Single>.Instance.Write(value.Radius, buffer, ref offset);
            //Type: SpellRadiusEntry Field: 3 Name: Zero Type: Int32;
            GenericTypePrimitiveSerializerStrategy<Int32>.Instance.Write(value.Zero, buffer, ref offset);
            //Type: SpellRadiusEntry Field: 4 Name: Radius2 Type: Single;
            GenericTypePrimitiveSerializerStrategy<Single>.Instance.Write(value.Radius2, buffer, ref offset);
        }
    }
}