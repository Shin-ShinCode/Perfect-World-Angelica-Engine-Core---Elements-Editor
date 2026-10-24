using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Elements.eList;
using ACE.License;
using ACE.Models;
using ACE.RSGlobal;
using Sentry;

namespace ACE.ActionHistory;

[Serializable]
public class ACTION_HISTORY
{
	private static class Class46
	{
		public static ParameterizedThreadStart parameterizedThreadStart_0;
	}

	public readonly int ClassVersion = 1;

	[NonSerialized]
	public bool antirecurse;

	[NonSerialized]
	public ITEM_EXT_COLOR Colors;

	[NonSerialized]
	public int ConversationListIndex;

	public uint Count;

	[NonSerialized]
	public CommonStorage CStorage;

	public int CurrentStageIndex;

	[NonSerialized]
	public ITEM_EXT_DESC Descriptions;

	public string ElementsFileName;

	[NonSerialized]
	public string FileName;

	[NonSerialized]
	public List<string> FileNames;

	public List<HISTORYSTAGE> History;

	[NonSerialized]
	public bool IsStageComplete;

	[NonSerialized]
	public bool IsSubStagesComplete = true;

	public uint LastStageID;

	[NonSerialized]
	public eList[] Lists;

	public int PrevStageIndex;

	public int SavedStage = -1;

	[NonSerialized]
	public Thread SaveHistoryThread;

	[NonSerialized]
	public HISTORYSTAGE Stage;

	[NonSerialized]
	public string UniqueID;

	[NonSerialized]
	public int UserIndex;

	public List<string> Users;

	private static readonly object object_0 = new object();

	public HISTORYSTAGE this[int index]
	{
		get
		{
			if (History != null && index >= 0 && index < History.Count)
			{
				HISTORYSTAGE result = History[index];
				GC.KeepAlive(this);
				return result;
			}
			return null;
		}
	}

	public ACTION_HISTORY()
	{
		CurrentStageIndex = -1;
		PrevStageIndex = -1;
		SavedStage = -1;
		History = new List<HISTORYSTAGE>(1024);
		(Users = new List<string>()).Add(CommonStorage.License.UserName);
		UserIndex = 0;
	}

	public static string GetItemsNames(eList eList_0, int[] itemsindices)
	{
		string result = string.Empty;
		if (itemsindices != null)
		{
			int num = itemsindices.Length;
			if (itemsindices[0] < eList_0.ItemCount)
			{
				int num2 = itemsindices[num - 1];
				if (num2 < eList_0.ItemCount)
				{
					switch (num)
					{
					default:
					{
						string text2 = Class16.smethod_0(1648928044);
						int int_3 = itemsindices[0];
						result = string.Concat(eList_0.GetParsedItemName(int_3) + text2, eList_0.GetParsedItemName(num2));
						break;
					}
					case 2:
					{
						int int_ = itemsindices[1];
						string text = Class16.smethod_0(1648942920);
						int int_2 = itemsindices[0];
						result = string.Concat(eList_0.GetParsedItemName(int_2) + text, eList_0.GetParsedItemName(int_));
						break;
					}
					case 1:
						result = eList_0.GetParsedItemName(itemsindices[0]);
						break;
					}
				}
			}
		}
		return result;
	}

	public static ACTION_HISTORY LoadHistory(CommonStorage commonStorage_0, ref eList[] eList_0, int ConversationListIndex, ITEM_EXT_DESC item_EXT_DESC_0, ITEM_EXT_COLOR Colors, string UniqueID, string ElementsFileName, int RealTimeStamp, ref bool IsElementsUnsaved)
	{
		ACTION_HISTORY aCTION_HISTORY = null;
		string text = Class16.smethod_0(1648928048);
		string text2 = Class16.smethod_0(1648928069);
		string text3 = string.Concat(string.Concat(Application.StartupPath + text2, UniqueID), text);
		if (LICENSE_INFO.Info.LicenseType >= LICENSE_TYPE.STANDART && CommonStorage.Params.SaveActionsHistory && File.Exists(text3))
		{
			try
			{
				using FileStream fileStream = smethod_0(text3);
				if (fileStream.Length > 0L)
				{
					aCTION_HISTORY = new BinaryFormatter().Deserialize(fileStream) as ACTION_HISTORY;
					int currentStageIndex = aCTION_HISTORY.CurrentStageIndex;
					byte b = ((aCTION_HISTORY.GetSavedStageIndex((uint)RealTimeStamp) == currentStageIndex) ? ((byte)1) : ((byte)0));
					int num = ((b == 0) ? 1 : 0);
					IsElementsUnsaved = (byte)num != 0;
					ACTION_HISTORY aCTION_HISTORY2 = aCTION_HISTORY;
					aCTION_HISTORY2.CurrentStageIndex = aCTION_HISTORY2.SavedStage;
					if (aCTION_HISTORY.CurrentStageIndex >= aCTION_HISTORY.History.Count)
					{
						ACTION_HISTORY aCTION_HISTORY3 = aCTION_HISTORY;
						aCTION_HISTORY3.CurrentStageIndex = aCTION_HISTORY3.History.Count - 1;
					}
					int currentStageIndex2 = aCTION_HISTORY.CurrentStageIndex;
					if (currentStageIndex2 > -1)
					{
						ACTION_HISTORY aCTION_HISTORY4 = aCTION_HISTORY;
						aCTION_HISTORY4.Stage = aCTION_HISTORY4[currentStageIndex2];
					}
					aCTION_HISTORY.PrevStageIndex = -2;
					if (!aCTION_HISTORY.Users.Contains(CommonStorage.License.UserName))
					{
						aCTION_HISTORY.Users.Add(CommonStorage.License.UserName);
					}
					ACTION_HISTORY aCTION_HISTORY5 = aCTION_HISTORY;
					aCTION_HISTORY5.UserIndex = aCTION_HISTORY5.Users.IndexOf(CommonStorage.License.UserName);
				}
			}
			catch (IOException ioexception_) when (smethod_2(ioexception_))
			{
				SentryHelper.CaptureMessage(Class16.smethod_0(1648928083) + text3 + Class16.smethod_0(1648928156), (SentryLevel)2, Class16.smethod_0(1648928165));
			}
			catch (Exception ex)
			{
				SentryHelper.CaptureException(ex, Class16.smethod_0(1648928205));
				object[] vars = new object[2] { ex.Message, text3 };
				TextStorage.TEXTS.ShowMessage(500, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, vars);
			}
		}
		if (aCTION_HISTORY == null || aCTION_HISTORY.History == null)
		{
			aCTION_HISTORY = new ACTION_HISTORY();
		}
		aCTION_HISTORY.IsStageComplete = true;
		aCTION_HISTORY.FileName = text3;
		aCTION_HISTORY.UniqueID = UniqueID;
		aCTION_HISTORY.CStorage = commonStorage_0;
		aCTION_HISTORY.Lists = eList_0;
		aCTION_HISTORY.ConversationListIndex = ConversationListIndex;
		aCTION_HISTORY.Descriptions = item_EXT_DESC_0;
		aCTION_HISTORY.Colors = Colors;
		aCTION_HISTORY.ElementsFileName = ElementsFileName;
		return aCTION_HISTORY;
	}

	private static FileStream smethod_0(string string_0)
	{
		return new FileStream(string_0, FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete);
	}

	private static byte[] smethod_1(string string_0)
	{
		using FileStream fileStream = smethod_0(string_0);
		if (fileStream.Length <= 0L)
		{
			return Array.Empty<byte>();
		}
		if (fileStream.Length > 2147483647L)
		{
			throw new IOException(Class16.smethod_0(1648928238) + string_0 + Class16.smethod_0(1648928243));
		}
		byte[] array = new byte[fileStream.Length];
		int i;
		int num;
		for (i = 0; i < array.Length; i += num)
		{
			num = fileStream.Read(array, i, array.Length - i);
			if (num <= 0)
			{
				break;
			}
		}
		if (i == array.Length)
		{
			return array;
		}
		Array.Resize(ref array, i);
		return array;
	}

	private static bool smethod_2(IOException ioexception_0)
	{
		int num = ioexception_0.HResult & 0xFFFF;
		if (num != 32)
		{
			return num == 33;
		}
		return true;
	}

	public HISTORYSTAGE ApplyStage(int StageIndex, [MarshalAs(UnmanagedType.U1)] bool IsRedo)
	{
		HISTORYSTAGE hISTORYSTAGE = History[StageIndex];
		if (IsRedo)
		{
			RedoStage(hISTORYSTAGE);
		}
		else
		{
			UndoStage(hISTORYSTAGE);
		}
		return hISTORYSTAGE;
	}

	public HISTORYSTAGE ApplySubstage(int StageIndex, int SubstageIndex, [MarshalAs(UnmanagedType.U1)] bool IsRedo)
	{
		if (StageIndex >= 0 && StageIndex < History.Count)
		{
			List<HISTORYSTAGE> substages = GetSubstages(StageIndex);
			if (substages != null && SubstageIndex >= 0 && SubstageIndex < substages.Count)
			{
				HISTORYSTAGE hISTORYSTAGE = substages[SubstageIndex];
				if (IsRedo)
				{
					RedoStage(hISTORYSTAGE);
				}
				else
				{
					UndoStage(hISTORYSTAGE);
				}
				return hISTORYSTAGE;
			}
			return null;
		}
		return null;
	}

	public void CancelLastStage([MarshalAs(UnmanagedType.U1)] bool cancelSuperStage)
	{
		List<HISTORYSTAGE> history = History;
		if (history == null)
		{
			return;
		}
		if (Stage != null && history.Count != 0)
		{
			if (CurrentStageIndex < 0 || CurrentStageIndex >= history.Count)
			{
				CurrentStageIndex = history.Count - 1;
			}
			if (CurrentStageIndex >= 0 && CurrentStageIndex < history.Count)
			{
				HISTORYSTAGE hISTORYSTAGE = History[CurrentStageIndex];
				if (hISTORYSTAGE == null)
				{
					History.RemoveAt(CurrentStageIndex);
					CurrentStageIndex = History.Count - 1;
					Stage = ((CurrentStageIndex >= 0) ? History[CurrentStageIndex] : null);
					IsStageComplete = true;
					IsSubStagesComplete = true;
					SaveHistory(bAsync: true);
					return;
				}
				bool flag2;
				bool flag = (flag2 = hISTORYSTAGE.action == (AH_ACTIONS)8);
				List<HISTORYSTAGE> subStages = hISTORYSTAGE.SubStages;
				if (flag2 && subStages != null && subStages.Count > 0 && !cancelSuperStage)
				{
					HISTORYSTAGE stage = Stage;
					subStages.Remove(stage);
					Stage = hISTORYSTAGE;
					IsStageComplete = true;
					return;
				}
				History.RemoveAt(CurrentStageIndex);
				int num = --CurrentStageIndex;
				if (num > -1)
				{
					Stage = History[num];
				}
				else
				{
					Stage = null;
				}
				IsStageComplete = true;
				if (flag)
				{
					IsSubStagesComplete = true;
				}
				SaveHistory(bAsync: true);
			}
			else
			{
				Stage = null;
				IsStageComplete = true;
				IsSubStagesComplete = true;
			}
		}
		else
		{
			GC.KeepAlive(this);
		}
	}

	public void CancelLastStage()
	{
		CancelLastStage(cancelSuperStage: false);
	}

	public void DeleteStage(int stageIndex)
	{
		List<HISTORYSTAGE> history = History;
		if (history != null && stageIndex >= 0 && stageIndex < history.Count)
		{
			History.RemoveAt(stageIndex);
			if (CurrentStageIndex >= history.Count)
			{
				CurrentStageIndex = history.Count - 1;
			}
			else if (CurrentStageIndex >= stageIndex)
			{
				CurrentStageIndex--;
			}
			if (CurrentStageIndex >= 0 && CurrentStageIndex < history.Count)
			{
				Stage = History[CurrentStageIndex];
			}
			else
			{
				Stage = null;
				CurrentStageIndex = -1;
			}
			IsStageComplete = true;
			SaveHistory(bAsync: true);
			GC.KeepAlive(this);
		}
	}

	public void ClearHistory()
	{
		List<HISTORYSTAGE> history = History;
		if (history != null)
		{
			History.Clear();
			CurrentStageIndex = -1;
			PrevStageIndex = -1;
			SavedStage = -1;
			Stage = null;
			IsStageComplete = true;
			SaveHistory(bAsync: true);
			GC.KeepAlive(this);
		}
	}

	public void CheckAndSetItemsIdsHash(ref HISTORYSTAGE Stage)
	{
		HISTORYSTAGE hISTORYSTAGE = Stage;
		if (hISTORYSTAGE.itemsindices != null && hISTORYSTAGE.Items.ListAndIdHashes == null)
		{
			ref HashSet<LISTandID> listAndIdHashes = ref Stage.Items.ListAndIdHashes;
			listAndIdHashes = new HashSet<LISTandID>();
			ref HashSet<LISTandID> listAndIdHashes2 = ref Stage.Items.ListAndIdHashes;
			ref int int_ = ref Stage.int_0;
			int count = Lists[int_].IDs.Count;
			int[] itemsindices = Stage.itemsindices;
			int num = 0;
			if (0 < (nint)itemsindices.LongLength)
			{
				LISTandID item = default(LISTandID);
				do
				{
					int num2 = itemsindices[num];
					if (num2 < count)
					{
						int num3 = Lists[int_].getid(num2);
						item.Int32_0 = int_;
						num3 = ((num3 > 1000000) ? 100000 : num3);
						item.id = num3;
						if (!listAndIdHashes2.Contains(item))
						{
							listAndIdHashes2.Add(item);
						}
					}
					num++;
				}
				while (num < (nint)itemsindices.LongLength);
			}
		}
		GC.KeepAlive(this);
	}

	public void Complete()
	{
		if (IsStageComplete)
		{
			return;
		}
		HISTORYSTAGE stage = Stage;
		int int_ = stage.int_0;
		if (stage.action != (AH_ACTIONS)4)
		{
			CheckAndSetItemsIdsHash(ref Stage);
		}
		HISTORYSTAGE stage2 = Stage;
		switch (stage2.action)
		{
		case AH_ACTIONS.Add:
		{
			ref int[] itemsindices = ref stage2.itemsindices;
			ref int[] fieldsindices = ref stage2.fieldsindices;
			stage2.values_new = new object[(nint)itemsindices.LongLength][];
			int num4 = 0;
			if (0 >= (nint)itemsindices.LongLength)
			{
				break;
			}
			int num5 = fieldsindices.Length;
			do
			{
				Stage.values_new[num4] = new object[num5];
				int num6 = itemsindices[num4];
				int num7 = 0;
				int[] array = fieldsindices;
				num5 = array.Length;
				if (0 < num5)
				{
					do
					{
						Stage.values_new[num4][num7] = Lists[int_].elementValues[num6][array[num7]];
						num7++;
						array = fieldsindices;
						num5 = array.Length;
					}
					while (num7 < num5);
				}
				num4++;
			}
			while (num4 < (nint)itemsindices.LongLength);
			break;
		}
		case AH_ACTIONS.Update:
		{
			Lists[int_].bItemsOrderingChanged = true;
			HISTORYSTAGE stage3 = Stage;
			ref int[] itemsindices2 = ref stage3.itemsindices;
			stage3.values_new = new object[(nint)itemsindices2.LongLength][];
			int num8 = 0;
			int[] array2 = itemsindices2;
			if (0 < (nint)array2.LongLength)
			{
				do
				{
					int num9 = array2[num8];
					Stage.values_new[num8] = new object[(nint)Lists[int_].elementValues[num9].LongLength];
					Lists[int_].elementValues[num9].CopyTo(Stage.values_new[num8], 0);
					num8++;
					array2 = itemsindices2;
				}
				while (num8 < (nint)array2.LongLength);
			}
			break;
		}
		case (AH_ACTIONS)4:
			Lists[int_].bItemsOrderingChanged = true;
			break;
		case (AH_ACTIONS)5:
			if (!SaveStageLists(stage2.GetStageRedoFileName()))
			{
				CancelLastStage(cancelSuperStage: false);
			}
			break;
		case (AH_ACTIONS)6:
			Stage.color_new = Colors.Get(stage2.IDs[0]);
			break;
		case (AH_ACTIONS)7:
		{
			stage2.descriptions_new = new string[(nint)stage2.IDs.LongLength];
			int num3 = 0;
			if (0 < (nint)Stage.IDs.LongLength)
			{
				do
				{
					Stage.descriptions_new[num3] = Descriptions.GetClean(Stage.IDs[num3]);
					num3++;
				}
				while (num3 < (nint)Stage.IDs.LongLength);
			}
			break;
		}
		case AH_ACTIONS.Remove:
		case (AH_ACTIONS)9:
		{
			ITEMS_COLLECTION items = stage2.Items;
			int count = items.Count;
			Stage.values_new = new object[count][];
			int num = 0;
			if (0 < items.Count)
			{
				do
				{
					vITEMPOS vITEMPOS2 = items.ItemsList[num];
					int int32_ = vITEMPOS2.Int32_0;
					int int32_2 = vITEMPOS2.Int32_1;
					Stage.values_new[num] = ACE.RSGlobal.RSGlobal.CloneArray(Lists[int32_2].elementValues[int32_]);
					num++;
				}
				while (num < items.Count);
			}
			if (items.bChangeDesc && Descriptions.FileLoaded)
			{
				int count2 = items.Count;
				Stage.descriptions_new = new string[count2];
				int num2 = 0;
				HashSet<LISTandID>.Enumerator enumerator = items.ListAndIdHashes.GetEnumerator();
				if (enumerator.MoveNext())
				{
					do
					{
						LISTandID current = enumerator.Current;
						if (Lists[current.Int32_0].bMatters)
						{
							string clean = Descriptions.GetClean(current.id);
							Stage.descriptions_new[num2] = clean;
						}
						num2++;
					}
					while (enumerator.MoveNext());
				}
			}
			if (Stage.IsMoveItems)
			{
				Lists[int_].bItemsOrderingChanged = true;
			}
			break;
		}
		}
		IsStageComplete = true;
		HISTORYSTAGE stage4 = Stage;
		if (stage4 != null)
		{
			if (!stage4.IsSubStage)
			{
				SaveHistory(bAsync: true);
			}
			if (History[CurrentStageIndex].action == (AH_ACTIONS)8)
			{
				Stage = History[CurrentStageIndex];
			}
		}
		GC.KeepAlive(this);
	}

	public void ElementsSaved(string BackupFileName, uint TimeStamp, [MarshalAs(UnmanagedType.U1)] bool bSaveAsync)
	{
		SavedStage = CurrentStageIndex;
		HISTORYSTAGE stage = Stage;
		if (stage != null)
		{
			stage.BackupFileName = BackupFileName;
			if (Stage.SavedTimeStamps == null)
			{
				Stage.SavedTimeStamps = new HashSet<uint>();
			}
			Stage.SavedTimeStamps.Add(TimeStamp);
		}
		SaveHistory(bSaveAsync);
	}

	public string GetCaption(int StageIndex, int SubStageIndex, [MarshalAs(UnmanagedType.U1)] bool bSetDate)
	{
		string text;
		HISTORYSTAGE hISTORYSTAGE;
		if (StageIndex < History.Count && StageIndex >= 0)
		{
			text = string.Empty;
			hISTORYSTAGE = ((SubStageIndex <= -1) ? History[StageIndex] : History[StageIndex].SubStages[SubStageIndex]);
			string customCaption = hISTORYSTAGE.CustomCaption;
			if (customCaption != null)
			{
				text = customCaption;
			}
			else
			{
				string cachedCaption = hISTORYSTAGE.CachedCaption;
				if (cachedCaption != null && hISTORYSTAGE.CaptionLang == CommonStorage.Texts.LangIndex)
				{
					text = cachedCaption;
				}
				else
				{
					int captionIndex = hISTORYSTAGE.CaptionIndex;
					if (captionIndex > 0)
					{
						object[] captionVars = hISTORYSTAGE.CaptionVars;
						if (captionVars != null || hISTORYSTAGE.action == (AH_ACTIONS)8)
						{
							object[] vars = captionVars;
							if (captionIndex == 856)
							{
								vars = new object[2]
								{
									captionVars[0],
									GetItemsNames(Lists[hISTORYSTAGE.int_0], hISTORYSTAGE.itemsindices)
								};
							}
							int captionIndex2 = hISTORYSTAGE.CaptionIndex;
							text = TextStorage.TEXTS.GetText(TextStorage.TEXTS.ResolveLegacyMessageKey(captionIndex2, 0), vars);
							goto IL_0416;
						}
					}
					ref eList reference = ref Lists[hISTORYSTAGE.int_0];
					string text2 = null;
					AH_ACTIONS action = hISTORYSTAGE.action;
					if (action != (AH_ACTIONS)7 && action != (AH_ACTIONS)6)
					{
						text2 = GetItemsNames(hISTORYSTAGE.Items);
					}
					string text3 = null;
					int[] iDs = hISTORYSTAGE.IDs;
					if (iDs != null)
					{
						switch (iDs.Length)
						{
						default:
						{
							int num4 = iDs[(nint)iDs.LongLength - 1];
							int num5 = iDs[0];
							string text5 = Class16.smethod_0(1648928044);
							text3 = string.Concat(num5 + text5, num4.ToString());
							break;
						}
						case 2:
						{
							int num2 = iDs[1];
							int num3 = iDs[0];
							string text4 = Class16.smethod_0(1648942920);
							text3 = string.Concat(num3 + text4, num2.ToString());
							break;
						}
						case 1:
						{
							int num = iDs[0];
							text3 = num.ToString();
							break;
						}
						}
					}
					switch (hISTORYSTAGE.action)
					{
					case AH_ACTIONS.Add:
					{
						int[] fieldsindices = hISTORYSTAGE.fieldsindices;
						int num6 = fieldsindices.Length;
						string text6;
						switch (num6)
						{
						default:
						{
							int int_4 = fieldsindices[num6 - 1];
							eList eList5 = reference;
							bool bTranslationExist4 = false;
							string fieldName2 = eList5.GetFieldName(int_4, ref bTranslationExist4);
							int int_5 = fieldsindices[0];
							eList eList6 = reference;
							bool bTranslationExist5 = false;
							text6 = string.Concat(eList6.GetFieldName(int_5, ref bTranslationExist5) + Class16.smethod_0(1648928044), fieldName2);
							break;
						}
						case 2:
						{
							int int_2 = fieldsindices[1];
							eList eList3 = reference;
							bool bTranslationExist2 = false;
							string fieldName = eList3.GetFieldName(int_2, ref bTranslationExist2);
							int int_3 = fieldsindices[0];
							eList eList4 = reference;
							bool bTranslationExist3 = false;
							text6 = string.Concat(eList4.GetFieldName(int_3, ref bTranslationExist3) + Class16.smethod_0(1648942920), fieldName);
							break;
						}
						case 1:
						{
							int int_ = fieldsindices[0];
							eList eList2 = reference;
							bool bTranslationExist = false;
							text6 = eList2.GetFieldName(int_, ref bTranslationExist);
							break;
						}
						}
						int captionIndex3 = hISTORYSTAGE.CaptionIndex;
						captionIndex3 = ((captionIndex3 <= 0) ? 136 : captionIndex3);
						object[] vars5 = new object[2] { text2, text6 };
						text = TextStorage.TEXTS.GetText(TextStorage.TEXTS.ResolveLegacyMessageKey(captionIndex3, 0), vars5);
						break;
					}
					case AH_ACTIONS.Update:
					{
						object[] vars4 = new object[1] { text2 };
						text = TextStorage.TEXTS.GetText(Class16.smethod_0(1648927266), vars4);
						break;
					}
					case (AH_ACTIONS)4:
					{
						object[] vars8 = new object[1] { text2 };
						text = TextStorage.TEXTS.GetText(Class16.smethod_0(1648927289), vars8);
						break;
					}
					case (AH_ACTIONS)6:
					{
						object[] vars7 = new object[1] { text3 };
						text = TextStorage.TEXTS.GetText(Class16.smethod_0(1648927312), vars7);
						break;
					}
					case (AH_ACTIONS)7:
					{
						object[] vars6 = new object[1] { text3 };
						text = TextStorage.TEXTS.GetText(Class16.smethod_0(1648927343), vars6);
						break;
					}
					case AH_ACTIONS.Remove:
					case (AH_ACTIONS)9:
						if (hISTORYSTAGE.IsMoveItems)
						{
							object[] vars2 = new object[1] { text2 };
							text = TextStorage.TEXTS.GetText(Class16.smethod_0(1648927366), vars2);
						}
						else
						{
							object[] vars3 = new object[1] { text2 };
							text = TextStorage.TEXTS.GetText(Class16.smethod_0(1648927389), vars3);
						}
						break;
					}
				}
			}
			goto IL_0416;
		}
		int num7 = StageIndex;
		string result = Class16.smethod_0(1648927412) + num7;
		GC.KeepAlive(this);
		return result;
		IL_0416:
		hISTORYSTAGE.CachedCaption = text;
		hISTORYSTAGE.CaptionLang = CommonStorage.Texts.LangIndex;
		if (bSetDate)
		{
			uint timeStamp = hISTORYSTAGE.TimeStamp;
			if (timeStamp != 0)
			{
				DateTime dateTime = ACE.RSGlobal.RSGlobal.Timestamp2DateTime(timeStamp).ToLocalTime();
				text = ((DateTime.Now.Day - dateTime.Day != 0) ? (dateTime.ToString(Class16.smethod_0(1648927460)) + text) : (dateTime.ToString(Class16.smethod_0(1648927434)) + text));
			}
		}
		GC.KeepAlive(this);
		return text;
	}

	public string GetCaption(int StageIndex, [MarshalAs(UnmanagedType.U1)] bool bSetDate)
	{
		return GetCaption(StageIndex, -1, bSetDate);
	}

	public string GetItemsNames(ITEMS_COLLECTION ic)
	{
		string result = string.Empty;
		if (ic != null)
		{
			ic.ValidateValues();
			int count = ic.Count;
			if (count == 1)
			{
				vITEMPOS vITEMPOS2 = ic[0];
				vITEMPOS vITEMPOS3 = ic[0];
				int itemCount = Lists[vITEMPOS3.Int32_1].ItemCount;
				if (vITEMPOS2.Int32_0 < itemCount)
				{
					vITEMPOS vITEMPOS4 = ic[0];
					vITEMPOS vITEMPOS5 = ic[0];
					result = Lists[vITEMPOS5.Int32_1].GetParsedItemName(vITEMPOS4.Int32_0);
					goto IL_024c;
				}
			}
			else if (count == 2)
			{
				vITEMPOS vITEMPOS6 = ic[0];
				vITEMPOS vITEMPOS7 = ic[0];
				int itemCount2 = Lists[vITEMPOS7.Int32_1].ItemCount;
				if (vITEMPOS6.Int32_0 < itemCount2)
				{
					vITEMPOS vITEMPOS8 = ic[1];
					vITEMPOS vITEMPOS9 = ic[1];
					int itemCount3 = Lists[vITEMPOS9.Int32_1].ItemCount;
					if (vITEMPOS8.Int32_0 < itemCount3)
					{
						vITEMPOS vITEMPOS10 = ic[1];
						vITEMPOS vITEMPOS11 = ic[1];
						vITEMPOS vITEMPOS12 = ic[0];
						vITEMPOS vITEMPOS13 = ic[0];
						eList eList2 = Lists[vITEMPOS11.Int32_1];
						string text = Class16.smethod_0(1648942920);
						result = string.Concat(Lists[vITEMPOS13.Int32_1].GetParsedItemName(vITEMPOS12.Int32_0) + text, eList2.GetParsedItemName(vITEMPOS10.Int32_0));
						goto IL_024c;
					}
				}
			}
			vITEMPOS vITEMPOS14 = ic[0];
			vITEMPOS vITEMPOS15 = ic[0];
			int itemCount4 = Lists[vITEMPOS15.Int32_1].ItemCount;
			if (vITEMPOS14.Int32_0 < itemCount4)
			{
				vITEMPOS vITEMPOS16 = ic[count - 1];
				vITEMPOS vITEMPOS17 = ic[count - 1];
				int itemCount5 = Lists[vITEMPOS17.Int32_1].ItemCount;
				if (vITEMPOS16.Int32_0 < itemCount5)
				{
					vITEMPOS vITEMPOS18 = ic[count - 1];
					vITEMPOS vITEMPOS19 = ic[count - 1];
					vITEMPOS vITEMPOS20 = ic[0];
					vITEMPOS vITEMPOS21 = ic[0];
					eList eList3 = Lists[vITEMPOS19.Int32_1];
					string text2 = Class16.smethod_0(1648928044);
					result = string.Concat(Lists[vITEMPOS21.Int32_1].GetParsedItemName(vITEMPOS20.Int32_0) + text2, eList3.GetParsedItemName(vITEMPOS18.Int32_0));
				}
			}
		}
		goto IL_024c;
		IL_024c:
		GC.KeepAlive(this);
		return result;
	}

	public int GetSavedStageIndex(uint SavedTimeStamp)
	{
		List<HISTORYSTAGE> history = History;
		int result;
		if (history != null && history.Count > 0)
		{
			int num = History.Count - 1;
			if (num >= 0)
			{
				while (History[num].SavedTimeStamps == null || !History[num].SavedTimeStamps.Contains(SavedTimeStamp))
				{
					num--;
					if (num >= 0)
					{
						continue;
					}
					goto IL_006e;
				}
				result = num;
				SavedStage = num;
				if (num != -1)
				{
					goto IL_0075;
				}
			}
		}
		goto IL_006e;
		IL_006e:
		result = SavedStage;
		goto IL_0075;
		IL_0075:
		return result;
	}

	public List<HISTORYSTAGE> GetSubstages(int StageIndex)
	{
		if (StageIndex < 0 || StageIndex >= History.Count)
		{
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1648927475), Class16.smethod_0(1648927529)) + StageIndex, Class16.smethod_0(1648934892), MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		if (History[StageIndex].action != (AH_ACTIONS)8)
		{
			GC.KeepAlive(this);
			return null;
		}
		LoadSubStages(History[StageIndex]);
		List<HISTORYSTAGE> subStages = History[StageIndex].SubStages;
		GC.KeepAlive(this);
		return subStages;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsElementsSaved(uint SavedTimeStamp)
	{
		int currentStageIndex = CurrentStageIndex;
		return GetSavedStageIndex(SavedTimeStamp) == currentStageIndex;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsElementsSaved()
	{
		return IsSaved(FILES_ENUM.ELEMENTS);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsFieldChanged(vITEMPOS item, int int_0)
	{
		return IsItemChanged(item, int_0, FILES_ENUM.ELEMENTS);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsItemChanged(ref HISTORYSTAGE hs, ref vITEMPOS vITEMPOS_0, ref LISTandID item_id, int int_0, FILES_ENUM CheckFile)
	{
		HISTORYSTAGE hISTORYSTAGE = null;
		int num;
		if (CheckFile == FILES_ENUM.ALL_FILES || CheckFile == FILES_ENUM.ELEMENTS)
		{
			HISTORYSTAGE hISTORYSTAGE2 = hs;
			if (hISTORYSTAGE2.action == (AH_ACTIONS)5)
			{
				if (!hISTORYSTAGE2.IsMoveItems && Array.IndexOf(hs.listsindices, vITEMPOS_0.Int32_1) > -1)
				{
					GC.KeepAlive(this);
					return int_0 == -1;
				}
			}
			else
			{
				if (hISTORYSTAGE2.IsMoveItems)
				{
					return false;
				}
				if (hISTORYSTAGE2.Items != null)
				{
					if (int_0 != -1)
					{
						hISTORYSTAGE2 = hs;
						if (hISTORYSTAGE2.action != AH_ACTIONS.Add || !hISTORYSTAGE2.Items.FieldsHashes.Contains(int_0))
						{
							num = 0;
							goto IL_008e;
						}
					}
					num = 1;
					goto IL_008e;
				}
			}
		}
		goto IL_00f5;
		IL_008e:
		if ((byte)num != 0)
		{
			if (Lists[vITEMPOS_0.Int32_1].bItemsOrderingChanged)
			{
				if (hs.Items.ListAndIdHashes == null)
				{
					CheckAndSetItemsIdsHash(ref hs);
				}
				bool result = hs.Items.ContainsId(item_id);
				GC.KeepAlive(this);
				return result;
			}
			bool result2 = hs.Items.Contains(vITEMPOS_0);
			GC.KeepAlive(this);
			return result2;
		}
		goto IL_00f5;
		IL_00f5:
		if ((CheckFile == FILES_ENUM.ALL_FILES || CheckFile == FILES_ENUM.ITEM_EXT_DESC || CheckFile == FILES_ENUM.ITEM_EXT_DESC_AND_ITEM_COLOR) && hs.action == (AH_ACTIONS)7)
		{
			bool result3 = Array.IndexOf(hs.IDs, item_id.id) > -1;
			GC.KeepAlive(this);
			return result3;
		}
		if (CheckFile == FILES_ENUM.ALL_FILES || CheckFile == FILES_ENUM.ITEM_COLOR || CheckFile == FILES_ENUM.ITEM_EXT_DESC_AND_ITEM_COLOR)
		{
			AH_ACTIONS action = hs.action;
			if (action == (AH_ACTIONS)7 || action == (AH_ACTIONS)6)
			{
				bool result4 = Array.IndexOf(hs.IDs, item_id.id) > -1;
				GC.KeepAlive(this);
				return result4;
			}
		}
		List<HISTORYSTAGE> subStages = hs.SubStages;
		if (subStages != null)
		{
			List<HISTORYSTAGE>.Enumerator enumerator = subStages.GetEnumerator();
			if (enumerator.MoveNext())
			{
				do
				{
					hISTORYSTAGE = enumerator.Current;
					if (IsItemChanged(ref hISTORYSTAGE, ref vITEMPOS_0, ref item_id, int_0, CheckFile))
					{
						GC.KeepAlive(this);
						return true;
					}
				}
				while (enumerator.MoveNext());
			}
		}
		return false;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsItemChanged(vITEMPOS item, int int_0, FILES_ENUM CheckFile)
	{
		if (IsStageComplete && !IsSaved(FILES_ENUM.ALL_FILES))
		{
			int num = Lists[item.Int32_1].getid(item.Int32_0);
			int int32_ = item.Int32_1;
			LISTandID lISTandID = new LISTandID
			{
				Int32_0 = int32_
			};
			num = ((num > 1000000) ? 100000 : num);
			lISTandID.id = num;
			LISTandID item_id = lISTandID;
			int currentStageIndex = CurrentStageIndex;
			int num2 = currentStageIndex;
			int savedStage = SavedStage;
			int num3 = savedStage;
			int num4 = 1;
			if (currentStageIndex >= savedStage)
			{
				num4 = -num4;
			}
			int num5 = num4;
			num3 = num5 + num3;
			if (num2 >= 0)
			{
				while (num2 != num3 && num2 < History.Count)
				{
					HISTORYSTAGE hs = History[num2];
					if (!IsItemChanged(ref hs, ref item, ref item_id, int_0, CheckFile))
					{
						num2 = num5 + num2;
						if (num2 < 0)
						{
							break;
						}
						continue;
					}
					return true;
				}
			}
			GC.KeepAlive(this);
			return false;
		}
		return false;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsItemChanged(vITEMPOS item, FILES_ENUM CheckFile)
	{
		return IsItemChanged(item, -1, CheckFile);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsItemChanged(vITEMPOS item)
	{
		return IsItemChanged(item, -1, FILES_ENUM.ALL_FILES);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsRedoAvailable()
	{
		int num = History.Count - 1;
		bool result = CurrentStageIndex < num;
		GC.KeepAlive(this);
		return result;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsSaved(FILES_ENUM CheckFile)
	{
		int currentStageIndex = CurrentStageIndex;
		if (currentStageIndex < SavedStage)
		{
			return false;
		}
		int num = -1;
		int num2 = currentStageIndex;
		if (num2 >= 0)
		{
			do
			{
				if (num2 < History.Count)
				{
					AH_ACTIONS action = History[num2].action;
					switch (CheckFile)
					{
					case FILES_ENUM.ALL_FILES:
						num = num2;
						break;
					case FILES_ENUM.ELEMENTS:
						if ((uint)(action - 1) <= 4u || (uint)(action - 8) <= 1u)
						{
							num = num2;
						}
						break;
					case FILES_ENUM.ITEM_EXT_DESC:
						if (action == (AH_ACTIONS)7)
						{
							num = num2;
						}
						break;
					case FILES_ENUM.ITEM_COLOR:
						if (action == (AH_ACTIONS)6)
						{
							num = num2;
						}
						break;
					case FILES_ENUM.ITEM_EXT_DESC_AND_ITEM_COLOR:
						if (action == (AH_ACTIONS)7 || action == (AH_ACTIONS)6)
						{
							num = num2;
						}
						break;
					}
				}
				if (num > -1)
				{
					break;
				}
				num2--;
			}
			while (num2 >= 0);
		}
		GC.KeepAlive(this);
		return SavedStage >= num;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsUndoAvailable()
	{
		return CurrentStageIndex > -1;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool LoadStageLists(HISTORYSTAGE Stage, string name)
	{
		string text = Class16.smethod_0(1648927580);
		string uniqueID = UniqueID;
		string text2 = Class16.smethod_0(1648928069);
		string text3 = string.Concat(string.Concat(string.Concat(Application.StartupPath + text2, uniqueID), text), name);
		if (File.Exists(text3))
		{
			BinaryReader binaryReader = null;
			try
			{
				binaryReader = new BinaryReader(new MemoryStream(RSCompression.DecompressDataFast(smethod_1(text3))));
				int[] listsindices = Stage.listsindices;
				for (int i = 0; i < (nint)listsindices.LongLength; i++)
				{
					int int_ = listsindices[i];
					eList.ReadList(binaryReader, int_, ref Lists, ConversationListIndex, GAMES.UNKNOWN_GAME, 0);
				}
				binaryReader.Close();
				GC.KeepAlive(this);
				return true;
			}
			catch (ApplicationException ex)
			{
				if (Stage != null)
				{
					method_1(Stage);
					Stage.action = AH_ACTIONS.None;
				}
				SentryHelper.CaptureMessage(Class16.smethod_0(1648927588) + text3 + Class16.smethod_0(1648927638) + ex.Message, (SentryLevel)2, Class16.smethod_0(1648927640));
				GC.KeepAlive(this);
				return false;
			}
			catch (InvalidDataException ex2)
			{
				if (Stage != null)
				{
					method_1(Stage);
					Stage.action = AH_ACTIONS.None;
				}
				SentryHelper.CaptureMessage(Class16.smethod_0(1648927588) + text3 + Class16.smethod_0(1648927638) + ex2.Message, (SentryLevel)2, Class16.smethod_0(1648927640));
				GC.KeepAlive(this);
				return false;
			}
			catch (EndOfStreamException ex3)
			{
				if (Stage != null)
				{
					method_1(Stage);
					Stage.action = AH_ACTIONS.None;
				}
				SentryHelper.CaptureMessage(Class16.smethod_0(1648927700) + text3 + Class16.smethod_0(1648927638) + ex3.Message, (SentryLevel)2, Class16.smethod_0(1648927640));
				GC.KeepAlive(this);
				return false;
			}
			catch (Exception ex4)
			{
				SentryHelper.CaptureException(ex4, Class16.smethod_0(1648926720));
			}
		}
		object[] vars = new object[1] { text3 };
		TextStorage.TEXTS.ShowMessage(496, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, vars);
		GC.KeepAlive(this);
		return false;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool LoadSubStages(HISTORYSTAGE Stage)
	{
		if (Stage.SubStages != null)
		{
			return true;
		}
		string subStagesFileName = Stage.GetSubStagesFileName();
		string text = Class16.smethod_0(1648927580);
		string uniqueID = UniqueID;
		string text2 = Class16.smethod_0(1648928069);
		string text3 = string.Concat(string.Concat(string.Concat(Application.StartupPath + text2, uniqueID), text), subStagesFileName);
		if (File.Exists(text3))
		{
			try
			{
				byte[] buffer = RSCompression.DecompressDataFast(smethod_1(text3));
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				Stage.SubStages = binaryFormatter.Deserialize(new MemoryStream(buffer)) as List<HISTORYSTAGE>;
			}
			catch (Exception ex)
			{
				SentryHelper.CaptureException(ex, Class16.smethod_0(1648926764));
			}
		}
		else
		{
			object[] vars = new object[1] { text3 };
			TextStorage.TEXTS.ShowMessage(496, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, vars);
		}
		GC.KeepAlive(this);
		return Stage.SubStages != null;
	}

	public HISTORYSTAGE Redo()
	{
		if (!IsRedoAvailable())
		{
			return null;
		}
		if (ACE.RSGlobal.RSGlobal.antirecurse_Redo_ACTION_HISTORY)
		{
			return null;
		}
		bool flag = false;
		try
		{
			ACE.RSGlobal.RSGlobal.antirecurse_Redo_ACTION_HISTORY = true;
			int index = ++CurrentStageIndex;
			(Stage = History[index]).IsRedo = true;
			HISTORYSTAGE stage = Stage;
			if (stage.action != (AH_ACTIONS)8)
			{
				RedoStage(stage);
			}
			else if (LoadSubStages(stage))
			{
				for (int i = 0; i < Stage.SubStages.Count; i++)
				{
					RedoStage(Stage.SubStages[i]);
				}
			}
			flag = true;
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1648926799));
			HISTORYSTAGE stage2 = Stage;
			if (stage2 != null)
			{
				method_1(stage2);
				Stage.action = AH_ACTIONS.None;
			}
			CommonStorage.Texts.ShowHandeledException(ex, 621, null);
		}
		finally
		{
			ACE.RSGlobal.RSGlobal.antirecurse_Redo_ACTION_HISTORY = false;
		}
		if (flag)
		{
			GC.KeepAlive(this);
			return Stage;
		}
		return null;
	}

	public HISTORYSTAGE Redo(int StageIndex)
	{
		if (antirecurse)
		{
			return null;
		}
		int num = StageIndex - CurrentStageIndex;
		if (num > 1)
		{
			HISTORYSTAGE hISTORYSTAGE = new HISTORYSTAGE((AH_ACTIONS)8);
			hISTORYSTAGE.SubStages = new List<HISTORYSTAGE>(num);
			int num2 = 0;
			if (0 < num)
			{
				do
				{
					hISTORYSTAGE.SubStages.Add(Redo());
					int num3 = num2;
					if (num3 - (int)((uint)num3 / 500u * 500) == 0)
					{
						Application.DoEvents();
					}
					num2++;
				}
				while (num2 < num);
			}
			GC.KeepAlive(this);
			return hISTORYSTAGE;
		}
		return Redo();
	}

	public void RedoStage(HISTORYSTAGE Stage)
	{
		if (Stage == null)
		{
			return;
		}
		Stage.IsRedo = true;
		switch (Stage.action)
		{
		case AH_ACTIONS.Add:
		{
			int int_ = Stage.int_0;
			if (int_ < 0 || int_ >= Lists.Length)
			{
				break;
			}
			int[] itemsindices = Stage.itemsindices;
			int[] fieldsindices = Stage.fieldsindices;
			if (itemsindices == null || fieldsindices == null)
			{
				break;
			}
			int num4 = 0;
			if (0 >= (nint)itemsindices.LongLength)
			{
				break;
			}
			do
			{
				int num5 = itemsindices[num4];
				if (num5 < 0 || num5 >= Lists[int_].elementValues.Length)
				{
					num4++;
					continue;
				}
				int num6 = 0;
				if (0 < (nint)fieldsindices.LongLength)
				{
					do
					{
						object[][] values_new = Stage.values_new;
						if (values_new != null && num4 < values_new.Length && values_new[num4] != null && num6 < values_new[num4].Length && fieldsindices[num6] >= 0 && fieldsindices[num6] < Lists[int_].elementValues[num5].Length)
						{
							Lists[int_].elementValues[num5][fieldsindices[num6]] = values_new[num4][num6];
						}
						num6++;
					}
					while (num6 < (nint)fieldsindices.LongLength);
				}
				num4++;
			}
			while (num4 < (nint)itemsindices.LongLength);
			break;
		}
		case AH_ACTIONS.Update:
		{
			int int_2 = Stage.int_0;
			if (int_2 < 0 || int_2 >= Lists.Length)
			{
				break;
			}
			int[] itemsindices2 = Stage.itemsindices;
			object[][] values_new2 = Stage.values_new;
			if (itemsindices2 == null || values_new2 == null)
			{
				break;
			}
			int num7 = Math.Min(itemsindices2.Length, values_new2.Length);
			int num8 = 0;
			if (num7 > 0)
			{
				do
				{
					Lists[int_2].AddItem(itemsindices2[num8], values_new2[num8]);
					num8++;
				}
				while (num8 < num7);
			}
			Lists[int_2].UpdateIDs();
			break;
		}
		case (AH_ACTIONS)4:
		{
			int int_3 = Stage.int_0;
			if (int_3 < 0 || int_3 >= Lists.Length)
			{
				break;
			}
			int[] itemsindices3 = Stage.itemsindices;
			if (itemsindices3 == null)
			{
				break;
			}
			int num10 = (int)((nint)itemsindices3.LongLength - 1);
			if (num10 >= 0)
			{
				do
				{
					int num11 = itemsindices3[num10];
					if (num11 >= 0 && num11 < Lists[int_3].elementValues.Length)
					{
						Lists[int_3].RemoveItem(num11);
					}
					num10--;
				}
				while (num10 >= 0);
			}
			Lists[int_3].UpdateIDs();
			break;
		}
		case (AH_ACTIONS)5:
			LoadStageLists(Stage, Stage.GetStageRedoFileName());
			break;
		case (AH_ACTIONS)6:
		{
			ITEM_EXT_COLOR colors = Colors;
			if (colors == null || !colors.FileLoaded)
			{
				break;
			}
			int num9 = 0;
			if (0 < (nint)Stage.IDs.LongLength)
			{
				do
				{
					Colors.Change(Stage.IDs[num9], Stage.color_new);
					num9++;
				}
				while (num9 < (nint)Stage.IDs.LongLength);
			}
			break;
		}
		case (AH_ACTIONS)7:
		{
			ITEM_EXT_DESC descriptions = Descriptions;
			if (descriptions == null || !descriptions.FileLoaded)
			{
				break;
			}
			int num3 = 0;
			if (0 < (nint)Stage.IDs.LongLength)
			{
				do
				{
					Descriptions.Change(Stage.IDs[num3], Stage.descriptions_new[num3]);
					num3++;
				}
				while (num3 < (nint)Stage.IDs.LongLength);
			}
			break;
		}
		case AH_ACTIONS.Remove:
		case (AH_ACTIONS)9:
		{
			ITEMS_COLLECTION items = Stage.Items;
			if (items == null)
			{
				break;
			}
			items.ValidateValues();
			int num = 0;
			if (0 < items.Count)
			{
				do
				{
					vITEMPOS vITEMPOS2 = items.ItemsList[num];
					int int32_ = vITEMPOS2.Int32_0;
					int int32_2 = vITEMPOS2.Int32_1;
					if (int32_2 >= 0 && int32_2 < Lists.Length && int32_ >= 0 && int32_ < Lists[int32_2].elementValues.Length && Stage.values_new != null && num < Stage.values_new.Length && Stage.values_new[num] != null)
					{
						Array.Copy(Stage.values_new[num], 0, Lists[int32_2].elementValues[int32_], 0, Math.Min(Stage.values_new[num].Length, Lists[int32_2].elementValues[int32_].Length));
					}
					num++;
				}
				while (num < items.Count);
			}
			if (!items.bChangeDesc || !Descriptions.FileLoaded)
			{
				break;
			}
			int num2 = 0;
			HashSet<LISTandID>.Enumerator enumerator = items.ListAndIdHashes.GetEnumerator();
			if (!enumerator.MoveNext())
			{
				break;
			}
			do
			{
				LISTandID current = enumerator.Current;
				if (Lists[current.Int32_0].bMatters)
				{
					string desc = Stage.descriptions_new[num2];
					Descriptions.Change(current.id, desc);
				}
				num2++;
			}
			while (enumerator.MoveNext());
			break;
		}
		}
		GC.KeepAlive(this);
	}

	public void SaveHistory([MarshalAs(UnmanagedType.U1)] bool bAsync)
	{
		if (CommonStorage.Params.SaveActionsHistory)
		{
			Thread saveHistoryThread = SaveHistoryThread;
			if (saveHistoryThread != null && saveHistoryThread.IsAlive && !SaveHistoryThread.Join(9000))
			{
				SaveHistoryThread.Abort();
				ACE.RSGlobal.RSGlobal.Sleep(500);
			}
			(SaveHistoryThread = new Thread(SaveHistoryAsync)).Start(this);
			if (!bAsync)
			{
				SaveHistoryThread.Join(9000);
			}
			GC.KeepAlive(this);
		}
	}

	public void SaveHistory()
	{
		SaveHistory(bAsync: true);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool SaveStageLists(string name)
	{
		string text = Class16.smethod_0(1648926817);
		if (!Directory.Exists(Application.StartupPath + text))
		{
			string text2 = Class16.smethod_0(1648926817);
			Directory.CreateDirectory(Application.StartupPath + text2);
		}
		string uniqueID = UniqueID;
		string text3 = Class16.smethod_0(1648928069);
		if (!Directory.Exists(string.Concat(Application.StartupPath + text3, uniqueID)))
		{
			string uniqueID2 = UniqueID;
			string text4 = Class16.smethod_0(1648928069);
			Directory.CreateDirectory(string.Concat(Application.StartupPath + text4, uniqueID2));
		}
		string text5 = Class16.smethod_0(1648927580);
		string uniqueID3 = UniqueID;
		string text6 = Class16.smethod_0(1648928069);
		string path = string.Concat(string.Concat(string.Concat(Application.StartupPath + text6, uniqueID3), text5), name);
		MemoryStream memoryStream = new MemoryStream();
		BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
		try
		{
			int[] listsindices = Stage.listsindices;
			if (listsindices == null || listsindices.Length == 0)
			{
				return true;
			}
			for (int i = 0; i < listsindices.Length; i++)
			{
				int num = listsindices[i];
				if (num >= 0 && Lists != null && num < Lists.Length && Lists[num] != null)
				{
					try
					{
						eList.WriteList(binaryWriter, num, ref Lists, ConversationListIndex, GAMES.UNKNOWN_GAME, 0);
					}
					catch (Exception ex)
					{
						string message = string.Format(Class16.smethod_0(1648926974), num, i, ex.Message);
						SentryHelper.CaptureMessage(message, (SentryLevel)2, Class16.smethod_0(1648927032));
					}
				}
				else
				{
					string format = Class16.smethod_0(1648926846);
					object arg = num;
					object arg2 = i;
					eList[] lists = Lists;
					string message2 = string.Format(format, arg, arg2, (lists != null) ? lists.Length : 0);
					SentryHelper.CaptureMessage(message2, (SentryLevel)2, Class16.smethod_0(1648926925));
				}
			}
			File.WriteAllBytes(path, RSCompression.CompressDataFast(memoryStream.ToArray()));
		}
		catch (Exception ex2)
		{
			SentryHelper.CaptureException(ex2, Class16.smethod_0(1648927087));
			GC.KeepAlive(this);
			return false;
		}
		finally
		{
			binaryWriter.Close();
			memoryStream.Close();
		}
		GC.KeepAlive(this);
		return true;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool SaveSubStages(string name)
	{
		if (!CommonStorage.Params.SaveActionsHistory)
		{
			return true;
		}
		string text = Class16.smethod_0(1648926817);
		if (!Directory.Exists(Application.StartupPath + text))
		{
			string text2 = Class16.smethod_0(1648926817);
			Directory.CreateDirectory(Application.StartupPath + text2);
		}
		string uniqueID = UniqueID;
		string text3 = Class16.smethod_0(1648928069);
		if (!Directory.Exists(string.Concat(Application.StartupPath + text3, uniqueID)))
		{
			string uniqueID2 = UniqueID;
			string text4 = Class16.smethod_0(1648928069);
			Directory.CreateDirectory(string.Concat(Application.StartupPath + text4, uniqueID2));
		}
		string text5 = Class16.smethod_0(1648927580);
		string uniqueID3 = UniqueID;
		string text6 = Class16.smethod_0(1648928069);
		string text7 = string.Concat(string.Concat(string.Concat(Application.StartupPath + text6, uniqueID3), text5), name);
		MemoryStream memoryStream = new MemoryStream();
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		try
		{
			binaryFormatter.Serialize(memoryStream, Stage.SubStages);
			File.WriteAllBytes(text7, RSCompression.CompressDataFast(memoryStream.ToArray()));
			memoryStream.Close();
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1648927115));
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1648927158), Class16.smethod_0(1648927205)) + Class16.smethod_0(1648941987) + text7, TextStorage.TEXTS.GetText(Class16.smethod_0(1648930319)), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
		return true;
	}

	public void SetUniqueID(string UniqueID)
	{
		this.UniqueID = UniqueID;
		string text = Class16.smethod_0(1648928048);
		string text2 = Class16.smethod_0(1648928069);
		FileName = string.Concat(string.Concat(Application.StartupPath + text2, UniqueID), text);
		GC.KeepAlive(this);
	}

	public void stAddItems(int int_0, int[] itemsindices, int[] selecteditems_before, int StageCaptionIndex)
	{
		method_0(AH_ACTIONS.Update);
		Stage.int_0 = int_0;
		Stage.itemsindices = itemsindices;
		Stage.selecteditems_before = ACE.RSGlobal.RSGlobal.CloneArray(selecteditems_before);
		Stage.CaptionIndex = StageCaptionIndex;
		IsStageComplete = false;
	}

	public void stAddItems(int int_0, int[] itemsindices, int[] selecteditems_before)
	{
		stAddItems(int_0, itemsindices, selecteditems_before, -1);
	}

	public void stChangeElements(int StageCaptionIndex)
	{
		object[] vars = new object[0];
		int endval = (int)((nint)Lists.LongLength - 1);
		int[] listsIndices = ACE.RSGlobal.RSGlobal.IntArray(0, endval, 1);
		stChangeLists(listsIndices, StageCaptionIndex, vars);
		GC.KeepAlive(this);
	}

	public void stChangeFields(int int_0, int[] itemsindices, int[] fieldsindices, int StageCaptionIndex, params object[] vars)
	{
		method_0(AH_ACTIONS.Add);
		Stage.int_0 = int_0;
		Stage.itemsindices = ACE.RSGlobal.RSGlobal.CloneArray(itemsindices);
		Stage.fieldsindices = ACE.RSGlobal.RSGlobal.CloneArray(fieldsindices);
		Stage.CaptionIndex = StageCaptionIndex;
		Stage.CaptionVars = vars;
		Stage.values_old = new object[(nint)itemsindices.LongLength][];
		int num = 0;
		if (0 < (nint)itemsindices.LongLength)
		{
			int num2 = fieldsindices.Length;
			do
			{
				Stage.values_old[num] = new object[num2];
				int num3 = itemsindices[num];
				int num4 = 0;
				num2 = fieldsindices.Length;
				if (0 < num2)
				{
					do
					{
						Stage.values_old[num][num4] = Lists[int_0].elementValues[num3][fieldsindices[num4]];
						num4++;
						num2 = fieldsindices.Length;
					}
					while (num4 < num2);
				}
				num++;
			}
			while (num < (nint)itemsindices.LongLength);
		}
		IsStageComplete = false;
	}

	public void stChangeFields(int int_0, int[] itemsindices, int[] fieldsindices, int StageCaptionIndex)
	{
		stChangeFields(int_0, itemsindices, fieldsindices, StageCaptionIndex, null);
	}

	public void stChangeFields(int int_0, int[] itemsindices, int[] fieldsindices)
	{
		stChangeFields(int_0, itemsindices, fieldsindices, -1, null);
	}

	public void stChangeFields(ITEMPOS ItemPos, int[] fieldsindices)
	{
		stChangeFields(itemsindices: new int[1] { ItemPos.int_1 }, int_0: ItemPos.int_0, fieldsindices: fieldsindices, StageCaptionIndex: -1, vars: null);
		GC.KeepAlive(this);
	}

	public void stChangeItems(ITEMS_COLLECTION Items)
	{
		method_0(AH_ACTIONS.Remove);
		Items.ValidateValues();
		Stage.CaptionIndex = -1;
		vITEMPOS vITEMPOS2 = Items.ItemsList[0];
		Stage.int_0 = vITEMPOS2.Int32_1;
		Stage.Items = Items;
		Stage.values_old = new object[Items.Count][];
		int num = 0;
		if (0 < Items.Count)
		{
			do
			{
				vITEMPOS vITEMPOS3 = Items.ItemsList[num];
				int int32_ = vITEMPOS3.Int32_0;
				int int32_2 = vITEMPOS3.Int32_1;
				Stage.values_old[num] = ACE.RSGlobal.RSGlobal.CloneArray(Lists[int32_2].elementValues[int32_]);
				num++;
			}
			while (num < Items.Count);
		}
		if (Items.bChangeDesc && Descriptions.FileLoaded)
		{
			Stage.descriptions_old = new string[Items.Count];
			int num2 = 0;
			HashSet<LISTandID>.Enumerator enumerator = Items.ListAndIdHashes.GetEnumerator();
			if (enumerator.MoveNext())
			{
				do
				{
					LISTandID current = enumerator.Current;
					if (Lists[current.Int32_0].bMatters)
					{
						string clean = Descriptions.GetClean(current.id);
						Stage.descriptions_old[num2] = clean;
					}
					num2++;
				}
				while (enumerator.MoveNext());
			}
		}
		IsStageComplete = false;
	}

	public void stChangeItems(int int_0, int[] itemsindices, int[] selecteditems_before, int[] selecteditems_after, int StageCaptionIndex)
	{
		method_0(AH_ACTIONS.Remove);
		Stage.CaptionIndex = StageCaptionIndex;
		Stage.int_0 = int_0;
		Stage.itemsindices = ACE.RSGlobal.RSGlobal.CloneArray(itemsindices);
		int num = ((selecteditems_before != null) ? 1 : 0);
		Stage.IsMoveItems = (byte)num != 0;
		Stage.selecteditems_before = selecteditems_before;
		Stage.selecteditems_after = selecteditems_after;
		Stage.values_old = new object[(nint)itemsindices.LongLength][];
		int num2 = 0;
		if (0 < (nint)itemsindices.LongLength)
		{
			do
			{
				int num3 = itemsindices[num2];
				Stage.values_old[num2] = new object[(nint)Lists[int_0].elementValues[num3].LongLength];
				Lists[int_0].elementValues[num3].CopyTo(Stage.values_old[num2], 0);
				num2++;
			}
			while (num2 < (nint)itemsindices.LongLength);
		}
		IsStageComplete = false;
	}

	public void stChangeItems(int int_0, int[] itemsindices, int[] selecteditems_before, int[] selecteditems_after)
	{
		stChangeItems(int_0, itemsindices, selecteditems_before, selecteditems_after, -1);
	}

	public void stChangeItems(int int_0, int[] itemsindices, int StageCaptionIndex)
	{
		stChangeItems(int_0, itemsindices, null, null, StageCaptionIndex);
	}

	public void stChangeItems(int int_0, int[] itemsindices)
	{
		stChangeItems(int_0, itemsindices, null, null, -1);
	}

	public void stChangeLists(int[] ListsIndices, int StageCaptionIndex, params object[] vars)
	{
		method_0((AH_ACTIONS)5);
		Stage.CaptionIndex = StageCaptionIndex;
		Stage.CaptionVars = vars;
		Stage.listsindices = ListsIndices;
		int num = (((nint)ListsIndices.LongLength == (nint)Lists.LongLength) ? 1 : 0);
		Stage.IsElementsSnapshot = (byte)num != 0;
		IsStageComplete = false;
		if (!SaveStageLists(Stage.GetStageUndoFileName()))
		{
			CancelLastStage(cancelSuperStage: false);
		}
	}

	public void stColor(int[] IDs)
	{
		if (!Colors.FileLoaded)
		{
			return;
		}
		method_0((AH_ACTIONS)6);
		Stage.IDs = IDs;
		Stage.colors_old = new int[(nint)IDs.LongLength];
		int num = 0;
		if (0 < (nint)IDs.LongLength)
		{
			do
			{
				ref int reference = ref IDs[num];
				if (Colors.Colors.ContainsKey(reference))
				{
					Stage.colors_old[num] = Colors.Colors[reference];
				}
				num++;
			}
			while (num < (nint)IDs.LongLength);
		}
		IsStageComplete = false;
	}

	public void stColor(int id)
	{
		stColor(new int[1] { id });
		GC.KeepAlive(this);
	}

	public void stDeleteItems(int int_0, int[] itemsindices)
	{
		method_0((AH_ACTIONS)4);
		Stage.int_0 = int_0;
		Stage.itemsindices = ACE.RSGlobal.RSGlobal.CloneArray(itemsindices);
		Stage.values_old = new object[(nint)itemsindices.LongLength][];
		int num = 0;
		if (0 < (nint)itemsindices.LongLength)
		{
			do
			{
				int num2 = itemsindices[num];
				Stage.values_old[num] = new object[(nint)Lists[int_0].elementValues[num2].LongLength];
				Lists[int_0].elementValues[num2].CopyTo(Stage.values_old[num], 0);
				num++;
			}
			while (num < (nint)itemsindices.LongLength);
		}
		Stage.CaptionIndex = 818;
		object[] captionVars = new object[1] { GetItemsNames(Lists[int_0], itemsindices) };
		Stage.CaptionVars = captionVars;
		IsStageComplete = false;
		CheckAndSetItemsIdsHash(ref Stage);
	}

	public void stDesc(int[] IDs)
	{
		if (!Descriptions.FileLoaded)
		{
			return;
		}
		method_0((AH_ACTIONS)7);
		Stage.IDs = IDs;
		Stage.descriptions_old = new string[(nint)IDs.LongLength];
		int num = 0;
		if (0 < (nint)IDs.LongLength)
		{
			do
			{
				Stage.descriptions_old[num] = Descriptions.GetClean(IDs[num]);
				num++;
			}
			while (num < (nint)IDs.LongLength);
		}
		IsStageComplete = false;
	}

	public void stDesc(int id)
	{
		stDesc(new int[1] { id });
		GC.KeepAlive(this);
	}

	public void stMoveItems(int int_0, int[] selecteditems_before, int[] selecteditems_after, int StageCaptionIndex, params object[] vars)
	{
		method_0((AH_ACTIONS)5);
		Stage.CaptionIndex = StageCaptionIndex;
		Stage.CaptionVars = vars;
		int[] listsindices = new int[1] { int_0 };
		Stage.listsindices = listsindices;
		Stage.int_0 = int_0;
		Stage.IsMoveItems = true;
		Stage.l_before = int_0;
		Stage.l_after = int_0;
		Stage.selecteditems_before = selecteditems_before;
		Stage.selecteditems_after = selecteditems_after;
		IsStageComplete = false;
		if (!SaveStageLists(Stage.GetStageUndoFileName()))
		{
			CancelLastStage(cancelSuperStage: false);
		}
	}

	public void SubStagesBegin(int int_0, int[] selecteditems_before, int StageCaptionIndex, params object[] vars)
	{
		if (method_0((AH_ACTIONS)8))
		{
			IsSubStagesComplete = false;
			if (int_0 > -1 && selecteditems_before != null)
			{
				Stage.l_before = int_0;
				Stage.selecteditems_before = selecteditems_before;
			}
			Stage.CaptionIndex = StageCaptionIndex;
			Stage.CaptionVars = vars;
		}
	}

	public void SubStagesBegin(int StageCaptionIndex, params object[] vars)
	{
		SubStagesBegin(-1, null, StageCaptionIndex, vars);
	}

	public void SubStagesComplete(int int_0, int[] selecteditems_after)
	{
		if (IsSubStagesComplete)
		{
			return;
		}
		if (!IsStageComplete)
		{
			CancelLastStage(cancelSuperStage: false);
		}
		IsSubStagesComplete = true;
		List<HISTORYSTAGE> subStages = Stage.SubStages;
		if (subStages != null && subStages.Count > 1)
		{
			if (int_0 > -1 && selecteditems_after != null)
			{
				Stage.l_after = int_0;
				Stage.selecteditems_after = selecteditems_after;
			}
			SaveSubStages(Stage.GetSubStagesFileName());
			SaveHistory(bAsync: true);
			return;
		}
		List<HISTORYSTAGE> subStages2 = Stage.SubStages;
		if (subStages2 != null && subStages2.Count == 1)
		{
			HISTORYSTAGE stage = Stage;
			HISTORYSTAGE hISTORYSTAGE = stage;
			(Stage = stage.SubStages[0]).IsSubStage = false;
			HISTORYSTAGE stage2 = Stage;
			if (int_0 == stage2.int_0)
			{
				int[] selecteditems_before = hISTORYSTAGE.selecteditems_before;
				if (selecteditems_before != null)
				{
					stage2.selecteditems_before = selecteditems_before;
					Stage.selecteditems_after = selecteditems_after;
				}
			}
			Stage.CaptionIndex = hISTORYSTAGE.CaptionIndex;
			Stage.CaptionVars = hISTORYSTAGE.CaptionVars;
			History[CurrentStageIndex] = Stage;
			SaveHistory(bAsync: true);
		}
		else
		{
			CancelLastStage(cancelSuperStage: true);
		}
	}

	public void SubStagesComplete()
	{
		SubStagesComplete(-1, null);
	}

	public HISTORYSTAGE Undo(int StageIndex)
	{
		if (antirecurse)
		{
			return null;
		}
		int num = 1 - StageIndex + CurrentStageIndex;
		if (num > 1)
		{
			HISTORYSTAGE hISTORYSTAGE = new HISTORYSTAGE((AH_ACTIONS)8);
			hISTORYSTAGE.SubStages = new List<HISTORYSTAGE>(num);
			int num2 = 0;
			if (0 < num)
			{
				do
				{
					hISTORYSTAGE.SubStages.Add(Undo());
					int num3 = num2;
					if (num3 - (int)((uint)num3 / 500u * 500) == 0)
					{
						Application.DoEvents();
					}
					num2++;
				}
				while (num2 < num);
			}
			GC.KeepAlive(this);
			return hISTORYSTAGE;
		}
		return Undo();
	}

	public HISTORYSTAGE Undo()
	{
		if (!IsStageComplete)
		{
			CancelLastStage(cancelSuperStage: false);
		}
		if (CurrentStageIndex <= -1)
		{
			return null;
		}
		if (antirecurse)
		{
			return null;
		}
		antirecurse = true;
		bool flag = false;
		try
		{
			(Stage = History[CurrentStageIndex]).IsRedo = false;
			HISTORYSTAGE stage = Stage;
			if (stage.action != (AH_ACTIONS)8)
			{
				UndoStage(stage);
			}
			else if (LoadSubStages(stage))
			{
				for (int num = Stage.SubStages.Count - 1; num >= 0; num--)
				{
					UndoStage(Stage.SubStages[num]);
				}
			}
			flag = true;
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1648930342));
			HISTORYSTAGE stage2 = Stage;
			if (stage2 != null)
			{
				method_1(stage2);
				Stage.action = AH_ACTIONS.None;
			}
			CommonStorage.Texts.ShowHandeledException(ex, 621, null);
		}
		finally
		{
			CurrentStageIndex--;
			antirecurse = false;
		}
		if (flag)
		{
			return Stage;
		}
		return null;
	}

	public void UndoStage(HISTORYSTAGE Stage)
	{
		if (Stage == null)
		{
			return;
		}
		Stage.IsRedo = false;
		switch (Stage.action)
		{
		case AH_ACTIONS.Add:
		{
			int int_ = Stage.int_0;
			if (int_ < 0 || int_ >= Lists.Length)
			{
				break;
			}
			int[] itemsindices = Stage.itemsindices;
			int[] fieldsindices = Stage.fieldsindices;
			if (itemsindices == null || fieldsindices == null || Stage.values_old == null)
			{
				break;
			}
			int num6 = 0;
			if (0 >= (nint)itemsindices.LongLength)
			{
				break;
			}
			int num7 = fieldsindices.Length;
			do
			{
				int num8 = itemsindices[num6];
				if (num8 < 0 || num8 >= Lists[int_].elementValues.Length || num6 >= Stage.values_old.Length || Stage.values_old[num6] == null)
				{
					num6++;
					continue;
				}
				int num9 = 0;
				if (0 < num7)
				{
					do
					{
						if (num9 < Stage.values_old[num6].Length && fieldsindices[num9] >= 0 && fieldsindices[num9] < Lists[int_].elementValues[num8].Length)
						{
							Lists[int_].elementValues[num8][fieldsindices[num9]] = Stage.values_old[num6][num9];
						}
						num9++;
						num7 = fieldsindices.Length;
					}
					while (num9 < num7);
				}
				num6++;
			}
			while (num6 < (nint)itemsindices.LongLength);
			break;
		}
		case AH_ACTIONS.Update:
		{
			int int_2 = Stage.int_0;
			if (int_2 < 0 || int_2 >= Lists.Length)
			{
				break;
			}
			int[] itemsindices2 = Stage.itemsindices;
			if (itemsindices2 == null)
			{
				break;
			}
			int num10 = (int)((nint)itemsindices2.LongLength - 1);
			if (num10 >= 0)
			{
				do
				{
					int num11 = itemsindices2[num10];
					if (num11 >= 0 && num11 < Lists[int_2].elementValues.Length)
					{
						Lists[int_2].RemoveItem(num11);
					}
					num10--;
				}
				while (num10 >= 0);
			}
			Lists[int_2].UpdateIDs();
			break;
		}
		case (AH_ACTIONS)4:
		{
			int int_3 = Stage.int_0;
			if (int_3 < 0 || int_3 >= Lists.Length)
			{
				break;
			}
			int[] itemsindices3 = Stage.itemsindices;
			object[][] values_old = Stage.values_old;
			if (itemsindices3 == null || values_old == null)
			{
				break;
			}
			int num12 = Math.Min(itemsindices3.Length, values_old.Length);
			int num13 = 0;
			if (num12 > 0)
			{
				do
				{
					Lists[int_3].AddItem(itemsindices3[num13], values_old[num13]);
					num13++;
				}
				while (num13 < num12);
			}
			Lists[int_3].UpdateIDs();
			break;
		}
		case (AH_ACTIONS)5:
			LoadStageLists(Stage, Stage.GetStageUndoFileName());
			break;
		case (AH_ACTIONS)6:
		{
			int num4 = 0;
			if (0 >= (nint)Stage.IDs.LongLength)
			{
				break;
			}
			do
			{
				int key2 = Stage.IDs[num4];
				int num5 = Stage.colors_old[num4];
				if (num5 != 0)
				{
					Colors.Colors[key2] = num5;
				}
				else
				{
					Colors.Colors.Remove(key2);
				}
				num4++;
			}
			while (num4 < (nint)Stage.IDs.LongLength);
			break;
		}
		case (AH_ACTIONS)7:
		{
			int num3 = 0;
			if (0 >= (nint)Stage.IDs.LongLength)
			{
				break;
			}
			do
			{
				int key = Stage.IDs[num3];
				string text = Stage.descriptions_old[num3];
				if (text != null)
				{
					Descriptions.Descriptions[key] = text;
				}
				else
				{
					Descriptions.Descriptions.Remove(key);
				}
				num3++;
			}
			while (num3 < (nint)Stage.IDs.LongLength);
			break;
		}
		case AH_ACTIONS.Remove:
		case (AH_ACTIONS)9:
		{
			ITEMS_COLLECTION items = Stage.Items;
			if (items == null)
			{
				break;
			}
			items.ValidateValues();
			int num = 0;
			if (0 < items.Count)
			{
				do
				{
					vITEMPOS vITEMPOS2 = items.ItemsList[num];
					int int32_ = vITEMPOS2.Int32_0;
					int int32_2 = vITEMPOS2.Int32_1;
					if (int32_2 >= 0 && int32_2 < Lists.Length && int32_ >= 0 && int32_ < Lists[int32_2].elementValues.Length && Stage.values_old != null && num < Stage.values_old.Length && Stage.values_old[num] != null)
					{
						Array.Copy(Stage.values_old[num], 0, Lists[int32_2].elementValues[int32_], 0, Math.Min(Stage.values_old[num].Length, Lists[int32_2].elementValues[int32_].Length));
					}
					num++;
				}
				while (num < items.Count);
			}
			if (!items.bChangeDesc || !Descriptions.FileLoaded)
			{
				break;
			}
			int num2 = 0;
			HashSet<LISTandID>.Enumerator enumerator = items.ListAndIdHashes.GetEnumerator();
			if (!enumerator.MoveNext())
			{
				break;
			}
			do
			{
				LISTandID current = enumerator.Current;
				if (Lists[current.Int32_0].bMatters)
				{
					string desc = Stage.descriptions_old[num2];
					Descriptions.Change(current.id, desc);
				}
				num2++;
			}
			while (enumerator.MoveNext());
			break;
		}
		}
		GC.KeepAlive(this);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	private bool method_0(AH_ACTIONS ah_ACTIONS_0)
	{
		int num = 0;
		try
		{
			if (History == null)
			{
				History = new List<HISTORYSTAGE>();
			}
			num = 1;
			HISTORYSTAGE stage = Stage;
			if (stage != null && stage.action == (AH_ACTIONS)8 && ah_ACTIONS_0 == (AH_ACTIONS)8 && !IsSubStagesComplete)
			{
				return false;
			}
			num = 2;
			if (!IsStageComplete)
			{
				CancelLastStage(cancelSuperStage: false);
			}
			num = 3;
			HISTORYSTAGE stage2 = Stage;
			if (stage2 != null && stage2.SubStages != null && !IsSubStagesComplete)
			{
				num = 4;
				HISTORYSTAGE hISTORYSTAGE = stage2;
				(Stage = new HISTORYSTAGE(ah_ACTIONS_0)).IsSubStage = true;
				num = 5;
				hISTORYSTAGE.SubStages.Add(Stage);
				hISTORYSTAGE.SubStageIndex = hISTORYSTAGE.SubStages.Count - 1;
				goto IL_01b1;
			}
			num = 8;
			int num2 = History.Count - 1;
			if (CurrentStageIndex < num2)
			{
				method_2();
			}
			num = 9;
			if (CommonStorage.Params.ActionsHistoryLimit > 0)
			{
				int actionsHistoryLimit = CommonStorage.Params.ActionsHistoryLimit;
				if (History.Count >= actionsHistoryLimit)
				{
					int prevStageIndex = PrevStageIndex;
					if (prevStageIndex > 0)
					{
						PrevStageIndex = prevStageIndex - 1;
					}
					int savedStage = SavedStage;
					if (savedStage > 0)
					{
						SavedStage = savedStage - 1;
					}
					num = 10;
					method_1(History[0]);
					History.RemoveAt(0);
					goto IL_0162;
				}
			}
			CurrentStageIndex++;
			goto IL_0162;
			IL_0162:
			num = 11;
			HISTORYSTAGE item = (Stage = new HISTORYSTAGE(ah_ACTIONS_0));
			History.Add(item);
			int num3 = (CurrentStageIndex = History.Count - 1);
			if (SavedStage > num3)
			{
				SavedStage = num3;
			}
			goto IL_01b1;
			IL_01b1:
			num = 13;
			Stage.UserIndex = UserIndex;
			DateTime utcNow = DateTime.UtcNow;
			Stage.TimeStamp = ACE.RSGlobal.RSGlobal.DateTime2Timestamp(utcNow);
			Stage.action = ah_ACTIONS_0;
			if (LastStageID == uint.MaxValue)
			{
				LastStageID = 0u;
			}
			uint stage_id = ++LastStageID;
			Stage.stage_id = stage_id;
			return true;
		}
		catch (Exception ex)
		{
			string value = Class16.smethod_0(1648930360);
			string key = Class16.smethod_0(1648930414);
			ex.Data.Add(key, value);
			string key2 = Class16.smethod_0(1648930426);
			ex.Data.Add(key2, num);
			int currentStageIndex = CurrentStageIndex;
			string key3 = Class16.smethod_0(1648930440);
			ex.Data.Add(key3, currentStageIndex);
			int actionsHistoryLimit2 = CommonStorage.Params.ActionsHistoryLimit;
			string key4 = Class16.smethod_0(1648930464);
			ex.Data.Add(key4, actionsHistoryLimit2);
			string text = Class16.smethod_0(1648934564) + ex.Message + Class16.smethod_0(1648934582) + ex.StackTrace + Class16.smethod_0(1648934604);
			foreach (DictionaryEntry datum in ex.Data)
			{
				text += string.Format(Class16.smethod_0(1648934622), datum.Key, datum.Value);
			}
			SentryHelper.CaptureException(ex, Class16.smethod_0(1648930490));
			DKBox.Show(text, Class16.smethod_0(1648930523), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			CancelLastStage(cancelSuperStage: true);
			return method_0(ah_ACTIONS_0);
		}
	}

	private void method_1(HISTORYSTAGE historystage_0)
	{
		switch (historystage_0.action)
		{
		case (AH_ACTIONS)8:
		{
			string text5 = Class16.smethod_0(1648927580);
			string uniqueID3 = UniqueID;
			string text6 = Class16.smethod_0(1648928069);
			ACE.RSGlobal.RSGlobal.DeleteIfExists(string.Concat(string.Concat(string.Concat(Application.StartupPath + text6, uniqueID3), text5), historystage_0.GetSubStagesFileName()));
			break;
		}
		case (AH_ACTIONS)5:
		{
			string text = Class16.smethod_0(1648927580);
			string uniqueID = UniqueID;
			string text2 = Class16.smethod_0(1648928069);
			ACE.RSGlobal.RSGlobal.DeleteIfExists(string.Concat(string.Concat(string.Concat(Application.StartupPath + text2, uniqueID), text), historystage_0.GetStageUndoFileName()));
			string text3 = Class16.smethod_0(1648927580);
			string uniqueID2 = UniqueID;
			string text4 = Class16.smethod_0(1648928069);
			ACE.RSGlobal.RSGlobal.DeleteIfExists(string.Concat(string.Concat(string.Concat(Application.StartupPath + text4, uniqueID2), text3), historystage_0.GetStageRedoFileName()));
			break;
		}
		}
		GC.KeepAlive(this);
	}

	private void method_2()
	{
		int num = CurrentStageIndex + 1;
		if (num < History.Count)
		{
			do
			{
				method_1(History[num]);
				num++;
			}
			while (num < History.Count);
		}
		int currentStageIndex = CurrentStageIndex;
		int count = History.Count - currentStageIndex - 1;
		History.RemoveRange(currentStageIndex + 1, count);
		CurrentStageIndex = History.Count - 1;
		GC.KeepAlive(this);
	}

	public static void SaveHistoryAsync(object data)
	{
		if (!(data is ACTION_HISTORY aCTION_HISTORY) || !Monitor.TryEnter(object_0))
		{
			return;
		}
		ACE.RSGlobal.RSGlobal.antirecurse_SaveHistoryAsync_ACTION_HISTORY = true;
		string text = null;
		try
		{
			string text2 = smethod_3(aCTION_HISTORY.FileName);
			if (string.IsNullOrWhiteSpace(text2))
			{
				SentryHelper.CaptureMessage(Class16.smethod_0(1648930563), (SentryLevel)2, Class16.smethod_0(1648930646));
				return;
			}
			string directoryName = System.IO.Path.GetDirectoryName(text2);
			if (!string.IsNullOrWhiteSpace(directoryName))
			{
				Directory.CreateDirectory(directoryName);
			}
			text = smethod_4(text2);
			ACE.RSGlobal.RSGlobal.DeleteIfExists(text);
			FileStream fileStream = new FileStream(text, FileMode.Create, FileAccess.Write, FileShare.None);
			try
			{
				new BinaryFormatter().Serialize(fileStream, aCTION_HISTORY);
				fileStream.Flush();
			}
			finally
			{
				((IDisposable)fileStream).Dispose();
			}
			if (!File.Exists(text) || new FileInfo(text).Length <= 0L)
			{
				throw new IOException(Class16.smethod_0(1648930681));
			}
			smethod_5(text, text2);
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1648930749));
			if (ex.GetType() != typeof(ThreadAbortException))
			{
				ACE.RSGlobal.RSGlobal.ShowHandledException(ex);
			}
		}
		finally
		{
			if (!string.IsNullOrWhiteSpace(text))
			{
				ACE.RSGlobal.RSGlobal.DeleteIfExists(text);
			}
			ACE.RSGlobal.RSGlobal.antirecurse_SaveHistoryAsync_ACTION_HISTORY = false;
			Monitor.Exit(object_0);
		}
	}

	private static string smethod_3(string string_0)
	{
		if (string.IsNullOrWhiteSpace(string_0))
		{
			return null;
		}
		if (string_0.IndexOfAny(System.IO.Path.GetInvalidPathChars()) >= 0)
		{
			return null;
		}
		try
		{
			return System.IO.Path.GetFullPath(string_0);
		}
		catch
		{
			return null;
		}
	}

	private static string smethod_4(string string_0)
	{
		string directoryName = System.IO.Path.GetDirectoryName(string_0);
		string fileName = System.IO.Path.GetFileName(string_0);
		string text = fileName + Class16.smethod_0(1648928036) + Guid.NewGuid().ToString(Class16.smethod_0(1648930778)) + Class16.smethod_0(1648930786);
		if (!string.IsNullOrWhiteSpace(directoryName))
		{
			return System.IO.Path.Combine(directoryName, text);
		}
		return text;
	}

	private static void smethod_5(string string_0, string string_1)
	{
		if (!string.IsNullOrWhiteSpace(string_0) && !string.IsNullOrWhiteSpace(string_1))
		{
			if (string.Equals(string_0, string_1, StringComparison.OrdinalIgnoreCase))
			{
				throw new IOException(Class16.smethod_0(1648929823));
			}
			if (File.Exists(string_1))
			{
				File.Replace(string_0, string_1, null, ignoreMetadataErrors: true);
			}
			else
			{
				File.Move(string_0, string_1);
			}
			return;
		}
		throw new IOException(Class16.smethod_0(1648930805));
	}
}
