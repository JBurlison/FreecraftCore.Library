using System;
using System.Collections.Generic;
using System.Text;

namespace FreecraftCore
{
	public static class VanillaToWotlkConverter
	{
		/// <summary>
		/// Produces a shift value offset that can be used to
		/// map the provided <see cref="containerFieldValue"/> to the
		/// <see cref="EContainerFields"/> for wotlk.
		/// </summary>
		/// <param name="containerFieldValue">The container field value to shift.</param>
		/// <param name="shiftValue">The value of the shift.</param>
		/// <returns>Indicates if the value should be written. This return is important. Don't write it if this returns false.</returns>
		public static bool ConvertUpdateFieldsContainer(EContainerFields_Vanilla containerFieldValue, out int shiftValue)
		{
			//Only need a static shift amount. 3.3.5 has more fields but we just don't write them
			shiftValue = (int)EContainerFields.CONTAINER_FIELD_NUM_SLOTS - (int)EContainerFields_Vanilla.CONTAINER_FIELD_NUM_SLOTS;

			return true;
		}

		/// <summary>
		/// Produces a shift value offset that can be used to
		/// map the provided <see cref="itemFieldValue"/> to the
		/// <see cref="EItemFields"/> for wotlk.
		/// </summary>
		/// <param name="itemFieldValue">The item field value to shift.</param>
		/// <param name="shiftValue">The value of the shift.</param>
		/// <returns>Indicates if the value should be written. This return is important. Don't write it if this returns false.</returns>
		public static bool ConvertUpdateFieldsItem(EItemFields_Vanilla itemFieldValue, out int shiftValue)
		{
			int shiftAmount = 0;
			bool shouldWrite = true;
			int i = (int)itemFieldValue;

			//It doesn't start to desync until after ITEM_FIELD_ENCHANTMENT
			if(i < (int)EItemFields_Vanilla.ITEM_FIELD_PROPERTY_SEED)
			{
				//Do nothing. It's correct.
			}
			else if(i >= (int)EItemFields_Vanilla.ITEM_FIELD_PROPERTY_SEED && i <= (int)EItemFields_Vanilla.ITEM_FIELD_RANDOM_PROPERTIES_ID)
			{
				//15
				shiftAmount = (int)EItemFields.ITEM_FIELD_PROPERTY_SEED - (int)EItemFields_Vanilla.ITEM_FIELD_PROPERTY_SEED;
			}
			else if(i == (int)EItemFields_Vanilla.ITEM_FIELD_ITEM_TEXT_ID)
			{
				//We don't write ITEM_FIELD_ITEM_TEXT_ID
				shouldWrite = false;
			}
			else if(i >= (int)EItemFields_Vanilla.ITEM_FIELD_DURABILITY)
			{
				//14
				shiftAmount = (int)EItemFields.ITEM_FIELD_DURABILITY - (int)EItemFields_Vanilla.ITEM_FIELD_DURABILITY;
			}
			else
				throw new InvalidOperationException($"Unhandled field: {((EItemFields_Vanilla)i).ToString()}:{i}:{i:X}");

			shiftValue = shiftAmount;
			return shouldWrite;
		}

		/// <summary>
		/// Produces a shift value offset that can be used to
		/// map the provided <see cref="unitFieldValue"/> to the
		/// <see cref="EUnitFields"/> for wotlk.
		/// </summary>
		/// <param name="unitFieldValue">The unit field value to shift.</param>
		/// <param name="shiftValue">The value of the shift.</param>
		/// <returns>Indicates if the value should be written. This return is important. Don't write it if this returns false.</returns>
		public static bool ConvertUpdateFieldsPlayer(EUnitFields_Vanilla unitFieldValue, out int shiftValue)
		{
			//TODO: Do we need this initial shift anymore?
			int shiftAmount = 2;
			bool shouldWrite = true;
			int i = (int)unitFieldValue;

			//This is aligned
			if(i == (int)EUnitFields_Vanilla.UNIT_FIELD_CHANNEL_OBJECT || i == ((int)EUnitFields_Vanilla.UNIT_FIELD_CHANNEL_OBJECT + 1))
				shiftAmount = 0;
			else if(i == (int)EUnitFields_Vanilla.UNIT_FIELD_BYTES_0)
			{
				//-13
				shiftAmount = (int)EUnitFields.UNIT_FIELD_BYTES_0 - (int)EUnitFields_Vanilla.UNIT_FIELD_BYTES_0;
			}
			else if(i == (int)EUnitFields_Vanilla.UNIT_CHANNEL_SPELL)
			{
				//-122
				shiftAmount = 0x0010 - 0x8a;
			}
			else if(i < (int)EUnitFields.UNIT_FIELD_CRITTER)
			{
				//TODO: This is kinda hacky, it was added after the default shift value
				shiftAmount = 0;
			}
			else if(i >= (int)EUnitFields_Vanilla.UNIT_FIELD_CHARMEDBY && i <= (int)EUnitFields_Vanilla.UNIT_FIELD_TARGET + 1) //is a 2 byte field
			{
				shiftAmount = (int)EUnitFields.UNIT_FIELD_CHARMEDBY - (int)EUnitFields_Vanilla.UNIT_FIELD_CHARMEDBY;
			}
			else if(i == (int)EUnitFields_Vanilla.UNIT_FIELD_PERSUADED || i == (int)EUnitFields_Vanilla.UNIT_FIELD_PERSUADED + 1) //it is a 2 index field
			{
				//TODO: What even is this?
				shouldWrite = false;
			}
			else if(i >= (int)EUnitFields_Vanilla.UNIT_FIELD_HEALTH && i <= (int)EUnitFields_Vanilla.UNIT_FIELD_POWER5)
			{
				shiftAmount = (int)EUnitFields.UNIT_FIELD_HEALTH - (int)EUnitFields_Vanilla.UNIT_FIELD_HEALTH;
			}
			else if(i >= (int)EUnitFields_Vanilla.UNIT_FIELD_MAXHEALTH && i < (int)EUnitFields_Vanilla.UNIT_FIELD_LEVEL) //keep less than
			{
				//4
				shiftAmount = (int)EUnitFields.UNIT_FIELD_MAXHEALTH - (int)EUnitFields_Vanilla.UNIT_FIELD_MAXHEALTH;
			}
			else if(i >= (int)EUnitFields_Vanilla.UNIT_FIELD_LEVEL && i <= (int)EUnitFields_Vanilla.UNIT_FIELD_FACTIONTEMPLATE)
			{
				//20
				shiftAmount = (int)EUnitFields.UNIT_FIELD_LEVEL - (int)EUnitFields_Vanilla.UNIT_FIELD_LEVEL;
			}
			else if(i >= (int)EUnitFields_Vanilla.UNIT_VIRTUAL_ITEM_SLOT_DISPLAY && i < (int)EUnitFields_Vanilla.UNIT_VIRTUAL_ITEM_INFO)
			{
				shiftAmount = (int)EUnitFields.UNIT_VIRTUAL_ITEM_SLOT_ID - (int)EUnitFields_Vanilla.UNIT_VIRTUAL_ITEM_SLOT_DISPLAY;
			}
			else if(i >= (int)EUnitFields_Vanilla.UNIT_VIRTUAL_ITEM_INFO && i <= (int)EUnitFields_Vanilla.UNIT_VIRTUAL_ITEM_INFO_05)
			{
				//Wotlk doesn't have this.
				shouldWrite = false;
			}
			else if(i == (int)EUnitFields_Vanilla.UNIT_FIELD_FLAGS)
			{
				//13
				shiftAmount = (int)EUnitFields.UNIT_FIELD_FLAGS - (int)EUnitFields_Vanilla.UNIT_FIELD_FLAGS;
			}
			else if(i >= (int)EUnitFields_Vanilla.UNIT_FIELD_AURA && i <= (int)EUnitFields_Vanilla.UNIT_FIELD_AURAAPPLICATIONS_LAST)
			{
				//Wotlk does not have all this aura stuff
				//It DOES have aura state though.
				shouldWrite = false;
			}
			else if(i >= (int)EUnitFields_Vanilla.UNIT_FIELD_AURASTATE && i <= (int)EUnitFields_Vanilla.UNIT_FIELD_BASEATTACKTIME)
			{
				//-64
				shiftAmount = (int)EUnitFields.UNIT_FIELD_AURASTATE - (int)EUnitFields_Vanilla.UNIT_FIELD_AURASTATE;
			}
			else if(i == (int)EUnitFields_Vanilla.UNIT_FIELD_OFFHANDATTACKTIME)
			{
				shouldWrite = false;
			}
			else if(i >= (int)EUnitFields_Vanilla.UNIT_FIELD_RANGEDATTACKTIME && i <= (int)EUnitFields_Vanilla.UNIT_DYNAMIC_FLAGS)
			{
				//-64
				shiftAmount = 0x003A - 0x7a;
			}
			else if(i >= (int)EUnitFields_Vanilla.UNIT_MOD_CAST_SPEED && i <= (int)EUnitFields_Vanilla.UNIT_FIELD_STAT4)
			{
				//-65
				shiftAmount = (int)EUnitFields.UNIT_MOD_CAST_SPEED - (int)EUnitFields_Vanilla.UNIT_MOD_CAST_SPEED;
			}
			else if(i >= (int)EUnitFields_Vanilla.UNIT_FIELD_RESISTANCES && i <= (int)EUnitFields_Vanilla.UNIT_FIELD_RESISTANCES_06)
			{
				//-56
				shiftAmount = (int)EUnitFields.UNIT_FIELD_RESISTANCES - (int)EUnitFields_Vanilla.UNIT_FIELD_RESISTANCES;
			}
			else if(i >= (int)EUnitFields_Vanilla.UNIT_FIELD_BASE_MANA && i <= (int)EUnitFields_Vanilla.UNIT_FIELD_POWER_COST_MULTIPLIER_06)
			{
				//-42
				shiftAmount = (int)EUnitFields.UNIT_FIELD_BASE_MANA - (int)EUnitFields_Vanilla.UNIT_FIELD_BASE_MANA;
			}
			else if(i >= (int)EUnitFields_Vanilla.UNIT_FIELD_PADDING && i <= (int)EUnitFields_Vanilla.PLAYER_GUILD_TIMESTAMP)
			{
				//-40
				shiftAmount = (int)EUnitFields.UNIT_FIELD_PADDING - (int)EUnitFields_Vanilla.UNIT_FIELD_PADDING;
			}
			else if(i >= (int)EUnitFields_Vanilla.PLAYER_QUEST_LOG_1_1 && i <= (int)EUnitFields_Vanilla.PLAYER_QUEST_LOG_LAST_3)
			{
				//TC quests:
				/*SetUInt32Value(PLAYER_QUEST_LOG_1_1 + slot * MAX_QUEST_OFFSET + QUEST_ID_OFFSET, quest_id);
				SetUInt32Value(PLAYER_QUEST_LOG_1_1 + slot * MAX_QUEST_OFFSET + QUEST_STATE_OFFSET, 0);
				SetUInt32Value(PLAYER_QUEST_LOG_1_1 + slot * MAX_QUEST_OFFSET + QUEST_COUNTS_OFFSET, 0);
				SetUInt32Value(PLAYER_QUEST_LOG_1_1 + slot * MAX_QUEST_OFFSET + QUEST_COUNTS_OFFSET + 1, 0);
				SetUInt32Value(PLAYER_QUEST_LOG_1_1 + slot * MAX_QUEST_OFFSET + QUEST_TIME_OFFSET, timer);*/

				//Mangos quests:
				/*SetUInt32Value(PLAYER_QUEST_LOG_1_1 + slot * MAX_QUEST_OFFSET + QUEST_ID_OFFSET, quest_id);
				 SetUInt32Value(PLAYER_QUEST_LOG_1_1 + slot * MAX_QUEST_OFFSET + QUEST_COUNT_STATE_OFFSET, 0);
				 SetUInt32Value(PLAYER_QUEST_LOG_1_1 + slot * MAX_QUEST_OFFSET + QUEST_TIME_OFFSET, timer);*/

				//TODO: Handle quests
				shouldWrite = false;
			}
			else if(i >= (int)EUnitFields_Vanilla.PLAYER_VISIBLE_ITEM_1_CREATOR && i <= (int)EUnitFields_Vanilla.PLAYER_VISIBLE_ITEM_LAST_PAD)
			{
				//TODO: Handle visible items
				shouldWrite = false;
			}
			else if(i >= (int)EUnitFields_Vanilla.PLAYER_FIELD_INV_SLOT_HEAD && i <= (int)EUnitFields_Vanilla.PLAYER_FIELD_BANK_SLOT_LAST + 1) //added an extra 1 because it is a 2 slot field
			{
				//-162
				//Only until the last bank slot. Wotlk doesn't have the same bankslot count.
				shiftAmount = (int)EUnitFields.PLAYER_FIELD_INV_SLOT_HEAD - (int)EUnitFields_Vanilla.PLAYER_FIELD_INV_SLOT_HEAD;
			}
			//TODO: Change this back to EUnitFields_Vanilla.PLAYER_FIELD_BANKBAG_SLOT_LAST after the value is fixed in Mangos/Cmangos
			else if(i >= (int)EUnitFields_Vanilla.PLAYER_FIELD_BANKBAG_SLOT_1 && i <= (int)EUnitFields_Vanilla.PLAYER_FIELD_BANKBAG_SLOT_LAST + 1) //added an extra 1 beacause it is a 2 slot field
			{
				//wotlk has more bank banks so we only send the vanilla data
				//-154
				shiftAmount = (int)EUnitFields.PLAYER_FIELD_BANKBAG_SLOT_1 - (int)EUnitFields_Vanilla.PLAYER_FIELD_BANKBAG_SLOT_1;
			}
			else if(i >= (int)EUnitFields_Vanilla.PLAYER_FIELD_VENDORBUYBACK_SLOT_1 && i <= (int)EUnitFields_Vanilla.PLAYER_FARSIGHT + 1) //farsight is a 2 slot field
			{
				//-152
				shiftAmount = (int)EUnitFields.PLAYER_FIELD_VENDORBUYBACK_SLOT_1 - (int)EUnitFields_Vanilla.PLAYER_FIELD_VENDORBUYBACK_SLOT_1;
			}
			else if(i == (int)EUnitFields_Vanilla.PLAYER_FIELD_COMBO_TARGET || i == (int)EUnitFields_Vanilla.PLAYER_FIELD_COMBO_TARGET + 1) //2 slot field
			{
				//TODO: Where is this on 3.3.5?? How is it communicated?
				shouldWrite = false;
			}
			else if(i >= (int)EUnitFields_Vanilla.PLAYER_XP && i <= (int)EUnitFields_Vanilla.PLAYER_PARRY_PERCENTAGE)
			{
				//Only until parry. Because after that wotlk expects expertise which vanilla doesn't have
				//-82
				shiftAmount = (int)EUnitFields.PLAYER_XP - (int)EUnitFields_Vanilla.PLAYER_XP;
			}
			else if(i >= (int)EUnitFields_Vanilla.PLAYER_CRIT_PERCENTAGE && i <= (int)EUnitFields_Vanilla.PLAYER_RANGED_CRIT_PERCENTAGE)
			{
				//Only until PLAYER_RANGED_CRIT_PERCENTAGE, wotlk has a couple of extra crit fields
				//-80
				shiftAmount = (int)EUnitFields.PLAYER_CRIT_PERCENTAGE - (int)EUnitFields_Vanilla.PLAYER_CRIT_PERCENTAGE;
			}
			else if(i >= (int)EUnitFields_Vanilla.PLAYER_EXPLORED_ZONES_1 && i < (int)EUnitFields_Vanilla.PLAYER_REST_STATE_EXPERIENCE)
			{
				//TODO: Handle explored zones
				shouldWrite = false;
				//Don't include rested
				//We must map the explored
				//Explored for Wotlk is UNIT_END + 0x037D
				//but in vanilla it is 0x39b + UNIT_END
				//-70
				shiftAmount = (int)EUnitFields.PLAYER_EXPLORED_ZONES_1 - (int)EUnitFields_Vanilla.PLAYER_EXPLORED_ZONES_1;
			}
			else if(i >= (int)EUnitFields_Vanilla.PLAYER_REST_STATE_EXPERIENCE && i <= (int)EUnitFields_Vanilla.PLAYER_FIELD_COINAGE)
			{
				//-6
				shiftAmount = (int)EUnitFields.PLAYER_REST_STATE_EXPERIENCE - (int)EUnitFields_Vanilla.PLAYER_REST_STATE_EXPERIENCE;
			}
			else if(i >= (int)EUnitFields_Vanilla.PLAYER_FIELD_POSSTAT0 && i <= (int)EUnitFields_Vanilla.PLAYER_FIELD_NEGSTAT4)
			{
				//in vanilla these are player only fields
				//but in trinitycore these are unit fields
				//so we need to go WAY back and insert these
				//Don't write pos/neg resist buffs or else a field will be overwritten.
				//-1088
				shiftAmount = (int)EUnitFields.UNIT_FIELD_POSSTAT0 - (int)EUnitFields_Vanilla.PLAYER_FIELD_POSSTAT0;

				Console.WriteLine($"****Shift for POSSTAT: {shiftAmount}********");
			}
			else if(i >= (int)EUnitFields_Vanilla.PLAYER_FIELD_RESISTANCEBUFFMODSPOSITIVE && i < (int)EUnitFields_Vanilla.PLAYER_FIELD_MOD_DAMAGE_DONE_POS) //keep less than: PLAYER_FIELD_RESISTANCEBUFFMODSNEGATIVE is 7 indices
			{
				//-1081
				shiftAmount = (int)EUnitFields.UNIT_FIELD_RESISTANCEBUFFMODSPOSITIVE - (int)EUnitFields_Vanilla.PLAYER_FIELD_RESISTANCEBUFFMODSPOSITIVE;
			}
			else if(i >= (int)EUnitFields_Vanilla.PLAYER_FIELD_MOD_DAMAGE_DONE_POS && i < (int)EUnitFields_Vanilla.PLAYER_FIELD_BYTES) //keep less than, we need all 6 indicies after PCT
			{
				//-30
				//Stop after DONE_PCT because healing fields are next in wotlk but vanilla doesn't have them.
				shiftAmount = (int)EUnitFields.PLAYER_FIELD_MOD_DAMAGE_DONE_POS - (int)EUnitFields_Vanilla.PLAYER_FIELD_MOD_DAMAGE_DONE_POS;
			}
			else if(i >= (int)EUnitFields_Vanilla.PLAYER_FIELD_BYTES && i < (int)EUnitFields_Vanilla.PLAYER_FIELD_SESSION_KILLS) //keep less than
			{
				//-25
				shiftAmount = (int)EUnitFields.PLAYER_FIELD_BYTES - (int)EUnitFields_Vanilla.PLAYER_FIELD_BYTES;
			}
			else if(i >= (int)EUnitFields_Vanilla.PLAYER_FIELD_SESSION_KILLS && i <= (int)EUnitFields_Vanilla.PLAYER_FIELD_LAST_WEEK_RANK)
			{
				//TODO: How should we handle Honor and stuff?
				shouldWrite = false;
			}
			else if(i >= (int)EUnitFields_Vanilla.PLAYER_FIELD_BYTES2 && i < (int)EUnitFields_Vanilla.PLAYER_END)
			{
				//This is the last fields we will write because it goes all the way to combat_rating_20
				//The issue after this, and it may or may not be handled by the time you read this, is that
				//there are many potentially important player fields after this in wotlk.
				//TODO:
				/*
				 *
				PLAYER_FIELD_ARENA_TEAM_INFO_1_1          = UNIT_END + 0x0454, // Size: 21, Type: INT, Flags: PRIVATE
				PLAYER_FIELD_HONOR_CURRENCY               = UNIT_END + 0x0469, // Size: 1, Type: INT, Flags: PRIVATE
				PLAYER_FIELD_ARENA_CURRENCY               = UNIT_END + 0x046A, // Size: 1, Type: INT, Flags: PRIVATE
				PLAYER_FIELD_MAX_LEVEL                    = UNIT_END + 0x046B, // Size: 1, Type: INT, Flags: PRIVATE
				PLAYER_FIELD_DAILY_QUESTS_1               = UNIT_END + 0x046C, // Size: 25, Type: INT, Flags: PRIVATE
				PLAYER_RUNE_REGEN_1                       = UNIT_END + 0x0485, // Size: 4, Type: FLOAT, Flags: PRIVATE
				PLAYER_NO_REAGENT_COST_1                  = UNIT_END + 0x0489, // Size: 3, Type: INT, Flags: PRIVATE
				PLAYER_FIELD_GLYPH_SLOTS_1                = UNIT_END + 0x048C, // Size: 6, Type: INT, Flags: PRIVATE
				PLAYER_FIELD_GLYPHS_1                     = UNIT_END + 0x0492, // Size: 6, Type: INT, Flags: PRIVATE
				PLAYER_GLYPHS_ENABLED                     = UNIT_END + 0x0498, // Size: 1, Type: INT, Flags: PRIVATE
				PLAYER_PET_SPELL_POWER                    = UNIT_END + 0x0499, // Size: 1, Type: INT, Flags: PRIVATE
				PLAYER_END
				 */
				//-31
				shiftAmount = (int)EUnitFields.PLAYER_FIELD_BYTES2 - (int)EUnitFields_Vanilla.PLAYER_FIELD_BYTES2;
			}
			else
				throw new InvalidOperationException($"Unhandled field: {((EUnitFields_Vanilla)i).ToString()}:{i}:{i:X}");

			shiftValue = shiftAmount;
			return shouldWrite;
		}
	}
}
