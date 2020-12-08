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
    /// code for the Type: <see cref="GenericStaticallySizedArrayChunkFive<Int32>"/>
    /// </summary>
    public sealed partial class GenericStaticallySizedArrayChunkFive_Int32_AutoGeneratedTemplateSerializerStrategy
        : BaseAutoGeneratedSerializerStrategy<GenericStaticallySizedArrayChunkFive_Int32_AutoGeneratedTemplateSerializerStrategy, GenericStaticallySizedArrayChunkFive<Int32>>
    {
        /// <summary>
        /// Auto-generated deserialization/read method.
        /// Partial method implemented from shared partial definition.
        /// </summary>
        /// <param name="value">See external doc.</param>
        /// <param name="buffer">See external doc.</param>
        /// <param name="offset">See external doc.</param>
        public override void InternalRead(GenericStaticallySizedArrayChunkFive<Int32> value, Span<byte> buffer, ref int offset)
        {
            //Type: GenericStaticallySizedArrayChunkFive Field: 1 Name: One Type: Int32;
            value.One = GenericTypePrimitiveSerializerStrategy<Int32>.Instance.Read(buffer, ref offset);
            //Type: GenericStaticallySizedArrayChunkFive Field: 2 Name: Two Type: Int32;
            value.Two = GenericTypePrimitiveSerializerStrategy<Int32>.Instance.Read(buffer, ref offset);
            //Type: GenericStaticallySizedArrayChunkFive Field: 3 Name: Three Type: Int32;
            value.Three = GenericTypePrimitiveSerializerStrategy<Int32>.Instance.Read(buffer, ref offset);
            //Type: GenericStaticallySizedArrayChunkFive Field: 4 Name: Four Type: Int32;
            value.Four = GenericTypePrimitiveSerializerStrategy<Int32>.Instance.Read(buffer, ref offset);
            //Type: GenericStaticallySizedArrayChunkFive Field: 5 Name: Five Type: Int32;
            value.Five = GenericTypePrimitiveSerializerStrategy<Int32>.Instance.Read(buffer, ref offset);
        }

        /// <summary>
        /// Auto-generated serialization/write method.
        /// Partial method implemented from shared partial definition.
        /// </summary>
        /// <param name="value">See external doc.</param>
        /// <param name="buffer">See external doc.</param>
        /// <param name="offset">See external doc.</param>
        public override void InternalWrite(GenericStaticallySizedArrayChunkFive<Int32> value, Span<byte> buffer, ref int offset)
        {
            //Type: GenericStaticallySizedArrayChunkFive Field: 1 Name: One Type: Int32;
            GenericTypePrimitiveSerializerStrategy<Int32>.Instance.Write(value.One, buffer, ref offset);
            //Type: GenericStaticallySizedArrayChunkFive Field: 2 Name: Two Type: Int32;
            GenericTypePrimitiveSerializerStrategy<Int32>.Instance.Write(value.Two, buffer, ref offset);
            //Type: GenericStaticallySizedArrayChunkFive Field: 3 Name: Three Type: Int32;
            GenericTypePrimitiveSerializerStrategy<Int32>.Instance.Write(value.Three, buffer, ref offset);
            //Type: GenericStaticallySizedArrayChunkFive Field: 4 Name: Four Type: Int32;
            GenericTypePrimitiveSerializerStrategy<Int32>.Instance.Write(value.Four, buffer, ref offset);
            //Type: GenericStaticallySizedArrayChunkFive Field: 5 Name: Five Type: Int32;
            GenericTypePrimitiveSerializerStrategy<Int32>.Instance.Write(value.Five, buffer, ref offset);
        }
    }
}