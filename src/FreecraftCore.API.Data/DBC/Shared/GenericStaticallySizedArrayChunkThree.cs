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
	public sealed class GenericStaticallySizedArrayChunkThree<T>// : IEnumerable<T>, IReadOnlyList<T> TODO: Owned types cannot have interfaces
	{
		[WireMember(1)]
		public T One { get; internal set; }

		[WireMember(2)]
		public T Two { get; internal set; }

		[WireMember(3)]
		public T Three { get; internal set; }

		public GenericStaticallySizedArrayChunkThree(T one, T two, T three)
		{
			One = one;
			Two = two;
			Three = three;
		}

		/// <summary>
		/// Serializer ctor.
		/// </summary>
		public GenericStaticallySizedArrayChunkThree()
		{
			
		}

		public IEnumerator<T> GetEnumerator()
		{
			yield return One;
			yield return Two;
			yield return Three;
		}

		public int Count => 3;

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
					default:
						throw new IndexOutOfRangeException($"Index {index} is out of range. Max range of: {Count}");
				}
			}
		}
	}
}
