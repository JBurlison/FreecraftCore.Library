using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using FreecraftCore.Serializer;
using Microsoft.EntityFrameworkCore;

namespace FreecraftCore
{
	//Exists because EF Core doesn't support arrays.
	[Owned]
	[WireDataContract]
	public sealed class GenericStaticallySizedArrayChunkFour<T>// : IEnumerable<T>, IReadOnlyList<T> TODO: Owned types cannot have interfaces
	{
		[WireMember(1)]
		public T One { get; private set; }

		[WireMember(2)]
		public T Two { get; private set; }

		[WireMember(3)]
		public T Three { get; private set; }

		[WireMember(4)]
		public T Four { get; private set; }

		public GenericStaticallySizedArrayChunkFour(T one, T two, T three, T four)
		{
			One = one;
			Two = two;
			Three = three;
			Four = four;
		}

		/// <summary>
		/// Serializer ctor.
		/// </summary>
		public GenericStaticallySizedArrayChunkFour()
		{
			
		}

		public IEnumerator<T> GetEnumerator()
		{
			yield return One;
			yield return Two;
			yield return Three;
			yield return Four;
		}

		public int Count => 4;

		public T this[int index]
		{
			get
			{
				switch (index)
				{
					case 1:
						return One;
					case 2:
						return Two;
					case 3:
						return Three;
					case 4:
						return Four;
					default:
						throw new IndexOutOfRangeException($"Index {index} is out of range. Max range of: {Count}");
				}
			}
		}
	}
}
