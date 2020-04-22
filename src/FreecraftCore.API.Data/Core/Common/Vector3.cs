using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreecraftCore.Serializer;
using Microsoft.EntityFrameworkCore;

namespace FreecraftCore
{
	[Owned]
	[WireDataContract]
	public class Vector3<T>// : Vector2<T> TODO: For compatibility with EF Core owned types we cannot use inheritence
	{
		/// <summary>
		/// X value.
		/// </summary>
		[WireMember(1)]
		public T X { get; private set; }

		/// <summary>
		/// Y value.
		/// </summary>
		[WireMember(2)]
		public T Y { get; private set; }

		/// <summary>
		/// Z value.
		/// </summary>
		[WireMember(3)]
		public T Z { get; private set; }

		public Vector3(T x, T y, T z)
		{
			X = x;
			Y = y;
			Z = z;
		}

		protected Vector3()
		{

		}

		/// <inheritdoc />
		public override string ToString()
		{
			return $"X: {X} Y: {Y} Z: {Z}";
		}
	}
}