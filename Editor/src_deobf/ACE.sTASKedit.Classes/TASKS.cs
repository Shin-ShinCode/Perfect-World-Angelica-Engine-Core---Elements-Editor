using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Classes.ACE;
using ACE.Cpk;
using ACE.License;
using ACE.RSGlobal;
using ACE.Settings;
using ACE.sTASKedit.tasks;
using ACE.sTASKedit.tasks.tasks.data;

namespace ACE.sTASKedit.Classes;

public class TASKS
{
	public static CommonStorage CStorage;

	public static List<Bitmap> Images;

	public static ImageList QuestImageList;

	public static Dictionary<int, string> TaskTypes;

	public int Count;

	public bool FileChanged;

	public bool FileLoaded;

	public string FileName;

	public IDictionary<int, QUEST_INFO> infos;

	public IDictionary<int, ATaskTempl> quests;

	public ATaskTempl[] QuestsArray;

	public QUEST_INFO[] QuestsInfo;

	public DateTime TimeChange;

	public int TimeStamp;

	public bool UnknownVersion;

	public int version;

	private bool bool_0;

	public TASKS(string filename)
	{
		FileLoaded = false;
		FileName = filename;
		try
		{
			FileStream fileStream = File.OpenRead(filename);
			BinaryReader binaryReader = new BinaryReader(fileStream);
			TimeStamp = binaryReader.ReadInt32();
			int num = (((version = binaryReader.ReadInt32()) == 123 && (CommonStorage.License.GetFeatureEntitlementsByName(Class16.smethod_0(1648893727)) || LICENSE_INFO.Info.LicenseType == LICENSE_TYPE.DEV)) ? 1 : 0);
			byte b = (byte)num;
			bool_0 = b != 0;
			if (b != 0)
			{
				version = 102;
			}
			int num2 = version;
			if (GlobalData.Versions.Contains(num2) && version != 146)
			{
				if (version > GlobalData.GetMaxAllowedTaskVersion())
				{
					UnknownVersion = true;
					binaryReader.Close();
					fileStream.Close();
					GC.KeepAlive(this);
					return;
				}
				if ((Count = binaryReader.ReadInt32()) < 0)
				{
					UnknownVersion = true;
					binaryReader.Close();
					fileStream.Close();
					GC.KeepAlive(this);
					return;
				}
				if (version >= 223)
				{
					GlobalData.data_size = binaryReader.ReadInt32();
				}
				Stream baseStream = binaryReader.BaseStream;
				long num3 = Count << 2;
				baseStream.Position += num3;
				QuestsArray = method_0(Count, binaryReader, version);
			}
			else
			{
				UnknownVersion = true;
			}
			binaryReader.Close();
			fileStream.Close();
			try
			{
				TimeChange = File.GetLastWriteTime(FileName);
			}
			catch (UnauthorizedAccessException ex)
			{
				SentryHelper.CaptureException(ex, Class16.smethod_0(1649254524));
				TimeChange = DateTime.MinValue;
			}
			catch (IOException ex2)
			{
				SentryHelper.CaptureException(ex2, Class16.smethod_0(1649254524));
				TimeChange = DateTime.MinValue;
			}
			QuestsInfo = null;
			IDictionary<int, ATaskTempl> dictionary = quests;
			FileLoaded = ((dictionary != null && dictionary.Count != 0) ? true : false);
		}
		catch (Exception ex3)
		{
			SentryHelper.CaptureException(ex3, Class16.smethod_0(1649254559));
			throw;
		}
		GC.KeepAlive(this);
	}

	public static QUEST_INFO GetQuestInfo(ATaskTempl ataskTempl_0, int version, [MarshalAs(UnmanagedType.U1)] bool addSubQuestText)
	{
		QUEST_INFO qUEST_INFO = new QUEST_INFO
		{
			id = ataskTempl_0.ID,
			color = Color.White
		};
		RSCommon.ParseNameAndColor(ataskTempl_0.Name, ref qUEST_INFO.name, ref qUEST_INFO.color);
		qUEST_INFO.name = qUEST_INFO.name.Split(default(char))[0];
		if (addSubQuestText && ataskTempl_0.m_ulParent > 0)
		{
			qUEST_INFO.name += Class16.smethod_0(1649254569);
		}
		var (color, num) = smethod_0(ataskTempl_0.m_ulType, version, qUEST_INFO.color);
		if (ataskTempl_0.m_bKeyTask)
		{
			color = Color.FromArgb(238, 156, 15);
			num = 2;
		}
		if (ataskTempl_0.m_bGM)
		{
			num = 12;
		}
		if (ataskTempl_0.m_bShowByLev && ataskTempl_0.m_ulPremise_Lev_Min == 999 && ataskTempl_0.m_ulPremise_Lev_Max == 999)
		{
			color = Color.LightGray;
		}
		if (color != Color.White)
		{
			qUEST_INFO.color = color;
		}
		qUEST_INFO.ImageIndex = num;
		if (Images == null || num < 0 || num >= Images.Count)
		{
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649254587)) + Class16.smethod_0(1648941987) + num, Class16.smethod_0(1648934892), MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		qUEST_INFO.image = Images[num];
		return qUEST_INFO;
	}

	private static (Color, int) smethod_0(int int_0, int int_1, Color color_0)
	{
		Dictionary<int, (Color, int)> dictionary = new Dictionary<int, (Color, int)>
		{
			{
				0,
				(Color.White, 0)
			},
			{
				1,
				(Color.White, 8)
			},
			{
				6,
				(Color.White, 4)
			},
			{
				9,
				(Color.White, 6)
			},
			{
				11,
				(Color.White, 6)
			},
			{
				100,
				((int_1 >= 120) ? Color.FromArgb(100, 185, 250) : Color.White, 8)
			},
			{
				101,
				((int_1 >= 120) ? Color.FromArgb(238, 156, 15) : Color.White, 0)
			},
			{
				102,
				((int_1 >= 120) ? Color.FromArgb(255, 150, 255) : Color.White, 10)
			},
			{
				104,
				((int_1 >= 120) ? Color.FromArgb(255, 255, 0) : Color.White, 8)
			},
			{
				105,
				((int_1 < 120 || !(color_0 == Color.White)) ? color_0 : Color.FromArgb(180, 180, 255), 6)
			},
			{
				106,
				((int_1 >= 120) ? Color.FromArgb(0, 200, 200) : Color.White, 4)
			},
			{
				107,
				((int_1 >= 120) ? Color.FromArgb(120, 255, 120) : Color.White, 4)
			},
			{
				108,
				((int_1 < 120) ? Color.White : ((int_1 < 126) ? Color.FromArgb(255, 120, 120) : Color.FromArgb(255, 0, 0)), 0)
			},
			{
				109,
				((int_1 >= 120) ? Color.FromArgb(146, 255, 216) : Color.White, 0)
			},
			{
				110,
				((int_1 < 120 || !(color_0 == Color.White)) ? color_0 : Color.FromArgb(255, 120, 120), 0)
			},
			{
				111,
				((int_1 < 120 || !(color_0 == Color.White)) ? color_0 : Color.FromArgb(255, 120, 120), 0)
			},
			{
				112,
				((int_1 < 120 || !(color_0 == Color.White)) ? color_0 : Color.FromArgb(255, 120, 120), 0)
			},
			{
				113,
				((int_1 < 120 || !(color_0 == Color.White)) ? color_0 : Color.FromArgb(255, 120, 120), 0)
			},
			{
				114,
				((int_1 < 120 || !(color_0 == Color.White)) ? color_0 : Color.FromArgb(255, 120, 120), 0)
			},
			{
				115,
				((int_1 < 120 || !(color_0 == Color.White)) ? color_0 : Color.FromArgb(255, 120, 120), 0)
			}
		};
		if (!dictionary.TryGetValue(int_0, out var value))
		{
			return (Color.White, 0);
		}
		return value;
	}

	public static void InitTaskTypes()
	{
		TaskTypes = new Dictionary<int, string>();
		Dictionary<int, string> dictionary = new Dictionary<int, string>
		{
			{
				0,
				Class16.smethod_0(1649007069)
			},
			{
				1,
				Class16.smethod_0(1649254624)
			},
			{
				2,
				Class16.smethod_0(1649254644)
			},
			{
				3,
				Class16.smethod_0(1649254664)
			},
			{
				4,
				Class16.smethod_0(1649254675)
			},
			{
				5,
				Class16.smethod_0(1649073467)
			},
			{
				6,
				Class16.smethod_0(1649254691)
			},
			{
				7,
				Class16.smethod_0(1649254704)
			},
			{
				8,
				Class16.smethod_0(1649254720)
			},
			{
				9,
				Class16.smethod_0(1649254741)
			},
			{
				10,
				Class16.smethod_0(1649254746)
			},
			{
				11,
				Class16.smethod_0(1649254768)
			},
			{
				12,
				Class16.smethod_0(1649171765)
			},
			{
				100,
				Class16.smethod_0(1649254796)
			},
			{
				101,
				Class16.smethod_0(1649254815)
			},
			{
				102,
				Class16.smethod_0(1649254825)
			},
			{
				103,
				Class16.smethod_0(1649254843)
			},
			{
				104,
				Class16.smethod_0(1649254869)
			},
			{
				105,
				Class16.smethod_0(1649254746)
			},
			{
				106,
				Class16.smethod_0(1649254873)
			},
			{
				107,
				Class16.smethod_0(1649254691)
			},
			{
				108,
				Class16.smethod_0(1649254895)
			},
			{
				109,
				Class16.smethod_0(1649254908)
			},
			{
				110,
				Class16.smethod_0(1649257984)
			},
			{
				111,
				Class16.smethod_0(1649258000)
			},
			{
				112,
				Class16.smethod_0(1649258021)
			},
			{
				113,
				Class16.smethod_0(1649151124)
			},
			{
				114,
				Class16.smethod_0(1649258025)
			},
			{
				115,
				Class16.smethod_0(1649258045)
			}
		};
		bool flag = ((LANG_INFO.CurrentLang == null) ? Class16.smethod_0(1648931959) : LANG_INFO.CurrentLang.Prefix) == Class16.smethod_0(1648932072);
		foreach (KeyValuePair<int, string> item in dictionary)
		{
			TaskTypes.Add(item.Key, flag ? smethod_1(item.Value) : item.Value);
		}
	}

	public static void LoadImageList()
	{
		try
		{
			Images = new List<Bitmap>();
			string text = Class16.smethod_0(1649258049);
			Images.Add(ACE.RSGlobal.RSGlobal.LoadImageW(Application.StartupPath + text));
			string text2 = Class16.smethod_0(1649258090);
			Images.Add(ACE.RSGlobal.RSGlobal.LoadImageW(Application.StartupPath + text2));
			string text3 = Class16.smethod_0(1649258131);
			Images.Add(ACE.RSGlobal.RSGlobal.LoadImageW(Application.StartupPath + text3));
			string text4 = Class16.smethod_0(1649258180);
			Images.Add(ACE.RSGlobal.RSGlobal.LoadImageW(Application.StartupPath + text4));
			string text5 = Class16.smethod_0(1649258221);
			Images.Add(ACE.RSGlobal.RSGlobal.LoadImageW(Application.StartupPath + text5));
			string text6 = Class16.smethod_0(1649258262);
			Images.Add(ACE.RSGlobal.RSGlobal.LoadImageW(Application.StartupPath + text6));
			string text7 = Class16.smethod_0(1649258303);
			Images.Add(ACE.RSGlobal.RSGlobal.LoadImageW(Application.StartupPath + text7));
			string text8 = Class16.smethod_0(1649258336);
			Images.Add(ACE.RSGlobal.RSGlobal.LoadImageW(Application.StartupPath + text8));
			string text9 = Class16.smethod_0(1649258377);
			Images.Add(ACE.RSGlobal.RSGlobal.LoadImageW(Application.StartupPath + text9));
			string text10 = Class16.smethod_0(1649258418);
			Images.Add(ACE.RSGlobal.RSGlobal.LoadImageW(Application.StartupPath + text10));
			string text11 = Class16.smethod_0(1649258459);
			Images.Add(ACE.RSGlobal.RSGlobal.LoadImageW(Application.StartupPath + text11));
			string text12 = Class16.smethod_0(1649257484);
			Images.Add(ACE.RSGlobal.RSGlobal.LoadImageW(Application.StartupPath + text12));
			string text13 = Class16.smethod_0(1649257525);
			Images.Add(ACE.RSGlobal.RSGlobal.LoadImageW(Application.StartupPath + text13));
			QuestImageList = new ImageList();
			Size imageSize = new Size(16, 16);
			QuestImageList.ImageSize = imageSize;
			QuestImageList.ColorDepth = ColorDepth.Depth32Bit;
			ImageList.ImageCollection images = QuestImageList.Images;
			Image[] images2 = Images.ToArray();
			images.AddRange(images2);
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649257565));
			string text14 = Class16.smethod_0(1648941447);
			string text15 = string.Concat(Class16.smethod_0(1649260060) + ex.Message, text14);
			DKBox.Show(text15, Class16.smethod_0(1648934892), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
	}

	public ATaskTempl AddTaskFromFile(string FileName)
	{
		TASKS tASKS = new TASKS(FileName);
		ATaskTempl aTaskTempl = null;
		if (tASKS.FileLoaded)
		{
			ATaskTempl[] questsArray = tASKS.QuestsArray;
			if ((nint)questsArray.LongLength > 0)
			{
				aTaskTempl = questsArray[0];
				aTaskTempl.ID = GetFreeID();
				ATaskTempl[] questsArray2 = QuestsArray;
				int num = questsArray2.Length;
				ATaskTempl[] array = new ATaskTempl[num + 1];
				Array.Copy(questsArray2, 0, array, 1, num);
				array[0] = aTaskTempl;
				QuestsArray = array;
				Count++;
				FileChanged = true;
			}
		}
		return aTaskTempl;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool ChangeValueFromReference(REFERENCE_TYPE_EX RefType, ref REFERENCE_ENTRY reference, int new_id, string val1, string val2, [MarshalAs(UnmanagedType.U1)] bool bRemove)
	{
		ATaskTempl value = null;
		if (!quests.TryGetValue(reference.id, out value))
		{
			GC.KeepAlive(this);
			return false;
		}
		REFERENCE_ENTRY rEFERENCE_ENTRY = reference;
		ref object oParent = ref rEFERENCE_ENTRY.oParent;
		object obj2;
		if (oParent != null)
		{
			int int_ = rEFERENCE_ENTRY.indices.int_0;
			object obj = null;
			obj2 = null;
			if (val1 != null)
			{
				obj = int.Parse(val1);
			}
			if (val2 != null)
			{
				obj2 = float.Parse(val2);
			}
			Type type = oParent.GetType();
			if (type == typeof(ITEM_WANTED[]))
			{
				ref ITEM_WANTED reference2 = ref ((ITEM_WANTED[])oParent)[int_];
				if (new_id > -1)
				{
					reference2.m_ulItemTemplId = new_id;
				}
				if (obj != null)
				{
					reference2.m_ulItemNum = (int)obj;
				}
				if (obj2 != null)
				{
					reference2.m_fProb = (float)obj2;
				}
			}
			else if (type == typeof(AWARD_MONSTERS_SUMMONED))
			{
				ref MONSTERS_SUMMONED reference3 = ref ((AWARD_MONSTERS_SUMMONED)oParent).m_Monsters[int_];
				if (new_id > -1)
				{
					reference3.m_ulMonsterTemplId = new_id;
				}
				if (obj != null)
				{
					reference3.m_ulMonsterNum = (int)obj;
				}
				if (obj2 != null)
				{
					reference3.m_fSummonProb = (float)obj2;
				}
			}
			else if (type == typeof(TITLE_AWARD[]))
			{
				TITLE_AWARD[] array = (TITLE_AWARD[])oParent;
				if (new_id > -1)
				{
					array[int_].m_ulTitleID = new_id;
				}
			}
			else if (type == typeof(MONSTER_WANTED[]))
			{
				ref MONSTER_WANTED reference4 = ref ((MONSTER_WANTED[])oParent)[int_];
				ReferenceSubType subType = RefType.SubType;
				if (subType == ReferenceSubType.TASKS_MONSTER_WANTED_MONSTERS)
				{
					if (new_id > -1)
					{
						reference4.m_ulMonsterTemplId = new_id;
					}
					if (obj == null)
					{
						goto IL_034d;
					}
					reference4.m_ulMonsterNum = (int)obj;
				}
				else if (subType == ReferenceSubType.TASKS_MONSTER_WANTED_ITEMS)
				{
					if (new_id > -1)
					{
						reference4.m_ulDropItemId = new_id;
					}
					if (obj == null)
					{
						goto IL_034d;
					}
					reference4.m_ulDropItemCount = (int)obj;
				}
			}
			else if (type == typeof(MONSTERS_CONTRIB[]))
			{
				MONSTERS_CONTRIB[] array2 = (MONSTERS_CONTRIB[])oParent;
				if (new_id > -1)
				{
					array2[int_].m_ulMonsterTemplId = new_id;
				}
			}
			else if (type == typeof(PLAYER_WANTED[]))
			{
				ref PLAYER_WANTED reference5 = ref ((PLAYER_WANTED[])oParent)[int_];
				if (new_id > -1)
				{
					reference5.m_ulDropItemId = new_id;
				}
				if (obj == null)
				{
					goto IL_034d;
				}
				reference5.m_ulDropItemCount = (int)obj;
			}
			else if (type == typeof(HOME_ITEM_WANTED[]))
			{
				ref HOME_ITEM_WANTED reference6 = ref ((HOME_ITEM_WANTED[])oParent)[int_];
				if (new_id > -1)
				{
					reference6.m_ulHomeItemTid = new_id;
				}
				if (obj == null)
				{
					goto IL_034d;
				}
				reference6.m_ulHomeItemCount = (int)obj;
			}
			else if (type == typeof(AWARD_PQ_RANKING))
			{
				ref RANKING_AWARD reference7 = ref ((AWARD_PQ_RANKING)oParent).m_RankingAward[int_];
				if (new_id > -1)
				{
					reference7.m_ulAwardItemId = new_id;
				}
				if (obj == null)
				{
					goto IL_034d;
				}
				reference7.m_ulAwardItemNum = (int)obj;
			}
			else if (type == typeof(int[]))
			{
				int[] array3 = (int[])oParent;
				if (new_id > -1)
				{
					array3[int_] = new_id;
				}
			}
			else
			{
				DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649257591)) + Class16.smethod_0(1648941987) + type.ToString(), Class16.smethod_0(1648934892), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			if (obj != null)
			{
				reference.extra_value1 = obj;
			}
			goto IL_034d;
		}
		switch (RefType.SubType)
		{
		default:
			switch (rEFERENCE_ENTRY.indices.int_0)
			{
			case 16777202:
				value.m_AwByItems_F.m_ulItemId = new_id;
				break;
			case 16777201:
				value.m_AwByItems_S.m_ulItemId = new_id;
				break;
			}
			break;
		case ReferenceSubType.TASKS_TM_BIND_CARRTER_ID:
			value.m_ulBindOnCarrierId = new_id;
			break;
		case ReferenceSubType.TASKS_AWARD_NPC:
			value.m_ulAwardNPC = new_id;
			break;
		case ReferenceSubType.TASKS_DELV_NPC:
			value.m_ulDelvNPC = new_id;
			break;
		}
		goto IL_03d5;
		IL_034d:
		if (obj2 != null)
		{
			reference.extra_value2 = obj2;
		}
		goto IL_03d5;
		IL_03d5:
		FileChanged = true;
		return true;
	}

	public ATaskTempl[] GetAllQuests()
	{
		IDictionary<int, ATaskTempl> dictionary = quests;
		if (dictionary == null)
		{
			return null;
		}
		ATaskTempl[] array = new ATaskTempl[dictionary.Count];
		quests.Values.CopyTo(array, 0);
		GC.KeepAlive(this);
		return array;
	}

	public int GetFreeID()
	{
		ATaskTempl[] questsArray = QuestsArray;
		int num = (int)((nint)questsArray.LongLength - 1);
		int iD = questsArray[num].ID;
		int num2 = ((QuestsArray[0].ID <= iD) ? QuestsArray[num].ID : QuestsArray[0].ID) + 1;
		if (!IsFreeID(QuestsArray, num2))
		{
			do
			{
				num2++;
			}
			while (!IsFreeID(QuestsArray, num2));
		}
		return num2;
	}

	public ATaskTempl GetQuest(int id)
	{
		ATaskTempl value = null;
		quests?.TryGetValue(id, out value);
		GC.KeepAlive(this);
		return value;
	}

	public QUEST_INFO GetQuestInfo(int id)
	{
		ATaskTempl value = null;
		IDictionary<int, ATaskTempl> dictionary = quests;
		if (dictionary != null && dictionary.TryGetValue(id, out value))
		{
			QUEST_INFO questInfo = GetQuestInfo(value, version, addSubQuestText: true);
			GC.KeepAlive(this);
			return questInfo;
		}
		GC.KeepAlive(this);
		return null;
	}

	public string GetTaskName(int id)
	{
		if (id == 0)
		{
			return Class16.smethod_0(1648924410);
		}
		QUEST_INFO value = null;
		IDictionary<int, QUEST_INFO> dictionary = infos;
		if (dictionary != null && !dictionary.TryGetValue(id, out value))
		{
			value = GetQuestInfo(id);
		}
		if (value != null)
		{
			return value.name;
		}
		object[] vars = new object[1] { id };
		string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1649257623), vars);
		GC.KeepAlive(this);
		return text;
	}

	public QUEST_INFO[] GetTasksInfo()
	{
		IDictionary<int, ATaskTempl> dictionary = quests;
		if (dictionary == null)
		{
			return null;
		}
		QUEST_INFO[] questsInfo = QuestsInfo;
		if (questsInfo != null)
		{
			return questsInfo;
		}
		QuestsInfo = new QUEST_INFO[dictionary.Count];
		infos = new Dictionary<int, QUEST_INFO>(quests.Count);
		int num = 0;
		foreach (KeyValuePair<int, ATaskTempl> quest in quests)
		{
			ValueType valueType = quest;
			ATaskTempl value = ((KeyValuePair<int, ATaskTempl>)(object)valueType).Value;
			QUEST_INFO questInfo = GetQuestInfo(value, version, addSubQuestText: true);
			QuestsInfo[num] = questInfo;
			num++;
			infos.Add(((KeyValuePair<int, ATaskTempl>)(object)valueType).Key, questInfo);
		}
		GC.KeepAlive(this);
		return QuestsInfo;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsFileChanged()
	{
		int num = ((FileLoaded && quests != null && (FileChanged || IsFileOnDiscChanged())) ? 1 : 0);
		return (byte)num != 0;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsFileOnDiscChanged()
	{
		int num = 0;
		if (FileLoaded && quests != null && !string.IsNullOrWhiteSpace(FileName))
		{
			try
			{
				if (!File.Exists(FileName))
				{
					GC.KeepAlive(this);
					return true;
				}
				DateTime lastWriteTime = File.GetLastWriteTime(FileName);
				if (!TimeChange.Equals(lastWriteTime))
				{
					num = 1;
				}
			}
			catch (UnauthorizedAccessException ex)
			{
				SentryHelper.CaptureException(ex, Class16.smethod_0(1649257646));
				num = 0;
			}
			catch (IOException ex2)
			{
				SentryHelper.CaptureException(ex2, Class16.smethod_0(1649257646));
				num = 0;
			}
		}
		GC.KeepAlive(this);
		return (byte)num != 0;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsFreeID(ATaskTempl[] quests, int id)
	{
		int num = 0;
		if (0 < (nint)quests.LongLength)
		{
			do
			{
				if (quests[num].ID != id)
				{
					if (quests[num].pSub == null || (nint)quests[num].pSub.LongLength <= 0 || IsFreeID(quests[num].pSub, id))
					{
						num++;
						continue;
					}
					return false;
				}
				return false;
			}
			while (num < (nint)quests.LongLength);
		}
		GC.KeepAlive(this);
		return true;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsFreeID(int id)
	{
		return IsFreeID(QuestsArray, id);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsQuestExist(int id)
	{
		IDictionary<int, ATaskTempl> dictionary = quests;
		int num = ((dictionary != null && dictionary.ContainsKey(id)) ? 1 : 0);
		GC.KeepAlive(this);
		return (byte)num != 0;
	}

	public void JoinTasks(string Tasks2FN, [MarshalAs(UnmanagedType.U1)] bool bAddNew, [MarshalAs(UnmanagedType.U1)] bool bReplaceClassMask, [MarshalAs(UnmanagedType.U1)] bool bReplaceType)
	{
		TASKS tASKS = new TASKS(Tasks2FN);
		int num = (int)((nint)tASKS.QuestsArray.LongLength - 1);
		if (num >= 0)
		{
			do
			{
				ATaskTempl aTaskTempl = tASKS.QuestsArray[num];
				int num2 = 0;
				ATaskTempl[] questsArray = QuestsArray;
				if (0 < (nint)questsArray.LongLength)
				{
					while (questsArray[num2].ID != aTaskTempl.ID)
					{
						num2++;
						questsArray = QuestsArray;
						if (num2 < (nint)questsArray.LongLength)
						{
							continue;
						}
						goto IL_0020;
					}
					if (num2 > -1)
					{
						ATaskTempl aTaskTempl2 = QuestsArray[num2];
						if (bReplaceClassMask)
						{
							aTaskTempl2.m_Occupations = aTaskTempl.m_Occupations;
							aTaskTempl2.m_ulOccupations = aTaskTempl.m_ulOccupations;
						}
						if (bReplaceType)
						{
							aTaskTempl2.m_ulType = aTaskTempl.m_ulType;
						}
						goto IL_0030;
					}
				}
				goto IL_0020;
				IL_0030:
				num--;
				continue;
				IL_0020:
				if (bAddNew)
				{
					ACE.RSGlobal.RSGlobal.AddElementToArray(ref QuestsArray, aTaskTempl, bToBegin: true);
				}
				goto IL_0030;
			}
			while (num >= 0);
		}
		Save();
	}

	public void Save()
	{
		string temporaryPath = null;
		try
		{
			string fileName = FileName;
			CStorage?.CreateBackup(fileName);
			if (!AceNative.IsSuccess(AceNative.IsLicenseValid()))
			{
				return;
			}
			string fullPath = System.IO.Path.GetFullPath(fileName);
			string directory = System.IO.Path.GetDirectoryName(fullPath);
			temporaryPath = System.IO.Path.Combine(directory, ".ace-" + Guid.NewGuid().ToString("N") + ".tmp");
			using (FileStream fileStream = new FileStream(temporaryPath, FileMode.CreateNew, FileAccess.Write))
			using (BinaryWriter binaryWriter = new BinaryWriter(fileStream))
			{
			binaryWriter.Write(TimeStamp);
			if (bool_0)
			{
				version = 123;
			}
			binaryWriter.Write(version);
			if (bool_0)
			{
				version = 102;
			}
			binaryWriter.Write(QuestsArray.Length);
			if (version >= 223)
			{
				binaryWriter.Write(GlobalData.data_size);
			}
			int num = QuestsArray.Length;
			int[] array = new int[num];
			binaryWriter.Write(new byte[num << 2]);
			for (int i = 0; i < (nint)QuestsArray.LongLength; i++)
			{
				int num2 = (int)binaryWriter.BaseStream.Position;
				array[i] = num2;
				QuestsArray[i].Write(version, binaryWriter);
			}
			if (version >= 223)
			{
				binaryWriter.BaseStream.Position = 16L;
			}
			else
			{
				binaryWriter.BaseStream.Position = 12L;
			}
			for (int j = 0; j < (nint)array.LongLength; j++)
			{
				binaryWriter.Write(array[j]);
			}
			}
			if (File.Exists(fileName))
			{
				File.Replace(temporaryPath, fileName, null);
			}
			else
			{
				File.Move(temporaryPath, fileName);
			}
			temporaryPath = null;
			FileChanged = false;
			DateTime lastWriteTime = File.GetLastWriteTime(FileName);
			TimeChange = lastWriteTime;
		}
		catch (Exception ex)
		{
			try
			{
				if (!string.IsNullOrEmpty(temporaryPath) && File.Exists(temporaryPath)) File.Delete(temporaryPath);
			}
			catch
			{
			}
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649257678));
			DKBox.Show(ex.Message, string.Empty);
		}
		GC.KeepAlive(this);
	}

	public void UpdateTasksDict()
	{
		quests = new Dictionary<int, ATaskTempl>(Count);
		int num = 0;
		if (0 < (nint)QuestsArray.LongLength)
		{
			do
			{
				ATaskTempl aTaskTempl = QuestsArray[num];
				if (!quests.ContainsKey(aTaskTempl.ID))
				{
					quests.Add(aTaskTempl.ID, aTaskTempl);
				}
				method_1(aTaskTempl.pSub);
				num++;
			}
			while (num < (nint)QuestsArray.LongLength);
		}
		GC.KeepAlive(this);
	}

	private static string smethod_1(string string_0)
	{
		return string_0;
	}

	private ATaskTempl[] method_0(int int_0, BinaryReader binaryReader_0, int int_1)
	{
		ATaskTempl[] array = new ATaskTempl[int_0];
		quests = new Dictionary<int, ATaskTempl>(int_0);
		int num = 0;
		if (0 < int_0)
		{
			do
			{
				try
				{
					ATaskTempl aTaskTempl = (array[num] = new ATaskTempl(int_1, binaryReader_0, (int)binaryReader_0.BaseStream.Position));
					if (!quests.ContainsKey(aTaskTempl.ID))
					{
						quests.Add(aTaskTempl.ID, aTaskTempl);
					}
					method_1(aTaskTempl.pSub);
				}
				catch (EndOfStreamException)
				{
					throw;
				}
				catch (Exception ex2)
				{
					SentryHelper.CaptureException(ex2, Class16.smethod_0(1649257695));
					throw;
				}
				num++;
			}
			while (num < int_0);
		}
		GC.KeepAlive(this);
		return array;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	private bool method_1(ATaskTempl[] ataskTempl_0)
	{
		if (ataskTempl_0 != null)
		{
			int num = ataskTempl_0.Length;
			if (num > 0)
			{
				int num2 = 0;
				if (0 < num)
				{
					do
					{
						try
						{
							ATaskTempl aTaskTempl = ataskTempl_0[num2];
							if (!quests.ContainsKey(aTaskTempl.ID))
							{
								quests.Add(aTaskTempl.ID, aTaskTempl);
							}
							method_1(aTaskTempl.pSub);
						}
						catch (Exception ex)
						{
							SentryHelper.CaptureException(ex, Class16.smethod_0(1649257718));
							throw;
						}
						num2++;
					}
					while (num2 < (nint)ataskTempl_0.LongLength);
				}
				GC.KeepAlive(this);
				return true;
			}
		}
		return false;
	}
}
