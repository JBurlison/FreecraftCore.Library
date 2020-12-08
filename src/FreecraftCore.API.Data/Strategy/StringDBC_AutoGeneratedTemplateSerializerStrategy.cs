using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using FreecraftCore.Serializer;
using FreecraftCore;
namespace FreecraftCore
{
    [AutoGeneratedWireMessageImplementationAttribute]
    public partial class StringDBC : IWireMessage<StringDBC>
    {
        public Type SerializableType => typeof(StringDBC);
        public StringDBC Read(Span<byte> buffer, ref int offset)
        {
            StringDBC_AutoGeneratedTemplateSerializerStrategy.Instance.InternalRead(this, buffer, ref offset);
            return this;
        }
        public void Write(StringDBC value, Span<byte> buffer, ref int offset)
        {
            StringDBC_AutoGeneratedTemplateSerializerStrategy.Instance.InternalWrite(this, buffer, ref offset);
        }
    }
}

namespace FreecraftCore.Serializer
{
    //THIS CODE IS FOR AUTO-GENERATED SERIALIZERS! DO NOT MODIFY UNLESS YOU KNOW WELL!
    /// <summary>
    /// FreecraftCore.Serializer's AUTO-GENERATED (do not edit) serialization
    /// code for the Type: <see cref="StringDBC"/>
    /// </summary>
    public sealed partial class StringDBC_AutoGeneratedTemplateSerializerStrategy
        : BaseAutoGeneratedSerializerStrategy<StringDBC_AutoGeneratedTemplateSerializerStrategy, StringDBC>
    {
        /// <summary>
        /// Auto-generated deserialization/read method.
        /// Partial method implemented from shared partial definition.
        /// </summary>
        /// <param name="value">See external doc.</param>
        /// <param name="buffer">See external doc.</param>
        /// <param name="offset">See external doc.</param>
        public override void InternalRead(StringDBC value, Span<byte> buffer, ref int offset)
        {
            //Type: StringDBC Field: 1 Name: StringValue Type: String;
            value.StringValue = TerminatedStringTypeSerializerStrategy<UTF8StringTypeSerializerStrategy, UTF8StringTerminatorTypeSerializerStrategy>.Instance.Read(buffer, ref offset);
        }

        /// <summary>
        /// Auto-generated serialization/write method.
        /// Partial method implemented from shared partial definition.
        /// </summary>
        /// <param name="value">See external doc.</param>
        /// <param name="buffer">See external doc.</param>
        /// <param name="offset">See external doc.</param>
        public override void InternalWrite(StringDBC value, Span<byte> buffer, ref int offset)
        {
            //Type: StringDBC Field: 1 Name: StringValue Type: String;
            TerminatedStringTypeSerializerStrategy<UTF8StringTypeSerializerStrategy, UTF8StringTerminatorTypeSerializerStrategy>.Instance.Write(value.StringValue, buffer, ref offset);
        }
    }
}