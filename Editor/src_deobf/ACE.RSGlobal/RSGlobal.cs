using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Classes.ACE;
using ACE.Classes.ACE_Extra;
using ACE.Elements.eList;
using ACE.Elements.eListCollection;
using ACE.sTASKedit.Classes;
using mshtml;

namespace ACE.RSGlobal;

internal static class RSGlobal
{
	private struct Struct111
	{
		public int int_0;

		public int int_1;
	}

	internal static bool SHOW_UNIVERSAL_NAMES = false;

	internal static int WM_ACE_UNDO_SUBACTION = 50109;

	internal static bool antirecurse_ChangeValues_MainWindow = false;

	internal static bool antirecurse_SetFiles_PRECINCT_LIST = false;

	internal static bool bMessageShowed_ApplyDescriptionChanges_MainWindow = false;

	internal static int WM_SELECT_ITEM_BY_ID = 50090;

	internal static int valid_recurse_level_UpdateGraphicalProbs_AddonsEditor = 0;

	internal static int WM_ACE_EXPORT_TO_TABLE = 50111;

	internal static int WM_ACE_SHOW_NPCGEN = 50114;

	internal static bool AntiRecurse_GenerateRefineHint_eListCollection = false;

	internal static bool antirecurse_UpdateEditText_NumericUpDownEx_RSGlobal = false;

	internal static bool AntiRecurse_LiveSearch_MainWindow = false;

	internal static int RetryCounter_Server_GetResponse_MainWindow = 0;

	internal static bool antirecurse_MoveFields_MainWindow_MOVEITEM_DESTINATION = false;

	internal static bool AntiRecurse_Server_GetResponse_MainWindow = false;

	internal static int WM_ACE_SID_SHOW_BYID = 50086;

	internal static int WM_ACE_SHOW_AI = 50116;

	internal static bool debug_show_listindex = false;

	internal static int WM_ACE_OPEN_FILE = 50133;

	internal static bool antirecurse_SelectItems_MainWindow = false;

	internal static int WM_SELECT_ITEMS_SET_LIST = 50092;

	internal static bool antirecurse_FindItem_GShopEditor_PW = false;

	internal static bool antirecurse_ShowPCKorCPKProtectionWindow_MainWindow = false;

	internal static int WM_ACE_COPYOCTET_TOCLIPBOARD = 50125;

	internal static bool antirecurse_RecipesPreview_MouseMove_RecipesPreview = false;

	internal static bool AntiRecurse_LoadDataBase_eListCollection = false;

	internal static int custom_valcount = -1;

	internal static int WM_GENERATE_OCTETS = 50102;

	internal static bool antiRecurse_CmdFind_Click_AddonsWindow = false;

	internal static bool AntiRecurse_ShowItemToolTip_ItemsToolTip = false;

	internal static int WM_ACE_SHOWMODEL = 50143;

	internal static int WM_ACE_SHOW_WINDOW = 50112;

	internal static bool antirecurse_Cells_DragEnter_RecipesPreview = false;

	internal static int WM_TOOLTIP_HIDE = 50101;

	internal static int WM_TOOLTIP_SHOW = 50098;

	internal static int WM_REFRESH_CURRENT_ITEM = 50105;

	internal static int WM_ACE_UPDATE_REFERENCES = 50127;

	internal static bool antirecurse_Show_MODEL_VIEWER = false;

	internal static int WM_ACE_SHOWBACKGROUNDMESSAGE = 50134;

	internal static int WM_PQE_SELECTTASK = 50140;

	internal static int WM_ACE_HINTS_DISABLED = 50132;

	internal static bool antirecurse_optSubCats_DragEnter_GShopEditor_PW = false;

	internal static int WM_ACE_REDO_ACTION = 50108;

	internal static uint BenchMarkCounter = 0u;

	internal static bool antirecurse_dgwItems1_DragOver_GShopEditor_PW = false;

	internal static bool ELEMENTS_DEBUG = false;

	internal static bool antirecurse_MainWindow_Activated_MainWindow = false;

	internal static int WM_ACE_TASKS_TOOLTIP_SHOW = 50126;

	internal static int selected_list = 0;

	internal static bool antirecurse_picIcons_MouseMove_IconsWindow = false;

	internal static int WM_ACE_GETITEMNAME_BYID_MULTI = 50123;

	internal static int WM_SELECT_FIELD_SET_ITEM = 50094;

	internal static int WM_REFRESH_UNDO_REDO = 50106;

	internal static bool antirecurse_FieldsBox_CellMouseMove_MainWindow = false;

	internal static int WM_ACE_SET_SETTING = 50118;

	internal static int WM_SELECT_FIELD_SET_FIELD = 50095;

	internal static int WM_ACE_GETITEMNAME_BYID = 50119;

	internal static int WM_ACE_UPDATE_ELEMENTS_REFERENCES = 50128;

	internal static int WM_ACE_SID_SHOW_BYLIST = 50088;

	internal static int WM_REFRESH_FIELD = 50104;

	internal static bool ValuesInChangeMode = false;

	internal static int LatestItemIndex = 0;

	internal static int recentTabIndex_RefreshPreview_MainWindow = 0;

	internal static bool antirecurse_FindNPC_NPCGenEditor = false;

	internal static bool bFirstRun_ActionsHistoryViewer_Shown_ActionsHistoryViewer = true;

	internal static int WM_ACE_UNDO_ACTION = 50107;

	internal static bool AntiRecurse_ShowTaskToolTip_API_Ace = false;

	internal static int FormLang_UpdateLanguage_GShopEditor_PW = -1;

	internal static int FormLang_UpdateLanguage_AIPolicyEditor = -1;

	internal static int FormLang_UpdateLanguage_Domain2Editor = -1;

	internal static int FormLang_UpdateLanguage_NPCGenEditor = -1;

	internal static int FormLang_UpdateLanguage_NPCGenEditorForm = -1;

	internal static int FormLang_UpdateLanguage_BmdEditor = -1;

	internal static int FormLang_UpdateLanguage_BonFileEditor = -1;

	internal static int FormLang_UpdateLanguage_sTASKedit = -1;

	internal static int FormLang_UpdateLanguage_DomainEditor = -1;

	internal static int FormLang_UpdateLanguage_PrecinctEditor = -1;

	internal static int FormLang_UpdateLanguage_IconEditor = -1;

	internal static int FormLang_UpdateLanguage_PCKEditor = -1;

	internal static int FormLang_UpdateLanguage_UIXmlEditor = -1;

	internal static int FormLang_UpdateLanguage_DynTasksEditor = -1;

	internal static int FormLang_UpdateLanguage_DynTaskDetailEditor = -1;

	internal static int FormLang_UpdateLanguage_RegionEditorForm = -1;

	internal static int FormLang_UpdateLanguage_PathEditor = -1;

	internal static int FormLang_UpdateLanguage_BuildInModelView = -1;

	internal static int FormLang_UpdateLanguage_NpcLiveEditorForm = -1;

	internal static int FormLang_UpdateLanguage_AddonsEditor = -1;

	internal static int FormLang_UpdateLanguage_PwMapSharpDxEditorForm = -1;

	internal static int FormLang_UpdateLanguage_GShopEditor_FW = -1;

	internal static int FormLang_UpdateLanguage_AITranslationEditorForm = -1;

	internal static int FormLang_UpdateLanguage_Domain2MapEditor = -1;

	internal static int FormLang_UpdateLanguage_ExtraDropEditor = -1;

	internal static bool antirecurse_RefreshToolTip_IconsWindow = false;

	internal static int WM_ACE_ELEMENTS_LOADING_COMPLETE = 50137;

	internal static int TSS0_UpdateGraphicalProbs_ProbsEditor = 0;

	internal static bool selectfield = false;

	internal static int WM_ACE_SHOW_GSHOP = 50113;

	internal static int WM_SELECT_ITEMS_SET_ITEMS = 50093;

	internal static bool bAntiRecurse_ShowSettings_MainWindow = false;

	internal static int WM_ACE_SHOW_PCK_PROTECTOR = 50117;

	internal static bool antirecurse_SendFileViaSSH_MainWindow = false;

	internal static int PrevSenderHash_optSubCats_Click_GShopEditor_PW = 0;

	internal static int WM_ACE_SID_ITEMSELECTED = 50141;

	internal static int WM_ACE_WINDOW_SHOWED = 50139;

	internal static int WM_ACE_UPDATE_GSHOP_REFERENCES = 50129;

	internal static bool antirecurse_cmdSelectDisk_Click_ActivationWindow = false;

	internal static bool antirecurse_WndProc_ItemsToolTip = false;

	internal static int prev_y_RefreshToolTip_IconsWindow = 0;

	internal static int WM_ACE_SID_CREATE = 50084;

	internal static int WM_TOOLTIP_SHOW_BY_ID = 50099;

	internal static bool antirecurse_SetActionsDateRange_ActionsHistoryViewer = false;

	internal static bool antirecurse_SaveHistoryAsync_ACTION_HISTORY = false;

	internal static int WM_ACE_REDO_SUBACTION = 50110;

	internal static int recurse_level_UpdateGraphicalProbs_DropEditor = 0;

	internal static int WM_ACE_SID_DESTROY = 50089;

	internal static bool AntiRecurse_FillEntries_MainWindow = false;

	internal static int WM_TOOLTIP_SHOW_BY_LIST = 50100;

	internal static int WM_SELECT_TAB = 50103;

	internal static bool AntiRecurse_TryGetIconByFields_eListCollection = false;

	internal static int WM_ACE_SELECTTASK = 50142;

	internal static bool AntiRecurse_GetElementToolTip_HINTS = false;

	internal static bool AntiRecurse_ShowBackgroundMessage_MainWindow = false;

	internal static bool AntiRecurse_ShowToolTip_ItemsToolTip = false;

	internal static bool replaced = false;

	internal static int WM_TOOLTIP_SET_OWNER = 50097;

	internal static bool antirecurse_UpdateElementsModelsCache_MODEL_VIEWER = false;

	internal static int WM_ACE_NOT_REGISTERED = 50135;

	internal static int WM_ACE_SAVESETTINGS = 50131;

	internal static bool AntiRecurse_SetReferencesTabs_MainWindow = false;

	internal static int WM_SELECT_ITEM = 50091;

	internal static bool bDontChangeValues = false;

	internal static int TSS0_UpdateGraphicalProbs_DropEditor = 0;

	internal static int WM_ACE_GETITEM_BYID = 50120;

	internal static int WM_ACE_GETITEM_BYID_NATIVE = 50121;

	internal static int PrevSenderHash_optCats_Click_GShopEditor_PW = 0;

	internal static int WM_ACE_GETITEM_BYID_SET_SIZE = 50122;

	internal static bool antirecurse_mnuPasteShortcut_Click_MainWindow = false;

	internal static int WM_ACE_SELECT_ITEM_BY_ID = 50096;

	internal static bool antirecurse_MoveItems_MainWindow = false;

	internal static bool antirecurse_FindItem_GShopEditor_FW = false;

	internal static int stat_key_count = 3;

	internal unsafe static sbyte* alpha;

	internal static byte[] ACTKEY_KEY;

	internal static char[] SETTINGS_CONST = Class16.smethod_0(1649161842).ToCharArray();

	internal static byte[] STATIC_LICENSE_KEY;

	internal static int ElementskillVAShift = 268439040;

	internal static byte[] LICENSE_FILE_KEY = Array.Empty<byte>();

	internal static byte key1 = 109;

	internal static byte[] PROTECTED_STRINGS_KEY = Array.Empty<byte>();

	internal static byte key2 = 19;

	internal static int valid_recurse_level_UpdateGraphicalProbs_DropEditor = 0;

	internal static IntPtr notificationHandle = IntPtr.Zero;

	internal static int WM_ACE_LOADING_COMPLETE = 50136;

	internal static int WM_ACE_SHOW_TASKS = 50115;

	internal static bool ar_Tabs_DragEnter_RecipesPreview = false;

	internal static bool antirecurse_QuickSearch_MainWindow = false;

	internal static int MAX_SUPPORTED_PROTECTION_VERSION_DecodeLogins_eListCollection = 3;

	internal static int WM_ACE_SID_SET_CALLBACK = 50085;

	internal static int WM_ACE_ELEMENTS_NOT_LOADED = 50138;

	internal static int WM_ACE_SID_SHOW_BYID_MULTI = 50087;

	internal static bool antirecurse_UpdatePckSettings_PCKProtectionWindow = false;

	internal static bool IsClear = false;

	internal static bool antirecurse_ShowModelPreview_MODEL_VIEWER = false;

	internal static bool antirecurse_change_list_MainWindow = false;

	internal static bool antirecurse_SelectedSuiteChanged_ProbsEditor = false;

	internal static bool locker_GetElementsWindowHandleSafe_API_Ace = false;

	internal static bool antirecurse_ImportData_MainWindow_ACE_DATA = false;

	internal static int WM_ACE_RESTART = 50130;

	internal static int WM_ACE_GETCLASSNAME = 50124;

	internal static int recurse_level_UpdateGraphicalProbs_AddonsEditor = 0;

	internal static bool AntiRecurse_TryGetIconByReferences_eListCollection = false;

	internal static int prev_x_RefreshToolTip_IconsWindow = 0;

	internal static bool bFirstShowing_RefreshPreview_MainWindow = true;

	internal static int TSS0_UpdateGraphicalProbs_AddonsEditor = 0;

	internal static bool AntiRecurse_ShowBackgroundMessage_GShopEditor_PW = false;

	internal static int CachedNamesStageIndex_txtQuickSearch_Enter_MainWindow = 0;

	internal static bool AntiRecurse_ShowItemToolTip_ItemsToolTip_ITEMPOS = false;

	internal static bool bShown_WndProc_ItemsWindow = false;

	internal static int custom_startindex = -1;

	internal static int valid_recurse_level_UpdateGraphicalProbs_ProbsEditor = 0;

	internal static bool antirecurse_Redo_ACTION_HISTORY = false;

	internal static int recurse_level_UpdateGraphicalProbs_ProbsEditor = 0;

	internal static bool customconfig = false;

	internal unsafe static void InitVariables()
	{
		alpha = (sbyte*)597;
		ELEMENTS_DEBUG = false;
		SHOW_UNIVERSAL_NAMES = false;
		WM_ACE_SID_CREATE = RegisterWindowMessage(Class16.smethod_0(1649161885));
		WM_ACE_SID_SET_CALLBACK = RegisterWindowMessage(Class16.smethod_0(1649161909));
		WM_ACE_SID_SHOW_BYID = RegisterWindowMessage(Class16.smethod_0(1649161931));
		WM_ACE_SID_SHOW_BYID_MULTI = RegisterWindowMessage(Class16.smethod_0(1649161966));
		WM_ACE_SID_SHOW_BYLIST = RegisterWindowMessage(Class16.smethod_0(1649161999));
		WM_ACE_SID_DESTROY = RegisterWindowMessage(Class16.smethod_0(1649162028));
		WM_SELECT_ITEM_BY_ID = RegisterWindowMessage(Class16.smethod_0(1649162053));
		WM_SELECT_ITEM = RegisterWindowMessage(Class16.smethod_0(1649162072));
		WM_SELECT_ITEMS_SET_LIST = RegisterWindowMessage(Class16.smethod_0(1649162101));
		WM_SELECT_ITEMS_SET_ITEMS = RegisterWindowMessage(Class16.smethod_0(1649162132));
		WM_SELECT_FIELD_SET_ITEM = RegisterWindowMessage(Class16.smethod_0(1649162164));
		WM_SELECT_FIELD_SET_FIELD = RegisterWindowMessage(Class16.smethod_0(1649162187));
		WM_ACE_SELECT_ITEM_BY_ID = RegisterWindowMessage(Class16.smethod_0(1649162219));
		WM_TOOLTIP_SET_OWNER = RegisterWindowMessage(Class16.smethod_0(1649161226));
		WM_TOOLTIP_SHOW = RegisterWindowMessage(Class16.smethod_0(1649161261));
		WM_TOOLTIP_SHOW_BY_ID = RegisterWindowMessage(Class16.smethod_0(1649161275));
		WM_TOOLTIP_SHOW_BY_LIST = RegisterWindowMessage(Class16.smethod_0(1649161311));
		WM_TOOLTIP_HIDE = RegisterWindowMessage(Class16.smethod_0(1649161341));
		WM_GENERATE_OCTETS = RegisterWindowMessage(Class16.smethod_0(1649161355));
		WM_SELECT_TAB = RegisterWindowMessage(Class16.smethod_0(1649161388));
		WM_REFRESH_FIELD = RegisterWindowMessage(Class16.smethod_0(1649161400));
		WM_REFRESH_CURRENT_ITEM = RegisterWindowMessage(Class16.smethod_0(1649161431));
		WM_REFRESH_UNDO_REDO = RegisterWindowMessage(Class16.smethod_0(1649161461));
		WM_ACE_UNDO_ACTION = RegisterWindowMessage(Class16.smethod_0(1649161480));
		WM_ACE_REDO_ACTION = RegisterWindowMessage(Class16.smethod_0(1649161509));
		WM_ACE_UNDO_SUBACTION = RegisterWindowMessage(Class16.smethod_0(1649161522));
		WM_ACE_REDO_SUBACTION = RegisterWindowMessage(Class16.smethod_0(1649161558));
		WM_ACE_EXPORT_TO_TABLE = RegisterWindowMessage(Class16.smethod_0(1649161578));
		WM_ACE_SHOW_WINDOW = RegisterWindowMessage(Class16.smethod_0(1649161615));
		WM_ACE_SHOW_GSHOP = RegisterWindowMessage(Class16.smethod_0(1649161632));
		WM_ACE_SHOW_NPCGEN = RegisterWindowMessage(Class16.smethod_0(1649161656));
		WM_ACE_SHOW_TASKS = RegisterWindowMessage(Class16.smethod_0(1649161681));
		WM_ACE_SHOW_AI = RegisterWindowMessage(Class16.smethod_0(1649161705));
		WM_ACE_SHOW_PCK_PROTECTOR = RegisterWindowMessage(Class16.smethod_0(1649160710));
		WM_ACE_SET_SETTING = RegisterWindowMessage(Class16.smethod_0(1649160742));
		WM_ACE_GETITEMNAME_BYID = RegisterWindowMessage(Class16.smethod_0(1649160767));
		WM_ACE_GETITEM_BYID = RegisterWindowMessage(Class16.smethod_0(1649160797));
		WM_ACE_GETITEM_BYID_NATIVE = RegisterWindowMessage(Class16.smethod_0(1649160823));
		WM_ACE_GETITEM_BYID_SET_SIZE = RegisterWindowMessage(Class16.smethod_0(1649160848));
		WM_ACE_GETITEMNAME_BYID_MULTI = RegisterWindowMessage(Class16.smethod_0(1649160883));
		WM_ACE_GETCLASSNAME = RegisterWindowMessage(Class16.smethod_0(1649160927));
		WM_ACE_COPYOCTET_TOCLIPBOARD = RegisterWindowMessage(Class16.smethod_0(1649160945));
		WM_ACE_TASKS_TOOLTIP_SHOW = RegisterWindowMessage(Class16.smethod_0(1649160988));
		WM_ACE_UPDATE_REFERENCES = RegisterWindowMessage(Class16.smethod_0(1649161020));
		WM_ACE_UPDATE_ELEMENTS_REFERENCES = RegisterWindowMessage(Class16.smethod_0(1649161043));
		WM_ACE_UPDATE_GSHOP_REFERENCES = RegisterWindowMessage(Class16.smethod_0(1649161083));
		WM_ACE_RESTART = RegisterWindowMessage(Class16.smethod_0(1649161120));
		WM_ACE_SAVESETTINGS = RegisterWindowMessage(Class16.smethod_0(1649161149));
		WM_ACE_HINTS_DISABLED = RegisterWindowMessage(Class16.smethod_0(1649161175));
		WM_ACE_OPEN_FILE = RegisterWindowMessage(Class16.smethod_0(1649161195));
		WM_ACE_SHOWBACKGROUNDMESSAGE = RegisterWindowMessage(Class16.smethod_0(1649160194));
		WM_ACE_NOT_REGISTERED = RegisterWindowMessage(Class16.smethod_0(1649160237));
		WM_ACE_LOADING_COMPLETE = RegisterWindowMessage(Class16.smethod_0(1649160257));
		WM_ACE_ELEMENTS_LOADING_COMPLETE = RegisterWindowMessage(Class16.smethod_0(1649160295));
		WM_ACE_ELEMENTS_NOT_LOADED = RegisterWindowMessage(Class16.smethod_0(1649160334));
		WM_ACE_WINDOW_SHOWED = RegisterWindowMessage(Class16.smethod_0(1649160367));
		WM_PQE_SELECTTASK = RegisterWindowMessage(Class16.smethod_0(1649160386));
		WM_ACE_SID_ITEMSELECTED = RegisterWindowMessage(Class16.smethod_0(1649160410));
		WM_ACE_SELECTTASK = RegisterWindowMessage(Class16.smethod_0(1649160440));
		WM_ACE_SHOWMODEL = RegisterWindowMessage(Class16.smethod_0(1649160464));
	}

	[return: MarshalAs(UnmanagedType.U1)]
	internal static bool IsArraysEquals(int[] array1, int[] array2)
	{
		if (array1 != null && array2 != null)
		{
			int num = array1.Length;
			if (num != array2.Length)
			{
				return false;
			}
			int num2 = 0;
			int num3 = num;
			if (0 < num3)
			{
				do
				{
					if (array1[num2] == array2[num2])
					{
						num2++;
						continue;
					}
					return false;
				}
				while (num2 < num3);
				return true;
			}
			return true;
		}
		return false;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	internal static bool IsArraysEquals(byte[] array1, byte[] array2)
	{
		if (array1 != null && array2 != null)
		{
			int num = array1.Length;
			if (num != array2.Length)
			{
				return false;
			}
			int num2 = 0;
			int num3 = num;
			if (0 < num3)
			{
				do
				{
					if (array1[num2] == array2[num2])
					{
						num2++;
						continue;
					}
					return false;
				}
				while (num2 < num3);
				return true;
			}
			return true;
		}
		return false;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	internal static bool IsArraysEquals(string[] array1, string[] array2)
	{
		if (array1 != null && array2 != null)
		{
			int num = array1.Length;
			if (num != array2.Length)
			{
				return false;
			}
			int num2 = 0;
			if (0 < num)
			{
				do
				{
					if (!(array1[num2] != array2[num2]))
					{
						num2++;
						continue;
					}
					return false;
				}
				while (num2 < array1.Length);
				return true;
			}
			return true;
		}
		return false;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	internal static bool IsValidArray(Array arr)
	{
		int num = ((arr != null && arr.Length != 0) ? 1 : 0);
		return (byte)num != 0;
	}

	internal static int[] IntArray(int startval, int endval, int step)
	{
		if (step == 0)
		{
			return Array.Empty<int>();
		}
		long num = (long)endval - (long)startval;
		if ((num > 0L && step < 0) || (num < 0L && step > 0))
		{
			return Array.Empty<int>();
		}
		long num2 = num / step;
		if (num2 >= 0L && num2 < 2147483647L)
		{
			int num3 = (int)num2;
			int[] array = new int[num3 + 1];
			int num4 = 0;
			if (0 <= num3)
			{
				int num5 = startval;
				do
				{
					array[num4] = num5;
					num4++;
					num5 = step + num5;
				}
				while (num4 <= num3);
			}
			return array;
		}
		return Array.Empty<int>();
	}

	internal static decimal[] DecimalArray(int startval, int endval)
	{
		int num = endval - startval;
		decimal[] array = new decimal[num + 1];
		int num2 = 0;
		if (0 <= num)
		{
			do
			{
				decimal num3 = num2 + startval;
				array[num2] = num3;
				num2++;
			}
			while (num2 <= num);
		}
		return array;
	}

	internal static int[] iarr(int val1, int val2)
	{
		return new int[2] { val1, val2 };
	}

	internal static int[] iarr(int val1, int val2, int val3)
	{
		return new int[3] { val1, val2, val3 };
	}

	internal static int[] CloneArray(int[] iArray)
	{
		int[] array = new int[iArray.Length];
		iArray.CopyTo(array, 0);
		return array;
	}

	internal static float[] CloneArray(float[] fArray)
	{
		float[] array = new float[fArray.Length];
		fArray.CopyTo(array, 0);
		return array;
	}

	internal static object[] CloneArray(object[] oArray)
	{
		object[] array = new object[oArray.Length];
		oArray.CopyTo(array, 0);
		return array;
	}

	internal static string[] CloneArray(string[] sArray)
	{
		string[] array = new string[sArray.Length];
		sArray.CopyTo(array, 0);
		return array;
	}

	internal static byte[] CloneArray(byte[] oArray)
	{
		byte[] array = new byte[oArray.Length];
		oArray.CopyTo(array, 0);
		return array;
	}

	internal static int[] RemoveArrayElement(int[] Arr, int Index)
	{
		int[] array = new int[Arr.Length - 1];
		Array.Copy(Arr, 0, array, 0, Index);
		Array.Copy(Arr, Index + 1, array, Index, Arr.Length - Index - 1);
		return array;
	}

	internal static string[] RemoveArrayElement(string[] Arr, int Index)
	{
		string[] array = new string[Arr.Length - 1];
		Array.Copy(Arr, 0, array, 0, Index);
		Array.Copy(Arr, Index + 1, array, Index, Arr.Length - Index - 1);
		return array;
	}

	internal static float[] StringArray2FloatArray(string[] source)
	{
		int num = source.Length;
		float[] array = new float[num];
		int num2 = 0;
		if (0 < num)
		{
			do
			{
				array[num2] = Convert.ToSingle(source[num2]);
				num2++;
			}
			while (num2 < source.Length);
		}
		return array;
	}

	internal static int AddElementToArray(ref string[] Arr, string Value)
	{
		Array.Resize(ref Arr, Arr.Length + 1);
		string[] array = Arr;
		array[array.Length - 1] = Value;
		return Arr.Length - 1;
	}

	internal static void AddElementToArray(ref int[] Arr, int Value)
	{
		int[] array = Arr;
		if (array != null)
		{
			Array.Resize(ref Arr, array.Length + 1);
		}
		else
		{
			Arr = new int[1];
		}
		int[] array2 = Arr;
		array2[array2.Length - 1] = Value;
	}

	internal static string[] IntArray2StringArray(int[] source)
	{
		int num = source.Length;
		string[] array = new string[num];
		int num2 = 0;
		if (0 < num)
		{
			do
			{
				int num3 = source[num2];
				array[num2] = num3.ToString();
				num2++;
			}
			while (num2 < source.Length);
		}
		return array;
	}

	internal static int[] StringArray2IntArray(string[] source)
	{
		int num = source.Length;
		int[] array = new int[num];
		int num2 = 0;
		if (0 < num)
		{
			do
			{
				array[num2] = UIntParseFast(source[num2]);
				num2++;
			}
			while (num2 < source.Length);
		}
		return array;
	}

	internal static string[] DecimalArray2StringArray(decimal[] source)
	{
		int num = source.Length;
		string[] array = new string[num];
		int num2 = 0;
		if (0 < num)
		{
			do
			{
				array[num2] = source[num2].ToString();
				num2++;
			}
			while (num2 < source.Length);
		}
		return array;
	}

	internal static void InsertToArray(ref string[] arr, int index, string value)
	{
		string[] array = arr;
		int num = array.Length;
		if (index < num)
		{
			string[] array2 = new string[num + 1];
			Array.Copy(array, 0, array2, 0, index);
			array2[index] = value;
			string[] array3 = arr;
			Array.Copy(array3, index, array2, index + 1, array3.Length - index);
			arr = array2;
		}
		else
		{
			Array.Resize(ref arr, num + 1);
			arr[index] = value;
		}
	}

	public static T[] InsertToArray<T>(T[] array, T item)
	{
		if (array == null)
		{
			return new T[1] { item };
		}
		T[] array2 = new T[array.Length + 1];
		Array.Copy(array, array2, array.Length);
		array2[array.Length] = item;
		return array2;
	}

	public static T[] InsertToArray<T>(T[] array, T item, int index)
	{
		if (array == null)
		{
			return new T[1] { item };
		}
		T[] array2 = new T[array.Length + 1];
		if (index >= 0 && index < array.Length)
		{
			Array.Copy(array, 0, array2, 0, index);
			array2[index] = item;
			Array.Copy(array, index, array2, index + 1, array.Length - index);
		}
		else
		{
			Array.Copy(array, array2, array.Length);
			array2[array.Length] = item;
		}
		return array2;
	}

	internal static void AddValueToStack<T>(ref T[] arr, T val, int limit)
	{
		if (limit > 0)
		{
			if (arr != null && arr.Length != 0 && limit != 1)
			{
				int num = arr.Length + 1;
				int num2 = ((num < limit) ? num : limit);
				T[] array = new T[num2];
				array[0] = val;
				Array.Copy(arr, 0, array, 1, num2 - 1);
				arr = array;
			}
			else
			{
				arr = new T[1] { val };
			}
		}
	}

	internal static int[] TryParseInts(string text)
	{
		int[] result = null;
		if (IsStringContainsAnyStringInArray(text, new string[3]
		{
			Class16.smethod_0(1648941518),
			Class16.smethod_0(1648928028),
			Class16.smethod_0(1648898262)
		}))
		{
			text = text.Replace(Class16.smethod_0(1648942211), string.Empty);
		}
		if (int.TryParse(text, out var _))
		{
			result = new int[1] { Convert.ToInt32(text) };
		}
		else if (Regex.IsMatch(text, Class16.smethod_0(1649160495)))
		{
			string[] array = text.Split('-');
			if (int.TryParse(array[0], out var _) && int.TryParse(array[1], out var _))
			{
				int endval = Convert.ToInt32(array[1]);
				result = IntArray(Convert.ToInt32(array[0]), endval, 1);
			}
		}
		else if (Regex.IsMatch(text, Class16.smethod_0(1649136955)))
		{
			result = ParseListOfInt(text);
		}
		return result;
	}

	internal static int[] IntCollectionToArray(Dictionary<int, string>.KeyCollection keys)
	{
		int[] array = new int[keys.Count];
		keys.CopyTo(array, 0);
		return array;
	}

	internal static int[] IntCollectionToArray(Dictionary<int, int>.KeyCollection keys)
	{
		int[] array = new int[keys.Count];
		keys.CopyTo(array, 0);
		return array;
	}

	internal static int GetMaxValueIndex<T>(T[] Arr) where T : IComparable<T>
	{
		if (Arr != null && Arr.Length != 0)
		{
			int result = 0;
			T other = Arr[0];
			for (int i = 1; i < Arr.Length; i++)
			{
				if (Arr[i].CompareTo(other) > 0)
				{
					other = Arr[i];
					result = i;
				}
			}
			return result;
		}
		return -1;
	}

	internal static int GetMinValueIndex<T>(T[] Arr) where T : IComparable<T>
	{
		if (Arr != null && Arr.Length != 0)
		{
			int result = 0;
			T other = Arr[0];
			for (int i = 1; i < Arr.Length; i++)
			{
				if (Arr[i].CompareTo(other) < 0)
				{
					other = Arr[i];
					result = i;
				}
			}
			return result;
		}
		return -1;
	}

	internal static void KeepOnlyUniqueValues<T>(ref T[] arr)
	{
		if (arr == null || arr.Length == 0)
		{
			return;
		}
		HashSet<T> hashSet = new HashSet<T>();
		List<T> list = new List<T>(arr.Length);
		for (int i = 0; i < arr.Length; i++)
		{
			if (hashSet.Add(arr[i]))
			{
				list.Add(arr[i]);
			}
		}
		arr = list.ToArray();
	}

	internal static void AddElementToArray<T>(ref T[] Arr, T Value, bool bToBegin = false)
	{
		if (Arr == null)
		{
			Arr = new T[1] { Value };
		}
		else if (bToBegin)
		{
			T[] array = new T[Arr.Length + 1];
			array[0] = Value;
			Array.Copy(Arr, 0, array, 1, Arr.Length);
			Arr = array;
		}
		else
		{
			Array.Resize(ref Arr, Arr.Length + 1);
			Arr[Arr.Length - 1] = Value;
		}
	}

	internal static void RemoveArrayElement<T>(ref T[] Arr, int Index)
	{
		if (Arr != null && Arr.Length != 0 && Index >= 0 && Index < Arr.Length)
		{
			T[] array = new T[Arr.Length - 1];
			Array.Copy(Arr, 0, array, 0, Index);
			Array.Copy(Arr, Index + 1, array, Index, Arr.Length - Index - 1);
			Arr = array;
		}
	}

	internal static TKey GetMaxValueKeyInDict<TKey>(Dictionary<TKey, int> dict)
	{
		if (dict != null && dict.Count != 0)
		{
			TKey result = default(TKey);
			int num = int.MinValue;
			bool flag = true;
			{
				foreach (KeyValuePair<TKey, int> item in dict)
				{
					if (flag || item.Value > num)
					{
						result = item.Key;
						num = item.Value;
						flag = false;
					}
				}
				return result;
			}
		}
		return default(TKey);
	}

	internal static void RemoveArrayLastElement<T>(ref T[] Arr)
	{
		if (Arr != null && Arr.Length != 0)
		{
			Array.Resize(ref Arr, Arr.Length - 1);
		}
	}

	internal static T GetMaxFrequentValue<T>(List<T> values)
	{
		if (values != null && values.Count != 0)
		{
			Dictionary<T, int> dictionary = new Dictionary<T, int>();
			foreach (T value in values)
			{
				if (!dictionary.ContainsKey(value))
				{
					dictionary[value] = 0;
				}
				dictionary[value]++;
			}
			return GetMaxValueKeyInDict(dictionary);
		}
		throw new ArgumentException(Class16.smethod_0(1649160510));
	}

	internal static void AddValueToStack<T>(ref T[] arr, T val, int limit, bool bReplace)
	{
		if (limit <= 0)
		{
			return;
		}
		if (arr != null && arr.Length != 0 && limit != 1)
		{
			int num = Array.IndexOf(arr, val);
			if (num != 0)
			{
				if (num > 0 && bReplace)
				{
					RemoveArrayElement(ref arr, num);
				}
				AddValueToStack(ref arr, val, limit);
			}
		}
		else
		{
			arr = new T[1] { val };
		}
	}

	public unsafe static string GetPSByKeyE(sbyte* Key)
	{
		return new string(Key);
	}

	public unsafe static string GetPSByKeyE(string Key)
	{
		sbyte* ptr = (sbyte*)Marshal.StringToHGlobalAnsi(Key).ToPointer();
		string pSByKeyE = GetPSByKeyE(ptr);
		Marshal.FreeHGlobal((IntPtr)ptr);
		int num = pSByKeyE.IndexOf('\0');
		if (num < 0)
		{
			return pSByKeyE;
		}
		return pSByKeyE.Substring(0, num);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	internal static bool IsArrayContains(string[] arr, string val)
	{
		if (arr != null)
		{
			int num = arr.Length;
			if (num != 0)
			{
				int num2 = 0;
				if (0 < num)
				{
					do
					{
						if (!(arr[num2] == val))
						{
							num2++;
							continue;
						}
						return true;
					}
					while (num2 < arr.Length);
					return false;
				}
				return false;
			}
		}
		return false;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	internal static bool IsArrayContains(int[] arr, int val)
	{
		if (arr != null && arr.Length != 0)
		{
			return Array.IndexOf(arr, val) != -1;
		}
		return false;
	}

	internal static void WriteStruct(BinaryWriter bw, object Struct)
	{
		byte[] array = new byte[Marshal.SizeOf(Struct)];
		ValueType valueType = GCHandle.Alloc(array, GCHandleType.Pinned);
		IntPtr ptr = ((GCHandle)(object)valueType).AddrOfPinnedObject();
		Marshal.StructureToPtr(Struct, ptr, fDeleteOld: false);
		bw.Write(array);
		((GCHandle)(object)valueType).Free();
	}

	internal static byte[] GetStructBytes(object Struct)
	{
		byte[] array = new byte[Marshal.SizeOf(Struct)];
		ValueType valueType = GCHandle.Alloc(array, GCHandleType.Pinned);
		IntPtr ptr = ((GCHandle)(object)valueType).AddrOfPinnedObject();
		Marshal.StructureToPtr(Struct, ptr, fDeleteOld: false);
		((GCHandle)(object)valueType).Free();
		return array;
	}

	internal static byte[] GenerateTrash(int trash_len)
	{
		byte[] array = new byte[trash_len];
		int num = 0;
		if (0 < trash_len)
		{
			do
			{
				byte b = (byte)RND.GenerateRnd(0, 255);
				array[num] = b;
				num++;
			}
			while (num < trash_len);
		}
		return array;
	}

	internal static float[] ReadFloat3(BinaryReader br)
	{
		float[] array = new float[3];
		int num = 0;
		do
		{
			array[num] = br.ReadSingle();
			num++;
		}
		while (num < 3);
		return array;
	}

	internal static void WriteFloat3(BinaryWriter bw, float[] farr)
	{
		bw.Write(farr[0]);
		bw.Write(farr[1]);
		bw.Write(farr[2]);
	}

	internal static T ReadStruct<T>(BinaryReader br) where T : struct
	{
		int count = Marshal.SizeOf(typeof(T));
		return ReadStruct<T>(br.ReadBytes(count));
	}

	internal static T ReadStruct<T>(byte[] bytes) where T : struct
	{
		GCHandle gCHandle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
		try
		{
			return (T)Marshal.PtrToStructure(gCHandle.AddrOfPinnedObject(), typeof(T));
		}
		finally
		{
			gCHandle.Free();
		}
	}

	public unsafe static byte[] MPPCCompress(byte[] src)
	{
		uint num = (uint)src.Length;
		byte* ptr = (byte*)(void*)calloc(num, 1u);
		IntPtr destination = (IntPtr)ptr;
		Marshal.Copy(src, 0, destination, (int)num);
		int num2 = (int)GNET__mppc__compressBound(num);
		byte* ptr2 = (byte*)(void*)calloc((uint)num2, 1u);
		if (((num <= 8192) ? GNET__mppc__compress(ptr2, &num2, ptr, (int)num) : GNET__mppc__compress2(ptr2, &num2, ptr, (int)num)) == -1)
		{
			throw new ApplicationException(Class16.smethod_0(1649160548));
		}
		byte[] array = new byte[num2];
		Marshal.Copy((IntPtr)ptr2, array, 0, num2);
		free((IntPtr)ptr2);
		free((IntPtr)ptr);
		return array;
	}

	public unsafe static byte[] MPPCDecompress(byte[] src, int* dest_len)
	{
		uint num = (uint)src.Length;
		byte* ptr = (byte*)(void*)calloc(num, 1u);
		IntPtr destination = (IntPtr)ptr;
		Marshal.Copy(src, 0, destination, (int)num);
		byte* ptr2 = (byte*)(void*)calloc((uint)(*dest_len), 1u);
		if (((*dest_len <= 8192) ? GNET__mppc__uncompress(ptr2, dest_len, ptr, (int)num) : GNET__mppc__uncompress2(ptr2, dest_len, ptr, (int)num)) == -1)
		{
			throw new ApplicationException(Class16.smethod_0(1649160570));
		}
		byte[] array = new byte[*dest_len];
		Marshal.Copy((IntPtr)ptr2, array, 0, *dest_len);
		free((IntPtr)ptr2);
		free((IntPtr)ptr);
		return array;
	}

	internal unsafe static void ExchangeValues(int* v1, int* v2)
	{
		int num = *v1;
		*v1 = *v2;
		*v2 = num;
	}

	[DllImport("user32.dll", CharSet = CharSet.Unicode)]
	public static extern int GetWindowLongW(IntPtr hWnd, int nIndex);

	[DllImport("user32.dll", EntryPoint = "SetWindowLongA")]
	public static extern IntPtr SetWindowLongA_1(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

	[DllImport("kernel32.dll")]
	public static extern int RegisterApplicationRestart(string pwzCommandline, int dwFlags);

	[DllImport("user32.dll", SetLastError = true)]
	public static extern int PostMessage(IntPtr hWnd, int Msg, int wparam, int lparam);

	[DllImport("user32.dll")]
	public static extern bool UnregisterHotKey(IntPtr hWnd, HOTKEY_ID id);

	[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	public static extern IntPtr MapViewOfFile(IntPtr hFileMapping, int dwDesiredAccess, int dwFileOffsetHigh, int dwFileOffsetLow, int dwNumberOfBytesToMap);

	[DllImport("user32.dll")]
	public static extern bool GetWindowRect(IntPtr hWnd, IntPtr lpRect);

	[DllImport("user32.dll")]
	public static extern bool IsWindowVisible(IntPtr hWnd);

	[DllImport("user32.dll")]
	public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int int_0, int int_1, int cx, int cy, uint uFlags);

	[DllImport("user32.dll")]
	public static extern bool SetActiveWindow(IntPtr hWnd);

	[DllImport("user32.dll")]
	public static extern IntPtr RegisterDeviceNotificationA(IntPtr hRecipient, IntPtr NotificationFilter, uint Flags);

	[DllImport("user32.dll", CharSet = CharSet.Unicode)]
	public static extern int SetWindowTextW(IntPtr hWnd, string lpString);

	[DllImport("user32.dll")]
	public static extern IntPtr WindowFromPoint(tagPOINT tagPOINT_0);

	[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	public static extern IntPtr OpenFileMapping(int dwDesiredAccess, int bInheritHandle, string lpName);

	[DllImport("user32.dll")]
	public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

	[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	public static extern IntPtr CloseHandle(IntPtr hFile);

	[DllImport("shlwapi.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
	public static extern int StrCmpLogicalW(string string_0, string string_1);

	[DllImport("user32.dll", SetLastError = true)]
	public static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wparam, IntPtr lparam);

	[DllImport("user32.dll", SetLastError = true)]
	public static extern int SendMessage(IntPtr hWnd, int Msg, int wparam, int lparam);

	[DllImport("user32.dll", SetLastError = true)]
	public static extern int SendMessage(IntPtr hWnd, int Msg, int wparam, IntPtr lparam);

	[DllImport("user32.dll", CharSet = CharSet.Unicode)]
	public static extern int GetWindowTextLength(IntPtr hWnd);

	[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	public static extern IntPtr CreateFileMapping(IntPtr hFile, IntPtr lpAttributes, int flProtect, int dwMaxSizeHi, int dwMaxSizeLow, string lpName);

	[DllImport("user32.dll")]
	public static extern bool RegisterHotKey(IntPtr hWnd, HOTKEY_ID id, uint fsModifiers, uint vk);

	[DllImport("user32.dll")]
	public static extern IntPtr GetForegroundWindow();

	[DllImport("user32.dll", CharSet = CharSet.Unicode)]
	public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

	[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	public static extern IntPtr UnmapViewOfFile(IntPtr hFileMap);

	[DllImport("user32.dll")]
	public static extern bool IsWindowEnabled(IntPtr hWnd);

	[DllImport("user32.dll", CharSet = CharSet.Unicode)]
	public static extern bool EnumWindows(EnumWindowsProc enumProc, IntPtr lParam);

	[DllImport("user32.dll")]
	public static extern int GetWindowText(IntPtr hWnd, StringBuilder strText, int maxCount);

	[DllImport("user32.dll")]
	public static extern bool SetFocus(IntPtr hWnd);

	[DllImport("user32.dll", SetLastError = true)]
	public static extern int FindWindow(string lpClassName, string lpWindowName);

	[DllImport("shell32.dll", CharSet = CharSet.Unicode)]
	public static extern bool IsUserAnAdmin();

	[DllImport("shell32.dll")]
	public static extern void SHChangeNotify(int wEventId, int uFlags, IntPtr dwItem1, IntPtr dwItem2);

	[DllImport("user32.dll")]
	public static extern bool SetForegroundWindow(IntPtr hWnd);

	[DllImport("user32.dll", CharSet = CharSet.Unicode)]
	public static extern int RegisterWindowMessage(string strMessage);

	[DllImport("user32.dll")]
	public static extern bool EnableWindow(IntPtr hWnd, bool bEnable);

	[DllImport("KERNEL32.dll")]
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
	public unsafe static extern void* DecodePointer(void* _Ptr);

	[DllImport("KERNEL32.dll")]
	[SuppressUnmanagedCodeSecurity]
	[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
	[SecurityCritical]
	public unsafe static extern void* EncodePointer(void* _Ptr);

	[DllImport("kernel32.dll")]
	public static extern ulong GetTickCount64();

	[DllImport("kernel32.dll")]
	public static extern uint GetTickCount();

	[DllImport("user32.dll")]
	public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

	[DllImport("user32.dll")]
	public static extern IntPtr GetDC(IntPtr hWnd);

	[DllImport("user32.dll")]
	public static extern bool ReleaseDC(IntPtr hWnd, IntPtr hDC);

	[DllImport("gdi32.dll")]
	public static extern int GetDeviceCaps(IntPtr hdc, int nIndex);

	[DllImport("user32.dll")]
	public static extern IntPtr MonitorFromWindow(IntPtr hwnd, uint dwFlags);

	[DllImport("user32.dll")]
	public static extern bool GetMonitorInfoW(IntPtr hMonitor, ref MONITORINFO lpmi);

	[DllImport("user32.dll")]
	public static extern bool EnumDisplaySettingsW(string lpszDeviceName, uint iModeNum, ref DEVMODE lpDevMode);

	[DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
	internal static extern IntPtr LoadCursorFromFileW(string lpFileName);

	[DllImport("user32.dll", EntryPoint = "GetCursorPos")]
	private static extern bool GetCursorPos_1(out Struct111 struct111_0);

	[DllImport("user32.dll")]
	public static extern IntPtr SetWindowLongA(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

	[DllImport("user32.dll")]
	public static extern int GetAsyncKeyState(int vKey);

	[DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr calloc(UIntPtr num, UIntPtr size);

	[DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
	public static extern void free(IntPtr ptr);

	[DllImport("MPPCLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
	internal unsafe static extern int GNET__mppc__compress(byte* dest, int* destLen, byte* source, int sourceLen);

	[DllImport("MPPCLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
	internal unsafe static extern int GNET__mppc__compress2(byte* dest, int* destLen, byte* source, int sourceLen);

	[DllImport("MPPCLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
	internal unsafe static extern int GNET__mppc__uncompress(byte* dest, int* destLen, byte* source, int sourceLen);

	[DllImport("MPPCLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
	internal unsafe static extern int GNET__mppc__uncompress2(byte* dest, int* destLen, byte* source, int sourceLen);

	[DllImport("MPPCLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
	public static extern uint GNET__mppc__compressBound(uint sourceLen);

	[DllImport("user32.dll", SetLastError = true)]
	public static extern int PostMessage(IntPtr hWnd, int Msg, int wparam, IntPtr lparam);

	[DllImport("user32.dll", SetLastError = true)]
	public static extern int PostMessage(IntPtr hWnd, int Msg, IntPtr wparam, IntPtr lparam);

	[return: MarshalAs(UnmanagedType.U1)]
	internal static bool IsIntFast(string input)
	{
		if (string.IsNullOrWhiteSpace(input))
		{
			return false;
		}
		switch (input[0])
		{
		default:
			return false;
		case '-':
		case '0':
		case '1':
		case '2':
		case '3':
		case '4':
		case '5':
		case '6':
		case '7':
		case '8':
		case '9':
		{
			int length = input.Length;
			int num = 1;
			if (1 < length)
			{
				do
				{
					char c = input[num];
					if ((ushort)(c + 65488) <= 9)
					{
						num++;
						continue;
					}
					return false;
				}
				while (num < length);
				return true;
			}
			return true;
		}
		}
	}

	[return: MarshalAs(UnmanagedType.U1)]
	internal static bool IsUIntFast(string input)
	{
		if (string.IsNullOrEmpty(input))
		{
			return false;
		}
		int length = input.Length;
		int num = 0;
		if (0 < length)
		{
			do
			{
				char c = input[num];
				if ((ushort)(c + 65488) <= 9)
				{
					num++;
					continue;
				}
				return false;
			}
			while (num < length);
			return true;
		}
		return true;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	internal static bool IsNumber(string input)
	{
		if (!string.IsNullOrEmpty(input))
		{
			double result;
			if (!(input == Class16.smethod_0(1648924112)))
			{
				return double.TryParse(input, out result);
			}
			return true;
		}
		return false;
	}

	internal static int pow(int int_0, int int_1)
	{
		return (int)Math.Pow(int_0, int_1);
	}

	internal static int String2Int32(string Value)
	{
		int result = 0;
		int.TryParse(Value, out result);
		return result;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	internal static bool TryParseUIntFast(string value, ref uint result)
	{
		if (value != null && value.Length != 0)
		{
			char[] array = value.ToCharArray();
			int num = 0;
			if (array.Length != 0)
			{
				do
				{
					char c = array[num];
					if ((ushort)(c + 65488) <= 9)
					{
						result = c + result * 10 - 48;
						num++;
						continue;
					}
					return false;
				}
				while (num < array.Length);
				return true;
			}
			return true;
		}
		return false;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	internal static bool TryParseUIntFastAsInt(string value, ref int result)
	{
		if (value != null && value.Length != 0)
		{
			char[] array = value.ToCharArray();
			int num = 0;
			if (array.Length != 0)
			{
				do
				{
					char c = array[num];
					if ((ushort)(c + 65488) <= 9)
					{
						result = c + result * 10 - 48;
						num++;
						continue;
					}
					return false;
				}
				while (num < array.Length);
				return true;
			}
			return true;
		}
		return false;
	}

	internal static int UIntParseFast(string value)
	{
		if (value == null)
		{
			return 0;
		}
		int num = 0;
		int length = value.Length;
		int num2 = 0;
		if (0 < length)
		{
			do
			{
				num = num * 10 + value[num2] - 48;
				num2++;
			}
			while (num2 < length);
		}
		return num;
	}

	internal static uint UUIntParseFast(string value)
	{
		if (value == null)
		{
			return 0u;
		}
		uint num = 0u;
		int length = value.Length;
		int num2 = 0;
		if (0 < length)
		{
			do
			{
				num = num * 10 + value[num2] - 48;
				num2++;
			}
			while (num2 < length);
		}
		return num;
	}

	internal static ulong UInt64ParseFast(string value)
	{
		if (value == null)
		{
			return 0uL;
		}
		ulong num = 0uL;
		int length = value.Length;
		int num2 = 0;
		if (0 < length)
		{
			do
			{
				num = (ulong)(value[num2] - 48) + num * 10L;
				num2++;
			}
			while (num2 < length);
		}
		return num;
	}

	internal static int String2Int_ext(string str)
	{
		if (str == Class16.smethod_0(1648935128))
		{
			return 32;
		}
		if (str == Class16.smethod_0(1648935171))
		{
			return 64;
		}
		if (str == Class16.smethod_0(1648935093))
		{
			return 16;
		}
		if (str == Class16.smethod_0(1648935222))
		{
			return 128;
		}
		if (str == Class16.smethod_0(1648935258))
		{
			return 256;
		}
		if (str == Class16.smethod_0(1648935311))
		{
			return 512;
		}
		return UIntParseFast(str);
	}

	internal static string ToPercent(float value, int NumAfterDecimal)
	{
		double num = (double)value * 100.0;
		double num2 = num;
		double num3 = num2 - (double)(int)num2;
		if ((double)value > 0.0001 && (num3 < 0.0001 || 1.0 - num3 < 0.0001))
		{
			double num4 = num;
			string text = Class16.smethod_0(1648923229);
			return num4.ToString(Class16.smethod_0(1648952888)) + text;
		}
		double num5 = Math.Round(num, NumAfterDecimal);
		string text2 = Class16.smethod_0(1648923229);
		return num5 + text2;
	}

	internal static string ToPercent(decimal value, int NumAfterDecimal)
	{
		decimal num = 999999m;
		if (value > num)
		{
			return Class16.smethod_0(1649160621);
		}
		decimal num2 = -999999m;
		if (value < num2)
		{
			return Class16.smethod_0(1649160627);
		}
		decimal d = 100m;
		decimal d2 = decimal.Multiply(value, d);
		d2 = Math.Round(d2, NumAfterDecimal);
		string text = Class16.smethod_0(1648923229);
		return d2.ToString(Class16.smethod_0(1648989181)) + text;
	}

	internal static string ToPercent(double value, int NumAfterDecimal)
	{
		double num = Math.Round(value * 100.0, NumAfterDecimal);
		string text = Class16.smethod_0(1648923229);
		return num.ToString(Class16.smethod_0(1648989181)) + text;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	internal static bool ContainsIgnoreCase(string str, string value)
	{
		int num = ((str != null && value != null && str.IndexOf(value, StringComparison.OrdinalIgnoreCase) > -1) ? 1 : 0);
		return (byte)num != 0;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	internal static bool ContainsIgnoreCase(string str, string variation1, string variation2)
	{
		if (str == null)
		{
			return false;
		}
		int num = ((str.IndexOf(variation1, StringComparison.OrdinalIgnoreCase) > -1 || str.IndexOf(variation2, StringComparison.OrdinalIgnoreCase) > -1) ? 1 : 0);
		return (byte)num != 0;
	}

	internal static string ReplaceIgnoreCase(string str, string search, string replacement)
	{
		string newValue = Class16.smethod_0(1649160642);
		string oldValue = Class16.smethod_0(1648938114);
		return Regex.Replace(str, Regex.Escape(search), replacement.Replace(oldValue, newValue), RegexOptions.IgnoreCase);
	}

	internal static string RemoveSpecialTextVars(string text)
	{
		text = text.Replace(Class16.smethod_0(1648908173), Class16.smethod_0(1648923229));
		text = text.Replace(Class16.smethod_0(1648908182), Class16.smethod_0(1648916453));
		text = text.Replace(Class16.smethod_0(1648962129), Class16.smethod_0(1649105917));
		text = text.Replace(Class16.smethod_0(1649160651), Class16.smethod_0(1648916453));
		text = text.Replace('\v', ' ');
		return text.Replace('\t', ' ');
	}

	internal static HSV Color2HSV(Color color)
	{
		HSV result = default(HSV);
		int num = Math.Max(color.R, Math.Max(color.G, color.B));
		int num2 = Math.Min(color.R, Math.Min(color.G, color.B));
		result.Hue = color.GetHue() / 360f;
		float saturation = ((num != 0) ? ((float)(1.0 - (double)(float)num2 / (double)(float)num)) : 0f);
		result.Saturation = saturation;
		result.Brightness = (float)num / 255f;
		return result;
	}

	internal static Color ColorFromHSV(HSV hsv)
	{
		int num = Convert.ToInt32(Math.Floor((double)(hsv.Hue *= 360f) / 60.0)) % 6;
		double num2 = (double)hsv.Hue / 60.0;
		double num3 = num2;
		double num4 = num3 - Math.Floor(num3);
		int num5 = Convert.ToInt32(hsv.Brightness *= 255f);
		int num6 = Convert.ToInt32((float)((1.0 - (double)hsv.Saturation) * (double)hsv.Brightness));
		int num7 = Convert.ToInt32((1.0 - (double)hsv.Saturation * num4) * (double)hsv.Brightness);
		int num8 = Convert.ToInt32((1.0 - (double)hsv.Saturation * (1.0 - num4)) * (double)hsv.Brightness);
		return num switch
		{
			0 => Color.FromArgb(255, num5, num8, num6), 
			1 => Color.FromArgb(255, num7, num5, num6), 
			2 => Color.FromArgb(255, num6, num5, num8), 
			3 => Color.FromArgb(255, num6, num7, num5), 
			4 => Color.FromArgb(255, num8, num6, num5), 
			_ => Color.FromArgb(255, num5, num6, num7), 
		};
	}

	internal static int GetMaxValueIndex(float[] Arr)
	{
		float num = 0f;
		int result = 0;
		int num2 = Arr.Length;
		int num3 = 0;
		if (0 < num2)
		{
			do
			{
				float num4 = Arr[num3];
				if ((double)num4 > (double)num)
				{
					num = num4;
					result = num3;
				}
				num3++;
			}
			while (num3 < num2);
		}
		return result;
	}

	internal static int GetMaxValueIndex(List<float> Arr)
	{
		float num = 0f;
		int result = 0;
		int count = Arr.Count;
		int num2 = 0;
		if (0 < count)
		{
			do
			{
				if ((double)Arr[num2] > (double)num)
				{
					num = Arr[num2];
					result = num2;
				}
				num2++;
			}
			while (num2 < count);
		}
		return result;
	}

	internal static int[] ParseListOfInt(string SeparatedList)
	{
		char[] separator = new char[1] { ',' };
		string[] array = SeparatedList.Replace(';', ',').Split(separator);
		bool flag = true;
		int num = 0;
		if (array.Length != 0)
		{
			do
			{
				flag = IsUIntFast(array[num]) && flag;
				num++;
			}
			while (num < array.Length);
			if (!flag)
			{
				return null;
			}
		}
		return StringArray2IntArray(array);
	}

	internal static string[] ParseListOfString(string SeparatedList)
	{
		return SeparatedList.Split(';');
	}

	internal static string[] TryParseStrings(string text)
	{
		if (string.IsNullOrWhiteSpace(text))
		{
			return null;
		}
		text = text.Trim();
		text = text.Replace(Class16.smethod_0(1648942920), Class16.smethod_0(1648928028));
		if (!IsNumber(text))
		{
			return text.Split(',', ';');
		}
		return null;
	}

	internal static decimal ToDecimalSafe(float value)
	{
		if (!float.IsNaN(value) && !float.IsInfinity(value))
		{
			if ((double)value < -7.922816251426434E+28)
			{
				return decimal.MinValue;
			}
			if ((double)value > 7.922816251426434E+28)
			{
				return decimal.MaxValue;
			}
			return new decimal(value);
		}
		return 0m;
	}

	internal static decimal ToDecimalSafe(double value)
	{
		if (!double.IsNaN(value) && !double.IsInfinity(value))
		{
			if (value < -7.922816251426434E+28)
			{
				return decimal.MinValue;
			}
			if (value > 7.922816251426434E+28)
			{
				return decimal.MaxValue;
			}
			return new decimal(value);
		}
		return 0m;
	}

	internal static List<string> ParseSpaceHashMap(string source)
	{
		List<string> list = new List<string>();
		string pattern = Class16.smethod_0(1649160670);
		string empty = string.Empty;
		string oldValue = Class16.smethod_0(1648904221);
		source = source.Replace(Class16.smethod_0(1648941987), empty).Replace(oldValue, empty);
		MatchCollection matchCollection = Regex.Matches(source, pattern);
		HashSet<string> hashSet = new HashSet<string>();
		if (matchCollection.Count > 0)
		{
			foreach (Match item in matchCollection)
			{
				string value = item.Groups[1].Value;
				string value2 = item.Groups[2].Value;
				list.Add(value + Class16.smethod_0(1648905535) + value2);
				if (!hashSet.Contains(value2))
				{
					hashSet.Add(value2);
				}
			}
		}
		list.Add(string.Empty);
		list.AddRange(hashSet);
		return list;
	}

	internal static void OrderConfig(string source_config, string dest_config, string sListOrderPath, GAMES Game, short version)
	{
		eListCollection eListCollection2 = new eListCollection(Game);
		StreamReader sr = new StreamReader(source_config);
		eListCollection2.LoadConfig(sr, null, null, null, null, bSetMainFieldsTypes: false);
		eListCollection eListCollection3 = new eListCollection(Game);
		StreamReader sr2 = new StreamReader(source_config);
		eListCollection3.LoadConfig(sr2, null, null, null, null, bSetMainFieldsTypes: false);
		StreamReader streamReader = File.OpenText(sListOrderPath);
		bool flag = false;
		int num = 0;
		string text = streamReader.ReadLine();
		if (text != null)
		{
			do
			{
				string[] array = text.Split(':');
				string text2 = array[0];
				int num2 = eListCollection2.get_LI(text2);
				if (num2 != -1)
				{
					if (array.Length > 1)
					{
						string text3 = array[1];
						if (!IsNumber(text3))
						{
							eListCollection2.Lists[num2].sAutoOffset = Class16.smethod_0(1648902775);
						}
						else
						{
							eListCollection2.Lists[num2].listOffsetData = new byte[UIntParseFast(text3)];
						}
					}
					else if (Game == GAMES.PW)
					{
						eListCollection2.Lists[num2].listOffsetData = new byte[0];
					}
					eListCollection3.Lists[num] = eListCollection2.Lists[num2];
					num++;
				}
				else if (!flag)
				{
					string text4 = Class16.smethod_0(1649160703);
					DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649163787), Class16.smethod_0(1649119793)) + text2 + text4, Class16.smethod_0(1648934892), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					flag = true;
				}
				text = streamReader.ReadLine();
			}
			while (text != null);
		}
		if (num != eListCollection2.ListCount)
		{
			int num3 = 0;
			if (eListCollection2.Lists.Length != 0)
			{
				do
				{
					int num4 = 0;
					if (0 >= num)
					{
						goto IL_0176;
					}
					while (true)
					{
						eList eList2 = eListCollection2.Lists[num3];
						if (eListCollection3.Lists[num4].uListName == eList2.uListName)
						{
							break;
						}
						num4++;
						if (num4 < num)
						{
							continue;
						}
						goto IL_0176;
					}
					goto IL_01b8;
					IL_01b8:
					num3++;
					continue;
					IL_0176:
					eList eList3 = eListCollection2.Lists[num3];
					DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649163817), Class16.smethod_0(1649163861)) + eList3.uListName, Class16.smethod_0(1648934892), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					goto IL_01b8;
				}
				while (num3 < eListCollection2.Lists.Length);
			}
			string text5 = Class16.smethod_0(1649163882);
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649163934), Class16.smethod_0(1649163973)) + sListOrderPath + text5, Class16.smethod_0(1648934892), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
		streamReader.Close();
		int conversationListIndex = ((Game != GAMES.PW || version >= 191) ? 999 : 58);
		eListCollection3.ConversationListIndex = conversationListIndex;
	}

	internal static void ConvertStructureToNormalEnglish(string source_config, string dest_config, GAMES Game, [MarshalAs(UnmanagedType.U1)] bool bPreserveUniversalFields)
	{
		eListCollection eListCollection2 = new eListCollection(Game);
		StreamReader sr = new StreamReader(source_config);
		eListCollection2.LoadConfig(sr, null, null, null, null, bSetMainFieldsTypes: false);
		eList[] lists = eListCollection2.Lists;
		int num = 0;
		if (lists.Length == 0)
		{
			return;
		}
		do
		{
			lists[num].ListName = GetListFriendlyName(lists[num].ListName);
			lists[num].ListName = lists[num].ListName.Replace(Class16.smethod_0(1649043292), Class16.smethod_0(1648942211));
			int num2 = 0;
			string[] elementFields = lists[num].elementFields;
			if (elementFields.Length != 0)
			{
				do
				{
					string text = elementFields[num2];
					if (!(text == Class16.smethod_0(1648966655)))
					{
						text = NamesConverter.GetFieldFriendlyName(text);
						lists[num].elementFields[num2] = text;
					}
					num2++;
					elementFields = lists[num].elementFields;
				}
				while (num2 < elementFields.Length);
			}
			num++;
		}
		while (num < lists.Length);
	}

	internal static string ConvertPropertiesNames(string string_0)
	{
		MatchCollection matchCollection = Regex.Matches(string_0, Class16.smethod_0(1649164013), RegexOptions.Multiline);
		if (matchCollection.Count > 0)
		{
			foreach (Match item in matchCollection)
			{
				string_0 = string_0.Replace(item.Groups[1].ToString(), item.Groups[2].ToString());
			}
		}
		return string_0;
	}

	internal static void ParseSkillIcons(string CppFileName)
	{
		Regex regex = new Regex(Class16.smethod_0(1649164076), RegexOptions.Compiled);
		Regex regex2 = new Regex(Class16.smethod_0(1649164121), RegexOptions.Compiled);
		Regex regex3 = new Regex(Class16.smethod_0(1649164146), RegexOptions.Compiled);
		Regex regex4 = new Regex(Class16.smethod_0(1649164180), RegexOptions.Compiled);
		List<SKILL> list = new List<SKILL>(5000);
		StringBuilder stringBuilder = new StringBuilder(256000);
		StreamReader streamReader = File.OpenText(CppFileName);
		string text = streamReader.ReadLine();
		if (text != null)
		{
			do
			{
				if (text.Length >= 10 && text.Contains(Class16.smethod_0(1649164203)) && regex.IsMatch(text))
				{
					SKILL item = default(SKILL);
					string text2 = regex.Matches(text)[0].Groups[1].ToString();
					if (text2.StartsWith(Class16.smethod_0(1648917675)))
					{
						text2 = text2.Substring(2);
					}
					if ((item.id = int.Parse(text2, NumberStyles.HexNumber)) - 1 <= 19998)
					{
						int num = 0;
						string text3 = streamReader.ReadLine();
						if (text3 != null)
						{
							do
							{
								MatchCollection matchCollection = regex2.Matches(text3);
								if (matchCollection.Count <= 0)
								{
									matchCollection = regex3.Matches(text3);
									if (matchCollection.Count > 0)
									{
										item.type = UIntParseFast(matchCollection[0].Groups[1].ToString());
									}
									else
									{
										matchCollection = regex4.Matches(text3);
										if (matchCollection.Count > 0)
										{
											item.max_level = UIntParseFast(matchCollection[0].Groups[1].ToString());
										}
									}
								}
								else
								{
									item.cls = UIntParseFast(matchCollection[0].Groups[1].ToString());
								}
								num++;
								if (num > 30)
								{
									break;
								}
								text3 = streamReader.ReadLine();
							}
							while (text3 != null);
						}
						list.Add(item);
						string text4 = Class16.smethod_0(1648898262);
						stringBuilder.AppendLine(item.id + text4 + item.type + text4 + item.cls + text4 + item.max_level);
					}
				}
				text = streamReader.ReadLine();
			}
			while (text != null);
		}
		streamReader.Close();
		OpenInNotepad(stringBuilder.ToString());
	}

	internal static byte[] ToBytesGBK(string string_0)
	{
		return Encoding.GetEncoding(Class16.smethod_0(1648985403)).GetBytes(string_0);
	}

	internal static byte[] ToBytesGBK(string string_0, int length)
	{
		byte[] array = new byte[length];
		byte[] bytes = Encoding.GetEncoding(Class16.smethod_0(1648985403)).GetBytes(string_0);
		int num = bytes.Length;
		length = ((num < length) ? num : length);
		Array.Copy(bytes, array, length);
		return array;
	}

	internal static byte[] ToBytesA(string string_0, int length)
	{
		byte[] array = new byte[length];
		byte[] bytes = Encoding.ASCII.GetBytes(string_0);
		int num = bytes.Length;
		length = ((num < length) ? num : length);
		Array.Copy(bytes, array, length);
		return array;
	}

	internal static byte[] ToBytesW(string string_0, int length)
	{
		length <<= 1;
		byte[] array = new byte[length];
		byte[] bytes = Encoding.Unicode.GetBytes(string_0);
		int num = bytes.Length;
		length = ((num < length) ? num : length);
		Array.Copy(bytes, array, length);
		return array;
	}

	internal static string ToStringGBK(byte[] bytes)
	{
		string text = Encoding.GetEncoding(Class16.smethod_0(1648985403)).GetString(bytes);
		int num = text.IndexOf('\0');
		if (num < 0)
		{
			return text;
		}
		return text.Substring(0, num);
	}

	internal static string ToStringW(byte[] bytes)
	{
		string text = Encoding.Unicode.GetString(bytes);
		int num = text.IndexOf('\0');
		if (num < 0)
		{
			return text;
		}
		return text.Substring(0, num);
	}

	internal static string WithCapitalLetter(string input)
	{
		if (string.IsNullOrWhiteSpace(input))
		{
			return string.Empty;
		}
		return input.Substring(0, 1).ToUpper() + input.Substring(1).ToLowerInvariant();
	}

	internal static string ToNormalText(string text, [MarshalAs(UnmanagedType.U1)] bool bOneLine)
	{
		if (bOneLine)
		{
			text = text.Replace(Class16.smethod_0(1648924428), Class16.smethod_0(1648942211));
			text = text.Replace('\r', ' ');
			text = text.Replace('\n', ' ');
			text = text.Replace('\u3000', ' ');
			if (text.Contains(Class16.smethod_0(1649043292)))
			{
				do
				{
					text = text.Replace(Class16.smethod_0(1649043292), Class16.smethod_0(1648942211));
				}
				while (text.Contains(Class16.smethod_0(1649043292)));
			}
			text = text.Replace(Class16.smethod_0(1649164244), Class16.smethod_0(1649168353));
		}
		if (text.Contains(Class16.smethod_0(1648935659)))
		{
			text = Regex.Replace(text, Class16.smethod_0(1649131805), string.Empty);
		}
		return text;
	}

	internal static string CutString(string input, int length)
	{
		int count = Regex.Matches(input, Class16.smethod_0(1649131805)).Count;
		if (Regex.Replace(input, Class16.smethod_0(1649131805), string.Empty).Length - 3 <= length)
		{
			return input;
		}
		string text = Class16.smethod_0(1648924410);
		return input.Substring(0, count * 7 + length) + text;
	}

	internal static void AppendStringValue(ref string dest, string value)
	{
		if (!string.IsNullOrEmpty(dest))
		{
			dest = dest + Class16.smethod_0(1648942920) + value;
		}
		else
		{
			dest = value;
		}
	}

	[return: MarshalAs(UnmanagedType.U1)]
	internal static bool IsSpecialLongChar(string string_0)
	{
		int num = 14;
		if (14 < CHARS.SpecialChars.Length)
		{
			do
			{
				if (!(CHARS.SpecialChars[num] == string_0))
				{
					num++;
					continue;
				}
				return true;
			}
			while (num < CHARS.SpecialChars.Length);
			return false;
		}
		return false;
	}

	internal static string ReplaceSpecialChars(string text)
	{
		if (text.Length < 2)
		{
			return text;
		}
		int num = 14;
		string[] specialChars = CHARS.SpecialChars;
		if (14 < specialChars.Length)
		{
			do
			{
				string text2 = specialChars[num];
				string text3 = CHARS.SpecialChars[num];
				string text4 = text;
				string oldValue = text3;
				string text5 = text2;
				text = text4.Replace(oldValue, text5 + text5);
				num++;
				specialChars = CHARS.SpecialChars;
			}
			while (num < specialChars.Length);
		}
		return text;
	}

	internal static string ReplaceChineseLongChars(string text)
	{
		if (text.Length < 2)
		{
			return text;
		}
		int num = 0;
		string[] chineseLongChars = CHARS.ChineseLongChars;
		if (chineseLongChars.Length != 0)
		{
			do
			{
				text = text.Replace(chineseLongChars[num], Class16.smethod_0(1648978986));
				num++;
				chineseLongChars = CHARS.ChineseLongChars;
			}
			while (num < chineseLongChars.Length);
		}
		return text;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	internal static bool IsTallCharsExist(string text)
	{
		string[] tallChars = CHARS.TallChars;
		int num = 0;
		if (tallChars.Length != 0)
		{
			do
			{
				if (!text.Contains(tallChars[num]))
				{
					num++;
					continue;
				}
				return true;
			}
			while (num < tallChars.Length);
			return false;
		}
		return false;
	}

	internal static string ColorToString(Color color_0)
	{
		byte b = color_0.B;
		byte g = color_0.G;
		byte r = color_0.R;
		string text = Class16.smethod_0(1648918695);
		string text2 = Class16.smethod_0(1648918695);
		return r.ToString(Class16.smethod_0(1648918695)) + g.ToString(text2) + b.ToString(text);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	internal static bool IsStringContainsAnyStringInArray(string str, string[] SearchedStrings)
	{
		if (str != null && !string.IsNullOrEmpty(str))
		{
			int num = 0;
			if (SearchedStrings.Length != 0)
			{
				do
				{
					string value = SearchedStrings[num];
					if (!str.Contains(value))
					{
						num++;
						continue;
					}
					return true;
				}
				while (num < SearchedStrings.Length);
				return false;
			}
			return false;
		}
		return false;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	internal static bool IsStringEqualWithRegexList(string str, string[] SearchedStrings, ref string res_regex)
	{
		if (str != null && !string.IsNullOrEmpty(str))
		{
			int num = 0;
			if (SearchedStrings.Length != 0)
			{
				string text;
				while (true)
				{
					text = SearchedStrings[num];
					if (Regex.IsMatch(str, text))
					{
						break;
					}
					num++;
					if (num >= SearchedStrings.Length)
					{
						return false;
					}
				}
				res_regex = text;
				return true;
			}
			return false;
		}
		return false;
	}

	internal static string SplitTextWithLines(string text, int OneLineCharsCount)
	{
		int num = 0;
		int num2 = 0;
		if (0 < text.Length - 2)
		{
			do
			{
				string text2 = Class16.smethod_0(1648941987);
				if (text.Substring(num2, 1) != text2)
				{
					string text3 = Class16.smethod_0(1648904221);
					if (text.Substring(num2, 1) != text3)
					{
						string text4 = Class16.smethod_0(1648903412);
						if (text.Substring(num2, 2) != text4)
						{
							string text5 = Class16.smethod_0(1648935632);
							if (text.Substring(num2, 2) != text5)
							{
								num++;
								goto IL_0019;
							}
						}
					}
				}
				num = 0;
				goto IL_0019;
				IL_0019:
				if (num >= OneLineCharsCount)
				{
					string text6 = Class16.smethod_0(1648942211);
					if (text.Substring(num2 + 1, 1) == text6)
					{
						num2++;
						text = text.Insert(num2, Class16.smethod_0(1648924428));
						num = 0;
						num2 += 2;
					}
				}
				num2++;
			}
			while (num2 < text.Length - 2);
		}
		return text;
	}

	internal static string RegEx_FilterValue(string input, string pattern)
	{
		Match match = Regex.Match(input, pattern);
		if (!match.Success)
		{
			return string.Empty;
		}
		if (match.Groups.Count > 1)
		{
			return match.Groups[1].Value;
		}
		return Class16.smethod_0(1648934925);
	}

	internal static string rn2CrLF(string text)
	{
		if (text != null)
		{
			text = text.Replace(Class16.smethod_0(1649164255), Class16.smethod_0(1648924428));
			text = text.Replace(Class16.smethod_0(1648935632), Class16.smethod_0(1648924428));
			text = text.Replace(Class16.smethod_0(1648903412), Class16.smethod_0(1648924428));
		}
		return text;
	}

	internal static string CrLF2rn(string text)
	{
		if (text != null)
		{
			text = text.Replace(Class16.smethod_0(1648924428), Class16.smethod_0(1648935632));
			text = text.Replace(Class16.smethod_0(1649164258), Class16.smethod_0(1649164267));
			text = text.Replace('"', '\'');
		}
		return text;
	}

	internal static string DoubleToString(double num)
	{
		if (Math.Abs(num - Math.Floor(num)) < 1E-05)
		{
			double num2 = num;
			return num2.ToString(Class16.smethod_0(1648909972));
		}
		double num3 = num;
		return num3.ToString();
	}

	internal static IntPtr Array2Char(byte[] Arr)
	{
		IntPtr intPtr = Marshal.AllocHGlobal(Arr.Length);
		Marshal.Copy(Arr, 0, intPtr, Arr.Length);
		return intPtr;
	}

	internal static byte[] Char2Array(IntPtr intptr_0, int len)
	{
		byte[] array = new byte[len];
		Marshal.Copy(intptr_0, array, 0, len);
		Marshal.FreeHGlobal(intptr_0);
		return array;
	}

	internal static string Size2Text(ulong size)
	{
		ulong num = size / 1000000000L;
		if (num >= 1000L)
		{
			double num2 = Math.Round((double)num / 1000.0, 1);
			string text = Class16.smethod_0(1649164284);
			return num2 + text;
		}
		ulong num3 = num;
		string text2 = Class16.smethod_0(1649163271);
		return num3 + text2;
	}

	internal static string FileSize2Text(ulong size)
	{
		double num = Math.Round((double)size * 9.313225746154785E-10, 2);
		string text = Class16.smethod_0(1649163271);
		return num + text;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	internal static bool IsHexString(string str)
	{
		int num = 0;
		if (0 < str.Length)
		{
			do
			{
				byte character = (byte)str[num];
				if (Uri.IsHexDigit((char)character))
				{
					num++;
					continue;
				}
				return false;
			}
			while (num < str.Length);
			return true;
		}
		return true;
	}

	internal static string[] GetLines(string text)
	{
		return Regex.Split(text, Class16.smethod_0(1649163274));
	}

	internal static string Bytes2StringW(byte[] bytes)
	{
		int num = 0;
		int num2 = 0;
		int num3 = bytes.Length - 1;
		if (0 < num3)
		{
			do
			{
				if (bytes[num2] != 0 || bytes[num2 + 1] != 0)
				{
					num2 += 2;
					continue;
				}
				num = num2;
				break;
			}
			while (num2 < num3);
		}
		string result = string.Empty;
		if (num > 0)
		{
			result = Encoding.Unicode.GetString(bytes, 0, num);
		}
		return result;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	internal static bool IsRegex(string string_0)
	{
		if (string.IsNullOrWhiteSpace(string_0))
		{
			return false;
		}
		int num = ((string_0[0] == '^' || string_0.Contains(Class16.smethod_0(1648938114)) || string_0.Contains(Class16.smethod_0(1649163291)) || string_0.Contains(Class16.smethod_0(1648927580))) ? 1 : 0);
		return (byte)num != 0;
	}

	internal static string ReadGBKString(ref BinaryReader br, int offset)
	{
		br.BaseStream.Seek(offset, SeekOrigin.Begin);
		List<byte> list = new List<byte>(10);
		byte b = br.ReadByte();
		if (b != 0)
		{
			while (b != 0)
			{
				list.Add(b);
				b = br.ReadByte();
				if (b == 0)
				{
					break;
				}
			}
		}
		return Encoding.GetEncoding(Class16.smethod_0(1648985403)).GetString(list.ToArray());
	}

	internal static string DeleteStartSpacesAndTabs(string text)
	{
		int num = 0;
		if (0 < text.Length)
		{
			while (!(text.Substring(num, 1) != Class16.smethod_0(1648942211)) || !(text.Substring(num, 1) != Class16.smethod_0(1648904383)))
			{
				num++;
				if (num >= text.Length)
				{
					break;
				}
			}
		}
		return text.Substring(num);
	}

	internal static ulong Log2(ulong num)
	{
		return (ulong)Math.Log(num, 2.0);
	}

	internal static void CtrlC(object text)
	{
		Clipboard.SetDataObject(new DataObject(DataFormats.UnicodeText, text), copy: false, 100, 100);
	}

	internal static int GetValueIndexByBaseVersion150_JD(int int_0, int BaseValueIndex, ushort version)
	{
		int num = 0;
		if (version == 150)
		{
			return BaseValueIndex;
		}
		switch (int_0)
		{
		case 21:
			if (version >= 156)
			{
				num = ((BaseValueIndex >= 16) ? 2 : num);
				if (BaseValueIndex >= 87)
				{
					num += 2;
				}
			}
			break;
		case 3:
			if (version >= 156)
			{
				num = ((BaseValueIndex >= 14) ? 3 : num);
				if (BaseValueIndex >= 116)
				{
					num++;
				}
				if (version >= 158)
				{
					if (num + BaseValueIndex >= 17)
					{
						num += 2;
					}
					if (num + BaseValueIndex >= 24)
					{
						num += 12;
					}
					if (num + BaseValueIndex >= 142)
					{
						num += 2;
					}
				}
			}
			if (version == 112 && BaseValueIndex > 5)
			{
				num -= 15;
			}
			break;
		}
		return num + BaseValueIndex;
	}

	internal static int GetValueIndexByBaseVersion547_FW(int int_0, int BaseValueIndex, ushort version)
	{
		int num = 0;
		if (version <= 547)
		{
			return BaseValueIndex;
		}
		switch (int_0)
		{
		case 19:
			if (version >= 643 && BaseValueIndex >= 11)
			{
				num = 1;
			}
			break;
		case 1:
			if (version >= 595)
			{
				num = ((BaseValueIndex >= 4) ? 2 : num);
				if (BaseValueIndex >= 76)
				{
					num++;
				}
			}
			if (version >= 615 && BaseValueIndex >= 112)
			{
				num++;
			}
			break;
		}
		return num + BaseValueIndex;
	}

	internal static Hashtable loadRules(string file, ref Hashtable rules, [MarshalAs(UnmanagedType.U1)] bool isinclude)
	{
		StreamReader streamReader = new StreamReader(file);
		string text = streamReader.ReadLine();
		if (text != null)
		{
			do
			{
				Application.DoEvents();
				if (!text.StartsWith(Class16.smethod_0(1649163308)))
				{
					if (text != string.Empty && !text.StartsWith(Class16.smethod_0(1648929947)))
					{
						string text2;
						string value;
						if (text.Contains(Class16.smethod_0(1648905535)))
						{
							string[] array = text.Split('|');
							text2 = array[0];
							value = array[1];
							if (isinclude)
							{
								if (text2 == Class16.smethod_0(1648963016))
								{
									int num = Convert.ToInt32((string)rules[Class16.smethod_0(1648963016)]) + Convert.ToInt32(value);
									rules[Class16.smethod_0(1648963016)] = num.ToString();
								}
								goto IL_00d1;
							}
						}
						else
						{
							text2 = text;
							value = string.Empty;
						}
						rules.Add(text2, value);
					}
				}
				else
				{
					string text3 = text.Split('|')[1];
					string text4 = Class16.smethod_0(1648927580);
					loadRules(Application.StartupPath + text4 + text3, ref rules, isinclude: true);
				}
				goto IL_00d1;
				IL_00d1:
				text = streamReader.ReadLine();
			}
			while (text != null);
		}
		streamReader.Close();
		return rules;
	}

	internal static Color Bgab2Argb(byte[] byteColor)
	{
		Color result = Color.FromArgb(255, byteColor[2], byteColor[1], byteColor[0]);
		if (byteColor[3] < 85)
		{
			return Color.Black;
		}
		return result;
	}

	internal static byte[] Rgb2Bgab(Color color_0)
	{
		byte b = byte.MaxValue;
		if (color_0.B == 0 && color_0.G == 0)
		{
			b = (byte)((color_0.R != 0) ? b : 0);
		}
		return new byte[4] { color_0.B, color_0.G, color_0.R, b };
	}

	internal static int CountWords(string text, string search)
	{
		if (!string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(search))
		{
			string empty = string.Empty;
			return (text.Length - text.Replace(search, empty).Length) / search.Length;
		}
		return 0;
	}

	internal static string CutLines(string text)
	{
		if (!string.IsNullOrWhiteSpace(text) && text.Length >= 100)
		{
			string[] array = text.Split('\n');
			int num = 0;
			if (array.Length != 0)
			{
				do
				{
					ref string reference = ref array[num];
					if (reference.Length > 100)
					{
						if (CountWords(reference, Class16.smethod_0(1649163315)) > 1)
						{
							reference = CutLines(reference = reference.Replace(Class16.smethod_0(1649163315), Class16.smethod_0(1649163332)));
						}
						else
						{
							int num2 = 80;
							if (80 < reference.Length)
							{
								string text2;
								do
								{
									if (num2 < reference.Length)
									{
										while (reference[num2 - 1] != ' ')
										{
											num2++;
											if (num2 >= reference.Length)
											{
												break;
											}
										}
									}
									if (num2 >= reference.Length)
									{
										break;
									}
									text2 = (reference = reference.Insert(num2, Class16.smethod_0(1649163349)));
									num2 += 80;
								}
								while (num2 < text2.Length);
							}
						}
					}
					num++;
				}
				while (num < array.Length);
			}
			return string.Join(Class16.smethod_0(1648941987), array);
		}
		return text;
	}

	internal static string ToHTML(string text, [MarshalAs(UnmanagedType.U1)] bool bCutLine)
	{
		if (text != null && text.Length >= 5)
		{
			string text2 = RemoveSpecialTextVars(text);
			text = text.Trim();
			text2 = text2.Replace(Class16.smethod_0(1648924428), Class16.smethod_0(1648941987));
			text2 = text2.Replace('\r', '\n');
			if (bCutLine)
			{
				text2 = CutLines(text2);
			}
			text2 = text2.Replace(Class16.smethod_0(1648942211), Class16.smethod_0(1648978947));
			int count = Regex.Matches(text2, Class16.smethod_0(1649131805)).Count;
			text2 = Regex.Replace(text2, Class16.smethod_0(1649131805), Class16.smethod_0(1649163365));
			string text3 = Class16.smethod_0(1648902161);
			string text4 = string.Empty;
			if (0 < count)
			{
				int num = count;
				do
				{
					text4 += text3;
					num--;
				}
				while (num != 0);
			}
			text2 += text4;
			if (text.Contains(Class16.smethod_0(1649163397)))
			{
				bool flag = false;
				int num2 = 0;
				if (0 < text2.Length)
				{
					do
					{
						if (text2.Length - num2 > 5)
						{
							string text5 = Class16.smethod_0(1648935659);
							if (text2.Substring(num2, 1) == text5)
							{
								string pattern = Class16.smethod_0(1649163406);
								if (Regex.IsMatch(text2.Substring(num2, 5), pattern))
								{
									if (flag)
									{
										text2 = text2.Insert(num2, Class16.smethod_0(1648902161));
										num2 += 7;
									}
									int num3 = Convert.ToInt32(text2.Substring(num2 + 2, 3)) / 2 + 100;
									string text6 = Class16.smethod_0(1649163421);
									text2 = text2.Insert(num2, Class16.smethod_0(1649163431) + num3 + text6);
									num2 += 30;
									text2 = text2.Substring(0, num2) + text2.Substring(num2 + 5);
									flag = true;
								}
							}
						}
						num2++;
					}
					while (num2 < text2.Length);
					if (flag)
					{
						text2 += Class16.smethod_0(1648902161);
					}
				}
			}
			text2 = text2.Replace(Class16.smethod_0(1648941987), Class16.smethod_0(1648958369));
			text2 = text2.Replace(Class16.smethod_0(1648935632), Class16.smethod_0(1648958369));
			return text2.Replace(Class16.smethod_0(1648903412), Class16.smethod_0(1648958369));
		}
		return text;
	}

	internal static DialogResult msgbox(object message)
	{
		string caption = Class16.smethod_0(1649141664);
		return DKBox.Show(message.ToString(), caption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
	}

	internal static DialogResult msgbox_err(string message, string title)
	{
		return DKBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
	}

	internal static DialogResult msgbox_err(Form owner, string message)
	{
		return DKBox.Show(owner, message, Class16.smethod_0(1648934892), MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
	}

	internal static string Color2HTML(Color color_0)
	{
		byte b = color_0.B;
		byte g = color_0.G;
		byte r = color_0.R;
		string text = Class16.smethod_0(1648918695);
		string text2 = Class16.smethod_0(1648918695);
		return (Class16.smethod_0(1648929947) + r.ToString(Class16.smethod_0(1648918695)) + g.ToString(text2) + b.ToString(text)).ToLowerInvariant();
	}

	[return: MarshalAs(UnmanagedType.U1)]
	internal static bool IsPointOnPlane(int x1, int x2, int y1, int y2, int int_0, int int_1)
	{
		int num = ((int_0 - x1 > -20 && x2 - int_0 > -20) ? 1 : 0);
		bool flag = (byte)num != 0;
		int num2 = ((int_1 - y1 > -20 && y2 - int_1 > -20) ? 1 : 0);
		int num3 = ((flag && (byte)num2 != 0) ? 1 : 0);
		return (byte)num3 != 0;
	}

	internal static void SetDoubleBuffered(Control control_0, [MarshalAs(UnmanagedType.U1)] bool value)
	{
		string name = Class16.smethod_0(1648901323);
		PropertyInfo property = typeof(Control).GetProperty(name, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.SetProperty);
		if (property != null)
		{
			property.SetValue(control_0, value, null);
		}
	}

	internal static string sVERSION()
	{
		string text = fVERSION().ToString(CultureInfo.InvariantCulture);
		if (text.Length == 1)
		{
			text += Class16.smethod_0(1649163462);
		}
		if (text.Length > 6)
		{
			text = text.Insert(6, Class16.smethod_0(1648928036));
		}
		return text;
	}

	internal static float fVERSION()
	{
		Version version = Assembly.GetExecutingAssembly().GetName().Version;
		float result = version.Major;
		if (version.Minor > 0 || version.Build > 0 || version.Revision > 0)
		{
			string text = version.Minor.ToString();
			string text2 = version.Build.ToString();
			string text3 = ((version.Revision > 0) ? version.Revision.ToString() : string.Empty);
			result = float.Parse(string.Format(Class16.smethod_0(1649163471), version.Major, text, text2, text3), CultureInfo.InvariantCulture);
		}
		return result;
	}

	internal static int GetMaxValueKeyInDict(IDictionary<int, int> dict)
	{
		int num = 0;
		int result = 0;
		foreach (KeyValuePair<int, int> item in dict)
		{
			ValueType valueType = item;
			int value = ((KeyValuePair<int, int>)(object)valueType).Value;
			if (value > num)
			{
				result = ((KeyValuePair<int, int>)(object)valueType).Key;
				num = value;
			}
		}
		return result;
	}

	internal static int GetMaxFrequentValue(List<int> values)
	{
		if (values != null && values.Count >= 1)
		{
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			int num = 0;
			if (0 < values.Count)
			{
				do
				{
					int key = values[num];
					if (!dictionary.ContainsKey(key))
					{
						dictionary.Add(key, 0);
					}
					int value = dictionary[key] + 1;
					dictionary[key] = value;
					num++;
				}
				while (num < values.Count);
			}
			return GetMaxValueKeyInDict(dictionary);
		}
		return 0;
	}

	internal static int CountInList(List<int> list, int value)
	{
		int num = 0;
		int num2 = 0;
		if (0 < list.Count)
		{
			do
			{
				if (list[num2] == value)
				{
					num++;
				}
				num2++;
			}
			while (num2 < list.Count);
		}
		return num;
	}

	internal static string GetPrefix(ref string text, [MarshalAs(UnmanagedType.U1)] bool bCut)
	{
		if (text.Length < 2)
		{
			return string.Empty;
		}
		int num = 0;
		string value = text.Substring(0, 1);
		while (true)
		{
			string[] specialChars = CHARS.SpecialChars;
			if (specialChars == null || specialChars.Length == 0 || !(Array.IndexOf(specialChars, value) > -1))
			{
				break;
			}
			num++;
			if (num == text.Length)
			{
				break;
			}
			value = text.Substring(num, 1);
		}
		string result = text.Substring(0, num);
		if (bCut)
		{
			text = text.Substring(num);
		}
		return result;
	}

	internal static string GetPostfix(ref string text, [MarshalAs(UnmanagedType.U1)] bool bCut)
	{
		if (text.Length < 2)
		{
			return string.Empty;
		}
		int num = text.Length - 1;
		string value = text.Substring(num, 1);
		while (true)
		{
			string[] specialChars = CHARS.SpecialChars;
			if (specialChars == null || specialChars.Length == 0 || !(Array.IndexOf(specialChars, value) > -1))
			{
				break;
			}
			num--;
			if (num == 0)
			{
				break;
			}
			value = text.Substring(num, 1);
		}
		num++;
		int length = text.Length - num;
		string result = text.Substring(num, length);
		if (bCut)
		{
			text = text.Substring(0, num);
		}
		return result;
	}

	internal static Color GetDynamicColorGreen(float value)
	{
		if (value > 1f)
		{
			return Color.Red;
		}
		if (value < 0f)
		{
			return Color.Black;
		}
		if (value < 0.5f)
		{
			float num = (float)(1.0 - (double)value * 2.0);
			int num2 = (int)((double)num * 255.0);
			return Color.FromArgb(num2, 255, num2);
		}
		return Color.FromArgb(0, 255 - (int)((double)(float)(((double)value - 0.5) * 2.0) * 127.0), 0);
	}

	internal static Image BlurImage(Image image)
	{
		Image image2 = new Bitmap(image);
		Graphics graphics = Graphics.FromImage(image2);
		SolidBrush solidBrush = new SolidBrush(Color.FromArgb(150, 200, 0, 0));
		graphics.FillRectangle(solidBrush, 0, 0, image2.Width, image2.Height);
		graphics?.Dispose();
		solidBrush?.Dispose();
		return image2;
	}

	internal static Image DrawProgress(float value, int width, int height)
	{
		height -= 2;
		Image image = new Bitmap(width, height);
		Graphics graphics = Graphics.FromImage(image);
		bool isDarkMode = TDark.IsDarkMode;
		float num = 0f;
		Color color;
		if (value >= 0f)
		{
			if (value > 1f)
			{
				value = 1f;
				num = 1f;
			}
			else if (value <= 1E-06f)
			{
				goto IL_006f;
			}
			color = (isDarkMode ? Color.FromArgb(50, 50, 50) : Color.LightGray);
			goto IL_0086;
		}
		value = 0f;
		num = -1f;
		goto IL_006f;
		IL_006f:
		color = (isDarkMode ? Color.FromArgb(40, 40, 40) : Color.White);
		goto IL_0086;
		IL_0086:
		Color color2 = color;
		if (num == -1f)
		{
			color2 = Color.Black;
		}
		SolidBrush solidBrush = new SolidBrush(color2);
		graphics.FillRectangle(solidBrush, 0, 0, width, height);
		Color color3 = (isDarkMode ? Color.FromArgb(80, 80, 80) : Color.Gray);
		Pen pen = new Pen(color3, 2f);
		graphics.DrawRectangle(pen, 0, 0, width, height);
		if (value > 1E-06f)
		{
			int num2 = (int)((double)(float)width * (double)value - 2.0);
			num2 = ((num2 < 1) ? 1 : num2);
			SolidBrush solidBrush2 = new SolidBrush(GetDynamicColorGreen((float)((double)num + (double)value)));
			graphics.FillRectangle(solidBrush2, 1, 1, num2, height - 2);
			if (value < 1f && value >= 0.01f)
			{
				Pen pen2 = new Pen(Color.Gray, 0.5f);
				graphics.DrawRectangle(pen2, num2, 0, 1, height);
				pen2?.Dispose();
			}
			solidBrush2?.Dispose();
		}
		pen?.Dispose();
		solidBrush?.Dispose();
		graphics?.Dispose();
		return image;
	}

	internal static uint DateTime2Timestamp(DateTime date)
	{
		DateTime value = new DateTime(1970, 1, 1, 0, 0, 0, 0);
		return Convert.ToUInt32(date.Subtract(value).TotalSeconds);
	}

	internal static DateTime Timestamp2DateTime(uint timestamp)
	{
		return new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(timestamp);
	}

	internal static string Period2String(uint time, int Type)
	{
		if (Type == 1 && time > 2147483648u)
		{
			return new DateTime((int)(((time >> 24) & 0x7F) + 2000), (int)((time >> 16) & 0xFF), (int)((time >> 8) & 0xFF), (ushort)time, 0, 0, 0).ToString(Class16.smethod_0(1649006896));
		}
		return string.Empty;
	}

	internal static int FindCloseSymbolIndex(string source, string open_symbol, string close_symbol, int start_index)
	{
		int num = 0;
		int num2 = start_index;
		if (start_index < source.Length)
		{
			do
			{
				if (!(source.Substring(num2, open_symbol.Length) == open_symbol))
				{
					if (source.Substring(num2, close_symbol.Length) == close_symbol)
					{
						if (num == 0)
						{
							return num2;
						}
						num--;
					}
				}
				else
				{
					num++;
				}
				num2++;
			}
			while (num2 < source.Length);
		}
		return source.Length;
	}

	internal static string ImageToBase64(Image image)
	{
		MemoryStream memoryStream = new MemoryStream();
		image.Save(memoryStream, ImageFormat.Png);
		byte[] inArray = memoryStream.ToArray();
		memoryStream.Close();
		return Convert.ToBase64String(inArray);
	}

	internal static string GetGamePrefix(GAMES Game)
	{
		string result = null;
		switch (Game)
		{
		case GAMES.PW:
			result = Class16.smethod_0(1648922898);
			break;
		case GAMES.FW:
			result = Class16.smethod_0(1649071077);
			break;
		case GAMES.JD:
			result = Class16.smethod_0(1648901867);
			break;
		case GAMES.ESO:
			result = Class16.smethod_0(1649190284);
			break;
		case GAMES.Chibi:
			result = Class16.smethod_0(1649163483);
			break;
		case GAMES.SW:
			result = Class16.smethod_0(1649163503);
			break;
		case GAMES.ROG:
			result = Class16.smethod_0(1649048600);
			break;
		case GAMES.TOS:
			result = Class16.smethod_0(1649163504);
			break;
		}
		return result;
	}

	internal static string ToBase64(string input)
	{
		return Convert.ToBase64String(Encoding.UTF8.GetBytes(input));
	}

	internal static Color GetDynamicColor(int level, int max_level, [MarshalAs(UnmanagedType.U1)] bool IsStrict)
	{
		if (level > max_level)
		{
			return Color.Red;
		}
		if (level == max_level)
		{
			return SpecialColors.MonsterMaxLevelColor;
		}
		double num = level;
		double num2 = max_level;
		if (num / num2 > 0.6)
		{
			int num3 = (int)(num2 * 0.6);
			double num4 = (double)(level - num3) / (double)(max_level - num3);
			return Color.FromArgb(255, 255 - (int)(num4 * 115.0), 255 - (int)(num4 * 255.0));
		}
		double num5 = num / (double)(int)(num2 * 0.6);
		return Color.FromArgb(95 - (int)(num5 * -160.0), 130 - (int)(num5 * -125.0), 40 - (int)(num5 * -215.0));
	}

	internal static bool IsFlagExist(int flags, int flag)
	{
		return (flags & flag) == flag;
	}

	internal static bool IsFlagExist(ulong flags, ulong flag)
	{
		return (flags & flag) == flag;
	}

	internal static bool IsFlagExistP(int flags, int flag)
	{
		return (flags & flag) != 0;
	}

	internal static bool IsFlagExistP(ulong flags, ulong flag)
	{
		return (flags & flag) > 0L;
	}

	internal static bool IsFlagExistP(ulong flags, int flag)
	{
		return (flags & (ulong)flag) > 0L;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	internal static bool IsFlagsExists(ulong mask, ulong flags)
	{
		if (mask != 0L)
		{
			List<ulong> list = new List<ulong>();
			int num = 63;
			do
			{
				ulong num2 = (ulong)num;
				ulong num3 = num2;
				ulong num6;
				if (num3 != 0L)
				{
					ulong num4 = 2uL;
					int num5 = 1;
					if (1L < num3)
					{
						do
						{
							num4 *= 2L;
							num5++;
						}
						while ((long)num5 < (long)num3);
					}
					num6 = num4;
				}
				else
				{
					num6 = 1uL;
				}
				if (flags / num6 > 0L)
				{
					ulong num7 = num2;
					ulong item;
					if (num7 == 0L)
					{
						item = 1uL;
					}
					else
					{
						ulong num8 = 2uL;
						int num9 = 1;
						if (1L < num7)
						{
							do
							{
								num8 *= 2L;
								num9++;
							}
							while ((long)num9 < (long)num7);
						}
						item = num8;
					}
					list.Add(item);
					ulong num10 = num2;
					ulong num11;
					if (num10 == 0L)
					{
						num11 = 1uL;
					}
					else
					{
						ulong num12 = 2uL;
						int num13 = 1;
						if (1L < num10)
						{
							do
							{
								num12 *= 2L;
								num13++;
							}
							while ((long)num13 < (long)num10);
						}
						num11 = num12;
					}
					flags %= num11;
				}
				num--;
			}
			while (num >= 0);
			int num14 = 0;
			if (0 < list.Count)
			{
				do
				{
					if (IsFlagExist(mask, list[num14]))
					{
						num14++;
						continue;
					}
					return false;
				}
				while (num14 < list.Count);
				return true;
			}
			return true;
		}
		if (flags == 0L)
		{
			return true;
		}
		return false;
	}

	internal static string GetUniversalSN(string real_sn)
	{
		if (string.IsNullOrWhiteSpace(real_sn))
		{
			return real_sn;
		}
		real_sn = real_sn.Trim();
		string text = real_sn;
		if (real_sn.Contains(Class16.smethod_0(1649163514)))
		{
			text = real_sn.Replace(Class16.smethod_0(1648911145), string.Empty);
			text = text.ToLowerInvariant();
			if (text.Length % 2 == 0 && IsHexString(text))
			{
				List<byte> list = new List<byte>();
				int num = 0;
				if (0 < text.Length)
				{
					do
					{
						byte item = Convert.ToByte(text.Substring(num, 2), 16);
						if (num + 2 + 1 < text.Length)
						{
							byte item2 = Convert.ToByte(text.Substring(num + 2, 2), 16);
							list.Add(item2);
						}
						list.Add(item);
						num += 4;
					}
					while (num < text.Length);
				}
				text = Encoding.UTF8.GetString(list.ToArray());
			}
			else
			{
				text = real_sn;
			}
		}
		if (text.StartsWith(Class16.smethod_0(1648941518)))
		{
			text = text.Substring(1);
		}
		return text.Trim();
	}

	internal static Bitmap MakeGrayscale(Image original)
	{
		Bitmap bitmap = new Bitmap(original.Width, original.Height);
		Graphics graphics = Graphics.FromImage(bitmap);
		ColorMatrix colorMatrix = new ColorMatrix(new float[5][]
		{
			new float[5] { 0.3f, 0.3f, 0.3f, 0f, 0f },
			new float[5] { 0.59f, 0.59f, 0.59f, 0f, 0f },
			new float[5] { 0.11f, 0.11f, 0.11f, 0f, 0f },
			new float[5] { 0f, 0f, 0f, 1f, 0f },
			new float[5] { 0f, 0f, 0f, 0f, 1f }
		});
		ImageAttributes imageAttributes = new ImageAttributes();
		imageAttributes.SetColorMatrix(colorMatrix);
		Rectangle destRect = new Rectangle(0, 0, original.Width, original.Height);
		graphics.DrawImage(original, destRect, 0, 0, original.Width, original.Height, GraphicsUnit.Pixel, imageAttributes);
		graphics?.Dispose();
		return bitmap;
	}

	internal static string GetColorName(Color toCheck)
	{
		string result = null;
		foreach (KnownColor value in Enum.GetValues(typeof(KnownColor)))
		{
			Color color = Color.FromKnownColor(value);
			if (toCheck.ToArgb() == color.ToArgb())
			{
				result = Enum.GetName(typeof(KnownColor), value);
			}
		}
		return result;
	}

	internal static string ToTitleCase(string text)
	{
		return Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(text);
	}

	internal static string GetListFriendlyName(string ListName)
	{
		if (ListName == null)
		{
			return null;
		}
		ListName = Regex.Replace(ListName, Class16.smethod_0(1648960146), string.Empty);
		if (ListName.Contains(Class16.smethod_0(1648942211)))
		{
			return ListName;
		}
		ListName = ListName.Replace('_', ' ');
		ListName = ListName.Replace(Class16.smethod_0(1649163533), string.Empty);
		ListName = ListName.Replace(Class16.smethod_0(1649163548), Class16.smethod_0(1649163565));
		ListName = ListName.ToLowerInvariant();
		ListName = ToTitleCase(ListName);
		ListName = ListName.Replace(Class16.smethod_0(1649163568), Class16.smethod_0(1649007040));
		ListName = ListName.Replace(Class16.smethod_0(1649163578), Class16.smethod_0(1649163596));
		if (ListName.EndsWith(Class16.smethod_0(1649163606)))
		{
			ListName = ListName.Replace(Class16.smethod_0(1649163606), string.Empty);
		}
		if (ListName == Class16.smethod_0(1649163620))
		{
			ListName = Class16.smethod_0(1649007040);
		}
		return ListName;
	}

	internal static void RemoveOrdDuplicates(ref int[] arr)
	{
		int[] array = arr;
		if (array == null)
		{
			return;
		}
		int num = array.Length;
		if (num == 0)
		{
			return;
		}
		List<int> list = new List<int>(num);
		list.Add(arr[0]);
		int num2 = 0;
		int[] array2 = arr;
		int num3 = 0;
		if (array2.Length != 0)
		{
			do
			{
				int num4 = array2[num3];
				if (list[num2] != num4)
				{
					list.Add(num4);
					num2++;
				}
				num3++;
			}
			while (num3 < array2.Length);
		}
		arr = list.ToArray();
	}

	internal static double CalculatePolygonArea(PointF[] polygon)
	{
		double num = 0.0;
		int num2 = 0;
		int num3 = polygon.Length;
		if (0 < num3)
		{
			do
			{
				int num4 = num2 + 1;
				int num5 = num4 % num3;
				double num6 = polygon[num5].Y;
				num = (double)polygon[num2].X * num6 + num;
				double num7 = polygon[num5].X;
				num -= (double)polygon[num2].Y * num7;
				num2 = num4;
				num3 = polygon.Length;
			}
			while (num2 < num3);
		}
		num *= 0.5;
		if (num < 0.0)
		{
			return 0.0 - num;
		}
		return num;
	}

	internal static object GetPropValue(object src, string propName)
	{
		return src.GetType().GetProperty(propName).GetValue(src, null);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	internal static bool IsChinese(string text)
	{
		int num = 0;
		if (0 < text.Length)
		{
			do
			{
				char c = text[num];
				if ((c < '一' || c > '鿿') && (c < 177984 || c > 178207))
				{
					num++;
					continue;
				}
				return true;
			}
			while (num < text.Length);
			return false;
		}
		return false;
	}

	internal static int CompareObjectsValues(object val1, object val2)
	{
		if (val1 == null)
		{
			if (val2 == null)
			{
				return 0;
			}
			return -1;
		}
		if (val2 == null)
		{
			return 1;
		}
		if (val1 == val2)
		{
			return 0;
		}
		Type type = val1.GetType();
		if (type == val2.GetType())
		{
			if (type == typeof(int))
			{
				return ((int)val1).CompareTo((int)val2);
			}
			if (type == typeof(float))
			{
				return ((float)val1).CompareTo((float)val2);
			}
			if (type == typeof(uint))
			{
				return ((uint)val1).CompareTo((uint)val2);
			}
			if (type == typeof(long))
			{
				return ((long)val1).CompareTo((long)val2);
			}
			if (type == typeof(ulong))
			{
				return ((ulong)val1).CompareTo((ulong)val2);
			}
			return StrCmpLogicalW((string)val1, (string)val2);
		}
		return StrCmpLogicalW(val1.ToString(), val2.ToString());
	}

	internal static int[] GetSelectedRows(DataGridView dgv)
	{
		int[] array = null;
		DataGridViewSelectedRowCollection selectedRows = dgv.SelectedRows;
		if (selectedRows.Count > 0)
		{
			array = new int[selectedRows.Count];
			int num = 0;
			if (0 < selectedRows.Count)
			{
				do
				{
					array[num] = selectedRows[num].Index;
					num++;
				}
				while (num < selectedRows.Count);
			}
			Array.Sort(array);
		}
		return array;
	}

	internal static Color GetTitleBorderColor(Color TextColor)
	{
		double num = (double)(int)TextColor.R * 0.3;
		double num2 = (double)(int)TextColor.G * 0.5 + num;
		double num3 = (double)(int)TextColor.B * 0.2 + num2;
		Color result = Color.White;
		if (num3 > 100.0)
		{
			result = Color.Black;
		}
		return result;
	}

	internal static Image GenerateImage(int width, int height, Color color)
	{
		Image image = new Bitmap(width, height);
		Graphics graphics = Graphics.FromImage(image);
		SolidBrush solidBrush = new SolidBrush(color);
		graphics.FillRectangle(solidBrush, 0, 0, width, height);
		graphics?.Dispose();
		solidBrush?.Dispose();
		return image;
	}

	internal static Image GenerateImageWithBorder(int width, int height, Color color)
	{
		Image image = new Bitmap(width, height);
		Graphics graphics = Graphics.FromImage(image);
		SolidBrush solidBrush = new SolidBrush(color);
		Pen pen = new Pen(GetTitleBorderColor(color), 3f);
		graphics.FillRectangle(solidBrush, 0, 0, width, height);
		pen.Alignment = PenAlignment.Inset;
		graphics.DrawRectangle(pen, 0, 0, width, height);
		graphics?.Dispose();
		solidBrush?.Dispose();
		pen?.Dispose();
		return image;
	}

	internal static string ConvertTitleCasedPropToNormalEnglish(string prop)
	{
		string text = prop;
		int num = 1;
		if (1 < prop.Length)
		{
			do
			{
				byte b = ToBytesGBK(text.Substring(num, 1))[0];
				if (b + 191 <= 25)
				{
					text = text.Insert(num, Class16.smethod_0(1648942211));
					num++;
				}
				num++;
			}
			while (num < text.Length);
		}
		text = text.Replace('_', ' ');
		text = text.Replace(Class16.smethod_0(1649043292), Class16.smethod_0(1648942211));
		text = ToTitleCase(text);
		return text.Replace(Class16.smethod_0(1649163638), Class16.smethod_0(1649166677));
	}

	internal static byte[] GenerateMapKey(int min_len, int max_len)
	{
		byte[] array = new byte[RND.GenerateRnd(min_len, max_len)];
		int num = 0;
		if (array.Length != 0)
		{
			do
			{
				byte b = (byte)RND.GenerateRnd(1, 254);
				array[num] = b;
				num++;
			}
			while (num < array.Length);
		}
		return array;
	}

	internal unsafe static byte[] MapDecrypt(byte[] input, byte[] key)
	{
		int num = input.Length;
		int num2 = key.Length;
		IntPtr intPtr = Marshal.AllocHGlobal(num);
		Marshal.Copy(input, 0, intPtr, num);
		IntPtr intPtr2 = Marshal.AllocHGlobal(num2);
		Marshal.Copy(key, 0, intPtr2, num2);
		try
		{
			byte* ptr = default(byte*);
			smethod_1((byte*)(void*)intPtr, &ptr, num, (byte*)(void*)intPtr2, num2);
			byte[] array = new byte[num];
			Marshal.Copy((IntPtr)ptr, array, 0, num);
			Marshal.FreeHGlobal((IntPtr)ptr);
			return array;
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
			Marshal.FreeHGlobal(intPtr2);
		}
	}

	internal unsafe static byte[] MapEncrypt(byte[] input, byte[] key)
	{
		int num = input.Length;
		int num2 = key.Length;
		IntPtr intPtr = Marshal.AllocHGlobal(num);
		Marshal.Copy(input, 0, intPtr, num);
		IntPtr intPtr2 = Marshal.AllocHGlobal(num2);
		Marshal.Copy(key, 0, intPtr2, num2);
		try
		{
			byte* ptr = default(byte*);
			smethod_0((byte*)(void*)intPtr, &ptr, num, (byte*)(void*)intPtr2, num2, 1000);
			byte[] array = new byte[num];
			Marshal.Copy((IntPtr)ptr, array, 0, num);
			Marshal.FreeHGlobal((IntPtr)ptr);
			return array;
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
			Marshal.FreeHGlobal(intPtr2);
		}
	}

	private unsafe static void smethod_0(byte* pByte_0, byte** ppByte_0, int int_0, byte* pByte_1, int int_1, int int_2)
	{
		*ppByte_0 = (byte*)(void*)Marshal.AllocHGlobal(int_0);
		for (int i = 0; i < int_0; i++)
		{
			(*ppByte_0)[i] = (byte)(pByte_0[i] ^ pByte_1[i % int_1] ^ (int_2 & 0xFF));
		}
	}

	private unsafe static void smethod_1(byte* pByte_0, byte** ppByte_0, int int_0, byte* pByte_1, int int_1)
	{
		*ppByte_0 = (byte*)(void*)Marshal.AllocHGlobal(int_0);
		for (int i = 0; i < int_0; i++)
		{
			(*ppByte_0)[i] = (byte)(pByte_0[i] ^ pByte_1[i % int_1] ^ 0xE8);
		}
	}

	internal static ReferenceType[] GetItemRefSections(ItemType item_type)
	{
		ReferenceType[] result = null;
		switch (item_type)
		{
		case ItemType.PW_NPC_ESSENCE:
			result = new ReferenceType[7]
			{
				ReferenceType.TASKS_NPCS,
				ReferenceType.GSHOP_NPCS,
				ReferenceType.GSHOP1_NPCS,
				ReferenceType.GSHOP2_NPCS,
				ReferenceType.GSHOP3_NPCS,
				ReferenceType.NPCGEN_NPCS,
				ReferenceType.NPCGEN_MONSTERS
			};
			break;
		case ItemType.PW_MONSTER_ESSENCE:
			result = new ReferenceType[4]
			{
				ReferenceType.TASKS_MONSTERS,
				ReferenceType.NPCGEN_MONSTERS,
				ReferenceType.NPCGEN_NPCS,
				ReferenceType.EXTRA_DROPS_MONSTERS
			};
			break;
		case ItemType.Matter:
			result = new ReferenceType[6]
			{
				ReferenceType.GSHOP_MATTERS,
				ReferenceType.GSHOP1_MATTERS,
				ReferenceType.GSHOP2_MATTERS,
				ReferenceType.GSHOP3_MATTERS,
				ReferenceType.TASKS_MATTERS,
				ReferenceType.EXTRA_DROPS_MATTERS
			};
			break;
		case ItemType.PW_MINE_ESSENCE:
			result = new ReferenceType[2]
			{
				ReferenceType.TASKS_MINES,
				ReferenceType.NPCGEN_MINES
			};
			break;
		case ItemType.PW_HOME_ITEM_ENTITY:
			result = new ReferenceType[1] { ReferenceType.TASKS_HOME_ITEMS };
			break;
		case ItemType.PW_TITLE_CONFIG:
		case ItemType.PW_COMPLEX_TITLE_CONFIG:
			result = new ReferenceType[1] { ReferenceType.TASKS_TITLES };
			break;
		}
		return result;
	}

	internal static ITEMDATA ITEMDATA()
	{
		return default(ITEMDATA);
	}

	internal static ITEMDATA ITEMDATA(object param)
	{
		return default(ITEMDATA);
	}

	internal unsafe static ITEMDATA ITEMDATA(ITEMDATA* itemPtr)
	{
		return default(ITEMDATA);
	}

	internal static void Sleep(int milliseconds)
	{
		Thread.Sleep(milliseconds);
	}

	internal static void Sleep(uint milliseconds)
	{
		Thread.Sleep((int)milliseconds);
	}

	internal static void ShowHandledException(Exception exception_0, string message)
	{
		SentryHelper.CaptureException(exception_0, Class16.smethod_0(1649163641));
		string key = Class16.smethod_0(1648894248);
		exception_0.Data.Add(key, message);
		DKBox.Show(exception_0.Message, Class16.smethod_0(1648924056), MessageBoxButtons.OK, MessageBoxIcon.Hand);
	}

	internal static void ShowHandledException(Exception exception_0)
	{
		SentryHelper.CaptureException(exception_0, Class16.smethod_0(1649163641));
		DKBox.Show(exception_0.Message, Class16.smethod_0(1648924056), MessageBoxButtons.OK, MessageBoxIcon.Hand);
	}

	internal static double GetSecretNumber_unmanaged(int int_82, int int_83)
	{
		long num = (int_82 * 31L) ^ (int_83 * 37L);
		num = num * 1103515245L + 12345L;
		double num2 = (double)(num % 1000000L) / 1000000.0;
		return num2 * 1000.0;
	}

	internal static bool CheckAll(bool bAccepted, object state)
	{
		return bAccepted;
	}

	internal static int GetElementsSecretNumber(int first_value, int list_index)
	{
		return Convert.ToInt32(Math.Floor(GetSecretNumber_unmanaged(first_value, list_index)));
	}

	internal static int GetTasksSecretNumber(int first_value)
	{
		return Convert.ToInt32(Math.Floor(GetSecretNumber_unmanaged(first_value, 71)));
	}

	internal static bool IsOneBit(ulong value)
	{
		if (value != 0L)
		{
			return (value & (value - 1L)) == 0L;
		}
		return false;
	}

	internal static string sVERSION_c()
	{
		return fVERSION().ToString(CultureInfo.InvariantCulture);
	}

	internal unsafe static char* RegHardwareIDW()
	{
		string text = Environment.MachineName + Class16.smethod_0(1648941518) + Environment.UserName;
		byte[] bytes = Encoding.Unicode.GetBytes(text + Class16.smethod_0(1648938185));
		char* ptr = (char*)(void*)Marshal.AllocHGlobal(bytes.Length);
		Marshal.Copy(bytes, 0, (IntPtr)ptr, bytes.Length);
		return ptr;
	}

	internal static void Static3()
	{
	}

	internal static byte CryptChar(byte byte_0, byte byte_1, int int_82)
	{
		return (byte)(byte_0 ^ byte_1 ^ (int_82 & 0xFF));
	}

	internal unsafe static int CryptHashBuffer(int hashType, sbyte* buffer, int bufferSize, sbyte* hashResult)
	{
		try
		{
			byte[] array = new byte[bufferSize];
			for (int i = 0; i < bufferSize; i++)
			{
				array[i] = (byte)buffer[i];
			}
			using (SHA256 sHA = SHA256.Create())
			{
				byte[] array2 = sHA.ComputeHash(array);
				for (int j = 0; j < Math.Min(array2.Length, 32); j++)
				{
					hashResult[j] = (sbyte)array2[j];
				}
			}
			return 1;
		}
		catch
		{
			return 0;
		}
	}

	internal unsafe static int CryptHashFileW(string filePath, sbyte* hashResult)
	{
		try
		{
			if (!File.Exists(filePath))
			{
				return 0;
			}
			byte[] buffer = File.ReadAllBytes(filePath);
			using (SHA256 sHA = SHA256.Create())
			{
				byte[] array = sHA.ComputeHash(buffer);
				for (int i = 0; i < Math.Min(array.Length, 32); i++)
				{
					hashResult[i] = (sbyte)array[i];
				}
			}
			return 1;
		}
		catch
		{
			return 0;
		}
	}

	[return: MarshalAs(UnmanagedType.U1)]
	internal static bool ContainsFast(ref string str, [MarshalAs(UnmanagedType.U2)] char value)
	{
		int length = str.Length;
		int num = 0;
		if (0 < length)
		{
			do
			{
				if (str[num] != value)
				{
					num++;
					continue;
				}
				return true;
			}
			while (num < length);
			return false;
		}
		return false;
	}

	internal static int[] DeleteZero(int[] arr)
	{
		List<int> list = new List<int>(arr.Length);
		int num = 0;
		if (arr.Length != 0)
		{
			do
			{
				int num2 = arr[num];
				if (num2 > 0)
				{
					list.Add(num2);
				}
				num++;
			}
			while (num < arr.Length);
		}
		return list.ToArray();
	}

	internal static string GetWindowText(IntPtr hWnd)
	{
		int windowTextLength = GetWindowTextLength(hWnd);
		if (windowTextLength > 0)
		{
			int num = windowTextLength + 1;
			StringBuilder stringBuilder = new StringBuilder(num);
			GetWindowText(hWnd, stringBuilder, num);
			return stringBuilder.ToString();
		}
		return string.Empty;
	}

	internal static void ShowWindow(IntPtr hWnd, FormWindowState CurrentState)
	{
		if (CurrentState == FormWindowState.Minimized)
		{
			ShowWindow(hWnd, 9);
		}
		SetWindowPos(hWnd, (IntPtr)(-1), 0, 0, 0, 0, 67u);
		SetWindowPos(hWnd, (IntPtr)(-2), 0, 0, 0, 0, 67u);
		SetForegroundWindow(hWnd);
		SetActiveWindow(hWnd);
		SetFocus(hWnd);
	}

	internal unsafe static IntPtr CreateMap(string MapName, int MapSize, IntPtr* hFile)
	{
		IntPtr hFile2 = new IntPtr(-1);
		IntPtr lpAttributes = new IntPtr(0);
		IntPtr intPtr = CreateFileMapping(hFile2, lpAttributes, 4, 0, MapSize, MapName);
		*hFile = intPtr;
		IntPtr result = IntPtr.Zero;
		if (*hFile != IntPtr.Zero)
		{
			result = MapViewOfFile(*hFile, 983071, 0, 0, MapSize);
		}
		return result;
	}

	internal static void RegisterUsbDeviceNotification(IntPtr windowHandle)
	{
		try
		{
			DevBroadcastDeviceInterface devBroadcastDeviceInterface = new DevBroadcastDeviceInterface();
			devBroadcastDeviceInterface.DeviceType = 5;
			Guid classGuid = new Guid(Class16.smethod_0(1649163685));
			devBroadcastDeviceInterface.ClassGuid = classGuid;
			devBroadcastDeviceInterface.Size = 32;
			IntPtr intPtr = Marshal.AllocHGlobal(32);
			IntPtr intPtr2 = intPtr;
			Marshal.StructureToPtr(devBroadcastDeviceInterface, intPtr2, fDeleteOld: true);
			IntPtr intPtr3 = RegisterDeviceNotificationA(windowHandle, intPtr2, 0u);
			notificationHandle = intPtr3;
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649163720));
			string caption = Class16.smethod_0(1649162756);
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649162771), Class16.smethod_0(1649162818)) + ex.Message, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
	}

	internal static Bitmap LoadImageW(string FileName)
	{
		// TODO(recovered): UI icon assets are loaded as loose files from Application.StartupPath.
		// When an asset is missing from the deployment folder, File.ReadAllBytes throws
		// (UnauthorizedAccessException if the path resolves to a directory, FileNotFoundException
		// otherwise) and crashes startup (MainWindow..ctor / ICONS / eListCollection / TASKS).
		// Degrade to a 1x1 placeholder so a missing decorative icon can't kill the app.
		if (string.IsNullOrEmpty(FileName) || !File.Exists(FileName))
		{
			return new Bitmap(1, 1);
		}
		try
		{
			MemoryStream memoryStream = new MemoryStream(File.ReadAllBytes(FileName));
			Bitmap result = new Bitmap(memoryStream);
			memoryStream.Close();
			return result;
		}
		catch (Exception)
		{
			return new Bitmap(1, 1);
		}
	}

	internal static string GetFileBaseName(string FileName)
	{
		if (string.IsNullOrWhiteSpace(FileName))
		{
			return null;
		}
		int num = FileName.LastIndexOf(Class16.smethod_0(1648927580));
		int num2 = FileName.LastIndexOf(Class16.smethod_0(1648928036));
		if (num2 < 1 || num2 < num)
		{
			num2 = FileName.Length;
		}
		if (num > 0)
		{
			return FileName.Substring(num + 1, num2 - num - 1);
		}
		return FileName.Substring(0, num2);
	}

	internal static void End(string reason, Exception exception_0)
	{
		try
		{
			if (reason != null)
			{
				RLogger.Fatal(exception_0, reason);
			}
			RLogger.CloseAndFlush();
		}
		catch
		{
			Marshal.GetExceptionCode();
			Marshal.GetExceptionPointers();
			uint num = 0u;
			try
			{
				goto end_IL_0011;
			}
			catch
			{
			}
			if (num != 0)
			{
				throw;
			}
			end_IL_0011:;
		}
		try
		{
			Environment.Exit(0);
			Process.GetCurrentProcess().Kill();
		}
		catch
		{
			Marshal.GetExceptionCode();
			Marshal.GetExceptionPointers();
			uint num2 = 0u;
			try
			{
				Process.GetCurrentProcess().Kill();
				return;
			}
			catch
			{
			}
			if (num2 != 0)
			{
				throw;
			}
		}
	}

	internal static void RunAsAdmin(string aFileName, string anArguments)
	{
		Process.Start(new ProcessStartInfo
		{
			FileName = aFileName,
			Arguments = anArguments,
			UseShellExecute = true,
			Verb = Class16.smethod_0(1649162874)
		});
	}

	internal static Process ShellHidden(string FileName, string Arguments)
	{
		Process process = new Process();
		try
		{
			process.StartInfo = new ProcessStartInfo
			{
				WindowStyle = ProcessWindowStyle.Hidden,
				FileName = FileName,
				Arguments = Arguments
			};
			process.Start();
		}
		catch
		{
			Marshal.GetExceptionCode();
			Marshal.GetExceptionPointers();
			uint num = 0u;
			try
			{
				return process;
			}
			catch
			{
			}
			if (num != 0)
			{
				throw;
			}
		}
		return process;
	}

	internal static Process ShellP(string FileName)
	{
		Process result = new Process();
		try
		{
			Process.Start(FileName, string.Empty);
		}
		catch
		{
			Marshal.GetExceptionCode();
			Marshal.GetExceptionPointers();
			uint num = 0u;
			try
			{
				return result;
			}
			catch
			{
			}
			if (num != 0)
			{
				throw;
			}
		}
		return result;
	}

	internal static Process ShellP(string FileName, string Arguments, [MarshalAs(UnmanagedType.U1)] bool waitForExit)
	{
		Process process = null;
		try
		{
			process = Process.Start(FileName, Arguments);
			if (waitForExit && !process.HasExited)
			{
				process.WaitForExit(60000);
			}
		}
		catch
		{
			Marshal.GetExceptionCode();
			Marshal.GetExceptionPointers();
			uint num = 0u;
			try
			{
				return null;
			}
			catch
			{
			}
			if (num != 0)
			{
				throw;
			}
		}
		return process;
	}

	internal static void OpenWith(string ProgramPath, string FilePath, string ExtraParams)
	{
		new Process();
		if (!File.Exists(ProgramPath))
		{
			return;
		}
		try
		{
			Process.Start(ProgramPath, Class16.smethod_0(1648904453) + FilePath + Class16.smethod_0(1649127950) + ExtraParams);
		}
		catch
		{
			Marshal.GetExceptionCode();
			Marshal.GetExceptionPointers();
			uint num = 0u;
			try
			{
				return;
			}
			catch
			{
			}
			if (num != 0)
			{
				throw;
			}
		}
	}

	internal static Cursor LoadCursorFromAniFile(string CursorFN)
	{
		IntPtr hglobal = Marshal.StringToHGlobalUni(CursorFN);
		IntPtr intPtr = LoadCursorFromFileW(CursorFN);
		Marshal.FreeHGlobal(hglobal);
		IntPtr intPtr2 = (IntPtr)0;
		if (intPtr != intPtr2)
		{
			return new Cursor(intPtr);
		}
		// TODO(recovered): the custom cursor asset may be missing from the deployment folder.
		// Falling through to new Cursor(CursorFN) on a missing file (or a path that resolves to
		// a directory) throws UnauthorizedAccessException/FileNotFoundException and kills startup
		// (CommonStorage..ctor -> LoadPWCursor), so degrade gracefully to the default cursor.
		if (string.IsNullOrEmpty(CursorFN) || !File.Exists(CursorFN))
		{
			return Cursors.Default;
		}
		try
		{
			return new Cursor(CursorFN);
		}
		catch (Exception)
		{
			return Cursors.Default;
		}
	}

	internal static Cursor LoadPWCursor()
	{
		if (CommonStorage.Params != null && !CommonStorage.Params.EnableCustomCursors)
		{
			return Cursors.Default;
		}
		string text = Class16.smethod_0(1649162894);
		return LoadCursorFromAniFile(Application.StartupPath + text);
	}

	internal static Cursor LoadFWCursor()
	{
		if (CommonStorage.Params != null && !CommonStorage.Params.EnableCustomCursors)
		{
			return Cursors.Default;
		}
		string text = Class16.smethod_0(1649162924);
		return LoadCursorFromAniFile(Application.StartupPath + text);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	internal static bool IsControlPressed()
	{
		return GetAsyncKeyState(17) >>> 15 != 0;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	internal static bool IsCtrlPressed()
	{
		return GetAsyncKeyState(17) >>> 15 != 0;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	internal static bool IsShiftPressed()
	{
		return GetAsyncKeyState(16) >>> 15 != 0;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	internal static bool IsAltPressed()
	{
		return GetAsyncKeyState(18) >>> 15 != 0;
	}

	internal static string GetFileDir(string FileName)
	{
		if (string.IsNullOrWhiteSpace(FileName))
		{
			return null;
		}
		int num = FileName.LastIndexOf(Class16.smethod_0(1648927580));
		return FileName.Substring(0, num + 1);
	}

	internal static void ShowWindow(Form window)
	{
		IntPtr handle = window.Handle;
		window.Show();
		window.Activate();
		ShowWindow(handle, window.WindowState);
		window.Focus();
	}

	internal static IntPtr GetObjectPointer(object obj)
	{
		ValueType valueType = GCHandle.Alloc(obj, GCHandleType.Pinned);
		IntPtr result = ((GCHandle)(object)valueType).AddrOfPinnedObject();
		if (((GCHandle)(object)valueType).IsAllocated)
		{
			((GCHandle)(object)valueType).Free();
		}
		return result;
	}

	internal static IntPtr calloc(uint num, uint size)
	{
		return calloc(new UIntPtr(num), new UIntPtr(size));
	}

	[return: MarshalAs(UnmanagedType.U1)]
	internal static bool DeleteIfExists(string fn)
	{
		bool result = true;
		try
		{
			if (File.Exists(fn))
			{
				File.Delete(fn);
			}
		}
		catch
		{
			Marshal.GetExceptionCode();
			Marshal.GetExceptionPointers();
			uint num = 0u;
			try
			{
				return false;
			}
			catch
			{
			}
			if (num != 0)
			{
				throw;
			}
		}
		return result;
	}

	internal static void ThrowExceptionG(string Message)
	{
		throw new ApplicationException(Message);
	}

	internal static void ShowOpenFileDialog(ref TextBox dest, string FileTitle, string Filter)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Filter = Filter;
		openFileDialog.FileName = FileTitle;
		if (openFileDialog.ShowDialog() == DialogResult.OK && File.Exists(openFileDialog.FileName))
		{
			dest.Text = openFileDialog.FileName;
		}
	}

	internal static string ShowOpenFileDialog(string FileTitle, string Filter)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Filter = Filter;
		openFileDialog.FileName = FileTitle;
		if (openFileDialog.ShowDialog() == DialogResult.OK && File.Exists(openFileDialog.FileName))
		{
			return openFileDialog.FileName;
		}
		return null;
	}

	internal static string GetPathRoot(string FileName)
	{
		int num = FileName.IndexOf(Class16.smethod_0(1648927580));
		if (num > -1)
		{
			return FileName.Substring(0, num);
		}
		return null;
	}

	internal static long GetFileSize(string FileName)
	{
		long result = -1L;
		if (File.Exists(FileName))
		{
			result = new FileInfo(FileName).Length;
		}
		return result;
	}

	internal static void OpenInNotepad(string fn, List<string> lines)
	{
		if (lines != null && lines.Count != 0)
		{
			File.WriteAllLines(fn, lines, Encoding.UTF8);
			if (File.Exists(fn))
			{
				string text = Class16.smethod_0(1648904453);
				string arguments = text + fn + text;
				ShellP(Class16.smethod_0(1648971820), arguments, waitForExit: false);
			}
		}
	}

	internal static void OpenInNotepad(List<string> lines)
	{
		string text = Class16.smethod_0(1649162946);
		OpenInNotepad(System.IO.Path.GetTempPath() + text, lines);
	}

	internal static void OpenInNotepad(string string_0)
	{
		string text = Class16.smethod_0(1649162946);
		string text2 = System.IO.Path.GetTempPath() + text;
		File.WriteAllText(text2, string_0, Encoding.UTF8);
		if (File.Exists(text2))
		{
			string text3 = Class16.smethod_0(1648904453);
			string arguments = text3 + text2 + text3;
			ShellP(Class16.smethod_0(1648971820), arguments, waitForExit: false);
		}
	}

	internal static void OpenFileLocation(string fn)
	{
		string arguments = Class16.smethod_0(1649170437) + fn;
		ShellP(Class16.smethod_0(1649049928), arguments, waitForExit: false);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	internal static bool IsValidPath(string path)
	{
		int num = ((!string.IsNullOrWhiteSpace(path) && path.IndexOfAny(System.IO.Path.GetInvalidPathChars()) == -1) ? 1 : 0);
		return (byte)num != 0;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	internal static bool IsFileExist(string FileName, [MarshalAs(UnmanagedType.U1)] bool bCheckFileEmptyTrue)
	{
		int num = ((IsValidPath(FileName) && File.Exists(FileName) && new FileInfo(FileName).Length > 0L) ? 1 : 0);
		return (byte)num != 0;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	internal static bool IsFileExist(string FileName)
	{
		int num = ((IsValidPath(FileName) && File.Exists(FileName)) ? 1 : 0);
		return (byte)num != 0;
	}

	internal unsafe static bool GetCursorPos(tagPOINT* lpPoint)
	{
		if (lpPoint == null)
		{
			return false;
		}
		bool cursorPos_;
		if (cursorPos_ = GetCursorPos_1(out var struct111_))
		{
			// TODO(recovered): ILSpy decompiled `lpPoint->field` as an invalid (tagPOINT) pointer cast.
			lpPoint->x = struct111_.int_0;
			lpPoint->y = struct111_.int_1;
		}
		return cursorPos_;
	}

	internal static bool GetCursorPos(out Point lpPoint)
	{
		Struct111 struct111_;
		bool cursorPos_ = GetCursorPos_1(out struct111_);
		lpPoint = new Point(struct111_.int_0, struct111_.int_1);
		return cursorPos_;
	}

	internal static string GetRelativePath(string Path)
	{
		string result = Path;
		if (Path.StartsWith(Application.StartupPath))
		{
			result = Path.Substring(Application.StartupPath.Length + 1);
		}
		return result;
	}
}
