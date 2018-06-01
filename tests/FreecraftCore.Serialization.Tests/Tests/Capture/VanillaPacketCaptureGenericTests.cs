using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Internal;
using FreecraftCore.Serializer;
using Ionic.Zlib;
using NUnit.Framework;
using Reinterpret.Net;

namespace FreecraftCore
{
	[TestFixture]
	public sealed class VanillaPacketCaptureGenericTests : GenericPacketCaptureTests<VanillaPacketCaptureTestCaseBuilder>
	{
		public VanillaPacketCaptureGenericTests()
		{

		}
	}
}
