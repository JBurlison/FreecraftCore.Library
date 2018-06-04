using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace FreecraftCore
{
	[TestFixture]
	public class VanillaToWotlkConverterTests
	{
		[Test]
		public static void Test_ConvertUnitFieldPlayer_Converts_All_Values([Range((int)EObjectFields_Vanilla.OBJECT_END, (int)EUnitFields_Vanilla.PLAYER_END - 1)] int fieldNumber)
		{
			//arrange
			EUnitFields_Vanilla vanillaUnitField = (EUnitFields_Vanilla)fieldNumber;

			//act
			bool? result = null;
			int shiftValue = 0;
			Assert.DoesNotThrow(() => result = VanillaToWotlkConverter.ConvertUpdateFieldsPlayer(vanillaUnitField, out shiftValue), $"Field: {fieldNumber}:{vanillaUnitField}:{fieldNumber:X} is not converted.");
			int newFieldNumber = (shiftValue + fieldNumber);

			//Assert
			Assert.NotNull(result);
			Assert.True(newFieldNumber >= (int)EObjectFields.OBJECT_END && newFieldNumber <= (int)EUnitFields.PLAYER_END);
		}
	}
}
