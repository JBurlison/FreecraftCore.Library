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
	public class Vector4<T>// : Vector3<T> TODO: For compatibility with EF Core owned types we cannot use inheritence
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

		/// <summary>
		/// X value.
		/// </summary>
		[WireMember(4)]
		public T W { get; private set; }

		public Vector4(T x, T y, T z, T w)
		{
			X = x;
			Y = y;
			Z = z;
			W = w;
		}

		private Vector4()
		{

		}

		/// <inheritdoc />
		public override string ToString()
		{
			return $"X: {X} Y: {Y} Z: {Z} W: {W}";
		}
	}
}