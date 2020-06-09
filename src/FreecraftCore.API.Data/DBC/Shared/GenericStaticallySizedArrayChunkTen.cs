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
	public sealed class GenericStaticallySizedArrayChunkTen<T>// : IEnumerable<T>, IReadOnlyList<T> TODO: Owned types cannot have interfaces
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

		[WireMember(8)]
		public T Eight { get; internal set; }

		[WireMember(9)]
		public T Nine { get; internal set; }

		[WireMember(10)]
		public T Ten { get; internal set; }

		public GenericStaticallySizedArrayChunkTen(T one, T two, T three, T four, T five, T six, T seven, T eight, T nine, T ten)
		{
			One = one;
			Two = two;
			Three = three;
			Four = four;
			Five = five;
			Six = six;
			Seven = seven;
			Eight = eight;
			Nine = nine;
			Ten = ten;
		}

		/// <summary>
		/// Serializer ctor.
		/// </summary>
		public GenericStaticallySizedArrayChunkTen()
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
			yield return Eight;
			yield return Nine;
			yield return Ten;
		}

		public int Count => 10;

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
					case 8:
						return Eight;
					case 9:
						return Nine;
					case 10:
						return Ten;
					default:
						throw new IndexOutOfRangeException($"Index {index} is out of range. Max range of: {Count}");
				}
			}
		}
	}
}
