using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Autofac;
using FreecraftCore.Packet.Auth;
using GladNet;
using Module = Autofac.Module;

namespace FreecraftCore
{
	//TODO: Make a generic generalized version
	public sealed class AuthenticationHandlerRegisterationModule : Module
	{
		/// <inheritdoc />
		protected override void Load(ContainerBuilder builder)
		{
			IEnumerable<Type> handlerTypes = LoadHandlerTypes();

			//Registers each type.
			foreach(Type t in handlerTypes)
				builder.RegisterType(t)
					.AsSelf()
					.SingleInstance();

			foreach(Type t in handlerTypes)
			{
				Type concretePayloadType = t.GetTypeInfo()
					.ImplementedInterfaces
					.First(i => i.GetTypeInfo().IsGenericType && i.GetTypeInfo().GetGenericTypeDefinition() == typeof(IPeerPayloadSpecificMessageHandler<,>))
					.GetGenericArguments()
					.First();

				Type tryHandlerType = typeof(TrySemanticsBasedOnTypePeerMessageHandler<,,>)
					.MakeGenericType(typeof(AuthenticationClientPayload), typeof(AuthenticationServerPayload), concretePayloadType);

				builder.Register(context =>
					{
						object handler = context.Resolve(t);

						return Activator.CreateInstance(tryHandlerType, handler);
					})
					.As(typeof(IPeerMessageHandler<AuthenticationClientPayload, AuthenticationServerPayload>))
					.SingleInstance();
			}
		}

		private IEnumerable<Type> LoadHandlerTypes()
		{
			return GetType().GetTypeInfo()
				.Assembly
				.GetTypes()
				.Where(t => t.GetInterfaces().Any(i => i.GetTypeInfo().IsGenericType && i.GetGenericTypeDefinition() == typeof(IPeerPayloadSpecificMessageHandler<,>)));
		}
	}
}
