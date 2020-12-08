using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using FreecraftCore.Serializer;
using FreecraftCore;
namespace FreecraftCore
{
    [AutoGeneratedWireMessageImplementationAttribute]
    public partial class ObjectUpdateValuesObjectBlock
    {
        public override Type SerializableType => typeof(ObjectUpdateValuesObjectBlock);
        public override ObjectUpdateBlock Read(Span<byte> buffer, ref int offset)
        {
            ObjectUpdateValuesObjectBlock_AutoGeneratedTemplateSerializerStrategy.Instance.InternalRead(this, buffer, ref offset);
            return this;
        }
        public override void Write(ObjectUpdateBlock value, Span<byte> buffer, ref int offset)
        {
            ObjectUpdateValuesObjectBlock_AutoGeneratedTemplateSerializerStrategy.Instance.InternalWrite(this, buffer, ref offset);
        }
    }
}

namespace FreecraftCore.Serializer
{
    //THIS CODE IS FOR AUTO-GENERATED SERIALIZERS! DO NOT MODIFY UNLESS YOU KNOW WELL!
    /// <summary>
    /// FreecraftCore.Serializer's AUTO-GENERATED (do not edit) serialization
    /// code for the Type: <see cref="ObjectUpdateValuesObjectBlock"/>
    /// </summary>
    public sealed partial class ObjectUpdateValuesObjectBlock_AutoGeneratedTemplateSerializerStrategy
        : BaseAutoGeneratedSerializerStrategy<ObjectUpdateValuesObjectBlock_AutoGeneratedTemplateSerializerStrategy, ObjectUpdateValuesObjectBlock>
    {
        /// <summary>
        /// Auto-generated deserialization/read method.
        /// Partial method implemented from shared partial definition.
        /// </summary>
        /// <param name="value">See external doc.</param>
        /// <param name="buffer">See external doc.</param>
        /// <param name="offset">See external doc.</param>
        public override void InternalRead(ObjectUpdateValuesObjectBlock value, Span<byte> buffer, ref int offset)
        {
            //Type: ObjectUpdateBlock Field: 1 Name: UpdateType Type: ObjectUpdateType;
            value.UpdateType = GenericPrimitiveEnumTypeSerializerStrategy<ObjectUpdateType, Byte>.Instance.Read(buffer, ref offset);
            //Type: ObjectUpdateValuesObjectBlock Field: 1 Name: ObjectToUpdate Type: PackedGuid;
            value.ObjectToUpdate = CustomPackedGuidTypeSerializer.Instance.Read(buffer, ref offset);
            //Type: ObjectUpdateValuesObjectBlock Field: 2 Name: UpdateValuesCollection Type: UpdateFieldValueCollection;
            value.UpdateValuesCollection = CustomUpdateFieldCollectionTypeSerializer.Instance.Read(buffer, ref offset);
        }

        /// <summary>
        /// Auto-generated serialization/write method.
        /// Partial method implemented from shared partial definition.
        /// </summary>
        /// <param name="value">See external doc.</param>
        /// <param name="buffer">See external doc.</param>
        /// <param name="offset">See external doc.</param>
        public override void InternalWrite(ObjectUpdateValuesObjectBlock value, Span<byte> buffer, ref int offset)
        {
            //Type: ObjectUpdateBlock Field: 1 Name: UpdateType Type: ObjectUpdateType;
            GenericPrimitiveEnumTypeSerializerStrategy<ObjectUpdateType, Byte>.Instance.Write(value.UpdateType, buffer, ref offset);
            //Type: ObjectUpdateValuesObjectBlock Field: 1 Name: ObjectToUpdate Type: PackedGuid;
            CustomPackedGuidTypeSerializer.Instance.Write(value.ObjectToUpdate, buffer, ref offset);
            //Type: ObjectUpdateValuesObjectBlock Field: 2 Name: UpdateValuesCollection Type: UpdateFieldValueCollection;
            CustomUpdateFieldCollectionTypeSerializer.Instance.Write(value.UpdateValuesCollection, buffer, ref offset);
        }
    }
}