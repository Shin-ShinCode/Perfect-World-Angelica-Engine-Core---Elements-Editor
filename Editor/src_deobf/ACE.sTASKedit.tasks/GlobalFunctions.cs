using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ACE.sTASKedit.tasks.tasks.data;

namespace ACE.sTASKedit.tasks;

public class GlobalFunctions
{
	private sealed class Class420 : IEnumerable<int>, IEnumerator<int>, IEnumerable, IEnumerator, IDisposable
	{
		private int int_0;

		private int int_1;

		private int int_2;

		private int int_3;

		public int int_4;

		private uint uint_0;

		private int int_5;

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
		public Class420(int int_6)
		{
			int_0 = int_6;
			int_2 = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			int_0 = -2;
		}

		private bool MoveNext()
		{
			int num = int_0;
			if (num != 0)
			{
				if (num != 1)
				{
					return false;
				}
				int_0 = -1;
				goto IL_0042;
			}
			int_0 = -1;
			uint_0 = (uint)int_3;
			int_5 = 0;
			goto IL_0060;
			IL_0042:
			uint_0 >>= 1;
			int_5++;
			goto IL_0060;
			IL_0060:
			if (uint_0 != 0)
			{
				if ((uint_0 & 1) == 1)
				{
					int_1 = int_5;
					int_0 = 1;
					return true;
				}
				goto IL_0042;
			}
			return false;
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
			Class420 @class;
			if (int_0 == -2 && int_2 == Environment.CurrentManagedThreadId)
			{
				int_0 = 0;
				@class = this;
			}
			else
			{
				@class = new Class420(0);
			}
			@class.int_3 = int_4;
			return @class;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<int>)this).GetEnumerator();
		}
	}

	public static IEnumerable<int> GetPowers(int value)
	{
		return new Class420(-2)
		{
			int_4 = value
		};
	}

	public static string ColorClean(string line)
	{
		string[] array = line.Split('^');
		if (array.Length > 1)
		{
			string text = string.Empty;
			if (array[0] != string.Empty)
			{
				text += array[0];
			}
			for (int i = 1; i < array.Length; i++)
			{
				if (array[i] != string.Empty)
				{
					try
					{
						text = ((!int.TryParse(array[i].Substring(0, 6), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out var _)) ? (text + Class16.smethod_0(1648935659) + array[i]) : (text + array[i].Substring(6)));
					}
					catch
					{
						text = text + Class16.smethod_0(1648935659) + array[i];
					}
				}
			}
			return text;
		}
		return line;
	}

	internal static char[] ReadChars(int length, BinaryReader br)
	{
		char[] array = new char[length];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = (char)br.ReadByte();
		}
		return array;
	}

	internal static short[] ReadNameChars(int length, BinaryReader br)
	{
		short[] array = new short[length];
		for (int i = 0; i < length; i++)
		{
			array[i] = br.ReadInt16();
		}
		return array;
	}

	internal static short[] ReadChars_pwstr(BinaryReader binaryReader_0)
	{
		int num = binaryReader_0.ReadInt32();
		if (num < 0)
		{
			return new short[0];
		}
		short[] array = new short[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = binaryReader_0.ReadInt16();
		}
		return array;
	}

	internal static void WriteChars(BinaryWriter bw, char[] Chars)
	{
		for (int i = 0; i < Chars.Length; i++)
		{
			bw.Write((byte)Chars[i]);
		}
	}

	internal static void WriteNameChars(BinaryWriter bw, short[] Chars)
	{
		for (int i = 0; i < Chars.Length; i++)
		{
			bw.Write(Chars[i]);
		}
	}

	internal static void WriteChars_pwstr(BinaryWriter bw, short[] Chars)
	{
		bw.Write(Chars.Length);
		for (int i = 0; i < Chars.Length; i++)
		{
			bw.Write(Chars[i]);
		}
	}

	public static void UpdateNode(TreeNode treeNode_0, ATaskTempl ataskTempl_0, int UpdateType, int GMIconIndex = 12, int DisabledIconIndex = 13)
	{
		string name = ataskTempl_0.Name;
		Color foreColor = Color.White;
		int imageIndex = 0;
		int selectedImageIndex = 1;
		treeNode_0.Tag = ataskTempl_0;
		switch ((GlobalData.ENUM_TASK_TYPE)ataskTempl_0.m_ulType)
		{
		case GlobalData.ENUM_TASK_TYPE.enumTTDaily:
			if (GlobalData.version >= 120)
			{
				foreColor = ((GlobalData.version < 156) ? Color.FromArgb(100, 185, 250) : Color.FromArgb(38, 178, 255));
			}
			imageIndex = 8;
			selectedImageIndex = 9;
			break;
		case GlobalData.ENUM_TASK_TYPE.enumTTLevel2:
			if (GlobalData.version >= 120)
			{
				foreColor = Color.FromArgb(238, 156, 15);
			}
			imageIndex = 0;
			selectedImageIndex = 1;
			break;
		case GlobalData.ENUM_TASK_TYPE.enumTTMajor:
			if (GlobalData.version >= 120)
			{
				foreColor = ((GlobalData.version < 156) ? Color.FromArgb(255, 150, 255) : Color.FromArgb(20, 255, 255));
			}
			if (GlobalData.version >= 156)
			{
				imageIndex = 16;
				selectedImageIndex = 17;
			}
			else
			{
				imageIndex = 10;
				selectedImageIndex = 11;
			}
			break;
		case GlobalData.ENUM_TASK_TYPE.enumTTBranch:
			if (GlobalData.version >= 120)
			{
				foreColor = Color.FromArgb(255, 255, 255);
			}
			imageIndex = 0;
			selectedImageIndex = 1;
			break;
		case GlobalData.ENUM_TASK_TYPE.enumTTEvent:
			if (GlobalData.version >= 120)
			{
				foreColor = ((GlobalData.version < 156) ? Color.FromArgb(255, 255, 0) : Color.FromArgb(150, 224, 255));
			}
			imageIndex = 8;
			selectedImageIndex = 9;
			break;
		case GlobalData.ENUM_TASK_TYPE.enumTTQiShaList:
			if (GlobalData.version >= 120)
			{
				foreColor = ((GlobalData.version >= 161) ? Color.FromArgb(150, 224, 255) : ((GlobalData.version < 156) ? Color.FromArgb(180, 180, 255) : Color.FromArgb(255, 255, 255)));
			}
			imageIndex = 6;
			selectedImageIndex = 7;
			break;
		case GlobalData.ENUM_TASK_TYPE.enumTTFaction:
			if (GlobalData.version >= 120)
			{
				foreColor = ((GlobalData.version < 156) ? Color.FromArgb(0, 200, 200) : Color.FromArgb(255, 255, 255));
			}
			imageIndex = 4;
			selectedImageIndex = 5;
			break;
		case GlobalData.ENUM_TASK_TYPE.enumTTFunction:
			if (GlobalData.version >= 120)
			{
				foreColor = ((GlobalData.version < 156) ? Color.FromArgb(120, 255, 120) : Color.FromArgb(20, 196, 100));
			}
			imageIndex = 4;
			selectedImageIndex = 5;
			break;
		case GlobalData.ENUM_TASK_TYPE.enumTTLegend:
			if (GlobalData.version >= 120)
			{
				foreColor = ((GlobalData.version < 126) ? Color.FromArgb(255, 120, 120) : ((GlobalData.version < 156) ? Color.FromArgb(255, 0, 0) : Color.FromArgb(255, 255, 255)));
			}
			imageIndex = 0;
			selectedImageIndex = 1;
			break;
		case GlobalData.ENUM_TASK_TYPE.enumTTQuestion:
			if (GlobalData.version >= 120)
			{
				foreColor = Color.FromArgb(146, 255, 216);
			}
			imageIndex = 0;
			selectedImageIndex = 1;
			break;
		case GlobalData.ENUM_TASK_TYPE.enumTTHome:
			if (GlobalData.version >= 120)
			{
				foreColor = ((GlobalData.version < 156) ? Color.FromArgb(255, 120, 120) : Color.FromArgb(84, 197, 255));
			}
			imageIndex = 0;
			selectedImageIndex = 1;
			break;
		case GlobalData.ENUM_TASK_TYPE.enumTTGrowth:
			foreColor = Color.FromArgb(20, 196, 100);
			imageIndex = 0;
			selectedImageIndex = 1;
			break;
		case GlobalData.ENUM_TASK_TYPE.enumTTStory:
			foreColor = Color.FromArgb(255, 173, 255);
			imageIndex = 12;
			selectedImageIndex = 13;
			break;
		case GlobalData.ENUM_TASK_TYPE.enumTTInstance:
			foreColor = Color.FromArgb(255, 255, 255);
			imageIndex = 0;
			selectedImageIndex = 1;
			break;
		case GlobalData.ENUM_TASK_TYPE.enumTTCommonOld:
			imageIndex = 0;
			selectedImageIndex = 1;
			break;
		case GlobalData.ENUM_TASK_TYPE.enumTTRepeatedOld:
			imageIndex = 8;
			selectedImageIndex = 9;
			break;
		case GlobalData.ENUM_TASK_TYPE.enumTTKeyOld:
			imageIndex = 0;
			selectedImageIndex = 1;
			break;
		case GlobalData.ENUM_TASK_TYPE.enumTTBossOld:
			imageIndex = 0;
			selectedImageIndex = 1;
			break;
		case GlobalData.ENUM_TASK_TYPE.enumTTInstanceOld:
			imageIndex = 0;
			selectedImageIndex = 1;
			break;
		case GlobalData.ENUM_TASK_TYPE.enumTTScrollOld:
			imageIndex = 0;
			selectedImageIndex = 1;
			break;
		case GlobalData.ENUM_TASK_TYPE.enumTTBusinessOld:
			imageIndex = 4;
			selectedImageIndex = 5;
			break;
		case GlobalData.ENUM_TASK_TYPE.enumTTFeelingOld:
			imageIndex = 0;
			selectedImageIndex = 1;
			break;
		case GlobalData.ENUM_TASK_TYPE.enumTTTacticsOld:
			imageIndex = 0;
			selectedImageIndex = 1;
			break;
		case GlobalData.ENUM_TASK_TYPE.enumTTRegionOld:
			imageIndex = 6;
			selectedImageIndex = 7;
			break;
		case GlobalData.ENUM_TASK_TYPE.enumTTSevenKillListOld:
			imageIndex = 0;
			selectedImageIndex = 1;
			break;
		case GlobalData.ENUM_TASK_TYPE.enumTTFactionOld:
			imageIndex = 6;
			selectedImageIndex = 7;
			break;
		case GlobalData.ENUM_TASK_TYPE.enumTTHintOld:
			imageIndex = 0;
			selectedImageIndex = 1;
			break;
		}
		if (ataskTempl_0.m_bKeyTask)
		{
			foreColor = Color.FromArgb(238, 156, 15);
			if (GlobalData.version >= 156)
			{
				imageIndex = 14;
				selectedImageIndex = 15;
			}
			else
			{
				imageIndex = 2;
				selectedImageIndex = 3;
			}
		}
		if (ataskTempl_0.m_bGM)
		{
			imageIndex = GMIconIndex;
			selectedImageIndex = GMIconIndex;
		}
		if (ataskTempl_0.m_bDiscardedTask && DisabledIconIndex >= 0)
		{
			imageIndex = DisabledIconIndex;
			selectedImageIndex = DisabledIconIndex;
		}
		if (name.StartsWith(Class16.smethod_0(1648935659)))
		{
			try
			{
				if (GlobalData.version <= 119 || ((ataskTempl_0.m_ulType == 105 || ataskTempl_0.m_ulType == 110) && !ataskTempl_0.m_bKeyTask))
				{
					foreColor = ((!int.TryParse(name.Substring(1, 6), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out var result)) ? Color.White : Color.FromArgb(result));
				}
			}
			catch
			{
				foreColor = Color.White;
			}
		}
		if (ataskTempl_0.IsDuplicateId)
		{
			foreColor = Color.Red;
			try
			{
				treeNode_0.NodeFont = new Font((treeNode_0.TreeView != null) ? treeNode_0.TreeView.Font : SystemFonts.DefaultFont, FontStyle.Bold);
			}
			catch
			{
			}
		}
		if (UpdateType != 1)
		{
			if (ataskTempl_0.IsDuplicateId)
			{
				treeNode_0.Text = ataskTempl_0.m_ID + Class16.smethod_0(1649403680) + ColorClean(name);
			}
			else
			{
				treeNode_0.Text = ataskTempl_0.m_ID + Class16.smethod_0(1648942627) + ColorClean(name);
			}
		}
		treeNode_0.ForeColor = foreColor;
		treeNode_0.ImageIndex = imageIndex;
		treeNode_0.SelectedImageIndex = selectedImageIndex;
	}

	public static int GetMaxTimetableSize(int version)
	{
		if (version < 69)
		{
			return 12;
		}
		return 24;
	}

	public static int GetMaxTaskRegion(int version)
	{
		if (version < 175)
		{
			return 8;
		}
		return 16;
	}

	public static int GetMaxPremTaskCount(int version)
	{
		if (version < 90)
		{
			return 5;
		}
		return 20;
	}

	public static int GetMaxOccupations(int version)
	{
		if (version < 89)
		{
			return 8;
		}
		if (version < 120)
		{
			return 10;
		}
		if (version < 147)
		{
			return 12;
		}
		if (version < 187)
		{
			return 14;
		}
		if (version < 195)
		{
			return 15;
		}
		if (version < 216)
		{
			return 16;
		}
		if (version < 240)
		{
			return 17;
		}
		return 18;
	}

	public static int GetMaxTeamMemWanted(int version)
	{
		if (version < 89)
		{
			return 8;
		}
		if (version < 120)
		{
			return 10;
		}
		if (version < 147)
		{
			return 12;
		}
		if (version < 195)
		{
			return 15;
		}
		if (version < 216)
		{
			return 16;
		}
		if (version < 240)
		{
			return 17;
		}
		return 18;
	}

	public static int GetMaxPlayerWanted(int version)
	{
		if (version < 135)
		{
			return 3;
		}
		return 6;
	}

	public static int GetMaxMonsterWanted(int version)
	{
		if (version < 135)
		{
			return 3;
		}
		return 6;
	}

	public static uint GetMaxMonsterUnwanted(int version, uint value)
	{
		if ((long)value < 6L)
		{
			return value;
		}
		return 6u;
	}

	public static int GetMaxAwardScales(int version)
	{
		if (version < 140)
		{
			return 5;
		}
		return 6;
	}

	public static int GetMaxMutexTasks(int version)
	{
		if (version < 215)
		{
			return 5;
		}
		return 20;
	}

	public static int GetMaxNeededTasks(int version)
	{
		if (version < 215)
		{
			return 5;
		}
		return 20;
	}

	public static int GetCombinedSwitches(int version)
	{
		return GlobalData.TaskParameterManager.GetCombinedSwitchesCount(version);
	}

	public static int GetMaxAwardCandidates(int version)
	{
		if (version < 89)
		{
			return 8;
		}
		if (version < 120)
		{
			return 10;
		}
		if (version < 164)
		{
			return 12;
		}
		return 999;
	}

	public static bool CheckFlag(int value, int flag)
	{
		return (value & flag) != 0;
	}

	public static bool ChckPrm(int version, byte[] combined_switches, int param)
	{
		if (!GlobalData.TaskParameterManager.IsParameterValidForVersion(version, (GlobalData.TaskParameters)param))
		{
			return false;
		}
		int parameterIndex = GlobalData.TaskParameterManager.GetParameterIndex(version, (GlobalData.TaskParameters)param);
		if (parameterIndex < 0)
		{
			return false;
		}
		int num = Convert.ToInt32(Math.Truncate((float)parameterIndex / 8f));
		int num2 = 1 << parameterIndex - 8 * num;
		return (combined_switches[num] & num2) != 0;
	}

	public static void SetParam(int version, byte[] combined_switches, int param, bool param_val)
	{
		if (param_val && GlobalData.TaskParameterManager.IsParameterValidForVersion(version, (GlobalData.TaskParameters)param))
		{
			int parameterIndex = GlobalData.TaskParameterManager.GetParameterIndex(version, (GlobalData.TaskParameters)param);
			if (parameterIndex >= 0)
			{
				int num = Convert.ToInt32(Math.Truncate((float)parameterIndex / 8f));
				int num2 = 1 << parameterIndex - 8 * num;
				combined_switches[num] += (byte)num2;
			}
		}
	}
}
