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
	public sealed class GenericStaticallySizedArrayChunkSeven<T>// : IEnumerable<T>, IReadOnlyList<T> TODO: Owned types cannot have interfaces
	{
		[WireMember(1)]
		public T One { get; internal set; }

		[WireMember(2)]
		public T Two { get; internal set; }

		[WireMember(3)]
		public T Three { get; internal set; }

		[WireMember(4)]
		public T Four { get; internal set; }

		[WireMember(5)]
		public T Five { get; internal set; }

		[WireMember(6)]
		public T Six { get; internal set; }

		[WireMember(7)]
		public T Seven { get; internal set; }

		public GenericStaticallySizedArrayChunkSeven(T one, T two, T three, T four, T five, T six, T seven)
		{
			One = one;
			Two = two;
			Three = three;
			Four = four;
			Five = five;
			Six = six;
			Seven = seven;
		}

		/// <summary>
		/// Serializer ctor.
		/// </summary>
		public GenericStaticallySizedArrayChunkSeven()
		{
			
		}

		public IEnumerator<T> GetEnumerator()
		{
			yield return One;
			yield return Two;
			yield return Three;
			yield return Four;
			yield return Five;
			yield return Six;
			yield return Seven;
		}

		public int Count => 7;

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
					case 5:
						return Five;
					case 6:
						return Six;
					case 7:
						return Seven;
					default:
						throw new IndexOutOfRangeException($"Index {index} is out of range. Max range of: {Count}");
				}
			}
		}
	}
}
