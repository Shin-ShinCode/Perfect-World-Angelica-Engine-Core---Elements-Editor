using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using ACE.Classes;
using ACE.Elements;
using ACE.Elements.eListCollection;
using ACE.MainWindow;
using ACE.NpcGen.Classes;
using ACE.NpcGen.Import;
using ACE.NpcGen.LBLIBRARY;
using ACE.NpcGen.NpcLiveEditor;
using ACE.Pck;
using ACE.Properties;
using ACE.RSGlobal;
using Newtonsoft.Json;

namespace ACE.NpcGen.NPCGenEditorForm;

public class NPCGenEditorForm : Form
{
	private sealed class Class255
	{
		public IntDictionary intDictionary_0;

		internal bool method_0(int int_0)
		{
			return int_0 == intDictionary_0.GridIndex;
		}
	}

	private sealed class Class256
	{
		public IntDictionary intDictionary_0;

		internal bool method_0(IntDictionary intDictionary_1)
		{
			return intDictionary_1.ErrorInex == intDictionary_0.ErrorInex;
		}
	}

	private sealed class Class257
	{
		public List<IntDictionary> list_0;

		internal void method_0(IntDictionary intDictionary_0)
		{
			intDictionary_0.ErrorInex -= list_0.Count;
		}
	}

	private sealed class Class258
	{
		public int int_0;

		internal bool method_0(_003C_003Ef__AnonymousType149<ClassDynamicObject, int> _003C_003Ef__AnonymousType149_0)
		{
			return _003C_003Ef__AnonymousType149_0.Item.Id == int_0;
		}
	}

	private sealed class Class259
	{
		public string string_0;

		internal bool method_0(GameMapInfo gameMapInfo_0)
		{
			return string.Equals(gameMapInfo_0.MapName, string_0, StringComparison.OrdinalIgnoreCase);
		}
	}

	private sealed class Class260
	{
		public int int_0;

		internal bool method_0(_003C_003Ef__AnonymousType149<ClassDynamicObject, int> _003C_003Ef__AnonymousType149_0)
		{
			return _003C_003Ef__AnonymousType149_0.Item.TriggerId == int_0;
		}
	}

	private sealed class Class261
	{
		public IntDictionary intDictionary_0;

		internal bool method_0(int int_0)
		{
			return int_0 == intDictionary_0.GridIndex;
		}
	}

	private sealed class Class262
	{
		public int int_0;

		public Predicate<IntDictionary> predicate_0;

		internal bool method_0(IntDictionary intDictionary_0)
		{
			return intDictionary_0.ErrorInex == int_0;
		}
	}

	private sealed class Class263
	{
		public int int_0;

		internal bool method_0(DefaultInformation defaultInformation_0)
		{
			return defaultInformation_0.Id == int_0;
		}
	}

	private sealed class Class264
	{
		public List<IntDictionary> list_0;

		internal void method_0(IntDictionary intDictionary_0)
		{
			intDictionary_0.ErrorInex -= list_0.Count;
		}

		internal void method_1(IntDictionary intDictionary_0)
		{
			intDictionary_0.ErrorInex -= list_0.Count;
		}

		internal void method_2(IntDictionary intDictionary_0)
		{
			intDictionary_0.ErrorInex -= list_0.Count;
		}
	}

	private sealed class Class265
	{
		public int int_0;

		internal bool method_0(_003C_003Ef__AnonymousType149<ClassTrigger, int> _003C_003Ef__AnonymousType149_0)
		{
			return _003C_003Ef__AnonymousType149_0.Item.GmID == int_0;
		}
	}

	private sealed class Class266
	{
		public int int_0;

		internal bool method_0(IntDictionary intDictionary_0)
		{
			return intDictionary_0.GridIndex == int_0;
		}

		internal bool method_1(IntDictionary intDictionary_0)
		{
			return intDictionary_0.GridIndex > int_0;
		}

		internal bool method_2(IntDictionary intDictionary_0)
		{
			return intDictionary_0.GridIndex > int_0;
		}
	}

	private sealed class Class267
	{
		public NPCGenEditorForm npcgenEditorForm_0;

		public int int_0;

		public int int_1;

		public int int_2;

		public Predicate<ClassTrigger> predicate_0;

		public Predicate<ClassTrigger> predicate_1;

		internal bool method_0(ClassTrigger classTrigger_0)
		{
			return classTrigger_0.Id == npcgenEditorForm_0.npcGen_0.NpcMobList[int_0].Trigger_id;
		}

		internal bool method_1(ClassTrigger classTrigger_0)
		{
			return classTrigger_0.Id == npcgenEditorForm_0.npcGen_0.ResourcesList[int_1].Trigger_id;
		}

		internal bool method_2(ClassTrigger classTrigger_0)
		{
			return classTrigger_0.Id == npcgenEditorForm_0.npcGen_0.DynamicsList[int_2].TriggerId;
		}
	}

	private sealed class Class268
	{
		public NPCGenEditorForm npcgenEditorForm_0;

		public int int_0;

		internal void method_0()
		{
			npcgenEditorForm_0.method_16(npcgenEditorForm_0.list_8[int_0].MapFragments, npcgenEditorForm_0.list_8[int_0].MapName);
		}
	}

	private static class Class269
	{
		public static Func<string, bool> func_0;

		public static Func<string, bool> func_1;
	}

	private sealed class Class270
	{
		public List<IntDictionary> list_0;

		internal void method_0(IntDictionary intDictionary_0)
		{
			intDictionary_0.ErrorInex -= list_0.Count;
		}

		internal void method_1(IntDictionary intDictionary_0)
		{
			intDictionary_0.ErrorInex -= list_0.Count;
		}
	}

	private sealed class Class271
	{
		public int int_0;

		internal bool method_0(DefaultInformation defaultInformation_0)
		{
			return defaultInformation_0.Id == int_0;
		}
	}

	private sealed class Class272
	{
		public int int_0;

		internal bool method_0(_003C_003Ef__AnonymousType149<ClassDefaultMonsters, int> _003C_003Ef__AnonymousType149_0)
		{
			return _003C_003Ef__AnonymousType149_0.Item.MobDops.Any(method_1);
		}

		internal bool method_1(ClassExtraMonsters classExtraMonsters_0)
		{
			return classExtraMonsters_0.Path == int_0;
		}
	}

	private sealed class Class273
	{
		public GameMapInfo gameMapInfo_0;

		internal bool method_0(string string_0)
		{
			return string_0 == gameMapInfo_0.MapPath;
		}

		internal bool method_1(string string_0)
		{
			return string_0.Contains(gameMapInfo_0.MapPath);
		}
	}

	private sealed class Class274
	{
		public NPCGenEditorForm npcgenEditorForm_0;

		public int int_0;

		public Predicate<ClassDefaultMonsters> predicate_0;

		public Predicate<ClassDefaultResources> predicate_1;

		public Predicate<ClassDynamicObject> predicate_2;

		internal bool method_0(ClassDefaultMonsters classDefaultMonsters_0)
		{
			return classDefaultMonsters_0.Trigger_id == npcgenEditorForm_0.npcGen_0.TriggersList[int_0].Id;
		}

		internal bool method_1(ClassDefaultResources classDefaultResources_0)
		{
			return classDefaultResources_0.Trigger_id == npcgenEditorForm_0.npcGen_0.TriggersList[int_0].Id;
		}

		internal bool method_2(ClassDynamicObject classDynamicObject_0)
		{
			return classDynamicObject_0.TriggerId == npcgenEditorForm_0.npcGen_0.TriggersList[int_0].Id;
		}
	}

	private sealed class Class275
	{
		public int int_0;

		internal bool method_0(_003C_003Ef__AnonymousType149<ClassDefaultMonsters, int> _003C_003Ef__AnonymousType149_0)
		{
			return _003C_003Ef__AnonymousType149_0.Item.MobDops.Any(method_1);
		}

		internal bool method_1(ClassExtraMonsters classExtraMonsters_0)
		{
			return classExtraMonsters_0.Id == int_0;
		}
	}

	private sealed class Class276
	{
		public int int_0;

		internal bool method_0(IntDictionary intDictionary_0)
		{
			return intDictionary_0.GridIndex == int_0;
		}

		internal bool method_1(IntDictionary intDictionary_0)
		{
			return intDictionary_0.GridIndex > int_0;
		}

		internal bool method_2(IntDictionary intDictionary_0)
		{
			return intDictionary_0.GridIndex > int_0;
		}
	}

	private sealed class Class277
	{
		public int int_0;

		public Predicate<IntDictionary> predicate_0;

		internal bool method_0(IntDictionary intDictionary_0)
		{
			return intDictionary_0.ErrorInex == int_0;
		}
	}

	private sealed class Class278
	{
		public int int_0;

		internal bool method_0(_003C_003Ef__AnonymousType149<ClassDefaultResources, int> _003C_003Ef__AnonymousType149_0)
		{
			return _003C_003Ef__AnonymousType149_0.Item.ResExtra.Any(method_1);
		}

		internal bool method_1(ClassExtraResources classExtraResources_0)
		{
			return classExtraResources_0.Id == int_0;
		}
	}

	private sealed class Class279
	{
		public ClassDynamicObject classDynamicObject_0;

		internal bool method_0(DefaultInformation defaultInformation_0)
		{
			return defaultInformation_0.Id == classDynamicObject_0.Id;
		}
	}

	private enum Enum19
	{

	}

	private sealed class Class280
	{
		public int int_0;

		internal bool method_0(IntDictionary intDictionary_0)
		{
			return intDictionary_0.GridIndex == int_0;
		}

		internal bool method_1(IntDictionary intDictionary_0)
		{
			return intDictionary_0.GridIndex > int_0;
		}

		internal bool method_2(IntDictionary intDictionary_0)
		{
			return intDictionary_0.GridIndex > int_0;
		}
	}

	private sealed class Class281
	{
		public int int_0;

		internal bool method_0(ClassTrigger classTrigger_0)
		{
			return classTrigger_0.GmID == int_0;
		}
	}

	private sealed class Class282
	{
		public int int_0;

		internal bool method_0(_003C_003Ef__AnonymousType149<ClassDefaultResources, int> _003C_003Ef__AnonymousType149_0)
		{
			return _003C_003Ef__AnonymousType149_0.Item.Trigger_id == int_0;
		}
	}

	private sealed class Class283
	{
		public IntDictionary intDictionary_0;

		internal bool method_0(IntDictionary intDictionary_1)
		{
			return intDictionary_1.ErrorInex == intDictionary_0.ErrorInex;
		}
	}

	private sealed class Class284
	{
		public string string_0;

		public NPCGenEditorForm npcgenEditorForm_0;

		public List<PCKFileEntry> list_0;

		public Bitmap bitmap_0;

		public Action action_0;

		internal bool method_0(MapLoadedInformation mapLoadedInformation_0)
		{
			return mapLoadedInformation_0.Name == string_0;
		}

		internal void method_1()
		{
			npcgenEditorForm_0.progressBar_1.Maximum = Math.Max(1, list_0.Count);
			npcgenEditorForm_0.progressBar_1.Value = 0;
		}

		internal void method_2()
		{
			if (!npcgenEditorForm_0.progressBar_1.IsDisposed)
			{
				npcgenEditorForm_0.progressBar_1.Value = Math.Min(npcgenEditorForm_0.progressBar_1.Value + 1, npcgenEditorForm_0.progressBar_1.Maximum);
			}
		}

		internal void method_3()
		{
			npcgenEditorForm_0.progressBar_1.Value = 0;
			if (npcgenEditorForm_0.showLocationWindow_0 == null)
			{
				npcgenEditorForm_0.showLocationWindow_0 = new ShowLocationWindow(npcgenEditorForm_0, bitmap_0);
				npcgenEditorForm_0.showLocationWindow_0.Show(npcgenEditorForm_0);
			}
			else if (!npcgenEditorForm_0.showLocationWindow_0.Visible)
			{
				npcgenEditorForm_0.showLocationWindow_0 = new ShowLocationWindow(npcgenEditorForm_0, bitmap_0);
				npcgenEditorForm_0.showLocationWindow_0.Show(npcgenEditorForm_0);
			}
			else
			{
				npcgenEditorForm_0.showLocationWindow_0.SetPicture(bitmap_0);
			}
		}
	}

	private sealed class Class285
	{
		public IntDictionary intDictionary_0;

		internal bool method_0(int int_0)
		{
			return int_0 == intDictionary_0.GridIndex;
		}
	}

	private sealed class Class286
	{
		public int int_0;

		internal bool method_0(ClassTrigger classTrigger_0)
		{
			return classTrigger_0.Id == int_0;
		}
	}

	private sealed class Class287
	{
		public int int_0;

		internal bool method_0(_003C_003Ef__AnonymousType149<ClassDefaultMonsters, int> _003C_003Ef__AnonymousType149_0)
		{
			return _003C_003Ef__AnonymousType149_0.Item.Trigger_id == int_0;
		}
	}

	private sealed class Class288
	{
		public int int_0;

		internal bool method_0(DefaultInformation defaultInformation_0)
		{
			return defaultInformation_0.Id == int_0;
		}
	}

	[Serializable]
	private sealed class Class289
	{
		public static readonly Class289 class289_0 = new Class289();

		public static Func<int, int> func_0;

		public static Func<int, int> func_1;

		public static Func<int, int> func_2;

		public static Func<IntDictionary, int> func_3;

		public static Func<IntDictionary, int> func_4;

		public static Func<IntDictionary, int> func_5;

		public static Func<int, int> func_6;

		public static Func<IntDictionary, int> func_7;

		public static Action<IntDictionary> action_0;

		public static Func<IntDictionary, int> func_8;

		public static Func<IntDictionary, int> func_9;

		public static Func<int, int> func_10;

		public static Func<IntDictionary, int> func_11;

		public static Action<IntDictionary> action_1;

		public static Func<IntDictionary, int> func_12;

		public static Func<IntDictionary, int> func_13;

		public static Func<IntDictionary, int> func_14;

		public static Func<int, int> func_15;

		public static Func<string, bool> func_16;

		public static Func<string, string> func_17;

		public static Func<string, PCKFileEntry> func_18;

		public static Func<string, PCKFileEntry> func_19;

		public static Func<GameMapInfo, string> func_20;

		public static Func<string, bool> func_21;

		public static Func<PCKFileEntry, string> func_22;

		public static Action action_2;

		public static Action action_3;

		public static Func<DataGridViewRow, int> func_23;

		public static Func<int, int> func_24;

		public static Func<int, int> func_25;

		public static Func<ClassTrigger, int> func_26;

		public static Func<ClassTrigger, int> func_27;

		public static Func<int, int> func_28;

		public static Func<IntDictionary, int> func_29;

		public static Action<IntDictionary> action_4;

		public static Func<IntDictionary, int> func_30;

		public static Func<IntDictionary, int> func_31;

		public static Func<int, int> func_32;

		public static Func<int, int> func_33;

		public static Func<int, int> func_34;

		public static Func<DataGridViewRow, int> func_35;

		public static Func<DataGridViewRow, int> func_36;

		public static Func<DataGridViewRow, int> func_37;

		public static Func<int, int> func_38;

		public static Func<ClassDynamicObject, int, _003C_003Ef__AnonymousType149<ClassDynamicObject, int>> func_39;

		public static Func<_003C_003Ef__AnonymousType149<ClassDynamicObject, int>, int> func_40;

		public static Func<ClassDynamicObject, int, _003C_003Ef__AnonymousType149<ClassDynamicObject, int>> func_41;

		public static Func<_003C_003Ef__AnonymousType149<ClassDynamicObject, int>, int> func_42;

		public static Func<DataGridViewRow, int> func_43;

		public static Func<int, int> func_44;

		public static Func<ClassDefaultMonsters, int, _003C_003Ef__AnonymousType149<ClassDefaultMonsters, int>> func_45;

		public static Func<_003C_003Ef__AnonymousType149<ClassDefaultMonsters, int>, int> func_46;

		public static Func<ClassDefaultMonsters, int, _003C_003Ef__AnonymousType149<ClassDefaultMonsters, int>> func_47;

		public static Func<_003C_003Ef__AnonymousType149<ClassDefaultMonsters, int>, int> func_48;

		public static Func<ClassDefaultMonsters, int, _003C_003Ef__AnonymousType149<ClassDefaultMonsters, int>> func_49;

		public static Func<_003C_003Ef__AnonymousType149<ClassDefaultMonsters, int>, int> func_50;

		public static Func<ClassTrigger, int, _003C_003Ef__AnonymousType149<ClassTrigger, int>> func_51;

		public static Func<_003C_003Ef__AnonymousType149<ClassTrigger, int>, int> func_52;

		public static Func<ClassTrigger, int, _003C_003Ef__AnonymousType149<ClassTrigger, int>> func_53;

		public static Func<_003C_003Ef__AnonymousType149<ClassTrigger, int>, int> func_54;

		public static Func<DataGridViewRow, int> func_55;

		public static Func<int, int> func_56;

		public static Func<DataGridViewRow, int> func_57;

		public static Func<DataGridViewRow, int> func_58;

		public static Func<DataGridViewRow, int> func_59;

		public static Func<ClassDefaultResources, int, _003C_003Ef__AnonymousType149<ClassDefaultResources, int>> func_60;

		public static Func<_003C_003Ef__AnonymousType149<ClassDefaultResources, int>, int> func_61;

		public static Func<ClassDefaultResources, int, _003C_003Ef__AnonymousType149<ClassDefaultResources, int>> func_62;

		public static Func<_003C_003Ef__AnonymousType149<ClassDefaultResources, int>, int> func_63;

		public static Func<string, string> func_64;

		internal int method_0(int int_0)
		{
			return int_0;
		}

		internal int method_1(int int_0)
		{
			return int_0;
		}

		internal int method_2(int int_0)
		{
			return int_0;
		}

		internal int method_3(IntDictionary intDictionary_0)
		{
			return intDictionary_0.GridIndex;
		}

		internal int method_4(IntDictionary intDictionary_0)
		{
			return intDictionary_0.GridIndex;
		}

		internal int method_5(IntDictionary intDictionary_0)
		{
			return intDictionary_0.GridIndex;
		}

		internal int method_6(int int_0)
		{
			return int_0;
		}

		internal int method_7(IntDictionary intDictionary_0)
		{
			return intDictionary_0.ErrorInex;
		}

		internal void method_8(IntDictionary intDictionary_0)
		{
			intDictionary_0.GridIndex--;
		}

		internal int method_9(IntDictionary intDictionary_0)
		{
			return intDictionary_0.ErrorInex;
		}

		internal int method_10(IntDictionary intDictionary_0)
		{
			return intDictionary_0.ErrorInex;
		}

		internal int method_11(int int_0)
		{
			return int_0;
		}

		internal int method_12(IntDictionary intDictionary_0)
		{
			return intDictionary_0.ErrorInex;
		}

		internal void method_13(IntDictionary intDictionary_0)
		{
			intDictionary_0.GridIndex--;
		}

		internal int method_14(IntDictionary intDictionary_0)
		{
			return intDictionary_0.ErrorInex;
		}

		internal int method_15(IntDictionary intDictionary_0)
		{
			return intDictionary_0.ErrorInex;
		}

		internal int method_16(IntDictionary intDictionary_0)
		{
			return intDictionary_0.ErrorInex;
		}

		internal int method_17(int int_0)
		{
			return int_0;
		}

		internal bool method_18(string string_0)
		{
			if (string_0.Contains(Class16.smethod_0(1649114142)))
			{
				return !string_0.Contains(Class16.smethod_0(1649114157));
			}
			return false;
		}

		internal string method_19(string string_0)
		{
			return string_0;
		}

		internal PCKFileEntry method_20(string string_0)
		{
			return new PCKFileEntry
			{
				Path = string_0
			};
		}

		internal PCKFileEntry method_21(string string_0)
		{
			return new PCKFileEntry
			{
				Path = string_0
			};
		}

		internal string method_22(GameMapInfo gameMapInfo_0)
		{
			return gameMapInfo_0.MapName;
		}

		internal bool method_23(string string_0)
		{
			return !string.IsNullOrWhiteSpace(string_0);
		}

		internal string method_24(PCKFileEntry pckfileEntry_0)
		{
			return pckfileEntry_0.Path;
		}

		internal void method_25()
		{
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649114179), Class16.smethod_0(1649114216)), Class16.smethod_0(1649115628), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		internal void method_26()
		{
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649114255)), Class16.smethod_0(1649115628), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		internal int method_27(DataGridViewRow dataGridViewRow_0)
		{
			return dataGridViewRow_0.Index;
		}

		internal int method_28(int int_0)
		{
			return int_0;
		}

		internal int method_29(int int_0)
		{
			return int_0;
		}

		internal int method_30(ClassTrigger classTrigger_0)
		{
			return classTrigger_0.Id;
		}

		internal int method_31(ClassTrigger classTrigger_0)
		{
			return classTrigger_0.GmID;
		}

		internal int method_32(int int_0)
		{
			return int_0;
		}

		internal int method_33(IntDictionary intDictionary_0)
		{
			return intDictionary_0.ErrorInex;
		}

		internal void method_34(IntDictionary intDictionary_0)
		{
			intDictionary_0.GridIndex--;
		}

		internal int method_35(IntDictionary intDictionary_0)
		{
			return intDictionary_0.ErrorInex;
		}

		internal int method_36(IntDictionary intDictionary_0)
		{
			return intDictionary_0.ErrorInex;
		}

		internal int method_37(int int_0)
		{
			return int_0;
		}

		internal int method_38(int int_0)
		{
			return int_0;
		}

		internal int method_39(int int_0)
		{
			return int_0;
		}

		internal int method_40(DataGridViewRow dataGridViewRow_0)
		{
			return dataGridViewRow_0.Index;
		}

		internal int method_41(DataGridViewRow dataGridViewRow_0)
		{
			return dataGridViewRow_0.Index;
		}

		internal int method_42(DataGridViewRow dataGridViewRow_0)
		{
			return dataGridViewRow_0.Index;
		}

		internal int method_43(int int_0)
		{
			return int_0;
		}

		internal _003C_003Ef__AnonymousType149<ClassDynamicObject, int> method_44(ClassDynamicObject classDynamicObject_0, int int_0)
		{
			return _003C_003Ef__AnonymousType149.Create(
				classDynamicObject_0,
				int_0
			);
		}

		internal int method_45(_003C_003Ef__AnonymousType149<ClassDynamicObject, int> _003C_003Ef__AnonymousType149_0)
		{
			return _003C_003Ef__AnonymousType149_0.Index;
		}

		internal _003C_003Ef__AnonymousType149<ClassDynamicObject, int> method_46(ClassDynamicObject classDynamicObject_0, int int_0)
		{
			return _003C_003Ef__AnonymousType149.Create(
				classDynamicObject_0,
				int_0
			);
		}

		internal int method_47(_003C_003Ef__AnonymousType149<ClassDynamicObject, int> _003C_003Ef__AnonymousType149_0)
		{
			return _003C_003Ef__AnonymousType149_0.Index;
		}

		internal int method_48(DataGridViewRow dataGridViewRow_0)
		{
			return dataGridViewRow_0.Index;
		}

		internal int method_49(int int_0)
		{
			return int_0;
		}

		internal _003C_003Ef__AnonymousType149<ClassDefaultMonsters, int> method_50(ClassDefaultMonsters classDefaultMonsters_0, int int_0)
		{
			return _003C_003Ef__AnonymousType149.Create(
				classDefaultMonsters_0,
				int_0
			);
		}

		internal int method_51(_003C_003Ef__AnonymousType149<ClassDefaultMonsters, int> _003C_003Ef__AnonymousType149_0)
		{
			return _003C_003Ef__AnonymousType149_0.Index;
		}

		internal _003C_003Ef__AnonymousType149<ClassDefaultMonsters, int> method_52(ClassDefaultMonsters classDefaultMonsters_0, int int_0)
		{
			return _003C_003Ef__AnonymousType149.Create(
				classDefaultMonsters_0,
				int_0
			);
		}

		internal int method_53(_003C_003Ef__AnonymousType149<ClassDefaultMonsters, int> _003C_003Ef__AnonymousType149_0)
		{
			return _003C_003Ef__AnonymousType149_0.Index;
		}

		internal _003C_003Ef__AnonymousType149<ClassDefaultMonsters, int> method_54(ClassDefaultMonsters classDefaultMonsters_0, int int_0)
		{
			return _003C_003Ef__AnonymousType149.Create(
				classDefaultMonsters_0,
				int_0
			);
		}

		internal int method_55(_003C_003Ef__AnonymousType149<ClassDefaultMonsters, int> _003C_003Ef__AnonymousType149_0)
		{
			return _003C_003Ef__AnonymousType149_0.Index;
		}

		internal _003C_003Ef__AnonymousType149<ClassTrigger, int> method_56(ClassTrigger classTrigger_0, int int_0)
		{
			return _003C_003Ef__AnonymousType149.Create(
				classTrigger_0,
				int_0
			);
		}

		internal int method_57(_003C_003Ef__AnonymousType149<ClassTrigger, int> _003C_003Ef__AnonymousType149_0)
		{
			return _003C_003Ef__AnonymousType149_0.Index;
		}

		internal _003C_003Ef__AnonymousType149<ClassTrigger, int> method_58(ClassTrigger classTrigger_0, int int_0)
		{
			return _003C_003Ef__AnonymousType149.Create(
				classTrigger_0,
				int_0
			);
		}

		internal int method_59(_003C_003Ef__AnonymousType149<ClassTrigger, int> _003C_003Ef__AnonymousType149_0)
		{
			return _003C_003Ef__AnonymousType149_0.Index;
		}

		internal int method_60(DataGridViewRow dataGridViewRow_0)
		{
			return dataGridViewRow_0.Index;
		}

		internal int method_61(int int_0)
		{
			return int_0;
		}

		internal int method_62(DataGridViewRow dataGridViewRow_0)
		{
			return dataGridViewRow_0.Index;
		}

		internal int method_63(DataGridViewRow dataGridViewRow_0)
		{
			return dataGridViewRow_0.Index;
		}

		internal int method_64(DataGridViewRow dataGridViewRow_0)
		{
			return dataGridViewRow_0.Index;
		}

		internal _003C_003Ef__AnonymousType149<ClassDefaultResources, int> method_65(ClassDefaultResources classDefaultResources_0, int int_0)
		{
			return _003C_003Ef__AnonymousType149.Create(
				classDefaultResources_0,
				int_0
			);
		}

		internal int method_66(_003C_003Ef__AnonymousType149<ClassDefaultResources, int> _003C_003Ef__AnonymousType149_0)
		{
			return _003C_003Ef__AnonymousType149_0.Index;
		}

		internal _003C_003Ef__AnonymousType149<ClassDefaultResources, int> method_67(ClassDefaultResources classDefaultResources_0, int int_0)
		{
			return _003C_003Ef__AnonymousType149.Create(
				classDefaultResources_0,
				int_0
			);
		}

		internal int method_68(_003C_003Ef__AnonymousType149<ClassDefaultResources, int> _003C_003Ef__AnonymousType149_0)
		{
			return _003C_003Ef__AnonymousType149_0.Index;
		}

		internal string method_69(string string_0)
		{
			return System.IO.Path.GetFileName(string_0);
		}
	}

	private sealed class Class290
	{
		public int int_0;

		internal bool method_0(ClassTrigger classTrigger_0)
		{
			return classTrigger_0.Id == int_0;
		}
	}

	private sealed class Class291
	{
		public int int_0;

		internal bool method_0(_003C_003Ef__AnonymousType149<ClassTrigger, int> _003C_003Ef__AnonymousType149_0)
		{
			return _003C_003Ef__AnonymousType149_0.Item.Id == int_0;
		}
	}

	private int int_0;

	private NumericUpDown numericUpDown_0;

	private NumericUpDown numericUpDown_1;

	private ComboBox comboBox_0;

	private NumericUpDown numericUpDown_2;

	private NumericUpDown numericUpDown_3;

	private NumericUpDown numericUpDown_4;

	private NumericUpDown numericUpDown_5;

	private ComboBox comboBox_1;

	private NumericUpDown numericUpDown_6;

	private NumericUpDown numericUpDown_7;

	private NumericUpDown numericUpDown_8;

	private NumericUpDown numericUpDown_9;

	private ComboBox comboBox_2;

	private bool bool_0 = true;

	private NumericUpDown numericUpDown_10;

	private NumericUpDown numericUpDown_11;

	private CheckBox checkBox_0;

	private CheckBox checkBox_1;

	private CheckBox checkBox_2;

	private CheckBox checkBox_3;

	private Button button_0;

	private CheckBox checkBox_4;

	private RadioButton radioButton_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_0;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_1;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_2;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_3;

	private IContainer icontainer_0;

	private ContextMenuStrip contextMenuStrip_0;

	private ContextMenuStrip contextMenuStrip_1;

	private Button button_1;

	private ComboBox comboBox_3;

	private RadioButton radioButton_1;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_4;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_5;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_6;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_7;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_8;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_9;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_10;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_11;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_12;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_13;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_14;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_15;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_16;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_17;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_18;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_19;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_20;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_21;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_22;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_23;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_24;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_25;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_26;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_27;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_28;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_29;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_30;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_31;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_32;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_33;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_34;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_35;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn_36;

	private NumericUpDown numericUpDown_12;

	private NumericUpDown numericUpDown_13;

	private ComboBox comboBox_4;

	private ComboBox comboBox_5;

	private ComboBox comboBox_6;

	private ToolStripMenuItem toolStripMenuItem_0;

	private TextBox textBox_0;

	private TextBox textBox_1;

	private TextBox textBox_2;

	private ToolStripMenuItem toolStripMenuItem_1;

	private ToolStripMenuItem toolStripMenuItem_2;

	private TextBox textBox_3;

	private TextBox textBox_4;

	private TextBox textBox_5;

	private DataGridView dataGridView_0;

	private TextBox textBox_6;

	private TextBox textBox_7;

	private TextBox textBox_8;

	private DynamicObjectsForm dynamicObjectsForm_0;

	private DataGridView dataGridView_1;

	private PictureBox pictureBox_0;

	private int int_1;

	private OpenFileDialog openFileDialog_0;

	private List<ClassDynamicObject> list_0;

	private Keys keys_0;

	private Button button_2;

	private TextBox textBox_9;

	private RadioButton radioButton_2;

	private TextBox textBox_10;

	private RadioButton radioButton_3;

	private TextBox textBox_11;

	private RadioButton radioButton_4;

	private Keys keys_1;

	private List<DefaultInformation> list_1;

	private List<DefaultInformation> list_2;

	private List<int> list_3;

	private Button button_3;

	private Button button_4;

	private Button button_5;

	private TabPage tabPage_0;

	private TextBox textBox_12;

	private OpenFileDialog openFileDialog_1;

	private List<IntDictionary> list_4 = new List<IntDictionary>();

	private List<IntDictionary> list_5 = new List<IntDictionary>();

	private List<IntDictionary> list_6 = new List<IntDictionary>();

	private DataGridView dataGridView_2;

	private TabPage tabPage_1;

	private CheckBox checkBox_5;

	private Button button_6;

	private ContextMenuStrip contextMenuStrip_2;

	private Button button_7;

	private Button button_8;

	private CheckBox checkBox_6;

	private Button button_9;

	private ComboBox comboBox_7;

	private Button button_10;

	private Button button_11;

	private TextBox textBox_13;

	private RadioButton radioButton_5;

	private TextBox textBox_14;

	private RadioButton radioButton_6;

	private TextBox textBox_15;

	private RadioButton radioButton_7;

	private TextBox textBox_16;

	private RadioButton radioButton_8;

	private TabPage tabPage_2;

	private ToolStripMenuItem toolStripMenuItem_3;

	private ToolStrip toolStrip_0;

	private ComboBox comboBox_8;

	private ToolStripButton toolStripButton_0;

	private ToolStripButton toolStripButton_1;

	private ComboBox comboBox_9;

	private ComboBox comboBox_10;

	private ComboBox comboBox_11;

	private Button button_12;

	private Button button_13;

	private Button button_14;

	private TextBox textBox_17;

	private NumericUpDown numericUpDown_14;

	private TextBox textBox_18;

	private GroupBox groupBox_0;

	private GroupBox groupBox_1;

	private GroupBox groupBox_2;

	private GroupBox groupBox_3;

	private GroupBox groupBox_4;

	private GroupBox groupBox_5;

	private GroupBox groupBox_6;

	private GroupBox groupBox_7;

	private GroupBox groupBox_8;

	private GroupBox groupBox_9;

	private GroupBox groupBox_10;

	private GroupBox groupBox_11;

	private GroupBox groupBox_12;

	private GroupBox groupBox_13;

	private GroupBox groupBox_14;

	private GroupBox groupBox_15;

	private GroupBox groupBox_16;

	private GroupBox groupBox_17;

	private GroupBox groupBox_18;

	private GroupBox groupBox_19;

	private NumericUpDown numericUpDown_15;

	private TextBox textBox_19;

	private ToolStripButton toolStripButton_2;

	private ToolStripButton toolStripButton_3;

	private int int_2 = 1;

	private Label label_0;

	private Label label_1;

	private Label label_2;

	private Label label_3;

	private Label label_4;

	private Label label_5;

	private Label label_6;

	private Label label_7;

	private Label label_8;

	private Label label_9;

	private Label label_10;

	private Label label_11;

	private Label label_12;

	private Label label_13;

	private Label label_14;

	private Label label_15;

	private Label label_16;

	private Label label_17;

	private Label label_18;

	private Label label_19;

	private Label label_20;

	private Label label_21;

	private Label label_22;

	private Label label_23;

	private Label label_24;

	private Label label_25;

	private Label label_26;

	private Label label_27;

	private Label label_28;

	private Label label_29;

	private Label label_30;

	private Label label_31;

	private Label label_32;

	private Label label_33;

	private Label label_34;

	private Label label_35;

	private Label label_36;

	private Label label_37;

	private Label label_38;

	private Label label_39;

	private Label label_40;

	private Label label_41;

	private Label label_42;

	private Label label_43;

	private Label label_44;

	private Label label_45;

	private Label label_46;

	private Label label_47;

	private Label label_48;

	private Label label_49;

	private Label label_50;

	private Label label_51;

	private Label label_52;

	private Label label_53;

	private Label label_54;

	private Label label_55;

	private Label label_56;

	private Label label_57;

	private Label label_58;

	private Label label_59;

	private Label label_60;

	private Label label_61;

	private Label label_62;

	private Label label_63;

	private Label label_64;

	private Label label_65;

	private Label label_66;

	private Label label_67;

	private Label label_68;

	private Label label_69;

	private Label label_70;

	private Label label_71;

	private Label label_72;

	private Label label_73;

	private Label label_74;

	private Label label_75;

	private Label label_76;

	private Label label_77;

	private Label label_78;

	private Label label_79;

	private Label label_80;

	private Label label_81;

	private Label label_82;

	private Label label_83;

	private Label label_84;

	private Label label_85;

	private Label label_86;

	private Label label_87;

	private Label label_88;

	private Label label_89;

	private Label label_90;

	private Label label_91;

	private Label label_92;

	private Label label_93;

	private Label label_94;

	private Label label_95;

	private Label label_96;

	private Label label_97;

	private Label label_98;

	private Label label_99;

	private Label label_100;

	private Label label_101;

	private Label label_102;

	private Label label_103;

	private Label label_104;

	private Label label_105;

	private Label label_106;

	private Label label_107;

	private TextBox textBox_20;

	private ToolStripDropDownButton toolStripDropDownButton_0;

	private ToolStripDropDownButton toolStripDropDownButton_1;

	private ToolStripMenuItem toolStripMenuItem_4;

	private ToolStripMenuItem toolStripMenuItem_5;

	private List<MapLoadedInformation> list_7;

	private GroupBox groupBox_20;

	private ProgressBar progressBar_0;

	private TabControl tabControl_0;

	private ShowLocationWindow showLocationWindow_0;

	private ProgressBar progressBar_1;

	private List<GameMapInfo> list_8;

	private ComboBox comboBox_12;

	private List<ClassDefaultMonsters> list_9;

	private Keys keys_2;

	private Keys keys_3;

	private ToolStripMenuItem toolStripMenuItem_6;

	private ToolStripDropDownButton toolStripDropDownButton_2;

	private ToolStripDropDownButton toolStripDropDownButton_3;

	private ToolStripMenuItem toolStripMenuItem_7;

	private ToolStripMenuItem toolStripMenuItem_8;

	private ToolStripMenuItem toolStripMenuItem_9;

	private DataGridView dataGridView_3;

	private NumericUpDown numericUpDown_16;

	private OpenFileDialog openFileDialog_2;

	private SaveFileDialog saveFileDialog_0;

	private TextBox textBox_21;

	private int int_3;

	private DataGridView dataGridView_4;

	private List<int> list_10;

	private int int_4;

	private DataGridView dataGridView_5;

	private Button button_15;

	private TabPage tabPage_3;

	private NumericUpDown numericUpDown_17;

	private NumericUpDown numericUpDown_18;

	private ComboBox comboBox_13;

	private NumericUpDown numericUpDown_19;

	private CheckBox checkBox_7;

	private TextBox textBox_22;

	private ACE.NpcGen.Classes.NpcGen npcGen_0;

	private NumericUpDown numericUpDown_20;

	private Button button_16;

	private ToolStripMenuItem toolStripMenuItem_10;

	private CheckBox checkBox_8;

	private Button button_17;

	private List<ClassDefaultResources> list_11;

	private Keys keys_4;

	private Button button_18;

	private TextBox textBox_23;

	private RadioButton radioButton_9;

	private TextBox textBox_24;

	private RadioButton radioButton_10;

	private TextBox textBox_25;

	private RadioButton radioButton_11;

	private Keys keys_5;

	private DataGridView dataGridView_6;

	private Button button_19;

	private DataGridView dataGridView_7;

	private int int_5;

	private Button button_20;

	private CheckBox checkBox_9;

	private Button button_21;

	private ToolStripMenuItem toolStripMenuItem_11;

	private ToolStripMenuItem toolStripMenuItem_12;

	private Button button_22;

	private List<int> list_12;

	private int int_6;

	private TabPage tabPage_4;

	private ToolStripMenuItem toolStripMenuItem_13;

	private NumericUpDown numericUpDown_21;

	private NumericUpDown numericUpDown_22;

	private TextBox textBox_26;

	private NumericUpDown numericUpDown_23;

	private TextBox textBox_27;

	private TextBox textBox_28;

	private TextBox textBox_29;

	private NumericUpDown numericUpDown_24;

	private TextBox textBox_30;

	private TextBox textBox_31;

	private NumericUpDown numericUpDown_25;

	private DataGridView dataGridView_8;

	private TextBox textBox_32;

	private TextBox textBox_33;

	private TextBox textBox_34;

	private TextBox textBox_35;

	private TextBox textBox_36;

	private Button button_23;

	private Button button_24;

	private List<int> list_13;

	private Button button_25;

	private DataGridView dataGridView_9;

	private List<int> list_14;

	private List<int> list_15;

	private TabPage tabPage_5;

	private List<int> list_16;

	private TextBox textBox_37;

	private OpenFileDialog openFileDialog_3;

	private CheckBox checkBox_10;

	private TextBox textBox_38;

	private TextBox textBox_39;

	private TextBox textBox_40;

	private TextBox textBox_41;

	private ToolStrip toolStrip_1;

	private ToolStrip toolStrip_2;

	private ToolStrip toolStrip_3;

	private ToolStripButton toolStripButton_4;

	private ToolStripButton toolStripButton_5;

	private ToolStripButton toolStripButton_6;

	private ToolStripButton toolStripButton_7;

	private ToolStripButton toolStripButton_8;

	private ToolStripDropDownButton toolStripDropDownButton_4;

	private ToolStripDropDownButton toolStripDropDownButton_5;

	private ToolStripDropDownButton toolStripDropDownButton_6;

	private ToolStripMenuItem toolStripMenuItem_14;

	private ToolStripMenuItem toolStripMenuItem_15;

	private ToolStripMenuItem toolStripMenuItem_16;

	private ToolStripMenuItem toolStripMenuItem_17;

	private ToolStripMenuItem toolStripMenuItem_18;

	private ToolStripMenuItem toolStripMenuItem_19;

	private ToolStripMenuItem toolStripMenuItem_20;

	private ToolStripMenuItem toolStripMenuItem_21;

	private ToolStripMenuItem toolStripMenuItem_22;

	private ToolStripMenuItem toolStripMenuItem_23;

	private ToolStripMenuItem toolStripMenuItem_24;

	private ToolStripMenuItem toolStripMenuItem_25;

	private ToolStripSeparator toolStripSeparator_0;

	private ToolStripSeparator toolStripSeparator_1;

	private ToolStripSeparator toolStripSeparator_2;

	private ToolStripSeparator toolStripSeparator_3;

	private ToolTip toolTip_0;

	private TextBox textBox_42;

	private Button button_26;

	private ContextMenuStrip contextMenuStrip_3;

	private Button button_27;

	private TextBox textBox_43;

	private RadioButton radioButton_12;

	private TextBox textBox_44;

	private RadioButton radioButton_13;

	private TextBox textBox_45;

	private RadioButton radioButton_14;

	private DataGridView dataGridView_10;

	private Button button_28;

	private List<int> list_17;

	private int int_7;

	private TabPage tabPage_6;

	private CheckBox checkBox_11;

	private TextBox textBox_46;

	private TextBox textBox_47;

	private TextBox textBox_48;

	private TextBox textBox_49;

	private ComboBox comboBox_14;

	private TextBox textBox_50;

	private CheckBox checkBox_12;

	private TextBox textBox_51;

	private TextBox textBox_52;

	private TextBox textBox_53;

	private TextBox textBox_54;

	private ComboBox comboBox_15;

	private TextBox textBox_55;

	private NumericUpDown numericUpDown_26;

	private TextBox textBox_56;

	private TextBox textBox_57;

	private List<int> list_18;

	private List<int> list_19;

	private ToolStripMenuItem toolStripMenuItem_26;

	private ToolStripMenuItem toolStripMenuItem_27;

	private ComboBox comboBox_16;

	private NumericUpDown numericUpDown_27;

	private TextBox textBox_58;

	private TextBox textBox_59;

	private TextBox textBox_60;

	private TextBox textBox_61;

	private TextBox textBox_62;

	private TextBox textBox_63;

	private TextBox textBox_64;

	private TextBox textBox_65;

	private TextBox textBox_66;

	private ToolStripMenuItem toolStripMenuItem_28;

	private ToolStripMenuItem toolStripMenuItem_29;

	private ToolStripMenuItem toolStripMenuItem_30;

	private ToolStripMenuItem toolStripMenuItem_31;

	private PCK_LIST pck_LIST_0;

	public List<offsets> Offsets = new List<offsets>();

	private int int_8;

	private NpcLiveEditorForm npcLiveEditorForm_0;

	private ComboBox comboBox_17;

	private Button button_29;

	private FileBasedUndoManager fileBasedUndoManager_0;

	private bool bool_1;

	public PCK_LIST EditorPCKs
	{
		[CompilerGenerated]
		get
		{
			return pck_LIST_0;
		}
		[CompilerGenerated]
		set
		{
			pck_LIST_0 = value;
		}
	}

	public NPCGenEditorForm()
	{
		InitializeComponent();
		TDark.StoreOriginalColors(this);
		TDark.ApplyTheme(this);
		TextStorage.TEXTS.SetFormLanguage(this, null);
		if (base.IsHandleCreated)
		{
			TDark.ApplyImmersiveDarkMode(base.Handle, TDark.IsDarkMode);
		}
		TDark.ApplyNativeDarkThemeRecursive(this);
		groupBox_13.Visible = false;
		try
		{
			ACE.RSGlobal.RSGlobal.SetDoubleBuffered(dataGridView_4, value: true);
			ACE.RSGlobal.RSGlobal.SetDoubleBuffered(dataGridView_5, value: true);
			ACE.RSGlobal.RSGlobal.SetDoubleBuffered(dataGridView_6, value: true);
			ACE.RSGlobal.RSGlobal.SetDoubleBuffered(dataGridView_7, value: true);
			ACE.RSGlobal.RSGlobal.SetDoubleBuffered(dataGridView_1, value: true);
			ACE.RSGlobal.RSGlobal.SetDoubleBuffered(dataGridView_10, value: true);
			ACE.RSGlobal.RSGlobal.SetDoubleBuffered(dataGridView_9, value: true);
			ACE.RSGlobal.RSGlobal.SetDoubleBuffered(dataGridView_2, value: true);
			ACE.RSGlobal.RSGlobal.SetDoubleBuffered(dataGridView_3, value: true);
			ACE.RSGlobal.RSGlobal.SetDoubleBuffered(dataGridView_8, value: true);
			ACE.RSGlobal.RSGlobal.SetDoubleBuffered(dataGridView_0, value: true);
		}
		catch
		{
		}
		try
		{
			dataGridView_4.Scroll += dataGridView_0_Scroll;
			dataGridView_5.Scroll += dataGridView_0_Scroll;
			dataGridView_6.Scroll += dataGridView_0_Scroll;
			dataGridView_7.Scroll += dataGridView_0_Scroll;
			dataGridView_1.Scroll += dataGridView_0_Scroll;
			dataGridView_10.Scroll += dataGridView_0_Scroll;
			dataGridView_9.Scroll += dataGridView_0_Scroll;
			dataGridView_2.Scroll += dataGridView_0_Scroll;
			dataGridView_3.Scroll += dataGridView_0_Scroll;
			dataGridView_8.Scroll += dataGridView_0_Scroll;
			dataGridView_0.Scroll += dataGridView_0_Scroll;
		}
		catch
		{
		}
		try
		{
			KBDHook.LocalHook = false;
			KBDHook.KeyDown += method_15;
			KBDHook.InstallHook();
		}
		catch
		{
		}
		// TODO(recovered): offsets.txt (NpcGen live-editor memory offsets) ships with the original
		// editor but is absent in this deployment; reading it unguarded threw and aborted opening
		// the NpcGen editor. Skip gracefully when missing (live-editing offsets just won't populate).
		string npcOffsetsPath = System.IO.Path.Combine(Application.StartupPath, Class16.smethod_0(1649114280));
		if (!File.Exists(npcOffsetsPath))
		{
			return;
		}
		StreamReader streamReader = new StreamReader(npcOffsetsPath);
		while (!streamReader.EndOfStream)
		{
			string text = streamReader.ReadLine();
			if (text.StartsWith(Class16.smethod_0(1648936731)))
			{
				comboBox_16.Items.Add(text.Replace(Class16.smethod_0(1649114298), string.Empty));
				string[] array = streamReader.ReadLine().Split(' ');
				Offsets.Add(new offsets
				{
					baseChain = new long[3]
					{
						long.Parse(array[0], NumberStyles.HexNumber),
						long.Parse(array[1], NumberStyles.HexNumber),
						long.Parse(array[2], NumberStyles.HexNumber)
					},
					dirX = int.Parse(streamReader.ReadLine(), NumberStyles.HexNumber),
					dirY = int.Parse(streamReader.ReadLine(), NumberStyles.HexNumber),
					dirZ = int.Parse(streamReader.ReadLine(), NumberStyles.HexNumber),
					posX = int.Parse(streamReader.ReadLine(), NumberStyles.HexNumber),
					posY = int.Parse(streamReader.ReadLine(), NumberStyles.HexNumber),
					posZ = int.Parse(streamReader.ReadLine(), NumberStyles.HexNumber)
				});
			}
		}
	}

	private void button_7_Click(object sender, EventArgs e)
	{
		if (npcGen_0 == null)
		{
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649114318)), Class16.smethod_0(1649115628), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
		else if (dataGridView_4.Rows.Count > 0 && dataGridView_5.Rows.Count > 0)
		{
			if (list_18 == null)
			{
				list_18 = new List<int>();
			}
			list_18 = list_18.OrderBy(Class289.class289_0.method_0).ToList();
			foreach (int item2 in list_18)
			{
				npcGen_0.NpcMobList[int_4].Amount_in_group++;
				ClassExtraMonsters item = new ClassExtraMonsters
				{
					Agression = npcGen_0.NpcMobList[int_4].MobDops[item2].Agression,
					Amount = npcGen_0.NpcMobList[int_4].MobDops[item2].Agression,
					bFac_Accept = npcGen_0.NpcMobList[int_4].MobDops[item2].bFac_Accept,
					bFac_Helper = npcGen_0.NpcMobList[int_4].MobDops[item2].bFac_Helper,
					bFaction = npcGen_0.NpcMobList[int_4].MobDops[item2].bFaction,
					bNeedHelp = npcGen_0.NpcMobList[int_4].MobDops[item2].bNeedHelp,
					Dead_amount = npcGen_0.NpcMobList[int_4].MobDops[item2].Dead_amount,
					Dead_time = npcGen_0.NpcMobList[int_4].MobDops[item2].Dead_time,
					fOffsetTrn = npcGen_0.NpcMobList[int_4].MobDops[item2].fOffsetTrn,
					fOffsetWater = npcGen_0.NpcMobList[int_4].MobDops[item2].fOffsetWater,
					Group = npcGen_0.NpcMobList[int_4].MobDops[item2].Group,
					Group_help_Needer = npcGen_0.NpcMobList[int_4].MobDops[item2].Group_help_Needer,
					Group_help_sender = npcGen_0.NpcMobList[int_4].MobDops[item2].Group_help_sender,
					Id = npcGen_0.NpcMobList[int_4].MobDops[item2].Id,
					Path = npcGen_0.NpcMobList[int_4].MobDops[item2].Path,
					Path_type = npcGen_0.NpcMobList[int_4].MobDops[item2].Path_type,
					RefreshLower = npcGen_0.NpcMobList[int_4].MobDops[item2].RefreshLower,
					Respawn = npcGen_0.NpcMobList[int_4].MobDops[item2].Respawn,
					Speed = npcGen_0.NpcMobList[int_4].MobDops[item2].Speed
				};
				npcGen_0.NpcMobList[int_4].MobDops.Add(item);
				dataGridView_5.Rows.Add(npcGen_0.NpcMobList[int_4].Amount_in_group, dataGridView_5.Rows[item2].Cells[1].Value, dataGridView_5.Rows[item2].Cells[2].Value);
			}
			RefreshRowNpcAndMobs(int_4);
			dataGridView_5.ClearSelection();
			for (int i = 1; i <= list_18.Count; i++)
			{
				dataGridView_5.Rows[dataGridView_5.Rows.Count - i].Selected = true;
			}
			dataGridView_5.CurrentCell = dataGridView_5.Rows[dataGridView_5.Rows.Count - 1].Cells[1];
			dataGridView_5.FirstDisplayedScrollingRowIndex = dataGridView_5.Rows.Count - 1;
		}
		else
		{
			ClassExtraMonsters classExtraMonsters = new ClassExtraMonsters();
			npcGen_0.NpcMobList[int_4].Amount_in_group++;
			classExtraMonsters.Id = 16;
			classExtraMonsters.Amount = 1;
			classExtraMonsters.Respawn = 60;
			npcGen_0.NpcMobList[int_4].MobDops.Add(classExtraMonsters);
			dataGridView_5.Rows.Add(1, 16, Class16.smethod_0(1649114342));
			RefreshRowNpcAndMobs(int_4);
			dataGridView_5_CurrentCellChanged(null, null);
		}
	}

	private void button_19_Click(object sender, EventArgs e)
	{
		if (npcGen_0 == null)
		{
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649114318)), Class16.smethod_0(1649115628), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
		else
		{
			if (dataGridView_6.Rows.Count <= 0)
			{
				return;
			}
			if (dataGridView_7.Rows.Count > 0)
			{
				list_19 = list_19.OrderBy(Class289.class289_0.method_1).ToList();
				foreach (int item2 in list_19)
				{
					npcGen_0.ResourcesList[int_6].Amount_in_group++;
					ClassExtraResources item = new ClassExtraResources
					{
						Id = npcGen_0.ResourcesList[int_6].ResExtra[item2].Id,
						Amount = npcGen_0.ResourcesList[int_6].ResExtra[item2].Amount,
						ResourceType = npcGen_0.ResourcesList[int_6].ResExtra[item2].ResourceType,
						Respawntime = npcGen_0.ResourcesList[int_6].ResExtra[item2].Respawntime,
						fHeiOff = npcGen_0.ResourcesList[int_6].ResExtra[item2].fHeiOff
					};
					npcGen_0.ResourcesList[int_6].ResExtra.Add(item);
					dataGridView_7.Rows.Add(npcGen_0.ResourcesList[int_6].Amount_in_group, dataGridView_7.Rows[item2].Cells[1].Value, dataGridView_7.Rows[item2].Cells[2].Value);
				}
				RefreshResourcesRow(int_6);
				dataGridView_7.ClearSelection();
				for (int i = 1; i <= list_19.Count; i++)
				{
					dataGridView_7.Rows[dataGridView_7.Rows.Count - i].Selected = true;
				}
				dataGridView_7.CurrentCell = dataGridView_7.Rows[dataGridView_7.Rows.Count - 1].Cells[1];
				dataGridView_7.FirstDisplayedScrollingRowIndex = dataGridView_7.Rows.Count - 1;
			}
			else
			{
				ClassExtraResources classExtraResources = new ClassExtraResources();
				npcGen_0.ResourcesList[int_6].Amount_in_group++;
				classExtraResources.Id = 3074;
				classExtraResources.Amount = 1;
				classExtraResources.Respawntime = 60;
				classExtraResources.ResourceType = 80;
				npcGen_0.ResourcesList[int_6].ResExtra.Add(classExtraResources);
				dataGridView_7.Rows.Add(1, 3074, Class16.smethod_0(1649114366));
				RefreshResourcesRow(int_6);
				dataGridView_7_CurrentCellChanged(null, null);
			}
		}
	}

	private void button_17_Click(object sender, EventArgs e)
	{
		if (npcGen_0 == null)
		{
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649114318)), Class16.smethod_0(1649115628), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			return;
		}
		if (dataGridView_6.Rows.Count > 0)
		{
			dataGridView_6.ScrollBars = ScrollBars.None;
			list_12 = list_12.OrderBy(Class289.class289_0.method_2).ToList();
			foreach (int item3 in list_12)
			{
				npcGen_0.ResourcesAmount++;
				ClassDefaultResources classDefaultResources = new ClassDefaultResources
				{
					Amount_in_group = npcGen_0.ResourcesList[item3].Amount_in_group,
					X_position = npcGen_0.ResourcesList[item3].X_position,
					Y_position = npcGen_0.ResourcesList[item3].Y_position,
					Z_position = npcGen_0.ResourcesList[item3].Z_position,
					bAutoRevive = npcGen_0.ResourcesList[item3].bAutoRevive,
					bInitGen = npcGen_0.ResourcesList[item3].bInitGen,
					bValidOnce = npcGen_0.ResourcesList[item3].bValidOnce,
					dwGenID = npcGen_0.ResourcesList[item3].dwGenID,
					IMaxNum = npcGen_0.ResourcesList[item3].IMaxNum,
					Trigger_id = npcGen_0.ResourcesList[item3].Trigger_id,
					InCline1 = npcGen_0.ResourcesList[item3].InCline1,
					X_Random = npcGen_0.ResourcesList[item3].X_Random,
					InCline2 = npcGen_0.ResourcesList[item3].InCline2,
					Z_Random = npcGen_0.ResourcesList[item3].Z_Random,
					Rotation = npcGen_0.ResourcesList[item3].Rotation,
					ResExtra = new List<ClassExtraResources>()
				};
				for (int i = 0; i < npcGen_0.ResourcesList[item3].Amount_in_group; i++)
				{
					ClassExtraResources item = new ClassExtraResources
					{
						Id = npcGen_0.ResourcesList[item3].ResExtra[i].Id,
						ResourceType = npcGen_0.ResourcesList[item3].ResExtra[i].ResourceType,
						Respawntime = npcGen_0.ResourcesList[item3].ResExtra[i].Respawntime,
						Amount = npcGen_0.ResourcesList[item3].ResExtra[i].Amount,
						fHeiOff = npcGen_0.ResourcesList[item3].ResExtra[i].fHeiOff
					};
					classDefaultResources.ResExtra.Add(item);
				}
				npcGen_0.ResourcesList.Add(classDefaultResources);
				dataGridView_6.Rows.Add(npcGen_0.ResourcesAmount, dataGridView_6.Rows[item3].Cells[1].Value, dataGridView_6.Rows[item3].Cells[2].Value);
			}
			dataGridView_6.ScrollBars = ScrollBars.Vertical;
			List<int> list = list_12;
			dataGridView_6.CurrentCell = dataGridView_6.Rows[dataGridView_6.Rows.Count - 1].Cells[1];
			for (int j = 1; j <= list.Count; j++)
			{
				dataGridView_6.Rows[dataGridView_6.Rows.Count - j].Selected = true;
			}
			dataGridView_6_CurrentCellChanged(null, null);
		}
		else
		{
			npcGen_0.ResourcesAmount++;
			ClassDefaultResources classDefaultResources2 = new ClassDefaultResources
			{
				Amount_in_group = 1,
				ResExtra = new List<ClassExtraResources>()
			};
			ClassExtraResources item2 = new ClassExtraResources
			{
				Id = 3074,
				Amount = 1,
				Respawntime = 60,
				ResourceType = 80
			};
			classDefaultResources2.ResExtra.Add(item2);
			npcGen_0.ResourcesList.Add(classDefaultResources2);
			dataGridView_6.Rows.Add(1, 3074, Class16.smethod_0(1649114366));
			dataGridView_6_CurrentCellChanged(null, null);
		}
		tabPage_4.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1649114378), Class16.smethod_0(1649114403)), npcGen_0.ResourcesAmount);
	}

	public void InitializeComponent()
	{
		this.icontainer_0 = new System.ComponentModel.Container();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle36 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle37 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle38 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle39 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle40 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle41 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle42 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle43 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle44 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle45 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle46 = new System.Windows.Forms.DataGridViewCellStyle();
		this.label_1 = new System.Windows.Forms.Label();
		this.textBox_21 = new System.Windows.Forms.TextBox();
		this.progressBar_0 = new System.Windows.Forms.ProgressBar();
		this.tabControl_0 = new System.Windows.Forms.TabControl();
		this.tabPage_2 = new System.Windows.Forms.TabPage();
		this.groupBox_0 = new System.Windows.Forms.GroupBox();
		this.numericUpDown_14 = new System.Windows.Forms.NumericUpDown();
		this.label_37 = new System.Windows.Forms.Label();
		this.numericUpDown_20 = new System.Windows.Forms.NumericUpDown();
		this.numericUpDown_12 = new System.Windows.Forms.NumericUpDown();
		this.checkBox_0 = new System.Windows.Forms.CheckBox();
		this.checkBox_2 = new System.Windows.Forms.CheckBox();
		this.checkBox_1 = new System.Windows.Forms.CheckBox();
		this.numericUpDown_16 = new System.Windows.Forms.NumericUpDown();
		this.checkBox_3 = new System.Windows.Forms.CheckBox();
		this.label_34 = new System.Windows.Forms.Label();
		this.numericUpDown_11 = new System.Windows.Forms.NumericUpDown();
		this.dataGridView_5 = new System.Windows.Forms.DataGridView();
		this.dataGridViewTextBoxColumn_26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_31 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_32 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.button_7 = new System.Windows.Forms.Button();
		this.label_33 = new System.Windows.Forms.Label();
		this.button_8 = new System.Windows.Forms.Button();
		this.numericUpDown_26 = new System.Windows.Forms.NumericUpDown();
		this.label_32 = new System.Windows.Forms.Label();
		this.numericUpDown_27 = new System.Windows.Forms.NumericUpDown();
		this.numericUpDown_17 = new System.Windows.Forms.NumericUpDown();
		this.numericUpDown_18 = new System.Windows.Forms.NumericUpDown();
		this.comboBox_13 = new System.Windows.Forms.ComboBox();
		this.comboBox_2 = new System.Windows.Forms.ComboBox();
		this.numericUpDown_13 = new System.Windows.Forms.NumericUpDown();
		this.numericUpDown_21 = new System.Windows.Forms.NumericUpDown();
		this.label_24 = new System.Windows.Forms.Label();
		this.numericUpDown_10 = new System.Windows.Forms.NumericUpDown();
		this.label_23 = new System.Windows.Forms.Label();
		this.numericUpDown_15 = new System.Windows.Forms.NumericUpDown();
		this.label_22 = new System.Windows.Forms.Label();
		this.label_30 = new System.Windows.Forms.Label();
		this.label_36 = new System.Windows.Forms.Label();
		this.label_25 = new System.Windows.Forms.Label();
		this.label_28 = new System.Windows.Forms.Label();
		this.label_27 = new System.Windows.Forms.Label();
		this.label_29 = new System.Windows.Forms.Label();
		this.label_26 = new System.Windows.Forms.Label();
		this.label_35 = new System.Windows.Forms.Label();
		this.dataGridView_4 = new System.Windows.Forms.DataGridView();
		this.dataGridViewTextBoxColumn_4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.contextMenuStrip_2 = new System.Windows.Forms.ContextMenuStrip(this.icontainer_0);
		this.toolStripMenuItem_4 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem_5 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripSeparator_0 = new System.Windows.Forms.ToolStripSeparator();
		this.toolStripMenuItem_16 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem_26 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem_1 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem_31 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem_31.Name = Class16.smethod_0(1649114425);
		this.toolStripMenuItem_31.Size = new System.Drawing.Size(180, 22);
		this.toolStripMenuItem_31.Text = Class16.smethod_0(1649063053);
		this.toolStripMenuItem_31.Click += new System.EventHandler(toolStripMenuItem_31_Click);
		this.toolStripSeparator_3 = new System.Windows.Forms.ToolStripSeparator();
		this.toolStripMenuItem_28 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem_3 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripSeparator_1 = new System.Windows.Forms.ToolStripSeparator();
		this.toolStripMenuItem_30 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem_29 = new System.Windows.Forms.ToolStripMenuItem();
		this.groupBox_20 = new System.Windows.Forms.GroupBox();
		this.button_9 = new System.Windows.Forms.Button();
		this.groupBox_18 = new System.Windows.Forms.GroupBox();
		this.numericUpDown_4 = new System.Windows.Forms.NumericUpDown();
		this.label_68 = new System.Windows.Forms.Label();
		this.numericUpDown_2 = new System.Windows.Forms.NumericUpDown();
		this.label_69 = new System.Windows.Forms.Label();
		this.numericUpDown_3 = new System.Windows.Forms.NumericUpDown();
		this.label_70 = new System.Windows.Forms.Label();
		this.comboBox_1 = new System.Windows.Forms.ComboBox();
		this.label_71 = new System.Windows.Forms.Label();
		this.comboBox_0 = new System.Windows.Forms.ComboBox();
		this.numericUpDown_5 = new System.Windows.Forms.NumericUpDown();
		this.label_72 = new System.Windows.Forms.Label();
		this.label_73 = new System.Windows.Forms.Label();
		this.textBox_19 = new System.Windows.Forms.TextBox();
		this.textBox_20 = new System.Windows.Forms.TextBox();
		this.textBox_42 = new System.Windows.Forms.TextBox();
		this.contextMenuStrip_1 = new System.Windows.Forms.ContextMenuStrip(this.icontainer_0);
		this.toolStripMenuItem_8 = new System.Windows.Forms.ToolStripMenuItem();
		this.label_19 = new System.Windows.Forms.Label();
		this.textBox_6 = new System.Windows.Forms.TextBox();
		this.label_18 = new System.Windows.Forms.Label();
		this.checkBox_4 = new System.Windows.Forms.CheckBox();
		this.checkBox_5 = new System.Windows.Forms.CheckBox();
		this.checkBox_6 = new System.Windows.Forms.CheckBox();
		this.textBox_18 = new System.Windows.Forms.TextBox();
		this.label_17 = new System.Windows.Forms.Label();
		this.comboBox_8 = new System.Windows.Forms.ComboBox();
		this.label_16 = new System.Windows.Forms.Label();
		this.textBox_66 = new System.Windows.Forms.TextBox();
		this.label_13 = new System.Windows.Forms.Label();
		this.textBox_63 = new System.Windows.Forms.TextBox();
		this.label_14 = new System.Windows.Forms.Label();
		this.textBox_60 = new System.Windows.Forms.TextBox();
		this.label_15 = new System.Windows.Forms.Label();
		this.textBox_65 = new System.Windows.Forms.TextBox();
		this.label_12 = new System.Windows.Forms.Label();
		this.textBox_62 = new System.Windows.Forms.TextBox();
		this.label_2 = new System.Windows.Forms.Label();
		this.textBox_59 = new System.Windows.Forms.TextBox();
		this.textBox_64 = new System.Windows.Forms.TextBox();
		this.textBox_61 = new System.Windows.Forms.TextBox();
		this.label_97 = new System.Windows.Forms.Label();
		this.textBox_58 = new System.Windows.Forms.TextBox();
		this.label_86 = new System.Windows.Forms.Label();
		this.label_75 = new System.Windows.Forms.Label();
		this.label_64 = new System.Windows.Forms.Label();
		this.textBox_17 = new System.Windows.Forms.TextBox();
		this.comboBox_7 = new System.Windows.Forms.ComboBox();
		this.label_31 = new System.Windows.Forms.Label();
		this.label_53 = new System.Windows.Forms.Label();
		this.label_20 = new System.Windows.Forms.Label();
		this.label_21 = new System.Windows.Forms.Label();
		this.button_10 = new System.Windows.Forms.Button();
		this.button_6 = new System.Windows.Forms.Button();
		this.toolStrip_0 = new System.Windows.Forms.ToolStrip();
		this.toolStripButton_0 = new System.Windows.Forms.ToolStripButton();
		this.toolStripButton_2 = new System.Windows.Forms.ToolStripButton();
		this.toolStripDropDownButton_0 = new System.Windows.Forms.ToolStripDropDownButton();
		this.toolStripMenuItem_14 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem_15 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripDropDownButton_2 = new System.Windows.Forms.ToolStripDropDownButton();
		this.toolStripMenuItem_9 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem_6 = new System.Windows.Forms.ToolStripMenuItem();
		this.tabPage_4 = new System.Windows.Forms.TabPage();
		this.groupBox_15 = new System.Windows.Forms.GroupBox();
		this.numericUpDown_25 = new System.Windows.Forms.NumericUpDown();
		this.label_41 = new System.Windows.Forms.Label();
		this.numericUpDown_22 = new System.Windows.Forms.NumericUpDown();
		this.label_59 = new System.Windows.Forms.Label();
		this.numericUpDown_24 = new System.Windows.Forms.NumericUpDown();
		this.numericUpDown_19 = new System.Windows.Forms.NumericUpDown();
		this.label_63 = new System.Windows.Forms.Label();
		this.numericUpDown_23 = new System.Windows.Forms.NumericUpDown();
		this.label_65 = new System.Windows.Forms.Label();
		this.button_20 = new System.Windows.Forms.Button();
		this.button_19 = new System.Windows.Forms.Button();
		this.dataGridView_7 = new System.Windows.Forms.DataGridView();
		this.dataGridViewTextBoxColumn_36 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.label_57 = new System.Windows.Forms.Label();
		this.label_62 = new System.Windows.Forms.Label();
		this.groupBox_14 = new System.Windows.Forms.GroupBox();
		this.groupBox_2 = new System.Windows.Forms.GroupBox();
		this.button_21 = new System.Windows.Forms.Button();
		this.numericUpDown_8 = new System.Windows.Forms.NumericUpDown();
		this.label_58 = new System.Windows.Forms.Label();
		this.numericUpDown_6 = new System.Windows.Forms.NumericUpDown();
		this.label_60 = new System.Windows.Forms.Label();
		this.numericUpDown_7 = new System.Windows.Forms.NumericUpDown();
		this.label_61 = new System.Windows.Forms.Label();
		this.numericUpDown_9 = new System.Windows.Forms.NumericUpDown();
		this.label_81 = new System.Windows.Forms.Label();
		this.textBox_27 = new System.Windows.Forms.TextBox();
		this.label_38 = new System.Windows.Forms.Label();
		this.textBox_31 = new System.Windows.Forms.TextBox();
		this.label_39 = new System.Windows.Forms.Label();
		this.textBox_22 = new System.Windows.Forms.TextBox();
		this.label_40 = new System.Windows.Forms.Label();
		this.checkBox_7 = new System.Windows.Forms.CheckBox();
		this.checkBox_8 = new System.Windows.Forms.CheckBox();
		this.checkBox_9 = new System.Windows.Forms.CheckBox();
		this.textBox_30 = new System.Windows.Forms.TextBox();
		this.label_44 = new System.Windows.Forms.Label();
		this.textBox_36 = new System.Windows.Forms.TextBox();
		this.label_45 = new System.Windows.Forms.Label();
		this.textBox_33 = new System.Windows.Forms.TextBox();
		this.label_46 = new System.Windows.Forms.Label();
		this.textBox_29 = new System.Windows.Forms.TextBox();
		this.label_47 = new System.Windows.Forms.Label();
		this.textBox_28 = new System.Windows.Forms.TextBox();
		this.label_48 = new System.Windows.Forms.Label();
		this.textBox_35 = new System.Windows.Forms.TextBox();
		this.textBox_34 = new System.Windows.Forms.TextBox();
		this.textBox_32 = new System.Windows.Forms.TextBox();
		this.label_50 = new System.Windows.Forms.Label();
		this.label_51 = new System.Windows.Forms.Label();
		this.label_52 = new System.Windows.Forms.Label();
		this.textBox_26 = new System.Windows.Forms.TextBox();
		this.label_55 = new System.Windows.Forms.Label();
		this.dataGridView_6 = new System.Windows.Forms.DataGridView();
		this.dataGridViewTextBoxColumn_33 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_34 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_35 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.toolStrip_1 = new System.Windows.Forms.ToolStrip();
		this.toolStripButton_1 = new System.Windows.Forms.ToolStripButton();
		this.toolStripButton_3 = new System.Windows.Forms.ToolStripButton();
		this.toolStripDropDownButton_1 = new System.Windows.Forms.ToolStripDropDownButton();
		this.toolStripMenuItem_11 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem_12 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripDropDownButton_3 = new System.Windows.Forms.ToolStripDropDownButton();
		this.toolStripMenuItem_13 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem_10 = new System.Windows.Forms.ToolStripMenuItem();
		this.button_22 = new System.Windows.Forms.Button();
		this.button_17 = new System.Windows.Forms.Button();
		this.tabPage_0 = new System.Windows.Forms.TabPage();
		this.groupBox_19 = new System.Windows.Forms.GroupBox();
		this.pictureBox_0 = new System.Windows.Forms.PictureBox();
		this.groupBox_17 = new System.Windows.Forms.GroupBox();
		this.textBox_0 = new System.Windows.Forms.TextBox();
		this.label_0 = new System.Windows.Forms.Label();
		this.button_4 = new System.Windows.Forms.Button();
		this.textBox_4 = new System.Windows.Forms.TextBox();
		this.groupBox_1 = new System.Windows.Forms.GroupBox();
		this.numericUpDown_1 = new System.Windows.Forms.NumericUpDown();
		this.label_43 = new System.Windows.Forms.Label();
		this.numericUpDown_0 = new System.Windows.Forms.NumericUpDown();
		this.label_66 = new System.Windows.Forms.Label();
		this.label_80 = new System.Windows.Forms.Label();
		this.textBox_5 = new System.Windows.Forms.TextBox();
		this.label_79 = new System.Windows.Forms.Label();
		this.textBox_3 = new System.Windows.Forms.TextBox();
		this.label_76 = new System.Windows.Forms.Label();
		this.textBox_2 = new System.Windows.Forms.TextBox();
		this.label_77 = new System.Windows.Forms.Label();
		this.textBox_1 = new System.Windows.Forms.TextBox();
		this.label_78 = new System.Windows.Forms.Label();
		this.label_74 = new System.Windows.Forms.Label();
		this.textBox_12 = new System.Windows.Forms.TextBox();
		this.textBox_8 = new System.Windows.Forms.TextBox();
		this.textBox_7 = new System.Windows.Forms.TextBox();
		this.label_87 = new System.Windows.Forms.Label();
		this.label_88 = new System.Windows.Forms.Label();
		this.label_89 = new System.Windows.Forms.Label();
		this.dataGridView_1 = new System.Windows.Forms.DataGridView();
		this.dataGridViewTextBoxColumn_7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.button_5 = new System.Windows.Forms.Button();
		this.button_3 = new System.Windows.Forms.Button();
		this.toolStrip_2 = new System.Windows.Forms.ToolStrip();
		this.toolStripButton_4 = new System.Windows.Forms.ToolStripButton();
		this.toolStripButton_5 = new System.Windows.Forms.ToolStripButton();
		this.toolStripDropDownButton_4 = new System.Windows.Forms.ToolStripDropDownButton();
		this.toolStripMenuItem_23 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem_24 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripDropDownButton_5 = new System.Windows.Forms.ToolStripDropDownButton();
		this.toolStripMenuItem_25 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem_17 = new System.Windows.Forms.ToolStripMenuItem();
		this.tabPage_6 = new System.Windows.Forms.TabPage();
		this.groupBox_6 = new System.Windows.Forms.GroupBox();
		this.dataGridView_0 = new System.Windows.Forms.DataGridView();
		this.dataGridViewTextBoxColumn_21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.button_12 = new System.Windows.Forms.Button();
		this.groupBox_5 = new System.Windows.Forms.GroupBox();
		this.dataGridView_8 = new System.Windows.Forms.DataGridView();
		this.dataGridViewTextBoxColumn_18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.button_14 = new System.Windows.Forms.Button();
		this.groupBox_4 = new System.Windows.Forms.GroupBox();
		this.dataGridView_3 = new System.Windows.Forms.DataGridView();
		this.dataGridViewTextBoxColumn_24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_27 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.button_13 = new System.Windows.Forms.Button();
		this.groupBox_3 = new System.Windows.Forms.GroupBox();
		this.groupBox_8 = new System.Windows.Forms.GroupBox();
		this.textBox_53 = new System.Windows.Forms.TextBox();
		this.label_101 = new System.Windows.Forms.Label();
		this.textBox_52 = new System.Windows.Forms.TextBox();
		this.label_102 = new System.Windows.Forms.Label();
		this.textBox_51 = new System.Windows.Forms.TextBox();
		this.label_103 = new System.Windows.Forms.Label();
		this.comboBox_15 = new System.Windows.Forms.ComboBox();
		this.textBox_54 = new System.Windows.Forms.TextBox();
		this.label_104 = new System.Windows.Forms.Label();
		this.textBox_55 = new System.Windows.Forms.TextBox();
		this.label_105 = new System.Windows.Forms.Label();
		this.label_106 = new System.Windows.Forms.Label();
		this.groupBox_7 = new System.Windows.Forms.GroupBox();
		this.textBox_48 = new System.Windows.Forms.TextBox();
		this.label_100 = new System.Windows.Forms.Label();
		this.textBox_47 = new System.Windows.Forms.TextBox();
		this.label_99 = new System.Windows.Forms.Label();
		this.textBox_46 = new System.Windows.Forms.TextBox();
		this.label_98 = new System.Windows.Forms.Label();
		this.comboBox_14 = new System.Windows.Forms.ComboBox();
		this.textBox_49 = new System.Windows.Forms.TextBox();
		this.label_94 = new System.Windows.Forms.Label();
		this.textBox_50 = new System.Windows.Forms.TextBox();
		this.label_93 = new System.Windows.Forms.Label();
		this.label_95 = new System.Windows.Forms.Label();
		this.checkBox_11 = new System.Windows.Forms.CheckBox();
		this.checkBox_12 = new System.Windows.Forms.CheckBox();
		this.textBox_38 = new System.Windows.Forms.TextBox();
		this.label_92 = new System.Windows.Forms.Label();
		this.textBox_57 = new System.Windows.Forms.TextBox();
		this.label_91 = new System.Windows.Forms.Label();
		this.textBox_56 = new System.Windows.Forms.TextBox();
		this.checkBox_10 = new System.Windows.Forms.CheckBox();
		this.textBox_40 = new System.Windows.Forms.TextBox();
		this.label_84 = new System.Windows.Forms.Label();
		this.label_96 = new System.Windows.Forms.Label();
		this.textBox_41 = new System.Windows.Forms.TextBox();
		this.textBox_39 = new System.Windows.Forms.TextBox();
		this.label_85 = new System.Windows.Forms.Label();
		this.label_90 = new System.Windows.Forms.Label();
		this.label_107 = new System.Windows.Forms.Label();
		this.dataGridView_10 = new System.Windows.Forms.DataGridView();
		this.dataGridViewTextBoxColumn_10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.contextMenuStrip_3 = new System.Windows.Forms.ContextMenuStrip(this.icontainer_0);
		this.toolStripMenuItem_0 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem_22 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem_27 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem_2 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripSeparator_2 = new System.Windows.Forms.ToolStripSeparator();
		this.toolStripMenuItem_19 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem_18 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStrip_3 = new System.Windows.Forms.ToolStrip();
		this.toolStripButton_6 = new System.Windows.Forms.ToolStripButton();
		this.toolStripButton_7 = new System.Windows.Forms.ToolStripButton();
		this.toolStripDropDownButton_6 = new System.Windows.Forms.ToolStripDropDownButton();
		this.toolStripMenuItem_20 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem_21 = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripButton_8 = new System.Windows.Forms.ToolStripButton();
		this.button_28 = new System.Windows.Forms.Button();
		this.button_26 = new System.Windows.Forms.Button();
		this.tabPage_5 = new System.Windows.Forms.TabPage();
		this.dataGridView_9 = new System.Windows.Forms.DataGridView();
		this.dataGridViewTextBoxColumn_13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.contextMenuStrip_0 = new System.Windows.Forms.ContextMenuStrip(this.icontainer_0);
		this.toolStripMenuItem_7 = new System.Windows.Forms.ToolStripMenuItem();
		this.groupBox_12 = new System.Windows.Forms.GroupBox();
		this.button_27 = new System.Windows.Forms.Button();
		this.textBox_45 = new System.Windows.Forms.TextBox();
		this.radioButton_14 = new System.Windows.Forms.RadioButton();
		this.textBox_43 = new System.Windows.Forms.TextBox();
		this.label_10 = new System.Windows.Forms.Label();
		this.radioButton_13 = new System.Windows.Forms.RadioButton();
		this.textBox_44 = new System.Windows.Forms.TextBox();
		this.label_11 = new System.Windows.Forms.Label();
		this.radioButton_12 = new System.Windows.Forms.RadioButton();
		this.groupBox_11 = new System.Windows.Forms.GroupBox();
		this.button_2 = new System.Windows.Forms.Button();
		this.textBox_11 = new System.Windows.Forms.TextBox();
		this.radioButton_4 = new System.Windows.Forms.RadioButton();
		this.textBox_10 = new System.Windows.Forms.TextBox();
		this.label_8 = new System.Windows.Forms.Label();
		this.radioButton_2 = new System.Windows.Forms.RadioButton();
		this.textBox_9 = new System.Windows.Forms.TextBox();
		this.label_9 = new System.Windows.Forms.Label();
		this.radioButton_3 = new System.Windows.Forms.RadioButton();
		this.groupBox_10 = new System.Windows.Forms.GroupBox();
		this.button_18 = new System.Windows.Forms.Button();
		this.textBox_25 = new System.Windows.Forms.TextBox();
		this.radioButton_11 = new System.Windows.Forms.RadioButton();
		this.textBox_24 = new System.Windows.Forms.TextBox();
		this.label_6 = new System.Windows.Forms.Label();
		this.radioButton_9 = new System.Windows.Forms.RadioButton();
		this.textBox_23 = new System.Windows.Forms.TextBox();
		this.label_7 = new System.Windows.Forms.Label();
		this.radioButton_10 = new System.Windows.Forms.RadioButton();
		this.groupBox_9 = new System.Windows.Forms.GroupBox();
		this.button_11 = new System.Windows.Forms.Button();
		this.textBox_15 = new System.Windows.Forms.TextBox();
		this.radioButton_7 = new System.Windows.Forms.RadioButton();
		this.textBox_16 = new System.Windows.Forms.TextBox();
		this.radioButton_8 = new System.Windows.Forms.RadioButton();
		this.textBox_14 = new System.Windows.Forms.TextBox();
		this.label_5 = new System.Windows.Forms.Label();
		this.radioButton_5 = new System.Windows.Forms.RadioButton();
		this.textBox_13 = new System.Windows.Forms.TextBox();
		this.label_82 = new System.Windows.Forms.Label();
		this.radioButton_6 = new System.Windows.Forms.RadioButton();
		this.tabPage_1 = new System.Windows.Forms.TabPage();
		this.button_16 = new System.Windows.Forms.Button();
		this.button_25 = new System.Windows.Forms.Button();
		this.dataGridView_2 = new System.Windows.Forms.DataGridView();
		this.dataGridViewTextBoxColumn_2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_28 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_29 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn_30 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.tabPage_3 = new System.Windows.Forms.TabPage();
		this.groupBox_13 = new System.Windows.Forms.GroupBox();
		this.radioButton_0 = new System.Windows.Forms.RadioButton();
		this.radioButton_1 = new System.Windows.Forms.RadioButton();
		this.comboBox_3 = new System.Windows.Forms.ComboBox();
		this.label_56 = new System.Windows.Forms.Label();
		this.groupBox_16 = new System.Windows.Forms.GroupBox();
		this.comboBox_9 = new System.Windows.Forms.ComboBox();
		this.label_3 = new System.Windows.Forms.Label();
		this.comboBox_4 = new System.Windows.Forms.ComboBox();
		this.label_4 = new System.Windows.Forms.Label();
		this.comboBox_11 = new System.Windows.Forms.ComboBox();
		this.label_67 = new System.Windows.Forms.Label();
		this.comboBox_6 = new System.Windows.Forms.ComboBox();
		this.label_83 = new System.Windows.Forms.Label();
		this.comboBox_10 = new System.Windows.Forms.ComboBox();
		this.label_49 = new System.Windows.Forms.Label();
		this.comboBox_5 = new System.Windows.Forms.ComboBox();
		this.label_54 = new System.Windows.Forms.Label();
		this.comboBox_16 = new System.Windows.Forms.ComboBox();
		this.button_1 = new System.Windows.Forms.Button();
		this.button_23 = new System.Windows.Forms.Button();
		this.comboBox_12 = new System.Windows.Forms.ComboBox();
		this.openFileDialog_1 = new System.Windows.Forms.OpenFileDialog();
		this.openFileDialog_2 = new System.Windows.Forms.OpenFileDialog();
		this.label_42 = new System.Windows.Forms.Label();
		this.textBox_37 = new System.Windows.Forms.TextBox();
		this.openFileDialog_3 = new System.Windows.Forms.OpenFileDialog();
		this.saveFileDialog_0 = new System.Windows.Forms.SaveFileDialog();
		this.button_0 = new System.Windows.Forms.Button();
		this.progressBar_1 = new System.Windows.Forms.ProgressBar();
		this.toolTip_0 = new System.Windows.Forms.ToolTip(this.icontainer_0);
		this.openFileDialog_0 = new System.Windows.Forms.OpenFileDialog();
		this.button_15 = new System.Windows.Forms.Button();
		this.button_24 = new System.Windows.Forms.Button();
		this.tabControl_0.SuspendLayout();
		this.tabPage_2.SuspendLayout();
		this.groupBox_0.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown_14).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown_20).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown_12).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown_16).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown_11).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dataGridView_5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown_26).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown_27).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown_17).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown_18).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown_13).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown_21).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown_10).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown_15).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dataGridView_4).BeginInit();
		this.contextMenuStrip_2.SuspendLayout();
		this.groupBox_20.SuspendLayout();
		this.groupBox_18.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown_4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown_2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown_3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown_5).BeginInit();
		this.contextMenuStrip_1.SuspendLayout();
		this.toolStrip_0.SuspendLayout();
		this.tabPage_4.SuspendLayout();
		this.groupBox_15.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown_25).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown_22).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown_24).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown_19).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown_23).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dataGridView_7).BeginInit();
		this.groupBox_14.SuspendLayout();
		this.groupBox_2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown_8).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown_6).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown_7).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown_9).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dataGridView_6).BeginInit();
		this.toolStrip_1.SuspendLayout();
		this.tabPage_0.SuspendLayout();
		this.groupBox_19.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.pictureBox_0).BeginInit();
		this.groupBox_17.SuspendLayout();
		this.groupBox_1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown_1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown_0).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dataGridView_1).BeginInit();
		this.toolStrip_2.SuspendLayout();
		this.tabPage_6.SuspendLayout();
		this.groupBox_6.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.dataGridView_0).BeginInit();
		this.groupBox_5.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.dataGridView_8).BeginInit();
		this.groupBox_4.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.dataGridView_3).BeginInit();
		this.groupBox_3.SuspendLayout();
		this.groupBox_8.SuspendLayout();
		this.groupBox_7.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.dataGridView_10).BeginInit();
		this.contextMenuStrip_3.SuspendLayout();
		this.toolStrip_3.SuspendLayout();
		this.tabPage_5.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.dataGridView_9).BeginInit();
		this.contextMenuStrip_0.SuspendLayout();
		this.groupBox_12.SuspendLayout();
		this.groupBox_11.SuspendLayout();
		this.groupBox_10.SuspendLayout();
		this.groupBox_9.SuspendLayout();
		this.tabPage_1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.dataGridView_2).BeginInit();
		this.tabPage_3.SuspendLayout();
		this.groupBox_13.SuspendLayout();
		this.groupBox_16.SuspendLayout();
		base.SuspendLayout();
		this.label_1.AutoSize = true;
		this.label_1.Location = new System.Drawing.Point(5, 33);
		this.label_1.Name = Class16.smethod_0(1648919238);
		this.label_1.Size = new System.Drawing.Size(72, 13);
		this.label_1.TabIndex = 0;
		this.label_1.Text = Class16.smethod_0(1649114455);
		this.textBox_21.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.textBox_21.Location = new System.Drawing.Point(75, 30);
		this.textBox_21.Name = Class16.smethod_0(1649114466);
		this.textBox_21.Size = new System.Drawing.Size(687, 20);
		this.textBox_21.TabIndex = 3;
		this.progressBar_0.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.progressBar_0.ForeColor = System.Drawing.Color.FromArgb(255, 128, 128);
		this.progressBar_0.Location = new System.Drawing.Point(4, 590);
		this.progressBar_0.Name = Class16.smethod_0(1649114495);
		this.progressBar_0.Size = new System.Drawing.Size(978, 23);
		this.progressBar_0.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
		this.progressBar_0.TabIndex = 9;
		this.tabControl_0.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.tabControl_0.Controls.Add(this.tabPage_2);
		this.tabControl_0.Controls.Add(this.tabPage_4);
		this.tabControl_0.Controls.Add(this.tabPage_0);
		this.tabControl_0.Controls.Add(this.tabPage_6);
		this.tabControl_0.Controls.Add(this.tabPage_5);
		this.tabControl_0.Controls.Add(this.tabPage_1);
		this.tabControl_0.Controls.Add(this.tabPage_3);
		this.tabControl_0.Location = new System.Drawing.Point(4, 81);
		this.tabControl_0.Name = Class16.smethod_0(1649114517);
		this.tabControl_0.SelectedIndex = 0;
		this.tabControl_0.Size = new System.Drawing.Size(974, 509);
		this.tabControl_0.TabIndex = 11;
		this.tabControl_0.Click += new System.EventHandler(textBox_13_Click);
		this.tabPage_2.BackColor = System.Drawing.Color.FromArgb(239, 244, 250);
		this.tabPage_2.Controls.Add(this.groupBox_0);
		this.tabPage_2.Controls.Add(this.dataGridView_4);
		this.tabPage_2.Controls.Add(this.groupBox_20);
		this.tabPage_2.Controls.Add(this.button_10);
		this.tabPage_2.Controls.Add(this.button_6);
		this.tabPage_2.Controls.Add(this.toolStrip_0);
		this.tabPage_2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.tabPage_2.Location = new System.Drawing.Point(4, 22);
		this.tabPage_2.Name = Class16.smethod_0(1649114530);
		this.tabPage_2.Padding = new System.Windows.Forms.Padding(3);
		this.tabPage_2.Size = new System.Drawing.Size(966, 483);
		this.tabPage_2.TabIndex = 0;
		this.tabPage_2.Text = Class16.smethod_0(1649114557);
		this.groupBox_0.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.groupBox_0.BackColor = System.Drawing.Color.FromArgb(239, 244, 250);
		this.groupBox_0.Controls.Add(this.numericUpDown_14);
		this.groupBox_0.Controls.Add(this.label_37);
		this.groupBox_0.Controls.Add(this.numericUpDown_20);
		this.groupBox_0.Controls.Add(this.numericUpDown_12);
		this.groupBox_0.Controls.Add(this.checkBox_0);
		this.groupBox_0.Controls.Add(this.checkBox_2);
		this.groupBox_0.Controls.Add(this.checkBox_1);
		this.groupBox_0.Controls.Add(this.numericUpDown_16);
		this.groupBox_0.Controls.Add(this.checkBox_3);
		this.groupBox_0.Controls.Add(this.label_34);
		this.groupBox_0.Controls.Add(this.numericUpDown_11);
		this.groupBox_0.Controls.Add(this.dataGridView_5);
		this.groupBox_0.Controls.Add(this.button_7);
		this.groupBox_0.Controls.Add(this.label_33);
		this.groupBox_0.Controls.Add(this.button_8);
		this.groupBox_0.Controls.Add(this.numericUpDown_26);
		this.groupBox_0.Controls.Add(this.label_32);
		this.groupBox_0.Controls.Add(this.numericUpDown_27);
		this.groupBox_0.Controls.Add(this.numericUpDown_17);
		this.groupBox_0.Controls.Add(this.numericUpDown_18);
		this.groupBox_0.Controls.Add(this.comboBox_13);
		this.groupBox_0.Controls.Add(this.comboBox_2);
		this.groupBox_0.Controls.Add(this.numericUpDown_13);
		this.groupBox_0.Controls.Add(this.numericUpDown_21);
		this.groupBox_0.Controls.Add(this.label_24);
		this.groupBox_0.Controls.Add(this.numericUpDown_10);
		this.groupBox_0.Controls.Add(this.label_23);
		this.groupBox_0.Controls.Add(this.numericUpDown_15);
		this.groupBox_0.Controls.Add(this.label_22);
		this.groupBox_0.Controls.Add(this.label_30);
		this.groupBox_0.Controls.Add(this.label_36);
		this.groupBox_0.Controls.Add(this.label_25);
		this.groupBox_0.Controls.Add(this.label_28);
		this.groupBox_0.Controls.Add(this.label_27);
		this.groupBox_0.Controls.Add(this.label_29);
		this.groupBox_0.Controls.Add(this.label_26);
		this.groupBox_0.Controls.Add(this.label_35);
		this.groupBox_0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.groupBox_0.Location = new System.Drawing.Point(364, 253);
		this.groupBox_0.Name = Class16.smethod_0(1648929126);
		this.groupBox_0.Size = new System.Drawing.Size(599, 229);
		this.groupBox_0.TabIndex = 14;
		this.groupBox_0.TabStop = false;
		this.groupBox_0.Text = Class16.smethod_0(1649114568);
		this.numericUpDown_14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.numericUpDown_14.Location = new System.Drawing.Point(293, 37);
		this.numericUpDown_14.Maximum = new decimal(new int[4] { 2147483647, 0, 0, 0 });
		this.numericUpDown_14.Minimum = new decimal(new int[4] { -2147483648, 0, 0, -2147483648 });
		this.numericUpDown_14.Name = Class16.smethod_0(1649114584);
		this.numericUpDown_14.Size = new System.Drawing.Size(80, 20);
		this.numericUpDown_14.TabIndex = 65;
		this.numericUpDown_14.KeyDown += new System.Windows.Forms.KeyEventHandler(numericUpDown_15_KeyDown);
		this.numericUpDown_14.Leave += new System.EventHandler(numericUpDown_15_Leave);
		this.label_37.AutoSize = true;
		this.label_37.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_37.Location = new System.Drawing.Point(247, 37);
		this.label_37.Name = Class16.smethod_0(1649114612);
		this.label_37.Size = new System.Drawing.Size(44, 15);
		this.label_37.TabIndex = 66;
		this.label_37.Text = Class16.smethod_0(1649112918);
		this.numericUpDown_20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.numericUpDown_20.Location = new System.Drawing.Point(293, 130);
		this.numericUpDown_20.Maximum = new decimal(new int[4] { 2147483647, 0, 0, 0 });
		this.numericUpDown_20.Minimum = new decimal(new int[4] { -2147483648, 0, 0, -2147483648 });
		this.numericUpDown_20.Name = Class16.smethod_0(1649114618);
		this.numericUpDown_20.Size = new System.Drawing.Size(80, 20);
		this.numericUpDown_20.TabIndex = 63;
		this.numericUpDown_20.KeyDown += new System.Windows.Forms.KeyEventHandler(numericUpDown_15_KeyDown);
		this.numericUpDown_20.Leave += new System.EventHandler(numericUpDown_15_Leave);
		this.numericUpDown_12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.numericUpDown_12.Location = new System.Drawing.Point(293, 106);
		this.numericUpDown_12.Maximum = new decimal(new int[4] { 2147483647, 0, 0, 0 });
		this.numericUpDown_12.Minimum = new decimal(new int[4] { -2147483648, 0, 0, -2147483648 });
		this.numericUpDown_12.Name = Class16.smethod_0(1649113629);
		this.numericUpDown_12.Size = new System.Drawing.Size(80, 20);
		this.numericUpDown_12.TabIndex = 61;
		this.numericUpDown_12.KeyDown += new System.Windows.Forms.KeyEventHandler(numericUpDown_15_KeyDown);
		this.numericUpDown_12.Leave += new System.EventHandler(numericUpDown_15_Leave);
		this.checkBox_0.AutoSize = true;
		this.checkBox_0.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.checkBox_0.Location = new System.Drawing.Point(283, 206);
		this.checkBox_0.Name = Class16.smethod_0(1649113652);
		this.checkBox_0.Size = new System.Drawing.Size(90, 17);
		this.checkBox_0.TabIndex = 60;
		this.checkBox_0.Text = Class16.smethod_0(1649113652);
		this.checkBox_0.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
		this.checkBox_0.UseVisualStyleBackColor = true;
		this.checkBox_0.KeyDown += new System.Windows.Forms.KeyEventHandler(numericUpDown_15_KeyDown);
		this.checkBox_0.Leave += new System.EventHandler(numericUpDown_15_Leave);
		this.checkBox_2.AutoSize = true;
		this.checkBox_2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.checkBox_2.Location = new System.Drawing.Point(306, 188);
		this.checkBox_2.Name = Class16.smethod_0(1649113670);
		this.checkBox_2.Size = new System.Drawing.Size(67, 17);
		this.checkBox_2.TabIndex = 38;
		this.checkBox_2.Text = Class16.smethod_0(1649113670);
		this.checkBox_2.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
		this.checkBox_2.UseVisualStyleBackColor = true;
		this.checkBox_2.KeyDown += new System.Windows.Forms.KeyEventHandler(numericUpDown_15_KeyDown);
		this.checkBox_2.Leave += new System.EventHandler(numericUpDown_15_Leave);
		this.checkBox_1.AutoSize = true;
		this.checkBox_1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.checkBox_1.Location = new System.Drawing.Point(286, 152);
		this.checkBox_1.Name = Class16.smethod_0(1649113685);
		this.checkBox_1.Size = new System.Drawing.Size(87, 17);
		this.checkBox_1.TabIndex = 39;
		this.checkBox_1.Text = Class16.smethod_0(1649113685);
		this.checkBox_1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
		this.checkBox_1.UseVisualStyleBackColor = true;
		this.checkBox_1.KeyDown += new System.Windows.Forms.KeyEventHandler(numericUpDown_15_KeyDown);
		this.checkBox_1.Leave += new System.EventHandler(numericUpDown_15_Leave);
		this.numericUpDown_16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.numericUpDown_16.Location = new System.Drawing.Point(293, 83);
		this.numericUpDown_16.Maximum = new decimal(new int[4] { 2147483647, 0, 0, 0 });
		this.numericUpDown_16.Minimum = new decimal(new int[4] { -2147483648, 0, 0, -2147483648 });
		this.numericUpDown_16.Name = Class16.smethod_0(1649113703);
		this.numericUpDown_16.Size = new System.Drawing.Size(80, 20);
		this.numericUpDown_16.TabIndex = 58;
		this.numericUpDown_16.KeyDown += new System.Windows.Forms.KeyEventHandler(numericUpDown_15_KeyDown);
		this.numericUpDown_16.Leave += new System.EventHandler(numericUpDown_15_Leave);
		this.checkBox_3.AutoSize = true;
		this.checkBox_3.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.checkBox_3.Location = new System.Drawing.Point(293, 170);
		this.checkBox_3.Name = Class16.smethod_0(1649113726);
		this.checkBox_3.Size = new System.Drawing.Size(80, 17);
		this.checkBox_3.TabIndex = 37;
		this.checkBox_3.Text = Class16.smethod_0(1649113726);
		this.checkBox_3.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
		this.checkBox_3.UseVisualStyleBackColor = true;
		this.checkBox_3.KeyDown += new System.Windows.Forms.KeyEventHandler(numericUpDown_15_KeyDown);
		this.checkBox_3.Leave += new System.EventHandler(numericUpDown_15_Leave);
		this.label_34.AutoSize = true;
		this.label_34.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_34.Location = new System.Drawing.Point(210, 83);
		this.label_34.Name = Class16.smethod_0(1649113742);
		this.label_34.Size = new System.Drawing.Size(81, 15);
		this.label_34.TabIndex = 59;
		this.label_34.Text = Class16.smethod_0(1649113756);
		this.numericUpDown_11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.numericUpDown_11.Location = new System.Drawing.Point(293, 60);
		this.numericUpDown_11.Maximum = new decimal(new int[4] { 2147483647, 0, 0, 0 });
		this.numericUpDown_11.Minimum = new decimal(new int[4] { -2147483648, 0, 0, -2147483648 });
		this.numericUpDown_11.Name = Class16.smethod_0(1649113775);
		this.numericUpDown_11.Size = new System.Drawing.Size(80, 20);
		this.numericUpDown_11.TabIndex = 56;
		this.numericUpDown_11.KeyDown += new System.Windows.Forms.KeyEventHandler(numericUpDown_15_KeyDown);
		this.numericUpDown_11.Leave += new System.EventHandler(numericUpDown_15_Leave);
		this.dataGridView_5.AllowUserToAddRows = false;
		this.dataGridView_5.AllowUserToDeleteRows = false;
		this.dataGridView_5.AllowUserToResizeColumns = false;
		this.dataGridView_5.AllowUserToResizeRows = false;
		this.dataGridView_5.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.dataGridView_5.BackgroundColor = System.Drawing.Color.FromArgb(15, 15, 15);
		this.dataGridView_5.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
		this.dataGridView_5.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
		this.dataGridView_5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridView_5.Columns.AddRange(this.dataGridViewTextBoxColumn_26, this.dataGridViewTextBoxColumn_31, this.dataGridViewTextBoxColumn_32);
		dataGridViewCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle.BackColor = System.Drawing.Color.FromArgb(15, 15, 15);
		dataGridViewCellStyle.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 8.25f);
		dataGridViewCellStyle.ForeColor = System.Drawing.Color.White;
		dataGridViewCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 255, 192);
		dataGridViewCellStyle.SelectionForeColor = System.Drawing.Color.Black;
		dataGridViewCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
		this.dataGridView_5.DefaultCellStyle = dataGridViewCellStyle;
		this.dataGridView_5.EnableHeadersVisualStyles = false;
		this.dataGridView_5.Location = new System.Drawing.Point(379, 11);
		this.dataGridView_5.Name = Class16.smethod_0(1649113797);
		this.dataGridView_5.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
		this.dataGridView_5.RowHeadersVisible = false;
		this.dataGridView_5.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		this.dataGridView_5.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		this.dataGridView_5.ShowCellErrors = false;
		this.dataGridView_5.ShowCellToolTips = false;
		this.dataGridView_5.ShowEditingIcon = false;
		this.dataGridView_5.ShowRowErrors = false;
		this.dataGridView_5.Size = new System.Drawing.Size(218, 186);
		this.dataGridView_5.TabIndex = 15;
		this.dataGridView_5.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(dataGridView_5_CellMouseEnter);
		this.dataGridView_5.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(dataGridView_5_CellMouseLeave);
		this.dataGridView_5.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(dataGridView_5_CellMouseMove);
		this.dataGridView_5.CurrentCellChanged += new System.EventHandler(dataGridView_5_CurrentCellChanged);
		dataGridViewCellStyle2.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.dataGridViewTextBoxColumn_26.DefaultCellStyle = dataGridViewCellStyle2;
		this.dataGridViewTextBoxColumn_26.FillWeight = 6.912442f;
		this.dataGridViewTextBoxColumn_26.HeaderText = Class16.smethod_0(1648929947);
		this.dataGridViewTextBoxColumn_26.Name = Class16.smethod_0(1648913143);
		this.dataGridViewTextBoxColumn_26.ReadOnly = true;
		this.dataGridViewTextBoxColumn_26.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
		this.dataGridViewTextBoxColumn_26.Width = 47;
		dataGridViewCellStyle3.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.dataGridViewTextBoxColumn_31.DefaultCellStyle = dataGridViewCellStyle3;
		this.dataGridViewTextBoxColumn_31.FillWeight = 44.7233f;
		this.dataGridViewTextBoxColumn_31.HeaderText = Class16.smethod_0(1649118934);
		this.dataGridViewTextBoxColumn_31.Name = Class16.smethod_0(1649065590);
		this.dataGridViewTextBoxColumn_31.ReadOnly = true;
		this.dataGridViewTextBoxColumn_31.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
		this.dataGridViewTextBoxColumn_31.Width = 50;
		this.dataGridViewTextBoxColumn_32.HeaderText = Class16.smethod_0(1648936731);
		this.dataGridViewTextBoxColumn_32.Name = Class16.smethod_0(1649065623);
		this.dataGridViewTextBoxColumn_32.ReadOnly = true;
		this.dataGridViewTextBoxColumn_32.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
		this.dataGridViewTextBoxColumn_32.Width = 125;
		this.button_7.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.button_7.ForeColor = System.Drawing.Color.Black;
		this.button_7.Image = ACE.Properties.Resources.mnuClone;
		this.button_7.Location = new System.Drawing.Point(378, 198);
		this.button_7.Name = Class16.smethod_0(1649113809);
		this.button_7.Size = new System.Drawing.Size(110, 29);
		this.button_7.TabIndex = 15;
		this.button_7.Text = Class16.smethod_0(1648931357);
		this.button_7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.button_7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		this.button_7.UseVisualStyleBackColor = true;
		this.button_7.Click += new System.EventHandler(button_7_Click);
		this.label_33.AutoSize = true;
		this.label_33.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_33.Location = new System.Drawing.Point(191, 60);
		this.label_33.Name = Class16.smethod_0(1649113841);
		this.label_33.Size = new System.Drawing.Size(100, 15);
		this.label_33.TabIndex = 57;
		this.label_33.Text = Class16.smethod_0(1649113863);
		this.button_8.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.button_8.ForeColor = System.Drawing.Color.Black;
		this.button_8.Image = ACE.Properties.Resources.NpcGenEditorForm_ExistenceGroupRemoveButton;
		this.button_8.Location = new System.Drawing.Point(488, 198);
		this.button_8.Name = Class16.smethod_0(1649113886);
		this.button_8.Size = new System.Drawing.Size(110, 29);
		this.button_8.TabIndex = 16;
		this.button_8.Text = Class16.smethod_0(1648925718);
		this.button_8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.button_8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		this.button_8.UseVisualStyleBackColor = true;
		this.button_8.Click += new System.EventHandler(button_8_Click);
		this.numericUpDown_26.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.numericUpDown_26.DecimalPlaces = 3;
		this.numericUpDown_26.Increment = new decimal(new int[4] { 3, 0, 0, 0 });
		this.numericUpDown_26.Location = new System.Drawing.Point(293, 14);
		this.numericUpDown_26.Maximum = new decimal(new int[4] { 2147483647, 0, 0, 0 });
		this.numericUpDown_26.Minimum = new decimal(new int[4] { -2147483648, 0, 0, -2147483648 });
		this.numericUpDown_26.Name = Class16.smethod_0(1649113919);
		this.numericUpDown_26.Size = new System.Drawing.Size(80, 20);
		this.numericUpDown_26.TabIndex = 54;
		this.numericUpDown_26.KeyDown += new System.Windows.Forms.KeyEventHandler(numericUpDown_15_KeyDown);
		this.numericUpDown_26.Leave += new System.EventHandler(numericUpDown_15_Leave);
		this.label_32.AutoSize = true;
		this.label_32.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_32.Location = new System.Drawing.Point(213, 14);
		this.label_32.Name = Class16.smethod_0(1649113930);
		this.label_32.Size = new System.Drawing.Size(78, 15);
		this.label_32.TabIndex = 55;
		this.label_32.Text = Class16.smethod_0(1649113944);
		this.numericUpDown_27.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.numericUpDown_27.DecimalPlaces = 3;
		this.numericUpDown_27.Location = new System.Drawing.Point(108, 200);
		this.numericUpDown_27.Maximum = new decimal(new int[4] { 2147483647, 0, 0, 0 });
		this.numericUpDown_27.Minimum = new decimal(new int[4] { -2147483648, 0, 0, -2147483648 });
		this.numericUpDown_27.Name = Class16.smethod_0(1649113973);
		this.numericUpDown_27.Size = new System.Drawing.Size(80, 20);
		this.numericUpDown_27.TabIndex = 52;
		this.numericUpDown_27.KeyDown += new System.Windows.Forms.KeyEventHandler(numericUpDown_15_KeyDown);
		this.numericUpDown_27.Leave += new System.EventHandler(numericUpDown_15_Leave);
		this.numericUpDown_17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.numericUpDown_17.Location = new System.Drawing.Point(108, 177);
		this.numericUpDown_17.Maximum = new decimal(new int[4] { 2147483647, 0, 0, 0 });
		this.numericUpDown_17.Minimum = new decimal(new int[4] { -2147483648, 0, 0, -2147483648 });
		this.numericUpDown_17.Name = Class16.smethod_0(1649113985);
		this.numericUpDown_17.Size = new System.Drawing.Size(80, 20);
		this.numericUpDown_17.TabIndex = 50;
		this.numericUpDown_17.KeyDown += new System.Windows.Forms.KeyEventHandler(numericUpDown_15_KeyDown);
		this.numericUpDown_17.Leave += new System.EventHandler(numericUpDown_15_Leave);
		this.numericUpDown_18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.numericUpDown_18.Location = new System.Drawing.Point(108, 154);
		this.numericUpDown_18.Maximum = new decimal(new int[4] { 2147483647, 0, 0, 0 });
		this.numericUpDown_18.Minimum = new decimal(new int[4] { -2147483648, 0, 0, -2147483648 });
		this.numericUpDown_18.Name = Class16.smethod_0(1649114012);
		this.numericUpDown_18.Size = new System.Drawing.Size(80, 20);
		this.numericUpDown_18.TabIndex = 48;
		this.numericUpDown_18.KeyDown += new System.Windows.Forms.KeyEventHandler(numericUpDown_15_KeyDown);
		this.numericUpDown_18.Leave += new System.EventHandler(numericUpDown_15_Leave);
		this.comboBox_13.BackColor = System.Drawing.Color.FromArgb(255, 192, 128);
		this.comboBox_13.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.comboBox_13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.comboBox_13.FormattingEnabled = true;
		this.comboBox_13.Items.AddRange(new object[3]
		{
			Class16.smethod_0(1648924120),
			Class16.smethod_0(1649007069),
			Class16.smethod_0(1649114029)
		});
		this.comboBox_13.Location = new System.Drawing.Point(108, 130);
		this.comboBox_13.Name = Class16.smethod_0(1649114034);
		this.comboBox_13.Size = new System.Drawing.Size(80, 21);
		this.comboBox_13.TabIndex = 46;
		this.comboBox_13.KeyDown += new System.Windows.Forms.KeyEventHandler(numericUpDown_15_KeyDown);
		this.comboBox_13.Leave += new System.EventHandler(numericUpDown_15_Leave);
		this.comboBox_2.BackColor = System.Drawing.Color.FromArgb(255, 192, 128);
		this.comboBox_2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.comboBox_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.comboBox_2.FormattingEnabled = true;
		this.comboBox_2.Items.AddRange(new object[3]
		{
			Class16.smethod_0(1648924120),
			Class16.smethod_0(1649114050),
			Class16.smethod_0(1649114067)
		});
		this.comboBox_2.Location = new System.Drawing.Point(108, 106);
		this.comboBox_2.Name = Class16.smethod_0(1649114083);
		this.comboBox_2.Size = new System.Drawing.Size(80, 21);
		this.comboBox_2.TabIndex = 37;
		this.comboBox_2.KeyDown += new System.Windows.Forms.KeyEventHandler(numericUpDown_15_KeyDown);
		this.comboBox_2.Leave += new System.EventHandler(numericUpDown_15_Leave);
		this.numericUpDown_13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.numericUpDown_13.Location = new System.Drawing.Point(108, 83);
		this.numericUpDown_13.Maximum = new decimal(new int[4] { 2147483647, 0, 0, 0 });
		this.numericUpDown_13.Minimum = new decimal(new int[4] { -2147483648, 0, 0, -2147483648 });
		this.numericUpDown_13.Name = Class16.smethod_0(1649114099);
		this.numericUpDown_13.Size = new System.Drawing.Size(80, 20);
		this.numericUpDown_13.TabIndex = 44;
		this.numericUpDown_13.KeyDown += new System.Windows.Forms.KeyEventHandler(numericUpDown_15_KeyDown);
		this.numericUpDown_13.Leave += new System.EventHandler(numericUpDown_15_Leave);
		this.numericUpDown_21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.numericUpDown_21.Location = new System.Drawing.Point(108, 60);
		this.numericUpDown_21.Maximum = new decimal(new int[4] { 2147483647, 0, 0, 0 });
		this.numericUpDown_21.Minimum = new decimal(new int[4] { -2147483648, 0, 0, -2147483648 });
		this.numericUpDown_21.Name = Class16.smethod_0(1649113109);
		this.numericUpDown_21.Size = new System.Drawing.Size(80, 20);
		this.numericUpDown_21.TabIndex = 42;
		this.numericUpDown_21.KeyDown += new System.Windows.Forms.KeyEventHandler(numericUpDown_15_KeyDown);
		this.numericUpDown_21.Leave += new System.EventHandler(numericUpDown_15_Leave);
		this.label_24.AutoSize = true;
		this.label_24.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_24.Location = new System.Drawing.Point(18, 60);
		this.label_24.Name = Class16.smethod_0(1649113123);
		this.label_24.Size = new System.Drawing.Size(89, 15);
		this.label_24.TabIndex = 41;
		this.label_24.Text = Class16.smethod_0(1649113137);
		this.numericUpDown_10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.numericUpDown_10.Location = new System.Drawing.Point(108, 37);
		this.numericUpDown_10.Maximum = new decimal(new int[4] { 2147483647, 0, 0, 0 });
		this.numericUpDown_10.Minimum = new decimal(new int[4] { -2147483648, 0, 0, -2147483648 });
		this.numericUpDown_10.Name = Class16.smethod_0(1649113165);
		this.numericUpDown_10.Size = new System.Drawing.Size(80, 20);
		this.numericUpDown_10.TabIndex = 40;
		this.numericUpDown_10.KeyDown += new System.Windows.Forms.KeyEventHandler(numericUpDown_15_KeyDown);
		this.numericUpDown_10.Leave += new System.EventHandler(numericUpDown_15_Leave);
		this.label_23.AutoSize = true;
		this.label_23.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_23.Location = new System.Drawing.Point(53, 37);
		this.label_23.Name = Class16.smethod_0(1649113178);
		this.label_23.Size = new System.Drawing.Size(54, 15);
		this.label_23.TabIndex = 39;
		this.label_23.Text = Class16.smethod_0(1649112443);
		this.numericUpDown_15.BackColor = System.Drawing.Color.FromArgb(128, 255, 128);
		this.numericUpDown_15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.numericUpDown_15.Location = new System.Drawing.Point(108, 14);
		this.numericUpDown_15.Maximum = new decimal(new int[4] { 2147483647, 0, 0, 0 });
		this.numericUpDown_15.Minimum = new decimal(new int[4] { -2147483648, 0, 0, -2147483648 });
		this.numericUpDown_15.Name = Class16.smethod_0(1649113192);
		this.numericUpDown_15.Size = new System.Drawing.Size(80, 20);
		this.numericUpDown_15.TabIndex = 38;
		this.numericUpDown_15.MouseEnter += new System.EventHandler(numericUpDown_15_MouseEnter);
		this.numericUpDown_15.MouseLeave += new System.EventHandler(numericUpDown_15_MouseLeave);
		this.numericUpDown_15.MouseMove += new System.Windows.Forms.MouseEventHandler(numericUpDown_15_MouseMove);
		this.numericUpDown_15.DoubleClick += new System.EventHandler(numericUpDown_15_DoubleClick);
		this.numericUpDown_15.KeyDown += new System.Windows.Forms.KeyEventHandler(numericUpDown_15_KeyDown);
		this.numericUpDown_15.Leave += new System.EventHandler(numericUpDown_15_Leave);
		this.label_22.AutoSize = true;
		this.label_22.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_22.Location = new System.Drawing.Point(85, 15);
		this.label_22.Name = Class16.smethod_0(1649113209);
		this.label_22.Size = new System.Drawing.Size(22, 15);
		this.label_22.TabIndex = 37;
		this.label_22.Text = Class16.smethod_0(1648930840);
		this.label_30.AutoSize = true;
		this.label_30.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_30.Location = new System.Drawing.Point(33, 201);
		this.label_30.Name = Class16.smethod_0(1649113231);
		this.label_30.Size = new System.Drawing.Size(74, 15);
		this.label_30.TabIndex = 53;
		this.label_30.Text = Class16.smethod_0(1649113245);
		this.label_36.AutoSize = true;
		this.label_36.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_36.Location = new System.Drawing.Point(204, 130);
		this.label_36.Name = Class16.smethod_0(1649113259);
		this.label_36.Size = new System.Drawing.Size(87, 15);
		this.label_36.TabIndex = 64;
		this.label_36.Text = Class16.smethod_0(1649113273);
		this.label_25.AutoSize = true;
		this.label_25.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_25.Location = new System.Drawing.Point(-1, 83);
		this.label_25.Name = Class16.smethod_0(1649113301);
		this.label_25.Size = new System.Drawing.Size(108, 15);
		this.label_25.TabIndex = 43;
		this.label_25.Text = Class16.smethod_0(1649113307);
		this.label_28.AutoSize = true;
		this.label_28.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_28.Location = new System.Drawing.Point(61, 154);
		this.label_28.Name = Class16.smethod_0(1649111462);
		this.label_28.Size = new System.Drawing.Size(46, 15);
		this.label_28.TabIndex = 49;
		this.label_28.Text = Class16.smethod_0(1649113331);
		this.label_27.AutoSize = true;
		this.label_27.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_27.Location = new System.Drawing.Point(47, 130);
		this.label_27.Name = Class16.smethod_0(1649111416);
		this.label_27.Size = new System.Drawing.Size(60, 15);
		this.label_27.TabIndex = 47;
		this.label_27.Text = Class16.smethod_0(1649113344);
		this.label_29.AutoSize = true;
		this.label_29.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_29.Location = new System.Drawing.Point(72, 177);
		this.label_29.Name = Class16.smethod_0(1649111483);
		this.label_29.Size = new System.Drawing.Size(35, 15);
		this.label_29.TabIndex = 51;
		this.label_29.Text = Class16.smethod_0(1649116897);
		this.label_26.AutoSize = true;
		this.label_26.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_26.Location = new System.Drawing.Point(36, 106);
		this.label_26.Name = Class16.smethod_0(1649113361);
		this.label_26.Size = new System.Drawing.Size(71, 15);
		this.label_26.TabIndex = 45;
		this.label_26.Text = Class16.smethod_0(1649112420);
		this.label_35.AutoSize = true;
		this.label_35.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_35.Location = new System.Drawing.Point(176, 107);
		this.label_35.Name = Class16.smethod_0(1649113383);
		this.label_35.Size = new System.Drawing.Size(115, 15);
		this.label_35.TabIndex = 62;
		this.label_35.Text = Class16.smethod_0(1649113397);
		this.dataGridView_4.AllowUserToAddRows = false;
		this.dataGridView_4.AllowUserToDeleteRows = false;
		this.dataGridView_4.AllowUserToResizeColumns = false;
		this.dataGridView_4.AllowUserToResizeRows = false;
		this.dataGridView_4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.dataGridView_4.BackgroundColor = System.Drawing.Color.FromArgb(15, 15, 15);
		this.dataGridView_4.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
		this.dataGridView_4.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
		dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
		dataGridViewCellStyle4.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 8.25f);
		dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
		dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
		dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
		this.dataGridView_4.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
		this.dataGridView_4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridView_4.Columns.AddRange(this.dataGridViewTextBoxColumn_4, this.dataGridViewTextBoxColumn_15, this.dataGridViewTextBoxColumn_3);
		this.dataGridView_4.ContextMenuStrip = this.contextMenuStrip_2;
		dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(15, 15, 15);
		dataGridViewCellStyle5.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 8.25f);
		dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
		dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
		dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
		this.dataGridView_4.DefaultCellStyle = dataGridViewCellStyle5;
		this.dataGridView_4.EnableHeadersVisualStyles = false;
		this.dataGridView_4.Location = new System.Drawing.Point(1, 29);
		this.dataGridView_4.Name = Class16.smethod_0(1649113422);
		this.dataGridView_4.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
		this.dataGridView_4.RowHeadersVisible = false;
		this.dataGridView_4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		this.dataGridView_4.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		this.dataGridView_4.ShowCellErrors = false;
		this.dataGridView_4.ShowCellToolTips = false;
		this.dataGridView_4.ShowEditingIcon = false;
		this.dataGridView_4.ShowRowErrors = false;
		this.dataGridView_4.Size = new System.Drawing.Size(359, 425);
		this.dataGridView_4.TabIndex = 15;
		this.dataGridView_4.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(dataGridView_4_CellMouseEnter);
		this.dataGridView_4.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(dataGridView_4_CellMouseLeave);
		this.dataGridView_4.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(dataGridView_4_CellMouseMove);
		this.dataGridView_4.CurrentCellChanged += new System.EventHandler(dataGridView_4_CurrentCellChanged);
		this.dataGridView_4.KeyDown += new System.Windows.Forms.KeyEventHandler(dataGridView_10_KeyDown);
		dataGridViewCellStyle6.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.dataGridViewTextBoxColumn_4.DefaultCellStyle = dataGridViewCellStyle6;
		this.dataGridViewTextBoxColumn_4.FillWeight = 6.912442f;
		this.dataGridViewTextBoxColumn_4.HeaderText = Class16.smethod_0(1648929947);
		this.dataGridViewTextBoxColumn_4.Name = Class16.smethod_0(1648910847);
		this.dataGridViewTextBoxColumn_4.ReadOnly = true;
		this.dataGridViewTextBoxColumn_4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
		this.dataGridViewTextBoxColumn_4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
		this.dataGridViewTextBoxColumn_4.Width = 45;
		dataGridViewCellStyle7.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(77, 255, 143);
		this.dataGridViewTextBoxColumn_15.DefaultCellStyle = dataGridViewCellStyle7;
		this.dataGridViewTextBoxColumn_15.FillWeight = 44.7233f;
		this.dataGridViewTextBoxColumn_15.HeaderText = Class16.smethod_0(1649118934);
		this.dataGridViewTextBoxColumn_15.Name = Class16.smethod_0(1648914199);
		this.dataGridViewTextBoxColumn_15.ReadOnly = true;
		this.dataGridViewTextBoxColumn_15.Resizable = System.Windows.Forms.DataGridViewTriState.False;
		this.dataGridViewTextBoxColumn_15.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
		this.dataGridViewTextBoxColumn_15.Width = 95;
		dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
		this.dataGridViewTextBoxColumn_3.DefaultCellStyle = dataGridViewCellStyle8;
		this.dataGridViewTextBoxColumn_3.HeaderText = Class16.smethod_0(1648936731);
		this.dataGridViewTextBoxColumn_3.Name = Class16.smethod_0(1648963847);
		this.dataGridViewTextBoxColumn_3.ReadOnly = true;
		this.dataGridViewTextBoxColumn_3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
		this.dataGridViewTextBoxColumn_3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
		this.dataGridViewTextBoxColumn_3.Width = 217;
		this.contextMenuStrip_2.Items.AddRange(new System.Windows.Forms.ToolStripItem[8] { this.toolStripMenuItem_4, this.toolStripMenuItem_5, this.toolStripSeparator_0, this.toolStripMenuItem_16, this.toolStripSeparator_1, this.toolStripMenuItem_30, this.toolStripMenuItem_29, this.toolStripMenuItem_31 });
		this.contextMenuStrip_2.Name = Class16.smethod_0(1649113432);
		this.contextMenuStrip_2.Size = new System.Drawing.Size(125, 126);
		this.contextMenuStrip_2.Text = Class16.smethod_0(1649073450);
		this.toolStripMenuItem_4.Image = ACE.Properties.Resources.NpcGenEditorForm_LineUpX;
		this.toolStripMenuItem_4.Name = Class16.smethod_0(1649113462);
		this.toolStripMenuItem_4.Size = new System.Drawing.Size(124, 22);
		this.toolStripMenuItem_4.Text = Class16.smethod_0(1649113476);
		this.toolStripMenuItem_4.Click += new System.EventHandler(toolStripMenuItem_23_Click);
		this.toolStripMenuItem_5.Image = ACE.Properties.Resources.NpcGenEditorForm_LineUpZ;
		this.toolStripMenuItem_5.Name = Class16.smethod_0(1649113492);
		this.toolStripMenuItem_5.Size = new System.Drawing.Size(124, 22);
		this.toolStripMenuItem_5.Text = Class16.smethod_0(1649113498);
		this.toolStripMenuItem_5.Click += new System.EventHandler(toolStripMenuItem_24_Click);
		this.toolStripSeparator_0.Name = Class16.smethod_0(1648920981);
		this.toolStripSeparator_0.Size = new System.Drawing.Size(121, 6);
		this.toolStripMenuItem_16.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[5] { this.toolStripMenuItem_26, this.toolStripMenuItem_1, this.toolStripSeparator_3, this.toolStripMenuItem_28, this.toolStripMenuItem_3 });
		this.toolStripMenuItem_16.Image = ACE.Properties.Resources.NpcGenEditorForm_Move;
		this.toolStripMenuItem_16.Name = Class16.smethod_0(1649012245);
		this.toolStripMenuItem_16.Size = new System.Drawing.Size(124, 22);
		this.toolStripMenuItem_16.Text = Class16.smethod_0(1649113514);
		this.toolStripMenuItem_26.Image = ACE.Properties.Resources.NpcGenEditorForm_UpExistence;
		this.toolStripMenuItem_26.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.toolStripMenuItem_26.Name = Class16.smethod_0(1649113533);
		this.toolStripMenuItem_26.Size = new System.Drawing.Size(164, 22);
		this.toolStripMenuItem_26.Text = Class16.smethod_0(1649113551);
		this.toolStripMenuItem_26.Click += new System.EventHandler(toolStripMenuItem_20_Click);
		this.toolStripMenuItem_1.Image = ACE.Properties.Resources.NpcGenEditorForm_DownExistence;
		this.toolStripMenuItem_1.Name = Class16.smethod_0(1649113563);
		this.toolStripMenuItem_1.Size = new System.Drawing.Size(164, 22);
		this.toolStripMenuItem_1.Text = Class16.smethod_0(1649113591);
		this.toolStripMenuItem_1.Click += new System.EventHandler(toolStripMenuItem_21_Click);
		this.toolStripSeparator_3.Name = Class16.smethod_0(1649038932);
		this.toolStripSeparator_3.Size = new System.Drawing.Size(161, 6);
		this.toolStripMenuItem_28.Name = Class16.smethod_0(1649108483);
		this.toolStripMenuItem_28.Size = new System.Drawing.Size(164, 22);
		this.toolStripMenuItem_28.Text = Class16.smethod_0(1649068439);
		this.toolStripMenuItem_3.Name = Class16.smethod_0(1649108519);
		this.toolStripMenuItem_3.Size = new System.Drawing.Size(164, 22);
		this.toolStripMenuItem_3.Text = Class16.smethod_0(1649108540);
		this.toolStripMenuItem_3.Click += new System.EventHandler(toolStripMenuItem_3_Click);
		this.toolStripSeparator_1.Name = Class16.smethod_0(1648921077);
		this.toolStripSeparator_1.Size = new System.Drawing.Size(121, 6);
		this.toolStripMenuItem_30.Image = ACE.Properties.Resources.NpcGenEditorForm_ExportExistence;
		this.toolStripMenuItem_30.Name = Class16.smethod_0(1649108557);
		this.toolStripMenuItem_30.Size = new System.Drawing.Size(124, 22);
		this.toolStripMenuItem_30.Text = Class16.smethod_0(1648931384);
		this.toolStripMenuItem_30.Click += new System.EventHandler(toolStripButton_6_Click);
		this.toolStripMenuItem_29.Image = ACE.Properties.Resources.NpcGenEditorForm_ImportExistence;
		this.toolStripMenuItem_29.Name = Class16.smethod_0(1649108579);
		this.toolStripMenuItem_29.Size = new System.Drawing.Size(124, 22);
		this.toolStripMenuItem_29.Text = Class16.smethod_0(1648931405);
		this.toolStripMenuItem_29.Click += new System.EventHandler(toolStripButton_7_Click);
		this.groupBox_20.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.groupBox_20.BackColor = System.Drawing.Color.FromArgb(239, 244, 250);
		this.groupBox_20.Controls.Add(this.button_9);
		this.groupBox_20.Controls.Add(this.groupBox_18);
		this.groupBox_20.Controls.Add(this.textBox_19);
		this.groupBox_20.Controls.Add(this.textBox_20);
		this.groupBox_20.Controls.Add(this.textBox_42);
		this.groupBox_20.Controls.Add(this.label_19);
		this.groupBox_20.Controls.Add(this.textBox_6);
		this.groupBox_20.Controls.Add(this.label_18);
		this.groupBox_20.Controls.Add(this.checkBox_4);
		this.groupBox_20.Controls.Add(this.checkBox_5);
		this.groupBox_20.Controls.Add(this.checkBox_6);
		this.groupBox_20.Controls.Add(this.textBox_18);
		this.groupBox_20.Controls.Add(this.label_17);
		this.groupBox_20.Controls.Add(this.comboBox_8);
		this.groupBox_20.Controls.Add(this.label_16);
		this.groupBox_20.Controls.Add(this.textBox_66);
		this.groupBox_20.Controls.Add(this.label_13);
		this.groupBox_20.Controls.Add(this.textBox_63);
		this.groupBox_20.Controls.Add(this.label_14);
		this.groupBox_20.Controls.Add(this.textBox_60);
		this.groupBox_20.Controls.Add(this.label_15);
		this.groupBox_20.Controls.Add(this.textBox_65);
		this.groupBox_20.Controls.Add(this.label_12);
		this.groupBox_20.Controls.Add(this.textBox_62);
		this.groupBox_20.Controls.Add(this.label_2);
		this.groupBox_20.Controls.Add(this.textBox_59);
		this.groupBox_20.Controls.Add(this.textBox_64);
		this.groupBox_20.Controls.Add(this.textBox_61);
		this.groupBox_20.Controls.Add(this.label_97);
		this.groupBox_20.Controls.Add(this.textBox_58);
		this.groupBox_20.Controls.Add(this.label_86);
		this.groupBox_20.Controls.Add(this.label_75);
		this.groupBox_20.Controls.Add(this.label_64);
		this.groupBox_20.Controls.Add(this.textBox_17);
		this.groupBox_20.Controls.Add(this.comboBox_7);
		this.groupBox_20.Controls.Add(this.label_31);
		this.groupBox_20.Controls.Add(this.label_53);
		this.groupBox_20.Controls.Add(this.label_20);
		this.groupBox_20.Controls.Add(this.label_21);
		this.groupBox_20.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.groupBox_20.Location = new System.Drawing.Point(364, 1);
		this.groupBox_20.Name = Class16.smethod_0(1649108609);
		this.groupBox_20.Size = new System.Drawing.Size(599, 250);
		this.groupBox_20.TabIndex = 12;
		this.groupBox_20.TabStop = false;
		this.groupBox_20.Text = Class16.smethod_0(1648898876);
		this.button_9.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.button_9.ForeColor = System.Drawing.Color.Maroon;
		this.button_9.Location = new System.Drawing.Point(342, 187);
		this.button_9.Name = Class16.smethod_0(1649108636);
		this.button_9.Size = new System.Drawing.Size(252, 52);
		this.button_9.TabIndex = 67;
		this.button_9.Text = Class16.smethod_0(1649108671);
		this.button_9.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		this.button_9.UseVisualStyleBackColor = true;
		this.button_9.Click += new System.EventHandler(button_9_Click);
		this.groupBox_18.BackColor = System.Drawing.Color.FromArgb(239, 244, 250);
		this.groupBox_18.Controls.Add(this.numericUpDown_4);
		this.groupBox_18.Controls.Add(this.label_68);
		this.groupBox_18.Controls.Add(this.numericUpDown_2);
		this.groupBox_18.Controls.Add(this.label_69);
		this.groupBox_18.Controls.Add(this.numericUpDown_3);
		this.groupBox_18.Controls.Add(this.label_70);
		this.groupBox_18.Controls.Add(this.comboBox_1);
		this.groupBox_18.Controls.Add(this.label_71);
		this.groupBox_18.Controls.Add(this.comboBox_0);
		this.groupBox_18.Controls.Add(this.numericUpDown_5);
		this.groupBox_18.Controls.Add(this.label_72);
		this.groupBox_18.Controls.Add(this.label_73);
		this.groupBox_18.Location = new System.Drawing.Point(342, 11);
		this.groupBox_18.Name = Class16.smethod_0(1649108698);
		this.groupBox_18.Size = new System.Drawing.Size(252, 171);
		this.groupBox_18.TabIndex = 18;
		this.groupBox_18.TabStop = false;
		this.groupBox_18.Text = Class16.smethod_0(1649108714);
		this.numericUpDown_4.BackColor = System.Drawing.SystemColors.Window;
		this.numericUpDown_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.numericUpDown_4.Location = new System.Drawing.Point(157, 135);
		this.numericUpDown_4.Maximum = new decimal(new int[4] { 2147483647, 0, 0, 0 });
		this.numericUpDown_4.Minimum = new decimal(new int[4] { -2147483648, 0, 0, -2147483648 });
		this.numericUpDown_4.Name = Class16.smethod_0(1649108754);
		this.numericUpDown_4.Size = new System.Drawing.Size(76, 20);
		this.numericUpDown_4.TabIndex = 49;
		this.numericUpDown_4.Value = new decimal(new int[4] { 60, 0, 0, 0 });
		this.label_68.AutoSize = true;
		this.label_68.Location = new System.Drawing.Point(74, 137);
		this.label_68.Name = Class16.smethod_0(1649108790);
		this.label_68.Size = new System.Drawing.Size(77, 13);
		this.label_68.TabIndex = 48;
		this.label_68.Text = Class16.smethod_0(1649113137);
		this.numericUpDown_2.BackColor = System.Drawing.SystemColors.Window;
		this.numericUpDown_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.numericUpDown_2.Location = new System.Drawing.Point(157, 112);
		this.numericUpDown_2.Maximum = new decimal(new int[4] { 2147483647, 0, 0, 0 });
		this.numericUpDown_2.Minimum = new decimal(new int[4] { -2147483648, 0, 0, -2147483648 });
		this.numericUpDown_2.Name = Class16.smethod_0(1649108804);
		this.numericUpDown_2.Size = new System.Drawing.Size(76, 20);
		this.numericUpDown_2.TabIndex = 47;
		this.numericUpDown_2.Value = new decimal(new int[4] { 1, 0, 0, 0 });
		this.label_69.AutoSize = true;
		this.label_69.Location = new System.Drawing.Point(44, 114);
		this.label_69.Name = Class16.smethod_0(1649108819);
		this.label_69.Size = new System.Drawing.Size(107, 13);
		this.label_69.TabIndex = 46;
		this.label_69.Text = Class16.smethod_0(1649108833);
		this.numericUpDown_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.numericUpDown_3.Location = new System.Drawing.Point(157, 88);
		this.numericUpDown_3.Maximum = new decimal(new int[4] { 2147483647, 0, 0, 0 });
		this.numericUpDown_3.Minimum = new decimal(new int[4] { -2147483648, 0, 0, -2147483648 });
		this.numericUpDown_3.Name = Class16.smethod_0(1649108868);
		this.numericUpDown_3.Size = new System.Drawing.Size(76, 20);
		this.numericUpDown_3.TabIndex = 45;
		this.numericUpDown_3.Value = new decimal(new int[4] { 16, 0, 0, 0 });
		this.label_70.AutoSize = true;
		this.label_70.Location = new System.Drawing.Point(87, 91);
		this.label_70.Name = Class16.smethod_0(1649108887);
		this.label_70.Size = new System.Drawing.Size(64, 13);
		this.label_70.TabIndex = 44;
		this.label_70.Text = Class16.smethod_0(1649108901);
		this.comboBox_1.BackColor = System.Drawing.Color.Silver;
		this.comboBox_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.comboBox_1.FormattingEnabled = true;
		this.comboBox_1.Items.AddRange(new object[2]
		{
			Class16.smethod_0(1649108912),
			Class16.smethod_0(1649007040)
		});
		this.comboBox_1.Location = new System.Drawing.Point(157, 63);
		this.comboBox_1.Name = Class16.smethod_0(1649108922);
		this.comboBox_1.Size = new System.Drawing.Size(76, 21);
		this.comboBox_1.TabIndex = 43;
		this.label_71.AutoSize = true;
		this.label_71.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_71.Location = new System.Drawing.Point(65, 64);
		this.label_71.Name = Class16.smethod_0(1649108951);
		this.label_71.Size = new System.Drawing.Size(86, 15);
		this.label_71.TabIndex = 42;
		this.label_71.Text = Class16.smethod_0(1649108965);
		this.comboBox_0.BackColor = System.Drawing.Color.Silver;
		this.comboBox_0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.comboBox_0.FormattingEnabled = true;
		this.comboBox_0.Items.AddRange(new object[2]
		{
			Class16.smethod_0(1649108978),
			Class16.smethod_0(1649112009)
		});
		this.comboBox_0.Location = new System.Drawing.Point(157, 40);
		this.comboBox_0.Name = Class16.smethod_0(1649107975);
		this.comboBox_0.Size = new System.Drawing.Size(76, 21);
		this.comboBox_0.TabIndex = 41;
		this.numericUpDown_5.BackColor = System.Drawing.SystemColors.Window;
		this.numericUpDown_5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.numericUpDown_5.Location = new System.Drawing.Point(157, 17);
		this.numericUpDown_5.Maximum = new decimal(new int[4] { 2147483647, 0, 0, 0 });
		this.numericUpDown_5.Minimum = new decimal(new int[4] { -2147483648, 0, 0, -2147483648 });
		this.numericUpDown_5.Name = Class16.smethod_0(1649107993);
		this.numericUpDown_5.Size = new System.Drawing.Size(76, 20);
		this.numericUpDown_5.TabIndex = 39;
		this.label_72.AutoSize = true;
		this.label_72.Location = new System.Drawing.Point(94, 20);
		this.label_72.Name = Class16.smethod_0(1649108017);
		this.label_72.Size = new System.Drawing.Size(57, 13);
		this.label_72.TabIndex = 0;
		this.label_72.Text = Class16.smethod_0(1649108039);
		this.label_73.AutoSize = true;
		this.label_73.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_73.Location = new System.Drawing.Point(94, 41);
		this.label_73.Name = Class16.smethod_0(1649108049);
		this.label_73.Size = new System.Drawing.Size(57, 15);
		this.label_73.TabIndex = 40;
		this.label_73.Text = Class16.smethod_0(1649111185);
		this.textBox_19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.textBox_19.Location = new System.Drawing.Point(245, 153);
		this.textBox_19.Name = Class16.smethod_0(1649108071);
		this.textBox_19.Size = new System.Drawing.Size(91, 20);
		this.textBox_19.TabIndex = 35;
		this.textBox_19.KeyDown += new System.Windows.Forms.KeyEventHandler(comboBox_7_KeyDown);
		this.textBox_19.Leave += new System.EventHandler(comboBox_7_Leave);
		this.textBox_20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.textBox_20.Location = new System.Drawing.Point(245, 130);
		this.textBox_20.Name = Class16.smethod_0(1649108086);
		this.textBox_20.Size = new System.Drawing.Size(91, 20);
		this.textBox_20.TabIndex = 33;
		this.textBox_20.KeyDown += new System.Windows.Forms.KeyEventHandler(comboBox_7_KeyDown);
		this.textBox_20.Leave += new System.EventHandler(comboBox_7_Leave);
		this.textBox_42.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.textBox_42.ContextMenuStrip = this.contextMenuStrip_1;
		this.textBox_42.Location = new System.Drawing.Point(245, 107);
		this.textBox_42.Name = Class16.smethod_0(1649108102);
		this.textBox_42.Size = new System.Drawing.Size(91, 20);
		this.textBox_42.TabIndex = 31;
		this.textBox_42.KeyDown += new System.Windows.Forms.KeyEventHandler(comboBox_7_KeyDown);
		this.textBox_42.Leave += new System.EventHandler(comboBox_7_Leave);
		this.contextMenuStrip_1.Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.toolStripMenuItem_8 });
		this.contextMenuStrip_1.Name = Class16.smethod_0(1649113432);
		this.contextMenuStrip_1.Size = new System.Drawing.Size(157, 26);
		this.contextMenuStrip_1.Text = Class16.smethod_0(1649073450);
		this.toolStripMenuItem_8.Image = ACE.Properties.Resources.NpcGenEditorForm_MoveToTrigger;
		this.toolStripMenuItem_8.Name = Class16.smethod_0(1649108116);
		this.toolStripMenuItem_8.Size = new System.Drawing.Size(156, 22);
		this.toolStripMenuItem_8.Text = Class16.smethod_0(1649108128);
		this.toolStripMenuItem_8.Click += new System.EventHandler(toolStripMenuItem_8_Click);
		this.label_19.AutoSize = true;
		this.label_19.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_19.Location = new System.Drawing.Point(193, 109);
		this.label_19.Name = Class16.smethod_0(1648913063);
		this.label_19.Size = new System.Drawing.Size(49, 15);
		this.label_19.TabIndex = 32;
		this.label_19.Text = Class16.smethod_0(1649111262);
		this.textBox_6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.textBox_6.Location = new System.Drawing.Point(245, 83);
		this.textBox_6.Name = Class16.smethod_0(1649108158);
		this.textBox_6.Size = new System.Drawing.Size(91, 20);
		this.textBox_6.TabIndex = 29;
		this.textBox_6.KeyDown += new System.Windows.Forms.KeyEventHandler(comboBox_7_KeyDown);
		this.textBox_6.Leave += new System.EventHandler(comboBox_7_Leave);
		this.label_18.AutoSize = true;
		this.label_18.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_18.Location = new System.Drawing.Point(183, 85);
		this.label_18.Name = Class16.smethod_0(1648913168);
		this.label_18.Size = new System.Drawing.Size(59, 15);
		this.label_18.TabIndex = 30;
		this.label_18.Text = Class16.smethod_0(1649108172);
		this.checkBox_4.AutoSize = true;
		this.checkBox_4.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.checkBox_4.Location = new System.Drawing.Point(261, 221);
		this.checkBox_4.Name = Class16.smethod_0(1649108179);
		this.checkBox_4.Size = new System.Drawing.Size(75, 17);
		this.checkBox_4.TabIndex = 28;
		this.checkBox_4.Text = Class16.smethod_0(1649111951);
		this.checkBox_4.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
		this.checkBox_4.UseVisualStyleBackColor = true;
		this.checkBox_4.KeyDown += new System.Windows.Forms.KeyEventHandler(comboBox_7_KeyDown);
		this.checkBox_4.Leave += new System.EventHandler(comboBox_7_Leave);
		this.checkBox_5.AutoSize = true;
		this.checkBox_5.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.checkBox_5.Location = new System.Drawing.Point(235, 200);
		this.checkBox_5.Name = Class16.smethod_0(1649108204);
		this.checkBox_5.Size = new System.Drawing.Size(101, 17);
		this.checkBox_5.TabIndex = 27;
		this.checkBox_5.Text = Class16.smethod_0(1649111910);
		this.checkBox_5.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
		this.checkBox_5.UseVisualStyleBackColor = true;
		this.checkBox_5.KeyDown += new System.Windows.Forms.KeyEventHandler(comboBox_7_KeyDown);
		this.checkBox_5.Leave += new System.EventHandler(comboBox_7_Leave);
		this.checkBox_6.AutoSize = true;
		this.checkBox_6.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.checkBox_6.Location = new System.Drawing.Point(223, 178);
		this.checkBox_6.Name = Class16.smethod_0(1649108230);
		this.checkBox_6.Size = new System.Drawing.Size(113, 17);
		this.checkBox_6.TabIndex = 26;
		this.checkBox_6.Text = Class16.smethod_0(1649111857);
		this.checkBox_6.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
		this.checkBox_6.UseVisualStyleBackColor = true;
		this.checkBox_6.KeyDown += new System.Windows.Forms.KeyEventHandler(comboBox_7_KeyDown);
		this.checkBox_6.Leave += new System.EventHandler(comboBox_7_Leave);
		this.textBox_18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.textBox_18.Location = new System.Drawing.Point(245, 60);
		this.textBox_18.Name = Class16.smethod_0(1649108253);
		this.textBox_18.Size = new System.Drawing.Size(91, 20);
		this.textBox_18.TabIndex = 24;
		this.textBox_18.KeyDown += new System.Windows.Forms.KeyEventHandler(comboBox_7_KeyDown);
		this.textBox_18.Leave += new System.EventHandler(comboBox_7_Leave);
		this.label_17.AutoSize = true;
		this.label_17.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_17.Location = new System.Drawing.Point(169, 62);
		this.label_17.Name = Class16.smethod_0(1648913041);
		this.label_17.Size = new System.Drawing.Size(73, 15);
		this.label_17.TabIndex = 25;
		this.label_17.Text = Class16.smethod_0(1649108270);
		this.comboBox_8.BackColor = System.Drawing.Color.Silver;
		this.comboBox_8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.comboBox_8.FormattingEnabled = true;
		this.comboBox_8.Items.AddRange(new object[2]
		{
			Class16.smethod_0(1649108912),
			Class16.smethod_0(1649007040)
		});
		this.comboBox_8.Location = new System.Drawing.Point(245, 11);
		this.comboBox_8.Name = Class16.smethod_0(1649108280);
		this.comboBox_8.Size = new System.Drawing.Size(91, 21);
		this.comboBox_8.TabIndex = 23;
		this.comboBox_8.KeyDown += new System.Windows.Forms.KeyEventHandler(comboBox_7_KeyDown);
		this.comboBox_8.Leave += new System.EventHandler(comboBox_7_Leave);
		this.label_16.AutoSize = true;
		this.label_16.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_16.Location = new System.Drawing.Point(215, 12);
		this.label_16.Name = Class16.smethod_0(1648914031);
		this.label_16.Size = new System.Drawing.Size(36, 15);
		this.label_16.TabIndex = 22;
		this.label_16.Text = Class16.smethod_0(1649014090);
		this.textBox_66.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.textBox_66.Location = new System.Drawing.Point(77, 222);
		this.textBox_66.Name = Class16.smethod_0(1649108308);
		this.textBox_66.Size = new System.Drawing.Size(91, 20);
		this.textBox_66.TabIndex = 21;
		this.textBox_66.KeyDown += new System.Windows.Forms.KeyEventHandler(comboBox_7_KeyDown);
		this.textBox_66.Leave += new System.EventHandler(comboBox_7_Leave);
		this.label_13.AutoSize = true;
		this.label_13.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_13.Location = new System.Drawing.Point(12, 224);
		this.label_13.Name = Class16.smethod_0(1648914048);
		this.label_13.Size = new System.Drawing.Size(60, 15);
		this.label_13.TabIndex = 20;
		this.label_13.Text = Class16.smethod_0(1649108324);
		this.textBox_63.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.textBox_63.Location = new System.Drawing.Point(77, 199);
		this.textBox_63.Name = Class16.smethod_0(1649108340);
		this.textBox_63.Size = new System.Drawing.Size(91, 20);
		this.textBox_63.TabIndex = 19;
		this.textBox_63.KeyDown += new System.Windows.Forms.KeyEventHandler(comboBox_7_KeyDown);
		this.textBox_63.Leave += new System.EventHandler(comboBox_7_Leave);
		this.label_14.AutoSize = true;
		this.label_14.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_14.Location = new System.Drawing.Point(12, 201);
		this.label_14.Name = Class16.smethod_0(1648920306);
		this.label_14.Size = new System.Drawing.Size(60, 15);
		this.label_14.TabIndex = 18;
		this.label_14.Text = Class16.smethod_0(1649108356);
		this.textBox_60.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.textBox_60.Location = new System.Drawing.Point(77, 176);
		this.textBox_60.Name = Class16.smethod_0(1649108372);
		this.textBox_60.Size = new System.Drawing.Size(91, 20);
		this.textBox_60.TabIndex = 17;
		this.textBox_60.KeyDown += new System.Windows.Forms.KeyEventHandler(comboBox_7_KeyDown);
		this.textBox_60.Leave += new System.EventHandler(comboBox_7_Leave);
		this.label_15.AutoSize = true;
		this.label_15.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_15.Location = new System.Drawing.Point(11, 178);
		this.label_15.Name = Class16.smethod_0(1648925222);
		this.label_15.Size = new System.Drawing.Size(61, 15);
		this.label_15.TabIndex = 16;
		this.label_15.Text = Class16.smethod_0(1649108388);
		this.textBox_65.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.textBox_65.Location = new System.Drawing.Point(77, 152);
		this.textBox_65.Name = Class16.smethod_0(1649108404);
		this.textBox_65.Size = new System.Drawing.Size(91, 20);
		this.textBox_65.TabIndex = 15;
		this.textBox_65.KeyDown += new System.Windows.Forms.KeyEventHandler(comboBox_7_KeyDown);
		this.textBox_65.Leave += new System.EventHandler(comboBox_7_Leave);
		this.label_12.AutoSize = true;
		this.label_12.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_12.Location = new System.Drawing.Point(6, 154);
		this.label_12.Name = Class16.smethod_0(1648920093);
		this.label_12.Size = new System.Drawing.Size(66, 15);
		this.label_12.TabIndex = 14;
		this.label_12.Text = Class16.smethod_0(1649108411);
		this.textBox_62.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.textBox_62.Location = new System.Drawing.Point(77, 129);
		this.textBox_62.Name = Class16.smethod_0(1649108437);
		this.textBox_62.Size = new System.Drawing.Size(91, 20);
		this.textBox_62.TabIndex = 13;
		this.textBox_62.KeyDown += new System.Windows.Forms.KeyEventHandler(comboBox_7_KeyDown);
		this.textBox_62.Leave += new System.EventHandler(comboBox_7_Leave);
		this.label_2.AutoSize = true;
		this.label_2.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_2.Location = new System.Drawing.Point(16, 131);
		this.label_2.Name = Class16.smethod_0(1648925176);
		this.label_2.Size = new System.Drawing.Size(56, 15);
		this.label_2.TabIndex = 12;
		this.label_2.Text = Class16.smethod_0(1649108452);
		this.textBox_59.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.textBox_59.Location = new System.Drawing.Point(77, 106);
		this.textBox_59.Name = Class16.smethod_0(1649108468);
		this.textBox_59.Size = new System.Drawing.Size(91, 20);
		this.textBox_59.TabIndex = 11;
		this.textBox_59.KeyDown += new System.Windows.Forms.KeyEventHandler(comboBox_7_KeyDown);
		this.textBox_59.Leave += new System.EventHandler(comboBox_7_Leave);
		this.textBox_64.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.textBox_64.Location = new System.Drawing.Point(77, 83);
		this.textBox_64.Name = Class16.smethod_0(1649108475);
		this.textBox_64.Size = new System.Drawing.Size(91, 20);
		this.textBox_64.TabIndex = 10;
		this.textBox_64.KeyDown += new System.Windows.Forms.KeyEventHandler(comboBox_7_KeyDown);
		this.textBox_64.Leave += new System.EventHandler(comboBox_7_Leave);
		this.textBox_61.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.textBox_61.Location = new System.Drawing.Point(77, 60);
		this.textBox_61.Name = Class16.smethod_0(1649107476);
		this.textBox_61.Size = new System.Drawing.Size(91, 20);
		this.textBox_61.TabIndex = 9;
		this.textBox_61.KeyDown += new System.Windows.Forms.KeyEventHandler(comboBox_7_KeyDown);
		this.textBox_61.Leave += new System.EventHandler(comboBox_7_Leave);
		this.label_97.AutoSize = true;
		this.label_97.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_97.Location = new System.Drawing.Point(15, 106);
		this.label_97.Name = Class16.smethod_0(1648925100);
		this.label_97.Size = new System.Drawing.Size(57, 15);
		this.label_97.TabIndex = 8;
		this.label_97.Text = Class16.smethod_0(1649107493);
		this.textBox_58.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.textBox_58.Location = new System.Drawing.Point(77, 37);
		this.textBox_58.Name = Class16.smethod_0(1649107509);
		this.textBox_58.Size = new System.Drawing.Size(91, 20);
		this.textBox_58.TabIndex = 7;
		this.textBox_58.KeyDown += new System.Windows.Forms.KeyEventHandler(comboBox_7_KeyDown);
		this.textBox_58.Leave += new System.EventHandler(comboBox_7_Leave);
		this.label_86.AutoSize = true;
		this.label_86.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_86.Location = new System.Drawing.Point(55, 84);
		this.label_86.Name = Class16.smethod_0(1648925008);
		this.label_86.Size = new System.Drawing.Size(17, 15);
		this.label_86.TabIndex = 6;
		this.label_86.Text = Class16.smethod_0(1649111438);
		this.label_75.AutoSize = true;
		this.label_75.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_75.Location = new System.Drawing.Point(55, 62);
		this.label_75.Name = Class16.smethod_0(1648930206);
		this.label_75.Size = new System.Drawing.Size(17, 15);
		this.label_75.TabIndex = 5;
		this.label_75.Text = Class16.smethod_0(1649013950);
		this.label_64.AutoSize = true;
		this.label_64.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_64.Location = new System.Drawing.Point(54, 39);
		this.label_64.Name = Class16.smethod_0(1648930240);
		this.label_64.Size = new System.Drawing.Size(18, 15);
		this.label_64.TabIndex = 4;
		this.label_64.Text = Class16.smethod_0(1649013968);
		this.textBox_17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.textBox_17.Enabled = false;
		this.textBox_17.Location = new System.Drawing.Point(245, 37);
		this.textBox_17.Name = Class16.smethod_0(1649107526);
		this.textBox_17.Size = new System.Drawing.Size(91, 20);
		this.textBox_17.TabIndex = 2;
		this.textBox_17.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		this.comboBox_7.BackColor = System.Drawing.Color.FromArgb(255, 255, 128);
		this.comboBox_7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.comboBox_7.FormattingEnabled = true;
		this.comboBox_7.Items.AddRange(new object[2]
		{
			Class16.smethod_0(1649108978),
			Class16.smethod_0(1649112009)
		});
		this.comboBox_7.Location = new System.Drawing.Point(77, 11);
		this.comboBox_7.Name = Class16.smethod_0(1649107545);
		this.comboBox_7.Size = new System.Drawing.Size(91, 21);
		this.comboBox_7.TabIndex = 1;
		this.comboBox_7.KeyDown += new System.Windows.Forms.KeyEventHandler(comboBox_7_KeyDown);
		this.comboBox_7.Leave += new System.EventHandler(comboBox_7_Leave);
		this.label_31.AutoSize = true;
		this.label_31.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_31.Location = new System.Drawing.Point(2, 14);
		this.label_31.Name = Class16.smethod_0(1648912145);
		this.label_31.Size = new System.Drawing.Size(57, 15);
		this.label_31.TabIndex = 0;
		this.label_31.Text = Class16.smethod_0(1649111185);
		this.label_53.AutoSize = true;
		this.label_53.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_53.Location = new System.Drawing.Point(187, 39);
		this.label_53.Name = Class16.smethod_0(1648912262);
		this.label_53.Size = new System.Drawing.Size(55, 15);
		this.label_53.TabIndex = 3;
		this.label_53.Text = Class16.smethod_0(1649107569);
		this.label_20.AutoSize = true;
		this.label_20.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_20.Location = new System.Drawing.Point(188, 132);
		this.label_20.Name = Class16.smethod_0(1648911426);
		this.label_20.Size = new System.Drawing.Size(54, 15);
		this.label_20.TabIndex = 34;
		this.label_20.Text = Class16.smethod_0(1649107585);
		this.label_21.AutoSize = true;
		this.label_21.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_21.Location = new System.Drawing.Point(185, 155);
		this.label_21.Name = Class16.smethod_0(1649107601);
		this.label_21.RightToLeft = System.Windows.Forms.RightToLeft.No;
		this.label_21.Size = new System.Drawing.Size(57, 15);
		this.label_21.TabIndex = 36;
		this.label_21.Text = Class16.smethod_0(1649107623);
		this.toolTip_0.SetToolTip(this.label_21, Class16.smethod_0(1649107639));
		this.button_10.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.button_10.ForeColor = System.Drawing.Color.Black;
		this.button_10.Image = ACE.Properties.Resources.NpcGenEditorForm_remove;
		this.button_10.Location = new System.Drawing.Point(180, 454);
		this.button_10.Name = Class16.smethod_0(1649107678);
		this.button_10.Size = new System.Drawing.Size(181, 29);
		this.button_10.TabIndex = 11;
		this.button_10.TabStop = false;
		this.button_10.Text = Class16.smethod_0(1648931371);
		this.button_10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.button_10.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		this.button_10.UseVisualStyleBackColor = true;
		this.button_10.Click += new System.EventHandler(button_10_Click);
		this.button_6.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.button_6.ForeColor = System.Drawing.Color.Black;
		this.button_6.Image = ACE.Properties.Resources.NpcGenEditorForm_Clone;
		this.button_6.Location = new System.Drawing.Point(0, 454);
		this.button_6.Name = Class16.smethod_0(1649107698);
		this.button_6.Size = new System.Drawing.Size(181, 29);
		this.button_6.TabIndex = 9;
		this.button_6.TabStop = false;
		this.button_6.Text = Class16.smethod_0(1648931357);
		this.button_6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.button_6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		this.button_6.UseVisualStyleBackColor = true;
		this.button_6.Click += new System.EventHandler(button_6_Click);
		this.toolStrip_0.AutoSize = false;
		this.toolStrip_0.BackColor = System.Drawing.Color.FromArgb(239, 244, 250);
		this.toolStrip_0.GripMargin = new System.Windows.Forms.Padding(0);
		this.toolStrip_0.Items.AddRange(new System.Windows.Forms.ToolStripItem[4] { this.toolStripButton_0, this.toolStripButton_2, this.toolStripDropDownButton_0, this.toolStripDropDownButton_2 });
		this.toolStrip_0.Location = new System.Drawing.Point(3, 3);
		this.toolStrip_0.Name = Class16.smethod_0(1649107733);
		this.toolStrip_0.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
		this.toolStrip_0.Size = new System.Drawing.Size(960, 25);
		this.toolStrip_0.TabIndex = 16;
		this.toolStrip_0.Text = Class16.smethod_0(1649107758);
		this.toolStripButton_0.Image = ACE.Properties.Resources.NpcGenEditorForm_ExportExistence;
		this.toolStripButton_0.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
		this.toolStripButton_0.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.toolStripButton_0.Name = Class16.smethod_0(1649107775);
		this.toolStripButton_0.Size = new System.Drawing.Size(62, 22);
		this.toolStripButton_0.Text = Class16.smethod_0(1648931384);
		this.toolStripButton_0.ToolTipText = Class16.smethod_0(1648931384);
		this.toolStripButton_0.Click += new System.EventHandler(toolStripButton_6_Click);
		this.toolStripButton_2.Image = ACE.Properties.Resources.NpcGenEditorForm_ImportExistence;
		this.toolStripButton_2.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.toolStripButton_2.Name = Class16.smethod_0(1649107797);
		this.toolStripButton_2.Size = new System.Drawing.Size(63, 22);
		this.toolStripButton_2.Text = Class16.smethod_0(1648931405);
		this.toolStripButton_2.ToolTipText = Class16.smethod_0(1648931405);
		this.toolStripButton_2.Click += new System.EventHandler(toolStripButton_7_Click);
		this.toolStripDropDownButton_0.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.toolStripMenuItem_14, this.toolStripMenuItem_15 });
		this.toolStripDropDownButton_0.Image = ACE.Properties.Resources.NpcGenEditorForm_LineUpExistenceDropDown;
		this.toolStripDropDownButton_0.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.toolStripDropDownButton_0.Name = Class16.smethod_0(1649107811);
		this.toolStripDropDownButton_0.Size = new System.Drawing.Size(75, 22);
		this.toolStripDropDownButton_0.Text = Class16.smethod_0(1649107841);
		this.toolStripDropDownButton_0.ToolTipText = Class16.smethod_0(1649107841);
		this.toolStripMenuItem_14.Image = ACE.Properties.Resources.NpcGenEditorForm_ToolStripLineUpX;
		this.toolStripMenuItem_14.Name = Class16.smethod_0(1649107863);
		this.toolStripMenuItem_14.Size = new System.Drawing.Size(97, 22);
		this.toolStripMenuItem_14.Text = Class16.smethod_0(1649107886);
		this.toolStripMenuItem_14.Click += new System.EventHandler(toolStripMenuItem_23_Click);
		this.toolStripMenuItem_15.Image = ACE.Properties.Resources.NpcGenEditorForm_ToolStripLineUpZ;
		this.toolStripMenuItem_15.Name = Class16.smethod_0(1649107889);
		this.toolStripMenuItem_15.Size = new System.Drawing.Size(97, 22);
		this.toolStripMenuItem_15.Text = Class16.smethod_0(1648915467);
		this.toolStripMenuItem_15.Click += new System.EventHandler(toolStripMenuItem_24_Click);
		this.toolStripDropDownButton_2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.toolStripMenuItem_9, this.toolStripMenuItem_6 });
		this.toolStripDropDownButton_2.Image = ACE.Properties.Resources.NpcGenEditorForm_Move;
		this.toolStripDropDownButton_2.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.toolStripDropDownButton_2.Name = Class16.smethod_0(1649107912);
		this.toolStripDropDownButton_2.Size = new System.Drawing.Size(66, 22);
		this.toolStripDropDownButton_2.Text = Class16.smethod_0(1649113514);
		this.toolStripDropDownButton_2.ToolTipText = Class16.smethod_0(1649113514);
		this.toolStripMenuItem_9.Image = ACE.Properties.Resources.NpcGenEditorForm_MoveUpToolStripMenuItem;
		this.toolStripMenuItem_9.Name = Class16.smethod_0(1649107948);
		this.toolStripMenuItem_9.Size = new System.Drawing.Size(146, 22);
		this.toolStripMenuItem_9.Text = Class16.smethod_0(1649106946);
		this.toolStripMenuItem_9.Click += new System.EventHandler(toolStripMenuItem_20_Click);
		this.toolStripMenuItem_6.Image = ACE.Properties.Resources.NpcGenEditorForm_MoveDownToolStripMenuItem;
		this.toolStripMenuItem_6.Name = Class16.smethod_0(1649106963);
		this.toolStripMenuItem_6.Size = new System.Drawing.Size(146, 22);
		this.toolStripMenuItem_6.Text = Class16.smethod_0(1649106995);
		this.toolStripMenuItem_6.Click += new System.EventHandler(toolStripMenuItem_21_Click);
		this.tabPage_4.BackColor = System.Drawing.Color.FromArgb(239, 244, 250);
		this.tabPage_4.Controls.Add(this.groupBox_15);
		this.tabPage_4.Controls.Add(this.groupBox_14);
		this.tabPage_4.Controls.Add(this.dataGridView_6);
		this.tabPage_4.Controls.Add(this.toolStrip_1);
		this.tabPage_4.Controls.Add(this.button_22);
		this.tabPage_4.Controls.Add(this.button_17);
		this.tabPage_4.Location = new System.Drawing.Point(4, 22);
		this.tabPage_4.Name = Class16.smethod_0(1649107022);
		this.tabPage_4.Padding = new System.Windows.Forms.Padding(3);
		this.tabPage_4.Size = new System.Drawing.Size(966, 483);
		this.tabPage_4.TabIndex = 1;
		this.tabPage_4.Text = Class16.smethod_0(1649008358);
		this.groupBox_15.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.groupBox_15.BackColor = System.Drawing.Color.FromArgb(239, 244, 250);
		this.groupBox_15.Controls.Add(this.numericUpDown_25);
		this.groupBox_15.Controls.Add(this.label_41);
		this.groupBox_15.Controls.Add(this.numericUpDown_22);
		this.groupBox_15.Controls.Add(this.label_59);
		this.groupBox_15.Controls.Add(this.numericUpDown_24);
		this.groupBox_15.Controls.Add(this.numericUpDown_19);
		this.groupBox_15.Controls.Add(this.label_63);
		this.groupBox_15.Controls.Add(this.numericUpDown_23);
		this.groupBox_15.Controls.Add(this.label_65);
		this.groupBox_15.Controls.Add(this.button_20);
		this.groupBox_15.Controls.Add(this.button_19);
		this.groupBox_15.Controls.Add(this.dataGridView_7);
		this.groupBox_15.Controls.Add(this.label_57);
		this.groupBox_15.Controls.Add(this.label_62);
		this.groupBox_15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.groupBox_15.Location = new System.Drawing.Point(364, 253);
		this.groupBox_15.Name = Class16.smethod_0(1648988898);
		this.groupBox_15.Size = new System.Drawing.Size(599, 229);
		this.groupBox_15.TabIndex = 18;
		this.groupBox_15.TabStop = false;
		this.groupBox_15.Text = Class16.smethod_0(1649008358);
		this.numericUpDown_25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.numericUpDown_25.Location = new System.Drawing.Point(320, 93);
		this.numericUpDown_25.Maximum = new decimal(new int[4] { 2147483647, 0, 0, 0 });
		this.numericUpDown_25.Minimum = new decimal(new int[4] { -2147483648, 0, 0, -2147483648 });
		this.numericUpDown_25.Name = Class16.smethod_0(1649107033);
		this.numericUpDown_25.Size = new System.Drawing.Size(80, 20);
		this.numericUpDown_25.TabIndex = 53;
		this.numericUpDown_25.KeyDown += new System.Windows.Forms.KeyEventHandler(numericUpDown_23_KeyDown);
		this.numericUpDown_25.Leave += new System.EventHandler(numericUpDown_23_Leave);
		this.label_41.AutoSize = true;
		this.label_41.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_41.ForeColor = System.Drawing.Color.FromArgb(192, 255, 192);
		this.label_41.Location = new System.Drawing.Point(386, 16);
		this.label_41.Name = Class16.smethod_0(1649107061);
		this.label_41.Size = new System.Drawing.Size(0, 15);
		this.label_41.TabIndex = 52;
		this.numericUpDown_22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.numericUpDown_22.DecimalPlaces = 3;
		this.numericUpDown_22.Location = new System.Drawing.Point(320, 119);
		this.numericUpDown_22.Maximum = new decimal(new int[4] { 2147483647, 0, 0, 0 });
		this.numericUpDown_22.Minimum = new decimal(new int[4] { -2147483648, 0, 0, -2147483648 });
		this.numericUpDown_22.Name = Class16.smethod_0(1649107067);
		this.numericUpDown_22.Size = new System.Drawing.Size(80, 20);
		this.numericUpDown_22.TabIndex = 50;
		this.numericUpDown_22.KeyDown += new System.Windows.Forms.KeyEventHandler(numericUpDown_23_KeyDown);
		this.numericUpDown_22.Leave += new System.EventHandler(numericUpDown_23_Leave);
		this.label_59.AutoSize = true;
		this.label_59.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_59.Location = new System.Drawing.Point(278, 93);
		this.label_59.Name = Class16.smethod_0(1649107090);
		this.label_59.Size = new System.Drawing.Size(36, 15);
		this.label_59.TabIndex = 47;
		this.label_59.Text = Class16.smethod_0(1649014090);
		this.numericUpDown_24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.numericUpDown_24.Location = new System.Drawing.Point(320, 67);
		this.numericUpDown_24.Maximum = new decimal(new int[4] { 2147483647, 0, 0, 0 });
		this.numericUpDown_24.Minimum = new decimal(new int[4] { -2147483648, 0, 0, -2147483648 });
		this.numericUpDown_24.Name = Class16.smethod_0(1649107104);
		this.numericUpDown_24.Size = new System.Drawing.Size(80, 20);
		this.numericUpDown_24.TabIndex = 42;
		this.numericUpDown_24.KeyDown += new System.Windows.Forms.KeyEventHandler(numericUpDown_23_KeyDown);
		this.numericUpDown_24.Leave += new System.EventHandler(numericUpDown_23_Leave);
		this.numericUpDown_19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.numericUpDown_19.Location = new System.Drawing.Point(320, 41);
		this.numericUpDown_19.Maximum = new decimal(new int[4] { 2147483647, 0, 0, 0 });
		this.numericUpDown_19.Minimum = new decimal(new int[4] { -2147483648, 0, 0, -2147483648 });
		this.numericUpDown_19.Name = Class16.smethod_0(1649107135);
		this.numericUpDown_19.Size = new System.Drawing.Size(80, 20);
		this.numericUpDown_19.TabIndex = 40;
		this.numericUpDown_19.KeyDown += new System.Windows.Forms.KeyEventHandler(numericUpDown_23_KeyDown);
		this.numericUpDown_19.Leave += new System.EventHandler(numericUpDown_23_Leave);
		this.label_63.AutoSize = true;
		this.label_63.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_63.Location = new System.Drawing.Point(260, 41);
		this.label_63.Name = Class16.smethod_0(1649107157);
		this.label_63.Size = new System.Drawing.Size(54, 15);
		this.label_63.TabIndex = 39;
		this.label_63.Text = Class16.smethod_0(1649112443);
		this.numericUpDown_23.BackColor = System.Drawing.Color.FromArgb(128, 255, 128);
		this.numericUpDown_23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.numericUpDown_23.Location = new System.Drawing.Point(320, 15);
		this.numericUpDown_23.Maximum = new decimal(new int[4] { 2147483647, 0, 0, 0 });
		this.numericUpDown_23.Minimum = new decimal(new int[4] { -2147483648, 0, 0, -2147483648 });
		this.numericUpDown_23.Name = Class16.smethod_0(1649107163);
		this.numericUpDown_23.Size = new System.Drawing.Size(80, 20);
		this.numericUpDown_23.TabIndex = 38;
		this.numericUpDown_23.MouseEnter += new System.EventHandler(numericUpDown_23_MouseEnter);
		this.numericUpDown_23.MouseLeave += new System.EventHandler(numericUpDown_23_MouseLeave);
		this.numericUpDown_23.MouseMove += new System.Windows.Forms.MouseEventHandler(numericUpDown_23_MouseMove);
		this.numericUpDown_23.DoubleClick += new System.EventHandler(numericUpDown_23_DoubleClick);
		this.numericUpDown_23.KeyDown += new System.Windows.Forms.KeyEventHandler(numericUpDown_23_KeyDown);
		this.numericUpDown_23.Leave += new System.EventHandler(numericUpDown_23_Leave);
		this.label_65.AutoSize = true;
		this.label_65.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_65.Location = new System.Drawing.Point(292, 16);
		this.label_65.Name = Class16.smethod_0(1649107189);
		this.label_65.Size = new System.Drawing.Size(22, 15);
		this.label_65.TabIndex = 37;
		this.label_65.Text = Class16.smethod_0(1648930840);
		this.button_20.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.button_20.ForeColor = System.Drawing.Color.Black;
		this.button_20.Image = ACE.Properties.Resources.NpcGenEditorForm_ResourcesRemoveButton;
		this.button_20.Location = new System.Drawing.Point(110, 201);
		this.button_20.Name = Class16.smethod_0(1649107195);
		this.button_20.Size = new System.Drawing.Size(110, 27);
		this.button_20.TabIndex = 16;
		this.button_20.Text = Class16.smethod_0(1648931371);
		this.button_20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.button_20.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		this.button_20.UseVisualStyleBackColor = true;
		this.button_20.Click += new System.EventHandler(button_20_Click);
		this.button_19.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.button_19.ForeColor = System.Drawing.Color.Black;
		this.button_19.Image = ACE.Properties.Resources.NpcGenEditorForm_ResourcesCloneButton;
		this.button_19.Location = new System.Drawing.Point(0, 201);
		this.button_19.Name = Class16.smethod_0(1649107236);
		this.button_19.Size = new System.Drawing.Size(110, 27);
		this.button_19.TabIndex = 15;
		this.button_19.Text = Class16.smethod_0(1648931357);
		this.button_19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.button_19.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		this.button_19.UseVisualStyleBackColor = true;
		this.button_19.Click += new System.EventHandler(button_19_Click);
		this.dataGridView_7.AllowUserToAddRows = false;
		this.dataGridView_7.AllowUserToDeleteRows = false;
		this.dataGridView_7.AllowUserToResizeColumns = false;
		this.dataGridView_7.AllowUserToResizeRows = false;
		this.dataGridView_7.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.dataGridView_7.BackgroundColor = System.Drawing.Color.FromArgb(15, 15, 15);
		this.dataGridView_7.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
		this.dataGridView_7.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
		this.dataGridView_7.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridView_7.Columns.AddRange(this.dataGridViewTextBoxColumn_36, this.dataGridViewTextBoxColumn_5, this.dataGridViewTextBoxColumn_6);
		dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(15, 15, 15);
		dataGridViewCellStyle9.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 8.25f);
		dataGridViewCellStyle9.ForeColor = System.Drawing.Color.White;
		dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(255, 255, 192);
		dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
		dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
		this.dataGridView_7.DefaultCellStyle = dataGridViewCellStyle9;
		this.dataGridView_7.EnableHeadersVisualStyles = false;
		this.dataGridView_7.Location = new System.Drawing.Point(1, 13);
		this.dataGridView_7.Name = Class16.smethod_0(1649107268);
		this.dataGridView_7.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
		this.dataGridView_7.RowHeadersVisible = false;
		this.dataGridView_7.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		this.dataGridView_7.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		this.dataGridView_7.ShowCellErrors = false;
		this.dataGridView_7.ShowCellToolTips = false;
		this.dataGridView_7.ShowEditingIcon = false;
		this.dataGridView_7.ShowRowErrors = false;
		this.dataGridView_7.Size = new System.Drawing.Size(218, 189);
		this.dataGridView_7.TabIndex = 15;
		this.dataGridView_7.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(dataGridView_7_CellMouseEnter);
		this.dataGridView_7.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(dataGridView_7_CellMouseLeave);
		this.dataGridView_7.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(dataGridView_7_CellMouseMove);
		this.dataGridView_7.CurrentCellChanged += new System.EventHandler(dataGridView_7_CurrentCellChanged);
		dataGridViewCellStyle10.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.dataGridViewTextBoxColumn_36.DefaultCellStyle = dataGridViewCellStyle10;
		this.dataGridViewTextBoxColumn_36.FillWeight = 6.912442f;
		this.dataGridViewTextBoxColumn_36.HeaderText = Class16.smethod_0(1648929947);
		this.dataGridViewTextBoxColumn_36.Name = Class16.smethod_0(1649029322);
		this.dataGridViewTextBoxColumn_36.ReadOnly = true;
		this.dataGridViewTextBoxColumn_36.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
		this.dataGridViewTextBoxColumn_36.Width = 47;
		dataGridViewCellStyle11.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.dataGridViewTextBoxColumn_5.DefaultCellStyle = dataGridViewCellStyle11;
		this.dataGridViewTextBoxColumn_5.FillWeight = 44.7233f;
		this.dataGridViewTextBoxColumn_5.HeaderText = Class16.smethod_0(1649118934);
		this.dataGridViewTextBoxColumn_5.Name = Class16.smethod_0(1649029355);
		this.dataGridViewTextBoxColumn_5.ReadOnly = true;
		this.dataGridViewTextBoxColumn_5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
		this.dataGridViewTextBoxColumn_5.Width = 50;
		this.dataGridViewTextBoxColumn_6.HeaderText = Class16.smethod_0(1648936731);
		this.dataGridViewTextBoxColumn_6.Name = Class16.smethod_0(1648910512);
		this.dataGridViewTextBoxColumn_6.ReadOnly = true;
		this.dataGridViewTextBoxColumn_6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
		this.dataGridViewTextBoxColumn_6.Width = 125;
		this.label_57.AutoSize = true;
		this.label_57.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_57.Location = new System.Drawing.Point(229, 119);
		this.label_57.Name = Class16.smethod_0(1649107293);
		this.label_57.Size = new System.Drawing.Size(85, 15);
		this.label_57.TabIndex = 51;
		this.label_57.Text = Class16.smethod_0(1649107299);
		this.label_62.AutoSize = true;
		this.label_62.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_62.Location = new System.Drawing.Point(225, 67);
		this.label_62.Name = Class16.smethod_0(1649107327);
		this.label_62.Size = new System.Drawing.Size(89, 15);
		this.label_62.TabIndex = 41;
		this.label_62.Text = Class16.smethod_0(1649113137);
		this.groupBox_14.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.groupBox_14.BackColor = System.Drawing.Color.FromArgb(239, 244, 250);
		this.groupBox_14.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
		this.groupBox_14.Controls.Add(this.groupBox_2);
		this.groupBox_14.Controls.Add(this.textBox_27);
		this.groupBox_14.Controls.Add(this.label_38);
		this.groupBox_14.Controls.Add(this.textBox_31);
		this.groupBox_14.Controls.Add(this.label_39);
		this.groupBox_14.Controls.Add(this.textBox_22);
		this.groupBox_14.Controls.Add(this.label_40);
		this.groupBox_14.Controls.Add(this.checkBox_7);
		this.groupBox_14.Controls.Add(this.checkBox_8);
		this.groupBox_14.Controls.Add(this.checkBox_9);
		this.groupBox_14.Controls.Add(this.textBox_30);
		this.groupBox_14.Controls.Add(this.label_44);
		this.groupBox_14.Controls.Add(this.textBox_36);
		this.groupBox_14.Controls.Add(this.label_45);
		this.groupBox_14.Controls.Add(this.textBox_33);
		this.groupBox_14.Controls.Add(this.label_46);
		this.groupBox_14.Controls.Add(this.textBox_29);
		this.groupBox_14.Controls.Add(this.label_47);
		this.groupBox_14.Controls.Add(this.textBox_28);
		this.groupBox_14.Controls.Add(this.label_48);
		this.groupBox_14.Controls.Add(this.textBox_35);
		this.groupBox_14.Controls.Add(this.textBox_34);
		this.groupBox_14.Controls.Add(this.textBox_32);
		this.groupBox_14.Controls.Add(this.label_50);
		this.groupBox_14.Controls.Add(this.label_51);
		this.groupBox_14.Controls.Add(this.label_52);
		this.groupBox_14.Controls.Add(this.textBox_26);
		this.groupBox_14.Controls.Add(this.label_55);
		this.groupBox_14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.groupBox_14.Location = new System.Drawing.Point(364, 1);
		this.groupBox_14.Name = Class16.smethod_0(1648928966);
		this.groupBox_14.Size = new System.Drawing.Size(599, 250);
		this.groupBox_14.TabIndex = 17;
		this.groupBox_14.TabStop = false;
		this.groupBox_14.Text = Class16.smethod_0(1649002051);
		this.groupBox_2.BackColor = System.Drawing.Color.FromArgb(239, 244, 250);
		this.groupBox_2.Controls.Add(this.button_21);
		this.groupBox_2.Controls.Add(this.numericUpDown_8);
		this.groupBox_2.Controls.Add(this.label_58);
		this.groupBox_2.Controls.Add(this.numericUpDown_6);
		this.groupBox_2.Controls.Add(this.label_60);
		this.groupBox_2.Controls.Add(this.numericUpDown_7);
		this.groupBox_2.Controls.Add(this.label_61);
		this.groupBox_2.Controls.Add(this.numericUpDown_9);
		this.groupBox_2.Controls.Add(this.label_81);
		this.groupBox_2.Location = new System.Drawing.Point(342, 7);
		this.groupBox_2.Name = Class16.smethod_0(1649107341);
		this.groupBox_2.Size = new System.Drawing.Size(254, 165);
		this.groupBox_2.TabIndex = 18;
		this.groupBox_2.TabStop = false;
		this.groupBox_2.Text = Class16.smethod_0(1649107358);
		this.button_21.Anchor = System.Windows.Forms.AnchorStyles.Top;
		this.button_21.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.button_21.ForeColor = System.Drawing.Color.FromArgb(192, 64, 0);
		this.button_21.Location = new System.Drawing.Point(2, 111);
		this.button_21.Name = Class16.smethod_0(1649107398);
		this.button_21.Size = new System.Drawing.Size(252, 52);
		this.button_21.TabIndex = 67;
		this.button_21.Text = Class16.smethod_0(1649107425);
		this.button_21.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		this.button_21.UseVisualStyleBackColor = true;
		this.button_21.Click += new System.EventHandler(button_21_Click);
		this.numericUpDown_8.BackColor = System.Drawing.SystemColors.Window;
		this.numericUpDown_8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.numericUpDown_8.Location = new System.Drawing.Point(157, 88);
		this.numericUpDown_8.Maximum = new decimal(new int[4] { 2147483647, 0, 0, 0 });
		this.numericUpDown_8.Minimum = new decimal(new int[4] { -2147483648, 0, 0, -2147483648 });
		this.numericUpDown_8.Name = Class16.smethod_0(1649110536);
		this.numericUpDown_8.Size = new System.Drawing.Size(76, 20);
		this.numericUpDown_8.TabIndex = 49;
		this.numericUpDown_8.Value = new decimal(new int[4] { 60, 0, 0, 0 });
		this.label_58.AutoSize = true;
		this.label_58.Location = new System.Drawing.Point(76, 88);
		this.label_58.Name = Class16.smethod_0(1649110573);
		this.label_58.Size = new System.Drawing.Size(77, 13);
		this.label_58.TabIndex = 48;
		this.label_58.Text = Class16.smethod_0(1649113137);
		this.numericUpDown_6.BackColor = System.Drawing.SystemColors.Window;
		this.numericUpDown_6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.numericUpDown_6.Location = new System.Drawing.Point(157, 65);
		this.numericUpDown_6.Maximum = new decimal(new int[4] { 2147483647, 0, 0, 0 });
		this.numericUpDown_6.Minimum = new decimal(new int[4] { -2147483648, 0, 0, -2147483648 });
		this.numericUpDown_6.Name = Class16.smethod_0(1649110579);
		this.numericUpDown_6.Size = new System.Drawing.Size(76, 20);
		this.numericUpDown_6.TabIndex = 47;
		this.numericUpDown_6.Value = new decimal(new int[4] { 1, 0, 0, 0 });
		this.label_60.AutoSize = true;
		this.label_60.Location = new System.Drawing.Point(45, 65);
		this.label_60.Name = Class16.smethod_0(1649110603);
		this.label_60.Size = new System.Drawing.Size(108, 13);
		this.label_60.TabIndex = 46;
		this.label_60.Text = Class16.smethod_0(1649110617);
		this.numericUpDown_7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.numericUpDown_7.Location = new System.Drawing.Point(157, 41);
		this.numericUpDown_7.Maximum = new decimal(new int[4] { 2147483647, 0, 0, 0 });
		this.numericUpDown_7.Minimum = new decimal(new int[4] { -2147483648, 0, 0, -2147483648 });
		this.numericUpDown_7.Name = Class16.smethod_0(1649110652);
		this.numericUpDown_7.Size = new System.Drawing.Size(76, 20);
		this.numericUpDown_7.TabIndex = 45;
		this.numericUpDown_7.Value = new decimal(new int[4] { 16, 0, 0, 0 });
		this.label_61.AutoSize = true;
		this.label_61.Location = new System.Drawing.Point(48, 42);
		this.label_61.Name = Class16.smethod_0(1649110664);
		this.label_61.Size = new System.Drawing.Size(105, 13);
		this.label_61.TabIndex = 44;
		this.label_61.Text = Class16.smethod_0(1649110686);
		this.numericUpDown_9.BackColor = System.Drawing.SystemColors.Window;
		this.numericUpDown_9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.numericUpDown_9.Location = new System.Drawing.Point(157, 17);
		this.numericUpDown_9.Maximum = new decimal(new int[4] { 2147483647, 0, 0, 0 });
		this.numericUpDown_9.Minimum = new decimal(new int[4] { -2147483648, 0, 0, -2147483648 });
		this.numericUpDown_9.Name = Class16.smethod_0(1649110707);
		this.numericUpDown_9.Size = new System.Drawing.Size(76, 20);
		this.numericUpDown_9.TabIndex = 39;
		this.numericUpDown_9.Value = new decimal(new int[4] { 3074, 0, 0, 0 });
		this.label_81.AutoSize = true;
		this.label_81.Location = new System.Drawing.Point(96, 18);
		this.label_81.Name = Class16.smethod_0(1649110741);
		this.label_81.Size = new System.Drawing.Size(57, 13);
		this.label_81.TabIndex = 0;
		this.label_81.Text = Class16.smethod_0(1649108039);
		this.textBox_27.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.textBox_27.Location = new System.Drawing.Point(244, 82);
		this.textBox_27.Name = Class16.smethod_0(1649110747);
		this.textBox_27.Size = new System.Drawing.Size(91, 20);
		this.textBox_27.TabIndex = 35;
		this.textBox_27.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox_32_KeyDown);
		this.textBox_27.Leave += new System.EventHandler(textBox_32_Leave);
		this.label_38.AutoSize = true;
		this.label_38.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_38.Location = new System.Drawing.Point(176, 84);
		this.label_38.Name = Class16.smethod_0(1649110763);
		this.label_38.RightToLeft = System.Windows.Forms.RightToLeft.No;
		this.label_38.Size = new System.Drawing.Size(67, 15);
		this.label_38.TabIndex = 36;
		this.label_38.Text = Class16.smethod_0(1649110777);
		this.textBox_31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.textBox_31.ContextMenuStrip = this.contextMenuStrip_1;
		this.textBox_31.Location = new System.Drawing.Point(244, 58);
		this.textBox_31.Name = Class16.smethod_0(1649110793);
		this.textBox_31.Size = new System.Drawing.Size(91, 20);
		this.textBox_31.TabIndex = 31;
		this.textBox_31.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox_32_KeyDown);
		this.textBox_31.Leave += new System.EventHandler(textBox_32_Leave);
		this.label_39.AutoSize = true;
		this.label_39.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_39.Location = new System.Drawing.Point(194, 60);
		this.label_39.Name = Class16.smethod_0(1649110810);
		this.label_39.Size = new System.Drawing.Size(49, 15);
		this.label_39.TabIndex = 32;
		this.label_39.Text = Class16.smethod_0(1649111262);
		this.textBox_22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.textBox_22.Location = new System.Drawing.Point(244, 36);
		this.textBox_22.Name = Class16.smethod_0(1649110824);
		this.textBox_22.Size = new System.Drawing.Size(91, 20);
		this.textBox_22.TabIndex = 29;
		this.textBox_22.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox_32_KeyDown);
		this.textBox_22.Leave += new System.EventHandler(textBox_32_Leave);
		this.label_40.AutoSize = true;
		this.label_40.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_40.Location = new System.Drawing.Point(184, 38);
		this.label_40.Name = Class16.smethod_0(1649110847);
		this.label_40.Size = new System.Drawing.Size(59, 15);
		this.label_40.TabIndex = 30;
		this.label_40.Text = Class16.smethod_0(1649108172);
		this.checkBox_7.AutoSize = true;
		this.checkBox_7.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.checkBox_7.Location = new System.Drawing.Point(260, 153);
		this.checkBox_7.Name = Class16.smethod_0(1649110861);
		this.checkBox_7.Size = new System.Drawing.Size(75, 17);
		this.checkBox_7.TabIndex = 28;
		this.checkBox_7.Text = Class16.smethod_0(1649110879);
		this.checkBox_7.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
		this.checkBox_7.UseVisualStyleBackColor = true;
		this.checkBox_7.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox_32_KeyDown);
		this.checkBox_7.Leave += new System.EventHandler(textBox_32_Leave);
		this.checkBox_8.AutoSize = true;
		this.checkBox_8.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.checkBox_8.Location = new System.Drawing.Point(229, 130);
		this.checkBox_8.Name = Class16.smethod_0(1649110895);
		this.checkBox_8.Size = new System.Drawing.Size(106, 17);
		this.checkBox_8.TabIndex = 27;
		this.checkBox_8.Text = Class16.smethod_0(1649110913);
		this.checkBox_8.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
		this.checkBox_8.UseVisualStyleBackColor = true;
		this.checkBox_8.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox_32_KeyDown);
		this.checkBox_8.Leave += new System.EventHandler(textBox_32_Leave);
		this.checkBox_9.AutoSize = true;
		this.checkBox_9.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.checkBox_9.Location = new System.Drawing.Point(220, 108);
		this.checkBox_9.Name = Class16.smethod_0(1649110943);
		this.checkBox_9.Size = new System.Drawing.Size(115, 17);
		this.checkBox_9.TabIndex = 26;
		this.checkBox_9.Text = Class16.smethod_0(1649110966);
		this.checkBox_9.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
		this.checkBox_9.UseVisualStyleBackColor = true;
		this.checkBox_9.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox_32_KeyDown);
		this.checkBox_9.Leave += new System.EventHandler(textBox_32_Leave);
		this.textBox_30.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.textBox_30.Location = new System.Drawing.Point(77, 172);
		this.textBox_30.Name = Class16.smethod_0(1649110991);
		this.textBox_30.Size = new System.Drawing.Size(91, 20);
		this.textBox_30.TabIndex = 21;
		this.textBox_30.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox_32_KeyDown);
		this.textBox_30.Leave += new System.EventHandler(textBox_32_Leave);
		this.label_44.AutoSize = true;
		this.label_44.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_44.Location = new System.Drawing.Point(16, 174);
		this.label_44.Name = Class16.smethod_0(1649111007);
		this.label_44.Size = new System.Drawing.Size(56, 15);
		this.label_44.TabIndex = 20;
		this.label_44.Text = Class16.smethod_0(1649111021);
		this.textBox_36.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.textBox_36.Location = new System.Drawing.Point(77, 103);
		this.textBox_36.Name = Class16.smethod_0(1649111037);
		this.textBox_36.Size = new System.Drawing.Size(91, 20);
		this.textBox_36.TabIndex = 19;
		this.textBox_36.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox_32_KeyDown);
		this.textBox_36.Leave += new System.EventHandler(textBox_32_Leave);
		this.label_45.AutoSize = true;
		this.label_45.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_45.Location = new System.Drawing.Point(12, 105);
		this.label_45.Name = Class16.smethod_0(1649110029);
		this.label_45.Size = new System.Drawing.Size(60, 15);
		this.label_45.TabIndex = 18;
		this.label_45.Text = Class16.smethod_0(1649108324);
		this.textBox_33.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.textBox_33.Location = new System.Drawing.Point(77, 80);
		this.textBox_33.Name = Class16.smethod_0(1649110035);
		this.textBox_33.Size = new System.Drawing.Size(91, 20);
		this.textBox_33.TabIndex = 17;
		this.textBox_33.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox_32_KeyDown);
		this.textBox_33.Leave += new System.EventHandler(textBox_32_Leave);
		this.label_46.AutoSize = true;
		this.label_46.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_46.Location = new System.Drawing.Point(11, 82);
		this.label_46.Name = Class16.smethod_0(1649110051);
		this.label_46.Size = new System.Drawing.Size(61, 15);
		this.label_46.TabIndex = 16;
		this.label_46.Text = Class16.smethod_0(1649110065);
		this.textBox_29.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.textBox_29.Location = new System.Drawing.Point(77, 149);
		this.textBox_29.Name = Class16.smethod_0(1649110081);
		this.textBox_29.Size = new System.Drawing.Size(91, 20);
		this.textBox_29.TabIndex = 15;
		this.textBox_29.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox_32_KeyDown);
		this.textBox_29.Leave += new System.EventHandler(textBox_32_Leave);
		this.label_47.AutoSize = true;
		this.label_47.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_47.Location = new System.Drawing.Point(20, 151);
		this.label_47.Name = Class16.smethod_0(1649110097);
		this.label_47.Size = new System.Drawing.Size(52, 15);
		this.label_47.TabIndex = 14;
		this.label_47.Text = Class16.smethod_0(1649110119);
		this.textBox_28.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.textBox_28.Location = new System.Drawing.Point(77, 126);
		this.textBox_28.Name = Class16.smethod_0(1649110134);
		this.textBox_28.Size = new System.Drawing.Size(91, 20);
		this.textBox_28.TabIndex = 13;
		this.textBox_28.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox_32_KeyDown);
		this.textBox_28.Leave += new System.EventHandler(textBox_32_Leave);
		this.label_48.AutoSize = true;
		this.label_48.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_48.Location = new System.Drawing.Point(20, 128);
		this.label_48.Name = Class16.smethod_0(1649110150);
		this.label_48.Size = new System.Drawing.Size(52, 15);
		this.label_48.TabIndex = 12;
		this.label_48.Text = Class16.smethod_0(1649110164);
		this.textBox_35.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.textBox_35.Location = new System.Drawing.Point(77, 57);
		this.textBox_35.Name = Class16.smethod_0(1649110171);
		this.textBox_35.Size = new System.Drawing.Size(91, 20);
		this.textBox_35.TabIndex = 10;
		this.textBox_35.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox_32_KeyDown);
		this.textBox_35.Leave += new System.EventHandler(textBox_32_Leave);
		this.textBox_34.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.textBox_34.Location = new System.Drawing.Point(77, 34);
		this.textBox_34.Name = Class16.smethod_0(1649110197);
		this.textBox_34.Size = new System.Drawing.Size(91, 20);
		this.textBox_34.TabIndex = 9;
		this.textBox_34.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox_32_KeyDown);
		this.textBox_34.Leave += new System.EventHandler(textBox_32_Leave);
		this.textBox_32.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.textBox_32.Location = new System.Drawing.Point(77, 11);
		this.textBox_32.Name = Class16.smethod_0(1649110215);
		this.textBox_32.Size = new System.Drawing.Size(91, 20);
		this.textBox_32.TabIndex = 7;
		this.textBox_32.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox_32_KeyDown);
		this.textBox_32.Leave += new System.EventHandler(textBox_32_Leave);
		this.label_50.AutoSize = true;
		this.label_50.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_50.Location = new System.Drawing.Point(55, 58);
		this.label_50.Name = Class16.smethod_0(1649110225);
		this.label_50.Size = new System.Drawing.Size(17, 15);
		this.label_50.TabIndex = 6;
		this.label_50.Text = Class16.smethod_0(1649111438);
		this.label_51.AutoSize = true;
		this.label_51.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_51.Location = new System.Drawing.Point(55, 36);
		this.label_51.Name = Class16.smethod_0(1649110247);
		this.label_51.Size = new System.Drawing.Size(17, 15);
		this.label_51.TabIndex = 5;
		this.label_51.Text = Class16.smethod_0(1649013950);
		this.label_52.AutoSize = true;
		this.label_52.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_52.Location = new System.Drawing.Point(54, 13);
		this.label_52.Name = Class16.smethod_0(1649110261);
		this.label_52.Size = new System.Drawing.Size(18, 15);
		this.label_52.TabIndex = 4;
		this.label_52.Text = Class16.smethod_0(1649013968);
		this.textBox_26.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.textBox_26.Enabled = false;
		this.textBox_26.Location = new System.Drawing.Point(244, 13);
		this.textBox_26.Name = Class16.smethod_0(1649110267);
		this.textBox_26.Size = new System.Drawing.Size(91, 20);
		this.textBox_26.TabIndex = 2;
		this.textBox_26.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		this.label_55.AutoSize = true;
		this.label_55.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_55.Location = new System.Drawing.Point(188, 15);
		this.label_55.Name = Class16.smethod_0(1649110303);
		this.label_55.Size = new System.Drawing.Size(55, 15);
		this.label_55.TabIndex = 3;
		this.label_55.Text = Class16.smethod_0(1649107569);
		this.dataGridView_6.AllowUserToAddRows = false;
		this.dataGridView_6.AllowUserToDeleteRows = false;
		this.dataGridView_6.AllowUserToResizeColumns = false;
		this.dataGridView_6.AllowUserToResizeRows = false;
		this.dataGridView_6.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.dataGridView_6.BackgroundColor = System.Drawing.Color.FromArgb(15, 15, 15);
		this.dataGridView_6.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
		this.dataGridView_6.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
		dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
		dataGridViewCellStyle12.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 8.25f);
		dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
		dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
		dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
		this.dataGridView_6.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
		this.dataGridView_6.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridView_6.Columns.AddRange(this.dataGridViewTextBoxColumn_33, this.dataGridViewTextBoxColumn_34, this.dataGridViewTextBoxColumn_35);
		this.dataGridView_6.ContextMenuStrip = this.contextMenuStrip_2;
		dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(15, 15, 15);
		dataGridViewCellStyle13.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 8.25f);
		dataGridViewCellStyle13.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
		dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
		dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
		this.dataGridView_6.DefaultCellStyle = dataGridViewCellStyle13;
		this.dataGridView_6.EnableHeadersVisualStyles = false;
		this.dataGridView_6.Location = new System.Drawing.Point(1, 29);
		this.dataGridView_6.Name = Class16.smethod_0(1649110317);
		this.dataGridView_6.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
		this.dataGridView_6.RowHeadersVisible = false;
		this.dataGridView_6.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		this.dataGridView_6.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		this.dataGridView_6.ShowCellErrors = false;
		this.dataGridView_6.ShowCellToolTips = false;
		this.dataGridView_6.ShowEditingIcon = false;
		this.dataGridView_6.ShowRowErrors = false;
		this.dataGridView_6.Size = new System.Drawing.Size(359, 425);
		this.dataGridView_6.TabIndex = 14;
		this.dataGridView_6.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(dataGridView_6_CellMouseEnter);
		this.dataGridView_6.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(dataGridView_6_CellMouseLeave);
		this.dataGridView_6.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(dataGridView_6_CellMouseMove);
		this.dataGridView_6.CurrentCellChanged += new System.EventHandler(dataGridView_6_CurrentCellChanged);
		this.dataGridView_6.KeyDown += new System.Windows.Forms.KeyEventHandler(dataGridView_10_KeyDown);
		dataGridViewCellStyle14.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.dataGridViewTextBoxColumn_33.DefaultCellStyle = dataGridViewCellStyle14;
		this.dataGridViewTextBoxColumn_33.FillWeight = 6.912442f;
		this.dataGridViewTextBoxColumn_33.HeaderText = Class16.smethod_0(1648929947);
		this.dataGridViewTextBoxColumn_33.Name = Class16.smethod_0(1649029567);
		this.dataGridViewTextBoxColumn_33.ReadOnly = true;
		this.dataGridViewTextBoxColumn_33.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
		this.dataGridViewTextBoxColumn_33.Width = 45;
		dataGridViewCellStyle15.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		dataGridViewCellStyle15.ForeColor = System.Drawing.Color.FromArgb(77, 255, 143);
		this.dataGridViewTextBoxColumn_34.DefaultCellStyle = dataGridViewCellStyle15;
		this.dataGridViewTextBoxColumn_34.FillWeight = 44.7233f;
		this.dataGridViewTextBoxColumn_34.HeaderText = Class16.smethod_0(1649118934);
		this.dataGridViewTextBoxColumn_34.Name = Class16.smethod_0(1649029256);
		this.dataGridViewTextBoxColumn_34.ReadOnly = true;
		this.dataGridViewTextBoxColumn_34.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
		this.dataGridViewTextBoxColumn_34.Width = 95;
		dataGridViewCellStyle16.ForeColor = System.Drawing.Color.White;
		this.dataGridViewTextBoxColumn_35.DefaultCellStyle = dataGridViewCellStyle16;
		this.dataGridViewTextBoxColumn_35.HeaderText = Class16.smethod_0(1648936731);
		this.dataGridViewTextBoxColumn_35.Name = Class16.smethod_0(1649029289);
		this.dataGridViewTextBoxColumn_35.ReadOnly = true;
		this.dataGridViewTextBoxColumn_35.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
		this.dataGridViewTextBoxColumn_35.Width = 217;
		this.toolStrip_1.AutoSize = false;
		this.toolStrip_1.BackColor = System.Drawing.Color.FromArgb(239, 244, 250);
		this.toolStrip_1.GripMargin = new System.Windows.Forms.Padding(0);
		this.toolStrip_1.Items.AddRange(new System.Windows.Forms.ToolStripItem[4] { this.toolStripButton_1, this.toolStripButton_3, this.toolStripDropDownButton_1, this.toolStripDropDownButton_3 });
		this.toolStrip_1.Location = new System.Drawing.Point(3, 3);
		this.toolStrip_1.Name = Class16.smethod_0(1649107758);
		this.toolStrip_1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
		this.toolStrip_1.Size = new System.Drawing.Size(960, 25);
		this.toolStrip_1.TabIndex = 19;
		this.toolStrip_1.Text = Class16.smethod_0(1649107758);
		this.toolStripButton_1.Image = ACE.Properties.Resources.NpcGenEditorForm_ExportResources;
		this.toolStripButton_1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
		this.toolStripButton_1.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.toolStripButton_1.Name = Class16.smethod_0(1649110329);
		this.toolStripButton_1.Size = new System.Drawing.Size(62, 22);
		this.toolStripButton_1.Text = Class16.smethod_0(1648931384);
		this.toolStripButton_1.ToolTipText = Class16.smethod_0(1648931384);
		this.toolStripButton_1.Click += new System.EventHandler(toolStripButton_6_Click);
		this.toolStripButton_3.Image = ACE.Properties.Resources.NpcGenEditorForm_ImportResources;
		this.toolStripButton_3.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.toolStripButton_3.Name = Class16.smethod_0(1649110359);
		this.toolStripButton_3.Size = new System.Drawing.Size(63, 22);
		this.toolStripButton_3.Text = Class16.smethod_0(1648931405);
		this.toolStripButton_3.ToolTipText = Class16.smethod_0(1648931405);
		this.toolStripButton_3.Click += new System.EventHandler(toolStripButton_7_Click);
		this.toolStripDropDownButton_1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.toolStripMenuItem_11, this.toolStripMenuItem_12 });
		this.toolStripDropDownButton_1.Image = ACE.Properties.Resources.NpcGenEditorForm_LineUpResource;
		this.toolStripDropDownButton_1.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.toolStripDropDownButton_1.Name = Class16.smethod_0(1649110381);
		this.toolStripDropDownButton_1.Size = new System.Drawing.Size(76, 22);
		this.toolStripDropDownButton_1.Text = Class16.smethod_0(1649110394);
		this.toolStripDropDownButton_1.ToolTipText = Class16.smethod_0(1649107841);
		this.toolStripMenuItem_11.Image = ACE.Properties.Resources.NpcGenEditorForm_ResourcesOnX;
		this.toolStripMenuItem_11.Name = Class16.smethod_0(1649110408);
		this.toolStripMenuItem_11.Size = new System.Drawing.Size(100, 22);
		this.toolStripMenuItem_11.Text = Class16.smethod_0(1649110427);
		this.toolStripMenuItem_11.Click += new System.EventHandler(toolStripMenuItem_23_Click);
		this.toolStripMenuItem_12.Image = ACE.Properties.Resources.NpcGenEditorForm_ResourcesOnZ;
		this.toolStripMenuItem_12.Name = Class16.smethod_0(1649110446);
		this.toolStripMenuItem_12.Size = new System.Drawing.Size(100, 22);
		this.toolStripMenuItem_12.Text = Class16.smethod_0(1649110457);
		this.toolStripMenuItem_12.Click += new System.EventHandler(toolStripMenuItem_24_Click);
		this.toolStripDropDownButton_3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.toolStripMenuItem_13, this.toolStripMenuItem_10 });
		this.toolStripDropDownButton_3.Image = ACE.Properties.Resources.NpcGenEditorForm_Move;
		this.toolStripDropDownButton_3.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.toolStripDropDownButton_3.Name = Class16.smethod_0(1649110476);
		this.toolStripDropDownButton_3.Size = new System.Drawing.Size(66, 22);
		this.toolStripDropDownButton_3.Text = Class16.smethod_0(1649113514);
		this.toolStripDropDownButton_3.ToolTipText = Class16.smethod_0(1649113514);
		this.toolStripMenuItem_13.Image = ACE.Properties.Resources.NpcGenEditorForm_ResourceUp;
		this.toolStripMenuItem_13.Name = Class16.smethod_0(1649110488);
		this.toolStripMenuItem_13.Size = new System.Drawing.Size(146, 22);
		this.toolStripMenuItem_13.Text = Class16.smethod_0(1649106946);
		this.toolStripMenuItem_13.Click += new System.EventHandler(toolStripMenuItem_20_Click);
		this.toolStripMenuItem_10.Image = ACE.Properties.Resources.NpcGenEditorForm_ResourceDown;
		this.toolStripMenuItem_10.Name = Class16.smethod_0(1649110505);
		this.toolStripMenuItem_10.Size = new System.Drawing.Size(146, 22);
		this.toolStripMenuItem_10.Text = Class16.smethod_0(1649106995);
		this.toolStripMenuItem_10.Click += new System.EventHandler(toolStripMenuItem_21_Click);
		this.button_22.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.button_22.ForeColor = System.Drawing.Color.Black;
		this.button_22.Image = ACE.Properties.Resources.NpcGenEditorForm_ResourcesRemoveButton;
		this.button_22.Location = new System.Drawing.Point(180, 454);
		this.button_22.Name = Class16.smethod_0(1649109508);
		this.button_22.Size = new System.Drawing.Size(181, 29);
		this.button_22.TabIndex = 16;
		this.button_22.Text = Class16.smethod_0(1648931371);
		this.button_22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.button_22.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		this.button_22.UseVisualStyleBackColor = true;
		this.button_22.Click += new System.EventHandler(button_22_Click);
		this.button_17.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.button_17.ForeColor = System.Drawing.Color.Black;
		this.button_17.Image = ACE.Properties.Resources.NpcGenEditorForm_ResourcesCloneButton;
		this.button_17.Location = new System.Drawing.Point(0, 454);
		this.button_17.Name = Class16.smethod_0(1649109528);
		this.button_17.Size = new System.Drawing.Size(181, 29);
		this.button_17.TabIndex = 15;
		this.button_17.Text = Class16.smethod_0(1648931357);
		this.button_17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.button_17.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		this.button_17.UseVisualStyleBackColor = true;
		this.button_17.Click += new System.EventHandler(button_17_Click);
		this.tabPage_0.BackColor = System.Drawing.Color.FromArgb(239, 244, 250);
		this.tabPage_0.Controls.Add(this.groupBox_19);
		this.tabPage_0.Controls.Add(this.groupBox_17);
		this.tabPage_0.Controls.Add(this.dataGridView_1);
		this.tabPage_0.Controls.Add(this.button_5);
		this.tabPage_0.Controls.Add(this.button_3);
		this.tabPage_0.Controls.Add(this.toolStrip_2);
		this.tabPage_0.Location = new System.Drawing.Point(4, 22);
		this.tabPage_0.Name = Class16.smethod_0(1649109555);
		this.tabPage_0.Padding = new System.Windows.Forms.Padding(3);
		this.tabPage_0.Size = new System.Drawing.Size(966, 483);
		this.tabPage_0.TabIndex = 2;
		this.tabPage_0.Text = Class16.smethod_0(1649109583);
		this.groupBox_19.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.groupBox_19.Controls.Add(this.pictureBox_0);
		this.groupBox_19.Location = new System.Drawing.Point(366, 131);
		this.groupBox_19.Name = Class16.smethod_0(1649109592);
		this.groupBox_19.Size = new System.Drawing.Size(597, 350);
		this.groupBox_19.TabIndex = 21;
		this.groupBox_19.TabStop = false;
		this.groupBox_19.Text = Class16.smethod_0(1649056363);
		this.pictureBox_0.BackColor = System.Drawing.Color.FromArgb(239, 244, 250);
		this.pictureBox_0.Location = new System.Drawing.Point(2, 15);
		this.pictureBox_0.Name = Class16.smethod_0(1649118937);
		this.pictureBox_0.Size = new System.Drawing.Size(594, 335);
		this.pictureBox_0.TabIndex = 0;
		this.pictureBox_0.TabStop = false;
		this.groupBox_17.BackColor = System.Drawing.Color.FromArgb(239, 244, 250);
		this.groupBox_17.Controls.Add(this.textBox_0);
		this.groupBox_17.Controls.Add(this.label_0);
		this.groupBox_17.Controls.Add(this.button_4);
		this.groupBox_17.Controls.Add(this.textBox_4);
		this.groupBox_17.Controls.Add(this.groupBox_1);
		this.groupBox_17.Controls.Add(this.label_80);
		this.groupBox_17.Controls.Add(this.textBox_5);
		this.groupBox_17.Controls.Add(this.label_79);
		this.groupBox_17.Controls.Add(this.textBox_3);
		this.groupBox_17.Controls.Add(this.label_76);
		this.groupBox_17.Controls.Add(this.textBox_2);
		this.groupBox_17.Controls.Add(this.label_77);
		this.groupBox_17.Controls.Add(this.textBox_1);
		this.groupBox_17.Controls.Add(this.label_78);
		this.groupBox_17.Controls.Add(this.label_74);
		this.groupBox_17.Controls.Add(this.textBox_12);
		this.groupBox_17.Controls.Add(this.textBox_8);
		this.groupBox_17.Controls.Add(this.textBox_7);
		this.groupBox_17.Controls.Add(this.label_87);
		this.groupBox_17.Controls.Add(this.label_88);
		this.groupBox_17.Controls.Add(this.label_89);
		this.groupBox_17.Location = new System.Drawing.Point(364, 1);
		this.groupBox_17.Name = Class16.smethod_0(1649109608);
		this.groupBox_17.Size = new System.Drawing.Size(599, 130);
		this.groupBox_17.TabIndex = 20;
		this.groupBox_17.TabStop = false;
		this.groupBox_17.Text = Class16.smethod_0(1649002051);
		this.textBox_0.BackColor = System.Drawing.Color.FromArgb(128, 255, 128);
		this.textBox_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.textBox_0.Location = new System.Drawing.Point(67, 13);
		this.textBox_0.Name = Class16.smethod_0(1649109624);
		this.textBox_0.Size = new System.Drawing.Size(91, 20);
		this.textBox_0.TabIndex = 69;
		this.textBox_0.TextChanged += new System.EventHandler(textBox_0_TextChanged);
		this.textBox_0.DoubleClick += new System.EventHandler(textBox_0_DoubleClick);
		this.textBox_0.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox_7_KeyDown);
		this.textBox_0.Leave += new System.EventHandler(textBox_7_Leave);
		this.label_0.AutoSize = true;
		this.label_0.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_0.ForeColor = System.Drawing.Color.Red;
		this.label_0.Location = new System.Drawing.Point(157, 15);
		this.label_0.Name = Class16.smethod_0(1649109642);
		this.label_0.Size = new System.Drawing.Size(0, 16);
		this.label_0.TabIndex = 68;
		this.button_4.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.button_4.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.button_4.ForeColor = System.Drawing.Color.FromArgb(192, 64, 0);
		this.button_4.Location = new System.Drawing.Point(341, 74);
		this.button_4.Name = Class16.smethod_0(1649109666);
		this.button_4.Size = new System.Drawing.Size(255, 52);
		this.button_4.TabIndex = 67;
		this.button_4.Text = Class16.smethod_0(1649107425);
		this.button_4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		this.button_4.UseVisualStyleBackColor = true;
		this.button_4.Click += new System.EventHandler(button_4_Click);
		this.textBox_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.textBox_4.Location = new System.Drawing.Point(248, 105);
		this.textBox_4.Name = Class16.smethod_0(1649109710);
		this.textBox_4.Size = new System.Drawing.Size(91, 20);
		this.textBox_4.TabIndex = 50;
		this.textBox_4.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox_7_KeyDown);
		this.textBox_4.Leave += new System.EventHandler(textBox_7_Leave);
		this.groupBox_1.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.groupBox_1.BackColor = System.Drawing.Color.FromArgb(239, 244, 250);
		this.groupBox_1.Controls.Add(this.numericUpDown_1);
		this.groupBox_1.Controls.Add(this.label_43);
		this.groupBox_1.Controls.Add(this.numericUpDown_0);
		this.groupBox_1.Controls.Add(this.label_66);
		this.groupBox_1.Location = new System.Drawing.Point(342, 10);
		this.groupBox_1.Name = Class16.smethod_0(1649109715);
		this.groupBox_1.Size = new System.Drawing.Size(254, 63);
		this.groupBox_1.TabIndex = 18;
		this.groupBox_1.TabStop = false;
		this.groupBox_1.Text = Class16.smethod_0(1649109740);
		this.numericUpDown_1.BackColor = System.Drawing.SystemColors.Window;
		this.numericUpDown_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.numericUpDown_1.Location = new System.Drawing.Point(157, 40);
		this.numericUpDown_1.Maximum = new decimal(new int[4] { 2147483647, 0, 0, 0 });
		this.numericUpDown_1.Minimum = new decimal(new int[4] { -2147483648, 0, 0, -2147483648 });
		this.numericUpDown_1.Name = Class16.smethod_0(1649109769);
		this.numericUpDown_1.Size = new System.Drawing.Size(76, 20);
		this.numericUpDown_1.TabIndex = 41;
		this.label_43.AutoSize = true;
		this.label_43.Location = new System.Drawing.Point(98, 43);
		this.label_43.Name = Class16.smethod_0(1649109794);
		this.label_43.Size = new System.Drawing.Size(57, 13);
		this.label_43.TabIndex = 40;
		this.label_43.Text = Class16.smethod_0(1649108039);
		this.numericUpDown_0.BackColor = System.Drawing.SystemColors.Window;
		this.numericUpDown_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.numericUpDown_0.Location = new System.Drawing.Point(157, 17);
		this.numericUpDown_0.Maximum = new decimal(new int[4] { 2147483647, 0, 0, 0 });
		this.numericUpDown_0.Minimum = new decimal(new int[4] { -2147483648, 0, 0, -2147483648 });
		this.numericUpDown_0.Name = Class16.smethod_0(1649109808);
		this.numericUpDown_0.Size = new System.Drawing.Size(76, 20);
		this.numericUpDown_0.TabIndex = 39;
		this.label_66.AutoSize = true;
		this.label_66.Location = new System.Drawing.Point(78, 18);
		this.label_66.Name = Class16.smethod_0(1649109836);
		this.label_66.Size = new System.Drawing.Size(77, 13);
		this.label_66.TabIndex = 0;
		this.label_66.Text = Class16.smethod_0(1649109842);
		this.label_80.AutoSize = true;
		this.label_80.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_80.Location = new System.Drawing.Point(165, 107);
		this.label_80.Name = Class16.smethod_0(1649109871);
		this.label_80.Size = new System.Drawing.Size(84, 15);
		this.label_80.TabIndex = 49;
		this.label_80.Text = Class16.smethod_0(1649109885);
		this.textBox_5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.textBox_5.ContextMenuStrip = this.contextMenuStrip_1;
		this.textBox_5.Location = new System.Drawing.Point(248, 82);
		this.textBox_5.Name = Class16.smethod_0(1649109898);
		this.textBox_5.Size = new System.Drawing.Size(91, 20);
		this.textBox_5.TabIndex = 48;
		this.textBox_5.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox_7_KeyDown);
		this.textBox_5.Leave += new System.EventHandler(textBox_7_Leave);
		this.label_79.AutoSize = true;
		this.label_79.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_79.Location = new System.Drawing.Point(200, 83);
		this.label_79.Name = Class16.smethod_0(1649109924);
		this.label_79.Size = new System.Drawing.Size(49, 15);
		this.label_79.TabIndex = 47;
		this.label_79.Text = Class16.smethod_0(1649111262);
		this.textBox_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.textBox_3.Location = new System.Drawing.Point(248, 59);
		this.textBox_3.Name = Class16.smethod_0(1649109930);
		this.textBox_3.Size = new System.Drawing.Size(91, 20);
		this.textBox_3.TabIndex = 46;
		this.textBox_3.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox_7_KeyDown);
		this.textBox_3.Leave += new System.EventHandler(textBox_7_Leave);
		this.label_76.AutoSize = true;
		this.label_76.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_76.Location = new System.Drawing.Point(193, 61);
		this.label_76.Name = Class16.smethod_0(1649109946);
		this.label_76.Size = new System.Drawing.Size(56, 15);
		this.label_76.TabIndex = 45;
		this.label_76.Text = Class16.smethod_0(1649111021);
		this.textBox_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.textBox_2.Location = new System.Drawing.Point(248, 36);
		this.textBox_2.Name = Class16.smethod_0(1649109960);
		this.textBox_2.Size = new System.Drawing.Size(91, 20);
		this.textBox_2.TabIndex = 44;
		this.textBox_2.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox_7_KeyDown);
		this.textBox_2.Leave += new System.EventHandler(textBox_7_Leave);
		this.label_77.AutoSize = true;
		this.label_77.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_77.Location = new System.Drawing.Point(213, 38);
		this.label_77.Name = Class16.smethod_0(1649109976);
		this.label_77.Size = new System.Drawing.Size(36, 15);
		this.label_77.TabIndex = 43;
		this.label_77.Text = Class16.smethod_0(1649109998);
		this.textBox_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.textBox_1.Location = new System.Drawing.Point(67, 105);
		this.textBox_1.Name = Class16.smethod_0(1649110012);
		this.textBox_1.Size = new System.Drawing.Size(91, 20);
		this.textBox_1.TabIndex = 42;
		this.textBox_1.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox_7_KeyDown);
		this.textBox_1.Leave += new System.EventHandler(textBox_7_Leave);
		this.label_78.AutoSize = true;
		this.label_78.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_78.Location = new System.Drawing.Point(26, 107);
		this.label_78.Name = Class16.smethod_0(1649109004);
		this.label_78.Size = new System.Drawing.Size(36, 15);
		this.label_78.TabIndex = 41;
		this.label_78.Text = Class16.smethod_0(1649109010);
		this.label_74.AutoSize = true;
		this.label_74.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_74.Location = new System.Drawing.Point(40, 15);
		this.label_74.Name = Class16.smethod_0(1649109024);
		this.label_74.Size = new System.Drawing.Size(22, 15);
		this.label_74.TabIndex = 39;
		this.label_74.Text = Class16.smethod_0(1648930840);
		this.textBox_12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.textBox_12.Location = new System.Drawing.Point(67, 82);
		this.textBox_12.Name = Class16.smethod_0(1649109046);
		this.textBox_12.Size = new System.Drawing.Size(91, 20);
		this.textBox_12.TabIndex = 10;
		this.textBox_12.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox_7_KeyDown);
		this.textBox_12.Leave += new System.EventHandler(textBox_7_Leave);
		this.textBox_8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.textBox_8.Location = new System.Drawing.Point(67, 59);
		this.textBox_8.Name = Class16.smethod_0(1649109056);
		this.textBox_8.Size = new System.Drawing.Size(91, 20);
		this.textBox_8.TabIndex = 9;
		this.textBox_8.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox_7_KeyDown);
		this.textBox_8.Leave += new System.EventHandler(textBox_7_Leave);
		this.textBox_7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.textBox_7.Location = new System.Drawing.Point(67, 36);
		this.textBox_7.Name = Class16.smethod_0(1649109074);
		this.textBox_7.Size = new System.Drawing.Size(91, 20);
		this.textBox_7.TabIndex = 7;
		this.textBox_7.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox_7_KeyDown);
		this.textBox_7.Leave += new System.EventHandler(textBox_7_Leave);
		this.label_87.AutoSize = true;
		this.label_87.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_87.Location = new System.Drawing.Point(45, 83);
		this.label_87.Name = Class16.smethod_0(1649109100);
		this.label_87.Size = new System.Drawing.Size(17, 15);
		this.label_87.TabIndex = 6;
		this.label_87.Text = Class16.smethod_0(1649111438);
		this.label_88.AutoSize = true;
		this.label_88.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_88.Location = new System.Drawing.Point(45, 61);
		this.label_88.Name = Class16.smethod_0(1649109106);
		this.label_88.Size = new System.Drawing.Size(17, 15);
		this.label_88.TabIndex = 5;
		this.label_88.Text = Class16.smethod_0(1649013950);
		this.label_89.AutoSize = true;
		this.label_89.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_89.Location = new System.Drawing.Point(44, 38);
		this.label_89.Name = Class16.smethod_0(1649109120);
		this.label_89.Size = new System.Drawing.Size(18, 15);
		this.label_89.TabIndex = 4;
		this.label_89.Text = Class16.smethod_0(1649013968);
		this.dataGridView_1.AllowUserToAddRows = false;
		this.dataGridView_1.AllowUserToDeleteRows = false;
		this.dataGridView_1.AllowUserToResizeColumns = false;
		this.dataGridView_1.AllowUserToResizeRows = false;
		this.dataGridView_1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.dataGridView_1.BackgroundColor = System.Drawing.Color.FromArgb(15, 15, 15);
		this.dataGridView_1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
		this.dataGridView_1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
		dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Control;
		dataGridViewCellStyle17.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 8.25f);
		dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText;
		dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
		dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
		this.dataGridView_1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
		this.dataGridView_1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridView_1.Columns.AddRange(this.dataGridViewTextBoxColumn_7, this.dataGridViewTextBoxColumn_8, this.dataGridViewTextBoxColumn_9, this.dataGridViewTextBoxColumn_0);
		this.dataGridView_1.ContextMenuStrip = this.contextMenuStrip_2;
		dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle18.BackColor = System.Drawing.Color.FromArgb(15, 15, 15);
		dataGridViewCellStyle18.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 8.25f);
		dataGridViewCellStyle18.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
		dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
		dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
		this.dataGridView_1.DefaultCellStyle = dataGridViewCellStyle18;
		this.dataGridView_1.EnableHeadersVisualStyles = false;
		this.dataGridView_1.Location = new System.Drawing.Point(1, 29);
		this.dataGridView_1.Name = Class16.smethod_0(1649118916);
		this.dataGridView_1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
		this.dataGridView_1.RowHeadersVisible = false;
		this.dataGridView_1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		this.dataGridView_1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		this.dataGridView_1.ShowCellErrors = false;
		this.dataGridView_1.ShowCellToolTips = false;
		this.dataGridView_1.ShowEditingIcon = false;
		this.dataGridView_1.ShowRowErrors = false;
		this.dataGridView_1.Size = new System.Drawing.Size(359, 425);
		this.dataGridView_1.TabIndex = 17;
		this.dataGridView_1.CurrentCellChanged += new System.EventHandler(dataGridView_1_CurrentCellChanged);
		this.dataGridView_1.KeyDown += new System.Windows.Forms.KeyEventHandler(dataGridView_10_KeyDown);
		dataGridViewCellStyle19.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.dataGridViewTextBoxColumn_7.DefaultCellStyle = dataGridViewCellStyle19;
		this.dataGridViewTextBoxColumn_7.FillWeight = 6.912442f;
		this.dataGridViewTextBoxColumn_7.HeaderText = Class16.smethod_0(1648929947);
		this.dataGridViewTextBoxColumn_7.Name = Class16.smethod_0(1649029397);
		this.dataGridViewTextBoxColumn_7.ReadOnly = true;
		this.dataGridViewTextBoxColumn_7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
		this.dataGridViewTextBoxColumn_7.Width = 45;
		dataGridViewCellStyle20.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		dataGridViewCellStyle20.ForeColor = System.Drawing.Color.FromArgb(77, 255, 143);
		this.dataGridViewTextBoxColumn_8.DefaultCellStyle = dataGridViewCellStyle20;
		this.dataGridViewTextBoxColumn_8.FillWeight = 44.7233f;
		this.dataGridViewTextBoxColumn_8.HeaderText = Class16.smethod_0(1649118934);
		this.dataGridViewTextBoxColumn_8.Name = Class16.smethod_0(1649029431);
		this.dataGridViewTextBoxColumn_8.ReadOnly = true;
		this.dataGridViewTextBoxColumn_8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
		this.dataGridViewTextBoxColumn_8.Width = 60;
		dataGridViewCellStyle21.ForeColor = System.Drawing.Color.White;
		this.dataGridViewTextBoxColumn_9.DefaultCellStyle = dataGridViewCellStyle21;
		this.dataGridViewTextBoxColumn_9.HeaderText = Class16.smethod_0(1648936731);
		this.dataGridViewTextBoxColumn_9.Name = Class16.smethod_0(1649029457);
		this.dataGridViewTextBoxColumn_9.ReadOnly = true;
		this.dataGridViewTextBoxColumn_9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
		this.dataGridViewTextBoxColumn_9.Width = 196;
		this.dataGridViewTextBoxColumn_0.HeaderText = Class16.smethod_0(1649108102);
		this.dataGridViewTextBoxColumn_0.Name = Class16.smethod_0(1648990839);
		this.dataGridViewTextBoxColumn_0.ReadOnly = true;
		this.dataGridViewTextBoxColumn_0.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
		this.dataGridViewTextBoxColumn_0.Width = 59;
		this.button_5.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.button_5.ForeColor = System.Drawing.Color.Black;
		this.button_5.Image = ACE.Properties.Resources.NpcGenEditorForm_remove;
		this.button_5.Location = new System.Drawing.Point(180, 454);
		this.button_5.Name = Class16.smethod_0(1649109142);
		this.button_5.Size = new System.Drawing.Size(181, 29);
		this.button_5.TabIndex = 19;
		this.button_5.Text = Class16.smethod_0(1648925718);
		this.button_5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.button_5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		this.button_5.UseVisualStyleBackColor = true;
		this.button_5.Click += new System.EventHandler(button_5_Click);
		this.button_3.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.button_3.ForeColor = System.Drawing.Color.Black;
		this.button_3.Image = ACE.Properties.Resources.NpcGenEditorForm_Clone;
		this.button_3.Location = new System.Drawing.Point(0, 454);
		this.button_3.Name = Class16.smethod_0(1649109163);
		this.button_3.Size = new System.Drawing.Size(181, 29);
		this.button_3.TabIndex = 18;
		this.button_3.Text = Class16.smethod_0(1648931357);
		this.button_3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.button_3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		this.button_3.UseVisualStyleBackColor = true;
		this.button_3.Click += new System.EventHandler(button_3_Click);
		this.toolStrip_2.AutoSize = false;
		this.toolStrip_2.BackColor = System.Drawing.Color.FromArgb(239, 244, 250);
		this.toolStrip_2.GripMargin = new System.Windows.Forms.Padding(0);
		this.toolStrip_2.Items.AddRange(new System.Windows.Forms.ToolStripItem[4] { this.toolStripButton_4, this.toolStripButton_5, this.toolStripDropDownButton_4, this.toolStripDropDownButton_5 });
		this.toolStrip_2.Location = new System.Drawing.Point(3, 3);
		this.toolStrip_2.Name = Class16.smethod_0(1649109199);
		this.toolStrip_2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
		this.toolStrip_2.Size = new System.Drawing.Size(960, 25);
		this.toolStrip_2.TabIndex = 22;
		this.toolStrip_2.Text = Class16.smethod_0(1649109199);
		this.toolStripButton_4.Image = ACE.Properties.Resources.NpcGenEditorForm_ExportResources;
		this.toolStripButton_4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
		this.toolStripButton_4.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.toolStripButton_4.Name = Class16.smethod_0(1649109208);
		this.toolStripButton_4.Size = new System.Drawing.Size(62, 22);
		this.toolStripButton_4.Text = Class16.smethod_0(1648931384);
		this.toolStripButton_4.ToolTipText = Class16.smethod_0(1648931384);
		this.toolStripButton_4.Click += new System.EventHandler(toolStripButton_6_Click);
		this.toolStripButton_5.Image = ACE.Properties.Resources.NpcGenEditorForm_ImportResources;
		this.toolStripButton_5.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.toolStripButton_5.Name = Class16.smethod_0(1649109239);
		this.toolStripButton_5.Size = new System.Drawing.Size(63, 22);
		this.toolStripButton_5.Text = Class16.smethod_0(1648931405);
		this.toolStripButton_5.ToolTipText = Class16.smethod_0(1648931405);
		this.toolStripButton_5.Click += new System.EventHandler(toolStripButton_7_Click);
		this.toolStripDropDownButton_4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.toolStripMenuItem_23, this.toolStripMenuItem_24 });
		this.toolStripDropDownButton_4.Image = ACE.Properties.Resources.NpcGenEditorForm_LineUpResource;
		this.toolStripDropDownButton_4.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.toolStripDropDownButton_4.Name = Class16.smethod_0(1649109262);
		this.toolStripDropDownButton_4.Size = new System.Drawing.Size(75, 22);
		this.toolStripDropDownButton_4.Text = Class16.smethod_0(1649107841);
		this.toolStripDropDownButton_4.ToolTipText = Class16.smethod_0(1649107841);
		this.toolStripMenuItem_23.Image = ACE.Properties.Resources.NpcGenEditorForm_ToolStripLineUpX;
		this.toolStripMenuItem_23.Name = Class16.smethod_0(1649068344);
		this.toolStripMenuItem_23.Size = new System.Drawing.Size(97, 22);
		this.toolStripMenuItem_23.Text = Class16.smethod_0(1649107886);
		this.toolStripMenuItem_23.Click += new System.EventHandler(toolStripMenuItem_23_Click);
		this.toolStripMenuItem_24.Image = ACE.Properties.Resources.NpcGenEditorForm_ToolStripLineUpZ;
		this.toolStripMenuItem_24.Name = Class16.smethod_0(1649063787);
		this.toolStripMenuItem_24.Size = new System.Drawing.Size(97, 22);
		this.toolStripMenuItem_24.Text = Class16.smethod_0(1648915467);
		this.toolStripMenuItem_24.Click += new System.EventHandler(toolStripMenuItem_24_Click);
		this.toolStripDropDownButton_5.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.toolStripMenuItem_25, this.toolStripMenuItem_17 });
		this.toolStripDropDownButton_5.Image = ACE.Properties.Resources.NpcGenEditorForm_Move;
		this.toolStripDropDownButton_5.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.toolStripDropDownButton_5.Name = Class16.smethod_0(1649109293);
		this.toolStripDropDownButton_5.Size = new System.Drawing.Size(66, 22);
		this.toolStripDropDownButton_5.Text = Class16.smethod_0(1649113514);
		this.toolStripDropDownButton_5.ToolTipText = Class16.smethod_0(1649113514);
		this.toolStripMenuItem_25.Image = ACE.Properties.Resources.NpcGenEditorForm_ResourceUp;
		this.toolStripMenuItem_25.Name = Class16.smethod_0(1649062981);
		this.toolStripMenuItem_25.Size = new System.Drawing.Size(154, 22);
		this.toolStripMenuItem_25.Text = Class16.smethod_0(1649113551);
		this.toolStripMenuItem_25.Click += new System.EventHandler(toolStripMenuItem_20_Click);
		this.toolStripMenuItem_17.Image = ACE.Properties.Resources.NpcGenEditorForm_ResourceDown;
		this.toolStripMenuItem_17.Name = Class16.smethod_0(1649068258);
		this.toolStripMenuItem_17.Size = new System.Drawing.Size(154, 22);
		this.toolStripMenuItem_17.Text = Class16.smethod_0(1649113591);
		this.toolStripMenuItem_17.Click += new System.EventHandler(toolStripMenuItem_21_Click);
		this.tabPage_6.BackColor = System.Drawing.Color.FromArgb(239, 244, 250);
		this.tabPage_6.Controls.Add(this.groupBox_6);
		this.tabPage_6.Controls.Add(this.groupBox_5);
		this.tabPage_6.Controls.Add(this.groupBox_4);
		this.tabPage_6.Controls.Add(this.groupBox_3);
		this.tabPage_6.Controls.Add(this.dataGridView_10);
		this.tabPage_6.Controls.Add(this.toolStrip_3);
		this.tabPage_6.Controls.Add(this.button_28);
		this.tabPage_6.Controls.Add(this.button_26);
		this.tabPage_6.Location = new System.Drawing.Point(4, 22);
		this.tabPage_6.Name = Class16.smethod_0(1649109324);
		this.tabPage_6.Padding = new System.Windows.Forms.Padding(3);
		this.tabPage_6.Size = new System.Drawing.Size(966, 483);
		this.tabPage_6.TabIndex = 3;
		this.tabPage_6.Text = Class16.smethod_0(1648942688);
		this.groupBox_6.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.groupBox_6.Controls.Add(this.dataGridView_0);
		this.groupBox_6.Controls.Add(this.button_12);
		this.groupBox_6.Location = new System.Drawing.Point(767, 214);
		this.groupBox_6.Name = Class16.smethod_0(1649109342);
		this.groupBox_6.Size = new System.Drawing.Size(198, 267);
		this.groupBox_6.TabIndex = 31;
		this.groupBox_6.TabStop = false;
		this.groupBox_6.Text = Class16.smethod_0(1649109359);
		this.dataGridView_0.AllowUserToAddRows = false;
		this.dataGridView_0.AllowUserToDeleteRows = false;
		this.dataGridView_0.AllowUserToResizeColumns = false;
		this.dataGridView_0.AllowUserToResizeRows = false;
		this.dataGridView_0.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.dataGridView_0.BackgroundColor = System.Drawing.Color.FromArgb(15, 15, 15);
		this.dataGridView_0.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
		this.dataGridView_0.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
		this.dataGridView_0.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridView_0.Columns.AddRange(this.dataGridViewTextBoxColumn_21, this.dataGridViewTextBoxColumn_22, this.dataGridViewTextBoxColumn_23);
		dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle22.BackColor = System.Drawing.Color.FromArgb(15, 15, 15);
		dataGridViewCellStyle22.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 8.25f);
		dataGridViewCellStyle22.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
		dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
		dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
		this.dataGridView_0.DefaultCellStyle = dataGridViewCellStyle22;
		this.dataGridView_0.EnableHeadersVisualStyles = false;
		this.dataGridView_0.Location = new System.Drawing.Point(2, 15);
		this.dataGridView_0.Name = Class16.smethod_0(1649109383);
		this.dataGridView_0.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
		this.dataGridView_0.RowHeadersVisible = false;
		this.dataGridView_0.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		this.dataGridView_0.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		this.dataGridView_0.ShowCellErrors = false;
		this.dataGridView_0.ShowCellToolTips = false;
		this.dataGridView_0.ShowEditingIcon = false;
		this.dataGridView_0.ShowRowErrors = false;
		this.dataGridView_0.Size = new System.Drawing.Size(194, 197);
		this.dataGridView_0.TabIndex = 25;
		this.dataGridView_0.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(dataGridView_0_CellDoubleClick);
		dataGridViewCellStyle23.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.dataGridViewTextBoxColumn_21.DefaultCellStyle = dataGridViewCellStyle23;
		this.dataGridViewTextBoxColumn_21.FillWeight = 6.912442f;
		this.dataGridViewTextBoxColumn_21.HeaderText = Class16.smethod_0(1648929947);
		this.dataGridViewTextBoxColumn_21.Name = Class16.smethod_0(1649109399);
		this.dataGridViewTextBoxColumn_21.ReadOnly = true;
		this.dataGridViewTextBoxColumn_21.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
		this.dataGridViewTextBoxColumn_21.Width = 35;
		dataGridViewCellStyle24.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		dataGridViewCellStyle24.ForeColor = System.Drawing.Color.FromArgb(77, 255, 143);
		this.dataGridViewTextBoxColumn_22.DefaultCellStyle = dataGridViewCellStyle24;
		this.dataGridViewTextBoxColumn_22.FillWeight = 44.7233f;
		this.dataGridViewTextBoxColumn_22.HeaderText = Class16.smethod_0(1649118934);
		this.dataGridViewTextBoxColumn_22.Name = Class16.smethod_0(1649109425);
		this.dataGridViewTextBoxColumn_22.ReadOnly = true;
		this.dataGridViewTextBoxColumn_22.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
		this.dataGridViewTextBoxColumn_22.Width = 45;
		dataGridViewCellStyle25.ForeColor = System.Drawing.Color.LightGray;
		this.dataGridViewTextBoxColumn_23.DefaultCellStyle = dataGridViewCellStyle25;
		this.dataGridViewTextBoxColumn_23.HeaderText = Class16.smethod_0(1648936731);
		this.dataGridViewTextBoxColumn_23.Name = Class16.smethod_0(1649109459);
		this.dataGridViewTextBoxColumn_23.ReadOnly = true;
		this.dataGridViewTextBoxColumn_23.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
		this.dataGridViewTextBoxColumn_23.Width = 120;
		this.button_12.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.button_12.ForeColor = System.Drawing.Color.Black;
		this.button_12.Image = ACE.Properties.Resources.NpcGenEditorForm_GotoDynamicsContacts;
		this.button_12.Location = new System.Drawing.Point(1, 211);
		this.button_12.Name = Class16.smethod_0(1649109501);
		this.button_12.Size = new System.Drawing.Size(196, 57);
		this.button_12.TabIndex = 27;
		this.button_12.Text = Class16.smethod_0(1649104400);
		this.button_12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.button_12.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		this.button_12.UseVisualStyleBackColor = true;
		this.button_12.Click += new System.EventHandler(button_12_Click);
		this.groupBox_5.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.groupBox_5.BackColor = System.Drawing.Color.FromArgb(239, 244, 250);
		this.groupBox_5.Controls.Add(this.dataGridView_8);
		this.groupBox_5.Controls.Add(this.button_14);
		this.groupBox_5.Location = new System.Drawing.Point(565, 214);
		this.groupBox_5.Name = Class16.smethod_0(1649104429);
		this.groupBox_5.Size = new System.Drawing.Size(198, 267);
		this.groupBox_5.TabIndex = 30;
		this.groupBox_5.TabStop = false;
		this.groupBox_5.Text = Class16.smethod_0(1649109359);
		this.dataGridView_8.AllowUserToAddRows = false;
		this.dataGridView_8.AllowUserToDeleteRows = false;
		this.dataGridView_8.AllowUserToResizeColumns = false;
		this.dataGridView_8.AllowUserToResizeRows = false;
		this.dataGridView_8.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.dataGridView_8.BackgroundColor = System.Drawing.Color.FromArgb(15, 15, 15);
		this.dataGridView_8.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
		this.dataGridView_8.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
		this.dataGridView_8.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridView_8.Columns.AddRange(this.dataGridViewTextBoxColumn_18, this.dataGridViewTextBoxColumn_19, this.dataGridViewTextBoxColumn_20);
		dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle26.BackColor = System.Drawing.Color.FromArgb(15, 15, 15);
		dataGridViewCellStyle26.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 8.25f);
		dataGridViewCellStyle26.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
		dataGridViewCellStyle26.SelectionBackColor = System.Drawing.SystemColors.Highlight;
		dataGridViewCellStyle26.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		dataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
		this.dataGridView_8.DefaultCellStyle = dataGridViewCellStyle26;
		this.dataGridView_8.EnableHeadersVisualStyles = false;
		this.dataGridView_8.Location = new System.Drawing.Point(2, 15);
		this.dataGridView_8.Name = Class16.smethod_0(1649104446);
		this.dataGridView_8.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
		this.dataGridView_8.RowHeadersVisible = false;
		this.dataGridView_8.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		this.dataGridView_8.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		this.dataGridView_8.ShowCellErrors = false;
		this.dataGridView_8.ShowCellToolTips = false;
		this.dataGridView_8.ShowEditingIcon = false;
		this.dataGridView_8.ShowRowErrors = false;
		this.dataGridView_8.Size = new System.Drawing.Size(194, 197);
		this.dataGridView_8.TabIndex = 25;
		this.dataGridView_8.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(dataGridView_8_CellDoubleClick);
		this.dataGridView_8.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(dataGridView_8_CellMouseEnter);
		this.dataGridView_8.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(dataGridView_8_CellMouseLeave);
		this.dataGridView_8.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(dataGridView_8_CellMouseMove);
		dataGridViewCellStyle27.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.dataGridViewTextBoxColumn_18.DefaultCellStyle = dataGridViewCellStyle27;
		this.dataGridViewTextBoxColumn_18.FillWeight = 6.912442f;
		this.dataGridViewTextBoxColumn_18.HeaderText = Class16.smethod_0(1648929947);
		this.dataGridViewTextBoxColumn_18.Name = Class16.smethod_0(1649104462);
		this.dataGridViewTextBoxColumn_18.ReadOnly = true;
		this.dataGridViewTextBoxColumn_18.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
		this.dataGridViewTextBoxColumn_18.Width = 35;
		dataGridViewCellStyle28.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		dataGridViewCellStyle28.ForeColor = System.Drawing.Color.FromArgb(77, 255, 143);
		this.dataGridViewTextBoxColumn_19.DefaultCellStyle = dataGridViewCellStyle28;
		this.dataGridViewTextBoxColumn_19.FillWeight = 44.7233f;
		this.dataGridViewTextBoxColumn_19.HeaderText = Class16.smethod_0(1649118934);
		this.dataGridViewTextBoxColumn_19.Name = Class16.smethod_0(1649104488);
		this.dataGridViewTextBoxColumn_19.ReadOnly = true;
		this.dataGridViewTextBoxColumn_19.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
		this.dataGridViewTextBoxColumn_19.Width = 45;
		dataGridViewCellStyle29.ForeColor = System.Drawing.Color.LightGray;
		this.dataGridViewTextBoxColumn_20.DefaultCellStyle = dataGridViewCellStyle29;
		this.dataGridViewTextBoxColumn_20.HeaderText = Class16.smethod_0(1648936731);
		this.dataGridViewTextBoxColumn_20.Name = Class16.smethod_0(1649104522);
		this.dataGridViewTextBoxColumn_20.ReadOnly = true;
		this.dataGridViewTextBoxColumn_20.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
		this.dataGridViewTextBoxColumn_20.Width = 120;
		this.button_14.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.button_14.ForeColor = System.Drawing.Color.Black;
		this.button_14.Image = ACE.Properties.Resources.NpcGenEditorForm_GotoResourcesContacts;
		this.button_14.Location = new System.Drawing.Point(1, 211);
		this.button_14.Name = Class16.smethod_0(1649104564);
		this.button_14.Size = new System.Drawing.Size(196, 57);
		this.button_14.TabIndex = 27;
		this.button_14.Text = Class16.smethod_0(1649104400);
		this.button_14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.button_14.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		this.button_14.UseVisualStyleBackColor = true;
		this.button_14.Click += new System.EventHandler(button_14_Click);
		this.groupBox_4.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.groupBox_4.BackColor = System.Drawing.Color.FromArgb(239, 244, 250);
		this.groupBox_4.Controls.Add(this.dataGridView_3);
		this.groupBox_4.Controls.Add(this.button_13);
		this.groupBox_4.Location = new System.Drawing.Point(364, 214);
		this.groupBox_4.Name = Class16.smethod_0(1649104584);
		this.groupBox_4.Size = new System.Drawing.Size(198, 267);
		this.groupBox_4.TabIndex = 29;
		this.groupBox_4.TabStop = false;
		this.groupBox_4.Text = Class16.smethod_0(1649104601);
		this.dataGridView_3.AllowUserToAddRows = false;
		this.dataGridView_3.AllowUserToDeleteRows = false;
		this.dataGridView_3.AllowUserToResizeColumns = false;
		this.dataGridView_3.AllowUserToResizeRows = false;
		this.dataGridView_3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.dataGridView_3.BackgroundColor = System.Drawing.Color.FromArgb(15, 15, 15);
		this.dataGridView_3.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
		this.dataGridView_3.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
		this.dataGridView_3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridView_3.Columns.AddRange(this.dataGridViewTextBoxColumn_24, this.dataGridViewTextBoxColumn_25, this.dataGridViewTextBoxColumn_27);
		dataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle30.BackColor = System.Drawing.Color.FromArgb(15, 15, 15);
		dataGridViewCellStyle30.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 8.25f);
		dataGridViewCellStyle30.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
		dataGridViewCellStyle30.SelectionBackColor = System.Drawing.SystemColors.Highlight;
		dataGridViewCellStyle30.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		dataGridViewCellStyle30.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
		this.dataGridView_3.DefaultCellStyle = dataGridViewCellStyle30;
		this.dataGridView_3.EnableHeadersVisualStyles = false;
		this.dataGridView_3.Location = new System.Drawing.Point(2, 15);
		this.dataGridView_3.Name = Class16.smethod_0(1649104625);
		this.dataGridView_3.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
		this.dataGridView_3.RowHeadersVisible = false;
		this.dataGridView_3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		this.dataGridView_3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		this.dataGridView_3.ShowCellErrors = false;
		this.dataGridView_3.ShowCellToolTips = false;
		this.dataGridView_3.ShowEditingIcon = false;
		this.dataGridView_3.ShowRowErrors = false;
		this.dataGridView_3.Size = new System.Drawing.Size(194, 197);
		this.dataGridView_3.TabIndex = 25;
		this.dataGridView_3.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(dataGridView_3_CellDoubleClick);
		this.dataGridView_3.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(dataGridView_3_CellMouseEnter);
		this.dataGridView_3.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(dataGridView_3_CellMouseLeave);
		this.dataGridView_3.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(dataGridView_3_CellMouseMove);
		dataGridViewCellStyle31.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.dataGridViewTextBoxColumn_24.DefaultCellStyle = dataGridViewCellStyle31;
		this.dataGridViewTextBoxColumn_24.FillWeight = 6.912442f;
		this.dataGridViewTextBoxColumn_24.HeaderText = Class16.smethod_0(1648929947);
		this.dataGridViewTextBoxColumn_24.Name = Class16.smethod_0(1649104641);
		this.dataGridViewTextBoxColumn_24.ReadOnly = true;
		this.dataGridViewTextBoxColumn_24.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
		this.dataGridViewTextBoxColumn_24.Width = 35;
		dataGridViewCellStyle32.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		dataGridViewCellStyle32.ForeColor = System.Drawing.Color.FromArgb(77, 255, 143);
		this.dataGridViewTextBoxColumn_25.DefaultCellStyle = dataGridViewCellStyle32;
		this.dataGridViewTextBoxColumn_25.FillWeight = 44.7233f;
		this.dataGridViewTextBoxColumn_25.HeaderText = Class16.smethod_0(1649118934);
		this.dataGridViewTextBoxColumn_25.Name = Class16.smethod_0(1649104675);
		this.dataGridViewTextBoxColumn_25.ReadOnly = true;
		this.dataGridViewTextBoxColumn_25.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
		this.dataGridViewTextBoxColumn_25.Width = 45;
		dataGridViewCellStyle33.ForeColor = System.Drawing.Color.LightGray;
		this.dataGridViewTextBoxColumn_27.DefaultCellStyle = dataGridViewCellStyle33;
		this.dataGridViewTextBoxColumn_27.HeaderText = Class16.smethod_0(1648936731);
		this.dataGridViewTextBoxColumn_27.Name = Class16.smethod_0(1649104717);
		this.dataGridViewTextBoxColumn_27.ReadOnly = true;
		this.dataGridViewTextBoxColumn_27.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
		this.dataGridViewTextBoxColumn_27.Width = 120;
		this.button_13.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.button_13.ForeColor = System.Drawing.Color.Black;
		this.button_13.Image = ACE.Properties.Resources.NpcGenEditorForm_GotoNpcMobsContacts;
		this.button_13.Location = new System.Drawing.Point(1, 211);
		this.button_13.Name = Class16.smethod_0(1649104751);
		this.button_13.Size = new System.Drawing.Size(196, 57);
		this.button_13.TabIndex = 27;
		this.button_13.Text = Class16.smethod_0(1649104400);
		this.button_13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.button_13.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		this.button_13.UseVisualStyleBackColor = true;
		this.button_13.Click += new System.EventHandler(button_13_Click);
		this.groupBox_3.BackColor = System.Drawing.Color.FromArgb(239, 244, 250);
		this.groupBox_3.Controls.Add(this.groupBox_8);
		this.groupBox_3.Controls.Add(this.groupBox_7);
		this.groupBox_3.Controls.Add(this.checkBox_11);
		this.groupBox_3.Controls.Add(this.checkBox_12);
		this.groupBox_3.Controls.Add(this.textBox_38);
		this.groupBox_3.Controls.Add(this.label_92);
		this.groupBox_3.Controls.Add(this.textBox_57);
		this.groupBox_3.Controls.Add(this.label_91);
		this.groupBox_3.Controls.Add(this.textBox_56);
		this.groupBox_3.Controls.Add(this.checkBox_10);
		this.groupBox_3.Controls.Add(this.textBox_40);
		this.groupBox_3.Controls.Add(this.label_84);
		this.groupBox_3.Controls.Add(this.label_96);
		this.groupBox_3.Controls.Add(this.textBox_41);
		this.groupBox_3.Controls.Add(this.textBox_39);
		this.groupBox_3.Controls.Add(this.label_85);
		this.groupBox_3.Controls.Add(this.label_90);
		this.groupBox_3.Controls.Add(this.label_107);
		this.groupBox_3.Location = new System.Drawing.Point(364, 1);
		this.groupBox_3.Name = Class16.smethod_0(1649104769);
		this.groupBox_3.Size = new System.Drawing.Size(599, 209);
		this.groupBox_3.TabIndex = 22;
		this.groupBox_3.TabStop = false;
		this.groupBox_3.Text = Class16.smethod_0(1649002051);
		this.groupBox_8.BackColor = System.Drawing.Color.FromArgb(239, 244, 250);
		this.groupBox_8.Controls.Add(this.textBox_53);
		this.groupBox_8.Controls.Add(this.label_101);
		this.groupBox_8.Controls.Add(this.textBox_52);
		this.groupBox_8.Controls.Add(this.label_102);
		this.groupBox_8.Controls.Add(this.textBox_51);
		this.groupBox_8.Controls.Add(this.label_103);
		this.groupBox_8.Controls.Add(this.comboBox_15);
		this.groupBox_8.Controls.Add(this.textBox_54);
		this.groupBox_8.Controls.Add(this.label_104);
		this.groupBox_8.Controls.Add(this.textBox_55);
		this.groupBox_8.Controls.Add(this.label_105);
		this.groupBox_8.Controls.Add(this.label_106);
		this.groupBox_8.Location = new System.Drawing.Point(326, 105);
		this.groupBox_8.Name = Class16.smethod_0(1649104786);
		this.groupBox_8.Size = new System.Drawing.Size(273, 94);
		this.groupBox_8.TabIndex = 94;
		this.groupBox_8.TabStop = false;
		this.groupBox_8.Text = Class16.smethod_0(1649104803);
		this.textBox_53.Location = new System.Drawing.Point(207, 64);
		this.textBox_53.Name = Class16.smethod_0(1649104819);
		this.textBox_53.Size = new System.Drawing.Size(63, 20);
		this.textBox_53.TabIndex = 93;
		this.textBox_53.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox_39_KeyDown);
		this.textBox_53.Leave += new System.EventHandler(textBox_39_Leave);
		this.label_101.AutoSize = true;
		this.label_101.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_101.Location = new System.Drawing.Point(156, 66);
		this.label_101.Name = Class16.smethod_0(1649104845);
		this.label_101.Size = new System.Drawing.Size(48, 15);
		this.label_101.TabIndex = 92;
		this.label_101.Text = Class16.smethod_0(1649016123);
		this.textBox_52.Location = new System.Drawing.Point(207, 40);
		this.textBox_52.Name = Class16.smethod_0(1649104851);
		this.textBox_52.Size = new System.Drawing.Size(63, 20);
		this.textBox_52.TabIndex = 91;
		this.textBox_52.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox_39_KeyDown);
		this.textBox_52.Leave += new System.EventHandler(textBox_39_Leave);
		this.label_102.AutoSize = true;
		this.label_102.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_102.Location = new System.Drawing.Point(156, 42);
		this.label_102.Name = Class16.smethod_0(1649104867);
		this.label_102.Size = new System.Drawing.Size(37, 15);
		this.label_102.TabIndex = 90;
		this.label_102.Text = Class16.smethod_0(1649016153);
		this.textBox_51.Location = new System.Drawing.Point(207, 14);
		this.textBox_51.Name = Class16.smethod_0(1649104881);
		this.textBox_51.Size = new System.Drawing.Size(63, 20);
		this.textBox_51.TabIndex = 89;
		this.textBox_51.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox_39_KeyDown);
		this.textBox_51.Leave += new System.EventHandler(textBox_39_Leave);
		this.label_103.AutoSize = true;
		this.label_103.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_103.Location = new System.Drawing.Point(156, 16);
		this.label_103.Name = Class16.smethod_0(1649103872);
		this.label_103.Size = new System.Drawing.Size(31, 15);
		this.label_103.TabIndex = 88;
		this.label_103.Text = Class16.smethod_0(1649016188);
		this.comboBox_15.BackColor = System.Drawing.Color.Silver;
		this.comboBox_15.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.comboBox_15.FormattingEnabled = true;
		this.comboBox_15.Items.AddRange(new object[8]
		{
			Class16.smethod_0(1648973883),
			Class16.smethod_0(1649011996),
			Class16.smethod_0(1649012001),
			Class16.smethod_0(1649012022),
			Class16.smethod_0(1649012036),
			Class16.smethod_0(1649012052),
			Class16.smethod_0(1649012059),
			Class16.smethod_0(1649012072)
		});
		this.comboBox_15.Location = new System.Drawing.Point(84, 64);
		this.comboBox_15.Name = Class16.smethod_0(1649103894);
		this.comboBox_15.Size = new System.Drawing.Size(63, 21);
		this.comboBox_15.TabIndex = 87;
		this.comboBox_15.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox_39_KeyDown);
		this.comboBox_15.Leave += new System.EventHandler(textBox_39_Leave);
		this.textBox_54.Location = new System.Drawing.Point(84, 40);
		this.textBox_54.Name = Class16.smethod_0(1649103905);
		this.textBox_54.Size = new System.Drawing.Size(63, 20);
		this.textBox_54.TabIndex = 86;
		this.textBox_54.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox_39_KeyDown);
		this.textBox_54.Leave += new System.EventHandler(textBox_39_Leave);
		this.label_104.AutoSize = true;
		this.label_104.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_104.Location = new System.Drawing.Point(39, 43);
		this.label_104.Name = Class16.smethod_0(1649103922);
		this.label_104.Size = new System.Drawing.Size(45, 15);
		this.label_104.TabIndex = 84;
		this.label_104.Text = Class16.smethod_0(1649103936);
		this.textBox_55.Location = new System.Drawing.Point(84, 15);
		this.textBox_55.Name = Class16.smethod_0(1649103957);
		this.textBox_55.Size = new System.Drawing.Size(63, 20);
		this.textBox_55.TabIndex = 83;
		this.textBox_55.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox_39_KeyDown);
		this.textBox_55.Leave += new System.EventHandler(textBox_39_Leave);
		this.label_105.AutoSize = true;
		this.label_105.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_105.Location = new System.Drawing.Point(49, 19);
		this.label_105.Name = Class16.smethod_0(1649103973);
		this.label_105.Size = new System.Drawing.Size(35, 15);
		this.label_105.TabIndex = 82;
		this.label_105.Text = Class16.smethod_0(1649103979);
		this.label_106.AutoSize = true;
		this.label_106.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_106.Location = new System.Drawing.Point(-12, 68);
		this.label_106.Name = Class16.smethod_0(1649103999);
		this.label_106.Size = new System.Drawing.Size(96, 15);
		this.label_106.TabIndex = 85;
		this.label_106.Text = Class16.smethod_0(1649104013);
		this.groupBox_7.BackColor = System.Drawing.Color.FromArgb(239, 244, 250);
		this.groupBox_7.Controls.Add(this.textBox_48);
		this.groupBox_7.Controls.Add(this.label_100);
		this.groupBox_7.Controls.Add(this.textBox_47);
		this.groupBox_7.Controls.Add(this.label_99);
		this.groupBox_7.Controls.Add(this.textBox_46);
		this.groupBox_7.Controls.Add(this.label_98);
		this.groupBox_7.Controls.Add(this.comboBox_14);
		this.groupBox_7.Controls.Add(this.textBox_49);
		this.groupBox_7.Controls.Add(this.label_94);
		this.groupBox_7.Controls.Add(this.textBox_50);
		this.groupBox_7.Controls.Add(this.label_93);
		this.groupBox_7.Controls.Add(this.label_95);
		this.groupBox_7.Location = new System.Drawing.Point(323, 5);
		this.groupBox_7.Name = Class16.smethod_0(1649104036);
		this.groupBox_7.Size = new System.Drawing.Size(273, 94);
		this.groupBox_7.TabIndex = 80;
		this.groupBox_7.TabStop = false;
		this.groupBox_7.Text = Class16.smethod_0(1649104053);
		this.textBox_48.Location = new System.Drawing.Point(207, 64);
		this.textBox_48.Name = Class16.smethod_0(1649104057);
		this.textBox_48.Size = new System.Drawing.Size(63, 20);
		this.textBox_48.TabIndex = 93;
		this.textBox_48.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox_39_KeyDown);
		this.textBox_48.Leave += new System.EventHandler(textBox_39_Leave);
		this.label_100.AutoSize = true;
		this.label_100.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_100.Location = new System.Drawing.Point(156, 65);
		this.label_100.Name = Class16.smethod_0(1649104084);
		this.label_100.Size = new System.Drawing.Size(48, 15);
		this.label_100.TabIndex = 92;
		this.label_100.Text = Class16.smethod_0(1649016123);
		this.textBox_47.Location = new System.Drawing.Point(207, 40);
		this.textBox_47.Name = Class16.smethod_0(1649104090);
		this.textBox_47.Size = new System.Drawing.Size(63, 20);
		this.textBox_47.TabIndex = 91;
		this.textBox_47.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox_39_KeyDown);
		this.textBox_47.Leave += new System.EventHandler(textBox_39_Leave);
		this.label_99.AutoSize = true;
		this.label_99.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_99.Location = new System.Drawing.Point(156, 41);
		this.label_99.Name = Class16.smethod_0(1649104107);
		this.label_99.Size = new System.Drawing.Size(37, 15);
		this.label_99.TabIndex = 90;
		this.label_99.Text = Class16.smethod_0(1649016153);
		this.textBox_46.Location = new System.Drawing.Point(207, 14);
		this.textBox_46.Name = Class16.smethod_0(1649104121);
		this.textBox_46.Size = new System.Drawing.Size(63, 20);
		this.textBox_46.TabIndex = 89;
		this.textBox_46.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox_39_KeyDown);
		this.textBox_46.Leave += new System.EventHandler(textBox_39_Leave);
		this.label_98.AutoSize = true;
		this.label_98.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_98.Location = new System.Drawing.Point(156, 15);
		this.label_98.Name = Class16.smethod_0(1649104137);
		this.label_98.Size = new System.Drawing.Size(31, 15);
		this.label_98.TabIndex = 88;
		this.label_98.Text = Class16.smethod_0(1649016188);
		this.comboBox_14.BackColor = System.Drawing.Color.Silver;
		this.comboBox_14.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.comboBox_14.FormattingEnabled = true;
		this.comboBox_14.Items.AddRange(new object[8]
		{
			Class16.smethod_0(1648973883),
			Class16.smethod_0(1649011996),
			Class16.smethod_0(1649012001),
			Class16.smethod_0(1649012022),
			Class16.smethod_0(1649012036),
			Class16.smethod_0(1649012052),
			Class16.smethod_0(1649012059),
			Class16.smethod_0(1649012072)
		});
		this.comboBox_14.Location = new System.Drawing.Point(84, 64);
		this.comboBox_14.Name = Class16.smethod_0(1649104159);
		this.comboBox_14.Size = new System.Drawing.Size(63, 21);
		this.comboBox_14.TabIndex = 87;
		this.comboBox_14.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox_39_KeyDown);
		this.comboBox_14.Leave += new System.EventHandler(textBox_39_Leave);
		this.textBox_49.Location = new System.Drawing.Point(84, 40);
		this.textBox_49.Name = Class16.smethod_0(1649104171);
		this.textBox_49.Size = new System.Drawing.Size(63, 20);
		this.textBox_49.TabIndex = 86;
		this.textBox_49.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox_39_KeyDown);
		this.textBox_49.Leave += new System.EventHandler(textBox_39_Leave);
		this.label_94.AutoSize = true;
		this.label_94.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_94.Location = new System.Drawing.Point(39, 39);
		this.label_94.Name = Class16.smethod_0(1649104197);
		this.label_94.Size = new System.Drawing.Size(45, 15);
		this.label_94.TabIndex = 84;
		this.label_94.Text = Class16.smethod_0(1649103936);
		this.textBox_50.Location = new System.Drawing.Point(84, 15);
		this.textBox_50.Name = Class16.smethod_0(1649104203);
		this.textBox_50.Size = new System.Drawing.Size(63, 20);
		this.textBox_50.TabIndex = 83;
		this.textBox_50.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox_39_KeyDown);
		this.textBox_50.Leave += new System.EventHandler(textBox_39_Leave);
		this.label_93.AutoSize = true;
		this.label_93.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_93.Location = new System.Drawing.Point(49, 15);
		this.label_93.Name = Class16.smethod_0(1649104228);
		this.label_93.Size = new System.Drawing.Size(35, 15);
		this.label_93.TabIndex = 82;
		this.label_93.Text = Class16.smethod_0(1649103979);
		this.label_95.AutoSize = true;
		this.label_95.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_95.Location = new System.Drawing.Point(-12, 64);
		this.label_95.Name = Class16.smethod_0(1649104234);
		this.label_95.Size = new System.Drawing.Size(96, 15);
		this.label_95.TabIndex = 85;
		this.label_95.Text = Class16.smethod_0(1649104013);
		this.checkBox_11.AutoSize = true;
		this.checkBox_11.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.checkBox_11.Location = new System.Drawing.Point(172, 170);
		this.checkBox_11.Name = Class16.smethod_0(1649104248);
		this.checkBox_11.Size = new System.Drawing.Size(109, 17);
		this.checkBox_11.TabIndex = 79;
		this.checkBox_11.Text = Class16.smethod_0(1649104279);
		this.checkBox_11.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
		this.checkBox_11.UseVisualStyleBackColor = true;
		this.checkBox_11.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox_39_KeyDown);
		this.checkBox_11.Leave += new System.EventHandler(textBox_39_Leave);
		this.checkBox_12.AutoSize = true;
		this.checkBox_12.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.checkBox_12.Location = new System.Drawing.Point(172, 190);
		this.checkBox_12.Name = Class16.smethod_0(1649104303);
		this.checkBox_12.Size = new System.Drawing.Size(109, 17);
		this.checkBox_12.TabIndex = 78;
		this.checkBox_12.Text = Class16.smethod_0(1649104325);
		this.checkBox_12.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
		this.checkBox_12.UseVisualStyleBackColor = true;
		this.checkBox_12.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox_39_KeyDown);
		this.checkBox_12.Leave += new System.EventHandler(textBox_39_Leave);
		this.textBox_38.Location = new System.Drawing.Point(147, 147);
		this.textBox_38.Name = Class16.smethod_0(1649104348);
		this.textBox_38.Size = new System.Drawing.Size(170, 20);
		this.textBox_38.TabIndex = 76;
		this.textBox_38.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox_39_KeyDown);
		this.textBox_38.Leave += new System.EventHandler(textBox_39_Leave);
		this.label_92.AutoSize = true;
		this.label_92.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_92.Location = new System.Drawing.Point(82, 148);
		this.label_92.Name = Class16.smethod_0(1649104364);
		this.label_92.Size = new System.Drawing.Size(60, 15);
		this.label_92.TabIndex = 77;
		this.label_92.Text = Class16.smethod_0(1649104370);
		this.textBox_57.Location = new System.Drawing.Point(147, 105);
		this.textBox_57.Name = Class16.smethod_0(1649103363);
		this.textBox_57.Size = new System.Drawing.Size(170, 20);
		this.textBox_57.TabIndex = 74;
		this.textBox_57.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox_39_KeyDown);
		this.textBox_57.Leave += new System.EventHandler(textBox_39_Leave);
		this.label_91.AutoSize = true;
		this.label_91.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_91.Location = new System.Drawing.Point(43, 107);
		this.label_91.Name = Class16.smethod_0(1649103387);
		this.label_91.Size = new System.Drawing.Size(99, 15);
		this.label_91.TabIndex = 75;
		this.label_91.Text = Class16.smethod_0(1649103401);
		this.textBox_56.Location = new System.Drawing.Point(147, 83);
		this.textBox_56.Name = Class16.smethod_0(1649103431);
		this.textBox_56.Size = new System.Drawing.Size(170, 20);
		this.textBox_56.TabIndex = 72;
		this.textBox_56.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox_39_KeyDown);
		this.textBox_56.Leave += new System.EventHandler(textBox_39_Leave);
		this.checkBox_10.AutoSize = true;
		this.checkBox_10.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.checkBox_10.Location = new System.Drawing.Point(168, 128);
		this.checkBox_10.Name = Class16.smethod_0(1649103448);
		this.checkBox_10.Size = new System.Drawing.Size(113, 17);
		this.checkBox_10.TabIndex = 71;
		this.checkBox_10.Text = Class16.smethod_0(1649103465);
		this.checkBox_10.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
		this.checkBox_10.UseVisualStyleBackColor = true;
		this.checkBox_10.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox_39_KeyDown);
		this.checkBox_10.Leave += new System.EventHandler(textBox_39_Leave);
		this.textBox_40.Location = new System.Drawing.Point(147, 14);
		this.textBox_40.Name = Class16.smethod_0(1649103491);
		this.textBox_40.Size = new System.Drawing.Size(170, 20);
		this.textBox_40.TabIndex = 69;
		this.textBox_40.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox_39_KeyDown);
		this.textBox_40.Leave += new System.EventHandler(textBox_39_Leave);
		this.label_84.AutoSize = true;
		this.label_84.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_84.ForeColor = System.Drawing.Color.Red;
		this.label_84.Location = new System.Drawing.Point(157, 15);
		this.label_84.Name = Class16.smethod_0(1649103517);
		this.label_84.Size = new System.Drawing.Size(0, 16);
		this.label_84.TabIndex = 68;
		this.label_96.AutoSize = true;
		this.label_96.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_96.Location = new System.Drawing.Point(78, 17);
		this.label_96.Name = Class16.smethod_0(1649103523);
		this.label_96.Size = new System.Drawing.Size(64, 15);
		this.label_96.TabIndex = 39;
		this.label_96.Text = Class16.smethod_0(1649108039);
		this.textBox_41.Location = new System.Drawing.Point(147, 60);
		this.textBox_41.Name = Class16.smethod_0(1649103537);
		this.textBox_41.Size = new System.Drawing.Size(170, 20);
		this.textBox_41.TabIndex = 9;
		this.textBox_41.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox_39_KeyDown);
		this.textBox_41.Leave += new System.EventHandler(textBox_39_Leave);
		this.textBox_39.Location = new System.Drawing.Point(147, 37);
		this.textBox_39.Name = Class16.smethod_0(1649103565);
		this.textBox_39.Size = new System.Drawing.Size(170, 20);
		this.textBox_39.TabIndex = 7;
		this.textBox_39.KeyDown += new System.Windows.Forms.KeyEventHandler(textBox_39_KeyDown);
		this.textBox_39.Leave += new System.EventHandler(textBox_39_Leave);
		this.label_85.AutoSize = true;
		this.label_85.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_85.Location = new System.Drawing.Point(30, 39);
		this.label_85.Name = Class16.smethod_0(1649103577);
		this.label_85.Size = new System.Drawing.Size(112, 15);
		this.label_85.TabIndex = 70;
		this.label_85.Text = Class16.smethod_0(1649103599);
		this.label_90.AutoSize = true;
		this.label_90.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_90.Location = new System.Drawing.Point(73, 85);
		this.label_90.Name = Class16.smethod_0(1649103617);
		this.label_90.Size = new System.Drawing.Size(69, 15);
		this.label_90.TabIndex = 73;
		this.label_90.Text = Class16.smethod_0(1649103639);
		this.label_107.AutoSize = true;
		this.label_107.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_107.Location = new System.Drawing.Point(109, 62);
		this.label_107.Name = Class16.smethod_0(1649103650);
		this.label_107.Size = new System.Drawing.Size(33, 15);
		this.label_107.TabIndex = 95;
		this.label_107.Text = Class16.smethod_0(1649103664);
		this.dataGridView_10.AllowUserToAddRows = false;
		this.dataGridView_10.AllowUserToDeleteRows = false;
		this.dataGridView_10.AllowUserToResizeColumns = false;
		this.dataGridView_10.AllowUserToResizeRows = false;
		this.dataGridView_10.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.dataGridView_10.BackgroundColor = System.Drawing.Color.FromArgb(15, 15, 15);
		this.dataGridView_10.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
		this.dataGridView_10.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
		dataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle34.BackColor = System.Drawing.SystemColors.Control;
		dataGridViewCellStyle34.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 8.25f);
		dataGridViewCellStyle34.ForeColor = System.Drawing.SystemColors.WindowText;
		dataGridViewCellStyle34.SelectionBackColor = System.Drawing.SystemColors.Highlight;
		dataGridViewCellStyle34.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		dataGridViewCellStyle34.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
		this.dataGridView_10.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle34;
		this.dataGridView_10.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridView_10.Columns.AddRange(this.dataGridViewTextBoxColumn_10, this.dataGridViewTextBoxColumn_11, this.dataGridViewTextBoxColumn_17, this.dataGridViewTextBoxColumn_12);
		this.dataGridView_10.ContextMenuStrip = this.contextMenuStrip_3;
		dataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle35.BackColor = System.Drawing.Color.FromArgb(15, 15, 15);
		dataGridViewCellStyle35.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 8.25f);
		dataGridViewCellStyle35.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
		dataGridViewCellStyle35.SelectionBackColor = System.Drawing.SystemColors.Highlight;
		dataGridViewCellStyle35.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		dataGridViewCellStyle35.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
		this.dataGridView_10.DefaultCellStyle = dataGridViewCellStyle35;
		this.dataGridView_10.EnableHeadersVisualStyles = false;
		this.dataGridView_10.Location = new System.Drawing.Point(1, 29);
		this.dataGridView_10.Name = Class16.smethod_0(1649103685);
		this.dataGridView_10.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
		this.dataGridView_10.RowHeadersVisible = false;
		this.dataGridView_10.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		this.dataGridView_10.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		this.dataGridView_10.ShowCellErrors = false;
		this.dataGridView_10.ShowCellToolTips = false;
		this.dataGridView_10.ShowEditingIcon = false;
		this.dataGridView_10.ShowRowErrors = false;
		this.dataGridView_10.Size = new System.Drawing.Size(359, 425);
		this.dataGridView_10.TabIndex = 18;
		this.dataGridView_10.CurrentCellChanged += new System.EventHandler(dataGridView_10_CurrentCellChanged);
		this.dataGridView_10.KeyDown += new System.Windows.Forms.KeyEventHandler(dataGridView_10_KeyDown);
		dataGridViewCellStyle36.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.dataGridViewTextBoxColumn_10.DefaultCellStyle = dataGridViewCellStyle36;
		this.dataGridViewTextBoxColumn_10.FillWeight = 6.912442f;
		this.dataGridViewTextBoxColumn_10.HeaderText = Class16.smethod_0(1648929947);
		this.dataGridViewTextBoxColumn_10.Name = Class16.smethod_0(1649029491);
		this.dataGridViewTextBoxColumn_10.ReadOnly = true;
		this.dataGridViewTextBoxColumn_10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
		this.dataGridViewTextBoxColumn_10.Width = 45;
		dataGridViewCellStyle37.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		dataGridViewCellStyle37.ForeColor = System.Drawing.Color.FromArgb(77, 255, 143);
		this.dataGridViewTextBoxColumn_11.DefaultCellStyle = dataGridViewCellStyle37;
		this.dataGridViewTextBoxColumn_11.FillWeight = 44.7233f;
		this.dataGridViewTextBoxColumn_11.HeaderText = Class16.smethod_0(1649118934);
		this.dataGridViewTextBoxColumn_11.Name = Class16.smethod_0(1649029533);
		this.dataGridViewTextBoxColumn_11.ReadOnly = true;
		this.dataGridViewTextBoxColumn_11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
		this.dataGridViewTextBoxColumn_11.Width = 55;
		this.dataGridViewTextBoxColumn_17.HeaderText = Class16.smethod_0(1649103696);
		this.dataGridViewTextBoxColumn_17.Name = Class16.smethod_0(1649103707);
		this.dataGridViewTextBoxColumn_17.Width = 55;
		dataGridViewCellStyle38.ForeColor = System.Drawing.Color.LightPink;
		this.dataGridViewTextBoxColumn_12.DefaultCellStyle = dataGridViewCellStyle38;
		this.dataGridViewTextBoxColumn_12.HeaderText = Class16.smethod_0(1648936731);
		this.dataGridViewTextBoxColumn_12.Name = Class16.smethod_0(1649029196);
		this.dataGridViewTextBoxColumn_12.ReadOnly = true;
		this.dataGridViewTextBoxColumn_12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
		this.dataGridViewTextBoxColumn_12.Width = 220;
		this.contextMenuStrip_3.AllowMerge = false;
		this.contextMenuStrip_3.Items.AddRange(new System.Windows.Forms.ToolStripItem[5] { this.toolStripMenuItem_0, this.toolStripMenuItem_22, this.toolStripSeparator_2, this.toolStripMenuItem_19, this.toolStripMenuItem_18 });
		this.contextMenuStrip_3.Name = Class16.smethod_0(1649113432);
		this.contextMenuStrip_3.Size = new System.Drawing.Size(188, 98);
		this.contextMenuStrip_3.Text = Class16.smethod_0(1649073450);
		this.toolStripMenuItem_0.Image = ACE.Properties.Resources.NpcGenEditorForm_DeleteEmptyTrigger;
		this.toolStripMenuItem_0.Name = Class16.smethod_0(1649103749);
		this.toolStripMenuItem_0.Size = new System.Drawing.Size(187, 22);
		this.toolStripMenuItem_0.Text = Class16.smethod_0(1649103774);
		this.toolStripMenuItem_0.Click += new System.EventHandler(toolStripButton_8_Click);
		this.toolStripMenuItem_22.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.toolStripMenuItem_27, this.toolStripMenuItem_2 });
		this.toolStripMenuItem_22.Image = ACE.Properties.Resources.NpcGenEditorForm_Move;
		this.toolStripMenuItem_22.Name = Class16.smethod_0(1649003364);
		this.toolStripMenuItem_22.Size = new System.Drawing.Size(187, 22);
		this.toolStripMenuItem_22.Text = Class16.smethod_0(1649113514);
		this.toolStripMenuItem_27.Image = ACE.Properties.Resources.NpcGenEditorForm_UpTrigger;
		this.toolStripMenuItem_27.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.toolStripMenuItem_27.Name = Class16.smethod_0(1649103794);
		this.toolStripMenuItem_27.Size = new System.Drawing.Size(105, 22);
		this.toolStripMenuItem_27.Text = Class16.smethod_0(1649103810);
		this.toolStripMenuItem_27.Click += new System.EventHandler(toolStripMenuItem_20_Click);
		this.toolStripMenuItem_2.Image = ACE.Properties.Resources.NpcGenEditorForm_DownTrigger;
		this.toolStripMenuItem_2.Name = Class16.smethod_0(1649103819);
		this.toolStripMenuItem_2.Size = new System.Drawing.Size(105, 22);
		this.toolStripMenuItem_2.Text = Class16.smethod_0(1649103845);
		this.toolStripMenuItem_2.Click += new System.EventHandler(toolStripMenuItem_21_Click);
		this.toolStripSeparator_2.Name = Class16.smethod_0(1649036149);
		this.toolStripSeparator_2.Size = new System.Drawing.Size(184, 6);
		this.toolStripMenuItem_19.Image = ACE.Properties.Resources.NpcGenEditorForm_ExportExistence;
		this.toolStripMenuItem_19.Name = Class16.smethod_0(1649069485);
		this.toolStripMenuItem_19.Size = new System.Drawing.Size(187, 22);
		this.toolStripMenuItem_19.Text = Class16.smethod_0(1648931384);
		this.toolStripMenuItem_19.Click += new System.EventHandler(toolStripButton_6_Click);
		this.toolStripMenuItem_18.Image = ACE.Properties.Resources.NpcGenEditorForm_ImportExistence;
		this.toolStripMenuItem_18.Name = Class16.smethod_0(1649069387);
		this.toolStripMenuItem_18.Size = new System.Drawing.Size(187, 22);
		this.toolStripMenuItem_18.Text = Class16.smethod_0(1648931405);
		this.toolStripMenuItem_18.Click += new System.EventHandler(toolStripButton_7_Click);
		this.toolStrip_3.AutoSize = false;
		this.toolStrip_3.BackColor = System.Drawing.Color.FromArgb(239, 244, 250);
		this.toolStrip_3.GripMargin = new System.Windows.Forms.Padding(0);
		this.toolStrip_3.Items.AddRange(new System.Windows.Forms.ToolStripItem[4] { this.toolStripButton_6, this.toolStripButton_7, this.toolStripDropDownButton_6, this.toolStripButton_8 });
		this.toolStrip_3.Location = new System.Drawing.Point(3, 3);
		this.toolStrip_3.Name = Class16.smethod_0(1649103848);
		this.toolStrip_3.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
		this.toolStrip_3.Size = new System.Drawing.Size(960, 25);
		this.toolStrip_3.TabIndex = 32;
		this.toolStrip_3.Text = Class16.smethod_0(1649103848);
		this.toolStripButton_6.Image = ACE.Properties.Resources.NpcGenEditorForm_ExportResources;
		this.toolStripButton_6.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
		this.toolStripButton_6.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.toolStripButton_6.Name = Class16.smethod_0(1649103865);
		this.toolStripButton_6.Size = new System.Drawing.Size(62, 22);
		this.toolStripButton_6.Text = Class16.smethod_0(1648931384);
		this.toolStripButton_6.ToolTipText = Class16.smethod_0(1648931384);
		this.toolStripButton_6.Click += new System.EventHandler(toolStripButton_6_Click);
		this.toolStripButton_7.Image = ACE.Properties.Resources.NpcGenEditorForm_ImportResources;
		this.toolStripButton_7.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.toolStripButton_7.Name = Class16.smethod_0(1649102864);
		this.toolStripButton_7.Size = new System.Drawing.Size(63, 22);
		this.toolStripButton_7.Text = Class16.smethod_0(1648931405);
		this.toolStripButton_7.ToolTipText = Class16.smethod_0(1648931405);
		this.toolStripButton_7.Click += new System.EventHandler(toolStripButton_7_Click);
		this.toolStripDropDownButton_6.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.toolStripMenuItem_20, this.toolStripMenuItem_21 });
		this.toolStripDropDownButton_6.Image = ACE.Properties.Resources.NpcGenEditorForm_Move;
		this.toolStripDropDownButton_6.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.toolStripDropDownButton_6.Name = Class16.smethod_0(1649102895);
		this.toolStripDropDownButton_6.Size = new System.Drawing.Size(66, 22);
		this.toolStripDropDownButton_6.Text = Class16.smethod_0(1649113514);
		this.toolStripDropDownButton_6.ToolTipText = Class16.smethod_0(1649113514);
		this.toolStripMenuItem_20.Image = ACE.Properties.Resources.NpcGenEditorForm_ResourceUp;
		this.toolStripMenuItem_20.Name = Class16.smethod_0(1649068750);
		this.toolStripMenuItem_20.Size = new System.Drawing.Size(146, 22);
		this.toolStripMenuItem_20.Text = Class16.smethod_0(1649106946);
		this.toolStripMenuItem_20.Click += new System.EventHandler(toolStripMenuItem_20_Click);
		this.toolStripMenuItem_21.Image = ACE.Properties.Resources.NpcGenEditorForm_ResourceDown;
		this.toolStripMenuItem_21.Name = Class16.smethod_0(1649068148);
		this.toolStripMenuItem_21.Size = new System.Drawing.Size(146, 22);
		this.toolStripMenuItem_21.Text = Class16.smethod_0(1649106995);
		this.toolStripMenuItem_21.Click += new System.EventHandler(toolStripMenuItem_21_Click);
		this.toolStripButton_8.Image = ACE.Properties.Resources.NpcGenEditorForm_Clear;
		this.toolStripButton_8.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.toolStripButton_8.Name = Class16.smethod_0(1649102926);
		this.toolStripButton_8.Size = new System.Drawing.Size(54, 22);
		this.toolStripButton_8.Text = Class16.smethod_0(1648928315);
		this.toolStripButton_8.ToolTipText = Class16.smethod_0(1649102949);
		this.toolStripButton_8.Click += new System.EventHandler(toolStripButton_8_Click);
		this.button_28.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.button_28.ForeColor = System.Drawing.Color.Black;
		this.button_28.Image = ACE.Properties.Resources.NpcGenEditorForm_remove;
		this.button_28.Location = new System.Drawing.Point(180, 454);
		this.button_28.Name = Class16.smethod_0(1649102969);
		this.button_28.Size = new System.Drawing.Size(181, 29);
		this.button_28.TabIndex = 21;
		this.button_28.Text = Class16.smethod_0(1648925718);
		this.button_28.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.button_28.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		this.button_28.UseVisualStyleBackColor = true;
		this.button_28.Click += new System.EventHandler(button_28_Click);
		this.button_26.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.button_26.ForeColor = System.Drawing.Color.Black;
		this.button_26.Image = ACE.Properties.Resources.NpcGenEditorForm_Clone;
		this.button_26.Location = new System.Drawing.Point(0, 454);
		this.button_26.Name = Class16.smethod_0(1649103004);
		this.button_26.Size = new System.Drawing.Size(181, 29);
		this.button_26.TabIndex = 20;
		this.button_26.Text = Class16.smethod_0(1648931357);
		this.button_26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.button_26.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		this.button_26.UseVisualStyleBackColor = true;
		this.button_26.Click += new System.EventHandler(button_26_Click);
		this.tabPage_5.BackColor = System.Drawing.Color.FromArgb(239, 244, 250);
		this.tabPage_5.Controls.Add(this.dataGridView_9);
		this.tabPage_5.Controls.Add(this.groupBox_12);
		this.tabPage_5.Controls.Add(this.groupBox_11);
		this.tabPage_5.Controls.Add(this.groupBox_10);
		this.tabPage_5.Controls.Add(this.groupBox_9);
		this.tabPage_5.Location = new System.Drawing.Point(4, 22);
		this.tabPage_5.Name = Class16.smethod_0(1649103030);
		this.tabPage_5.Padding = new System.Windows.Forms.Padding(3);
		this.tabPage_5.Size = new System.Drawing.Size(966, 483);
		this.tabPage_5.TabIndex = 5;
		this.tabPage_5.Text = Class16.smethod_0(1648931650);
		this.dataGridView_9.AllowUserToAddRows = false;
		this.dataGridView_9.AllowUserToDeleteRows = false;
		this.dataGridView_9.AllowUserToResizeColumns = false;
		this.dataGridView_9.AllowUserToResizeRows = false;
		this.dataGridView_9.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.dataGridView_9.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
		this.dataGridView_9.BackgroundColor = System.Drawing.Color.FromArgb(15, 15, 15);
		this.dataGridView_9.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
		this.dataGridView_9.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
		this.dataGridView_9.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridView_9.Columns.AddRange(this.dataGridViewTextBoxColumn_13, this.dataGridViewTextBoxColumn_14, this.dataGridViewTextBoxColumn_16, this.dataGridViewTextBoxColumn_1);
		this.dataGridView_9.ContextMenuStrip = this.contextMenuStrip_0;
		dataGridViewCellStyle39.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle39.BackColor = System.Drawing.Color.FromArgb(15, 15, 15);
		dataGridViewCellStyle39.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 8.25f);
		dataGridViewCellStyle39.ForeColor = System.Drawing.Color.FromArgb(224, 224, 224);
		dataGridViewCellStyle39.SelectionBackColor = System.Drawing.SystemColors.Highlight;
		dataGridViewCellStyle39.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		dataGridViewCellStyle39.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
		this.dataGridView_9.DefaultCellStyle = dataGridViewCellStyle39;
		this.dataGridView_9.EnableHeadersVisualStyles = false;
		this.dataGridView_9.Location = new System.Drawing.Point(3, 157);
		this.dataGridView_9.Name = Class16.smethod_0(1649103046);
		this.dataGridView_9.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
		this.dataGridView_9.RowHeadersVisible = false;
		this.dataGridView_9.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		this.dataGridView_9.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		this.dataGridView_9.ShowCellErrors = false;
		this.dataGridView_9.ShowCellToolTips = false;
		this.dataGridView_9.ShowEditingIcon = false;
		this.dataGridView_9.ShowRowErrors = false;
		this.dataGridView_9.Size = new System.Drawing.Size(960, 323);
		this.dataGridView_9.TabIndex = 16;
		this.dataGridView_9.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(dataGridView_9_CellDoubleClick);
		dataGridViewCellStyle40.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.dataGridViewTextBoxColumn_13.DefaultCellStyle = dataGridViewCellStyle40;
		this.dataGridViewTextBoxColumn_13.FillWeight = 5f;
		this.dataGridViewTextBoxColumn_13.HeaderText = Class16.smethod_0(1648929947);
		this.dataGridViewTextBoxColumn_13.Name = Class16.smethod_0(1649029230);
		this.dataGridViewTextBoxColumn_13.ReadOnly = true;
		this.dataGridViewTextBoxColumn_13.Resizable = System.Windows.Forms.DataGridViewTriState.False;
		this.dataGridViewTextBoxColumn_13.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
		dataGridViewCellStyle41.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		dataGridViewCellStyle41.ForeColor = System.Drawing.Color.FromArgb(77, 255, 143);
		this.dataGridViewTextBoxColumn_14.DefaultCellStyle = dataGridViewCellStyle41;
		this.dataGridViewTextBoxColumn_14.FillWeight = 33f;
		this.dataGridViewTextBoxColumn_14.HeaderText = Class16.smethod_0(1649118934);
		this.dataGridViewTextBoxColumn_14.Name = Class16.smethod_0(1649103063);
		this.dataGridViewTextBoxColumn_14.ReadOnly = true;
		this.dataGridViewTextBoxColumn_14.Resizable = System.Windows.Forms.DataGridViewTriState.False;
		this.dataGridViewTextBoxColumn_14.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
		dataGridViewCellStyle42.ForeColor = System.Drawing.Color.White;
		this.dataGridViewTextBoxColumn_16.DefaultCellStyle = dataGridViewCellStyle42;
		this.dataGridViewTextBoxColumn_16.FillWeight = 46f;
		this.dataGridViewTextBoxColumn_16.HeaderText = Class16.smethod_0(1648936731);
		this.dataGridViewTextBoxColumn_16.Name = Class16.smethod_0(1649103089);
		this.dataGridViewTextBoxColumn_16.ReadOnly = true;
		this.dataGridViewTextBoxColumn_16.Resizable = System.Windows.Forms.DataGridViewTriState.False;
		this.dataGridViewTextBoxColumn_16.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
		this.dataGridViewTextBoxColumn_1.FillWeight = 16f;
		this.dataGridViewTextBoxColumn_1.HeaderText = Class16.smethod_0(1649103123);
		this.dataGridViewTextBoxColumn_1.Name = Class16.smethod_0(1648990853);
		this.dataGridViewTextBoxColumn_1.ReadOnly = true;
		this.dataGridViewTextBoxColumn_1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
		this.dataGridViewTextBoxColumn_1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
		this.contextMenuStrip_0.Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.toolStripMenuItem_7 });
		this.contextMenuStrip_0.Name = Class16.smethod_0(1649113432);
		this.contextMenuStrip_0.Size = new System.Drawing.Size(166, 26);
		this.contextMenuStrip_0.Text = Class16.smethod_0(1649061905);
		this.toolStripMenuItem_7.Name = Class16.smethod_0(1649103137);
		this.toolStripMenuItem_7.Size = new System.Drawing.Size(165, 22);
		this.toolStripMenuItem_7.Text = Class16.smethod_0(1649103166);
		this.toolStripMenuItem_7.Click += new System.EventHandler(toolStripMenuItem_7_Click);
		this.groupBox_12.Controls.Add(this.button_27);
		this.groupBox_12.Controls.Add(this.textBox_45);
		this.groupBox_12.Controls.Add(this.radioButton_14);
		this.groupBox_12.Controls.Add(this.textBox_43);
		this.groupBox_12.Controls.Add(this.label_10);
		this.groupBox_12.Controls.Add(this.radioButton_13);
		this.groupBox_12.Controls.Add(this.textBox_44);
		this.groupBox_12.Controls.Add(this.label_11);
		this.groupBox_12.Controls.Add(this.radioButton_12);
		this.groupBox_12.Location = new System.Drawing.Point(726, 1);
		this.groupBox_12.Name = Class16.smethod_0(1649103189);
		this.groupBox_12.Size = new System.Drawing.Size(235, 154);
		this.groupBox_12.TabIndex = 12;
		this.groupBox_12.TabStop = false;
		this.groupBox_12.Text = Class16.smethod_0(1649103206);
		this.button_27.Anchor = System.Windows.Forms.AnchorStyles.Left;
		this.button_27.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.button_27.ForeColor = System.Drawing.Color.Black;
		this.button_27.Image = ACE.Properties.Resources.NpcGenEditorForm_TriggerSearchButton;
		this.button_27.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
		this.button_27.Location = new System.Drawing.Point(1, 107);
		this.button_27.Name = Class16.smethod_0(1649103231);
		this.button_27.Size = new System.Drawing.Size(234, 45);
		this.button_27.TabIndex = 31;
		this.button_27.Text = Class16.smethod_0(1648999261);
		this.button_27.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.button_27.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		this.button_27.UseVisualStyleBackColor = true;
		this.button_27.Click += new System.EventHandler(button_27_Click);
		this.textBox_45.Location = new System.Drawing.Point(80, 64);
		this.textBox_45.Name = Class16.smethod_0(1649103249);
		this.textBox_45.Size = new System.Drawing.Size(151, 20);
		this.textBox_45.TabIndex = 6;
		this.textBox_45.Click += new System.EventHandler(textBox_13_Click);
		this.radioButton_14.AutoSize = true;
		this.radioButton_14.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.radioButton_14.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(255, 128, 0);
		this.radioButton_14.Location = new System.Drawing.Point(31, 64);
		this.radioButton_14.Name = Class16.smethod_0(1649103273);
		this.radioButton_14.Size = new System.Drawing.Size(45, 17);
		this.radioButton_14.TabIndex = 7;
		this.radioButton_14.Text = Class16.smethod_0(1649103311);
		this.radioButton_14.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		this.radioButton_14.UseVisualStyleBackColor = true;
		this.textBox_43.Location = new System.Drawing.Point(80, 42);
		this.textBox_43.Name = Class16.smethod_0(1649103315);
		this.textBox_43.Size = new System.Drawing.Size(151, 20);
		this.textBox_43.TabIndex = 4;
		this.textBox_43.Click += new System.EventHandler(textBox_13_Click);
		this.textBox_43.TextChanged += new System.EventHandler(textBox_43_TextChanged);
		this.label_10.AutoSize = true;
		this.label_10.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_10.Location = new System.Drawing.Point(153, 23);
		this.label_10.Name = Class16.smethod_0(1649103339);
		this.label_10.Size = new System.Drawing.Size(0, 13);
		this.label_10.TabIndex = 3;
		this.radioButton_13.AutoSize = true;
		this.radioButton_13.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.radioButton_13.Checked = true;
		this.radioButton_13.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(255, 128, 0);
		this.radioButton_13.Location = new System.Drawing.Point(40, 20);
		this.radioButton_13.Name = Class16.smethod_0(1649103354);
		this.radioButton_13.Size = new System.Drawing.Size(36, 17);
		this.radioButton_13.TabIndex = 1;
		this.radioButton_13.TabStop = true;
		this.radioButton_13.Text = Class16.smethod_0(1648941057);
		this.radioButton_13.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		this.radioButton_13.UseVisualStyleBackColor = true;
		this.textBox_44.BackColor = System.Drawing.Color.WhiteSmoke;
		this.textBox_44.Location = new System.Drawing.Point(80, 20);
		this.textBox_44.Name = Class16.smethod_0(1649106462);
		this.textBox_44.Size = new System.Drawing.Size(67, 20);
		this.textBox_44.TabIndex = 0;
		this.textBox_44.Text = Class16.smethod_0(1648924112);
		this.toolTip_0.SetToolTip(this.textBox_44, Class16.smethod_0(1649106484));
		this.textBox_44.Click += new System.EventHandler(textBox_13_Click);
		this.textBox_44.TextChanged += new System.EventHandler(textBox_44_TextChanged);
		this.label_11.AutoSize = true;
		this.label_11.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_11.Location = new System.Drawing.Point(144, 18);
		this.label_11.Name = Class16.smethod_0(1649106527);
		this.label_11.Size = new System.Drawing.Size(14, 20);
		this.label_11.TabIndex = 2;
		this.label_11.Text = Class16.smethod_0(1648905535);
		this.radioButton_12.AutoSize = true;
		this.radioButton_12.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.radioButton_12.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(255, 128, 0);
		this.radioButton_12.Location = new System.Drawing.Point(24, 43);
		this.radioButton_12.Name = Class16.smethod_0(1649106542);
		this.radioButton_12.Size = new System.Drawing.Size(52, 17);
		this.radioButton_12.TabIndex = 5;
		this.radioButton_12.Text = Class16.smethod_0(1649106572);
		this.radioButton_12.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		this.radioButton_12.UseVisualStyleBackColor = true;
		this.groupBox_11.Controls.Add(this.button_2);
		this.groupBox_11.Controls.Add(this.textBox_11);
		this.groupBox_11.Controls.Add(this.radioButton_4);
		this.groupBox_11.Controls.Add(this.textBox_10);
		this.groupBox_11.Controls.Add(this.label_8);
		this.groupBox_11.Controls.Add(this.radioButton_2);
		this.groupBox_11.Controls.Add(this.textBox_9);
		this.groupBox_11.Controls.Add(this.label_9);
		this.groupBox_11.Controls.Add(this.radioButton_3);
		this.groupBox_11.Location = new System.Drawing.Point(485, 1);
		this.groupBox_11.Name = Class16.smethod_0(1649106583);
		this.groupBox_11.Size = new System.Drawing.Size(235, 154);
		this.groupBox_11.TabIndex = 11;
		this.groupBox_11.TabStop = false;
		this.groupBox_11.Text = Class16.smethod_0(1649106592);
		this.button_2.Anchor = System.Windows.Forms.AnchorStyles.Left;
		this.button_2.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.button_2.ForeColor = System.Drawing.Color.Black;
		this.button_2.Image = ACE.Properties.Resources.NpcGenEditorForm_DynamicSearchButton;
		this.button_2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
		this.button_2.Location = new System.Drawing.Point(0, 107);
		this.button_2.Name = Class16.smethod_0(1649106624);
		this.button_2.Size = new System.Drawing.Size(234, 45);
		this.button_2.TabIndex = 30;
		this.button_2.Text = Class16.smethod_0(1648999261);
		this.button_2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.button_2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		this.button_2.UseVisualStyleBackColor = true;
		this.button_2.Click += new System.EventHandler(button_2_Click);
		this.textBox_11.Location = new System.Drawing.Point(80, 64);
		this.textBox_11.Name = Class16.smethod_0(1649106650);
		this.textBox_11.Size = new System.Drawing.Size(151, 20);
		this.textBox_11.TabIndex = 6;
		this.textBox_11.Click += new System.EventHandler(textBox_13_Click);
		this.radioButton_4.AutoSize = true;
		this.radioButton_4.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.radioButton_4.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(255, 128, 0);
		this.radioButton_4.Location = new System.Drawing.Point(18, 64);
		this.radioButton_4.Name = Class16.smethod_0(1649106685);
		this.radioButton_4.Size = new System.Drawing.Size(58, 17);
		this.radioButton_4.TabIndex = 7;
		this.radioButton_4.Text = Class16.smethod_0(1649108102);
		this.radioButton_4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		this.radioButton_4.UseVisualStyleBackColor = true;
		this.textBox_10.Location = new System.Drawing.Point(80, 42);
		this.textBox_10.Name = Class16.smethod_0(1649106718);
		this.textBox_10.Size = new System.Drawing.Size(151, 20);
		this.textBox_10.TabIndex = 4;
		this.textBox_10.Click += new System.EventHandler(textBox_13_Click);
		this.label_8.AutoSize = true;
		this.label_8.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_8.Location = new System.Drawing.Point(153, 23);
		this.label_8.Name = Class16.smethod_0(1649106742);
		this.label_8.Size = new System.Drawing.Size(0, 13);
		this.label_8.TabIndex = 3;
		this.radioButton_2.AutoSize = true;
		this.radioButton_2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.radioButton_2.Checked = true;
		this.radioButton_2.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(255, 128, 0);
		this.radioButton_2.Location = new System.Drawing.Point(40, 20);
		this.radioButton_2.Name = Class16.smethod_0(1649106757);
		this.radioButton_2.Size = new System.Drawing.Size(36, 17);
		this.radioButton_2.TabIndex = 1;
		this.radioButton_2.TabStop = true;
		this.radioButton_2.Text = Class16.smethod_0(1648941057);
		this.radioButton_2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		this.radioButton_2.UseVisualStyleBackColor = true;
		this.textBox_9.BackColor = System.Drawing.Color.FromArgb(128, 255, 128);
		this.textBox_9.Location = new System.Drawing.Point(80, 20);
		this.textBox_9.Name = Class16.smethod_0(1649106777);
		this.textBox_9.Size = new System.Drawing.Size(67, 20);
		this.textBox_9.TabIndex = 0;
		this.textBox_9.Text = Class16.smethod_0(1648924112);
		this.toolTip_0.SetToolTip(this.textBox_9, Class16.smethod_0(1649106807));
		this.textBox_9.Click += new System.EventHandler(textBox_13_Click);
		this.textBox_9.TextChanged += new System.EventHandler(textBox_9_TextChanged);
		this.textBox_9.DoubleClick += new System.EventHandler(textBox_9_DoubleClick);
		this.label_9.AutoSize = true;
		this.label_9.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_9.Location = new System.Drawing.Point(144, 18);
		this.label_9.Name = Class16.smethod_0(1649106849);
		this.label_9.Size = new System.Drawing.Size(14, 20);
		this.label_9.TabIndex = 2;
		this.label_9.Text = Class16.smethod_0(1648905535);
		this.radioButton_3.AutoSize = true;
		this.radioButton_3.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.radioButton_3.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(255, 128, 0);
		this.radioButton_3.Location = new System.Drawing.Point(23, 43);
		this.radioButton_3.Name = Class16.smethod_0(1649106864);
		this.radioButton_3.Size = new System.Drawing.Size(53, 17);
		this.radioButton_3.TabIndex = 5;
		this.radioButton_3.Text = Class16.smethod_0(1648936731);
		this.radioButton_3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		this.radioButton_3.UseVisualStyleBackColor = true;
		this.groupBox_10.BackColor = System.Drawing.Color.FromArgb(239, 244, 250);
		this.groupBox_10.Controls.Add(this.button_18);
		this.groupBox_10.Controls.Add(this.textBox_25);
		this.groupBox_10.Controls.Add(this.radioButton_11);
		this.groupBox_10.Controls.Add(this.textBox_24);
		this.groupBox_10.Controls.Add(this.label_6);
		this.groupBox_10.Controls.Add(this.radioButton_9);
		this.groupBox_10.Controls.Add(this.textBox_23);
		this.groupBox_10.Controls.Add(this.label_7);
		this.groupBox_10.Controls.Add(this.radioButton_10);
		this.groupBox_10.Location = new System.Drawing.Point(244, 1);
		this.groupBox_10.Name = Class16.smethod_0(1649106902);
		this.groupBox_10.Size = new System.Drawing.Size(235, 154);
		this.groupBox_10.TabIndex = 10;
		this.groupBox_10.TabStop = false;
		this.groupBox_10.Text = Class16.smethod_0(1649106919);
		this.button_18.Anchor = System.Windows.Forms.AnchorStyles.Left;
		this.button_18.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.button_18.ForeColor = System.Drawing.Color.Black;
		this.button_18.Image = ACE.Properties.Resources.NpcGenEditorForm_ResourceSearchButton;
		this.button_18.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
		this.button_18.Location = new System.Drawing.Point(1, 107);
		this.button_18.Name = Class16.smethod_0(1649106941);
		this.button_18.Size = new System.Drawing.Size(234, 45);
		this.button_18.TabIndex = 29;
		this.button_18.Text = Class16.smethod_0(1648999261);
		this.button_18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.button_18.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		this.button_18.UseVisualStyleBackColor = true;
		this.button_18.Click += new System.EventHandler(button_18_Click);
		this.textBox_25.Location = new System.Drawing.Point(80, 64);
		this.textBox_25.Name = Class16.smethod_0(1649105936);
		this.textBox_25.Size = new System.Drawing.Size(151, 20);
		this.textBox_25.TabIndex = 6;
		this.textBox_25.Click += new System.EventHandler(textBox_13_Click);
		this.radioButton_11.AutoSize = true;
		this.radioButton_11.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.radioButton_11.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(255, 128, 0);
		this.radioButton_11.Location = new System.Drawing.Point(18, 64);
		this.radioButton_11.Name = Class16.smethod_0(1649105972);
		this.radioButton_11.Size = new System.Drawing.Size(58, 17);
		this.radioButton_11.TabIndex = 7;
		this.radioButton_11.Text = Class16.smethod_0(1649108102);
		this.radioButton_11.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		this.radioButton_11.UseVisualStyleBackColor = true;
		this.textBox_24.Location = new System.Drawing.Point(80, 42);
		this.textBox_24.Name = Class16.smethod_0(1649106006);
		this.textBox_24.Size = new System.Drawing.Size(151, 20);
		this.textBox_24.TabIndex = 4;
		this.textBox_24.Click += new System.EventHandler(textBox_13_Click);
		this.label_6.AutoSize = true;
		this.label_6.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_6.Location = new System.Drawing.Point(153, 23);
		this.label_6.Name = Class16.smethod_0(1649106031);
		this.label_6.Size = new System.Drawing.Size(0, 13);
		this.label_6.TabIndex = 3;
		this.radioButton_9.AutoSize = true;
		this.radioButton_9.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.radioButton_9.Checked = true;
		this.radioButton_9.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(255, 128, 0);
		this.radioButton_9.Location = new System.Drawing.Point(40, 20);
		this.radioButton_9.Name = Class16.smethod_0(1649106046);
		this.radioButton_9.Size = new System.Drawing.Size(36, 17);
		this.radioButton_9.TabIndex = 1;
		this.radioButton_9.TabStop = true;
		this.radioButton_9.Text = Class16.smethod_0(1648941057);
		this.radioButton_9.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		this.radioButton_9.UseVisualStyleBackColor = true;
		this.textBox_23.BackColor = System.Drawing.Color.FromArgb(128, 255, 128);
		this.textBox_23.Location = new System.Drawing.Point(80, 20);
		this.textBox_23.Name = Class16.smethod_0(1649106067);
		this.textBox_23.Size = new System.Drawing.Size(67, 20);
		this.textBox_23.TabIndex = 0;
		this.textBox_23.Text = Class16.smethod_0(1648924112);
		this.toolTip_0.SetToolTip(this.textBox_23, Class16.smethod_0(1649106484));
		this.textBox_23.Click += new System.EventHandler(textBox_13_Click);
		this.textBox_23.TextChanged += new System.EventHandler(textBox_23_TextChanged);
		this.textBox_23.DoubleClick += new System.EventHandler(textBox_23_DoubleClick);
		this.label_7.AutoSize = true;
		this.label_7.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_7.Location = new System.Drawing.Point(144, 18);
		this.label_7.Name = Class16.smethod_0(1649106090);
		this.label_7.Size = new System.Drawing.Size(14, 20);
		this.label_7.TabIndex = 2;
		this.label_7.Text = Class16.smethod_0(1648905535);
		this.radioButton_10.AutoSize = true;
		this.radioButton_10.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.radioButton_10.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(255, 128, 0);
		this.radioButton_10.Location = new System.Drawing.Point(23, 43);
		this.radioButton_10.Name = Class16.smethod_0(1649106105);
		this.radioButton_10.Size = new System.Drawing.Size(53, 17);
		this.radioButton_10.TabIndex = 5;
		this.radioButton_10.Text = Class16.smethod_0(1648936731);
		this.radioButton_10.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		this.radioButton_10.UseVisualStyleBackColor = true;
		this.groupBox_9.Controls.Add(this.button_11);
		this.groupBox_9.Controls.Add(this.textBox_15);
		this.groupBox_9.Controls.Add(this.radioButton_7);
		this.groupBox_9.Controls.Add(this.textBox_16);
		this.groupBox_9.Controls.Add(this.radioButton_8);
		this.groupBox_9.Controls.Add(this.textBox_14);
		this.groupBox_9.Controls.Add(this.label_5);
		this.groupBox_9.Controls.Add(this.radioButton_5);
		this.groupBox_9.Controls.Add(this.textBox_13);
		this.groupBox_9.Controls.Add(this.label_82);
		this.groupBox_9.Controls.Add(this.radioButton_6);
		this.groupBox_9.Location = new System.Drawing.Point(3, 1);
		this.groupBox_9.Name = Class16.smethod_0(1649106136);
		this.groupBox_9.Size = new System.Drawing.Size(235, 154);
		this.groupBox_9.TabIndex = 0;
		this.groupBox_9.TabStop = false;
		this.groupBox_9.Text = Class16.smethod_0(1649106153);
		this.button_11.Anchor = System.Windows.Forms.AnchorStyles.Left;
		this.button_11.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.button_11.ForeColor = System.Drawing.Color.Black;
		this.button_11.Image = ACE.Properties.Resources.NpcGenEditorForm_ExistenceSearchButton;
		this.button_11.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
		this.button_11.Location = new System.Drawing.Point(0, 107);
		this.button_11.Name = Class16.smethod_0(1649106179);
		this.button_11.Size = new System.Drawing.Size(234, 45);
		this.button_11.TabIndex = 28;
		this.button_11.Text = Class16.smethod_0(1648999261);
		this.button_11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.button_11.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		this.button_11.UseVisualStyleBackColor = true;
		this.button_11.Click += new System.EventHandler(button_11_Click);
		this.textBox_15.Location = new System.Drawing.Point(80, 86);
		this.textBox_15.Name = Class16.smethod_0(1649106215);
		this.textBox_15.Size = new System.Drawing.Size(151, 20);
		this.textBox_15.TabIndex = 8;
		this.textBox_15.Click += new System.EventHandler(textBox_13_Click);
		this.radioButton_7.AutoSize = true;
		this.radioButton_7.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.radioButton_7.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(255, 128, 0);
		this.radioButton_7.Location = new System.Drawing.Point(27, 86);
		this.radioButton_7.Name = Class16.smethod_0(1649106233);
		this.radioButton_7.Size = new System.Drawing.Size(47, 17);
		this.radioButton_7.TabIndex = 9;
		this.radioButton_7.Text = Class16.smethod_0(1648893060);
		this.radioButton_7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		this.radioButton_7.UseVisualStyleBackColor = true;
		this.textBox_16.Location = new System.Drawing.Point(80, 64);
		this.textBox_16.Name = Class16.smethod_0(1649106265);
		this.textBox_16.Size = new System.Drawing.Size(151, 20);
		this.textBox_16.TabIndex = 6;
		this.textBox_16.Click += new System.EventHandler(textBox_13_Click);
		this.radioButton_8.AutoSize = true;
		this.radioButton_8.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.radioButton_8.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(255, 128, 0);
		this.radioButton_8.Location = new System.Drawing.Point(16, 64);
		this.radioButton_8.Name = Class16.smethod_0(1649106302);
		this.radioButton_8.Size = new System.Drawing.Size(58, 17);
		this.radioButton_8.TabIndex = 7;
		this.radioButton_8.Text = Class16.smethod_0(1649108102);
		this.radioButton_8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		this.radioButton_8.UseVisualStyleBackColor = true;
		this.textBox_14.Location = new System.Drawing.Point(80, 42);
		this.textBox_14.Name = Class16.smethod_0(1649106329);
		this.textBox_14.Size = new System.Drawing.Size(151, 20);
		this.textBox_14.TabIndex = 4;
		this.textBox_14.Click += new System.EventHandler(textBox_13_Click);
		this.label_5.AutoSize = true;
		this.label_5.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_5.Location = new System.Drawing.Point(153, 23);
		this.label_5.Name = Class16.smethod_0(1649106355);
		this.label_5.Size = new System.Drawing.Size(0, 13);
		this.label_5.TabIndex = 3;
		this.radioButton_5.AutoSize = true;
		this.radioButton_5.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.radioButton_5.Checked = true;
		this.radioButton_5.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(255, 128, 0);
		this.radioButton_5.Location = new System.Drawing.Point(38, 20);
		this.radioButton_5.Name = Class16.smethod_0(1649106370);
		this.radioButton_5.Size = new System.Drawing.Size(36, 17);
		this.radioButton_5.TabIndex = 1;
		this.radioButton_5.TabStop = true;
		this.radioButton_5.Text = Class16.smethod_0(1648941057);
		this.radioButton_5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		this.radioButton_5.UseVisualStyleBackColor = true;
		this.textBox_13.BackColor = System.Drawing.Color.FromArgb(128, 255, 128);
		this.textBox_13.Location = new System.Drawing.Point(80, 20);
		this.textBox_13.Name = Class16.smethod_0(1649106400);
		this.textBox_13.Size = new System.Drawing.Size(67, 20);
		this.textBox_13.TabIndex = 0;
		this.textBox_13.Text = Class16.smethod_0(1648924112);
		this.toolTip_0.SetToolTip(this.textBox_13, Class16.smethod_0(1649106484));
		this.textBox_13.Click += new System.EventHandler(textBox_13_Click);
		this.textBox_13.TextChanged += new System.EventHandler(textBox_13_TextChanged);
		this.textBox_13.DoubleClick += new System.EventHandler(textBox_13_DoubleClick);
		this.label_82.AutoSize = true;
		this.label_82.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_82.Location = new System.Drawing.Point(144, 18);
		this.label_82.Name = Class16.smethod_0(1649106424);
		this.label_82.Size = new System.Drawing.Size(14, 20);
		this.label_82.TabIndex = 2;
		this.label_82.Text = Class16.smethod_0(1648905535);
		this.radioButton_6.AutoSize = true;
		this.radioButton_6.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.radioButton_6.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(255, 128, 0);
		this.radioButton_6.Location = new System.Drawing.Point(21, 43);
		this.radioButton_6.Name = Class16.smethod_0(1649105422);
		this.radioButton_6.Size = new System.Drawing.Size(53, 17);
		this.radioButton_6.TabIndex = 5;
		this.radioButton_6.Text = Class16.smethod_0(1648936731);
		this.radioButton_6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		this.radioButton_6.UseVisualStyleBackColor = true;
		this.tabPage_1.BackColor = System.Drawing.Color.FromArgb(239, 244, 250);
		this.tabPage_1.Controls.Add(this.button_16);
		this.tabPage_1.Controls.Add(this.button_25);
		this.tabPage_1.Controls.Add(this.dataGridView_2);
		this.tabPage_1.Location = new System.Drawing.Point(4, 22);
		this.tabPage_1.Name = Class16.smethod_0(1649105454);
		this.tabPage_1.Padding = new System.Windows.Forms.Padding(3);
		this.tabPage_1.Size = new System.Drawing.Size(966, 483);
		this.tabPage_1.TabIndex = 6;
		this.tabPage_1.Text = Class16.smethod_0(1649105470);
		this.button_16.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.button_16.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 12.75f);
		this.button_16.ForeColor = System.Drawing.Color.Black;
		this.button_16.Image = ACE.Properties.Resources.NpcGenEditorForm_RemoveAllErrors;
		this.button_16.Location = new System.Drawing.Point(187, 428);
		this.button_16.Name = Class16.smethod_0(1649105475);
		this.button_16.Size = new System.Drawing.Size(249, 54);
		this.button_16.TabIndex = 18;
		this.button_16.Text = Class16.smethod_0(1649105497);
		this.button_16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.button_16.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		this.button_16.UseVisualStyleBackColor = true;
		this.button_16.Click += new System.EventHandler(button_16_Click);
		this.button_25.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.button_25.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 12.75f);
		this.button_25.ForeColor = System.Drawing.Color.Black;
		this.button_25.Image = ACE.Properties.Resources.NpcGenEditorForm_SearchErrorsButton;
		this.button_25.Location = new System.Drawing.Point(0, 428);
		this.button_25.Name = Class16.smethod_0(1649105522);
		this.button_25.Size = new System.Drawing.Size(186, 54);
		this.button_25.TabIndex = 17;
		this.button_25.Text = Class16.smethod_0(1649105547);
		this.button_25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
		this.button_25.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		this.button_25.UseVisualStyleBackColor = true;
		this.button_25.Click += new System.EventHandler(button_25_Click);
		this.dataGridView_2.AllowUserToAddRows = false;
		this.dataGridView_2.AllowUserToDeleteRows = false;
		this.dataGridView_2.AllowUserToResizeColumns = false;
		this.dataGridView_2.AllowUserToResizeRows = false;
		this.dataGridView_2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.dataGridView_2.BackgroundColor = System.Drawing.Color.FromArgb(15, 15, 15);
		this.dataGridView_2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
		this.dataGridView_2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
		dataGridViewCellStyle43.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle43.BackColor = System.Drawing.SystemColors.Control;
		dataGridViewCellStyle43.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 8.25f);
		dataGridViewCellStyle43.ForeColor = System.Drawing.SystemColors.WindowText;
		dataGridViewCellStyle43.SelectionBackColor = System.Drawing.SystemColors.Highlight;
		dataGridViewCellStyle43.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		dataGridViewCellStyle43.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
		this.dataGridView_2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle43;
		this.dataGridView_2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridView_2.Columns.AddRange(this.dataGridViewTextBoxColumn_2, this.dataGridViewTextBoxColumn_28, this.dataGridViewTextBoxColumn_29, this.dataGridViewTextBoxColumn_30);
		dataGridViewCellStyle44.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle44.BackColor = System.Drawing.Color.FromArgb(15, 15, 15);
		dataGridViewCellStyle44.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 8.25f);
		dataGridViewCellStyle44.ForeColor = System.Drawing.Color.White;
		dataGridViewCellStyle44.SelectionBackColor = System.Drawing.Color.BlueViolet;
		dataGridViewCellStyle44.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		dataGridViewCellStyle44.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
		this.dataGridView_2.DefaultCellStyle = dataGridViewCellStyle44;
		this.dataGridView_2.EnableHeadersVisualStyles = false;
		this.dataGridView_2.Location = new System.Drawing.Point(0, 0);
		this.dataGridView_2.Name = Class16.smethod_0(1649105573);
		this.dataGridView_2.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
		this.dataGridView_2.RowHeadersVisible = false;
		this.dataGridView_2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		this.dataGridView_2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		this.dataGridView_2.ShowCellErrors = false;
		this.dataGridView_2.ShowCellToolTips = false;
		this.dataGridView_2.ShowEditingIcon = false;
		this.dataGridView_2.ShowRowErrors = false;
		this.dataGridView_2.Size = new System.Drawing.Size(966, 427);
		this.dataGridView_2.TabIndex = 16;
		this.dataGridView_2.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(dataGridView_2_CellDoubleClick);
		this.dataGridViewTextBoxColumn_2.HeaderText = Class16.smethod_0(1648929947);
		this.dataGridViewTextBoxColumn_2.Name = Class16.smethod_0(1648963825);
		this.dataGridViewTextBoxColumn_2.Width = 45;
		dataGridViewCellStyle45.ForeColor = System.Drawing.Color.FromArgb(77, 255, 143);
		this.dataGridViewTextBoxColumn_28.DefaultCellStyle = dataGridViewCellStyle45;
		this.dataGridViewTextBoxColumn_28.FillWeight = 6.912442f;
		this.dataGridViewTextBoxColumn_28.HeaderText = Class16.smethod_0(1648942867);
		this.dataGridViewTextBoxColumn_28.Name = Class16.smethod_0(1649105590);
		this.dataGridViewTextBoxColumn_28.ReadOnly = true;
		this.dataGridViewTextBoxColumn_28.Resizable = System.Windows.Forms.DataGridViewTriState.False;
		this.dataGridViewTextBoxColumn_28.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
		this.dataGridViewTextBoxColumn_28.Width = 50;
		dataGridViewCellStyle46.ForeColor = System.Drawing.Color.FromArgb(77, 255, 143);
		this.dataGridViewTextBoxColumn_29.DefaultCellStyle = dataGridViewCellStyle46;
		this.dataGridViewTextBoxColumn_29.FillWeight = 44.7233f;
		this.dataGridViewTextBoxColumn_29.HeaderText = Class16.smethod_0(1649103123);
		this.dataGridViewTextBoxColumn_29.Name = Class16.smethod_0(1649105616);
		this.dataGridViewTextBoxColumn_29.ReadOnly = true;
		this.dataGridViewTextBoxColumn_29.Resizable = System.Windows.Forms.DataGridViewTriState.False;
		this.dataGridViewTextBoxColumn_29.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
		this.dataGridViewTextBoxColumn_29.Width = 200;
		this.dataGridViewTextBoxColumn_30.HeaderText = Class16.smethod_0(1648934892);
		this.dataGridViewTextBoxColumn_30.Name = Class16.smethod_0(1649105650);
		this.dataGridViewTextBoxColumn_30.ReadOnly = true;
		this.dataGridViewTextBoxColumn_30.Resizable = System.Windows.Forms.DataGridViewTriState.False;
		this.dataGridViewTextBoxColumn_30.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
		this.dataGridViewTextBoxColumn_30.Width = 669;
		this.tabPage_3.BackColor = System.Drawing.Color.FromArgb(239, 244, 250);
		this.tabPage_3.Controls.Add(this.groupBox_13);
		this.tabPage_3.Controls.Add(this.comboBox_3);
		this.tabPage_3.Controls.Add(this.label_56);
		this.tabPage_3.Controls.Add(this.groupBox_16);
		this.tabPage_3.Controls.Add(this.comboBox_16);
		this.tabPage_3.Controls.Add(this.button_1);
		this.tabPage_3.Controls.Add(this.button_23);
		this.tabPage_3.Location = new System.Drawing.Point(4, 22);
		this.tabPage_3.Name = Class16.smethod_0(1649105692);
		this.tabPage_3.Padding = new System.Windows.Forms.Padding(3);
		this.tabPage_3.Size = new System.Drawing.Size(966, 483);
		this.tabPage_3.TabIndex = 4;
		this.tabPage_3.Text = Class16.smethod_0(1649105709);
		this.groupBox_13.BackColor = System.Drawing.Color.FromArgb(128, 255, 128);
		this.groupBox_13.Controls.Add(this.radioButton_0);
		this.groupBox_13.Controls.Add(this.radioButton_1);
		this.groupBox_13.Location = new System.Drawing.Point(774, 4);
		this.groupBox_13.Name = Class16.smethod_0(1649105735);
		this.groupBox_13.Size = new System.Drawing.Size(96, 98);
		this.groupBox_13.TabIndex = 63;
		this.groupBox_13.TabStop = false;
		this.groupBox_13.Text = Class16.smethod_0(1649105744);
		this.radioButton_0.BackColor = System.Drawing.Color.Transparent;
		this.radioButton_0.Checked = true;
		this.radioButton_0.ForeColor = System.Drawing.Color.Black;
		this.radioButton_0.Image = ACE.Properties.Resources.NpcGenEditorForm_Clear;
		this.radioButton_0.Location = new System.Drawing.Point(10, 19);
		this.radioButton_0.Name = Class16.smethod_0(1648928315);
		this.radioButton_0.Size = new System.Drawing.Size(85, 24);
		this.radioButton_0.TabIndex = 59;
		this.radioButton_0.TabStop = true;
		this.radioButton_0.Text = Class16.smethod_0(1648928315);
		this.radioButton_0.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		this.radioButton_0.UseVisualStyleBackColor = false;
		this.radioButton_0.CheckedChanged += new System.EventHandler(radioButton_1_CheckedChanged);
		this.radioButton_1.BackColor = System.Drawing.Color.Transparent;
		this.radioButton_1.ForeColor = System.Drawing.Color.Black;
		this.radioButton_1.Image = ACE.Properties.Resources.NpcGenEditorForm_Dark;
		this.radioButton_1.Location = new System.Drawing.Point(10, 42);
		this.radioButton_1.Name = Class16.smethod_0(1648900669);
		this.radioButton_1.Size = new System.Drawing.Size(79, 24);
		this.radioButton_1.TabIndex = 60;
		this.radioButton_1.Text = Class16.smethod_0(1648900669);
		this.radioButton_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.radioButton_1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		this.radioButton_1.UseVisualStyleBackColor = false;
		this.radioButton_1.CheckedChanged += new System.EventHandler(radioButton_1_CheckedChanged);
		this.comboBox_3.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.comboBox_3.BackColor = System.Drawing.Color.FromArgb(255, 128, 0);
		this.comboBox_3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.comboBox_3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.comboBox_3.FormattingEnabled = true;
		this.comboBox_3.Items.AddRange(new object[4]
		{
			Class16.smethod_0(1648910861),
			Class16.smethod_0(1648911788),
			Class16.smethod_0(1648911042),
			Class16.smethod_0(1648910944)
		});
		this.comboBox_3.Location = new System.Drawing.Point(335, 435);
		this.comboBox_3.Name = Class16.smethod_0(1649105760);
		this.comboBox_3.Size = new System.Drawing.Size(43, 21);
		this.comboBox_3.TabIndex = 61;
		this.label_56.AutoSize = true;
		this.label_56.BackColor = System.Drawing.Color.Transparent;
		this.label_56.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_56.ForeColor = System.Drawing.Color.Black;
		this.label_56.Location = new System.Drawing.Point(2, 4);
		this.label_56.Name = Class16.smethod_0(1649105797);
		this.label_56.Size = new System.Drawing.Size(36, 15);
		this.label_56.TabIndex = 5;
		this.label_56.Text = Class16.smethod_0(1648928315);
		this.groupBox_16.BackColor = System.Drawing.Color.FromArgb(239, 244, 250);
		this.groupBox_16.Controls.Add(this.comboBox_9);
		this.groupBox_16.Controls.Add(this.label_3);
		this.groupBox_16.Controls.Add(this.comboBox_4);
		this.groupBox_16.Controls.Add(this.label_4);
		this.groupBox_16.Controls.Add(this.comboBox_11);
		this.groupBox_16.Controls.Add(this.label_67);
		this.groupBox_16.Controls.Add(this.comboBox_6);
		this.groupBox_16.Controls.Add(this.label_83);
		this.groupBox_16.Controls.Add(this.comboBox_10);
		this.groupBox_16.Controls.Add(this.label_49);
		this.groupBox_16.Controls.Add(this.comboBox_5);
		this.groupBox_16.Controls.Add(this.label_54);
		this.groupBox_16.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.groupBox_16.Location = new System.Drawing.Point(1, 25);
		this.groupBox_16.Name = Class16.smethod_0(1649105803);
		this.groupBox_16.Size = new System.Drawing.Size(398, 148);
		this.groupBox_16.TabIndex = 0;
		this.groupBox_16.TabStop = false;
		this.groupBox_16.Text = Class16.smethod_0(1649105819);
		this.comboBox_9.DropDownHeight = 100;
		this.comboBox_9.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.comboBox_9.FormattingEnabled = true;
		this.comboBox_9.IntegralHeight = false;
		this.comboBox_9.ItemHeight = 13;
		this.comboBox_9.Items.AddRange(new object[26]
		{
			Class16.smethod_0(1648915780),
			Class16.smethod_0(1648915795),
			Class16.smethod_0(1648915818),
			Class16.smethod_0(1649105837),
			Class16.smethod_0(1649105845),
			Class16.smethod_0(1648995835),
			Class16.smethod_0(1649105853),
			Class16.smethod_0(1649105861),
			Class16.smethod_0(1648979963),
			Class16.smethod_0(1649105869),
			Class16.smethod_0(1649105877),
			Class16.smethod_0(1649105885),
			Class16.smethod_0(1648995827),
			Class16.smethod_0(1648930778),
			Class16.smethod_0(1649130914),
			Class16.smethod_0(1649105893),
			Class16.smethod_0(1649105901),
			Class16.smethod_0(1649105909),
			Class16.smethod_0(1649105917),
			Class16.smethod_0(1649104901),
			Class16.smethod_0(1648915562),
			Class16.smethod_0(1648915585),
			Class16.smethod_0(1649104909),
			Class16.smethod_0(1649105901),
			Class16.smethod_0(1648916476),
			Class16.smethod_0(1648915467)
		});
		this.comboBox_9.Location = new System.Drawing.Point(189, 73);
		this.comboBox_9.Name = Class16.smethod_0(1649104917);
		this.comboBox_9.Size = new System.Drawing.Size(42, 21);
		this.comboBox_9.TabIndex = 16;
		this.comboBox_9.SelectedIndexChanged += new System.EventHandler(comboBox_5_SelectedIndexChanged);
		this.label_3.AutoSize = true;
		this.label_3.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_3.Location = new System.Drawing.Point(174, 73);
		this.label_3.Name = Class16.smethod_0(1649104944);
		this.label_3.Size = new System.Drawing.Size(17, 18);
		this.label_3.TabIndex = 15;
		this.label_3.Text = Class16.smethod_0(1648941500);
		this.comboBox_4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.comboBox_4.FormattingEnabled = true;
		this.comboBox_4.Items.AddRange(new object[2]
		{
			Class16.smethod_0(1649104967),
			Class16.smethod_0(1649104969)
		});
		this.comboBox_4.Location = new System.Drawing.Point(87, 73);
		this.comboBox_4.Name = Class16.smethod_0(1649104991);
		this.comboBox_4.Size = new System.Drawing.Size(87, 21);
		this.comboBox_4.TabIndex = 14;
		this.comboBox_4.SelectedIndexChanged += new System.EventHandler(comboBox_5_SelectedIndexChanged);
		this.label_4.AutoSize = true;
		this.label_4.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_4.ForeColor = System.Drawing.Color.Black;
		this.label_4.Location = new System.Drawing.Point(11, 74);
		this.label_4.Name = Class16.smethod_0(1649105028);
		this.label_4.Size = new System.Drawing.Size(69, 15);
		this.label_4.TabIndex = 17;
		this.label_4.Text = Class16.smethod_0(1649105035);
		this.comboBox_11.DropDownHeight = 100;
		this.comboBox_11.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.comboBox_11.FormattingEnabled = true;
		this.comboBox_11.IntegralHeight = false;
		this.comboBox_11.ItemHeight = 13;
		this.comboBox_11.Items.AddRange(new object[26]
		{
			Class16.smethod_0(1648915780),
			Class16.smethod_0(1648915795),
			Class16.smethod_0(1648915818),
			Class16.smethod_0(1649105837),
			Class16.smethod_0(1649105845),
			Class16.smethod_0(1648995835),
			Class16.smethod_0(1649105853),
			Class16.smethod_0(1649105861),
			Class16.smethod_0(1648979963),
			Class16.smethod_0(1649105869),
			Class16.smethod_0(1649105877),
			Class16.smethod_0(1649105885),
			Class16.smethod_0(1648995827),
			Class16.smethod_0(1648930778),
			Class16.smethod_0(1649130914),
			Class16.smethod_0(1649105893),
			Class16.smethod_0(1649105901),
			Class16.smethod_0(1649105909),
			Class16.smethod_0(1649105917),
			Class16.smethod_0(1649104901),
			Class16.smethod_0(1648915562),
			Class16.smethod_0(1648915585),
			Class16.smethod_0(1649104909),
			Class16.smethod_0(1649105901),
			Class16.smethod_0(1648916476),
			Class16.smethod_0(1648915467)
		});
		this.comboBox_11.Location = new System.Drawing.Point(189, 46);
		this.comboBox_11.Name = Class16.smethod_0(1649105061);
		this.comboBox_11.Size = new System.Drawing.Size(42, 21);
		this.comboBox_11.TabIndex = 12;
		this.comboBox_11.SelectedIndexChanged += new System.EventHandler(comboBox_5_SelectedIndexChanged);
		this.label_67.AutoSize = true;
		this.label_67.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_67.Location = new System.Drawing.Point(174, 46);
		this.label_67.Name = Class16.smethod_0(1649105088);
		this.label_67.Size = new System.Drawing.Size(17, 18);
		this.label_67.TabIndex = 11;
		this.label_67.Text = Class16.smethod_0(1648941500);
		this.comboBox_6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.comboBox_6.FormattingEnabled = true;
		this.comboBox_6.Items.AddRange(new object[2]
		{
			Class16.smethod_0(1649104967),
			Class16.smethod_0(1649104969)
		});
		this.comboBox_6.Location = new System.Drawing.Point(87, 46);
		this.comboBox_6.Name = Class16.smethod_0(1649105110);
		this.comboBox_6.Size = new System.Drawing.Size(87, 21);
		this.comboBox_6.TabIndex = 10;
		this.comboBox_6.SelectedIndexChanged += new System.EventHandler(comboBox_5_SelectedIndexChanged);
		this.label_83.AutoSize = true;
		this.label_83.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_83.ForeColor = System.Drawing.Color.Black;
		this.label_83.Location = new System.Drawing.Point(17, 47);
		this.label_83.Name = Class16.smethod_0(1649105139);
		this.label_83.Size = new System.Drawing.Size(63, 15);
		this.label_83.TabIndex = 13;
		this.label_83.Text = Class16.smethod_0(1649105153);
		this.comboBox_10.DropDownHeight = 100;
		this.comboBox_10.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.comboBox_10.FormattingEnabled = true;
		this.comboBox_10.IntegralHeight = false;
		this.comboBox_10.ItemHeight = 13;
		this.comboBox_10.Items.AddRange(new object[26]
		{
			Class16.smethod_0(1648915780),
			Class16.smethod_0(1648915795),
			Class16.smethod_0(1648915818),
			Class16.smethod_0(1649105837),
			Class16.smethod_0(1649105845),
			Class16.smethod_0(1648995835),
			Class16.smethod_0(1649105853),
			Class16.smethod_0(1649105861),
			Class16.smethod_0(1648979963),
			Class16.smethod_0(1649105869),
			Class16.smethod_0(1649105877),
			Class16.smethod_0(1649105885),
			Class16.smethod_0(1648995827),
			Class16.smethod_0(1648930778),
			Class16.smethod_0(1649130914),
			Class16.smethod_0(1649105893),
			Class16.smethod_0(1649105901),
			Class16.smethod_0(1649105909),
			Class16.smethod_0(1649105917),
			Class16.smethod_0(1649104901),
			Class16.smethod_0(1648915562),
			Class16.smethod_0(1648915585),
			Class16.smethod_0(1649104909),
			Class16.smethod_0(1649105901),
			Class16.smethod_0(1648916476),
			Class16.smethod_0(1648915467)
		});
		this.comboBox_10.Location = new System.Drawing.Point(189, 19);
		this.comboBox_10.Name = Class16.smethod_0(1649105169);
		this.comboBox_10.Size = new System.Drawing.Size(42, 21);
		this.comboBox_10.TabIndex = 8;
		this.comboBox_10.SelectedIndexChanged += new System.EventHandler(comboBox_5_SelectedIndexChanged);
		this.label_49.AutoSize = true;
		this.label_49.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_49.Location = new System.Drawing.Point(174, 19);
		this.label_49.Name = Class16.smethod_0(1649105207);
		this.label_49.Size = new System.Drawing.Size(17, 18);
		this.label_49.TabIndex = 7;
		this.label_49.Text = Class16.smethod_0(1648941500);
		this.comboBox_5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.comboBox_5.FormattingEnabled = true;
		this.comboBox_5.Items.AddRange(new object[2]
		{
			Class16.smethod_0(1649104967),
			Class16.smethod_0(1649104969)
		});
		this.comboBox_5.Location = new System.Drawing.Point(87, 19);
		this.comboBox_5.Name = Class16.smethod_0(1649105221);
		this.comboBox_5.Size = new System.Drawing.Size(87, 21);
		this.comboBox_5.TabIndex = 6;
		this.comboBox_5.SelectedIndexChanged += new System.EventHandler(comboBox_5_SelectedIndexChanged);
		this.label_54.AutoSize = true;
		this.label_54.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.label_54.ForeColor = System.Drawing.Color.Black;
		this.label_54.Location = new System.Drawing.Point(23, 20);
		this.label_54.Name = Class16.smethod_0(1649105253);
		this.label_54.Size = new System.Drawing.Size(57, 15);
		this.label_54.TabIndex = 9;
		this.label_54.Text = Class16.smethod_0(1649105259);
		this.comboBox_16.DropDownHeight = 150;
		this.comboBox_16.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.comboBox_16.FormattingEnabled = true;
		this.comboBox_16.IntegralHeight = false;
		this.comboBox_16.Location = new System.Drawing.Point(292, 2);
		this.comboBox_16.Name = Class16.smethod_0(1649105275);
		this.comboBox_16.Size = new System.Drawing.Size(107, 21);
		this.comboBox_16.TabIndex = 16;
		this.button_1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.button_1.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 8.5f);
		this.button_1.ForeColor = System.Drawing.Color.Black;
		this.button_1.Image = ACE.Properties.Resources.NpcGenEditorForm_ConvertAndSaveButton;
		this.button_1.Location = new System.Drawing.Point(175, 423);
		this.button_1.Name = Class16.smethod_0(1649105298);
		this.button_1.Size = new System.Drawing.Size(207, 60);
		this.button_1.TabIndex = 17;
		this.button_1.Text = Class16.smethod_0(1649105333);
		this.button_1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		this.button_1.UseVisualStyleBackColor = true;
		this.button_1.Click += new System.EventHandler(button_1_Click);
		this.button_23.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.button_23.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 8.5f);
		this.button_23.ForeColor = System.Drawing.Color.Black;
		this.button_23.Image = ACE.Properties.Resources.NpcGenEditorForm_SaveFile;
		this.button_23.Location = new System.Drawing.Point(3, 423);
		this.button_23.Name = Class16.smethod_0(1649105367);
		this.button_23.Size = new System.Drawing.Size(169, 60);
		this.button_23.TabIndex = 7;
		this.button_23.Text = Class16.smethod_0(1649105382);
		this.button_23.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		this.button_23.UseVisualStyleBackColor = true;
		this.button_23.Click += new System.EventHandler(button_23_Click);
		this.comboBox_12.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.comboBox_12.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
		this.comboBox_12.DropDownHeight = 150;
		this.comboBox_12.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.comboBox_12.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.comboBox_12.FormattingEnabled = true;
		this.comboBox_12.IntegralHeight = false;
		this.comboBox_12.Location = new System.Drawing.Point(882, 5);
		this.comboBox_12.Name = Class16.smethod_0(1649105405);
		this.comboBox_12.Size = new System.Drawing.Size(94, 21);
		this.comboBox_12.TabIndex = 220;
		this.openFileDialog_1.FileName = Class16.smethod_0(1649100297);
		this.openFileDialog_1.Filter = Class16.smethod_0(1649100325);
		this.openFileDialog_2.FileName = Class16.smethod_0(1649100360);
		this.openFileDialog_2.Filter = Class16.smethod_0(1649100378);
		this.label_42.AutoSize = true;
		this.label_42.Location = new System.Drawing.Point(5, 57);
		this.label_42.Name = Class16.smethod_0(1648912200);
		this.label_42.Size = new System.Drawing.Size(73, 13);
		this.label_42.TabIndex = 12;
		this.label_42.Text = Class16.smethod_0(1649100417);
		this.textBox_37.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.textBox_37.Location = new System.Drawing.Point(75, 54);
		this.textBox_37.Name = Class16.smethod_0(1649100445);
		this.textBox_37.Size = new System.Drawing.Size(687, 20);
		this.textBox_37.TabIndex = 13;
		this.openFileDialog_3.FileName = Class16.smethod_0(1649100457);
		this.openFileDialog_3.Filter = Class16.smethod_0(1649100484);
		this.saveFileDialog_0.FileName = Class16.smethod_0(1649100360);
		this.saveFileDialog_0.Filter = Class16.smethod_0(1649100378);
		this.button_0.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.button_0.BackColor = System.Drawing.Color.FromArgb(192, 255, 255);
		this.button_0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.button_0.Location = new System.Drawing.Point(882, 28);
		this.button_0.Name = Class16.smethod_0(1649100541);
		this.button_0.Size = new System.Drawing.Size(96, 24);
		this.button_0.TabIndex = 1;
		this.button_0.Text = Class16.smethod_0(1649100553);
		this.button_0.UseVisualStyleBackColor = false;
		this.button_0.Click += new System.EventHandler(button_0_Click);
		this.progressBar_1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.progressBar_1.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);
		this.progressBar_1.Location = new System.Drawing.Point(882, 53);
		this.progressBar_1.Name = Class16.smethod_0(1649100568);
		this.progressBar_1.Size = new System.Drawing.Size(95, 22);
		this.progressBar_1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
		this.progressBar_1.TabIndex = 0;
		this.openFileDialog_0.FileName = Class16.smethod_0(1649100586);
		this.openFileDialog_0.Filter = Class16.smethod_0(1649100620);
		this.button_15.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.button_15.ForeColor = System.Drawing.Color.Black;
		this.button_15.Image = ACE.Properties.Resources.NpcGenEditorForm_OpenFiles;
		this.button_15.Location = new System.Drawing.Point(791, 29);
		this.button_15.Name = Class16.smethod_0(1649100667);
		this.button_15.Size = new System.Drawing.Size(90, 45);
		this.button_15.TabIndex = 6;
		this.button_15.Text = Class16.smethod_0(1648931498);
		this.button_15.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		this.button_15.UseVisualStyleBackColor = true;
		this.button_15.Click += new System.EventHandler(button_15_Click);
		this.button_24.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.button_24.BackColor = System.Drawing.SystemColors.Control;
		this.button_24.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.button_24.Image = ACE.Properties.Resources.NpcGenEditorForm_Search_Npcgen;
		this.button_24.Location = new System.Drawing.Point(762, 30);
		this.button_24.Name = Class16.smethod_0(1649100683);
		this.button_24.Size = new System.Drawing.Size(26, 20);
		this.button_24.TabIndex = 5;
		this.button_24.UseVisualStyleBackColor = false;
		this.button_24.Click += new System.EventHandler(button_24_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
		this.BackColor = System.Drawing.Color.FromArgb(239, 244, 250);
		base.ClientSize = new System.Drawing.Size(981, 614);
		base.Controls.Add(this.progressBar_1);
		base.Controls.Add(this.comboBox_12);
		base.Controls.Add(this.button_0);
		base.Controls.Add(this.textBox_37);
		base.Controls.Add(this.label_42);
		base.Controls.Add(this.tabControl_0);
		base.Controls.Add(this.progressBar_0);
		base.Controls.Add(this.button_15);
		base.Controls.Add(this.button_24);
		base.Controls.Add(this.textBox_21);
		base.Controls.Add(this.label_1);
		this.Font = new System.Drawing.Font(Class16.smethod_0(1648929920), 8.25f);
		base.Icon = ACE.Properties.Resources.edit;
		this.MinimumSize = new System.Drawing.Size(997, 650);
		base.Name = Class16.smethod_0(1649100711);
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = Class16.smethod_0(1649115628);
		base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(NPCGenEditorForm_FormClosed);
		base.Load += new System.EventHandler(NPCGenEditorForm_Load);
		base.Activated += new System.EventHandler(NPCGenEditorForm_Activated);
		this.tabControl_0.ResumeLayout(false);
		this.tabPage_2.ResumeLayout(false);
		this.groupBox_0.ResumeLayout(false);
		this.groupBox_0.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown_14).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown_20).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown_12).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown_16).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown_11).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dataGridView_5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown_26).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown_27).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown_17).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown_18).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown_13).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown_21).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown_10).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown_15).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dataGridView_4).EndInit();
		this.contextMenuStrip_2.ResumeLayout(false);
		this.groupBox_20.ResumeLayout(false);
		this.groupBox_20.PerformLayout();
		this.groupBox_18.ResumeLayout(false);
		this.groupBox_18.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown_4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown_2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown_3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown_5).EndInit();
		this.contextMenuStrip_1.ResumeLayout(false);
		this.toolStrip_0.ResumeLayout(false);
		this.toolStrip_0.PerformLayout();
		this.tabPage_4.ResumeLayout(false);
		this.groupBox_15.ResumeLayout(false);
		this.groupBox_15.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown_25).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown_22).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown_24).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown_19).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown_23).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dataGridView_7).EndInit();
		this.groupBox_14.ResumeLayout(false);
		this.groupBox_14.PerformLayout();
		this.groupBox_2.ResumeLayout(false);
		this.groupBox_2.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown_8).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown_6).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown_7).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown_9).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dataGridView_6).EndInit();
		this.toolStrip_1.ResumeLayout(false);
		this.toolStrip_1.PerformLayout();
		this.tabPage_0.ResumeLayout(false);
		this.groupBox_19.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.pictureBox_0).EndInit();
		this.groupBox_17.ResumeLayout(false);
		this.groupBox_17.PerformLayout();
		this.groupBox_1.ResumeLayout(false);
		this.groupBox_1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown_1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numericUpDown_0).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dataGridView_1).EndInit();
		this.toolStrip_2.ResumeLayout(false);
		this.toolStrip_2.PerformLayout();
		this.tabPage_6.ResumeLayout(false);
		this.groupBox_6.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.dataGridView_0).EndInit();
		this.groupBox_5.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.dataGridView_8).EndInit();
		this.groupBox_4.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.dataGridView_3).EndInit();
		this.groupBox_3.ResumeLayout(false);
		this.groupBox_3.PerformLayout();
		this.groupBox_8.ResumeLayout(false);
		this.groupBox_8.PerformLayout();
		this.groupBox_7.ResumeLayout(false);
		this.groupBox_7.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.dataGridView_10).EndInit();
		this.contextMenuStrip_3.ResumeLayout(false);
		this.toolStrip_3.ResumeLayout(false);
		this.toolStrip_3.PerformLayout();
		this.tabPage_5.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.dataGridView_9).EndInit();
		this.contextMenuStrip_0.ResumeLayout(false);
		this.groupBox_12.ResumeLayout(false);
		this.groupBox_12.PerformLayout();
		this.groupBox_11.ResumeLayout(false);
		this.groupBox_11.PerformLayout();
		this.groupBox_10.ResumeLayout(false);
		this.groupBox_10.PerformLayout();
		this.groupBox_9.ResumeLayout(false);
		this.groupBox_9.PerformLayout();
		this.tabPage_1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.dataGridView_2).EndInit();
		this.tabPage_3.ResumeLayout(false);
		this.tabPage_3.PerformLayout();
		this.groupBox_13.ResumeLayout(false);
		this.groupBox_16.ResumeLayout(false);
		this.groupBox_16.PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	private static eListCollection smethod_0()
	{
		return ItemsToolTip.eLC;
	}

	private static bool smethod_1(ItemType itemType_0, int int_9, out string string_0)
	{
		string_0 = null;
		eListCollection eListCollection2 = smethod_0();
		if (eListCollection2 != null && int_9 > 0)
		{
			try
			{
				ITEMPOS iTEMPOS = eListCollection2.FindItemPos(eListCollection2.GetLists(itemType_0), int_9);
				if (iTEMPOS == null)
				{
					return false;
				}
				string_0 = eListCollection2.GetItemInfo(iTEMPOS, bUseCache: true, bCheckIsFreeID: true, bCheckHasReferences: true)?.name;
				return !string.IsNullOrEmpty(string_0);
			}
			catch
			{
				return false;
			}
		}
		return false;
	}

	private static string smethod_2(ItemType itemType_0, int int_9)
	{
		if (!smethod_1(itemType_0, int_9, out var string_))
		{
			return Class16.smethod_0(1648936686);
		}
		return string_;
	}

	private int method_0(ItemType itemType_0, int int_9)
	{
		if (!ACE.MainWindow.MainWindow.IsMainWindowRunning())
		{
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649100734)), Class16.smethod_0(1649115628), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			return 0;
		}
		if (smethod_0() == null)
		{
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649100763)), Class16.smethod_0(1649115628), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			return 0;
		}
		return ACE.MainWindow.MainWindow.ShowSelectItemDialog(itemType_0, int_9, this);
	}

	private void method_1(Control control_0, ItemType itemType_0, int int_9)
	{
		if (control_0 != null && int_9 > 0 && HINTS.ToolTipWindow != null)
		{
			HINTS.ToolTipWindow.SetOwnerHandle(control_0.Handle);
			HINTS.ToolTipWindow.ShowItemToolTip(int_9, itemType_0);
		}
	}

	private void method_2()
	{
		HINTS.ToolTipWindow?.SmoothHide();
	}

	private bool method_3()
	{
		return Environment.TickCount - int_8 < 0;
	}

	private void method_4(int int_9)
	{
		int_8 = Environment.TickCount + Math.Max(0, int_9);
	}

	private void dataGridView_0_Scroll(object sender, ScrollEventArgs e)
	{
		method_4(300);
		try
		{
			HINTS.ToolTipWindow?.Hide();
		}
		catch
		{
		}
		if (sender is DataGridView dataGridView)
		{
			dataGridView.Invalidate();
		}
	}

	[DllImport("kernel32.dll")]
	public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

	public ClassPosition GetCoordinates()
	{
		string[] array = new string[3]
		{
			Class16.smethod_0(1649099780),
			Class16.smethod_0(1649099795),
			Class16.smethod_0(1649099831)
		};
		Process[] array2 = Array.Empty<Process>();
		string[] array3 = array;
		foreach (string processName in array3)
		{
			array2 = Process.GetProcessesByName(processName);
			if (array2.Length != 0)
			{
				break;
			}
		}
		if (array2.Length == 0)
		{
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649099843)), Class16.smethod_0(1649115628), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			return null;
		}
		if (comboBox_16.SelectedIndex >= 0 && comboBox_16.SelectedIndex < Offsets.Count)
		{
			int id = array2[0].Id;
			offsets offsets2 = Offsets[comboBox_16.SelectedIndex];
			long num = 0L;
			int num2 = 0;
			while (true)
			{
				if (num2 < 3)
				{
					long num3 = method_10(id, num + offsets2.baseChain[num2]);
					if (num3 == 0L)
					{
						break;
					}
					num = num3;
					num2++;
					continue;
				}
				float float_ = method_9(id, num + offsets2.posX);
				float float_2 = method_9(id, num + offsets2.posY);
				float float_3 = method_9(id, num + offsets2.posZ);
				float dX = method_9(id, num + offsets2.dirX);
				float dY = method_9(id, num + offsets2.dirY);
				float dZ = method_9(id, num + offsets2.dirZ);
				return new ClassPosition(float_, float_2, float_3, dX, dY, dZ);
			}
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649099981)), Class16.smethod_0(1649115628), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return null;
		}
		DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649099873), Class16.smethod_0(1649099910)), Class16.smethod_0(1649115628), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		return null;
	}

	public string GetDynamicName(int Id)
	{
		Class263 @class = new Class263();
		@class.int_0 = Id;
		string result = Class16.smethod_0(1648942867);
		int num = list_1.FindIndex(@class.method_0);
		if (num != -1)
		{
			result = list_1[num].Name;
		}
		return result;
	}

	public void RefreshResourcesRow(int index)
	{
		int[] array = new int[npcGen_0.ResourcesList[index].Amount_in_group];
		string[] array2 = new string[npcGen_0.ResourcesList[index].Amount_in_group];
		for (int i = 0; i < npcGen_0.ResourcesList[index].Amount_in_group; i++)
		{
			array[i] = npcGen_0.ResourcesList[index].ResExtra[i].Id;
			if (ItemsToolTip.eLC != null && array[i] != 0)
			{
				array2[i] = smethod_2(ItemType.NpcOrMobOrMine, array[i]);
			}
			else
			{
				array2[i] = Class16.smethod_0(1648942867);
			}
		}
		dataGridView_6.Rows[index].Cells[1].Value = string.Join(Class16.smethod_0(1648928028), array);
		dataGridView_6.Rows[index].Cells[2].Value = string.Join(Class16.smethod_0(1648928028), array2);
	}

	private void method_5(Control control_0, ref List<Control> list_20)
	{
		foreach (Control control in control_0.Controls)
		{
			method_5(control, ref list_20);
			if (control is TabPage || control is GroupBox || control is RadioButton)
			{
				list_20.Add(control);
			}
		}
	}

	private void method_6(Control control_0, ref List<Control> list_20)
	{
		foreach (Control control in control_0.Controls)
		{
			method_6(control, ref list_20);
			if (control is Label || control is RadioButton || control is GroupBox)
			{
				list_20.Add(control);
			}
		}
	}

	private void method_7(Control control_0, ref List<Control> list_20)
	{
		foreach (Control control in control_0.Controls)
		{
			method_7(control, ref list_20);
			if (control is TextBox)
			{
				list_20.Add(control);
			}
		}
	}

	private List<PointF> method_8(int int_9)
	{
		List<PointF> list = new List<PointF>();
		switch (int_9)
		{
		case 1:
			foreach (int item in list_10)
			{
				list.Add(new PointF(npcGen_0.NpcMobList[item].X_position, npcGen_0.NpcMobList[item].Z_position));
			}
			break;
		case 2:
			foreach (int item2 in list_12)
			{
				list.Add(new PointF(npcGen_0.ResourcesList[item2].X_position, npcGen_0.ResourcesList[item2].Z_position));
			}
			break;
		case 3:
			foreach (int item3 in list_3)
			{
				list.Add(new PointF(npcGen_0.DynamicsList[item3].X_position, npcGen_0.DynamicsList[item3].Z_position));
			}
			break;
		}
		return list;
	}

	private void button_12_Click(object sender, EventArgs e)
	{
		try
		{
			if (dataGridView_0.SelectedRows.Count != 0)
			{
				dataGridView_1.ClearSelection();
				dataGridView_1.CurrentCell = dataGridView_1.Rows[npcGen_0.DynamicsList.IndexOf(list_0[dataGridView_0.SelectedRows[dataGridView_0.SelectedRows.Count - 1].Index])].Cells[1];
				for (int i = 0; i < dataGridView_0.SelectedRows.Count; i++)
				{
					dataGridView_1.Rows[npcGen_0.DynamicsList.IndexOf(list_0[dataGridView_0.SelectedRows[i].Index])].Selected = true;
				}
				tabControl_0.SelectedIndex = 2;
			}
		}
		catch
		{
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649100013)), Class16.smethod_0(1649115628), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
	}

	private void button_13_Click(object sender, EventArgs e)
	{
		try
		{
			if (dataGridView_3.SelectedRows.Count != 0)
			{
				dataGridView_4.ClearSelection();
				dataGridView_4.CurrentCell = dataGridView_4.Rows[npcGen_0.NpcMobList.IndexOf(list_9[dataGridView_3.SelectedRows[dataGridView_3.SelectedRows.Count - 1].Index])].Cells[1];
				for (int i = 0; i < dataGridView_3.SelectedRows.Count; i++)
				{
					dataGridView_4.Rows[npcGen_0.NpcMobList.IndexOf(list_9[dataGridView_3.SelectedRows[i].Index])].Selected = true;
				}
				dataGridView_4_CurrentCellChanged(null, null);
				tabControl_0.SelectedIndex = 0;
			}
		}
		catch
		{
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649100013)), Class16.smethod_0(1649115628), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
	}

	private void button_14_Click(object sender, EventArgs e)
	{
		try
		{
			if (dataGridView_8.SelectedRows.Count != 0)
			{
				dataGridView_6.ClearSelection();
				dataGridView_6.CurrentCell = dataGridView_6.Rows[npcGen_0.ResourcesList.IndexOf(list_11[dataGridView_8.SelectedRows[dataGridView_8.SelectedRows.Count - 1].Index])].Cells[1];
				for (int i = 0; i < dataGridView_8.SelectedRows.Count; i++)
				{
					dataGridView_6.Rows[npcGen_0.ResourcesList.IndexOf(list_11[dataGridView_8.SelectedRows[i].Index])].Selected = true;
				}
				tabControl_0.SelectedIndex = 1;
			}
		}
		catch
		{
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649100013)), Class16.smethod_0(1649115628), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
	}

	private void dataGridView_10_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.W && Control.ModifierKeys == Keys.Shift)
		{
			toolStripMenuItem_20_Click(null, null);
		}
		if (e.KeyCode == Keys.S && Control.ModifierKeys == Keys.Shift)
		{
			toolStripMenuItem_21_Click(null, null);
		}
	}

	private void numericUpDown_15_DoubleClick(object sender, EventArgs e)
	{
		int num = method_0(ItemType.NpcOrMobOrMine, Convert.ToInt32(numericUpDown_15.Value));
		if (num > 0)
		{
			numericUpDown_15.Value = num;
			SetId(num, 1, 1);
		}
	}

	private void numericUpDown_15_MouseEnter(object sender, EventArgs e)
	{
		if (int.TryParse(numericUpDown_15.Value.ToString(), out var result) && result > 0)
		{
			method_1(numericUpDown_15, ItemType.NpcOrMobOrMine, result);
		}
	}

	private void numericUpDown_15_MouseLeave(object sender, EventArgs e)
	{
		method_2();
	}

	private void numericUpDown_15_MouseMove(object sender, MouseEventArgs e)
	{
		if (int.TryParse(numericUpDown_15.Value.ToString(), out var result) && result > 0)
		{
			method_1(numericUpDown_15, ItemType.NpcOrMobOrMine, result);
		}
	}

	private static int smethod_3<T>(int int_9, IList<T> ilist_0)
	{
		if (int_9 > 0 && ilist_0 != null)
		{
			return Math.Min(int_9, ilist_0.Count);
		}
		return 0;
	}

	public void RefreshRowNpcAndMobs(int index)
	{
		int num = smethod_3(npcGen_0.NpcMobList[index].Amount_in_group, npcGen_0.NpcMobList[index].MobDops);
		int[] array = new int[num];
		string[] array2 = new string[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = npcGen_0.NpcMobList[index].MobDops[i].Id;
			if (ItemsToolTip.eLC != null && array[i] != 0)
			{
				array2[i] = smethod_2(ItemType.NpcOrMobOrMine, array[i]);
			}
			else
			{
				array2[i] = Class16.smethod_0(1648942867);
			}
		}
		dataGridView_4.Rows[index].Cells[1].Value = string.Join(Class16.smethod_0(1648928028), array);
		dataGridView_4.Rows[index].Cells[2].Value = string.Join(Class16.smethod_0(1648928028), array2);
	}

	public void SetId(int Id, int act, int Window)
	{
		if (act == 1 && Window == 1)
		{
			numericUpDown_15.Value = Id;
			numericUpDown_15_Leave(numericUpDown_15, null);
		}
		else if (act == 1 && Window == 2)
		{
			textBox_13.Text = Id.ToString();
			textBox_13_TextChanged(null, null);
		}
		else if (act == 2 && Window == 1)
		{
			numericUpDown_23.Value = Id;
			numericUpDown_23_Leave(numericUpDown_23, null);
		}
		else if (act == 2 && Window == 2)
		{
			textBox_23.Text = Id.ToString();
			textBox_23_TextChanged(null, null);
		}
		else if (act == 3 && Window == 1)
		{
			textBox_0.Text = Id.ToString();
			textBox_7_Leave(textBox_0, null);
		}
		else if (act == 3 && Window == 2)
		{
			textBox_9.Text = Id.ToString();
			textBox_9_TextChanged(null, null);
		}
	}

	public void ShowWrongFile()
	{
		DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649100039)), Class16.smethod_0(1649115628), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
	}

	public void SortDynamicObjects()
	{
		for (int i = 0; i < npcGen_0.DynobjectAmount; i++)
		{
			dataGridView_1.Rows.Add(i + 1, npcGen_0.DynamicsList[i].Id, GetDynamicName(npcGen_0.DynamicsList[i].Id), npcGen_0.DynamicsList[i].TriggerId);
		}
		if (dataGridView_1.Rows.Count != 0)
		{
			dataGridView_1.CurrentCell = dataGridView_1.Rows[0].Cells[1];
			dataGridView_1_CurrentCellChanged(null, null);
		}
	}

	public void SortNpcGen()
	{
		for (int i = 0; i < npcGen_0.NpcMobsAmount; i++)
		{
			int num = smethod_3(npcGen_0.NpcMobList[i].Amount_in_group, npcGen_0.NpcMobList[i].MobDops);
			int[] array = new int[num];
			string[] array2 = new string[num];
			for (int j = 0; j < num; j++)
			{
				array[j] = npcGen_0.NpcMobList[i].MobDops[j].Id;
				if (ItemsToolTip.eLC == null)
				{
					array2[j] = Class16.smethod_0(1648942867);
				}
				else if (array[j] != 0)
				{
					array2[j] = smethod_2(ItemType.NpcOrMobOrMine, array[j]);
				}
				else
				{
					array2[j] = Class16.smethod_0(1648936686);
				}
			}
			dataGridView_4.Rows.Add(i + 1, string.Join(Class16.smethod_0(1648928028), array), string.Join(Class16.smethod_0(1648928028), array2));
			if (npcGen_0.NpcMobList[i].Type == 1)
			{
				dataGridView_4.Rows[i].Cells[1].Style.ForeColor = Color.FromArgb(251, 251, 107);
				dataGridView_4.Rows[i].Cells[2].Style.ForeColor = Color.FromArgb(251, 251, 107);
			}
			method_26();
		}
		dataGridView_4_CurrentCellChanged(null, null);
		for (int k = 0; k < npcGen_0.ResourcesAmount; k++)
		{
			int num2 = smethod_3(npcGen_0.ResourcesList[k].Amount_in_group, npcGen_0.ResourcesList[k].ResExtra);
			int[] array3 = new int[num2];
			string[] array4 = new string[num2];
			for (int l = 0; l < num2; l++)
			{
				array3[l] = npcGen_0.ResourcesList[k].ResExtra[l].Id;
				if (ItemsToolTip.eLC == null)
				{
					array4[l] = Class16.smethod_0(1648942867);
				}
				else if (array3[l] != 0)
				{
					array4[l] = smethod_2(ItemType.NpcOrMobOrMine, array3[l]);
				}
				else
				{
					array4[l] = Class16.smethod_0(1648936686);
				}
			}
			dataGridView_6.Rows.Add(k + 1, string.Join(Class16.smethod_0(1648928028), array3), string.Join(Class16.smethod_0(1648928028), array4));
			method_26();
		}
		method_25(progressBar_0.Maximum);
		if (dataGridView_6.Rows.Count != 0)
		{
			dataGridView_6.CurrentCell = dataGridView_6.Rows[0].Cells[1];
		}
		if (dataGridView_7.Rows.Count != 0)
		{
			dataGridView_7.CurrentCell = dataGridView_7.Rows[0].Cells[1];
		}
	}

	public void SortTriggers()
	{
		for (int i = 0; i < npcGen_0.TriggersAmount; i++)
		{
			dataGridView_10.Rows.Add(i + 1, npcGen_0.TriggersList[i].Id, npcGen_0.TriggersList[i].GmID, npcGen_0.TriggersList[i].TriggerName);
		}
		if (dataGridView_10.Rows.Count != 0)
		{
			dataGridView_10.CurrentCell = dataGridView_10.Rows[0].Cells[1];
		}
		dataGridView_10_CurrentCellChanged(null, null);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	[DllImport("Kernel32.dll")]
	private static extern bool ReadProcessMemory(IntPtr intptr_0, IntPtr intptr_1, byte[] byte_0, int int_9, int int_10);

	private void button_15_Click(object sender, EventArgs e)
	{
		if (File.Exists(textBox_21.Text))
		{
			EditorSessionTracker.LogFolderAccess(textBox_21.Text, Class16.smethod_0(1648903793), Class16.smethod_0(1648906400));
			npcGen_0 = new ACE.NpcGen.Classes.NpcGen();
			FileStream fileStream = new FileStream(textBox_21.Text, FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete);
			try
			{
				BinaryReader binaryReader = new BinaryReader(fileStream);
				try
				{
					npcGen_0.ReadNpcgen(binaryReader);
				}
				finally
				{
					((IDisposable)binaryReader).Dispose();
				}
			}
			finally
			{
				((IDisposable)fileStream).Dispose();
			}
			Text = string.Format(Class16.smethod_0(1649100063), textBox_21.Text, npcGen_0.File_version);
			dataGridView_4.ScrollBars = ScrollBars.None;
			dataGridView_6.ScrollBars = ScrollBars.None;
			dataGridView_1.ScrollBars = ScrollBars.None;
			dataGridView_10.ScrollBars = ScrollBars.None;
			dataGridView_4.Rows.Clear();
			dataGridView_6.Rows.Clear();
			dataGridView_1.Rows.Clear();
			dataGridView_10.Rows.Clear();
			dataGridView_2.Rows.Clear();
			progressBar_0.Maximum = Math.Max(1, npcGen_0.NpcMobsAmount + npcGen_0.ResourcesAmount + npcGen_0.DynobjectAmount + npcGen_0.TriggersAmount);
			SortNpcGen();
			SortDynamicObjects();
			SortTriggers();
			dataGridView_4.ScrollBars = ScrollBars.Vertical;
			dataGridView_6.ScrollBars = ScrollBars.Vertical;
			dataGridView_1.ScrollBars = ScrollBars.Vertical;
			dataGridView_10.ScrollBars = ScrollBars.Vertical;
			tabPage_2.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1649100099), Class16.smethod_0(1649100128)), npcGen_0.NpcMobsAmount);
			tabPage_4.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1649100154), Class16.smethod_0(1649114403)), npcGen_0.ResourcesAmount);
			tabPage_0.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1649100189), Class16.smethod_0(1649100220)), npcGen_0.DynobjectAmount);
			tabPage_6.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1649100240), Class16.smethod_0(1649100264)), npcGen_0.TriggersAmount);
			if (npcGen_0.File_version <= 6)
			{
				DKBox.Show(Class16.smethod_0(1649099269), Class16.smethod_0(1649115628), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			DialogResult dialogResult = DKBox.Show(Class16.smethod_0(1649099396), Class16.smethod_0(1649115628), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (dialogResult == DialogResult.Yes)
			{
				button_25_Click(null, null);
				tabControl_0.SelectedIndex = 5;
			}
		}
		else
		{
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649099439)), Class16.smethod_0(1649115628), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
	}

	private float method_9(int int_9, long long_0)
	{
		long value = method_10(int_9, long_0);
		return BitConverter.ToSingle(BitConverter.GetBytes(value), 0);
	}

	private long method_10(int int_9, long long_0)
	{
		if (int_9 <= 0)
		{
			return 0L;
		}
		string text = System.IO.Path.Combine(Application.StartupPath, Class16.smethod_0(1649099459));
		if (!File.Exists(text))
		{
			return 0L;
		}
		ProcessStartInfo startInfo = new ProcessStartInfo
		{
			FileName = text,
			Arguments = string.Format(Class16.smethod_0(1649099483), int_9, long_0),
			RedirectStandardOutput = true,
			UseShellExecute = false,
			CreateNoWindow = true
		};
		try
		{
			using Process process = Process.Start(startInfo);
			if (process == null)
			{
				return 0L;
			}
			string text2 = process.StandardOutput.ReadToEnd();
			process.WaitForExit();
			if (long.TryParse((text2 ?? string.Empty).Trim(), out var result))
			{
				return result;
			}
		}
		catch
		{
			return 0L;
		}
		return 0L;
	}

	private void button_16_Click(object sender, EventArgs e)
	{
		if (npcGen_0 == null)
		{
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649114318)), Class16.smethod_0(1649115628), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			return;
		}
		if (list_5 == null)
		{
			list_5 = new List<IntDictionary>();
		}
		if (list_6 == null)
		{
			list_6 = new List<IntDictionary>();
		}
		if (list_4 == null)
		{
			list_4 = new List<IntDictionary>();
		}
		DialogResult dialogResult = DKBox.Show(Class16.smethod_0(1649099499), Class16.smethod_0(1649115628), MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
		if (dialogResult != DialogResult.Yes)
		{
			return;
		}
		dataGridView_4.ScrollBars = ScrollBars.None;
		dataGridView_6.ScrollBars = ScrollBars.None;
		dataGridView_1.ScrollBars = ScrollBars.None;
		dataGridView_2.Rows.Clear();
		List<int> list = new List<int>();
		List<int> list2 = new List<int>();
		List<int> list3 = new List<int>();
		list_5 = list_5.OrderByDescending(Class289.class289_0.method_3).ToList();
		progressBar_0.Maximum = Math.Max(1, list_5.Count + list_6.Count + list_4.Count);
		using (List<IntDictionary>.Enumerator enumerator = list_5.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				Class285 @class = new Class285();
				@class.intDictionary_0 = enumerator.Current;
				if (list.FindIndex(@class.method_0) == -1)
				{
					dataGridView_4.Rows.RemoveAt(@class.intDictionary_0.GridIndex);
					npcGen_0.NpcMobList.RemoveAt(@class.intDictionary_0.GridIndex);
					list.Add(@class.intDictionary_0.GridIndex);
				}
				progressBar_0.Value++;
			}
		}
		npcGen_0.NpcMobsAmount = npcGen_0.NpcMobList.Count;
		list_5.Clear();
		dataGridView_4_CurrentCellChanged(null, null);
		list_6 = list_6.OrderByDescending(Class289.class289_0.method_4).ToList();
		using (List<IntDictionary>.Enumerator enumerator2 = list_6.GetEnumerator())
		{
			while (enumerator2.MoveNext())
			{
				Class261 class2 = new Class261();
				class2.intDictionary_0 = enumerator2.Current;
				if (list2.FindIndex(class2.method_0) == -1)
				{
					dataGridView_6.Rows.RemoveAt(class2.intDictionary_0.GridIndex);
					npcGen_0.ResourcesList.RemoveAt(class2.intDictionary_0.GridIndex);
					list2.Add(class2.intDictionary_0.GridIndex);
				}
				progressBar_0.Value++;
			}
		}
		npcGen_0.ResourcesAmount = npcGen_0.ResourcesList.Count;
		list_6.Clear();
		dataGridView_6_CurrentCellChanged(null, null);
		list_4 = list_4.OrderByDescending(Class289.class289_0.method_5).ToList();
		using (List<IntDictionary>.Enumerator enumerator3 = list_4.GetEnumerator())
		{
			while (enumerator3.MoveNext())
			{
				Class255 class3 = new Class255();
				class3.intDictionary_0 = enumerator3.Current;
				if (list3.FindIndex(class3.method_0) == -1)
				{
					dataGridView_1.Rows.RemoveAt(class3.intDictionary_0.GridIndex);
					npcGen_0.DynamicsList.RemoveAt(class3.intDictionary_0.GridIndex);
					list3.Add(class3.intDictionary_0.GridIndex);
				}
				progressBar_0.Value++;
			}
		}
		dataGridView_4.ScrollBars = ScrollBars.Vertical;
		dataGridView_6.ScrollBars = ScrollBars.Vertical;
		dataGridView_1.ScrollBars = ScrollBars.Vertical;
		if (dataGridView_4.CurrentCell != null)
		{
			dataGridView_4.FirstDisplayedScrollingRowIndex = dataGridView_4.CurrentCell.RowIndex;
		}
		if (dataGridView_6.CurrentCell != null)
		{
			dataGridView_6.FirstDisplayedScrollingRowIndex = dataGridView_6.CurrentCell.RowIndex;
		}
		if (dataGridView_1.CurrentCell != null)
		{
			dataGridView_1.FirstDisplayedScrollingRowIndex = dataGridView_1.CurrentCell.RowIndex;
		}
		npcGen_0.DynobjectAmount = npcGen_0.DynamicsList.Count;
		list_4.Clear();
		dataGridView_1_CurrentCellChanged(null, null);
		progressBar_0.Value = 0;
	}

	private void method_11()
	{
		if (dynamicObjectsForm_0 == null || dynamicObjectsForm_0.IsDisposed)
		{
			dynamicObjectsForm_0 = new DynamicObjectsForm(list_1, this);
		}
	}

	public string GetDynamicNameEn(int Id)
	{
		Class288 @class = new Class288();
		@class.int_0 = Id;
		string result = Class16.smethod_0(1648942867);
		int num = list_1.FindIndex(@class.method_0);
		if (num != -1)
		{
			result = list_1[num].Name;
		}
		return result;
	}

	private void button_6_Click(object sender, EventArgs e)
	{
		if (npcGen_0 == null)
		{
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649114318)), Class16.smethod_0(1649115628), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			return;
		}
		PushUndoSnapshot();
		if (list_10 == null)
		{
			list_10 = new List<int>();
		}
		if (dataGridView_4.Rows.Count > 0)
		{
			dataGridView_4.ScrollBars = ScrollBars.None;
			list_10 = list_10.OrderBy(Class289.class289_0.method_6).ToList();
			foreach (int item3 in list_10)
			{
				npcGen_0.NpcMobsAmount++;
				ClassDefaultMonsters classDefaultMonsters = new ClassDefaultMonsters
				{
					Amount_in_group = npcGen_0.NpcMobList[item3].Amount_in_group,
					bAutoRevive = npcGen_0.NpcMobList[item3].bAutoRevive,
					BInitGen = npcGen_0.NpcMobList[item3].BInitGen,
					BValicOnce = npcGen_0.NpcMobList[item3].BValicOnce,
					dwGenId = npcGen_0.NpcMobList[item3].dwGenId,
					iGroupType = npcGen_0.NpcMobList[item3].iGroupType,
					MaxRespawnTime = npcGen_0.NpcMobList[item3].MaxRespawnTime,
					Type = npcGen_0.NpcMobList[item3].Type,
					Life_time = npcGen_0.NpcMobList[item3].Life_time,
					Trigger_id = npcGen_0.NpcMobList[item3].Trigger_id,
					Location = npcGen_0.NpcMobList[item3].Location,
					X_direction = npcGen_0.NpcMobList[item3].X_direction,
					X_position = npcGen_0.NpcMobList[item3].X_position,
					X_random = npcGen_0.NpcMobList[item3].X_random,
					Y_direction = npcGen_0.NpcMobList[item3].Y_direction,
					Y_position = npcGen_0.NpcMobList[item3].Y_position,
					Y_random = npcGen_0.NpcMobList[item3].Y_random,
					Z_direction = npcGen_0.NpcMobList[item3].Z_direction,
					Z_position = npcGen_0.NpcMobList[item3].Z_position,
					Z_random = npcGen_0.NpcMobList[item3].Z_random,
					MobDops = new List<ClassExtraMonsters>()
				};
				for (int i = 0; i < npcGen_0.NpcMobList[item3].Amount_in_group; i++)
				{
					ClassExtraMonsters item = new ClassExtraMonsters
					{
						Agression = npcGen_0.NpcMobList[item3].MobDops[i].Agression,
						Amount = npcGen_0.NpcMobList[item3].MobDops[i].Amount,
						bFac_Accept = npcGen_0.NpcMobList[item3].MobDops[i].bFac_Accept,
						bFac_Helper = npcGen_0.NpcMobList[item3].MobDops[i].bFac_Helper,
						bFaction = npcGen_0.NpcMobList[item3].MobDops[i].bFaction,
						bNeedHelp = npcGen_0.NpcMobList[item3].MobDops[i].bNeedHelp,
						Dead_amount = npcGen_0.NpcMobList[item3].MobDops[i].Dead_amount,
						Dead_time = npcGen_0.NpcMobList[item3].MobDops[i].Dead_time,
						fOffsetTrn = npcGen_0.NpcMobList[item3].MobDops[i].fOffsetTrn,
						fOffsetWater = npcGen_0.NpcMobList[item3].MobDops[i].fOffsetWater,
						Group = npcGen_0.NpcMobList[item3].MobDops[i].Group,
						Group_help_Needer = npcGen_0.NpcMobList[item3].MobDops[i].Group_help_Needer,
						Group_help_sender = npcGen_0.NpcMobList[item3].MobDops[i].Group_help_sender,
						Id = npcGen_0.NpcMobList[item3].MobDops[i].Id,
						Path = npcGen_0.NpcMobList[item3].MobDops[i].Path,
						Path_type = npcGen_0.NpcMobList[item3].MobDops[i].Path_type,
						RefreshLower = npcGen_0.NpcMobList[item3].MobDops[i].RefreshLower,
						Respawn = npcGen_0.NpcMobList[item3].MobDops[i].Respawn,
						Speed = npcGen_0.NpcMobList[item3].MobDops[i].Speed
					};
					classDefaultMonsters.MobDops.Add(item);
				}
				npcGen_0.NpcMobList.Add(classDefaultMonsters);
				dataGridView_4.Rows.Add(dataGridView_4.Rows.Count, dataGridView_4.Rows[item3].Cells[1].Value, dataGridView_4.Rows[item3].Cells[2].Value);
			}
			dataGridView_4.ScrollBars = ScrollBars.Vertical;
			List<int> list = list_10;
			dataGridView_4.CurrentCell = dataGridView_4.Rows[dataGridView_4.Rows.Count - 1].Cells[1];
			for (int j = 1; j <= list.Count; j++)
			{
				dataGridView_4.Rows[dataGridView_4.Rows.Count - j].Selected = true;
			}
			dataGridView_4_CurrentCellChanged(null, null);
		}
		else if (npcGen_0 != null)
		{
			npcGen_0.NpcMobsAmount++;
			ClassDefaultMonsters classDefaultMonsters2 = new ClassDefaultMonsters
			{
				Location = 0,
				Type = 0,
				Amount_in_group = 1,
				MobDops = new List<ClassExtraMonsters>()
			};
			ClassExtraMonsters item2 = new ClassExtraMonsters
			{
				Id = 16,
				Amount = 1,
				Respawn = 30
			};
			classDefaultMonsters2.MobDops.Add(item2);
			npcGen_0.NpcMobList.Add(classDefaultMonsters2);
			dataGridView_4.Rows.Add(1, 16, Class16.smethod_0(1649114342));
			dataGridView_4_CurrentCellChanged(null, null);
		}
		int num = list_10?.Count ?? 0;
		tabPage_2.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1649099575), Class16.smethod_0(1649099594)), num, npcGen_0.NpcMobsAmount);
	}

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, IntPtr lParam);

	private IntPtr method_12(object object_0)
	{
		return GCHandle.Alloc(object_0, GCHandleType.Pinned).AddrOfPinnedObject();
	}

	private void toolStripMenuItem_31_Click(object sender, EventArgs e)
	{
		DataGridView dataGridView = null;
		if (tabControl_0.SelectedTab == tabPage_2)
		{
			dataGridView = dataGridView_4;
		}
		else if (tabControl_0.SelectedTab == tabPage_4)
		{
			dataGridView = dataGridView_6;
		}
		else if (tabControl_0.SelectedTab == tabPage_0)
		{
			dataGridView = dataGridView_1;
		}
		if (dataGridView == null)
		{
			return;
		}
		int num = -1;
		List<int> list = new List<int>();
		int num2 = 0;
		if (0 < dataGridView.SelectedRows.Count)
		{
			do
			{
				object value = dataGridView.SelectedRows[num2].Cells[1].Value;
				int result = 0;
				if (value != null && int.TryParse(value.ToString(), out result))
				{
					eListCollection eLC = HINTS.eLC;
					if (eLC != null)
					{
						ITEMPOS iTEMPOS = eLC.FindItemPos(eLC.NpcMobMineLists, result);
						if (iTEMPOS != null)
						{
							if (num == -1)
							{
								num = iTEMPOS.int_0;
							}
							if (iTEMPOS.int_0 == num && !list.Contains(iTEMPOS.int_1))
							{
								list.Add(iTEMPOS.int_1);
							}
						}
					}
				}
				num2++;
			}
			while (num2 < dataGridView.SelectedRows.Count);
		}
		int[] array = list.ToArray();
		Array.Sort(array);
		if (list.Count != 0 && HINTS.CStorage != null && HINTS.CStorage.MainWindowForm != null)
		{
			int wM_SELECT_ITEMS_SET_LIST = ACE.RSGlobal.RSGlobal.WM_SELECT_ITEMS_SET_LIST;
			int wM_SELECT_ITEMS_SET_ITEMS = ACE.RSGlobal.RSGlobal.WM_SELECT_ITEMS_SET_ITEMS;
			Form mainWindowForm = HINTS.CStorage.MainWindowForm;
			SendMessage(mainWindowForm.Handle, wM_SELECT_ITEMS_SET_LIST, num, 0);
			IntPtr lParam = method_12(array);
			SendMessage(mainWindowForm.Handle, wM_SELECT_ITEMS_SET_ITEMS, array.Length, lParam);
		}
	}

	private void button_10_Click(object sender, EventArgs e)
	{
		if (npcGen_0 == null || list_10.Count == 0)
		{
			return;
		}
		DialogResult dialogResult = DKBox.Show(Class16.smethod_0(1649099630), Class16.smethod_0(1649115628), MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
		if (dialogResult != DialogResult.Yes)
		{
			return;
		}
		PushUndoSnapshot();
		int num = list_10.Min();
		dataGridView_4.ScrollBars = ScrollBars.None;
		dataGridView_2.ScrollBars = ScrollBars.None;
		bool_0 = false;
		dataGridView_4.ClearSelection();
		progressBar_0.Maximum = Math.Max(1, list_10.Count);
		npcGen_0.NpcMobsAmount -= list_10.Count;
		using (List<int>.Enumerator enumerator = list_10.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				Class280 @class = new Class280();
				@class.int_0 = enumerator.Current;
				Class264 class2 = new Class264();
				class2.list_0 = list_5.Where(@class.method_0).OrderByDescending(Class289.class289_0.method_7).ToList();
				foreach (IntDictionary item in class2.list_0)
				{
					dataGridView_2.Rows.RemoveAt(item.ErrorInex);
					list_5.RemoveAt(item.ErrorInex);
				}
				list_5.Where(@class.method_1).ToList().ForEach(class2.method_0);
				list_5.Where(@class.method_2).ToList().ForEach(Class289.class289_0.method_8);
				list_6.ForEach(class2.method_1);
				list_4.ForEach(class2.method_2);
				npcGen_0.NpcMobList.RemoveAt(@class.int_0);
				dataGridView_4.Rows.RemoveAt(@class.int_0);
				progressBar_0.Value++;
			}
		}
		if (dataGridView_2.Rows.Count != 0)
		{
			for (int i = 0; i < list_5.Count; i++)
			{
				dataGridView_2.Rows[i].Cells[0].Value = i + 1;
				dataGridView_2.Rows[i].Cells[1].Value = list_5[i].GridIndex + 1;
			}
			int num2 = ((list_6.Count != 0) ? ((IEnumerable<IntDictionary>)list_6).Min((Func<IntDictionary, int>)Class289.class289_0.method_9) : 0);
			for (int j = num2; j <= num2; j++)
			{
				dataGridView_2.Rows[j].Cells[0].Value = j + 1;
			}
			int num3 = ((list_4.Count != 0) ? ((IEnumerable<IntDictionary>)list_4).Min((Func<IntDictionary, int>)Class289.class289_0.method_10) : 0);
			for (int k = num3; k <= num3; k++)
			{
				dataGridView_2.Rows[k].Cells[0].Value = k + 1;
			}
		}
		bool_0 = true;
		progressBar_0.Value = 0;
		dataGridView_4.ScrollBars = ScrollBars.Vertical;
		dataGridView_2.ScrollBars = ScrollBars.Vertical;
		if (dataGridView_4.Rows.Count > num)
		{
			dataGridView_4.CurrentCell = dataGridView_4.Rows[num].Cells[1];
			dataGridView_4.FirstDisplayedScrollingRowIndex = num;
		}
		else if (dataGridView_4.Rows.Count != 0)
		{
			dataGridView_4.CurrentCell = dataGridView_4.Rows[dataGridView_4.Rows.Count - 1].Cells[1];
			dataGridView_4.FirstDisplayedScrollingRowIndex = dataGridView_4.Rows.Count - 1;
		}
		dataGridView_4_CurrentCellChanged(null, null);
		for (int l = 0; l < dataGridView_4.Rows.Count; l++)
		{
			dataGridView_4.Rows[l].Cells[0].Value = l + 1;
		}
		tabPage_2.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1649099683), Class16.smethod_0(1649100128)), npcGen_0.NpcMobsAmount);
	}

	private void button_22_Click(object sender, EventArgs e)
	{
		if (list_12 == null)
		{
			list_12 = new List<int>();
		}
		if (list_6 == null)
		{
			list_6 = new List<IntDictionary>();
		}
		if (list_4 == null)
		{
			list_4 = new List<IntDictionary>();
		}
		if (npcGen_0 == null || npcGen_0.ResourcesList == null || list_12.Count == 0)
		{
			return;
		}
		list_12 = list_12.Where(method_36).Distinct().OrderByDescending(Class289.class289_0.method_11)
			.ToList();
		if (list_12.Count == 0)
		{
			return;
		}
		DialogResult dialogResult = DKBox.Show(Class16.smethod_0(1649099630), Class16.smethod_0(1649115628), MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
		if (dialogResult != DialogResult.Yes)
		{
			return;
		}
		PushUndoSnapshot();
		int num = list_12.Min();
		dataGridView_6.ScrollBars = ScrollBars.None;
		dataGridView_2.ScrollBars = ScrollBars.None;
		bool_0 = false;
		dataGridView_6.ClearSelection();
		progressBar_0.Maximum = Math.Max(1, list_12.Count);
		npcGen_0.ResourcesAmount -= list_12.Count;
		using (List<int>.Enumerator enumerator = list_12.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				Class266 @class = new Class266();
				@class.int_0 = enumerator.Current;
				Class270 class2 = new Class270();
				class2.list_0 = list_6.Where(@class.method_0).OrderByDescending(Class289.class289_0.method_12).ToList();
				using (List<IntDictionary>.Enumerator enumerator2 = class2.list_0.GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						Class283 class3 = new Class283();
						class3.intDictionary_0 = enumerator2.Current;
						if (class3.intDictionary_0.ErrorInex >= 0 && class3.intDictionary_0.ErrorInex < dataGridView_2.Rows.Count)
						{
							dataGridView_2.Rows.RemoveAt(class3.intDictionary_0.ErrorInex);
						}
						int num2 = list_6.FindIndex(class3.method_0);
						if (num2 >= 0)
						{
							list_6.RemoveAt(num2);
						}
					}
				}
				list_6.Where(@class.method_1).ToList().ForEach(class2.method_0);
				list_6.Where(@class.method_2).ToList().ForEach(Class289.class289_0.method_13);
				list_4.ForEach(class2.method_1);
				npcGen_0.ResourcesList.RemoveAt(@class.int_0);
				dataGridView_6.Rows.RemoveAt(@class.int_0);
				progressBar_0.Value++;
			}
		}
		if (dataGridView_2.Rows.Count != 0)
		{
			Class277 class4 = new Class277();
			int num3 = ((list_6.Count != 0) ? ((IEnumerable<IntDictionary>)list_6).Min((Func<IntDictionary, int>)Class289.class289_0.method_14) : 0);
			int num4 = ((list_6.Count != 0) ? ((IEnumerable<IntDictionary>)list_6).Max((Func<IntDictionary, int>)Class289.class289_0.method_15) : 0);
			class4.int_0 = num3;
			while (class4.int_0 <= num4)
			{
				if (class4.int_0 >= 0 && class4.int_0 < dataGridView_2.Rows.Count)
				{
					dataGridView_2.Rows[class4.int_0].Cells[0].Value = class4.int_0 + 1;
					IntDictionary intDictionary = list_6.Find(class4.method_0);
					if (intDictionary != null)
					{
						dataGridView_2.Rows[class4.int_0].Cells[1].Value = intDictionary.GridIndex + 1;
					}
				}
				class4.int_0++;
			}
			int num5 = ((list_4.Count != 0) ? ((IEnumerable<IntDictionary>)list_4).Min((Func<IntDictionary, int>)Class289.class289_0.method_16) : 0);
			for (int i = num5; i <= num5; i++)
			{
				dataGridView_2.Rows[i].Cells[0].Value = i + 1;
			}
		}
		bool_0 = true;
		progressBar_0.Value = 0;
		dataGridView_6.ScrollBars = ScrollBars.Vertical;
		dataGridView_2.ScrollBars = ScrollBars.Vertical;
		if (dataGridView_6.Rows.Count > num)
		{
			dataGridView_6.CurrentCell = dataGridView_6.Rows[num].Cells[1];
			dataGridView_6.FirstDisplayedScrollingRowIndex = num;
		}
		else if (dataGridView_6.Rows.Count != 0)
		{
			dataGridView_6.CurrentCell = dataGridView_6.Rows[dataGridView_6.Rows.Count - 1].Cells[1];
			dataGridView_6.FirstDisplayedScrollingRowIndex = dataGridView_6.Rows.Count - 1;
		}
		dataGridView_6_CurrentCellChanged(null, null);
		for (int j = 0; j < dataGridView_6.Rows.Count; j++)
		{
			dataGridView_6.Rows[j].Cells[0].Value = j + 1;
		}
		tabPage_4.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1649099714), Class16.smethod_0(1649114403)), npcGen_0.ResourcesAmount);
	}

	private void button_20_Click(object sender, EventArgs e)
	{
		if (list_19 == null || list_19.Count == 0 || dataGridView_6.Rows.Count <= 0 || dataGridView_7.Rows.Count <= 0)
		{
			return;
		}
		list_19 = list_19.OrderByDescending(Class289.class289_0.method_17).ToList();
		DialogResult dialogResult = DKBox.Show(Class16.smethod_0(1649099749), Class16.smethod_0(1649115628), MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
		if (dialogResult != DialogResult.Yes)
		{
			return;
		}
		int num = list_19.Min();
		dataGridView_7.ClearSelection();
		foreach (int item in list_19)
		{
			npcGen_0.ResourcesList[int_6].Amount_in_group--;
			npcGen_0.ResourcesList[int_6].ResExtra.RemoveAt(item);
			dataGridView_7.Rows.RemoveAt(item);
		}
		RefreshResourcesRow(int_6);
		if (dataGridView_7.Rows.Count > num)
		{
			dataGridView_7.CurrentCell = dataGridView_7.Rows[num].Cells[1];
			dataGridView_7.FirstDisplayedScrollingRowIndex = num;
		}
		else if (dataGridView_7.Rows.Count != 0)
		{
			dataGridView_7.CurrentCell = dataGridView_7.Rows[dataGridView_7.Rows.Count - 1].Cells[1];
			dataGridView_7.FirstDisplayedScrollingRowIndex = dataGridView_7.Rows.Count - 1;
		}
		dataGridView_7_CurrentCellChanged(null, null);
	}

	public void InitializeMapsFromEditor()
	{
		PCK pCK = EditorPCKs?.Surfaces;
		if (pCK != null && pCK.FileLoaded)
		{
			try
			{
				list_8 = new List<GameMapInfo>();
				List<string> filesList = pCK.GetFilesList(Class16.smethod_0(1649098821));
				if (filesList != null && filesList.Count != 0)
				{
					List<string> list = filesList.Where(Class289.class289_0.method_18).ToList();
					List<string> list2 = new List<string>();
					foreach (string item in list)
					{
						Class273 @class = new Class273();
						@class.gameMapInfo_0 = new GameMapInfo();
						List<string> list3 = item.Split('\\').ToList();
						if (list3.Count >= 2)
						{
							@class.gameMapInfo_0.MapName = list3.ElementAt(list3.Count - 2);
							list3.RemoveAt(list3.Count - 1);
							@class.gameMapInfo_0.MapPath = string.Join(Class16.smethod_0(1648927580), list3);
							if (list2.FindIndex(@class.method_0) == -1)
							{
								@class.gameMapInfo_0.MapFragments = list.Where(@class.method_1).OrderBy(Class289.class289_0.method_19).Select(Class289.class289_0.method_20)
									.ToList();
								list_8.Add(@class.gameMapInfo_0);
								list2.Add(@class.gameMapInfo_0.MapPath);
							}
						}
					}
					if (list_8.Count != 0)
					{
						GameMapInfo gameMapInfo = new GameMapInfo
						{
							MapName = Class16.smethod_0(1649098845),
							MapPath = Class16.smethod_0(1649098849)
						};
						List<string> filesList2 = pCK.GetFilesList(gameMapInfo.MapPath);
						if (filesList2 != null && filesList2.Count > 0)
						{
							gameMapInfo.MapFragments = filesList2.Select(Class289.class289_0.method_21).ToList();
							list_8.Add(gameMapInfo);
						}
						string[] source = CoordDataImportLogic.SortMapIds(list_8.Select(Class289.class289_0.method_22)).ToArray();
						list_8 = source.Select(method_37).ToList();
						comboBox_12.Items.Clear();
						for (int i = 0; i < list_8.Count; i++)
						{
							comboBox_12.Items.Add(list_8[i].MapName);
						}
						if (comboBox_12.Items.Count > 0)
						{
							int num = comboBox_12.FindStringExact(Class16.smethod_0(1649098845));
							comboBox_12.SelectedIndex = ((num >= 0) ? num : 0);
						}
					}
					else
					{
						DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649098878)), Class16.smethod_0(1649115628), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
				}
				return;
			}
			catch (Exception ex)
			{
				SentryHelper.CaptureException(ex, Class16.smethod_0(1649098897));
				DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649098945), Class16.smethod_0(1649098977)), ex.Message, ex.StackTrace), Class16.smethod_0(1649115628), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				comboBox_12.Items.Clear();
				list_8 = null;
				showLocationWindow_0 = null;
				return;
			}
		}
		DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649098788)), Class16.smethod_0(1649115628), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
	}

	private static void smethod_4(PictureBox pictureBox_1, Image image_0)
	{
		if (pictureBox_1 == null)
		{
			image_0?.Dispose();
			return;
		}
		Image image = pictureBox_1.Image;
		pictureBox_1.Image = image_0;
		if (image == null || image == image_0)
		{
			return;
		}
		try
		{
			image.Dispose();
		}
		catch
		{
		}
	}

	private void method_13(string string_0)
	{
		if (!File.Exists(string_0))
		{
			smethod_4(pictureBox_0, null);
			return;
		}
		using Image original = Image.FromFile(string_0);
		smethod_4(pictureBox_0, new Bitmap(original));
	}

	private void textBox_0_TextChanged(object sender, EventArgs e)
	{
		if (!string.IsNullOrWhiteSpace(textBox_0.Text))
		{
			label_0.Text = GetDynamicName(Convert.ToInt32(textBox_0.Text));
			string string_ = string.Format(Class16.smethod_0(1649118867), Application.StartupPath, Convert.ToInt32(textBox_0.Text));
			method_13(string_);
			if (label_0.Text == Class16.smethod_0(1648942867))
			{
				smethod_4(pictureBox_0, null);
			}
		}
	}

	private void toolStripButton_7_Click(object sender, EventArgs e)
	{
		if (npcGen_0 != null)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			try
			{
				if (tabControl_0.SelectedIndex == 0)
				{
					openFileDialog.FileName = Class16.smethod_0(1649099011);
					openFileDialog.Filter = Class16.smethod_0(1649099043);
					openFileDialog.Multiselect = true;
					if (openFileDialog.ShowDialog() != DialogResult.OK)
					{
						return;
					}
					try
					{
						string[] array = smethod_5(openFileDialog);
						bool flag = array.Any(smethod_6);
						bool flag2 = array.Any(smethod_7);
						if (flag && flag2)
						{
							DKBox.Show(Class16.smethod_0(1649099137), Class16.smethod_0(1649115628), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							return;
						}
						if (flag2)
						{
							method_28(array.Where(smethod_7).ToArray());
							return;
						}
						if (array.Length != 1)
						{
							DKBox.Show(Class16.smethod_0(1649099237), Class16.smethod_0(1649115628), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							return;
						}
						string text = File.ReadAllText(array[0]);
						ExistenceExportData existenceExportData = JsonConvert.DeserializeObject<ExistenceExportData>(text);
						if (existenceExportData?.Type != Class16.smethod_0(1649102347))
						{
							ShowWrongFile();
							return;
						}
						foreach (ClassDefaultMonsters datum in existenceExportData.Data)
						{
							int num = (datum.Amount_in_group = smethod_3(datum.Amount_in_group, datum.MobDops));
							int[] array2 = new int[num];
							string[] array3 = new string[num];
							for (int i = 0; i < num; i++)
							{
								array2[i] = datum.MobDops[i].Id;
								if (ItemsToolTip.eLC != null && array2[i] != 0)
								{
									array3[i] = smethod_2(ItemType.NpcOrMobOrMine, array2[i]);
								}
								else
								{
									array3[i] = Class16.smethod_0(1648942867);
								}
							}
							dataGridView_4.Rows.Add(dataGridView_4.Rows.Count + 1, string.Join(Class16.smethod_0(1648928028), array2), string.Join(Class16.smethod_0(1648928028), array3));
							npcGen_0.NpcMobList.Add(datum);
							npcGen_0.NpcMobsAmount++;
						}
						if (existenceExportData.Data.Count > 0)
						{
							dataGridView_4.CurrentCell = dataGridView_4.Rows[dataGridView_4.Rows.Count - 1].Cells[1];
							for (int j = 0; j < existenceExportData.Data.Count; j++)
							{
								dataGridView_4.Rows[dataGridView_4.Rows.Count - 1 - j].Selected = true;
							}
							dataGridView_4_CurrentCellChanged(null, null);
						}
						return;
					}
					catch (Exception ex)
					{
						SentryHelper.CaptureException(ex, Class16.smethod_0(1649102363));
						DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649102408), Class16.smethod_0(1649102455)), ex.Message), Class16.smethod_0(1649115628), MessageBoxButtons.OK, MessageBoxIcon.Hand);
						return;
					}
				}
				if (tabControl_0.SelectedIndex == 1)
				{
					openFileDialog.FileName = Class16.smethod_0(1649102492);
					openFileDialog.Filter = Class16.smethod_0(1649102524);
					openFileDialog.Multiselect = true;
					if (openFileDialog.ShowDialog() != DialogResult.OK)
					{
						return;
					}
					try
					{
						string[] array4 = smethod_5(openFileDialog);
						bool flag3 = array4.Any(smethod_6);
						bool flag4 = array4.Any(smethod_7);
						if (flag3 && flag4)
						{
							DKBox.Show(Class16.smethod_0(1649099137), Class16.smethod_0(1649115628), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							return;
						}
						if (flag4)
						{
							method_28(array4.Where(smethod_7).ToArray());
							return;
						}
						if (array4.Length != 1)
						{
							DKBox.Show(Class16.smethod_0(1649099237), Class16.smethod_0(1649115628), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							return;
						}
						string text2 = File.ReadAllText(array4[0]);
						ResourcesExportData resourcesExportData = JsonConvert.DeserializeObject<ResourcesExportData>(text2);
						if (resourcesExportData?.Type != Class16.smethod_0(1649008358))
						{
							ShowWrongFile();
							return;
						}
						foreach (ClassDefaultResources datum2 in resourcesExportData.Data)
						{
							int num2 = (datum2.Amount_in_group = smethod_3(datum2.Amount_in_group, datum2.ResExtra));
							int[] array5 = new int[num2];
							string[] array6 = new string[num2];
							for (int k = 0; k < num2; k++)
							{
								array5[k] = datum2.ResExtra[k].Id;
								if (ItemsToolTip.eLC != null && array5[k] != 0)
								{
									array6[k] = smethod_2(ItemType.NpcOrMobOrMine, array5[k]);
								}
								else
								{
									array6[k] = Class16.smethod_0(1648942867);
								}
							}
							dataGridView_6.Rows.Add(dataGridView_6.Rows.Count + 1, string.Join(Class16.smethod_0(1648928028), array5), string.Join(Class16.smethod_0(1648928028), array6));
							npcGen_0.ResourcesList.Add(datum2);
							npcGen_0.ResourcesAmount++;
						}
						if (resourcesExportData.Data.Count > 0)
						{
							dataGridView_6.CurrentCell = dataGridView_6.Rows[dataGridView_6.Rows.Count - 1].Cells[1];
							for (int l = 0; l < resourcesExportData.Data.Count; l++)
							{
								dataGridView_6.Rows[dataGridView_6.Rows.Count - 1 - l].Selected = true;
							}
							dataGridView_6_CurrentCellChanged(null, null);
						}
						return;
					}
					catch (Exception ex2)
					{
						SentryHelper.CaptureException(ex2, Class16.smethod_0(1649102363));
						DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649102610), Class16.smethod_0(1649102455)), ex2.Message), Class16.smethod_0(1649115628), MessageBoxButtons.OK, MessageBoxIcon.Hand);
						return;
					}
				}
				if (tabControl_0.SelectedIndex == 2)
				{
					openFileDialog.FileName = Class16.smethod_0(1649102651);
					openFileDialog.Filter = Class16.smethod_0(1649102689);
					if (openFileDialog.ShowDialog() != DialogResult.OK)
					{
						return;
					}
					try
					{
						string text3 = File.ReadAllText(openFileDialog.FileName);
						DynamicObjectsExportData dynamicObjectsExportData = JsonConvert.DeserializeObject<DynamicObjectsExportData>(text3);
						if (dynamicObjectsExportData?.Type != Class16.smethod_0(1649102740))
						{
							ShowWrongFile();
							return;
						}
						foreach (ClassDynamicObject datum3 in dynamicObjectsExportData.Data)
						{
							dataGridView_1.Rows.Add(dataGridView_1.Rows.Count + 1, datum3.Id, GetDynamicName(datum3.Id), datum3.TriggerId);
							npcGen_0.DynamicsList.Add(datum3);
							npcGen_0.DynobjectAmount++;
						}
						if (dynamicObjectsExportData.Data.Count > 0)
						{
							dataGridView_1.CurrentCell = dataGridView_1.Rows[dataGridView_1.Rows.Count - 1].Cells[1];
							for (int m = 0; m < dynamicObjectsExportData.Data.Count; m++)
							{
								dataGridView_1.Rows[dataGridView_1.Rows.Count - 1 - m].Selected = true;
							}
							dataGridView_1_CurrentCellChanged(null, null);
						}
						return;
					}
					catch (Exception ex3)
					{
						SentryHelper.CaptureException(ex3, Class16.smethod_0(1649102363));
						DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649102756), Class16.smethod_0(1649102455)), ex3.Message), Class16.smethod_0(1649115628), MessageBoxButtons.OK, MessageBoxIcon.Hand);
						return;
					}
				}
				if (tabControl_0.SelectedIndex != 3)
				{
					return;
				}
				openFileDialog.FileName = Class16.smethod_0(1649102797);
				openFileDialog.Filter = Class16.smethod_0(1649102828);
				if (openFileDialog.ShowDialog() != DialogResult.OK)
				{
					return;
				}
				try
				{
					string text4 = File.ReadAllText(openFileDialog.FileName);
					TriggersExportData triggersExportData = JsonConvert.DeserializeObject<TriggersExportData>(text4);
					if (triggersExportData?.Type != Class16.smethod_0(1649101832))
					{
						ShowWrongFile();
						return;
					}
					foreach (ClassTrigger datum4 in triggersExportData.Data)
					{
						dataGridView_10.Rows.Add(dataGridView_10.Rows.Count + 1, datum4.Id, datum4.GmID, datum4.TriggerName);
						npcGen_0.TriggersList.Add(datum4);
						npcGen_0.TriggersAmount++;
					}
					if (triggersExportData.Data.Count > 0)
					{
						dataGridView_10.CurrentCell = dataGridView_10.Rows[dataGridView_10.Rows.Count - 1].Cells[1];
						for (int n = 0; n < triggersExportData.Data.Count; n++)
						{
							dataGridView_10.Rows[dataGridView_10.Rows.Count - 1 - n].Selected = true;
						}
						dataGridView_10_CurrentCellChanged(null, null);
					}
					return;
				}
				catch (Exception ex4)
				{
					SentryHelper.CaptureException(ex4, Class16.smethod_0(1649102363));
					DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649101848), Class16.smethod_0(1649102455)), ex4.Message), Class16.smethod_0(1649115628), MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
				}
			}
			finally
			{
				((IDisposable)openFileDialog).Dispose();
			}
		}
		DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649101889)), Class16.smethod_0(1649115628), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
	}

	private static string[] smethod_5(OpenFileDialog openFileDialog_4)
	{
		if (openFileDialog_4?.FileNames != null && openFileDialog_4.FileNames.Length != 0)
		{
			return openFileDialog_4.FileNames.Where(Class289.class289_0.method_23).ToArray();
		}
		if (!string.IsNullOrWhiteSpace(openFileDialog_4?.FileName))
		{
			return new string[1] { openFileDialog_4.FileName };
		}
		return Array.Empty<string>();
	}

	private static bool smethod_6(string string_0)
	{
		return string.Equals(System.IO.Path.GetExtension(string_0), Class16.smethod_0(1648899122), StringComparison.OrdinalIgnoreCase);
	}

	private static bool smethod_7(string string_0)
	{
		return string.Equals(System.IO.Path.GetExtension(string_0), Class16.smethod_0(1648997294), StringComparison.OrdinalIgnoreCase);
	}

	private void button_9_Click(object sender, EventArgs e)
	{
		if (comboBox_16.SelectedIndex < 0)
		{
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649101926)), Class16.smethod_0(1649115628), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			return;
		}
		if (OffsetManager.OffsetsList.Count == 0)
		{
			OffsetManager.LoadOffsets();
		}
		OffsetManager.SelectOffsets(comboBox_16.SelectedIndex);
		int? npcElementIdFilter = null;
		if (npcGen_0 != null && dataGridView_4.Rows.Count > 0 && dataGridView_5.Rows.Count > 0 && dataGridView_5.CurrentRow != null)
		{
			int index = dataGridView_5.CurrentRow.Index;
			if (index >= 0 && int_4 >= 0 && int_4 < npcGen_0.NpcMobList.Count && index < npcGen_0.NpcMobList[int_4].MobDops.Count)
			{
				npcElementIdFilter = npcGen_0.NpcMobList[int_4].MobDops[index].Id;
			}
		}
		if (npcLiveEditorForm_0 != null && !npcLiveEditorForm_0.IsDisposed)
		{
			npcLiveEditorForm_0.Close();
		}
		if (CommonStorage.License != null && CommonStorage.License.Special.livenpceditor)
		{
			npcLiveEditorForm_0 = new NpcLiveEditorForm(npcElementIdFilter);
			npcLiveEditorForm_0.OnInsertPositionData += method_14;
			npcLiveEditorForm_0.FormClosed += npcLiveEditorForm_0_FormClosed;
			npcLiveEditorForm_0.Show();
		}
	}

	private void method_14(float float_0, float float_1, float float_2, float float_3, float float_4)
	{
		if (npcGen_0 == null)
		{
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649114318)), Class16.smethod_0(1649115628), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
		else if (dataGridView_4.Rows.Count != 0 && int_4 >= 0 && int_4 < npcGen_0.NpcMobList.Count)
		{
			textBox_58.Text = float_0.ToString();
			textBox_61.Text = float_1.ToString();
			textBox_64.Text = float_2.ToString();
			textBox_59.Text = float_3.ToString();
			textBox_65.Text = float_4.ToString();
			comboBox_7_Leave(textBox_58, null);
			comboBox_7_Leave(textBox_61, null);
			comboBox_7_Leave(textBox_64, null);
			comboBox_7_Leave(textBox_59, null);
			comboBox_7_Leave(textBox_65, null);
		}
		else
		{
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649101953)), Class16.smethod_0(1649115628), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
	}

	private void radioButton_1_CheckedChanged(object sender, EventArgs e)
	{
		int_2 = ((!TDark.IsDarkMode) ? 1 : 2);
		try
		{
			TDark.ApplyTheme(this);
			TDark.ApplyNativeDarkThemeRecursive(this);
			if (dynamicObjectsForm_0 != null && !dynamicObjectsForm_0.IsDisposed)
			{
				TDark.ApplyThemeToDynamicControl(dynamicObjectsForm_0);
			}
		}
		catch
		{
		}
	}

	private void method_15(LLKHEventArgs llkheventArgs_0)
	{
		Class279 @class = new Class279();
		ClassPosition classPosition = null;
		if ((llkheventArgs_0.Keys == keys_3 && Control.ModifierKeys == keys_2) || (llkheventArgs_0.Keys == keys_5 && Control.ModifierKeys == keys_4) || (llkheventArgs_0.Keys == keys_1 && Control.ModifierKeys == keys_0))
		{
			bool flag = false;
			string[] array5 = new string[3] { Class16.smethod_0(1649099780), Class16.smethod_0(1649099795), Class16.smethod_0(1649099831) };
			foreach (string text5 in array5)
			{
				try
				{
					if (Process.GetProcessesByName(text5).Length != 0)
					{
						flag = true;
						break;
					}
				}
				catch
				{
				}
			}
			if (!flag)
			{
				return;
			}
			classPosition = GetCoordinates();
		}
		if (classPosition == null)
		{
			return;
		}
		if (llkheventArgs_0.Keys == keys_3 && Control.ModifierKeys == keys_2)
		{
			npcGen_0.NpcMobsAmount++;
			ClassDefaultMonsters classDefaultMonsters = new ClassDefaultMonsters
			{
				X_position = classPosition.PosX,
				Y_position = classPosition.PosY,
				Z_position = classPosition.PosZ,
				X_direction = classPosition.DirX,
				Y_direction = classPosition.DirY,
				Z_direction = classPosition.DirZ,
				Amount_in_group = 1,
				Location = comboBox_0.SelectedIndex,
				Type = comboBox_1.SelectedIndex,
				Trigger_id = Convert.ToInt32(numericUpDown_5.Value)
			};
			ClassExtraMonsters item = new ClassExtraMonsters
			{
				Id = Convert.ToInt32(numericUpDown_3.Value),
				Amount = Convert.ToInt32(numericUpDown_2.Value),
				Respawn = Convert.ToInt32(numericUpDown_4.Value)
			};
			classDefaultMonsters.MobDops = new List<ClassExtraMonsters> { item };
			npcGen_0.NpcMobList.Add(classDefaultMonsters);
			string text = Class16.smethod_0(1648942867);
			text = ((ItemsToolTip.eLC == null || classDefaultMonsters.MobDops[0].Id == 0) ? Class16.smethod_0(1648942867) : smethod_2(ItemType.NpcOrMobOrMine, classDefaultMonsters.MobDops[0].Id));
			dataGridView_4.Rows.Add(npcGen_0.NpcMobsAmount, classDefaultMonsters.MobDops[0].Id, text);
			dataGridView_4.CurrentCell = dataGridView_4.Rows[dataGridView_4.Rows.Count - 1].Cells[1];
		}
		if (llkheventArgs_0.Keys == keys_5 && Control.ModifierKeys == keys_4)
		{
			npcGen_0.ResourcesAmount++;
			ClassDefaultResources classDefaultResources = new ClassDefaultResources
			{
				X_position = classPosition.PosX,
				Y_position = classPosition.PosY,
				Z_position = classPosition.PosZ,
				Amount_in_group = 1,
				Trigger_id = Convert.ToInt32(numericUpDown_9.Value)
			};
			ClassExtraResources item2 = new ClassExtraResources
			{
				Id = Convert.ToInt32(numericUpDown_7.Value),
				Amount = Convert.ToInt32(numericUpDown_6.Value),
				Respawntime = Convert.ToInt32(numericUpDown_8.Value)
			};
			classDefaultResources.ResExtra = new List<ClassExtraResources> { item2 };
			npcGen_0.ResourcesList.Add(classDefaultResources);
			string text2 = Class16.smethod_0(1648942867);
			text2 = ((ItemsToolTip.eLC == null || classDefaultResources.ResExtra[0].Id == 0) ? Class16.smethod_0(1648942867) : smethod_2(ItemType.NpcOrMobOrMine, classDefaultResources.ResExtra[0].Id));
			dataGridView_6.Rows.Add(npcGen_0.NpcMobsAmount, classDefaultResources.ResExtra[0].Id, text2);
			dataGridView_6.CurrentCell = dataGridView_6.Rows[dataGridView_6.Rows.Count - 1].Cells[1];
		}
		if (llkheventArgs_0.Keys == keys_1 && Control.ModifierKeys == keys_0)
		{
			@class.classDynamicObject_0 = new ClassDynamicObject
			{
				Id = Convert.ToInt32(numericUpDown_1.Value),
				TriggerId = Convert.ToInt32(numericUpDown_0.Value),
				X_position = classPosition.PosX,
				Y_position = classPosition.PosY,
				Z_position = classPosition.PosZ
			};
			npcGen_0.DynobjectAmount++;
			npcGen_0.DynamicsList.Add(@class.classDynamicObject_0);
			string text3 = Class16.smethod_0(1648942867);
			int num = list_1.FindIndex(@class.method_0);
			if (num != -1)
			{
				text3 = list_1[num].Name;
			}
			dataGridView_1.Rows.Add(npcGen_0.DynobjectAmount, @class.classDynamicObject_0.Id, text3, @class.classDynamicObject_0.TriggerId);
			dataGridView_1.CurrentCell = dataGridView_1.Rows[dataGridView_1.Rows.Count - 1].Cells[1];
		}
	}

	private void toolStripMenuItem_23_Click(object sender, EventArgs e)
	{
		if (npcGen_0 == null)
		{
			return;
		}
		if (tabControl_0.SelectedIndex == 0)
		{
			foreach (int item in list_10)
			{
				npcGen_0.NpcMobList[item].X_position = npcGen_0.NpcMobList[int_4].X_position;
			}
			return;
		}
		if (tabControl_0.SelectedIndex == 1)
		{
			foreach (int item2 in list_12)
			{
				npcGen_0.ResourcesList[item2].X_position = npcGen_0.ResourcesList[int_4].X_position;
			}
			return;
		}
		if (tabControl_0.SelectedIndex != 2)
		{
			return;
		}
		foreach (int item3 in list_3)
		{
			npcGen_0.DynamicsList[item3].X_position = npcGen_0.DynamicsList[int_4].X_position;
		}
	}

	private void toolStripMenuItem_24_Click(object sender, EventArgs e)
	{
		if (npcGen_0 == null)
		{
			return;
		}
		if (tabControl_0.SelectedIndex == 0)
		{
			foreach (int item in list_10)
			{
				npcGen_0.NpcMobList[item].Z_position = npcGen_0.NpcMobList[int_4].Z_position;
			}
			return;
		}
		if (tabControl_0.SelectedIndex == 1)
		{
			foreach (int item2 in list_12)
			{
				npcGen_0.ResourcesList[item2].Z_position = npcGen_0.ResourcesList[int_4].Z_position;
			}
			return;
		}
		if (tabControl_0.SelectedIndex != 2)
		{
			return;
		}
		foreach (int item3 in list_3)
		{
			npcGen_0.DynamicsList[item3].Z_position = npcGen_0.DynamicsList[int_4].Z_position;
		}
	}

	private void method_16(List<PCKFileEntry> list_20, string string_0)
	{
		Class284 @class = new Class284();
		@class.string_0 = string_0;
		@class.npcgenEditorForm_0 = this;
		@class.list_0 = list_20;
		int num = 256;
		@class.bitmap_0 = null;
		int num2 = list_7.FindIndex(@class.method_0);
		if (num2 != -1)
		{
			if (@class.list_0.Count == 88)
			{
				num = 1024;
			}
			@class.bitmap_0 = new Bitmap(list_7[num2].Width, list_7[num2].Height);
			int num3 = 0;
			int num4 = 0;
			Graphics graphics = Graphics.FromImage(@class.bitmap_0);
			try
			{
				progressBar_1.BeginInvokeSafe(@class.method_1);
			}
			catch (InvalidOperationException)
			{
			}
			@class.list_0 = @class.list_0.OrderBy(Class289.class289_0.method_24).ToList();
			PCK pCK = EditorPCKs?.Surfaces;
			if (pCK != null && pCK.FileLoaded)
			{
				for (int i = 0; i < @class.list_0.Count; i++)
				{
					byte[] fileB = pCK.GetFileB(@class.list_0[i].Path);
					if (fileB != null)
					{
						graphics.DrawImage(PWHelper.LoadDDSImage(fileB), new Point(num3, num4));
					}
					num3 += num;
					if (num3 == @class.bitmap_0.Width)
					{
						num4 += num;
						num3 = 0;
					}
					progressBar_1.BeginInvokeSafe(@class.method_2);
				}
				this.BeginInvokeSafe(@class.method_3);
			}
			else
			{
				this.BeginInvokeSafe(Class289.class289_0.method_25);
			}
		}
		else
		{
			this.BeginInvokeSafe(Class289.class289_0.method_26);
		}
	}

	private void textBox_13_Click(object sender, EventArgs e)
	{
		Control control = sender as Control;
		string name = control.Name;
		if (name == null)
		{
			return;
		}
		switch (name.Length)
		{
		case 15:
			switch (name[0])
			{
			case 'T':
				if (name == Class16.smethod_0(1649106462))
				{
					radioButton_13.Checked = true;
				}
				break;
			case 'D':
				if (name == Class16.smethod_0(1649106777))
				{
					radioButton_2.Checked = true;
				}
				break;
			}
			break;
		case 16:
			if (name == Class16.smethod_0(1649106067))
			{
				radioButton_9.Checked = true;
			}
			break;
		case 17:
			switch (name[0])
			{
			case 'T':
				if (!(name == Class16.smethod_0(1649103315)))
				{
					if (name == Class16.smethod_0(1649103249))
					{
						radioButton_14.Checked = true;
					}
				}
				else
				{
					radioButton_12.Checked = true;
				}
				break;
			case 'E':
				if (name == Class16.smethod_0(1649106400))
				{
					radioButton_5.Checked = true;
				}
				break;
			case 'D':
				if (name == Class16.smethod_0(1649106718))
				{
					radioButton_3.Checked = true;
				}
				break;
			}
			break;
		case 18:
			if (name == Class16.smethod_0(1649106006))
			{
				radioButton_10.Checked = true;
			}
			break;
		case 19:
			switch (name[15])
			{
			case 'P':
				if (name == Class16.smethod_0(1649106215))
				{
					radioButton_7.Checked = true;
				}
				break;
			case 'N':
				if (name == Class16.smethod_0(1649106329))
				{
					radioButton_6.Checked = true;
				}
				break;
			}
			break;
		case 20:
			if (name == Class16.smethod_0(1649106650))
			{
				radioButton_4.Checked = true;
			}
			break;
		case 21:
			if (name == Class16.smethod_0(1649105936))
			{
				radioButton_11.Checked = true;
			}
			break;
		case 22:
			if (name == Class16.smethod_0(1649106265))
			{
				radioButton_8.Checked = true;
			}
			break;
		}
	}

	private void toolStripMenuItem_7_Click(object sender, EventArgs e)
	{
		try
		{
			if (npcGen_0 == null)
			{
				return;
			}
			if (int_0 == 1 && dataGridView_9.Rows.Count != 0)
			{
				dataGridView_4.CurrentCell = dataGridView_4.Rows[list_14[dataGridView_9.SelectedRows[dataGridView_9.SelectedRows.Count - 1].Index]].Cells[1];
				foreach (DataGridViewRow selectedRow in dataGridView_9.SelectedRows)
				{
					dataGridView_4.Rows[list_14[selectedRow.Index]].Selected = true;
				}
				tabControl_0.SelectedIndex = 0;
				dataGridView_4_CurrentCellChanged(null, null);
			}
			else if (int_0 == 2 && dataGridView_9.Rows.Count != 0)
			{
				dataGridView_6.CurrentCell = dataGridView_6.Rows[list_15[dataGridView_9.SelectedRows[dataGridView_9.SelectedRows.Count - 1].Index]].Cells[1];
				foreach (DataGridViewRow selectedRow2 in dataGridView_9.SelectedRows)
				{
					dataGridView_6.Rows[list_15[selectedRow2.Index]].Selected = true;
				}
				tabControl_0.SelectedIndex = 1;
				dataGridView_6_CurrentCellChanged(null, null);
			}
			else if (int_0 == 3 && dataGridView_9.Rows.Count != 0)
			{
				dataGridView_1.CurrentCell = dataGridView_1.Rows[list_13[dataGridView_9.SelectedRows[dataGridView_9.SelectedRows.Count - 1].Index]].Cells[1];
				foreach (DataGridViewRow selectedRow3 in dataGridView_9.SelectedRows)
				{
					dataGridView_1.Rows[list_13[selectedRow3.Index]].Selected = true;
				}
				tabControl_0.SelectedIndex = 2;
				dataGridView_1_CurrentCellChanged(null, null);
			}
			else
			{
				if (int_0 != 4 || dataGridView_9.Rows.Count == 0)
				{
					return;
				}
				dataGridView_10.CurrentCell = dataGridView_10.Rows[list_16[dataGridView_9.SelectedRows[dataGridView_9.SelectedRows.Count - 1].Index]].Cells[1];
				foreach (DataGridViewRow selectedRow4 in dataGridView_9.SelectedRows)
				{
					dataGridView_10.Rows[list_16[selectedRow4.Index]].Selected = true;
				}
				tabControl_0.SelectedIndex = 3;
				dataGridView_10_CurrentCellChanged(null, null);
			}
		}
		catch
		{
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649101996)), Class16.smethod_0(1649102019), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
	}

	private void textBox_32_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			textBox_32_Leave(sender, null);
		}
	}

	private void textBox_32_Leave(object sender, EventArgs e)
	{
		if (!(sender is Control control) || npcGen_0 == null || npcGen_0.ResourcesList == null || list_12 == null)
		{
			return;
		}
		string name = control.Name;
		if (name == null)
		{
			return;
		}
		int result;
		float result2;
		switch (name.Length)
		{
		case 19:
			if (!(name == Class16.smethod_0(1649110895)))
			{
				break;
			}
			{
				foreach (int item in list_12)
				{
					npcGen_0.ResourcesList[item].bAutoRevive = Convert.ToByte(checkBox_8.Checked);
				}
				break;
			}
		case 8:
			if (!(name == Class16.smethod_0(1649110824)))
			{
				break;
			}
			int.TryParse(textBox_22.Text, out result);
			{
				foreach (int item2 in list_12)
				{
					npcGen_0.ResourcesList[item2].dwGenID = result;
				}
				break;
			}
		case 9:
		{
			byte result3;
			switch (name[8])
			{
			case 'l':
				if (!(name == Class16.smethod_0(1649110747)))
				{
					break;
				}
				int.TryParse(textBox_27.Text, out result);
				{
					foreach (int item3 in list_12)
					{
						npcGen_0.ResourcesList[item3].IMaxNum = result;
					}
					break;
				}
			case 'm':
				if (!(name == Class16.smethod_0(1649110035)))
				{
					if (!(name == Class16.smethod_0(1649111037)))
					{
						break;
					}
					float.TryParse(textBox_36.Text, out result2);
					{
						foreach (int item4 in list_12)
						{
							npcGen_0.ResourcesList[item4].Z_Random = result2;
						}
						break;
					}
				}
				float.TryParse(textBox_33.Text, out result2);
				{
					foreach (int item5 in list_12)
					{
						npcGen_0.ResourcesList[item5].X_Random = result2;
					}
					break;
				}
			case 'n':
				if (!(name == Class16.smethod_0(1649110991)))
				{
					break;
				}
				byte.TryParse(textBox_30.Text, out result3);
				{
					foreach (int item6 in list_12)
					{
						npcGen_0.ResourcesList[item6].Rotation = result3;
					}
					break;
				}
			case '2':
				if (!(name == Class16.smethod_0(1649110081)))
				{
					break;
				}
				byte.TryParse(textBox_29.Text, out result3);
				{
					foreach (int item7 in list_12)
					{
						npcGen_0.ResourcesList[item7].InCline2 = result3;
					}
					break;
				}
			case '1':
				if (!(name == Class16.smethod_0(1649110134)))
				{
					break;
				}
				byte.TryParse(textBox_28.Text, out result3);
				{
					foreach (int item8 in list_12)
					{
						npcGen_0.ResourcesList[item8].InCline1 = result3;
					}
					break;
				}
			}
			break;
		}
		case 10:
			if (!(name == Class16.smethod_0(1649110793)))
			{
				break;
			}
			int.TryParse(textBox_31.Text, out result);
			{
				foreach (int item9 in list_12)
				{
					npcGen_0.ResourcesList[item9].Trigger_id = result;
				}
				break;
			}
		case 11:
			switch (name[1])
			{
			case 'X':
				if (!(name == Class16.smethod_0(1649110215)))
				{
					break;
				}
				float.TryParse(textBox_32.Text, out result2);
				{
					foreach (int item10 in list_12)
					{
						npcGen_0.ResourcesList[item10].X_position = result2;
					}
					break;
				}
			case 'Y':
				if (!(name == Class16.smethod_0(1649110197)))
				{
					break;
				}
				float.TryParse(textBox_34.Text, out result2);
				{
					foreach (int item11 in list_12)
					{
						npcGen_0.ResourcesList[item11].Y_position = result2;
					}
					break;
				}
			case 'Z':
				if (!(name == Class16.smethod_0(1649110171)))
				{
					break;
				}
				float.TryParse(textBox_35.Text, out result2);
				{
					foreach (int item12 in list_12)
					{
						npcGen_0.ResourcesList[item12].Z_position = result2;
					}
					break;
				}
			case 'B':
				if (!(name == Class16.smethod_0(1649110861)))
				{
					break;
				}
				{
					foreach (int item13 in list_12)
					{
						npcGen_0.ResourcesList[item13].bValidOnce = Convert.ToByte(checkBox_7.Checked);
					}
					break;
				}
			}
			break;
		case 16:
			if (!(name == Class16.smethod_0(1649110943)))
			{
				break;
			}
			{
				foreach (int item14 in list_12)
				{
					npcGen_0.ResourcesList[item14].bInitGen = Convert.ToByte(checkBox_9.Checked);
				}
				break;
			}
		}
	}

	private void textBox_23_DoubleClick(object sender, EventArgs e)
	{
		int.TryParse(textBox_23.Text, out var result);
		int num = method_0(ItemType.PW_MINE_ESSENCE, result);
		if (num > 0)
		{
			textBox_23.Text = num.ToString();
			SetId(num, 2, 2);
		}
	}

	private void textBox_23_TextChanged(object sender, EventArgs e)
	{
		if (npcGen_0 != null)
		{
			int.TryParse(textBox_23.Text, out var result);
			if (ItemsToolTip.eLC != null && result != 0)
			{
				textBox_24.Text = smethod_2(ItemType.NpcOrMobOrMine, result);
			}
			else
			{
				textBox_24.Text = string.Empty;
			}
		}
	}

	private void dataGridView_6_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
	{
		if (!method_3() && HINTS.ToolTipWindow != null && ((e.ColumnIndex > 0) & (e.RowIndex >= 0)))
		{
			string text = Convert.ToString(dataGridView_6.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
			object value = dataGridView_6.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
			if (value != null && int.TryParse(value.ToString(), out var result) && result > 0)
			{
				HINTS.ToolTipWindow.SetOwnerHandle(dataGridView_6.Handle);
				HINTS.ToolTipWindow.ShowItemToolTip(result, ItemType.NpcOrMobOrMine);
			}
			else
			{
				HINTS.ToolTipWindow.ShowToolTip(dataGridView_6, text);
			}
		}
	}

	private void dataGridView_6_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
	{
		if (HINTS.ToolTipWindow != null)
		{
			HINTS.ToolTipWindow.SmoothHide();
		}
	}

	private void dataGridView_6_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
	{
		if (!method_3() && ((e.ColumnIndex > 0) & (e.RowIndex >= 0)))
		{
			object value = dataGridView_6.Rows[e.RowIndex].Cells[1].Value;
			if (value != null && int.TryParse(value.ToString(), out var result) && result > 0 && HINTS.ToolTipWindow != null)
			{
				HINTS.ToolTipWindow.SetOwnerHandle(dataGridView_6.Handle);
				HINTS.ToolTipWindow.ShowItemToolTip(result, ItemType.NpcOrMobOrMine);
			}
		}
	}

	private void dataGridView_6_CurrentCellChanged(object sender, EventArgs e)
	{
		if (!bool_0 || npcGen_0?.ResourcesList == null || dataGridView_6?.CurrentRow == null)
		{
			return;
		}
		list_12 = dataGridView_6.SelectedRows.Cast<DataGridViewRow>().Select(Class289.class289_0.method_27).OrderByDescending(Class289.class289_0.method_28)
			.ToList();
		int_6 = dataGridView_6.CurrentRow.Index;
		if (int_6 != -1 && int_6 < npcGen_0.ResourcesList.Count)
		{
			ClassDefaultResources classDefaultResources = npcGen_0.ResourcesList[int_6];
			textBox_32.Text = classDefaultResources.X_position.ToString();
			textBox_34.Text = classDefaultResources.Y_position.ToString();
			textBox_35.Text = classDefaultResources.Z_position.ToString();
			textBox_33.Text = classDefaultResources.X_Random.ToString();
			textBox_36.Text = classDefaultResources.Z_Random.ToString();
			textBox_28.Text = classDefaultResources.InCline1.ToString();
			textBox_29.Text = classDefaultResources.InCline2.ToString();
			textBox_30.Text = classDefaultResources.Rotation.ToString();
			textBox_26.Text = classDefaultResources.Amount_in_group.ToString();
			textBox_22.Text = classDefaultResources.dwGenID.ToString();
			textBox_31.Text = classDefaultResources.Trigger_id.ToString();
			textBox_27.Text = classDefaultResources.IMaxNum.ToString();
			checkBox_9.Checked = Convert.ToBoolean(classDefaultResources.bInitGen);
			checkBox_8.Checked = Convert.ToBoolean(classDefaultResources.bAutoRevive);
			checkBox_7.Checked = Convert.ToBoolean(classDefaultResources.bValidOnce);
			dataGridView_7.Rows.Clear();
			for (int i = 0; i < classDefaultResources.Amount_in_group; i++)
			{
				string text = Class16.smethod_0(1648942867);
				text = ((ItemsToolTip.eLC != null) ? ((classDefaultResources.ResExtra[i].Id == 0) ? Class16.smethod_0(1648936686) : smethod_2(ItemType.NpcOrMobOrMine, classDefaultResources.ResExtra[i].Id)) : Class16.smethod_0(1648942867));
				dataGridView_7.Rows.Add(i + 1, classDefaultResources.ResExtra[i].Id, text);
			}
			if (showLocationWindow_0 != null && progressBar_0.Value == 0 && list_12.Count != 0 && showLocationWindow_0.Visible)
			{
				showLocationWindow_0.GetCoordinates(method_8(2));
			}
			dataGridView_7_CurrentCellChanged(null, null);
		}
		tabPage_4.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1649102047), Class16.smethod_0(1649102070)), list_12.Count, npcGen_0.ResourcesAmount);
	}

	private void dataGridView_7_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
	{
		if (!method_3() && ((e.ColumnIndex > 0) & (e.RowIndex >= 0)))
		{
			object value = dataGridView_7.Rows[e.RowIndex].Cells[1].Value;
			if (value != null && int.TryParse(value.ToString(), out var result) && result > 0 && HINTS.ToolTipWindow != null)
			{
				HINTS.ToolTipWindow.SetOwnerHandle(dataGridView_7.Handle);
				HINTS.ToolTipWindow.ShowItemToolTip(result, ItemType.NpcOrMobOrMine);
			}
		}
	}

	private void dataGridView_7_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
	{
		if (HINTS.ToolTipWindow != null)
		{
			HINTS.ToolTipWindow.SmoothHide();
		}
	}

	private void dataGridView_7_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
	{
		if (!method_3() && ((e.ColumnIndex > 0) & (e.RowIndex >= 0)))
		{
			object value = dataGridView_7.Rows[e.RowIndex].Cells[1].Value;
			if (value != null && int.TryParse(value.ToString(), out var result) && result > 0 && HINTS.ToolTipWindow != null)
			{
				HINTS.ToolTipWindow.SetOwnerHandle(dataGridView_7.Handle);
				HINTS.ToolTipWindow.ShowItemToolTip(result, ItemType.NpcOrMobOrMine);
			}
		}
	}

	private void dataGridView_7_CurrentCellChanged(object sender, EventArgs e)
	{
		if (npcGen_0 == null || npcGen_0.ResourcesList == null || dataGridView_7.CurrentRow == null || dataGridView_7.CurrentRow.Index == -1 || int_6 < 0 || int_6 >= npcGen_0.ResourcesList.Count || npcGen_0.ResourcesList[int_6]?.ResExtra == null)
		{
			return;
		}
		list_19 = new List<int>(dataGridView_7.SelectedRows.Count);
		foreach (DataGridViewRow selectedRow in dataGridView_7.SelectedRows)
		{
			if (selectedRow.Index >= 0 && selectedRow.Index < npcGen_0.ResourcesList[int_6].ResExtra.Count)
			{
				list_19.Add(selectedRow.Index);
			}
		}
		int_5 = dataGridView_7.CurrentRow.Index;
		if (int_5 >= 0 && int_5 < npcGen_0.ResourcesList[int_6].ResExtra.Count)
		{
			numericUpDown_23.Value = npcGen_0.ResourcesList[int_6].ResExtra[int_5].Id;
			numericUpDown_19.Value = npcGen_0.ResourcesList[int_6].ResExtra[int_5].Amount;
			numericUpDown_24.Value = npcGen_0.ResourcesList[int_6].ResExtra[int_5].Respawntime;
			numericUpDown_25.Value = npcGen_0.ResourcesList[int_6].ResExtra[int_5].ResourceType;
			numericUpDown_22.Value = Convert.ToDecimal(npcGen_0.ResourcesList[int_6].ResExtra[int_5].fHeiOff);
		}
	}

	private void numericUpDown_23_DoubleClick(object sender, EventArgs e)
	{
		int num = method_0(ItemType.PW_MINE_ESSENCE, Convert.ToInt32(numericUpDown_23.Value));
		if (num > 0)
		{
			numericUpDown_23.Value = num;
			SetId(num, 2, 1);
		}
	}

	private void numericUpDown_23_MouseEnter(object sender, EventArgs e)
	{
		if (int.TryParse(numericUpDown_23.Value.ToString(), out var result) && result > 0 && HINTS.ToolTipWindow != null)
		{
			HINTS.ToolTipWindow.SetOwnerHandle(numericUpDown_23.Handle);
			HINTS.ToolTipWindow.ShowItemToolTip(result, ItemType.NpcOrMobOrMine);
		}
	}

	private void numericUpDown_23_MouseLeave(object sender, EventArgs e)
	{
		if (HINTS.ToolTipWindow != null)
		{
			HINTS.ToolTipWindow.SmoothHide();
		}
	}

	private void numericUpDown_23_MouseMove(object sender, MouseEventArgs e)
	{
		if (int.TryParse(numericUpDown_23.Value.ToString(), out var result) && result > 0 && HINTS.ToolTipWindow != null)
		{
			HINTS.ToolTipWindow.SetOwnerHandle(numericUpDown_23.Handle);
			HINTS.ToolTipWindow.ShowItemToolTip(result, ItemType.NpcOrMobOrMine);
		}
	}

	private void button_21_Click(object sender, EventArgs e)
	{
		ClassPosition coordinates = GetCoordinates();
		if (coordinates != null)
		{
			textBox_32.Text = coordinates.PosX.ToString();
			textBox_34.Text = coordinates.PosY.ToString();
			textBox_35.Text = coordinates.PosZ.ToString();
			textBox_32_Leave(textBox_32, null);
			textBox_32_Leave(textBox_34, null);
			textBox_32_Leave(textBox_35, null);
		}
	}

	private void dataGridView_8_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
	{
		button_14_Click(null, null);
	}

	private void dataGridView_8_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
	{
		if ((e.ColumnIndex > 0) & (e.RowIndex >= 0))
		{
			object value = dataGridView_8.Rows[e.RowIndex].Cells[1].Value;
			if (value != null && int.TryParse(value.ToString(), out var result) && result > 0 && HINTS.ToolTipWindow != null)
			{
				HINTS.ToolTipWindow.SetOwnerHandle(dataGridView_8.Handle);
				HINTS.ToolTipWindow.ShowItemToolTip(result, ItemType.NpcOrMobOrMine);
			}
		}
	}

	private void dataGridView_8_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
	{
		if (HINTS.ToolTipWindow != null)
		{
			HINTS.ToolTipWindow.SmoothHide();
		}
	}

	private void dataGridView_8_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
	{
		if ((e.ColumnIndex > 0) & (e.RowIndex >= 0))
		{
			object value = dataGridView_8.Rows[e.RowIndex].Cells[1].Value;
			if (value != null && int.TryParse(value.ToString(), out var result) && result > 0 && HINTS.ToolTipWindow != null)
			{
				HINTS.ToolTipWindow.SetOwnerHandle(dataGridView_8.Handle);
				HINTS.ToolTipWindow.ShowItemToolTip(result, ItemType.NpcOrMobOrMine);
			}
		}
	}

	private void button_23_Click(object sender, EventArgs e)
	{
		if (npcGen_0 == null)
		{
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649114318)), Class16.smethod_0(1649115628), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			return;
		}
		if (string.IsNullOrWhiteSpace(textBox_21.Text))
		{
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649102094)), Class16.smethod_0(1649115628), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			return;
		}
		try
		{
			if (!File.Exists(textBox_21.Text))
			{
				DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649099439)), Class16.smethod_0(1649115628), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			string text = textBox_21.Text;
			string text2 = text + Class16.smethod_0(1648930786);
			FileStream fileStream = new FileStream(text2, FileMode.Create, FileAccess.Write, FileShare.None);
			try
			{
				BinaryWriter binaryWriter = new BinaryWriter(fileStream);
				try
				{
					npcGen_0.WriteNpcgen(binaryWriter, npcGen_0.File_version);
				}
				finally
				{
					((IDisposable)binaryWriter).Dispose();
				}
			}
			finally
			{
				((IDisposable)fileStream).Dispose();
			}
			NpcGenFileHelper.ReplaceFileWithRetry(text2, text);
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649102112)), Class16.smethod_0(1649115628), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
		catch (IOException ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649102138));
			DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649102176), Class16.smethod_0(1649102209)), ex.Message), Class16.smethod_0(1649115628), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
		catch (Exception ex2)
		{
			SentryHelper.CaptureException(ex2, Class16.smethod_0(1649102138));
			DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649102176), Class16.smethod_0(1649102209)), ex2.Message), Class16.smethod_0(1649115628), MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void button_25_Click(object sender, EventArgs e)
	{
		Class267 @class = new Class267();
		@class.npcgenEditorForm_0 = this;
		if (npcGen_0 == null)
		{
			return;
		}
		list_5 = new List<IntDictionary>();
		list_6 = new List<IntDictionary>();
		list_4 = new List<IntDictionary>();
		string text = Class16.smethod_0(1649102240);
		string text2 = Class16.smethod_0(1649008358);
		string text3 = Class16.smethod_0(1649102268);
		string text4 = Class16.smethod_0(1649102282);
		string text5 = Class16.smethod_0(1649101316);
		string text6 = Class16.smethod_0(1649101340);
		string text7 = Class16.smethod_0(1649101357);
		progressBar_0.Maximum = Math.Max(1, npcGen_0.NpcMobsAmount + npcGen_0.ResourcesAmount + npcGen_0.DynobjectAmount);
		dataGridView_2.ScrollBars = ScrollBars.None;
		dataGridView_2.Rows.Clear();
		int num = 1;
		@class.int_0 = 0;
		string string_;
		while (@class.int_0 < npcGen_0.NpcMobsAmount)
		{
			if (npcGen_0.NpcMobList[@class.int_0].Amount_in_group == 0)
			{
				dataGridView_2.Rows.Add(num, @class.int_0 + 1, text, text4);
				list_5.Add(new IntDictionary(num - 1, @class.int_0));
				num++;
			}
			if (npcGen_0.NpcMobList[@class.int_0].Trigger_id != 0 && npcGen_0.TriggersList.FindIndex(@class.method_0) == -1)
			{
				dataGridView_2.Rows.Add(num, @class.int_0 + 1, text, text5);
				list_5.Add(new IntDictionary(num - 1, @class.int_0));
				num++;
			}
			for (int i = 0; i < npcGen_0.NpcMobList[@class.int_0].Amount_in_group; i++)
			{
				int id = npcGen_0.NpcMobList[@class.int_0].MobDops[i].Id;
				if (id != 0 && ItemsToolTip.eLC != null && !smethod_1(ItemType.NpcOrMobOrMine, id, out string_))
				{
					dataGridView_2.Rows.Add(num, @class.int_0 + 1, text, text6);
					list_5.Add(new IntDictionary(num - 1, @class.int_0));
					num++;
					break;
				}
			}
			for (int j = 0; j < npcGen_0.NpcMobList[@class.int_0].Amount_in_group; j++)
			{
				if (npcGen_0.NpcMobList[@class.int_0].MobDops[j].Amount == 0)
				{
					dataGridView_2.Rows.Add(num, @class.int_0 + 1, text, text7);
					list_5.Add(new IntDictionary(num - 1, @class.int_0));
					num++;
					break;
				}
			}
			progressBar_0.Value++;
			@class.int_0++;
		}
		@class.int_1 = 0;
		while (@class.int_1 < npcGen_0.ResourcesAmount)
		{
			if (npcGen_0.ResourcesList[@class.int_1].Amount_in_group == 0)
			{
				dataGridView_2.Rows.Add(num, @class.int_1 + 1, text2, text4);
				list_6.Add(new IntDictionary(num - 1, @class.int_1));
				num++;
			}
			if (npcGen_0.ResourcesList[@class.int_1].Trigger_id != 0 && npcGen_0.TriggersList.FindIndex(@class.method_1) == -1)
			{
				dataGridView_2.Rows.Add(num, @class.int_1 + 1, text2, text5);
				list_6.Add(new IntDictionary(num - 1, @class.int_1));
				num++;
			}
			for (int k = 0; k < npcGen_0.ResourcesList[@class.int_1].Amount_in_group; k++)
			{
				int id2 = npcGen_0.ResourcesList[@class.int_1].ResExtra[k].Id;
				if (id2 != 0 && ItemsToolTip.eLC != null && !smethod_1(ItemType.NpcOrMobOrMine, id2, out string_))
				{
					dataGridView_2.Rows.Add(num, @class.int_1 + 1, text2, text6);
					list_6.Add(new IntDictionary(num - 1, @class.int_1));
					num++;
					break;
				}
			}
			for (int l = 0; l < npcGen_0.ResourcesList[@class.int_1].Amount_in_group; l++)
			{
				if (npcGen_0.ResourcesList[@class.int_1].ResExtra[l].Amount == 0)
				{
					dataGridView_2.Rows.Add(num, @class.int_1 + 1, text2, text7);
					list_6.Add(new IntDictionary(num - 1, @class.int_1));
					num++;
					break;
				}
			}
			progressBar_0.Value++;
			@class.int_1++;
		}
		@class.int_2 = 0;
		while (@class.int_2 < npcGen_0.DynobjectAmount)
		{
			if (npcGen_0.DynamicsList[@class.int_2].TriggerId != 0 && npcGen_0.TriggersList.FindIndex(@class.method_2) == -1)
			{
				dataGridView_2.Rows.Add(num, @class.int_2 + 1, text3, text5);
				list_4.Add(new IntDictionary(num - 1, @class.int_2));
				num++;
			}
			progressBar_0.Value++;
			@class.int_2++;
		}
		progressBar_0.Value = 0;
		dataGridView_2.ScrollBars = ScrollBars.Vertical;
	}

	private void dataGridView_9_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
	{
		toolStripMenuItem_7_Click(null, null);
	}

	private void button_24_Click(object sender, EventArgs e)
	{
		if (openFileDialog_2.ShowDialog() == DialogResult.OK)
		{
			textBox_21.Text = openFileDialog_2.FileName;
		}
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		Class268 @class = new Class268();
		@class.npcgenEditorForm_0 = this;
		if (CommonStorage.License != null && CommonStorage.License.Special.npcgen_mapview && list_8 != null)
		{
			@class.int_0 = comboBox_12.SelectedIndex;
			if (@class.int_0 >= 0 && @class.int_0 < list_8.Count)
			{
				Thread thread = new Thread(@class.method_0);
				thread.Start();
			}
		}
	}

	private void textBox_39_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			textBox_39_Leave(sender, new EventArgs());
		}
	}

	private void textBox_39_Leave(object sender, EventArgs e)
	{
		if (npcGen_0 == null || list_17 == null || list_17.Count == 0)
		{
			return;
		}
		Control control = sender as Control;
		string name = control.Name;
		if (name == null)
		{
			return;
		}
		int result;
		switch (name.Length)
		{
		case 8:
			if (!(name == Class16.smethod_0(1649104881)))
			{
				break;
			}
			int.TryParse(textBox_51.Text, out result);
			{
				foreach (int item in list_17)
				{
					npcGen_0.TriggersList[item].StopDay = result;
				}
				break;
			}
		case 9:
			switch (name[6])
			{
			case 'e':
				if (!(name == Class16.smethod_0(1649103957)))
				{
					break;
				}
				int.TryParse(textBox_55.Text, out result);
				{
					foreach (int item2 in list_17)
					{
						npcGen_0.TriggersList[item2].StopYear = result;
					}
					break;
				}
			case 'D':
				if (!(name == Class16.smethod_0(1649104121)))
				{
					break;
				}
				int.TryParse(textBox_46.Text, out result);
				{
					foreach (int item3 in list_17)
					{
						npcGen_0.TriggersList[item3].StartDay = result;
					}
					break;
				}
			case 'o':
				if (!(name == Class16.smethod_0(1649104851)))
				{
					break;
				}
				int.TryParse(textBox_52.Text, out result);
				{
					foreach (int item4 in list_17)
					{
						npcGen_0.TriggersList[item4].StopHour = result;
					}
					break;
				}
			case 'i':
				if (!(name == Class16.smethod_0(1649104348)))
				{
					break;
				}
				int.TryParse(textBox_38.Text, out result);
				{
					foreach (int item5 in list_17)
					{
						npcGen_0.TriggersList[item5].Duration = result;
					}
					break;
				}
			}
			break;
		case 10:
			switch (name[6])
			{
			case 'Y':
				if (!(name == Class16.smethod_0(1649104203)))
				{
					break;
				}
				int.TryParse(textBox_50.Text, out result);
				{
					foreach (int item6 in list_17)
					{
						npcGen_0.TriggersList[item6].StartYear = result;
					}
					break;
				}
			case 'H':
				if (!(name == Class16.smethod_0(1649104090)))
				{
					break;
				}
				int.TryParse(textBox_47.Text, out result);
				{
					foreach (int item7 in list_17)
					{
						npcGen_0.TriggersList[item7].StartHour = result;
					}
					break;
				}
			case 't':
				if (!(name == Class16.smethod_0(1649103448)))
				{
					break;
				}
				{
					foreach (int item8 in list_17)
					{
						npcGen_0.TriggersList[item8].AutoStart = Convert.ToByte(checkBox_10.Checked);
					}
					break;
				}
			case 'o':
				if (!(name == Class16.smethod_0(1649103905)))
				{
					break;
				}
				int.TryParse(textBox_54.Text, out result);
				{
					foreach (int item9 in list_17)
					{
						npcGen_0.TriggersList[item9].StopMonth = result;
					}
					break;
				}
			}
			break;
		case 11:
			switch (name[3])
			{
			case 'o':
				if (!(name == Class16.smethod_0(1649104819)))
				{
					break;
				}
				int.TryParse(textBox_53.Text, out result);
				{
					foreach (int item10 in list_17)
					{
						npcGen_0.TriggersList[item10].StopMinute = result;
					}
					break;
				}
			case 'a':
				if (!(name == Class16.smethod_0(1649104171)))
				{
					break;
				}
				int.TryParse(textBox_49.Text, out result);
				{
					foreach (int item11 in list_17)
					{
						npcGen_0.TriggersList[item11].StartMonth = result;
					}
					break;
				}
			case '_':
				if (!(name == Class16.smethod_0(1649103491)))
				{
					break;
				}
				int.TryParse(textBox_40.Text, out result);
				{
					foreach (int item12 in list_17)
					{
						npcGen_0.TriggersList[item12].Id = result;
						dataGridView_10.Rows[item12].Cells[1].Value = result;
					}
					break;
				}
			}
			break;
		case 12:
			switch (name[3])
			{
			case 'o':
				if (!(name == Class16.smethod_0(1649103894)))
				{
					break;
				}
				{
					foreach (int item13 in list_17)
					{
						npcGen_0.TriggersList[item13].StopWeekDay = comboBox_15.SelectedIndex - 1;
					}
					break;
				}
			case 'a':
				if (!(name == Class16.smethod_0(1649104057)))
				{
					break;
				}
				int.TryParse(textBox_48.Text, out result);
				{
					foreach (int item14 in list_17)
					{
						npcGen_0.TriggersList[item14].StartMinute = result;
					}
					break;
				}
			}
			break;
		case 13:
			switch (name[1])
			{
			case 'S':
				if (!(name == Class16.smethod_0(1649104159)))
				{
					break;
				}
				{
					foreach (int item15 in list_17)
					{
						npcGen_0.TriggersList[item15].StartWeekDay = comboBox_14.SelectedIndex - 1;
					}
					break;
				}
			case 'N':
				if (!(name == Class16.smethod_0(1649103537)))
				{
					break;
				}
				{
					foreach (int item16 in list_17)
					{
						npcGen_0.TriggersList[item16].TriggerName = textBox_41.Text;
						dataGridView_10.Rows[item16].Cells[3].Value = textBox_41.Text;
					}
					break;
				}
			case 'G':
				if (!(name == Class16.smethod_0(1649103565)))
				{
					break;
				}
				int.TryParse(textBox_39.Text, out result);
				{
					foreach (int item17 in list_17)
					{
						npcGen_0.TriggersList[item17].GmID = result;
						dataGridView_10.Rows[item17].Cells[2].Value = result;
					}
					break;
				}
			}
			break;
		case 15:
			if (!(name == Class16.smethod_0(1649104303)))
			{
				break;
			}
			{
				foreach (int item18 in list_17)
				{
					npcGen_0.TriggersList[item18].DontStopOnSchedule = Convert.ToByte(checkBox_12.Checked);
				}
				break;
			}
		case 16:
			if (!(name == Class16.smethod_0(1649104248)))
			{
				break;
			}
			{
				foreach (int item19 in list_17)
				{
					npcGen_0.TriggersList[item19].DontStartOnSchedule = Convert.ToByte(checkBox_11.Checked);
				}
				break;
			}
		case 17:
			if (!(name == Class16.smethod_0(1649103363)))
			{
				break;
			}
			int.TryParse(textBox_57.Text, out result);
			{
				foreach (int item20 in list_17)
				{
					npcGen_0.TriggersList[item20].WaitWhileStop = result;
				}
				break;
			}
		case 18:
			if (!(name == Class16.smethod_0(1649103431)))
			{
				break;
			}
			int.TryParse(textBox_56.Text, out result);
			{
				foreach (int item21 in list_17)
				{
					npcGen_0.TriggersList[item21].WaitWhileStart = result;
				}
				break;
			}
		case 14:
			break;
		}
	}

	private void button_26_Click(object sender, EventArgs e)
	{
		if (dataGridView_10.Rows.Count > 0)
		{
			if (npcGen_0 == null || list_17 == null || list_17.Count == 0)
			{
				return;
			}
			PushUndoSnapshot();
			dataGridView_10.ScrollBars = ScrollBars.None;
			list_17 = list_17.OrderBy(Class289.class289_0.method_29).ToList();
			foreach (int item2 in list_17)
			{
				npcGen_0.TriggersAmount++;
				ClassTrigger classTrigger = new ClassTrigger
				{
					Id = ((IEnumerable<ClassTrigger>)npcGen_0.TriggersList).Max((Func<ClassTrigger, int>)Class289.class289_0.method_30) + 1,
					GmID = ((IEnumerable<ClassTrigger>)npcGen_0.TriggersList).Max((Func<ClassTrigger, int>)Class289.class289_0.method_31) + 1,
					TriggerName = npcGen_0.TriggersList[item2].TriggerName,
					AutoStart = npcGen_0.TriggersList[item2].AutoStart,
					DontStartOnSchedule = npcGen_0.TriggersList[item2].DontStartOnSchedule,
					DontStopOnSchedule = npcGen_0.TriggersList[item2].DontStopOnSchedule,
					Duration = npcGen_0.TriggersList[item2].Duration,
					StartDay = npcGen_0.TriggersList[item2].StartDay,
					StartHour = npcGen_0.TriggersList[item2].StartHour,
					StartMinute = npcGen_0.TriggersList[item2].StartMinute,
					StartMonth = npcGen_0.TriggersList[item2].StartMonth,
					StartWeekDay = npcGen_0.TriggersList[item2].StartWeekDay,
					StartYear = npcGen_0.TriggersList[item2].StartYear,
					StopDay = npcGen_0.TriggersList[item2].StopDay,
					StopHour = npcGen_0.TriggersList[item2].StopHour,
					StopMinute = npcGen_0.TriggersList[item2].StopMinute,
					StopMonth = npcGen_0.TriggersList[item2].StopMonth,
					StopWeekDay = npcGen_0.TriggersList[item2].StopWeekDay,
					StopYear = npcGen_0.TriggersList[item2].StopYear,
					WaitWhileStart = npcGen_0.TriggersList[item2].WaitWhileStart,
					WaitWhileStop = npcGen_0.TriggersList[item2].WaitWhileStop
				};
				npcGen_0.TriggersList.Add(classTrigger);
				dataGridView_10.Rows.Add(npcGen_0.TriggersAmount, classTrigger.Id, classTrigger.GmID, dataGridView_10.Rows[item2].Cells[3].Value);
			}
			dataGridView_10.ScrollBars = ScrollBars.Vertical;
			List<int> list = list_17;
			dataGridView_10.CurrentCell = dataGridView_10.Rows[dataGridView_10.Rows.Count - 1].Cells[1];
			for (int i = 1; i <= list.Count; i++)
			{
				dataGridView_10.Rows[dataGridView_10.Rows.Count - i].Selected = true;
			}
			dataGridView_10_CurrentCellChanged(null, null);
		}
		else
		{
			PushUndoSnapshot();
			npcGen_0.TriggersAmount++;
			ClassTrigger item = new ClassTrigger
			{
				Id = 1,
				GmID = 2,
				TriggerName = Class16.smethod_0(1649123804),
				Duration = 60,
				StartYear = -1,
				StartMonth = -1,
				StartWeekDay = -1,
				StartDay = -1,
				StartHour = -1,
				StartMinute = -1,
				StopYear = -1,
				StopMonth = -1,
				StopWeekDay = -1,
				StopDay = -1,
				StopHour = -1,
				StopMinute = -1
			};
			npcGen_0.TriggersList.Add(item);
			dataGridView_10.Rows.Add(1, 1, 2, Class16.smethod_0(1649123804));
			dataGridView_10_CurrentCellChanged(null, null);
		}
		tabPage_6.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1649101397), Class16.smethod_0(1649100264)), npcGen_0.TriggersAmount);
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		if (npcGen_0 != null && saveFileDialog_0.ShowDialog() == DialogResult.OK)
		{
			BinaryWriter binaryWriter = new BinaryWriter(File.Create(saveFileDialog_0.FileName));
			npcGen_0.WriteNpcgen(binaryWriter, Convert.ToInt32(comboBox_3.SelectedItem));
			binaryWriter.Close();
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649102112)), Class16.smethod_0(1649115628), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
	}

	private void button_3_Click(object sender, EventArgs e)
	{
		if (npcGen_0 == null)
		{
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649114318)), Class16.smethod_0(1649115628), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			return;
		}
		PushUndoSnapshot();
		if (dataGridView_1.Rows.Count > 0)
		{
			dataGridView_1.ScrollBars = ScrollBars.None;
			list_3 = list_3.OrderBy(Class289.class289_0.method_32).ToList();
			foreach (int item3 in list_3)
			{
				npcGen_0.DynobjectAmount++;
				ClassDynamicObject item = new ClassDynamicObject
				{
					Id = npcGen_0.DynamicsList[item3].Id,
					InCline1 = npcGen_0.DynamicsList[item3].InCline1,
					InCline2 = npcGen_0.DynamicsList[item3].InCline2,
					Rotation = npcGen_0.DynamicsList[item3].Rotation,
					Scale = npcGen_0.DynamicsList[item3].Scale,
					TriggerId = npcGen_0.DynamicsList[item3].TriggerId,
					X_position = npcGen_0.DynamicsList[item3].X_position,
					Y_position = npcGen_0.DynamicsList[item3].Y_position,
					Z_position = npcGen_0.DynamicsList[item3].Z_position
				};
				npcGen_0.DynamicsList.Add(item);
				dataGridView_1.Rows.Add(npcGen_0.DynobjectAmount, dataGridView_1.Rows[item3].Cells[1].Value, dataGridView_1.Rows[item3].Cells[2].Value, dataGridView_1.Rows[item3].Cells[3].Value);
			}
			dataGridView_1.ScrollBars = ScrollBars.Vertical;
			List<int> list = list_3;
			dataGridView_1.CurrentCell = dataGridView_1.Rows[dataGridView_1.Rows.Count - 1].Cells[1];
			for (int i = 1; i <= list.Count; i++)
			{
				dataGridView_1.Rows[dataGridView_1.Rows.Count - i].Selected = true;
			}
			dataGridView_1_CurrentCellChanged(null, null);
		}
		else
		{
			npcGen_0.DynobjectAmount++;
			ClassDynamicObject item2 = new ClassDynamicObject
			{
				Id = 16
			};
			npcGen_0.DynamicsList.Add(item2);
			dataGridView_1.Rows.Add(1, 9, Class16.smethod_0(1649101423), 0);
			dataGridView_1_CurrentCellChanged(null, null);
		}
		tabPage_0.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1649101427), Class16.smethod_0(1649100220)), npcGen_0.DynobjectAmount);
	}

	private void button_5_Click(object sender, EventArgs e)
	{
		if (npcGen_0 == null || list_3.Count == 0)
		{
			return;
		}
		DialogResult dialogResult = DKBox.Show(Class16.smethod_0(1649099630), Class16.smethod_0(1649115628), MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
		if (dialogResult != DialogResult.Yes)
		{
			return;
		}
		int num = list_3.Min();
		dataGridView_1.ScrollBars = ScrollBars.None;
		dataGridView_2.ScrollBars = ScrollBars.None;
		bool_0 = false;
		dataGridView_1.ClearSelection();
		progressBar_0.Maximum = Math.Max(1, list_3.Count);
		npcGen_0.DynobjectAmount -= list_3.Count;
		using (List<int>.Enumerator enumerator = list_3.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				Class276 @class = new Class276();
				@class.int_0 = enumerator.Current;
				Class257 class2 = new Class257();
				class2.list_0 = list_4.Where(@class.method_0).OrderByDescending(Class289.class289_0.method_33).ToList();
				using (List<IntDictionary>.Enumerator enumerator2 = class2.list_0.GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						Class256 class3 = new Class256();
						class3.intDictionary_0 = enumerator2.Current;
						dataGridView_2.Rows.RemoveAt(class3.intDictionary_0.ErrorInex);
						list_4.RemoveAt(list_4.FindIndex(class3.method_0));
					}
				}
				list_4.Where(@class.method_1).ToList().ForEach(class2.method_0);
				list_4.Where(@class.method_2).ToList().ForEach(Class289.class289_0.method_34);
				npcGen_0.DynamicsList.RemoveAt(@class.int_0);
				dataGridView_1.Rows.RemoveAt(@class.int_0);
				progressBar_0.Value++;
			}
		}
		if (dataGridView_2.Rows.Count != 0)
		{
			Class262 class4 = new Class262();
			int num2 = ((list_4.Count != 0) ? ((IEnumerable<IntDictionary>)list_4).Min((Func<IntDictionary, int>)Class289.class289_0.method_35) : 0);
			int num3 = ((list_4.Count != 0) ? ((IEnumerable<IntDictionary>)list_4).Max((Func<IntDictionary, int>)Class289.class289_0.method_36) : 0);
			class4.int_0 = num2;
			while (class4.int_0 <= num3)
			{
				dataGridView_2.Rows[class4.int_0].Cells[0].Value = class4.int_0 + 1;
				IntDictionary intDictionary = list_4.Find(class4.method_0);
				if (intDictionary != null)
				{
					dataGridView_2.Rows[class4.int_0].Cells[1].Value = intDictionary.GridIndex + 1;
				}
				class4.int_0++;
			}
		}
		bool_0 = true;
		progressBar_0.Value = 0;
		dataGridView_1.ScrollBars = ScrollBars.Vertical;
		dataGridView_2.ScrollBars = ScrollBars.Vertical;
		if (dataGridView_1.Rows.Count > num)
		{
			dataGridView_1.CurrentCell = dataGridView_1.Rows[num].Cells[1];
			dataGridView_1.FirstDisplayedScrollingRowIndex = num;
		}
		else if (dataGridView_1.Rows.Count != 0)
		{
			dataGridView_1.CurrentCell = dataGridView_1.Rows[dataGridView_1.Rows.Count - 1].Cells[1];
			dataGridView_1.FirstDisplayedScrollingRowIndex = dataGridView_1.Rows.Count - 1;
		}
		dataGridView_1_CurrentCellChanged(null, null);
		for (int i = 0; i < dataGridView_1.Rows.Count; i++)
		{
			dataGridView_1.Rows[i].Cells[0].Value = i + 1;
		}
		tabPage_0.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1649101468), Class16.smethod_0(1649101501)), npcGen_0.DynobjectAmount);
	}

	private void comboBox_5_SelectedIndexChanged(object sender, EventArgs e)
	{
		Control control = sender as Control;
		KeysConverter keysConverter = new KeysConverter();
		string name = control.Name;
		if (!(name == Class16.smethod_0(1649105221)))
		{
			if (!(name == Class16.smethod_0(1649105169)))
			{
				if (!(name == Class16.smethod_0(1649105110)))
				{
					if (!(name == Class16.smethod_0(1649105061)))
					{
						if (!(name == Class16.smethod_0(1649104991)))
						{
							if (name == Class16.smethod_0(1649104917))
							{
								keys_1 = (Keys)keysConverter.ConvertFromString(comboBox_9.SelectedItem.ToString());
							}
						}
						else
						{
							keys_0 = (Keys)keysConverter.ConvertFromString(comboBox_4.SelectedItem.ToString());
						}
					}
					else
					{
						keys_5 = (Keys)keysConverter.ConvertFromString(comboBox_11.SelectedItem.ToString());
					}
				}
				else
				{
					keys_4 = (Keys)keysConverter.ConvertFromString(comboBox_6.SelectedItem.ToString());
				}
			}
			else
			{
				keys_3 = (Keys)keysConverter.ConvertFromString(comboBox_10.SelectedItem.ToString());
			}
		}
		else
		{
			keys_2 = (Keys)keysConverter.ConvertFromString(comboBox_5.SelectedItem.ToString());
		}
	}

	private void toolStripButton_8_Click(object sender, EventArgs e)
	{
		Class274 @class = new Class274();
		@class.npcgenEditorForm_0 = this;
		if (npcGen_0 == null)
		{
			return;
		}
		List<int> list = new List<int>();
		@class.int_0 = 0;
		while (@class.int_0 < npcGen_0.TriggersAmount)
		{
			int num = npcGen_0.NpcMobList.FindIndex(@class.method_0);
			int num2 = npcGen_0.ResourcesList.FindIndex(@class.method_1);
			int num3 = npcGen_0.DynamicsList.FindIndex(@class.method_2);
			if (num == -1 && num2 == -1 && num3 == -1)
			{
				list.Add(npcGen_0.TriggersList.IndexOf(npcGen_0.TriggersList[@class.int_0]));
			}
			@class.int_0++;
		}
		dataGridView_10.ScrollBars = ScrollBars.None;
		list = list.OrderByDescending(Class289.class289_0.method_37).ToList();
		DialogResult dialogResult = DKBox.Show(Class16.smethod_0(1649101521), Class16.smethod_0(1649115628), MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
		if (dialogResult != DialogResult.Yes)
		{
			return;
		}
		foreach (int item in list)
		{
			npcGen_0.TriggersAmount--;
			npcGen_0.TriggersList.RemoveAt(item);
			dataGridView_10.Rows.RemoveAt(item);
		}
		dataGridView_10.ScrollBars = ScrollBars.Vertical;
		tabPage_6.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1649101588), Class16.smethod_0(1649100264)), npcGen_0.TriggersAmount);
		DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649101614), Class16.smethod_0(1649101644)), list.Count), Class16.smethod_0(1649115628), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
	}

	private void button_8_Click(object sender, EventArgs e)
	{
		if (list_18 == null || dataGridView_4.Rows.Count <= 0 || dataGridView_5.Rows.Count <= 0)
		{
			return;
		}
		DialogResult dialogResult = DKBox.Show(Class16.smethod_0(1649099630), Class16.smethod_0(1649115628), MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
		if (dialogResult != DialogResult.Yes)
		{
			return;
		}
		list_18 = list_18.OrderByDescending(Class289.class289_0.method_38).ToList();
		int num = list_18.Min();
		dataGridView_5.ClearSelection();
		foreach (int item in list_18)
		{
			npcGen_0.NpcMobList[int_4].Amount_in_group--;
			npcGen_0.NpcMobList[int_4].MobDops.RemoveAt(item);
			dataGridView_5.Rows.RemoveAt(item);
		}
		RefreshRowNpcAndMobs(int_4);
		if (dataGridView_5.Rows.Count > num)
		{
			dataGridView_5.CurrentCell = dataGridView_5.Rows[num].Cells[1];
			dataGridView_5.FirstDisplayedScrollingRowIndex = num;
		}
		else if (dataGridView_5.Rows.Count != 0)
		{
			dataGridView_5.CurrentCell = dataGridView_5.Rows[dataGridView_5.Rows.Count - 1].Cells[1];
			dataGridView_5.FirstDisplayedScrollingRowIndex = dataGridView_5.Rows.Count - 1;
		}
		dataGridView_5_CurrentCellChanged(null, null);
	}

	private void button_28_Click(object sender, EventArgs e)
	{
		if (npcGen_0 == null || list_17 == null || list_17.Count == 0)
		{
			return;
		}
		DialogResult dialogResult = DKBox.Show(Class16.smethod_0(1649101671), Class16.smethod_0(1649115628), MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
		if (dialogResult != DialogResult.Yes)
		{
			return;
		}
		list_17 = list_17.OrderByDescending(Class289.class289_0.method_39).ToList();
		dataGridView_10.ScrollBars = ScrollBars.None;
		int num = list_17.Min();
		dataGridView_10.ClearSelection();
		npcGen_0.TriggersAmount -= list_17.Count;
		foreach (int item in list_17)
		{
			npcGen_0.TriggersList.RemoveAt(item);
			dataGridView_10.Rows.RemoveAt(item);
		}
		dataGridView_10.ScrollBars = ScrollBars.Vertical;
		if (dataGridView_10.Rows.Count > num)
		{
			dataGridView_10.CurrentCell = dataGridView_10.Rows[num].Cells[1];
			dataGridView_10.FirstDisplayedScrollingRowIndex = num;
		}
		else if (dataGridView_10.Rows.Count != 0)
		{
			dataGridView_10.CurrentCell = dataGridView_10.Rows[dataGridView_10.Rows.Count - 1].Cells[1];
			dataGridView_10.FirstDisplayedScrollingRowIndex = dataGridView_10.Rows.Count - 1;
		}
		if (dataGridView_10.Rows.Count == 0)
		{
			dataGridView_10.Rows.Clear();
		}
		dataGridView_10_CurrentCellChanged(null, null);
		tabPage_6.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1649101733), Class16.smethod_0(1649100264)), npcGen_0.TriggersAmount);
	}

	private void textBox_0_DoubleClick(object sender, EventArgs e)
	{
		dynamicObjectsForm_0.SetWindow = 1;
		dynamicObjectsForm_0.ShowDialog(this);
	}

	private void button_4_Click(object sender, EventArgs e)
	{
		ClassPosition coordinates = GetCoordinates();
		if (coordinates != null)
		{
			textBox_7.Text = coordinates.PosX.ToString();
			textBox_8.Text = coordinates.PosY.ToString();
			textBox_12.Text = coordinates.PosZ.ToString();
			textBox_7_Leave(textBox_7, null);
			textBox_7_Leave(textBox_8, null);
			textBox_7_Leave(textBox_12, null);
		}
	}

	private void toolStripMenuItem_21_Click(object sender, EventArgs e)
	{
		if (npcGen_0 == null)
		{
			return;
		}
		DataGridView dataGridView = null;
		int selectedIndex = tabControl_0.SelectedIndex;
		if (tabControl_0.SelectedIndex == 0)
		{
			dataGridView = dataGridView_4;
		}
		else if (tabControl_0.SelectedIndex == 1)
		{
			dataGridView = dataGridView_6;
		}
		else if (tabControl_0.SelectedIndex == 2)
		{
			dataGridView = dataGridView_1;
		}
		else if (tabControl_0.SelectedIndex == 3)
		{
			dataGridView = dataGridView_10;
		}
		List<DataGridViewRow> list = dataGridView.SelectedRows.Cast<DataGridViewRow>().OrderByDescending(Class289.class289_0.method_40).ToList();
		List<DataGridViewRow> list2 = dataGridView.SelectedRows.Cast<DataGridViewRow>().OrderByDescending(Class289.class289_0.method_41).ToList();
		if (list.Count == 0 || list[0].Index == dataGridView.Rows.Count - 1)
		{
			return;
		}
		bool_0 = false;
		foreach (DataGridViewRow item5 in list)
		{
			int index = item5.Index;
			int num = item5.Index + 1;
			dataGridView.Rows.Remove(item5);
			dataGridView.Rows.Insert(num, item5);
			switch (selectedIndex)
			{
			case 0:
			{
				ClassDefaultMonsters item4 = npcGen_0.NpcMobList[index];
				npcGen_0.NpcMobList.RemoveAt(index);
				npcGen_0.NpcMobList.Insert(num, item4);
				break;
			}
			case 1:
			{
				ClassDefaultResources item3 = npcGen_0.ResourcesList[index];
				npcGen_0.ResourcesList.RemoveAt(index);
				npcGen_0.ResourcesList.Insert(num, item3);
				break;
			}
			case 2:
			{
				ClassDynamicObject item2 = npcGen_0.DynamicsList[index];
				npcGen_0.DynamicsList.RemoveAt(index);
				npcGen_0.DynamicsList.Insert(num, item2);
				break;
			}
			case 3:
			{
				ClassTrigger item = npcGen_0.TriggersList[index];
				npcGen_0.TriggersList.RemoveAt(index);
				npcGen_0.TriggersList.Insert(num, item);
				break;
			}
			}
		}
		bool_0 = true;
		dataGridView.CurrentCell = dataGridView.Rows[list[list.Count() - 1].Index].Cells[1];
		foreach (DataGridViewRow item6 in list2)
		{
			dataGridView.Rows[item6.Index].Selected = true;
		}
	}

	private void dataGridView_0_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
	{
		button_12_Click(null, null);
	}

	private void dataGridView_1_CurrentCellChanged(object sender, EventArgs e)
	{
		if (list_3 == null)
		{
			list_3 = new List<int>();
		}
		ClassDynamicObject classDynamicObject;
		Label label;
		object obj;
		if (bool_0 && npcGen_0?.DynamicsList != null)
		{
			list_3 = dataGridView_1.SelectedRows.Cast<DataGridViewRow>().Select(Class289.class289_0.method_42).Where(method_38)
				.OrderByDescending(Class289.class289_0.method_43)
				.ToList();
			if (dataGridView_1.CurrentRow != null)
			{
				int_1 = dataGridView_1.CurrentRow.Index;
				if (int_1 >= 0 && int_1 < npcGen_0.DynamicsList.Count && int_1 < dataGridView_1.Rows.Count)
				{
					classDynamicObject = npcGen_0.DynamicsList[int_1];
					textBox_0.Text = classDynamicObject.Id.ToString();
					label = label_0;
					if (dataGridView_1.Rows[int_1].Cells.Count <= 2)
					{
						obj = string.Empty;
					}
					else
					{
						object value = dataGridView_1.Rows[int_1].Cells[2].Value;
						if (value == null)
						{
							obj = null;
						}
						else
						{
							obj = value.ToString();
							if (obj != null)
							{
								goto IL_01a9;
							}
						}
						obj = string.Empty;
					}
					goto IL_01a9;
				}
			}
			goto IL_030c;
		}
		tabPage_0.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1649101759), Class16.smethod_0(1649101788)), list_3.Count, npcGen_0?.DynobjectAmount ?? 0);
		return;
		IL_01a9:
		label.Text = (string)obj;
		textBox_7.Text = classDynamicObject.X_position.ToString();
		textBox_8.Text = classDynamicObject.Y_position.ToString();
		textBox_12.Text = classDynamicObject.Z_position.ToString();
		textBox_1.Text = classDynamicObject.InCline1.ToString();
		textBox_2.Text = classDynamicObject.InCline2.ToString();
		textBox_3.Text = classDynamicObject.Rotation.ToString();
		textBox_5.Text = classDynamicObject.TriggerId.ToString();
		textBox_4.Text = classDynamicObject.Scale.ToString();
		object obj2 = ((dataGridView_1.Rows[int_1].Cells.Count > 1) ? dataGridView_1.Rows[int_1].Cells[1].Value : null);
		if (obj2 != null)
		{
			string string_ = string.Format(Class16.smethod_0(1649118867), Application.StartupPath, obj2);
			method_13(string_);
		}
		if (showLocationWindow_0 != null && progressBar_0.Value == 0 && list_3.Count != 0 && showLocationWindow_0.Visible)
		{
			showLocationWindow_0.GetCoordinates(method_8(3));
		}
		goto IL_030c;
		IL_030c:
		tabPage_0.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1649101759), Class16.smethod_0(1649101788)), list_3.Count, npcGen_0.DynobjectAmount);
	}

	private void button_2_Click(object sender, EventArgs e)
	{
		if (npcGen_0 == null)
		{
			return;
		}
		int_0 = 3;
		string text = Class16.smethod_0(1649101810);
		list_13 = new List<int>();
		dataGridView_1.ScrollBars = ScrollBars.None;
		dataGridView_9.Rows.Clear();
		if (radioButton_2.Checked)
		{
			Class258 CS_0024_003C_003E8__locals4 = new Class258();
			int.TryParse(textBox_9.Text, out CS_0024_003C_003E8__locals4.int_0);
			list_13 = (from _003C_003Ef__AnonymousType149_0 in npcGen_0.DynamicsList.Select((ClassDynamicObject classDynamicObject_0, int int_0) => _003C_003Ef__AnonymousType149.Create(
				classDynamicObject_0,
				int_0
			))
				where _003C_003Ef__AnonymousType149_0.Item.Id == CS_0024_003C_003E8__locals4.int_0
				select _003C_003Ef__AnonymousType149_0.Index).ToList();
			for (int num = 0; num < list_13.Count(); num++)
			{
				dataGridView_9.Rows.Add(num + 1, dataGridView_1.Rows[list_13[num]].Cells[1].Value, dataGridView_1.Rows[list_13[num]].Cells[2].Value, text);
			}
		}
		else if (radioButton_3.Checked)
		{
			int num2 = 1;
			for (int num3 = 0; num3 < dataGridView_1.Rows.Count; num3++)
			{
				object value = dataGridView_1.Rows[num3].Cells[2].Value;
				if (value != null && value.ToString()?.ToLower()?.Contains(textBox_10.Text.ToLower()) == true)
				{
					list_13.Add(num3);
					dataGridView_9.Rows.Add(num2, dataGridView_1.Rows[num3].Cells[1].Value, dataGridView_1.Rows[num3].Cells[2].Value, text);
					num2++;
				}
			}
		}
		else if (radioButton_4.Checked)
		{
			Class260 CS_0024_003C_003E8__locals5 = new Class260();
			int.TryParse(textBox_11.Text, out CS_0024_003C_003E8__locals5.int_0);
			list_13 = (from _003C_003Ef__AnonymousType149_0 in npcGen_0.DynamicsList.Select((ClassDynamicObject classDynamicObject_0, int int_0) => _003C_003Ef__AnonymousType149.Create(
				classDynamicObject_0,
				int_0
			))
				where _003C_003Ef__AnonymousType149_0.Item.TriggerId == CS_0024_003C_003E8__locals5.int_0
				select _003C_003Ef__AnonymousType149_0.Index).ToList();
			for (int num4 = 0; num4 < list_13.Count; num4++)
			{
				dataGridView_9.Rows.Add(num4 + 1, dataGridView_1.Rows[list_13[num4]].Cells[1].Value, dataGridView_1.Rows[list_13[num4]].Cells[2].Value, text);
			}
		}
		dataGridView_1.ScrollBars = ScrollBars.Vertical;
	}

	private void textBox_9_DoubleClick(object sender, EventArgs e)
	{
		dynamicObjectsForm_0.SetWindow = 2;
		dynamicObjectsForm_0.ShowDialog(this);
	}

	private void textBox_9_TextChanged(object sender, EventArgs e)
	{
		Class271 @class = new Class271();
		if (npcGen_0 != null)
		{
			int.TryParse(textBox_9.Text, out @class.int_0);
			int num = list_1.FindIndex(@class.method_0);
			if (num != -1)
			{
				textBox_10.Text = list_1[num].Name;
			}
			else
			{
				textBox_10.Text = string.Empty;
			}
		}
	}

	private void textBox_7_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			textBox_7_Leave(sender, null);
		}
	}

	private void textBox_7_Leave(object sender, EventArgs e)
	{
		Control control = sender as Control;
		if (list_3 == null)
		{
			return;
		}
		string name = control.Name;
		if (name == null)
		{
			return;
		}
		byte result;
		switch (name.Length)
		{
		case 11:
		{
			int result2;
			float result3;
			switch (name[1])
			{
			case 'T':
				if (!(name == Class16.smethod_0(1649109898)))
				{
					break;
				}
				int.TryParse(textBox_5.Text, out result2);
				{
					foreach (int item in list_3)
					{
						dataGridView_1.Rows[item].Cells[3].Value = result2;
						npcGen_0.DynamicsList[item].TriggerId = result2;
					}
					break;
				}
			case 'X':
				if (!(name == Class16.smethod_0(1649109074)))
				{
					break;
				}
				float.TryParse(textBox_7.Text, out result3);
				{
					foreach (int item2 in list_3)
					{
						npcGen_0.DynamicsList[item2].X_position = result3;
					}
					break;
				}
			case 'Y':
				if (!(name == Class16.smethod_0(1649109056)))
				{
					break;
				}
				float.TryParse(textBox_8.Text, out result3);
				{
					foreach (int item3 in list_3)
					{
						npcGen_0.DynamicsList[item3].Y_position = result3;
					}
					break;
				}
			case 'Z':
				if (!(name == Class16.smethod_0(1649109046)))
				{
					break;
				}
				float.TryParse(textBox_12.Text, out result3);
				{
					foreach (int item4 in list_3)
					{
						npcGen_0.DynamicsList[item4].Z_position = result3;
					}
					break;
				}
			case 'I':
				if (!(name == Class16.smethod_0(1649109624)))
				{
					break;
				}
				int.TryParse(textBox_0.Text, out result2);
				{
					foreach (int item5 in list_3)
					{
						npcGen_0.DynamicsList[item5].Id = result2;
						dataGridView_1.Rows[item5].Cells[1].Value = result2;
						dataGridView_1.Rows[item5].Cells[2].Value = label_0.Text;
					}
					break;
				}
			}
			break;
		}
		case 9:
			switch (name[8])
			{
			case 'n':
				if (!(name == Class16.smethod_0(1649109930)))
				{
					break;
				}
				byte.TryParse(textBox_3.Text, out result);
				{
					foreach (int item6 in list_3)
					{
						npcGen_0.DynamicsList[item6].Rotation = result;
					}
					break;
				}
			case '2':
				if (!(name == Class16.smethod_0(1649109960)))
				{
					break;
				}
				byte.TryParse(textBox_2.Text, out result);
				{
					foreach (int item7 in list_3)
					{
						npcGen_0.DynamicsList[item7].InCline2 = result;
					}
					break;
				}
			case '1':
				if (!(name == Class16.smethod_0(1649110012)))
				{
					break;
				}
				byte.TryParse(textBox_1.Text, out result);
				{
					foreach (int item8 in list_3)
					{
						npcGen_0.DynamicsList[item8].InCline1 = result;
					}
					break;
				}
			}
			break;
		case 6:
			if (!(name == Class16.smethod_0(1649109710)))
			{
				break;
			}
			byte.TryParse(textBox_4.Text, out result);
			{
				foreach (int item9 in list_3)
				{
					npcGen_0.DynamicsList[item9].Scale = result;
				}
				break;
			}
		}
	}

	private void dataGridView_2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
	{
		try
		{
			object value = dataGridView_2.Rows[e.RowIndex].Cells[2].Value;
			object obj;
			if (value == null)
			{
				obj = null;
			}
			else
			{
				obj = value.ToString();
				if (obj != null)
				{
					goto IL_003b;
				}
			}
			obj = string.Empty;
			goto IL_003b;
			IL_003b:
			string text = (string)obj;
			if (text == Class16.smethod_0(1649102240))
			{
				dataGridView_4.CurrentCell = dataGridView_4.Rows[Convert.ToInt32(dataGridView_2.Rows[e.RowIndex].Cells[1].Value) - 1].Cells[1];
				tabControl_0.SelectedIndex = 0;
			}
			else if (text == Class16.smethod_0(1649008358))
			{
				dataGridView_6.CurrentCell = dataGridView_6.Rows[Convert.ToInt32(dataGridView_2.Rows[e.RowIndex].Cells[1].Value) - 1].Cells[1];
				tabControl_0.SelectedIndex = 1;
			}
			else if (text == Class16.smethod_0(1649102268))
			{
				dataGridView_1.CurrentCell = dataGridView_1.Rows[Convert.ToInt32(dataGridView_2.Rows[e.RowIndex].Cells[1].Value) - 1].Cells[1];
				tabControl_0.SelectedIndex = 2;
			}
		}
		catch
		{
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649100812)), Class16.smethod_0(1649115628), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
	}

	private void dataGridView_4_CurrentCellChanged(object sender, EventArgs e)
	{
		if (!bool_0)
		{
			return;
		}
		dataGridView_5.Rows.Clear();
		list_10 = dataGridView_4.SelectedRows.Cast<DataGridViewRow>().Select(Class289.class289_0.method_48).OrderByDescending(Class289.class289_0.method_49)
			.ToList();
		if (dataGridView_4.CurrentRow != null)
		{
			int_4 = dataGridView_4.CurrentRow.Index;
			if (int_4 != -1 && npcGen_0?.NpcMobList != null && int_4 < npcGen_0.NpcMobList.Count)
			{
				ClassDefaultMonsters classDefaultMonsters = npcGen_0.NpcMobList[int_4];
				comboBox_7.SelectedIndex = classDefaultMonsters.Location;
				textBox_17.Text = classDefaultMonsters.Amount_in_group.ToString();
				textBox_58.Text = classDefaultMonsters.X_position.ToString();
				textBox_61.Text = classDefaultMonsters.Y_position.ToString();
				textBox_64.Text = classDefaultMonsters.Z_position.ToString();
				textBox_59.Text = classDefaultMonsters.X_direction.ToString();
				textBox_62.Text = classDefaultMonsters.Y_direction.ToString();
				textBox_65.Text = classDefaultMonsters.Z_direction.ToString();
				textBox_60.Text = classDefaultMonsters.X_random.ToString();
				textBox_63.Text = classDefaultMonsters.Y_random.ToString();
				textBox_66.Text = classDefaultMonsters.Z_random.ToString();
				comboBox_8.SelectedIndex = classDefaultMonsters.Type;
				textBox_18.Text = classDefaultMonsters.iGroupType.ToString();
				checkBox_6.Checked = Convert.ToBoolean(classDefaultMonsters.BInitGen);
				checkBox_5.Checked = Convert.ToBoolean(classDefaultMonsters.bAutoRevive);
				checkBox_4.Checked = Convert.ToBoolean(classDefaultMonsters.BValicOnce);
				textBox_6.Text = classDefaultMonsters.dwGenId.ToString();
				textBox_42.Text = classDefaultMonsters.Trigger_id.ToString();
				textBox_20.Text = classDefaultMonsters.Life_time.ToString();
				textBox_19.Text = classDefaultMonsters.MaxRespawnTime.ToString();
				for (int i = 0; i < classDefaultMonsters.Amount_in_group; i++)
				{
					string text = Class16.smethod_0(1648942867);
					text = ((ItemsToolTip.eLC == null) ? Class16.smethod_0(1648942867) : ((classDefaultMonsters.MobDops[i].Id == 0) ? Class16.smethod_0(1648936686) : smethod_2(ItemType.NpcOrMobOrMine, classDefaultMonsters.MobDops[i].Id)));
					dataGridView_5.Rows.Add(i + 1, classDefaultMonsters.MobDops[i].Id, text);
					if (classDefaultMonsters.Type == 1)
					{
						dataGridView_5.Rows[i].Cells[1].Style.ForeColor = Color.FromArgb(251, 251, 107);
						dataGridView_5.Rows[i].Cells[2].Style.ForeColor = Color.FromArgb(251, 251, 107);
					}
				}
			}
			if (showLocationWindow_0 != null && progressBar_0.Value == 0 && list_10.Count != 0 && showLocationWindow_0.Visible)
			{
				showLocationWindow_0.GetCoordinates(method_8(1));
			}
			dataGridView_5_CurrentCellChanged(null, null);
		}
		tabPage_2.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1649100834), Class16.smethod_0(1649099594)), list_10.Count, npcGen_0?.NpcMobsAmount ?? 0);
	}

	private void button_11_Click(object sender, EventArgs e)
	{
		if (npcGen_0 == null)
		{
			return;
		}
		int_0 = 1;
		string text = Class16.smethod_0(1649102347);
		list_14 = new List<int>();
		dataGridView_9.ScrollBars = ScrollBars.None;
		dataGridView_9.Rows.Clear();
		if (radioButton_5.Checked)
		{
			Class275 CS_0024_003C_003E8__locals6 = new Class275();
			int.TryParse(textBox_13.Text, out CS_0024_003C_003E8__locals6.int_0);
			list_14 = (from _003C_003Ef__AnonymousType149_0 in npcGen_0.NpcMobList.Select((ClassDefaultMonsters classDefaultMonsters_0, int int_0) => _003C_003Ef__AnonymousType149.Create(
				classDefaultMonsters_0,
				int_0
			))
				where _003C_003Ef__AnonymousType149_0.Item.MobDops.Any(CS_0024_003C_003E8__locals6.method_1)
				select _003C_003Ef__AnonymousType149_0.Index).ToList();
			for (int num = 0; num < list_14.Count(); num++)
			{
				dataGridView_9.Rows.Add(num + 1, dataGridView_4.Rows[list_14[num]].Cells[1].Value, dataGridView_4.Rows[list_14[num]].Cells[2].Value, text);
			}
		}
		else if (radioButton_6.Checked)
		{
			int num2 = 1;
			for (int num3 = 0; num3 < dataGridView_4.Rows.Count; num3++)
			{
				object value = dataGridView_4.Rows[num3].Cells[2].Value;
				if (value != null && value.ToString()?.ToLower()?.Contains(textBox_14.Text.ToLower()) == true)
				{
					list_14.Add(num3);
					dataGridView_9.Rows.Add(num2, dataGridView_4.Rows[num3].Cells[1].Value, dataGridView_4.Rows[num3].Cells[2].Value, text);
					num2++;
				}
			}
		}
		else if (radioButton_8.Checked)
		{
			Class287 CS_0024_003C_003E8__locals7 = new Class287();
			int.TryParse(textBox_13.Text, out CS_0024_003C_003E8__locals7.int_0);
			list_14 = (from _003C_003Ef__AnonymousType149_0 in npcGen_0.NpcMobList.Select((ClassDefaultMonsters classDefaultMonsters_0, int int_0) => _003C_003Ef__AnonymousType149.Create(
				classDefaultMonsters_0,
				int_0
			))
				where _003C_003Ef__AnonymousType149_0.Item.Trigger_id == CS_0024_003C_003E8__locals7.int_0
				select _003C_003Ef__AnonymousType149_0.Index).ToList();
			for (int num4 = 0; num4 < list_14.Count; num4++)
			{
				dataGridView_9.Rows.Add(num4 + 1, dataGridView_4.Rows[list_14[num4]].Cells[1].Value, dataGridView_4.Rows[list_14[num4]].Cells[2].Value, text);
			}
		}
		else if (radioButton_7.Checked)
		{
			Class272 CS_0024_003C_003E8__locals8 = new Class272();
			int.TryParse(textBox_15.Text, out CS_0024_003C_003E8__locals8.int_0);
			list_14 = (from _003C_003Ef__AnonymousType149_0 in npcGen_0.NpcMobList.Select((ClassDefaultMonsters classDefaultMonsters_0, int int_0) => _003C_003Ef__AnonymousType149.Create(
				classDefaultMonsters_0,
				int_0
			))
				where _003C_003Ef__AnonymousType149_0.Item.MobDops.Any(CS_0024_003C_003E8__locals8.method_1)
				select _003C_003Ef__AnonymousType149_0.Index).ToList();
			for (int num5 = 0; num5 < list_14.Count; num5++)
			{
				dataGridView_9.Rows.Add(num5 + 1, dataGridView_4.Rows[list_14[num5]].Cells[1].Value, dataGridView_4.Rows[list_14[num5]].Cells[2].Value, text);
			}
		}
		dataGridView_9.ScrollBars = ScrollBars.Vertical;
	}

	private void textBox_13_DoubleClick(object sender, EventArgs e)
	{
		int.TryParse(textBox_13.Text, out var result);
		int num = method_0(ItemType.NpcOrMobOrMine, result);
		if (num > 0)
		{
			textBox_13.Text = num.ToString();
			SetId(num, 1, 2);
		}
	}

	private void textBox_13_TextChanged(object sender, EventArgs e)
	{
		if (npcGen_0 != null)
		{
			int.TryParse(textBox_13.Text, out var result);
			if (ItemsToolTip.eLC != null && result != 0)
			{
				textBox_14.Text = smethod_2(ItemType.NpcOrMobOrMine, result);
			}
			else
			{
				textBox_14.Text = string.Empty;
			}
		}
	}

	private void toolStripMenuItem_3_Click(object sender, EventArgs e)
	{
		if (npcGen_0 != null && dataGridView_4.CurrentRow != null && dataGridView_4.CurrentRow.Index != -1)
		{
			ClassDefaultMonsters item = npcGen_0.NpcMobList[dataGridView_4.CurrentRow.Index];
			npcGen_0.NpcMobList.RemoveAt(dataGridView_4.CurrentRow.Index);
			npcGen_0.NpcMobList.Insert(npcGen_0.NpcMobList.Count, item);
			DataGridViewRow dataGridViewRow = dataGridView_4.Rows[dataGridView_4.CurrentRow.Index];
			dataGridView_4.Rows.Remove(dataGridViewRow);
			dataGridView_4.Rows.Insert(dataGridView_4.Rows.Count, dataGridViewRow);
			dataGridView_4.CurrentCell = dataGridView_4.Rows[dataGridView_4.Rows.Count - 1].Cells[1];
		}
	}

	private void toolStripButton_6_Click(object sender, EventArgs e)
	{
		if (npcGen_0 != null)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			if (tabControl_0.SelectedIndex == 0)
			{
				if (list_10.Count == 0)
				{
					return;
				}
				saveFileDialog.FileName = string.Format(Class16.smethod_0(1649100871), list_10.Count);
				saveFileDialog.Filter = Class16.smethod_0(1649100900);
				if (saveFileDialog.ShowDialog() != DialogResult.OK)
				{
					return;
				}
				try
				{
					ExistenceExportData existenceExportData = new ExistenceExportData
					{
						Type = Class16.smethod_0(1649102347),
						Version = Class16.smethod_0(1648898309),
						ExportDate = DateTime.Now,
						Data = new List<ClassDefaultMonsters>()
					};
					foreach (int item in list_10)
					{
						if (item < npcGen_0.NpcMobList.Count)
						{
							existenceExportData.Data.Add(npcGen_0.NpcMobList[item]);
						}
					}
					string contents = JsonConvert.SerializeObject((object)existenceExportData, (Newtonsoft.Json.Formatting)1);
					File.WriteAllText(saveFileDialog.FileName, contents);
					DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649100929), Class16.smethod_0(1649100989)), existenceExportData.Data.Count), Class16.smethod_0(1649115628), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					return;
				}
				catch (Exception ex)
				{
					SentryHelper.CaptureException(ex, Class16.smethod_0(1649101033));
					DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649101086), Class16.smethod_0(1649101115)), ex.Message), Class16.smethod_0(1649115628), MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
				}
			}
			if (tabControl_0.SelectedIndex == 1)
			{
				if (list_12.Count == 0)
				{
					return;
				}
				saveFileDialog.FileName = string.Format(Class16.smethod_0(1649101158), list_12.Count);
				saveFileDialog.Filter = Class16.smethod_0(1649101178);
				if (saveFileDialog.ShowDialog() != DialogResult.OK)
				{
					return;
				}
				try
				{
					ResourcesExportData resourcesExportData = new ResourcesExportData
					{
						Type = Class16.smethod_0(1649008358),
						Version = Class16.smethod_0(1648898309),
						ExportDate = DateTime.Now,
						Data = new List<ClassDefaultResources>()
					};
					foreach (int item2 in list_12)
					{
						if (item2 < npcGen_0.ResourcesList.Count)
						{
							resourcesExportData.Data.Add(npcGen_0.ResourcesList[item2]);
						}
					}
					string contents2 = JsonConvert.SerializeObject((object)resourcesExportData, (Newtonsoft.Json.Formatting)1);
					File.WriteAllText(saveFileDialog.FileName, contents2);
					DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649101222), Class16.smethod_0(1649101265)), resourcesExportData.Data.Count), Class16.smethod_0(1649115628), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					return;
				}
				catch (Exception ex2)
				{
					SentryHelper.CaptureException(ex2, Class16.smethod_0(1649101033));
					DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649096204), Class16.smethod_0(1649101115)), ex2.Message), Class16.smethod_0(1649115628), MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
				}
			}
			if (tabControl_0.SelectedIndex == 2)
			{
				if (list_3.Count == 0)
				{
					return;
				}
				saveFileDialog.FileName = string.Format(Class16.smethod_0(1649096235), list_3.Count);
				saveFileDialog.Filter = Class16.smethod_0(1649102689);
				if (saveFileDialog.ShowDialog() != DialogResult.OK)
				{
					return;
				}
				try
				{
					DynamicObjectsExportData dynamicObjectsExportData = new DynamicObjectsExportData
					{
						Type = Class16.smethod_0(1649102740),
						Version = Class16.smethod_0(1648898309),
						ExportDate = DateTime.Now,
						Data = new List<ClassDynamicObject>()
					};
					foreach (int item3 in list_3)
					{
						if (item3 < npcGen_0.DynamicsList.Count)
						{
							dynamicObjectsExportData.Data.Add(npcGen_0.DynamicsList[item3]);
						}
					}
					string contents3 = JsonConvert.SerializeObject((object)dynamicObjectsExportData, (Newtonsoft.Json.Formatting)1);
					File.WriteAllText(saveFileDialog.FileName, contents3);
					DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649096277), Class16.smethod_0(1649096334)), dynamicObjectsExportData.Data.Count), Class16.smethod_0(1649115628), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					return;
				}
				catch (Exception ex3)
				{
					SentryHelper.CaptureException(ex3, Class16.smethod_0(1649101033));
					DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649096391), Class16.smethod_0(1649101115)), ex3.Message), Class16.smethod_0(1649115628), MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
				}
			}
			if (tabControl_0.SelectedIndex != 3 || list_17.Count == 0)
			{
				return;
			}
			saveFileDialog.FileName = string.Format(Class16.smethod_0(1649096430), list_17.Count);
			saveFileDialog.Filter = Class16.smethod_0(1649102828);
			if (saveFileDialog.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			try
			{
				TriggersExportData triggersExportData = new TriggersExportData
				{
					Type = Class16.smethod_0(1649101832),
					Version = Class16.smethod_0(1648898309),
					ExportDate = DateTime.Now,
					Data = new List<ClassTrigger>()
				};
				foreach (int item4 in list_17)
				{
					if (item4 < npcGen_0.TriggersList.Count)
					{
						triggersExportData.Data.Add(npcGen_0.TriggersList[item4]);
					}
				}
				string contents4 = JsonConvert.SerializeObject((object)triggersExportData, (Newtonsoft.Json.Formatting)1);
				File.WriteAllText(saveFileDialog.FileName, contents4);
				DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649096449), Class16.smethod_0(1649096499)), triggersExportData.Data.Count), Class16.smethod_0(1649115628), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			catch (Exception ex4)
			{
				SentryHelper.CaptureException(ex4, Class16.smethod_0(1649101033));
				DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649096557), Class16.smethod_0(1649101115)), ex4.Message), Class16.smethod_0(1649115628), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
		}
		DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649101889)), Class16.smethod_0(1649115628), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
	}

	private void NPCGenEditorForm_FormClosed(object sender, FormClosedEventArgs e)
	{
		XmlTextWriter xmlTextWriter = new XmlTextWriter(string.Format(Application.StartupPath + Class16.smethod_0(1649096596)), Encoding.UTF8)
		{
			Formatting = System.Xml.Formatting.Indented,
			IndentChar = '\t',
			Indentation = 1,
			QuoteChar = '\''
		};
		xmlTextWriter.WriteStartDocument();
		xmlTextWriter.WriteStartElement(Class16.smethod_0(1648898290));
		xmlTextWriter.WriteStartAttribute(Class16.smethod_0(1648898341));
		xmlTextWriter.WriteString(Class16.smethod_0(1649102019));
		xmlTextWriter.WriteEndAttribute();
		xmlTextWriter.WriteStartElement(Class16.smethod_0(1649068916));
		xmlTextWriter.WriteElementString(Class16.smethod_0(1648942674), Class16.smethod_0(1649096630));
		xmlTextWriter.WriteElementString(Class16.smethod_0(1649096632), TDark.IsDarkMode ? Class16.smethod_0(1648934967) : Class16.smethod_0(1648934925));
		if (!string.IsNullOrWhiteSpace(textBox_21.Text))
		{
			xmlTextWriter.WriteElementString(Class16.smethod_0(1649096662), textBox_21.Text);
		}
		else
		{
			xmlTextWriter.WriteElementString(Class16.smethod_0(1649096662), Class16.smethod_0(1649096679));
		}
		if (!string.IsNullOrWhiteSpace(textBox_37.Text))
		{
			xmlTextWriter.WriteElementString(Class16.smethod_0(1649096688), textBox_37.Text);
		}
		else
		{
			xmlTextWriter.WriteElementString(Class16.smethod_0(1649096688), Class16.smethod_0(1649096679));
		}
		if (comboBox_5.SelectedIndex == -1)
		{
			comboBox_5.SelectedIndex = 0;
		}
		if (comboBox_10.SelectedIndex == -1)
		{
			comboBox_10.SelectedIndex = 0;
		}
		if (comboBox_6.SelectedIndex == -1)
		{
			comboBox_6.SelectedIndex = 0;
		}
		if (comboBox_11.SelectedIndex == -1)
		{
			comboBox_11.SelectedIndex = 0;
		}
		if (comboBox_4.SelectedIndex == -1)
		{
			comboBox_4.SelectedIndex = 0;
		}
		if (comboBox_9.SelectedIndex == -1)
		{
			comboBox_9.SelectedIndex = 0;
		}
		xmlTextWriter.WriteElementString(Class16.smethod_0(1649095683), comboBox_16.SelectedIndex.ToString());
		xmlTextWriter.WriteElementString(Class16.smethod_0(1649095711), string.Format(Class16.smethod_0(1649095734), comboBox_5.SelectedIndex, comboBox_10.SelectedIndex));
		xmlTextWriter.WriteElementString(Class16.smethod_0(1649095748), string.Format(Class16.smethod_0(1649095734), comboBox_6.SelectedIndex, comboBox_11.SelectedIndex));
		xmlTextWriter.WriteElementString(Class16.smethod_0(1649095762), string.Format(Class16.smethod_0(1649095734), comboBox_4.SelectedIndex, comboBox_9.SelectedIndex));
		xmlTextWriter.WriteEndElement();
		xmlTextWriter.WriteStartElement(Class16.smethod_0(1649095791));
		xmlTextWriter.WriteElementString(Class16.smethod_0(1649095810), numericUpDown_3.Value.ToString());
		xmlTextWriter.WriteElementString(Class16.smethod_0(1649095837), numericUpDown_2.Value.ToString());
		xmlTextWriter.WriteElementString(Class16.smethod_0(1649095860), numericUpDown_4.Value.ToString());
		xmlTextWriter.WriteElementString(Class16.smethod_0(1649095880), numericUpDown_5.Value.ToString());
		xmlTextWriter.WriteElementString(Class16.smethod_0(1649095904), comboBox_0.SelectedIndex.ToString());
		xmlTextWriter.WriteElementString(Class16.smethod_0(1649095929), comboBox_1.SelectedIndex.ToString());
		xmlTextWriter.WriteEndElement();
		xmlTextWriter.WriteStartElement(Class16.smethod_0(1649095958));
		xmlTextWriter.WriteElementString(Class16.smethod_0(1649095977), numericUpDown_7.Value.ToString());
		xmlTextWriter.WriteElementString(Class16.smethod_0(1649096004), numericUpDown_6.Value.ToString());
		xmlTextWriter.WriteElementString(Class16.smethod_0(1649096019), numericUpDown_8.Value.ToString());
		xmlTextWriter.WriteElementString(Class16.smethod_0(1649096055), numericUpDown_9.Value.ToString());
		xmlTextWriter.WriteEndElement();
		xmlTextWriter.WriteStartElement(Class16.smethod_0(1649096079));
		xmlTextWriter.WriteElementString(Class16.smethod_0(1649096097), numericUpDown_0.Value.ToString());
		xmlTextWriter.WriteElementString(Class16.smethod_0(1649096120), numericUpDown_1.Value.ToString());
		xmlTextWriter.WriteEndElement();
		xmlTextWriter.WriteEndDocument();
		xmlTextWriter.Close();
	}

	private void NPCGenEditorForm_Load(object sender, EventArgs e)
	{
		list_2 = new List<DefaultInformation>();
		list_1 = new List<DefaultInformation>();
		try
		{
			string path = Application.StartupPath + Class16.smethod_0(1649096138);
			if (!File.Exists(path))
			{
				File.WriteAllText(path, Class16.smethod_0(1649096162));
			}
			if (File.Exists(path))
			{
				StreamReader streamReader = new StreamReader(path);
				try
				{
					string text;
					while ((text = streamReader.ReadLine()) != null)
					{
						if (!string.IsNullOrWhiteSpace(text))
						{
							string[] array = text.Split(new string[1] { Class16.smethod_0(1649097844) }, StringSplitOptions.None);
							if (array.Length >= 2 && int.TryParse(array[0], out var result))
							{
								DefaultInformation item = new DefaultInformation
								{
									Id = result,
									Name = array[1]
								};
								list_1.Add(item);
							}
						}
					}
				}
				finally
				{
					((IDisposable)streamReader).Dispose();
				}
			}
		}
		catch
		{
		}
		comboBox_3.SelectedIndex = 0;
		method_11();
		try
		{
			if (File.Exists(Application.StartupPath + Class16.smethod_0(1649096596)))
			{
				XmlTextReader xmlTextReader = new XmlTextReader(string.Format(Application.StartupPath + Class16.smethod_0(1649096596)));
				try
				{
					xmlTextReader.ReadToFollowing(Class16.smethod_0(1648942674));
					xmlTextReader.ReadElementContentAsString();
					xmlTextReader.ReadToFollowing(Class16.smethod_0(1649096632));
					Convert.ToInt32(xmlTextReader.ReadElementContentAsString());
					xmlTextReader.ReadToFollowing(Class16.smethod_0(1649096662));
					textBox_21.Text = xmlTextReader.ReadElementContentAsString();
					xmlTextReader.ReadToFollowing(Class16.smethod_0(1649096688));
					textBox_37.Text = xmlTextReader.ReadElementContentAsString();
					xmlTextReader.ReadToFollowing(Class16.smethod_0(1649095683));
					comboBox_16.SelectedIndex = Convert.ToInt32(xmlTextReader.ReadElementContentAsString());
					xmlTextReader.ReadToFollowing(Class16.smethod_0(1649095711));
					string[] array2 = xmlTextReader.ReadElementContentAsString().Split('+');
					comboBox_5.SelectedIndex = Convert.ToInt32(array2[0]);
					comboBox_10.SelectedIndex = Convert.ToInt32(array2[1]);
					xmlTextReader.ReadToFollowing(Class16.smethod_0(1649095748));
					string[] array3 = xmlTextReader.ReadElementContentAsString().Split('+');
					comboBox_6.SelectedIndex = Convert.ToInt32(array3[0]);
					comboBox_11.SelectedIndex = Convert.ToInt32(array3[1]);
					xmlTextReader.ReadToFollowing(Class16.smethod_0(1649095762));
					string[] array4 = xmlTextReader.ReadElementContentAsString().Split('+');
					comboBox_4.SelectedIndex = Convert.ToInt32(array4[0]);
					comboBox_9.SelectedIndex = Convert.ToInt32(array4[1]);
					comboBox_5_SelectedIndexChanged(comboBox_5, null);
					comboBox_5_SelectedIndexChanged(comboBox_10, null);
					comboBox_5_SelectedIndexChanged(comboBox_6, null);
					comboBox_5_SelectedIndexChanged(comboBox_11, null);
					comboBox_5_SelectedIndexChanged(comboBox_4, null);
					comboBox_5_SelectedIndexChanged(comboBox_9, null);
					xmlTextReader.ReadToFollowing(Class16.smethod_0(1649095810));
					numericUpDown_3.Value = Convert.ToDecimal(xmlTextReader.ReadElementContentAsString());
					xmlTextReader.ReadToFollowing(Class16.smethod_0(1649095837));
					numericUpDown_2.Value = Convert.ToDecimal(xmlTextReader.ReadElementContentAsString());
					xmlTextReader.ReadToFollowing(Class16.smethod_0(1649095860));
					numericUpDown_4.Value = Convert.ToDecimal(xmlTextReader.ReadElementContentAsString());
					xmlTextReader.ReadToFollowing(Class16.smethod_0(1649095880));
					numericUpDown_5.Value = Convert.ToDecimal(xmlTextReader.ReadElementContentAsString());
					xmlTextReader.ReadToFollowing(Class16.smethod_0(1649095904));
					int num = Convert.ToInt32(xmlTextReader.ReadElementContentAsString());
					if (num < 0)
					{
						num = 0;
					}
					comboBox_0.SelectedIndex = num;
					xmlTextReader.ReadToFollowing(Class16.smethod_0(1649095929));
					int num2 = Convert.ToInt32(xmlTextReader.ReadElementContentAsString());
					if (num2 < 0)
					{
						num2 = 0;
					}
					comboBox_1.SelectedIndex = num2;
					xmlTextReader.ReadToFollowing(Class16.smethod_0(1649095977));
					numericUpDown_7.Value = Convert.ToDecimal(xmlTextReader.ReadElementContentAsString());
					xmlTextReader.ReadToFollowing(Class16.smethod_0(1649096004));
					numericUpDown_6.Value = Convert.ToDecimal(xmlTextReader.ReadElementContentAsString());
					xmlTextReader.ReadToFollowing(Class16.smethod_0(1649096019));
					numericUpDown_8.Value = Convert.ToDecimal(xmlTextReader.ReadElementContentAsString());
					xmlTextReader.ReadToFollowing(Class16.smethod_0(1649096055));
					numericUpDown_9.Value = Convert.ToDecimal(xmlTextReader.ReadElementContentAsString());
					xmlTextReader.ReadToFollowing(Class16.smethod_0(1649096097));
					numericUpDown_0.Value = Convert.ToDecimal(xmlTextReader.ReadElementContentAsString());
					xmlTextReader.ReadToFollowing(Class16.smethod_0(1649096120));
					numericUpDown_1.Value = Convert.ToDecimal(xmlTextReader.ReadElementContentAsString());
				}
				finally
				{
					((IDisposable)xmlTextReader).Dispose();
				}
			}
			else
			{
				comboBox_0.SelectedIndex = 0;
				comboBox_1.SelectedIndex = 0;
				comboBox_16.SelectedIndex = 0;
				comboBox_5.SelectedIndex = 0;
				comboBox_10.SelectedIndex = 1;
				comboBox_6.SelectedIndex = 0;
				comboBox_11.SelectedIndex = 2;
				comboBox_4.SelectedIndex = 0;
				comboBox_9.SelectedIndex = 3;
				comboBox_5_SelectedIndexChanged(comboBox_5, null);
				comboBox_5_SelectedIndexChanged(comboBox_10, null);
				comboBox_5_SelectedIndexChanged(comboBox_6, null);
				comboBox_5_SelectedIndexChanged(comboBox_11, null);
				comboBox_5_SelectedIndexChanged(comboBox_4, null);
				comboBox_5_SelectedIndexChanged(comboBox_9, null);
			}
		}
		catch
		{
		}
		list_7 = new List<MapLoadedInformation>();
		if (File.Exists(Application.StartupPath + Class16.smethod_0(1649097880)))
		{
			StreamReader streamReader2 = new StreamReader(Application.StartupPath + Class16.smethod_0(1649097880));
			try
			{
				while (!streamReader2.EndOfStream)
				{
					string text2 = streamReader2.ReadLine();
					if (string.IsNullOrWhiteSpace(text2))
					{
						continue;
					}
					string[] array5 = text2.Split(new string[1] { Class16.smethod_0(1649097844) }, StringSplitOptions.None);
					if (array5.Length >= 2)
					{
						MapLoadedInformation mapLoadedInformation = new MapLoadedInformation
						{
							Name = array5[0]
						};
						string[] array6 = array5[1].Split(new string[1] { Class16.smethod_0(1648928028) }, StringSplitOptions.RemoveEmptyEntries);
						if (array6.Length >= 2)
						{
							int.TryParse(array6[0], out mapLoadedInformation.Width);
							int.TryParse(array6[1], out mapLoadedInformation.Height);
							list_7.Add(mapLoadedInformation);
						}
					}
				}
			}
			finally
			{
				((IDisposable)streamReader2).Dispose();
			}
		}
		method_20();
		method_21();
		method_17();
	}

	private void method_17()
	{
		bool visible = CommonStorage.License != null && CommonStorage.License.Special.npcgen_mapview;
		bool visible2 = CommonStorage.License != null && CommonStorage.License.Special.livenpceditor;
		button_0.Visible = visible;
		comboBox_12.Visible = visible;
		button_9.Visible = visible2;
		button_21.Visible = visible2;
		button_4.Visible = visible2;
	}

	private void toolStripMenuItem_8_Click(object sender, EventArgs e)
	{
		if (npcGen_0 != null)
		{
			Class286 @class = new Class286();
			@class.int_0 = 0;
			if (tabControl_0.SelectedIndex == 0)
			{
				int.TryParse(textBox_42.Text, out @class.int_0);
			}
			else if (tabControl_0.SelectedIndex == 1)
			{
				int.TryParse(textBox_31.Text, out @class.int_0);
			}
			else if (tabControl_0.SelectedIndex == 2)
			{
				int.TryParse(textBox_5.Text, out @class.int_0);
			}
			int num = npcGen_0.TriggersList.FindIndex(@class.method_0);
			if (num != -1)
			{
				dataGridView_10.CurrentCell = dataGridView_10.Rows[num].Cells[1];
				tabControl_0.SelectedIndex = 3;
			}
			else
			{
				DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649097897)), Class16.smethod_0(1649115628), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}
	}

	private void dataGridView_3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
	{
		button_13_Click(null, null);
	}

	private void dataGridView_3_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
	{
		if (HINTS.ToolTipWindow != null)
		{
			HINTS.ToolTipWindow.SmoothHide();
		}
	}

	private void dataGridView_3_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
	{
		if ((e.ColumnIndex > 0) & (e.RowIndex >= 0))
		{
			object value = dataGridView_3.Rows[e.RowIndex].Cells[1].Value;
			if (value != null && int.TryParse(value.ToString(), out var result) && result > 0 && HINTS.ToolTipWindow != null)
			{
				HINTS.ToolTipWindow.SetOwnerHandle(dataGridView_3.Handle);
				HINTS.ToolTipWindow.ShowItemToolTip(result, ItemType.NpcOrMobOrMine);
			}
		}
	}

	private void comboBox_7_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			comboBox_7_Leave(sender, null);
		}
	}

	private void comboBox_7_Leave(object sender, EventArgs e)
	{
		if (list_10 == null || npcGen_0 == null)
		{
			return;
		}
		Control control = sender as Control;
		string name = control.Name;
		if (name == null)
		{
			return;
		}
		int result2;
		float result;
		switch (name.Length)
		{
		case 7:
			switch (name[0])
			{
			case 'd':
				if (!(name == Class16.smethod_0(1649108158)))
				{
					break;
				}
				int.TryParse(textBox_6.Text, out result2);
				{
					foreach (int item in list_10)
					{
						npcGen_0.NpcMobList[item].dwGenId = result2;
					}
					break;
				}
			case 'T':
				if (!(name == Class16.smethod_0(1649108102)))
				{
					break;
				}
				int.TryParse(textBox_42.Text, out result2);
				{
					foreach (int item2 in list_10)
					{
						npcGen_0.NpcMobList[item2].Trigger_id = result2;
					}
					break;
				}
			}
			break;
		case 8:
			switch (name[0])
			{
			case 'X':
				if (!(name == Class16.smethod_0(1649108468)))
				{
					break;
				}
				float.TryParse(textBox_59.Text, out result);
				{
					foreach (int item3 in list_10)
					{
						npcGen_0.NpcMobList[item3].X_direction = result;
					}
					break;
				}
			case 'Y':
				if (!(name == Class16.smethod_0(1649108437)))
				{
					break;
				}
				float.TryParse(textBox_62.Text, out result);
				{
					foreach (int item4 in list_10)
					{
						npcGen_0.NpcMobList[item4].Y_direction = result;
					}
					break;
				}
			case 'Z':
				if (!(name == Class16.smethod_0(1649108404)))
				{
					break;
				}
				float.TryParse(textBox_65.Text, out result);
				{
					foreach (int item5 in list_10)
					{
						npcGen_0.NpcMobList[item5].Z_direction = result;
					}
					break;
				}
			case 'I':
				if (!(name == Class16.smethod_0(1649108071)))
				{
					break;
				}
				int.TryParse(textBox_19.Text, out result2);
				{
					foreach (int item6 in list_10)
					{
						npcGen_0.NpcMobList[item6].MaxRespawnTime = result2;
					}
					break;
				}
			}
			break;
		case 9:
			switch (name[0])
			{
			case 'X':
				if (!(name == Class16.smethod_0(1649108372)))
				{
					break;
				}
				float.TryParse(textBox_60.Text, out result);
				{
					foreach (int item7 in list_10)
					{
						npcGen_0.NpcMobList[item7].X_random = result;
					}
					break;
				}
			case 'Y':
				if (!(name == Class16.smethod_0(1649108340)))
				{
					break;
				}
				float.TryParse(textBox_63.Text, out result);
				{
					foreach (int item8 in list_10)
					{
						npcGen_0.NpcMobList[item8].Y_random = result;
					}
					break;
				}
			case 'Z':
				if (!(name == Class16.smethod_0(1649108308)))
				{
					break;
				}
				float.TryParse(textBox_66.Text, out result);
				{
					foreach (int item9 in list_10)
					{
						npcGen_0.NpcMobList[item9].Z_random = result;
					}
					break;
				}
			case 'L':
				if (!(name == Class16.smethod_0(1649108086)))
				{
					break;
				}
				int.TryParse(textBox_20.Text, out result2);
				{
					foreach (int item10 in list_10)
					{
						npcGen_0.NpcMobList[item10].Life_time = result2;
					}
					break;
				}
			}
			break;
		case 10:
			switch (name[0])
			{
			case 'X':
				if (!(name == Class16.smethod_0(1649107509)))
				{
					break;
				}
				float.TryParse(textBox_58.Text, out result);
				{
					foreach (int item11 in list_10)
					{
						npcGen_0.NpcMobList[item11].X_position = result;
					}
					break;
				}
			case 'Y':
				if (!(name == Class16.smethod_0(1649107476)))
				{
					break;
				}
				float.TryParse(textBox_61.Text, out result);
				{
					foreach (int item12 in list_10)
					{
						npcGen_0.NpcMobList[item12].Y_position = result;
					}
					break;
				}
			case 'Z':
				if (!(name == Class16.smethod_0(1649108475)))
				{
					break;
				}
				float.TryParse(textBox_64.Text, out result);
				{
					foreach (int item13 in list_10)
					{
						npcGen_0.NpcMobList[item13].Z_position = result;
					}
					break;
				}
			case 'G':
				if (!(name == Class16.smethod_0(1649108253)))
				{
					break;
				}
				int.TryParse(textBox_18.Text, out result2);
				{
					foreach (int item14 in list_10)
					{
						npcGen_0.NpcMobList[item14].iGroupType = result2;
					}
					break;
				}
			case 'B':
				if (!(name == Class16.smethod_0(1649108179)))
				{
					break;
				}
				{
					foreach (int item15 in list_10)
					{
						npcGen_0.NpcMobList[item15].BValicOnce = Convert.ToByte(checkBox_4.Checked);
					}
					break;
				}
			}
			break;
		case 13:
			if (!(name == Class16.smethod_0(1649108280)))
			{
				break;
			}
			{
				foreach (int item16 in list_10)
				{
					npcGen_0.NpcMobList[item16].Type = comboBox_8.SelectedIndex;
					if (comboBox_8.SelectedIndex == 1)
					{
						dataGridView_4.Rows[item16].Cells[1].Style.ForeColor = Color.FromArgb(251, 251, 107);
						dataGridView_4.Rows[item16].Cells[2].Style.ForeColor = Color.FromArgb(251, 251, 107);
					}
					else
					{
						dataGridView_4.Rows[item16].Cells[1].Style.ForeColor = Color.FromArgb(77, 255, 143);
						dataGridView_4.Rows[item16].Cells[2].Style.ForeColor = Color.White;
					}
				}
				break;
			}
		case 16:
			if (!(name == Class16.smethod_0(1649108230)))
			{
				break;
			}
			{
				foreach (int item17 in list_10)
				{
					npcGen_0.NpcMobList[item17].BInitGen = Convert.ToByte(checkBox_6.Checked);
				}
				break;
			}
		case 17:
			if (!(name == Class16.smethod_0(1649107545)))
			{
				break;
			}
			{
				foreach (int item18 in list_10)
				{
					npcGen_0.NpcMobList[item18].Location = comboBox_7.SelectedIndex;
				}
				break;
			}
		case 19:
			if (!(name == Class16.smethod_0(1649108204)))
			{
				break;
			}
			{
				foreach (int item19 in list_10)
				{
					npcGen_0.NpcMobList[item19].bAutoRevive = Convert.ToByte(checkBox_5.Checked);
				}
				break;
			}
		case 11:
		case 12:
		case 14:
		case 15:
		case 18:
			break;
		}
	}

	private void dataGridView_4_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
	{
		if (!method_3() && HINTS.ToolTipWindow != null && ((e.ColumnIndex > 0) & (e.RowIndex >= 0)))
		{
			string text = Convert.ToString(dataGridView_4.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
			object value = dataGridView_4.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
			if (value != null && int.TryParse(value.ToString(), out var result) && result > 0)
			{
				HINTS.ToolTipWindow.SetOwnerHandle(dataGridView_4.Handle);
				HINTS.ToolTipWindow.ShowItemToolTip(result, ItemType.NpcOrMobOrMine);
			}
			else
			{
				HINTS.ToolTipWindow.ShowToolTip(dataGridView_4, text);
			}
		}
	}

	private void dataGridView_4_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
	{
		if (HINTS.ToolTipWindow != null)
		{
			HINTS.ToolTipWindow.SmoothHide();
		}
	}

	private void dataGridView_4_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
	{
		if (!method_3() && ((e.ColumnIndex > 0) & (e.RowIndex >= 0)))
		{
			object value = dataGridView_4.Rows[e.RowIndex].Cells[1].Value;
			if (value != null && int.TryParse(value.ToString(), out var result) && result > 0 && HINTS.ToolTipWindow != null)
			{
				HINTS.ToolTipWindow.SetOwnerHandle(dataGridView_4.Handle);
				HINTS.ToolTipWindow.ShowItemToolTip(result, ItemType.NpcOrMobOrMine);
			}
		}
	}

	private void dataGridView_5_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
	{
		if (!method_3() && ((e.ColumnIndex > 0) & (e.RowIndex >= 0)))
		{
			object value = dataGridView_5.Rows[e.RowIndex].Cells[1].Value;
			if (value != null && int.TryParse(value.ToString(), out var result) && result > 0 && HINTS.ToolTipWindow != null)
			{
				HINTS.ToolTipWindow.SetOwnerHandle(dataGridView_5.Handle);
				HINTS.ToolTipWindow.ShowItemToolTip(result, ItemType.NpcOrMobOrMine);
			}
		}
	}

	private void dataGridView_5_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
	{
		if (HINTS.ToolTipWindow != null)
		{
			HINTS.ToolTipWindow.SmoothHide();
		}
	}

	private void dataGridView_5_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
	{
		if (!method_3() && ((e.ColumnIndex > 0) & (e.RowIndex >= 0)))
		{
			object value = dataGridView_5.Rows[e.RowIndex].Cells[1].Value;
			if (value != null && int.TryParse(value.ToString(), out var result) && result > 0 && HINTS.ToolTipWindow != null)
			{
				HINTS.ToolTipWindow.SetOwnerHandle(dataGridView_5.Handle);
				HINTS.ToolTipWindow.ShowItemToolTip(result, ItemType.NpcOrMobOrMine);
			}
		}
	}

	private void button_27_Click(object sender, EventArgs e)
	{
		if (npcGen_0 == null)
		{
			return;
		}
		int_0 = 4;
		string text = Class16.smethod_0(1648942688);
		list_16 = new List<int>();
		dataGridView_9.ScrollBars = ScrollBars.None;
		dataGridView_9.Rows.Clear();
		if (radioButton_13.Checked)
		{
			Class291 CS_0024_003C_003E8__locals4 = new Class291();
			int.TryParse(textBox_44.Text, out CS_0024_003C_003E8__locals4.int_0);
			list_16 = (from _003C_003Ef__AnonymousType149_0 in npcGen_0.TriggersList.Select((ClassTrigger classTrigger_0, int int_0) => _003C_003Ef__AnonymousType149.Create(
				classTrigger_0,
				int_0
			))
				where _003C_003Ef__AnonymousType149_0.Item.Id == CS_0024_003C_003E8__locals4.int_0
				select _003C_003Ef__AnonymousType149_0.Index).ToList();
			for (int num = 0; num < list_16.Count(); num++)
			{
				dataGridView_9.Rows.Add(num + 1, dataGridView_10.Rows[list_16[num]].Cells[1].Value, dataGridView_10.Rows[list_16[num]].Cells[3].Value, text);
			}
		}
		else if (radioButton_12.Checked)
		{
			Class265 CS_0024_003C_003E8__locals5 = new Class265();
			int.TryParse(textBox_43.Text, out CS_0024_003C_003E8__locals5.int_0);
			list_16 = (from _003C_003Ef__AnonymousType149_0 in npcGen_0.TriggersList.Select((ClassTrigger classTrigger_0, int int_0) => _003C_003Ef__AnonymousType149.Create(
				classTrigger_0,
				int_0
			))
				where _003C_003Ef__AnonymousType149_0.Item.GmID == CS_0024_003C_003E8__locals5.int_0
				select _003C_003Ef__AnonymousType149_0.Index).ToList();
			for (int num2 = 0; num2 < list_16.Count; num2++)
			{
				dataGridView_9.Rows.Add(num2 + 1, dataGridView_10.Rows[list_16[num2]].Cells[1].Value, dataGridView_10.Rows[list_16[num2]].Cells[3].Value, text);
			}
		}
		else if (radioButton_14.Checked)
		{
			int num3 = 1;
			for (int num4 = 0; num4 < dataGridView_10.Rows.Count; num4++)
			{
				object value = dataGridView_10.Rows[num4].Cells[3].Value;
				if (value != null && value.ToString()?.ToLower()?.Contains(textBox_45.Text.ToLower()) == true)
				{
					list_16.Add(num4);
					dataGridView_9.Rows.Add(num3, dataGridView_10.Rows[num4].Cells[1].Value, dataGridView_10.Rows[num4].Cells[3].Value, text);
					num3++;
				}
			}
		}
		dataGridView_9.ScrollBars = ScrollBars.Vertical;
	}

	private void textBox_43_TextChanged(object sender, EventArgs e)
	{
		if (npcGen_0 == null)
		{
			return;
		}
		Class281 @class = new Class281();
		int.TryParse(textBox_43.Text, out @class.int_0);
		int num = npcGen_0.TriggersList.FindIndex(@class.method_0);
		if (num == -1)
		{
			return;
		}
		TextBox textBox = textBox_45;
		object value = dataGridView_10.Rows[num].Cells[3].Value;
		object obj;
		if (value == null)
		{
			obj = null;
		}
		else
		{
			obj = value.ToString();
			if (obj != null)
			{
				goto IL_0082;
			}
		}
		obj = string.Empty;
		goto IL_0082;
		IL_0082:
		textBox.Text = (string)obj;
	}

	private void textBox_44_TextChanged(object sender, EventArgs e)
	{
		if (npcGen_0 == null)
		{
			return;
		}
		Class290 @class = new Class290();
		int.TryParse(textBox_44.Text, out @class.int_0);
		int num = npcGen_0.TriggersList.FindIndex(@class.method_0);
		if (num == -1)
		{
			return;
		}
		TextBox textBox = textBox_45;
		object value = dataGridView_10.Rows[num].Cells[3].Value;
		object obj;
		if (value == null)
		{
			obj = null;
		}
		else
		{
			obj = value.ToString();
			if (obj != null)
			{
				goto IL_0082;
			}
		}
		obj = string.Empty;
		goto IL_0082;
		IL_0082:
		textBox.Text = (string)obj;
	}

	private void dataGridView_10_CurrentCellChanged(object sender, EventArgs e)
	{
		if (bool_0)
		{
			list_17 = dataGridView_10.SelectedRows.Cast<DataGridViewRow>().Select(Class289.class289_0.method_60).OrderByDescending(Class289.class289_0.method_61)
				.ToList();
			if (dataGridView_10.CurrentRow != null)
			{
				int_7 = dataGridView_10.CurrentRow.Index;
				if (int_7 != -1)
				{
					textBox_40.Text = npcGen_0.TriggersList[int_7].Id.ToString();
					textBox_39.Text = npcGen_0.TriggersList[int_7].GmID.ToString();
					textBox_41.Text = npcGen_0.TriggersList[int_7].TriggerName.ToString();
					textBox_56.Text = npcGen_0.TriggersList[int_7].WaitWhileStart.ToString();
					textBox_57.Text = npcGen_0.TriggersList[int_7].WaitWhileStop.ToString();
					checkBox_10.Checked = Convert.ToBoolean(npcGen_0.TriggersList[int_7].AutoStart);
					textBox_38.Text = npcGen_0.TriggersList[int_7].Duration.ToString();
					checkBox_11.Checked = Convert.ToBoolean(npcGen_0.TriggersList[int_7].DontStartOnSchedule);
					checkBox_12.Checked = Convert.ToBoolean(npcGen_0.TriggersList[int_7].DontStopOnSchedule);
					textBox_50.Text = npcGen_0.TriggersList[int_7].StartYear.ToString();
					textBox_49.Text = npcGen_0.TriggersList[int_7].StartMonth.ToString();
					comboBox_14.SelectedIndex = npcGen_0.TriggersList[int_7].StartWeekDay + 1;
					textBox_46.Text = npcGen_0.TriggersList[int_7].StartDay.ToString();
					textBox_47.Text = npcGen_0.TriggersList[int_7].StartHour.ToString();
					textBox_48.Text = npcGen_0.TriggersList[int_7].StartMinute.ToString();
					textBox_55.Text = npcGen_0.TriggersList[int_7].StopYear.ToString();
					textBox_54.Text = npcGen_0.TriggersList[int_7].StopMonth.ToString();
					comboBox_15.SelectedIndex = npcGen_0.TriggersList[int_7].StopWeekDay + 1;
					textBox_51.Text = npcGen_0.TriggersList[int_7].StopDay.ToString();
					textBox_52.Text = npcGen_0.TriggersList[int_7].StopHour.ToString();
					textBox_53.Text = npcGen_0.TriggersList[int_7].StopMinute.ToString();
					dataGridView_3.ScrollBars = ScrollBars.None;
					dataGridView_8.ScrollBars = ScrollBars.None;
					dataGridView_0.ScrollBars = ScrollBars.None;
					list_9 = npcGen_0.NpcMobList.Where(method_39).ToList();
					dataGridView_3.Rows.Clear();
					for (int i = 0; i < list_9.Count; i++)
					{
						string text = Convert.ToString(dataGridView_4.Rows[npcGen_0.NpcMobList.IndexOf(list_9[i])].Cells[1].Value);
						string text2 = Convert.ToString(dataGridView_4.Rows[npcGen_0.NpcMobList.IndexOf(list_9[i])].Cells[2].Value);
						dataGridView_3.Rows.Add(i + 1, text, text2);
					}
					list_11 = npcGen_0.ResourcesList.Where(method_40).ToList();
					dataGridView_8.Rows.Clear();
					for (int j = 0; j < list_11.Count; j++)
					{
						string text3 = Convert.ToString(dataGridView_6.Rows[npcGen_0.ResourcesList.IndexOf(list_11[j])].Cells[1].Value);
						string text4 = Convert.ToString(dataGridView_6.Rows[npcGen_0.ResourcesList.IndexOf(list_11[j])].Cells[2].Value);
						dataGridView_8.Rows.Add(j + 1, text3, text4);
					}
					list_0 = npcGen_0.DynamicsList.Where(method_41).ToList();
					dataGridView_0.Rows.Clear();
					for (int k = 0; k < list_0.Count; k++)
					{
						string text5 = Convert.ToString(dataGridView_1.Rows[npcGen_0.DynamicsList.IndexOf(list_0[k])].Cells[1].Value);
						string text6 = Convert.ToString(dataGridView_1.Rows[npcGen_0.DynamicsList.IndexOf(list_0[k])].Cells[2].Value);
						dataGridView_0.Rows.Add(k + 1, text5, text6);
					}
					dataGridView_3.ScrollBars = ScrollBars.Vertical;
					dataGridView_8.ScrollBars = ScrollBars.Vertical;
					dataGridView_0.ScrollBars = ScrollBars.Vertical;
				}
			}
		}
		tabPage_6.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1649097933), Class16.smethod_0(1649097947)), list_17.Count, npcGen_0.TriggersAmount);
	}

	private void dataGridView_3_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
	{
		if (HINTS.ToolTipWindow != null && ((e.ColumnIndex > 0) & (e.RowIndex >= 0)))
		{
			string text = Convert.ToString(dataGridView_3.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
			object value = dataGridView_3.Rows[e.RowIndex].Cells[1].Value;
			if (value != null && int.TryParse(value.ToString(), out var result) && result > 0)
			{
				HINTS.ToolTipWindow.SetOwnerHandle(dataGridView_3.Handle);
				HINTS.ToolTipWindow.ShowItemToolTip(result, ItemType.NpcOrMobOrMine);
			}
			else
			{
				HINTS.ToolTipWindow.ShowToolTip(dataGridView_3, text);
			}
		}
	}

	private void dataGridView_5_CurrentCellChanged(object sender, EventArgs e)
	{
		if (dataGridView_5.CurrentRow != null && dataGridView_5.CurrentRow.Index != -1)
		{
			list_18 = dataGridView_5.SelectedRows.Cast<DataGridViewRow>().Select(Class289.class289_0.method_62).ToList();
			int_3 = dataGridView_5.CurrentRow.Index;
			numericUpDown_15.Value = npcGen_0.NpcMobList[int_4].MobDops[int_3].Id;
			numericUpDown_10.Value = npcGen_0.NpcMobList[int_4].MobDops[int_3].Amount;
			numericUpDown_21.Value = npcGen_0.NpcMobList[int_4].MobDops[int_3].Respawn;
			numericUpDown_13.Value = npcGen_0.NpcMobList[int_4].MobDops[int_3].Dead_amount;
			comboBox_2.SelectedIndex = npcGen_0.NpcMobList[int_4].MobDops[int_3].Agression;
			comboBox_13.SelectedIndex = npcGen_0.NpcMobList[int_4].MobDops[int_3].Path_type;
			numericUpDown_18.Value = npcGen_0.NpcMobList[int_4].MobDops[int_3].Speed;
			numericUpDown_17.Value = npcGen_0.NpcMobList[int_4].MobDops[int_3].Path;
			numericUpDown_27.Value = Convert.ToDecimal(npcGen_0.NpcMobList[int_4].MobDops[int_3].fOffsetWater);
			numericUpDown_26.Value = Convert.ToDecimal(npcGen_0.NpcMobList[int_4].MobDops[int_3].fOffsetTrn);
			numericUpDown_14.Value = npcGen_0.NpcMobList[int_4].MobDops[int_3].Group;
			numericUpDown_11.Value = npcGen_0.NpcMobList[int_4].MobDops[int_3].Group_help_sender;
			numericUpDown_16.Value = npcGen_0.NpcMobList[int_4].MobDops[int_3].Group_help_Needer;
			checkBox_3.Checked = Convert.ToBoolean(npcGen_0.NpcMobList[int_4].MobDops[int_3].bNeedHelp);
			checkBox_2.Checked = Convert.ToBoolean(npcGen_0.NpcMobList[int_4].MobDops[int_3].bFaction);
			checkBox_1.Checked = Convert.ToBoolean(npcGen_0.NpcMobList[int_4].MobDops[int_3].bFac_Helper);
			checkBox_0.Checked = Convert.ToBoolean(npcGen_0.NpcMobList[int_4].MobDops[int_3].bFac_Accept);
			numericUpDown_12.Value = npcGen_0.NpcMobList[int_4].MobDops[int_3].Dead_time;
			numericUpDown_20.Value = npcGen_0.NpcMobList[int_4].MobDops[int_3].RefreshLower;
		}
	}

	private void numericUpDown_15_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			numericUpDown_15_Leave(sender, null);
		}
	}

	private void numericUpDown_15_Leave(object sender, EventArgs e)
	{
		if (list_10 == null || npcGen_0 == null)
		{
			return;
		}
		Control control = sender as Control;
		string name = control.Name;
		if (name == null)
		{
			return;
		}
		switch (name.Length)
		{
		case 8:
			if (!(name == Class16.smethod_0(1649113670)))
			{
				break;
			}
			{
				foreach (int item in list_10)
				{
					foreach (int item2 in list_18)
					{
						if (npcGen_0.NpcMobList[item].Amount_in_group >= item2 + 1)
						{
							npcGen_0.NpcMobList[item].MobDops[item2].bFaction = Convert.ToByte(checkBox_2.Checked);
						}
					}
				}
				break;
			}
		case 9:
			switch (name[0])
			{
			case 'b':
				if (!(name == Class16.smethod_0(1649113726)))
				{
					break;
				}
				{
					foreach (int item3 in list_10)
					{
						foreach (int item4 in list_18)
						{
							if (npcGen_0.NpcMobList[item3].Amount_in_group >= item4 + 1)
							{
								npcGen_0.NpcMobList[item3].MobDops[item4].bNeedHelp = Convert.ToByte(checkBox_3.Checked);
							}
						}
					}
					break;
				}
			case 'P':
				if (!(name == Class16.smethod_0(1649114034)))
				{
					break;
				}
				{
					foreach (int item5 in list_10)
					{
						foreach (int item6 in list_18)
						{
							if (npcGen_0.NpcMobList[item5].Amount_in_group >= item6 + 1)
							{
								npcGen_0.NpcMobList[item5].MobDops[item6].Path_type = comboBox_13.SelectedIndex;
							}
						}
					}
					break;
				}
			case 'A':
				if (!(name == Class16.smethod_0(1649114083)))
				{
					break;
				}
				{
					foreach (int item7 in list_10)
					{
						foreach (int item8 in list_18)
						{
							if (npcGen_0.NpcMobList[item7].Amount_in_group >= item8 + 1)
							{
								npcGen_0.NpcMobList[item7].MobDops[item8].Agression = comboBox_2.SelectedIndex;
							}
						}
					}
					break;
				}
			}
			break;
		case 10:
			switch (name[0])
			{
			case 'P':
				if (!(name == Class16.smethod_0(1649114012)))
				{
					break;
				}
				{
					foreach (int item9 in list_10)
					{
						foreach (int item10 in list_18)
						{
							if (npcGen_0.NpcMobList[item9].Amount_in_group >= item10 + 1)
							{
								npcGen_0.NpcMobList[item9].MobDops[item10].Speed = Convert.ToInt32(numericUpDown_18.Value);
							}
						}
					}
					break;
				}
			case 'I':
				if (!(name == Class16.smethod_0(1649113192)))
				{
					break;
				}
				{
					foreach (int item11 in list_10)
					{
						foreach (int item12 in list_18)
						{
							if (npcGen_0.NpcMobList[item11].Amount_in_group >= item12 + 1)
							{
								npcGen_0.NpcMobList[item11].MobDops[item12].Id = Convert.ToInt32(numericUpDown_15.Value);
								dataGridView_5.Rows[item12].Cells[1].Value = Convert.ToInt32(numericUpDown_15.Value);
								if (ItemsToolTip.eLC != null && numericUpDown_15.Value != 0m)
								{
									dataGridView_5.Rows[item12].Cells[2].Value = smethod_2(ItemType.NpcOrMobOrMine, Convert.ToInt32(numericUpDown_15.Value));
								}
								else
								{
									dataGridView_5.Rows[item12].Cells[2].Value = Class16.smethod_0(1648942867);
								}
							}
						}
						RefreshRowNpcAndMobs(item11);
					}
					break;
				}
			}
			break;
		case 11:
			switch (name[5])
			{
			case 'H':
				if (!(name == Class16.smethod_0(1649113685)))
				{
					break;
				}
				{
					foreach (int item13 in list_10)
					{
						foreach (int item14 in list_18)
						{
							if (npcGen_0.NpcMobList[item13].Amount_in_group >= item14 + 1)
							{
								npcGen_0.NpcMobList[item13].MobDops[item14].bFac_Helper = Convert.ToByte(checkBox_1.Checked);
							}
						}
					}
					break;
				}
			case 'A':
				if (!(name == Class16.smethod_0(1649113652)))
				{
					break;
				}
				{
					foreach (int item15 in list_10)
					{
						foreach (int item16 in list_18)
						{
							if (npcGen_0.NpcMobList[item15].Amount_in_group >= item16 + 1)
							{
								npcGen_0.NpcMobList[item15].MobDops[item16].bFac_Accept = Convert.ToByte(checkBox_0.Checked);
							}
						}
					}
					break;
				}
			}
			break;
		case 12:
			switch (name[0])
			{
			case 'T':
				if (!(name == Class16.smethod_0(1649113919)))
				{
					break;
				}
				{
					foreach (int item17 in list_10)
					{
						foreach (int item18 in list_18)
						{
							if (npcGen_0.NpcMobList[item17].Amount_in_group >= item18 + 1)
							{
								npcGen_0.NpcMobList[item17].MobDops[item18].fOffsetTrn = Convert.ToSingle(numericUpDown_26.Value);
							}
						}
					}
					break;
				}
			case 'P':
				if (!(name == Class16.smethod_0(1649113985)))
				{
					break;
				}
				{
					foreach (int item19 in list_10)
					{
						foreach (int item20 in list_18)
						{
							if (npcGen_0.NpcMobList[item19].Amount_in_group >= item20 + 1)
							{
								npcGen_0.NpcMobList[item19].MobDops[item20].Path = Convert.ToInt32(numericUpDown_17.Value);
							}
						}
					}
					break;
				}
			}
			break;
		case 13:
			switch (name[0])
			{
			case 'W':
				if (!(name == Class16.smethod_0(1649113973)))
				{
					break;
				}
				{
					foreach (int item21 in list_10)
					{
						foreach (int item22 in list_18)
						{
							if (npcGen_0.NpcMobList[item21].Amount_in_group >= item22 + 1)
							{
								npcGen_0.NpcMobList[item21].MobDops[item22].fOffsetWater = Convert.ToSingle(numericUpDown_27.Value);
							}
						}
					}
					break;
				}
			case 'G':
				if (!(name == Class16.smethod_0(1649114584)))
				{
					break;
				}
				{
					foreach (int item23 in list_10)
					{
						foreach (int item24 in list_18)
						{
							if (npcGen_0.NpcMobList[item23].Amount_in_group >= item24 + 1)
							{
								npcGen_0.NpcMobList[item23].MobDops[item24].Group = Convert.ToInt32(numericUpDown_14.Value);
							}
						}
					}
					break;
				}
			}
			break;
		case 14:
			if (!(name == Class16.smethod_0(1649113165)))
			{
				break;
			}
			{
				foreach (int item25 in list_10)
				{
					foreach (int item26 in list_18)
					{
						if (npcGen_0.NpcMobList[item25].Amount_in_group >= item26 + 1)
						{
							npcGen_0.NpcMobList[item25].MobDops[item26].Amount = Convert.ToInt32(numericUpDown_10.Value);
						}
					}
				}
				break;
			}
		case 15:
			switch (name[0])
			{
			case 'R':
				if (!(name == Class16.smethod_0(1649113109)))
				{
					break;
				}
				{
					foreach (int item27 in list_10)
					{
						foreach (int item28 in list_18)
						{
							if (npcGen_0.NpcMobList[item27].Amount_in_group >= item28 + 1)
							{
								npcGen_0.NpcMobList[item27].MobDops[item28].Respawn = Convert.ToInt32(numericUpDown_21.Value);
							}
						}
					}
					break;
				}
			case 'A':
				if (!(name == Class16.smethod_0(1649113775)))
				{
					break;
				}
				{
					foreach (int item29 in list_10)
					{
						foreach (int item30 in list_18)
						{
							if (npcGen_0.NpcMobList[item29].Amount_in_group >= item30 + 1)
							{
								npcGen_0.NpcMobList[item29].MobDops[item30].Group_help_sender = Convert.ToInt32(numericUpDown_11.Value);
							}
						}
					}
					break;
				}
			}
			break;
		case 16:
			switch (name[0])
			{
			case 'N':
				if (!(name == Class16.smethod_0(1649113703)))
				{
					break;
				}
				{
					foreach (int item31 in list_10)
					{
						foreach (int item32 in list_18)
						{
							if (npcGen_0.NpcMobList[item31].Amount_in_group >= item32 + 1)
							{
								npcGen_0.NpcMobList[item31].MobDops[item32].Group_help_Needer = Convert.ToInt32(numericUpDown_16.Value);
							}
						}
					}
					break;
				}
			case 'D':
				if (!(name == Class16.smethod_0(1649113629)))
				{
					break;
				}
				{
					foreach (int item33 in list_10)
					{
						foreach (int item34 in list_18)
						{
							if (npcGen_0.NpcMobList[item33].Amount_in_group >= item34 + 1)
							{
								npcGen_0.NpcMobList[item33].MobDops[item34].Dead_time = Convert.ToInt32(numericUpDown_12.Value);
							}
						}
					}
					break;
				}
			}
			break;
		case 19:
			if (!(name == Class16.smethod_0(1649114099)))
			{
				break;
			}
			{
				foreach (int item35 in list_10)
				{
					foreach (int item36 in list_18)
					{
						if (npcGen_0.NpcMobList[item35].Amount_in_group >= item36 + 1)
						{
							npcGen_0.NpcMobList[item35].MobDops[item36].Dead_amount = Convert.ToInt32(numericUpDown_13.Value);
						}
					}
				}
				break;
			}
		case 20:
			if (!(name == Class16.smethod_0(1649114618)))
			{
				break;
			}
			{
				foreach (int item37 in list_10)
				{
					foreach (int item38 in list_18)
					{
						if (npcGen_0.NpcMobList[item37].Amount_in_group >= item38 + 1)
						{
							npcGen_0.NpcMobList[item37].MobDops[item38].RefreshLower = Convert.ToInt32(numericUpDown_20.Value);
						}
					}
				}
				break;
			}
		case 17:
		case 18:
			break;
		}
	}

	private void numericUpDown_23_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			numericUpDown_23_Leave(sender, null);
		}
	}

	private void numericUpDown_23_Leave(object sender, EventArgs e)
	{
		Control control = sender as Control;
		if (list_19 == null)
		{
			return;
		}
		string name = control.Name;
		if (!(name == Class16.smethod_0(1649107163)))
		{
			if (!(name == Class16.smethod_0(1649107135)))
			{
				if (!(name == Class16.smethod_0(1649107104)))
				{
					if (!(name == Class16.smethod_0(1649107033)))
					{
						if (!(name == Class16.smethod_0(1649107067)))
						{
							return;
						}
						{
							foreach (int item in list_12)
							{
								foreach (int item2 in list_19)
								{
									if (npcGen_0.ResourcesList[item].Amount_in_group >= item2 + 1)
									{
										npcGen_0.ResourcesList[item].ResExtra[item2].fHeiOff = Convert.ToSingle(numericUpDown_22.Value);
									}
								}
							}
							return;
						}
					}
					{
						foreach (int item3 in list_12)
						{
							foreach (int item4 in list_19)
							{
								if (npcGen_0.ResourcesList[item3].Amount_in_group >= item4 + 1)
								{
									npcGen_0.ResourcesList[item3].ResExtra[item4].ResourceType = Convert.ToInt32(numericUpDown_25.Value);
								}
							}
						}
						return;
					}
				}
				{
					foreach (int item5 in list_12)
					{
						foreach (int item6 in list_19)
						{
							if (npcGen_0.ResourcesList[item5].Amount_in_group >= item6 + 1)
							{
								npcGen_0.ResourcesList[item5].ResExtra[item6].Respawntime = Convert.ToInt32(numericUpDown_24.Value);
							}
						}
					}
					return;
				}
			}
			{
				foreach (int item7 in list_12)
				{
					foreach (int item8 in list_19)
					{
						if (npcGen_0.ResourcesList[item7].Amount_in_group >= item8 + 1)
						{
							npcGen_0.ResourcesList[item7].ResExtra[item8].Amount = Convert.ToInt32(numericUpDown_19.Value);
						}
					}
				}
				return;
			}
		}
		foreach (int item9 in list_12)
		{
			foreach (int item10 in list_19)
			{
				if (npcGen_0.ResourcesList[item9].Amount_in_group >= item10 + 1)
				{
					npcGen_0.ResourcesList[item9].ResExtra[item10].Id = Convert.ToInt32(numericUpDown_23.Value);
					dataGridView_7.Rows[item10].Cells[1].Value = Convert.ToInt32(numericUpDown_23.Value);
					if (ItemsToolTip.eLC != null && numericUpDown_23.Value != 0m)
					{
						dataGridView_7.Rows[item10].Cells[2].Value = smethod_2(ItemType.NpcOrMobOrMine, Convert.ToInt32(numericUpDown_23.Value));
					}
					else
					{
						dataGridView_7.Rows[item10].Cells[2].Value = Class16.smethod_0(1648942867);
					}
				}
			}
			RefreshResourcesRow(item9);
		}
	}

	private void toolStripMenuItem_20_Click(object sender, EventArgs e)
	{
		if (npcGen_0 == null)
		{
			return;
		}
		DataGridView dataGridView = null;
		int selectedIndex = tabControl_0.SelectedIndex;
		if (tabControl_0.SelectedIndex == 0)
		{
			dataGridView = dataGridView_4;
		}
		else if (tabControl_0.SelectedIndex == 1)
		{
			dataGridView = dataGridView_6;
		}
		else if (tabControl_0.SelectedIndex == 2)
		{
			dataGridView = dataGridView_1;
		}
		else if (tabControl_0.SelectedIndex == 3)
		{
			dataGridView = dataGridView_10;
		}
		List<DataGridViewRow> list = dataGridView.SelectedRows.Cast<DataGridViewRow>().OrderBy(Class289.class289_0.method_63).ToList();
		List<DataGridViewRow> list2 = dataGridView.SelectedRows.Cast<DataGridViewRow>().OrderBy(Class289.class289_0.method_64).ToList();
		if (list.Count == 0 || list[0].Index == 0)
		{
			return;
		}
		bool_0 = false;
		foreach (DataGridViewRow item5 in list)
		{
			int index = item5.Index;
			int num = item5.Index - 1;
			dataGridView.Rows.Remove(item5);
			dataGridView.Rows.Insert(num, item5);
			switch (selectedIndex)
			{
			case 0:
			{
				ClassDefaultMonsters item4 = npcGen_0.NpcMobList[index];
				npcGen_0.NpcMobList.RemoveAt(index);
				npcGen_0.NpcMobList.Insert(num, item4);
				break;
			}
			case 1:
			{
				ClassDefaultResources item3 = npcGen_0.ResourcesList[index];
				npcGen_0.ResourcesList.RemoveAt(index);
				npcGen_0.ResourcesList.Insert(num, item3);
				break;
			}
			case 2:
			{
				ClassDynamicObject item2 = npcGen_0.DynamicsList[index];
				npcGen_0.DynamicsList.RemoveAt(index);
				npcGen_0.DynamicsList.Insert(num, item2);
				break;
			}
			case 3:
			{
				ClassTrigger item = npcGen_0.TriggersList[index];
				npcGen_0.TriggersList.RemoveAt(index);
				npcGen_0.TriggersList.Insert(num, item);
				break;
			}
			}
		}
		bool_0 = true;
		dataGridView.CurrentCell = dataGridView.Rows[list[list.Count() - 1].Index].Cells[1];
		foreach (DataGridViewRow item6 in list2)
		{
			dataGridView.Rows[item6.Index].Selected = true;
		}
	}

	private void NPCGenEditorForm_Activated(object sender, EventArgs e)
	{
		method_18();
	}

	private void method_18()
	{
		if (ACE.RSGlobal.RSGlobal.FormLang_UpdateLanguage_NPCGenEditorForm != CommonStorage.Texts.LangIndex)
		{
			TextStorage.TEXTS.SetFormLanguage(this, null);
			ACE.RSGlobal.RSGlobal.FormLang_UpdateLanguage_NPCGenEditorForm = CommonStorage.Texts.LangIndex;
		}
		GC.KeepAlive(this);
	}

	private void method_19(object sender, EventArgs e)
	{
		DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649097970)) + Class16.smethod_0(1649097995), Class16.smethod_0(1649115628), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
	}

	private void button_18_Click(object sender, EventArgs e)
	{
		if (npcGen_0 == null)
		{
			return;
		}
		int_0 = 2;
		string text = Class16.smethod_0(1649008358);
		list_15 = new List<int>();
		dataGridView_9.ScrollBars = ScrollBars.None;
		dataGridView_9.Rows.Clear();
		if (radioButton_9.Checked)
		{
			Class278 CS_0024_003C_003E8__locals4 = new Class278();
			int.TryParse(textBox_23.Text, out CS_0024_003C_003E8__locals4.int_0);
			list_15 = (from _003C_003Ef__AnonymousType149_0 in npcGen_0.ResourcesList.Select((ClassDefaultResources classDefaultResources_0, int int_0) => _003C_003Ef__AnonymousType149.Create(
				classDefaultResources_0,
				int_0
			))
				where _003C_003Ef__AnonymousType149_0.Item.ResExtra.Any(CS_0024_003C_003E8__locals4.method_1)
				select _003C_003Ef__AnonymousType149_0.Index).ToList();
			for (int num = 0; num < list_15.Count(); num++)
			{
				dataGridView_9.Rows.Add(num + 1, dataGridView_6.Rows[list_15[num]].Cells[1].Value, dataGridView_6.Rows[list_15[num]].Cells[2].Value, text);
			}
		}
		else if (radioButton_10.Checked)
		{
			int num2 = 1;
			for (int num3 = 0; num3 < dataGridView_6.Rows.Count; num3++)
			{
				object value = dataGridView_6.Rows[num3].Cells[2].Value;
				object obj;
				if (value == null)
				{
					obj = null;
				}
				else
				{
					obj = value.ToString();
					if (obj != null)
					{
						goto IL_01d6;
					}
				}
				obj = string.Empty;
				goto IL_01d6;
				IL_01d6:
				if (((string)obj).ToLower().Contains(textBox_24.Text.ToLower()))
				{
					list_15.Add(num3);
					dataGridView_9.Rows.Add(num2, dataGridView_6.Rows[num3].Cells[1].Value, dataGridView_6.Rows[num3].Cells[2].Value, text);
					num2++;
				}
			}
		}
		else if (radioButton_11.Checked)
		{
			Class282 CS_0024_003C_003E8__locals5 = new Class282();
			int.TryParse(textBox_25.Text, out CS_0024_003C_003E8__locals5.int_0);
			list_15 = (from _003C_003Ef__AnonymousType149_0 in npcGen_0.ResourcesList.Select((ClassDefaultResources classDefaultResources_0, int int_0) => _003C_003Ef__AnonymousType149.Create(
				classDefaultResources_0,
				int_0
			))
				where _003C_003Ef__AnonymousType149_0.Item.Trigger_id == CS_0024_003C_003E8__locals5.int_0
				select _003C_003Ef__AnonymousType149_0.Index).ToList();
			for (int num4 = 0; num4 < list_15.Count; num4++)
			{
				dataGridView_9.Rows.Add(num4 + 1, dataGridView_6.Rows[list_15[num4]].Cells[1].Value, dataGridView_6.Rows[list_15[num4]].Cells[2].Value, text);
			}
		}
		dataGridView_9.ScrollBars = ScrollBars.Vertical;
	}

	private void method_20()
	{
		string[] array = CommonStorage.AParams?.NpcGenPaths;
		if (array == null || array.Length == 0)
		{
			return;
		}
		comboBox_17 = new ComboBox
		{
			DropDownStyle = ComboBoxStyle.DropDownList,
			Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right),
			Location = new Point(75, 6),
			Size = new Size(650, 21),
			TabIndex = 2,
			Name = Class16.smethod_0(1649098067)
		};
		button_29 = new Button
		{
			Text = Class16.smethod_0(1649098090),
			FlatStyle = FlatStyle.Flat,
			Anchor = (AnchorStyles.Top | AnchorStyles.Right),
			Location = new Point(730, 6),
			Size = new Size(58, 21),
			TabIndex = 2,
			Name = Class16.smethod_0(1649098099)
		};
		Label label = new Label
		{
			Text = Class16.smethod_0(1649098132),
			AutoSize = true,
			Location = new Point(5, 10),
			Name = Class16.smethod_0(1649098139)
		};
		foreach (string item in CoordDataImportLogic.SortNpcgenPresetPaths(array))
		{
			if (!string.IsNullOrWhiteSpace(item))
			{
				comboBox_17.Items.Add(item);
			}
		}
		if (comboBox_17.Items.Count > 0)
		{
			string text = (textBox_21.Text ?? string.Empty).Trim();
			int num = (string.IsNullOrWhiteSpace(text) ? (-1) : comboBox_17.FindStringExact(text));
			comboBox_17.SelectedIndex = ((num >= 0) ? num : 0);
		}
		button_29.Click += button_29_Click;
		textBox_21.Location = new Point(75, 30);
		label_1.Location = new Point(5, 33);
		button_24.Location = new Point(button_24.Location.X, 30);
		base.Controls.Add(label);
		base.Controls.Add(comboBox_17);
		base.Controls.Add(button_29);
		if (TDark.IsDarkMode)
		{
			TDark.ApplyThemeToDynamicControl(comboBox_17);
			TDark.ApplyThemeToDynamicControl(button_29);
			TDark.ApplyThemeToDynamicControl(label);
		}
	}

	private void button_29_Click(object sender, EventArgs e)
	{
		if (comboBox_17 != null && comboBox_17.SelectedItem != null)
		{
			string text = comboBox_17.SelectedItem.ToString();
			if (!string.IsNullOrWhiteSpace(text) && File.Exists(text))
			{
				textBox_21.Text = text;
				button_15_Click(sender, e);
			}
			else
			{
				DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649098162), Class16.smethod_0(1649098198)), text), Class16.smethod_0(1649115628), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
	}

	private void method_21()
	{
		fileBasedUndoManager_0 = new FileBasedUndoManager(Class16.smethod_0(1649098216));
		fileBasedUndoManager_0.AttachKeyboardShortcuts(this, method_22, method_23);
		fileBasedUndoManager_0.AttachToToolStrip(toolStrip_0, method_42, method_43);
	}

	private byte[] method_22()
	{
		if (npcGen_0 == null)
		{
			return null;
		}
		try
		{
			MemoryStream memoryStream = new MemoryStream();
			try
			{
				BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
				try
				{
					npcGen_0.WriteNpcgen(binaryWriter, npcGen_0.File_version);
					binaryWriter.Write(tabControl_0?.SelectedIndex ?? 0);
					binaryWriter.Write(dataGridView_4?.CurrentRow?.Index ?? (-1));
					binaryWriter.Write(dataGridView_6?.CurrentRow?.Index ?? (-1));
					binaryWriter.Write(dataGridView_1?.CurrentRow?.Index ?? (-1));
					binaryWriter.Write(dataGridView_10?.CurrentRow?.Index ?? (-1));
					binaryWriter.Flush();
					return memoryStream.ToArray();
				}
				finally
				{
					((IDisposable)binaryWriter).Dispose();
				}
			}
			finally
			{
				((IDisposable)memoryStream).Dispose();
			}
		}
		catch
		{
			return null;
		}
	}

	private void method_23(byte[] byte_0)
	{
		if (byte_0 == null || byte_0.Length == 0)
		{
			return;
		}
		bool flag = bool_0;
		try
		{
			bool_1 = true;
			bool_0 = false;
			MemoryStream memoryStream = new MemoryStream(byte_0);
			try
			{
				BinaryReader binaryReader = new BinaryReader(memoryStream);
				try
				{
					ACE.NpcGen.Classes.NpcGen npcGen = new ACE.NpcGen.Classes.NpcGen();
					npcGen.ReadNpcgen(binaryReader);
					npcGen_0 = npcGen;
					method_24();
					int int_ = 0;
					int int_2 = -1;
					int int_3 = -1;
					int int_4 = -1;
					int int_5 = -1;
					if (memoryStream.Position + 20L <= memoryStream.Length)
					{
						int_ = binaryReader.ReadInt32();
						int_2 = binaryReader.ReadInt32();
						int_3 = binaryReader.ReadInt32();
						int_4 = binaryReader.ReadInt32();
						int_5 = binaryReader.ReadInt32();
					}
					method_27(int_, int_2, int_3, int_4, int_5);
					bool_0 = flag;
				}
				finally
				{
					((IDisposable)binaryReader).Dispose();
				}
			}
			finally
			{
				((IDisposable)memoryStream).Dispose();
			}
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649098237));
		}
		finally
		{
			bool_0 = flag;
			bool_1 = false;
		}
	}

	public void PushUndoSnapshot()
	{
		if (!bool_1)
		{
			byte[] array = method_22();
			if (array != null)
			{
				fileBasedUndoManager_0?.PushUndo(array);
			}
		}
	}

	private void method_24()
	{
		if (npcGen_0 != null)
		{
			method_25(npcGen_0.NpcMobsAmount + npcGen_0.ResourcesAmount + npcGen_0.DynobjectAmount + npcGen_0.TriggersAmount);
			SuspendLayout();
			dataGridView_4.SuspendLayout();
			dataGridView_6.SuspendLayout();
			dataGridView_1.SuspendLayout();
			dataGridView_10.SuspendLayout();
			dataGridView_4.ScrollBars = ScrollBars.None;
			dataGridView_6.ScrollBars = ScrollBars.None;
			dataGridView_1.ScrollBars = ScrollBars.None;
			dataGridView_10.ScrollBars = ScrollBars.None;
			dataGridView_4.Rows.Clear();
			dataGridView_6.Rows.Clear();
			dataGridView_1.Rows.Clear();
			dataGridView_10.Rows.Clear();
			SortNpcGen();
			SortDynamicObjects();
			SortTriggers();
			dataGridView_4.ScrollBars = ScrollBars.Vertical;
			dataGridView_6.ScrollBars = ScrollBars.Vertical;
			dataGridView_1.ScrollBars = ScrollBars.Vertical;
			dataGridView_10.ScrollBars = ScrollBars.Vertical;
			dataGridView_4.ResumeLayout(performLayout: false);
			dataGridView_6.ResumeLayout(performLayout: false);
			dataGridView_1.ResumeLayout(performLayout: false);
			dataGridView_10.ResumeLayout(performLayout: false);
			ResumeLayout(performLayout: false);
			tabPage_2.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1649100099), Class16.smethod_0(1649100128)), npcGen_0.NpcMobsAmount);
			tabPage_4.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1649100154), Class16.smethod_0(1649114403)), npcGen_0.ResourcesAmount);
			tabPage_0.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1649100189), Class16.smethod_0(1649100220)), npcGen_0.DynobjectAmount);
			tabPage_6.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1649100240), Class16.smethod_0(1649100264)), npcGen_0.TriggersAmount);
		}
	}

	private void method_25(int int_9)
	{
		if (progressBar_0 != null && !progressBar_0.IsDisposed)
		{
			int_9 = Math.Max(1, int_9);
			if (progressBar_0.Maximum != int_9)
			{
				progressBar_0.Maximum = int_9;
			}
			if (progressBar_0.Minimum != 0)
			{
				progressBar_0.Minimum = 0;
			}
			progressBar_0.Value = 0;
		}
	}

	private void method_26()
	{
		if (progressBar_0 != null && !progressBar_0.IsDisposed)
		{
			int num = progressBar_0.Value + 1;
			if (num > progressBar_0.Maximum)
			{
				num = progressBar_0.Maximum;
			}
			if (num < progressBar_0.Minimum)
			{
				num = progressBar_0.Minimum;
			}
			progressBar_0.Value = num;
		}
	}

	private void method_27(int int_9, int int_10, int int_11, int int_12, int int_13)
	{
		if (tabControl_0 != null)
		{
			if (int_9 < 0 || int_9 >= tabControl_0.TabPages.Count)
			{
				int_9 = 0;
			}
			tabControl_0.SelectedIndex = int_9;
			smethod_8(dataGridView_4, int_10);
			smethod_8(dataGridView_6, int_11);
			smethod_8(dataGridView_1, int_12);
			smethod_8(dataGridView_10, int_13);
			switch (int_9)
			{
			case 0:
				dataGridView_4_CurrentCellChanged(null, EventArgs.Empty);
				break;
			case 1:
				dataGridView_6_CurrentCellChanged(null, EventArgs.Empty);
				break;
			case 2:
				dataGridView_1_CurrentCellChanged(null, EventArgs.Empty);
				break;
			case 3:
				dataGridView_10_CurrentCellChanged(null, EventArgs.Empty);
				break;
			}
		}
	}

	private static void smethod_8(DataGridView dataGridView_11, int int_9)
	{
		if (dataGridView_11 != null)
		{
			dataGridView_11.ClearSelection();
			if (int_9 >= 0 && int_9 < dataGridView_11.Rows.Count && dataGridView_11.ColumnCount != 0)
			{
				int index = ((dataGridView_11.ColumnCount > 1) ? 1 : 0);
				dataGridView_11.Rows[int_9].Selected = true;
				dataGridView_11.CurrentCell = dataGridView_11.Rows[int_9].Cells[index];
			}
		}
	}

	private void method_28(IReadOnlyList<string> ireadOnlyList_0)
	{
		CoordDataParseResult coordDataParseResult = CoordDataParser.ParseFiles(ireadOnlyList_0);
		if (coordDataParseResult.Entries.Count == 0)
		{
			DKBox.Show(Class16.smethod_0(1649097250), Class16.smethod_0(1649115628), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			return;
		}
		string detectedMap = CoordDataImportLogic.ResolveCurrentMap(textBox_21.Text, coordDataParseResult.Maps, method_29());
		CoordDataImportDialog coordDataImportDialog = new CoordDataImportDialog(ireadOnlyList_0.Select(Class289.class289_0.method_69).ToList(), coordDataParseResult.Maps, detectedMap);
		try
		{
			if (coordDataImportDialog.ShowDialog(this) != DialogResult.OK)
			{
				return;
			}
			string selectedMapId = coordDataImportDialog.SelectedMapId;
			List<CoordDataSpawnEntry> list = CoordDataImportLogic.FilterEntriesByMap(coordDataParseResult.Entries, selectedMapId);
			if (list.Count == 0)
			{
				DKBox.Show(Class16.smethod_0(1649097346) + selectedMapId + Class16.smethod_0(1648928156), Class16.smethod_0(1649115628), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			eListCollection eListCollection2 = ItemsToolTip.eLC ?? HINTS.eLC;
			if (eListCollection2 == null)
			{
				DKBox.Show(Class16.smethod_0(1649097395), Class16.smethod_0(1649115628), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			ItemType itemType_ = eListCollection2.ParseListType(Class16.smethod_0(1648963546));
			ItemType itemType_2 = eListCollection2.ParseListType(Class16.smethod_0(1648960167));
			ItemType itemType_3 = eListCollection2.ParseListType(Class16.smethod_0(1648963535));
			int selectedIndex = tabControl_0.SelectedIndex;
			int npcMobsAmount = npcGen_0.NpcMobsAmount;
			int resourcesAmount = npcGen_0.ResourcesAmount;
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			bool flag = false;
			List<CoordDataSpatialEntry> list2 = method_30();
			List<CoordDataSpatialEntry> list3 = method_31();
			foreach (CoordDataSpawnEntry item in list)
			{
				Enum19 @enum = method_32(eListCollection2, item.Id, itemType_, itemType_2, itemType_3);
				switch (@enum)
				{
				default:
					num4++;
					break;
				case (Enum19)3:
					if (coordDataImportDialog.IgnoreDuplicates && CoordDataImportLogic.IsDuplicate(item, list3, coordDataImportDialog.ConsiderNearCoordinates, coordDataImportDialog.NearDistance))
					{
						num3++;
						break;
					}
					if (!flag)
					{
						PushUndoSnapshot();
						flag = true;
					}
					method_34(item);
					list3.Add(new CoordDataSpatialEntry(item.Id, item.Single_0, item.Single_1, item.Single_2));
					num2++;
					break;
				case (Enum19)1:
				case (Enum19)2:
					if (coordDataImportDialog.IgnoreDuplicates && CoordDataImportLogic.IsDuplicate(item, list2, coordDataImportDialog.ConsiderNearCoordinates, coordDataImportDialog.NearDistance))
					{
						num3++;
						break;
					}
					if (!flag)
					{
						PushUndoSnapshot();
						flag = true;
					}
					method_33(item, @enum == (Enum19)2);
					list2.Add(new CoordDataSpatialEntry(item.Id, item.Single_0, item.Single_1, item.Single_2));
					num++;
					break;
				}
			}
			if (num == 0 && num2 == 0)
			{
				DKBox.Show(string.Format(Class16.smethod_0(1649097516), selectedMapId, num3, num4), Class16.smethod_0(1649115628), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			method_24();
			method_35(selectedIndex, npcMobsAmount, resourcesAmount, num, num2);
			DKBox.Show(string.Format(Class16.smethod_0(1649097614), selectedMapId, num, num2, num3, num4, coordDataParseResult.IgnoredLineCount), Class16.smethod_0(1649115628), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
		finally
		{
			((IDisposable)coordDataImportDialog).Dispose();
		}
	}

	private string method_29()
	{
		if (comboBox_12?.SelectedItem != null)
		{
			return comboBox_12.SelectedItem.ToString();
		}
		string text = comboBox_12?.Text;
		if (!string.IsNullOrWhiteSpace(text))
		{
			return text.Trim();
		}
		return null;
	}

	private List<CoordDataSpatialEntry> method_30()
	{
		List<CoordDataSpatialEntry> list = new List<CoordDataSpatialEntry>();
		if (npcGen_0?.NpcMobList == null)
		{
			return list;
		}
		for (int i = 0; i < npcGen_0.NpcMobList.Count; i++)
		{
			ClassDefaultMonsters classDefaultMonsters = npcGen_0.NpcMobList[i];
			int num = smethod_3(classDefaultMonsters.Amount_in_group, classDefaultMonsters.MobDops);
			for (int j = 0; j < num; j++)
			{
				if (classDefaultMonsters.MobDops[j].Id > 0)
				{
					list.Add(new CoordDataSpatialEntry(classDefaultMonsters.MobDops[j].Id, classDefaultMonsters.X_position, classDefaultMonsters.Y_position, classDefaultMonsters.Z_position));
				}
			}
		}
		return list;
	}

	private List<CoordDataSpatialEntry> method_31()
	{
		List<CoordDataSpatialEntry> list = new List<CoordDataSpatialEntry>();
		if (npcGen_0?.ResourcesList == null)
		{
			return list;
		}
		for (int i = 0; i < npcGen_0.ResourcesList.Count; i++)
		{
			ClassDefaultResources classDefaultResources = npcGen_0.ResourcesList[i];
			int num = smethod_3(classDefaultResources.Amount_in_group, classDefaultResources.ResExtra);
			for (int j = 0; j < num; j++)
			{
				if (classDefaultResources.ResExtra[j].Id > 0)
				{
					list.Add(new CoordDataSpatialEntry(classDefaultResources.ResExtra[j].Id, classDefaultResources.X_position, classDefaultResources.Y_position, classDefaultResources.Z_position));
				}
			}
		}
		return list;
	}

	private Enum19 method_32(eListCollection eListCollection_0, int int_9, ItemType itemType_0, ItemType itemType_1, ItemType itemType_2)
	{
		ITEMPOS iTEMPOS = eListCollection_0.FindItemPos(ItemType.NpcOrMobOrMine, int_9);
		if (!(iTEMPOS == null) && iTEMPOS.IsValid())
		{
			ItemType listType = eListCollection_0.GetListType(iTEMPOS.int_0);
			if (listType == itemType_0)
			{
				return (Enum19)1;
			}
			if (listType == itemType_1)
			{
				return (Enum19)2;
			}
			if (listType == itemType_2)
			{
				return (Enum19)3;
			}
			return (Enum19)0;
		}
		return (Enum19)0;
	}

	private void method_33(CoordDataSpawnEntry coordDataSpawnEntry_0, bool bool_2)
	{
		ClassDefaultMonsters item = new ClassDefaultMonsters
		{
			Amount_in_group = 1,
			Location = 1,
			Type = (bool_2 ? 1 : 0),
			Trigger_id = Convert.ToInt32(numericUpDown_5.Value),
			X_position = coordDataSpawnEntry_0.Single_0,
			Y_position = coordDataSpawnEntry_0.Single_1,
			Z_position = coordDataSpawnEntry_0.Single_2,
			MobDops = new List<ClassExtraMonsters>
			{
				new ClassExtraMonsters
				{
					Id = coordDataSpawnEntry_0.Id,
					Amount = Convert.ToInt32(numericUpDown_2.Value),
					Respawn = Convert.ToInt32(numericUpDown_4.Value)
				}
			}
		};
		npcGen_0.NpcMobList.Add(item);
		npcGen_0.NpcMobsAmount = npcGen_0.NpcMobList.Count;
	}

	private void method_34(CoordDataSpawnEntry coordDataSpawnEntry_0)
	{
		ClassDefaultResources item = new ClassDefaultResources
		{
			Amount_in_group = 1,
			Trigger_id = Convert.ToInt32(numericUpDown_9.Value),
			X_position = coordDataSpawnEntry_0.Single_0,
			Y_position = coordDataSpawnEntry_0.Single_1,
			Z_position = coordDataSpawnEntry_0.Single_2,
			ResExtra = new List<ClassExtraResources>
			{
				new ClassExtraResources
				{
					Id = coordDataSpawnEntry_0.Id,
					Amount = Convert.ToInt32(numericUpDown_6.Value),
					Respawntime = Convert.ToInt32(numericUpDown_8.Value),
					ResourceType = 80
				}
			}
		};
		npcGen_0.ResourcesList.Add(item);
		npcGen_0.ResourcesAmount = npcGen_0.ResourcesList.Count;
	}

	private void method_35(int int_9, int int_10, int int_11, int int_12, int int_13)
	{
		int num = int_9;
		if (num == 0 && int_12 == 0 && int_13 > 0)
		{
			num = 1;
		}
		else if (num == 1 && int_13 == 0 && int_12 > 0)
		{
			num = 0;
		}
		tabControl_0.SelectedIndex = num;
		if (num == 0 && int_12 > 0)
		{
			smethod_8(dataGridView_4, int_10 + int_12 - 1);
			dataGridView_4_CurrentCellChanged(null, EventArgs.Empty);
		}
		else if (num == 1 && int_13 > 0)
		{
			smethod_8(dataGridView_6, int_11 + int_13 - 1);
			dataGridView_6_CurrentCellChanged(null, EventArgs.Empty);
		}
	}

	private bool method_36(int int_9)
	{
		if (int_9 >= 0 && int_9 < npcGen_0.ResourcesList.Count)
		{
			return int_9 < dataGridView_6.Rows.Count;
		}
		return false;
	}

	private GameMapInfo method_37(string string_0)
	{
		Class259 @class = new Class259();
		@class.string_0 = string_0;
		return list_8.First(@class.method_0);
	}

	private void npcLiveEditorForm_0_FormClosed(object sender, FormClosedEventArgs e)
	{
		npcLiveEditorForm_0.OnInsertPositionData -= method_14;
		npcLiveEditorForm_0 = null;
	}

	private bool method_38(int int_9)
	{
		if (int_9 >= 0)
		{
			return int_9 < npcGen_0.DynamicsList.Count;
		}
		return false;
	}

	private bool method_39(ClassDefaultMonsters classDefaultMonsters_0)
	{
		return classDefaultMonsters_0.Trigger_id == npcGen_0.TriggersList[int_7].Id;
	}

	private bool method_40(ClassDefaultResources classDefaultResources_0)
	{
		return classDefaultResources_0.Trigger_id == npcGen_0.TriggersList[int_7].Id;
	}

	private bool method_41(ClassDynamicObject classDynamicObject_0)
	{
		return classDynamicObject_0.TriggerId == npcGen_0.TriggersList[int_7].Id;
	}

	private void method_42(object sender, EventArgs e)
	{
		byte[] currentState = method_22();
		byte[] array = fileBasedUndoManager_0.Undo(currentState);
		if (array != null)
		{
			method_23(array);
		}
	}

	private void method_43(object sender, EventArgs e)
	{
		byte[] currentState = method_22();
		byte[] array = fileBasedUndoManager_0.Redo(currentState);
		if (array != null)
		{
			method_23(array);
		}
	}
}
