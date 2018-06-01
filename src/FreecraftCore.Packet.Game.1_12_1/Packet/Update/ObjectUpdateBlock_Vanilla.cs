using System;
using FreecraftCore.Serializer;

namespace FreecraftCore
{
	/// <summary>
	/// This is the base type for an update block.
	/// Exists mostly for the use of polymorphic deserialization.
	/// WoW sends blocks of data in the update packets.
	/// </summary>
	[WireDataContractBaseType((int)ObjectUpdateType.UPDATETYPE_CREATE_OBJECT2, typeof(ObjectUpdateCreateObject2Block_Vanilla))]
	[WireDataContractBaseType((int)ObjectUpdateType.UPDATETYPE_MOVEMENT, typeof(ObjectUpdateMovementBlock_Vanilla))]
	[WireDataContractBaseType((int)ObjectUpdateType.UPDATETYPE_CREATE_OBJECT, typeof(ObjectUpdateCreateObject1Block_Vanilla))]
	[WireDataContractBaseType((int)ObjectUpdateType.UPDATETYPE_VALUES, typeof(ObjectUpdateValuesObjectBlock_Vanilla))]
	//Mangos does not ever even send the NEAR_OBJECTS
	//[WireDataContractBaseType((int)ObjectUpdateType.UPDATETYPE_NEAR_OBJECTS, typeof(ObjectUpdateNearObjectsBlock))]
	[WireDataContractBaseType((int)ObjectUpdateType.UPDATETYPE_OUT_OF_RANGE_OBJECTS, typeof(ObjectUpdateDestroyObjectBlock_Vanilla))]
	[WireDataContract(WireDataContractAttribute.KeyType.Byte, InformationHandlingFlags.DontConsumeRead)]
	public abstract class ObjectUpdateBlock_Vanilla : IUpdateBlockChunk
	{
		//This field is set by the serializer.
		/// <summary>
		/// The update type of the block.
		/// </summary>
		[DontWrite] //we don't want to write because we want the serializer to use the type information instead.
		[WireMember(1)]
		public ObjectUpdateType UpdateType { get; }

		//While most update types do have a GUID as the next fields some
		//do not therefore we must only read them in child types

		/// <summary>
		/// Serializer ctor.
		/// </summary>
		protected ObjectUpdateBlock_Vanilla()
		{
			Console.WriteLine($"Creating Empty: {GetType().Name}");
		}
	}
}