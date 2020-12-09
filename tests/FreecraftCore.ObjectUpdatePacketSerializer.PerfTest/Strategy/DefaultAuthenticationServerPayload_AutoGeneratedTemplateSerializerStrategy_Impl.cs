using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using FreecraftCore.Serializer;
using FreecraftCore;
namespace FreecraftCore
{
    [AutoGeneratedWireMessageImplementationAttribute]
    public partial class DefaultAuthenticationServerPayload
    {
        public override Type SerializableType => typeof(DefaultAuthenticationServerPayload);
        public override AuthenticationServerPayload Read(Span<byte> buffer, ref int offset)
        {
            DefaultAuthenticationServerPayload_AutoGeneratedTemplateSerializerStrategy.Instance.InternalRead(this, buffer, ref offset);
            return this;
        }
        public override void Write(AuthenticationServerPayload value, Span<byte> buffer, ref int offset)
        {
            DefaultAuthenticationServerPayload_AutoGeneratedTemplateSerializerStrategy.Instance.InternalWrite(this, buffer, ref offset);
        }
    }
}

namespace FreecraftCore.Serializer
{
    //THIS CODE IS FOR AUTO-GENERATED SERIALIZERS! DO NOT MODIFY UNLESS YOU KNOW WELL!
    /// <summary>
    /// FreecraftCore.Serializer's AUTO-GENERATED (do not edit) serialization
    /// code for the Type: <see cref="DefaultAuthenticationServerPayload"/>
    /// </summary>
    public sealed partial class DefaultAuthenticationServerPayload_AutoGeneratedTemplateSerializerStrategy
        : BaseAutoGeneratedSerializerStrategy<DefaultAuthenticationServerPayload_AutoGeneratedTemplateSerializerStrategy, DefaultAuthenticationServerPayload>
    {
        /// <summary>
        /// Auto-generated deserialization/read method.
        /// Partial method implemented from shared partial definition.
        /// </summary>
        /// <param name="value">See external doc.</param>
        /// <param name="buffer">See external doc.</param>
        /// <param name="offset">See external doc.</param>
        public override void InternalRead(DefaultAuthenticationServerPayload value, Span<byte> buffer, ref int offset)
        {
            //Type: AuthenticationServerPayload Field: 1 Name: OperationCode Type: AuthOperationCode;
            value.OperationCode = GenericPrimitiveEnumTypeSerializerStrategy<AuthOperationCode, Byte>.Instance.Read(buffer, ref offset);
            //Type: DefaultAuthenticationServerPayload Field: 1 Name: Data Type: Byte[];
            value.Data = PrimitiveArrayTypeSerializerStrategy<Byte>.Instance.Read(buffer, ref offset);
        }

        /// <summary>
        /// Auto-generated serialization/write method.
        /// Partial method implemented from shared partial definition.
        /// </summary>
        /// <param name="value">See external doc.</param>
        /// <param name="buffer">See external doc.</param>
        /// <param name="offset">See external doc.</param>
        public override void InternalWrite(DefaultAuthenticationServerPayload value, Span<byte> buffer, ref int offset)
        {
            //Type: AuthenticationServerPayload Field: 1 Name: OperationCode Type: AuthOperationCode;
            GenericPrimitiveEnumTypeSerializerStrategy<AuthOperationCode, Byte>.Instance.Write(value.OperationCode, buffer, ref offset);
            //Type: DefaultAuthenticationServerPayload Field: 1 Name: Data Type: Byte[];
            PrimitiveArrayTypeSerializerStrategy<Byte>.Instance.Write(value.Data, buffer, ref offset);
        }
    }
}