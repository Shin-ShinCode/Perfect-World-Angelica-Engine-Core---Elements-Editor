using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Operations;

namespace ACE.AIPolicyEditor.AIPolicy;

public static class Operation
{
	private sealed class Class31 : IEnumerable<int>, IEnumerator<int>, IEnumerable, IEnumerator, IDisposable
	{
		private int int_0;

		private int int_1;

		private int int_2;

		private int int_3;

		int IEnumerator<int>.Current
		{
			[DebuggerHidden]
			get
			{
				return int_1;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return int_1;
			}
		}

		[DebuggerHidden]
		public Class31(int int_4)
		{
			int_0 = int_4;
			int_2 = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			int_0 = -2;
		}

		private bool MoveNext()
		{
			switch (int_0)
			{
			default:
				return false;
			case 0:
				int_0 = -1;
				int_3 = 0;
				goto IL_0042;
			case 1:
			{
				int_0 = -1;
				int num = int_3 + 1;
				int_3 = num;
				goto IL_0042;
			}
			case 2:
				{
					int_0 = -1;
					int num = int_3 + 1;
					int_3 = num;
					break;
				}
				IL_0042:
				if (int_3 > 114)
				{
					int_3 = 200;
					break;
				}
				int_1 = int_3;
				int_0 = 1;
				return true;
			}
			if (int_3 > 206)
			{
				return false;
			}
			int_1 = int_3;
			int_0 = 2;
			return true;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<int> IEnumerable<int>.GetEnumerator()
		{
			if (int_0 == -2 && int_2 == Environment.CurrentManagedThreadId)
			{
				int_0 = 0;
				return this;
			}
			return new Class31(0);
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<int>)this).GetEnumerator();
		}
	}

	public static IEnumerable<int> GetKnownOperationIds()
	{
		return new Class31(-2);
	}

	public static IOperation Read(BinaryReader br, int version, int id)
	{
		IOperation operation = null;
		switch (id)
		{
		case 0:
			operation = new O_ATTACK_TYPE();
			break;
		case 1:
			operation = new O_USE_SKILL();
			break;
		case 2:
			operation = ((version <= 16) ? ((IOperation)new O_TALK_TEXT_OLD()) : ((IOperation)new O_TALK_TEXT()));
			break;
		case 3:
			operation = new O_RESET_HATE_LIST();
			break;
		case 4:
			operation = new O_RUN_TRIGGER();
			break;
		case 5:
			operation = new O_STOP_TRIGGER();
			break;
		case 6:
			operation = new O_ACTIVE_TRIGGER();
			break;
		case 7:
			operation = new O_CREATE_TIMER();
			break;
		case 8:
			operation = new O_KILL_TIMER();
			break;
		case 9:
			operation = new O_FLEE();
			break;
		case 10:
			operation = new O_SET_HATE_TO_FIRST();
			break;
		case 11:
			operation = new O_SET_HATE_TO_LAST();
			break;
		case 12:
			operation = new O_SET_HATE_FIFTY_PERCENT();
			break;
		case 13:
			operation = new O_SKIP_OPERATION();
			break;
		case 14:
			operation = new O_ACTIVE_CONTROLLER();
			break;
		case 15:
			operation = ((version <= 3) ? ((IOperation)new O_SET_GLOBAL_VERSION3()) : ((IOperation)new O_SET_GLOBAL()));
			break;
		case 16:
			operation = new O_REVISE_GLOBAL();
			break;
		case 17:
			operation = ((version <= 6) ? ((IOperation)new O_SUMMON_MONSTER_VERSION6()) : ((IOperation)new O_SUMMON_MONSTER()));
			break;
		case 18:
			operation = new O_WALK_ALONG();
			break;
		case 19:
			operation = ((version > 8) ? ((version >= 38) ? ((IOperation)new O_PLAY_ACTION_VERSION40()) : ((IOperation)new O_PLAY_ACTION())) : new O_PLAY_ACTION_VERSION8());
			break;
		case 20:
			operation = new O_REVISE_HISTORY();
			break;
		case 21:
			operation = new O_SET_HISTORY();
			break;
		case 22:
			operation = new O_DELIVER_FACTION_PVP_POINTS();
			break;
		case 23:
			operation = new O_CALC_VAR();
			break;
		case 24:
			operation = new O_SUMMON_MONSTER_2();
			break;
		case 25:
			operation = new O_WALK_ALONG_2();
			break;
		case 26:
			operation = new O_USE_SKILL_2();
			break;
		case 27:
			operation = new O_ACTIVE_CONTROLLER_2();
			break;
		case 28:
			operation = new O_DELIVER_TASK();
			break;
		case 29:
			operation = ((version <= 23) ? ((IOperation)new O_SUMMON_MINE_VERSION23()) : ((IOperation)new O_SUMMON_MINE()));
			break;
		case 30:
			operation = new O_SUMMON_NPC();
			break;
		case 31:
			operation = new O_DELIVER_RANDOM_TASK_IN_REGION();
			break;
		case 32:
			operation = new O_DELIVER_TASK_IN_HATE_LIST();
			break;
		case 33:
			operation = new O_CLEAR_TOWER_TASK_IN_REGION();
			break;
		case 34:
			operation = new O_SAVE_PLAYER_COUNT_IN_RADIUS_TO_PARAM();
			break;
		case 35:
			operation = new O_SAVE_PLAYER_COUNT_IN_REGION_TO_PARAM();
			break;
		case 36:
			operation = new O_SKILL_WITH_TALK();
			break;
		case 37:
			operation = new O_USE_SKILL_3();
			break;
		case 38:
			operation = new O_SORT_NUM();
			break;
		case 39:
			operation = new O_GET_POS_NUM();
			break;
		case 40:
			operation = new O_AUTO_BIND_CARRIER();
			break;
		case 41:
			operation = new O_ADD_RANGE_TO_HATE_LIST();
			break;
		case 42:
			operation = new O_SAVE_ALIVE_PLAYER_COUNT_IN_RADIUS_TO_PARAM();
			break;
		case 43:
			operation = new O_SAVE_ALIVE_PLAYER_COUNT_IN_REGION_TO_PARAM();
			break;
		case 44:
			operation = new O_WALK_ALONG_3();
			break;
		case 45:
			operation = new O_WALK_ALONG_4();
			break;
		case 46:
			operation = new O_SAVE_TIME();
			break;
		case 47:
			operation = new O_RANDOM_ASSIGNMENT();
			break;
		case 48:
			operation = new O_CARRIER_VOTING();
			break;
		case 49:
			operation = new O_VOTING_RESULT();
			break;
		case 50:
			operation = new O_VOTING_SHOW();
			break;
		case 51:
			operation = new O_CARRIER_DELIVERY_TASK();
			break;
		case 52:
			operation = new O_CARRIER_NOENTRY();
			break;
		case 53:
			operation = new O_TALK_TEXT_2();
			break;
		case 54:
			operation = new O_CREATE_TIMER_2();
			break;
		case 55:
			operation = new O_KILL_TIMER_2();
			break;
		case 56:
			operation = new O_CHANGE_MONSTER_FIGHTING_STATE();
			break;
		case 57:
			operation = new O_CHANGE_MONSTER_ACTIVE_PASSIVE();
			break;
		case 58:
			operation = new O_CHILD_CARRIER_PARENT_MONSTER();
			break;
		case 59:
			operation = new O_CLOSE_CHILD_MONSTER();
			break;
		case 60:
			operation = new O_DELIVER_HATE_TARGETS();
			break;
		case 61:
			operation = new O_CHANGE_MONSTER_ATTACK_POLICY();
			break;
		case 62:
			operation = new O_SPECIFY_FAILED_TASK_ID();
			break;
		case 63:
			operation = new O_SPECIFY_FAILED_TASK_ID_REGIONAL();
			break;
		case 64:
			operation = new O_MASS_ACTIVE_CONTROLLER();
			break;
		case 65:
			operation = new O_BOSS_RUSH_AWARD();
			break;
		case 66:
			operation = new O_BOSS_RUSH_END();
			break;
		case 67:
			operation = new O_USE_SKILL_IN_REGION();
			break;
		case 68:
			operation = new O_BIRTH_SIZE();
			break;
		case 69:
			operation = new O_REVISE_GLOBAL_2();
			break;
		case 70:
			operation = new O_70();
			break;
		case 71:
			operation = new O_GET_HP_NUM();
			break;
		case 72:
			operation = new O_TALK_TEXT_IN_REGION();
			break;
		case 73:
			operation = new O_ACTIVE_WHITELIST();
			break;
		case 74:
			operation = new O_USE_SKILL_IN_STRATEGY_ZONE();
			break;
		case 75:
			operation = new O_75();
			break;
		case 76:
			operation = new O_76();
			break;
		case 77:
			operation = new O_USE_SKILL_4();
			break;
		case 78:
			operation = new O_78();
			break;
		case 79:
			operation = new O_79();
			break;
		case 80:
			operation = new O_80();
			break;
		case 81:
			operation = new O_81();
			break;
		case 82:
			operation = new O_82();
			break;
		case 83:
			operation = new O_83();
			break;
		case 84:
			operation = new O_84();
			break;
		case 85:
			operation = new O_85();
			break;
		case 86:
			operation = new O_86();
			break;
		case 87:
			operation = new O_87();
			break;
		case 88:
			operation = new O_PET_POLICY();
			break;
		case 89:
			operation = new O_89();
			break;
		case 90:
			operation = new O_90();
			break;
		case 91:
			operation = new O_91();
			break;
		case 92:
			operation = new O_92();
			break;
		case 93:
			operation = new O_93();
			break;
		case 94:
			operation = new O_94();
			break;
		case 95:
			operation = new O_95();
			break;
		case 96:
			operation = new O_96();
			break;
		case 97:
			operation = new O_97();
			break;
		case 98:
			operation = new O_98();
			break;
		case 99:
			operation = new O_COPY_VALUE_TO_MULTIPLE();
			break;
		case 100:
			operation = new O_FAKE_MONSTER_POS();
			break;
		case 101:
			operation = new O_101();
			break;
		case 102:
			operation = new O_CHECK_FACTION_DEATH();
			break;
		case 103:
			operation = new O_103();
			break;
		case 104:
			operation = new O_104();
			break;
		case 105:
			operation = new O_105();
			break;
		case 106:
			operation = new O_106();
			break;
		case 107:
			operation = new O_107();
			break;
		case 108:
			operation = new O_108();
			break;
		case 109:
			operation = new O_109();
			break;
		case 110:
			operation = new O_GIVE_TASK_FOR_RADIUS();
			break;
		case 111:
			operation = new O_111();
			break;
		case 112:
			operation = new O_112();
			break;
		case 113:
			operation = new O_113();
			break;
		case 114:
			operation = new O_114();
			break;
		case 200:
			operation = new O_CALC_VAR_FLOAT();
			break;
		case 201:
			operation = new O_CALC_VAR_MULTI();
			break;
		case 202:
			operation = new O_SET_VAR_STRING();
			break;
		case 203:
			operation = new O_TALK_FROM_VAR_STRING();
			break;
		case 204:
			operation = new O_ADJUST_PROP_BY_ANYTHING();
			break;
		case 205:
			operation = new O_REFRESH_PROP();
			break;
		case 206:
			operation = new O_ACTIVE_PEACE_ZONE();
			break;
		}
		if (br != null)
		{
			operation?.Read(br);
		}
		return operation;
	}
}
