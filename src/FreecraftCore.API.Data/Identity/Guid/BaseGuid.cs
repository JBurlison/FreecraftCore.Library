using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FreecraftCore
{
	public abstract class BaseGuid : IEquatable<BaseGuid>
	{
		/// <summary>
		/// GUID value.
		/// </summary>
		public abstract ulong RawGuidValue { get; } //setter only for serialization

		/// <summary>
		/// Indicates the object Type that the <see cref="GUID"/> is associated with.
		/// </summary>
		public EntityGuidMask ObjectType => (EntityGuidMask)((RawGuidValue >> 48) & 0x0000FFFF);

		/// <summary>
		/// Indiciates the current GUID of the object. This is the last chunk represents the id that the world server assigned to the object. (The rest is just maskable flags about the object)
		/// </summary>
		public int CurrentObjectGuid => (int)(RawGuidValue & 0x0000000000FFFFFF);

		/// <summary>
		/// Based on ObjectGuid::GetEntry
		/// </summary>
		public int Entry => (int) (HasEntry ? (RawGuidValue >> 24) & 0x0000000000FFFFFF : 0);

		/// <summary>
		/// Base on ObjectGuid::HasEntry
		/// </summary>
		public bool HasEntry => EntityGuidMaskHasEntry(ObjectType);

		/// <summary>
		/// Indiciates if the GUID is an empty or unitialized GUID.
		/// </summary>
		/// <returns></returns>
		public bool isEmpty()
		{
			return RawGuidValue == 0;
		}

		/// <summary>
		/// Indicates if the <see cref="BaseGuid"/> is associated with an Object Type <paramref name="guidType"/>.
		/// </summary>
		/// <param name="guidType">Type of GUID.</param>
		/// <returns>True if <see cref="ObjectType"/> is the same as <paramref name="guidType"/>.</returns>
		public bool isType(EntityGuidMask guidType)
		{
			return guidType == ObjectType;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool isType(EntityTypeId typeId)
		{
			return TypeId == typeId;
		}

		private static bool EntityGuidMaskHasEntry(EntityGuidMask guidMask)
		{
			if (!Enum.IsDefined(typeof(EntityGuidMask), guidMask)) throw new InvalidEnumArgumentException(nameof(guidMask), (int) guidMask, typeof(EntityGuidMask));

			switch(guidMask)
			{
				case EntityGuidMask.Item:
				case EntityGuidMask.Player:
				case EntityGuidMask.DynamicObject:
				case EntityGuidMask.Corpse:
				case EntityGuidMask.Mo_Transport:
				case EntityGuidMask.Instance:
				case EntityGuidMask.Group:
					return false;
				case EntityGuidMask.GameObject:
				case EntityGuidMask.Transport:
				case EntityGuidMask.Unit:
				case EntityGuidMask.Pet:
				case EntityGuidMask.Vehicle:
				default:
					return true;
			}
		}

		/// <summary>
		/// Based on TrinityCore: ObjectGuid::GetTypeId
		/// </summary>
		public EntityTypeId TypeId
		{
			get
			{
				switch (ObjectType)
				{
					case EntityGuidMask.Item:
						return EntityTypeId.TYPEID_ITEM;
					//case HighGuid::Container:    return TYPEID_CONTAINER; HighGuid::Container == HighGuid::Item currently
					case EntityGuidMask.Unit:
						return EntityTypeId.TYPEID_UNIT;
					case EntityGuidMask.Pet:
						return EntityTypeId.TYPEID_UNIT;
					case EntityGuidMask.Player:
						return EntityTypeId.TYPEID_PLAYER;
					case EntityGuidMask.GameObject:
						return EntityTypeId.TYPEID_GAMEOBJECT;
					case EntityGuidMask.DynamicObject:
						return EntityTypeId.TYPEID_DYNAMICOBJECT;
					case EntityGuidMask.Corpse:
						return EntityTypeId.TYPEID_CORPSE;
					case EntityGuidMask.Mo_Transport:
						return EntityTypeId.TYPEID_GAMEOBJECT;
					case EntityGuidMask.Vehicle:
						return EntityTypeId.TYPEID_UNIT;
					// unknown
					case EntityGuidMask.Instance:
					case EntityGuidMask.Group:
					default:
						return EntityTypeId.TYPEID_OBJECT;
				}
			}
		}

		//TODO: Doc
		public bool HasType(EntityGuidMask guidType)
		{
			return (guidType & ObjectType) == guidType;
		}

		//TODO: Doc
		public bool HasAnyType(EntityGuidMask guidType)
		{
			return (guidType & ObjectType) != 0;
		}

		public bool Equals(BaseGuid other)
		{
			if (other == null)
				return false;
			else
				return other.RawGuidValue == this.RawGuidValue;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((BaseGuid) obj);
		}

		public override int GetHashCode()
		{
			throw new NotImplementedException();
		}
	}
}
