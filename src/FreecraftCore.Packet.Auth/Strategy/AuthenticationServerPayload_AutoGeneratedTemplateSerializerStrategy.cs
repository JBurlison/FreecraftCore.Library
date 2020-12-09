using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using FreecraftCore.Serializer;
using FreecraftCore;
namespace FreecraftCore
{
    [AutoGeneratedWireMessageImplementationAttribute]
    public partial class AuthenticationServerPayload : IWireMessage<AuthenticationServerPayload>
    {
        public virtual Type SerializableType => typeof(AuthenticationServerPayload);
        public virtual AuthenticationServerPayload Read(Span<byte> buffer, ref int offset)
        {
            AuthenticationServerPayload_AutoGeneratedTemplateSerializerStrategy.Instance.InternalRead(this, buffer, ref offset);
            return this;
        }
        public virtual void Write(AuthenticationServerPayload value, Span<byte> buffer, ref int offset)
        {
            AuthenticationServerPayload_AutoGeneratedTemplateSerializerStrategy.Instance.InternalWrite(this, buffer, ref offset);
        }
    }
}

namespace FreecraftCore.Serializer
{
    //THIS CODE IS FOR AUTO-GENERATED SERIALIZERS! DO NOT MODIFY UNLESS YOU KNOW WELL!
    /// <summary>
    /// FreecraftCore.Serializer's AUTO-GENERATED (do not edit) serialization
    /// code for the Type: <see cref="AuthenticationServerPayload"/>
    /// </summary>
    public sealed partial class AuthenticationServerPayload_AutoGeneratedTemplateSerializerStrategy
        : BasePolymorphicAutoGeneratedSerializerStrategy<AuthenticationServerPayload_AutoGeneratedTemplateSerializerStrategy, AuthenticationServerPayload, Byte>
    {
        protected override AuthenticationServerPayload CreateType(int key)
        {
            switch (key)
            {
                case (int)FreecraftCore.AuthOperationCode.AUTH_LOGON_CHALLENGE:
                    return new AuthLogonChallengeResponse();
                case (int)FreecraftCore.AuthOperationCode.AUTH_LOGON_PROOF:
                    return new AuthLogonProofResponse();
                case (int)FreecraftCore.AuthOperationCode.REALM_LIST:
                    return new AuthRealmListResponse();
                default:
                    return new DefaultAuthenticationServerPayload();
            }
        }
    }
}