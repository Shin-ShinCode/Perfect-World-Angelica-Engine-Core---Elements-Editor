using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using ACE.ActionHistory;
using ACE.Addons;
using ACE.Classes;
using ACE.Classes.ACE;
using ACE.Classes.ACE_Extra;
using ACE.Classes.ACE_Octets;
using ACE.Classes.Localization;
using ACE.Cpk;
using ACE.Elements.eList;
using ACE.ExtraDrops;
using ACE.License;
using ACE.MainWindow;
using ACE.Models;
using ACE.MppcLibrary;
using ACE.NpcGen;
using ACE.Path;
using ACE.Pck;
using ACE.Protectors;
using ACE.RSGlobal;
using ACE.Settings;
using ACE.sTASKedit.Classes;
using ACE.sTASKedit.tasks.tasks.data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sentry;

namespace ACE.Elements.eListCollection;

public class eListCollection
{
	private struct Struct54(FIELDTYPE fieldtype_1, int int_1)
	{
		public FIELDTYPE fieldtype_0 = fieldtype_1;

		public int int_0 = int_1;
	}

	private static class Class129
	{
		public static Action<int> action_0;

		public static ParameterizedThreadStart parameterizedThreadStart_0;
	}

	private struct Struct55(FIELDTYPE fieldtype_1, int int_1, ulong[] ulong_1)
	{
		public FIELDTYPE fieldtype_0 = fieldtype_1;

		public int int_0 = int_1;

		public ulong[] ulong_0 = ulong_1;
	}

	private sealed class Class130
	{
		public int int_0;

		internal int method_0(global::_003C_003Ef__AnonymousType1<string, int> _003C_003Ef__AnonymousType1_0)
		{
			return Math.Abs(_003C_003Ef__AnonymousType1_0.Version - int_0);
		}

		internal int method_1(global::_003C_003Ef__AnonymousType1<string, int> _003C_003Ef__AnonymousType1_0)
		{
			return (_003C_003Ef__AnonymousType1_0.Version >= int_0) ? 1 : 0;
		}
	}

	private struct Struct56
	{
		public uint uint_0;

		public int int_0;

		public byte[][] byte_0;
	}

	private enum Enum9
	{

	}

	[Serializable]
	private sealed class Class131
	{
		public static readonly Class131 class131_0 = new Class131();

		public static Func<KeyValuePair<string, string>, string> func_0;

		public static Func<string, global::_003C_003Ef__AnonymousType1<string, int>> func_1;

		public static Func<global::_003C_003Ef__AnonymousType1<string, int>, bool> func_2;

		public static Func<global::_003C_003Ef__AnonymousType1<string, int>, string> func_3;

		internal string method_0(KeyValuePair<string, string> keyValuePair_0)
		{
			return keyValuePair_0.Key;
		}

		internal global::_003C_003Ef__AnonymousType1<string, int> method_1(string string_0)
		{
			return _003C_003Ef__AnonymousType1.Create(
				string_0,
				smethod_15(string_0)
			);
		}

		internal bool method_2(global::_003C_003Ef__AnonymousType1<string, int> _003C_003Ef__AnonymousType1_0)
		{
			return _003C_003Ef__AnonymousType1_0.Version > 0;
		}

		internal string method_3(global::_003C_003Ef__AnonymousType1<string, int> _003C_003Ef__AnonymousType1_0)
		{
			return _003C_003Ef__AnonymousType1_0.File;
		}
	}

	private struct Struct57
	{
		public int int_0;

		public int int_1;

		public uint uint_0;
	}

	private sealed class Class132
	{
		public eListCollection eListCollection_0;

		public string string_0;

		internal string method_0(string string_1)
		{
			return System.IO.Path.Combine(Application.StartupPath, Class16.smethod_0(1648909207), eListCollection_0.GamePrefix + Class16.smethod_0(1648923968) + string_0 + Class16.smethod_0(1648923968) + string_1 + Class16.smethod_0(1648904996));
		}
	}

	public class EnumEntry
	{
		public string EnumName;

		public bool IsMask;

		public EnumMember[] Members;
	}

	public class EnumMember
	{
		public decimal Value;

		public string Name;

		public Dictionary<string, string> Translation;
	}

	public struct ListOffsetInfo(int offset, int size)
	{
		public int ListOffset = offset;

		public int ListSize = size;
	}

	public enum RECIPES_SORT_TYPE
	{
		BY_ID,
		BY_TYPE,
		BY_SUBTYPE,
		AUTO_ARMOR
	}

	public static RSCrypt SecretEncrypter;

	public static RSCrypt SecretDecrypter;

	public static CommonStorage CStorage;

	public static LICENSE_INFO License;

	public static PCK_LIST PCKs;

	public static Dictionary<string, int> CROSS_LISTS;

	public static string[] HintExcludedFields;

	public static string[] HintItemListFields;

	public Dictionary<string, string> FieldCategories;

	public bool bMultithread;

	public NPCGEN_LIST NpcGenList;

	public Dictionary<int, int[]> ShortcutItems;

	public Dictionary<int, int[]> RecentItems;

	public Dictionary<string, int> ListIndices;

	public Dictionary<string, string> ListTranslation;

	public StreamReader Localization_sr;

	public string UserCustomTypesFN;

	public string UserCustomLangFN;

	public string UserFieldSetsFN;

	public int ConfigVersion;

	public FIELDS_TRANSLATER TranslatedFieldsGlobal;

	public TASKS Tasks;

	public bool bCustomProtection;

	public bool FileLoaded;

	public ELEMENTS_PROTECTION_STATUS ProtectionStatus;

	public bool IsElementsAllowed;

	public bool IsElementsEncrypted;

	public bool IsUsersCanEditPermissions;

	public bool IsProtectionVersionNotSupported;

	public string[] AllowedLogins;

	public int ProtectionVersion;

	public ELEMENTS_CRYPTER ElementsCrypter;

	public int[] MainSimilarLists;

	public Dictionary<int, int[]> SimilarListsCache;

	public int[] ListsWithSubIcons;

	public Dictionary<int, List<int[]>> ProbFieldsSuites;

	public Dictionary<int, List<PROB_SUITE_EXTENDED>> ProbFieldsSuitesEx;

	public Dictionary<int, int[]> FieldsToEncrypt;

	public string ConfigPath;

	public NotesClass Notes;

	public Dictionary<int, ITEMINFO>[] ItemsCache;

	public List<int>[] IDsCache;

	public PATH_DATA PathData;

	public ICONS Icons;

	public Dictionary<int, int> LastAddons;

	public ID_2[] first2IDs;

	public ELEMENTS_DECODED_VALUES DecodedValues;

	public GAMES Game;

	public string GamePrefix;

	public ACTION_HISTORY ActionsHistory;

	public ITEM_EXT_DESC Descriptions;

	public ITEM_EXT_COLOR Colors;

	public bool FileChanged;

	public ParamsClass Params;

	public AddonsCollection Addons;

	public SkillsCollection Skills;

	public int[] AllLists;

	public int[] MattersLists;

	public int[] NpcMobMineLists;

	public int[] EquipmentLists;

	public int[] AllListsAndCoversations;

	public int[] NPCServicesLists;

	public int addons_l;

	public HashSet<int> MattersListsFast;

	public bool bLoadedWithErrors;

	public byte[] BytesAfterEndOfFile;

	public bool unkVersion;

	public bool badStructure;

	public List<int> StructChangedLists;

	public DBReaderClass DBReader;

	public DateTime TimeChange;

	public bool IsNewUIDCreated;

	public int ListCount;

	public int ConfigIndex;

	public int ConfigCount;

	public CONFIG_LOADING_STATUS status;

	public Dictionary<ID_SPACE, List<int>> Spaces;

	public bool isPacked;

	public int full_signature;

	public int DetectedVersion;

	public short Version;

	public short Signature;

	public uint TimeStamp;

	public uint RealTimeStamp;

	public int ConversationListIndex;

	public string ConfigFile;

	public string ConfigFile2;

	public string FileName;

	public string Elements2FileName;

	public string UniqueID;

	public ACE.Elements.eList.eList[] Lists;

	public int ItemCount;

	public bool bOnlyConfig;

	public bool domesticPW;

	public int Elements2ListStartIndex = -1;

	public int Elements2ListCount;

	public StreamReader FieldTypes_sr;

	public ACE.Elements.eList.eList _matterTemplate;

	public string MATTER_TEMPLATE;

	public Exception sharedException;

	public Dictionary<int, List<int>> MattersReferencesBase;

	private bool bool_0;

	private Dictionary<string, List<vFIELDPOS>> dictionary_0;

	public int[] MattersAnd90;

	public Dictionary<int, int[]> FieldListsCache;

	public int LastFoundedItemList;

	public bool bDontWriteOctets;

	public static Bitmap DefaultACEImage;

	public string sDefaultACEImage32;

	public string sDefaultACEImage16;

	public byte[] ComputerName = Array.Empty<byte>();

	public byte[] HardInfo = Array.Empty<byte>();

	public byte[] OrgData = Array.Empty<byte>();

	public uint tag_name;

	public uint tag_info;

	public uint ComputerTimestamp;

	public HashSet<string> MattersFields;

	public static object[] Bridge;

	public Dictionary<int, List<string>> ProbSuitesNames;

	public ELEMENTS_REFERENCES References;

	public bool bRefsGenerated;

	public HashSet<int> ListsWithItemsSet;

	private UniversalStatusHandler universalStatusHandler_0;

	public Dictionary<string, Dictionary<string, Dictionary<string, string>>> EnumsTranslations;

	public Dictionary<string, int> EnumToStrId;

	public Dictionary<int, string> StrIdToEnum;

	private ProgressHandler progressHandler_0;

	private static readonly HashSet<string> hashSet_0;

	private static readonly ulong[] ulong_0;

	private static readonly ulong[] ulong_1;

	private static readonly ulong[] ulong_2;

	private static readonly ulong[] ulong_3;

	private static readonly ulong[] ulong_4;

	private static readonly ulong[] ulong_5;

	private static readonly ulong[] ulong_6;

	private static readonly ulong[] ulong_7;

	private static readonly ulong[] ulong_8;

	private static readonly ulong[] ulong_9;

	private static readonly Struct54[] struct54_0;

	private static readonly Struct55[] struct55_0;

	private static readonly Struct54[] struct54_1;

	private static readonly Struct55[] struct55_1;

	private static readonly Struct54[] struct54_2;

	private static readonly Struct55[] struct55_2;

	private static readonly Struct54[] struct54_3;

	private static readonly Struct55[] struct55_3;

	private Font font_0;

	private Font font_1;

	private string string_0;

	public ACE.Elements.eList.eList this[string LIST_NAME]
	{
		get
		{
			int value = 0;
			if (ListIndices.TryGetValue(LIST_NAME, out value) && value < ListCount)
			{
				return Lists[value];
			}
			return null;
		}
		set
		{
			int value2 = 0;
			if (ListIndices.TryGetValue(LIST_NAME, out value2))
			{
				Lists[value2] = value;
			}
		}
	}

	public ACE.Elements.eList.eList this[int int_0]
	{
		get
		{
			return Lists[int_0];
		}
		set
		{
			Lists[int_0] = value;
		}
	}

	public object this[int int_0, int int_1, string field_name]
	{
		get
		{
			object result = Lists[int_0][int_1, field_name];
			GC.KeepAlive(this);
			return result;
		}
		set
		{
			Lists[int_0][int_1, field_name] = value;
			GC.KeepAlive(this);
		}
	}

	public object this[int int_0, int int_1, int int_2]
	{
		get
		{
			return GetValueO(int_0, int_1, int_2, bConvertString: false, bConvertShopPrice: false, bConvertHexColor: false, bConvertFloatAddon: false);
		}
		set
		{
			Lists[int_0].elementValues[int_1][int_2] = value;
		}
	}

	public bool HasElements2Lists
	{
		get
		{
			if (Elements2ListStartIndex >= 0)
			{
				return Elements2ListCount > 0;
			}
			return false;
		}
	}

	// TODO(recovered): ILSpy rendered the list-name->index lookup method get_LI(string) as a
	// malformed parameterless `LI` property whose body referenced the (undefined) LIST_NAME.
	// Restored as the method its 130+ call sites (get_LI(name)) expect.
	public int get_LI(string LIST_NAME)
	{
		int value = -1;
		if (ListIndices != null && ListIndices.TryGetValue(LIST_NAME, out value))
		{
			GC.KeepAlive(this);
			return value;
		}
		return -1;
	}

	[SpecialName]
	public event ProgressHandler OnExportProgress
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
			progressHandler_0 = (ProgressHandler)Delegate.Combine(progressHandler_0, value);
			GC.KeepAlive(this);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
			progressHandler_0 = (ProgressHandler)Delegate.Remove(progressHandler_0, value);
			GC.KeepAlive(this);
		}
	}

	[SpecialName]
	public event UniversalStatusHandler OnStatusChanged
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
			universalStatusHandler_0 = (UniversalStatusHandler)Delegate.Combine(universalStatusHandler_0, value);
			GC.KeepAlive(this);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
			universalStatusHandler_0 = (UniversalStatusHandler)Delegate.Remove(universalStatusHandler_0, value);
			GC.KeepAlive(this);
		}
	}

	public eListCollection(string elFile, [MarshalAs(UnmanagedType.U1)] bool bMultithread, [MarshalAs(UnmanagedType.U1)] bool isFirstItems)
	{
		List<int> list = null;
		this.bMultithread = false;
		ConfigVersion = 0;
		bCustomProtection = false;
		FileLoaded = false;
		addons_l = 0;
		ConfigIndex = 0;
		ConfigCount = 0;
		isPacked = false;
		RealTimeStamp = 0u;
		bOnlyConfig = false;
		domesticPW = false;
		MATTER_TEMPLATE = Class16.smethod_0(1648961498);
		bool_0 = false;
		dictionary_0 = new Dictionary<string, List<vFIELDPOS>>();
		LastFoundedItemList = -1;
		bDontWriteOctets = false;
		sDefaultACEImage16 = ACE.RSGlobal.RSGlobal.ImageToBase64(ICONS.ResizeImage(DefaultACEImage, 14, 12));
		bRefsGenerated = false;
		EnumToStrId = new Dictionary<string, int>();
		StrIdToEnum = new Dictionary<int, string>();
		this.bMultithread = bMultithread;
		bLoadedWithErrors = false;
		MattersLists = new int[0];
		MattersReferencesBase = new Dictionary<int, List<int>>();
		LoadElements(elFile, isFirstItems);
		ACE.Elements.eList.eList[] lists = Lists;
		if (lists == null)
		{
			return;
		}
		int num = lists.Length;
		bool flag;
		if (num == 0 || lists[0].elementValues == null || (!(flag = unkVersion) && sharedException != null))
		{
			return;
		}
		ListCount = num;
		if (!flag)
		{
			DecodeLogins();
		}
		else
		{
			IsElementsAllowed = true;
		}
		if (!IsElementsAllowed)
		{
			FileLoaded = false;
			Lists = null;
			if (IsProtectionVersionNotSupported)
			{
				TextStorage.TEXTS.ShowErrorMessage(511);
			}
			else
			{
				TextStorage.TEXTS.ShowErrorMessage(478);
			}
			GC.KeepAlive(this);
			return;
		}
		if (RealTimeStamp == 0)
		{
			RealTimeStamp = ACE.RSGlobal.RSGlobal.DateTime2Timestamp(TimeChange);
		}
		Encode_talk_proc();
		string langPrefix = ((LANG_INFO.CurrentLang == null) ? Class16.smethod_0(1648931959) : LANG_INFO.CurrentLang.Prefix);
		ushort file_version = (ushort)Version;
		string gamePrefix = GamePrefix;
		GAMES game = Game;
		DBReader = new DBReaderClass(CStorage, langPrefix, game, gamePrefix, file_version);
		UpdateItemCount();
		FileChanged = false;
		ItemsCache = new Dictionary<int, ITEMINFO>[(nint)Lists.LongLength];
		CreateOrGetFileUID(bNew: false);
		GAMES game2 = Game;
		if (game2 == GAMES.ROG || game2 == GAMES.TOS)
		{
			Spaces = new Dictionary<ID_SPACE, List<int>>();
			int num2 = 0;
			if (0 < ListCount)
			{
				do
				{
					if (num2 != ConversationListIndex)
					{
						ACE.Elements.eList.eList eList2 = Lists[num2];
						eList2.SpaceId = (ID_SPACE)eList2._idSpace;
						ACE.Elements.eList.eList[] lists2 = Lists;
						if (lists2[num2].SpaceId != ID_SPACE.invalid)
						{
							list = null;
							if (!Spaces.TryGetValue(lists2[num2].SpaceId, out list))
							{
								ID_SPACE spaceId = Lists[num2].SpaceId;
								Spaces.Add(spaceId, new List<int>(num2));
							}
							else
							{
								list.Add(num2);
							}
						}
					}
					num2++;
				}
				while (num2 < ListCount);
			}
		}
		int num3 = 0;
		if (0 < ListCount)
		{
			do
			{
				Lists[num3].Game = Game;
				Lists[num3].CreateFastDataTypes();
				bool bMatters = MattersListsFast != null && MattersListsFast.Contains(num3);
				GC.KeepAlive(this);
				Lists[num3].bMatters = bMatters;
				num3++;
			}
			while (num3 < ListCount);
		}
		string text = Class16.smethod_0(1648961520);
		string gamePrefix2 = GamePrefix;
		string text2 = Class16.smethod_0(1648960527);
		string path = string.Concat(string.Concat(Application.StartupPath + text2, gamePrefix2), text);
		if (File.Exists(path))
		{
			ParseFieldLimits(File.OpenText(path));
		}
		GC.KeepAlive(this);
	}

	public eListCollection(string elFile, [MarshalAs(UnmanagedType.U1)] bool bMultithread)
		: this(elFile, bMultithread, isFirstItems: false)
	{
	}

	public eListCollection(GAMES Game, short Version)
	{
		bMultithread = false;
		ConfigVersion = 0;
		bCustomProtection = false;
		FileLoaded = false;
		addons_l = 0;
		ConfigIndex = 0;
		ConfigCount = 0;
		isPacked = false;
		RealTimeStamp = 0u;
		bOnlyConfig = false;
		domesticPW = false;
		MATTER_TEMPLATE = Class16.smethod_0(1648961498);
		bool_0 = false;
		dictionary_0 = new Dictionary<string, List<vFIELDPOS>>();
		LastFoundedItemList = -1;
		bDontWriteOctets = false;
		sDefaultACEImage16 = ACE.RSGlobal.RSGlobal.ImageToBase64(ICONS.ResizeImage(DefaultACEImage, 14, 12));
		bRefsGenerated = false;
		EnumToStrId = new Dictionary<string, int>();
		StrIdToEnum = new Dictionary<int, string>();
		this.Game = Game;
		this.Version = Version;
		GamePrefix = ACE.RSGlobal.RSGlobal.GetGamePrefix(Game);
		method_0(null);
		MattersLists = new int[0];
		MattersReferencesBase = new Dictionary<int, List<int>>();
		DecodedValues = new ELEMENTS_DECODED_VALUES();
		int num = 0;
		if (0 >= (nint)Lists.LongLength)
		{
			return;
		}
		do
		{
			if (num != ConversationListIndex)
			{
				ACE.Elements.eList.eList eList2 = Lists[num];
				eList2.fieldtypes = new FIELDTYPE[(nint)eList2.elementFields.LongLength];
				method_4(num, bool_1: false);
			}
			num++;
		}
		while (num < (nint)Lists.LongLength);
	}

	public eListCollection(GAMES Game)
	{
		bMultithread = false;
		ConfigVersion = 0;
		bCustomProtection = false;
		FileLoaded = false;
		addons_l = 0;
		ConfigIndex = 0;
		ConfigCount = 0;
		isPacked = false;
		RealTimeStamp = 0u;
		bOnlyConfig = false;
		domesticPW = false;
		MATTER_TEMPLATE = Class16.smethod_0(1648961498);
		bool_0 = false;
		dictionary_0 = new Dictionary<string, List<vFIELDPOS>>();
		LastFoundedItemList = -1;
		bDontWriteOctets = false;
		sDefaultACEImage16 = ACE.RSGlobal.RSGlobal.ImageToBase64(ICONS.ResizeImage(DefaultACEImage, 14, 12));
		bRefsGenerated = false;
		EnumToStrId = new Dictionary<string, int>();
		StrIdToEnum = new Dictionary<int, string>();
		this.Game = Game;
		GamePrefix = ACE.RSGlobal.RSGlobal.GetGamePrefix(Game);
		bOnlyConfig = true;
	}

	static eListCollection()
	{
		HintExcludedFields = new string[6]
		{
			Class16.smethod_0(1648960536),
			Class16.smethod_0(1648960564),
			Class16.smethod_0(1648960582),
			Class16.smethod_0(1648960592),
			Class16.smethod_0(1648960608),
			Class16.smethod_0(1648960631)
		};
		HintItemListFields = new string[6]
		{
			Class16.smethod_0(1648960646),
			Class16.smethod_0(1648960664),
			Class16.smethod_0(1648960695),
			Class16.smethod_0(1648960724),
			Class16.smethod_0(1648960745),
			Class16.smethod_0(1648960782)
		};
		hashSet_0 = new HashSet<string>();
		ulong_0 = new ulong[2] { 1uL, 0uL };
		ulong_1 = new ulong[44]
		{
			0uL, 1uL, 2uL, 3uL, 4uL, 5uL, 6uL, 7uL, 8uL, 9uL,
			10uL, 11uL, 12uL, 13uL, 14uL, 15uL, 16uL, 17uL, 18uL, 19uL,
			25uL, 29uL, 32uL, 33uL, 34uL, 35uL, 36uL, 38uL, 39uL, 40uL,
			41uL, 42uL, 43uL, 44uL, 47uL, 48uL, 49uL, 55uL, 56uL, 57uL,
			58uL, 59uL, 60uL, 61uL
		};
		ulong_2 = new ulong[3] { 0uL, 3uL, 5uL };
		ulong_3 = new ulong[6] { 0uL, 1uL, 2uL, 3uL, 6uL, 7uL };
		ulong_4 = new ulong[8] { 0uL, 158uL, 159uL, 160uL, 161uL, 164uL, 165uL, 1402uL };
		ulong_5 = new ulong[7] { 0uL, 1uL, 3uL, 4uL, 2uL, 6uL, 7uL };
		ulong_6 = new ulong[5] { 0uL, 1uL, 3uL, 4uL, 5uL };
		ulong_7 = new ulong[7] { 48uL, 49uL, 50uL, 51uL, 52uL, 53uL, 0uL };
		ulong_8 = new ulong[14]
		{
			0uL, 1uL, 2uL, 3uL, 4uL, 5uL, 6uL, 7uL, 8uL, 9uL,
			11uL, 12uL, 13uL, 14uL
		};
		ulong_9 = new ulong[9] { 1uL, 2uL, 3uL, 4uL, 5uL, 6uL, 8uL, 9uL, 10uL };
		struct54_0 = new Struct54[5]
		{
			new Struct54(FIELDTYPE.ft_bool, 14),
			new Struct54(FIELDTYPE.monster_powerlvl, 15),
			new Struct54(FIELDTYPE.monster_attacktype, 23),
			new Struct54(FIELDTYPE.role_in_war_pw, 390),
			new Struct54(FIELDTYPE.stand_mode_pw, 830)
		};
		struct55_0 = new Struct55[1]
		{
			new Struct55(FIELDTYPE.invertedboolean, 14, ulong_0)
		};
		struct54_1 = new Struct54[3]
		{
			new Struct54(FIELDTYPE.ft_gender, 18),
			new Struct54(FIELDTYPE.npc_combined_services_jd, 684),
			new Struct54(FIELDTYPE.proc_type, 853)
		};
		struct55_1 = new Struct55[2]
		{
			new Struct55(FIELDTYPE.addontype_jd, 434, ulong_1),
			new Struct55(FIELDTYPE.sale_promotion_item_essence_condition_type, 841, ulong_2)
		};
		struct54_2 = new Struct54[6]
		{
			new Struct54(FIELDTYPE.ft_gender, 18),
			new Struct54(FIELDTYPE.equipslot_mask_fw, 117),
			new Struct54(FIELDTYPE.equip_location_fw, 118),
			new Struct54(FIELDTYPE.character_combo_id, 119),
			new Struct54(FIELDTYPE.racemask_fw, 120),
			new Struct54(FIELDTYPE.color_fw, 385)
		};
		struct55_2 = new Struct55[1]
		{
			new Struct55(FIELDTYPE.equip_type_fw, 116, ulong_3)
		};
		struct54_3 = new Struct54[35]
		{
			new Struct54(FIELDTYPE.ft_gender, 16),
			new Struct54(FIELDTYPE.ft_fixed_props, 17),
			new Struct54(FIELDTYPE.monster_enviroment, 24),
			new Struct54(FIELDTYPE.monster_bonus, 25),
			new Struct54(FIELDTYPE.damage_type, 29),
			new Struct54(FIELDTYPE.fly_mode, 82),
			new Struct54(FIELDTYPE.character_combo_id, 79),
			new Struct54(FIELDTYPE.npc_combined_services, 9),
			new Struct54(FIELDTYPE.npc_combined_services2, 81),
			new Struct54(FIELDTYPE.npc_combined_services3, 9900),
			new Struct54(FIELDTYPE.npc_faction_combined_services, 9901),
			new Struct54(FIELDTYPE.ft_title_name_pos, 9902),
			new Struct54(FIELDTYPE.refine_type, 178),
			new Struct54(FIELDTYPE.equipslot_mask, 83),
			new Struct54(FIELDTYPE.monster_immunity, 84),
			new Struct54(FIELDTYPE.congregate_type, 416),
			new Struct54(FIELDTYPE.monster_faction_mask_pw, 391),
			new Struct54(FIELDTYPE.dye_type, 443),
			new Struct54(FIELDTYPE.refine_binding_only, 444),
			new Struct54(FIELDTYPE.food_mask, 446),
			new Struct54(FIELDTYPE.stone_combined_switch_pw, 690),
			new Struct54(FIELDTYPE.pet_combined_switch_pw, 691),
			new Struct54(FIELDTYPE.target_item_combined_switch_pw, 692),
			new Struct54(FIELDTYPE.monster_combined_switch, 471),
			new Struct54(FIELDTYPE.short_range_mode, 527),
			new Struct54(FIELDTYPE.npc_combined_switch, 528),
			new Struct54(FIELDTYPE.after_death_pw, 831),
			new Struct54(FIELDTYPE.highest_frequency_pw, 832),
			new Struct54(FIELDTYPE.ft_gender2, 18),
			new Struct54(FIELDTYPE.autoteam_combined_switch_pw, 833),
			new Struct54(FIELDTYPE.autoteam_type_pw, 834),
			new Struct54(FIELDTYPE.autoteam_time_type_pw, 927),
			new Struct54(FIELDTYPE.week_pw, 929),
			new Struct54(FIELDTYPE.proc_type, 836),
			new Struct54(FIELDTYPE.mid_param_num, 926)
		};
		struct55_3 = new Struct55[6]
		{
			new Struct55(FIELDTYPE.prof_requirements, 19, ulong_4),
			new Struct55(FIELDTYPE.equipslot, 20, ulong_5),
			new Struct55(FIELDTYPE.crafttype, 21, ulong_6),
			new Struct55(FIELDTYPE.monster_element, 22, ulong_7),
			new Struct55(FIELDTYPE.weapons_attacktype, 26, ulong_8),
			new Struct55(FIELDTYPE.styletype, 28, ulong_9)
		};
		string text = Class16.smethod_0(1648960803);
		DefaultACEImage = ACE.RSGlobal.RSGlobal.LoadImageW(Application.StartupPath + text);
	}

	private CONFIG_LOADING_STATUS method_0(BinaryReader binaryReader_0)
	{
		if (method_13(binaryReader_0) == CONFIG_LOADING_STATUS.Success)
		{
			return CONFIG_LOADING_STATUS.Success;
		}
		int num = 0;
		CONFIG_LOADING_STATUS cONFIG_LOADING_STATUS;
		do
		{
			if (binaryReader_0 != null)
			{
				binaryReader_0.BaseStream.Position = 0L;
			}
			cONFIG_LOADING_STATUS = method_13(binaryReader_0);
			num++;
		}
		while (cONFIG_LOADING_STATUS == CONFIG_LOADING_STATUS.Loading && num < 3);
		return cONFIG_LOADING_STATUS;
	}

	private void method_1(int int_0, int int_1, string string_1, [MarshalAs(UnmanagedType.U1)] bool bool_1, Enum9 enum9_0)
	{
		List<vFIELDPOS> list = null;
		Enum9 @enum = enum9_0;
		int num = 0;
		List<int> list2 = null;
		if (enum9_0 != 0)
		{
			goto IL_00b2;
		}
		char c = string_1[0];
		int value;
		if (c == '@')
		{
			@enum = (Enum9)6;
			value = -1;
		}
		else
		{
			if (c != '-')
			{
				if (c == '[')
				{
					@enum = (Enum9)8;
					value = -1;
					goto IL_02f1;
				}
				if ((uint)(ushort)(c + 65439) <= 25u)
				{
					@enum = (Enum9)1;
					value = -1;
					goto IL_011b;
				}
				if ((uint)c >= 65u)
				{
					@enum = (Enum9)2;
					value = -1;
					goto IL_016f;
				}
				if (string_1.Length > 1)
				{
					string text = string_1;
					if (text[text.Length - 1] == 'm')
					{
						@enum = (Enum9)5;
						value = -1;
						goto IL_01a9;
					}
				}
				if (ACE.RSGlobal.RSGlobal.IsUIntFast(string_1))
				{
					@enum = ((ACE.RSGlobal.RSGlobal.UIntParseFast(string_1) >= 2000) ? ((Enum9)4) : ((Enum9)3));
				}
				goto IL_00b2;
			}
			@enum = (Enum9)7;
			value = -1;
		}
		goto IL_01d3;
		IL_039a:
		FIELDTYPE fIELDTYPE;
		SetFieldType(Lists[int_0], int_1, fIELDTYPE);
		if (fIELDTYPE == FIELDTYPE.custom_list)
		{
			if (list2 != null)
			{
				SetFieldBindedLists(int_0, int_1, list2.ToArray());
			}
			else
			{
				SetFieldBindedLists(int_0, int_1, new int[1] { num });
			}
		}
		GC.KeepAlive(this);
		return;
		IL_017f:
		value = ACE.RSGlobal.RSGlobal.UIntParseFast(string_1);
		num = value;
		fIELDTYPE = FIELDTYPE.custom_list;
		goto IL_0382;
		IL_03dd:
		GC.KeepAlive(this);
		return;
		IL_0190:
		value = ACE.RSGlobal.RSGlobal.UIntParseFast(string_1);
		fIELDTYPE = FIELDTYPE.ft_ENUM_EXTRA;
		method_2(int_0, int_1, value, bool_1: true);
		goto IL_039a;
		IL_01d3:
		string key = string_1.Substring(1);
		if (@enum == (Enum9)7 && !bool_0)
		{
			list = null;
			bool flag = dictionary_0.TryGetValue(key, out list);
			if (list == null)
			{
				list = new List<vFIELDPOS>();
			}
			vFIELDPOS item = new vFIELDPOS
			{
				int_0 = int_0,
				int_2 = int_1
			};
			list.Add(item);
			if (!flag)
			{
				dictionary_0.Add(key, list);
			}
		}
		else
		{
			if (EnumToStrId.TryGetValue(key, out value))
			{
				if (value > 200000)
				{
					fIELDTYPE = FIELDTYPE.ft_MASK_EXTRA;
					if (Lists[int_0].elementTypes[int_1] == Class16.smethod_0(1648989776))
					{
						Lists[int_0].elementTypes[int_1] = Class16.smethod_0(1648989786);
					}
				}
				else
				{
					fIELDTYPE = FIELDTYPE.ft_ENUM_EXTRA;
				}
				method_2(int_0, int_1, value, bool_1: false);
				goto IL_02a7;
			}
			if (bool_1)
			{
				object[] vars = new object[3] { string_1, int_1, GamePrefix };
				TextStorage.TEXTS.ShowMessage(695, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, vars);
			}
		}
		goto IL_03dd;
		IL_016f:
		num = this.get_LI(string_1);
		fIELDTYPE = FIELDTYPE.custom_list;
		goto IL_0382;
		IL_01a9:
		string_1 = string_1.Substring(0, string_1.Length - 1);
		fIELDTYPE = FIELDTYPE.ft_MASK_EXTRA;
		value = ACE.RSGlobal.RSGlobal.UIntParseFast(string_1);
		method_2(int_0, int_1, value, bool_1: true);
		goto IL_039a;
		IL_00b2:
		value = -1;
		switch (@enum)
		{
		case (Enum9)1:
			goto IL_011b;
		case (Enum9)2:
			goto IL_016f;
		case (Enum9)3:
			goto IL_017f;
		case (Enum9)4:
			goto IL_0190;
		case (Enum9)5:
			goto IL_01a9;
		case (Enum9)6:
		case (Enum9)7:
			goto IL_01d3;
		case (Enum9)8:
			goto IL_02f1;
		}
		if (bool_1)
		{
			object[] vars2 = new object[3] { string_1, int_1, GamePrefix };
			TextStorage.TEXTS.ShowMessage(695, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, vars2);
		}
		goto IL_03dd;
		IL_011b:
		FIELDTYPE_MANAGED result = FIELDTYPE_MANAGED.not_set;
		if (Enum.TryParse<FIELDTYPE_MANAGED>(string_1, out result))
		{
			fIELDTYPE = (FIELDTYPE)result;
			goto IL_02a7;
		}
		if (bool_1)
		{
			object[] vars3 = new object[3] { string_1, int_1, GamePrefix };
			TextStorage.TEXTS.ShowMessage(695, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, vars3);
		}
		goto IL_03dd;
		IL_02a7:
		if (fIELDTYPE != FIELDTYPE.not_set)
		{
			goto IL_039a;
		}
		goto IL_03dd;
		IL_0382:
		if (num == -1 && (list2 == null || list2.Count == 0))
		{
			GC.KeepAlive(this);
			return;
		}
		goto IL_039a;
		IL_02f1:
		string text2 = string_1.Substring(1, string_1.Length - 2);
		char[] separator = new char[1] { ',' };
		string[] array = text2.Replace(Class16.smethod_0(1648942211), string.Empty).Split(separator);
		list2 = new List<int>();
		int num2 = 0;
		if (0 < (nint)array.LongLength)
		{
			do
			{
				string lIST_NAME = array[num2];
				num = this.get_LI(lIST_NAME);
				if (num > -1)
				{
					list2.Add(num);
				}
				num2++;
			}
			while (num2 < (nint)array.LongLength);
		}
		if (list2.Count > 0)
		{
			fIELDTYPE = FIELDTYPE.custom_list;
			goto IL_0382;
		}
		goto IL_03dd;
	}

	private void method_2(int int_0, int int_1, int int_2, [MarshalAs(UnmanagedType.U1)] bool bool_1)
	{
		if (Lists[int_0].fieldtypes_extra == null)
		{
			Lists[int_0].fieldtypes_extra = new Dictionary<int, int>();
		}
		if (Lists[int_0].fieldtypes_extra.ContainsKey(int_1))
		{
			Lists[int_0].fieldtypes_extra[int_1] = int_2;
		}
		else
		{
			Lists[int_0].fieldtypes_extra.Add(int_1, int_2);
		}
		if (bool_1)
		{
			DecodedValues.AddValues(int_2);
		}
		GC.KeepAlive(this);
	}

	private void method_3(int int_0)
	{
		ACE.Elements.eList.eList eList2 = Lists[int_0];
		FIELD_TYPES_DB fieldTypesDB = eList2.FieldTypesDB;
		if (fieldTypesDB == null)
		{
			return;
		}
		_ = fieldTypesDB.Count;
		int num = eList2.elementTypes.Length;
		Dictionary<string, FIELD_TYPE_INFO>.Enumerator enumerator = eList2.FieldTypesDB.Fields.GetEnumerator();
		if (!enumerator.MoveNext())
		{
			return;
		}
		do
		{
			ValueType valueType = enumerator.Current;
			string key = ((KeyValuePair<string, FIELD_TYPE_INFO>)(object)valueType).Key;
			FIELD_TYPE_INFO value = ((KeyValuePair<string, FIELD_TYPE_INFO>)(object)valueType).Value;
			if (value.bRegex)
			{
				int num2 = 1;
				if (1 >= num)
				{
					continue;
				}
				do
				{
					if (Regex.IsMatch(eList2.elementFields[num2], key))
					{
						method_1(int_0, num2, value.Type, value.bUserType, (Enum9)0);
					}
					num2++;
				}
				while (num2 < num);
			}
			else
			{
				int num3 = eList2.get_fields(key);
				if (num3 > -1)
				{
					method_1(int_0, num3, value.Type, value.bUserType, (Enum9)0);
				}
			}
		}
		while (enumerator.MoveNext());
	}

	private void method_4(int int_0, [MarshalAs(UnmanagedType.U1)] bool bool_1)
	{
		ACE.Elements.eList.eList eList2 = Lists[int_0];
		if (Game != GAMES.PW)
		{
			int iconFieldIndex = eList2.IconFieldIndex;
			if (iconFieldIndex > 0)
			{
				eList2.fieldtypes[iconFieldIndex] = FIELDTYPE.file_icon;
			}
		}
		// TODO(recovered): type the "proc_type" field (an enum) by name so it is edited through the
		// options picker (ListBoxWindow) instead of a raw text box. Community configs declare proc_type
		// as int32 and the name-based auto-typer (GetListTypesDB) only runs on the debug _autofields
		// command, so the field was left FIELDTYPE.none -> fell through to ChangeValuesWindow. The
		// decoded options already exist (registered via the struct54 tables / legacy.msg.836). method_3
		// (overlay) only sets bound fields, so this assignment survives. No-op when the field is absent.
		int fileIconFieldIndex0 = (eList2.IconFieldIndex <= 0) ? eList2.get_fields("file_icon") : -1;
			if (fileIconFieldIndex0 > 0)
			{
				// TODO(recovered): PW configs name the icon field "file_icon" (not "Icon"), and the
				// name-based typer only runs on the debug _autofields command, so IconFieldIndex stayed
				// -1 -> GetIconName returned "" -> every list-icon lookup missed the atlas (placeholder
				// for every item). Detect it by name at load so PW item icons resolve.
				eList2.IconFieldIndex = fileIconFieldIndex0;
				// Force the file_icon type (not just when none): GetIconName only strips the icon
				// PATH down to the bare filename (to match the atlas, which is keyed by filename) when
				// GetFieldType returns file_icon; otherwise it keeps the full path + sets isTga, which
				// never matches the atlas. The community config types this field generically, so we
				// must override it to file_icon.
				eList2.fieldtypes[fileIconFieldIndex0] = FIELDTYPE.file_icon;
			}
		if (ACE.RSGlobal.RSGlobal.ELEMENTS_DEBUG)
		{
			return;
		}
			if (eList2.FieldTypesDB != null)
			{
				method_3(int_0);
			}
			// TODO(recovered): name-based typing + Type/Subtype binding run UNCONDITIONALLY (after method_3
			// so they win). Previously this method returned right after method_3 whenever a FieldTypesDB
			// existed (always true for PW), so Type/Subtype were never binded and proc_type/levelup_addon/
			// element_id were left raw (the community config + debug-only auto-typer don't type them).
			int procTypeFieldIndex = eList2.get_fields("proc_type");
			if (procTypeFieldIndex > -1)
			{
				// proc_type is a BITMASK (No PvP Drop / No Discard / Shop Item / ...), not a single enum.
				// Type it ft_MASK_EXTRA and point its extra-type at FIELDTYPE.proc_type (where the bit
				// options are registered as a mask) so it decodes via DecodeMask: value 0 -> "None".
				eList2.fieldtypes[procTypeFieldIndex] = FIELDTYPE.ft_MASK_EXTRA;
				method_2(int_0, procTypeFieldIndex, (int)FIELDTYPE.proc_type, bool_1: false);
			}
			int comboIdFieldIndex = eList2.get_fields("character_combo_id");
			if (comboIdFieldIndex > -1)
			{
				// The PW class-combo mask options are registered under FIELDTYPE.character_combo_id, but the
				// config sets this field's extra-type to a code with no mask options ("Unknown: 219"). Point
				// the extra-type at character_combo_id so DecodeMask resolves the class names.
				eList2.fieldtypes[comboIdFieldIndex] = FIELDTYPE.ft_MASK_EXTRA;
				method_2(int_0, comboIdFieldIndex, (int)FIELDTYPE.character_combo_id, bool_1: false);
			}
			int levelupAddonFieldIndex = eList2.get_fields("levelup_addon");
			if (levelupAddonFieldIndex > -1)
			{
				eList2.fieldtypes[levelupAddonFieldIndex] = FIELDTYPE.refine_addon_pw;
			}
			int elementIdFieldIndex = eList2.get_fields("element_id");
			if (elementIdFieldIndex > -1)
			{
				eList2.fieldtypes[elementIdFieldIndex] = FIELDTYPE.matters;
			}
			int typeFieldIndex = eList2.TypeFieldIndex;
			if (typeFieldIndex > 0)
			{
				int bindedListIndex = ((eList2.SubTypeFieldIndex <= 0) ? (int_0 - 1) : (int_0 - 2));
				if (bindedListIndex >= 0 && bindedListIndex < ListCount)
				{
					SetFieldBindedList(int_0, typeFieldIndex, bindedListIndex);
				}
			}
			int subTypeFieldIndex = eList2.SubTypeFieldIndex;
			if (subTypeFieldIndex > 0 && int_0 - 1 >= 0)
			{
				SetFieldBindedList(int_0, subTypeFieldIndex, int_0 - 1);
			}
	}

	private void method_5(BinaryWriter binaryWriter_0, object object_0, string string_1)
	{
		if (!string_1.StartsWith(Class16.smethod_0(1648989776)) && !string_1.StartsWith(Class16.smethod_0(1648902717)))
		{
			if (!string_1.StartsWith(Class16.smethod_0(1648986043)) && !string_1.StartsWith(Class16.smethod_0(1648989805)) && !string_1.StartsWith(Class16.smethod_0(1648989809)))
			{
				if (!string_1.StartsWith(Class16.smethod_0(1648989786)) && !string_1.StartsWith(Class16.smethod_0(1648960827)))
				{
					if (!string_1.StartsWith(Class16.smethod_0(1648960840)) && !string_1.StartsWith(Class16.smethod_0(1648989830)))
					{
						if (!string_1.StartsWith(Class16.smethod_0(1648960851)) && !string_1.StartsWith(Class16.smethod_0(1648989834)))
						{
							if (string_1.StartsWith(Class16.smethod_0(1648902744)))
							{
								binaryWriter_0.Write((float)object_0);
							}
							else if (string_1.StartsWith(Class16.smethod_0(1648989855)))
							{
								binaryWriter_0.Write((double)object_0);
							}
							else if (!string_1.StartsWith(Class16.smethod_0(1648902764)) && !string_1.StartsWith(Class16.smethod_0(1648985282)))
							{
								if (!string_1.StartsWith(Class16.smethod_0(1648902778)) && !string_1.StartsWith(Class16.smethod_0(1648902792)) && !string_1.StartsWith(Class16.smethod_0(1648985302)))
								{
									string_1.StartsWith(Class16.smethod_0(1648985317));
								}
								binaryWriter_0.Write((byte[])object_0);
							}
							else
							{
								binaryWriter_0.Write((byte[])object_0);
							}
						}
						else
						{
							binaryWriter_0.Write((ulong)object_0);
						}
					}
					else
					{
						binaryWriter_0.Write((long)object_0);
					}
				}
				else
				{
					binaryWriter_0.Write((uint)object_0);
				}
			}
			else
			{
				binaryWriter_0.Write((short)object_0);
			}
		}
		else
		{
			binaryWriter_0.Write((int)object_0);
		}
	}

	private void method_6(ACE.Elements.eList.eList eList_0, string string_1, int int_0)
	{
		string item = string.Format(Class16.smethod_0(1648960871), Version, int_0);
		eList_0.elementFields = ACE.RSGlobal.RSGlobal.InsertToArray(eList_0.elementFields, item, int_0);
		eList_0.elementTypes = ACE.RSGlobal.RSGlobal.InsertToArray(eList_0.elementTypes, string_1, int_0);
		object[][] elementValues = eList_0.elementValues;
		if (elementValues != null && (nint)elementValues.LongLength > 0)
		{
			Array.Resize(ref elementValues[0], (int)((nint)eList_0.elementTypes.LongLength + 1));
		}
		GC.KeepAlive(this);
	}

	private void method_7(ACE.Elements.eList.eList eList_0, string string_1)
	{
		method_6(eList_0, string_1, eList_0.elementTypes.Length);
	}

	private void method_8(ACE.Elements.eList.eList eList_0, int int_0, int int_1)
	{
		string string_;
		if (int_0 < 500000000)
		{
			string_ = Class16.smethod_0(1648989776);
			eList_0.elementValues[0][int_1] = int_0;
		}
		else
		{
			string_ = Class16.smethod_0(1648902744);
			float num = BitConverter.ToSingle(BitConverter.GetBytes(int_0), 0);
			eList_0.elementValues[0][int_1] = num;
		}
		method_6(eList_0, string_, int_1);
	}

	private void method_9(ACE.Elements.eList.eList eList_0, int int_0)
	{
		method_8(eList_0, int_0, eList_0.elementTypes.Length);
	}

	private void method_10()
	{
		if (Game != GAMES.PW)
		{
			return;
		}
		string text = Class16.smethod_0(1648960892);
		string gamePrefix = GamePrefix;
		string text2 = Class16.smethod_0(1648960910);
		string path = string.Concat(string.Concat(Application.StartupPath + text2, gamePrefix), text);
		if (!File.Exists(path))
		{
			GC.KeepAlive(this);
			return;
		}
		LastAddons = new Dictionary<int, int>();
		using (StreamReader streamReader = new StreamReader(path, Encoding.ASCII))
		{
			string text3 = streamReader.ReadLine();
			while (text3 != null)
			{
				if (text3 != string.Empty && !text3.StartsWith(Class16.smethod_0(1648929947)))
				{
					string[] array = text3.Split('=');
					if (array.Length >= 2 && int.TryParse(array[0], out int addonId) && int.TryParse(array[1], out int addonVal))
					{
						LastAddons[addonId] = addonVal;
					}
				}
				text3 = streamReader.ReadLine();
			}
		}
		GC.KeepAlive(this);
	}

	private StreamReader method_11(BinaryReader binaryReader_0)
	{
		object obj = null;
		int num = binaryReader_0.ReadInt32();
		if (num > 0)
		{
			obj = new StreamReader(new MemoryStream(RSCompression.DecompressData(binaryReader_0.ReadBytes(num))));
		}
		GC.KeepAlive(this);
		return (StreamReader)obj;
	}

	private int method_12()
	{
		if (License == null)
		{
			GC.KeepAlive(this);
			return -2;
		}
		if (!License.TryGetFeatureEntitlementInt(Class16.smethod_0(1648960915), out var value))
		{
			GC.KeepAlive(this);
			return -2;
		}
		GC.KeepAlive(this);
		return value;
	}

	private CONFIG_LOADING_STATUS method_13(BinaryReader binaryReader_0)
	{
		if (binaryReader_0 != null)
		{
			if (binaryReader_0.BaseStream.Length < 6L)
			{
				return CONFIG_LOADING_STATUS.VersionNotSupported;
			}
			full_signature = (int)binaryReader_0.ReadUInt32();
			binaryReader_0.BaseStream.Position = 0L;
			DetectedVersion = binaryReader_0.ReadUInt16();
			Version = ((DetectedVersion <= 32767) ? ((short)DetectedVersion) : short.MaxValue);
			int num = method_12();
			switch (num)
			{
			case -2:
				return CONFIG_LOADING_STATUS.VersionNotSupported;
			case -1:
				num = 999999999;
				break;
			}
			if (DetectedVersion > num)
			{
				return CONFIG_LOADING_STATUS.VersionNotSupported;
			}
			int num2 = binaryReader_0.ReadUInt16();
			Signature = ((num2 <= 32767) ? ((short)num2) : short.MaxValue);
			if (DetectedVersion > 32767)
			{
				return CONFIG_LOADING_STATUS.VersionNotSupported;
			}
			if (DetectedVersion > 7)
			{
				TimeStamp = binaryReader_0.ReadUInt32();
				if (num2 == 8192 && DetectedVersion >= 262 && DetectedVersion < 350)
				{
					int num3 = binaryReader_0.ReadInt32();
					if (num3 > 0)
					{
						OrgData = binaryReader_0.ReadBytes(num3);
					}
					else
					{
						OrgData = Array.Empty<byte>();
					}
				}
				if (DetectedVersion >= 350)
				{
					long position = binaryReader_0.BaseStream.Position;
					OrgData = binaryReader_0.ReadBytes(binaryReader_0.ReadInt32());
					tag_name = binaryReader_0.ReadUInt32();
					ComputerName = binaryReader_0.ReadBytes(binaryReader_0.ReadInt32());
					ComputerTimestamp = binaryReader_0.ReadUInt32();
					tag_info = binaryReader_0.ReadUInt32();
					HardInfo = binaryReader_0.ReadBytes(binaryReader_0.ReadInt32());
					binaryReader_0.BaseStream.Position = position;
				}
			}
			else
			{
				TimeStamp = 0u;
			}
			GAMES gAMES = (Game = DetectGame(Version, Signature, TimeStamp));
			int num4 = ((gAMES == GAMES.PW && Signature == 8192) ? 1 : 0);
			domesticPW = (byte)num4 != 0;
			GamePrefix = ACE.RSGlobal.RSGlobal.GetGamePrefix(gAMES);
		}
		if (!IsGameAccepted())
		{
			return CONFIG_LOADING_STATUS.GameNotSupported;
		}
		if (!string.IsNullOrEmpty(ConfigFile = FindConfig()))
		{
			int startIndex = ConfigFile.Length - 1;
			string text = ConfigFile.Substring(startIndex);
			if (ACE.RSGlobal.RSGlobal.IsUIntFast(text))
			{
				ConfigVersion = ACE.RSGlobal.RSGlobal.UIntParseFast(text);
			}
			else
			{
				ConfigVersion = 1;
			}
			StreamReader localization_sr = null;
			StreamReader fieldTypes_sr = null;
			StreamReader extraTypes_sr = null;
			StreamReader fieldSets_sr = null;
			string text2 = Class16.smethod_0(1648960950);
			string gamePrefix = GamePrefix;
			string text3 = Class16.smethod_0(1648927580);
			string text4 = Class16.smethod_0(1648960967);
			string path = string.Concat(string.Concat(string.Concat(string.Concat(Application.StartupPath + text4, gamePrefix), text3), gamePrefix), text2);
			string text5 = Class16.smethod_0(1648960983);
			string path2 = Application.StartupPath + text5;
			string text6 = Class16.smethod_0(1648961013);
			string gamePrefix2 = GamePrefix;
			string text7 = Class16.smethod_0(1648927580);
			string text8 = Class16.smethod_0(1648960967);
			string path3 = string.Concat(string.Concat(string.Concat(string.Concat(Application.StartupPath + text8, gamePrefix2), text7), gamePrefix2), text6);
			if (File.Exists(path))
			{
				fieldTypes_sr = new StreamReader(path);
			}
			if (File.Exists(path2))
			{
				extraTypes_sr = new StreamReader(path2);
			}
			if (File.Exists(path3))
			{
				fieldSets_sr = new StreamReader(path3);
			}
			LoadConfig(new StreamReader(ConfigFile), fieldTypes_sr, localization_sr, extraTypes_sr, fieldSets_sr, bSetMainFieldsTypes: true);
			if (!unkVersion)
			{
				return CONFIG_LOADING_STATUS.Success;
			}
			return CONFIG_LOADING_STATUS.UnknownVersion;
		}
		return CONFIG_LOADING_STATUS.VersionNotSupported;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	private bool method_14(BinaryReader binaryReader_0, int int_0)
	{
		bool flag = false;
		bool flag2 = false;
		int num = int_0 + 1;
		long position = binaryReader_0.BaseStream.Position;
		long position2 = 0L;
		try
		{
			ReadList(binaryReader_0, Game, Version, int_0, ref Lists, ConversationListIndex, bReadOffset: true, domesticPW);
			ID_2[] array = first2IDs;
			if (array != null && int_0 < (nint)array.LongLength)
			{
				if (array[int_0].id2 <= -1)
				{
					goto IL_00bb;
				}
				int id = array[int_0].id1;
				if (getid(int_0, 0) != id)
				{
					goto IL_00bb;
				}
				int id2 = first2IDs[int_0].id2;
				flag = getid(int_0, 1) != id2;
			}
			goto end_IL_0022;
			IL_00bb:
			if (num < (nint)first2IDs.LongLength && num < (nint)Lists.LongLength)
			{
				position2 = binaryReader_0.BaseStream.Position;
				AutoDetectOffset(binaryReader_0, Game, Version, int_0, Lists[num], domesticPW);
				uint test_count = binaryReader_0.ReadUInt32();
				if (!first2IDs[num].CheckItemCount(test_count))
				{
					flag = true;
					flag2 = true;
				}
				else
				{
					ID_2[] array2 = first2IDs;
					if (array2[num].id1 > -1)
					{
						flag = array2[num].id1 != binaryReader_0.ReadInt32();
					}
				}
				binaryReader_0.BaseStream.Position = position2;
			}
			end_IL_0022:;
		}
		catch
		{
		}
		if (!flag)
		{
			GC.KeepAlive(this);
			return true;
		}
		binaryReader_0.BaseStream.Position = position;
		ACE.Elements.eList.eList eList2 = new ACE.Elements.eList.eList();
		eList2.elementTypes = Lists[int_0].elementTypes;
		eList2.elementFields = Lists[int_0].elementFields;
		eList2._elementTypes = Lists[int_0]._elementTypes;
		eList2._elementFields = Lists[int_0]._elementFields;
		eList2.listOffsetData = AutoDetectOffset(binaryReader_0, Game, Version, int_0, Lists[int_0], domesticPW);
		uint num2 = binaryReader_0.ReadUInt32();
		if (num2 > 70000)
		{
			throw new Exception(TextStorage.TEXTS.GetText(Class16.smethod_0(1648960002)));
		}
		eList2.elementValues = new object[num2][];
		int num3 = 0;
		if (0 < (int)num2)
		{
			do
			{
				eList2.elementValues[num3] = new object[(nint)eList2.elementTypes.LongLength + 1];
				int num4 = 0;
				if (0 < (nint)eList2.elementTypes.LongLength)
				{
					do
					{
						eList2.elementValues[num3][num4] = ACE.Elements.eList.eList.readValue(binaryReader_0, eList2.elementTypes[num4]);
						num4++;
					}
					while (num4 < (nint)eList2.elementTypes.LongLength);
				}
				if (num3 <= 0)
				{
					int num5 = eList2.elementTypes.Length;
					long position3 = binaryReader_0.BaseStream.Position;
					if (!StructChangedLists.Contains(int_0))
					{
						Lists[int_0].bListStructChanged = true;
						StructChangedLists.Add(int_0);
					}
					bool flag3 = false;
					int num6 = 0;
					if (first2IDs[int_0].IdExists())
					{
						uint num7 = binaryReader_0.ReadUInt32();
						if (num7 != (uint)first2IDs[int_0].id2)
						{
							do
							{
								int int_1 = eList2.elementTypes.Length;
								method_8(eList2, (int)num7, int_1);
								num7 = (uint)binaryReader_0.ReadInt32();
								num6++;
								if (num6 > 20 && num6 >= num5)
								{
									flag3 = true;
									break;
								}
							}
							while (num7 != (uint)first2IDs[int_0].id2);
						}
						binaryReader_0.BaseStream.Position -= 4L;
						if (flag3)
						{
							break;
						}
					}
					else
					{
						bool flag4 = false;
						AutoDetectOffset(binaryReader_0, Game, Version, num, Lists[num], domesticPW);
						uint test_count2 = (uint)binaryReader_0.ReadInt32();
						if (first2IDs[num].CheckItemCount(test_count2))
						{
							ID_2[] array3 = first2IDs;
							if (array3[num].id1 > -1)
							{
								int id3 = array3[num].id1;
								flag4 = binaryReader_0.ReadInt32() == id3;
							}
							else
							{
								flag4 = true;
							}
						}
						binaryReader_0.BaseStream.Position = position3;
						if (!flag4)
						{
							while (true)
							{
								uint num8 = (uint)binaryReader_0.ReadInt32();
								int int_2 = eList2.elementTypes.Length;
								method_8(eList2, (int)num8, int_2);
								if (first2IDs[num].CheckItemCount(num8))
								{
									ID_2[] array4 = first2IDs;
									if (array4[num].id1 > -1)
									{
										int id4 = array4[num].id1;
										bool flag5;
										flag4 = (flag5 = binaryReader_0.ReadInt32() == id4);
										if (!flag5)
										{
											goto IL_03d8;
										}
									}
									else
									{
										flag4 = true;
									}
									int num9 = Lists[num].listOffsetData.Length;
									binaryReader_0.BaseStream.Position -= num9 + 8;
									int num10 = num9 / 4;
									Array.Resize(ref eList2.elementFields, (int)((nint)eList2.elementFields.LongLength - num10));
									Array.Resize(ref eList2.elementTypes, (int)((nint)eList2.elementTypes.LongLength - num10));
									Array.Resize(ref eList2.elementValues[0], (int)((nint)eList2.elementTypes.LongLength + 1));
								}
								goto IL_03d8;
								IL_03d8:
								num6++;
								if (flag4)
								{
									break;
								}
								if (num6 > 20 && num6 >= num5)
								{
									goto end_IL_0532;
								}
							}
						}
					}
				}
				num3++;
				continue;
				end_IL_0532:
				break;
			}
			while (num3 < (int)num2);
		}
		bool flag6;
		bool result = (flag6 = num3 == (int)num2);
		if (flag6)
		{
			Lists[int_0].elementFields = eList2.elementFields;
			Lists[int_0].elementValues = eList2.elementValues;
			Lists[int_0].elementTypes = eList2.elementTypes;
			Lists[int_0].listOffsetData = eList2.listOffsetData;
		}
		else
		{
			if (flag2)
			{
				throw new ApplicationException(Class16.smethod_0(1648960025));
			}
			binaryReader_0.BaseStream.Position = position2;
		}
		GC.KeepAlive(this);
		return result;
	}

	private int method_15()
	{
		if (License == null)
		{
			GC.KeepAlive(this);
			return -1;
		}
		if (!License.TryGetFeatureEntitlementInt(Class16.smethod_0(1648960061), out var value))
		{
			GC.KeepAlive(this);
			return -1;
		}
		GC.KeepAlive(this);
		return value;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	private bool method_16(BinaryReader binaryReader_0, int int_0, eListCollection eListCollection_0)
	{
		long position = binaryReader_0.BaseStream.Position;
		try
		{
			ACE.Elements.eList.eList eList2 = new ACE.Elements.eList.eList();
			eList2.elementTypes = Lists[int_0].elementTypes;
			eList2.elementFields = Lists[int_0].elementFields;
			eList2._elementTypes = Lists[int_0]._elementTypes;
			eList2._elementFields = Lists[int_0]._elementFields;
			eList2.listOffsetData = AutoDetectOffset(binaryReader_0, Game, Version, int_0, Lists[int_0], domesticPW);
			int listItemSize = ACE.Elements.eList.eList.GetListItemSize(eList2, skipStrings: false);
			short version = Version;
			if (version >= 191 && Game == GAMES.PW)
			{
				int num = version;
				int num2 = ((num == 1488 || num >= 30000) ? 1 : 0);
				if ((byte)num2 == 0)
				{
					goto IL_00d8;
				}
			}
			if (Game == GAMES.SW)
			{
				goto IL_00d8;
			}
			int num3 = 0;
			goto IL_00db;
			IL_00d8:
			num3 = 1;
			goto IL_00db;
			IL_00db:
			bool flag = (byte)num3 != 0;
			uint num4;
			if (isPacked)
			{
				eList2._idSpace = (int)binaryReader_0.ReadUInt32();
				eList2._list_type = (int)binaryReader_0.ReadUInt32();
				eList2.item_size = (int)binaryReader_0.ReadUInt32();
				num4 = binaryReader_0.ReadUInt32();
			}
			else
			{
				if (flag)
				{
					eList2._list_type = (int)binaryReader_0.ReadUInt32();
				}
				num4 = binaryReader_0.ReadUInt32();
				if (flag)
				{
					eList2.item_size = (int)binaryReader_0.ReadUInt32();
				}
			}
			if (num4 > 70000)
			{
				throw new Exception(TextStorage.TEXTS.GetText(Class16.smethod_0(1648960002)));
			}
			bool flag2 = false;
			if (Game != GAMES.PW || flag || isPacked)
			{
				flag2 = Lists[int_0].item_size == listItemSize;
			}
			eList2.elementValues = new object[num4][];
			if (num4 != 0)
			{
				if (!flag2 && !method_17(binaryReader_0, eList2, int_0, eListCollection_0))
				{
					binaryReader_0.BaseStream.Position = position;
					GC.KeepAlive(this);
					return false;
				}
				Lists[int_0].d_elementOffsets = new long[num4];
				Lists[int_0].d_elementBytes = new byte[num4][];
				int listItemSize2 = ACE.Elements.eList.eList.GetListItemSize(eList2);
				for (int i = 0; i < (int)num4; i++)
				{
					eList2.elementValues[i] = new object[(nint)eList2.elementTypes.LongLength + 1];
					Lists[int_0].d_elementOffsets[i] = binaryReader_0.BaseStream.Position;
					Lists[int_0].d_elementBytes[i] = ACE.Elements.eList.ElementsBinary.ReadExact(binaryReader_0, listItemSize2);
					binaryReader_0.BaseStream.Position -= listItemSize2;
					int num5 = 0;
					while (true)
					{
						string[] elementTypes = eList2.elementTypes;
						if (num5 >= (nint)elementTypes.LongLength)
						{
							break;
						}
						eList2.elementValues[i][num5] = ACE.Elements.eList.eList.readValue(binaryReader_0, elementTypes[num5]);
						num5++;
					}
				}
			}
			Lists[int_0]._idSpace = eList2._idSpace;
			Lists[int_0]._list_type = eList2._list_type;
			Lists[int_0].item_size = eList2.item_size;
			Lists[int_0].elementValues = eList2.elementValues;
			Lists[int_0].elementFields = eList2.elementFields;
			Lists[int_0].elementTypes = eList2.elementTypes;
			Lists[int_0]._elementFields = eList2._elementFields;
			Lists[int_0]._elementTypes = eList2._elementTypes;
			Lists[int_0].listOffsetData = eList2.listOffsetData;
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1648960067));
			binaryReader_0.BaseStream.Position = position;
			GC.KeepAlive(this);
			return false;
		}
		return true;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	private bool method_17(BinaryReader binaryReader_0, ACE.Elements.eList.eList eList_0, int int_0, eListCollection eListCollection_0)
	{
		eList_0.bListStructChanged = true;
		ACE.Elements.eList.eList eList2 = eListCollection_0.Lists[int_0];
		if ((nint)eList2.elementValues.LongLength < 1)
		{
			GC.KeepAlive(this);
			return true;
		}
		if ((nint)eList2.elementTypes.LongLength == 2)
		{
			return true;
		}
		eList_0.elementValues[0] = new object[(nint)eList_0.elementTypes.LongLength + 1];
		int num = 0;
		int num2 = 0;
		bool flag = false;
		int num3 = int_0 + 1;
		long position = binaryReader_0.BaseStream.Position;
		int num4 = 0;
		do
		{
			IL_02f3:
			long num5 = binaryReader_0.BaseStream.Position;
			if (num2 < (nint)eList2.elementTypes.LongLength)
			{
				object obj_val = ACE.Elements.eList.eList.readValue(binaryReader_0, eList_0.elementTypes[num]);
				if (num2 > eList2.NameFieldIndex && !((num2 <= -1) ? string.Empty : eList2.elementTypes[num2]).StartsWith(Class16.smethod_0(1648902778)))
				{
					string value = ACE.Elements.eList.eList.GetValue(obj_val, eList_0.elementTypes[num], roundTrip: false);
					string value2 = eList2.GetValue(0, num2, roundTrip: false);
					if (value != value2)
					{
						int num6 = num4;
						string value3;
						do
						{
							binaryReader_0.BaseStream.Position = num5;
							int int_1 = binaryReader_0.ReadInt32();
							method_8(eList_0, int_1, num);
							num5 += 4L;
							num++;
							num6++;
							value3 = ACE.Elements.eList.eList.GetValue(ACE.Elements.eList.eList.readValue(binaryReader_0, eList_0.elementTypes[num]), eList_0.elementTypes[num], roundTrip: false);
							if (num6 > 30)
							{
								GC.KeepAlive(this);
								return false;
							}
						}
						while (value3 != value2);
					}
					num4 = 0;
				}
				num++;
				num2++;
				continue;
			}
			int num7 = binaryReader_0.ReadInt32();
			object[][] elementValues = eList2.elementValues;
			int num10;
			if ((nint)elementValues.LongLength > 1)
			{
				if (num7 != (int)elementValues[1][0])
				{
					goto IL_02a2;
				}
				flag = true;
			}
			else
			{
				if (num3 < eListCollection_0.ListCount)
				{
					binaryReader_0.BaseStream.Position = num5;
					AutoDetectOffset(binaryReader_0, Game, Version, num3, Lists[num3], domesticPW);
					short version = Version;
					if (version >= 191 && Game == GAMES.PW)
					{
						int num8 = version;
						int num9 = ((num8 == 1488 || num8 >= 30000) ? 1 : 0);
						if ((byte)num9 == 0)
						{
							goto IL_021c;
						}
					}
					if (Game == GAMES.SW)
					{
						goto IL_021c;
					}
					num10 = 0;
					goto IL_021f;
				}
				flag = true;
			}
			goto IL_02e1;
			IL_021c:
			num10 = 1;
			goto IL_021f;
			IL_02a2:
			if (!flag)
			{
				binaryReader_0.BaseStream.Position = num5 + 4L;
				method_8(eList_0, num7, eList_0.elementTypes.Length);
				num++;
				num4++;
				if (num4 > 50)
				{
					binaryReader_0.BaseStream.Position = position;
					GC.KeepAlive(this);
					return false;
				}
				goto IL_02f3;
			}
			goto IL_02e1;
			IL_02e1:
			binaryReader_0.BaseStream.Position = position;
			continue;
			IL_021f:
			byte b = (byte)num10;
			bool flag2 = b != 0;
			if (b != 0)
			{
				binaryReader_0.ReadUInt32();
			}
			uint test_count = binaryReader_0.ReadUInt32();
			uint num11 = 68u;
			if (flag2)
			{
				num11 = binaryReader_0.ReadUInt32();
			}
			if (first2IDs[num3].CheckItemCount(test_count) && num11 >= 68)
			{
				ID_2[] array = first2IDs;
				if (array[num3].id1 <= -1)
				{
					flag = true;
					goto IL_02e1;
				}
				int id = array[num3].id1;
				flag = binaryReader_0.ReadInt32() == id;
			}
			goto IL_02a2;
		}
		while (!flag);
		return true;
	}

	private void method_18(BinaryReader binaryReader_0, int int_0)
	{
		ACE.Elements.eList.eList eList2 = Lists[int_0];
		long position = binaryReader_0.BaseStream.Position;
		eList2.listOffsetData = AutoDetectOffset(binaryReader_0, Game, Version, int_0, eList2, domesticPW);
		if (isPacked)
		{
			eList2._idSpace = (int)binaryReader_0.ReadUInt32();
			eList2._list_type = (int)binaryReader_0.ReadUInt32();
			eList2.item_size = (int)binaryReader_0.ReadUInt32();
			binaryReader_0.ReadUInt32();
		}
		else if (Game == GAMES.PW)
		{
			eList2._list_type = (int)binaryReader_0.ReadUInt32();
			binaryReader_0.ReadUInt32();
			eList2.item_size = (int)binaryReader_0.ReadUInt32();
		}
		else
		{
			binaryReader_0.BaseStream.Position -= 4L;
			eList2.item_size = (int)binaryReader_0.ReadUInt32();
		}
		int listItemSize = ACE.Elements.eList.eList.GetListItemSize(eList2, skipStrings: false);
		int item_size = eList2.item_size;
		int num = item_size - listItemSize;
		if (num > 30000)
		{
			binaryReader_0.BaseStream.Position = position;
			if (method_14(binaryReader_0, int_0))
			{
				GC.KeepAlive(this);
				return;
			}
			object[] vars = new object[1] { eList2.uListName };
			TextStorage.TEXTS.ThrowEcxeptionT(694, vars);
			badStructure = true;
		}
		else
		{
			if (num > 0)
			{
				goto IL_019c;
			}
			if (num < 0)
			{
				int num2 = 0;
				int num3 = (int)((nint)eList2.elementTypes.LongLength - 1);
				if (num3 >= 0)
				{
					do
					{
						num = ACE.Elements.eList.eList.GetFieldSize(eList2.elementTypes[num3]) + num;
						num2++;
						if (num >= 0)
						{
							break;
						}
						num3--;
					}
					while (num3 >= 0);
				}
				Array.Resize(ref eList2.elementFields, (int)((nint)eList2.elementFields.LongLength - num2));
				Array.Resize(ref eList2.elementTypes, (int)((nint)eList2.elementTypes.LongLength - num2));
				if (num > 0)
				{
					goto IL_019c;
				}
			}
		}
		goto IL_020a;
		IL_020a:
		binaryReader_0.BaseStream.Position = position;
		ReadList(binaryReader_0, Game, Version, int_0, ref Lists, ConversationListIndex, bReadOffset: true, domesticPW);
		GC.KeepAlive(this);
		return;
		IL_019c:
		int num4 = num % 4;
		if (num4 > 0)
		{
			num -= num4;
		}
		int num5 = num / 4;
		if (0 < num5)
		{
			int num6 = num5;
			do
			{
				method_6(eList2, Class16.smethod_0(1648989776), eList2.elementTypes.Length);
				num6--;
			}
			while (num6 != 0);
		}
		if (num4 > 0)
		{
			string string_ = Class16.smethod_0(1648985282) + num4;
			method_6(eList2, string_, eList2.elementTypes.Length);
		}
		goto IL_020a;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	private bool method_19(ITEMINFO iteminfo_0)
	{
		int num = ((References.ReferencesSpecial.ContainsKey(iteminfo_0.pos.int_0) && References.IsItemHasReferences(iteminfo_0.pos.int_0, iteminfo_0.item_type, iteminfo_0.id)) ? 1 : 0);
		GC.KeepAlive(this);
		return (byte)num != 0;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	private bool method_20(ITEMPOS itempos_0)
	{
		int num;
		if (References.ReferencesSpecial.ContainsKey(itempos_0.int_0))
		{
			int int_ = itempos_0.int_0;
			ItemType itemType = GetItemType(int_, bNpcMobAndMineIsSame: false);
			int int_2 = itempos_0.int_0;
			if (References.IsItemHasReferences(int_2, itemType, getid(itempos_0)))
			{
				num = 1;
				goto IL_004b;
			}
		}
		num = 0;
		goto IL_004b;
		IL_004b:
		GC.KeepAlive(this);
		return (byte)num != 0;
	}

	private static object[] smethod_0(object object_0, string string_1)
	{
		string empty = string.Empty;
		string oldValue = Class16.smethod_0(1648928036);
		string oldValue2 = Class16.smethod_0(1648928028);
		if (object_0.ToString() == string_1.Replace(oldValue2, empty).Replace(oldValue, empty))
		{
			return new object[1] { object_0 };
		}
		return new object[2] { object_0, string_1 };
	}

	public static void SaveListsSize(GAMES game, short version, string outputFN)
	{
		eListCollection eListCollection2 = new eListCollection(game, version);
		FileStream fileStream = File.OpenWrite(outputFN);
		StreamWriter streamWriter = new StreamWriter(fileStream);
		ACE.Elements.eList.eList[] lists = eListCollection2.Lists;
		int num = 0;
		if (0 < (nint)lists.LongLength)
		{
			do
			{
				ACE.Elements.eList.eList eList2 = lists[num];
				int listItemSize = ACE.Elements.eList.eList.GetListItemSize(eList2, skipStrings: false);
				streamWriter.WriteLine(string.Concat(eList2.uListName + Class16.smethod_0(1648942211), listItemSize));
				num++;
			}
			while (num < (nint)lists.LongLength);
		}
		streamWriter.Close();
		fileStream.Close();
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsListExist(string LIST_NAME)
	{
		return this.get_LI(LIST_NAME) != -1;
	}

	public void Encode_talk_proc()
	{
		int talk_proc_ListIndex = Get_talk_proc_ListIndex();
		if (talk_proc_ListIndex > -1 && talk_proc_ListIndex < ListCount)
		{
			byte[] listOffsetData = Lists[talk_proc_ListIndex].listOffsetData;
			if (listOffsetData != null)
			{
				byte[] listOffsetData2 = SecretEncrypter.EncryptBytes(listOffsetData, bBase64: false);
				Lists[talk_proc_ListIndex].listOffsetData = listOffsetData2;
			}
		}
		GC.KeepAlive(this);
	}

	public void DecodeLogins()
	{
		int nPC_TALK_ListIndex = Get_NPC_TALK_ListIndex();
		bool flag;
		if (nPC_TALK_ListIndex >= 0 && nPC_TALK_ListIndex < ListCount)
		{
			ACE.Elements.eList.eList eList2 = Lists[nPC_TALK_ListIndex];
			if (eList2.NPC_TALK != null)
			{
				int version = Version;
				int num = ((version == 1488 || version >= 30000) ? 1 : 0);
				if ((byte)num == 0)
				{
					ref EL_COMPUTER_DATA nPC_TALK = ref eList2.NPC_TALK;
					RealTimeStamp = (uint)nPC_TALK.timestamp;
					EL_COMPUTER_DATA eL_COMPUTER_DATA = nPC_TALK;
					byte[] array = new byte[eL_COMPUTER_DATA.len];
					int num2 = 0;
					byte[] body = eL_COMPUTER_DATA.body;
					if (0 < (nint)body.LongLength)
					{
						do
						{
							array[num2] = (byte)(eL_COMPUTER_DATA.tag[3 - num2 % 4] ^ body[num2]);
							num2++;
							eL_COMPUTER_DATA = nPC_TALK;
							body = eL_COMPUTER_DATA.body;
						}
						while (num2 < (nint)body.LongLength);
					}
					ProtectionStatus = ELEMENTS_PROTECTION_STATUS.UNKNOWN;
					if ((nint)array.LongLength > 12)
					{
						switch (array[0])
						{
						case 1:
							ProtectionStatus = ELEMENTS_PROTECTION_STATUS.PROTECTED_BY_LOGIN;
							break;
						case 0:
							ProtectionStatus = ELEMENTS_PROTECTION_STATUS.UNPROTECTED;
							break;
						}
					}
					if (ProtectionStatus != ELEMENTS_PROTECTION_STATUS.UNKNOWN)
					{
						flag = false;
						int num3 = (ProtectionVersion = array[1]);
						if (num3 > 6)
						{
							ProtectionVersion = 0;
							int num4 = array[1];
							int num5 = array.Length;
							flag = num5 > num4 + 3;
							byte[] array2 = new byte[num4];
							byte[] array3 = new byte[num5 - num4 - 2];
							Array.Copy(array, 2, array2, 0, num4);
							Array.Copy(array, num4 + 2, array3, 0, array3.Length);
							RSCrypt rSCrypt = new RSCrypt(array2);
							char[] separator = new char[1] { '\n' };
							AllowedLogins = rSCrypt.DecryptString(array3).Split(separator);
						}
						else
						{
							if (num3 != 0)
							{
								if (num3 != 1 && num3 != 2 && num3 != 3)
								{
									goto IL_030e;
								}
							}
							else
							{
								ProtectionVersion = 2;
							}
							BinaryReader binaryReader = new BinaryReader(new MemoryStream(array));
							binaryReader.BaseStream.Position = 2L;
							if (binaryReader.ReadInt32() == binaryReader.BaseStream.Length)
							{
								RealTimeStamp = binaryReader.ReadUInt32();
								IsUsersCanEditPermissions = binaryReader.ReadBoolean();
								IsElementsEncrypted = binaryReader.ReadBoolean();
								int count = binaryReader.ReadInt32();
								int num6 = binaryReader.ReadInt32();
								int count2 = binaryReader.ReadInt32();
								int count3 = binaryReader.ReadInt32();
								byte[] key = binaryReader.ReadBytes(count);
								byte[] array4 = null;
								if (num6 > 0)
								{
									array4 = binaryReader.ReadBytes(num6);
								}
								byte[] input = binaryReader.ReadBytes(count2);
								binaryReader.ReadBytes(count3);
								byte[] array5 = binaryReader.ReadBytes(16);
								RSCrypt rSCrypt2 = null;
								if (ProtectionVersion < 3)
								{
									rSCrypt2 = new RSCrypt(key);
								}
								byte[] key2 = null;
								byte[] array6;
								if (rSCrypt2 != null)
								{
									array6 = rSCrypt2.DecryptBytes(input, bBase64: true);
									if (array4 != null)
									{
										key2 = rSCrypt2.DecryptBytes(array4, bBase64: false);
									}
								}
								else
								{
									array6 = ACE.RSGlobal.RSGlobal.MapDecrypt(input, key);
									if (array4 != null)
									{
										key2 = ACE.RSGlobal.RSGlobal.MapDecrypt(array4, key);
									}
								}
								if (ACE.RSGlobal.RSGlobal.IsArraysEquals(array5, RSMD5.GetBytes(array6)))
								{
									char[] separator2 = new char[1] { '\n' };
									AllowedLogins = Encoding.UTF8.GetString(array6).Split(separator2);
									if (array4 != null)
									{
										ElementsCrypter = new ELEMENTS_CRYPTER(key2);
									}
									flag = true;
								}
							}
							binaryReader.Close();
						}
						goto IL_030e;
					}
					IsElementsAllowed = true;
					nPC_TALK.ComputerName = Encoding.UTF8.GetString(array);
					goto IL_0421;
				}
			}
		}
		AllowedLogins = new string[1] { License.GetStaticUserName() };
		IsElementsAllowed = true;
		return;
		IL_030e:
		int num7 = ((ProtectionVersion > ACE.RSGlobal.RSGlobal.MAX_SUPPORTED_PROTECTION_VERSION_DecodeLogins_eListCollection) ? 1 : 0);
		IsProtectionVersionNotSupported = (byte)num7 != 0;
		int num8;
		if (flag)
		{
			if (ProtectionStatus != ELEMENTS_PROTECTION_STATUS.UNPROTECTED && !License.Licenses.IgnoreElProtectionByLogin)
			{
				string staticUserName = License.GetStaticUserName();
				string[] allowedLogins = AllowedLogins;
				if (allowedLogins == null || allowedLogins.Length == 0 || Array.IndexOf(allowedLogins, staticUserName) <= -1)
				{
					num8 = 0;
					goto IL_037b;
				}
			}
			num8 = 1;
			goto IL_037b;
		}
		int num9 = ((ProtectionStatus == ELEMENTS_PROTECTION_STATUS.UNPROTECTED || License.Licenses.IgnoreElProtectionByLogin) ? 1 : 0);
		IsElementsAllowed = (byte)num9 != 0;
		goto IL_03e4;
		IL_03e4:
		if (AllowedLogins == null)
		{
			AllowedLogins = new string[1] { License.GetStaticUserName() };
		}
		goto IL_0421;
		IL_037b:
		byte b = (byte)num8;
		IsElementsAllowed = b != 0;
		if (b != 0 && IsElementsEncrypted && ElementsCrypter != null)
		{
			if (!IsProtectionVersionNotSupported)
			{
				DecryptElements();
			}
			else
			{
				IsElementsAllowed = false;
			}
		}
		goto IL_03e4;
		IL_0421:
		string[] allowedLogins2 = AllowedLogins;
		if (allowedLogins2 == null || allowedLogins2.Length == 0 || allowedLogins2[0] == string.Empty)
		{
			AllowedLogins = new string[1] { License.GetStaticUserName() };
		}
	}

	public void DecryptElements()
	{
		ElementsCrypter.Reset();
		GetFieldsToEncrypt(IsDecrypt: true);
		Dictionary<int, int[]>.Enumerator enumerator = FieldsToEncrypt.GetEnumerator();
		if (enumerator.MoveNext())
		{
			do
			{
				ValueType valueType = enumerator.Current;
				int key = ((KeyValuePair<int, int[]>)(object)valueType).Key;
				int[] value = ((KeyValuePair<int, int[]>)(object)valueType).Value;
				int itemsCount = GetItemsCount(key);
				int num = 0;
				if (0 >= itemsCount)
				{
					continue;
				}
				int num2 = value.Length;
				do
				{
					int num3 = 0;
					if (0 < num2)
					{
						do
						{
							int num4 = value[num3];
							Lists[key].elementValues[num][num4] = ElementsCrypter.DecodeValue((float)Lists[key].elementValues[num][num4]);
							num3++;
							num2 = value.Length;
						}
						while (num3 < num2);
					}
					num++;
				}
				while (num < itemsCount);
			}
			while (enumerator.MoveNext());
		}
		GC.KeepAlive(this);
	}

	public void UpdateNamesCache(int int_0)
	{
		if (int_0 == addons_l)
		{
			AddonsCollection addons = Addons;
			if (addons != null && addons.bLoaded)
			{
				ACE.Elements.eList.eList eList2 = Lists[int_0];
				ref string[] namesCache = ref eList2.NamesCache;
				if (namesCache != null)
				{
					string[] array = namesCache;
					if ((nint)array.LongLength == eList2.ItemCount)
					{
						goto IL_00c7;
					}
					if (array != null)
					{
						Array array2 = array;
						Array.Clear(array2, 0, array2.Length);
					}
				}
				int num = Lists[int_0].elementValues.Length;
				namesCache = new string[num];
				int num2 = 0;
				if (0 < num)
				{
					do
					{
						AddonsCollection addons2 = Addons;
						string addonNameByID = addons2.GetAddonNameByID(GetIdFast(int_0, num2));
						namesCache[num2] = (addonNameByID ?? string.Empty).ToLowerInvariant();
						num2++;
					}
					while (num2 < num);
				}
				goto IL_00c7;
			}
		}
		Lists[int_0].UpdateNamesCache();
		goto IL_00c7;
		IL_00c7:
		GC.KeepAlive(this);
	}

	public void UpdateNamesCache()
	{
		int[] allLists = AllLists;
		int num = 0;
		if (0 < (nint)allLists.LongLength)
		{
			do
			{
				UpdateNamesCache(allLists[num]);
				num++;
			}
			while (num < (nint)allLists.LongLength);
		}
	}

	public void UpdateItemCount()
	{
		ItemCount = 0;
		int num = 0;
		ACE.Elements.eList.eList[] lists = Lists;
		if (0 >= (nint)lists.LongLength)
		{
			return;
		}
		do
		{
			object[][] elementValues = lists[num].elementValues;
			if (elementValues != null)
			{
				ItemCount = (int)((nint)elementValues.LongLength + ItemCount);
			}
			num++;
		}
		while (num < (nint)lists.LongLength);
	}

	public void RemoveItem(int ListIndex, int ElementIndex)
	{
		Lists[ListIndex].RemoveItem(ElementIndex);
		FileChanged = true;
		ResetCachedList(ListIndex);
	}

	public ITEMPOS AddItem(int ListIndex, [MarshalAs(UnmanagedType.U1)] bool bSetUniqueID, ref int id, string Name)
	{
		object[] array = CreateEmptyItem(ListIndex);
		if (bSetUniqueID)
		{
			id = GetFreeID(ListIndex, ref id);
		}
		array[0] = id;
		int nameFieldIndex = Lists[ListIndex].NameFieldIndex;
		array[nameFieldIndex] = ACE.RSGlobal.RSGlobal.ToBytesW(Name, 32);
		int num = Lists[ListIndex].AddItem(array);
		ItemChanged(ListIndex, num);
		FileChanged = true;
		return new ITEMPOS(ListIndex, num);
	}

	public void AddItem(int int_0, int int_1, object[] ItemValues)
	{
		Lists[int_0].AddItem(int_1, ItemValues);
		ResetCachedList(int_0);
		ItemChanged(int_0, int_1);
		FileChanged = true;
	}

	public int AddItem(int ListIndex, object[] ItemValues)
	{
		int num = Lists[ListIndex].AddItem(ItemValues);
		ItemChanged(ListIndex, num);
		FileChanged = true;
		return num;
	}

	public void ItemChanged(int int_0, int int_1)
	{
		ACE.Elements.eList.eList eList2 = Lists[int_0];
		object[][] elementValues = eList2.elementValues;
		if (int_1 < (nint)elementValues.LongLength)
		{
			eList2.IDs[int_1] = (int)elementValues[int_1][0];
		}
		Dictionary<int, ITEMINFO> dictionary = ItemsCache[int_0];
		if (dictionary != null && dictionary.ContainsKey(int_1))
		{
			ItemsCache[int_0].Remove(int_1);
		}
		FileChanged = true;
	}

	public void ItemChanged(ITEMPOS ItemPos)
	{
		ItemChanged(ItemPos.int_0, ItemPos.int_1);
	}

	public string GetOffset(int ListIndex)
	{
		string result = BitConverter.ToString(Lists[ListIndex].listOffsetData);
		GC.KeepAlive(this);
		return result;
	}

	private static bool smethod_1(object object_0, out int int_0)
	{
		try
		{
			if (object_0 is int num)
			{
				int num2 = num;
				int_0 = num2;
				return true;
			}
			if (object_0 is uint num3)
			{
				uint num4 = num3;
				if (num4 <= int.MaxValue)
				{
					int_0 = (int)num4;
					return true;
				}
			}
			else if (object_0 is long num5)
			{
				long num6 = num5;
				if (num6 >= -2147483648L && num6 <= 2147483647L)
				{
					int_0 = (int)num6;
					return true;
				}
			}
			else
			{
				if (object_0 is short num7)
				{
					short num8 = num7;
					int_0 = num8;
					return true;
				}
				if (object_0 is ushort num9)
				{
					ushort num10 = num9;
					int_0 = num10;
					return true;
				}
				if (object_0 is byte b)
				{
					byte b2 = b;
					int_0 = b2;
					return true;
				}
				if (object_0 is sbyte b3)
				{
					sbyte b4 = b3;
					int_0 = b4;
					return true;
				}
				if (object_0 is float num11)
				{
					float num12 = num11;
					if (num12 >= -2.1474836E+09f && num12 <= 2.1474836E+09f)
					{
						int_0 = Convert.ToInt32(num12);
						return true;
					}
				}
				else if (object_0 is double num13)
				{
					double num14 = num13;
					if (num14 >= -2147483648.0 && num14 <= 2147483647.0)
					{
						int_0 = Convert.ToInt32(num14);
						return true;
					}
				}
				else if (object_0 is decimal num15)
				{
					decimal num16 = num15;
					if (num16 >= -2147483648m && num16 <= 2147483647m)
					{
						int_0 = decimal.ToInt32(num16);
						return true;
					}
				}
				else if (object_0 is string text)
				{
					string s = text;
					if (int.TryParse(s, out var result))
					{
						int_0 = result;
						return true;
					}
				}
			}
			int_0 = Convert.ToInt32(object_0);
			return true;
		}
		catch
		{
			int_0 = 0;
			return false;
		}
	}

	public void SetOffset(int ListIndex, string Offset)
	{
		if (Offset != string.Empty)
		{
			string[] array = Offset.Split('-');
			Lists[ListIndex].listOffsetData = new byte[(nint)array.LongLength];
			int num = 0;
			if (0 < (nint)array.LongLength)
			{
				do
				{
					Lists[ListIndex].listOffsetData[num] = Convert.ToByte(array[num], 16);
					num++;
				}
				while (num < (nint)array.LongLength);
			}
		}
		else
		{
			Lists[ListIndex].listOffsetData = new byte[0];
		}
	}

	public string GetAddonValue(int int_0, int int_1)
	{
		if (Lists != null && Lists.Length != 0 && Lists[0] != null && Lists[0].elementValues != null && int_0 >= 0 && int_0 < Lists[0].elementValues.Length && Lists[0].elementValues[int_0] != null && int_1 >= 0 && int_1 < Lists[0].elementValues[int_0].Length)
		{
			object object_ = Lists[0].elementValues[int_0][int_1];
			if (IsFloatAddon(0, int_0, int_1))
			{
				if (!smethod_1(object_, out var int_2))
				{
					return Class16.smethod_0(1648924112);
				}
				string result = BitConverter.ToSingle(BitConverter.GetBytes(int_2), 0).ToString();
				GC.KeepAlive(this);
				return result;
			}
			if (!smethod_1(object_, out var int_3))
			{
				return Class16.smethod_0(1648924112);
			}
			string result2 = int_3.ToString();
			GC.KeepAlive(this);
			return result2;
		}
		return Class16.smethod_0(1648924112);
	}

	public string GetValue(ITEMPOS ItemPos, string field_name)
	{
		int num = Lists[ItemPos.int_0].get_fields(field_name);
		GC.KeepAlive(this);
		if (num > -1)
		{
			return GetValue(ItemPos.int_0, ItemPos.int_1, num);
		}
		return string.Empty;
	}

	public string GetValue(int ListIndex, int ElementIndex, int FieldIndex)
	{
		if (!IsFieldExist(new FIELDPOS(ListIndex, ElementIndex, FieldIndex)))
		{
			GC.KeepAlive(this);
			return string.Empty;
		}
		string result;
		if (IsFloatAddon(ListIndex, ElementIndex, FieldIndex))
		{
			result = GetAddonValue(ElementIndex, FieldIndex);
		}
		else
		{
			switch (GetFieldType(ListIndex, ElementIndex, FieldIndex))
			{
			default:
				result = Lists[ListIndex].GetValue(ElementIndex, FieldIndex);
				break;
			case FIELDTYPE.ft_hex_color:
				result = ((Lists[ListIndex].elementValues[ElementIndex][FieldIndex] is byte[] byteColor) ? ACE.RSGlobal.RSGlobal.Color2HTML(ACE.RSGlobal.RSGlobal.Bgab2Argb(byteColor)).ToUpper() : string.Empty);
				break;
			case FIELDTYPE.shop_price:
			{
				int valueIFast = Lists[ListIndex].GetValueIFast(ElementIndex, FieldIndex);
				GC.KeepAlive(this);
				result = CStorage.GetGamePricePW(valueIFast).ToString();
				break;
			}
			}
		}
		GC.KeepAlive(this);
		return result;
	}

	public string GetValue(int ListIndex, int ElementIndex, string FieldUName)
	{
		int num = Lists[ListIndex].get_fields(FieldUName);
		if (num > -1)
		{
			GC.KeepAlive(this);
			return GetValue(ListIndex, ElementIndex, num);
		}
		return null;
	}

	public string GetValue(ITEMPOS ip, int int_0)
	{
		return GetValue(ip.int_0, ip.int_1, int_0);
	}

	public string GetValue(FIELDPOS fieldpos)
	{
		return GetValue(fieldpos.int_0, fieldpos.int_1, fieldpos.int_2);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsFloatAddon(int int_0)
	{
		GAMES game = Game;
		if (game != GAMES.SW && game != GAMES.ROG && game != GAMES.TOS)
		{
			int num = addons_l;
			if (Lists != null && Lists.Length != 0 && num >= 0 && num < Lists.Length && Lists[num] != null && int_0 >= 0 && int_0 < Lists[num].ItemCount && Lists[0] != null && Lists[0].elementValues != null && int_0 < Lists[0].elementValues.Length)
			{
				int id = Lists[num].getid(int_0);
				GC.KeepAlive(this);
				FIELD_DATA_TYPE_ENUM customAddonType = CommonStorage.AParams.GetCustomAddonType(id);
				if (customAddonType > FIELD_DATA_TYPE_ENUM.Unknown)
				{
					GC.KeepAlive(this);
					return customAddonType == FIELD_DATA_TYPE_ENUM.Float;
				}
				int num2 = 3;
				num2 = ((Game != GAMES.PW) ? 4 : num2);
				if (Lists[0].elementValues[int_0] != null && num2 >= 0 && num2 < Lists[0].elementValues[int_0].Length)
				{
					if (!smethod_1(Lists[0].elementValues[int_0][num2], out var int_1))
					{
						return false;
					}
					return int_1 > 500000000;
				}
				return false;
			}
			return false;
		}
		return false;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsFloatAddon(int int_0, int int_1, int int_2)
	{
		GAMES game = Game;
		if (game != GAMES.SW && game != GAMES.ROG && game != GAMES.TOS)
		{
			int num = addons_l;
			if (int_0 == num)
			{
				int num2 = 3;
				num2 = ((game != GAMES.PW) ? 4 : num2);
				if (int_2 >= num2)
				{
					if (Lists == null || Lists.Length == 0 || num < 0 || num >= Lists.Length || Lists[num] == null || Lists[0] == null || Lists[0].elementValues == null || int_1 < 0 || int_1 >= Lists[0].elementValues.Length || Lists[0].elementValues[int_1] == null || int_2 < 0 || int_2 >= Lists[0].elementValues[int_1].Length)
					{
						return false;
					}
					int num3 = num;
					int id = Lists[num3].getid(int_1);
					GC.KeepAlive(this);
					FIELD_DATA_TYPE_ENUM customAddonType = CommonStorage.AParams.GetCustomAddonType(id);
					if (customAddonType > FIELD_DATA_TYPE_ENUM.Unknown)
					{
						GC.KeepAlive(this);
						int num4 = ((int_2 < num2 + 2 && customAddonType == FIELD_DATA_TYPE_ENUM.Float) ? 1 : 0);
						return (byte)num4 != 0;
					}
					if (smethod_1(Lists[0].elementValues[int_1][int_2], out var int_3) && int_3 > 500000000)
					{
						return true;
					}
				}
			}
			return false;
		}
		return false;
	}

	public decimal GetValueDecimal(int int_0, int int_1, int int_2)
	{
		if (IsFloatAddon(int_0, int_1, int_2))
		{
			float value = BitConverter.ToSingle(BitConverter.GetBytes((int)Lists[0].elementValues[int_1][int_2]), 0);
			decimal result = ACE.RSGlobal.RSGlobal.ToDecimalSafe(value);
			GC.KeepAlive(this);
			return result;
		}
		decimal num = default(decimal);
		if (GetFieldType(int_0, int_1, int_2) == FIELDTYPE.shop_price && Game == GAMES.PW)
		{
			int valueIFast = Lists[int_0].GetValueIFast(int_1, int_2);
			GC.KeepAlive(this);
			num = CStorage.GetGamePricePW(valueIFast);
		}
		else
		{
			num = Lists[int_0].GetValueDecimal(int_1, int_2);
		}
		GC.KeepAlive(this);
		return num;
	}

	public decimal GetValueDecimal(FIELDPOS fp)
	{
		return GetValueDecimal(fp.int_0, fp.int_1, fp.int_2);
	}

	public decimal GetValueDecimal(int int_0, int int_1, string field_name)
	{
		int num = Lists[int_0].get_fields(field_name);
		GC.KeepAlive(this);
		if (num > -1)
		{
			return GetValueDecimal(int_0, int_1, num);
		}
		return 0m;
	}

	public float GetValueF(int int_0, int int_1, string field_name)
	{
		int num = Lists[int_0].get_fields(field_name);
		GC.KeepAlive(this);
		if (num > -1)
		{
			float valueF = Lists[int_0].GetValueF(int_1, num);
			GC.KeepAlive(this);
			return valueF;
		}
		return 0f;
	}

	public float GetValueF(ITEMPOS ItemPos, string field_name)
	{
		int num = Lists[ItemPos.int_0].get_fields(field_name);
		GC.KeepAlive(this);
		if (num > -1)
		{
			int int_ = ItemPos.int_1;
			float valueF = Lists[ItemPos.int_0].GetValueF(int_, num);
			GC.KeepAlive(this);
			return valueF;
		}
		return 0f;
	}

	public float GetValueF(int ListIndex, int ElementIndex, int FieldIndex)
	{
		float valueF = Lists[ListIndex].GetValueF(ElementIndex, FieldIndex);
		GC.KeepAlive(this);
		return valueF;
	}

	public float GetValueF(FIELDPOS fieldpos)
	{
		int int_ = fieldpos.int_2;
		int int_2 = fieldpos.int_1;
		float valueF = Lists[fieldpos.int_0].GetValueF(int_2, int_);
		GC.KeepAlive(this);
		return valueF;
	}

	public double GetValueD(int ListIndex, int ElementIndex, int FieldIndex)
	{
		double valueD = Lists[ListIndex].GetValueD(ElementIndex, FieldIndex);
		GC.KeepAlive(this);
		return valueD;
	}

	public double GetValueD(FIELDPOS fieldpos)
	{
		int int_ = fieldpos.int_2;
		int int_2 = fieldpos.int_1;
		double valueD = Lists[fieldpos.int_0].GetValueD(int_2, int_);
		GC.KeepAlive(this);
		return valueD;
	}

	public int GetValueI(int int_0, int int_1, int int_2)
	{
		int valueIFast = Lists[int_0].GetValueIFast(int_1, int_2);
		GC.KeepAlive(this);
		return valueIFast;
	}

	public int GetValueI(int int_0, int int_1, string field_name)
	{
		int num = Lists[int_0].get_fields(field_name);
		GC.KeepAlive(this);
		int result;
		if (num > -1)
		{
			result = Lists[int_0].GetValueIFast(int_1, num);
			GC.KeepAlive(this);
		}
		else
		{
			result = 0;
		}
		return result;
	}

	public int GetValueI(FIELDPOS fieldpos)
	{
		int int_ = fieldpos.int_2;
		int int_2 = fieldpos.int_1;
		int int_3 = fieldpos.int_0;
		int valueIFast = Lists[int_3].GetValueIFast(int_2, int_);
		GC.KeepAlive(this);
		return valueIFast;
	}

	public int GetValueI(ITEMPOS ItemPos, int int_0)
	{
		int int_1 = ItemPos.int_1;
		int int_2 = ItemPos.int_0;
		int valueIFast = Lists[int_2].GetValueIFast(int_1, int_0);
		GC.KeepAlive(this);
		return valueIFast;
	}

	public int GetValueI(ITEMPOS ItemPos, string field_name)
	{
		int num = Lists[ItemPos.int_0].get_fields(field_name);
		GC.KeepAlive(this);
		int result;
		if (num > -1)
		{
			int int_ = ItemPos.int_1;
			int int_2 = ItemPos.int_0;
			result = Lists[int_2].GetValueIFast(int_, num);
			GC.KeepAlive(this);
		}
		else
		{
			result = 0;
		}
		return result;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool SetValue(int int_0, int int_1, int int_2, string Value, [MarshalAs(UnmanagedType.U1)] bool AutoSaveStage)
	{
		if (AutoSaveStage)
		{
			int[] fieldsindices = new int[1] { int_2 };
			int[] itemsindices = new int[1] { int_1 };
			ActionsHistory.stChangeFields(int_0, itemsindices, fieldsindices, -1, null);
		}
		if (int_2 == 0)
		{
			if (!ACE.RSGlobal.RSGlobal.IsNumber(Value))
			{
				Value = Class16.smethod_0(1648924112);
			}
			int old_id = Lists[int_0].getid(int_1);
			GC.KeepAlive(this);
			Notes.IDChanged(int_0, old_id, ACE.RSGlobal.RSGlobal.UIntParseFast(Value));
		}
		if (string.IsNullOrWhiteSpace(Value) && IsNumericType(int_0, int_2))
		{
			if (Game == GAMES.FW)
			{
				ACE.Elements.eList.eList eList2 = Lists[int_0];
				if (eList2.ListType == ItemType.FW_ITEM_TRADE_PAGE_CONFIG)
				{
					ref string reference = ref eList2.elementFields[int_2];
					int num = ((reference.Contains(Class16.smethod_0(1648960126)) && reference.EndsWith(Class16.smethod_0(1648932143))) ? 1 : 0);
					if ((byte)num != 0)
					{
						Value = Class16.smethod_0(1648960129);
						goto IL_0104;
					}
				}
			}
			Value = Class16.smethod_0(1648924112);
		}
		goto IL_0104;
		IL_022f:
		bool flag;
		if (AutoSaveStage)
		{
			if (flag)
			{
				ActionsHistory.Complete();
			}
			else
			{
				ActionsHistory.CancelLastStage(cancelSuperStage: false);
			}
		}
		goto IL_024f;
		IL_0208:
		FileChanged = true;
		ItemChanged(int_0, int_1);
		if (AutoSaveStage)
		{
			if (int_0 == addons_l)
			{
				Addons.Refresh();
			}
			goto IL_022f;
		}
		goto IL_024f;
		IL_0104:
		FIELDTYPE fieldType = GetFieldType(int_0, int_1, int_2);
		bool flag2 = false;
		if (IsFloatAddon(int_0, int_1, int_2))
		{
			float value = Convert.ToSingle(Value);
			Value = BitConverter.ToInt32(BitConverter.GetBytes(value), 0).ToString();
		}
		else if (fieldType == FIELDTYPE.shop_price)
		{
			if (!ACE.RSGlobal.RSGlobal.IsNumber(Value))
			{
				Value = Class16.smethod_0(1648924112);
			}
			int price = ACE.RSGlobal.RSGlobal.UIntParseFast(Value);
			Value = CStorage.GetElementPricePW(price).ToString();
		}
		else
		{
			if (fieldType == FIELDTYPE.ft_hex_color)
			{
				Value = Value.Trim();
				if (Value.StartsWith(Class16.smethod_0(1648929947)) || Value.StartsWith(Class16.smethod_0(1648935659)))
				{
					Value = Value.Substring(1);
				}
				object obj = null;
				try
				{
					obj = RSCommon.HexToColor_o(Value);
				}
				catch
				{
				}
				if (obj != null)
				{
					byte[] array = ACE.RSGlobal.RSGlobal.Rgb2Bgab((Color)obj);
					Lists[int_0].elementValues[int_1][int_2] = array;
				}
				flag2 = true;
			}
			flag = flag2;
			if (flag2)
			{
				goto IL_0208;
			}
		}
		if (flag = Lists[int_0].SetValue(int_1, int_2, Value))
		{
			goto IL_0208;
		}
		goto IL_022f;
		IL_024f:
		GC.KeepAlive(this);
		return flag;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool SetValue(int ListIndex, int ElementIndex, int FieldIndex, string Value)
	{
		return SetValue(ListIndex, ElementIndex, FieldIndex, Value, AutoSaveStage: true);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool SetValue(FIELDPOS fieldpos, string Value)
	{
		int int_ = fieldpos.int_2;
		int int_2 = fieldpos.int_1;
		int int_3 = fieldpos.int_0;
		return SetValue(int_3, int_2, int_, Value, AutoSaveStage: true);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool SetValue(ITEMPOS ItemPos, string FieldUName, string Value, [MarshalAs(UnmanagedType.U1)] bool AutoSaveStage)
	{
		int num = Lists[ItemPos.int_0].get_fields(FieldUName);
		if (num > -1)
		{
			GC.KeepAlive(this);
			return SetValue(ItemPos.int_0, ItemPos.int_1, num, Value, AutoSaveStage);
		}
		return false;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool SetValue(ITEMPOS ItemPos, string FieldUName, string Value)
	{
		int num = Lists[ItemPos.int_0].get_fields(FieldUName);
		if (num > -1)
		{
			GC.KeepAlive(this);
			int int_ = ItemPos.int_1;
			int int_2 = ItemPos.int_0;
			return SetValue(int_2, int_, num, Value, AutoSaveStage: true);
		}
		return false;
	}

	public void SetValueI(int ListIndex, int ElementIndex, int FieldIndex, int Value, [MarshalAs(UnmanagedType.U1)] bool AutoSaveStage)
	{
		if (AutoSaveStage)
		{
			int[] fieldsindices = new int[1] { FieldIndex };
			int[] itemsindices = new int[1] { ElementIndex };
			ActionsHistory.stChangeFields(ListIndex, itemsindices, fieldsindices, -1, null);
		}
		if (Lists[ListIndex].elementTypes[FieldIndex] == Class16.smethod_0(1648989776))
		{
			Lists[ListIndex].elementValues[ElementIndex][FieldIndex] = Value;
		}
		else
		{
			Lists[ListIndex].elementValues[ElementIndex][FieldIndex] = (uint)Value;
		}
		if (AutoSaveStage)
		{
			ActionsHistory.Complete();
		}
		GC.KeepAlive(this);
	}

	public void SetValueI(ITEMPOS ItemPos, int FieldIndex, int Value, [MarshalAs(UnmanagedType.U1)] bool AutoSaveStage)
	{
		SetValueI(ItemPos.int_0, ItemPos.int_1, FieldIndex, Value, AutoSaveStage);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool SetNum(int ListIndex, int ElementIndex, int FieldIndex, decimal Value)
	{
		if (FieldIndex == 0)
		{
			int old_id = Lists[ListIndex].getid(ElementIndex);
			GC.KeepAlive(this);
			Notes.IDChanged(ListIndex, old_id, Convert.ToInt32(Value));
		}
		if (IsFloatAddon(ListIndex, ElementIndex, FieldIndex))
		{
			Value = BitConverter.ToInt32(BitConverter.GetBytes((float)Value), 0);
		}
		else if (GetFieldType(ListIndex, ElementIndex, FieldIndex) == FIELDTYPE.shop_price)
		{
			decimal num = 2147483647m;
			if (Value > num)
			{
				Value = 2147483647m;
			}
			else if (Value < default(decimal))
			{
				Value = default(decimal);
			}
			Value = CStorage.GetElementPricePW(decimal.ToInt32(Value));
		}
		bool result;
		if (result = Lists[ListIndex].SetValue(ElementIndex, FieldIndex, Value))
		{
			FileChanged = true;
			ItemChanged(ListIndex, ElementIndex);
			if (ListIndex == 0)
			{
				Addons.Refresh();
			}
		}
		GC.KeepAlive(this);
		return result;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsFieldChanged(int int_0, int int_1, int int_2)
	{
		vITEMPOS item = new vITEMPOS
		{
			Int32_1 = int_0,
			Int32_0 = int_1
		};
		bool result = ActionsHistory.IsItemChanged(item, int_2, FILES_ENUM.ELEMENTS);
		GC.KeepAlive(this);
		return result;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsItemChanged(int int_0, int int_1)
	{
		bool result = IsItemChanged(new vITEMPOS
		{
			Int32_1 = int_0,
			Int32_0 = int_1
		});
		GC.KeepAlive(this);
		return result;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsItemChanged(vITEMPOS item)
	{
		if (ACE.RSGlobal.RSGlobal.ELEMENTS_DEBUG)
		{
			return false;
		}
		if (item.Int32_1 >= 0 && item.Int32_0 >= 0)
		{
			ACTION_HISTORY actionsHistory = ActionsHistory;
			if (actionsHistory == null)
			{
				return false;
			}
			try
			{
				bool result = actionsHistory.IsItemChanged(item, -1, FILES_ENUM.ALL_FILES);
				GC.KeepAlive(this);
				return result;
			}
			catch (NullReferenceException)
			{
				return false;
			}
		}
		return false;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsItemChanged(ITEMPOS ItemPos)
	{
		vITEMPOS item = new vITEMPOS(ItemPos);
		bool result = IsItemChanged(item);
		GC.KeepAlive(this);
		return result;
	}

	public string GetTypeS(int ListIndex, int FieldIndex)
	{
		return Lists[ListIndex].elementTypes[FieldIndex];
	}

	public FIELD_DATA_TYPE_ENUM GetTypeFast(int int_0, int int_1)
	{
		return Lists[int_0].FieldDataTypes[int_1].data_type;
	}

	public void LoadConfig(StreamReader sr, StreamReader fieldTypes_sr, StreamReader Localization_sr, StreamReader ExtraTypes_sr, StreamReader fieldSets_sr, [MarshalAs(UnmanagedType.U1)] bool bSetMainFieldsTypes)
	{
		string text = sr.ReadLine();
		if (!string.IsNullOrWhiteSpace(text))
		{
			text = text.Trim().TrimStart('\ufeff');
		}
		int result = 0;
		if (!string.IsNullOrWhiteSpace(text) && ACE.RSGlobal.RSGlobal.IsIntFast(text))
		{
			int.TryParse(text, out result);
		}
		else
		{
			result = ACE.RSGlobal.RSGlobal.UIntParseFast(text);
		}
		if (result < 0)
		{
			result = 0;
		}
		ListCount = result;
		string text2 = sr.ReadLine();
		int result2 = 0;
		if (!string.IsNullOrWhiteSpace(text2) && ACE.RSGlobal.RSGlobal.IsIntFast(text2))
		{
			int.TryParse(text2, out result2);
		}
		else
		{
			result2 = ACE.RSGlobal.RSGlobal.UIntParseFast(text2);
		}
		int num = (ConversationListIndex = result2);
		GAMES game = Game;
		if (game != GAMES.PW && game != GAMES.UNKNOWN_GAME && num != 999)
		{
			ConversationListIndex = ListCount - 1;
		}
		if (game == GAMES.PW)
		{
			short version = Version;
			if (version >= 350)
			{
				int num2 = version;
				int num3 = ((num2 == 1488 || num2 >= 30000) ? 1 : 0);
				if ((byte)num3 == 0 && ConversationListIndex != 999)
				{
					ConversationListIndex = ListCount - 1;
				}
			}
		}
		ListIndices = new Dictionary<string, int>((Lists = new ACE.Elements.eList.eList[ListCount]).Length);
		int num4 = 0;
		if (0 < (nint)Lists.LongLength)
		{
			while (true)
			{
				string text3 = sr.ReadLine();
				if (string.IsNullOrWhiteSpace(text3))
				{
					continue;
				}
				Lists[num4] = new ACE.Elements.eList.eList();
				Lists[num4].ListIndex = num4;
				string text4 = Regex.Replace(text3, Class16.smethod_0(1648960146), string.Empty);
				Lists[num4].ListName = text4;
				Lists[num4].uListName = text4;
				ListIndices[Lists[num4].uListName] = num4;
				Lists[num4].ListType = ParseListType(text4);
				string text5 = sr.ReadLine();
				if (Version != 32222)
				{
					if (text5 != Class16.smethod_0(1648902775) && ACE.RSGlobal.RSGlobal.IsUIntFast(text5))
					{
						int num5 = ACE.RSGlobal.RSGlobal.UIntParseFast(text5);
						if (num4 == 0 && Version > 7)
						{
							num5 -= 4;
						}
						if (num5 < 0)
						{
							num5 = 0;
						}
						Lists[num4].listOffsetData = new byte[num5];
					}
					else
					{
						Lists[num4].sAutoOffset = text5;
					}
				}
				char[] separator = new char[1] { ';' };
				Lists[num4].elementFields = sr.ReadLine().Split(separator);
				char[] separator2 = new char[1] { ';' };
				Lists[num4].elementTypes = sr.ReadLine().Split(separator2);
				for (int i = 0; i < Lists[num4].elementTypes.Length; i++)
				{
					if (Lists[num4].elementTypes[i] == Class16.smethod_0(1648902717))
					{
						Lists[num4].elementTypes[i] = Class16.smethod_0(1648989776);
					}
					else if (Lists[num4].elementTypes[i] == Class16.smethod_0(1648960827))
					{
						Lists[num4].elementTypes[i] = Class16.smethod_0(1648989786);
					}
				}
				ACE.Elements.eList.eList eList2 = Lists[num4];
				int num6 = eList2.elementTypes.Length;
				int num7 = eList2.elementFields.Length;
				if (num7 != num6)
				{
					Array.Resize(ref eList2.elementFields, num6);
					int num8 = num7 - 1;
					if (num8 < (nint)Lists[num4].elementFields.LongLength)
					{
						do
						{
							Lists[num4].elementFields[num8] = Class16.smethod_0(1648966655);
							num8++;
						}
						while (num8 < (nint)Lists[num4].elementFields.LongLength);
					}
				}
				if (bSetMainFieldsTypes && num4 != ConversationListIndex)
				{
					if (Game == GAMES.PW && text4 == Class16.smethod_0(1648960167))
					{
						Lists[num4].NameFieldIndex = 1;
						Lists[num4].TypeFieldIndex = 2;
					}
					else
					{
						ACE.Elements.eList.eList eList3 = Lists[num4];
						if ((nint)eList3.elementFields.LongLength > 1)
						{
							int num9 = Array.IndexOf(eList3.elementFields, Class16.smethod_0(1648936731));
							if (num9 <= 0)
							{
								num9 = Array.IndexOf(eList3.elementFields, Class16.smethod_0(1648905100));
							}
							if (num9 <= 0)
							{
								num9 = Array.IndexOf(eList3.elementFields, Class16.smethod_0(1648960177));
							}
							if (num9 <= 0)
							{
								num9 = Array.IndexOf(eList3.elementFields, Class16.smethod_0(1648960193));
							}
							if (num9 > 0)
							{
								Lists[num4].NameFieldIndex = num9;
								int num10 = Array.IndexOf(eList3.elementFields, Class16.smethod_0(1648960536));
								if (num10 > 0)
								{
									Lists[num4].TypeFieldIndex = num10;
								}
								int num11 = Array.IndexOf(eList3.elementFields, Class16.smethod_0(1648960564));
								if (num11 > 0)
								{
									Lists[num4].SubTypeFieldIndex = num11;
								}
							}
							else
							{
								string fieldName = eList3.GetFieldName(1);
								if (string.Equals(fieldName, Class16.smethod_0(1648936875), StringComparison.OrdinalIgnoreCase))
								{
									Lists[num4].TypeFieldIndex = 1;
									if (Lists[num4].FieldCount > 2 && string.Equals(Lists[num4].GetFieldName(2), Class16.smethod_0(1648960211), StringComparison.OrdinalIgnoreCase))
									{
										Lists[num4].SubTypeFieldIndex = 2;
										Lists[num4].NameFieldIndex = 3;
									}
									else
									{
										Lists[num4].NameFieldIndex = 2;
									}
								}
								else if (string.Equals(fieldName, Class16.smethod_0(1648960211), StringComparison.OrdinalIgnoreCase))
								{
									Lists[num4].TypeFieldIndex = 1;
									Lists[num4].NameFieldIndex = 2;
								}
								else
								{
									Lists[num4].NameFieldIndex = 1;
								}
							}
							GAMES game2 = Game;
							if (game2 == GAMES.ESO || game2 == GAMES.Chibi)
							{
								Lists[num4].IconFieldIndex = Array.IndexOf(Lists[num4].elementFields, Class16.smethod_0(1648960225));
							}
						}
					}
				}
				num4++;
				if (num4 >= (nint)Lists.LongLength)
				{
					break;
				}
			}
		}
		sr.Close();
		CROSS_LISTS = ListIndices;
		if (!bOnlyConfig)
		{
			if (fieldTypes_sr != null)
			{
				ParseFieldTypes(fieldTypes_sr, bUserTypes: false);
			}
			string text6 = Class16.smethod_0(1648960244);
			string gamePrefix = GamePrefix;
			string text7 = Class16.smethod_0(1648960527);
			if (File.Exists(UserCustomTypesFN = string.Concat(string.Concat(Application.StartupPath + text7, gamePrefix), text6)))
			{
				ParseFieldTypes(File.OpenText(UserCustomTypesFN), bUserTypes: true);
			}
		}
		this.Localization_sr = null;
		LoadLocalization();
		string text8 = Class16.smethod_0(1648960257);
		string gamePrefix2 = GamePrefix;
		string text9 = Class16.smethod_0(1648960527);
		string path = string.Concat(string.Concat(Application.StartupPath + text9, gamePrefix2), text8);
		if (File.Exists(path))
		{
			try { ParseHintFields(File.OpenText(path)); } catch (Exception) { /* TODO(recovered): hint-field overlay is optional; never abort load on it. */ }
		}
		if (fieldSets_sr != null)
		{
			ParseFieldSets(fieldSets_sr, bUser: false);
		}
		string text10 = Class16.smethod_0(1648961013);
		string gamePrefix3 = GamePrefix;
		string text11 = Class16.smethod_0(1648960527);
		if (File.Exists(UserFieldSetsFN = string.Concat(string.Concat(Application.StartupPath + text11, gamePrefix3), text10)))
		{
			ParseFieldSets(File.OpenText(UserFieldSetsFN), bUser: true);
		}
		GAMES game3 = Game;
		if (game3 != GAMES.ROG && game3 != GAMES.TOS)
		{
			try { ParseSpacesId(); } catch (Exception) { /* TODO(recovered): optional spaces-id pass; don't abort load. */ }
		}
		// TODO(recovered): ReplaceTypes / InitDecodedValues apply enum/value/reference decoding.
		// Licensed calls both unconditionally. On community v233 configs a single missing list/field
		// used to throw and skip the rest (and FillListsArrays below), so each is guarded to keep the
		// load best-effort. BUT a silent swallow here drops the whole DecodedValues enum table ->
		// every enum field (incl. equipment-addon params) renders raw with no name. Log the failure
		// so it is diagnosable instead of silently losing all enum names.
		try { ReplaceTypes(); } catch (Exception ex) { SentryHelper.CaptureException(ex, "eListCollection.LoadConfig: ReplaceTypes failed (enum/type renames skipped)"); }
		try { InitDecodedValues(ExtraTypes_sr); } catch (Exception ex) { SentryHelper.CaptureException(ex, "eListCollection.LoadConfig: InitDecodedValues failed (DecodedValues enum table left incomplete -> enum fields show raw values)"); }
		FillListsArrays();
	}

	public void LoadConfig(StreamReader sr, [MarshalAs(UnmanagedType.U1)] bool bSetMainFieldsTypes)
	{
		LoadConfig(sr, null, null, null, null, bSetMainFieldsTypes);
	}

	public void ParseFieldLang(StreamReader Localization_sr, [MarshalAs(UnmanagedType.U1)] bool bCheckExistence)
	{
		int num = 16777215;
		int num2 = 0;
		string text = null;
		try
		{
			bool flag = false;
			if (!bCheckExistence)
			{
				string text2 = Class16.smethod_0(1648934967);
				flag = Localization_sr.ReadLine() == text2;
				Localization_sr.ReadLine();
				Localization_sr.ReadLine();
				int num3 = ACE.RSGlobal.RSGlobal.UIntParseFast(Localization_sr.ReadLine());
				int regexCount = (flag ? num3 : 0);
				TranslatedFieldsGlobal = new FIELDS_TRANSLATER(num3, regexCount);
			}
			else
			{
				int num4 = 0;
				do
				{
					num4 = Localization_sr.BaseStream.ReadByte();
					if (num4 == -1)
					{
						Localization_sr.Close();
						return;
					}
				}
				while (num4 != 64 && num4 != 35);
				Stream baseStream = Localization_sr.BaseStream;
				long position = baseStream.Position;
				position += -1L;
				baseStream.Position = position;
				flag = true;
			}
			FIELDS_TRANSLATER fIELDS_TRANSLATER = TranslatedFieldsGlobal;
			while (true)
			{
				text = Localization_sr.ReadLine();
				if (text == null)
				{
					break;
				}
				num2++;
				if (string.IsNullOrWhiteSpace(text))
				{
					continue;
				}
				if (text[0] == '@')
				{
					string[] array = text.Split(';');
					string lIST_NAME = array[0].Substring(1);
					string listName = array[1];
					num = this.get_LI(lIST_NAME);
					if (num > -1)
					{
						Lists[num].ListName = listName;
					}
				}
				else if (text[0] == '#')
				{
					if (text == Class16.smethod_0(1648960287))
					{
						num = 16777215;
					}
					else if (text == Class16.smethod_0(1648960290))
					{
						num = 16777215;
						bCheckExistence = true;
					}
					else
					{
						bCheckExistence = true;
						int num5 = text.IndexOf(Class16.smethod_0(1648924402));
						string text3 = null;
						text3 = ((num5 <= -1) ? text.Substring(1) : text.Substring(num5 + 1, text.Length - num5 - 1));
						flag = true;
						string text4 = text3;
						if (text4[text4.Length - 1] == '~')
						{
							text3 = text3.Substring(0, text3.Length - 1);
							flag = true;
						}
						num = this.get_LI(text3);
						switch (num)
						{
						default:
							if (Lists[num].FieldsTranslation == null)
							{
								FIELDS_TRANSLATER fieldsTranslation = new FIELDS_TRANSLATER(8, 8);
								Lists[num].FieldsTranslation = fieldsTranslation;
							}
							fIELDS_TRANSLATER = Lists[num].FieldsTranslation;
							continue;
						case 16777215:
							break;
						case -1:
							fIELDS_TRANSLATER = null;
							continue;
						}
					}
					fIELDS_TRANSLATER = TranslatedFieldsGlobal;
				}
				else if (fIELDS_TRANSLATER != null)
				{
					string[] array2 = text.Split(';');
					string text5 = array2[0];
					string translated = array2[1];
					bool isRegex = false;
					if (text5[0] == '~')
					{
						isRegex = true;
						text5 = text5.Substring(1);
					}
					else if (flag)
					{
						isRegex = text5.Contains(Class16.smethod_0(1648938114));
					}
					fIELDS_TRANSLATER.Add(text5, translated, bCheckExistence, isRegex);
				}
			}
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1648960307));
			if (ex.GetType() == typeof(ApplicationException))
			{
				object[] vars = new object[1] { ex.Message };
				TextStorage.TEXTS.ShowMessage(5, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, vars);
			}
			else
			{
				string key = Class16.smethod_0(1648960344);
				ex.Data.Add(key, text);
				string key2 = Class16.smethod_0(1648960355);
				ex.Data.Add(key2, num2);
				string uListName = Lists[num].uListName;
				string key3 = Class16.smethod_0(1648960381);
				ex.Data.Add(key3, uListName);
				string key4 = Class16.smethod_0(1648893587);
				string text6 = string.Format(Class16.smethod_0(1648960396), Localization_sr.BaseStream.Position, Localization_sr.BaseStream.Length);
				ex.Data.Add(key4, text6);
				string text7 = string.Format(Class16.smethod_0(1648960412), ex.Message, ex.StackTrace, text, num2, uListName, text6);
				DKBox.Show(text7, Class16.smethod_0(1648959493), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
		Localization_sr.Close();
		GC.KeepAlive(this);
	}

	public void ParseFieldTypes(StreamReader FieldTypes_sr, [MarshalAs(UnmanagedType.U1)] bool bUserTypes)
	{
		ACE.Elements.eList.eList eList2 = null;
		string text = null;
		try
		{
			while (true)
			{
				switch (FieldTypes_sr.BaseStream.ReadByte())
				{
				case 35:
				{
					Stream baseStream = FieldTypes_sr.BaseStream;
					long position = baseStream.Position;
					position += -1L;
					baseStream.Position = position;
					bool flag = false;
					while (true)
					{
						text = FieldTypes_sr.ReadLine();
						if (text == null)
						{
							break;
						}
						if (string.IsNullOrWhiteSpace(text))
						{
							continue;
						}
						if (text[0] == '#')
						{
							int num = text.IndexOf(Class16.smethod_0(1648924402));
							string text2 = null;
							text2 = ((num <= -1) ? text.Substring(1) : text.Substring(num + 1, text.Length - num - 1));
							string text3 = text2;
							// TODO(recovered): a plain comment line (e.g. "# notes ending with a colon:")
							// produced an empty header token -> text3[text3.Length-1] threw
							// IndexOutOfRangeException and aborted the whole user overlay. Treat an
							// empty/whitespace header as a comment: skip it, keep the current eList2.
							if (string.IsNullOrWhiteSpace(text2))
							{
								continue;
							}
							bool flag2;
							flag = (flag2 = text3[text3.Length - 1] == '~');
							if (flag2)
							{
								text2 = text2.Substring(0, text2.Length - 1);
							}
							if (text2 == MATTER_TEMPLATE)
							{
								if (_matterTemplate == null)
								{
									_matterTemplate = new ACE.Elements.eList.eList();
								}
								eList2 = _matterTemplate;
								flag = true;
							}
							else
							{
								int num2 = this.get_LI(text2);
								eList2 = ((num2 == -1) ? null : Lists[num2]);
							}
						}
						else
						{
							if (eList2 == null)
							{
								continue;
							}
							// TODO(recovered): also create FieldTypesDB when parsing USER types. The user
							// overlay (PW_UserTypes.csv) can bind fields on a list whose base config never
							// created a FieldTypesDB (e.g. NPC_ESSENCE), leaving it null -> fieldTypesDB.Add
							// threw NullReferenceException and aborted the whole overlay (enums/refs/values
							// stopped decoding). Create it on demand so user bindings apply.
							if (eList2.FieldTypesDB == null)
							{
								eList2.FieldTypesDB = new FIELD_TYPES_DB();
							}
							FIELD_TYPES_DB fieldTypesDB = eList2.FieldTypesDB;
							try
							{
							if (text.StartsWith(Class16.smethod_0(1648959534)))
							{
								string text4 = text.Substring(1);
								if (text4 == MATTER_TEMPLATE)
								{
									ACE.Elements.eList.eList matterTemplate = _matterTemplate;
									if (matterTemplate != null)
									{
										FIELD_TYPES_DB fieldTypesDB2 = matterTemplate.FieldTypesDB;
										if (fieldTypesDB2 != null)
										{
											fieldTypesDB2.CopyMembersTo(ref fieldTypesDB.Fields);
											continue;
										}
									}
									throw new Exception(Class16.smethod_0(1648959542));
								}
								int num3 = this.get_LI(text4);
								if (num3 > -1)
								{
									FIELD_TYPES_DB fieldTypesDB3 = Lists[num3].FieldTypesDB;
									if (fieldTypesDB3 != null)
									{
										fieldTypesDB3.CopyMembersTo(ref fieldTypesDB.Fields);
										continue;
									}
								}
								string text5 = Class16.smethod_0(1648959578);
								throw new Exception(string.Concat(Class16.smethod_0(1648959606) + text4, text5));
							}
							string[] array = text.Split(';');
							string text6 = array[0];
							string text7 = null;
							text7 = (((nint)array.LongLength <= 1 || string.IsNullOrWhiteSpace(array[1])) ? text6 : array[1]);
							bool bRegex = false;
							if (text6[0] == '~')
							{
								bRegex = true;
								text6 = text6.Substring(1);
							}
							if (flag)
							{
								bRegex = text6.Contains(Class16.smethod_0(1648938114));
							}
							fieldTypesDB.Add(text6, text7, bRegex, bUserTypes);
							}
							catch (Exception)
							{
								// TODO(recovered): a malformed/unknown field-type binding line must not
								// abort the whole overlay. Skip this single line so the remaining
								// enum/value/reference bindings on this and later lists still apply.
							}
						}
					}
					goto end_IL_0004;
				}
				case -1:
					FieldTypes_sr.Close();
					return;
				}
				continue;
				end_IL_0004:
				break;
			}
		}
		catch (Exception ex)
		{
			if (ex.GetType() == typeof(ApplicationException))
			{
				object[] vars = new object[1] { ex.Message };
				SentryHelper.CaptureException(ex, Class16.smethod_0(1648959626));
				TextStorage.TEXTS.ShowMessage(5, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, vars);
			}
			else
			{
				string key = Class16.smethod_0(1648960344);
				ex.Data.Add(key, text);
				string uListName = ((eList2 != null) ? eList2.uListName : "(null)");
				string key2 = Class16.smethod_0(1648960381);
				ex.Data.Add(key2, uListName);
				string key3 = Class16.smethod_0(1648893587);
				string text8 = string.Format(Class16.smethod_0(1648960396), FieldTypes_sr.BaseStream.Position, FieldTypes_sr.BaseStream.Length);
				ex.Data.Add(key3, text8);
				string text9 = Class16.smethod_0(1648934564) + ex.Message + Class16.smethod_0(1648934582) + ex.StackTrace + Class16.smethod_0(1648959664) + text + Class16.smethod_0(1648959688) + uListName + Class16.smethod_0(1648959707) + text8;
				SentryHelper.CaptureException(ex, Class16.smethod_0(1648959626));
				DKBox.Show(text9, Class16.smethod_0(1648959733), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
		FieldTypes_sr.Close();
		GC.KeepAlive(this);
	}

	public void LoadElements(string elFile, [MarshalAs(UnmanagedType.U1)] bool isFirstItems)
	{
		FileStream fs = null;
		BinaryReader br = null;
		Exception ex = null;
		try
		{
			fs = new FileStream(elFile, FileMode.Open, FileAccess.Read, FileShare.Read);
			br = new BinaryReader(fs);
			object[] array;
			object obj;
			object[] vars3;
			switch (status = method_0(br))
			{
			case CONFIG_LOADING_STATUS.GameNotSupported:
				TextStorage.TEXTS.ShowMessage(552, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, null);
				return;
			case CONFIG_LOADING_STATUS.LicenseNotSet:
				TextStorage.TEXTS.ShowMessage(673, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, null);
				return;
			case CONFIG_LOADING_STATUS.UnknownVersion:
				unkVersion = true;
				goto case CONFIG_LOADING_STATUS.Success;
			case CONFIG_LOADING_STATUS.Success:
			{
				DateTime lastWriteTime = File.GetLastWriteTime(elFile);
				TimeChange = lastWriteTime;
				if (unkVersion)
				{
					LoadFirst2IDs();
				}
				if (ACE.Elements.eList.eList.IsElementsPacked(Game, Version) && !isFirstItems)
				{
					isPacked = true;
					int num = (int)((Lists != null) ? Lists.LongLength : 0L);
					br = UnpackElements(ref fs, ref br, Game, Version, ref Lists, ref ConversationListIndex, unkVersion, first2IDs);
					if (Lists != null && num != (int)Lists.LongLength)
					{
						ListCount = Lists.Length;
						FillListsArrays();
					}
				}
				if (unkVersion)
				{
					TryReadUnknownVersion(br);
				}
				else if (!bMultithread && !CommonStorage.AParams.DisableParallelElementsLoading)
				{
					ReadKnownVersionParallel(br, isFirstItems);
				}
				else
				{
					ReadKnownVersion(br, isFirstItems);
				}
				int num2 = (int)(br.BaseStream.Length - br.BaseStream.Position);
				if ((uint)(num2 - 1) <= 99999998u)
				{
					BytesAfterEndOfFile = br.ReadBytes(num2);
				}
				method_10();
				FileName = elFile;
				FileLoaded = true;
				break;
			}
			case CONFIG_LOADING_STATUS.VersionNotSupported:
			{
				object[] vars2 = new object[1] { (DetectedVersion > 0) ? DetectedVersion : Version };
				TextStorage.TEXTS.ShowMessage(553, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, vars2);
				return;
			}
			default:
			{
				array = new object[1];
				Exception ex3 = sharedException;
				if (ex3 == null)
				{
					obj = null;
				}
				else
				{
					obj = ex3.Message;
					if (obj != null)
					{
						goto IL_0242;
					}
				}
				obj = Class16.smethod_0(1648959775);
				goto IL_0242;
			}
			case CONFIG_LOADING_STATUS.ProtectectedFile:
				TextStorage.TEXTS.ShowMessage(660, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, null);
				return;
			case CONFIG_LOADING_STATUS.LicenseExpired:
				TextStorage.TEXTS.ShowMessage(490, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, null);
				return;
			case CONFIG_LOADING_STATUS.LicenseBlocked:
				TextStorage.TEXTS.ShowMessage(360, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, null);
				return;
			case CONFIG_LOADING_STATUS.LicenseReseted:
				TextStorage.TEXTS.ShowMessage(672, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, null);
				return;
			case CONFIG_LOADING_STATUS.AuthenticationFailed:
				{
					string text = string.Empty;
					Exception ex2 = sharedException;
					if (ex2 != null)
					{
						text = ex2.Message;
					}
					object[] vars = new object[1] { text };
					TextStorage.TEXTS.ShowMessage(359, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, vars);
					return;
				}
				IL_0242:
				array[0] = obj;
				vars3 = array;
				TextStorage.TEXTS.ThrowEcxeptionT(483, vars3);
				return;
			}
		}
		catch (IOException ex4)
		{
			Lists = null;
			FileLoaded = false;
			ex = ex4;
			object[] vars4 = new object[1] { elFile };
			TextStorage.TEXTS.ShowMessage(5, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, vars4);
		}
		catch (Exception ex5)
		{
			Lists = null;
			FileLoaded = false;
			bool flag = ConfigCount > 1 && ConfigIndex + 1 < ConfigCount;
			if (ex5.GetType() == typeof(ApplicationException) && sharedException == null)
			{
				ex = ex5;
				if (!flag)
				{
					object[] vars5 = new object[1] { ex5.Message };
					TextStorage.TEXTS.ShowMessage(5, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, vars5);
					string key = Class16.smethod_0(1648959802);
					ex5.Data.Add(key, true);
					SentryHelper.CaptureException(ex5, Class16.smethod_0(1648959829));
				}
			}
			else
			{
				Exception ex6 = sharedException;
				Exception ex7 = ((ex6 == null) ? ex5 : ex6);
				ex = ex7;
				GAMES game = Game;
				string key2 = Class16.smethod_0(1648959856);
				ex7.Data.Add(key2, (int)game);
				short version = Version;
				string key3 = Class16.smethod_0(1648959878);
				ex7.Data.Add(key3, version);
				short version2 = Version;
				string key4 = Class16.smethod_0(1648959895);
				ex7.Data.Add(key4, version2);
				uint timeStamp = TimeStamp;
				string key5 = Class16.smethod_0(1648959906);
				ex7.Data.Add(key5, timeStamp);
				string key6 = Class16.smethod_0(1648959933);
				ex7.Data.Add(key6, elFile);
				if (fs != null)
				{
					string format = Class16.smethod_0(1648960396);
					string key7 = Class16.smethod_0(1648893587);
					ex7.Data.Add(key7, string.Format(format, fs.Position, fs.Length));
				}
				SentryHelper.CaptureException(ex5, Class16.smethod_0(1648959829));
			}
		}
		finally
		{
			br?.Close();
			fs?.Close();
			CONFIG_LOADING_STATUS cONFIG_LOADING_STATUS = status;
			if (cONFIG_LOADING_STATUS == CONFIG_LOADING_STATUS.LicenseExpired || cONFIG_LOADING_STATUS == CONFIG_LOADING_STATUS.LicenseBlocked || cONFIG_LOADING_STATUS == CONFIG_LOADING_STATUS.LicenseReseted || cONFIG_LOADING_STATUS == CONFIG_LOADING_STATUS.LicenseNotSet)
			{
				License.Unregister(bDeleteLicense: true);
				int num3 = (int)status;
				ACE.RSGlobal.RSGlobal.End(Class16.smethod_0(1648959939) + num3, null);
			}
		}
		if (ex == null)
		{
			return;
		}
		int configCount = ConfigCount;
		if (configCount > 1 && ++ConfigIndex < configCount)
		{
			LoadElements(elFile, isFirstItems);
			return;
		}
		string key8 = Class16.smethod_0(1648959802);
		if (!ex.Data.Contains(key8))
		{
			string text2 = Class16.smethod_0(1648934564) + ex.Message + Class16.smethod_0(1648934582) + ex.StackTrace + Class16.smethod_0(1648934604);
			foreach (DictionaryEntry datum in ex.Data)
			{
				text2 += string.Format(Class16.smethod_0(1648934622), datum.Key, datum.Value);
			}
			DKBox.Show(text2, Class16.smethod_0(1648959974), MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		sharedException = ex;
	}

	private static bool smethod_2(BinaryReader binaryReader_0)
	{
		long position = binaryReader_0.BaseStream.Position;
		try
		{
			long length = binaryReader_0.BaseStream.Length;
			if (position + 4L > length)
			{
				return false;
			}
			uint num = binaryReader_0.ReadUInt32();
			if (num > 200000)
			{
				binaryReader_0.BaseStream.Position = position;
				return false;
			}
			long num2 = 0L;
			uint num3 = 0u;
			while (true)
			{
				if (num3 < num)
				{
					if (binaryReader_0.BaseStream.Position + 6L <= length)
					{
						binaryReader_0.ReadUInt32();
						ushort num4 = binaryReader_0.ReadUInt16();
						num2 += num4;
						if (num2 > 2147483647L)
						{
							break;
						}
						num3++;
						continue;
					}
					binaryReader_0.BaseStream.Position = position;
					return false;
				}
				if (binaryReader_0.BaseStream.Position + 4L > length)
				{
					binaryReader_0.BaseStream.Position = position;
					return false;
				}
				uint num5 = binaryReader_0.ReadUInt32();
				if (num5 != (uint)num2)
				{
					binaryReader_0.BaseStream.Position = position;
					return false;
				}
				if (binaryReader_0.BaseStream.Position + num2 > length)
				{
					binaryReader_0.BaseStream.Position = position;
					return false;
				}
				binaryReader_0.BaseStream.Position += num2;
				return true;
			}
			binaryReader_0.BaseStream.Position = position;
			return false;
		}
		catch
		{
			binaryReader_0.BaseStream.Position = position;
			return false;
		}
	}

	private static bool smethod_3(BinaryReader binaryReader_0, out byte[] byte_0)
	{
		long position = binaryReader_0.BaseStream.Position;
		try
		{
			int conversationListLength = ACE.Elements.eList.eList.GetConversationListLength(binaryReader_0);
			if (conversationListLength > 0 && position + conversationListLength <= binaryReader_0.BaseStream.Length)
			{
				byte_0 = binaryReader_0.ReadBytes(conversationListLength);
				if (byte_0 != null && byte_0.Length == conversationListLength)
				{
					return true;
				}
				binaryReader_0.BaseStream.Position = position;
				byte_0 = null;
				return false;
			}
			binaryReader_0.BaseStream.Position = position;
			byte_0 = null;
			return false;
		}
		catch
		{
			binaryReader_0.BaseStream.Position = position;
			byte_0 = null;
			return false;
		}
	}

	private static bool smethod_4(BinaryReader binaryReader_0, BinaryWriter binaryWriter_0)
	{
		if (!smethod_3(binaryReader_0, out var byte_))
		{
			return false;
		}
		binaryWriter_0.Write(byte_);
		return true;
	}

	private static bool smethod_5(BinaryReader binaryReader_0, out Struct56 struct56_0)
	{
		long position = binaryReader_0.BaseStream.Position;
		struct56_0 = default(Struct56);
		try
		{
			long length = binaryReader_0.BaseStream.Length;
			if (position + 4L > length)
			{
				return false;
			}
			uint num = binaryReader_0.ReadUInt32();
			if (num > 200000)
			{
				binaryReader_0.BaseStream.Position = position;
				return false;
			}
			if (num == 0)
			{
				struct56_0 = new Struct56
				{
					uint_0 = 0u,
					int_0 = 68,
					byte_0 = Array.Empty<byte[]>()
				};
				return true;
			}
			short[] array = new short[num];
			long num2 = 0L;
			uint num3 = 0u;
			while (true)
			{
				if (num3 < num)
				{
					if (binaryReader_0.BaseStream.Position + 6L <= length)
					{
						binaryReader_0.ReadUInt32();
						num2 += (array[num3] = (short)binaryReader_0.ReadUInt16());
						if (num2 > 2147483647L)
						{
							break;
						}
						num3++;
						continue;
					}
					binaryReader_0.BaseStream.Position = position;
					return false;
				}
				if (binaryReader_0.BaseStream.Position + 4L > length)
				{
					binaryReader_0.BaseStream.Position = position;
					return false;
				}
				uint num4 = binaryReader_0.ReadUInt32();
				if (num4 != (uint)num2)
				{
					binaryReader_0.BaseStream.Position = position;
					return false;
				}
				if (binaryReader_0.BaseStream.Position + num2 > length)
				{
					binaryReader_0.BaseStream.Position = position;
					return false;
				}
				byte[][] array2 = new byte[num][];
				pw_mppc_unmanaged pw_mppc_unmanaged2 = new pw_mppc_unmanaged();
				int num5 = 0;
				uint num6 = 0u;
				while (true)
				{
					if (num6 < num)
					{
						byte[] array3 = binaryReader_0.ReadBytes(array[num6]);
						byte[] array4 = pw_mppc_unmanaged2.decompress(array3, 262144);
						if (array4 == null)
						{
							try
							{
								array4 = MppcUnpacker.Decompress(array3);
							}
							catch
							{
								array4 = null;
							}
						}
						if (array4 == null || array4.Length == 0)
						{
							break;
						}
						if (array4.Length > num5)
						{
							int num7 = array4.Length;
							for (uint num8 = 0u; num8 < num6; num8++)
							{
								byte[] array5 = array2[num8];
								if (array5 != null && array5.Length != num7)
								{
									byte[] array6 = new byte[num7];
									Buffer.BlockCopy(array5, 0, array6, 0, Math.Min(array5.Length, num7));
									array2[num8] = array6;
								}
							}
							num5 = num7;
						}
						if (array4.Length < num5)
						{
							byte[] array7 = new byte[num5];
							Buffer.BlockCopy(array4, 0, array7, 0, array4.Length);
							array4 = array7;
						}
						array2[num6] = array4;
						num6++;
						continue;
					}
					struct56_0 = new Struct56
					{
						uint_0 = num,
						int_0 = num5,
						byte_0 = array2
					};
					return true;
				}
				binaryReader_0.BaseStream.Position = position;
				return false;
			}
			binaryReader_0.BaseStream.Position = position;
			return false;
		}
		catch
		{
			binaryReader_0.BaseStream.Position = position;
			struct56_0 = default(Struct56);
			return false;
		}
	}

	private static void smethod_6(ACE.Elements.eList.eList eList_0, int int_0)
	{
		int num = Math.Min(64, Math.Max(0, int_0 - 4));
		int num2 = int_0 - 4 - num;
		int num3 = Math.Max(0, num2 / 4);
		int num4 = Math.Max(0, num2 % 4);
		int num5 = ((num4 > 0) ? 1 : 0);
		int num6 = 2 + num3 + num5;
		if (num6 < 2)
		{
			num6 = 2;
		}
		eList_0.elementFields = new string[num6];
		eList_0.elementTypes = new string[num6];
		eList_0.elementFields[0] = Class16.smethod_0(1648941057);
		eList_0.elementTypes[0] = Class16.smethod_0(1648989776);
		eList_0.elementFields[1] = Class16.smethod_0(1648936731);
		eList_0.elementTypes[1] = Class16.smethod_0(1648985302) + num;
		eList_0.NameFieldIndex = 1;
		for (int i = 0; i < num3; i++)
		{
			eList_0.elementFields[2 + i] = Class16.smethod_0(1648963085) + (i + 1);
			eList_0.elementTypes[2 + i] = Class16.smethod_0(1648989776);
		}
		if (num4 > 0)
		{
			int num7 = num6 - 1;
			eList_0.elementFields[num7] = Class16.smethod_0(1648963088);
			eList_0.elementTypes[num7] = Class16.smethod_0(1648985282) + num4;
		}
	}

	private static int smethod_7(ref ACE.Elements.eList.eList[] eList_0, ref int int_0, int int_1, List<Struct56> list_0)
	{
		int num = list_0?.Count ?? 0;
		if (num <= 0)
		{
			return 0;
		}
		int num2 = eList_0.Length;
		Array.Resize(ref eList_0, num2 + num);
		for (int num3 = num2 - 1; num3 >= int_1; num3--)
		{
			eList_0[num3 + num] = eList_0[num3];
		}
		for (int i = 0; i < num; i++)
		{
			int num4 = int_1 + i;
			ACE.Elements.eList.eList eList2 = new ACE.Elements.eList.eList();
			eList2.ListIndex = num4;
			eList2._list_type = num4;
			eList2._idSpace = 0;
			eList2.item_size = list_0[i].int_0;
			eList2.uListName = (eList2.ListName = string.Format(Class16.smethod_0(1648963104), num4 + 1));
			smethod_6(eList2, eList2.item_size);
			eList_0[num4] = eList2;
		}
		for (int j = int_1 + num; j < eList_0.Length; j++)
		{
			ACE.Elements.eList.eList eList3 = eList_0[j];
			if (eList3 != null)
			{
				eList3.ListIndex = j;
				eList3._list_type = j;
			}
		}
		int_0 += num;
		return num;
	}

	private static void smethod_8(BinaryWriter binaryWriter_0, int int_0, ACE.Elements.eList.eList eList_0, Struct56 struct56_0)
	{
		binaryWriter_0.Write(eList_0?._idSpace ?? 0);
		binaryWriter_0.Write(eList_0?._list_type ?? int_0);
		binaryWriter_0.Write(struct56_0.int_0);
		binaryWriter_0.Write(struct56_0.uint_0);
		if (struct56_0.byte_0 != null && struct56_0.byte_0.Length != 0)
		{
			for (int i = 0; i < struct56_0.byte_0.Length; i++)
			{
				binaryWriter_0.Write(struct56_0.byte_0[i]);
			}
		}
	}

	public static BinaryReader UnpackElements(ref FileStream fs, ref BinaryReader br, GAMES Game, short Version, ref ACE.Elements.eList.eList[] Lists, ref int ConversationListIndex, [MarshalAs(UnmanagedType.U1)] bool unkVersion, ID_2[] first2IDs)
	{
		MemoryStream memoryStream = new MemoryStream();
		BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
		int num = 0;
		int num5;
		while (true)
		{
			if (num < (nint)Lists.LongLength)
			{
				Application.DoEvents();
				if (num == ConversationListIndex)
				{
					long position = br.BaseStream.Position;
					if (unkVersion && Game == GAMES.PW)
					{
						int num2 = ConversationListIndex;
						List<Struct56> list = new List<Struct56>();
						Struct56 struct56_;
						while (list.Count < 50 && smethod_5(br, out struct56_))
						{
							list.Add(struct56_);
						}
						if (smethod_3(br, out var byte_))
						{
							int num3 = smethod_7(ref Lists, ref ConversationListIndex, num2, list);
							if (num3 > 0)
							{
								for (int i = 0; i < num3; i++)
								{
									int num4 = num2 + i;
									smethod_8(binaryWriter, num4, Lists[num4], list[i]);
								}
							}
							binaryWriter.Write(byte_);
							num = ConversationListIndex;
							goto IL_0386;
						}
						br.BaseStream.Position = position;
					}
					if (smethod_4(br, binaryWriter))
					{
						goto IL_0386;
					}
					br.BaseStream.Position = position;
				}
				if (Game == GAMES.PW && num == 0)
				{
					byte[] buffer = Read_PW_ZeroOffsets(br, Version);
					binaryWriter.Write(buffer);
				}
				num5 = ACE.Elements.eList.eList.GetListItemSize(Lists[num], skipStrings: false);
				int num6 = ((Game == GAMES.ROG || Game == GAMES.TOS) ? 1 : 0);
				bool flag = (byte)num6 != 0;
				int num7 = -1;
				int num8 = -1;
				if (flag)
				{
					num7 = br.ReadInt32();
					num8 = br.ReadInt32();
					num5 = br.ReadInt32();
				}
				if (num5 <= 0 || num5 > 100000000)
				{
					break;
				}
				uint num9 = br.ReadUInt32();
				if (num9 <= 10000000)
				{
					byte[][] array = new byte[0][];
					int[] array2 = new int[num9];
					bool flag2 = false;
					if (num9 != 0)
					{
						short[] array3 = new short[num9];
						uint num10 = 0u;
						if (0 < num9)
						{
							do
							{
								array2[num10] = (int)br.ReadUInt32();
								if (unkVersion && first2IDs != null && num < (nint)first2IDs.LongLength)
								{
									switch (num10)
									{
									case 1u:
										first2IDs[num].id2 = array2[1];
										break;
									case 0u:
										first2IDs[num].id1 = array2[0];
										break;
									}
								}
								short num11 = (short)br.ReadUInt16();
								array3[num10] = num11;
								num10++;
							}
							while (num10 < num9);
						}
						br.ReadUInt32();
						array = new byte[num9][];
						for (uint num12 = 0u; num12 < num9; num12++)
						{
							byte[] array4 = br.ReadBytes(array3[num12]);
							byte[] array5 = null;
							if (flag)
							{
								array5 = ZlibHelpers.Uncompress_SharpZipLib(array4, num5);
							}
							else
							{
								bool flag3 = false;
								try
								{
									array5 = Lists[num].mppc_unmanaged.decompress(array4, num5);
									if (array5 != null)
									{
										int num13 = array5.Length;
										if (num13 != num5)
										{
											num5 = num13;
											flag2 = true;
										}
										flag3 = true;
									}
								}
								catch
								{
								}
								if (!flag3)
								{
									array5 = TryDecompressUnknownVersion(array4, num5);
									if (array5 == null)
									{
										string message = string.Format(Class16.smethod_0(1648963278), num, Lists[num].uListName, num12, num5, array4.Length, Game, Version);
										throw new ApplicationException(message);
									}
									int num14 = array5.Length;
									if (num14 != num5)
									{
										num5 = num14;
										flag2 = true;
									}
								}
							}
							array[num12] = array5;
						}
					}
					if (!flag && flag2)
					{
						uint num15 = 0u;
						if (0 < num9)
						{
							do
							{
								byte[] array6 = array[num15];
								if (array6 != null)
								{
									if ((nint)array6.LongLength != num5)
									{
										byte[] array7 = new byte[num5];
										Buffer.BlockCopy(array6, 0, array7, 0, Math.Min(array6.Length, num5));
										array[num15] = array7;
									}
									num15++;
									continue;
								}
								string message2 = string.Format(Class16.smethod_0(1648963393), num, Lists[num].uListName, num15, num5, Game, Version);
								throw new ApplicationException(message2);
							}
							while (num15 < num9);
						}
					}
					int value = ((num7 <= -1) ? Lists[num]._idSpace : num7);
					binaryWriter.Write(value);
					int value2 = ((num8 > -1) ? num8 : num);
					binaryWriter.Write(value2);
					binaryWriter.Write(num5);
					binaryWriter.Write(num9);
					int num16 = 0;
					if (0 < (nint)array.LongLength)
					{
						do
						{
							binaryWriter.Write(array[num16]);
							num16++;
						}
						while (num16 < (nint)array.LongLength);
					}
					goto IL_0386;
				}
				throw new ApplicationException(string.Format(Class16.smethod_0(1648963200), num9, num, Lists[num].uListName));
			}
			BinaryReader binaryReader = br;
			BinaryReader binaryReader2 = br;
			int num17 = (int)(binaryReader.BaseStream.Length - binaryReader2.BaseStream.Position);
			if ((uint)(num17 - 1) <= 99999998u)
			{
				binaryWriter.Write(br.ReadBytes(num17));
			}
			memoryStream.Position = 0L;
			br.Close();
			fs.Close();
			return new BinaryReader(memoryStream);
			IL_0386:
			num++;
		}
		throw new ApplicationException(string.Format(Class16.smethod_0(1648963131), num5, num, Lists[num].uListName));
	}

	public static byte[] TryDecompressUnknownVersion(byte[] packedItem, int origStructSize)
	{
		if (packedItem != null && packedItem.Length != 0)
		{
			try
			{
				pw_mppc_unmanaged pw_mppc_unmanaged2 = new pw_mppc_unmanaged();
				byte[] array = pw_mppc_unmanaged2.decompress(packedItem, 262144);
				if (array != null)
				{
					return array;
				}
				array = pw_mppc_unmanaged2.decompress(packedItem, 8192);
				if (array != null)
				{
					return array;
				}
			}
			catch
			{
			}
			try
			{
				return MppcUnpacker.Decompress(packedItem);
			}
			catch
			{
			}
			return null;
		}
		return null;
	}

	public static byte[] AutoDetectOffset(BinaryReader br, GAMES Game, short Version, int int_0, ACE.Elements.eList.eList list, [MarshalAs(UnmanagedType.U1)] bool domesticPW)
	{
		if (Version == 32222)
		{
			return null;
		}
		list.listOffset = br.BaseStream.Position;
		byte[] listOffsetData = list.listOffsetData;
		if (listOffsetData != null)
		{
			int num = listOffsetData.Length;
			if (num != 0)
			{
				byte[] array = (list.listOffsetData = br.ReadBytes(num));
				if (Game != GAMES.PW && (nint)array.LongLength == 4)
				{
					br.BaseStream.Position -= 4L;
					list.item_size = br.ReadInt32();
				}
				return list.listOffsetData;
			}
		}
		int offset_after = 0;
		if (Game != GAMES.PW)
		{
			offset_after = 4;
		}
		else if (!domesticPW && int_0 == 0 && Version >= 191)
		{
			int num2 = ((Version == 1488 || Version >= 30000) ? 1 : 0);
			if ((byte)num2 == 0)
			{
				return Read_PW_ZeroOffsets(br, Version);
			}
		}
		if (int_0 == Get_NPC_TALK_ListIndex(Game, Version, CROSS_LISTS, domesticPW))
		{
			return Read_NPC_TALK_Offsets(list, br, offset_after);
		}
		if (Game == GAMES.PW && domesticPW && Version >= 262 && int_0 == 99)
		{
			return Read_talk_proc_Offsets(br, 0);
		}
		if (int_0 == Get_talk_proc_ListIndex(Game, Version, CROSS_LISTS, domesticPW))
		{
			return Read_talk_proc_Offsets(br, offset_after);
		}
		return null;
	}

	public static byte[] Read_PW_ZeroOffsets(BinaryReader br, int version)
	{
		if (version >= 350)
		{
			int num = ((version == 1488 || version >= 30000) ? 1 : 0);
			if ((byte)num == 0)
			{
				return Read_PW_ZeroOffsets_v350plus(br);
			}
		}
		uint num2 = br.ReadUInt32();
		br.BaseStream.Position -= 4L;
		int num4;
		if (version >= 350)
		{
			int num3 = ((version == 1488 || version >= 30000) ? 1 : 0);
			if ((byte)num3 == 0)
			{
				num4 = 100;
				goto IL_0072;
			}
		}
		num4 = 0;
		goto IL_0072;
		IL_0072:
		return br.ReadBytes((int)num2 + num4 + 4);
	}

	public static byte[] Read_PW_ZeroOffsets_v350plus(BinaryReader br)
	{
		long position = br.BaseStream.Position;
		uint num = br.ReadUInt32();
		br.BaseStream.Position += num + 4;
		uint num2 = br.ReadUInt32();
		br.BaseStream.Position += num2 + 8;
		uint num3 = br.ReadUInt32();
		long num4 = br.BaseStream.Position + num3;
		br.BaseStream.Position = position;
		return br.ReadBytes((int)(num4 - position));
	}

	public static byte[] Read_NPC_TALK_Offsets(ACE.Elements.eList.eList list, BinaryReader br, int offset_after)
	{
		list.NPC_TALK = new EL_COMPUTER_DATA();
		list.NPC_TALK.tag = br.ReadBytes(4);
		list.NPC_TALK.len = br.ReadInt32();
		list.NPC_TALK.body = br.ReadBytes(list.NPC_TALK.len);
		list.NPC_TALK.timestamp = br.ReadInt32();
		EL_COMPUTER_DATA nPC_TALK = list.NPC_TALK;
		byte[] array = new byte[offset_after + nPC_TALK.len + 12];
		byte[] tag = nPC_TALK.tag;
		Array.Copy(tag, 0, array, 0, tag.Length);
		Array.Copy(BitConverter.GetBytes(list.NPC_TALK.len), 0, array, 4, 4);
		byte[] body = list.NPC_TALK.body;
		Array.Copy(body, 0, array, 8, body.Length);
		EL_COMPUTER_DATA nPC_TALK2 = list.NPC_TALK;
		int destinationIndex = nPC_TALK2.len + 8;
		Array.Copy(BitConverter.GetBytes(nPC_TALK2.timestamp), 0, array, destinationIndex, 4);
		list.NPC_TALK.offset_after = offset_after;
		if (offset_after != 0)
		{
			list.NPC_TALK.ExtraOffset = br.ReadBytes(offset_after);
			Array.Copy(list.NPC_TALK.ExtraOffset, 0, array, (int)((nint)array.LongLength - offset_after), offset_after);
		}
		return array;
	}

	public void Write_NPC_TALK_Offsets(EL_COMPUTER_DATA NPC_TALK, BinaryWriter bw, [MarshalAs(UnmanagedType.U1)] bool bEncryptElements)
	{
		bool flag = false;
		bool flag2 = ProtectionStatus == ELEMENTS_PROTECTION_STATUS.PROTECTED_BY_LOGIN;
		if (!LICENSE_INFO.Info.bTrial && flag2)
		{
			byte[] array = ACE.RSGlobal.RSGlobal.GenerateMapKey(8, 8);
			byte[] array2 = new byte[0];
			if (IsElementsEncrypted && bEncryptElements)
			{
				array2 = ACE.RSGlobal.RSGlobal.MapEncrypt(ElementsCrypter.key, array);
			}
			if (AllowedLogins == null)
			{
				AllowedLogins = new string[1] { string.Empty };
			}
			string[] allowedLogins = AllowedLogins;
			string separator = Class16.smethod_0(1648941987);
			byte[] bytes = Encoding.UTF8.GetBytes(string.Join(separator, allowedLogins));
			byte[] array3 = ACE.RSGlobal.RSGlobal.MapEncrypt(bytes, array);
			string userName = License.UserName;
			byte[] array4 = ACE.RSGlobal.RSGlobal.MapEncrypt(Encoding.UTF8.GetBytes(userName), array);
			byte[] bytes2 = RSMD5.GetBytes(bytes);
			int value = (int)((nint)array.LongLength + ((nint)bytes2.LongLength + (nint)array4.LongLength + (nint)array3.LongLength + (nint)array2.LongLength) + 28);
			MemoryStream memoryStream = new MemoryStream();
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			int num = ((ProtectionStatus == ELEMENTS_PROTECTION_STATUS.PROTECTED_BY_LOGIN) ? 1 : 0);
			binaryWriter.Write((byte)num);
			binaryWriter.Write((byte)3);
			binaryWriter.Write(value);
			binaryWriter.Write(RealTimeStamp);
			binaryWriter.Write(IsUsersCanEditPermissions ? ((byte)1) : ((byte)0));
			binaryWriter.Write(IsElementsEncrypted ? ((byte)1) : ((byte)0));
			binaryWriter.Write(array.Length);
			binaryWriter.Write(array2.Length);
			binaryWriter.Write(array3.Length);
			binaryWriter.Write(array4.Length);
			binaryWriter.Write(array);
			if ((nint)array2.LongLength > 0)
			{
				binaryWriter.Write(array2);
			}
			binaryWriter.Write(array3);
			binaryWriter.Write(array4);
			binaryWriter.Write(bytes2);
			binaryWriter.Close();
			NPC_TALK.body = memoryStream.ToArray();
			memoryStream.Close();
			int num2 = 0;
			do
			{
				byte b = (byte)RND.GenerateRnd(1, 254);
				NPC_TALK.tag[num2] = b;
				num2++;
			}
			while (num2 < 4);
			flag = true;
		}
		else if ((nint)NPC_TALK.body.LongLength > 16)
		{
			NPC_TALK.tag = BitConverter.GetBytes(2876672477u);
			string s = Class16.smethod_0(1648963514);
			NPC_TALK.body = Encoding.UTF8.GetBytes(s);
			flag = true;
		}
		int num3 = (NPC_TALK.len = NPC_TALK.body.Length);
		if (flag)
		{
			int num4 = 0;
			if (0 < num3)
			{
				do
				{
					byte[] body = NPC_TALK.body;
					body[num4] = (byte)(NPC_TALK.tag[3 - num4 % 4] ^ body[num4]);
					num4++;
				}
				while (num4 < NPC_TALK.len);
			}
		}
		if (!CommonStorage.AParams.DontUpdateRealTimestamp)
		{
			NPC_TALK.timestamp = (int)RealTimeStamp;
		}
		bw.Write(NPC_TALK.tag);
		bw.Write(NPC_TALK.len);
		bw.Write(NPC_TALK.body);
		bw.Write(NPC_TALK.timestamp);
		if (NPC_TALK.offset_after != 0)
		{
			bw.Write(NPC_TALK.ExtraOffset);
		}
		GC.KeepAlive(this);
	}

	public static byte[] Read_talk_proc_Offsets(BinaryReader br, int offset_after)
	{
		byte[] array = br.ReadBytes(4);
		int num = br.ReadInt32();
		byte[] array2 = br.ReadBytes(num);
		byte[] array3 = new byte[offset_after + num + 8];
		Array.Copy(array, 0, array3, 0, array.Length);
		Array.Copy(BitConverter.GetBytes(num), 0, array3, 4, 4);
		Array.Copy(array2, 0, array3, 8, array2.Length);
		if (offset_after != 0)
		{
			int destinationIndex = (int)((nint)array3.LongLength - offset_after);
			Array.Copy(br.ReadBytes(offset_after), 0, array3, destinationIndex, offset_after);
		}
		return array3;
	}

	public static byte[] DetectOffsetByFirstID(BinaryReader br, int id)
	{
		long position = br.BaseStream.Position;
		int num = 0;
		if (br.ReadInt32() != id)
		{
			do
			{
				br.BaseStream.Position -= 3L;
				num++;
			}
			while (br.ReadInt32() != id);
		}
		br.BaseStream.Position = position;
		return br.ReadBytes(num - 4);
	}

	public int GetItemNameIndex(int int_0)
	{
		return Lists[int_0].NameFieldIndex;
	}

	public int GetItemTypeIndex(int int_0)
	{
		return Lists[int_0].TypeFieldIndex;
	}

	public int GetItemSubtypeIndex(int int_0)
	{
		return Lists[int_0].SubTypeFieldIndex;
	}

	public void SetFieldBindedList(int int_0, int int_1, int BindedListIndex)
	{
		SetFieldBindedLists(int_0, int_1, new int[1] { BindedListIndex });
		GC.KeepAlive(this);
	}

	public void SetFieldBindedList(int int_0, string FieldUName, int BindedListIndex)
	{
		int num = Lists[int_0].get_fields(FieldUName);
		if (num > -1)
		{
			SetFieldBindedList(int_0, num, BindedListIndex);
		}
	}

	public void SetFieldBindedLists(int int_0, int int_1, int[] BindedListIndexes)
	{
		Lists[int_0].fieldtypes[int_1] = FIELDTYPE.custom_list;
		if (Lists[int_0].FieldsBindedLists == null)
		{
			Lists[int_0].FieldsBindedLists = new Dictionary<int, int[]>();
		}
		if (!Lists[int_0].FieldsBindedLists.ContainsKey(int_1))
		{
			Lists[int_0].FieldsBindedLists.Add(int_1, BindedListIndexes);
		}
		else
		{
			Lists[int_0].FieldsBindedLists[int_1] = BindedListIndexes;
		}
		int num = 0;
		if (0 < (nint)BindedListIndexes.LongLength)
		{
			do
			{
				AddReferenceToList(BindedListIndexes[num], int_0, int_1);
				num++;
			}
			while (num < (nint)BindedListIndexes.LongLength);
		}
	}

	public void AddReferenceToList(int binded_l, int referenced_l, int referenced_list_f)
	{
		List<int> list = null;
		if (Lists[binded_l].References == null)
		{
			Lists[binded_l].References = new Dictionary<int, List<int>>();
		}
		list = null;
		if (!Lists[binded_l].References.TryGetValue(referenced_l, out list))
		{
			list = new List<int>();
			Lists[binded_l].References.Add(referenced_l, list);
		}
		list.Add(referenced_list_f);
		GC.KeepAlive(this);
	}

	public void SetFieldType(ACE.Elements.eList.eList list, int int_0, FIELDTYPE ftype)
	{
		List<int> list2 = null;
		list.fieldtypes[int_0] = ftype;
		switch (ftype)
		{
		case FIELDTYPE.ft_hex_color:
			list.ColorFieldIndex = int_0;
			list.elementTypes[int_0] = Class16.smethod_0(1648983932);
			break;
		case FIELDTYPE.file_model:
			if (list.ModelFieldIndex <= 0)
			{
				list.ModelFieldIndex = int_0;
			}
			break;
		case FIELDTYPE.file_icon:
			if (list.IconFieldIndex < 0)
			{
				list.IconFieldIndex = int_0;
			}
			break;
		case FIELDTYPE.file_icon_tga:
			if (list.IconFieldIndex < 0)
			{
				list.IconFieldIndex = int_0;
				list.IsTgaIcon = true;
			}
			break;
		case FIELDTYPE.ft_fixed_props:
		case FIELDTYPE.color_fw:
			list.ColorFieldIndex = int_0;
			break;
		}
		int listIndex = list.ListIndex;
		switch (ftype)
		{
		case FIELDTYPE.refine_addon_pw:
		case FIELDTYPE.equip_addon:
		case FIELDTYPE.complect_equip:
		case FIELDTYPE.mob_npc_mine:
		case FIELDTYPE.matters_and_equip_suite:
		case FIELDTYPE.homes:
		case FIELDTYPE.transcription_jd:
		case FIELDTYPE.npc_services:
		case FIELDTYPE.drop_tables:
		case FIELDTYPE.any_list:
		{
			int[] fieldLists = GetFieldLists(ftype);
			int num = 0;
			if (0 < (nint)fieldLists.LongLength)
			{
				do
				{
					AddReferenceToList(fieldLists[num], listIndex, int_0);
					num++;
				}
				while (num < (nint)fieldLists.LongLength);
			}
			break;
		}
		case FIELDTYPE.matters:
			list2 = null;
			if (!MattersReferencesBase.TryGetValue(listIndex, out list2))
			{
				list2 = new List<int>();
				MattersReferencesBase.Add(listIndex, list2);
			}
			list2.Add(int_0);
			break;
		}
	}

	public void SetFieldType(int int_0, int int_1, FIELDTYPE ftype)
	{
		SetFieldType(Lists[int_0], int_1, ftype);
	}

	public int[] GetFieldLists(FIELDTYPE fieldtype)
	{
		int[] value = null;
		Dictionary<int, int[]> fieldListsCache = FieldListsCache;
		if (fieldListsCache != null && fieldListsCache.TryGetValue((int)fieldtype, out value))
		{
			GC.KeepAlive(this);
			return value;
		}
		switch (fieldtype)
		{
		case FIELDTYPE.refine_addon_pw:
		case FIELDTYPE.equip_addon:
			value = new int[1] { addons_l };
			break;
		case FIELDTYPE.matters:
			return MattersLists;
		default:
			return AllLists;
		case FIELDTYPE.complect_equip:
			return EquipmentLists;
		case FIELDTYPE.mob_npc_mine:
		{
			string lIST_NAME5 = Class16.smethod_0(1648963535);
			string lIST_NAME6 = Class16.smethod_0(1648960167);
			value = ACE.RSGlobal.RSGlobal.iarr(this.get_LI(Class16.smethod_0(1648963546)), this.get_LI(lIST_NAME6), this.get_LI(lIST_NAME5));
			break;
		}
		case FIELDTYPE.matters_and_equip_suite:
			if (MattersAnd90 == null)
			{
				int[] mattersLists = MattersLists;
				mattersLists.CopyTo(MattersAnd90 = new int[(nint)mattersLists.LongLength + 1], 0);
				int[] mattersAnd = MattersAnd90;
				int num = (int)((nint)mattersAnd.LongLength - 1);
				mattersAnd[num] = this.get_LI(Class16.smethod_0(1648923298));
			}
			return MattersAnd90;
		case FIELDTYPE.homes:
		{
			string lIST_NAME3 = Class16.smethod_0(1648963568);
			string lIST_NAME4 = Class16.smethod_0(1648962575);
			value = ACE.RSGlobal.RSGlobal.iarr(this.get_LI(Class16.smethod_0(1648962599)), this.get_LI(lIST_NAME4), this.get_LI(lIST_NAME3));
			break;
		}
		case FIELDTYPE.transcription_jd:
		{
			string lIST_NAME2 = Class16.smethod_0(1648962617);
			value = ACE.RSGlobal.RSGlobal.iarr(this.get_LI(Class16.smethod_0(1648962650)), this.get_LI(lIST_NAME2));
			break;
		}
		case FIELDTYPE.npc_services:
			value = NPCServicesLists;
			break;
		case FIELDTYPE.drop_tables:
		{
			string lIST_NAME = Class16.smethod_0(1648962685);
			value = ACE.RSGlobal.RSGlobal.iarr(this.get_LI(Class16.smethod_0(1648962709)), this.get_LI(lIST_NAME));
			break;
		}
		}
		if (FieldListsCache == null)
		{
			FieldListsCache = new Dictionary<int, int[]>();
		}
		int num2 = 0;
		int num3 = value.Length;
		if (0 < num3)
		{
			do
			{
				if (value[num2] != -1)
				{
					num2++;
					continue;
				}
				List<int> list = new List<int>(new List<int>());
				int[] array = value;
				int num4 = 0;
				if (0 < (nint)value.LongLength)
				{
					do
					{
						int num5 = array[num4];
						if (num5 != -1)
						{
							list.Add(num5);
						}
						num4++;
					}
					while (num4 < (nint)array.LongLength);
				}
				value = list.ToArray();
				break;
			}
			while (num2 < num3);
		}
		FieldListsCache.Add((int)fieldtype, value);
		GC.KeepAlive(this);
		return value;
	}

	public int[] GetFieldLists(int int_0, int int_1, int int_2)
	{
		int[] array = null;
		FIELDTYPE fieldType = GetFieldType(int_0, int_1, int_2);
		if (fieldType == FIELDTYPE.custom_list)
		{
			Dictionary<int, int[]> fieldsBindedLists = Lists[int_0].FieldsBindedLists;
			array = null;
			if (fieldsBindedLists != null && fieldsBindedLists.TryGetValue(int_2, out array))
			{
				GC.KeepAlive(this);
				return array;
			}
			int endval = ListCount - 1;
			int[] result = ACE.RSGlobal.RSGlobal.IntArray(1, endval, 1);
			GC.KeepAlive(this);
			return result;
		}
		GC.KeepAlive(this);
		return GetFieldLists(fieldType);
	}

	public void FillFieldsType(ACE.Elements.eList.eList list, int[] indices, FIELDTYPE ftype)
	{
		int num = 0;
		if (0 < (nint)indices.LongLength)
		{
			do
			{
				SetFieldType(list, indices[num], ftype);
				num++;
			}
			while (num < (nint)indices.LongLength);
		}
	}

	public FIELDTYPE GetFieldType(int int_0, int int_1, int int_2)
	{
		if (int_0 >= 0 && int_2 >= 0 && Lists != null && int_0 < Lists.Length)
		{
			ACE.Elements.eList.eList eList2 = Lists[int_0];
			if (eList2 != null && eList2.fieldtypes != null && int_2 < eList2.fieldtypes.Length)
			{
				// Task service records store task references as repeated tasks_N_id fields.
				// These IDs are not elements.data list IDs, so automatic list binding cannot
				// identify them; classify by the schema field name instead.
				if (Game == GAMES.PW && eList2.elementFields != null && int_2 < eList2.elementFields.Length && IsTaskReferenceField(eList2.elementFields[int_2]))
				{
					return FIELDTYPE.ft_quest;
				}
				if (eList2.ListType == ItemType.PW_NPC_MAKE_SERVICE
					&& eList2.elementFields != null
					&& int_2 < eList2.elementFields.Length
					&& eList2.elementFields[int_2] == "id_make_skill")
				{
					return FIELDTYPE.skills_pw;
				}
				if (eList2.ListType == ItemType.PW_EQUIPMENT_ADDON && int_2 == 2 && CommonStorage.AParams.AllowToEditAddonsId)
				{
					GC.KeepAlive(this);
					return FIELDTYPE.mid_param_num;
				}
				ACE.Elements.eList.eList eList3 = Lists[int_0];
				FIELDTYPE fIELDTYPE = eList3.fieldtypes[int_2];
				switch (fIELDTYPE)
				{
				case FIELDTYPE.addon_param1:
				case FIELDTYPE.addon_param2:
				case FIELDTYPE.addon_param3:
					switch (Game)
					{
					case GAMES.JD:
					{
						int num3 = -1;
						if (int_1 > -1)
						{
							num3 = GetValueI(int_0, int_1, Class16.smethod_0(1648893461));
						}
						switch (num3)
						{
						default:
							fIELDTYPE = FIELDTYPE.none;
							break;
						case 34:
						case 35:
						case 38:
							fIELDTYPE = ((fIELDTYPE != FIELDTYPE.addon_param1) ? FIELDTYPE.none : FIELDTYPE.ft_skills);
							break;
						case -1:
						case 39:
							fIELDTYPE = FIELDTYPE.ft_skills;
							break;
						}
						break;
					}
					case GAMES.PW:
						{
							if (fIELDTYPE == FIELDTYPE.addon_param1)
							{
								if (int_1 != -1)
								{
									int num = eList3.getid(int_1);
									GC.KeepAlive(this);
									int num2 = num;
									if (!Addons.IsAbility(num2.ToString()))
									{
										goto IL_0179;
									}
								}
								fIELDTYPE = FIELDTYPE.ft_skills;
								break;
							}
							if (fIELDTYPE == FIELDTYPE.addon_param3 && int_1 > -1 && CommonStorage.AParams.AllowToEditAddonsId)
							{
								int valueIFast2 = Lists[int_0].GetValueIFast(int_1, 2);
								GC.KeepAlive(this);
								fIELDTYPE = ((valueIFast2 <= 3) ? FIELDTYPE.none : FIELDTYPE.equip_addon);
								break;
							}
							goto IL_0179;
						}
						IL_0179:
						fIELDTYPE = FIELDTYPE.none;
						break;
					}
					break;
				case FIELDTYPE.sale_promotion_item_essence_condition_arg1:
					if (int_1 > -1 && int_1 < GetItemsCount(int_0) && int_2 > 0)
					{
						int valueIFast = eList3.GetValueIFast(int_1, int_2 - 1);
						GC.KeepAlive(this);
						if (valueIFast == 5)
						{
							fIELDTYPE = FIELDTYPE.matters;
							break;
						}
					}
					fIELDTYPE = FIELDTYPE.none;
					break;
				}
				return fIELDTYPE;
			}
		}
		return FIELDTYPE.not_set;
	}

	private static bool IsTaskReferenceField(string fieldName)
	{
		if (string.IsNullOrEmpty(fieldName))
		{
			return false;
		}

		if (string.Equals(fieldName, "task_in_id", StringComparison.OrdinalIgnoreCase)
			|| string.Equals(fieldName, "task_out_id", StringComparison.OrdinalIgnoreCase))
		{
			return true;
		}

		string prefix;
		if (fieldName.StartsWith("tasks_", StringComparison.OrdinalIgnoreCase))
		{
			prefix = "tasks_";
		}
		else if (fieldName.StartsWith("task_lists_", StringComparison.OrdinalIgnoreCase))
		{
			prefix = "task_lists_";
		}
		else
		{
			return false;
		}

		if (!fieldName.EndsWith("_id", StringComparison.OrdinalIgnoreCase))
		{
			return false;
		}

		int numberLength = fieldName.Length - prefix.Length - 3;
		if (numberLength <= 0)
		{
			return false;
		}

		for (int i = prefix.Length; i < prefix.Length + numberLength; i++)
		{
			if (!char.IsDigit(fieldName[i]))
			{
				return false;
			}
		}

		return fieldName[prefix.Length + numberLength] == '_';
	}

	public FIELDTYPE GetFieldType(ITEMPOS ItemPos, int int_0)
	{
		return GetFieldType(ItemPos.int_0, ItemPos.int_1, int_0);
	}

	public FIELDTYPE GetFieldType(int int_0, int int_1)
	{
		FIELDTYPE result;
		if (int_0 >= 0 && Lists != null && int_0 < Lists.Length)
		{
			ACE.Elements.eList.eList eList2 = Lists[int_0];
			if (eList2 == null)
			{
				return FIELDTYPE.not_set;
			}
			if (int_1 >= 0)
			{
				FIELDTYPE[] fieldtypes = eList2.fieldtypes;
				if (fieldtypes != null && int_1 < fieldtypes.Length)
				{
					result = fieldtypes[int_1];
					goto IL_0041;
				}
			}
			result = FIELDTYPE.not_set;
			goto IL_0041;
		}
		return FIELDTYPE.not_set;
		IL_0041:
		GC.KeepAlive(this);
		return result;
	}

	public void SetItemID(int int_0, int int_1, int id, [MarshalAs(UnmanagedType.U1)] bool bAutoSaveStage)
	{
		if (bAutoSaveStage)
		{
			int[] fieldsindices = new int[1];
			int[] itemsindices = new int[1] { int_1 };
			ActionsHistory.stChangeFields(int_0, itemsindices, fieldsindices, -1, null);
		}
		int old_id = Lists[int_0].getid(int_1);
		GC.KeepAlive(this);
		Notes.IDChanged(int_0, old_id, id);
		Lists[int_0].elementValues[int_1][0] = id;
		Lists[int_0].IDs[int_1] = id;
		if (bAutoSaveStage)
		{
			ActionsHistory.Complete();
		}
		ItemChanged(int_0, int_1);
	}

	public void SetItemID(int int_0, int int_1, string ID)
	{
		SetItemID(int_0, int_1, ACE.RSGlobal.RSGlobal.UIntParseFast(ID), bAutoSaveStage: true);
		GC.KeepAlive(this);
	}

	public void SetItemName(int int_0, int int_1, string name, [MarshalAs(UnmanagedType.U1)] bool AutoSaveStage)
	{
		SetValue(int_0, int_1, Lists[int_0].NameFieldIndex, name, AutoSaveStage);
	}

	public string GetRealItemName(int int_0, int int_1)
	{
		if (Lists != null && int_0 >= 0 && int_0 < Lists.Length && Lists[int_0] != null)
		{
			int nameFieldIndex = Lists[int_0].NameFieldIndex;
			if (nameFieldIndex < 0)
			{
				return null;
			}
			return GetValue(int_0, int_1, nameFieldIndex);
		}
		return null;
	}

	public string GetRealItemName(ITEMPOS ip)
	{
		return GetRealItemName(ip.int_0, ip.int_1);
	}

	public string GetRecipeNameFromResultItem(int int_0, int int_1, [MarshalAs(UnmanagedType.U1)] bool isCaption)
	{
		string text = string.Empty;
		ITEMPOS iTEMPOS = new ITEMPOS(int_0, int_1);
		new List<ITEMPOS>(4);
		HashSet<string> hashSet = new HashSet<string>();
		int num = 0;
		do
		{
			string text2 = Class16.smethod_0(1648962733);
			ITEMPOS iTEMPOS2 = FindItemPos(iTEMPOS, string.Concat(Class16.smethod_0(1648962751) + num, text2));
			if (iTEMPOS2 != null)
			{
				string text3 = GetParsedItemName(iTEMPOS2);
				if (num > 0 && isCaption)
				{
					text3 = text3.Replace(Class16.smethod_0(1648962766), string.Empty);
				}
				if (!hashSet.Contains(text3))
				{
					string text5;
					if (isCaption)
					{
						string text4 = Class16.smethod_0(1649008474);
						text5 = string.Concat(Class16.smethod_0(1648961184) + GetItemID(iTEMPOS2), text4);
					}
					else
					{
						text5 = string.Empty;
					}
					hashSet.Add(text3 + text5);
				}
			}
			num++;
		}
		while (num < 4);
		if (hashSet.Count > 0)
		{
			text = string.Join(Class16.smethod_0(1648942920), hashSet);
		}
		if (string.IsNullOrWhiteSpace(text))
		{
			text = GetRealItemName(int_0, int_1);
		}
		if (!text.Contains(Class16.smethod_0(1648962775)))
		{
			int valueI = GetValueI(iTEMPOS, Class16.smethod_0(1648970122));
			if (valueI > 1)
			{
				text = string.Concat(text, Class16.smethod_0(1648962783) + valueI);
			}
		}
		GC.KeepAlive(this);
		return text;
	}

	public int FindItemIndexByID(int int_0, int id)
	{
		try
		{
			if (id <= 0)
			{
				return -1;
			}
			ACE.Elements.eList.eList[] lists = Lists;
			if (lists != null && int_0 >= 0 && int_0 < lists.Length)
			{
				List<int> list = lists[int_0]?.IDs;
				if (list != null && list.Count != 0)
				{
					int result = list.IndexOf(id);
					GC.KeepAlive(this);
					return result;
				}
				return -1;
			}
			return -1;
		}
		catch
		{
			return -1;
		}
	}

	public int FindItemIndexByID(int int_0, string id)
	{
		if (!(id == Class16.smethod_0(1648924112)) && ACE.RSGlobal.RSGlobal.IsUIntFast(id) && int_0 >= 0 && int_0 < ListCount)
		{
			int result = FindItemIndexByID(int_0, ACE.RSGlobal.RSGlobal.UIntParseFast(id));
			GC.KeepAlive(this);
			return result;
		}
		return -1;
	}

	public ITEMPOS FindMatter(string id)
	{
		int id2 = ACE.RSGlobal.RSGlobal.UIntParseFast(id);
		ITEMPOS result = FindItemPos(MattersLists, id2);
		GC.KeepAlive(this);
		return result;
	}

	public ITEMPOS FindMatter(int id)
	{
		return FindItemPos(MattersLists, id);
	}

	public ITEMPOS FindItemPos(int[] lists, int id)
	{
		if (id > 0 && lists != null)
		{
			ITEMPOS result = null;
			if ((nint)lists.LongLength == 1)
			{
				int num = lists[0];
				int num2 = FindItemIndexByID(num, id);
				if (num2 > -1)
				{
					result = new ITEMPOS(num, num2);
				}
				return result;
			}
			int lastFoundedItemList = LastFoundedItemList;
			if (lastFoundedItemList > -1)
			{
				int num3 = lastFoundedItemList;
				int num4 = FindItemIndexByID(num3, id);
				int num5;
				if (num4 > -1)
				{
					result = new ITEMPOS(num3, num4);
					num5 = 1;
				}
				else
				{
					num5 = 0;
				}
				if ((byte)num5 != 0)
				{
					return result;
				}
			}
			int num6 = lists.Length;
			int num7 = 0;
			if (0 < num6)
			{
				do
				{
					int num8 = lists[num7];
					if (num8 != ConversationListIndex && num8 != LastFoundedItemList && num8 < ListCount)
					{
						int num9 = FindItemIndexByID(num8, id);
						int num10;
						if (num9 > -1)
						{
							result = new ITEMPOS(num8, num9);
							num10 = 1;
						}
						else
						{
							num10 = 0;
						}
						if ((byte)num10 != 0)
						{
							LastFoundedItemList = num8;
							return result;
						}
					}
					num7++;
				}
				while (num7 < num6);
			}
			return null;
		}
		return null;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool FindItemPos(int int_0, int id, ref ITEMPOS ItemPos)
	{
		int num = FindItemIndexByID(int_0, id);
		int num2;
		if (num > -1)
		{
			ItemPos = new ITEMPOS(int_0, num);
			num2 = 1;
		}
		else
		{
			num2 = 0;
		}
		return (byte)num2 != 0;
	}

	public ITEMPOS FindItemPos(string ListName, int id)
	{
		int num = this.get_LI(ListName);
		if (num > -1)
		{
			object obj = null;
			int num2 = FindItemIndexByID(num, id);
			if (num2 > -1)
			{
				obj = new ITEMPOS(num, num2);
			}
			return (ITEMPOS)obj;
		}
		return null;
	}

	public ITEMPOS FindItemPos(int int_0, int id)
	{
		object obj = null;
		int num = FindItemIndexByID(int_0, id);
		if (num > -1)
		{
			obj = new ITEMPOS(int_0, num);
		}
		return (ITEMPOS)obj;
	}

	public ITEMPOS FindItemPos(int[] lists, string id)
	{
		ITEMPOS result = FindItemPos(lists, ACE.RSGlobal.RSGlobal.UIntParseFast(id));
		GC.KeepAlive(this);
		return result;
	}

	public ITEMPOS FindItemPos(int parent_l, int parent_e, int int_0)
	{
		int valueIFast = Lists[parent_l].GetValueIFast(parent_e, int_0);
		GC.KeepAlive(this);
		if (valueIFast > 0)
		{
			return FindItemPos(GetFieldLists(parent_l, parent_e, int_0), valueIFast);
		}
		return null;
	}

	public ITEMPOS FindItemPos(ITEMPOS ParentItem, string FieldUName)
	{
		int num = Lists[ParentItem.int_0].get_fields(FieldUName);
		if (num > -1)
		{
			GC.KeepAlive(this);
			int int_ = ParentItem.int_1;
			int int_2 = ParentItem.int_0;
			int valueIFast = Lists[int_2].GetValueIFast(int_, num);
			GC.KeepAlive(this);
			return FindItemPos(GetFieldLists(ParentItem.int_0, ParentItem.int_1, num), valueIFast);
		}
		return null;
	}

	public ITEMPOS FindItemPos(ITEMPOS ParentItem, int int_0)
	{
		int int_1 = ParentItem.int_1;
		int int_2 = ParentItem.int_0;
		int valueIFast = Lists[int_2].GetValueIFast(int_1, int_0);
		GC.KeepAlive(this);
		return FindItemPos(GetFieldLists(ParentItem.int_0, ParentItem.int_1, int_0), valueIFast);
	}

	public ITEMPOS FindItemPos(FIELDTYPE ftype, int id)
	{
		return FindItemPos(GetFieldLists(ftype), id);
	}

	public ITEMPOS FindItemPos(ItemType item_type, int id)
	{
		return FindItemPos(GetLists(item_type), id);
	}

	public ITEMPOS FindItemFromField(FIELDPOS FieldPos)
	{
		int int_ = FieldPos.int_2;
		int int_2 = FieldPos.int_1;
		int int_3 = FieldPos.int_0;
		int valueIFast = Lists[int_3].GetValueIFast(int_2, int_);
		GC.KeepAlive(this);
		return FindItemPos(GetFieldLists(FieldPos.int_0, FieldPos.int_1, FieldPos.int_2), valueIFast);
	}

	public ITEMPOS FindItemPosByID(int id)
	{
		ITEMPOS result = null;
		int num = 0;
		if (0 < ListCount)
		{
			do
			{
				if (num != ConversationListIndex)
				{
					int num2 = FindItemIndexByID(num, id);
					int num3;
					if (num2 > -1)
					{
						result = new ITEMPOS(num, num2);
						num3 = 1;
					}
					else
					{
						num3 = 0;
					}
					if ((byte)num3 != 0)
					{
						return result;
					}
				}
				num++;
			}
			while (num < ListCount);
		}
		return null;
	}

	public ITEMPOS FindItemPosByID(int parent_l, int int_0, int id)
	{
		return FindItemPos(GetFieldLists(parent_l, 0, int_0), id);
	}

	public int LoadClientSign()
	{
		if (License == null)
		{
			GC.KeepAlive(this);
			return -1;
		}
		if (License.TryGetFeatureEntitlementInt(Class16.smethod_0(1648962784), out var value))
		{
			GC.KeepAlive(this);
			return value;
		}
		GC.KeepAlive(this);
		return -1;
	}

	public void SaveList(string fn, int int_0, [MarshalAs(UnmanagedType.U1)] bool skipStrings)
	{
		string fullPath = System.IO.Path.GetFullPath(fn);
		string temporaryPath = CreateSiblingTemporaryPath(fullPath);
		try
		{
			using (FileStream stream = new FileStream(temporaryPath, FileMode.CreateNew, FileAccess.Write, FileShare.None))
			using (BinaryWriter writer = new BinaryWriter(stream))
			{
				writer.Write(int_0);
				ACE.Elements.eList.eList.WriteList(writer, int_0, Lists, ConversationListIndex, Game, Version, skipStrings, isRealm: false);
				writer.Flush();
				stream.Flush(true);
			}

			using (FileStream validationStream = new FileStream(temporaryPath, FileMode.Open, FileAccess.Read, FileShare.Read))
			using (BinaryReader validationReader = new BinaryReader(validationStream))
			{
				if (validationStream.Length < sizeof(int) || validationReader.ReadInt32() != int_0)
				{
					throw new InvalidDataException("O arquivo temporário da lista de Elements não passou pela validação do cabeçalho.");
				}
			}

			CommitSiblingTemporaryFile(temporaryPath, fullPath);
			GC.KeepAlive(this);
		}
		finally
		{
			if (File.Exists(temporaryPath))
			{
				File.Delete(temporaryPath);
			}
		}
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool Save(string FN, ToolStripProgressBar progress, [MarshalAs(UnmanagedType.U1)] bool bEncryptElements, ELEMENTS_SAVE_TYPE SaveType)
	{
		return Save(FN, FN, progress);
	}

	private bool method_21(string string_1, int int_0, int int_1, int int_2, ToolStripProgressBar toolStripProgressBar_0, [MarshalAs(UnmanagedType.U1)] bool bool_1)
	{
		if (Lists != null && int_0 >= 0 && int_1 >= 0 && int_0 + int_1 <= Lists.Length)
		{
			if (string.IsNullOrWhiteSpace(string_1))
			{
				return false;
			}
			string path = string_1;
			try
			{
				path = System.IO.Path.GetFullPath(string_1);
			}
			catch
			{
			}
			string directoryName = System.IO.Path.GetDirectoryName(path);
			if (!string.IsNullOrWhiteSpace(directoryName) && !Directory.Exists(directoryName))
			{
				method_24(string_1, new DirectoryNotFoundException(Class16.smethod_0(1648962805) + string_1 + Class16.smethod_0(1648928156)));
				return false;
			}
			string temporaryPath = CreateSiblingTemporaryPath(string_1);
			try
			{
				FileStream fileStream = new FileStream(temporaryPath, FileMode.CreateNew, FileAccess.Write);
				try
				{
					BinaryWriter binaryWriter = new BinaryWriter(fileStream);
					try
					{
						binaryWriter.Write(Version);
						binaryWriter.Write(Signature);
						if (Version >= 350)
						{
							binaryWriter.Write(TimeStamp);
							binaryWriter.Write(OrgData.Length);
							binaryWriter.Write(OrgData);
							binaryWriter.Write(tag_name);
							binaryWriter.Write(ComputerName.Length);
							binaryWriter.Write(ComputerName);
							binaryWriter.Write(ComputerTimestamp);
							binaryWriter.Write(tag_info);
							binaryWriter.Write(HardInfo.Length);
							binaryWriter.Write(HardInfo);
							for (int i = 0; i < int_1; i++)
							{
								int num = int_0 + i;
								if (num == int_2)
								{
									for (int j = 0; j < Lists[num].elementValues.Length; j++)
									{
										object[] values = Lists[num].elementValues[j];
										if (values == null || Lists[num].FieldDataTypes == null || values.Length != Lists[num].FieldDataTypes.Length)
										{
											throw new InvalidDataException(string.Format("A lista {0}, item {1}, não corresponde à quantidade de campos definida pela CFG.", num, j));
										}
										int num2 = values.Length;
										for (int k = 0; k < num2; k++)
										{
											ACE.Elements.eList.eList.writeValue(binaryWriter, values[k], Lists[num].FieldDataTypes[k].data_type, k, null);
										}
									}
								}
								else
								{
									List<byte> list = new List<byte>();
									int num3 = Lists[num].elementValues.Length;
									binaryWriter.Write(num3);
									if (num3 <= 0)
									{
										continue;
									}
									for (int l = 0; l < num3; l++)
									{
										object[] values = Lists[num].elementValues[l];
										if (values == null || Lists[num].FieldDataTypes == null || values.Length != Lists[num].FieldDataTypes.Length)
										{
											throw new InvalidDataException(string.Format("A lista {0}, item {1}, não corresponde à quantidade de campos definida pela CFG.", num, l));
										}
										using MemoryStream memoryStream = new MemoryStream();
										BinaryWriter binaryWriter2 = new BinaryWriter(memoryStream);
										try
										{
											int num4 = values.Length;
											for (int m = 0; m < num4; m++)
											{
												ACE.Elements.eList.eList.writeValue(binaryWriter2, values[m], Lists[num].FieldDataTypes[m].data_type, m, null);
											}
											byte[] buffer = memoryStream.ToArray();
											byte[] array = Lists[num].mppc_managed.compress(buffer);
											list.AddRange(array);
											binaryWriter.Write(Convert.ToInt32(Lists[num].GetValue(l, 0)));
											binaryWriter.Write(Convert.ToInt16(array.Length));
										}
										finally
										{
											((IDisposable)binaryWriter2).Dispose();
										}
									}
									int value = list.Count;
									binaryWriter.Write(value);
									binaryWriter.Write(list.ToArray());
								}
								if (toolStripProgressBar_0 != null && !toolStripProgressBar_0.IsDisposed)
								{
									int value2;
									if (i <= 0)
									{
										value2 = 0;
									}
									else if (int_1 <= 0)
									{
										value2 = 100;
									}
									else
									{
										int num5 = 1 - (int)((double)i / (double)int_1 * -99.0);
										num5 = ((num5 > 100) ? 100 : num5);
										value2 = num5;
									}
									toolStripProgressBar_0.Value = value2;
								}
							}
						}
						else
						{
							if (Version > 7)
							{
								binaryWriter.Write(TimeStamp);
							}
							int talk_proc_ListIndex = Get_talk_proc_ListIndex();
							int int_3 = ((Game != GAMES.PW) ? 4 : 0);
							for (int n = 0; n < int_1; n++)
							{
								int num6 = int_0 + n;
								ACE.Elements.eList.eList eList2 = Lists[num6];
								byte[] listOffsetData = eList2.listOffsetData;
								if (listOffsetData != null && listOffsetData.Length != 0)
								{
									if (num6 == talk_proc_ListIndex)
									{
										binaryWriter.Write(smethod_9(listOffsetData, int_3));
									}
									else
									{
										binaryWriter.Write(listOffsetData);
									}
								}
								if (eList2.elementValues == null)
								{
									throw new InvalidDataException(string.Format("A lista {0} não possui valores carregados para salvar.", num6));
								}
								if (num6 != int_2)
								{
									int value3 = eList2.elementValues.Length;
									if (Game == GAMES.PW && Version >= 191)
									{
										binaryWriter.Write(eList2._list_type);
										binaryWriter.Write(value3);
										int num7 = eList2.item_size;
										if (num7 <= 0)
										{
											num7 = ACE.Elements.eList.eList.GetListItemSize(eList2, skipStrings: false);
										}
										binaryWriter.Write(num7);
									}
									else
									{
										binaryWriter.Write(value3);
									}
								}
								int val = ((eList2.elementTypes != null) ? eList2.elementTypes.Length : 0);
								int num8 = ((eList2.FieldDataTypes != null) ? eList2.FieldDataTypes.Length : 0);
								for (int num9 = 0; num9 < eList2.elementValues.Length; num9++)
								{
									object[] array2 = eList2.elementValues[num9];
									if (array2 == null)
									{
										throw new InvalidDataException(string.Format("A lista {0}, item {1}, não contém valores carregados.", num6, num9));
									}
									if (array2.Length != val)
									{
										throw new InvalidDataException(string.Format("A lista {0}, item {1}, possui {2} valores, mas a CFG define {3} campos.", num6, num9, array2.Length, val));
									}
									int num10 = array2.Length;
									for (int num11 = 0; num11 < num10; num11++)
									{
										if (eList2.FieldDataTypes != null && num11 < num8)
										{
											ACE.Elements.eList.eList.writeValue(binaryWriter, array2[num11], eList2.FieldDataTypes[num11].data_type, num11, null);
										}
										else
										{
											smethod_10(binaryWriter, array2[num11], eList2.elementTypes[num11]);
										}
									}
								}
								if (toolStripProgressBar_0 != null && !toolStripProgressBar_0.IsDisposed)
								{
									int value4;
									if (n <= 0)
									{
										value4 = 0;
									}
									else if (int_1 <= 0)
									{
										value4 = 100;
									}
									else
									{
										int num12 = 1 - (int)((double)n / (double)int_1 * -99.0);
										num12 = ((num12 > 100) ? 100 : num12);
										value4 = num12;
									}
									toolStripProgressBar_0.Value = value4;
								}
							}
							if (bool_1 && BytesAfterEndOfFile != null && BytesAfterEndOfFile.Length != 0)
							{
								binaryWriter.Write(BytesAfterEndOfFile);
							}
						}
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
				CommitSiblingTemporaryFile(temporaryPath, string_1);
				return true;
			}
			catch (Exception ex)
			{
				TryDeleteTemporaryFile(temporaryPath);
				SentryHelper.CaptureException(ex, Class16.smethod_0(1648962847));
				method_24(string_1, ex);
				return false;
			}
		}
		return false;
	}

	public bool Save(string elFile, string FN, ToolStripProgressBar progress)
	{
		int int_ = method_38();
		if (!method_21(elFile, 0, int_, ConversationListIndex, progress, bool_1: true))
		{
			return false;
		}
		if (string.Equals(elFile, FN, StringComparison.OrdinalIgnoreCase))
		{
			return true;
		}
		return method_23(elFile, FN);
	}

	private static string CreateSiblingTemporaryPath(string destination)
	{
		string fullPath = System.IO.Path.GetFullPath(destination);
		string directory = System.IO.Path.GetDirectoryName(fullPath);
		return System.IO.Path.Combine(directory, ".ace-" + Guid.NewGuid().ToString("N") + ".tmp");
	}

	private static void CommitSiblingTemporaryFile(string temporaryPath, string destination)
	{
		if (File.Exists(destination))
		{
			File.Replace(temporaryPath, destination, null);
			return;
		}
		File.Move(temporaryPath, destination);
	}

	private static void TryDeleteTemporaryFile(string path)
	{
		try
		{
			if (!string.IsNullOrEmpty(path) && File.Exists(path)) File.Delete(path);
		}
		catch
		{
		}
	}

	private bool method_23(string string_1, string string_2)
	{
		for (int i = 1; i <= 5; i++)
		{
			try
			{
				string temporaryPath = CreateSiblingTemporaryPath(string_2);
				try
				{
					File.Copy(string_1, temporaryPath, overwrite: false);
					CommitSiblingTemporaryFile(temporaryPath, string_2);
				}
				finally
				{
					TryDeleteTemporaryFile(temporaryPath);
				}
				return true;
			}
			catch (IOException ex) when (ex.HResult == -2147024864)
			{
				if (i == 5)
				{
					method_24(string_2, ex);
					return false;
				}
				Thread.Sleep(200);
			}
			catch (Exception ex2)
			{
				SentryHelper.CaptureException(ex2, Class16.smethod_0(1648962925));
				method_24(string_2, ex2);
				return false;
			}
		}
		return false;
	}

	private void method_24(string string_1, Exception exception_0)
	{
		object[] vars = new object[2] { exception_0.Message, string_1 };
		TextStorage.TEXTS.ShowMessage(614, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, vars);
	}

	private static byte[] smethod_9(byte[] byte_0, int int_0)
	{
		if (byte_0 != null && byte_0.Length >= 8)
		{
			try
			{
				int num = BitConverter.ToInt32(byte_0, 4);
				if (num < 0)
				{
					return byte_0;
				}
				long num2 = 8L + num + int_0;
				if (num2 > 0L && num2 <= 2147483647L)
				{
					int num3 = (int)num2;
					if (num3 > byte_0.Length)
					{
						return byte_0;
					}
					if (num3 == byte_0.Length)
					{
						return byte_0;
					}
					byte[] array = new byte[num3];
					Buffer.BlockCopy(byte_0, 0, array, 0, num3);
					return array;
				}
				return byte_0;
			}
			catch
			{
				return byte_0;
			}
		}
		return byte_0;
	}

	private static void smethod_10(BinaryWriter binaryWriter_0, object object_0, string string_1)
	{
		if (string_1 == Class16.smethod_0(1648989776))
		{
			binaryWriter_0.Write((int)object_0);
			return;
		}
		if (string_1 == Class16.smethod_0(1648902744))
		{
			binaryWriter_0.Write((float)object_0);
			return;
		}
		if (string_1 == Class16.smethod_0(1648989786))
		{
			binaryWriter_0.Write((uint)object_0);
			return;
		}
		if (string_1 == Class16.smethod_0(1648989830))
		{
			binaryWriter_0.Write((long)object_0);
			return;
		}
		if (string_1 == Class16.smethod_0(1648989834))
		{
			binaryWriter_0.Write((ulong)object_0);
			return;
		}
		if (string_1 == Class16.smethod_0(1648989855))
		{
			binaryWriter_0.Write((double)object_0);
			return;
		}
		if (!string_1.StartsWith(Class16.smethod_0(1648985282)) && !string_1.StartsWith(Class16.smethod_0(1648985317)) && !string_1.StartsWith(Class16.smethod_0(1648985302)))
		{
			throw new InvalidOperationException(Class16.smethod_0(1648962953) + string_1);
		}
		binaryWriter_0.Write((byte[])object_0);
	}

	public void Export(string RulesFile, string TargetFile)
	{
		Hashtable rules = new Hashtable();
		ACE.RSGlobal.RSGlobal.loadRules(RulesFile, ref rules, isinclude: false);
		if (File.Exists(TargetFile))
		{
			File.Delete(TargetFile);
		}
		FileStream fileStream = new FileStream(TargetFile, FileMode.Create, FileAccess.Write);
		BinaryWriter binaryWriter = new BinaryWriter(fileStream);
		short num = Convert.ToInt16((string)rules[Class16.smethod_0(1648962988)]);
		binaryWriter.Write(num);
		if (rules.ContainsKey(Class16.smethod_0(1648963005)))
		{
			binaryWriter.Write(Convert.ToInt16((string)rules[Class16.smethod_0(1648963005)]));
		}
		else
		{
			binaryWriter.Write(Signature);
		}
		int num2 = Lists.Length;
		if (rules.ContainsKey(Class16.smethod_0(1648963016)))
		{
			num2 -= Convert.ToInt32((string)rules[Class16.smethod_0(1648963016)]);
		}
		int num3 = 0;
		if (0 < (nint)Lists.LongLength)
		{
			do
			{
				if (!rules.ContainsKey(Class16.smethod_0(1648967102) + num3))
				{
					if (num3 >= num2)
					{
						break;
					}
					if (num3 == 0 && Game == GAMES.PW && num > 7)
					{
						binaryWriter.Write(TimeStamp);
					}
					else if (rules.ContainsKey(Class16.smethod_0(1648967112) + num3))
					{
						char[] separator = new char[2] { '-', ' ' };
						string[] array = ((string)rules[Class16.smethod_0(1648967112) + num3]).Split(separator);
						int num4 = array.Length;
						if (num4 > 1)
						{
							byte[] array2 = new byte[num4];
							int num5 = 0;
							if (0 < num4)
							{
								do
								{
									array2[num5] = Convert.ToByte(array[num5], 16);
									num5++;
								}
								while (num5 < (nint)array.LongLength);
							}
							if ((nint)array2.LongLength > 0)
							{
								binaryWriter.Write(array2);
							}
						}
					}
					else if (Lists[num3].listOffsetData != null)
					{
						if (num3 == Get_NPC_TALK_ListIndex())
						{
							Write_NPC_TALK_Offsets(Lists[num3].NPC_TALK, binaryWriter, bEncryptElements: false);
						}
						else if (num3 == Get_talk_proc_ListIndex())
						{
							byte[] listOffsetData = Lists[num3].listOffsetData;
							binaryWriter.Write(SecretDecrypter.DecryptBytes(listOffsetData, bBase64: false));
						}
						else
						{
							binaryWriter.Write(Lists[num3].listOffsetData);
						}
					}
					if (num3 == ConversationListIndex)
					{
						ACE.Elements.eList.eList.writeValue(binaryWriter, Lists[num3].elementValues[0][0], FIELD_DATA_TYPE_ENUM.Bool, 0, null);
					}
					else
					{
						binaryWriter.Write(Lists[num3].elementValues.Length);
						int num6 = 0;
						if (0 < (nint)Lists[num3].elementValues.LongLength)
						{
							do
							{
								int num7 = 0;
								if (0 < GetFieldsCount(num3))
								{
									do
									{
										if (GetFieldType(num3, num6, num7) == FIELDTYPE.equip_addon && LastAddons != null && LastAddons.ContainsKey(num))
										{
											int valueIFast = Lists[num3].GetValueIFast(num6, num7);
											GC.KeepAlive(this);
											if (valueIFast > LastAddons[num] && num3 == 35)
											{
												switch (num7)
												{
												case 12:
													ACE.Elements.eList.eList.writeValue(binaryWriter, 673, FIELD_DATA_TYPE_ENUM.Int, 12, null);
													goto IL_04a9;
												case 11:
													ACE.Elements.eList.eList.writeValue(binaryWriter, 672, FIELD_DATA_TYPE_ENUM.Int, 11, null);
													goto IL_04a9;
												}
											}
										}
										if (Game == GAMES.PW && Version == 29 && (num == 27 || num == 28) && num3 == 123 && num7 == 2)
										{
											ACE.Elements.eList.eList.writeValue(binaryWriter, 0, FIELD_DATA_TYPE_ENUM.Int, 2, null);
										}
										else
										{
											string text = Class16.smethod_0(1648924402);
											if (rules.ContainsKey(string.Concat(string.Concat(Class16.smethod_0(1648963047) + num3, text), num7)))
											{
												binaryWriter.Write(0);
											}
											string text2 = Class16.smethod_0(1648924402);
											if (!rules.ContainsKey(string.Concat(string.Concat(Class16.smethod_0(1648967141) + num3, text2), num7)))
											{
												ACE.Elements.eList.eList eList2 = Lists[num3];
												ACE.Elements.eList.eList.writeValue(binaryWriter, eList2.elementValues[num6][num7], eList2.FieldDataTypes[num7].data_type, num7, null);
											}
											string text3 = Class16.smethod_0(1648924402);
											if (rules.ContainsKey(string.Concat(string.Concat(Class16.smethod_0(1648963063) + num3, text3), num7 + 1)))
											{
												string text4 = Class16.smethod_0(1648924402);
												int num8 = Convert.ToInt32(rules[string.Concat(string.Concat(Class16.smethod_0(1648963063) + num3, text4), num7 + 1)]);
												if (0 < num8)
												{
													int num9 = num8;
													do
													{
														binaryWriter.Write(0);
														num9--;
													}
													while (num9 != 0);
												}
											}
										}
										goto IL_04a9;
										IL_04a9:
										num7++;
									}
									while (num7 < GetFieldsCount(num3));
								}
								if (rules.ContainsKey(Class16.smethod_0(1648963063) + num3))
								{
									int num10 = Convert.ToInt32(rules[Class16.smethod_0(1648963063) + num3]);
									if (0 < num10)
									{
										int num11 = num10;
										do
										{
											binaryWriter.Write(0);
											num11--;
										}
										while (num11 != 0);
									}
								}
								num6++;
							}
							while (num6 < (nint)Lists[num3].elementValues.LongLength);
						}
					}
				}
				num3++;
			}
			while (num3 < (nint)Lists.LongLength);
		}
		if (rules.ContainsKey(Class16.smethod_0(1648962061)))
		{
			int num12 = Convert.ToInt32((string)rules[Class16.smethod_0(1648962061)]);
			if (0 < num12)
			{
				int num13 = num12;
				do
				{
					binaryWriter.Write(0);
					num13--;
				}
				while (num13 != 0);
			}
		}
		binaryWriter.Close();
		fileStream.Close();
		GC.KeepAlive(this);
	}

	public string GetItemID(ITEMPOS ItemPos)
	{
		int int_ = ItemPos.int_1;
		int int_2 = ItemPos.int_0;
		int num = Lists[int_2].getid(int_);
		GC.KeepAlive(this);
		int num2 = num;
		string result = num2.ToString();
		GC.KeepAlive(this);
		return result;
	}

	public string GetItemID(int int_0, int int_1)
	{
		int num = Lists[int_0].getid(int_1);
		GC.KeepAlive(this);
		int num2 = num;
		string result = num2.ToString();
		GC.KeepAlive(this);
		return result;
	}

	public int getid(ITEMPOS ItemPos)
	{
		int int_ = ItemPos.int_1;
		int int_2 = ItemPos.int_0;
		int result = Lists[int_2].getid(int_);
		GC.KeepAlive(this);
		return result;
	}

	public int getid(int int_0, int int_1)
	{
		int result = Lists[int_0].getid(int_1);
		GC.KeepAlive(this);
		return result;
	}

	public int GetItemsCount()
	{
		return ItemCount;
	}

	public int GetItemsCount(int int_0)
	{
		if (int_0 >= 0 && Lists != null && int_0 < ListCount && int_0 < Lists.Length)
		{
			ACE.Elements.eList.eList eList2 = Lists[int_0];
			if (eList2 == null)
			{
				return 0;
			}
			object[][] elementValues = eList2.elementValues;
			if (elementValues != null)
			{
				return elementValues.Length;
			}
		}
		return 0;
	}

	public ListViewItem GetItem(int int_0, int int_1, [MarshalAs(UnmanagedType.U1)] bool NameIsFirst)
	{
		return CreateListViewItem(GetItemInfo(new ITEMPOS(int_0, int_1), bUseCache: true, bCheckIsFreeID: true, bCheckHasReferences: true), NameIsFirst);
	}

	public ListViewItem GetItem(int int_0, int int_1)
	{
		return CreateListViewItem(GetItemInfo(new ITEMPOS(int_0, int_1), bUseCache: true, bCheckIsFreeID: true, bCheckHasReferences: true), NameIsFirst: false);
	}

	public ListViewItem GetItem(ITEMPOS ItemPos)
	{
		return CreateListViewItem(GetItemInfo(ItemPos, bUseCache: true, bCheckIsFreeID: true, bCheckHasReferences: true), NameIsFirst: true);
	}

	public string GetParsedItemName(int int_0, int int_1, [MarshalAs(UnmanagedType.U1)] bool bRealAddonName)
	{
		if (int_0 < 0)
		{
			string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1648924372));
			GC.KeepAlive(this);
			return text;
		}
		string text2 = null;
		int int_4;
		FIELDTYPE fIELDTYPE;
		if (int_0 == addons_l && bRealAddonName)
		{
			AddonsCollection addons = Addons;
			if (addons != null && addons.bLoaded)
			{
				switch (Game)
				{
				case GAMES.JD:
				{
					if (Skills == null)
					{
						break;
					}
					int int_2 = Lists[int_0].get_fields(Class16.smethod_0(1648962073));
					if (GetFieldType(int_0, int_1, int_2) == FIELDTYPE.ft_skills)
					{
						int valueI = GetValueI(int_0, int_1, Class16.smethod_0(1648962073));
						text2 = Skills.GetSkillName(valueI, bNormalText: false);
						int int_3 = Lists[int_0].get_fields(Class16.smethod_0(1648962094));
						if (GetFieldType(int_0, int_1, int_3) == FIELDTYPE.ft_skills)
						{
							int valueI2 = GetValueI(int_0, int_1, Class16.smethod_0(1648962094));
							string skillName = Skills.GetSkillName(valueI2, bNormalText: false);
							text2 = string.Concat(text2, Class16.smethod_0(1648985576) + skillName);
						}
						else
						{
							text2 = string.Concat(text2, Class16.smethod_0(1648922866) + GetValue(int_0, int_1, Class16.smethod_0(1648962094)));
						}
					}
					else
					{
						int id2 = Lists[int_0].getid(int_1);
						GC.KeepAlive(this);
						text2 = RSCommon.GetParsedItemName(Addons.GetAddonNameByID(id2));
					}
					break;
				}
				case GAMES.PW:
				{
					int id = Lists[int_0].getid(int_1);
					GC.KeepAlive(this);
					text2 = RSCommon.GetParsedItemName(Addons.GetAddonNameByID(id));
					break;
				}
				}
			}
			else
			{
				GAMES game = Game;
				if (game == GAMES.FW || game == GAMES.SW || game == GAMES.ROG || game == GAMES.TOS)
				{
					int_4 = Lists[int_0].get_fields(Class16.smethod_0(1648893461));
					FIELDTYPE fieldType = GetFieldType(int_0, int_1, int_4);
					if (fieldType != FIELDTYPE.ft_ENUM_EXTRA && fieldType != FIELDTYPE.ft_MASK_EXTRA)
					{
						if (fieldType == FIELDTYPE.character_combo_id_jd)
						{
							fIELDTYPE = (FIELDTYPE)4005;
							goto IL_022f;
						}
						fIELDTYPE = fieldType;
					}
					else
					{
						fIELDTYPE = (FIELDTYPE)GetExtraType(int_0, int_1, int_4);
					}
					if (fIELDTYPE > FIELDTYPE.not_set)
					{
						goto IL_022f;
					}
				}
			}
		}
		goto IL_03c6;
		IL_022f:
		int num = addons_l;
		int valueIFast = Lists[num].GetValueIFast(int_1, int_4);
		GC.KeepAlive(this);
		int valueI3 = GetValueI(addons_l, int_1, Class16.smethod_0(1648962099));
		decimal num2 = GetValueDecimal(addons_l, int_1, Class16.smethod_0(1648962073));
		decimal num3 = GetValueDecimal(addons_l, int_1, Class16.smethod_0(1648962094));
		decimal valueDecimal = GetValueDecimal(addons_l, int_1, Class16.smethod_0(1648962124));
		decimal value = valueIFast;
		text2 = DecodedValues.DecodeValue((int)fIELDTYPE, value);
		bool flag = text2.Contains(Class16.smethod_0(1648962129));
		if (valueI3 >= 2)
		{
			decimal num4 = 500m;
			if (num3 > num4)
			{
				goto IL_02fb;
			}
		}
		if (flag)
		{
			goto IL_02fb;
		}
		goto IL_0365;
		IL_03c6:
		if (string.IsNullOrWhiteSpace(text2))
		{
			text2 = GetRealItemName(int_0, int_1);
			if (RSCommon.IsTagColorExist(text2))
			{
				text2 = text2.Substring(7, text2.Length - 7);
			}
		}
		if (ACE.RSGlobal.RSGlobal.debug_show_listindex)
		{
			text2 = string.Concat(int_0 + Class16.smethod_0(1648908709), text2);
		}
		GC.KeepAlive(this);
		return text2;
		IL_0365:
		int _valCount = 0;
		text2 = Helpers.ConvertCStringToCompositeFormatting(text2, out _valCount);
		switch (_valCount)
		{
		case 1:
			text2 = string.Format(text2, num2);
			break;
		case 2:
			text2 = string.Format(text2, num2, num3);
			break;
		case 3:
			text2 = string.Format(text2, num2, num3, valueDecimal);
			break;
		}
		goto IL_03c6;
		IL_02fb:
		_ = (int)num2;
		num2 = num3;
		num3 = valueDecimal;
		string text3 = Class16.smethod_0(1648962138);
		if (text2.Contains(Class16.smethod_0(1648962129)))
		{
			text2 = text2.Replace(Class16.smethod_0(1648962129), text3);
		}
		else
		{
			string text4 = Class16.smethod_0(1648942897);
			text2 = string.Concat(text2, string.Concat(Class16.smethod_0(1648899468) + text3, text4));
		}
		goto IL_0365;
	}

	public string GetParsedItemName(int int_0, int int_1)
	{
		return GetParsedItemName(int_0, int_1, bRealAddonName: true);
	}

	public string GetParsedItemName(ITEMPOS pos)
	{
		if (pos == null)
		{
			string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1648924372));
			GC.KeepAlive(this);
			return text;
		}
		GC.KeepAlive(this);
		int int_ = pos.int_1;
		int int_2 = pos.int_0;
		return GetParsedItemName(int_2, int_, bRealAddonName: true);
	}

	public string GenerateItemTagColor(int int_0, int int_1, Color newcolor)
	{
		string text = GetRealItemName(int_0, int_1);
		if (RSCommon.IsTagColorExist(text))
		{
			text = text.Substring(7);
		}
		text = RSCommon.Color2ColorTag(newcolor) + text;
		GC.KeepAlive(this);
		return text;
	}

	public Color GetTagColor(int int_0, int int_1)
	{
		Color tagColor = RSCommon.GetTagColor(GetRealItemName(int_0, int_1));
		GC.KeepAlive(this);
		return tagColor;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsNumericType(int int_0, int int_1)
	{
		FIELD_DATA_TYPE_ENUM data_type = Lists[int_0].FieldDataTypes[int_1].data_type;
		if ((uint)(data_type - 1) > 6u)
		{
			return false;
		}
		return true;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsFloatedField(int int_0, int int_1)
	{
		FIELD_DATA_TYPE_ENUM data_type = Lists[int_0].FieldDataTypes[int_1].data_type;
		int num = ((data_type == FIELD_DATA_TYPE_ENUM.Float || data_type == FIELD_DATA_TYPE_ENUM.Double) ? 1 : 0);
		return (byte)num != 0;
	}

	public void LoadDataBase([MarshalAs(UnmanagedType.U1)] bool isPCK, [MarshalAs(UnmanagedType.U1)] bool onlyAddons)
	{
		string text = null;
		if (ACE.RSGlobal.RSGlobal.AntiRecurse_LoadDataBase_eListCollection)
		{
			return;
		}
		ACE.RSGlobal.RSGlobal.AntiRecurse_LoadDataBase_eListCollection = true;
		try
		{
			if (!onlyAddons)
			{
				text = null;
				if (Params.UsePck && PCKs != null && !CommonStorage.AParams.DontLoadLuaFromPck)
				{
					GAMES game = Game;
					bool fromPck;
					int num;
					switch (game)
					{
					case GAMES.FW:
					case GAMES.SW:
						fromPck = false;
						if (game == GAMES.FW)
						{
							if (PCKs.LoadIfNotLoaded(Class16.smethod_0(1648962188)))
							{
								GAMES game2 = PCKs[Class16.smethod_0(1648962188)].Game;
								if (game2 == Game)
								{
									num = 1;
									goto IL_00a6;
								}
							}
							num = 0;
							goto IL_00a6;
						}
						goto IL_00af;
					case GAMES.PW:
						{
							if (PCKs.LoadIfNotLoaded(Class16.smethod_0(1648991932)) && PCKs[Class16.smethod_0(1648991932)].Game == Game)
							{
								byte[] fileB = PCKs.GetFileB(Class16.smethod_0(1648962153));
								if (fileB != null)
								{
									text = Encoding.Unicode.GetString(fileB);
								}
							}
							break;
						}
						IL_00af:
						try
						{
							LoadGameLuaScriptsDb(fromPck);
						}
						catch (Exception ex)
						{
							SentryHelper.CaptureException(ex, Class16.smethod_0(1648962193));
							string text2 = Class16.smethod_0(1648962236) + ex.Message;
							DKBox.Show(text2, Class16.smethod_0(1648934892), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							LoadGameLuaScriptsDb(fromPck: false);
						}
						break;
						IL_00a6:
						fromPck = (byte)num != 0;
						goto IL_00af;
					}
				}
				else
				{
					GAMES game3 = Game;
					if (game3 == GAMES.FW || game3 == GAMES.SW)
					{
						LoadGameLuaScriptsDb(fromPck: false);
					}
				}
				if (text == null)
				{
					string text3 = null;
					string text4 = ((LANG_INFO.CurrentLang == null) ? Class16.smethod_0(1648931959) : LANG_INFO.CurrentLang.Prefix);
					string text5 = System.IO.Path.Combine(Application.StartupPath, Class16.smethod_0(1648909207), GamePrefix + Class16.smethod_0(1648962276));
					string text6 = System.IO.Path.Combine(Application.StartupPath, Class16.smethod_0(1648909207), Class16.smethod_0(1648962288));
					switch (Game)
					{
					default:
					{
						if (DatabaseLocaleResolver.TryFindFirstExistingByToken(method_48, out var existingPath2, out var _, text4))
						{
							text3 = existingPath2;
						}
						break;
					}
					case GAMES.FW:
					{
						string text7 = System.IO.Path.Combine(Application.StartupPath, Class16.smethod_0(1648909207), Class16.smethod_0(1648962307));
						string existingPath;
						string usedToken;
						if (File.Exists(text7))
						{
							text3 = text7;
						}
						else if (DatabaseLocaleResolver.TryFindFirstExistingByToken(method_47, out existingPath, out usedToken, text4))
						{
							text3 = existingPath;
						}
						break;
					}
					case GAMES.Chibi:
						break;
					}
					if (text3 == null && File.Exists(text5))
					{
						text3 = text5;
					}
					if (text3 == null && File.Exists(text6))
					{
						text3 = text6;
					}
					if (File.Exists(text3))
					{
						text = File.ReadAllText(text3);
					}
					else if (Game != GAMES.Chibi)
					{
						string text8 = string.Join(Class16.smethod_0(1648928028), DatabaseLocaleResolver.GetLookupTokens(text4));
						string message = Class16.smethod_0(1648962340) + GamePrefix + Class16.smethod_0(1648962386) + text4 + Class16.smethod_0(1648962414) + text8 + Class16.smethod_0(1648962424);
						string item = Class16.smethod_0(1648962433) + GamePrefix + Class16.smethod_0(1648923968) + text4;
						if (hashSet_0.Add(item))
						{
							SentryHelper.CaptureMessage(message, (SentryLevel)1, Class16.smethod_0(1648908340));
						}
					}
					if (text == null)
					{
						goto IL_036e;
					}
				}
				Skills = new SkillsCollection(Lists, GamePrefix, ref text);
			}
			goto IL_036e;
			IL_036e:
			if (!isPCK)
			{
				GAMES game4 = Game;
				if ((game4 == GAMES.PW || game4 == GAMES.JD) && Lists != null && Lists.Length != 0 && Lists[0] != null)
				{
					Addons = new AddonsCollection(Lists, Params.UseAddonsFilter, DBReader, LastAddons, DecodedValues, Skills);
				}
			}
		}
		finally
		{
			ACE.RSGlobal.RSGlobal.AntiRecurse_LoadDataBase_eListCollection = false;
		}
	}

	public ITEMINFO GetItemInfoByID(int int_0, int id)
	{
		ITEMPOS itemPos = null;
		int num = FindItemIndexByID(int_0, id);
		if (num > -1)
		{
			itemPos = new ITEMPOS(int_0, num);
		}
		return GetItemInfo(itemPos, bUseCache: true, bCheckIsFreeID: true, bCheckHasReferences: true);
	}

	public ITEMINFO GetItemInfo(ITEMPOS ItemPos, [MarshalAs(UnmanagedType.U1)] bool bUseCache, [MarshalAs(UnmanagedType.U1)] bool bCheckIsFreeID, [MarshalAs(UnmanagedType.U1)] bool bCheckHasReferences)
	{
		List<string> list = null;
		if (ItemPos != null)
		{
			ACE.Elements.eList.eList[] lists = Lists;
			if (lists == null || ItemPos.int_0 < 0 || ItemPos.int_0 >= lists.Length || lists[ItemPos.int_0] == null)
			{
				return null;
			}
			if (ItemPos.int_1 < 0 || ItemPos.int_1 >= GetItemsCount(ItemPos.int_0))
			{
				return null;
			}
			Dictionary<int, ITEMINFO>[] itemsCache = ItemsCache;
			if (itemsCache != null)
			{
				int int_ = ItemPos.int_0;
				if (itemsCache[int_] == null)
				{
					ItemsCache[int_] = new Dictionary<int, ITEMINFO>(GetItemsCount(int_));
				}
				if (bUseCache && ItemsCache[int_].ContainsKey(ItemPos.int_1))
				{
					ITEMINFO result = ItemsCache[int_][ItemPos.int_1];
					GC.KeepAlive(this);
					return result;
				}
				try
				{
					ITEMINFO iTEMINFO = new ITEMINFO();
					iTEMINFO.pos = new ITEMPOS(ItemPos.int_0, ItemPos.int_1);
					int int_2 = ItemPos.int_1;
					ACE.Elements.eList.eList eList2 = lists[int_];
					if (eList2 == null)
					{
						return null;
					}
					int num = eList2.getid(int_2);
					GC.KeepAlive(this);
					iTEMINFO.id = num;
					int num2 = num;
					iTEMINFO.ID = num2.ToString();
					if (bCheckIsFreeID)
					{
						int id = iTEMINFO.id;
						int int_3 = ItemPos.int_1;
						int num3 = ((!IsFreeID(int_, int_3, id, null, bInAllLists: false)) ? 1 : 0);
						iTEMINFO.bOcupiedID = (byte)num3 != 0;
					}
					ItemType item_type = (iTEMINFO.item_type = GetItemType(int_, bNpcMobAndMineIsSame: false));
					if (bCheckHasReferences)
					{
						int num4 = (((iTEMINFO.RefCount = References.GetCount(int_, item_type, iTEMINFO.id)) > 0) ? 1 : 0);
						iTEMINFO.bHasReferences = (byte)num4 != 0;
					}
					list = null;
					iTEMINFO.bHasErrors = CheckItemErrors(ItemPos, bFast: true, ref list);
					if (iTEMINFO.name == null)
					{
						try
						{
							iTEMINFO.name = GetParsedItemName(ItemPos);
						}
						catch
						{
							iTEMINFO.name = iTEMINFO.ID;
						}
						try
						{
							Color itemColor = GetItemColor(ItemPos.int_0, ItemPos.int_1);
							iTEMINFO.color = itemColor;
						}
						catch
						{
							iTEMINFO.color = Color.Empty;
						}
					}
					if (eList2.ListType != ItemType.PW_RECIPE_ESSENCE)
					{
						if (IsMobsList(int_))
						{
							string name = iTEMINFO.name;
							iTEMINFO.name = GetPowerLvlPrefix(ItemPos) + name;
						}
						if (IsListContainSubItems(int_))
						{
							iTEMINFO.SubItemsCount = GetItemSubItemsCount(iTEMINFO.pos);
						}
					}
					else if (Params.UseAlternativeRecipesNames)
					{
						int result_f = 0;
						ITEMPOS iTEMPOS = GenerateRecipeResult(ItemPos, ref result_f, bRandomItem: false);
						if (iTEMPOS != null)
						{
							try
							{
								iTEMINFO.name = GetParsedItemName(iTEMPOS);
							}
							catch
							{
								iTEMINFO.name = iTEMINFO.ID;
							}
							int valueI = GetValueI(ItemPos, Class16.smethod_0(1648970122));
							if (valueI > 1)
							{
								string name2 = iTEMINFO.name;
								iTEMINFO.name = string.Concat(name2, Class16.smethod_0(1648962783) + valueI);
							}
							try
							{
								Color itemColor2 = GetItemColor(iTEMPOS.int_0, iTEMPOS.int_1);
								iTEMINFO.color = itemColor2;
							}
							catch
							{
								iTEMINFO.color = Color.Empty;
							}
						}
					}
					iTEMINFO.IconName = GetIconName(ItemPos, ref iTEMINFO.IsTgaIcon);
					int id2 = iTEMINFO.id;
					LISTandID item = new LISTandID
					{
						Int32_0 = int_
					};
					id2 = ((id2 > 1000000) ? 100000 : id2);
					item.id = id2;
					Color itemCategoryColor = GetItemCategoryColor(item);
					iTEMINFO.CatColor = itemCategoryColor;
					if (!ItemsCache[int_].ContainsKey(ItemPos.int_1))
					{
						ItemsCache[int_].Add(ItemPos.int_1, iTEMINFO);
					}
					else
					{
						ItemsCache[int_][ItemPos.int_1] = iTEMINFO;
					}
					GC.KeepAlive(this);
					return iTEMINFO;
				}
				catch (NullReferenceException)
				{
					return null;
				}
				catch (IndexOutOfRangeException)
				{
					return null;
				}
			}
		}
		return null;
	}

	public ITEMINFO GetItemInfo(ITEMPOS ItemPos)
	{
		return GetItemInfo(ItemPos, bUseCache: true, bCheckIsFreeID: true, bCheckHasReferences: true);
	}

	public ITEMINFO GetItemInfo(int int_0, int int_1)
	{
		ITEMPOS itemPos = new ITEMPOS(int_0, int_1);
		return GetItemInfo(itemPos, bUseCache: true, bCheckIsFreeID: true, bCheckHasReferences: true);
	}

	public ITEMINFO GetItemInfo(ITEMPOS ParentItem, string fieldName)
	{
		if (ParentItem == null)
		{
			return null;
		}
		ITEMPOS itemPos = FindItemPos(ParentItem, fieldName);
		return GetItemInfo(itemPos, bUseCache: true, bCheckIsFreeID: true, bCheckHasReferences: true);
	}

	public ITEMINFO GetItemInfo(ITEMPOS ParentItem, int int_0)
	{
		if (ParentItem == null)
		{
			return null;
		}
		int int_1 = ParentItem.int_1;
		int int_2 = ParentItem.int_0;
		int valueIFast = Lists[int_2].GetValueIFast(int_1, int_0);
		GC.KeepAlive(this);
		ITEMPOS itemPos = FindItemPos(GetFieldLists(ParentItem.int_0, ParentItem.int_1, int_0), valueIFast);
		return GetItemInfo(itemPos, bUseCache: true, bCheckIsFreeID: true, bCheckHasReferences: true);
	}

	public ITEMINFO GetItemInfo(int id)
	{
		ITEMPOS itemPos = FindItemPos(MattersLists, id);
		return GetItemInfo(itemPos, bUseCache: true, bCheckIsFreeID: true, bCheckHasReferences: true);
	}

	public ITEMINFO GetItemInfo(string id)
	{
		ITEMPOS itemPos = FindMatter(id);
		return GetItemInfo(itemPos, bUseCache: true, bCheckIsFreeID: true, bCheckHasReferences: true);
	}

	public ITEMINFO GetItemInfo(int[] lists, int id)
	{
		ITEMPOS itemPos = FindItemPos(lists, id);
		return GetItemInfo(itemPos, bUseCache: true, bCheckIsFreeID: true, bCheckHasReferences: true);
	}

	public ITEMINFO GetItemInfo(int[] lists, string id)
	{
		ITEMPOS itemPos = FindItemPos(lists, ACE.RSGlobal.RSGlobal.UIntParseFast(id));
		GC.KeepAlive(this);
		return GetItemInfo(itemPos, bUseCache: true, bCheckIsFreeID: true, bCheckHasReferences: true);
	}

	public int valindex(int int_0, int int_1)
	{
		switch (Game)
		{
		default:
			GC.KeepAlive(this);
			return int_1;
		case GAMES.PW:
			GC.KeepAlive(this);
			return int_1;
		case GAMES.FW:
		{
			int valueIndexByBaseVersion547_FW = ACE.RSGlobal.RSGlobal.GetValueIndexByBaseVersion547_FW(int_0, int_1, (ushort)Version);
			GC.KeepAlive(this);
			return valueIndexByBaseVersion547_FW;
		}
		case GAMES.JD:
		{
			int valueIndexByBaseVersion150_JD = ACE.RSGlobal.RSGlobal.GetValueIndexByBaseVersion150_JD(int_0, int_1, (ushort)Version);
			GC.KeepAlive(this);
			return valueIndexByBaseVersion150_JD;
		}
		}
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsFieldExist(FIELDPOS fp)
	{
		int int_ = fp.int_0;
		int num = ((int_ > -1 && fp.int_1 > -1 && fp.int_2 > -1 && int_ < (nint)Lists.LongLength && fp.int_1 < GetItemsCount(int_) && fp.int_2 < GetFieldsCount(fp.int_0)) ? 1 : 0);
		return (byte)num != 0;
	}

	public int GetFieldsCount(int int_0)
	{
		nint num = (nint)Lists[int_0].elementTypes.LongLength;
		GC.KeepAlive(this);
		return (int)num;
	}

	public void ExportItems(string file, int ListIndex, int[] itemsindices)
	{
		if (File.Exists(file))
		{
			File.Delete(file);
		}
		StreamWriter streamWriter = new StreamWriter(file, append: false, Encoding.Unicode);
		try
		{
			ACE.Elements.eList.eList eList2 = Lists[ListIndex];
			string arg = ListIndex.ToString();
			if (Game != GAMES.Chibi && !CommonStorage.AParams.ItemsImportCompatibilityAce)
			{
				arg = eList2.uListName;
			}
			streamWriter.WriteLine(string.Format(Class16.smethod_0(1648889430), Version, arg));
			int fieldsCount = GetFieldsCount(ListIndex);
			foreach (int elementIndex in itemsindices)
			{
				for (int j = 0; j < fieldsCount; j++)
				{
					string arg2 = ((eList2.elementFields != null && j < eList2.elementFields.Length) ? eList2.elementFields[j] : ((j == 0) ? Class16.smethod_0(1648941057) : (Class16.smethod_0(1648962449) + j)));
					string text = eList2.GetValue(elementIndex, j, roundTrip: true);
					if (text.Length > 1 && (text.Contains(Class16.smethod_0(1648941987)) || text.Contains(Class16.smethod_0(1648904221))))
					{
						text = text.Replace(Class16.smethod_0(1648941987), Class16.smethod_0(1648903412)).Replace(Class16.smethod_0(1648904221), Class16.smethod_0(1648935632));
					}
					streamWriter.WriteLine(string.Format(Class16.smethod_0(1648962470), arg2, text));
				}
			}
		}
		finally
		{
			((IDisposable)streamWriter).Dispose();
		}
		GC.KeepAlive(this);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool ImportItemsContent(string FileContent, ref int ChangedListIndex, ref int[] ChangedItemsIndices, ref int ChangedElementsCounter, ref int AddedElementsCounter, ref ITEM_REPLACE_MODE ReplaceMode, Form owner)
	{
		string[] array = FileContent.Replace(Class16.smethod_0(1648904221), string.Empty).Split('\n');
		if (array != null && array.Length != 0)
		{
			int num = 0;
			bool flag = false;
			for (int i = 0; i < Math.Min(array.Length, 10); i++)
			{
				if (array[i].Contains(Class16.smethod_0(1648962482)))
				{
					flag = true;
					break;
				}
			}
			string text = array[num].Trim();
			if (string.IsNullOrWhiteSpace(text))
			{
				return false;
			}
			string[] array2 = text.Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			if (array2 != null && array2.Length >= 2)
			{
				if (!short.TryParse(array2[0], out var result))
				{
					return false;
				}
				string text2 = array2[1].Trim();
				int num2 = -1;
				if (ACE.RSGlobal.RSGlobal.IsUIntFast(text2))
				{
					num2 = ACE.RSGlobal.RSGlobal.UIntParseFast(text2);
					if (Lists == null || num2 < 0 || num2 >= ListCount)
					{
						return false;
					}
				}
				else
				{
					num2 = this.get_LI(text2);
					if (num2 < 0)
					{
						return false;
					}
				}
				ChangedListIndex = num2;
				ACE.Elements.eList.eList eList2 = Lists[num2];
				Dictionary<int, int> dictionary = new Dictionary<int, int>(eList2.IDs.Count);
				for (int j = 0; j < eList2.IDs.Count; j++)
				{
					int key = eList2.IDs[j];
					if (!dictionary.ContainsKey(key))
					{
						dictionary.Add(key, j);
					}
				}
				List<int> list = new List<int>();
				bool flag2 = false;
				List<object[]> list2 = new List<object[]>();
				if (flag)
				{
					Dictionary<string, string> dictionary2 = null;
					for (int k = num + 1; k < array.Length; k++)
					{
						string text3 = array[k].Trim();
						if (string.IsNullOrWhiteSpace(text3) || !text3.StartsWith(Class16.smethod_0(1648904453)) || !text3.Contains(Class16.smethod_0(1648962482)))
						{
							continue;
						}
						int num3 = text3.IndexOf(Class16.smethod_0(1648962482));
						string text4 = text3.Substring(1, num3 - 1);
						string value = text3.Substring(num3 + 5).TrimEnd('"');
						if (text4.Equals(Class16.smethod_0(1648941057), StringComparison.OrdinalIgnoreCase))
						{
							if (dictionary2 != null)
							{
								list2.Add(method_25(dictionary2, eList2));
							}
							dictionary2 = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
						}
						if (dictionary2 != null)
						{
							dictionary2[text4] = value;
						}
					}
					if (dictionary2 != null)
					{
						list2.Add(method_25(dictionary2, eList2));
					}
				}
				else
				{
					eListCollection eListCollection2 = new eListCollection(Game, result);
					int num4 = ((Game == GAMES.Chibi) ? num2 : eListCollection2.get_LI(eList2.uListName));
					ACE.Elements.eList.eList eList3 = ((num4 <= -1 || num4 >= eListCollection2.Lists.Length) ? null : eListCollection2.Lists[num4]);
					for (int l = num + 1; l < array.Length; l++)
					{
						string text5 = array[l];
						if (string.IsNullOrWhiteSpace(text5))
						{
							continue;
						}
						string[] array3 = text5.Split('\t');
						if (array3 != null && array3.Length != 0)
						{
							object[] array4 = new object[array3.Length];
							for (int m = 0; m < array3.Length; m++)
							{
								string type = ((eList3 != null && m < eList3.elementTypes.Length) ? eList3.elementTypes[m] : ((m < eList2.elementTypes.Length) ? eList2.elementTypes[m] : Class16.smethod_0(1648989776)));
								array4[m] = DeserializeValue(array3[m], type);
							}
							if (eList3 != null && array4.Length != eList2.FieldCount)
							{
								array4 = ConvertItem(eList3, eList2, array4, Lists[0].IDsHashSet);
							}
							list2.Add(array4);
						}
					}
				}
				for (int n = 0; n < list2.Count; n++)
				{
					object[] array5 = list2[n];
					if (array5 == null || array5.Length == 0)
					{
						continue;
					}
					int num5 = Convert.ToInt32(array5[0]);
					if (num5 == 0)
					{
						continue;
					}
					if (dictionary.TryGetValue(num5, out var value2))
					{
						int num6 = (int)ReplaceMode;
						if (num6 == 0)
						{
							ImportModeSelector importModeSelector = new ImportModeSelector(CStorage);
							try
							{
								if (importModeSelector.ShowDialog(owner) != DialogResult.OK)
								{
									flag2 = true;
									break;
								}
								ReplaceMode = (ITEM_REPLACE_MODE)CommonStorage.iData;
								num6 = (int)ReplaceMode;
							}
							finally
							{
								((IDisposable)importModeSelector).Dispose();
							}
						}
						if (num6 == 2)
						{
							continue;
						}
						if ((num6 == 1 || num6 == 3) && num6 == 1)
						{
							int[] itemsindices = new int[1] { value2 };
							ActionsHistory.stChangeItems(num2, itemsindices, null, null, -1);
							int length = Math.Min(array5.Length, eList2.elementValues[value2].Length);
							Array.Copy(array5, 0, eList2.elementValues[value2], 0, length);
							ActionsHistory.Complete();
							ChangedElementsCounter++;
							ItemChanged(num2, value2);
							list.Add(value2);
							continue;
						}
						if (num6 == 4)
						{
							int int_ = GetItemsCount(num2) - 1;
							int num7 = eList2.getid(int_);
							int firstnewid = num7 + 1;
							array5[0] = GetFreeID(num2, ref firstnewid);
						}
					}
					int num8 = GetItemsCount(num2) - 1;
					ActionsHistory.stAddItems(num2, new int[1] { GetItemsCount(num2) }, new int[1] { num8 }, -1);
					int num9 = AddItem(num2, array5);
					ActionsHistory.Complete();
					AddedElementsCounter++;
					list.Add(num9);
					int key2 = Convert.ToInt32(array5[0]);
					if (!dictionary.ContainsKey(key2))
					{
						dictionary.Add(key2, num9);
					}
					if (flag2)
					{
						break;
					}
				}
				ChangedItemsIndices = list.ToArray();
				FileChanged = ChangedElementsCounter > 0 || AddedElementsCounter > 0;
				ItemsCache[num2] = null;
				GC.KeepAlive(this);
				if (ChangedElementsCounter <= 0)
				{
					return AddedElementsCounter > 0;
				}
				return true;
			}
			return false;
		}
		return false;
	}

	private object[] method_25(Dictionary<string, string> dictionary_1, ACE.Elements.eList.eList eList_0)
	{
		object[] array = new object[eList_0.FieldCount];
		for (int i = 0; i < eList_0.FieldCount; i++)
		{
			string key = eList_0.elementFields[i];
			if (dictionary_1.TryGetValue(key, out var value))
			{
				array[i] = DeserializeValue(value, eList_0.elementTypes[i]);
			}
			else
			{
				array[i] = method_26(eList_0.elementTypes[i]);
			}
		}
		return array;
	}

	private object method_26(string string_1)
	{
		if (string_1.StartsWith(Class16.smethod_0(1648902778)))
		{
			return string.Empty;
		}
		if (string_1.StartsWith(Class16.smethod_0(1648902792)))
		{
			return string.Empty;
		}
		if (string_1 == Class16.smethod_0(1648902744))
		{
			return 0f;
		}
		return 0;
	}

	public static object[] GetDefaultItem(ACE.Elements.eList.eList List)
	{
		if (List.ItemCount > 0)
		{
			return ACE.RSGlobal.RSGlobal.CloneArray(List.elementValues[0]);
		}
		return CreateEmptyItem(List);
	}

	public object[] CreateEmptyItem(int int_0)
	{
		object[] result = CreateEmptyItem(Lists[int_0]);
		GC.KeepAlive(this);
		return result;
	}

	public static object[] CreateEmptyItem(ACE.Elements.eList.eList List)
	{
		string[] elementTypes = List.elementTypes;
		int num = elementTypes.Length;
		object[] array = new object[num + 1];
		int num2 = 0;
		if (0 < num)
		{
			do
			{
				array[num2] = CreateEmptyField(elementTypes[num2]);
				num2++;
				elementTypes = List.elementTypes;
			}
			while (num2 < (nint)elementTypes.LongLength);
		}
		return array;
	}

	public object CreateEmptyField(int int_0, int int_1)
	{
		object result = CreateEmptyField(Lists[int_0].elementTypes[int_1]);
		GC.KeepAlive(this);
		return result;
	}

	public static object CreateEmptyField(string type)
	{
		if (type != null)
		{
			switch (type.Length)
			{
			case 3:
				if (type == Class16.smethod_0(1648989776))
				{
					return 0;
				}
				break;
			case 4:
				if (type == Class16.smethod_0(1648989786))
				{
					return 0u;
				}
				break;
			case 5:
				switch (type[3])
				{
				case 'a':
					if (type == Class16.smethod_0(1648902744))
					{
						return 0f;
					}
					break;
				case '6':
					if (type == Class16.smethod_0(1648989830))
					{
						return 0L;
					}
					break;
				case '1':
					if (type == Class16.smethod_0(1648989805))
					{
						return (short)0;
					}
					break;
				}
				break;
			case 6:
				switch (type[4])
				{
				case 'l':
					if (type == Class16.smethod_0(1648989855))
					{
						return 0.0;
					}
					break;
				case '6':
					if (type == Class16.smethod_0(1648989834))
					{
						return 0uL;
					}
					break;
				case '1':
					if (type == Class16.smethod_0(1648989809))
					{
						return (ushort)0;
					}
					break;
				}
				break;
			}
		}
		if (type.StartsWith(Class16.smethod_0(1648985282)))
		{
			return new byte[ACE.RSGlobal.RSGlobal.String2Int_ext(type.Substring(5))];
		}
		if (type.StartsWith(Class16.smethod_0(1648985302)))
		{
			return new byte[ACE.RSGlobal.RSGlobal.String2Int_ext(type.Substring(8))];
		}
		if (type.StartsWith(Class16.smethod_0(1648985317)))
		{
			return new byte[ACE.RSGlobal.RSGlobal.String2Int_ext(type.Substring(7))];
		}
		return null;
	}

	public static object DeserializeValue(string Value, string type)
	{
		if (type != null)
		{
			switch (type.Length)
			{
			case 3:
				if (type == Class16.smethod_0(1648989776))
				{
					if (Value == string.Empty)
					{
						Value = Class16.smethod_0(1648924112);
					}
					return ACE.RSGlobal.RSGlobal.UIntParseFast(Value);
				}
				break;
			case 4:
				if (type == Class16.smethod_0(1648989786))
				{
					if (Value == string.Empty)
					{
						Value = Class16.smethod_0(1648924112);
					}
					return (!Value.StartsWith(Class16.smethod_0(1648941518))) ? Convert.ToUInt32(Value) : BitConverter.ToUInt32(BitConverter.GetBytes(ACE.RSGlobal.RSGlobal.UIntParseFast(Value)), 0);
				}
				break;
			case 5:
				switch (type[3])
				{
				case 'a':
					if (type == Class16.smethod_0(1648902744))
					{
						float float_ = 0f;
						NumberConverter.TryParseUniversalFloat(Value, ref float_);
						return float_;
					}
					break;
				case '6':
					if (type == Class16.smethod_0(1648989830))
					{
						if (Value == string.Empty)
						{
							Value = Class16.smethod_0(1648924112);
						}
						return Convert.ToInt64(Value);
					}
					break;
				case '1':
					if (type == Class16.smethod_0(1648989805))
					{
						if (Value == string.Empty)
						{
							Value = Class16.smethod_0(1648924112);
						}
						return Convert.ToInt16(Value);
					}
					break;
				}
				break;
			case 6:
				switch (type[4])
				{
				case 'l':
					if (type == Class16.smethod_0(1648989855))
					{
						if (Value == string.Empty)
						{
							Value = Class16.smethod_0(1648924112);
						}
						return Convert.ToDouble(Value);
					}
					break;
				case '6':
					if (type == Class16.smethod_0(1648989834))
					{
						if (Value == string.Empty)
						{
							Value = Class16.smethod_0(1648924112);
						}
						return Convert.ToUInt64(Value);
					}
					break;
				case '1':
					if (type == Class16.smethod_0(1648989809))
					{
						if (Value == string.Empty)
						{
							Value = Class16.smethod_0(1648924112);
						}
						return Convert.ToUInt16(Value);
					}
					break;
				}
				break;
			}
		}
		switch (type[0])
		{
		default:
			return null;
		case 'w':
		{
			Encoding unicode = Encoding.Unicode;
			byte[] array3 = new byte[ACE.RSGlobal.RSGlobal.String2Int_ext(type.Substring(8))];
			byte[] bytes = unicode.GetBytes(Value);
			int num2 = bytes.Length;
			int num3 = array3.Length;
			if (num3 > num2)
			{
				Array.Copy(bytes, array3, num2);
			}
			else
			{
				Array.Copy(bytes, array3, num3);
			}
			return array3;
		}
		case 's':
		{
			Encoding encoding = Encoding.GetEncoding(Class16.smethod_0(1648985403));
			byte[] array4 = new byte[ACE.RSGlobal.RSGlobal.String2Int_ext(type.Substring(7))];
			byte[] bytes2 = encoding.GetBytes(Value);
			int num4 = bytes2.Length;
			int num5 = array4.Length;
			if (num5 > num4)
			{
				Array.Copy(bytes2, array4, num4);
			}
			else
			{
				Array.Copy(bytes2, array4, num5);
			}
			return array4;
		}
		case 'b':
		{
			string[] array = Value.Split('-');
			byte[] array2 = new byte[ACE.RSGlobal.RSGlobal.String2Int_ext(type.Substring(5))];
			int num = 0;
			if (0 < (nint)array.LongLength)
			{
				do
				{
					array2[num] = Convert.ToByte(array[num], 16);
					num++;
				}
				while (num < (nint)array.LongLength);
			}
			return array2;
		}
		}
	}

	public HashSet<int> GetCachedIDs(int ListIndex)
	{
		HashSet<int> hashSet = new HashSet<int>();
		List<int> list = new List<int>();
		IsFreeID(ListIndex, 0, 0, list, bInAllLists: false);
		List<int>.Enumerator enumerator = list.GetEnumerator();
		if (enumerator.MoveNext())
		{
			do
			{
				int current = enumerator.Current;
				hashSet.UnionWith(Lists[current].IDs);
			}
			while (enumerator.MoveNext());
		}
		GC.KeepAlive(this);
		return hashSet;
	}

	public List<int> GetAllSimilarLists(int int_0)
	{
		List<int> list = new List<int>();
		IsFreeID(int_0, 0, 0, list, bInAllLists: false);
		return list;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsFreeID(int current_l, int current_e, int id, int ListIndex)
	{
		if (ACE.RSGlobal.RSGlobal.ELEMENTS_DEBUG)
		{
			return true;
		}
		if (ListIndex < ListCount)
		{
			List<int> iDs = Lists[ListIndex].IDs;
			if (iDs != null && iDs.Count != 0)
			{
				int num = Lists[ListIndex].IDs.IndexOf(id);
				if (num > -1)
				{
					if (current_e == -1)
					{
						GC.KeepAlive(this);
						return false;
					}
					if (current_l == ListIndex)
					{
						if (current_e == num)
						{
							int num2 = num + 1;
							if (num2 >= Lists[ListIndex].IDs.Count || Lists[ListIndex].IDs.IndexOf(id, num2) <= -1)
							{
								goto IL_009a;
							}
						}
						GC.KeepAlive(this);
						return false;
					}
					return false;
				}
				goto IL_009a;
			}
		}
		GC.KeepAlive(this);
		return true;
		IL_009a:
		return true;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsFreeID(int current_l, int current_e, int id, List<int> outResultLists, [MarshalAs(UnmanagedType.U1)] bool bInAllLists)
	{
		List<int> list = null;
		if (id < 0 && outResultLists == null)
		{
			return false;
		}
		int num = ((current_e > -1 || CommonStorage.AParams.UseSmartUniqueID) ? 1 : 0);
		if (!bInAllLists && current_l > -1 && (byte)num != 0)
		{
			list = null;
			ref ID_SPACE spaceId = ref Lists[current_l].SpaceId;
			if (Spaces.TryGetValue(spaceId, out list))
			{
				if (!IsFreeID(current_l, current_e, id, current_l))
				{
					return false;
				}
				int num2 = 0;
				if (0 < list.Count)
				{
					do
					{
						int num3 = list[num2];
						if (num3 == current_l || IsFreeID(current_l, current_e, id, num3))
						{
							num2++;
							continue;
						}
						return false;
					}
					while (num2 < list.Count);
				}
			}
			else
			{
				outResultLists?.Add(current_l);
				if (!IsFreeID(current_l, current_e, id, current_l))
				{
					return false;
				}
			}
		}
		else if (current_l == addons_l)
		{
			outResultLists?.Add(current_l);
			if (!IsFreeID(current_l, current_e, id, current_l))
			{
				return false;
			}
		}
		else
		{
			int num4 = 1;
			if (1 < (nint)Lists.LongLength)
			{
				do
				{
					if (num4 != ConversationListIndex)
					{
						outResultLists?.Add(num4);
						if (!IsFreeID(current_l, current_e, id, num4))
						{
							return false;
						}
					}
					num4++;
				}
				while (num4 < (nint)Lists.LongLength);
			}
		}
		return true;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsFreeID(int current_l, int current_e, int id)
	{
		return IsFreeID(current_l, current_e, id, null, bInAllLists: false);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsFreeID(int current_l, int current_e)
	{
		int id = Lists[current_l].getid(current_e);
		GC.KeepAlive(this);
		return IsFreeID(current_l, current_e, id, null, bInAllLists: false);
	}

	public int GetFreeID(int int_0, ref int firstnewid)
	{
		if (ACE.RSGlobal.RSGlobal.ELEMENTS_DEBUG)
		{
			return 0;
		}
		while (true)
		{
			byte b = ((!CommonStorage.AParams.UseSmartUniqueID) ? ((byte)1) : ((byte)0));
			if (IsFreeID(int_0, -1, firstnewid, null, b != 0))
			{
				break;
			}
			firstnewid++;
		}
		GC.KeepAlive(this);
		return firstnewid;
	}

	public static int GetFreeID(HashSet<int> CachedIDs, ref int firstnewid)
	{
		if (CachedIDs.Contains(firstnewid))
		{
			int item;
			do
			{
				firstnewid++;
				item = firstnewid;
			}
			while (CachedIDs.Contains(item));
		}
		return firstnewid;
	}

	public void SetUniqueID(int int_0, int int_1)
	{
		int int_2 = GetItemsCount(int_0) - 1;
		int num = Lists[int_0].getid(int_2);
		GC.KeepAlive(this);
		SetUniqueID(int_0, int_1, num + 1, bAutoSaveStage: true);
	}

	public int SetUniqueID(int int_0, int int_1, int firstnewid, [MarshalAs(UnmanagedType.U1)] bool bAutoSaveStage)
	{
		if (int_0 > -1 && int_0 < ListCount && int_1 > -1 && int_1 < GetItemsCount(int_0))
		{
			if (IsFreeID(int_0, int_1) && Params.DontChangeUniqueID)
			{
				return firstnewid;
			}
			SetItemID(int_0, int_1, GetFreeID(int_0, ref firstnewid), bAutoSaveStage);
			return firstnewid + 1;
		}
		return firstnewid;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool ProtectElements()
	{
		bool flag = false;
		int num = this.get_LI(Class16.smethod_0(1648962502));
		if (GetItemsCount(num) == 0)
		{
			object[] array = CreateEmptyItem(num);
			array[4] = 10f;
			array[5] = 1;
			array[6] = 105;
			array[7] = 100;
			int int_ = AddItem(num, array);
			SetUniqueID(num, int_, 60000, bAutoSaveStage: false);
			flag = true;
		}
		int num2 = this.get_LI(Class16.smethod_0(1648962520));
		if (GetItemsCount(num2) == 0)
		{
			int int_2 = AddItem(num2, CreateEmptyItem(num2));
			SetUniqueID(num2, int_2, 60001, bAutoSaveStage: false);
			flag = true;
		}
		int num3 = this.get_LI(Class16.smethod_0(1648962556));
		if (GetItemsCount(num3) == 0)
		{
			int int_3 = AddItem(num3, CreateEmptyItem(num3));
			SetUniqueID(num3, int_3, 60002, bAutoSaveStage: false);
			flag = true;
		}
		int num4 = this.get_LI(Class16.smethod_0(1648961556));
		string value = Class16.smethod_0(1648961583);
		if (!GetValue(num4, 0, 2).StartsWith(value))
		{
			string newValue = Class16.smethod_0(1648961583);
			string oldValue = Class16.smethod_0(1648961598);
			Lists[num4].SetValue(0, 2, GetValue(num4, 0, 2).Replace(oldValue, newValue));
			flag = true;
		}
		else if (!flag)
		{
			goto IL_0162;
		}
		FileChanged = true;
		goto IL_0162;
		IL_0162:
		return flag;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool UnProtectElements()
	{
		bool flag = false;
		if (GetItemsCount(25) > 0)
		{
			int num = 0;
			if (0 < GetItemsCount(25))
			{
				do
				{
					RemoveItem(25, num);
					num++;
				}
				while (num < GetItemsCount(25));
			}
			flag = true;
		}
		if (GetItemsCount(51) > 0)
		{
			int num2 = 0;
			if (0 < GetItemsCount(51))
			{
				do
				{
					RemoveItem(51, num2);
					num2++;
				}
				while (num2 < GetItemsCount(51));
			}
			flag = true;
		}
		if (GetItemsCount(52) > 0)
		{
			int num3 = 0;
			if (0 < GetItemsCount(52))
			{
				do
				{
					RemoveItem(52, num3);
					num3++;
				}
				while (num3 < GetItemsCount(52));
			}
			flag = true;
		}
		string value = Class16.smethod_0(1648961598);
		if (!GetValue(59, 0, 2).StartsWith(value))
		{
			Lists[59].SetValue(0, 2, GetValue(59, 0, 2).ToLowerInvariant());
			flag = true;
		}
		else if (!flag)
		{
			goto IL_00e5;
		}
		FileChanged = true;
		goto IL_00e5;
		IL_00e5:
		return flag;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsElementsProtected()
	{
		if (Game != GAMES.PW)
		{
			return false;
		}
		if (GetItemsCount(this.get_LI(Class16.smethod_0(1648962502))) > 0 && GetItemsCount(this.get_LI(Class16.smethod_0(1648962520))) > 0 && GetItemsCount(this.get_LI(Class16.smethod_0(1648962556))) > 0)
		{
			string value = Class16.smethod_0(1648961583);
			if (GetValue(this.get_LI(Class16.smethod_0(1648961556)), 0, 2).StartsWith(value))
			{
				GC.KeepAlive(this);
				return true;
			}
		}
		return false;
	}

	public object GetValueO(ITEMPOS ItemPos, string FieldUName)
	{
		int num = Lists[ItemPos.int_0].get_fields(FieldUName);
		if (num > -1)
		{
			GC.KeepAlive(this);
			return Lists[ItemPos.int_0].elementValues[ItemPos.int_1][num];
		}
		return null;
	}

	public object GetValueO(int int_0, int int_1, int int_2, [MarshalAs(UnmanagedType.U1)] bool bConvertString, [MarshalAs(UnmanagedType.U1)] bool bConvertShopPrice, [MarshalAs(UnmanagedType.U1)] bool bConvertHexColor, [MarshalAs(UnmanagedType.U1)] bool bConvertFloatAddon)
	{
		if (int_2 >= 0 && int_2 <= (nint)Lists[int_0].elementTypes.LongLength - 1)
		{
			object obj = null;
			if (bConvertFloatAddon && IsFloatAddon(int_0, int_1, int_2))
			{
				if (IsFloatAddon(0, int_1, int_2))
				{
					float num = BitConverter.ToSingle(BitConverter.GetBytes((int)Lists[0].elementValues[int_1][int_2]), 0);
					obj = num;
				}
				else
				{
					obj = (int)Lists[0].elementValues[int_1][int_2];
				}
			}
			else
			{
				FIELDTYPE fieldType = GetFieldType(int_0, int_1, int_2);
				if (bConvertShopPrice && fieldType == FIELDTYPE.shop_price)
				{
					int valueIFast = Lists[int_0].GetValueIFast(int_1, int_2);
					GC.KeepAlive(this);
					obj = CStorage.GetGamePricePW(valueIFast);
				}
				else if (bConvertHexColor && fieldType == FIELDTYPE.ft_hex_color)
				{
					obj = ACE.RSGlobal.RSGlobal.Color2HTML(ACE.RSGlobal.RSGlobal.Bgab2Argb((byte[])Lists[int_0].elementValues[int_1][int_2])).ToUpper();
				}
				else if (bConvertString && IsStringOrByteType(int_0, int_2))
				{
					obj = Lists[int_0].GetValue(int_1, int_2);
				}
			}
			if (obj == null)
			{
				obj = Lists[int_0].elementValues[int_1][int_2];
			}
			return obj;
		}
		GC.KeepAlive(this);
		return null;
	}

	public object GetValueO(int int_0, int int_1, int int_2)
	{
		return GetValueO(int_0, int_1, int_2, bConvertString: false, bConvertShopPrice: false, bConvertHexColor: false, bConvertFloatAddon: false);
	}

	public object GetValueO(FIELDPOS fp)
	{
		int int_ = fp.int_2;
		if (int_ >= 0)
		{
			ACE.Elements.eList.eList eList2 = Lists[fp.int_0];
			if (int_ <= (nint)eList2.elementTypes.LongLength - 1)
			{
				return eList2.elementValues[fp.int_1][int_];
			}
		}
		GC.KeepAlive(this);
		return null;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsStringOrByteType(int int_0, int int_1)
	{
		FIELD_DATA_TYPE_ENUM data_type = Lists[int_0].FieldDataTypes[int_1].data_type;
		int num = ((data_type == FIELD_DATA_TYPE_ENUM.WString || data_type == FIELD_DATA_TYPE_ENUM.String || data_type == FIELD_DATA_TYPE_ENUM.Bool) ? 1 : 0);
		return (byte)num != 0;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsStringType(int int_0, int int_1)
	{
		FIELD_DATA_TYPE_ENUM data_type = Lists[int_0].FieldDataTypes[int_1].data_type;
		int num = ((data_type == FIELD_DATA_TYPE_ENUM.WString || data_type == FIELD_DATA_TYPE_ENUM.String) ? 1 : 0);
		return (byte)num != 0;
	}

	public string GenerateCreaterOctets(string creator)
	{
		string text = null;
		if (creator != null && !(creator == string.Empty))
		{
			text += (creator.Length << 1).ToString(Class16.smethod_0(1648918695));
			char[] array = creator.ToCharArray();
			int num = 0;
			if (0 < (nint)array.LongLength)
			{
				do
				{
					string empty = string.Empty;
					string oldValue = Class16.smethod_0(1648941518);
					text += BitConverter.ToString(BitConverter.GetBytes(array[num])).Replace(oldValue, empty);
					num++;
				}
				while (num < (nint)array.LongLength);
			}
			GC.KeepAlive(this);
			return text;
		}
		GC.KeepAlive(this);
		return Class16.smethod_0(1648978986);
	}

	public unsafe string GenerateEquipmentOctetsPW(ITEMPOS ItemPos, string creator, ACE.Classes.ITEMDATA* ItemData)
	{
		string empty = string.Empty;
		string text = empty;
		if (Game != GAMES.PW)
		{
			return empty;
		}
		ItemType listType = Lists[ItemPos.int_0].ListType;
		int num = ((listType == ItemType.PW_ARMOR_ESSENCE || listType == ItemType.PW_NEW_ARMOR_ESSENCE) ? 1 : 0);
		bool flag = (byte)num != 0;
		bool flag2 = false;
		if (License.Special.TrialFunctionsMask == 1L && !License.Special.PW.PreviewRefine)
		{
			License.Special.PW.PreviewRefine = true;
			flag2 = true;
		}
		bDontWriteOctets = true;
		((int*)ItemData)[2] = GetValueI(ItemPos, Class16.smethod_0(1648960536));
		((int*)ItemData)[3] = GetValueI(ItemPos, Class16.smethod_0(1648960564));
		((int*)ItemData)[4] = GetValueI(ItemPos, Class16.smethod_0(1648961613));
		ADDONINFO[] array = (((((int*)ItemData)[250] = GetValueI(ItemPos, Class16.smethod_0(1648961617))) <= 0) ? GetRandomAddons(ItemPos.int_0, ItemPos.int_1) : GetCraftAddons(ItemPos.int_0, ItemPos.int_1));
		float valueF = GetValueF(ItemPos, Class16.smethod_0(1648919584));
		float valueF2 = GetValueF(ItemPos, Class16.smethod_0(1648919621));
		float valueF3 = GetValueF(ItemPos, Class16.smethod_0(1648919642));
		float valueF4 = GetValueF(ItemPos, Class16.smethod_0(1648919679));
		float valueByFieldNameF = GetValueByFieldNameF(ItemPos, Class16.smethod_0(1648922985), 0f);
		float num2 = 0f;
		if (Version >= 120 && ItemPos.int_0 == this.get_LI(Class16.smethod_0(1648923245)))
		{
			num2 = GetValueByFieldNameF(ItemPos, Class16.smethod_0(1648923022), 0f);
		}
		int num3 = -1;
		if ((double)valueF2 + (double)valueF + (double)valueF3 + (double)valueF4 + (double)valueByFieldNameF + (double)num2 < 9.999999974752427E-07)
		{
			num3 = 0;
		}
		else
		{
			while (true)
			{
				num3 = ((!TestProbability(valueF)) ? num3 : 0);
				num3 = (TestProbability(valueF2) ? 1 : num3);
				num3 = (TestProbability(valueF3) ? 2 : num3);
				num3 = (TestProbability(valueF4) ? 3 : num3);
				num3 = (TestProbability(valueByFieldNameF) ? 4 : num3);
				if (!TestProbability(num2))
				{
					if (num3 == -1)
					{
						continue;
					}
					if (num3 == 0)
					{
						break;
					}
				}
				else
				{
					num3 = 5;
				}
				num = array.Length;
				if (num != 0)
				{
					num3 = ((((int*)ItemData)[250] > 0) ? num : num3);
				}
				break;
			}
		}
		num = array.Length;
		num3 = (((int*)ItemData)[48] = ((num < num3) ? num : num3));
		bool flag3 = false;
		ADDONINFO[] uniqueAddons = GetUniqueAddons(ItemPos.int_0, ItemPos.int_1);
		int num4;
		int id;
		if (ItemPos.int_0 == this.get_LI(Class16.smethod_0(1648923245)))
		{
			float valueF5 = GetValueF(ItemPos, Class16.smethod_0(1648923079));
			num = ((TestProbability(valueF5) && uniqueAddons.Length != 0) ? 1 : 0);
			byte b = (byte)num;
			flag3 = b != 0;
			if (b != 0)
			{
				if (((int*)ItemData)[250] > 0)
				{
					((int*)ItemData)[48]++;
				}
				else
				{
					num3--;
				}
			}
			id = ((int*)ItemData)[3];
			num4 = this.get_LI(Class16.smethod_0(1648961635));
			ITEMPOS iTEMPOS = null;
			id = FindItemIndexByID(num4, id);
			if (id > -1)
			{
				iTEMPOS = new ITEMPOS(num4, id);
			}
			if (iTEMPOS != null)
			{
				num4 = iTEMPOS.int_1;
				float valueF6 = Lists[iTEMPOS.int_0].GetValueF(num4, 9);
				GC.KeepAlive(this);
				((float*)ItemData)[10] = valueF6;
				num4 = iTEMPOS.int_1;
				float valueF7 = Lists[iTEMPOS.int_0].GetValueF(num4, 10);
				GC.KeepAlive(this);
				((float*)ItemData)[13] = valueF7;
			}
		}
		List<int> list = new List<int>();
		num4 = 0;
		id = 0;
		int num5;
		if (array.Length != 0)
		{
			num5 = num3;
			while (num4 < num3)
			{
				num = ((((int*)ItemData)[250] == 0 || !list.Contains(id)) ? 1 : 0);
				if ((byte)num != 0)
				{
					num = ((((int*)ItemData)[250] > 0 && ((nint)num3 == (nint)array.LongLength || num5 == 1)) ? 1 : 0);
					num = (((byte)num != 0 || TestProbability(array[id].probability)) ? 1 : 0);
					if ((byte)num != 0)
					{
						AddAddon(array[id], ItemData, num4);
						num4++;
						num5--;
						list.Add(id);
					}
				}
				id++;
				num = array.Length;
				id = ((id <= num - 1) ? id : 0);
				if (num == 0)
				{
					break;
				}
			}
		}
		ADDONINFO addon = null;
		if (flag3)
		{
			num5 = 0;
			if (uniqueAddons.Length != 0)
			{
				do
				{
					if (!TestProbability(uniqueAddons[num5].probability))
					{
						num5++;
						num = uniqueAddons.Length;
						num5 = ((num5 <= num - 1) ? num5 : 0);
						continue;
					}
					addon = uniqueAddons[num5];
					AddAddon(addon, ItemData, num4);
					break;
				}
				while (num != 0);
			}
		}
		bDontWriteOctets = false;
		((int*)ItemData)[42] = GetValueI(ItemPos, Class16.smethod_0(1648961657));
		((int*)ItemData)[41] = GetValueI(ItemPos, Class16.smethod_0(1648961685));
		((int*)ItemData)[43] = GetValueI(ItemPos, Class16.smethod_0(1648961710));
		((int*)ItemData)[46] = GetValueI(ItemPos, Class16.smethod_0(1648961733));
		((int*)ItemData)[44] = GetValueI(ItemPos, Class16.smethod_0(1648961744));
		((int*)ItemData)[45] = GetValueI(ItemPos, Class16.smethod_0(1648961774));
		((int*)ItemData)[47] = 0;
		if (Version >= 60)
		{
			((int*)ItemData)[47] = GetValueI(ItemPos, Class16.smethod_0(1648961787));
		}
		if (!bDontWriteOctets)
		{
			num5 = ((int*)ItemData)[42];
			string text2 = Get4bytes(num5).Substring(0, 4);
			GC.KeepAlive(this);
			text += text2;
		}
		if (!bDontWriteOctets)
		{
			num5 = ((int*)ItemData)[41];
			string text3 = Get4bytes(num5).Substring(0, 4);
			GC.KeepAlive(this);
			text += text3;
		}
		if (!bDontWriteOctets)
		{
			num5 = ((int*)ItemData)[43];
			string text4 = Get4bytes(num5).Substring(0, 4);
			GC.KeepAlive(this);
			text += text4;
		}
		if (!bDontWriteOctets)
		{
			num5 = ((int*)ItemData)[46];
			string text5 = Get4bytes(num5).Substring(0, 4);
			GC.KeepAlive(this);
			text += text5;
		}
		if (!bDontWriteOctets)
		{
			num5 = ((int*)ItemData)[44];
			string text6 = Get4bytes(num5).Substring(0, 4);
			GC.KeepAlive(this);
			text += text6;
		}
		if (!bDontWriteOctets)
		{
			num5 = ((int*)ItemData)[45];
			string text7 = Get4bytes(num5).Substring(0, 4);
			GC.KeepAlive(this);
			text += text7;
		}
		num5 = GetValueI(ItemPos, Class16.smethod_0(1648961820));
		int valueI = GetValueI(ItemPos, Class16.smethod_0(1648961833));
		if (num5 > valueI)
		{
			num5 = valueI - 1;
		}
		num5 = RND.GenerateRnd(num5, valueI);
		if (!bDontWriteOctets)
		{
			text += Get4bytes(num5 * 100);
		}
		if (!bDontWriteOctets)
		{
			text += Get4bytes(valueI * 100);
		}
		((int*)ItemData)[38] = num5;
		((int*)ItemData)[39] = valueI;
		text = ((listType != ItemType.PW_WEAPON_ESSENCE) ? (text + Class16.smethod_0(1648961865)) : (text + Class16.smethod_0(1648961862)));
		text += Class16.smethod_0(1648961884);
		if (!bDontWriteOctets)
		{
			text += GenerateCreaterOctets(creator);
		}
		((int*)ItemData)[19] = 0;
		((int*)ItemData)[20] = 0;
		((int*)ItemData)[21] = 0;
		((int*)ItemData)[22] = 0;
		((int*)ItemData)[23] = 0;
		num5 = GetValueI(ItemPos, Class16.smethod_0(1648961893));
		int num6;
		if (num5 > 0)
		{
			ParamsClass paramsClass = Params;
			if (paramsClass.PreviewRefine && paramsClass.PreviewRefineLevel > 0 && License.Special.PW.PreviewRefine)
			{
				num6 = 1;
				goto IL_083b;
			}
		}
		num6 = 0;
		goto IL_083b;
		IL_083b:
		bool flag4 = (byte)num6 != 0;
		if (listType == ItemType.PW_WEAPON_ESSENCE)
		{
			((sbyte*)ItemData)[996] = 0;
			int val = GetValueI(ItemPos, Class16.smethod_0(1648961905)) switch
			{
				2 => 2, 
				1 => 0, 
				_ => 1, 
			};
			string text8;
			if (!bDontWriteOctets)
			{
				text8 = Get4bytes(val).Substring(0, 4);
				GC.KeepAlive(this);
				text += text8;
			}
			if (!bDontWriteOctets)
			{
				text8 = Get4bytes(0).Substring(0, 4);
				GC.KeepAlive(this);
				text += text8;
			}
			if (!bDontWriteOctets)
			{
				text += Get4bytes(((int*)ItemData)[2]);
			}
			if (!bDontWriteOctets)
			{
				text += Get4bytes(((int*)ItemData)[4]);
			}
			num6 = (((int*)ItemData)[40] = GetValueI(ItemPos, Class16.smethod_0(1648961928)));
			if (!bDontWriteOctets)
			{
				text += Get4bytes(num6);
			}
			((int*)ItemData)[14] = GetValueI(ItemPos, Class16.smethod_0(1648961953));
			text8 = Class16.smethod_0(1648961970);
			string text9 = Class16.smethod_0(1648961989);
			string text10 = Class16.smethod_0(1648962007);
			string text11 = Class16.smethod_0(1648961989);
			((int*)ItemData)[15] = GetMinMaxRange(ItemPos, text11 + text10, text9 + text8);
			((int*)ItemData)[16] = GetValueI(ItemPos, Class16.smethod_0(1648962010));
			text11 = Class16.smethod_0(1648961970);
			text10 = Class16.smethod_0(1648962033);
			text9 = Class16.smethod_0(1648962007);
			text8 = Class16.smethod_0(1648962033);
			num6 = (((int*)ItemData)[17] = GetMinMaxRange(ItemPos, text8 + text9, text10 + text11));
			((int*)ItemData)[28] = ((int*)ItemData)[14];
			((int*)ItemData)[29] = ((int*)ItemData)[15];
			((int*)ItemData)[30] = ((int*)ItemData)[16];
			((int*)ItemData)[31] = num6;
			ParamsClass paramsClass2 = Params;
			int previewRefineLevel;
			if (paramsClass2.PreviewRefine && License.Special.PW.PreviewRefine)
			{
				int num7 = num5;
				previewRefineLevel = paramsClass2.PreviewRefineLevel;
				Addons.RefineWeapon(num7.ToString(), previewRefineLevel, (int*)ItemData + 14, (int*)ItemData + 15, (int*)ItemData + 16, (int*)ItemData + 17);
			}
			if (!bDontWriteOctets)
			{
				text += Get4bytes(((int*)ItemData)[28]);
			}
			if (!bDontWriteOctets)
			{
				text += Get4bytes(((int*)ItemData)[29]);
			}
			if (!bDontWriteOctets)
			{
				text += Get4bytes(((int*)ItemData)[30]);
			}
			if (!bDontWriteOctets)
			{
				text += Get4bytes(((int*)ItemData)[31]);
			}
			previewRefineLevel = (int)((double)((float*)ItemData)[10] * 20.0);
			if (!bDontWriteOctets)
			{
				text += Get4bytes(previewRefineLevel);
			}
			float val2 = (((float*)ItemData)[12] = GetValueF(ItemPos, Class16.smethod_0(1648956937)));
			if (!bDontWriteOctets)
			{
				text += Get4bytes(val2);
			}
			if (!bDontWriteOctets)
			{
				text += Get4bytes(((float*)ItemData)[13]);
			}
		}
		else
		{
			((int*)ItemData)[9] = 0;
			((int*)ItemData)[8] = 0;
			((int*)ItemData)[5] = 0;
			((int*)ItemData)[6] = 0;
			string text12;
			string text13;
			string text14;
			string text15;
			if (flag)
			{
				text12 = Class16.smethod_0(1648956964);
				text13 = Class16.smethod_0(1648956968);
				text14 = Class16.smethod_0(1648956990);
				text15 = Class16.smethod_0(1648956968);
				((int*)ItemData)[18] = GetMinMaxRange(ItemPos, text15 + text14, text13 + text12);
				text12 = Class16.smethod_0(1648956964);
				text13 = Class16.smethod_0(1648956993);
				text14 = Class16.smethod_0(1648956990);
				text15 = Class16.smethod_0(1648956993);
				((int*)ItemData)[7] = GetMinMaxRange(ItemPos, text15 + text14, text13 + text12);
				text12 = Class16.smethod_0(1648956964);
				text13 = Class16.smethod_0(1648957021);
				text14 = Class16.smethod_0(1648956990);
				text15 = Class16.smethod_0(1648957021);
				((int*)ItemData)[6] = GetMinMaxRange(ItemPos, text15 + text14, text13 + text12);
				text12 = Class16.smethod_0(1648956964);
				text13 = Class16.smethod_0(1648957038);
				text14 = Class16.smethod_0(1648956990);
				text15 = Class16.smethod_0(1648957038);
				((int*)ItemData)[24] = (((int*)ItemData)[5] = GetMinMaxRange(ItemPos, text15 + text14, text13 + text12));
				((int*)ItemData)[32] = ((int*)ItemData)[18];
				((int*)ItemData)[25] = ((int*)ItemData)[7];
				ParamsClass paramsClass3 = Params;
				if (paramsClass3.PreviewRefine && License.Special.PW.PreviewRefine)
				{
					int num8 = num5;
					int previewRefineLevel2 = paramsClass3.PreviewRefineLevel;
					Addons.RefineArmor(num8.ToString(), previewRefineLevel2, (int*)ItemData + 5);
				}
				if (!bDontWriteOctets)
				{
					text += Get4bytes(((int*)ItemData)[32]);
				}
				if (!bDontWriteOctets)
				{
					text += Get4bytes(((int*)ItemData)[25]);
				}
				if (!bDontWriteOctets)
				{
					text += Get4bytes(((int*)ItemData)[6]);
				}
				if (!bDontWriteOctets)
				{
					text += Get4bytes(((int*)ItemData)[24]);
				}
			}
			else if (Lists[ItemPos.int_0].ListType == ItemType.PW_DECORATION_ESSENCE)
			{
				text12 = Class16.smethod_0(1648956964);
				text13 = Class16.smethod_0(1648957055);
				text14 = Class16.smethod_0(1648956990);
				text15 = Class16.smethod_0(1648957055);
				((int*)ItemData)[9] = GetMinMaxRange(ItemPos, text15 + text14, text13 + text12);
				text12 = Class16.smethod_0(1648956964);
				text13 = Class16.smethod_0(1648957068);
				text14 = Class16.smethod_0(1648956990);
				text15 = Class16.smethod_0(1648957068);
				((int*)ItemData)[8] = GetMinMaxRange(ItemPos, text15 + text14, text13 + text12);
				text12 = Class16.smethod_0(1648956964);
				text13 = Class16.smethod_0(1648956968);
				text14 = Class16.smethod_0(1648956990);
				text15 = Class16.smethod_0(1648956968);
				((int*)ItemData)[18] = GetMinMaxRange(ItemPos, text15 + text14, text13 + text12);
				text12 = Class16.smethod_0(1648956964);
				text13 = Class16.smethod_0(1648956993);
				text14 = Class16.smethod_0(1648956990);
				text15 = Class16.smethod_0(1648956993);
				int num9 = (((int*)ItemData)[7] = GetMinMaxRange(ItemPos, text15 + text14, text13 + text12));
				((int*)ItemData)[27] = ((int*)ItemData)[9];
				((int*)ItemData)[26] = ((int*)ItemData)[8];
				((int*)ItemData)[32] = ((int*)ItemData)[18];
				((int*)ItemData)[25] = num9;
				ParamsClass paramsClass4 = Params;
				if (paramsClass4.PreviewRefine && License.Special.PW.PreviewRefine)
				{
					int num10 = num5;
					int previewRefineLevel3 = paramsClass4.PreviewRefineLevel;
					Addons.RefineOrnament(num10.ToString(), previewRefineLevel3, ItemData);
				}
				if (!bDontWriteOctets)
				{
					text += Get4bytes(((int*)ItemData)[27]);
				}
				if (!bDontWriteOctets)
				{
					text += Get4bytes(((int*)ItemData)[26]);
				}
				if (!bDontWriteOctets)
				{
					text += Get4bytes(((int*)ItemData)[32]);
				}
				if (!bDontWriteOctets)
				{
					text += Get4bytes(((int*)ItemData)[25]);
				}
			}
			text12 = Class16.smethod_0(1648956964);
			text13 = Class16.smethod_0(1648957087);
			text14 = Class16.smethod_0(1648956990);
			text15 = Class16.smethod_0(1648957087);
			((int*)ItemData)[33] = GetMinMaxRange(ItemPos, text15 + text14, text13 + text12);
			text12 = Class16.smethod_0(1648956964);
			text13 = Class16.smethod_0(1648957110);
			text14 = Class16.smethod_0(1648956990);
			text15 = Class16.smethod_0(1648957110);
			((int*)ItemData)[34] = GetMinMaxRange(ItemPos, text15 + text14, text13 + text12);
			text12 = Class16.smethod_0(1648956964);
			text13 = Class16.smethod_0(1648957133);
			text14 = Class16.smethod_0(1648956990);
			text15 = Class16.smethod_0(1648957133);
			((int*)ItemData)[35] = GetMinMaxRange(ItemPos, text15 + text14, text13 + text12);
			text12 = Class16.smethod_0(1648956964);
			text13 = Class16.smethod_0(1648957156);
			text14 = Class16.smethod_0(1648956990);
			text15 = Class16.smethod_0(1648957156);
			((int*)ItemData)[36] = GetMinMaxRange(ItemPos, text15 + text14, text13 + text12);
			text12 = Class16.smethod_0(1648956964);
			text13 = Class16.smethod_0(1648957171);
			text14 = Class16.smethod_0(1648956990);
			text15 = Class16.smethod_0(1648957171);
			int num11 = (((int*)ItemData)[37] = GetMinMaxRange(ItemPos, text15 + text14, text13 + text12));
			int num12 = ((int*)ItemData)[33];
			((int*)ItemData)[19] += num12;
			((int*)ItemData)[20] += ((int*)ItemData)[34];
			((int*)ItemData)[21] += ((int*)ItemData)[35];
			((int*)ItemData)[22] += ((int*)ItemData)[36];
			((int*)ItemData)[23] += num11;
			if (!bDontWriteOctets)
			{
				text += Get4bytes(num12);
			}
			if (!bDontWriteOctets)
			{
				text += Get4bytes(((int*)ItemData)[34]);
			}
			if (!bDontWriteOctets)
			{
				text += Get4bytes(((int*)ItemData)[35]);
			}
			if (!bDontWriteOctets)
			{
				text += Get4bytes(((int*)ItemData)[36]);
			}
			if (!bDontWriteOctets)
			{
				text += Get4bytes(((int*)ItemData)[37]);
			}
		}
		ItemType listType2 = Lists[ItemPos.int_0].ListType;
		if (listType2 != ItemType.PW_WEAPON_ESSENCE && listType2 != ItemType.PW_ARMOR_ESSENCE && listType2 != ItemType.PW_NEW_ARMOR_ESSENCE)
		{
			text += Class16.smethod_0(1648957194);
			text += Class16.smethod_0(1648957194);
			((int*)ItemData)[1] = 0;
		}
		else
		{
			float valueF8 = GetValueF(ItemPos, Class16.smethod_0(1648957213));
			float valueF9 = GetValueF(ItemPos, Class16.smethod_0(1648957244));
			float valueF10 = GetValueF(ItemPos, Class16.smethod_0(1648957267));
			float num13;
			float num14;
			if (flag)
			{
				num13 = GetValueF(ItemPos, Class16.smethod_0(1648957298));
				num14 = GetValueF(ItemPos, Class16.smethod_0(1648957329));
			}
			else
			{
				num13 = 0f;
				num14 = 0f;
			}
			short num15 = -1;
			if ((double)valueF9 + (double)valueF8 + (double)valueF10 + (double)num13 + (double)num14 < 9.999999974752427E-07)
			{
				num15 = 0;
			}
			else
			{
				do
				{
					num15 = (short)((!TestProbability(valueF8)) ? num15 : 0);
					num15 = (short)(TestProbability(valueF9) ? 1 : num15);
					num15 = (short)(TestProbability(valueF10) ? 2 : num15);
					num15 = (short)(TestProbability(num13) ? 3 : num15);
					if (TestProbability(num14))
					{
						num15 = 4;
						break;
					}
				}
				while (num15 == -1);
			}
			int num16 = num15;
			((int*)ItemData)[1] = num16;
			if (!bDontWriteOctets)
			{
				num16 = num15;
				string text16 = Get4bytes(num16).Substring(0, 4);
				GC.KeepAlive(this);
				text += text16;
			}
			text += Class16.smethod_0(1648957194);
			num16 = num15;
			if (1 <= num16)
			{
				uint num17 = (uint)num16;
				do
				{
					text += Class16.smethod_0(1648971739);
					num17--;
				}
				while (num17 != 0);
			}
		}
		ADDONINFO aDDONINFO = null;
		if (flag4 && num5 > 0)
		{
			aDDONINFO = GetAddonInfo(num5);
		}
		int num18;
		if (!bDontWriteOctets)
		{
			num18 = ((aDDONINFO != null) ? 1 : 0);
			text += Get4bytes(num18 + ((int*)ItemData)[48]);
		}
		num18 = 0;
		if (0 < list.Count)
		{
			do
			{
				text += AddAddon(array[list[num18]], ItemData, num18);
				num18++;
			}
			while (num18 < list.Count);
		}
		if (flag3)
		{
			text += AddAddon(addon, ItemData, num4);
		}
		if (aDDONINFO != null)
		{
			text += ADDON.GetAddonHeadOctet(num5, 2);
			if (!bDontWriteOctets)
			{
				text += Get4bytes(aDDONINFO.param1);
			}
			if (!bDontWriteOctets)
			{
				text += Get4bytes(Params.PreviewRefineLevel);
			}
		}
		if (ItemPos.int_0 == this.get_LI(Class16.smethod_0(1648923245)))
		{
			float num19 = ((float*)ItemData)[10];
			if (num19 > 0f)
			{
				((float*)ItemData)[11] = (float)(1.0 / (double)num19);
			}
		}
		if (flag2)
		{
			License.Special.PW.PreviewRefine = false;
		}
		((int*)ItemData)[248] = num5;
		string result = text.ToLowerInvariant();
		GC.KeepAlive(this);
		return result;
	}

	public unsafe string AddAddon(ADDONINFO addon, ACE.Classes.ITEMDATA* ItemData, int index)
	{
		string text = null;
		int id = addon.id;
		ACE.Classes.ITEMDATA* ptr = (ACE.Classes.ITEMDATA*)((byte*)ItemData + index * 24);
		((int*)ptr)[50] = id;
		ACE.Classes.ITEMDATA* ptr2 = (ACE.Classes.ITEMDATA*)((byte*)ItemData + (index + 9) * 24);
		*(sbyte*)ptr2 = 0;
		int num;
		if (Addons.Abilities != null)
		{
			int id2 = addon.id;
			string value = id2.ToString();
			string[] iDs = Addons.Abilities.IDs;
			if (iDs != null && iDs.Length != 0 && Array.IndexOf(iDs, value) > -1)
			{
				num = 1;
				goto IL_0077;
			}
		}
		num = 0;
		goto IL_0077;
		IL_0077:
		byte b = (((byte*)ptr)[217] = (byte)num);
		int num2 = addon.num_params;
		if (b == 0 && num2 > 1)
		{
			num2--;
		}
		text += ADDON.GetAddonHeadOctet(id, num2);
		if (((bool*)ptr)[217])
		{
			if (!bDontWriteOctets)
			{
				text += Get4bytes(addon.param1);
			}
			if (addon.num_params >= 2 && !bDontWriteOctets)
			{
				text += Get4bytes(addon.param2);
			}
			if (addon.num_params == 3 && !bDontWriteOctets)
			{
				text += Get4bytes(addon.param3);
			}
			((double*)ptr)[26] = addon.param1;
			goto IL_035b;
		}
		double num3 = 0.0;
		int val = 0;
		int val2;
		if (addon.num_params > 0)
		{
			if (IsFloatAddon(addon.pos.int_1))
			{
				*(sbyte*)ptr2 = 1;
				if (addon.num_params == 1)
				{
					float num4 = BitConverter.ToSingle(BitConverter.GetBytes(addon.param1), 0);
					num3 = num4;
				}
				else
				{
					float num5 = BitConverter.ToSingle(BitConverter.GetBytes(addon.param1), 0);
					float num6 = BitConverter.ToSingle(BitConverter.GetBytes(addon.param2), 0);
					num3 = RND.GenerateRnd((double)num5, (double)num6);
				}
				string text2 = TextStorage.TEXTS.GetText(Class16.smethod_0(1648957360));
				if (Addons.GetAddonNameByID(addon.id).StartsWith(text2))
				{
					val2 = Convert.ToInt32(num3 * 20.0);
					if (bDontWriteOctets)
					{
						((float*)ItemData)[10] = (float)((double)((float*)ItemData)[10] - (double)(float)num3);
					}
					((sbyte*)ItemData)[996] = 1;
				}
				else
				{
					string text3 = TextStorage.TEXTS.GetText(Class16.smethod_0(1648957391));
					if (Addons.GetAddonNameByID(addon.id).StartsWith(text3))
					{
						string text4 = TextStorage.TEXTS.GetText(Class16.smethod_0(1648957391));
						string text5 = Class16.smethod_0(1648957414);
						int id3 = addon.id;
						if (!Addons.GetAddonNameByID(id3).StartsWith(text4 + text5))
						{
							val2 = addon.param1;
							goto IL_0315;
						}
					}
					val2 = Convert.ToInt32(num3 * 100.0);
				}
			}
			else
			{
				switch (addon.num_params)
				{
				default:
					num3 = addon.param1;
					val = RND.GenerateRnd(addon.param2, addon.param3);
					break;
				case 2:
					num3 = RND.GenerateRnd(addon.param1, addon.param2);
					break;
				case 1:
					num3 = addon.param1;
					break;
				}
				val2 = (int)num3;
			}
			goto IL_0315;
		}
		goto IL_034c;
		IL_034c:
		((double*)ptr)[26] = Math.Round(num3, 2);
		goto IL_035b;
		IL_035b:
		GC.KeepAlive(this);
		return text;
		IL_0315:
		if (!bDontWriteOctets)
		{
			text += Get4bytes(val2);
		}
		if (addon.num_params == 3 && !bDontWriteOctets)
		{
			text += Get4bytes(val);
		}
		goto IL_034c;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool TestProbability(float probability)
	{
		if (probability < 1E-07f)
		{
			return false;
		}
		if (probability >= 1f)
		{
			return true;
		}
		if (RND.Randomer.NextDouble() <= (double)probability)
		{
			GC.KeepAlive(this);
			return true;
		}
		return false;
	}

	public ADDONINFO GetAddonInfo(int id)
	{
		if (id == 0)
		{
			return null;
		}
		int num = addons_l;
		ITEMPOS iTEMPOS = null;
		int num2 = FindItemIndexByID(num, id);
		if (num2 > -1)
		{
			iTEMPOS = new ITEMPOS(num, num2);
		}
		if (iTEMPOS == null)
		{
			return null;
		}
		ADDONINFO aDDONINFO = new ADDONINFO();
		aDDONINFO.pos = iTEMPOS;
		aDDONINFO.id = id;
		aDDONINFO.num_params = (int)Lists[iTEMPOS.int_0].elementValues[iTEMPOS.int_1][2];
		aDDONINFO.param1 = (int)Lists[iTEMPOS.int_0].elementValues[iTEMPOS.int_1][3];
		aDDONINFO.param2 = (int)Lists[iTEMPOS.int_0].elementValues[iTEMPOS.int_1][4];
		aDDONINFO.param3 = (int)Lists[iTEMPOS.int_0].elementValues[iTEMPOS.int_1][5];
		return aDDONINFO;
	}

	public ADDONINFO[] GetCraftAddons(int int_0, int int_1)
	{
		List<ADDONINFO> list = new List<ADDONINFO>();
		string name = Class16.smethod_0(1648926289);
		int num = Lists[int_0].get_fields(Class16.smethod_0(1648923486));
		int num2 = Lists[int_0].get_fields(name);
		int num3 = num;
		if (num < num2)
		{
			do
			{
				int valueIFast = Lists[int_0].GetValueIFast(int_1, num3);
				GC.KeepAlive(this);
				float valueF = Lists[int_0].GetValueF(int_1, num3 + 1);
				GC.KeepAlive(this);
				if (LastAddons == null || !LastAddons.ContainsKey(Version) || valueIFast <= LastAddons[Version])
				{
					ADDONINFO addonInfo = GetAddonInfo(valueIFast);
					if (addonInfo != null)
					{
						addonInfo.probability = valueF;
						list.Add(addonInfo);
					}
				}
				num3 += 2;
			}
			while (num3 < num2);
		}
		ADDONINFO[] result = list.ToArray();
		GC.KeepAlive(this);
		return result;
	}

	public ADDONINFO[] GetRandomAddons(int int_0, int int_1)
	{
		List<ADDONINFO> list = new List<ADDONINFO>();
		string name = null;
		string name2 = null;
		string uListName = Lists[int_0].uListName;
		if (!(uListName == Class16.smethod_0(1648923245)))
		{
			if (!(uListName == Class16.smethod_0(1648923258)))
			{
				if (uListName == Class16.smethod_0(1648923366))
				{
					name = Class16.smethod_0(1648922763);
					name2 = Class16.smethod_0(1648957423);
				}
			}
			else
			{
				name = Class16.smethod_0(1648922763);
				name2 = Class16.smethod_0(1648957423);
			}
		}
		else
		{
			name = Class16.smethod_0(1648922763);
			name2 = Class16.smethod_0(1648957423);
		}
		int num = Lists[int_0].get_fields(name);
		int num2 = Lists[int_0].get_fields(name2);
		int num3 = num;
		if (num < num2)
		{
			do
			{
				int valueIFast = Lists[int_0].GetValueIFast(int_1, num3);
				GC.KeepAlive(this);
				float valueF = Lists[int_0].GetValueF(int_1, num3 + 1);
				GC.KeepAlive(this);
				if ((LastAddons == null || !LastAddons.ContainsKey(Version) || valueIFast <= LastAddons[Version]) && !(valueF < 1E-06f))
				{
					ADDONINFO addonInfo = GetAddonInfo(valueIFast);
					if (addonInfo != null)
					{
						addonInfo.probability = valueF;
						list.Add(addonInfo);
					}
				}
				num3 += 2;
			}
			while (num3 < num2);
		}
		ADDONINFO[] result = list.ToArray();
		GC.KeepAlive(this);
		return result;
	}

	public ADDONINFO[] GetUniqueAddons(int int_0, int int_1)
	{
		List<ADDONINFO> list = new List<ADDONINFO>(0);
		if (int_0 == this.get_LI(Class16.smethod_0(1648923245)))
		{
			int num = Lists[int_0].get_fields(Class16.smethod_0(1648926314));
			ACE.Elements.eList.eList eList2 = Lists[int_0];
			if (num < eList2.get_fields(Class16.smethod_0(1648923533)))
			{
				ACE.Elements.eList.eList eList3;
				do
				{
					int valueIFast = Lists[int_0].GetValueIFast(int_1, num);
					GC.KeepAlive(this);
					float valueF = Lists[int_0].GetValueF(int_1, num + 1);
					GC.KeepAlive(this);
					if (!(valueF < 1E-06f) && (LastAddons == null || !LastAddons.ContainsKey(Version) || valueIFast <= LastAddons[Version]))
					{
						ADDONINFO addonInfo = GetAddonInfo(valueIFast);
						if (addonInfo != null)
						{
							addonInfo.probability = valueF;
							list.Add(addonInfo);
						}
					}
					num += 2;
					eList3 = Lists[int_0];
				}
				while (num < eList3.get_fields(Class16.smethod_0(1648923533)));
			}
		}
		ADDONINFO[] result = list.ToArray();
		GC.KeepAlive(this);
		return result;
	}

	public string Get2bytes(int int_0, int int_1, int int_2)
	{
		string result = Get4bytes(int_0, int_1, int_2).Substring(0, 4);
		GC.KeepAlive(this);
		return result;
	}

	public string Get2bytes(int val)
	{
		string result = Get4bytes(val).Substring(0, 4);
		GC.KeepAlive(this);
		return result;
	}

	public string Get4bytes(float val)
	{
		string empty = string.Empty;
		string oldValue = Class16.smethod_0(1648941518);
		string result = BitConverter.ToString(BitConverter.GetBytes(val)).Replace(oldValue, empty);
		GC.KeepAlive(this);
		return result;
	}

	public string Get4bytes(int val)
	{
		string empty = string.Empty;
		string oldValue = Class16.smethod_0(1648941518);
		string result = BitConverter.ToString(BitConverter.GetBytes(val)).Replace(oldValue, empty);
		GC.KeepAlive(this);
		return result;
	}

	public string Get4bytes(int int_0, int int_1, int int_2)
	{
		if (Lists != null && int_0 >= 0 && int_0 < Lists.Length)
		{
			ACE.Elements.eList.eList eList2 = Lists[int_0];
			if (eList2 != null && eList2.elementValues != null && eList2.FieldDataTypes != null && int_1 >= 0 && int_1 < eList2.elementValues.Length && int_2 >= 0 && int_2 < eList2.FieldDataTypes.Length)
			{
				object[] array = eList2.elementValues[int_1];
				if (array != null && int_2 < array.Length)
				{
					byte[] valueBytes = ACE.Elements.eList.eList.GetValueBytes(array[int_2], eList2.FieldDataTypes[int_2].data_type);
					if (valueBytes == null)
					{
						return Get4bytes(0);
					}
					if ((nint)valueBytes.LongLength != 4)
					{
						return Get4bytes(0);
					}
					string empty = string.Empty;
					string oldValue = Class16.smethod_0(1648941518);
					string result = BitConverter.ToString(valueBytes).Replace(oldValue, empty);
					GC.KeepAlive(this);
					return result;
				}
				return Get4bytes(0);
			}
			return Get4bytes(0);
		}
		return Get4bytes(0);
	}

	public int GetMinMaxRange(ITEMPOS ItemPos, string field_min, string field_max)
	{
		int num = Lists[ItemPos.int_0].get_fields(field_min);
		int int_ = ItemPos.int_1;
		int int_2 = ItemPos.int_0;
		int num2 = (int)GetValueO(int_2, int_, num, bConvertString: false, bConvertShopPrice: false, bConvertHexColor: false, bConvertFloatAddon: false);
		int int_3 = ItemPos.int_1;
		int int_4 = ItemPos.int_0;
		int num3 = (int)GetValueO(int_4, int_3, num + 1, bConvertString: false, bConvertShopPrice: false, bConvertHexColor: false, bConvertFloatAddon: false);
		num2 = ((num2 > num3) ? num3 : num2);
		int result = RND.GenerateRnd(num2, num3);
		GC.KeepAlive(this);
		return result;
	}

	public float GetMinMaxRangeF(ITEMPOS ItemPos, string fn_min, string fn_max)
	{
		int num = Lists[ItemPos.int_0].get_fields(fn_min);
		int int_ = ItemPos.int_1;
		int int_2 = ItemPos.int_0;
		float num2 = (float)GetValueO(int_2, int_, num, bConvertString: false, bConvertShopPrice: false, bConvertHexColor: false, bConvertFloatAddon: false);
		int int_3 = ItemPos.int_1;
		int int_4 = ItemPos.int_0;
		float num3 = (float)GetValueO(int_4, int_3, num + 1, bConvertString: false, bConvertShopPrice: false, bConvertHexColor: false, bConvertFloatAddon: false);
		if ((double)num2 > (double)num3)
		{
			num2 = num3;
		}
		float result = RND.GenerateRnd(num2, num3);
		GC.KeepAlive(this);
		return result;
	}

	public unsafe string GenerateOctets(ITEMPOS ItemPos, string creator, ACE.Classes.ITEMDATA* ItemData)
	{
		int[] array = null;
		float[] array2 = null;
		string empty = string.Empty;
		string text = empty;
		if (Game != GAMES.PW)
		{
			return empty;
		}
		int int_ = ItemPos.int_0;
		int num = int_;
		ACE.Elements.eList.eList eList2 = Lists[int_];
		switch (eList2.ListType)
		{
		case ItemType.PW_DAMAGERUNE_ESSENCE:
			if (!bDontWriteOctets)
			{
				int int_71 = eList2.get_fields(Class16.smethod_0(1648956513));
				int int_72 = ItemPos.int_1;
				int int_73 = ItemPos.int_0;
				string text15 = Get4bytes(int_73, int_72, int_71).Substring(0, 4);
				GC.KeepAlive(this);
				text += text15;
			}
			if (!bDontWriteOctets)
			{
				int int_74 = Lists[ItemPos.int_0].get_fields(Class16.smethod_0(1648956531));
				int int_75 = ItemPos.int_1;
				int int_76 = ItemPos.int_0;
				string text16 = Get4bytes(int_76, int_75, int_74).Substring(0, 4);
				GC.KeepAlive(this);
				text += text16;
			}
			if (!bDontWriteOctets)
			{
				int int_77 = Lists[ItemPos.int_0].get_fields(Class16.smethod_0(1648956562));
				int int_78 = ItemPos.int_1;
				int int_79 = ItemPos.int_0;
				string text17 = Get4bytes(int_79, int_78, int_77).Substring(0, 4);
				GC.KeepAlive(this);
				text += text17;
			}
			if (!bDontWriteOctets)
			{
				int int_80 = Lists[ItemPos.int_0].get_fields(Class16.smethod_0(1648956593));
				int int_81 = ItemPos.int_1;
				int int_82 = ItemPos.int_0;
				string text18 = Get4bytes(int_82, int_81, int_80).Substring(0, 4);
				GC.KeepAlive(this);
				text += text18;
			}
			break;
		case ItemType.PW_MEDICINE_ESSENCE:
		{
			int int_51;
			switch (GetValueI(ItemPos, Class16.smethod_0(1648960536)))
			{
			case 1810:
				if (!bDontWriteOctets)
				{
					int_51 = ItemPos.int_1;
					int int_56 = ItemPos.int_0;
					text += Get4bytes(int_56, int_51, Lists[ItemPos.int_0].get_fields(Class16.smethod_0(1648956431)));
				}
				if (!bDontWriteOctets)
				{
					int_51 = ItemPos.int_1;
					int int_57 = ItemPos.int_0;
					text += Get4bytes(int_57, int_51, Lists[ItemPos.int_0].get_fields(Class16.smethod_0(1648956442)));
				}
				break;
			case 1802:
				if (!bDontWriteOctets)
				{
					int_51 = ItemPos.int_1;
					int int_54 = ItemPos.int_0;
					text += Get4bytes(int_54, int_51, Lists[ItemPos.int_0].get_fields(Class16.smethod_0(1648956431)));
				}
				if (!bDontWriteOctets)
				{
					int_51 = ItemPos.int_1;
					int int_55 = ItemPos.int_0;
					text += Get4bytes(int_55, int_51, Lists[ItemPos.int_0].get_fields(Class16.smethod_0(1648956469)));
				}
				break;
			case 1794:
				if (!bDontWriteOctets)
				{
					int_51 = ItemPos.int_1;
					int int_52 = ItemPos.int_0;
					text += Get4bytes(int_52, int_51, Lists[ItemPos.int_0].get_fields(Class16.smethod_0(1648956442)));
				}
				if (!bDontWriteOctets)
				{
					int_51 = ItemPos.int_1;
					int int_53 = ItemPos.int_0;
					text += Get4bytes(int_53, int_51, Lists[ItemPos.int_0].get_fields(Class16.smethod_0(1648956487)));
				}
				break;
			}
			int_51 = GetValueI(ItemPos, Class16.smethod_0(1648956497));
			if (int_51 < 1000)
			{
				int_51 *= 100;
			}
			if (!bDontWriteOctets)
			{
				text += Get4bytes(int_51);
			}
			if (!bDontWriteOctets)
			{
				int_51 = ItemPos.int_1;
				int int_58 = ItemPos.int_0;
				text += Get4bytes(int_58, int_51, Lists[ItemPos.int_0].get_fields(Class16.smethod_0(1648961657)));
			}
			break;
		}
		case ItemType.PW_FLYSWORD_ESSENCE:
		{
			if (!bDontWriteOctets)
			{
				float valueF5 = GetValueF(ItemPos, Class16.smethod_0(1648956708));
				int val4 = ((valueF5 < -2.1474836E+09f) ? int.MinValue : ((!(valueF5 > 2.1474836E+09f)) ? Convert.ToInt32(valueF5) : int.MaxValue));
				text += Get4bytes(val4);
			}
			if (!bDontWriteOctets)
			{
				float valueF6 = GetValueF(ItemPos, Class16.smethod_0(1648956727));
				int val5 = ((valueF6 < -2.1474836E+09f) ? int.MinValue : ((!(valueF6 > 2.1474836E+09f)) ? Convert.ToInt32(valueF6) : int.MaxValue));
				text += Get4bytes(val5);
			}
			if (!bDontWriteOctets)
			{
				int int_83 = Lists[ItemPos.int_0].get_fields(Class16.smethod_0(1648956616));
				int int_84 = ItemPos.int_1;
				int int_85 = ItemPos.int_0;
				string text19 = Get4bytes(int_85, int_84, int_83).Substring(0, 4);
				GC.KeepAlive(this);
				text += text19;
			}
			if (!bDontWriteOctets)
			{
				int int_86 = Lists[ItemPos.int_0].get_fields(Class16.smethod_0(1648961613));
				int int_87 = ItemPos.int_1;
				int int_88 = ItemPos.int_0;
				string text20 = Get4bytes(int_88, int_87, int_86).Substring(0, 4);
				GC.KeepAlive(this);
				text += text20;
			}
			if (!bDontWriteOctets)
			{
				int int_89 = ItemPos.int_1;
				int int_90 = ItemPos.int_0;
				text += Get4bytes(int_90, int_89, Lists[ItemPos.int_0].get_fields(Class16.smethod_0(1648961685)));
			}
			if (!bDontWriteOctets)
			{
				float valueF7 = GetValueF(ItemPos, Class16.smethod_0(1648956738));
				int val6 = ((valueF7 < -2.1474836E+09f) ? int.MinValue : ((!(valueF7 > 2.1474836E+09f)) ? Convert.ToInt32(valueF7) : int.MaxValue));
				text += Get4bytes(val6);
			}
			float valueF8 = GetValueF(ItemPos, Class16.smethod_0(1648956770));
			float valueF9 = GetValueF(ItemPos, Class16.smethod_0(1648956795));
			if (!bDontWriteOctets)
			{
				text += Get4bytes(RND.GenerateRnd(valueF8, valueF9));
			}
			valueF8 = GetValueF(ItemPos, Class16.smethod_0(1648956828));
			valueF9 = GetValueF(ItemPos, Class16.smethod_0(1648956850));
			if (!bDontWriteOctets)
			{
				text += Get4bytes(RND.GenerateRnd(valueF8, valueF9));
			}
			text += Class16.smethod_0(1648956880);
			if (!bDontWriteOctets)
			{
				text += GenerateCreaterOctets(creator);
			}
			text += Class16.smethod_0(1648957194);
			break;
		}
		case ItemType.PW_ARMORRUNE_ESSENCE:
			if (!bDontWriteOctets)
			{
				int int_18 = ItemPos.int_1;
				int int_19 = ItemPos.int_0;
				text += Get4bytes(int_19, int_18, eList2.get_fields(Class16.smethod_0(1648956513)));
			}
			if (!bDontWriteOctets)
			{
				int int_20 = ItemPos.int_1;
				int int_21 = ItemPos.int_0;
				text += Get4bytes(int_21, int_20, Lists[ItemPos.int_0].get_fields(Class16.smethod_0(1648956616)));
			}
			if (!bDontWriteOctets)
			{
				int int_22 = ItemPos.int_1;
				int int_23 = ItemPos.int_0;
				text += Get4bytes(int_23, int_22, Lists[ItemPos.int_0].get_fields(Class16.smethod_0(1648956655)));
			}
			if (!bDontWriteOctets)
			{
				int int_24 = ItemPos.int_1;
				int int_25 = ItemPos.int_0;
				text += Get4bytes(int_25, int_24, Lists[ItemPos.int_0].get_fields(Class16.smethod_0(1648956675)));
			}
			break;
		case ItemType.PW_STONE_ESSENCE:
		{
			ADDONINFO addonInfo = GetAddonInfo(GetValueI(ItemPos, Class16.smethod_0(1648923615)));
			ADDONINFO addonInfo2 = GetAddonInfo(GetValueI(ItemPos, Class16.smethod_0(1648923637)));
			if (addonInfo != null && addonInfo2 != null)
			{
				text += Class16.smethod_0(1648955932);
				text += AddAddon(addonInfo, ItemData, 0);
				text += Class16.smethod_0(1648955932);
				text += AddAddon(addonInfo2, ItemData, 1);
			}
			else
			{
				text += Class16.smethod_0(1648955939);
			}
			break;
		}
		case ItemType.PW_TOSSMATTER_ESSENCE:
		{
			if (!bDontWriteOctets)
			{
				int int_41 = ItemPos.int_1;
				int int_42 = ItemPos.int_0;
				text += Get4bytes(int_42, int_41, eList2.get_fields(Class16.smethod_0(1648961657)));
			}
			if (!bDontWriteOctets)
			{
				int int_43 = ItemPos.int_1;
				int int_44 = ItemPos.int_0;
				text += Get4bytes(int_44, int_43, Lists[ItemPos.int_0].get_fields(Class16.smethod_0(1648961710)));
			}
			if (!bDontWriteOctets)
			{
				int int_45 = ItemPos.int_1;
				int int_46 = ItemPos.int_0;
				text += Get4bytes(int_46, int_45, Lists[ItemPos.int_0].get_fields(Class16.smethod_0(1648961744)));
			}
			if (!bDontWriteOctets)
			{
				int int_47 = ItemPos.int_1;
				int int_48 = ItemPos.int_0;
				text += Get4bytes(int_48, int_47, Lists[ItemPos.int_0].get_fields(Class16.smethod_0(1648961953)));
			}
			float valueF = GetValueF(ItemPos, Class16.smethod_0(1648956904));
			float valueF2 = GetValueF(ItemPos, Class16.smethod_0(1648955910));
			if (!bDontWriteOctets)
			{
				text += Get4bytes(RND.GenerateRnd(valueF, valueF2));
			}
			if (!bDontWriteOctets)
			{
				int int_49 = ItemPos.int_1;
				int int_50 = ItemPos.int_0;
				text += Get4bytes(int_50, int_49, Lists[ItemPos.int_0].get_fields(Class16.smethod_0(1648956937)));
			}
			if (!bDontWriteOctets)
			{
				float valueF3 = GetValueF(ItemPos, Class16.smethod_0(1648956889));
				int val2 = ((valueF3 < -2.1474836E+09f) ? int.MinValue : ((!(valueF3 > 2.1474836E+09f)) ? Convert.ToInt32(valueF3) : int.MaxValue));
				text += Get4bytes(val2);
			}
			break;
		}
		case ItemType.PW_TOWNSCROLL_ESSENCE:
			if (!bDontWriteOctets)
			{
				float valueF4 = GetValueF(ItemPos, Class16.smethod_0(1648956889));
				int val3 = ((valueF4 < -2.1474836E+09f) ? int.MinValue : ((!(valueF4 > 2.1474836E+09f)) ? Convert.ToInt32(valueF4) : int.MaxValue));
				text += Get4bytes(val3);
			}
			break;
		case ItemType.PW_FASHION_ESSENCE:
			if (!bDontWriteOctets)
			{
				int int_97 = ItemPos.int_1;
				int int_98 = ItemPos.int_0;
				text += Get4bytes(int_98, int_97, eList2.get_fields(Class16.smethod_0(1648961657)));
			}
			text += Class16.smethod_0(1648957194);
			if (!bDontWriteOctets)
			{
				int int_99 = Lists[ItemPos.int_0].get_fields(Class16.smethod_0(1648956046));
				int int_100 = ItemPos.int_1;
				int int_101 = ItemPos.int_0;
				string text21 = Get4bytes(int_101, int_100, int_99).Substring(0, 4);
				GC.KeepAlive(this);
				text += text21;
			}
			text += Class16.smethod_0(1648957194);
			break;
		case ItemType.PW_TASKDICE_ESSENCE:
		{
			array = new int[0];
			array2 = new float[0];
			int num3 = 0;
			int num4 = 1;
			bool flag = Lists[num].get_fields(Class16.smethod_0(1648955962)) > -1;
			while (true)
			{
				string name = (flag ? (Class16.smethod_0(1648956005) + num4 + Class16.smethod_0(1648956023)) : (Class16.smethod_0(1648956005) + num4 + Class16.smethod_0(1648986201)));
				int num5 = Lists[num].get_fields(name);
				if (num5 <= 0)
				{
					string name2 = ((!flag) ? (Class16.smethod_0(1648956005) + num4 + Class16.smethod_0(1648956023)) : (Class16.smethod_0(1648956005) + num4 + Class16.smethod_0(1648986201)));
					num5 = Lists[num].get_fields(name2);
					if (num5 <= 0)
					{
						break;
					}
				}
				int int_106 = ItemPos.int_1;
				int int_107 = ItemPos.int_0;
				int_107 = Lists[int_107].GetValueIFast(int_106, num5);
				GC.KeepAlive(this);
				int num6 = Lists[num].get_fields(Class16.smethod_0(1648956005) + num4 + Class16.smethod_0(1648986239));
				float num7 = 0f;
				int_106 = ItemPos.int_1;
				if (num6 > -1)
				{
					num7 = Lists[ItemPos.int_0].GetValueF(int_106, num6);
					GC.KeepAlive(this);
				}
				else
				{
					num7 = Lists[ItemPos.int_0].GetValueF(int_106, num5 + 1);
					GC.KeepAlive(this);
				}
				if (int_107 > 0 && num7 > 1E-07f)
				{
					num3++;
					Array.Resize(ref array, num3);
					Array.Resize(ref array2, num3);
					array[num3 - 1] = int_107;
					array2[num3 - 1] = num7;
				}
				num4++;
			}
			if (num3 > 0)
			{
				int num8 = 0;
				if (!TestProbability(array2[0]))
				{
					do
					{
						num8++;
						num8 = ((num8 < (nint)array.LongLength) ? num8 : 0);
					}
					while (!TestProbability(array2[num8]));
				}
				num8 = array[num8];
				if (!bDontWriteOctets)
				{
					text += Get4bytes(num8);
				}
			}
			else
			{
				text += Class16.smethod_0(1648971739);
			}
			break;
		}
		case ItemType.PW_PET_FOOD_ESSENCE:
			if (!bDontWriteOctets)
			{
				int int_8 = ItemPos.int_1;
				int int_9 = ItemPos.int_0;
				text += Get4bytes(int_9, int_8, eList2.get_fields(Class16.smethod_0(1648956208)));
			}
			if (!bDontWriteOctets)
			{
				int int_10 = ItemPos.int_1;
				int int_11 = ItemPos.int_0;
				text += Get4bytes(int_11, int_10, Lists[ItemPos.int_0].get_fields(Class16.smethod_0(1648956188)));
			}
			break;
		case ItemType.PW_PET_EGG_ESSENCE:
		{
			int val7 = 1;
			int val8 = 4095;
			int num9 = 0;
			ITEMPOS iTEMPOS2 = FindItemPos(ItemPos, Class16.smethod_0(1648956066));
			if (iTEMPOS2 != null)
			{
				val7 = GetValueI(iTEMPOS2, Class16.smethod_0(1648956087));
				val8 = GetValueI(iTEMPOS2, Class16.smethod_0(1648961685));
				num9 = GetValueI(iTEMPOS2, Class16.smethod_0(1648956099)) switch
				{
					28752 => 3, 
					8781 => 0, 
					8782 => 1, 
					8783 => 2, 
					37698 => 5, 
					28913 => 4, 
					_ => 4, 
				};
			}
			List<int> list = new List<int>();
			List<int> list2 = new List<int>();
			int num10 = Lists[num].get_fields(Class16.smethod_0(1648956113));
			int int_113;
			if (num10 <= Lists[num].get_fields(Class16.smethod_0(1648956137)))
			{
				do
				{
					int int_112 = ItemPos.int_1;
					int_113 = ItemPos.int_0;
					int_113 = Lists[int_113].GetValueIFast(int_112, num10);
					GC.KeepAlive(this);
					if (int_113 > 0)
					{
						list.Add(int_113);
						int_113 = ItemPos.int_1;
						int_112 = ItemPos.int_0;
						int_113 = Lists[int_112].GetValueIFast(int_113, num10 + 1);
						GC.KeepAlive(this);
						list2.Add(int_113);
					}
					num10 += 2;
				}
				while (num10 <= Lists[num].get_fields(Class16.smethod_0(1648956137)));
			}
			if (!bDontWriteOctets)
			{
				text += Get4bytes(val7);
			}
			if (!bDontWriteOctets)
			{
				text += Get4bytes(val8);
			}
			if (!bDontWriteOctets)
			{
				int_113 = ItemPos.int_1;
				int int_114 = ItemPos.int_0;
				text += Get4bytes(int_114, int_113, Lists[ItemPos.int_0].get_fields(Class16.smethod_0(1648956162)));
			}
			if (!bDontWriteOctets)
			{
				int_113 = ItemPos.int_1;
				int int_115 = ItemPos.int_0;
				text += Get4bytes(int_115, int_113, Lists[ItemPos.int_0].get_fields(Class16.smethod_0(1648956066)));
			}
			if (!bDontWriteOctets)
			{
				text += Get4bytes(0);
			}
			if (!bDontWriteOctets)
			{
				text += Get4bytes(getid(ItemPos));
			}
			if (!bDontWriteOctets)
			{
				text += Get4bytes(num9);
			}
			if (!bDontWriteOctets)
			{
				int_113 = Lists[ItemPos.int_0].get_fields(Class16.smethod_0(1648961613));
				int int_116 = ItemPos.int_1;
				int int_117 = ItemPos.int_0;
				string text22 = Get4bytes(int_117, int_116, int_113).Substring(0, 4);
				GC.KeepAlive(this);
				text += text22;
			}
			if (!bDontWriteOctets)
			{
				string text23 = Get4bytes(0).Substring(0, 4);
				GC.KeepAlive(this);
				text += text23;
			}
			if (!bDontWriteOctets)
			{
				int_113 = ItemPos.int_1;
				int int_118 = ItemPos.int_0;
				text += Get4bytes(int_118, int_113, Lists[ItemPos.int_0].get_fields(Class16.smethod_0(1648956188)));
			}
			if (!bDontWriteOctets)
			{
				int_113 = ItemPos.int_1;
				int int_119 = ItemPos.int_0;
				text += Get4bytes(int_119, int_113, Lists[ItemPos.int_0].get_fields(Class16.smethod_0(1648956198)));
			}
			if (!bDontWriteOctets)
			{
				string text24 = Get4bytes(0).Substring(0, 4);
				GC.KeepAlive(this);
				text += text24;
			}
			if (!bDontWriteOctets)
			{
				int_113 = list.Count;
				string text25 = Get4bytes(int_113).Substring(0, 4);
				GC.KeepAlive(this);
				text += text25;
			}
			text += new string('0', 32);
			int_113 = 0;
			if (0 < list.Count)
			{
				do
				{
					if (!bDontWriteOctets)
					{
						text += Get4bytes(list[int_113]);
					}
					if (!bDontWriteOctets)
					{
						text += Get4bytes(list2[int_113]);
					}
					int_113++;
				}
				while (int_113 < list.Count);
			}
			if (num9 == 5)
			{
				string text26 = new string('0', 48);
				text += text26;
			}
			break;
		}
		case ItemType.PW_FACEPILL_ESSENCE:
			if (!bDontWriteOctets)
			{
				int int_102 = ItemPos.int_1;
				int int_103 = ItemPos.int_0;
				text += Get4bytes(int_103, int_102, eList2.get_fields(Class16.smethod_0(1648956051)));
			}
			if (!bDontWriteOctets)
			{
				int int_104 = ItemPos.int_1;
				int int_105 = ItemPos.int_0;
				text += Get4bytes(int_105, int_104, Lists[ItemPos.int_0].get_fields(Class16.smethod_0(1648961685)));
			}
			break;
		case ItemType.PW_WEDDING_BOOKCARD_ESSENCE:
			if (!bDontWriteOctets)
			{
				int int_31 = ItemPos.int_1;
				int int_32 = ItemPos.int_0;
				text += Get4bytes(int_32, int_31, eList2.get_fields(Class16.smethod_0(1648955471)));
			}
			if (!bDontWriteOctets)
			{
				int int_33 = ItemPos.int_1;
				int int_34 = ItemPos.int_0;
				text += Get4bytes(int_34, int_33, Lists[ItemPos.int_0].get_fields(Class16.smethod_0(1648906641)));
			}
			if (!bDontWriteOctets)
			{
				int int_35 = ItemPos.int_1;
				int int_36 = ItemPos.int_0;
				text += Get4bytes(int_36, int_35, Lists[ItemPos.int_0].get_fields(Class16.smethod_0(1648906674)));
			}
			break;
		case ItemType.PW_SPEAKER_ESSENCE:
			if (!bDontWriteOctets)
			{
				int int_29 = ItemPos.int_1;
				int int_30 = ItemPos.int_0;
				text += Get4bytes(int_30, int_29, eList2.get_fields(Class16.smethod_0(1648956268)));
			}
			break;
		case ItemType.PW_AUTOHP_ESSENCE:
			if (!bDontWriteOctets)
			{
				int int_108 = ItemPos.int_1;
				int int_109 = ItemPos.int_0;
				text += Get4bytes(int_109, int_108, eList2.get_fields(Class16.smethod_0(1648956286)));
			}
			if (!bDontWriteOctets)
			{
				int int_110 = ItemPos.int_1;
				int int_111 = ItemPos.int_0;
				text += Get4bytes(int_111, int_110, Lists[ItemPos.int_0].get_fields(Class16.smethod_0(1648956301)));
			}
			break;
		case ItemType.PW_AUTOMP_ESSENCE:
			if (!bDontWriteOctets)
			{
				int int_93 = ItemPos.int_1;
				int int_94 = ItemPos.int_0;
				text += Get4bytes(int_94, int_93, eList2.get_fields(Class16.smethod_0(1648956314)));
			}
			if (!bDontWriteOctets)
			{
				int int_95 = ItemPos.int_1;
				int int_96 = ItemPos.int_0;
				text += Get4bytes(int_96, int_95, Lists[ItemPos.int_0].get_fields(Class16.smethod_0(1648956301)));
			}
			break;
		case ItemType.PW_DOUBLE_EXP_ESSENCE:
			if (!bDontWriteOctets)
			{
				int int_91 = ItemPos.int_1;
				int int_92 = ItemPos.int_0;
				text += Get4bytes(int_92, int_91, eList2.get_fields(Class16.smethod_0(1648956329)));
			}
			break;
		case ItemType.PW_GOBLIN_ESSENCE:
		{
			if (!bDontWriteOctets)
			{
				text += Get4bytes(0);
			}
			if (!bDontWriteOctets)
			{
				string text2 = Get4bytes(1).Substring(0, 4);
				GC.KeepAlive(this);
				text += text2;
			}
			if (!bDontWriteOctets)
			{
				string text3 = Get4bytes(1).Substring(0, 4);
				GC.KeepAlive(this);
				text += text3;
			}
			if (!bDontWriteOctets)
			{
				int int_59 = Lists[ItemPos.int_0].get_fields(Class16.smethod_0(1648956359));
				int int_60 = ItemPos.int_1;
				int int_61 = ItemPos.int_0;
				string text4 = Get4bytes(int_61, int_60, int_59).Substring(0, 4);
				GC.KeepAlive(this);
				text += text4;
			}
			if (!bDontWriteOctets)
			{
				int int_62 = Lists[ItemPos.int_0].get_fields(Class16.smethod_0(1648956371));
				int int_63 = ItemPos.int_1;
				int int_64 = ItemPos.int_0;
				string text5 = Get4bytes(int_64, int_63, int_62).Substring(0, 4);
				GC.KeepAlive(this);
				text += text5;
			}
			if (!bDontWriteOctets)
			{
				int int_65 = Lists[ItemPos.int_0].get_fields(Class16.smethod_0(1648956398));
				int int_66 = ItemPos.int_1;
				int int_67 = ItemPos.int_0;
				string text6 = Get4bytes(int_67, int_66, int_65).Substring(0, 4);
				GC.KeepAlive(this);
				text += text6;
			}
			if (!bDontWriteOctets)
			{
				int int_68 = Lists[ItemPos.int_0].get_fields(Class16.smethod_0(1648956414));
				int int_69 = ItemPos.int_1;
				int int_70 = ItemPos.int_0;
				string text7 = Get4bytes(int_70, int_69, int_68).Substring(0, 4);
				GC.KeepAlive(this);
				text += text7;
			}
			if (!bDontWriteOctets)
			{
				string text8 = Get4bytes(1).Substring(0, 4);
				GC.KeepAlive(this);
				text += text8;
			}
			if (!bDontWriteOctets)
			{
				string text9 = Get4bytes(0).Substring(0, 4);
				GC.KeepAlive(this);
				text += text9;
			}
			if (!bDontWriteOctets)
			{
				string text10 = Get4bytes(0).Substring(0, 4);
				GC.KeepAlive(this);
				text += text10;
			}
			if (!bDontWriteOctets)
			{
				string text11 = Get4bytes(0).Substring(0, 4);
				GC.KeepAlive(this);
				text += text11;
			}
			if (!bDontWriteOctets)
			{
				string text12 = Get4bytes(0).Substring(0, 4);
				GC.KeepAlive(this);
				text += text12;
			}
			if (!bDontWriteOctets)
			{
				string text13 = Get4bytes(0).Substring(0, 4);
				GC.KeepAlive(this);
				text += text13;
			}
			if (!bDontWriteOctets)
			{
				string text14 = Get4bytes(0).Substring(0, 4);
				GC.KeepAlive(this);
				text += text14;
			}
			if (!bDontWriteOctets)
			{
				text += Get4bytes(20000);
			}
			if (!bDontWriteOctets)
			{
				text += Get4bytes(0);
			}
			if (!bDontWriteOctets)
			{
				text += Get4bytes(0);
			}
			int num2 = 0;
			int valueI = GetValueI(ItemPos, Class16.smethod_0(1648955400));
			num2 = ((valueI > 0) ? 1 : num2);
			int valueI2 = GetValueI(ItemPos, Class16.smethod_0(1648955429));
			if (valueI2 > 0)
			{
				num2++;
			}
			int valueI3 = GetValueI(ItemPos, Class16.smethod_0(1648955442));
			if (valueI3 > 0)
			{
				num2++;
			}
			if (!bDontWriteOctets)
			{
				text += Get4bytes(num2);
			}
			if (valueI > 0 && !bDontWriteOctets)
			{
				text += Get4bytes(valueI);
			}
			if (valueI2 > 0 && !bDontWriteOctets)
			{
				text += Get4bytes(valueI2);
			}
			if (valueI3 > 0 && !bDontWriteOctets)
			{
				text += Get4bytes(valueI3);
			}
			break;
		}
		case ItemType.PW_GOBLIN_EXPPILL_ESSENCE:
			if (!bDontWriteOctets)
			{
				int int_37 = ItemPos.int_1;
				int int_38 = ItemPos.int_0;
				text += Get4bytes(int_38, int_37, eList2.get_fields(Class16.smethod_0(1648956188)));
			}
			if (!bDontWriteOctets)
			{
				int int_39 = ItemPos.int_1;
				int int_40 = ItemPos.int_0;
				text += Get4bytes(int_40, int_39, Lists[ItemPos.int_0].get_fields(Class16.smethod_0(1648961613)));
			}
			break;
		case ItemType.PW_SKILLMATTER_ESSENCE:
			if (!bDontWriteOctets)
			{
				int int_12 = ItemPos.int_1;
				int int_13 = ItemPos.int_0;
				text += Get4bytes(int_13, int_12, eList2.get_fields(Class16.smethod_0(1648956229)));
			}
			if (!bDontWriteOctets)
			{
				int int_14 = ItemPos.int_1;
				int int_15 = ItemPos.int_0;
				text += Get4bytes(int_15, int_14, Lists[ItemPos.int_0].get_fields(Class16.smethod_0(1648970107)));
			}
			if (!bDontWriteOctets)
			{
				int int_16 = ItemPos.int_1;
				int int_17 = ItemPos.int_0;
				text += Get4bytes(int_17, int_16, Lists[ItemPos.int_0].get_fields(Class16.smethod_0(1648956242)));
			}
			break;
		case ItemType.PW_WEAPON_ESSENCE:
		case ItemType.PW_ARMOR_ESSENCE:
		case ItemType.PW_DECORATION_ESSENCE:
		case ItemType.PW_NEW_ARMOR_ESSENCE:
			text = GenerateEquipmentOctetsPW(ItemPos, creator, ItemData);
			break;
		case ItemType.PW_POKER_ESSENCE:
		{
			int val = 0;
			ITEMPOS iTEMPOS = FindItemPos(ItemPos, Class16.smethod_0(1648960564));
			if (iTEMPOS != null)
			{
				val = GetValueI(iTEMPOS, Class16.smethod_0(1648893461));
			}
			if (!bDontWriteOctets)
			{
				text += Get4bytes(val);
			}
			if (!bDontWriteOctets)
			{
				val = ItemPos.int_1;
				int int_26 = ItemPos.int_0;
				text += Get4bytes(int_26, val, Lists[ItemPos.int_0].get_fields(Class16.smethod_0(1648955547)));
			}
			if (!bDontWriteOctets)
			{
				val = ItemPos.int_1;
				int int_27 = ItemPos.int_0;
				text += Get4bytes(int_27, val, Lists[ItemPos.int_0].get_fields(Class16.smethod_0(1648961657)));
			}
			val = GetMinMaxRange(ItemPos, Class16.smethod_0(1648955566), Class16.smethod_0(1648955596));
			if (!bDontWriteOctets)
			{
				text += Get4bytes(val);
			}
			if (!bDontWriteOctets)
			{
				val = ItemPos.int_1;
				int int_28 = ItemPos.int_0;
				text += Get4bytes(int_28, val, Lists[ItemPos.int_0].get_fields(Class16.smethod_0(1648955618)));
			}
			if (!bDontWriteOctets)
			{
				text += Get4bytes(1);
			}
			if (!bDontWriteOctets)
			{
				text += Get4bytes(0);
			}
			if (!bDontWriteOctets)
			{
				text += Get4bytes(0);
			}
			break;
		}
		case ItemType.PW_FORCE_TOKEN_ESSENCE:
			if (!bDontWriteOctets)
			{
				int int_2 = ItemPos.int_1;
				int int_3 = ItemPos.int_0;
				text += Get4bytes(int_3, int_2, eList2.get_fields(Class16.smethod_0(1648955474)));
			}
			if (!bDontWriteOctets)
			{
				int int_4 = ItemPos.int_1;
				int int_5 = ItemPos.int_0;
				text += Get4bytes(int_5, int_4, Lists[ItemPos.int_0].get_fields(Class16.smethod_0(1648955502)));
			}
			if (!bDontWriteOctets)
			{
				int int_6 = ItemPos.int_1;
				int int_7 = ItemPos.int_0;
				text += Get4bytes(int_7, int_6, Lists[ItemPos.int_0].get_fields(Class16.smethod_0(1648955515)));
			}
			break;
		}
		string result = text.ToLowerInvariant();
		GC.KeepAlive(this);
		return result;
	}

	public unsafe string GenerateOctets(ITEMPOS ItemPos, string creator)
	{
		ACE.Classes.ITEMDATA iTEMDATA = default(ACE.Classes.ITEMDATA);
		System.Runtime.CompilerServices.Unsafe.InitBlock(ref System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, byte>(ref iTEMDATA), (byte)0, 2048u);
		ACE.Classes.ITEMDATA iTEMDATA2 = ACE.RSGlobal.RSGlobal.ITEMDATA();
		string result = GenerateOctets(ItemPos, creator, &iTEMDATA2);
		GC.KeepAlive(this);
		return result;
	}

	public unsafe string GenerateXML(ITEMPOS ItemPos, int count, string creator, ACE.Classes.ITEMDATA* ItemData, ref string octet)
	{
		int int_ = ItemPos.int_0;
		int int_2 = ItemPos.int_1;
		int num = 1;
		ItemType itemType = ParseListType(Lists[int_].uListName);
		if (Game == GAMES.PW && (itemType == ItemType.PW_WEAPON_ESSENCE || itemType == ItemType.PW_ARMOR_ESSENCE || itemType == ItemType.PW_DECORATION_ESSENCE || itemType == ItemType.PW_FLYSWORD_ESSENCE || itemType == ItemType.PW_NEW_ARMOR_ESSENCE))
		{
			num = count;
			count = 1;
		}
		int num2 = Lists[int_].getid(int_2);
		GC.KeepAlive(this);
		*(int*)ItemData = num2;
		int num3 = 1;
		num3 = (((int*)ItemData)[254] = ((count > 1) ? count : num3));
		if (Game != GAMES.PW || (int_ != this.get_LI(Class16.smethod_0(1648955634)) && int_ != this.get_LI(Class16.smethod_0(1648955663)) && int_ != this.get_LI(Class16.smethod_0(1648955681))))
		{
			int num4 = Lists[int_].get_fields(Class16.smethod_0(1648955717));
			if (num4 > 0)
			{
				int valueIFast = Lists[int_].GetValueIFast(int_2, num4);
				GC.KeepAlive(this);
				num3 = valueIFast;
			}
		}
		int num5 = 0;
		if (Lists[int_].get_fields(Class16.smethod_0(1648955728)) > -1)
		{
			num5 = GetValueI(ItemPos, Class16.smethod_0(1648955728));
		}
		((int*)ItemData)[252] = num5;
		if (Game == GAMES.PW)
		{
			int int_3 = ItemPos.int_0;
			bool flag = MattersListsFast != null && MattersListsFast.Contains(int_3);
			GC.KeepAlive(this);
			if (flag)
			{
				string text = string.Empty;
				int num6 = 0;
				if (0 < num)
				{
					ACE.Classes.ITEMDATA* ptr = (ACE.Classes.ITEMDATA*)((byte*)ItemData + 1020);
					ACE.Classes.ITEMDATA* ptr2 = (ACE.Classes.ITEMDATA*)((byte*)ItemData + 1012);
					do
					{
						text = ((Version <= 12) ? (text + Class16.smethod_0(1648955744)) : (text + Class16.smethod_0(1648955766)));
						if (Version > 12)
						{
							string text2 = Class16.smethod_0(1648955771);
							text = string.Concat(text, string.Concat(Class16.smethod_0(1648955791) + GetItemID(int_, int_2), text2));
						}
						else
						{
							string text3 = Class16.smethod_0(1648955795);
							text = string.Concat(text, string.Concat(Class16.smethod_0(1648955821) + GetItemID(int_, int_2), text3));
						}
						if (Version > 12)
						{
							string text4 = Class16.smethod_0(1648955860);
							text = string.Concat(text, string.Concat(Class16.smethod_0(1648955865) + num6, text4));
						}
						else
						{
							string text5 = Class16.smethod_0(1648955795);
							text = string.Concat(text, string.Concat(Class16.smethod_0(1648955886) + num6, text5));
						}
						num3 = ((count > num3) ? count : num3);
						if (Version > 12)
						{
							string text6 = Class16.smethod_0(1648958998);
							text = string.Concat(text, string.Concat(Class16.smethod_0(1648959013) + count, text6));
						}
						else
						{
							string text7 = Class16.smethod_0(1648955795);
							text = string.Concat(text, string.Concat(Class16.smethod_0(1648959028) + count, text7));
						}
						if (Version > 12)
						{
							string text8 = Class16.smethod_0(1648959070);
							text = string.Concat(text, string.Concat(Class16.smethod_0(1648959081) + num3, text8));
						}
						else
						{
							string text9 = Class16.smethod_0(1648955795);
							text = string.Concat(text, string.Concat(Class16.smethod_0(1648959108) + num3, text9));
						}
						((int*)ItemData)[254] = num3;
						text = ((Version <= 12) ? (text + Class16.smethod_0(1648959160)) : (text + Class16.smethod_0(1648959146)));
						text += (octet = GenerateOctets(ItemPos, creator, ItemData));
						text = ((Version <= 12) ? (text + Class16.smethod_0(1648955795)) : (text + Class16.smethod_0(1648959212)));
						byte[] array = new byte[*(int*)ptr = octet.Length / 2];
						int num7 = 0;
						if (0 < octet.Length)
						{
							do
							{
								byte b = Convert.ToByte(octet.Substring(num7, 2), 16);
								int num8 = num7 / 2;
								array[num8] = b;
								((byte*)ItemData + num8)[1024] = (byte)(sbyte)b;
								num7 += 2;
							}
							while (num7 < octet.Length);
						}
						if (Version > 12)
						{
							string text10 = Class16.smethod_0(1648959218);
							text = string.Concat(text, string.Concat(Class16.smethod_0(1648959244) + num5, text10));
						}
						else
						{
							string text11 = Class16.smethod_0(1648955795);
							text = string.Concat(text, string.Concat(Class16.smethod_0(1648959262) + num5, text11));
						}
						text = ((Version <= 12) ? (text + Class16.smethod_0(1648959343)) : (text + Class16.smethod_0(1648959299)));
						text = ((Version <= 12) ? (text + Class16.smethod_0(1648959419)) : (text + Class16.smethod_0(1648959395)));
						text = ((Version <= 12) ? (text + Class16.smethod_0(1648958473)) : (text + Class16.smethod_0(1648959473)));
						text = ((Version <= 12) ? (text + Class16.smethod_0(1648958549)) : (text + Class16.smethod_0(1648958535)));
						uint num9 = 0u;
						if (Game == GAMES.PW)
						{
							switch (itemType)
							{
							case ItemType.PW_WEAPON_ESSENCE:
								num9 = 1u;
								break;
							case ItemType.PW_FLYSWORD_ESSENCE:
								num9 = 4096u;
								break;
							case ItemType.PW_DAMAGERUNE_ESSENCE:
								num9 = 131072u;
								break;
							case ItemType.PW_PROJECTILE_ESSENCE:
								num9 = 2048u;
								break;
							case ItemType.PW_FORCE_TOKEN_ESSENCE:
								num9 = 67108864u;
								break;
							case ItemType.PW_SELL_CERTIFICATE_ESSENCE:
								num9 = 16777216u;
								break;
							case ItemType.PW_BIBLE_ESSENCE:
								num9 = 262144u;
								break;
							case ItemType.PW_SPEAKER_ESSENCE:
								num9 = 524288u;
								break;
							case ItemType.PW_AUTOHP_ESSENCE:
								num9 = 1048576u;
								break;
							case ItemType.PW_AUTOMP_ESSENCE:
								num9 = 2097152u;
								break;
							case ItemType.PW_GOBLIN_ESSENCE:
								num9 = 8388608u;
								break;
							case ItemType.PW_POKER_ESSENCE:
							{
								ITEMPOS iTEMPOS2 = FindItemPos(int_, int_2, Lists[int_].TypeFieldIndex);
								if (iTEMPOS2 != null)
								{
									ulong num10 = ACE.RSGlobal.RSGlobal.UInt64ParseFast(GetValue(iTEMPOS2, Class16.smethod_0(1648958590)));
									ulong num11 = num10 >> 32;
									num9 = (uint)((num11 == 0L) ? ((int)num10 & 0x3FFFFFFF) : (((int)num11 & 0x3FFFFFFF) | int.MinValue));
								}
								break;
							}
							case ItemType.PW_DYNSKILLEQUIP_ESSENCE:
								num9 = 402653184u;
								break;
							case ItemType.PW_ARMOR_ESSENCE:
							case ItemType.PW_DECORATION_ESSENCE:
							case ItemType.PW_FASHION_ESSENCE:
							case ItemType.PW_NEW_ARMOR_ESSENCE:
							case ItemType.PW_FASHION2_ESSENCE:
							{
								ITEMPOS iTEMPOS = FindItemPos(int_, int_2, Lists[int_].SubTypeFieldIndex);
								if (iTEMPOS != null)
								{
									num9 = (uint)GetValueI(iTEMPOS, Class16.smethod_0(1648958590));
								}
								break;
							}
							}
						}
						uint num12 = num9;
						text += num12;
						*(uint*)ptr2 = num9;
						text = ((Version <= 12) ? (text + Class16.smethod_0(1648955795)) : (text + Class16.smethod_0(1648958607)));
						text = ((Version <= 12) ? (text + Class16.smethod_0(1648958636)) : (text + Class16.smethod_0(1648958621)));
						num6++;
					}
					while (num6 < num);
				}
				object obj = null;
				if (int_ != this.get_LI(Class16.smethod_0(1648955663)) && int_ != this.get_LI(Class16.smethod_0(1648955681)))
				{
					obj = GetValueO(ItemPos, Class16.smethod_0(1648970148));
				}
				if (obj != null)
				{
					((int*)ItemData)[251] = GetValueI(ItemPos, Class16.smethod_0(1648970148));
				}
				else
				{
					((int*)ItemData)[251] = 0;
				}
				string result = text.Replace(Class16.smethod_0(1648941987), Class16.smethod_0(1648924428));
				GC.KeepAlive(this);
				return result;
			}
		}
		return string.Empty;
	}

	public unsafe string GenerateXML(ITEMPOS ItemPos, int count, string creator, ACE.Classes.ITEMDATA* ItemData)
	{
		string octet = null;
		return GenerateXML(ItemPos, count, creator, ItemData, ref octet);
	}

	public unsafe string GenerateXML(int int_0, int int_1, int count, string creator, ACE.Classes.ITEMDATA* ItemData)
	{
		string text = null;
		ITEMPOS itemPos = new ITEMPOS(int_0, int_1);
		text = null;
		return GenerateXML(itemPos, count, creator, ItemData, ref text);
	}

	public void SetRecipeNameFromItem(int int_0, int int_1)
	{
		string recipeNameFromResultItem = GetRecipeNameFromResultItem(int_0, int_1, isCaption: false);
		SetValue(int_0, int_1, Lists[int_0].NameFieldIndex, recipeNameFromResultItem, AutoSaveStage: false);
	}

	public void SetAlternativeItemName(int int_0, int int_1, string fromFieldName)
	{
		string value = GetRealItemName(int_0, int_1);
		ITEMPOS iTEMPOS = new ITEMPOS(int_0, int_1);
		ITEMINFO iTEMINFO;
		if (iTEMPOS == null)
		{
			iTEMINFO = null;
		}
		else
		{
			ITEMPOS itemPos = FindItemPos(iTEMPOS, fromFieldName);
			iTEMINFO = GetItemInfo(itemPos, bUseCache: true, bCheckIsFreeID: true, bCheckHasReferences: true);
		}
		if (iTEMINFO != null)
		{
			value = iTEMINFO.name;
		}
		SetValue(int_0, int_1, Lists[int_0].NameFieldIndex, value, AutoSaveStage: false);
	}

	private void method_27(FIELDTYPE fieldtype_0, int int_0)
	{
		string[] textsByPrefix = TextStorage.TEXTS.GetTextsByPrefix(Class16.smethod_0(1648908609) + int_0);
		DecodedValues.AddValues(fieldtype_0, textsByPrefix ?? Array.Empty<string>());
	}

	private void method_28(FIELDTYPE fieldtype_0, int int_0, ulong[] ulong_10)
	{
		string[] textsByPrefix = TextStorage.TEXTS.GetTextsByPrefix(Class16.smethod_0(1648908609) + int_0);
		DecodedValues.AddValues(fieldtype_0, textsByPrefix ?? Array.Empty<string>(), ulong_10);
	}

	private void method_29(FIELDTYPE fieldtype_0, int int_0)
	{
		string[] textsByPrefix = TextStorage.TEXTS.GetTextsByPrefix(Class16.smethod_0(1648908609) + int_0);
		if (textsByPrefix != null && textsByPrefix.Length != 0)
		{
			DecodedValues.AddValues(fieldtype_0, textsByPrefix);
		}
	}

	private void method_30(int int_0)
	{
		string[] textsByPrefix = TextStorage.TEXTS.GetTextsByPrefix(Class16.smethod_0(1648908609) + int_0);
		if (textsByPrefix != null && textsByPrefix.Length != 0)
		{
			DecodedValues.AddValues(int_0);
		}
	}

	private void method_31(Struct54[] struct54_4)
	{
		if (struct54_4 != null && struct54_4.Length != 0)
		{
			for (int i = 0; i < struct54_4.Length; i++)
			{
				method_27(struct54_4[i].fieldtype_0, struct54_4[i].int_0);
			}
		}
	}

	private void method_32(Struct55[] struct55_4)
	{
		if (struct55_4 != null && struct55_4.Length != 0)
		{
			for (int i = 0; i < struct55_4.Length; i++)
			{
				method_28(struct55_4[i].fieldtype_0, struct55_4[i].int_0, struct55_4[i].ulong_0);
			}
		}
	}

	public void InitDecodedValues(StreamReader ExtraTypes_sr)
	{
		if (!bOnlyConfig)
		{
			if (ExtraTypes_sr != null)
			{
				CommonStorage.Texts.LoadTextsFromCSV(ExtraTypes_sr, bCheckExistence: true, bCheckLangCount: false, Class16.smethod_0(1648958652));
			}
			string text = Class16.smethod_0(1648958669);
			string gamePrefix = GamePrefix;
			string text2 = Class16.smethod_0(1648960527);
			string text3 = string.Concat(string.Concat(Application.StartupPath + text2, gamePrefix), text);
			if (File.Exists(text3))
			{
				CommonStorage.Texts.LoadTexts(text3, bCheckExistence: true, bCheckLangCount: false);
			}
			DecodedValues = new ELEMENTS_DECODED_VALUES();
			method_31(struct54_0);
			method_32(struct55_0);
			switch (Game)
			{
			default:
				method_31(struct54_1);
				method_32(struct55_1);
				method_30(4005);
				break;
			case GAMES.FW:
				method_31(struct54_2);
				method_32(struct55_2);
				method_29(FIELDTYPE.proc_type, 5001);
				break;
			case GAMES.PW:
				method_31(struct54_3);
				method_32(struct55_3);
				method_44();
				break;
			}
			LoadWorldTargets();
			LoadEnumsAndMasks();
		}
	}

	public void LoadInstanceList()
	{
		List<string> list = new List<string>(95);
		List<decimal> list2 = new List<decimal>(95);
		string text = ((LANG_INFO.CurrentLang == null) ? Class16.smethod_0(1648931959) : LANG_INFO.CurrentLang.Prefix);
		string text2 = Class16.smethod_0(1648997294);
		string text3 = Class16.smethod_0(1648958683);
		string gamePrefix = GamePrefix;
		string text4 = Class16.smethod_0(1648960527);
		string text5 = string.Concat(string.Concat(string.Concat(string.Concat(Application.StartupPath + text4, gamePrefix), text3), text), text2);
		string text6 = string.Concat(string.Concat(string.Concat(string.Concat(Application.StartupPath + text4, gamePrefix), text3), Class16.smethod_0(1648931959)), text2);
		try
		{
			bool flag = false;
			bool sourceFound = false;
			if (Params.UsePck && PCKs != null && PCKs.LoadIfNotLoaded(Class16.smethod_0(1648991932)))
			{
				byte[] fileB = PCKs.GetFileB(Class16.smethod_0(1648905007));
				byte[] fileB2 = PCKs.GetFileB(Class16.smethod_0(1648905026));
				flag = INSTANCE_LIST.TryLoadFromPckEntries(fileB, fileB2, out sourceFound);
			}
			if (!flag && !sourceFound)
			{
				string fn = (File.Exists(text5) ? text5 : text6);
				INSTANCE_LIST.Load(fn);
			}
			if (INSTANCE_LIST.Instances != null)
			{
				List<INSTANCE>.Enumerator enumerator = INSTANCE_LIST.Instances.GetEnumerator();
				while (enumerator.MoveNext())
				{
					INSTANCE current = enumerator.Current;
					decimal item = current.ID;
					list2.Add(item);
					list.Add(INSTANCE_LIST.FormatDisplayName(current));
				}
			}
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1648958708));
			string text7 = Class16.smethod_0(1648958739) + ex.Message;
			DKBox.Show(text7, Class16.smethod_0(1648934892), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
		if (list.Count == 0)
		{
			list.Add(TextStorage.TEXTS.GetText(Class16.smethod_0(1648908635)));
			list2.Add(0m);
		}
		decimal[] realvalues = list2.ToArray();
		string[] decodedvalues = list.ToArray();
		DecodedValues.AddValues(FIELDTYPE.instance_file, decodedvalues, realvalues);
		GC.KeepAlive(this);
	}

	public void LoadWorldTargets()
	{
		if (CommonStorage.AParams == null)
		{
			return;
		}
		List<string> list = new List<string>(110);
		List<decimal> list2 = new List<decimal>(110);
		string text = CommonStorage.AParams.WorldTargetsPath;
		if (string.IsNullOrWhiteSpace(text) || !File.Exists(text))
		{
			string text2 = ((LANG_INFO.CurrentLang == null) ? Class16.smethod_0(1648931959) : LANG_INFO.CurrentLang.Prefix);
			string text3 = Class16.smethod_0(1648997294);
			string text4 = Class16.smethod_0(1648958782);
			string gamePrefix = GamePrefix;
			string text5 = Class16.smethod_0(1648960527);
			text = string.Concat(string.Concat(string.Concat(string.Concat(Application.StartupPath + text5, gamePrefix), text4), text2), text3);
		}
		if (File.Exists(text))
		{
			try
			{
				StreamReader streamReader = File.OpenText(text);
				while (!streamReader.EndOfStream)
				{
					string text6 = streamReader.ReadLine();
					if (string.IsNullOrWhiteSpace(text6) || text6.StartsWith(Class16.smethod_0(1648892117)) || text6.StartsWith(Class16.smethod_0(1648929947)))
					{
						continue;
					}
					string text7 = null;
					int num = text6.IndexOf(Class16.smethod_0(1648904453));
					if (num > -1)
					{
						int num2 = num + 1;
						int num3 = text6.IndexOf(Class16.smethod_0(1648904453), num2);
						if (num3 > num2)
						{
							text7 = text6.Substring(num2, num3 - num - 1);
							if (!string.IsNullOrEmpty(text7))
							{
								text6 = text6.Replace(text7, Class16.smethod_0(1648958804));
							}
						}
					}
					text6 = text6.Replace(' ', '\t');
					while (text6.Contains(Class16.smethod_0(1648982940)))
					{
						text6 = text6.Replace(Class16.smethod_0(1648982940), Class16.smethod_0(1648904383));
					}
					string[] array = text6.Split('\t');
					if (array != null && array.Length >= 2)
					{
						if (text7 == null)
						{
							text7 = array[1];
						}
						int result = 0;
						if (int.TryParse(array[0], out result))
						{
							decimal item = result;
							list2.Add(item);
							list.Add(text7);
						}
					}
				}
				streamReader.Close();
			}
			catch (Exception ex)
			{
				SentryHelper.CaptureException(ex, Class16.smethod_0(1648958812));
				string text8 = Class16.smethod_0(1648958843) + ex.Message;
				DKBox.Show(text8, Class16.smethod_0(1648934892), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
		decimal[] realvalues = list2.ToArray();
		string[] decodedvalues = list.ToArray();
		DecodedValues.AddValues(FIELDTYPE.world_targets_file, decodedvalues, realvalues);
		GC.KeepAlive(this);
	}

	public unsafe ACE.Classes.ITEMDATA* GenerateItemData(ACE.Classes.ITEMDATA* pItemdata_0, ITEMPOS ItemPos)
	{
		string text = null;
		ACE.RSGlobal.RSGlobal.ITEMDATA(pItemdata_0);
		text = null;
		GenerateXML(ItemPos, 1, string.Empty, pItemdata_0, ref text);
		return pItemdata_0;
	}

	public string GetHTMLDescription(int id)
	{
		string result = ((!IsDescsLoaded()) ? string.Empty : ACE.RSGlobal.RSGlobal.ToHTML(Descriptions.Get(id), bCutLine: false));
		GC.KeepAlive(this);
		return result;
	}

	public string GetACEwatemark()
	{
		if (CommonStorage.AParams.DisableACEwatemark)
		{
			GC.KeepAlive(this);
			return string.Empty;
		}
		string arg = ((!(((LANG_INFO.CurrentLang == null) ? Class16.smethod_0(1648931959) : LANG_INFO.CurrentLang.Prefix) == Class16.smethod_0(1648932072))) ? Class16.smethod_0(1648958886) : Class16.smethod_0(1648958886));
		string result = string.Format(Class16.smethod_0(1648958918), arg, Class16.smethod_0(1648958966));
		GC.KeepAlive(this);
		return result;
	}

	public string GetHtmlItemImage(string IconName, int int_0, [MarshalAs(UnmanagedType.U1)] bool compact)
	{
		string text = null;
		if (!compact)
		{
			text = string.Concat(str1: (Game != GAMES.PW) ? TextStorage.TEXTS.GetText(Class16.smethod_0(1648957992)) : (ParseListType(Lists[int_0].uListName) switch
			{
				ItemType.PW_NPC_ESSENCE => TextStorage.TEXTS.GetText(Class16.smethod_0(1648958970)), 
				ItemType.PW_MONSTER_ESSENCE => TextStorage.TEXTS.GetText(Class16.smethod_0(1648957969)), 
				_ => TextStorage.TEXTS.GetText(Class16.smethod_0(1648957992)), 
			}), str0: Class16.smethod_0(1648958023));
		}
		Bitmap bitmap;
		if (IconName != null)
		{
			ICONS icons = Icons;
			if (icons.Icons != null)
			{
				int size = (compact ? 24 : 0);
				bitmap = icons.GetIcon(IconName, Lists[int_0].IsTgaIcon, size);
				goto IL_0103;
			}
		}
		if (compact)
		{
			GC.KeepAlive(this);
			return string.Empty;
		}
		bitmap = DefaultACEImage;
		goto IL_0103;
		IL_0103:
		string text2 = Class16.smethod_0(1648958042);
		string text3 = Class16.smethod_0(1648958074);
		string text4 = Class16.smethod_0(1648958097);
		string text5 = Class16.smethod_0(1648979290);
		string text6 = Class16.smethod_0(1648979309);
		string text7 = Class16.smethod_0(1648923968);
		string result = string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(Class16.smethod_0(1648958217) + bitmap.Width, text7), bitmap.Height), text6), ACE.RSGlobal.RSGlobal.ImageToBase64(bitmap)), text5), text4), text), text3), text2);
		GC.KeepAlive(this);
		return result;
	}

	public unsafe string GenerateHTMLPreview(ITEMPOS ItemPos, ACE.Classes.ITEMDATA data, string creator, [MarshalAs(UnmanagedType.U1)] bool IsShopPrice, [MarshalAs(UnmanagedType.U1)] bool IsCleanHtml, [MarshalAs(UnmanagedType.U1)] bool bUnlimited, [MarshalAs(UnmanagedType.U1)] bool bViewIcon, ref DESC_EX Desc)
	{
		string empty = string.Empty;
		ITEMINFO itemInfo = GetItemInfo(ItemPos, bUseCache: true, bCheckIsFreeID: true, bCheckHasReferences: true);
		int int_ = ItemPos.int_0;
		bool flag = MattersListsFast != null && MattersListsFast.Contains(int_);
		GC.KeepAlive(this);
		empty += Class16.smethod_0(1648958272);
		string text = itemInfo.name;
		string uListName = Lists[ItemPos.int_0].uListName;
		string text2;
		if (System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(4))) > 0 && Game == GAMES.PW && (uListName == Class16.smethod_0(1648923245) || uListName == Class16.smethod_0(1648923258) || uListName == Class16.smethod_0(1648923096)))
		{
			object[] vars = new object[1] { System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(4))) };
			text2 = TextStorage.TEXTS.GetText(Class16.smethod_0(1648958288), vars);
			text += text2;
		}
		if (!Desc.bOnlyRefines && (License.Special.PW.PreviewRefine || License.Special.TrialFunctionsMask == 1L))
		{
			ParamsClass paramsClass = Params;
			if (paramsClass.PreviewRefine && paramsClass.PreviewRefineLevel > 0 && Game == GAMES.PW && (uListName == Class16.smethod_0(1648923245) || uListName == Class16.smethod_0(1648923258) || uListName == Class16.smethod_0(1648923366) || uListName == Class16.smethod_0(1648923096)))
			{
				int previewRefineLevel = Params.PreviewRefineLevel;
				text2 = Class16.smethod_0(1648922866);
				text = string.Concat(text, text2 + previewRefineLevel);
			}
		}
		HTML_HELPER hTML_HELPER = new HTML_HELPER(itemInfo.pos);
		hTML_HELPER.bViewReferences = false;
		hTML_HELPER.bNameBold = true;
		hTML_HELPER.bViewID = CommonStorage.AParams.bShowItemIdOnHint;
		hTML_HELPER.IdAfterName = CommonStorage.AParams.bShowItemIdOnHint;
		hTML_HELPER.bViewIcon = bViewIcon;
		hTML_HELPER.Name = text;
		hTML_HELPER.bDisableLinks = IsCleanHtml;
		text2 = EchoItem(hTML_HELPER, bOneLine: true);
		empty += text2;
		empty += Class16.smethod_0(1648902286);
		if (IsCleanHtml)
		{
			empty += GetACEwatemark();
		}
		Desc.head = empty;
		text2 = string.Empty;
		bool flag2 = false;
		if (flag)
		{
			text2 += Class16.smethod_0(1648902302);
			if (Game == GAMES.PW)
			{
				ulong flags = (ulong)(int)System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, uint>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(1008)));
				if (ACE.RSGlobal.RSGlobal.IsFlagExist(flags, 64uL))
				{
					uListName = TextStorage.TEXTS.GetText(Class16.smethod_0(1648958319));
					text = Class16.smethod_0(1648902161);
					uListName = string.Concat(Class16.smethod_0(1648958342) + uListName, text);
					text = ((uListName.Length <= 40) ? string.Empty : Class16.smethod_0(1648979197));
					uListName += text;
					GC.KeepAlive(this);
					text2 = string.Concat(text2, Class16.smethod_0(1648958369) + uListName);
					System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(1008))) -= 64;
				}
				else if (ACE.RSGlobal.RSGlobal.IsFlagExistP(flags, 15))
				{
					uListName = TextStorage.TEXTS.GetText(Class16.smethod_0(1648958390));
					text = Class16.smethod_0(1648902161);
					uListName = string.Concat(Class16.smethod_0(1648958413) + uListName, text);
					text = ((uListName.Length <= 40) ? string.Empty : Class16.smethod_0(1648979197));
					uListName += text;
					GC.KeepAlive(this);
					text2 = string.Concat(text2, Class16.smethod_0(1648958369) + uListName);
					System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(1008))) -= (int)Math.Pow(2.0, 15.0);
				}
				ItemType itemType = ParseListType(Lists[ItemPos.int_0].uListName);
				switch (itemType)
				{
				case ItemType.PW_WEAPON_ESSENCE:
				case ItemType.PW_ARMOR_ESSENCE:
				case ItemType.PW_DECORATION_ESSENCE:
				case ItemType.PW_NEW_ARMOR_ESSENCE:
				{
					flag2 = true;
					int previewRefineLevel2 = Params.PreviewRefineLevel;
					uListName = GenerateRefineText(System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(992))), previewRefineLevel2);
					Color lightGreen = Color.LightGreen;
					uListName = EchoAddon(System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(992))), uListName, lightGreen, IsCleanHtml);
					GC.KeepAlive(this);
					text = ((uListName.Length <= 40) ? string.Empty : Class16.smethod_0(1648979197));
					text = uListName + text;
					GC.KeepAlive(this);
					text2 = string.Concat(text2, Class16.smethod_0(1648958369) + text);
					if (itemType == ItemType.PW_ARMOR_ESSENCE || itemType == ItemType.PW_NEW_ARMOR_ESSENCE)
					{
						Desc.AddRefinedProp(uListName);
					}
					previewRefineLevel2 = ItemPos.int_0 - 1;
					ITEMPOS pos = null;
					int num = FindItemIndexByID(previewRefineLevel2, System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(12))));
					if (num > -1)
					{
						pos = new ITEMPOS(previewRefineLevel2, num);
					}
					uListName = GetParsedItemName(pos);
					text = ((uListName.Length <= 40) ? string.Empty : Class16.smethod_0(1648979197));
					uListName += text;
					GC.KeepAlive(this);
					text2 = string.Concat(text2, Class16.smethod_0(1648958369) + uListName);
					object[] vars2 = new object[1] { System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(16))) };
					uListName = TextStorage.TEXTS.GetText(Class16.smethod_0(1648958440), vars2);
					text = ((uListName.Length <= 40) ? string.Empty : Class16.smethod_0(1648979197));
					uListName += text;
					GC.KeepAlive(this);
					text2 = string.Concat(text2, Class16.smethod_0(1648958369) + uListName);
					switch (itemType)
					{
					case ItemType.PW_WEAPON_ESSENCE:
					{
						float num2 = System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, float>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(44)));
						uListName = ((System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, byte>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(996))) == 0) ? Class16.smethod_0(1648936452) : Class16.smethod_0(1648957447));
						text = Class16.smethod_0(1648902161);
						string text3 = Class16.smethod_0(1648922976);
						uListName = string.Concat(string.Concat(Class16.smethod_0(1648957478) + uListName, TextStorage.TEXTS.GetText(TextStorage.TEXTS.ResolveLegacyMessageKey(300, 0), num2.ToString(text3))), text);
						text = ((uListName.Length <= 40) ? string.Empty : Class16.smethod_0(1648979197));
						uListName += text;
						GC.KeepAlive(this);
						text2 = string.Concat(text2, Class16.smethod_0(1648958369) + uListName);
						float num3 = System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, float>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(48)));
						uListName = Class16.smethod_0(1648922976);
						uListName = TextStorage.TEXTS.GetText(TextStorage.TEXTS.ResolveLegacyMessageKey(301, 0), num3.ToString(uListName));
						text = ((uListName.Length <= 40) ? string.Empty : Class16.smethod_0(1648979197));
						uListName += text;
						GC.KeepAlive(this);
						text2 = string.Concat(text2, Class16.smethod_0(1648958369) + uListName);
						if (System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(8))) == 13)
						{
							float num4 = System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, float>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(52)));
							uListName = Class16.smethod_0(1648922976);
							uListName = TextStorage.TEXTS.GetText(TextStorage.TEXTS.ResolveLegacyMessageKey(302, 0), num4.ToString(uListName));
							text = ((uListName.Length <= 40) ? string.Empty : Class16.smethod_0(1648979197));
							uListName += text;
							GC.KeepAlive(this);
							text2 = string.Concat(text2, Class16.smethod_0(1648958369) + uListName);
						}
						vars2 = new object[2]
						{
							System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(56))),
							System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(60)))
						};
						uListName = TextStorage.TEXTS.GetText(Class16.smethod_0(1648957482), vars2);
						text = ((uListName.Length <= 40) ? string.Empty : Class16.smethod_0(1648979197));
						uListName += text;
						GC.KeepAlive(this);
						text2 = string.Concat(text2, Class16.smethod_0(1648958369) + uListName);
						if (System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(56))) != System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(112))) || System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(60))) != System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(116))))
						{
							Color cornflowerBlue11 = Color.CornflowerBlue;
							text2 += HTML_HELPER.EchoTextColored(cornflowerBlue11, string.Format(Class16.smethod_0(1648957505), System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(112))), System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(116)))));
							Desc.AddRefinedProp(uListName);
						}
						if (System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(8))) == 292 || System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(8))) == 25333 || System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(8))) == 44879)
						{
							vars2 = new object[2]
							{
								System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(64))),
								System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(68)))
							};
							uListName = TextStorage.TEXTS.GetText(Class16.smethod_0(1648957522), vars2);
							text = ((uListName.Length <= 40) ? string.Empty : Class16.smethod_0(1648979197));
							uListName += text;
							GC.KeepAlive(this);
							text2 = string.Concat(text2, Class16.smethod_0(1648958369) + uListName);
							if (System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(64))) != System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(120))) || System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(68))) != System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(124))))
							{
								Color cornflowerBlue12 = Color.CornflowerBlue;
								text2 += HTML_HELPER.EchoTextColored(cornflowerBlue12, string.Format(Class16.smethod_0(1648957505), System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(120))), System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(124)))));
								Desc.AddRefinedProp(uListName);
							}
						}
						break;
					}
					case ItemType.PW_ARMOR_ESSENCE:
					case ItemType.PW_DECORATION_ESSENCE:
					case ItemType.PW_NEW_ARMOR_ESSENCE:
						if (System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(36))) > 0)
						{
							vars2 = new object[1] { System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(36))) };
							uListName = TextStorage.TEXTS.GetText(Class16.smethod_0(1648957545), vars2);
							text = ((uListName.Length <= 40) ? string.Empty : Class16.smethod_0(1648979197));
							uListName += text;
							GC.KeepAlive(this);
							text2 = string.Concat(text2, Class16.smethod_0(1648958369) + uListName);
						}
						if (System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(36))) != System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(108))))
						{
							Color cornflowerBlue = Color.CornflowerBlue;
							text2 += HTML_HELPER.EchoTextColored(cornflowerBlue, string.Format(Class16.smethod_0(1648957568), System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(108)))));
							Desc.AddRefinedProp(uListName);
						}
						if (System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(32))) > 0)
						{
							vars2 = new object[1] { System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(32))) };
							uListName = TextStorage.TEXTS.GetText(Class16.smethod_0(1648957589), vars2);
							text = ((uListName.Length <= 40) ? string.Empty : Class16.smethod_0(1648979197));
							uListName += text;
							GC.KeepAlive(this);
							text2 = string.Concat(text2, Class16.smethod_0(1648958369) + uListName);
						}
						if (System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(32))) != System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(104))))
						{
							Color cornflowerBlue2 = Color.CornflowerBlue;
							text2 += HTML_HELPER.EchoTextColored(cornflowerBlue2, string.Format(Class16.smethod_0(1648957568), System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(104)))));
							Desc.AddRefinedProp(uListName);
						}
						if (System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(72))) > 0)
						{
							vars2 = new object[1] { System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(72))) };
							uListName = TextStorage.TEXTS.GetText(Class16.smethod_0(1648957612), vars2);
							text = ((uListName.Length <= 40) ? string.Empty : Class16.smethod_0(1648979197));
							uListName += text;
							GC.KeepAlive(this);
							text2 = string.Concat(text2, Class16.smethod_0(1648958369) + uListName);
						}
						if (System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(72))) != System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(128))))
						{
							Color cornflowerBlue3 = Color.CornflowerBlue;
							text2 += HTML_HELPER.EchoTextColored(cornflowerBlue3, string.Format(Class16.smethod_0(1648957568), System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(128)))));
							Desc.AddRefinedProp(uListName);
						}
						if (System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(28))) > 0)
						{
							vars2 = new object[1] { System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(28))) };
							uListName = TextStorage.TEXTS.GetText(Class16.smethod_0(1648957627), vars2);
							text = ((uListName.Length <= 40) ? string.Empty : Class16.smethod_0(1648979197));
							uListName += text;
							GC.KeepAlive(this);
							text2 = string.Concat(text2, Class16.smethod_0(1648958369) + uListName);
						}
						if (System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(28))) != System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(100))))
						{
							Color cornflowerBlue4 = Color.CornflowerBlue;
							text2 += HTML_HELPER.EchoTextColored(cornflowerBlue4, string.Format(Class16.smethod_0(1648957568), System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(100)))));
							Desc.AddRefinedProp(uListName);
						}
						if (System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(20))) > 0)
						{
							vars2 = new object[1] { System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(20))) };
							uListName = TextStorage.TEXTS.GetText(Class16.smethod_0(1648957650), vars2);
							text = ((uListName.Length <= 40) ? string.Empty : Class16.smethod_0(1648979197));
							uListName += text;
							GC.KeepAlive(this);
							text2 = string.Concat(text2, Class16.smethod_0(1648958369) + uListName);
						}
						if (System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(20))) != System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(96))) && System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(96))) != 0)
						{
							Color cornflowerBlue5 = Color.CornflowerBlue;
							text2 += HTML_HELPER.EchoTextColored(cornflowerBlue5, string.Format(Class16.smethod_0(1648957568), System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(96)))));
							Desc.AddRefinedProp(uListName);
						}
						if (System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(24))) > 0)
						{
							vars2 = new object[1] { System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(24))) };
							uListName = TextStorage.TEXTS.GetText(Class16.smethod_0(1648957673), vars2);
							text = ((uListName.Length <= 40) ? string.Empty : Class16.smethod_0(1648979197));
							uListName += text;
							GC.KeepAlive(this);
							text2 = string.Concat(text2, Class16.smethod_0(1648958369) + uListName);
						}
						if (System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(76))) > 0)
						{
							vars2 = new object[1] { System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(76))) };
							uListName = TextStorage.TEXTS.GetText(Class16.smethod_0(1648957696), vars2);
							text = ((uListName.Length <= 40) ? string.Empty : Class16.smethod_0(1648979197));
							uListName += text;
							GC.KeepAlive(this);
							text2 = string.Concat(text2, Class16.smethod_0(1648958369) + uListName);
						}
						if (System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(76))) != System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(132))))
						{
							Color cornflowerBlue6 = Color.CornflowerBlue;
							text2 += HTML_HELPER.EchoTextColored(cornflowerBlue6, string.Format(Class16.smethod_0(1648957568), System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(132)))));
							Desc.AddRefinedProp(uListName);
						}
						if (System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(80))) > 0)
						{
							vars2 = new object[1] { System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(80))) };
							uListName = TextStorage.TEXTS.GetText(Class16.smethod_0(1648957727), vars2);
							text = ((uListName.Length <= 40) ? string.Empty : Class16.smethod_0(1648979197));
							uListName += text;
							GC.KeepAlive(this);
							text2 = string.Concat(text2, Class16.smethod_0(1648958369) + uListName);
						}
						if (System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(80))) != System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(136))))
						{
							Color cornflowerBlue7 = Color.CornflowerBlue;
							text2 += HTML_HELPER.EchoTextColored(cornflowerBlue7, string.Format(Class16.smethod_0(1648957568), System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(136)))));
							Desc.AddRefinedProp(uListName);
						}
						if (System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(84))) > 0)
						{
							vars2 = new object[1] { System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(84))) };
							uListName = TextStorage.TEXTS.GetText(Class16.smethod_0(1648957750), vars2);
							text = ((uListName.Length <= 40) ? string.Empty : Class16.smethod_0(1648979197));
							uListName += text;
							GC.KeepAlive(this);
							text2 = string.Concat(text2, Class16.smethod_0(1648958369) + uListName);
						}
						if (System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(84))) != System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(140))))
						{
							Color cornflowerBlue8 = Color.CornflowerBlue;
							text2 += HTML_HELPER.EchoTextColored(cornflowerBlue8, string.Format(Class16.smethod_0(1648957568), System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(140)))));
							Desc.AddRefinedProp(uListName);
						}
						if (System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(88))) > 0)
						{
							vars2 = new object[1] { System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(88))) };
							uListName = TextStorage.TEXTS.GetText(Class16.smethod_0(1648957773), vars2);
							text = ((uListName.Length <= 40) ? string.Empty : Class16.smethod_0(1648979197));
							uListName += text;
							GC.KeepAlive(this);
							text2 = string.Concat(text2, Class16.smethod_0(1648958369) + uListName);
						}
						if (System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(88))) != System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(144))))
						{
							Color cornflowerBlue9 = Color.CornflowerBlue;
							text2 += HTML_HELPER.EchoTextColored(cornflowerBlue9, string.Format(Class16.smethod_0(1648957568), System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(144)))));
							Desc.AddRefinedProp(uListName);
						}
						if (System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(92))) > 0)
						{
							vars2 = new object[1] { System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(92))) };
							uListName = TextStorage.TEXTS.GetText(Class16.smethod_0(1648957796), vars2);
							text = ((uListName.Length <= 40) ? string.Empty : Class16.smethod_0(1648979197));
							uListName += text;
							GC.KeepAlive(this);
							text2 = string.Concat(text2, Class16.smethod_0(1648958369) + uListName);
						}
						if (System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(92))) != System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(148))))
						{
							Color cornflowerBlue10 = Color.CornflowerBlue;
							text2 += HTML_HELPER.EchoTextColored(cornflowerBlue10, string.Format(Class16.smethod_0(1648957568), System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(148)))));
							Desc.AddRefinedProp(uListName);
						}
						break;
					}
					if (Desc.bOnlyRefines)
					{
						return null;
					}
					vars2 = new object[2]
					{
						System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(152))),
						System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(156)))
					};
					string text4 = TextStorage.TEXTS.GetText(Class16.smethod_0(1648957811), vars2);
					text = ((text4.Length <= 40) ? string.Empty : Class16.smethod_0(1648979197));
					text4 += text;
					GC.KeepAlive(this);
					text2 = string.Concat(text2, Class16.smethod_0(1648958369) + text4);
					if (itemType == ItemType.PW_WEAPON_ESSENCE && System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(160))) != 0)
					{
						ITEMPOS pos2 = null;
						int num5 = FindItemIndexByID(30, System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(160))));
						if (num5 > -1)
						{
							pos2 = new ITEMPOS(30, num5);
						}
						text4 = GetParsedItemName(pos2);
						text4 = TextStorage.TEXTS.GetText(TextStorage.TEXTS.ResolveLegacyMessageKey(311, 0), text4);
						text = ((text4.Length <= 40) ? string.Empty : Class16.smethod_0(1648979197));
						text4 += text;
						GC.KeepAlive(this);
						text2 = string.Concat(text2, Class16.smethod_0(1648958369) + text4);
					}
					if (System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(164))) != 1023 && (Version >= 60 || System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(164))) != 255))
					{
						text4 = DecodeMask(60, (ulong)(int)System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, uint>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(164))));
						text = string.Empty;
						string oldValue = Class16.smethod_0(1648928028);
						text4 = TextStorage.TEXTS.GetText(TextStorage.TEXTS.ResolveLegacyMessageKey(312, 0), text4.Replace(oldValue, text));
						text = ((text4.Length <= 40) ? string.Empty : Class16.smethod_0(1648979197));
						text4 += text;
						GC.KeepAlive(this);
						text2 = string.Concat(text2, Class16.smethod_0(1648958369) + text4);
					}
					vars2 = new object[1] { System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(168))) };
					text4 = TextStorage.TEXTS.GetText(Class16.smethod_0(1648957834), vars2);
					text = ((text4.Length <= 40) ? string.Empty : Class16.smethod_0(1648979197));
					text4 += text;
					GC.KeepAlive(this);
					text2 = string.Concat(text2, Class16.smethod_0(1648958369) + text4);
					if (System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(172))) > 0)
					{
						vars2 = new object[1] { System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(172))) };
						text4 = TextStorage.TEXTS.GetText(Class16.smethod_0(1648957857), vars2);
						text = ((text4.Length <= 40) ? string.Empty : Class16.smethod_0(1648979197));
						text4 += text;
						GC.KeepAlive(this);
						text2 = string.Concat(text2, Class16.smethod_0(1648958369) + text4);
					}
					if (System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(176))) > 0)
					{
						vars2 = new object[1] { System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(176))) };
						text4 = TextStorage.TEXTS.GetText(Class16.smethod_0(1648957880), vars2);
						text = ((text4.Length <= 40) ? string.Empty : Class16.smethod_0(1648979197));
						text4 += text;
						GC.KeepAlive(this);
						text2 = string.Concat(text2, Class16.smethod_0(1648958369) + text4);
					}
					if (System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(180))) > 0)
					{
						vars2 = new object[1] { System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(180))) };
						text4 = TextStorage.TEXTS.GetText(Class16.smethod_0(1648957911), vars2);
						text = ((text4.Length <= 40) ? string.Empty : Class16.smethod_0(1648979197));
						text4 += text;
						GC.KeepAlive(this);
						text2 = string.Concat(text2, Class16.smethod_0(1648958369) + text4);
					}
					if (System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(184))) > 0)
					{
						vars2 = new object[1] { System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(184))) };
						text4 = TextStorage.TEXTS.GetText(Class16.smethod_0(1648957934), vars2);
						text = ((text4.Length <= 40) ? string.Empty : Class16.smethod_0(1648979197));
						text4 += text;
						GC.KeepAlive(this);
						text2 = string.Concat(text2, Class16.smethod_0(1648958369) + text4);
					}
					if (System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(188))) > 0)
					{
						vars2 = new object[1] { System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(188))) };
						text4 = TextStorage.TEXTS.GetText(Class16.smethod_0(1648952837), vars2);
						text = ((text4.Length <= 40) ? string.Empty : Class16.smethod_0(1648979197));
						text4 += text;
						GC.KeepAlive(this);
						text2 = string.Concat(text2, Class16.smethod_0(1648958369) + text4);
					}
					text2 += Class16.smethod_0(1648952860);
					if (0 < System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(192))))
					{
						IntPtr intPtr = (IntPtr)System.Runtime.CompilerServices.Unsafe.AsPointer<ACE.Classes.ITEMDATA>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(208)));
						IntPtr intPtr2 = (IntPtr)System.Runtime.CompilerServices.Unsafe.AsPointer<ACE.Classes.ITEMDATA>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(216)));
						IntPtr intPtr3 = (IntPtr)System.Runtime.CompilerServices.Unsafe.AsPointer<ACE.Classes.ITEMDATA>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(217)));
						IntPtr intPtr4 = (IntPtr)System.Runtime.CompilerServices.Unsafe.AsPointer<ACE.Classes.ITEMDATA>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(200)));
						uint num6 = System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, uint>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(192)));
						do
						{
							int num7 = *(int*)(void*)intPtr4;
							if (*(bool*)(void*)intPtr3)
							{
								text4 = Addons.GetAddonNameByID(num7);
							}
							else
							{
								text4 = Addons.GetAddonTitleByID(num7);
								text4 = text4.Replace(Class16.smethod_0(1648923229), string.Empty);
								if (*(bool*)(void*)intPtr2)
								{
									int num8 = num7;
									if (Addons.IsPercentAddon(num8.ToString()))
									{
										float num9 = (float)(*(double*)(void*)intPtr);
										int numAfterDecimal = 2;
										if ((double)num9 < 0.0001)
										{
											numAfterDecimal = 4;
										}
										text = ACE.RSGlobal.RSGlobal.ToPercent(num9, numAfterDecimal);
									}
									else
									{
										double num10 = *(double*)(void*)intPtr;
										text = num10.ToString(Class16.smethod_0(1648922976));
									}
								}
								else
								{
									double num11 = *(double*)(void*)intPtr;
									text = num11.ToString(Class16.smethod_0(1648952888));
								}
								text4 += text;
							}
							text4 = EchoAddon(num7, text4, IsCleanHtml);
							text = ((text4.Length <= 40) ? string.Empty : Class16.smethod_0(1648979197));
							text4 += text;
							GC.KeepAlive(this);
							text2 = string.Concat(text2, Class16.smethod_0(1648958369) + text4);
							intPtr4 += 24;
							intPtr3 += 24;
							intPtr2 += 24;
							intPtr += 24;
							num6--;
						}
						while (num6 != 0);
					}
					text2 += Class16.smethod_0(1648902161);
					break;
				}
				}
				object valueO = GetValueO(ItemPos, Class16.smethod_0(1648965136));
				if (IsShopPrice)
				{
					if (valueO != null)
					{
						System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(1004))) = GetValueI(ItemPos, Class16.smethod_0(1648965136));
						System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(1004))) = CStorage.GetGamePricePW(System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(1004))));
					}
					else
					{
						System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(1004))) = 0;
					}
				}
				if (valueO != null && System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(1004))) > 0)
				{
					int num12 = System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(1004)));
					string text5 = Class16.smethod_0(1648909972);
					text5 = TextStorage.TEXTS.GetText(TextStorage.TEXTS.ResolveLegacyMessageKey(314, 0), num12.ToString(text5));
					text = ((text5.Length <= 40) ? string.Empty : Class16.smethod_0(1648979197));
					text5 += text;
					GC.KeepAlive(this);
					text2 = string.Concat(text2, Class16.smethod_0(1648958369) + text5);
				}
				text2 += Class16.smethod_0(1648952897);
			}
			Desc.body = text2;
			text2 = string.Empty;
			if (!string.IsNullOrWhiteSpace(creator))
			{
				creator = HttpUtility.HtmlEncode(creator);
				string text6 = Class16.smethod_0(1648902161);
				text6 = string.Concat(Class16.smethod_0(1648952914) + TextStorage.TEXTS.GetText(TextStorage.TEXTS.ResolveLegacyMessageKey(315, 0), creator), text6);
				text = ((text6.Length <= 40) ? string.Empty : Class16.smethod_0(1648979197));
				text6 += text;
				GC.KeepAlive(this);
				text2 = string.Concat(text2, Class16.smethod_0(1648958369) + text6);
				Desc.creator = text2;
				text2 = string.Empty;
			}
			if (Game == GAMES.PW)
			{
				bool flag3 = false;
				int int_2 = -1;
				int num13 = this.get_LI(Class16.smethod_0(1648923298));
				int num14 = 0;
				if (0 < GetItemsCount(num13))
				{
					do
					{
						int int_3 = findex(num13, Class16.smethod_0(1648952958));
						int_3 = Lists[num13].GetValueIFast(num14, int_3);
						GC.KeepAlive(this);
						int num15 = int_3;
						num15 = ((int_3 > 12) ? 12 : num15);
						int_3 = 0;
						if (0 < num15)
						{
							do
							{
								int valueIFast = Lists[num13].GetValueIFast(num14, int_3 + 3);
								GC.KeepAlive(this);
								if (valueIFast != *(int*)(&data))
								{
									if (flag3)
									{
										break;
									}
									int_3++;
									continue;
								}
								flag3 = true;
								int_2 = num14;
								break;
							}
							while (int_3 < num15);
						}
						num14++;
					}
					while (num14 < GetItemsCount(num13));
					if (flag3)
					{
						text2 += Class16.smethod_0(1648958369);
						int int_4 = findex(num13, Class16.smethod_0(1648952958));
						int_4 = Lists[num13].GetValueIFast(int_2, int_4);
						GC.KeepAlive(this);
						text2 += Class16.smethod_0(1648952860);
						int num16 = 1;
						string text7;
						if (1 < int_4)
						{
							do
							{
								int num17 = num16;
								text7 = Class16.smethod_0(1648986201);
								text = Class16.smethod_0(1648952975);
								num14 = findex(num13, string.Concat(text + num17, text7));
								num14 = Lists[num13].GetValueIFast(int_2, num14);
								GC.KeepAlive(this);
								if (num14 > 0)
								{
									int num18 = num16 + 1;
									text7 = Class16.smethod_0(1648952989);
									text7 = string.Concat(string.Concat(Class16.smethod_0(1648942889) + num18, text7), EchoAddon(num14, IsCleanHtml));
									text = ((text7.Length <= 40) ? string.Empty : Class16.smethod_0(1648979197));
									text7 += text;
									GC.KeepAlive(this);
									text2 = string.Concat(text2, Class16.smethod_0(1648958369) + text7);
								}
								num16++;
							}
							while (num16 < int_4);
						}
						text2 += Class16.smethod_0(1648902161);
						Color color_ = Color.FromArgb(15917184);
						text7 = GetRealItemName(num13, int_2);
						if (RSCommon.IsTagColorExist(text7))
						{
							color_ = RSCommon.GetTagColor(text7);
							text7 = RSCommon.GetParsedItemName(text7);
						}
						text = Class16.smethod_0(1648952998);
						string text8 = Class16.smethod_0(1648905508);
						text2 = string.Concat(text2, string.Concat(text8 + ACE.RSGlobal.RSGlobal.Color2HTML(color_), text));
						text = Class16.smethod_0(1648942897);
						text8 = Class16.smethod_0(1648953007);
						text7 = string.Concat(string.Concat(string.Concat(string.Concat(text7 + Class16.smethod_0(1648899468), int_4), text8), int_4), text);
						text = ((text7.Length <= 40) ? string.Empty : Class16.smethod_0(1648979197));
						text7 += text;
						GC.KeepAlive(this);
						text2 = string.Concat(text2, Class16.smethod_0(1648958369) + text7);
						text2 += Class16.smethod_0(1648902161);
						num16 = 1;
						if (1 <= int_4)
						{
							do
							{
								int num19 = num16;
								text7 = Class16.smethod_0(1648986201);
								text = Class16.smethod_0(1648953009);
								num14 = findex(num13, string.Concat(text + num19, text7));
								num14 = Lists[num13].GetValueIFast(int_2, num14);
								GC.KeepAlive(this);
								ITEMPOS iTEMPOS = FindItemPos(EquipmentLists, num14);
								if (iTEMPOS != null)
								{
									HTML_HELPER hTML_HELPER2 = new HTML_HELPER();
									hTML_HELPER2.bViewID = false;
									hTML_HELPER2.LinkItem = iTEMPOS;
									hTML_HELPER2.ItemInfo = GetItemInfo(iTEMPOS, bUseCache: true, bCheckIsFreeID: true, bCheckHasReferences: true);
									Color nameColor = Color.FromArgb(6746170);
									hTML_HELPER2.NameColor = nameColor;
									hTML_HELPER2.bDisableLinks = IsCleanHtml;
									text7 = GetRealItemName(iTEMPOS.int_0, iTEMPOS.int_1);
									if (RSCommon.IsTagColorExist(text7))
									{
										Color tagColor = RSCommon.GetTagColor(text7);
										hTML_HELPER2.NameColor = tagColor;
										text7.Substring(7, text7.Length - 7);
									}
									hTML_HELPER2.bNameBold = true;
									if (iTEMPOS == ItemPos)
									{
										hTML_HELPER2.bNameUnderline = true;
									}
									text7 = EchoItem(hTML_HELPER2, bOneLine: true);
									text2 = string.Concat(text2, Class16.smethod_0(1648953027) + text7);
								}
								num16++;
							}
							while (num16 <= int_4);
						}
					}
				}
				Desc.suite = text2;
				text2 = string.Empty;
				if (Version > 12 && System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(1008))) > 0)
				{
					string text9 = Class16.smethod_0(1648928036);
					text = Class16.smethod_0(1648953058);
					string oldValue2 = Class16.smethod_0(1648942920);
					text9 = DecodeMask(60, (ulong)(int)System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, uint>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(1008)))).Replace(oldValue2, text) + text9;
					text9 = HTML_HELPER.EchoTextColored(Color.FromArgb(48, 230, 230), text9);
					text = ((text9.Length <= 40) ? string.Empty : Class16.smethod_0(1648979197));
					text9 += text;
					GC.KeepAlive(this);
					text2 = string.Concat(text2, Class16.smethod_0(1648958369) + text9);
					Desc.proc = text2;
					text2 = string.Empty;
				}
			}
			if (IsDescExist(*(int*)(&data)))
			{
				string desc = Class16.smethod_0(1648958369) + ACE.RSGlobal.RSGlobal.ToHTML(Descriptions.Get(*(int*)(&data)), bCutLine: true);
				Desc.desc = desc;
			}
		}
		if (!IsCleanHtml)
		{
			string text10;
			if (!flag2)
			{
				text10 = ((!flag) ? string.Empty : Class16.smethod_0(1648953072));
				Desc.props = text10 + GenerateHTMLPreview_SetProperties(ItemPos, flag, bUnlimited, Desc.HighlightItem, null);
			}
			byte b = ((ACE.RSGlobal.RSGlobal.CountWords(text2, Class16.smethod_0(1648908417)) > 20) ? ((byte)1) : ((byte)0));
			Desc.refs = GenerateHTMLPreview_References(ItemPos, bManyRefs: false, b != 0, bAddLine: false, bUnlimited);
			Desc.errors = GenerateHTMLPreview_SetErrors(ItemPos, bAddLine: true);
			Desc.duplicates = GenerateHTMLPreview_SetDuplicates(ItemPos, bAddLine: true);
			text10 = Class16.smethod_0(1648958369) + GetHtmlItemImage(itemInfo.IconName, ItemPos.int_0, compact: false);
			Desc.watemark = text10;
		}
		if (Desc.bBuild)
		{
			StringBuilder stringBuilder = new StringBuilder(20480);
			string text11 = ((!IsCleanHtml) ? Class16.smethod_0(1648953126) : Class16.smethod_0(1648953101));
			string text12 = Class16.smethod_0(1648952998);
			stringBuilder.Append(string.Concat(Class16.smethod_0(1648953151) + text11, text12));
			stringBuilder.Append(Desc.head);
			stringBuilder.Append(Desc.body);
			stringBuilder.Append(Desc.creator);
			stringBuilder.Append(Desc.suite);
			stringBuilder.Append(Desc.desc);
			stringBuilder.Append(Desc.proc);
			stringBuilder.Append(Desc.props);
			stringBuilder.Append(Desc.refs);
			stringBuilder.Append(Desc.errors);
			stringBuilder.Append(Desc.duplicates);
			stringBuilder.Append(Desc.watemark);
			stringBuilder.Append(Class16.smethod_0(1648953247));
			text2 = stringBuilder.ToString();
		}
		GC.KeepAlive(this);
		return text2;
	}

	public string GenerateHTMLPreview(ITEMPOS ItemPos, ACE.Classes.ITEMDATA data, string creator)
	{
		DESC_EX dESC_EX = null;
		dESC_EX = new DESC_EX(bBuild: true);
		return GenerateHTMLPreview(ItemPos, data, creator, IsShopPrice: false, IsCleanHtml: false, bUnlimited: false, bViewIcon: false, ref dESC_EX);
	}

	public unsafe string GenerateHTMLPreview(ITEMPOS ItemPos, [MarshalAs(UnmanagedType.U1)] bool IsShopPrice, [MarshalAs(UnmanagedType.U1)] bool IsCleanHtml, [MarshalAs(UnmanagedType.U1)] bool bUnlimited)
	{
		DESC_EX dESC_EX = null;
		string text = null;
		dESC_EX = new DESC_EX(bBuild: true);
		ACE.Classes.ITEMDATA data = default(ACE.Classes.ITEMDATA);
		ACE.RSGlobal.RSGlobal.ITEMDATA(&data);
		text = null;
		GenerateXML(ItemPos, 1, string.Empty, &data, ref text);
		return GenerateHTMLPreview(ItemPos, data, Params.DefaultCreator, IsShopPrice, IsCleanHtml, bUnlimited, IsCleanHtml, ref dESC_EX);
	}

	public string GenerateHTMLPreview(ITEMPOS ItemPos, [MarshalAs(UnmanagedType.U1)] bool IsShopPrice, [MarshalAs(UnmanagedType.U1)] bool IsCleanHtml)
	{
		return GenerateHTMLPreview(ItemPos, IsShopPrice, IsCleanHtml, bUnlimited: false);
	}

	public string GenerateHTMLPreview(ITEMPOS ItemPos, [MarshalAs(UnmanagedType.U1)] bool IsShopPrice)
	{
		return GenerateHTMLPreview(ItemPos, IsShopPrice, IsCleanHtml: false, bUnlimited: false);
	}

	public string GenerateHTMLPreview(ITEMPOS ItemPos)
	{
		return GenerateHTMLPreview(ItemPos, IsShopPrice: false, IsCleanHtml: false, bUnlimited: false);
	}

	public unsafe DESC_EX GetItemHTML(ITEMPOS ItemPos, [MarshalAs(UnmanagedType.U1)] bool IsShopPrice, [MarshalAs(UnmanagedType.U1)] bool bUnlimited, [MarshalAs(UnmanagedType.U1)] bool bOnlyRefines, ITEMPOS HighlightItem)
	{
		DESC_EX dESC_EX = null;
		string text = null;
		dESC_EX = new DESC_EX(bBuild: false);
		dESC_EX.HighlightItem = HighlightItem;
		dESC_EX.bOnlyRefines = bOnlyRefines;
		ACE.Classes.ITEMDATA data = default(ACE.Classes.ITEMDATA);
		ACE.RSGlobal.RSGlobal.ITEMDATA(&data);
		text = null;
		GenerateXML(ItemPos, 1, string.Empty, &data, ref text);
		GenerateHTMLPreview(ItemPos, data, Params.DefaultCreator, IsShopPrice, IsCleanHtml: false, bUnlimited, bViewIcon: false, ref dESC_EX);
		return dESC_EX;
	}

	public unsafe DESC_EX GetItemHTML(ITEMPOS ItemPos, [MarshalAs(UnmanagedType.U1)] bool IsShopPrice, [MarshalAs(UnmanagedType.U1)] bool bUnlimited)
	{
		DESC_EX dESC_EX = null;
		string text = null;
		dESC_EX = new DESC_EX(bBuild: false);
		ACE.Classes.ITEMDATA data = default(ACE.Classes.ITEMDATA);
		ACE.RSGlobal.RSGlobal.ITEMDATA(&data);
		text = null;
		GenerateXML(ItemPos, 1, string.Empty, &data, ref text);
		GenerateHTMLPreview(ItemPos, data, Params.DefaultCreator, IsShopPrice, IsCleanHtml: false, bUnlimited, bViewIcon: false, ref dESC_EX);
		return dESC_EX;
	}

	public string AddLineSmart(string line, ref DESC_EX Desc, ref string LatestLine, [MarshalAs(UnmanagedType.U1)] bool IsRefinedProps)
	{
		LatestLine = line;
		string text = ((line.Length <= 40) ? string.Empty : Class16.smethod_0(1648979197));
		LatestLine += text;
		GC.KeepAlive(this);
		return LatestLine;
	}

	public string GenerateHTMLPreview_SetErrors(ITEMPOS ItemPos, [MarshalAs(UnmanagedType.U1)] bool bAddLine)
	{
		string text = null;
		List<string> details = null;
		if (CheckItemErrors(ItemPos, bFast: false, ref details))
		{
			if (bAddLine)
			{
				text += Class16.smethod_0(1648958369);
			}
			object[] vars = new object[1] { details.Count };
			Color red = Color.Red;
			string text2 = TextStorage.TEXTS.GetText(Class16.smethod_0(1648953262), vars);
			text += HTML_HELPER.EchoTextColored(red, bBold: true, text2);
			string text3 = Class16.smethod_0(1648902317) + string.Join(Class16.smethod_0(1648953285), details);
			Color red2 = Color.Red;
			text = string.Concat(text, Class16.smethod_0(1648958369) + HTML_HELPER.EchoTextColored(red2, bBold: false, text3));
		}
		GC.KeepAlive(this);
		return text;
	}

	public string GenerateHTMLPreview_SetDuplicates(ITEMPOS ItemPos, [MarshalAs(UnmanagedType.U1)] bool bAddLine)
	{
		if (CommonStorage.AParams.HintIdDuplicatesLimit < 1)
		{
			CommonStorage.AParams.HintIdDuplicatesLimit = 1;
		}
		string text = null;
		int num = getid(ItemPos);
		List<vITEMPOS> idDublicates = GetIdDublicates(ItemPos.int_0, ItemPos.int_1, num, bInAllLists: false);
		if (idDublicates != null)
		{
			object[] vars = new object[1] { idDublicates.Count };
			Color red = Color.Red;
			string text2 = TextStorage.TEXTS.GetText(Class16.smethod_0(1648953310), vars);
			string title = HTML_HELPER.EchoTextColored(red, text2);
			bool bMany = false;
			if (idDublicates.Count > CommonStorage.AParams.HintIdDuplicatesLimit)
			{
				int count = idDublicates.Count - CommonStorage.AParams.HintIdDuplicatesLimit;
				idDublicates.RemoveRange(CommonStorage.AParams.HintIdDuplicatesLimit, count);
				bMany = true;
			}
			if (bAddLine)
			{
				text += Class16.smethod_0(1648958369);
			}
			Color red2 = Color.Red;
			text += GenerateItemListHtml(idDublicates, title, null, bMany, bMargin: true, bViewList: true, new HighlightInfo(num, red2), null);
		}
		GC.KeepAlive(this);
		return text;
	}

	public unsafe string GenerateHTMLPreview_SetProperties(ITEMPOS ItemPos, [MarshalAs(UnmanagedType.U1)] bool IsMatter, [MarshalAs(UnmanagedType.U1)] bool bUnlimited, ITEMPOS HighlightItem, int[] CustomFields)
	{
		object obj = null;
		string text = null;
		string text2 = null;
		string text3 = null;
		string empty = string.Empty;
		HashSet<string> hashSet = new HashSet<string>();
		int num;
		if (bUnlimited)
		{
			num = 9999;
		}
		else
		{
			num = Params.ToolTipFieldsNumLimit;
			if (num == 0)
			{
				return string.Empty;
			}
		}
		int int_ = ItemPos.int_0;
		int int_2 = ItemPos.int_1;
		if (FieldCategories == null)
		{
			MakeFieldCategories();
		}
		empty += Class16.smethod_0(1648953333);
		int num2 = 0;
		List<string> hintFields = Lists[int_].HintFields;
		int num3 = GetFieldsCount(ItemPos.int_0);
		int num4 = 0;
		if (CustomFields != null)
		{
			num3 = CustomFields.Length;
			num4 = -1;
		}
		else if (hintFields != null)
		{
			num3 = hintFields.Count;
			num4 = -1;
		}
		bool flag = IsListWithPages(ItemPos.int_0);
		if (0 < num)
		{
			int num6 = default(int);
			FIELDTYPE fIELDTYPE = default(FIELDTYPE);
			do
			{
				num4++;
				int num5 = num4;
				if (num4 >= num3)
				{
					break;
				}
				string text4;
				if (CustomFields != null)
				{
					num5 = CustomFields[num4];
					text4 = Lists[int_].elementFields[num5];
					goto IL_0163;
				}
				if (hintFields != null)
				{
					text4 = hintFields[num4];
					num5 = Lists[int_].get_fields(text4);
					if (num5 != -1)
					{
						goto IL_0163;
					}
				}
				else if (num4 >= 5 || num4 != Lists[ItemPos.int_0].NameFieldIndex)
				{
					text4 = Lists[int_].elementFields[num4];
					string[] hintExcludedFields = HintExcludedFields;
					if (hintExcludedFields == null || hintExcludedFields.Length == 0 || Array.IndexOf(hintExcludedFields, text4) <= -1)
					{
						goto IL_0163;
					}
				}
				continue;
				IL_031b:
				string text5 = GetValue(ItemPos.int_0, ItemPos.int_1, num5);
				goto IL_032f;
				IL_032f:
				Color nameColor = Color.White;
				Image image = null;
				obj = null;
				text = null;
				text2 = null;
				FIELDTYPE fieldType;
				if (fieldType >= FIELDTYPE.matters || fieldType == FIELDTYPE.refine_addon_pw || fieldType == FIELDTYPE.equip_addon || fieldType == FIELDTYPE.ft_quest)
				{
					FIELDPOS fieldPos = new FIELDPOS(int_, int_2, num5);
					if (TryGetRefExtraVal(fieldPos, ref obj, ref text, ref text2, &num6, &fIELDTYPE))
					{
						num4++;
						if (fIELDTYPE != FIELDTYPE.ft_prob)
						{
							text = ((!(text != Class16.smethod_0(1648924112))) ? null : string.Concat(text2 + Class16.smethod_0(1648942211), text));
						}
					}
				}
				bool flag2;
				if (!flag2 && text5 == Class16.smethod_0(1648924112))
				{
					continue;
				}
				if (IsProbFieldStrict(int_, num5))
				{
					PROB_ONE_FIELD_SET suiteByProb = GetSuiteByProb(ItemPos, num5);
					if (suiteByProb != null && suiteByProb.Fields.IsSomeFieldsPresent() && !suiteByProb.Values.IsSomeValuesPresent())
					{
						continue;
					}
				}
				text5 = DecodeValue(ItemPos.int_0, num5, ItemPos.int_1, text5);
				if (!flag2 && text5 != null)
				{
					switch (text5.Length)
					{
					case 1:
						if (!(text5 == Class16.smethod_0(1648924112)))
						{
							break;
						}
						continue;
					case 2:
						switch (text5[1])
						{
						case 'o':
							if (!(text5 == Class16.smethod_0(1648908427)))
							{
								break;
							}
							continue;
						case '0':
							if (!(text5 == Class16.smethod_0(1648978986)))
							{
								break;
							}
							continue;
						case '%':
							if (!(text5 == Class16.smethod_0(1648919583)))
							{
								break;
							}
							continue;
						}
						break;
					case 3:
						if (!(text5 == Class16.smethod_0(1648924410)))
						{
							break;
						}
						continue;
					case 4:
						if (!(text5 == Class16.smethod_0(1648924120)))
						{
							break;
						}
						continue;
					case 0:
						continue;
					}
				}
				ITEMINFO iTEMINFO = null;
				bool flag3 = false;
				if (fieldType > FIELDTYPE.none)
				{
					nameColor = Color.FromArgb(225, 255, 225);
					if (fieldType < FIELDTYPE.matters && fieldType != FIELDTYPE.equip_addon)
					{
						switch (fieldType)
						{
						case FIELDTYPE.ft_hex_color:
						{
							byte[] array = (byte[])Lists[int_].elementValues[int_2][num5];
							if (array[0] != 0 || array[1] != 0 || array[2] != 0 || array[3] != 0)
							{
								Color color = Color.FromArgb(ACE.RSGlobal.RSGlobal.Bgab2Argb(array).ToArgb());
								image = ACE.RSGlobal.RSGlobal.GenerateImage(16, 16, color);
							}
							break;
						}
						case FIELDTYPE.ft_quest:
							if (Tasks != null)
							{
								int valueIFast = Lists[int_].GetValueIFast(int_2, num5);
								GC.KeepAlive(this);
								QUEST_INFO questInfo = Tasks.GetQuestInfo(valueIFast);
								if (questInfo != null)
								{
									valueIFast = Params.FieldHeight;
									Bitmap image2 = (Bitmap)questInfo.image;
									int num7 = valueIFast;
									image = ICONS.ResizeImage(image2, num7, num7);
									nameColor = questInfo.color;
								}
							}
							break;
						}
					}
					else
					{
						flag3 = true;
						ITEMPOS iTEMPOS = FindItemPos(new ITEMPOS(int_, int_2), num5);
						if (iTEMPOS != null)
						{
							iTEMINFO = GetItemInfo(iTEMPOS, bUseCache: true, bCheckIsFreeID: true, bCheckHasReferences: true);
							if (Params.ShowIcons)
							{
								ICONS icons = Icons;
								if (icons.Icons != null)
								{
									nameColor = iTEMINFO.color;
									string iconName = iTEMINFO.IconName;
									if (iconName != null)
									{
										image = icons.GetIcon(iconName, Lists[iTEMPOS.int_0].IsTgaIcon, 16);
									}
								}
							}
						}
					}
					if (image != null)
					{
						string text6 = Class16.smethod_0(1648904718);
						if (image.Tag as string == text6)
						{
							image = null;
						}
					}
				}
				string text7;
				if (text7 == Class16.smethod_0(1648902744))
				{
					nameColor = Color.FromArgb(255, 255, 230);
				}
				else if (text7.Contains(Class16.smethod_0(1648902792)))
				{
					nameColor = Color.FromArgb(135, 206, 250);
				}
				bool flag4 = false;
				if (text5.Length > 50)
				{
					text5 = ACE.RSGlobal.RSGlobal.CutString(text5, 50);
				}
				if (text7.Contains(Class16.smethod_0(1648902778)) && text5.Contains(Class16.smethod_0(1648935659)))
				{
					nameColor = Color.White;
					text5 = ACE.RSGlobal.RSGlobal.ToHTML(text5, bCutLine: false);
					flag4 = true;
				}
				bool flag5;
				string text8;
				if (flag5)
				{
					empty = string.Concat(empty, Class16.smethod_0(1648942627) + text5);
				}
				else
				{
					text8 += Class16.smethod_0(1648924402);
					string text9;
					string text10;
					if (flag)
					{
						if (fieldType == FIELDTYPE.matters || fieldType == FIELDTYPE.custom_list)
						{
							text8 = string.Empty;
						}
					}
					else
					{
						text3 = null;
						if (ACE.RSGlobal.RSGlobal.IsStringEqualWithRegexList(text4, HintItemListFields.ToList().ToArray(), ref text3))
						{
							text8 = string.Empty;
							if (FieldCategories.ContainsKey(text3) && !hashSet.Contains(text3))
							{
								text9 = Class16.smethod_0(1648924402);
								Dictionary<string, string> fieldCategories = FieldCategories;
								text10 = Class16.smethod_0(1648958369);
								empty = string.Concat(empty, text10 + EchoFieldName(fieldCategories[text3] + text9, new FIELDPOS(ItemPos, num5)));
								hashSet.Add(text3);
							}
						}
					}
					FIELDPOS fp = new FIELDPOS(ItemPos, num5);
					text9 = Class16.smethod_0(1648942211);
					text10 = Class16.smethod_0(1648958369);
					empty = string.Concat(empty, string.Concat(text10 + EchoFieldName(text8, fp), text9));
					HTML_HELPER hTML_HELPER = new HTML_HELPER();
					int num8 = ((flag3 && text8 == string.Empty) ? 1 : 0);
					hTML_HELPER.bViewID = (byte)num8 != 0;
					hTML_HELPER.icon = image;
					if (iTEMINFO != null)
					{
						hTML_HELPER.bIconNecessarily = true;
						hTML_HELPER.ItemInfo = iTEMINFO;
						hTML_HELPER.LinkItem = iTEMINFO.pos;
						hTML_HELPER.bViewIcon = IsIconsExist(iTEMINFO.pos.int_0);
						hTML_HELPER.bNameUnderline = iTEMINFO.pos == HighlightItem;
					}
					else if (fieldType == FIELDTYPE.ft_quest)
					{
						int int_3 = ItemPos.int_0;
						int_3 = Lists[int_3].GetValueIFast(int_2, num5);
						GC.KeepAlive(this);
						hTML_HELPER.LinkTaskID = int_3;
					}
					else
					{
						hTML_HELPER.bViewIcon = false;
						if (flag3)
						{
							int int_4 = ItemPos.int_0;
							int_4 = Lists[int_4].GetValueIFast(int_2, num5);
							GC.KeepAlive(this);
							hTML_HELPER.ID = int_4;
							Color red = Color.Red;
							hTML_HELPER.IDColor = red;
							Color red2 = Color.Red;
							hTML_HELPER.NameColor = red2;
						}
					}
					num8 = ((!flag4) ? 1 : 0);
					hTML_HELPER.bHtmlEncode = (byte)num8 != 0;
					hTML_HELPER.Name = text5;
					hTML_HELPER.NameColor = nameColor;
					hTML_HELPER.extra1 = text;
					string text11 = EchoItem(hTML_HELPER, bOneLine: true);
					empty += text11;
				}
				num2++;
				continue;
				IL_01b6:
				int num9;
				flag2 = (byte)num9 != 0;
				num9 = ((text4.EndsWith(Class16.smethod_0(1648961970)) && Lists[int_].elementFields[num5 - 1].EndsWith(Class16.smethod_0(1648962007))) ? 1 : 0);
				flag5 = (byte)num9 != 0;
				text8 = GetFieldName(ItemPos.int_0, num5);
				if (text8 == Class16.smethod_0(1648966655))
				{
					continue;
				}
				if (flag2)
				{
					text8 = text8.Replace(Class16.smethod_0(1648952349), string.Empty);
				}
				text7 = Lists[int_].elementTypes[num5];
				fieldType = GetFieldType(ItemPos.int_0, ItemPos.int_1, num5);
				if ((CustomFields == null && (text7.StartsWith(Class16.smethod_0(1648985317)) || fieldType == FIELDTYPE.ft_path_data || fieldType == FIELDTYPE.file_icon_tga || fieldType == FIELDTYPE.file_model)) || (IsMatter && CustomFields == null && (fieldType == FIELDTYPE.proc_type || text4.EndsWith(Class16.smethod_0(1648952354)))))
				{
					continue;
				}
				if (num5 <= -1)
				{
					goto IL_031b;
				}
				ACE.Elements.eList.eList eList2 = Lists[int_];
				FIELD_DATA_TYPE_ENUM data_type = eList2.FieldDataTypes[num5].data_type;
				FIELD_DATA_TYPE_ENUM fIELD_DATA_TYPE_ENUM = data_type;
				if (fIELD_DATA_TYPE_ENUM != FIELD_DATA_TYPE_ENUM.Float)
				{
					FIELD_DATA_TYPE_ENUM fIELD_DATA_TYPE_ENUM2 = data_type;
					if (fIELD_DATA_TYPE_ENUM2 != FIELD_DATA_TYPE_ENUM.Double)
					{
						goto IL_031b;
					}
				}
				double valueD = eList2.GetValueD(int_2, num5);
				GC.KeepAlive(this);
				text5 = Math.Round(valueD, 3).ToString();
				goto IL_032f;
				IL_0163:
				if (text4.EndsWith(Class16.smethod_0(1648962007)))
				{
					ACE.Elements.eList.eList eList3 = Lists[int_];
					if (num5 < (nint)eList3.elementTypes.LongLength - 1 && eList3.elementFields[num5 + 1].EndsWith(Class16.smethod_0(1648961970)))
					{
						num9 = 1;
						goto IL_01b6;
					}
				}
				num9 = 0;
				goto IL_01b6;
			}
			while (num2 < num);
			if (num2 > 0)
			{
				empty += Class16.smethod_0(1648902161);
				goto IL_09ff;
			}
		}
		empty = string.Empty;
		goto IL_09ff;
		IL_09ff:
		GC.KeepAlive(this);
		return empty;
	}

	public string GenerateHTMLPreview_SetProperties(ITEMPOS ItemPos, int[] CustomFields)
	{
		int int_ = ItemPos.int_0;
		bool isMatter = MattersListsFast != null && MattersListsFast.Contains(int_);
		GC.KeepAlive(this);
		return GenerateHTMLPreview_SetProperties(ItemPos, isMatter, bUnlimited: false, null, CustomFields);
	}

	public string EchoFieldName(string FieldName, FIELDPOS fp)
	{
		string text = Class16.smethod_0(1648902161);
		string result = EchoLink(fp, string.Concat(Class16.smethod_0(1648952373) + FieldName, text));
		GC.KeepAlive(this);
		return result;
	}

	public string EchoLink(FIELDPOS fp, string text)
	{
		string text2 = Class16.smethod_0(1648952428);
		string result = string.Concat(string.Format(Class16.smethod_0(1648952439), fp.int_0, fp.int_1, fp.int_2) + text, text2);
		GC.KeepAlive(this);
		return result;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsMattersList(int int_0)
	{
		bool result = MattersListsFast != null && MattersListsFast.Contains(int_0);
		GC.KeepAlive(this);
		return result;
	}

	public void CreateFirst2IDsFile()
	{
		string text = Class16.smethod_0(1648952480);
		string gamePrefix = GamePrefix;
		string text2 = Class16.smethod_0(1648952491);
		StreamWriter streamWriter = new StreamWriter(string.Concat(string.Concat(Application.StartupPath + text2, gamePrefix), text), append: false, Encoding.ASCII);
		streamWriter.WriteLine(Lists.Length);
		int num = 0;
		if (0 < (nint)Lists.LongLength)
		{
			do
			{
				if (num == ConversationListIndex)
				{
					streamWriter.WriteLine(string.Empty);
				}
				else
				{
					int num2 = -1;
					int num3 = -1;
					if (GetItemsCount(num) > 1)
					{
						int num4 = Lists[num].getid(0);
						GC.KeepAlive(this);
						num2 = num4;
						int num5 = Lists[num].getid(1);
						GC.KeepAlive(this);
						num3 = num5;
					}
					else if (GetItemsCount(num) == 1)
					{
						int num6 = Lists[num].getid(0);
						GC.KeepAlive(this);
						num2 = num6;
					}
					string text3 = Class16.smethod_0(1648908627);
					string text4 = Class16.smethod_0(1648905535);
					streamWriter.WriteLine(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(num + text3, num2), text4), num3), text3), GetItemsCount(num)));
				}
				num++;
			}
			while (num < (nint)Lists.LongLength);
		}
		streamWriter.Close();
		GC.KeepAlive(this);
	}

	public void LoadFirst2IDs()
	{
		string text = Class16.smethod_0(1648952480);
		string gamePrefix = GamePrefix;
		string text2 = Class16.smethod_0(1648952491);
		string path = string.Concat(string.Concat(Application.StartupPath + text2, gamePrefix), text);
		if (!File.Exists(path))
		{
			GC.KeepAlive(this);
			return;
		}
		first2IDs = new ID_2[0];
		try
		{
			using StreamReader streamReader = new StreamReader(path, Encoding.ASCII);
			first2IDs = new ID_2[ACE.RSGlobal.RSGlobal.UIntParseFast(streamReader.ReadLine())];
			int num = 0;
			string text3 = streamReader.ReadLine();
			while (text3 != null && num < first2IDs.Length)
			{
				if (text3 != string.Empty)
				{
					first2IDs[num].Init();
					string[] array = text3.Split('=');
					if (array.Length >= 2)
					{
						string[] array2 = array[1].Split(new char[1] { '|' });
						if (array2.Length >= 2 && int.TryParse(array2[0], out int id1) && int.TryParse(array2[1], out int id2))
						{
							first2IDs[num].id1 = id1;
							first2IDs[num].id2 = id2;
							if ((nint)array.LongLength > 2)
							{
								first2IDs[num].item_count = ACE.RSGlobal.RSGlobal.UIntParseFast(array[2]);
							}
							else
							{
								first2IDs[num].item_count = -1;
							}
						}
					}
				}
				num++;
				text3 = streamReader.ReadLine();
			}
		}
		catch
		{
		}
	}

	public unsafe string GetIconPath(int int_0, int int_1, int int_2)
	{
		if (int_2 < 0)
		{
			return null;
		}
		string result = null;
		if (Game == GAMES.PW)
		{
			result = GetValue(int_0, int_1, int_2);
		}
		else
		{
			PATH_DATA pathData = PathData;
			if (pathData != null && pathData.Paths != null)
			{
				int valueIFast = Lists[int_0].GetValueIFast(int_1, int_2);
				GC.KeepAlive(this);
				bool flag = default(bool);
				result = PathData.GetPath((uint)valueIFast, &flag);
			}
		}
		GC.KeepAlive(this);
		return result;
	}

	public string GetIconPath(ITEMPOS ip)
	{
		int int_ = ip.int_0;
		return GetIconPath(int_, ip.int_1, Lists[int_].IconFieldIndex);
	}

	public string GetIconPath(int int_0, int int_1)
	{
		return GetIconPath(int_0, int_1, Lists[int_0].IconFieldIndex);
	}

	public unsafe string GetFilePath(int int_0, int int_1, int int_2)
	{
		bool flag = default(bool);
		return GetFilePath(int_0, int_1, int_2, &flag);
	}

	public unsafe string GetFilePath(int int_0, int int_1, int int_2, bool* path_found)
	{
		if (int_2 < 0)
		{
			return null;
		}
		string result = string.Empty;
		if (Game == GAMES.PW)
		{
			result = GetValue(int_0, int_1, int_2);
			*path_found = true;
		}
		else
		{
			PATH_DATA pathData = PathData;
			if (pathData != null && pathData.Paths != null)
			{
				int valueIFast = Lists[int_0].GetValueIFast(int_1, int_2);
				GC.KeepAlive(this);
				result = PathData.GetPath((uint)valueIFast, path_found);
			}
		}
		GC.KeepAlive(this);
		return result;
	}

	public string GetIconName(ITEMPOS ip, int int_0, [MarshalAs(UnmanagedType.U1)] bool bStrict, ref bool isTga)
	{
		int int_1 = ip.int_0;
		if (int_1 < 0)
		{
			return null;
		}
		int num = int_1;
		int int_2 = ip.int_1;
		string uListName = Lists[int_1].uListName;
		ITEMPOS iTEMPOS;
		if (!bStrict && Game == GAMES.PW)
		{
			iTEMPOS = null;
			if (uListName == Class16.smethod_0(1648963535) && (int_0 == -1 || string.IsNullOrWhiteSpace(GetValue(ip.int_0, ip.int_1, int_0))))
			{
				float num2 = 0f;
				int num3 = 0;
				int num4 = 1;
				do
				{
					string text = Class16.smethod_0(1648986201);
					int num5 = Lists[ip.int_0].get_fields(string.Concat(Class16.smethod_0(1648970216) + num4, text));
					string text2 = Class16.smethod_0(1648986239);
					int fieldIndex = Lists[ip.int_0].get_fields(string.Concat(Class16.smethod_0(1648970216) + num4, text2));
					int valueIFast = Lists[num].GetValueIFast(int_2, num5);
					GC.KeepAlive(this);
					float valueF = Lists[num].GetValueF(int_2, fieldIndex);
					GC.KeepAlive(this);
					if (valueIFast > 0 && (double)valueF > (double)num2)
					{
						num3 = num5;
						num2 = valueF;
					}
					num4++;
				}
				while (num4 <= 16);
				if (num3 > 0)
				{
					iTEMPOS = FindItemPos(ip, num3);
				}
				goto IL_0566;
			}
			if (uListName != null)
			{
				switch (uListName.Length)
				{
				case 11:
					break;
				case 13:
					goto IL_0252;
				case 14:
					goto IL_028b;
				case 15:
					goto IL_02c4;
				case 16:
					goto IL_03db;
				case 19:
					goto IL_0462;
				default:
					goto IL_0498;
				}
				if (uListName == Class16.smethod_0(1648960167))
				{
					iTEMPOS = FindItemPos(ip, Lists[num].get_fields(Class16.smethod_0(1648952630)));
					if (iTEMPOS == null)
					{
						iTEMPOS = FindItemPos(ip, Lists[num].get_fields(Class16.smethod_0(1648952652)));
						if (iTEMPOS == null)
						{
							if (Version >= 60)
							{
								iTEMPOS = FindItemPos(ip, Lists[num].get_fields(Class16.smethod_0(1648952666)));
							}
							goto IL_0566;
						}
					}
					goto IL_056f;
				}
			}
			goto IL_0498;
		}
		goto IL_057f;
		IL_03db:
		char c = uListName[4];
		if (c != 'M')
		{
			if (c != 'S' || !(uListName == Class16.smethod_0(1648952504)))
			{
				goto IL_0498;
			}
			iTEMPOS = FindItemPos(ip, Lists[num].get_fields(Class16.smethod_0(1648952605)));
		}
		else
		{
			if (!(uListName == Class16.smethod_0(1648952535)))
			{
				goto IL_0498;
			}
			iTEMPOS = FindItemPos(ip, Lists[num].get_fields(Class16.smethod_0(1648951917)));
		}
		goto IL_0566;
		IL_0462:
		if (!(uListName == Class16.smethod_0(1648952571)))
		{
			goto IL_0498;
		}
		iTEMPOS = FindItemPos(ip, Lists[num].get_fields(Class16.smethod_0(1648951890)));
		goto IL_0566;
		IL_0252:
		if (!(uListName == Class16.smethod_0(1648923298)))
		{
			goto IL_0498;
		}
		iTEMPOS = FindItemPos(ip, Lists[num].get_fields(Class16.smethod_0(1648951961)));
		goto IL_0566;
		IL_028b:
		if (!(uListName == Class16.smethod_0(1648952558)))
		{
			goto IL_0498;
		}
		iTEMPOS = FindItemPos(ip, Lists[num].get_fields(Class16.smethod_0(1648951942)));
		goto IL_0566;
		IL_02c4:
		if (!(uListName == Class16.smethod_0(1648963546)))
		{
			goto IL_0498;
		}
		float num6 = 0f;
		int num7 = 0;
		int num8 = 1;
		do
		{
			string text3 = Class16.smethod_0(1648986201);
			int num9 = Lists[ip.int_0].get_fields(string.Concat(Class16.smethod_0(1648986211) + num8, text3));
			string text4 = Class16.smethod_0(1648986239);
			int fieldIndex2 = Lists[ip.int_0].get_fields(string.Concat(Class16.smethod_0(1648986211) + num8, text4));
			int valueIFast2 = Lists[num].GetValueIFast(int_2, num9);
			GC.KeepAlive(this);
			float valueF2 = Lists[num].GetValueF(int_2, fieldIndex2);
			GC.KeepAlive(this);
			if (valueIFast2 > 0 && (double)valueF2 > (double)num6)
			{
				num7 = num9;
				num6 = valueF2;
			}
			num8++;
		}
		while (num8 <= 32);
		if (num7 > 0)
		{
			iTEMPOS = FindItemPos(ip, num7);
		}
		goto IL_0566;
		IL_0498:
		string text5 = Class16.smethod_0(1648952704);
		string text6 = Class16.smethod_0(1648952757);
		int num10 = ((uListName == Class16.smethod_0(1648952781) || uListName == text6 || uListName == text5) ? 1 : 0);
		if ((byte)num10 != 0)
		{
			iTEMPOS = FindItemPos(ip, Lists[num].get_fields(Class16.smethod_0(1648952813)));
		}
		else if (uListName == Class16.smethod_0(1648952829))
		{
			iTEMPOS = FindItemPos(ip, Lists[num].get_fields(Class16.smethod_0(1648951842)));
		}
		else if (uListName == Class16.smethod_0(1648955663))
		{
			iTEMPOS = FindItemPos(ip, Lists[num].get_fields(Class16.smethod_0(1648951885)));
		}
		goto IL_0566;
		IL_056f:
		GC.KeepAlive(this);
		return GetIconName(iTEMPOS, ref isTga);
		IL_0566:
		if (iTEMPOS != null)
		{
			goto IL_056f;
		}
		goto IL_057f;
		IL_057f:
		string text7 = null;
		if (num > -1 && int_0 > 0)
		{
			text7 = GetIconPath(num, int_2, int_0);
			if (text7 != null)
			{
				FIELDTYPE fieldType = GetFieldType(num, int_2, int_0);
				if (fieldType != FIELDTYPE.file_icon && fieldType != FIELDTYPE.file_icon_pet)
				{
					isTga = true;
				}
				else
				{
					if (text7.Contains(Class16.smethod_0(1648892117)))
					{
						text7 = text7.Replace('/', '\\');
					}
					if (text7.Contains(Class16.smethod_0(1648927580)))
					{
						string text8 = text7;
						text7 = text8.Substring(text8.LastIndexOf(Class16.smethod_0(1648927580)) + 1);
					}
				}
				text7 = text7.ToLowerInvariant();
			}
		}
		else if (!bStrict)
		{
			string text9 = TryGetIconByFields(ip, ref isTga);
			if (text9 == null)
			{
				text9 = TryGetIconByReferences(ip, ref isTga);
				if (text9 == null)
				{
					if (uListName == Class16.smethod_0(1648963546))
					{
						text9 = Class16.smethod_0(1648904769);
					}
					else if (uListName == Class16.smethod_0(1648960167))
					{
						text9 = Class16.smethod_0(1648904785);
					}
					else if (uListName.EndsWith(Class16.smethod_0(1648952691)))
					{
						text9 = Class16.smethod_0(1648904805);
					}
				}
			}
			text7 = text9;
		}
		GC.KeepAlive(this);
		return text7;
	}

	public string GetIconName(ITEMPOS ip, ref bool isTga)
	{
		int iconFieldIndex = Lists[ip.int_0].IconFieldIndex;
		string iconName = GetIconName(ip, iconFieldIndex, bStrict: false, ref isTga);
		if (iconFieldIndex > 0 && string.IsNullOrWhiteSpace(iconName))
		{
			int num = iconFieldIndex + 1;
			int int_ = ip.int_0;
			if (num < (nint)Lists[int_].elementTypes.LongLength)
			{
				do
				{
					FIELDTYPE fieldType = GetFieldType(int_, ip.int_1, num);
					if (fieldType == FIELDTYPE.file_icon || fieldType == FIELDTYPE.file_icon_tga)
					{
						iconName = GetIconName(ip, num, bStrict: false, ref isTga);
						if (!string.IsNullOrWhiteSpace(iconName))
						{
							break;
						}
					}
					num++;
					int_ = ip.int_0;
				}
				while (num < (nint)Lists[int_].elementTypes.LongLength);
			}
		}
		GC.KeepAlive(this);
		return iconName;
	}

	public string GetIconName(int int_0, int int_1, ref bool isTga)
	{
		int iconFieldIndex = Lists[int_0].IconFieldIndex;
		return GetIconName(new ITEMPOS(int_0, int_1), iconFieldIndex, bStrict: false, ref isTga);
	}

	public string GetIconNameStrict(ITEMPOS ip, int int_0)
	{
		bool isTga = false;
		return GetIconName(ip, int_0, bStrict: true, ref isTga);
	}

	public string GetIconNameStrict(ITEMPOS ip)
	{
		int iconFieldIndex = Lists[ip.int_0].IconFieldIndex;
		bool isTga = false;
		return GetIconName(ip, iconFieldIndex, bStrict: true, ref isTga);
	}

	public string GetIconNameStrict(int int_0, int int_1)
	{
		int iconFieldIndex = Lists[int_0].IconFieldIndex;
		ITEMPOS ip = new ITEMPOS(int_0, int_1);
		bool isTga = false;
		return GetIconName(ip, iconFieldIndex, bStrict: true, ref isTga);
	}

	public string TryGetIconByFields(ITEMPOS ItemPos, ref bool isTga)
	{
		if (ACE.RSGlobal.RSGlobal.AntiRecurse_TryGetIconByFields_eListCollection)
		{
			return null;
		}
		ACE.RSGlobal.RSGlobal.AntiRecurse_TryGetIconByFields_eListCollection = true;
		try
		{
			string result = null;
			ACE.Elements.eList.eList eList2 = Lists[ItemPos.int_0];
			ACE.Elements.eList.eList eList3 = eList2;
			int num = eList3.elementTypes.Length;
			int num2 = 2;
			if (Game == GAMES.PW)
			{
				if (eList2.uListName == Class16.smethod_0(1648960167))
				{
					num2 = 8;
				}
				else if (Lists[ItemPos.int_0].uListName == Class16.smethod_0(1648963546))
				{
					GC.KeepAlive(this);
					return null;
				}
			}
			int num3 = num2;
			if (num2 < num)
			{
				do
				{
					if (eList3.fieldtypes[num3] >= FIELDTYPE.matters)
					{
						ITEMPOS iTEMPOS = FindItemPos(ItemPos, num3);
						if (iTEMPOS != null && IsIconsExist(iTEMPOS.int_0))
						{
							result = GetIconName(iTEMPOS, ref isTga);
							break;
						}
					}
					num3++;
				}
				while (num3 < num);
			}
			return result;
		}
		finally
		{
			ACE.RSGlobal.RSGlobal.AntiRecurse_TryGetIconByFields_eListCollection = false;
		}
	}

	public string TryGetIconByReferences(ITEMPOS ItemPos, ref bool isTga)
	{
		List<ELEMENTS_REFERENCES_SUITE> list = null;
		if (ACE.RSGlobal.RSGlobal.AntiRecurse_TryGetIconByReferences_eListCollection)
		{
			return null;
		}
		if (Lists[ItemPos.int_0].uListName == Class16.smethod_0(1648963546))
		{
			GC.KeepAlive(this);
			return null;
		}
		ACE.RSGlobal.RSGlobal.AntiRecurse_TryGetIconByReferences_eListCollection = true;
		try
		{
			string text = null;
			list = null;
			if (GetReferencesFast(ref list, ItemPos, bOnlyElements: true))
			{
				int num = 0;
				if (0 < list.Count)
				{
					do
					{
						ELEMENTS_REFERENCES_SUITE eLEMENTS_REFERENCES_SUITE = list[num];
						if (!IsIconsExist(eLEMENTS_REFERENCES_SUITE.ListIndex))
						{
							goto IL_005f;
						}
						eLEMENTS_REFERENCES_SUITE.InitEnumerator(50);
						REFERENCE_ENTRY next = eLEMENTS_REFERENCES_SUITE.GetNext();
						if (next != null)
						{
							while (true)
							{
								int int_ = next.FieldPos.int_1;
								ITEMPOS ip = new ITEMPOS(next.FieldPos.int_0, int_);
								if (IsItemExist(ip))
								{
									text = GetIconName(ip, ref isTga);
								}
								if (text != null)
								{
									break;
								}
								next = eLEMENTS_REFERENCES_SUITE.GetNext();
								if (next != null)
								{
									continue;
								}
								goto IL_00d0;
							}
							break;
						}
						goto IL_00d0;
						IL_00d0:
						if (text != null)
						{
							break;
						}
						goto IL_005f;
						IL_005f:
						num++;
					}
					while (num < list.Count);
				}
			}
			return text;
		}
		finally
		{
			ACE.RSGlobal.RSGlobal.AntiRecurse_TryGetIconByReferences_eListCollection = false;
		}
	}

	public string DecodeMask(int ftype, ulong mask)
	{
		if (Game == GAMES.PW)
		{
			if (ftype != 61)
			{
				if (ftype != 68)
				{
					if (ftype == 81)
					{
						if (mask == 0L)
						{
							string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1648951991));
							GC.KeepAlive(this);
							return text;
						}
						goto IL_0182;
					}
				}
				else if (Version <= 12)
				{
					if (mask > 131071L)
					{
						string text2 = TextStorage.TEXTS.GetText(Class16.smethod_0(1648908687));
						GC.KeepAlive(this);
						return text2;
					}
				}
				else if (mask == 4294967295L)
				{
					string text3 = TextStorage.TEXTS.GetText(Class16.smethod_0(1648952014));
					GC.KeepAlive(this);
					return text3;
				}
			}
			else
			{
				if (mask == 0L)
				{
					string text4 = TextStorage.TEXTS.GetText(Class16.smethod_0(1648952036));
					GC.KeepAlive(this);
					return text4;
				}
				if (Version <= 12 && mask == 32895L)
				{
					string text5 = TextStorage.TEXTS.GetText(Class16.smethod_0(1648952049));
					GC.KeepAlive(this);
					return text5;
				}
			}
		}
		if (mask == 0L)
		{
			string text6 = TextStorage.TEXTS.GetText(Class16.smethod_0(1648908635));
			GC.KeepAlive(this);
			return text6;
		}
		switch (ftype)
		{
		case 76:
		{
			ulong num = mask;
			string result = num.ToString();
			GC.KeepAlive(this);
			return result;
		}
		case 60:
			if (mask == 4294967295L || mask == ulong.MaxValue)
			{
				string text7 = TextStorage.TEXTS.GetText(Class16.smethod_0(1648952014));
				GC.KeepAlive(this);
				return text7;
			}
			break;
		}
		goto IL_0182;
		IL_0182:
		string[] decodedValuesArray = DecodedValues.GetDecodedValuesArray(ftype);
		ulong num2 = (ulong)decodedValuesArray.LongLength;
		ulong num3;
		if (num2 == 0L)
		{
			num3 = 1uL;
		}
		else
		{
			ulong num4 = 2uL;
			int num5 = 1;
			if (1L < num2)
			{
				do
				{
					num4 *= 2L;
					num5++;
				}
				while ((ulong)num5 < num2);
			}
			num3 = num4;
		}
		if (mask > (ulong)((long)num3 + -1L))
		{
			ulong num6 = mask;
			string text8 = TextStorage.TEXTS.GetText(Class16.smethod_0(1648908687));
			string result2 = string.Concat(text8 + Class16.smethod_0(1648908709), num6.ToString());
			GC.KeepAlive(this);
			return result2;
		}
		if (mask > 1L)
		{
			ulong num7 = (ulong)decodedValuesArray.LongLength;
			ulong num8;
			if (num7 == 0L)
			{
				num8 = 1uL;
			}
			else
			{
				ulong num9 = 2uL;
				int num10 = 1;
				if (1L < num7)
				{
					do
					{
						num9 *= 2L;
						num10++;
					}
					while ((ulong)num10 < num7);
				}
				num8 = num9;
			}
			if (mask == (ulong)((long)num8 + -1L))
			{
				string text9 = TextStorage.TEXTS.GetText(Class16.smethod_0(1648952014));
				GC.KeepAlive(this);
				return text9;
			}
		}
		string text10 = string.Empty;
		int num11 = (int)((nint)decodedValuesArray.LongLength - 1);
		if (num11 >= 0)
		{
			do
			{
				ulong num12 = (ulong)num11;
				ulong num13 = num12;
				ulong num14;
				if (num13 == 0L)
				{
					num14 = 1uL;
				}
				else
				{
					ulong num15 = 2uL;
					int num16 = 1;
					if (1L < num13)
					{
						do
						{
							num15 *= 2L;
							num16++;
						}
						while ((ulong)num16 < num13);
					}
					num14 = num15;
				}
				if (mask / num14 > 0L)
				{
					text10 = string.Concat(Class16.smethod_0(1648942920) + decodedValuesArray[num11], text10);
					ulong num17 = num12;
					ulong num18;
					if (num17 == 0L)
					{
						num18 = 1uL;
					}
					else
					{
						ulong num19 = 2uL;
						int num20 = 1;
						if (1L < num17)
						{
							do
							{
								num19 *= 2L;
								num20++;
							}
							while ((ulong)num20 < num17);
						}
						num18 = num19;
					}
					mask %= num18;
				}
				num11--;
			}
			while (num11 >= 0);
		}
		text10 = text10.Substring(2);
		GC.KeepAlive(this);
		return text10;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsIconsExist(int int_0)
	{
		if (int_0 < 0)
		{
			return false;
		}
		bool flag = false;
		if (Game == GAMES.PW)
		{
			if (ListsWithSubIcons == null)
			{
				ListsWithSubIcons = new int[14]
				{
					this.get_LI(Class16.smethod_0(1648952558)),
					this.get_LI(Class16.smethod_0(1648923298)),
					this.get_LI(Class16.smethod_0(1648952535)),
					this.get_LI(Class16.smethod_0(1648952504)),
					this.get_LI(Class16.smethod_0(1648960167)),
					this.get_LI(Class16.smethod_0(1648952704)),
					this.get_LI(Class16.smethod_0(1648952829)),
					this.get_LI(Class16.smethod_0(1648963546)),
					this.get_LI(Class16.smethod_0(1648955681)),
					this.get_LI(Class16.smethod_0(1648955663)),
					this.get_LI(Class16.smethod_0(1648952571)),
					this.get_LI(Class16.smethod_0(1648952781)),
					this.get_LI(Class16.smethod_0(1648952757)),
					this.get_LI(Class16.smethod_0(1648963535))
				};
			}
			int[] listsWithSubIcons = ListsWithSubIcons;
			byte b = (byte)((listsWithSubIcons != null && listsWithSubIcons.Length != 0 && Array.IndexOf(listsWithSubIcons, int_0) > -1) ? 1 : 0);
			flag = b != 0;
		}
		GC.KeepAlive(this);
		int num = ((Lists[int_0].IconFieldIndex > 0 || flag) ? 1 : 0);
		return (byte)num != 0;
	}

	public Image GetIcon(ITEMPOS ip, [MarshalAs(UnmanagedType.U1)] bool bRealSize, int size)
	{
		bool isTga = false;
		if (bRealSize)
		{
			Bitmap icon = Icons.GetIcon(GetIconName(ip, ref isTga), IsTga: false);
			GC.KeepAlive(this);
			return icon;
		}
		Bitmap icon2 = Icons.GetIcon(GetIconName(ip, ref isTga), IsTga: false, size);
		GC.KeepAlive(this);
		return icon2;
	}

	public Image GetIcon(ITEMINFO info, int size)
	{
		Bitmap icon = Icons.GetIcon(info.IconName, info.IsTgaIcon, size);
		GC.KeepAlive(this);
		return icon;
	}

	public Image GetIcon(ITEMINFO info)
	{
		Bitmap icon = Icons.GetIcon(info.IconName, info.IsTgaIcon);
		GC.KeepAlive(this);
		return icon;
	}

	public Image GetIcon(ITEMPOS ip, [MarshalAs(UnmanagedType.U1)] bool bRealSize)
	{
		return GetIcon(ip, bRealSize, 32);
	}

	public Image GetIcon(ITEMPOS ip)
	{
		return GetIcon(ip, bRealSize: false, 32);
	}

	public Image GetIcon(int int_0, int int_1)
	{
		ITEMPOS ip = new ITEMPOS(int_0, int_1);
		return GetIcon(ip, bRealSize: false, 32);
	}

	public string GetIconValue(string iconName)
	{
		if (Game == GAMES.PW)
		{
			return iconName;
		}
		PATH_DATA pathData = PathData;
		if (pathData.Paths != null)
		{
			string result = pathData.GetPathID(iconName, bContains: true).ToString();
			GC.KeepAlive(this);
			return result;
		}
		GC.KeepAlive(this);
		return Class16.smethod_0(1648924112);
	}

	public string GetIconValue(int line_icons_count, int int_0, int int_1)
	{
		string iconName = Icons.GetIconName(line_icons_count, int_0, int_1);
		GC.KeepAlive(this);
		return GetIconValue(iconName);
	}

	public void TranslateItem(int int_0, int int_1, int from, int to, [MarshalAs(UnmanagedType.U1)] bool bTranslateDesc)
	{
		string text = null;
		int num = 0;
		for (int i = 0; i < GetFieldsCount(int_0); i++)
		{
			if (!IsLocalizableField(int_0, i))
			{
				continue;
			}
			Application.DoEvents();
			string text2 = null;
			string value = GetValue(int_0, int_1, i);
			if (value.Contains(Class16.smethod_0(1648927580)))
			{
				continue;
			}
			text = value;
			if (RSCommon.IsTagColorExist(value))
			{
				text2 = text.Substring(0, 7);
				int length = text.Length - 7;
				text = text.Substring(7, length);
			}
			string prefix = ACE.RSGlobal.RSGlobal.GetPrefix(ref text, bCut: true);
			string postfix = ACE.RSGlobal.RSGlobal.GetPostfix(ref text, bCut: true);
			if (string.IsNullOrWhiteSpace(text))
			{
				continue;
			}
			try
			{
				int maxFieldChars = smethod_11(Lists[int_0].FieldDataTypes[i], text2, prefix, postfix);
				text = UniversalTranslator.Translate(text, from, to, maxFieldChars);
				num = 0;
			}
			catch (Exception ex)
			{
				num++;
				SentryHelper.CaptureException(ex, Class16.smethod_0(1648952078));
				ACE.MainWindow.MainWindow.ShowBackgroundMessageOutside(ex.Message);
				if (num < 3)
				{
					Application.DoEvents();
					i--;
				}
				continue;
			}
			if (text2 != null)
			{
				text = text2 + text;
			}
			text = string.Concat(prefix + text, postfix);
			SetValue(int_0, int_1, i, text, AutoSaveStage: false);
		}
		if (bTranslateDesc)
		{
			bool flag = MattersListsFast != null && MattersListsFast.Contains(int_0);
			GC.KeepAlive(this);
			if (flag)
			{
				int num2 = Lists[int_0].getid(int_1);
				GC.KeepAlive(this);
				int id = num2;
				string text3 = Descriptions.Get(num2);
				if (!string.IsNullOrWhiteSpace(text3))
				{
					try
					{
						if (Regex.IsMatch(text3, Class16.smethod_0(1648952106)))
						{
							string[] array = Regex.Split(text3, Class16.smethod_0(1648952106));
							MatchCollection matchCollection = Regex.Matches(text3, Class16.smethod_0(1648952129));
							StringBuilder stringBuilder = new StringBuilder(text3.Length);
							for (int j = 0; j < (nint)array.LongLength; j++)
							{
								string text4 = array[j];
								if (!string.IsNullOrWhiteSpace(text4))
								{
									text4 = UniversalTranslator.Translate(text4, from, to);
								}
								string text5 = ((j <= 0) ? string.Empty : matchCollection[j - 1].Value);
								stringBuilder.Append(text5 + text4);
							}
							text3 = stringBuilder.ToString();
						}
						else
						{
							text3 = UniversalTranslator.Translate(text3, from, to);
						}
					}
					catch (Exception ex2)
					{
						SentryHelper.CaptureException(ex2, Class16.smethod_0(1648952154));
					}
					text3 = text3.Replace(Class16.smethod_0(1648924428), Class16.smethod_0(1648941987));
					text3 = text3.Replace('\r', '\n');
					text3 = text3.Replace(Class16.smethod_0(1648941987), Class16.smethod_0(1648924428));
					Descriptions.Change(id, text3);
				}
			}
		}
		GC.KeepAlive(this);
	}

	private static int smethod_11(FIELD_DATA_TYPE field_DATA_TYPE_0, string string_1, string string_2, string string_3)
	{
		if (field_DATA_TYPE_0.data_type != FIELD_DATA_TYPE_ENUM.WString)
		{
			return 0;
		}
		if (field_DATA_TYPE_0.size <= 2)
		{
			return 0;
		}
		int num = (field_DATA_TYPE_0.size - 2) / 2;
		int num2 = (string_1?.Length ?? 0) + (string_2?.Length ?? 0) + (string_3?.Length ?? 0);
		int num3 = num - num2;
		if (num3 <= 0)
		{
			return 0;
		}
		return num3;
	}

	public void TranslateItem(vITEMPOS item, int from, int to, [MarshalAs(UnmanagedType.U1)] bool bTranslateDesc)
	{
		TranslateItem(item.Int32_1, item.Int32_0, from, to, bTranslateDesc);
		GC.KeepAlive(this);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsLocalizableField(int int_0, int int_1)
	{
		if (int_1 < 1)
		{
			return false;
		}
		ACE.Elements.eList.eList eList2 = Lists[int_0];
		if (int_1 == eList2.IconFieldIndex)
		{
			return false;
		}
		return eList2.FieldDataTypes[int_1].data_type == FIELD_DATA_TYPE_ENUM.WString;
	}

	public unsafe FIELDTYPE TryToFindFieldBindedList(int int_0, int int_1, int[] TestLists, int* BindedListIndex)
	{
		if (MattersFields == null)
		{
			MattersFields = new HashSet<string>(new string[2]
			{
				Class16.smethod_0(1648952202),
				Class16.smethod_0(1648952237)
			});
		}
		FIELDTYPE fIELDTYPE = FIELDTYPE.not_set;
		string text = Lists[int_0].elementFields[int_1];
		if (MattersFields.Contains(text))
		{
			GC.KeepAlive(this);
			return FIELDTYPE.matters;
		}
		*BindedListIndex = -1;
		FIELD_DATA_TYPE_ENUM data_type = Lists[int_0].FieldDataTypes[int_1].data_type;
		if (data_type == FIELD_DATA_TYPE_ENUM.Int || data_type == FIELD_DATA_TYPE_ENUM.UInt)
		{
			text = text.Replace(Class16.smethod_0(1648952248), string.Empty);
			text = text.Replace(Class16.smethod_0(1648986201), string.Empty);
			if (text.Length >= 6 && Lists[int_0].uListName == Class16.smethod_0(1648960167))
			{
				int num = FindList(text.ToUpperInvariant(), 1, bStrict: true);
				if (num > -1)
				{
					*BindedListIndex = num;
					GC.KeepAlive(this);
					return FIELDTYPE.custom_list;
				}
			}
			bool flag = !ACE.RSGlobal.RSGlobal.ContainsIgnoreCase(text, Class16.smethod_0(1648952258));
			fIELDTYPE = ((TestLists == MattersLists) ? FIELDTYPE.matters : ((TestLists == EquipmentLists) ? FIELDTYPE.complect_equip : fIELDTYPE));
			HashSet<int> hashSet = new HashSet<int>();
			int num2 = 0;
			if (0 < (nint)Lists.LongLength)
			{
				do
				{
					if ((!flag || !ACE.RSGlobal.RSGlobal.ContainsIgnoreCase(Lists[num2].uListName, Class16.smethod_0(1648952258))) && ACE.RSGlobal.RSGlobal.ContainsIgnoreCase(Lists[num2].uListName, text))
					{
						hashSet.Add(num2);
					}
					num2++;
				}
				while (num2 < (nint)Lists.LongLength);
			}
			int num3 = ListCount - 1;
			int endval = ((num3 < int_0 + 5) ? num3 : (int_0 + 5));
			int[] other = ACE.RSGlobal.RSGlobal.IntArray((0 <= int_0 - 5) ? (int_0 - 5) : 0, endval, 1);
			hashSet.UnionWith(other);
			int endval2 = ListCount - 1;
			int[] other2 = ACE.RSGlobal.RSGlobal.IntArray(0, endval2, 1);
			hashSet.UnionWith(other2);
			if (flag)
			{
				hashSet.Remove(addons_l);
			}
			int[] lists = new List<int>(hashSet).ToArray();
			List<int> list = new List<int>();
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			int num4 = 0;
			if (0 < GetItemsCount(int_0))
			{
				do
				{
					int valueIFast = Lists[int_0].GetValueIFast(num4, int_1);
					GC.KeepAlive(this);
					if (valueIFast >= 100)
					{
						ITEMPOS iTEMPOS;
						if (TestLists != null)
						{
							iTEMPOS = FindItemPos(TestLists, valueIFast);
							if (iTEMPOS == null)
							{
								GC.KeepAlive(this);
								return FIELDTYPE.not_set;
							}
						}
						else
						{
							iTEMPOS = FindItemPos(lists, valueIFast);
							if (iTEMPOS == null)
							{
								goto IL_023d;
							}
						}
						list.Add(iTEMPOS.int_0);
						int num5 = 0;
						if (0 < ListCount)
						{
							do
							{
								if (num5 != ConversationListIndex && (!flag || !Lists[num5].uListName.Contains(Class16.smethod_0(1648952278))) && Lists[num5].IDs.Contains(valueIFast))
								{
									if (dictionary.ContainsKey(num5))
									{
										int value = dictionary[num5] + 1;
										dictionary[num5] = value;
									}
									else
									{
										dictionary.Add(num5, 1);
									}
								}
								num5++;
							}
							while (num5 < ListCount);
						}
					}
					goto IL_023d;
					IL_023d:
					num4++;
				}
				while (num4 < GetItemsCount(int_0));
			}
			if (TestLists != null)
			{
				GC.KeepAlive(this);
				return fIELDTYPE;
			}
			if (list.Count == 1)
			{
				fIELDTYPE = FIELDTYPE.custom_list;
				*BindedListIndex = list[0];
			}
			else if (list.Count > 1)
			{
				if (dictionary.Count == 0)
				{
					GC.KeepAlive(this);
					return FIELDTYPE.not_set;
				}
				int maxValueKeyInDict = ACE.RSGlobal.RSGlobal.GetMaxValueKeyInDict(dictionary);
				if (list.Count - dictionary[maxValueKeyInDict] > 3)
				{
					fIELDTYPE = ((Game == GAMES.PW && TryToFindFieldBindedList(int_0, int_1, EquipmentLists, BindedListIndex) == FIELDTYPE.complect_equip) ? FIELDTYPE.complect_equip : ((TryToFindFieldBindedList(int_0, int_1, MattersLists, BindedListIndex) == FIELDTYPE.matters) ? FIELDTYPE.matters : FIELDTYPE.any_list));
				}
				else
				{
					fIELDTYPE = FIELDTYPE.custom_list;
					*BindedListIndex = maxValueKeyInDict;
				}
			}
		}
		return fIELDTYPE;
	}

	public unsafe string _GenerateFieldsBindedLists(int int_0, int first_f, int last_f, int* BindedListIndex)
	{
		return string.Empty;
	}

	public int FindList(string NameOrIndex, int start_l, [MarshalAs(UnmanagedType.U1)] bool bStrict)
	{
		if (string.IsNullOrWhiteSpace(NameOrIndex))
		{
			GC.KeepAlive(this);
			return -1;
		}
		start_l = ((start_l < (nint)Lists.LongLength - 1) ? start_l : 0);
		int num = this.get_LI(NameOrIndex);
		if (num > -1)
		{
			return num;
		}
		if (ACE.RSGlobal.RSGlobal.IsUIntFast(NameOrIndex))
		{
			num = ACE.RSGlobal.RSGlobal.UIntParseFast(NameOrIndex);
			if (num > 0 && num < ListCount)
			{
				return num;
			}
		}
		int num2 = start_l;
		ACE.Elements.eList.eList[] lists = Lists;
		if (start_l < (nint)lists.LongLength)
		{
			do
			{
				if (bStrict)
				{
					if (lists[num2].uListName.StartsWith(NameOrIndex, StringComparison.InvariantCultureIgnoreCase) || Lists[num2].uListName.EndsWith(NameOrIndex, StringComparison.InvariantCultureIgnoreCase))
					{
						return num2;
					}
				}
				else if (ACE.RSGlobal.RSGlobal.ContainsIgnoreCase(lists[num2].ListName, NameOrIndex) || ACE.RSGlobal.RSGlobal.ContainsIgnoreCase(Lists[num2].uListName, NameOrIndex))
				{
					return num2;
				}
				num2++;
				lists = Lists;
			}
			while (num2 < (nint)lists.LongLength);
		}
		GC.KeepAlive(this);
		return -1;
	}

	public int FindList(string Name)
	{
		return FindList(Name, 0, bStrict: false);
	}

	public int FindListSuperStrict(string Name, int start_l, [MarshalAs(UnmanagedType.U1)] bool bOnlyStruct)
	{
		if (string.IsNullOrWhiteSpace(Name))
		{
			GC.KeepAlive(this);
			return -1;
		}
		start_l = ((start_l < (nint)Lists.LongLength - 1) ? start_l : 0);
		int num = this.get_LI(Name);
		if (num > -1)
		{
			return num;
		}
		if (bOnlyStruct)
		{
			return -1;
		}
		int num2 = start_l;
		ACE.Elements.eList.eList[] lists = Lists;
		if (start_l < (nint)lists.LongLength)
		{
			do
			{
				if (!(lists[num2].ListName == Name))
				{
					num2++;
					lists = Lists;
					continue;
				}
				return num2;
			}
			while (num2 < (nint)lists.LongLength);
		}
		GC.KeepAlive(this);
		return -1;
	}

	public int AddRange(int int_0, object[] itemValues, int count)
	{
		ACE.Elements.eList.eList eList2 = Lists[int_0];
		int num = eList2.elementValues.Length;
		int num2 = num;
		Array.Resize(ref eList2.elementValues, num + count);
		int num3 = num2;
		object[][] elementValues = Lists[int_0].elementValues;
		if (num2 < (nint)elementValues.LongLength)
		{
			do
			{
				elementValues[num3] = new object[(nint)itemValues.LongLength];
				itemValues.CopyTo(Lists[int_0].elementValues[num3], 0);
				Lists[int_0].IDs.Add((int)itemValues[0]);
				ItemChanged(int_0, num3);
				num3++;
				elementValues = Lists[int_0].elementValues;
			}
			while (num3 < (nint)elementValues.LongLength);
		}
		Lists[int_0].bItemsOrderingChanged = true;
		FileChanged = true;
		return num2;
	}

	public void MoveItem(int int_0, int src_e, int dest_e)
	{
		Lists[int_0].MoveItem(src_e, dest_e);
		ItemsCache[int_0] = null;
		FileChanged = true;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsItemExist(int int_0, int int_1)
	{
		if (int_0 > -1 && int_0 < ListCount && int_1 > -1 && int_1 < GetItemsCount(int_0))
		{
			return true;
		}
		return false;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsItemExist(ITEMPOS ip)
	{
		int num;
		if (ip != null)
		{
			int int_ = ip.int_1;
			int int_2 = ip.int_0;
			if (int_2 > -1 && int_2 < ListCount && int_ > -1 && int_ < GetItemsCount(int_2))
			{
				num = 1;
				goto IL_0038;
			}
		}
		num = 0;
		goto IL_0038;
		IL_0038:
		return (byte)num != 0;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsItemExist(ITEMINFO info)
	{
		int num = ((info != null && IsItemExist(info.pos)) ? 1 : 0);
		return (byte)num != 0;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsItemsExist(int int_0, int[] items)
	{
		if (int_0 >= 0 && int_0 < ListCount && items != null)
		{
			int num = items.Length;
			if (num != 0)
			{
				int num2 = 0;
				if (0 < num)
				{
					do
					{
						int num3 = items[num2];
						if (int_0 > -1 && int_0 < ListCount && num3 > -1 && num3 < GetItemsCount(int_0))
						{
							num2++;
							continue;
						}
						return false;
					}
					while (num2 < (nint)items.LongLength);
				}
				return true;
			}
		}
		return false;
	}

	private static string smethod_12(Font font_2)
	{
		if (font_2 == null)
		{
			return string.Empty;
		}
		return font_2.Name + Class16.smethod_0(1648905535) + font_2.SizeInPoints.ToString(Class16.smethod_0(1648952282)) + Class16.smethod_0(1648905535) + (int)font_2.Style + Class16.smethod_0(1648905535) + (int)font_2.Unit;
	}

	private void method_33()
	{
		ADDITIONAL_PARAMS aParams = CommonStorage.AParams;
		object obj;
		if (aParams == null)
		{
			obj = null;
		}
		else
		{
			obj = aParams.ItemsFont;
			if (obj != null)
			{
				goto IL_001a;
			}
		}
		obj = SystemFonts.DefaultFont;
		goto IL_001a;
		IL_001a:
		Font font = (Font)obj;
		string text = smethod_12(font);
		if (!(text == string_0) || font_0 == null || font_1 == null)
		{
			method_34();
			font_0 = new Font(font, FontStyle.Underline);
			font_1 = new Font(font, FontStyle.Bold);
			string_0 = text;
		}
	}

	private void method_34()
	{
		if (font_0 != null)
		{
			try
			{
				font_0.Dispose();
			}
			catch
			{
			}
			font_0 = null;
		}
		if (font_1 != null)
		{
			try
			{
				font_1.Dispose();
			}
			catch
			{
			}
			font_1 = null;
		}
		string_0 = null;
	}

	public ListViewItem CreateListViewItem(ITEMINFO info, [MarshalAs(UnmanagedType.U1)] bool NameIsFirst)
	{
		ListViewItem listViewItem = new ListViewItem();
		if (info == null)
		{
			return listViewItem;
		}
		string text = info.NameWithSubItems();
		if (text == string.Empty)
		{
			text = Class16.smethod_0(1648966655);
		}
		listViewItem.UseItemStyleForSubItems = false;
		if (NameIsFirst)
		{
			text = Class16.smethod_0(1648952302) + text;
			listViewItem.Text = text;
			string text2 = info.ID;
			bool flag = false;
			if (info.pos != null)
			{
				try
				{
					vITEMPOS item = new vITEMPOS(info.pos);
					flag = IsItemChanged(item);
					GC.KeepAlive(this);
				}
				catch (NullReferenceException)
				{
					flag = false;
				}
			}
			if (flag)
			{
				text2 += Class16.smethod_0(1648941528);
			}
			listViewItem.SubItems.Add(text2);
			ListViewItem.ListViewSubItem listViewSubItem = listViewItem.SubItems[1];
			Color foreColor = Color.Silver;
			if (!info.bOcupiedID && !info.bHasErrors)
			{
				if (info.bHasReferences)
				{
					method_33();
					listViewSubItem.Font = font_0;
					listViewSubItem.Tag = true;
				}
			}
			else
			{
				foreColor = Color.Red;
				method_33();
				listViewSubItem.Font = font_1;
			}
			listViewSubItem.ForeColor = foreColor;
			if (Params.ShowItemsColor)
			{
				listViewItem.SubItems[0].ForeColor = info.color;
			}
			int refCount = info.RefCount;
			listViewItem.SubItems.Add(refCount.ToString());
			Color foreColor2 = ((info.RefCount <= 0) ? Color.Gray : Color.Cyan);
			listViewItem.SubItems[2].ForeColor = foreColor2;
			listViewSubItem.BackColor = info.CatColor;
			listViewSubItem.BackColor = SpecialColors.ItemDark;
		}
		else
		{
			listViewItem.Text = info.ID;
			listViewItem.SubItems.Add(text);
			Color silver = Color.Silver;
			listViewItem.SubItems[0].ForeColor = silver;
			if (Params.ShowItemsColor)
			{
				listViewItem.SubItems[1].ForeColor = info.color;
			}
			listViewItem.SubItems[0].BackColor = SpecialColors.ItemDark;
			listViewItem.SubItems[1].BackColor = SpecialColors.ItemDark;
		}
		listViewItem.Tag = info.pos;
		if (info.IsTgaIcon)
		{
			int imageIndex = Icons?.GetPckIconIndex(info.IconName) ?? 1;
			listViewItem.ImageIndex = imageIndex;
		}
		else
		{
			int imageIndex2 = Icons?.GetIconIndex(info.IconName) ?? 1;
			listViewItem.ImageIndex = imageIndex2;
		}
		GC.KeepAlive(this);
		return listViewItem;
	}

	public unsafe ListViewItem.ListViewSubItem[] GetSubItems(ListViewItem owner, ITEMPOS ip, int* icon_index)
	{
		ListViewItem.ListViewSubItem[] array = new ListViewItem.ListViewSubItem[2];
		ITEMINFO itemInfo = GetItemInfo(ip, bUseCache: true, bCheckIsFreeID: true, bCheckHasReferences: true);
		if (itemInfo == null)
		{
			return array;
		}
		array[1] = new ListViewItem.ListViewSubItem(owner, itemInfo.ID);
		Color silver = Color.Silver;
		array[1].ForeColor = silver;
		array[1].BackColor = SpecialColors.ItemDark;
		array[0] = new ListViewItem.ListViewSubItem(owner, itemInfo.name);
		if (Params.ShowItemsColor)
		{
			array[0].ForeColor = itemInfo.color;
		}
		array[0].BackColor = SpecialColors.ItemDark;
		int num = Icons?.GetIconIndex(itemInfo.IconName) ?? 1;
		*icon_index = num;
		GC.KeepAlive(this);
		return array;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsMobsList(int int_0)
	{
		bool result = Lists[int_0].uListName == Class16.smethod_0(1648963546);
		GC.KeepAlive(this);
		return result;
	}

	public int GetPowerLVL(ITEMPOS ip)
	{
		int int_ = ip.int_0;
		int num = ((Game == GAMES.PW) ? Lists[int_].get_fields(Class16.smethod_0(1648952311)) : Lists[int_].get_fields(Class16.smethod_0(1648961613)));
		int result = 0;
		if (num > 0)
		{
			int int_2 = ip.int_1;
			int int_3 = ip.int_0;
			int valueIFast = Lists[int_3].GetValueIFast(int_2, num);
			GC.KeepAlive(this);
			result = valueIFast;
			if (Game != GAMES.PW)
			{
				result = valueIFast / 20;
			}
			result = ((result > 5) ? 5 : result);
		}
		return result;
	}

	public string GetPowerLvlPrefix(ITEMPOS ip)
	{
		string text = null;
		switch (GetPowerLVL(ip))
		{
		case 1:
			text = Class16.smethod_0(1648951296);
			break;
		case 2:
			text = Class16.smethod_0(1648951305);
			break;
		case 3:
			text = Class16.smethod_0(1648951314);
			break;
		case 4:
			text = Class16.smethod_0(1648951323);
			break;
		case 5:
			text = Class16.smethod_0(1648951340);
			break;
		}
		if (text != null)
		{
			string text2 = Class16.smethod_0(1648924347);
			text = string.Concat(Class16.smethod_0(1648924364) + text, text2);
		}
		GC.KeepAlive(this);
		return text;
	}

	public int GetTypeID(ITEMPOS ItemPos)
	{
		int int_ = ItemPos.int_0;
		ACE.Elements.eList.eList[] lists = Lists;
		int typeFieldIndex = lists[int_].TypeFieldIndex;
		if (typeFieldIndex > 0)
		{
			int int_2 = typeFieldIndex;
			int int_3 = ItemPos.int_1;
			int num = int_;
			int valueIFast = lists[num].GetValueIFast(int_3, int_2);
			GC.KeepAlive(this);
			return valueIFast;
		}
		return -1;
	}

	public int GetSubTypeID(ITEMPOS ItemPos)
	{
		int int_ = ItemPos.int_0;
		ACE.Elements.eList.eList[] lists = Lists;
		int subTypeFieldIndex = lists[int_].SubTypeFieldIndex;
		if (subTypeFieldIndex > 0)
		{
			int int_2 = subTypeFieldIndex;
			int int_3 = ItemPos.int_1;
			int num = int_;
			int valueIFast = lists[num].GetValueIFast(int_3, int_2);
			GC.KeepAlive(this);
			return valueIFast;
		}
		return -1;
	}

	public int? GetTypeIdOrNull(int int_0, int int_1)
	{
		ACE.Elements.eList.eList eList2 = Lists[int_0];
		int typeFieldIndex = eList2.TypeFieldIndex;
		if (typeFieldIndex > 0)
		{
			int int_2 = typeFieldIndex;
			int valueIFast = eList2.GetValueIFast(int_1, int_2);
			GC.KeepAlive(this);
			int? result = valueIFast;
			GC.KeepAlive(this);
			return result;
		}
		GC.KeepAlive(this);
		return null;
	}

	public int? GetSubTypeIdOrNull(int int_0, int int_1)
	{
		ACE.Elements.eList.eList eList2 = Lists[int_0];
		int subTypeFieldIndex = eList2.SubTypeFieldIndex;
		if (subTypeFieldIndex > 0)
		{
			int int_2 = subTypeFieldIndex;
			int valueIFast = eList2.GetValueIFast(int_1, int_2);
			GC.KeepAlive(this);
			int? result = valueIFast;
			GC.KeepAlive(this);
			return result;
		}
		GC.KeepAlive(this);
		return null;
	}

	public unsafe int SortRecipes(ITEMPOS ip, int TabFieldIndex, int LastIndex)
	{
		if (!(ip == null) && Lists != null && ip.int_0 >= 0 && ip.int_0 < Lists.Length && Lists[ip.int_0] != null)
		{
			if (ip.int_1 >= 0 && Lists[ip.int_0].elementValues != null && ip.int_1 < Lists[ip.int_0].elementValues.Length)
			{
				List<int> list = null;
				List<ITEMPOS> list2 = null;
				Dictionary<int, List<int>> dictionary = null;
				list = new List<int>();
				list2 = new List<ITEMPOS>();
				List<int> list3 = new List<int>();
				List<int> list4 = new List<int>();
				int[,] array = new int[8, 4];
				int num = 0;
				int num2 = TabFieldIndex;
				if (TabFieldIndex <= LastIndex)
				{
					do
					{
						int[] fieldLists = GetFieldLists(ip.int_0, ip.int_1, num2);
						if (fieldLists != null && fieldLists.Length != 0 && fieldLists[0] == this.get_LI(Class16.smethod_0(1648952558)) && method_35(ip, num2))
						{
							int num3 = num % 8;
							int num4 = num / 8;
							if (num4 >= array.GetLength(1))
							{
								num2++;
								continue;
							}
							num++;
							array[num3, num4] = num2;
							int int_ = ip.int_1;
							int int_2 = ip.int_0;
							int valueIFast = Lists[int_2].GetValueIFast(int_, num2);
							GC.KeepAlive(this);
							int num5 = this.get_LI(Class16.smethod_0(1648952558));
							ITEMPOS iTEMPOS = null;
							int num6 = FindItemIndexByID(num5, valueIFast);
							if (num6 > -1)
							{
								iTEMPOS = new ITEMPOS(num5, num6);
							}
							if (iTEMPOS != null)
							{
								int int_3 = iTEMPOS.int_0;
								ITEMPOS iTEMPOS2 = FindItemPos(iTEMPOS, Lists[int_3].get_fields(Class16.smethod_0(1648951942)));
								if (iTEMPOS2 != null)
								{
									list.Add(valueIFast);
									list2.Add(iTEMPOS2);
									list3.Add(iTEMPOS2.int_0);
								}
							}
							Lists[ip.int_0].elementValues[ip.int_1][num2] = 0;
						}
						num2++;
					}
					while (num2 <= LastIndex);
				}
				if (list2.Count == 0)
				{
					GC.KeepAlive(this);
					return 0;
				}
				RECIPES_SORT_TYPE rECIPES_SORT_TYPE = RECIPES_SORT_TYPE.BY_ID;
				int maxFrequentValue = ACE.RSGlobal.RSGlobal.GetMaxFrequentValue(list3);
				int num7 = ACE.RSGlobal.RSGlobal.CountInList(list3, maxFrequentValue);
				int num8 = (int)((double)list3.Count * 0.2 + 1.0);
				if (list3.Count - num7 < num8)
				{
					ACE.Elements.eList.eList eList2 = Lists[maxFrequentValue];
					if (eList2.TypeFieldIndex > 0)
					{
						rECIPES_SORT_TYPE = RECIPES_SORT_TYPE.BY_TYPE;
						if (eList2.SubTypeFieldIndex > 0)
						{
							List<ITEMPOS>.Enumerator enumerator = list2.GetEnumerator();
							if (enumerator.MoveNext())
							{
								do
								{
									ITEMPOS current = enumerator.Current;
									if (current.int_0 == maxFrequentValue)
									{
										list4.Add(GetTypeID(current));
									}
								}
								while (enumerator.MoveNext());
							}
							int maxFrequentValue2 = ACE.RSGlobal.RSGlobal.GetMaxFrequentValue(list4);
							int num9 = ACE.RSGlobal.RSGlobal.CountInList(list4, maxFrequentValue2);
							int num10 = (int)((double)list4.Count * 0.2 + 1.0);
							if (list4.Count - num9 < num10)
							{
								rECIPES_SORT_TYPE = RECIPES_SORT_TYPE.BY_SUBTYPE;
							}
							else if (maxFrequentValue == this.get_LI(Class16.smethod_0(1648923258)) || maxFrequentValue == this.get_LI(Class16.smethod_0(1648923096)))
							{
								rECIPES_SORT_TYPE = RECIPES_SORT_TYPE.AUTO_ARMOR;
							}
						}
					}
				}
				dictionary = null;
				RecipesSorter_SortItems(ref list, ref list2, ref dictionary, rECIPES_SORT_TYPE, maxFrequentValue);
				int num11 = 0;
				int num12 = 0;
				int num13 = 0;
				int num14 = 0;
				int num15 = 0;
				if (0 < list.Count)
				{
					int num16 = 8;
					do
					{
						if (num15 < 0 || num15 >= list2.Count)
						{
							num11++;
							num15++;
							continue;
						}
						int num17 = 8;
						if (num11 < 8)
						{
							num17 = num16;
						}
						int num18 = 4;
						if (list2[num15] != null)
						{
							int typeID = GetTypeID(list2[num15]);
							int subTypeID = GetSubTypeID(list2[num15]);
							switch (rECIPES_SORT_TYPE)
							{
							case RECIPES_SORT_TYPE.BY_ID:
								num17 = num15 % 8 + 1;
								num18 = num15 / 8 + 1;
								break;
							case RECIPES_SORT_TYPE.BY_TYPE:
								typeID = ((list2[num15].int_0 != maxFrequentValue) ? (-1) : typeID);
								if (!RecipesSorter_GetCell(dictionary, list[num15], typeID, &num17, &num18))
								{
									num11++;
									num16--;
								}
								break;
							case RECIPES_SORT_TYPE.BY_SUBTYPE:
								subTypeID = ((list2[num15].int_0 != maxFrequentValue) ? (-1) : subTypeID);
								if (!RecipesSorter_GetCell(dictionary, list[num15], subTypeID, &num17, &num18))
								{
									num11++;
									num16--;
								}
								break;
							case RECIPES_SORT_TYPE.AUTO_ARMOR:
								if (!RecipesSorter_GetEquipCell(typeID, subTypeID, &num17, &num18, &num12, &num13, &num14, ip, array))
								{
									num11++;
									num16--;
								}
								break;
							}
						}
						else
						{
							num11++;
							num16--;
						}
						num17 = Math.Max(1, Math.Min(8, num17));
						num18 = Math.Max(1, Math.Min(4, num18));
						int num19 = num17;
						if (num17 > 8)
						{
							num17 = 8;
						}
						if (num18 > 4)
						{
							num18 = 4;
						}
						if (!RecipesSorter_IsCellEmpty(num18, num17, ip, array))
						{
							num17 = ((num11 < 8) ? num16 : 8);
							num18 = 4;
							if (!RecipesSorter_IsCellEmpty(4, num17, ip, array))
							{
								num17 = num19;
								RecipesSorter_FindEmtyCell(&num18, &num17, ip, array);
							}
						}
						num17 = Math.Max(1, Math.Min(8, num17));
						num18 = Math.Max(1, Math.Min(4, num18));
						int num20 = array[num17 - 1, num18 - 1];
						if (method_35(ip, num20))
						{
							Lists[ip.int_0].elementValues[ip.int_1][num20] = list[num15];
						}
						else
						{
							num11++;
						}
						num15++;
					}
					while (num15 < list.Count);
					if (num11 != 0)
					{
						if (num11 >= 8)
						{
							return 3;
						}
						return 2;
					}
				}
				GC.KeepAlive(this);
				return 1;
			}
			GC.KeepAlive(this);
			return 0;
		}
		GC.KeepAlive(this);
		return 0;
	}

	private bool method_35(ITEMPOS itempos_0, int int_0)
	{
		if (itempos_0 != null && itempos_0.int_0 >= 0 && itempos_0.int_0 < Lists.Length && Lists[itempos_0.int_0] != null && itempos_0.int_1 >= 0 && Lists[itempos_0.int_0].elementValues != null && itempos_0.int_1 < Lists[itempos_0.int_0].elementValues.Length && Lists[itempos_0.int_0].elementValues[itempos_0.int_1] != null && int_0 >= 0)
		{
			return int_0 < Lists[itempos_0.int_0].elementValues[itempos_0.int_1].Length;
		}
		return false;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool RecipesSorter_IsCellEmpty(int row, int column, ITEMPOS ip, int[,] fields_indices)
	{
		if (!(ip == null) && fields_indices != null)
		{
			if (row >= 1 && row <= fields_indices.GetLength(1) && column >= 1 && column <= fields_indices.GetLength(0))
			{
				int num = fields_indices[column - 1, row - 1];
				if (!method_35(ip, num))
				{
					return false;
				}
				try
				{
					return Convert.ToInt32(Lists[ip.int_0].elementValues[ip.int_1][num]) == 0;
				}
				catch
				{
					return false;
				}
			}
			return false;
		}
		return false;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public unsafe bool RecipesSorter_FindEmtyCell(int* row, int* column, ITEMPOS ip, int[,] fields_indices)
	{
		int num = 0;
		bool result = false;
		int num2 = *column;
		if (num2 <= 8)
		{
			do
			{
				int num3 = 1;
				while (!RecipesSorter_IsCellEmpty(num3, num2, ip, fields_indices))
				{
					num3++;
					if (num3 <= 4)
					{
						continue;
					}
					goto IL_0024;
				}
				*row = num3;
				*column = num2;
				result = true;
				break;
				IL_0024:
				num2 = ((num2 == 8) ? 1 : num2);
				num++;
				if (num == 8)
				{
					break;
				}
				num2++;
			}
			while (num2 <= 8);
		}
		return result;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public unsafe bool RecipesSorter_GetCell(Dictionary<int, List<int>> UniqueTypesBase, int item_id, int type, int* column, int* row)
	{
		if ((*row = new List<int>(UniqueTypesBase.Keys).IndexOf(type) + 1) > 0)
		{
			if ((*column = UniqueTypesBase[type].IndexOf(item_id) + 1) <= 8)
			{
				GC.KeepAlive(this);
				return true;
			}
			*column = 0;
		}
		Dictionary<int, List<int>>.Enumerator enumerator = UniqueTypesBase.GetEnumerator();
		if (enumerator.MoveNext())
		{
			do
			{
				ValueType valueType = enumerator.Current;
				if (((KeyValuePair<int, List<int>>)(object)valueType).Value.Count < 8)
				{
					((KeyValuePair<int, List<int>>)(object)valueType).Value.Add(item_id);
					*column = ((KeyValuePair<int, List<int>>)(object)valueType).Value.Count;
					*row = new List<int>(UniqueTypesBase.Keys).IndexOf(((KeyValuePair<int, List<int>>)(object)valueType).Key) + 1;
					break;
				}
			}
			while (enumerator.MoveNext());
		}
		if (*column == 0)
		{
			*column = 8;
			*row = 4;
		}
		GC.KeepAlive(this);
		return false;
	}

	public void RecipesSorter_SortItems(ref List<int> recipes_ids, ref List<ITEMPOS> Items, ref Dictionary<int, List<int>> UniqueTypesBase, RECIPES_SORT_TYPE sort_type, int int_0)
	{
		List<int> list = new List<int>(recipes_ids.Count);
		List<ITEMPOS> list2 = new List<ITEMPOS>(Items.Count);
		UniqueTypesBase = new Dictionary<int, List<int>>();
		switch (sort_type)
		{
		case RECIPES_SORT_TYPE.BY_TYPE:
		case RECIPES_SORT_TYPE.BY_SUBTYPE:
		case RECIPES_SORT_TYPE.AUTO_ARMOR:
		{
			int num4 = 0;
			if (0 < Items.Count)
			{
				do
				{
					list.Add(0);
					list2.Add(null);
					num4++;
				}
				while (num4 < Items.Count);
			}
			int num5 = 0;
			int num6 = 0;
			int num7 = 0;
			if (Items.Count <= 0)
			{
				break;
			}
			do
			{
				if (Items[num7] == null || Items[num7].int_0 == int_0)
				{
					int num8 = -1;
					int index2 = 0;
					int num9 = 0;
					if (Items.Count > 0)
					{
						do
						{
							if (Items[num9] != null && Items[num9].int_0 == int_0)
							{
								int num10 = ((sort_type != RECIPES_SORT_TYPE.BY_SUBTYPE) ? GetTypeID(Items[num9]) : GetSubTypeID(Items[num9]));
								if (num10 < num8 || num8 == -1)
								{
									index2 = num9;
									num8 = num10;
								}
							}
							num9++;
						}
						while (num9 < Items.Count);
					}
					list2[num5] = Items[index2];
					list[num5] = recipes_ids[index2];
					if (!UniqueTypesBase.ContainsKey(num8) && UniqueTypesBase.Count < 4)
					{
						UniqueTypesBase.Add(num8, new List<int>());
					}
					if (UniqueTypesBase.ContainsKey(num8))
					{
						UniqueTypesBase[num8].Add(recipes_ids[index2]);
					}
					Items[index2] = null;
					num5++;
				}
				else
				{
					num6++;
					int index3 = Items.Count - num6;
					list2[index3] = Items[num7];
					int index4 = Items.Count - num6;
					list[index4] = recipes_ids[num7];
				}
				num7++;
			}
			while (num7 < Items.Count);
			break;
		}
		case RECIPES_SORT_TYPE.BY_ID:
		{
			int num = 0;
			if (Items.Count <= 0)
			{
				break;
			}
			do
			{
				int num2 = -1;
				int index = 0;
				int num3 = 0;
				if (Items.Count > 0)
				{
					do
					{
						if (Items[num3] != null && (getid(Items[num3]) < num2 || num2 == -1))
						{
							index = num3;
							num2 = getid(Items[num3]);
						}
						num3++;
					}
					while (num3 < Items.Count);
				}
				list2.Add(Items[index]);
				list.Add(recipes_ids[index]);
				Items[index] = null;
				num++;
			}
			while (num < Items.Count);
			break;
		}
		}
		recipes_ids = list;
		Items = list2;
		GC.KeepAlive(this);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public unsafe bool RecipesSorter_GetEquipCell(int type, int subtype, int* column, int* row, int* hands_count, int* heads_count, int* mantles_count, ITEMPOS ip, int[,] fields_indices)
	{
		if (type <= 216)
		{
			if (type != 125)
			{
				if (type != 150)
				{
					if (type != 216)
					{
						goto IL_00e8;
					}
					*column = 3;
					switch (subtype)
					{
					default:
						*row = ((subtype != 219) ? 4 : 3);
						break;
					case 218:
						*row = 2;
						break;
					case 217:
						*row = 1;
						break;
					}
				}
				else
				{
					*column = 2;
					switch (subtype)
					{
					default:
						*row = ((subtype != 202) ? 4 : 3);
						break;
					case 188:
						*row = 2;
						break;
					case 163:
						*row = 1;
						break;
					}
				}
			}
			else
			{
				*column = 1;
				switch (subtype)
				{
				default:
					*row = ((subtype != 153) ? 4 : 3);
					break;
				case 140:
					*row = 2;
					break;
				case 127:
					*row = 1;
					break;
				}
			}
			goto IL_01ad;
		}
		if (type != 316)
		{
			if (type == 346)
			{
				*column = 4;
				(*hands_count)++;
				int num = *hands_count;
				if (subtype != 347)
				{
					if (subtype == 356)
					{
						int num2 = ((num > 3) ? num : 3);
						*row = num2;
						goto IL_01a3;
					}
					*row = ((subtype != 2875) ? 4 : 2);
				}
				else
				{
					*row = 1;
				}
				goto IL_01ad;
			}
			if (type != 369)
			{
				goto IL_00e8;
			}
			*column = 8;
			(*mantles_count)++;
			int num3 = *mantles_count;
			*row = num3;
		}
		else
		{
			*column = 7;
			(*heads_count)++;
			int num4 = *heads_count;
			switch (subtype)
			{
			default:
				*row = num4;
				break;
			case 318:
			{
				int num6 = (RecipesSorter_IsCellEmpty(1, *column, ip, fields_indices) ? 1 : (*heads_count));
				*row = num6;
				break;
			}
			case 317:
			{
				int num5 = ((!RecipesSorter_IsCellEmpty(2, *column, ip, fields_indices)) ? (*heads_count) : 2);
				*row = num5;
				break;
			}
			}
		}
		goto IL_01a3;
		IL_01a3:
		if (*row > 4)
		{
			*row = 4;
		}
		goto IL_01ad;
		IL_01ad:
		if (!RecipesSorter_IsCellEmpty(*row, *column, ip, fields_indices))
		{
			RecipesSorter_FindEmtyCell(row, column, ip, fields_indices);
		}
		return true;
		IL_00e8:
		return false;
	}

	public ITEMPOS GenerateRecipeResult(ITEMPOS RecipePos, ref int result_f, [MarshalAs(UnmanagedType.U1)] bool bRandomItem)
	{
		List<int> list = null;
		list = new List<int>();
		TryGetSimilarFields(RecipePos.int_0, Class16.smethod_0(1648951942), ref list);
		List<int> list2 = new List<int>(list.Count);
		List<float> list3 = new List<float>(list.Count);
		float num = 0f;
		int num2 = 0;
		if (0 < list.Count)
		{
			do
			{
				int int_ = list[num2];
				int valueI = GetValueI(RecipePos, int_);
				float valueF = GetValueF(RecipePos, string.Format(Class16.smethod_0(1648951349), num2 + 1));
				list2.Add(valueI);
				list3.Add(valueF);
				num = (float)((double)valueF + (double)num);
				num2++;
			}
			while (num2 < list.Count);
		}
		if (list2.Count == 0)
		{
			GC.KeepAlive(this);
			return null;
		}
		if (list3.Sum() < 0f)
		{
			GC.KeepAlive(this);
			return null;
		}
		int num4;
		if (bRandomItem && Math.Abs((float)(1.0 - (double)num)) < 0.01f)
		{
			int num3 = 0;
			if (!TestProbability(list3[0]))
			{
				do
				{
					num3++;
					num3 = ((num3 != list.Count) ? num3 : 0);
				}
				while (!TestProbability(list3[num3]));
			}
			num4 = num3;
		}
		else
		{
			num4 = ACE.RSGlobal.RSGlobal.GetMaxValueIndex(list3.ToArray());
			if (list2[num4] == 0)
			{
				int num5 = 0;
				if (0 < list2.Count)
				{
					do
					{
						if (list2[num5] <= 0)
						{
							num5++;
							continue;
						}
						num4 = num5;
						break;
					}
					while (num5 < list2.Count);
				}
				num4 = ((list2[num4] != 0) ? num4 : 0);
			}
		}
		int id = list2[num4];
		result_f = list[num4];
		GC.KeepAlive(this);
		return FindItemPos(MattersLists, id);
	}

	public Color GetDyeColor(ITEMPOS ItemPos)
	{
		Color result = ACE.RSGlobal.RSGlobal.ColorFromHSV(new HSV
		{
			Hue = GetMinMaxRangeF(ItemPos, Class16.smethod_0(1648951371), Class16.smethod_0(1648951391)),
			Saturation = GetMinMaxRangeF(ItemPos, Class16.smethod_0(1648951395), Class16.smethod_0(1648951415)),
			Brightness = GetMinMaxRangeF(ItemPos, Class16.smethod_0(1648951419), Class16.smethod_0(1648951439))
		});
		GC.KeepAlive(this);
		return result;
	}

	public static object[] ConvertItem(ACE.Elements.eList.eList DestList, string[] SourceFields, string[] SourceTypes, object[] item, [MarshalAs(UnmanagedType.U1)] bool IsDifferentList, HashSet<int> AddonIDs)
	{
		string[] elementFields = DestList.elementFields;
		string[] elementTypes = DestList.elementTypes;
		if (ACE.RSGlobal.RSGlobal.IsArraysEquals(elementFields, SourceFields))
		{
			return ACE.RSGlobal.RSGlobal.CloneArray(item);
		}
		object[] defaultItem = GetDefaultItem(DestList);
		if (SourceFields.Length == SourceTypes.Length && item.Length >= SourceFields.Length)
		{
			for (int i = 0; i < (nint)elementFields.LongLength; i++)
			{
				string text = elementFields[i];
				int num = Array.IndexOf(SourceFields, text);
				if (num <= -1 || (IsDifferentList && (text == Class16.smethod_0(1648956099) || text == Class16.smethod_0(1648960536) || text == Class16.smethod_0(1648960564))))
				{
					continue;
				}
				if (SourceTypes[num] == elementTypes[i])
				{
					defaultItem[i] = item[num];
				}
				else
				{
					try
					{
						string value = ACE.Elements.eList.eList.GetValue(item[num], SourceTypes[num], roundTrip: true);
						defaultItem[i] = DeserializeValue(value, elementTypes[i]);
					}
					catch (Exception ex)
					{
						SentryHelper.CaptureException(ex, Class16.smethod_0(1648951582));
						object[] vars = new object[2] { text, ex.Message };
						CStorage.Alert(946, vars);
					}
				}
				if (DestList.Game != GAMES.PW || i < 0)
				{
					continue;
				}
				FIELDTYPE[] fieldtypes = DestList.fieldtypes;
				if (fieldtypes == null)
				{
					continue;
				}
				FIELDTYPE fIELDTYPE = fieldtypes[i];
				if (fIELDTYPE == FIELDTYPE.equip_addon)
				{
					uint num2 = ((!(defaultItem[i].GetType() == typeof(int))) ? ((uint)defaultItem[i]) : ((uint)(int)defaultItem[i]));
					if ((int)num2 > 0 && !AddonIDs.Contains((int)num2))
					{
						defaultItem[i] = ACE.Elements.eList.eList.i0;
					}
				}
			}
			int num3 = (int)((nint)defaultItem.LongLength - 1);
			defaultItem[num3] = new object();
			return defaultItem;
		}
		string message = string.Format(Class16.smethod_0(1648951443), SourceFields.Length, SourceTypes.Length, item.Length);
		SentryHelper.CaptureMessage(message, (SentryLevel)3, Class16.smethod_0(1648951534));
		return defaultItem;
	}

	public static object[] ConvertItem(ACE.Elements.eList.eList SourceList, ACE.Elements.eList.eList DestList, object[] item, HashSet<int> AddonIDs)
	{
		string[] elementTypes = SourceList.elementTypes;
		string[] elementFields = SourceList.elementFields;
		return ConvertItem(DestList, elementFields, elementTypes, item, SourceList.uListName != DestList.uListName, AddonIDs);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public static bool IsConvertable(ACE.Elements.eList.eList DestList, string[] SourceFields, string[] SourceTypes)
	{
		string[] elementFields = DestList.elementFields;
		int num = 0;
		int num2 = 0;
		if (0 < (nint)elementFields.LongLength)
		{
			do
			{
				string value = elementFields[num2];
				if (Array.IndexOf(SourceFields, value) > -1)
				{
					num++;
				}
				num2++;
			}
			while (num2 < (nint)elementFields.LongLength);
		}
		return (double)num / (double)Math.Max(SourceFields.Length, elementFields.Length) >= 0.7;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public static bool IsConvertable(ACE.Elements.eList.eList SourceList, ACE.Elements.eList.eList DestList)
	{
		return IsConvertable(DestList, SourceList.elementFields, SourceList.elementTypes);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsConvertable(ACE_DATA_LIST rdata, int int_0)
	{
		if (int_0 < 0)
		{
			return false;
		}
		if (Lists[int_0].uListName == rdata.ListName)
		{
			GC.KeepAlive(this);
			return false;
		}
		bool result = IsConvertable(Lists[int_0], rdata.elementFields, rdata.elementTypes);
		GC.KeepAlive(this);
		return result;
	}

	public void SaveConfig(string ConfigFile)
	{
		StreamWriter streamWriter = new StreamWriter(ConfigFile, append: false, Encoding.UTF8);
		streamWriter.WriteLine(Lists.Length);
		streamWriter.WriteLine(ConversationListIndex);
		int num = 0;
		if (Lists.Length != 0)
		{
			do
			{
				streamWriter.WriteLine();
				streamWriter.WriteLine(num + Class16.smethod_0(1648942627) + Lists[num].ListName);
				ACE.Elements.eList.eList eList2 = Lists[num];
				string sAutoOffset = eList2.sAutoOffset;
				if (sAutoOffset != null)
				{
					streamWriter.WriteLine(sAutoOffset);
				}
				else
				{
					byte[] listOffsetData = eList2.listOffsetData;
					int value = ((listOffsetData != null) ? listOffsetData.Length : 0);
					streamWriter.WriteLine(value);
				}
				if (num != ConversationListIndex)
				{
					eList2 = Lists[num];
					int num2 = eList2.elementTypes.Length;
					if (eList2.elementFields.Length != num2)
					{
						Array.Resize(ref eList2.elementFields, num2);
					}
					streamWriter.WriteLine(string.Join(Class16.smethod_0(1648898262), Lists[num].elementFields));
					streamWriter.WriteLine(string.Join(Class16.smethod_0(1648898262), Lists[num].elementTypes));
				}
				else
				{
					streamWriter.WriteLine(Class16.smethod_0(1648951608));
					streamWriter.WriteLine(Class16.smethod_0(1648902775));
				}
				num++;
			}
			while (num < Lists.Length);
		}
		streamWriter.Close();
	}

	public void SaveConfig()
	{
		SaveConfig(ConfigPath);
	}

	public static int GetListSize(int int_0, ACE.Elements.eList.eList List, BinaryReader br, GAMES Game, int Version, int ConversationListIndex, [MarshalAs(UnmanagedType.U1)] bool autoSkip, [MarshalAs(UnmanagedType.U1)] bool domesticPW, [MarshalAs(UnmanagedType.U1)] bool isFirstItems)
	{
		long position = br.BaseStream.Position;
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		byte[] array = AutoDetectOffset(br, Game, (short)Version, int_0, List, domesticPW);
		bool flag = ACE.Elements.eList.eList.IsElementsPacked(Game, Version);
		if (array != null)
		{
			num = array.Length;
			if (num == 4 && (Game == GAMES.FW || Game == GAMES.JD))
			{
				num3 = BitConverter.ToInt32(array, 0);
			}
		}
		byte b = ((int_0 != ConversationListIndex) ? ((byte)1) : ((byte)0));
		bool flag2 = b != 0;
		if (b != 0)
		{
			if (flag)
			{
				br.ReadInt32();
				br.ReadInt32();
				int num4 = br.ReadInt32();
				num2 = br.ReadInt32() * num4;
				num += 12;
			}
			else
			{
				if (Game == GAMES.PW && Version >= 191)
				{
					int num5 = ((Version == 1488 || Version >= 30000) ? 1 : 0);
					if ((byte)num5 == 0)
					{
						br.ReadInt32();
						int num6 = br.ReadInt32();
						int num7 = br.ReadInt32();
						if (num6 > 0)
						{
							num2 = num6 * num7;
						}
						num += 8;
						goto IL_0173;
					}
				}
				int num8 = br.ReadInt32();
				if (num8 > 0)
				{
					int listItemSize = ACE.Elements.eList.eList.GetListItemSize(List);
					num2 = listItemSize * num8;
					if (num3 > 0 && listItemSize != num3)
					{
						int num9 = num3 - listItemSize;
						object[] array2 = new object[6] { int_0, List.uListName, listItemSize, num3, num9, null };
						int num10 = Math.Abs(num9) / 4;
						array2[5] = num10;
						TextStorage.TEXTS.ThrowEcxeptionT(858, array2);
					}
				}
			}
		}
		else
		{
			num2 = ACE.Elements.eList.eList.GetConversationListLength(br);
		}
		goto IL_0173;
		IL_0173:
		if (autoSkip)
		{
			br.BaseStream.Position += num2;
		}
		else
		{
			br.BaseStream.Position = position;
		}
		int num11 = (flag2 ? 4 : 0) + num2 + num;
		if (num11 < 0)
		{
			string text = Class16.smethod_0(1648951618);
			throw new ApplicationException(string.Concat(string.Concat(Class16.smethod_0(1648951646) + num11, text), int_0));
		}
		return num11;
	}

	public int GetListSize(int int_0, BinaryReader br, [MarshalAs(UnmanagedType.U1)] bool autoSkip, [MarshalAs(UnmanagedType.U1)] bool domesticPW, [MarshalAs(UnmanagedType.U1)] bool isFirstItems)
	{
		int listSize = GetListSize(int_0, Lists[int_0], br, Game, Version, ConversationListIndex, autoSkip, domesticPW, isFirstItems);
		GC.KeepAlive(this);
		return listSize;
	}

	public int GetListItemSize(int int_0)
	{
		int listItemSize = ACE.Elements.eList.eList.GetListItemSize(Lists[int_0], skipStrings: false);
		GC.KeepAlive(this);
		return listItemSize;
	}

	public float GetValueByFieldNameF(ITEMPOS ItemPos, string FieldName, float DefaultValueIfFieldDontExists)
	{
		object valueO = GetValueO(ItemPos, FieldName);
		if (valueO != null)
		{
			return (float)valueO;
		}
		if (DefaultValueIfFieldDontExists != -1f)
		{
			return DefaultValueIfFieldDontExists;
		}
		object[] vars = new object[1] { FieldName };
		TextStorage.TEXTS.ThrowEcxeptionT(547, vars);
		GC.KeepAlive(this);
		return 0f;
	}

	public float GetValueByFieldNameF(ITEMPOS ItemPos, string FieldName)
	{
		return GetValueByFieldNameF(ItemPos, FieldName, -1f);
	}

	public int GetValueByFieldNameI(ITEMPOS ItemPos, string FieldName, int DefaultValueIfFieldDontExists)
	{
		object valueO = GetValueO(ItemPos, FieldName);
		if (valueO != null)
		{
			if (valueO.GetType() == typeof(int))
			{
				GC.KeepAlive(this);
				return (int)valueO;
			}
			return (int)(uint)valueO;
		}
		if (DefaultValueIfFieldDontExists != -1)
		{
			return DefaultValueIfFieldDontExists;
		}
		object[] vars = new object[1] { FieldName };
		TextStorage.TEXTS.ThrowEcxeptionT(547, vars);
		GC.KeepAlive(this);
		return 0;
	}

	public int GetValueByFieldNameI(ITEMPOS ItemPos, string FieldName)
	{
		return GetValueByFieldNameI(ItemPos, FieldName, -1);
	}

	public FIELDPOS FindFieldPos(ITEMPOS ItemPos, string FieldUName)
	{
		int num = Lists[ItemPos.int_0].get_fields(FieldUName);
		if (num > -1)
		{
			GC.KeepAlive(this);
			return new FIELDPOS(ItemPos, num);
		}
		return null;
	}

	private bool method_36(BinaryReader binaryReader_0, out int int_0, out int int_1, out byte[] byte_0)
	{
		int_0 = 0;
		int_1 = 0;
		byte_0 = null;
		if (Game == GAMES.PW && Signature == 8192 && Version >= 262 && domesticPW)
		{
			if (binaryReader_0 != null && binaryReader_0.BaseStream != null)
			{
				long position = binaryReader_0.BaseStream.Position;
				long length = binaryReader_0.BaseStream.Length;
				long num = length - position;
				if (num < 4L)
				{
					return false;
				}
				int[] array = new int[6] { 0, 4, 8, 12, 16, 20 };
				int[] array2 = array;
				foreach (int num2 in array2)
				{
					long num3 = position + num2;
					if (num3 < 0L || num3 + 4L > length)
					{
						continue;
					}
					binaryReader_0.BaseStream.Position = num3;
					uint num4 = binaryReader_0.ReadUInt32();
					binaryReader_0.BaseStream.Position = num3;
					if (num4 == 0 || num4 > 200000)
					{
						continue;
					}
					try
					{
						int conversationListLength = ACE.Elements.eList.eList.GetConversationListLength(binaryReader_0);
						if (conversationListLength > 0 && num3 + conversationListLength <= length)
						{
							binaryReader_0.BaseStream.Position = num3;
							byte[] array3 = binaryReader_0.ReadBytes(conversationListLength);
							if (array3 != null && array3.Length == conversationListLength)
							{
								int_0 = num2;
								int_1 = conversationListLength;
								byte_0 = array3;
								return true;
							}
						}
					}
					catch (Exception ex)
					{
						SentryHelper.CaptureException(ex, Class16.smethod_0(1648951666));
					}
				}
				binaryReader_0.BaseStream.Position = position;
				return false;
			}
			return false;
		}
		return false;
	}

	private void method_37(byte[] byte_0, int int_0, int int_1)
	{
		if (byte_0 != null && byte_0.Length == int_1 && int_1 > 0)
		{
			int num = Lists.Length;
			Array.Resize(ref Lists, num + 1);
			Lists[num] = new ACE.Elements.eList.eList();
			Lists[num].ListIndex = num;
			Lists[num].ListName = Class16.smethod_0(1648987478);
			Lists[num].uListName = Class16.smethod_0(1648987478);
			Lists[num].listOffsetData = Array.Empty<byte>();
			Lists[num].elementFields = new string[1] { Class16.smethod_0(1648951714) };
			Lists[num].elementTypes = new string[1] { Class16.smethod_0(1648985282) + int_1 };
			Lists[num].elementValues = new object[1][] { new object[1] { byte_0 } };
			ConversationListIndex = num;
			ListCount = Lists.Length;
			FillListsArrays();
		}
	}

	public static GAMES DetectGame(short Version, short Signature, uint TimeStamp)
	{
		if (Signature != 12288 && Signature != 8192)
		{
			int num = ((Version == 1488 || Version >= 30000) ? 1 : 0);
			if ((byte)num == 0)
			{
				if (Signature == 0)
				{
					if (Version > 900)
					{
						return GAMES.ROG;
					}
					if (Version <= 500)
					{
						return GAMES.SW;
					}
					return GAMES.TOS;
				}
				if (TimeStamp != 1298874673 && TimeStamp != 1482259767)
				{
					if (Version > 300)
					{
						return GAMES.FW;
					}
					if (Version == 136 && TimeStamp != 1246505186)
					{
						return GAMES.ESO;
					}
					return GAMES.JD;
				}
				return GAMES.Chibi;
			}
		}
		return GAMES.PW;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsGameAccepted()
	{
		LICENSE_INFO.LICENSES licenses = License.Licenses;
		switch (Game)
		{
		case GAMES.PW:
		{
			int num2 = ((licenses.PW.Elements || licenses.PW.GShop) ? 1 : 0);
			return (byte)num2 != 0;
		}
		case GAMES.FW:
		{
			int num = ((licenses.FW.Elements || licenses.FW.GShop || licenses.FW.NPCGen) ? 1 : 0);
			return (byte)num != 0;
		}
		case GAMES.JD:
			return licenses.JD.Elements;
		case GAMES.ESO:
			return licenses.ESO;
		case GAMES.Chibi:
			return licenses.Chibi;
		case GAMES.SW:
			return licenses.SW;
		default:
			return false;
		case GAMES.ROG:
			return licenses.ttcz;
		case GAMES.TOS:
			return licenses.TOS;
		}
	}

	public string FindConfig2()
	{
		string text = CommonStorage.AParams?.Cfg2DefaultPath;
		bool flag;
		if (!(flag = !string.IsNullOrWhiteSpace(text)) && !string.IsNullOrEmpty(ConfigFile))
		{
			if (ConfigFile.EndsWith(Class16.smethod_0(1648951732), StringComparison.OrdinalIgnoreCase) && File.Exists(ConfigFile))
			{
				return ConfigFile;
			}
			string text2 = ConfigFile + Class16.smethod_0(1648934967);
			if (File.Exists(text2))
			{
				return text2;
			}
		}
		if (!flag)
		{
			return null;
		}
		int version = Version;
		string path = text.Trim();
		if (!Directory.Exists(path))
		{
			return null;
		}
		uint timeStamp = TimeStamp;
		string text3 = Class16.smethod_0(1648923968);
		string[] array = Directory.GetFiles(path, string.Concat(string.Concat(string.Concat(string.Concat(GamePrefix + Class16.smethod_0(1648951736), version), text3), timeStamp), Class16.smethod_0(1648951747)));
		if (array == null || array.Length == 0)
		{
			version = Version;
			if (version > 0)
			{
				do
				{
					array = ((!domesticPW) ? Directory.GetFiles(path, string.Concat(string.Concat(GamePrefix + Class16.smethod_0(1648951736), version), Class16.smethod_0(1648951747))) : Directory.GetFiles(path, string.Concat(string.Concat(GamePrefix + Class16.smethod_0(1648951761), version), Class16.smethod_0(1648951747))));
					if ((nint)array.LongLength > 0)
					{
						break;
					}
					version--;
				}
				while (version > 0);
			}
		}
		if (array != null && array.Length != 0)
		{
			return array[0];
		}
		return null;
	}

	public static void ReadListsAsync(object data)
	{
		ACE.Elements.eList.eList[] array = null;
		object[] array2 = (object[])data;
		BinaryReader binaryReader = (BinaryReader)array2[0];
		GAMES game = (GAMES)(int)array2[1];
		short version = (short)array2[2];
		array = (ACE.Elements.eList.eList[])array2[3];
		int conversationListIndex = (int)array2[4];
		int num = (int)array2[5];
		int num2 = (int)array2[6];
		bool flag = (bool)array2[7];
		int num3 = num;
		int num4 = num + num2;
		if (num < num4)
		{
			do
			{
				ReadList(binaryReader, game, version, num3, ref array, conversationListIndex, bReadOffset: true, flag);
				num3++;
			}
			while (num3 < num4);
		}
		binaryReader.Close();
	}

	public void ReadKnownVersion(BinaryReader br, [MarshalAs(UnmanagedType.U1)] bool isFirstItems)
	{
		if (Game == GAMES.PW && Signature == 8192 && Version >= 262 && domesticPW && ConversationListIndex != 999 && ConversationListIndex >= 0 && ConversationListIndex < ListCount)
		{
			ConversationListIndex = 999;
		}
		int num = 0;
		ACE.Elements.eList.eList[] lists = Lists;
		if (0 < (nint)lists.LongLength)
		{
			do
			{
				if (num != ConversationListIndex)
				{
					ACE.Elements.eList.eList eList2 = lists[num];
					eList2.fieldtypes = new FIELDTYPE[(nint)eList2.elementFields.LongLength];
					method_4(num, bool_1: true);
				}
				ReadList(br, Game, Version, num, ref Lists, ConversationListIndex, bReadOffset: true, domesticPW);
				num++;
				lists = Lists;
			}
			while (num < (nint)lists.LongLength);
		}
		try
		{
			long valueOrDefault = (br?.BaseStream?.Position).GetValueOrDefault();
			(br?.BaseStream?.Length).GetValueOrDefault();
			if (method_36(br, out var int_, out var int_2, out var byte_))
			{
				br.BaseStream.Position = valueOrDefault + int_ + int_2;
				method_37(byte_, int_, int_2);
				br.BaseStream.Position = valueOrDefault + int_ + int_2;
			}
		}
		catch
		{
		}
		GC.KeepAlive(this);
	}

	public void ReadKnownVersionElements2(BinaryReader br, [MarshalAs(UnmanagedType.U1)] bool isFirstItems)
	{
		int num = 0;
		ACE.Elements.eList.eList[] lists = Lists;
		if (0 < (nint)lists.LongLength)
		{
			do
			{
				if (num != ConversationListIndex)
				{
					ACE.Elements.eList.eList eList2 = lists[num];
					eList2.fieldtypes = new FIELDTYPE[(nint)eList2.elementFields.LongLength];
					method_4(num, bool_1: true);
				}
				ReadList(br, Game, Version, num, ref Lists, ConversationListIndex, bReadOffset: true, domesticPW);
				num++;
				lists = Lists;
			}
			while (num < (nint)lists.LongLength);
		}
		GC.KeepAlive(this);
	}

	public static void ReadListParallelFunc(int int_0)
	{
		ACE.Elements.eList.eList[] array = null;
		GAMES game = (GAMES)(int)Bridge[1];
		short version = (short)Bridge[2];
		array = (ACE.Elements.eList.eList[])Bridge[3];
		int conversationListIndex = (int)Bridge[4];
		byte[] buffer = ((byte[][])Bridge[6])[int_0];
		bool flag = (bool)Bridge[7];
		MemoryStream memoryStream = new MemoryStream(buffer);
		BinaryReader binaryReader = new BinaryReader(memoryStream);
		ReadList(binaryReader, game, version, int_0, ref array, conversationListIndex, bReadOffset: true, flag);
		binaryReader.Close();
		memoryStream.Close();
	}

	public void ReadKnownVersionParallel(BinaryReader br, [MarshalAs(UnmanagedType.U1)] bool isFirstItems)
	{
		ACE.Elements.eList.eList[] lists = Lists;
		int num = lists.Length;
		ListOffsetInfo[] array = new ListOffsetInfo[num];
		byte[][] array2 = new byte[num][];
		int num2 = 0;
		if (0 < num)
		{
			ListOffsetInfo listOffsetInfo = default(ListOffsetInfo);
			do
			{
				if (num2 != ConversationListIndex)
				{
					ACE.Elements.eList.eList eList2 = lists[num2];
					eList2.fieldtypes = new FIELDTYPE[(nint)eList2.elementFields.LongLength];
					method_4(num2, bool_1: true);
				}
				int listSize = GetListSize(num2, br, autoSkip: false, domesticPW, isFirstItems);
				listOffsetInfo.ListOffset = (int)br.BaseStream.Position;
				listOffsetInfo.ListSize = listSize;
				array[num2] = listOffsetInfo;
				array2[num2] = br.ReadBytes(array[num2].ListSize);
				num2++;
				lists = Lists;
			}
			while (num2 < (nint)lists.LongLength);
		}
		Bridge = new object[8]
		{
			br,
			(int)Game,
			Version,
			Lists,
			ConversationListIndex,
			array,
			array2,
			domesticPW
		};
		Action<int> body = ReadListParallelFunc;
		Parallel.For(0, Lists.Length, body);
		Bridge = null;
		GC.KeepAlive(this);
	}

	public void ReadKnownVersionMultiThread(BinaryReader br, [MarshalAs(UnmanagedType.U1)] bool isFirstItems)
	{
		int num = 0;
		ACE.Elements.eList.eList[] lists = Lists;
		if (0 < (nint)lists.LongLength)
		{
			do
			{
				if (num != ConversationListIndex)
				{
					ACE.Elements.eList.eList eList2 = lists[num];
					eList2.fieldtypes = new FIELDTYPE[(nint)eList2.elementFields.LongLength];
					method_4(num, bool_1: true);
				}
				num++;
				lists = Lists;
			}
			while (num < (nint)lists.LongLength);
		}
		long position = br.BaseStream.Position;
		int num2 = (int)((nint)Lists.LongLength / 3);
		int num3 = num2;
		int num4 = num2;
		int num5 = 0;
		int num6 = 0;
		if (0 < num3)
		{
			do
			{
				num5 = GetListSize(num6, br, autoSkip: true, domesticPW, isFirstItems) + num5;
				num6++;
			}
			while (num6 < num3);
		}
		int num7 = 0;
		int num8 = num3;
		if (num3 < num3 + num4)
		{
			do
			{
				num7 = GetListSize(num8, br, autoSkip: true, domesticPW, isFirstItems) + num7;
				num8++;
			}
			while (num8 < num3 + num4);
		}
		br.BaseStream.Position = position;
		BinaryReader binaryReader = new BinaryReader(new MemoryStream(br.ReadBytes(num5)));
		Thread thread = new Thread(ReadListsAsync);
		thread.Start(new object[8]
		{
			binaryReader,
			(int)Game,
			Version,
			Lists,
			ConversationListIndex,
			0,
			num3,
			domesticPW
		});
		BinaryReader binaryReader2 = new BinaryReader(new MemoryStream(br.ReadBytes(num7)));
		Thread thread2 = new Thread(ReadListsAsync);
		thread2.Start(new object[8]
		{
			binaryReader2,
			(int)Game,
			Version,
			Lists,
			ConversationListIndex,
			num3,
			num4,
			domesticPW
		});
		int num9 = num3 + num4;
		if (num9 < (nint)Lists.LongLength)
		{
			do
			{
				ReadList(br, Game, Version, num9, ref Lists, ConversationListIndex, bReadOffset: true, domesticPW);
				num9++;
			}
			while (num9 < (nint)Lists.LongLength);
		}
		thread.Join();
		thread2.Join();
		GC.KeepAlive(this);
	}

	public void TryReadUnknownVersion(BinaryReader br)
	{
		StructChangedLists = new List<int>();
		string text = Class16.smethod_0(1648951776);
		string gamePrefix = GamePrefix;
		string text2 = Class16.smethod_0(1648952491);
		string text3 = string.Concat(string.Concat(Application.StartupPath + text2, gamePrefix), text);
		eListCollection eListCollection2 = null;
		if (File.Exists(text3))
		{
			eListCollection2 = new eListCollection(text3, bMultithread: false, isFirstItems: true);
		}
		for (int num = 0; num < (nint)Lists.LongLength; num++)
		{
			Application.DoEvents();
			ACE.Elements.eList.eList obj = Lists[num];
			object obj2;
			if (obj == null)
			{
				obj2 = null;
			}
			else
			{
				obj2 = obj.uListName;
				if (obj2 != null)
				{
					goto IL_00a8;
				}
			}
			ACE.Elements.eList.eList obj3 = Lists[num];
			if (obj3 == null)
			{
				obj2 = null;
			}
			else
			{
				obj2 = obj3.ListName;
				if (obj2 != null)
				{
					goto IL_00a8;
				}
			}
			obj2 = string.Empty;
			goto IL_00a8;
			IL_00a8:
			if (num != ConversationListIndex)
			{
				try
				{
					_ = Lists[num].elementTypes?.LongLength;
					ACE.Elements.eList.eList.GetListItemSize(Lists[num], skipStrings: false);
				}
				catch
				{
				}
			}
			long position = br.BaseStream.Position;
			try
			{
				if (num != ConversationListIndex)
				{
					goto IL_0128;
				}
				try
				{
					ReadList(br, Game, Version, num, ref Lists, ConversationListIndex, bReadOffset: true, domesticPW);
				}
				catch
				{
					br.BaseStream.Position = position;
					goto IL_0128;
				}
				goto end_IL_00e4;
				IL_0237:
				Lists[num].UpdateIDs();
				ACE.Elements.eList.eList eList2 = Lists[num];
				FIELDTYPE[] fieldtypes = eList2.fieldtypes;
				if (fieldtypes == null || (nint)fieldtypes.LongLength != (nint)eList2.elementTypes.LongLength)
				{
					ACE.Elements.eList.eList eList3 = eList2;
					eList3.fieldtypes = new FIELDTYPE[(nint)eList3.elementFields.LongLength];
					byte b = ((!StructChangedLists.Contains(num)) ? ((byte)1) : ((byte)0));
					method_4(num, b != 0);
				}
				_ = Lists[num].elementTypes?.LongLength;
				try
				{
					ACE.Elements.eList.eList.GetListItemSize(Lists[num], skipStrings: false);
				}
				catch
				{
				}
				goto end_IL_00e4;
				IL_0128:
				if (Game == GAMES.PW)
				{
					eList2 = Lists[num];
					ACE.Elements.eList.eList eList4 = eList2;
					eList4.fieldtypes = new FIELDTYPE[(nint)eList4.elementFields.LongLength];
					method_4(num, bool_1: true);
				}
				if (eListCollection2 != null)
				{
					if (isPacked || !method_16(br, num, eListCollection2))
					{
						Lists[num].bListStructChanged = true;
						if (Game != GAMES.PW)
						{
							goto IL_01ca;
						}
						short version = Version;
						if (version >= 191)
						{
							int num2 = version;
							int num3 = ((num2 == 1488 || num2 >= 30000) ? 1 : 0);
							if ((byte)num3 == 0)
							{
								goto IL_01ca;
							}
						}
						method_14(br, num);
					}
				}
				else if (Game != GAMES.PW)
				{
					method_18(br, num);
				}
				else
				{
					short version2 = Version;
					if (version2 >= 191)
					{
						int num4 = version2;
						int num5 = ((num4 == 1488 || num4 >= 30000) ? 1 : 0);
						if ((byte)num5 == 0)
						{
							method_18(br, num);
						}
						else
						{
							method_14(br, num);
						}
					}
					else
					{
						method_14(br, num);
					}
				}
				goto IL_0237;
				IL_01ca:
				method_18(br, num);
				goto IL_0237;
				end_IL_00e4:;
			}
			catch (Exception ex)
			{
				if (!(ex is EndOfStreamException))
				{
					SentryHelper.CaptureException(ex, Class16.smethod_0(1648951807));
				}
				if (!ACE.RSGlobal.RSGlobal.ELEMENTS_DEBUG)
				{
					object[] vars = new object[3]
					{
						num,
						br.BaseStream.Position,
						ex.Message
					};
					TextStorage.TEXTS.ShowMessage(183, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, vars);
				}
				br.BaseStream.Position = position;
				Array.Resize(newSize: ListCount = Math.Max(0, num - 1), array: ref Lists);
				FillListsArrays();
				bLoadedWithErrors = true;
				break;
			}
		}
	}

	public static void ReadList(BinaryReader br, GAMES Game, short Version, int int_0, ref ACE.Elements.eList.eList[] Li, int ConversationListIndex, [MarshalAs(UnmanagedType.U1)] bool bReadOffset, [MarshalAs(UnmanagedType.U1)] bool domesticPW)
	{
		if (bReadOffset && Version != 32222)
		{
			Li[int_0].listOffsetData = AutoDetectOffset(br, Game, Version, int_0, Li[int_0], domesticPW);
		}
		ACE.Elements.eList.eList.ReadList(br, int_0, ref Li, ConversationListIndex, Game, Version);
	}

	public int[] GetLists([MarshalAs(UnmanagedType.U1)] bool bIncludeConversations)
	{
		if (bIncludeConversations)
		{
			return AllListsAndCoversations;
		}
		return AllLists;
	}

	public int[] GetLists(ItemType item_type)
	{
		switch (item_type)
		{
		default:
		{
			int startIndex = GamePrefix.Length + 1;
			string lIST_NAME = Enum.GetName(typeof(ItemType), item_type).Substring(startIndex);
			int[] result = INTARRFAST.SetInt(this.get_LI(lIST_NAME));
			GC.KeepAlive(this);
			return result;
		}
		case ItemType.All:
			return AllLists;
		case ItemType.Matter:
			return MattersLists;
		case ItemType.NpcOrMobOrMine:
			return NpcMobMineLists;
		}
	}

	public unsafe void GenerateItemOctets(ITEMPOS ItemPos, ITEMOCTETS* ItemOctets)
	{
		string text = null;
		bDontWriteOctets = false;
		ACE.Classes.ITEMDATA iTEMDATA = default(ACE.Classes.ITEMDATA);
		ACE.RSGlobal.RSGlobal.ITEMDATA(&iTEMDATA);
		text = null;
		GenerateXML(ItemPos, 1, string.Empty, &iTEMDATA, ref text);
		*(int*)ItemOctets = System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref iTEMDATA, new IntPtr(1016)));
		((int*)ItemOctets)[1] = System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref iTEMDATA, new IntPtr(1008)));
		((int*)ItemOctets)[2] = System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref iTEMDATA, new IntPtr(1012)));
		((int*)ItemOctets)[3] = System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref iTEMDATA, new IntPtr(1020)));
		System.Runtime.CompilerServices.Unsafe.CopyBlock(ref System.Runtime.CompilerServices.Unsafe.AsRef<byte>((void*)((byte*)ItemOctets + 16)), ref System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, byte>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref iTEMDATA, new IntPtr(1024))), (uint)System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, int>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref iTEMDATA, new IntPtr(1020))));
	}

	public unsafe ITEMOCTETS* GenerateItemOctets(ITEMOCTETS* pItemoctets_0, ITEMPOS ItemPos)
	{
		bDontWriteOctets = false;
		System.Runtime.CompilerServices.Unsafe.InitBlock((void*)pItemoctets_0, (byte)0, 1556u);
		GenerateItemOctets(ItemPos, pItemoctets_0);
		return pItemoctets_0;
	}

	public string GeneratePaintNumDesc(string sNum)
	{
		if (!string.IsNullOrWhiteSpace(sNum) && ACE.RSGlobal.RSGlobal.IsUIntFast(sNum))
		{
			if (sNum == Class16.smethod_0(1648924112))
			{
				string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1648954915));
				GC.KeepAlive(this);
				return text;
			}
			string s = sNum.Substring(sNum.Length - 1);
			int result = 0;
			int.TryParse(s, out result);
			int num = result;
			if (sNum.Length >= 2)
			{
				string s2 = sNum.Substring(sNum.Length - 2);
				int result2 = 0;
				int.TryParse(s2, out result2);
				num = result2;
			}
			string text2 = ((result == 1) ? TextStorage.TEXTS.GetText(Class16.smethod_0(1648954984)) : ((result == 0 || (num > 9 && num < 21) || (result >= 5 && result <= 9)) ? TextStorage.TEXTS.GetText(Class16.smethod_0(1648954961)) : TextStorage.TEXTS.GetText(Class16.smethod_0(1648954938))));
			object[] vars = new object[2] { sNum, text2 };
			string text3 = TextStorage.TEXTS.GetText(Class16.smethod_0(1648955015), vars);
			GC.KeepAlive(this);
			return text3;
		}
		GC.KeepAlive(this);
		return string.Empty;
	}

	public void ResetCachedList(int int_0)
	{
		if (int_0 == ConversationListIndex)
		{
			return;
		}
		switch (int_0)
		{
		default:
		{
			Dictionary<int, ITEMINFO> dictionary = ItemsCache[int_0];
			if (dictionary != null)
			{
				dictionary.Clear();
				ItemsCache[int_0] = null;
			}
			Lists[int_0].UpdateIDs();
			break;
		}
		case 16777215:
			ResetCachedLists();
			break;
		case 8388607:
		{
			int[] mattersLists = MattersLists;
			int num = 0;
			if (0 < (nint)mattersLists.LongLength)
			{
				do
				{
					ResetCachedList(mattersLists[num]);
					num++;
				}
				while (num < (nint)mattersLists.LongLength);
			}
			break;
		}
		}
		GC.KeepAlive(this);
	}

	public void ResetCachedLists()
	{
		Array itemsCache = ItemsCache;
		if (itemsCache != null)
		{
			Array.Clear(itemsCache, 0, itemsCache.Length);
		}
		ItemsCache = new Dictionary<int, ITEMINFO>[(nint)Lists.LongLength];
		int[] allLists = AllLists;
		int num = 0;
		if (0 < (nint)allLists.LongLength)
		{
			do
			{
				Lists[allLists[num]].UpdateIDs();
				num++;
			}
			while (num < (nint)allLists.LongLength);
		}
		GC.KeepAlive(this);
	}

	public void ResetCachedItem(int int_0, int int_1)
	{
		ItemsCache[int_0]?.Remove(int_1);
		GC.KeepAlive(this);
	}

	public void SortItemsByFieldValue(int int_0, int[] itemsindicies, int int_1, [MarshalAs(UnmanagedType.U1)] bool bDesc)
	{
		object obj = null;
		string type = Lists[int_0].elementTypes[int_1];
		int num = 1;
		num = (bDesc ? (-1) : num);
		ActionsHistory.stChangeItems(int_0, itemsindicies, null, null, 394);
		object[] captionVars = new object[1] { GetItemID(int_0, itemsindicies[0]) };
		ActionsHistory.Stage.CaptionVars = captionVars;
		int num2 = 0;
		int num3 = itemsindicies.Length;
		if (0 < num3)
		{
			do
			{
				int num4 = itemsindicies[num2];
				object obj2 = null;
				int num5 = num4;
				int num6 = num2;
				if (num2 < num3)
				{
					do
					{
						int num7 = itemsindicies[num6];
						obj = null;
						if (CompareValues(obj2, int_0, num7, int_1, type, ref obj) == num || obj2 == null)
						{
							obj2 = obj;
							num5 = num7;
						}
						num6++;
					}
					while (num6 < (nint)itemsindicies.LongLength);
				}
				ItemChanged(int_0, num4);
				if (num4 != num5)
				{
					object[][] elementValues = Lists[int_0].elementValues;
					object[] array = elementValues[num4];
					elementValues[num4] = elementValues[num5];
					Lists[int_0].elementValues[num5] = array;
				}
				num2++;
				num3 = itemsindicies.Length;
			}
			while (num2 < num3);
		}
		ActionsHistory.Complete();
		Lists[int_0].UpdateIDs();
		GC.KeepAlive(this);
	}

	public int CompareValues(object val1, int int_0, int int_1, int int_2, string type, ref object val2)
	{
		int num = 0;
		ulong num2 = 0uL;
		ulong num3 = 0uL;
		val2 = Lists[int_0].elementValues[int_1][int_2];
		if (!(type == Class16.smethod_0(1648989776)))
		{
			if (!(type == Class16.smethod_0(1648902744)))
			{
				if (!(type == Class16.smethod_0(1648989786)))
				{
					if (!(type == Class16.smethod_0(1648989830)))
					{
						if (!(type == Class16.smethod_0(1648989834)))
						{
							string string_ = (string)(val2 = Lists[int_0].GetValue(int_1, int_2));
							if (val1 != null)
							{
								num = ACE.RSGlobal.RSGlobal.StrCmpLogicalW((string)val1, string_);
							}
						}
						else if (val1 != null)
						{
							num = ((ulong)val1).CompareTo((ulong)val2);
						}
					}
					else if (val1 != null)
					{
						num = ((long)val1).CompareTo((long)val2);
					}
				}
				else if (val1 != null)
				{
					num = ((uint)val1).CompareTo((uint)val2);
					num2 = (uint)val1;
					num3 = (uint)val2;
				}
			}
			else if (val1 != null)
			{
				num = ((float)val1).CompareTo((float)val2);
			}
		}
		else if (val1 != null)
		{
			num = ((int)val1).CompareTo((int)val2);
			num2 = (ulong)(int)val1;
			num3 = (ulong)(int)val2;
		}
		if ((uint)(GetFieldType(int_0, int_1, int_2) - 58) <= 20u && num2 > 0L && num3 > 0L && num2 != num3)
		{
			bool flag = ACE.RSGlobal.RSGlobal.IsOneBit(num2);
			bool flag2 = ACE.RSGlobal.RSGlobal.IsOneBit(num3);
			if (flag)
			{
				if (!flag2)
				{
					num = -1;
				}
			}
			else
			{
				num = (flag2 ? 1 : num);
			}
		}
		int result = Math.Sign(num);
		GC.KeepAlive(this);
		return result;
	}

	public void SortItemsByID(int int_0, int[] itemsindicies)
	{
		ActionsHistory.stChangeItems(int_0, itemsindicies, null, null, 394);
		object[] captionVars = new object[1] { GetItemID(int_0, itemsindicies[0]) };
		ActionsHistory.Stage.CaptionVars = captionVars;
		int num = 0;
		if (0 < (nint)itemsindicies.LongLength)
		{
			do
			{
				int num2 = itemsindicies[num];
				if (ItemsCache[int_0].ContainsKey(num2))
				{
					ItemsCache[int_0].Remove(num2);
				}
				int num3 = Lists[int_0].getid(num2);
				GC.KeepAlive(this);
				int num4 = num3;
				int num5 = num2;
				int num6 = num + 1;
				if (num + 1 < (nint)itemsindicies.LongLength)
				{
					do
					{
						int num7 = itemsindicies[num6];
						int num8 = Lists[int_0].getid(num7);
						GC.KeepAlive(this);
						if (num8 < num4)
						{
							num4 = num8;
							num5 = num7;
						}
						num6++;
					}
					while (num6 < (nint)itemsindicies.LongLength);
				}
				ItemChanged(int_0, num2);
				if (num2 != num5)
				{
					object[][] elementValues = Lists[int_0].elementValues;
					object[] array = elementValues[num2];
					elementValues[num2] = elementValues[num5];
					Lists[int_0].elementValues[num5] = array;
				}
				num++;
			}
			while (num < (nint)itemsindicies.LongLength);
		}
		ActionsHistory.Complete();
		GC.KeepAlive(this);
	}

	public void SortItemsByID_desc(int int_0, int[] itemsindicies)
	{
		ActionsHistory.stChangeItems(int_0, itemsindicies, null, null, 395);
		object[] captionVars = new object[1] { GetItemID(int_0, itemsindicies[0]) };
		ActionsHistory.Stage.CaptionVars = captionVars;
		int num = 0;
		if (0 < (nint)itemsindicies.LongLength)
		{
			do
			{
				int num2 = itemsindicies[num];
				if (ItemsCache[int_0].ContainsKey(num2))
				{
					ItemsCache[int_0].Remove(num2);
				}
				object obj = null;
				int num3 = 0;
				int num4 = num;
				if (num < (nint)itemsindicies.LongLength)
				{
					do
					{
						int num5 = itemsindicies[num4];
						int num6 = Lists[int_0].getid(num5);
						GC.KeepAlive(this);
						if (obj == null || num6 > (int)obj)
						{
							obj = num6;
							num3 = num5;
						}
						num4++;
					}
					while (num4 < (nint)itemsindicies.LongLength);
				}
				ItemChanged(int_0, num3);
				object[][] elementValues = Lists[int_0].elementValues;
				object[] array = elementValues[num2];
				elementValues[num2] = elementValues[num3];
				Lists[int_0].elementValues[num3] = array;
				num++;
			}
			while (num < (nint)itemsindicies.LongLength);
		}
		ActionsHistory.Complete();
		GC.KeepAlive(this);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool CompareWithIntOrUintValue(int val, int int_0, int int_1, int int_2)
	{
		string text = Lists[int_0].elementTypes[int_2];
		if (text[0] == 'i')
		{
			GC.KeepAlive(this);
			return val == (int)Lists[int_0].elementValues[int_1][int_2];
		}
		if (text[0] == 'u')
		{
			GC.KeepAlive(this);
			return val == (int)(uint)Lists[int_0].elementValues[int_1][int_2];
		}
		return false;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsMattersField(int int_0, int int_1, int int_2)
	{
		FIELDTYPE fieldType = GetFieldType(int_0, int_1, int_2);
		if (fieldType == FIELDTYPE.matters || fieldType == FIELDTYPE.complect_equip)
		{
			goto IL_0051;
		}
		if (fieldType == FIELDTYPE.custom_list)
		{
			int[] fieldLists = GetFieldLists(int_0, int_1, int_2);
			bool flag = fieldLists != null && fieldLists.Length != 0 && MattersListsFast != null && MattersListsFast.Contains(fieldLists[0]);
			GC.KeepAlive(this);
			if (flag)
			{
				goto IL_0051;
			}
		}
		int num = 0;
		goto IL_0053;
		IL_0053:
		return (byte)num != 0;
		IL_0051:
		num = 1;
		goto IL_0053;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsAnyListInField(int int_0, int int_1, int int_2)
	{
		FIELDTYPE fieldType = GetFieldType(int_0, int_1, int_2);
		int num = (((fieldType >= FIELDTYPE.matters && fieldType <= FIELDTYPE.any_list) || fieldType == FIELDTYPE.equip_addon || fieldType == FIELDTYPE.refine_addon_pw) ? 1 : 0);
		GC.KeepAlive(this);
		return (byte)num != 0;
	}

	public static void RebuildAllConfigs(GAMES Game)
	{
		string text = ((LANG_INFO.CurrentLang == null) ? Class16.smethod_0(1648931959) : LANG_INFO.CurrentLang.Prefix);
		string text2 = Class16.smethod_0(1648955038);
		string text3 = Class16.smethod_0(1648960967);
		string[] files = Directory.GetFiles(string.Concat(Application.StartupPath + text3, text), ACE.RSGlobal.RSGlobal.GetGamePrefix(Game) + text2);
		eListCollection eListCollection2 = new eListCollection(Game);
		int num = 0;
		if (0 >= (nint)files.LongLength)
		{
			return;
		}
		do
		{
			string path = files[num];
			eListCollection2.LoadConfig(new StreamReader(path), null, null, null, null, bSetMainFieldsTypes: false);
			if (Game == GAMES.PW)
			{
				short version = eListCollection2.Version;
				if (version <= 12)
				{
					string text4 = Class16.smethod_0(1648989786);
					eListCollection2[Class16.smethod_0(1648960167)].elementTypes[37] = text4;
				}
				else if (version >= 136)
				{
					string text5 = Class16.smethod_0(1648989786);
					eListCollection2[Class16.smethod_0(1648960167)].elementTypes[39] = text5;
				}
				else
				{
					string text6 = Class16.smethod_0(1648989786);
					eListCollection2[Class16.smethod_0(1648960167)].elementTypes[38] = text6;
				}
			}
			num++;
		}
		while (num < (nint)files.LongLength);
	}

	public int[] GetProbFieldsSuite(int int_0, int int_1, ref int index)
	{
		GetProbFieldsSuites();
		if (ProbFieldsSuites.ContainsKey(int_0))
		{
			List<int[]>.Enumerator enumerator = ProbFieldsSuites[int_0].GetEnumerator();
			if (enumerator.MoveNext())
			{
				do
				{
					int[] current = enumerator.Current;
					if ((index = Array.IndexOf(current, int_1)) > -1)
					{
						GC.KeepAlive(this);
						return current;
					}
				}
				while (enumerator.MoveNext());
			}
		}
		return null;
	}

	public Dictionary<int, List<int[]>> GetProbFieldsSuites()
	{
		Dictionary<int, List<int[]>> probFieldsSuites = ProbFieldsSuites;
		if (probFieldsSuites != null)
		{
			return probFieldsSuites;
		}
		ProbSuitesNames = new Dictionary<int, List<string>>();
		ProbFieldsSuites = new Dictionary<int, List<int[]>>();
		if (Game == GAMES.PW)
		{
			int num = this.get_LI(Class16.smethod_0(1648923245));
			ProbFieldsSuites.Add(num, new List<int[]>());
			List<int[]> list = ProbFieldsSuites[num];
			int endval = Lists[num].get_fields(Class16.smethod_0(1648955054));
			int[] item = ACE.RSGlobal.RSGlobal.IntArray(Lists[num].get_fields(Class16.smethod_0(1648955085)), endval, 1);
			list.Add(item);
			endval = Lists[num].get_fields(Class16.smethod_0(1648957267));
			item = ACE.RSGlobal.RSGlobal.IntArray(Lists[num].get_fields(Class16.smethod_0(1648957213)), endval, 1);
			list.Add(item);
			string name = Class16.smethod_0(1648919679);
			if (Lists[num].get_fields(Class16.smethod_0(1648923022)) > -1)
			{
				name = Class16.smethod_0(1648923022);
			}
			else if (Lists[num].get_fields(Class16.smethod_0(1648922985)) > -1)
			{
				name = Class16.smethod_0(1648922985);
			}
			int endval2 = Lists[num].get_fields(name);
			int[] item2 = ACE.RSGlobal.RSGlobal.IntArray(Lists[num].get_fields(Class16.smethod_0(1648919584)), endval2, 1);
			list.Add(item2);
			string name2 = Class16.smethod_0(1648955116);
			ACE.Elements.eList.eList eList2 = Lists[num];
			string name3 = Class16.smethod_0(1648955150);
			ACE.Elements.eList.eList eList3 = Lists[num];
			list.Add(ACE.RSGlobal.RSGlobal.IntArray(eList3.get_fields(name3), eList2.get_fields(name2), 2));
			name3 = Class16.smethod_0(1648957423);
			eList3 = Lists[num];
			name2 = Class16.smethod_0(1648955183);
			eList2 = Lists[num];
			list.Add(ACE.RSGlobal.RSGlobal.IntArray(eList2.get_fields(name2), eList3.get_fields(name3), 2));
			name3 = Class16.smethod_0(1648955214);
			eList3 = Lists[num];
			name2 = Class16.smethod_0(1648955242);
			eList2 = Lists[num];
			list.Add(ACE.RSGlobal.RSGlobal.IntArray(eList2.get_fields(name2), eList3.get_fields(name3), 2));
			if (Lists[num].get_fields(Class16.smethod_0(1648955285)) > -1)
			{
				name3 = Class16.smethod_0(1648955316);
				eList3 = Lists[num];
				name2 = Class16.smethod_0(1648955285);
				eList2 = Lists[num];
				list.Add(ACE.RSGlobal.RSGlobal.IntArray(eList2.get_fields(name2), eList3.get_fields(name3), 2));
			}
			int num2 = this.get_LI(Class16.smethod_0(1648923258));
			ProbFieldsSuites.Add(num2, new List<int[]>());
			List<int[]> list2 = ProbFieldsSuites[num2];
			int endval3 = Lists[num2].get_fields(Class16.smethod_0(1648955348));
			int[] item3 = ACE.RSGlobal.RSGlobal.IntArray(Lists[num2].get_fields(Class16.smethod_0(1648955085)), endval3, 1);
			list2.Add(item3);
			endval3 = Lists[num2].get_fields(Class16.smethod_0(1648957329));
			item3 = ACE.RSGlobal.RSGlobal.IntArray(Lists[num2].get_fields(Class16.smethod_0(1648957213)), endval3, 1);
			list2.Add(item3);
			string name4 = Class16.smethod_0(1648919679);
			if (Lists[num2].get_fields(Class16.smethod_0(1648922985)) > -1)
			{
				name4 = Class16.smethod_0(1648922985);
			}
			endval3 = Lists[num2].get_fields(name4);
			item3 = ACE.RSGlobal.RSGlobal.IntArray(Lists[num2].get_fields(Class16.smethod_0(1648919584)), endval3, 1);
			list2.Add(item3);
			name4 = Class16.smethod_0(1648955116);
			ACE.Elements.eList.eList eList4 = Lists[num2];
			string name5 = Class16.smethod_0(1648955150);
			ACE.Elements.eList.eList eList5 = Lists[num2];
			list2.Add(ACE.RSGlobal.RSGlobal.IntArray(eList5.get_fields(name5), eList4.get_fields(name4), 2));
			name4 = Class16.smethod_0(1648957423);
			eList4 = Lists[num2];
			name5 = Class16.smethod_0(1648955183);
			eList5 = Lists[num2];
			list2.Add(ACE.RSGlobal.RSGlobal.IntArray(eList5.get_fields(name5), eList4.get_fields(name4), 2));
			int num3 = this.get_LI(Class16.smethod_0(1648923366));
			ProbFieldsSuites.Add(num3, new List<int[]>());
			List<int[]> list3 = ProbFieldsSuites[num3];
			name4 = Class16.smethod_0(1648919679);
			if (Lists[num3].get_fields(Class16.smethod_0(1648922985)) > -1)
			{
				name4 = Class16.smethod_0(1648922985);
			}
			int endval4 = Lists[num3].get_fields(name4);
			int[] item4 = ACE.RSGlobal.RSGlobal.IntArray(Lists[num3].get_fields(Class16.smethod_0(1648919584)), endval4, 1);
			list3.Add(item4);
			name4 = Class16.smethod_0(1648955116);
			ACE.Elements.eList.eList eList6 = Lists[num3];
			string name6 = Class16.smethod_0(1648955150);
			ACE.Elements.eList.eList eList7 = Lists[num3];
			list3.Add(ACE.RSGlobal.RSGlobal.IntArray(eList7.get_fields(name6), eList6.get_fields(name4), 2));
			name4 = Class16.smethod_0(1648957423);
			eList6 = Lists[num3];
			name6 = Class16.smethod_0(1648955183);
			eList7 = Lists[num3];
			list3.Add(ACE.RSGlobal.RSGlobal.IntArray(eList7.get_fields(name6), eList6.get_fields(name4), 2));
			int num4 = this.get_LI(Class16.smethod_0(1648955371));
			ProbFieldsSuites.Add(num4, new List<int[]>());
			List<int[]> list4 = ProbFieldsSuites[num4];
			name4 = Class16.smethod_0(1648954374);
			eList6 = Lists[num4];
			name6 = Class16.smethod_0(1648955150);
			eList7 = Lists[num4];
			list4.Add(ACE.RSGlobal.RSGlobal.IntArray(eList7.get_fields(name6), eList6.get_fields(name4), 2));
			if (!ProbSuitesNames.ContainsKey(num4))
			{
				ProbSuitesNames.Add(num4, new List<string>());
			}
			name4 = TextStorage.TEXTS.GetText(Class16.smethod_0(1648954400));
			ProbSuitesNames[num4].Add(name4);
			int num5 = this.get_LI(Class16.smethod_0(1648963546));
			ProbFieldsSuites.Add(num5, new List<int[]>());
			List<int[]> list5 = ProbFieldsSuites[num5];
			name4 = Class16.smethod_0(1648954431);
			ACE.Elements.eList.eList eList8 = Lists[num5];
			string name7 = Class16.smethod_0(1648954458);
			ACE.Elements.eList.eList eList9 = Lists[num5];
			list5.Add(ACE.RSGlobal.RSGlobal.IntArray(eList9.get_fields(name7), eList8.get_fields(name4), 2));
			name4 = Class16.smethod_0(1648954501);
			eList8 = Lists[num5];
			name7 = Class16.smethod_0(1648954532);
			eList9 = Lists[num5];
			list5.Add(ACE.RSGlobal.RSGlobal.IntArray(eList9.get_fields(name7), eList8.get_fields(name4), 3));
			name4 = Class16.smethod_0(1648954555);
			eList8 = Lists[num5];
			name7 = Class16.smethod_0(1648954586);
			eList9 = Lists[num5];
			list5.Add(ACE.RSGlobal.RSGlobal.IntArray(eList9.get_fields(name7), eList8.get_fields(name4), 3));
			name4 = Class16.smethod_0(1648954617);
			eList8 = Lists[num5];
			name7 = Class16.smethod_0(1648954648);
			eList9 = Lists[num5];
			list5.Add(ACE.RSGlobal.RSGlobal.IntArray(eList9.get_fields(name7), eList8.get_fields(name4), 3));
			int endval5 = Lists[num5].get_fields(Class16.smethod_0(1648987587));
			int[] item5 = ACE.RSGlobal.RSGlobal.IntArray(Lists[num5].get_fields(Class16.smethod_0(1648987511)), endval5, 1);
			list5.Add(item5);
			name4 = Class16.smethod_0(1648954687);
			eList8 = Lists[num5];
			name7 = Class16.smethod_0(1648986250);
			eList9 = Lists[num5];
			list5.Add(ACE.RSGlobal.RSGlobal.IntArray(eList9.get_fields(name7), eList8.get_fields(name4), 2));
			if (Lists[num5].get_fields(Class16.smethod_0(1648954713)) > -1)
			{
				name4 = Class16.smethod_0(1648954744);
				eList8 = Lists[num5];
				name7 = Class16.smethod_0(1648954713);
				eList9 = Lists[num5];
				list5.Add(ACE.RSGlobal.RSGlobal.IntArray(eList9.get_fields(name7), eList8.get_fields(name4), 3));
			}
			name4 = Class16.smethod_0(1648954783);
			name7 = Class16.smethod_0(1648954803);
			int int_ = this.get_LI(Class16.smethod_0(1648952558));
			AddProbFields(int_, name7, name4, 2, 783, 0);
			int_ = this.get_LI(Class16.smethod_0(1648954839));
			int step = ((Lists[int_].get_fields(Class16.smethod_0(1648954862)) > -1 || Lists[int_].get_fields(Class16.smethod_0(1648953858)) > -1) ? 3 : 2);
			name4 = Class16.smethod_0(1648953899);
			if (Lists[int_].get_fields(Class16.smethod_0(1648953930)) > -1)
			{
				name4 = Class16.smethod_0(1648953930);
			}
			if (Lists[int_].get_fields(Class16.smethod_0(1648953962)) > -1)
			{
				name4 = Class16.smethod_0(1648953962);
			}
			AddProbFields(int_, Class16.smethod_0(1648953994), name4, step, 784, 0);
			int_ = this.get_LI(Class16.smethod_0(1648963535));
			step = ((Lists[int_].get_fields(Class16.smethod_0(1648954025)) > -1) ? 3 : 2);
			AddProbFields(int_, Class16.smethod_0(1648954048), Class16.smethod_0(1648954086), step, 785, 0);
			AddProbFields(int_, Class16.smethod_0(1648986936), Class16.smethod_0(1648986851), 2, 785, 1);
			if (Version <= 12)
			{
				return ProbFieldsSuites;
			}
			string f_last = Class16.smethod_0(1648954117);
			string f_first = Class16.smethod_0(1648954138);
			int_ = this.get_LI(Class16.smethod_0(1648954174));
			AddProbFields(int_, f_first, f_last, 2, 786, 0);
			f_last = Class16.smethod_0(1648954187);
			f_first = Class16.smethod_0(1648954223);
			AddProbFields(this.get_LI(Class16.smethod_0(1648923456)), f_first, f_last, 2, 787, 1);
			f_last = Class16.smethod_0(1648954242);
			f_first = Class16.smethod_0(1648954272);
			AddProbFields(this.get_LI(Class16.smethod_0(1648923456)), f_first, f_last, 1, 787, 0);
			f_last = Class16.smethod_0(1648954310);
			f_first = Class16.smethod_0(1648954329);
			int_ = this.get_LI(Class16.smethod_0(1648954354));
			AddProbFields(int_, f_first, f_last, 2, 788, 0);
			int_ = this.get_LI(Class16.smethod_0(1648953355));
			if (int_ > -1)
			{
				AddProbFields(int_, Class16.smethod_0(1648954329), f_last, 2, 788, 0);
			}
			int_ = this.get_LI(Class16.smethod_0(1648953398));
			if (int_ < 0)
			{
				return ProbFieldsSuites;
			}
			int num6 = 2;
			num6 = ((Lists[int_].get_fields(Class16.smethod_0(1648953421)) > -1) ? 3 : num6);
			AddProbFields(int_, Class16.smethod_0(1648954329), Class16.smethod_0(1648954310), num6, 788, 0);
			string f_last2 = Class16.smethod_0(1648957423);
			string f_first2 = Class16.smethod_0(1648955183);
			int_ = this.get_LI(Class16.smethod_0(1648923432));
			AddProbFields(int_, f_first2, f_last2, 3, 789, 0);
			f_last2 = Class16.smethod_0(1648953432);
			f_first2 = Class16.smethod_0(1648953477);
			int_ = this.get_LI(Class16.smethod_0(1648953506));
			AddProbFields(int_, f_first2, f_last2, 31, 798, 0);
			f_last2 = Class16.smethod_0(1648953550);
			f_first2 = Class16.smethod_0(1648953580);
			int_ = this.get_LI(Class16.smethod_0(1648953601));
			AddProbFields(int_, f_first2, f_last2, 1, 790, 0);
			f_last2 = Class16.smethod_0(1648953655);
			f_first2 = Class16.smethod_0(1648954329);
			int_ = this.get_LI(Class16.smethod_0(1648952704));
			AddProbFields(int_, f_first2, f_last2, 3, 791, 0);
			f_last2 = Class16.smethod_0(1648953673);
			f_first2 = Class16.smethod_0(1648954329);
			int_ = this.get_LI(Class16.smethod_0(1648953708));
			AddProbFields(int_, f_first2, f_last2, 4, 792, 0);
			f_last2 = Class16.smethod_0(1648953736);
			f_first2 = Class16.smethod_0(1648953763);
			int_ = this.get_LI(Class16.smethod_0(1648953797));
			AddProbFields(int_, f_first2, f_last2, 3, 792, 0);
			f_last2 = Class16.smethod_0(1648953837);
			f_first2 = Class16.smethod_0(1649079808);
			AddProbFields(this.get_LI(Class16.smethod_0(1649079834)), f_first2, f_last2, 2, 793, 1);
			f_last2 = Class16.smethod_0(1649079870);
			f_first2 = Class16.smethod_0(1649079890);
			AddProbFields(this.get_LI(Class16.smethod_0(1649079834)), f_first2, f_last2, 1, 793, 0);
			f_last2 = Class16.smethod_0(1649079926);
			f_first2 = Class16.smethod_0(1648954803);
			int_ = this.get_LI(Class16.smethod_0(1649079946));
			AddProbFields(int_, f_first2, f_last2, 3, 783, 0);
			int_ = this.get_LI(Class16.smethod_0(1649079978));
			if (int_ > -1)
			{
				AddProbFields(int_, Class16.smethod_0(1649080010), Class16.smethod_0(1649080054), 3, 783, 0);
			}
			int_ = this.get_LI(Class16.smethod_0(1649080082));
			if (int_ < 0)
			{
				int_ = this.get_LI(Class16.smethod_0(1649080107));
			}
			if (int_ > -1)
			{
				AddProbFields(int_, Class16.smethod_0(1649080141), Class16.smethod_0(1649080166), 2, 788, 0);
			}
			f_last2 = Class16.smethod_0(1649080185);
			f_first2 = Class16.smethod_0(1649080211);
			int_ = this.get_LI(Class16.smethod_0(1649080244));
			AddProbFields(int_, f_first2, f_last2, 3, 792, 0);
			f_last2 = Class16.smethod_0(1648954687);
			f_first2 = Class16.smethod_0(1648986250);
			AddProbFields(this.get_LI(Class16.smethod_0(1649080267)), f_first2, f_last2, 2, 794, 1);
			f_last2 = Class16.smethod_0(1648987587);
			f_first2 = Class16.smethod_0(1648987511);
			AddProbFields(this.get_LI(Class16.smethod_0(1649080267)), f_first2, f_last2, 1, 794, 0);
			int_ = this.get_LI(Class16.smethod_0(1648923096));
			if (int_ > -1)
			{
				ProbFieldsSuites.Add(int_, new List<int[]>());
				List<int[]> list6 = ProbFieldsSuites[int_];
				int endval6 = Lists[int_].get_fields(Class16.smethod_0(1648955348));
				int[] item6 = ACE.RSGlobal.RSGlobal.IntArray(Lists[int_].get_fields(Class16.smethod_0(1648955085)), endval6, 1);
				list6.Add(item6);
				endval6 = Lists[int_].get_fields(Class16.smethod_0(1648957329));
				item6 = ACE.RSGlobal.RSGlobal.IntArray(Lists[int_].get_fields(Class16.smethod_0(1648957213)), endval6, 1);
				list6.Add(item6);
				string name8 = Class16.smethod_0(1648919679);
				if (Lists[int_].get_fields(Class16.smethod_0(1648922985)) > -1)
				{
					name8 = Class16.smethod_0(1648922985);
				}
				endval6 = Lists[int_].get_fields(name8);
				item6 = ACE.RSGlobal.RSGlobal.IntArray(Lists[int_].get_fields(Class16.smethod_0(1648919584)), endval6, 1);
				list6.Add(item6);
				name8 = Class16.smethod_0(1648955116);
				ACE.Elements.eList.eList eList10 = Lists[int_];
				string name9 = Class16.smethod_0(1648955150);
				ACE.Elements.eList.eList eList11 = Lists[int_];
				list6.Add(ACE.RSGlobal.RSGlobal.IntArray(eList11.get_fields(name9), eList10.get_fields(name8), 2));
				name8 = Class16.smethod_0(1648957423);
				eList10 = Lists[int_];
				name9 = Class16.smethod_0(1648955183);
				eList11 = Lists[int_];
				list6.Add(ACE.RSGlobal.RSGlobal.IntArray(eList11.get_fields(name9), eList10.get_fields(name8), 2));
			}
		}
		else
		{
			CreateProbFieldsAutomatically();
		}
		return ProbFieldsSuites;
	}

	public void AddProbFields(int int_0, int[] fields, int str_id, int str_index)
	{
		if (!ProbFieldsSuites.ContainsKey(int_0))
		{
			ProbFieldsSuites.Add(int_0, new List<int[]>());
		}
		List<int[]> list = ProbFieldsSuites[int_0];
		list.Add(fields);
		string text;
		if (str_id > 0)
		{
			text = TextStorage.TEXTS.GetText(TextStorage.TEXTS.ResolveLegacyMessageKey(str_id, str_index), null);
		}
		else
		{
			object[] array = new object[2] { list.Count, null };
			int int_1 = fields[0];
			string text2 = ACE.RSGlobal.RSGlobal.WithCapitalLetter(NamesConverter.RemoveIndices(GetFieldName(int_0, int_1)));
			GC.KeepAlive(this);
			array[1] = text2;
			text = TextStorage.TEXTS.GetText(Class16.smethod_0(1649080310), array);
		}
		if (!ProbSuitesNames.ContainsKey(int_0))
		{
			ProbSuitesNames.Add(int_0, new List<string>());
		}
		ProbSuitesNames[int_0].Add(text);
		GC.KeepAlive(this);
	}

	public void AddProbFields(int int_0, string f_first, string f_last, int step, int str_id, int str_index)
	{
		if (int_0 != -1 && int_0 < ListCount)
		{
			if (Lists[int_0].get_fields(f_first) != -1 && Lists[int_0].get_fields(f_last) != -1)
			{
				ACE.Elements.eList.eList eList2 = Lists[int_0];
				ACE.Elements.eList.eList eList3 = Lists[int_0];
				AddProbFields(int_0, ACE.RSGlobal.RSGlobal.IntArray(eList3.get_fields(f_first), eList2.get_fields(f_last), step), str_id, str_index);
				GC.KeepAlive(this);
			}
			else
			{
				GC.KeepAlive(this);
			}
		}
	}

	public void AddProbFields(int int_0, string f_first, string f_last, int step)
	{
		AddProbFields(int_0, f_first, f_last, step, 0, 0);
	}

	public void AddProbFields(int int_0, string f_first, string f_last, int step, int str_id)
	{
		AddProbFields(int_0, f_first, f_last, step, str_id, 0);
	}

	public void AddProbFields(int int_0, string f_first, string f_last)
	{
		AddProbFields(int_0, f_first, f_last, 1, 0, 0);
	}

	public void AddProbFields(int int_0, int[] fields)
	{
		AddProbFields(int_0, fields, 0, 0);
	}

	public string GetCleanFieldName(int int_0, int int_1)
	{
		return Lists[int_0].elementFields[int_1];
	}

	public string GetRealFieldName(int int_0, int int_1)
	{
		return Lists[int_0].elementFields[int_1];
	}

	public string GetFieldName(int int_0, int int_1)
	{
		ACE.Elements.eList.eList eList2 = Lists[int_0];
		bool bTranslationExist = false;
		string fieldName = eList2.GetFieldName(int_1, ref bTranslationExist);
		GC.KeepAlive(this);
		return fieldName;
	}

	public string GetFieldName(FIELDPOS fp)
	{
		return GetFieldName(fp.int_0, fp.int_2);
	}

	public int GetIDinField(int int_0, int int_1, int int_2)
	{
		int valueIFast = Lists[int_0].GetValueIFast(int_1, int_2);
		GC.KeepAlive(this);
		return valueIFast;
	}

	public void FixCrLfInNames()
	{
		int num = 0;
		ACE.Elements.eList.eList[] lists = Lists;
		if (0 >= (nint)lists.LongLength)
		{
			return;
		}
		do
		{
			int num2 = 0;
			if (0 < (nint)lists[num].elementValues.LongLength)
			{
				do
				{
					string realItemName = GetRealItemName(num, num2);
					if (realItemName.Contains(Class16.smethod_0(1648904221)) || realItemName.Contains(Class16.smethod_0(1648941987)))
					{
						realItemName = realItemName.Replace(Class16.smethod_0(1648904221), string.Empty);
						realItemName = realItemName.Replace(Class16.smethod_0(1648941987), string.Empty);
						SetValue(num, num2, Lists[num].NameFieldIndex, realItemName, AutoSaveStage: false);
					}
					num2++;
				}
				while (num2 < (nint)Lists[num].elementValues.LongLength);
			}
			num++;
			lists = Lists;
		}
		while (num < (nint)lists.LongLength);
	}

	public Color GetMobColor(int moblvl)
	{
		ParamsClass paramsClass = Params;
		if (paramsClass != null && !paramsClass.ShowMobsColor)
		{
			Color white = Color.White;
			GC.KeepAlive(this);
			return white;
		}
		int num = 150;
		if (paramsClass != null)
		{
			num = paramsClass.MaxMobLevel;
		}
		if (moblvl < 0)
		{
			Color red = Color.Red;
			GC.KeepAlive(this);
			return red;
		}
		moblvl = ((moblvl > num) ? num : moblvl);
		Color dynamicColor = ACE.RSGlobal.RSGlobal.GetDynamicColor(moblvl, num, IsStrict: true);
		GC.KeepAlive(this);
		return dynamicColor;
	}

	public Color GetItemColor(int int_0, int int_1)
	{
		ACE.Elements.eList.eList[] lists = Lists;
		if (lists != null && int_0 >= 0 && int_0 < lists.Length)
		{
			ACE.Elements.eList.eList eList2 = lists[int_0];
			if (eList2 == null)
			{
				return Color.White;
			}
			int itemsCount;
			try
			{
				itemsCount = GetItemsCount(int_0);
			}
			catch
			{
				return Color.White;
			}
			if (int_1 >= 0 && int_1 < itemsCount)
			{
				if (eList2.NameFieldIndex < 0)
				{
					return Color.White;
				}
				try
				{
					ParamsClass paramsClass = Params;
					if (paramsClass != null && !paramsClass.ShowItemsColor)
					{
						Color white = Color.White;
						GC.KeepAlive(this);
						return white;
					}
					if (ACE.RSGlobal.RSGlobal.ELEMENTS_DEBUG)
					{
						Color white2 = Color.White;
						GC.KeepAlive(this);
						return white2;
					}
					Color result = Color.White;
					int num = eList2.getid(int_1);
					GC.KeepAlive(this);
					Color color;
					if (int_0 == 0)
					{
						GAMES game = Game;
						if (game == GAMES.PW)
						{
							bool flag = Addons.IsAbility(num);
							bool flag2 = num == 2311;
							if (flag || flag2)
							{
								goto IL_0119;
							}
						}
						else if (game == GAMES.JD)
						{
							int int_2 = lists[0].get_fields(Class16.smethod_0(1648962073));
							if (GetFieldType(0, int_1, int_2) == FIELDTYPE.ft_skills)
							{
								goto IL_0119;
							}
						}
						color = SpecialColors.AddonColor;
						goto IL_0129;
					}
					string realItemName = GetRealItemName(int_0, int_1);
					object obj2 = (string.IsNullOrWhiteSpace(realItemName) ? null : RSCommon.GetTagColor_o(realItemName));
					if (obj2 != null)
					{
						result = (Color)obj2;
					}
					else
					{
						bool flag3 = MattersListsFast != null && MattersListsFast.Contains(int_0);
						GC.KeepAlive(this);
						if (flag3 && Colors != null && IsColorExist(num) && Colors.Colors != null)
						{
							int num2 = Colors.Colors[num];
							ADDITIONAL_PARAMS aParams = CommonStorage.AParams;
							if (aParams != null && aParams.colors != null && num2 < (nint)aParams.colors.LongLength)
							{
								result = aParams.colors[num2];
							}
						}
						else
						{
							switch (Game)
							{
							case GAMES.PW:
								result = GetItemColorPW(int_0, int_1, num);
								break;
							case GAMES.FW:
								result = GetItemColorFW(int_0, int_1, num);
								break;
							case GAMES.JD:
								switch (eList2.ListType)
								{
								case ItemType.JD_NPC_ESSENCE:
									result = SpecialColors.NpcColorJD;
									break;
								case ItemType.JD_MONSTER_ESSENCE:
									result = GetMobColor(GetValueI(int_0, int_1, Class16.smethod_0(1648961613)));
									break;
								}
								break;
							}
						}
					}
					goto IL_0267;
					IL_0129:
					result = color;
					goto IL_0267;
					IL_0267:
					return result;
					IL_0119:
					color = SpecialColors.AddonSkillColorPW;
					goto IL_0129;
				}
				catch
				{
					return Color.White;
				}
			}
			return Color.White;
		}
		return Color.White;
	}

	public Color GetItemColor(ITEMPOS ItemPos)
	{
		return GetItemColor(ItemPos.int_0, ItemPos.int_1);
	}

	public Color GetItemColorPW(int int_0, int int_1, int id)
	{
		Color result = Color.White;
		ACE.Elements.eList.eList eList2 = Lists[int_0];
		ItemType listType = eList2.ListType;
		switch (listType)
		{
		case ItemType.PW_NPC_ESSENCE:
			result = SpecialColors.NpcColorPW;
			break;
		case ItemType.PW_MONSTER_ESSENCE:
		{
			int valueIFast2 = eList2.GetValueIFast(int_1, 15);
			GC.KeepAlive(this);
			result = GetMobColor(valueIFast2);
			break;
		}
		case ItemType.PW_FACE_TEXTURE_ESSENCE:
		case ItemType.PW_FACE_SHAPE_ESSENCE:
		case ItemType.PW_FACE_EXPRESSION_ESSENCE:
		case ItemType.PW_FACE_HAIR_ESSENCE:
		case ItemType.PW_FACE_MOUSTACHE_ESSENCE:
		case ItemType.PW_COLORPICKER_ESSENCE:
		case ItemType.PW_CUSTOMIZEDATA_ESSENCE:
		case ItemType.PW_FACE_FALING_ESSENCE:
		case ItemType.PW_FASHION_ESSENCE:
		case ItemType.PW_FACE_THIRDEYE_ESSENCE:
		case ItemType.PW_FASHION2_ESSENCE:
		{
			string field_name = ((listType != ItemType.PW_FASHION_ESSENCE) ? Class16.smethod_0(1649079309) : Class16.smethod_0(1648956046));
			switch (GetValueI(int_0, int_1, field_name))
			{
			case 1:
				result = Color.HotPink;
				break;
			case 0:
				result = Color.LawnGreen;
				break;
			}
			break;
		}
		case ItemType.PW_WEAPON_ESSENCE:
		case ItemType.PW_ARMOR_ESSENCE:
		case ItemType.PW_DECORATION_ESSENCE:
		case ItemType.PW_NEW_ARMOR_ESSENCE:
		{
			int colorFieldIndex = eList2.ColorFieldIndex;
			int valueIFast = eList2.GetValueIFast(int_1, colorFieldIndex);
			GC.KeepAlive(this);
			ITEMCOLORS_PW iTEMCOLORS_PW = (ITEMCOLORS_PW)valueIFast;
			if (valueIFast == 0 && GetValueF(int_0, int_1, Class16.smethod_0(1648919584)) < 0.3f)
			{
				iTEMCOLORS_PW = ITEMCOLORS_PW.Yellow;
			}
			else
			{
				switch (iTEMCOLORS_PW)
				{
				case ITEMCOLORS_PW.None:
					goto IL_01af;
				case ITEMCOLORS_PW.Red:
					goto IL_01b7;
				case ITEMCOLORS_PW.Green:
					goto IL_01bf;
				case ITEMCOLORS_PW.Blue:
					goto IL_01c7;
				}
			}
			result = SpecialColors.BlueColorPW;
			break;
		}
		case ItemType.PW_TITLE_CONFIG:
		case ItemType.PW_COMPLEX_TITLE_CONFIG:
			{
				byte[] array = (byte[])eList2.elementValues[int_1][4];
				if (array[0] != 0 || array[1] != 0 || array[2] != 0 || array[3] != 0)
				{
					result = Color.FromArgb(ACE.RSGlobal.RSGlobal.Bgab2Argb(array).ToArgb());
				}
				break;
			}
			IL_01bf:
			result = SpecialColors.GoldColorPW;
			break;
			IL_01b7:
			result = SpecialColors.GreenColorPW;
			break;
			IL_01af:
			result = Color.White;
			break;
			IL_01c7:
			result = SpecialColors.OrangeColorPW;
			break;
		}
		GC.KeepAlive(this);
		return result;
	}

	public Color GetItemColorFW(int int_0, int int_1, int id)
	{
		Color result = Color.White;
		ACE.Elements.eList.eList eList2 = Lists[int_0];
		switch (eList2.ListType)
		{
		default:
		{
			int colorFieldIndex = eList2.ColorFieldIndex;
			if (colorFieldIndex > 0)
			{
				int int_2 = colorFieldIndex;
				int valueIFast = eList2.GetValueIFast(int_1, int_2);
				GC.KeepAlive(this);
				result = valueIFast switch
				{
					0 => Color.Gray, 
					1 => Color.White, 
					2 => Color.Green, 
					3 => SpecialColors.BlueColorFW, 
					4 => Color.DarkViolet, 
					5 => Color.Gold, 
					_ => Color.DarkViolet, 
				};
			}
			break;
		}
		case ItemType.FW_NPC_ESSENCE:
			result = SpecialColors.NpcColorFW;
			break;
		case ItemType.FW_MONSTER_ESSENCE:
			result = GetMobColor(GetValueI(int_0, int_1, Class16.smethod_0(1649079325)));
			break;
		}
		GC.KeepAlive(this);
		return result;
	}

	public int GetItemColorIndex(int int_0)
	{
		return Lists[int_0].ColorFieldIndex;
	}

	public void GetIdDublicates(int current_l, int current_e, int id, int ListIndex, ref List<vITEMPOS> IdDublicates)
	{
		if (ListIndex >= ListCount)
		{
			return;
		}
		List<int> iDs = Lists[ListIndex].IDs;
		if (iDs == null)
		{
			return;
		}
		int num = iDs.IndexOf(id, 0);
		if (num <= -1)
		{
			return;
		}
		vITEMPOS item = default(vITEMPOS);
		do
		{
			if (num != current_e || ListIndex != current_l)
			{
				if (IdDublicates == null)
				{
					IdDublicates = new List<vITEMPOS>(2);
				}
				item.Int32_1 = ListIndex;
				item.Int32_0 = num;
				IdDublicates.Add(item);
				GC.KeepAlive(this);
			}
			num = Lists[ListIndex].IDs.IndexOf(id, num + 1);
		}
		while (num > -1);
	}

	public List<vITEMPOS> GetIdDublicates(int current_l, int current_e, int id, [MarshalAs(UnmanagedType.U1)] bool bInAllLists)
	{
		if (ACE.RSGlobal.RSGlobal.ELEMENTS_DEBUG)
		{
			return null;
		}
		if (badStructure)
		{
			return null;
		}
		List<vITEMPOS> IdDublicates = null;
		if (!bInAllLists && current_l >= 1)
		{
			List<int> similarLists = GetSimilarLists(current_l);
			if (similarLists != null)
			{
				int num = 0;
				if (0 < similarLists.Count)
				{
					do
					{
						GetIdDublicates(current_l, current_e, id, similarLists[num], ref IdDublicates);
						num++;
					}
					while (num < similarLists.Count);
				}
			}
			else
			{
				GetIdDublicates(current_l, current_e, id, current_l, ref IdDublicates);
			}
		}
		else if (current_l == 0)
		{
			GetIdDublicates(0, current_e, id, 0, ref IdDublicates);
		}
		else
		{
			int num2 = 1;
			if (1 < (nint)Lists.LongLength)
			{
				do
				{
					if (num2 != ConversationListIndex)
					{
						GetIdDublicates(current_l, current_e, id, num2, ref IdDublicates);
					}
					num2++;
				}
				while (num2 < (nint)Lists.LongLength);
			}
		}
		return IdDublicates;
	}

	public void AddIdDublicate(int int_0, int int_1, ref List<vITEMPOS> IdDublicates)
	{
		if (IdDublicates == null)
		{
			IdDublicates = new List<vITEMPOS>(2);
		}
		vITEMPOS item = new vITEMPOS
		{
			Int32_1 = int_0,
			Int32_0 = int_1
		};
		IdDublicates.Add(item);
		GC.KeepAlive(this);
	}

	public List<int> GetSimilarLists(int ListIndex)
	{
		List<int> value = null;
		Dictionary<ID_SPACE, List<int>> spaces = Spaces;
		if (spaces != null && spaces.TryGetValue(Lists[ListIndex].SpaceId, out value))
		{
			GC.KeepAlive(this);
			return value;
		}
		return new List<int> { ListIndex };
	}

	public void FixProbs(ref List<float> probs)
	{
		float value = 0f;
		float num = 0f;
		int num2 = 0;
		if (0 < probs.Count)
		{
			do
			{
				num = (float)((double)probs[num2] + (double)num);
				num2++;
			}
			while (num2 < probs.Count);
			if (num > 1.5f)
			{
				num = 0f;
			}
			else if (!(num <= 0f))
			{
				goto IL_0063;
			}
		}
		value = (float)(1.0 / (double)(float)probs.Count);
		goto IL_0063;
		IL_0063:
		int num3 = 0;
		if (0 < probs.Count)
		{
			do
			{
				if (num > 0f)
				{
					value = (float)((double)probs[num3] / (double)num);
				}
				probs[num3] = value;
				num3++;
			}
			while (num3 < probs.Count);
		}
		decimal num4 = default(decimal);
		int num5 = 0;
		if (0 < probs.Count)
		{
			do
			{
				decimal d = (decimal)probs[num5];
				num4 = decimal.Add(num4, d);
				num5++;
			}
			while (num5 < probs.Count);
		}
		decimal num6 = 1m;
		if (num4 != num6)
		{
			int maxValueIndex = ACE.RSGlobal.RSGlobal.GetMaxValueIndex(probs.ToArray());
			decimal d2 = 1m;
			decimal d3 = decimal.Subtract(d2, num4);
			decimal num7 = decimal.Add((decimal)probs[maxValueIndex], d3);
			probs[maxValueIndex] = (float)num7;
		}
		GC.KeepAlive(this);
	}

	public static int Get_NPC_TALK_ListIndex(GAMES Game, short Version, Dictionary<string, int> LI, [MarshalAs(UnmanagedType.U1)] bool domesticPW)
	{
		switch (Game)
		{
		default:
			return -1;
		case GAMES.FW:
		case GAMES.JD:
		case GAMES.ESO:
			return LI[Class16.smethod_0(1649079364)];
		case GAMES.PW:
			{
				if (Version > 7 && !domesticPW)
				{
					if (Version >= 350)
					{
						int num = ((Version == 1488 || Version >= 30000) ? 1 : 0);
						if ((byte)num == 0)
						{
							goto IL_0056;
						}
					}
					return LI[Class16.smethod_0(1649079331)];
				}
				goto IL_0056;
			}
			IL_0056:
			return -1;
		}
	}

	public int Get_NPC_TALK_ListIndex()
	{
		int result = Get_NPC_TALK_ListIndex(Game, Version, ListIndices, domesticPW);
		GC.KeepAlive(this);
		return result;
	}

	public static int Get_talk_proc_ListIndex(GAMES Game, short Version, Dictionary<string, int> LI, [MarshalAs(UnmanagedType.U1)] bool domesticPW)
	{
		if (domesticPW)
		{
			if (Version < 100 && LI != null && LI.TryGetValue(Class16.smethod_0(1649079379), out var value))
			{
				return value;
			}
			if (LI != null && LI.TryGetValue(Class16.smethod_0(1648987478), out var value2))
			{
				return value2;
			}
			return -1;
		}
		switch (Game)
		{
		default:
			return -1;
		case GAMES.PW:
			if (Version <= 7 || Version >= 350)
			{
				int num = ((Version == 1488 || Version >= 30000) ? 1 : 0);
				if ((byte)num == 0)
				{
					return -1;
				}
			}
			return LI[Class16.smethod_0(1649079400)];
		case GAMES.FW:
		case GAMES.JD:
		case GAMES.ESO:
		{
			int value3 = -1;
			if (LI.TryGetValue(Class16.smethod_0(1649079433), out value3))
			{
				return LI[Class16.smethod_0(1649079433)];
			}
			return value3;
		}
		case GAMES.Chibi:
			return 40;
		}
	}

	public int Get_talk_proc_ListIndex()
	{
		int result = Get_talk_proc_ListIndex(Game, Version, ListIndices, domesticPW);
		GC.KeepAlive(this);
		return result;
	}

	public static string _CreateQueryConfigDB(string FileName)
	{
		return null;
	}

	public static string CreateQueryConfigDB_OLD(string FileName, int lang_index)
	{
		return null;
	}

	public string GenerateUniqueFileID(string BaseName)
	{
		int num = Lists[0].getid(0);
		GC.KeepAlive(this);
		int int_ = GetItemsCount(0) - 1;
		int num2 = Lists[0].getid(int_);
		GC.KeepAlive(this);
		int num3 = num2 + num;
		int num4 = method_38();
		if (num4 > 1 && GetItemsCount(num4 - 2) > 0)
		{
			int num5 = num4 - 2;
			int num6 = Lists[num5].getid(0);
			GC.KeepAlive(this);
			num3 = num6 + num3;
		}
		string result = string.Format(Class16.smethod_0(1649079469), BaseName, GamePrefix, Version, TimeStamp, num3);
		GC.KeepAlive(this);
		return result;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool CreateOrGetFileUID([MarshalAs(UnmanagedType.U1)] bool bNew)
	{
		string text = Class16.smethod_0(1648923968);
		string text2 = System.IO.Path.GetFileNameWithoutExtension(FileName) + text;
		bool flag = false;
		uint timeStamp = TimeStamp;
		string text3 = Class16.smethod_0(1648928048);
		if (File.Exists(string.Concat(string.Concat(Class16.smethod_0(1649079494) + text2, timeStamp.ToString()), text3)))
		{
			uint timeStamp2 = TimeStamp;
			UniqueID = text2 + timeStamp2;
			flag = true;
		}
		else
		{
			string text4 = (UniqueID = GenerateUniqueFileID(text2));
			string text5 = Class16.smethod_0(1648928048);
			flag = File.Exists(string.Concat(Class16.smethod_0(1649079494) + text4, text5)) || flag;
		}
		if (bNew || !flag)
		{
			UniqueID = GenerateUniqueFileID(text2);
			IsNewUIDCreated = true;
		}
		ActionsHistory?.SetUniqueID(UniqueID);
		GC.KeepAlive(this);
		return IsNewUIDCreated;
	}

	public Dictionary<int, int[]> GetFieldsToEncrypt([MarshalAs(UnmanagedType.U1)] bool IsDecrypt)
	{
		GetProbFieldsSuites();
		FieldsToEncrypt = new Dictionary<int, int[]>(ProbFieldsSuites.Count);
		Dictionary<int, List<int[]>>.Enumerator enumerator = ProbFieldsSuites.GetEnumerator();
		if (enumerator.MoveNext())
		{
			do
			{
				ValueType valueType = enumerator.Current;
				List<int> list = new List<int>();
				int key = ((KeyValuePair<int, List<int[]>>)(object)valueType).Key;
				if (IsDecrypt)
				{
					int protectionVersion = ProtectionVersion;
					if (protectionVersion == 1)
					{
						if (key != this.get_LI(Class16.smethod_0(1648953506)))
						{
							if (key == this.get_LI(Class16.smethod_0(1648953601)))
							{
								break;
							}
							goto IL_0088;
						}
					}
					else if (protectionVersion != 2 || key != this.get_LI(Class16.smethod_0(1648923456)))
					{
						goto IL_0088;
					}
				}
				else if (key != this.get_LI(Class16.smethod_0(1648923456)))
				{
					goto IL_0088;
				}
				continue;
				IL_0088:
				List<int[]>.Enumerator enumerator2 = ((KeyValuePair<int, List<int[]>>)(object)valueType).Value.GetEnumerator();
				if (enumerator2.MoveNext())
				{
					do
					{
						int[] current = enumerator2.Current;
						list.AddRange(current);
					}
					while (enumerator2.MoveNext());
				}
				FieldsToEncrypt.Add(key, list.ToArray());
			}
			while (enumerator.MoveNext());
		}
		GC.KeepAlive(this);
		return FieldsToEncrypt;
	}

	public unsafe string DecodeValue(int int_0, int int_1, int int_2, string value)
	{
		try
		{
			string text;
			if (!string.IsNullOrWhiteSpace(value) && int_1 != 0)
			{
				text = null;
				FIELDTYPE fieldType = GetFieldType(int_0, int_2, int_1);
				if (fieldType >= FIELDTYPE.matters)
				{
					int valueIFast = Lists[int_0].GetValueIFast(int_2, int_1);
					if (valueIFast == 0 && !string.IsNullOrWhiteSpace(value)) { int.TryParse(value.Trim(), out valueIFast); }
					text = FindItemName(GetFieldLists(int_0, int_2, int_1), valueIFast, IsDefinitelyID: true);
				}
				else if (fieldType >= FIELDTYPE.ai_id)
				{
					switch (fieldType)
					{
					case FIELDTYPE.ai_id:
					{
						int num = ACE.RSGlobal.RSGlobal.UIntParseFast(value);
						text = ((num != 0) ? ((DataFiles.AIPolicy == null) ? (value + TextStorage.Msg(Class16.smethod_0(1649079529), Class16.smethod_0(1649079562))) : DataFiles.AIPolicy.GetControllerDisplayText(num)) : TextStorage.TEXTS.GetText(Class16.smethod_0(1649079507)));
						break;
					}
					case FIELDTYPE.ft_skills:
					case FIELDTYPE.potion_skills:
					case FIELDTYPE.scrolls_skills:
					case FIELDTYPE.skills_pw:
					case FIELDTYPE.ft_dyn_skills:
					case FIELDTYPE.monster_skills:
						if (Skills != null)
						{
							text = Skills.GetSkillNameAndDesc(ACE.RSGlobal.RSGlobal.UIntParseFast(value));
						}
						break;
					case FIELDTYPE.refine_addon_pw:
					{
						int previewRefineLevel = Params.PreviewRefineLevel;
						text = GenerateRefineText(ACE.RSGlobal.RSGlobal.UIntParseFast(value), previewRefineLevel);
						break;
					}
					case FIELDTYPE.equip_addon:
					{
						int num2 = ACE.RSGlobal.RSGlobal.UIntParseFast(value);
						string text4;
						if (num2 != 0)
						{
							int num3 = addons_l;
							ITEMPOS pos = null;
							int num4 = FindItemIndexByID(num3, num2);
							if (num4 > -1)
							{
								pos = new ITEMPOS(num3, num4);
							}
							text4 = GetParsedItemName(pos);
						}
						else
						{
							text4 = string.Empty;
						}
						text = text4;
						break;
					}
					case FIELDTYPE.ft_quest:
						if (Tasks != null)
						{
							int valueIFast2 = Lists[int_0].GetValueIFast(int_2, int_1);
							GC.KeepAlive(this);
							text = Tasks.GetTaskName(valueIFast2);
						}
						else
						{
							string text3 = TextStorage.TEXTS.GetText(Class16.smethod_0(1649079599));
							text = value + text3;
						}
						break;
					case FIELDTYPE.ft_path_data:
					case FIELDTYPE.file_model:
					case FIELDTYPE.file_icon:
					case FIELDTYPE.file_icon_tga:
					{
						if (Game == GAMES.PW && fieldType != FIELDTYPE.ft_path_data)
						{
							break;
						}
						PATH_DATA pathData = PathData;
						if (pathData != null && pathData.Paths != null)
						{
							if (value != Class16.smethod_0(1648924112))
							{
								uint id = (uint)ACE.RSGlobal.RSGlobal.UIntParseFast(value);
								bool flag = default(bool);
								text = PathData.GetPath(id, &flag);
							}
							else
							{
								text = TextStorage.TEXTS.GetText(Class16.smethod_0(1649079507));
							}
						}
						else
						{
							string text2 = TextStorage.TEXTS.GetText(Class16.smethod_0(1649079622));
							text = value + text2;
						}
						break;
					}
					}
				}
				else if (fieldType >= FIELDTYPE.ft_MASK_EXTRA)
				{
					if (ACE.RSGlobal.RSGlobal.IsNumber(value))
					{
						if (fieldType == FIELDTYPE.monster_immunity)
						{
							text = DecodeMonsterImmunity(value);
						}
						else
						{
							decimal num5 = Convert.ToDecimal(value, CultureInfo.InvariantCulture);
							decimal num6 = -1m;
							if (num5 == num6)
							{
								text = TextStorage.TEXTS.GetText(Class16.smethod_0(1648952014));
							}
							else if (Lists[int_0].elementTypes[int_1] == Class16.smethod_0(1648989786))
							{
								decimal num7 = 4294967295m;
								if (num5 == num7)
								{
									text = TextStorage.TEXTS.GetText(Class16.smethod_0(1648952014));
								}
							}
							else if (Lists[int_0].elementTypes[int_1] == Class16.smethod_0(1648989834))
							{
								decimal num8 = 18446744073709551615m;
								if (num5 == num8)
								{
									text = TextStorage.TEXTS.GetText(Class16.smethod_0(1648952014));
								}
							}
							if (text != null)
							{
								goto IL_0962;
							}
							int num9;
							switch (fieldType)
							{
							default:
								num9 = (int)fieldType;
								break;
							case FIELDTYPE.character_combo_id_jd:
								num9 = 4005;
								break;
							case FIELDTYPE.ft_ENUM_EXTRA:
							case FIELDTYPE.ft_MASK_EXTRA:
								num9 = GetExtraType(int_0, int_2, int_1);
								break;
							}
							int ftype = num9;
							text = DecodeMask(ftype, (ulong)num5);
						}
					}
				}
				else if (fieldType < FIELDTYPE.ft_ENUM_EXTRA)
				{
					if (fieldType >= FIELDTYPE.shop_price)
					{
						int valueIFast3;
						string text6;
						object[] vars;
						int valueI;
						switch (fieldType)
						{
						case FIELDTYPE.shop_price:
						{
							valueIFast3 = Lists[int_0].GetValueIFast(int_2, int_1);
							GC.KeepAlive(this);
							if (CommonStorage.AParams.DisableShopPriceTaxCalculation)
							{
								int num12 = valueIFast3;
								text = num12.ToString(Class16.smethod_0(1648909972));
								break;
							}
							int num13 = CStorage.GetGamePricePW(valueIFast3);
							if (num13 < 0)
							{
								num13 = 0;
							}
							else if (num13 > 9999)
							{
								int num14 = num13;
								text6 = num14.ToString(Class16.smethod_0(1648909972));
								goto IL_04b3;
							}
							int num15 = num13;
							text6 = num15.ToString();
							goto IL_04b3;
						}
						case FIELDTYPE.refine_jd:
						{
							string field_name = Class16.smethod_0(1649079645);
							text = DecodeRefineJD(GetValueI(int_0, int_2, Class16.smethod_0(1649079651)), GetValueI(int_0, int_2, field_name), value);
							break;
						}
						case FIELDTYPE.hp_regen:
						{
							int num16 = (int)(Convert.ToDouble(value, CultureInfo.InvariantCulture) * (2.0 / 15.0));
							object[] array = new object[2];
							int num17 = num16;
							array[0] = num17.ToString(Class16.smethod_0(1648909972));
							array[1] = (num16 * 60).ToString(Class16.smethod_0(1648909972));
							string text7 = TextStorage.TEXTS.GetText(Class16.smethod_0(1649079665), array);
							text = value + text7;
							break;
						}
						case FIELDTYPE.refine_reserved_prob:
						{
							string text5 = TextStorage.TEXTS.GetText(Class16.smethod_0(1649079695));
							float num10 = Convert.ToSingle(value, CultureInfo.InvariantCulture);
							int numAfterDecimal = 2;
							if ((double)num10 < 0.0001)
							{
								numAfterDecimal = 4;
							}
							text = ACE.RSGlobal.RSGlobal.ToPercent(num10, numAfterDecimal) + text5;
							break;
						}
						case FIELDTYPE.time_seconds:
							text = CommonStorage.SecondsToString((uint)ACE.RSGlobal.RSGlobal.UIntParseFast(value), bShowSeconds: true, bZeroIsNotForever: false);
							break;
						case FIELDTYPE.ft_reputation:
							if (ACE.RSGlobal.RSGlobal.UIntParseFast(value) == -1)
							{
								text = TextStorage.TEXTS.GetText(Class16.smethod_0(1648908635));
							}
							break;
						case FIELDTYPE.ft_period:
						{
							uint num11 = (uint)ACE.RSGlobal.RSGlobal.UIntParseFast(value);
							text = ((num11 <= 2147483648u) ? CommonStorage.SecondsToString(num11, bShowSeconds: true, bZeroIsNotForever: false) : ACE.RSGlobal.RSGlobal.Period2String(num11, 1));
							break;
						}
						case FIELDTYPE.ft_timestamp:
							text = CommonStorage.Timestamp2String((uint)ACE.RSGlobal.RSGlobal.UIntParseFast(value), ShowSeconds: true);
							break;
						case FIELDTYPE.price_jd:
							text = DecodePriceJD((uint)ACE.RSGlobal.RSGlobal.UIntParseFast(value));
							break;
						case FIELDTYPE.addon_param1:
						case FIELDTYPE.addon_param2:
						case FIELDTYPE.addon_param3:
							{
								if (int_1 > -1)
								{
									ACE.Elements.eList.eList eList2 = Lists[int_0];
									FIELD_DATA_TYPE_ENUM data_type = eList2.FieldDataTypes[int_1].data_type;
									if (data_type == FIELD_DATA_TYPE_ENUM.Double)
									{
										double value2 = (double)eList2.elementValues[int_2][int_1];
										text = Math.Round(value2, 15).ToString();
									}
								}
								break;
							}
							IL_04b3:
							vars = new object[2] { text6, valueIFast3 };
							text = TextStorage.TEXTS.GetText(Class16.smethod_0(1649079718), vars);
							valueI = GetValueI(int_0, int_2, Class16.smethod_0(1648970148));
							if (valueI >= valueIFast3 && valueI != 1 && valueIFast3 != 1)
							{
								string text8 = TextStorage.TEXTS.GetText(Class16.smethod_0(1649079741));
								text += text8;
							}
							if (valueI > 195000000)
							{
								string text9 = TextStorage.TEXTS.GetText(Class16.smethod_0(1649079764));
								text += text9;
							}
							break;
						}
					}
					else
					{
						FIELD_DATA_TYPE_ENUM fIELD_DATA_TYPE_ENUM = ((int_1 > -1) ? Lists[int_0].FieldDataTypes[int_1].data_type : FIELD_DATA_TYPE_ENUM.Unknown);
						if (int_0 == addons_l && fIELD_DATA_TYPE_ENUM != FIELD_DATA_TYPE_ENUM.Double)
						{
							return value;
						}
						switch (fIELD_DATA_TYPE_ENUM)
						{
						case FIELD_DATA_TYPE_ENUM.Int:
						{
							int num23 = (int)Lists[int_0].elementValues[int_2][int_1];
							if (num23 > 9999)
							{
								int num24 = num23;
								text = num24.ToString(Class16.smethod_0(1648909972));
							}
							else
							{
								int num25 = num23;
								text = num25.ToString();
							}
							break;
						}
						case FIELD_DATA_TYPE_ENUM.UInt:
						{
							uint num20 = (uint)Lists[int_0].elementValues[int_2][int_1];
							if (num20 > 9999)
							{
								uint num21 = num20;
								text = num21.ToString(Class16.smethod_0(1648909972));
							}
							else
							{
								uint num22 = num20;
								text = num22.ToString();
							}
							break;
						}
						case FIELD_DATA_TYPE_ENUM.Float:
						{
							float valueF = Lists[int_0].GetValueF(int_2, int_1);
							GC.KeepAlive(this);
							if (IsProbField(int_0, int_1))
							{
								int numAfterDecimal2 = 2;
								if ((double)valueF < 0.0001)
								{
									numAfterDecimal2 = 4;
								}
								text = ACE.RSGlobal.RSGlobal.ToPercent(valueF, numAfterDecimal2);
							}
							else if (valueF > 0.01f)
							{
								float num26 = valueF;
								text = num26.ToString(Class16.smethod_0(1649079779));
							}
							else
							{
								text = Math.Round(valueF, 7).ToString();
							}
							break;
						}
						case FIELD_DATA_TYPE_ENUM.Double:
						{
							double num18 = (double)Lists[int_0].elementValues[int_2][int_1];
							if (num18 > 9999.0)
							{
								double num19 = num18;
								text = num19.ToString(Class16.smethod_0(1648909972));
							}
							else
							{
								text = Math.Round(num18, 15).ToString();
							}
							break;
						}
						}
					}
				}
				else if (ACE.RSGlobal.RSGlobal.IsUIntFast(value))
				{
					decimal value3 = ACE.RSGlobal.RSGlobal.UInt64ParseFast(value);
					int ftype2 = fieldType switch
					{
						FIELDTYPE.character_combo_id_jd => 4005, 
						FIELDTYPE.ft_ENUM_EXTRA => GetExtraType(int_0, int_2, int_1), 
						_ => (int)fieldType, 
					};
					text = DecodedValues.DecodeValue(ftype2, value3);
				}
				if (text == null)
				{
					text = value;
				}
				goto IL_0962;
			}
			GC.KeepAlive(this);
			return value;
			IL_0962:
			GC.KeepAlive(this);
			return text;
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649079796));
			GC.KeepAlive(this);
			return value;
		}
	}

	public string DecodeValue(int int_0, int int_1, int int_2)
	{
		return DecodeValue(int_0, int_2, int_1, GetValue(int_0, int_1, int_2));
	}

	public string DecodeValue(ITEMPOS ItemPos, int int_0)
	{
		string value = GetValue(ItemPos.int_0, ItemPos.int_1, int_0);
		return DecodeValue(ItemPos.int_0, int_0, ItemPos.int_1, value);
	}

	public string DecodeRefineJD(int min_atc, int max_atc, string value)
	{
		int num = Convert.ToInt32(value);
		object[] vars = new object[3]
		{
			num,
			num + min_atc,
			num + max_atc
		};
		string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1649078806), vars);
		GC.KeepAlive(this);
		return text;
	}

	public string DecodeMonsterImmunity(string mask)
	{
		int num = Convert.ToInt32(mask);
		switch (num)
		{
		case 62:
		{
			string text2 = TextStorage.TEXTS.GetText(Class16.smethod_0(1649078829));
			GC.KeepAlive(this);
			return text2;
		}
		default:
			GC.KeepAlive(this);
			return DecodeMask(65, (ulong)num);
		case 63:
		case 16383:
		case 262143:
		case 524287:
		{
			string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1649078852));
			GC.KeepAlive(this);
			return text;
		}
		}
	}

	public string FindItemName(int[] lists, int id, [MarshalAs(UnmanagedType.U1)] bool IsDefinitelyID)
	{
		if (id == 0)
		{
			if (IsDefinitelyID)
			{
				return Class16.smethod_0(1648924410);
			}
			return string.Empty;
		}
		ITEMPOS iTEMPOS = FindItemPos(lists, id);
		if (iTEMPOS != null)
		{
			if (Game == GAMES.PW)
			{
				int int_ = iTEMPOS.int_0;
				if (int_ == this.get_LI(Class16.smethod_0(1648952558)) && Params.UseAlternativeRecipesNames)
				{
					return GetRecipeNameFromResultItem(int_, iTEMPOS.int_1, isCaption: true);
				}
			}
			int int_2 = iTEMPOS.int_1;
			int int_3 = iTEMPOS.int_0;
			string text = GetParsedItemName(int_3, int_2, bRealAddonName: true);
			if (string.IsNullOrWhiteSpace(text))
			{
				text = Class16.smethod_0(1648966655);
			}
			GC.KeepAlive(this);
			return text;
		}
		if (IsDefinitelyID)
		{
			string text2 = TextStorage.TEXTS.GetText(Class16.smethod_0(1649078867));
			GC.KeepAlive(this);
			return text2;
		}
		GC.KeepAlive(this);
		return string.Empty;
	}

	public string GetItemModelPath(int int_0, int int_1)
	{
		int modelFieldIndex = Lists[int_0].ModelFieldIndex;
		if (modelFieldIndex > 0)
		{
			string value = GetValue(int_0, int_1, modelFieldIndex);
			if (string.IsNullOrWhiteSpace(value))
			{
				ACE.Elements.eList.eList eList2 = Lists[int_0];
				int num = eList2.ModelFieldIndex + 1;
				if (num < (nint)eList2.elementTypes.LongLength)
				{
					do
					{
						if (GetFieldType(int_0, int_1, num) == FIELDTYPE.file_model)
						{
							value = GetValue(int_0, int_1, num);
							if (!string.IsNullOrWhiteSpace(value))
							{
								break;
							}
						}
						num++;
					}
					while (num < (nint)Lists[int_0].elementTypes.LongLength);
				}
			}
			string result = value.Trim().ToLowerInvariant();
			GC.KeepAlive(this);
			return result;
		}
		GC.KeepAlive(this);
		return null;
	}

	public string GetItemModelPath(ITEMPOS ItemPos)
	{
		return GetItemModelPath(ItemPos.int_0, ItemPos.int_1);
	}

	public int GetItemModelIndex(int int_0, int int_1)
	{
		int num = Lists[int_0].ModelFieldIndex;
		if (int_0 != this.get_LI(Class16.smethod_0(1649078890)) && int_0 != this.get_LI(Class16.smethod_0(1649078912)))
		{
			if (num > 0 && string.IsNullOrWhiteSpace(GetValue(int_0, int_1, num)))
			{
				ACE.Elements.eList.eList eList2 = Lists[int_0];
				int num2 = eList2.ModelFieldIndex + 1;
				if (Game == GAMES.FW && eList2.ListType == ItemType.FW_PET_BEDGE_ESSENCE)
				{
					num2 = eList2.get_fields(Class16.smethod_0(1649078943));
				}
				int num3 = num2;
				if (num2 < (nint)Lists[int_0].elementTypes.LongLength)
				{
					do
					{
						if (GetFieldType(int_0, int_1, num3) != FIELDTYPE.file_model || string.IsNullOrWhiteSpace(GetValue(int_0, int_1, num3)))
						{
							num3++;
							continue;
						}
						num = num3;
						break;
					}
					while (num3 < (nint)Lists[int_0].elementTypes.LongLength);
				}
			}
			GC.KeepAlive(this);
			return num;
		}
		return num;
	}

	public int GetItemModelIndex(ITEMPOS ItemPos)
	{
		return GetItemModelIndex(ItemPos.int_0, ItemPos.int_1);
	}

	public void CreateFieldsTranslationDB(string UniversalConfigFile, string LocalizedFieldPath, [MarshalAs(UnmanagedType.U1)] bool bSetUniversalListName)
	{
	}

	public void CreateFieldsTypesDB(string UniversalConfigFile, string FieldTypesPath)
	{
	}

	public void ReplaceTypes()
	{
		if (Game != GAMES.PW || ListCount <= 60)
		{
			return;
		}
		string value = Class16.smethod_0(1648989786);
		string type = Class16.smethod_0(1648893461);
		string field_name = Class16.smethod_0(1649078965);
		Lists[this.get_LI(Class16.smethod_0(1648960167))][field_name, type] = value;
		string value2 = Class16.smethod_0(1648989786);
		string type2 = Class16.smethod_0(1648893461);
		string field_name2 = Class16.smethod_0(1649078989);
		Lists[this.get_LI(Class16.smethod_0(1648960167))][field_name2, type2] = value2;
		string value3 = Class16.smethod_0(1648989786);
		string type3 = Class16.smethod_0(1648893461);
		string field_name3 = Class16.smethod_0(1649079014);
		Lists[this.get_LI(Class16.smethod_0(1648963546))][field_name3, type3] = value3;
		string value4 = Class16.smethod_0(1648989786);
		string type4 = Class16.smethod_0(1648893461);
		string field_name4 = Class16.smethod_0(1649079028);
		Lists[this.get_LI(Class16.smethod_0(1648963546))][field_name4, type4] = value4;
		string value5 = Class16.smethod_0(1648989786);
		string type5 = Class16.smethod_0(1648893461);
		string field_name5 = Class16.smethod_0(1649079042);
		Lists[this.get_LI(Class16.smethod_0(1648963546))][field_name5, type5] = value5;
		string value6 = Class16.smethod_0(1648989786);
		string type6 = Class16.smethod_0(1648893461);
		string field_name6 = Class16.smethod_0(1649079073);
		Lists[this.get_LI(Class16.smethod_0(1648963546))][field_name6, type6] = value6;
		string value7 = Class16.smethod_0(1648989776);
		string type7 = Class16.smethod_0(1648893461);
		string field_name7 = Class16.smethod_0(1649079104);
		Lists[this.get_LI(Class16.smethod_0(1648963546))][field_name7, type7] = value7;
		string value8 = Class16.smethod_0(1648989776);
		string type8 = Class16.smethod_0(1648893461);
		string field_name8 = Class16.smethod_0(1649079115);
		Lists[this.get_LI(Class16.smethod_0(1648963535))][field_name8, type8] = value8;
		string item = Class16.smethod_0(1649079149);
		Lists[this.get_LI(Class16.smethod_0(1648963546))].elementTypes = ACE.RSGlobal.RSGlobal.InsertToArray(Lists[this.get_LI(Class16.smethod_0(1648963546))].elementTypes, item, 4);
		string item2 = Class16.smethod_0(1649079166);
		Lists[this.get_LI(Class16.smethod_0(1648963546))].elementFields = ACE.RSGlobal.RSGlobal.InsertToArray(Lists[this.get_LI(Class16.smethod_0(1648963546))].elementFields, item2, 4);
		ACE.Elements.eList.eList eList2 = Lists[this.get_LI(Class16.smethod_0(1648952504))];
		if (eList2.get_fields(Class16.smethod_0(1648951917)) > -1)
		{
			int num = 1;
			do
			{
				int num2 = 1;
				do
				{
					string format = Class16.smethod_0(1649079170);
					if (!ChangeFieldName(eList2, string.Format(Class16.smethod_0(1649079207), num, num2), string.Format(format, num, num2)))
					{
						break;
					}
					num2++;
				}
				while (num2 <= 32);
				num++;
			}
			while (num <= 8);
		}
		ACE.Elements.eList.eList[] lists = Lists;
		int num3 = 0;
		if (0 < (nint)lists.LongLength)
		{
			do
			{
				ACE.Elements.eList.eList eList3 = lists[num3];
				int num4 = 0;
				string[] elementFields = eList3.elementFields;
				if (0 < (nint)elementFields.LongLength)
				{
					do
					{
						if ((elementFields[num4] == Class16.smethod_0(1648958590) || eList3.elementFields[num4] == Class16.smethod_0(1649079236)) && eList3.elementTypes[num4] == Class16.smethod_0(1648989776))
						{
							eList3.elementTypes[num4] = Class16.smethod_0(1648989786);
						}
						num4++;
						elementFields = eList3.elementFields;
					}
					while (num4 < (nint)elementFields.LongLength);
				}
				num3++;
			}
			while (num3 < (nint)lists.LongLength);
		}
		FixTasksIdFieldName(Class16.smethod_0(1649079261));
		FixTasksIdFieldName(Class16.smethod_0(1649079287));
		FixTasksIdFieldName(Class16.smethod_0(1649078282));
		FixTasksIdFieldName(Class16.smethod_0(1649078312));
		FixTasksIdFieldName(Class16.smethod_0(1648960167));
		FixTasksIdFieldName(Class16.smethod_0(1649078343));
		ChangeFieldName(Class16.smethod_0(1648963535), Class16.smethod_0(1649078363), Class16.smethod_0(1649078377));
		ChangeFieldName(Class16.smethod_0(1648963535), Class16.smethod_0(1649078394), Class16.smethod_0(1649078409));
	}

	public void FixTasksIdFieldName(string listName)
	{
		int num = this.get_LI(listName);
		if (num == -1)
		{
			return;
		}
		ACE.Elements.eList.eList eList2 = Lists[num];
		if (eList2.get_fields(Class16.smethod_0(1649078427)) > -1)
		{
			int num2 = 1;
			do
			{
				string format = Class16.smethod_0(1649078452);
				if (!ChangeFieldName(eList2, string.Format(Class16.smethod_0(1649078471), num2), string.Format(format, num2)))
				{
					break;
				}
				num2++;
			}
			while (num2 <= 512);
		}
		if (eList2.get_fields(Class16.smethod_0(1649078482)) > -1)
		{
			int num3 = 1;
			do
			{
				string format2 = Class16.smethod_0(1649078452);
				if (!ChangeFieldName(eList2, string.Format(Class16.smethod_0(1649078504), num3), string.Format(format2, num3)))
				{
					break;
				}
				num3++;
			}
			while (num3 <= 512);
		}
		GC.KeepAlive(this);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public static bool ChangeFieldName(ACE.Elements.eList.eList list, string fieldName, string newFieldName)
	{
		int num = list.get_fields(fieldName);
		if (num > -1)
		{
			list.elementFields[num] = newFieldName;
			if (list._elementFields != null)
			{
				int num2 = -1;
				for (int i = 0; i < list._elementFields.Length; i++)
				{
					if (list._elementFields[i] == fieldName)
					{
						num2 = i;
						break;
					}
				}
				if (num2 > -1)
				{
					list._elementFields[num2] = newFieldName;
				}
			}
			return true;
		}
		return false;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool ChangeFieldName(string listName, string fieldName, string newFieldName)
	{
		int num = this.get_LI(listName);
		if (num == -1)
		{
			return false;
		}
		bool result = ChangeFieldName(Lists[num], fieldName, newFieldName);
		GC.KeepAlive(this);
		return result;
	}

	public void SaveFirstItems(string fn)
	{
	}

	public void SaveFieldTypesDB()
	{
	}

	public string GetListTypesDB(int int_0, eListCollection eLC, string ListName, [MarshalAs(UnmanagedType.U1)] bool bAutoSetTypes)
	{
		bool flag = false;
		string[] elementFields = eLC.Lists[int_0].elementFields;
		List<string> list = new List<string>();
		int num = 0;
		ACE.Elements.eList.eList eList2 = Lists[int_0];
		if (0 < (nint)eList2.elementTypes.LongLength)
		{
			do
			{
				string text = elementFields[num];
				FIELDTYPE fIELDTYPE = eList2.fieldtypes[num];
				if (fIELDTYPE == FIELDTYPE.none)
				{
					if (bAutoSetTypes)
					{
						if (text == Class16.smethod_0(1648955728))
						{
							fIELDTYPE = FIELDTYPE.proc_type;
						}
						else if (text == Class16.smethod_0(1648960592))
						{
							fIELDTYPE = FIELDTYPE.file_icon;
						}
						else if (Game != GAMES.PW && (text == Class16.smethod_0(1648960582) || text == Class16.smethod_0(1649078528)))
						{
							fIELDTYPE = FIELDTYPE.ft_path_data;
						}
						else
						{
							if (!text.Contains(Class16.smethod_0(1649078545)) && !text.Contains(Class16.smethod_0(1649078567)))
							{
								goto IL_021b;
							}
							fIELDTYPE = FIELDTYPE.matters;
						}
						goto IL_00cc;
					}
				}
				else if (fIELDTYPE > FIELDTYPE.none)
				{
					goto IL_00cc;
				}
				goto IL_021b;
				IL_00cc:
				if (!flag)
				{
					list.Add(Class16.smethod_0(1648929947) + ListName);
					flag = true;
				}
				string text3;
				switch (fIELDTYPE)
				{
				case FIELDTYPE.custom_list:
				{
					int[] fieldLists = GetFieldLists(int_0, 0, num);
					List<string> list2 = new List<string>();
					int num3 = 0;
					if (0 < (nint)fieldLists.LongLength)
					{
						do
						{
							list2.Add(eLC.Lists[fieldLists[num3]].uListName);
							num3++;
						}
						while (num3 < (nint)fieldLists.LongLength);
					}
					text3 = string.Join(Class16.smethod_0(1648928028), list2);
					break;
				}
				default:
					text3 = Enum.GetName(typeof(FIELDTYPE_MANAGED), (FIELDTYPE_MANAGED)fIELDTYPE);
					break;
				case FIELDTYPE.ft_ENUM_EXTRA:
				case FIELDTYPE.ft_MASK_EXTRA:
				{
					int extraType = GetExtraType(int_0, -1, num);
					if (extraType >= 100000)
					{
						string text2 = StrIdToEnum[extraType];
						text3 = ((!dictionary_0.ContainsKey(text2)) ? Class16.smethod_0(1649078580) : Class16.smethod_0(1648941518)) + text2;
					}
					else
					{
						string text4 = ((fIELDTYPE != FIELDTYPE.ft_MASK_EXTRA) ? string.Empty : Class16.smethod_0(1649078588));
						int num2 = extraType;
						text3 = num2 + text4;
					}
					break;
				}
				}
				string item = text;
				if (elementFields[num] != text3)
				{
					item = string.Concat(text, Class16.smethod_0(1648898262) + text3);
				}
				list.Add(item);
				goto IL_021b;
				IL_021b:
				num++;
				eList2 = Lists[int_0];
			}
			while (num < (nint)eList2.elementTypes.LongLength);
		}
		string result = string.Join(Class16.smethod_0(1648924428), list);
		GC.KeepAlive(this);
		return result;
	}

	public string GetListTypesDB(int int_0)
	{
		return GetListTypesDB(int_0, this, Lists[int_0].uListName, bAutoSetTypes: false);
	}

	public string[] GetListNames([MarshalAs(UnmanagedType.U1)] bool bIncludeConversations)
	{
		int[] array = ((!bIncludeConversations) ? AllLists : AllListsAndCoversations);
		string[] array2 = new string[(nint)array.LongLength];
		int num = 0;
		if (0 < (nint)array2.LongLength)
		{
			do
			{
				int num2 = array[num];
				int num3 = ((!Params.FirstListIndexIs1) ? num2 : (num2 + 1));
				ACE.Elements.eList.eList eList2 = Lists[num2];
				string text = ((!ACE.RSGlobal.RSGlobal.SHOW_UNIVERSAL_NAMES) ? eList2.ListName : eList2.uListName);
				int num4 = num3;
				string text2 = num4.ToString(Class16.smethod_0(1648902328));
				array2[num] = string.Concat(text2 + Class16.smethod_0(1648908709), text);
				num++;
			}
			while (num < (nint)array2.LongLength);
		}
		GC.KeepAlive(this);
		return array2;
	}

	public string GetListTranslation(int int_0)
	{
		List<string> list = new List<string>();
		list.Add(Class16.smethod_0(1648929947) + Lists[int_0].uListName);
		int num = 1;
		ACE.Elements.eList.eList eList2 = Lists[int_0];
		if (1 < (nint)eList2.elementTypes.LongLength)
		{
			do
			{
				string text = eList2.elementFields[num];
				string fieldName = GetFieldName(int_0, num);
				if (!(text == Class16.smethod_0(1648966655)))
				{
					list.Add(string.Concat(text + Class16.smethod_0(1648898262), fieldName));
				}
				num++;
				eList2 = Lists[int_0];
			}
			while (num < (nint)eList2.elementTypes.LongLength);
		}
		string result = string.Join(Class16.smethod_0(1648924428), list);
		GC.KeepAlive(this);
		return result;
	}

	public Dictionary<string, string> GetListTranslationMap(int int_0)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
		if (int_0 >= 0 && int_0 < ListCount)
		{
			ACE.Elements.eList.eList eList2 = Lists[int_0];
			int num = 1;
			if (1 < (nint)eList2.elementTypes.LongLength)
			{
				do
				{
					string text = eList2.elementFields[num];
					if (!string.IsNullOrWhiteSpace(text) && text != Class16.smethod_0(1648966655))
					{
						dictionary[text] = GetFieldName(int_0, num) ?? string.Empty;
					}
					num++;
				}
				while (num < (nint)eList2.elementTypes.LongLength);
			}
			GC.KeepAlive(this);
			return dictionary;
		}
		GC.KeepAlive(this);
		return dictionary;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsProbFieldStrict(int int_0, int int_1)
	{
		bool result;
		FIELDTYPE fIELDTYPE;
		if (int_0 >= 0 && Lists != null && int_0 < Lists.Length && Lists[int_0] != null && int_1 >= 0)
		{
			if (Lists[int_0].fieldtypes != null && int_1 < Lists[int_0].fieldtypes.Length && Lists[int_0].FieldDataTypes != null && int_1 < Lists[int_0].FieldDataTypes.Length)
			{
				List<int[]> list = null;
				FIELDTYPE fieldType = GetFieldType(int_0, int_1);
				bool flag;
				result = (flag = fieldType == FIELDTYPE.ft_prob);
				if (!flag && fieldType == FIELDTYPE.not_set && Lists[int_0].FieldDataTypes[int_1].data_type == FIELD_DATA_TYPE_ENUM.Float)
				{
					GetProbFieldsSuites();
					list = null;
					if (ProbFieldsSuites.TryGetValue(int_0, out list))
					{
						List<int[]>.Enumerator enumerator = list.GetEnumerator();
						if (!enumerator.MoveNext())
						{
							goto IL_0101;
						}
						while (Array.IndexOf(enumerator.Current, int_1) <= -1)
						{
							if (enumerator.MoveNext())
							{
								continue;
							}
							goto IL_0101;
						}
						result = true;
						fIELDTYPE = FIELDTYPE.ft_prob;
						goto IL_0104;
					}
				}
				goto IL_0115;
			}
			return false;
		}
		return false;
		IL_0104:
		Lists[int_0].fieldtypes[int_1] = fIELDTYPE;
		goto IL_0115;
		IL_0101:
		fIELDTYPE = FIELDTYPE.none;
		goto IL_0104;
		IL_0115:
		return result;
	}

	public void SaveListNamesTranslation([MarshalAs(UnmanagedType.U1)] bool bConvertToNormalEnglish, string FieldTypesPath)
	{
	}

	public void SaveListNamesAsTitledEnglish()
	{
		List<string> list = new List<string>(ListCount);
		int[] allLists = AllLists;
		int num = 0;
		if (0 < (nint)allLists.LongLength)
		{
			do
			{
				int num2 = allLists[num];
				string uListName = Lists[num2].uListName;
				string text = Class16.smethod_0(1648898262);
				string uListName2 = Lists[num2].uListName;
				list.Add(string.Concat(string.Concat(Class16.smethod_0(1649078580) + uListName2, text), ACE.RSGlobal.RSGlobal.GetListFriendlyName(uListName)));
				num++;
			}
			while (num < (nint)allLists.LongLength);
		}
		ACE.RSGlobal.RSGlobal.OpenInNotepad(list);
		GC.KeepAlive(this);
	}

	public void UpdateElementsReferences(int int_0)
	{
		ELEMENTS_IDS_REFERENCES eLEMENTS_IDS_REFERENCES = null;
		if (Lists == null || int_0 < 0 || int_0 >= (nint)Lists.LongLength || Lists[int_0] == null)
		{
			return;
		}
		switch (int_0)
		{
		default:
		{
			ELEMENTS_REFERENCES references = References;
			if (references.ReferencesSpecial == null)
			{
				references.InitElementsRefs(ListCount);
			}
			eLEMENTS_IDS_REFERENCES = new ELEMENTS_IDS_REFERENCES(ReferenceType.ELEMENTS_LIST);
			FillReferences(ref eLEMENTS_IDS_REFERENCES, Lists[int_0].References);
			References.ReferencesSpecial[int_0] = eLEMENTS_IDS_REFERENCES;
			break;
		}
		case 16777215:
			UpdateElementsReferences();
			break;
		case 8388607:
			UpdateMattersReferences();
			break;
		}
		GC.KeepAlive(this);
	}

	public void UpdateElementsReferences()
	{
		References.InitElementsRefs(ListCount);
		int[] allLists = AllLists;
		int num = 0;
		if (0 < (nint)allLists.LongLength)
		{
			do
			{
				UpdateElementsReferences(allLists[num]);
				num++;
			}
			while (num < (nint)allLists.LongLength);
		}
		UpdateMattersReferences();
		bRefsGenerated = true;
	}

	public void UpdateMattersReferences()
	{
		References.ReferencesMatters = new ELEMENTS_IDS_REFERENCES(ReferenceType.ELEMENTS_MATTERS);
		FillReferences(ref References.ReferencesMatters, MattersReferencesBase);
		Dictionary<ReferenceType, ELEMENTS_IDS_REFERENCES> referencesExtra = References.ReferencesExtra;
		if (referencesExtra != null)
		{
			if (referencesExtra.ContainsKey(ReferenceType.ELEMENTS_MATTERS))
			{
				ELEMENTS_REFERENCES references = References;
				references.ReferencesExtra[ReferenceType.ELEMENTS_MATTERS] = references.ReferencesMatters;
			}
			else
			{
				ELEMENTS_REFERENCES references2 = References;
				references2.ReferencesExtra.Add(ReferenceType.ELEMENTS_MATTERS, references2.ReferencesMatters);
			}
		}
		GC.KeepAlive(this);
	}

	public void FillReferences(ref ELEMENTS_IDS_REFERENCES ListRefs, Dictionary<int, List<int>> ReferencesBase)
	{
		if (ReferencesBase == null)
		{
			return;
		}
		try
		{
			Dictionary<int, List<int>>.Enumerator enumerator = ReferencesBase.GetEnumerator();
			if (enumerator.MoveNext())
			{
				INDICES ind = default(INDICES);
				do
				{
					ValueType valueType = enumerator.Current;
					int key = ((KeyValuePair<int, List<int>>)(object)valueType).Key;
					List<int> value = ((KeyValuePair<int, List<int>>)(object)valueType).Value;
					int num = GetItemsCount(key) - 1;
					if (num < 0)
					{
						continue;
					}
					do
					{
						int id = Lists[key].getid(num);
						GC.KeepAlive(this);
						List<int>.Enumerator enumerator2 = value.GetEnumerator();
						if (enumerator2.MoveNext())
						{
							do
							{
								int current = enumerator2.Current;
								int valueIFast = Lists[key].GetValueIFast(num, current);
								GC.KeepAlive(this);
								if (valueIFast > 0)
								{
									ind.int_0 = key;
									ind.int_1 = num;
									ind.int_2 = current;
									ListRefs.AddRef(ReferenceSubType.ELEMENTS_ANY_ITEM, key, null, ind, null, id, valueIFast);
								}
							}
							while (enumerator2.MoveNext());
						}
						num--;
					}
					while (num >= 0);
				}
				while (enumerator.MoveNext());
			}
		}
		catch (IndexOutOfRangeException)
		{
		}
		catch (InvalidCastException)
		{
		}
		catch (ArgumentException)
		{
		}
		GC.KeepAlive(this);
	}

	public int GetReferences(ref Dictionary<int, List<ELEMENTS_REFERENCES_SUITE>> dest, int int_0, List<int> IDs)
	{
		if (dest == null)
		{
			dest = new Dictionary<int, List<ELEMENTS_REFERENCES_SUITE>>();
		}
		if (IDs == null)
		{
			return 0;
		}
		ELEMENTS_REFERENCES references = References;
		if (references != null)
		{
			Dictionary<int, ELEMENTS_IDS_REFERENCES> referencesSpecial = references.ReferencesSpecial;
			if (referencesSpecial != null && referencesSpecial.ContainsKey(int_0))
			{
				goto IL_0034;
			}
		}
		UpdateElementsReferences(int_0);
		goto IL_0034;
		IL_0034:
		ItemType itemType = GetItemType(int_0, bNpcMobAndMineIsSame: false);
		int references2 = References.GetReferences(int_0, itemType, IDs, ref dest);
		GC.KeepAlive(this);
		return references2;
	}

	public int GetReferences(ref List<ELEMENTS_REFERENCES_SUITE> dest, ITEMPOS ItemPos)
	{
		List<ELEMENTS_REFERENCES_SUITE> list = null;
		int int_ = ItemPos.int_1;
		int int_2 = ItemPos.int_0;
		int num = Lists[int_2].getid(int_);
		GC.KeepAlive(this);
		if (num < 1)
		{
			return 0;
		}
		ELEMENTS_REFERENCES references = References;
		if (references != null)
		{
			Dictionary<int, ELEMENTS_IDS_REFERENCES> referencesSpecial = references.ReferencesSpecial;
			if (referencesSpecial != null && referencesSpecial.ContainsKey(ItemPos.int_0))
			{
				goto IL_005d;
			}
		}
		UpdateElementsReferences(ItemPos.int_0);
		goto IL_005d;
		IL_005d:
		int int_3 = ItemPos.int_0;
		ItemType itemType = GetItemType(int_3, bNpcMobAndMineIsSame: false);
		list = null;
		References.GetReferences(ItemPos.int_0, itemType, num, ref list);
		dest = list;
		int count = ELEMENTS_REFERENCES.GetCount(list);
		GC.KeepAlive(this);
		return count;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool GetReferencesFast(ref List<ELEMENTS_REFERENCES_SUITE> dest, ITEMPOS ItemPos, [MarshalAs(UnmanagedType.U1)] bool bOnlyElements)
	{
		List<ELEMENTS_REFERENCES_SUITE> list = null;
		int int_ = ItemPos.int_1;
		int int_2 = ItemPos.int_0;
		int num = Lists[int_2].getid(int_);
		GC.KeepAlive(this);
		if (num < 1)
		{
			return false;
		}
		ELEMENTS_REFERENCES references = References;
		if (references != null)
		{
			Dictionary<int, ELEMENTS_IDS_REFERENCES> referencesSpecial = references.ReferencesSpecial;
			if (referencesSpecial != null && referencesSpecial.ContainsKey(ItemPos.int_0))
			{
				goto IL_0060;
			}
		}
		UpdateElementsReferences(ItemPos.int_0);
		goto IL_0060;
		IL_0060:
		int int_3 = ItemPos.int_0;
		ItemType itemType = GetItemType(int_3, bNpcMobAndMineIsSame: false);
		if (bOnlyElements)
		{
			dest = References.GetElementsReferences(ItemPos.int_0, itemType, num);
		}
		else
		{
			list = null;
			References.GetReferences(ItemPos.int_0, itemType, num, ref list);
			dest = list;
		}
		List<ELEMENTS_REFERENCES_SUITE> list2 = dest;
		int num2 = ((list2 != null && list2.Count > 0) ? 1 : 0);
		GC.KeepAlive(this);
		return (byte)num2 != 0;
	}

	public ItemType GetItemType(int int_0, [MarshalAs(UnmanagedType.U1)] bool bNpcMobAndMineIsSame)
	{
		ItemType result = ItemType.All;
		bool flag = MattersListsFast != null && MattersListsFast.Contains(int_0);
		GC.KeepAlive(this);
		if (flag)
		{
			return ItemType.Matter;
		}
		string uListName = Lists[int_0].uListName;
		Enum.TryParse<ItemType>(string.Concat(GamePrefix + Class16.smethod_0(1648923968), uListName), out result);
		if (bNpcMobAndMineIsSame && Array.IndexOf(GetNpcMobMineListsIT(), result) > -1)
		{
			result = ItemType.NpcOrMobOrMine;
		}
		GC.KeepAlive(this);
		return result;
	}

	public ItemType GetItemType(int int_0)
	{
		return GetItemType(int_0, bNpcMobAndMineIsSame: false);
	}

	public ItemType[] GetNpcMobMineListsIT()
	{
		ItemType[] result = null;
		switch (Game)
		{
		case GAMES.PW:
			result = new ItemType[3]
			{
				ItemType.PW_NPC_ESSENCE,
				ItemType.PW_MONSTER_ESSENCE,
				ItemType.PW_MINE_ESSENCE
			};
			break;
		case GAMES.FW:
			result = new ItemType[3]
			{
				ItemType.FW_NPC_ESSENCE,
				ItemType.FW_MONSTER_ESSENCE,
				ItemType.FW_MINE_ESSENCE
			};
			break;
		case GAMES.JD:
			result = new ItemType[3]
			{
				ItemType.JD_NPC_ESSENCE,
				ItemType.JD_MONSTER_ESSENCE,
				ItemType.JD_MINE_ESSENCE
			};
			break;
		case GAMES.ESO:
			result = new ItemType[3]
			{
				ItemType.ESO_NPC_ESSENCE,
				ItemType.ESO_MONSTER_ESSENCE,
				ItemType.ESO_MINE_ESSENCE
			};
			break;
		}
		return result;
	}

	public ItemType ParseListType(string ListName)
	{
		ItemType result = ItemType.NONE;
		Enum.TryParse<ItemType>(string.Concat(GamePrefix + Class16.smethod_0(1648923968), ListName), out result);
		GC.KeepAlive(this);
		return result;
	}

	public ItemType GetListType(int int_0)
	{
		return Lists[int_0].ListType;
	}

	public string GenerateHTMLPreview_References(ITEMPOS ItemPos, [MarshalAs(UnmanagedType.U1)] bool bManyRefs, [MarshalAs(UnmanagedType.U1)] bool bReduceRefs, [MarshalAs(UnmanagedType.U1)] bool bAddLine, [MarshalAs(UnmanagedType.U1)] bool bUnlimited)
	{
		string text = string.Empty;
		List<ELEMENTS_REFERENCES_SUITE> dest = null;
		int references = GetReferences(ref dest, ItemPos);
		int num = CommonStorage.AParams.ToolTipReferencesNumLimit;
		if (bManyRefs)
		{
			num = ((40 < num * 2) ? 40 : (num * 2));
		}
		else if (bReduceRefs)
		{
			num = num / 2 + 3;
		}
		num = (bUnlimited ? 99999 : num);
		if (references != 0 && num > 0)
		{
			if (!bManyRefs)
			{
				text += Class16.smethod_0(1648958369);
			}
			if (bAddLine)
			{
				text += Class16.smethod_0(1648958369);
			}
			text += Class16.smethod_0(1649078596);
			Color cyan = Color.Cyan;
			object[] vars = new object[1] { references };
			string text2 = TextStorage.TEXTS.GetText(Class16.smethod_0(1649078638), vars);
			text += HTML_HELPER.EchoReferencesLink(text2, ItemPos, cyan);
			int num2 = num / dest.Count;
			if (num2 == 0)
			{
				num2 = 1;
				num = dest.Count;
			}
			int num3 = 0;
			int num4 = 0;
			if (0 < dest.Count)
			{
				do
				{
					ELEMENTS_REFERENCES_SUITE eLEMENTS_REFERENCES_SUITE = dest[num4];
					bool flag = eLEMENTS_REFERENCES_SUITE.RefType.DataFileType == DATA_FILES_ENUM.ELEMENTS;
					_ = Color.White;
					DATA_FILES_ENUM dataFileType = eLEMENTS_REFERENCES_SUITE.RefType.DataFileType;
					Color color_;
					string text3;
					if (dataFileType == DATA_FILES_ENUM.ELEMENTS)
					{
						ACE.Elements.eList.eList eList2 = Lists[eLEMENTS_REFERENCES_SUITE.ListIndex];
						text3 = ((!ACE.RSGlobal.RSGlobal.SHOW_UNIVERSAL_NAMES) ? eList2.ListName : eList2.uListName);
						color_ = Color.Gold;
					}
					else if (dataFileType != DATA_FILES_ENUM.TASKS)
					{
						if (dataFileType == DATA_FILES_ENUM.NPCGEN)
						{
							text3 = NPCGEN_LIST.GetInstanceName(eLEMENTS_REFERENCES_SUITE.RefType.param1);
							color_ = Color.MediumOrchid;
						}
						else
						{
							text3 = eLEMENTS_REFERENCES_SUITE.GetRefCaption();
							color_ = Color.CornflowerBlue;
						}
					}
					else
					{
						text3 = eLEMENTS_REFERENCES_SUITE.GetRefCaption();
						color_ = ((eLEMENTS_REFERENCES_SUITE.RefType.SubType < ReferenceSubType.TASKS_AWARD_SUCCESS_CAND_ITEMS) ? Color.LightSalmon : Color.LightGreen);
					}
					if (eLEMENTS_REFERENCES_SUITE.Count > 1)
					{
						int count = eLEMENTS_REFERENCES_SUITE.Count;
						string text4 = Class16.smethod_0(1648942897);
						text3 = string.Concat(text3, string.Concat(Class16.smethod_0(1648899468) + count, text4));
					}
					text3 += Class16.smethod_0(1648924402);
					string text5 = Class16.smethod_0(1648902161);
					string text6 = Class16.smethod_0(1648905490);
					text = string.Concat(text, string.Concat(string.Concat(string.Concat(Class16.smethod_0(1649078661) + ACE.RSGlobal.RSGlobal.Color2HTML(color_), text6), text3), text5));
					if (num4 == dest.Count - 1)
					{
						num2 = num - num3;
					}
					int num5 = ((((num2 >= eLEMENTS_REFERENCES_SUITE.Count) ? eLEMENTS_REFERENCES_SUITE.Count : num2) == 1 && dest.Count > 7) ? 1 : 0);
					bool bOneLine = (byte)num5 != 0;
					eLEMENTS_REFERENCES_SUITE.InitEnumerator(num2);
					REFERENCE_ENTRY next = eLEMENTS_REFERENCES_SUITE.GetNext();
					if (next == null)
					{
						goto IL_0275;
					}
					while (num3 < num)
					{
						text = ((!flag) ? (text + EchoItem(ItemPos, next, eLEMENTS_REFERENCES_SUITE.RefType, bOneLine, IsTaskHint: false, 0, bUnderline: false)) : (text + EchoItem(next.FieldPos, bOneLine)));
						num3++;
						next = eLEMENTS_REFERENCES_SUITE.GetNext();
						if (next != null)
						{
							continue;
						}
						goto IL_0275;
					}
					goto IL_0284;
					IL_0275:
					if (num3 >= num || eLEMENTS_REFERENCES_SUITE.Count > num2)
					{
						goto IL_0284;
					}
					goto IL_029d;
					IL_0284:
					text += Class16.smethod_0(1649078702);
					if (num3 >= num)
					{
						break;
					}
					goto IL_029d;
					IL_029d:
					num4++;
				}
				while (num4 < dest.Count);
			}
			text += Class16.smethod_0(1648902161);
			if (bManyRefs)
			{
				text += Class16.smethod_0(1648958369);
			}
			GC.KeepAlive(this);
			return text;
		}
		GC.KeepAlive(this);
		return string.Empty;
	}

	public string GenerateHTMLPreview_References(ITEMPOS ItemPos)
	{
		return GenerateHTMLPreview_References(ItemPos, bManyRefs: true, bReduceRefs: false, bAddLine: false, bUnlimited: false);
	}

	public string EchoItem(HTML_HELPER HtmlData, [MarshalAs(UnmanagedType.U1)] bool bOneLine)
	{
		FIELDPOS linkField = HtmlData.LinkField;
		if (linkField != null && HtmlData.LinkItem == null)
		{
			HtmlData.LinkItem = new ITEMPOS(linkField.int_0, linkField.int_1);
		}
		if (HtmlData.ItemInfo == null)
		{
			ITEMPOS linkItem = HtmlData.LinkItem;
			if (linkItem != null)
			{
				ITEMINFO iTEMINFO = (HtmlData.ItemInfo = GetItemInfo(linkItem, bUseCache: true, bCheckIsFreeID: true, bCheckHasReferences: true));
				if (iTEMINFO != null && HtmlData.bViewIcon && HtmlData.icon == null)
				{
					string iconName = iTEMINFO.IconName;
					if (iconName != null)
					{
						int int_ = HtmlData.LinkItem.int_0;
						bool isTga = Lists != null && int_ >= 0 && int_ < Lists.Length && Lists[int_] != null && Lists[int_].IsTgaIcon;
						HtmlData.icon = Icons.GetIcon(iconName, isTga, HtmlData.icon_size);
					}
				}
			}
		}
		ITEMINFO itemInfo = HtmlData.ItemInfo;
		if (itemInfo != null)
		{
			if (HtmlData.ID == 0)
			{
				HtmlData.ID = itemInfo.id;
			}
			if (HtmlData.Name == null)
			{
				HtmlData.Name = itemInfo.name;
			}
			Color white = Color.White;
			if (HtmlData.NameColor == white)
			{
				ref Color nameColor = ref HtmlData.NameColor;
				nameColor = HtmlData.ItemInfo.color;
			}
			if (HtmlData.bIconNecessarily && HtmlData.icon == null)
			{
				HtmlData.icon = Icons.GetIcon(null, IsTga: false, 16);
			}
			else
			{
				Image icon = HtmlData.icon;
				if (icon != null && icon.Tag != null)
				{
					string text = Class16.smethod_0(1648904718);
					if ((string)HtmlData.icon.Tag == text)
					{
						HtmlData.icon = null;
					}
				}
			}
			int int_2 = HtmlData.ItemInfo.pos.int_0;
			if (Lists != null && int_2 >= 0 && int_2 < Lists.Length && Lists[int_2] != null && (Lists[int_2].uListName == Class16.smethod_0(1649078718) || Lists[int_2].uListName == Class16.smethod_0(1649078729)))
			{
				Color titleBorderColor = ACE.RSGlobal.RSGlobal.GetTitleBorderColor(HtmlData.NameColor);
				HtmlData.NameBorderColor = titleBorderColor;
			}
		}
		if (HtmlData.bViewListName)
		{
			ITEMPOS linkItem2 = HtmlData.LinkItem;
			if (linkItem2 != null)
			{
				ACE.Elements.eList.eList eList2 = Lists[linkItem2.int_0];
				string listName = ((!ACE.RSGlobal.RSGlobal.SHOW_UNIVERSAL_NAMES) ? eList2.ListName : eList2.uListName);
				HtmlData.ListName = listName;
			}
		}
		HtmlData.FirstListIndexIs1 = CommonStorage.Params.FirstListIndexIs1;
		string result = ((!bOneLine) ? Class16.smethod_0(1648958369) : string.Empty) + HtmlData.GetItemHtml();
		GC.KeepAlive(this);
		return result;
	}

	public string EchoItem(HTML_HELPER HtmlData)
	{
		return EchoItem(HtmlData, bOneLine: true);
	}

	public unsafe string EchoItem(FIELDPOS fp, [MarshalAs(UnmanagedType.U1)] bool bOneLine)
	{
		object obj = null;
		string text = null;
		string text2 = null;
		string fieldName = GetFieldName(fp.int_0, fp.int_2);
		obj = null;
		text = null;
		text2 = null;
		int num = default(int);
		FIELDTYPE fIELDTYPE = default(FIELDTYPE);
		TryGetRefExtraVal(fp, ref obj, ref text, ref text2, &num, &fIELDTYPE);
		HTML_HELPER hTML_HELPER = new HTML_HELPER();
		hTML_HELPER.LinkField = fp;
		hTML_HELPER.extra1 = fieldName;
		hTML_HELPER.extra2 = text;
		hTML_HELPER.bIconNecessarily = true;
		return EchoItem(hTML_HELPER, bOneLine);
	}

	public string EchoItem(ITEMPOS ItemPos, REFERENCE_ENTRY reference, REFERENCE_TYPE_EX RefType, [MarshalAs(UnmanagedType.U1)] bool bOneLine, [MarshalAs(UnmanagedType.U1)] bool IsTaskHint, int item_id, [MarshalAs(UnmanagedType.U1)] bool bUnderline)
	{
		HTML_HELPER hTML_HELPER = new HTML_HELPER();
		switch (RefType.DataFileType)
		{
		case DATA_FILES_ENUM.TASKS:
			if (!IsTaskHint)
			{
				QUEST_INFO qUEST_INFO = (QUEST_INFO)reference.oSpecial;
				hTML_HELPER.ID = qUEST_INFO.id;
				hTML_HELPER.Name = qUEST_INFO.name;
				ref Color nameColor2 = ref hTML_HELPER.NameColor;
				nameColor2 = qUEST_INFO.color;
				hTML_HELPER.icon = qUEST_INFO.image;
				hTML_HELPER.LinkTaskID = qUEST_INFO.id;
			}
			else
			{
				hTML_HELPER.ID = item_id;
				if (ItemPos != null)
				{
					hTML_HELPER.LinkItem = ItemPos;
					hTML_HELPER.bNameUnderline = bUnderline;
				}
				else
				{
					TextStorage tEXTS = TextStorage.TEXTS;
					hTML_HELPER.Name = tEXTS.GetText(tEXTS.ResolveLegacyMessageKey(151, 0), null);
					Color red2 = Color.Red;
					hTML_HELPER.NameColor = red2;
					hTML_HELPER.bNameBold = true;
				}
			}
			hTML_HELPER.extra2 = reference.Value2;
			break;
		case DATA_FILES_ENUM.NPCGEN:
		{
			ITEMINFO itemInfo2 = GetItemInfo(ItemPos, bUseCache: true, bCheckIsFreeID: false, bCheckHasReferences: false);
			if (itemInfo2 == null)
			{
				return string.Empty;
			}
			hTML_HELPER.ID = reference.id;
			NPCGEN_LIST npcGenList = NpcGenList;
			if (npcGenList != null)
			{
				hTML_HELPER.Name = HttpUtility.HtmlEncode(npcGenList.GetAreaName(RefType.param1, RefType.param2, reference));
			}
			hTML_HELPER.bHtmlEncode = false;
			Color white = Color.White;
			string text3 = Class16.smethod_0(1648902161);
			string text4 = Class16.smethod_0(1649078764);
			string name2 = hTML_HELPER.Name;
			hTML_HELPER.Name = string.Concat(name2, string.Concat(string.Concat(string.Concat(Class16.smethod_0(1648905508) + ACE.RSGlobal.RSGlobal.Color2HTML(white), text4), reference.GetNpcCoords(bWithRealCoords: false)), text3));
			ReferenceType sectionType = RefType.SectionType;
			if ((sectionType == ReferenceType.NPCGEN_MONSTERS && itemInfo2.item_type != ItemType.PW_MONSTER_ESSENCE) || (sectionType == ReferenceType.NPCGEN_NPCS && itemInfo2.item_type != ItemType.PW_NPC_ESSENCE))
			{
				int index = ((sectionType != ReferenceType.NPCGEN_MONSTERS) ? 1 : 0);
				string text5 = TextStorage.TEXTS.GetText(TextStorage.TEXTS.ResolveLegacyMessageKey(725, index), null);
				string name3 = hTML_HELPER.Name;
				string text6 = Class16.smethod_0(1649078775);
				hTML_HELPER.Name = string.Concat(string.Concat(text5 + itemInfo2.name, text6), name3);
				Color red3 = Color.Red;
				hTML_HELPER.NameColor = red3;
			}
			else
			{
				ref Color nameColor3 = ref hTML_HELPER.NameColor;
				nameColor3 = itemInfo2.color;
			}
			object[] vars = new object[1] { reference.Value2 };
			TextStorage tEXTS2 = TextStorage.TEXTS;
			hTML_HELPER.extra2 = tEXTS2.GetText(tEXTS2.ResolveLegacyMessageKey(717, 0), vars);
			break;
		}
		case DATA_FILES_ENUM.GSHOP:
		case DATA_FILES_ENUM.GSHOP1:
		case DATA_FILES_ENUM.GSHOP2:
		case DATA_FILES_ENUM.EXTRA_DROPS:
		case DATA_FILES_ENUM.GSHOP3:
		{
			ITEMINFO itemInfo = GetItemInfo(ItemPos, bUseCache: true, bCheckIsFreeID: true, bCheckHasReferences: true);
			hTML_HELPER.ID = reference.id;
			hTML_HELPER.Name = reference.Name;
			if (itemInfo != null)
			{
				ref Color nameColor = ref hTML_HELPER.NameColor;
				nameColor = itemInfo.color;
				if (IsIconsExist(itemInfo.pos.int_0))
				{
					hTML_HELPER.icon = Icons.GetIcon(itemInfo.IconName, itemInfo.IsTgaIcon, 16);
				}
			}
			else
			{
				Color red = Color.Red;
				hTML_HELPER.NameColor = red;
				string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1648924372));
				string name = hTML_HELPER.Name;
				hTML_HELPER.Name = string.Concat(name, Class16.smethod_0(1648942211) + text);
			}
			string text2 = (hTML_HELPER.extra2 = reference.Value2);
			ReferenceSubType subType = RefType.SubType;
			if (subType == ReferenceSubType.GSHOP_GOODS || subType == ReferenceSubType.GSHOP1_GOODS || subType == ReferenceSubType.GSHOP2_GOODS || subType == ReferenceSubType.GSHOP3_GOODS)
			{
				hTML_HELPER.extra2 = text2 + Class16.smethod_0(1649078778);
			}
			break;
		}
		}
		if (ACE.RSGlobal.RSGlobal.IsUIntFast(hTML_HELPER.extra1 = reference.Value1))
		{
			hTML_HELPER.extra1 = CommonStorage.GetPieces(ACE.RSGlobal.RSGlobal.UIntParseFast(hTML_HELPER.extra1));
		}
		GC.KeepAlive(this);
		return EchoItem(hTML_HELPER, bOneLine);
	}

	public unsafe string GetExtraRefValue(FIELDPOS RefFieldPos)
	{
		object dest = null;
		string str = null;
		string ExtraValFieldName = null;
		int num = default(int);
		FIELDTYPE fIELDTYPE = default(FIELDTYPE);
		TryGetRefExtraVal(RefFieldPos, ref dest, ref str, ref ExtraValFieldName, &num, &fIELDTYPE);
		return str;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public unsafe bool TryGetRefExtraVal(FIELDPOS FieldPos, ref object dest, ref string str, ref string ExtraValFieldName, int* ExtraValFieldIndex, FIELDTYPE* ftype)
	{
		if (Lists[FieldPos.int_0].uListName == Class16.smethod_0(1648952504))
		{
			GC.KeepAlive(this);
			return false;
		}
		int int_ = FieldPos.int_1;
		int int_2 = FieldPos.int_0;
		if (int_2 > -1 && int_2 < ListCount && int_ > -1 && int_ < GetItemsCount(int_2))
		{
			int num = FieldPos.int_2 + 1;
			int int_3 = FieldPos.int_0;
			int num2 = ((num < (nint)Lists[int_3].elementTypes.LongLength && GetFieldType(int_3, FieldPos.int_1, num) <= FIELDTYPE.ft_prob && IsNumericType(FieldPos.int_0, num)) ? 1 : 0);
			byte b = (byte)num2;
			bool flag = b != 0;
			if (b != 0)
			{
				if (Game != GAMES.Chibi)
				{
					string text = Lists[FieldPos.int_0].elementFields[FieldPos.int_2];
					int num3 = text.IndexOf(Class16.smethod_0(1648923968));
					if (num3 > 0)
					{
						string value = text.Substring(0, num3);
						flag = Lists[FieldPos.int_0].elementFields[num].StartsWith(value);
					}
				}
				if (flag)
				{
					*ExtraValFieldIndex = num;
					if (IsProbField(FieldPos.int_0, num))
					{
						TextStorage tEXTS = TextStorage.TEXTS;
						ExtraValFieldName = tEXTS.GetText(tEXTS.ResolveLegacyMessageKey(703, 0), null);
						*ftype = FIELDTYPE.ft_prob;
					}
					else if (IsCountField(FieldPos.int_0, num))
					{
						TextStorage tEXTS2 = TextStorage.TEXTS;
						ExtraValFieldName = tEXTS2.GetText(tEXTS2.ResolveLegacyMessageKey(703, 1), null);
						*ftype = FIELDTYPE.ft_count;
					}
					else
					{
						ExtraValFieldName = NamesConverter.RemoveIndices(GetFieldName(FieldPos.int_0, num));
					}
					int int_4 = FieldPos.int_0;
					ACE.Elements.eList.eList[] lists = Lists;
					ACE.Elements.eList.eList eList2 = lists[int_4];
					if (eList2.FieldDataTypes[num].data_type == FIELD_DATA_TYPE_ENUM.Float)
					{
						int int_5 = FieldPos.int_1;
						float valueF = eList2.GetValueF(int_5, num);
						GC.KeepAlive(this);
						dest = valueF;
						int numAfterDecimal = 2;
						if ((double)valueF < 0.0001)
						{
							numAfterDecimal = 4;
						}
						str = ACE.RSGlobal.RSGlobal.ToPercent(valueF, numAfterDecimal);
					}
					else
					{
						int int_6 = FieldPos.int_1;
						int num4 = int_4;
						int valueIFast = lists[num4].GetValueIFast(int_6, num);
						GC.KeepAlive(this);
						dest = valueIFast;
						if (*ftype == FIELDTYPE.ft_count)
						{
							str = CommonStorage.GetPieces(valueIFast);
						}
						else
						{
							int num5 = valueIFast;
							str = num5.ToString(Class16.smethod_0(1648909972));
						}
					}
					goto IL_0270;
				}
			}
			*ExtraValFieldIndex = -1;
			goto IL_0270;
		}
		return false;
		IL_0270:
		GC.KeepAlive(this);
		return dest != null;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsCountField(int int_0, int int_1)
	{
		ACE.Elements.eList.eList eList2 = Lists[int_0];
		ref string reference = ref eList2.elementFields[int_1];
		FIELD_DATA_TYPE_ENUM data_type = eList2.FieldDataTypes[int_1].data_type;
		int num = ((((data_type == FIELD_DATA_TYPE_ENUM.Int || data_type == FIELD_DATA_TYPE_ENUM.UInt) && reference.EndsWith(Class16.smethod_0(1648961470))) || reference.Contains(Class16.smethod_0(1648961473)) || reference.Contains(Class16.smethod_0(1648961493))) ? 1 : 0);
		GC.KeepAlive(this);
		return (byte)num != 0;
	}

	public void ParseHintFields(StreamReader HintFields_sr)
	{
		ACE.Elements.eList.eList eList2 = null;
		bool flag = false;
		string text = HintFields_sr.ReadLine();
		if (text != null)
		{
			do
			{
				if (!string.IsNullOrWhiteSpace(text))
				{
					if (text[0] == '#')
					{
						int num = text.IndexOf(Class16.smethod_0(1648924402));
						string text2 = ((num <= -1) ? text.Substring(1) : text.Substring(num + 1, text.Length - num - 1));
						string text3 = text2;
						// TODO(recovered): comment-header guard (empty token from a plain comment line).
						if (string.IsNullOrWhiteSpace(text2))
						{
							text = HintFields_sr.ReadLine();
							continue;
						}
						bool flag2;
						flag = (flag2 = text3[text3.Length - 1] == '~');
						if (flag2)
						{
							text2 = text2.Substring(0, text2.Length - 1);
						}
						int num2 = this.get_LI(text2);
						eList2 = ((num2 == -1) ? null : Lists[num2]);
					}
					else if (eList2 != null)
					{
						if (eList2.HintFields == null)
						{
							eList2.HintFields = new List<string>();
						}
						string text4 = text;
						bool flag3 = false;
						if (text[0] == '~')
						{
							flag3 = true;
							text4 = text.Substring(1);
						}
						if (flag)
						{
							flag3 = text4.Contains(Class16.smethod_0(1648938114));
						}
						if (flag3)
						{
							int num3 = 0;
							if (0 < (nint)eList2.elementTypes.LongLength)
							{
								do
								{
									if (Regex.IsMatch(eList2.elementFields[num3], text4))
									{
										eList2.HintFields.Add(eList2.elementFields[num3]);
									}
									num3++;
								}
								while (num3 < (nint)eList2.elementTypes.LongLength);
							}
						}
						else
						{
							eList2.HintFields.Add(text4);
						}
					}
				}
				text = HintFields_sr.ReadLine();
			}
			while (text != null);
		}
		HintFields_sr.Close();
		GC.KeepAlive(this);
	}

	public void ParseFieldLimits(StreamReader sr)
	{
		ACE.Elements.eList.eList eList2 = null;
		string text = sr.ReadLine();
		if (text != null)
		{
			long result = 0L;
			FIELD_LIMITS value = default(FIELD_LIMITS);
			do
			{
				if (!string.IsNullOrWhiteSpace(text))
				{
					if (text[0] == '#')
					{
						int num = text.IndexOf(Class16.smethod_0(1648924402));
						string lIST_NAME = ((num <= -1) ? text.Substring(1) : text.Substring(num + 1, text.Length - num - 1));
						int num2 = this.get_LI(lIST_NAME);
						eList2 = ((num2 == -1) ? null : Lists[num2]);
					}
					else if (eList2 != null)
					{
						if (eList2.FieldLimits == null)
						{
							eList2.FieldLimits = new Dictionary<int, FIELD_LIMITS>();
						}
						string[] array = text.Split(';');
						string text2 = array[0];
						if (text2[0] == '~')
						{
							text2 = text2.Substring(1);
						}
						bool isRegex = text2.Contains(Class16.smethod_0(1648938114));
						List<int> fields = eList2.GetFields(text2, isRegex);
						if (fields.Count > 0)
						{
							long result2 = 0L;
							switch (array.Length)
							{
							case 3:
								long.TryParse(array[1], out result2);
								long.TryParse(array[2], out result);
								break;
							case 2:
								long.TryParse(array[1], out result);
								break;
							}
							if (result < result2)
							{
								result = result2;
							}
							List<int>.Enumerator enumerator = fields.GetEnumerator();
							if (enumerator.MoveNext())
							{
								do
								{
									int current = enumerator.Current;
									value.minimum = result2;
									value.maximum = result;
									eList2.FieldLimits.Add(current, value);
								}
								while (enumerator.MoveNext());
							}
						}
					}
				}
				text = sr.ReadLine();
			}
			while (text != null);
		}
		sr.Close();
		GC.KeepAlive(this);
	}

	public void LoadLocalization()
	{
		if (TranslatedFieldsGlobal == null)
		{
			TranslatedFieldsGlobal = new FIELDS_TRANSLATER(0, 0);
		}
		method_43();
		if (!ACE.RSGlobal.RSGlobal.ELEMENTS_DEBUG)
		{
			for (int num = ListCount - 1; num >= 0; num--)
			{
				if (Lists[num].ListName == Lists[num].uListName)
				{
					Lists[num].ListName = ACE.RSGlobal.RSGlobal.GetListFriendlyName(Lists[num].uListName);
				}
			}
		}
		SetGlobalTranslation();
	}

	public void SetGlobalTranslation()
	{
		ACE.Elements.eList.eList[] lists = Lists;
		int num = 0;
		if (0 < (nint)lists.LongLength)
		{
			do
			{
				lists[num].TranslationGlobal = TranslatedFieldsGlobal;
				num++;
			}
			while (num < (nint)lists.LongLength);
		}
	}

	public void UpdateShortcuts(List<ITEMINFO> Shortcuts)
	{
		int[] array = null;
		ShortcutItems = new Dictionary<int, int[]>(Shortcuts.Count);
		List<ITEMINFO>.Enumerator enumerator = Shortcuts.GetEnumerator();
		if (enumerator.MoveNext())
		{
			do
			{
				ITEMINFO current = enumerator.Current;
				array = null;
				if (ShortcutItems.TryGetValue(current.pos.int_0, out array))
				{
					ACE.RSGlobal.RSGlobal.AddValueToStack(ref array, current.id, 10);
					ShortcutItems[current.pos.int_0] = array;
				}
				else
				{
					int[] value = new int[1] { current.id };
					ShortcutItems.Add(current.pos.int_0, value);
				}
			}
			while (enumerator.MoveNext());
		}
		PRIORITY_ITEMS.ShortcutItems = ShortcutItems;
	}

	public int findex(int int_0, string field_name)
	{
		int result = Lists[int_0].get_fields(field_name);
		GC.KeepAlive(this);
		return result;
	}

	public int GetIdFast(int int_0, int int_1)
	{
		int result = Lists[int_0].IDs[int_1];
		GC.KeepAlive(this);
		return result;
	}

	public string GenerateRefineHint(ITEMPOS ItemPos, int int_0)
	{
		int valueI = GetValueI(ItemPos, int_0);
		if (valueI == 0)
		{
			string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1649081859));
			GC.KeepAlive(this);
			return text;
		}
		ITEMPOS iTEMPOS = null;
		int num = FindItemIndexByID(0, valueI);
		if (num > -1)
		{
			iTEMPOS = new ITEMPOS(0, num);
		}
		if (iTEMPOS == null)
		{
			string text2 = TextStorage.TEXTS.GetText(Class16.smethod_0(1649081882));
			GC.KeepAlive(this);
			return text2;
		}
		if (ACE.RSGlobal.RSGlobal.AntiRecurse_GenerateRefineHint_eListCollection)
		{
			GC.KeepAlive(this);
			return string.Empty;
		}
		ACE.RSGlobal.RSGlobal.AntiRecurse_GenerateRefineHint_eListCollection = true;
		try
		{
			StringBuilder stringBuilder = new StringBuilder(20480);
			ParamsClass paramsClass = Params;
			bool previewRefine = paramsClass.PreviewRefine;
			int previewRefineLevel = paramsClass.PreviewRefineLevel;
			paramsClass.PreviewRefine = true;
			int num2 = 1;
			string head;
			do
			{
				Params.PreviewRefineLevel = num2;
				Color dynamicColor = ACE.RSGlobal.RSGlobal.GetDynamicColor(num2, 12, IsStrict: true);
				DESC_EX itemHTML = GetItemHTML(ItemPos, IsShopPrice: false, bUnlimited: false, bOnlyRefines: true, null);
				head = itemHTML.head;
				if (Lists[ItemPos.int_0].ListType == ItemType.PW_WEAPON_ESSENCE)
				{
					itemHTML.Refines.Reverse();
				}
				else if (itemHTML.Refines.Count >= 5)
				{
					string text3 = null;
					List<string>.Enumerator enumerator = itemHTML.Refines.GetEnumerator();
					if (enumerator.MoveNext())
					{
						do
						{
							string text4 = Regex.Match(enumerator.Current, Class16.smethod_0(1648902914)).Groups[0].ToString();
							if (text3 == null)
							{
								text3 = text4;
							}
							else if (text3 != text4)
							{
								text3 = null;
								break;
							}
						}
						while (enumerator.MoveNext());
					}
					if (text3 != null)
					{
						bool flag = itemHTML.Refines.Count == 6;
						itemHTML.Refines.Clear();
						if (flag)
						{
							itemHTML.Refines.Add(TextStorage.TEXTS.GetText(TextStorage.TEXTS.ResolveLegacyMessageKey(894, 0), text3));
						}
						else
						{
							itemHTML.Refines.Add(TextStorage.TEXTS.GetText(TextStorage.TEXTS.ResolveLegacyMessageKey(893, 0), text3));
						}
					}
				}
				string text5 = string.Format(Class16.smethod_0(1649081905), num2, string.Join(Class16.smethod_0(1648993435), itemHTML.Refines));
				stringBuilder.AppendLine(Class16.smethod_0(1648903120) + HTML_HELPER.EchoTextColored(dynamicColor, bBold: true, text5));
				num2++;
			}
			while (num2 <= 12);
			Params.PreviewRefine = previewRefine;
			Params.PreviewRefineLevel = previewRefineLevel;
			DESC_EX itemHTML2 = GetItemHTML(iTEMPOS, IsShopPrice: false, bUnlimited: false);
			StringBuilder stringBuilder2 = new StringBuilder(40000);
			stringBuilder2.Append(Class16.smethod_0(1648903003));
			stringBuilder2.Append(itemHTML2.head);
			stringBuilder2.Append(itemHTML2.body);
			string text6 = Class16.smethod_0(1649081923);
			stringBuilder2.AppendLine(string.Concat(Class16.smethod_0(1649081940) + head, text6));
			if (stringBuilder.Length > 0)
			{
				stringBuilder2.AppendLine(stringBuilder.ToString());
			}
			stringBuilder2.Append(itemHTML2.refs);
			stringBuilder2.Append(itemHTML2.errors);
			stringBuilder2.Append(itemHTML2.duplicates);
			stringBuilder2.Append(Class16.smethod_0(1648953247));
			string result = stringBuilder2.ToString();
			GC.KeepAlive(this);
			return result;
		}
		finally
		{
			ACE.RSGlobal.RSGlobal.AntiRecurse_GenerateRefineHint_eListCollection = false;
		}
	}

	public string GenerateRefineHint(int int_0, int int_1, int int_2)
	{
		return GenerateRefineHint(new ITEMPOS(int_0, int_1), int_2);
	}

	public string GenerateRefineHint(int int_0, int int_1)
	{
		int int_2 = Lists[int_0].get_fields(Class16.smethod_0(1648961893));
		string result = GenerateRefineHint(new ITEMPOS(int_0, int_1), int_2);
		GC.KeepAlive(this);
		return result;
	}

	public string GenerateRefineText(int addonid, int level)
	{
		if (addonid == 0)
		{
			string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1649081859));
			GC.KeepAlive(this);
			return text;
		}
		ITEMPOS iTEMPOS = null;
		int num = FindItemIndexByID(0, addonid);
		if (num > -1)
		{
			iTEMPOS = new ITEMPOS(0, num);
		}
		if (iTEMPOS == null)
		{
			string text2 = TextStorage.TEXTS.GetText(Class16.smethod_0(1649081882));
			GC.KeepAlive(this);
			return text2;
		}
		int valueI = GetValueI(iTEMPOS.int_0, iTEMPOS.int_1, Class16.smethod_0(1648962073));
		level = ((level < 1) ? 12 : level);
		object[] array = new object[3];
		string empty = string.Empty;
		string oldValue = Class16.smethod_0(1648941500);
		string text3 = Addons.GetAddonTitleByID(addonid).Replace(oldValue, empty);
		array[0] = text3;
		int num2 = addonid;
		array[1] = num2.ToString();
		array[2] = Addons.GetRefineBonus(level, valueI).ToString();
		string text4 = TextStorage.TEXTS.GetText(Class16.smethod_0(1649081946), array);
		GC.KeepAlive(this);
		return text4;
	}

	public string EchoRefineAddon(int addonid, int level, [MarshalAs(UnmanagedType.U1)] bool disableLinks)
	{
		string text = GenerateRefineText(addonid, level);
		Color lightGreen = Color.LightGreen;
		string result = EchoAddon(addonid, text, lightGreen, disableLinks);
		GC.KeepAlive(this);
		return result;
	}

	public string EchoAddon(int addonid, string text, Color color, [MarshalAs(UnmanagedType.U1)] bool disableLinks)
	{
		HTML_HELPER hTML_HELPER = new HTML_HELPER();
		hTML_HELPER.bViewIcon = false;
		hTML_HELPER.bNameBold = true;
		hTML_HELPER.bViewID = false;
		ITEMPOS linkItem = null;
		int num = FindItemIndexByID(0, addonid);
		if (num > -1)
		{
			linkItem = new ITEMPOS(0, num);
		}
		hTML_HELPER.LinkItem = linkItem;
		hTML_HELPER.Name = text;
		hTML_HELPER.NameColor = color;
		hTML_HELPER.bDisableLinks = disableLinks;
		string itemHtml = hTML_HELPER.GetItemHtml();
		GC.KeepAlive(this);
		return itemHtml;
	}

	public string EchoAddon(int addonid, [MarshalAs(UnmanagedType.U1)] bool disableLinks)
	{
		Color color = Color.FromArgb(7500528);
		string result = EchoAddon(addonid, Addons.GetAddonNameByID(addonid), color, disableLinks);
		GC.KeepAlive(this);
		return result;
	}

	public string EchoAddon(int addonid, string text, [MarshalAs(UnmanagedType.U1)] bool disableLinks)
	{
		ITEMPOS itemPos = null;
		int num = FindItemIndexByID(0, addonid);
		if (num > -1)
		{
			itemPos = new ITEMPOS(0, num);
		}
		ITEMINFO itemInfo = GetItemInfo(itemPos, bUseCache: true, bCheckIsFreeID: true, bCheckHasReferences: true);
		Color color = Color.FromArgb(7500528);
		if (itemInfo != null)
		{
			color = itemInfo.color;
		}
		GC.KeepAlive(this);
		return EchoAddon(addonid, text, color, disableLinks);
	}

	public void SaveFieldsTranslationRegEx(string LocalizedFieldPath)
	{
	}

	public void SetFieldName(int int_0, string field, string TranslatedField, [MarshalAs(UnmanagedType.U1)] bool bCheckRegex)
	{
		if (string.IsNullOrEmpty(field))
		{
			throw new ArgumentException(Class16.smethod_0(1649081969), Class16.smethod_0(1649082010));
		}
		if (string.IsNullOrEmpty(TranslatedField))
		{
			throw new ArgumentException(Class16.smethod_0(1649082029), Class16.smethod_0(1649082073));
		}
		if (Lists == null)
		{
			throw new InvalidOperationException(Class16.smethod_0(1649082092));
		}
		if (int_0 >= 0 && int_0 < Lists.Length)
		{
			if (Lists[int_0] == null)
			{
				throw new InvalidOperationException(string.Format(Class16.smethod_0(1649082169), int_0));
			}
			if (TranslatedFieldsGlobal == null)
			{
				TranslatedFieldsGlobal = new FIELDS_TRANSLATER(0, 0);
			}
			if (bCheckRegex)
			{
				field = Regex.Replace(field, Class16.smethod_0(1649082220), Class16.smethod_0(1649082231));
				if (Regex.Replace(field, Class16.smethod_0(1648902914), Class16.smethod_0(1649082231)) != field)
				{
					field = Regex.Replace(field, Class16.smethod_0(1648902914), Class16.smethod_0(1648938114));
				}
				if (field.Contains(Class16.smethod_0(1648938114)) || field.Contains(Class16.smethod_0(1648927580)))
				{
					if (TranslatedField.Contains(Class16.smethod_0(1648938114)))
					{
						int num = 1;
						int num2 = 0;
						if (0 < TranslatedField.Length)
						{
							int num3 = 1;
							do
							{
								if (TranslatedField[num2] == '$')
								{
									int num4 = ((num2 < TranslatedField.Length - 1 && ((uint)TranslatedField[num3] > 57u || (uint)TranslatedField[num3] < 48u)) ? 1 : 0);
									if ((byte)num4 != 0 || num2 == TranslatedField.Length - 1)
									{
										int num5 = num;
										num2++;
										num3++;
										TranslatedField = TranslatedField.Insert(num2, num5.ToString());
										num++;
									}
								}
								num2++;
								num3++;
							}
							while (num2 < TranslatedField.Length);
						}
					}
					TranslatedFieldsGlobal.Add(field, TranslatedField, bCheckExistence: true, IsRegex: true);
					goto IL_0216;
				}
			}
			TranslatedFieldsGlobal.Add(field, TranslatedField, bCheckExistence: true, IsRegex: false);
			goto IL_0216;
		}
		throw new ArgumentOutOfRangeException(Class16.smethod_0(1649082121), string.Format(Class16.smethod_0(1649082140), int_0));
		IL_0216:
		GC.KeepAlive(this);
	}

	public void SaveAllGlobalTranslation([MarshalAs(UnmanagedType.U1)] bool userData)
	{
		//IL_0218: Unknown result type (might be due to invalid IL or missing references)
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0235: Expected O, but got Unknown
		string prefixOrCode = ((LANG_INFO.CurrentLang == null) ? Class16.smethod_0(1648931959) : LANG_INFO.CurrentLang.Prefix);
		string path = LocalizationBridge.ResolveLocaleCodeFromLegacyPrefix(prefixOrCode);
		string path2 = (userData ? System.IO.Path.Combine(Application.StartupPath, Class16.smethod_0(1648899207), Class16.smethod_0(1648899196)) : System.IO.Path.Combine(Application.StartupPath, Class16.smethod_0(1648899196)));
		string path3 = System.IO.Path.Combine(path2, path, Class16.smethod_0(1648906367), GamePrefix + Class16.smethod_0(1648899122));
		Directory.CreateDirectory(System.IO.Path.GetDirectoryName(path3));
		Dictionary<string, string> dictionary = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
		for (int i = 0; i < ListCount; i++)
		{
			ACE.Elements.eList.eList eList2 = Lists[i];
			dictionary[Class16.smethod_0(1649078580) + eList2.uListName] = eList2.ListName ?? string.Empty;
		}
		if (TranslatedFieldsGlobal != null)
		{
			foreach (KeyValuePair<string, string> translatedField in TranslatedFieldsGlobal.TranslatedFields)
			{
				dictionary[translatedField.Key] = translatedField.Value ?? string.Empty;
			}
			for (int j = 0; j < TranslatedFieldsGlobal.TranslatedFieldsRegEx.Count; j++)
			{
				string text = TranslatedFieldsGlobal.TranslatedFieldsRegEx.sRegexes[j] ?? string.Empty;
				text = text.Replace(Class16.smethod_0(1648902910), Class16.smethod_0(1648938114));
				if (text.Length > 2 && text[0] == '^' && text[text.Length - 1] == '$')
				{
					text = text.Substring(1, text.Length - 2);
				}
				string key = Class16.smethod_0(1648923237) + text;
				string value = TranslatedFieldsGlobal.TranslatedFieldsRegEx.Translations[j] ?? string.Empty;
				dictionary[key] = value;
			}
		}
		JObject val = new JObject { [Class16.smethod_0(1648899827)] = (JToken)(object)JObject.FromObject((object)dictionary) };
		File.WriteAllText(path3, ((JToken)val).ToString((Formatting)1), Encoding.UTF8);
		GC.KeepAlive(this);
	}

	public void SaveAllGlobalTranslation()
	{
		SaveAllGlobalTranslation(userData: true);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsListWithPages(int int_0)
	{
		ACE.Elements.eList.eList eList2 = Lists[int_0];
		string uListName = eList2.uListName;
		int num = ((eList2.get_fields(Class16.smethod_0(1649082232)) > -1 && uListName != Class16.smethod_0(1649082257) && uListName != Class16.smethod_0(1649082292)) ? 1 : 0);
		GC.KeepAlive(this);
		return (byte)num != 0;
	}

	public int TryGetPageCount(int int_0)
	{
		int num = 0;
		do
		{
			num++;
		}
		while (Lists[int_0].get_fields(string.Format(Class16.smethod_0(1649082322), num)) > -1);
		num = ((num > 9) ? 9 : num);
		GC.KeepAlive(this);
		return num - 1;
	}

	public unsafe void SetFieldTypesAutomatically(ToolStripProgressBar progress)
	{
		string[] searchedStrings = new string[30]
		{
			Class16.smethod_0(1649082357),
			Class16.smethod_0(1649082361),
			Class16.smethod_0(1649081356),
			Class16.smethod_0(1649081362),
			Class16.smethod_0(1649081379),
			Class16.smethod_0(1649081394),
			Class16.smethod_0(1649081413),
			Class16.smethod_0(1649081417),
			Class16.smethod_0(1649081438),
			Class16.smethod_0(1649081441),
			Class16.smethod_0(1649081462),
			Class16.smethod_0(1649081476),
			Class16.smethod_0(1648962188),
			Class16.smethod_0(1649081480),
			Class16.smethod_0(1649081499),
			Class16.smethod_0(1649081519),
			Class16.smethod_0(1649081533),
			Class16.smethod_0(1649081537),
			Class16.smethod_0(1648956046),
			Class16.smethod_0(1649081552),
			Class16.smethod_0(1649081572),
			Class16.smethod_0(1649081576),
			Class16.smethod_0(1649081596),
			Class16.smethod_0(1649081621),
			Class16.smethod_0(1648961470),
			Class16.smethod_0(1648891370),
			Class16.smethod_0(1648888564),
			Class16.smethod_0(1648906425),
			Class16.smethod_0(1648899764),
			Class16.smethod_0(1649081627)
		};
		HashSet<string> hashSet = new HashSet<string>(new string[6]
		{
			Class16.smethod_0(1649081647),
			Class16.smethod_0(1649081664),
			Class16.smethod_0(1649081690),
			Class16.smethod_0(1649081727),
			Class16.smethod_0(1649081764),
			Class16.smethod_0(1648952202)
		});
		int num = 0;
		if (0 < ListCount)
		{
			do
			{
				if (num != ConversationListIndex)
				{
					ACE.Elements.eList.eList eList2 = Lists[num];
					int num2 = 1;
					if (1 < (nint)eList2.elementTypes.LongLength)
					{
						do
						{
							FIELDTYPE fIELDTYPE = eList2.fieldtypes[num2];
							if (fIELDTYPE <= FIELDTYPE.none || fIELDTYPE == FIELDTYPE.ft_path_data)
							{
								string text = eList2.elementFields[num2];
								FIELD_DATA_TYPE_ENUM data_type = eList2.FieldDataTypes[num2].data_type;
								if (data_type != FIELD_DATA_TYPE_ENUM.WString && data_type != FIELD_DATA_TYPE_ENUM.String && data_type != FIELD_DATA_TYPE_ENUM.Double && data_type != FIELD_DATA_TYPE_ENUM.Bool)
								{
									if (text == Class16.smethod_0(1648960592) && eList2.IconFieldIndex < 0)
									{
										eList2.IconFieldIndex = num2;
										if (num2 > 0)
										{
											eList2.fieldtypes[num2] = FIELDTYPE.file_icon;
										}
									}
									else if (text.Contains(Class16.smethod_0(1649081413)) && text.EndsWith(Class16.smethod_0(1648932143)))
									{
										SetFieldType(Lists[num], num2, FIELDTYPE.ft_reputation);
									}
									else if (Game == GAMES.JD && (text == Class16.smethod_0(1648961685) || text == Class16.smethod_0(1649081801)))
									{
										SetFieldType(Lists[num], num2, FIELDTYPE.character_combo_id_jd);
									}
									else if (Game == GAMES.JD && (text == Class16.smethod_0(1648970148) || text == Class16.smethod_0(1648965136)))
									{
										SetFieldType(Lists[num], num2, FIELDTYPE.price_jd);
									}
									else if (text.Contains(Class16.smethod_0(1648888564)) && text.Contains(Class16.smethod_0(1648891370)))
									{
										SetFieldType(Lists[num], num2, FIELDTYPE.file_model);
									}
									else if (text.Contains(Class16.smethod_0(1649081438)))
									{
										FIELDTYPE ftype = DetermineIconType(num, num2);
										SetFieldType(Lists[num], num2, ftype);
									}
									else if (!text.StartsWith(Class16.smethod_0(1649081827)) && !text.Contains(Class16.smethod_0(1649081847)) && !text.EndsWith(Class16.smethod_0(1649080836)))
									{
										if ((data_type == FIELD_DATA_TYPE_ENUM.Int || data_type == FIELD_DATA_TYPE_ENUM.UInt) && (text.StartsWith(Class16.smethod_0(1649080840)) || text.StartsWith(Class16.smethod_0(1649080850)) || text.StartsWith(Class16.smethod_0(1649080869)) || text.StartsWith(Class16.smethod_0(1649080872)) || text.Contains(Class16.smethod_0(1649080883)) || text.StartsWith(Class16.smethod_0(1649080903))) && IsBooleanField(num, num2))
										{
											SetFieldType(Lists[num], num2, FIELDTYPE.ft_bool);
										}
										else if (text.Contains(Class16.smethod_0(1649080907)))
										{
											Lists[num].elementTypes[num2] = Class16.smethod_0(1648983932);
											SetFieldType(Lists[num], num2, FIELDTYPE.ft_hex_color);
										}
										else if (IsProbField(num, num2))
										{
											SetFieldType(Lists[num], num2, FIELDTYPE.ft_prob);
										}
										else if ((text.StartsWith(Class16.smethod_0(1648952248)) || text.Contains(Class16.smethod_0(1648986201))) && (hashSet.Contains(text) || text.EndsWith(Class16.smethod_0(1649080926)) || !ACE.RSGlobal.RSGlobal.IsStringContainsAnyStringInArray(text, searchedStrings)))
										{
											int bindedListIndex = -1;
											FIELDTYPE fIELDTYPE2 = TryToFindFieldBindedList(num, num2, null, &bindedListIndex);
											if (fIELDTYPE2 == FIELDTYPE.custom_list)
											{
												SetFieldBindedList(num, num2, bindedListIndex);
											}
											else
											{
												SetFieldType(Lists[num], num2, fIELDTYPE2);
											}
										}
									}
									else
									{
										SetFieldType(Lists[num], num2, FIELDTYPE.ft_path_data);
									}
									if (eList2.fieldtypes[num2] != FIELDTYPE.none)
									{
										SetFieldTypeToSimilarFields(num, num2);
									}
								}
							}
							num2++;
						}
						while (num2 < (nint)eList2.elementTypes.LongLength);
					}
					int listCount = ListCount;
					int value;
					if (num <= 0)
					{
						value = 0;
					}
					else if (listCount <= 0)
					{
						value = 100;
					}
					else
					{
						int num3 = 1 - (int)((double)num / (double)listCount * -99.0);
						num3 = ((num3 > 100) ? 100 : num3);
						value = num3;
					}
					if (progress != null && !progress.IsDisposed)
					{
						progress.Value = value;
						Application.DoEvents();
					}
				}
				num++;
			}
			while (num < ListCount);
		}
		if (progress != null && !progress.IsDisposed)
		{
			progress.Value = 0;
		}
		GC.KeepAlive(this);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsBooleanField(int int_0, int int_1)
	{
		int num = 0;
		if (0 < Lists[int_0].ItemCount)
		{
			do
			{
				int valueIFast = Lists[int_0].GetValueIFast(num, int_1);
				GC.KeepAlive(this);
				if ((uint)valueIFast <= 1u)
				{
					num++;
					continue;
				}
				return false;
			}
			while (num < Lists[int_0].ItemCount);
		}
		return true;
	}

	public unsafe FIELDTYPE DetermineIconType(int int_0, int int_1)
	{
		int num = 0;
		if (0 < Lists[int_0].ItemCount)
		{
			bool flag = default(bool);
			do
			{
				int valueIFast = Lists[int_0].GetValueIFast(num, int_1);
				GC.KeepAlive(this);
				string path = PathData.GetPath((uint)valueIFast, &flag);
				if (string.IsNullOrWhiteSpace(path) || !path.EndsWith(Class16.smethod_0(1648904836)))
				{
					num++;
					continue;
				}
				return FIELDTYPE.file_icon_tga;
			}
			while (num < Lists[int_0].ItemCount);
		}
		GC.KeepAlive(this);
		return FIELDTYPE.file_icon;
	}

	public void SetFieldTypeToSimilarFields(int int_0, int int_1)
	{
		string text = Lists[int_0].elementFields[int_1];
		string text2 = Class16.smethod_0(1648902914);
		string text3 = Regex.Replace(text, text2, text2);
		if (text3 == text)
		{
			GC.KeepAlive(this);
			return;
		}
		ACE.Elements.eList.eList eList2 = Lists[int_0];
		FIELDTYPE fIELDTYPE = eList2.fieldtypes[int_1];
		int bindedListIndex = -1;
		if (fIELDTYPE == FIELDTYPE.custom_list)
		{
			bindedListIndex = eList2.FieldsBindedLists[int_1][0];
		}
		int num = 1;
		eList2 = Lists[int_0];
		if (1 >= (nint)eList2.elementTypes.LongLength)
		{
			return;
		}
		do
		{
			if (eList2.fieldtypes[num] <= FIELDTYPE.none)
			{
				string text4 = eList2.elementFields[num];
				if (!(text4 == Class16.smethod_0(1648966655)) && !text4.StartsWith(Class16.smethod_0(1649080931)) && !text4.StartsWith(Class16.smethod_0(1649080949)) && Regex.IsMatch(text4, text3))
				{
					if (fIELDTYPE == FIELDTYPE.custom_list)
					{
						SetFieldBindedList(int_0, num, bindedListIndex);
					}
					else
					{
						SetFieldType(Lists[int_0], num, fIELDTYPE);
					}
				}
			}
			num++;
			eList2 = Lists[int_0];
		}
		while (num < (nint)eList2.elementTypes.LongLength);
	}

	public List<vITEMPOS> GetFavoriteItems()
	{
		List<LISTandID> favoriteItems = PRIORITY_ITEMS.GetFavoriteItems(CommonStorage.AParams.FavoriteItemsLimit);
		GC.KeepAlive(this);
		return GetItemsV(favoriteItems);
	}

	public List<vITEMPOS> GetItemsV(List<LISTandID> items)
	{
		List<vITEMPOS> list = new List<vITEMPOS>(items.Count);
		List<LISTandID>.Enumerator enumerator = items.GetEnumerator();
		if (enumerator.MoveNext())
		{
			vITEMPOS item = default(vITEMPOS);
			do
			{
				LISTandID current = enumerator.Current;
				int listCount = ListCount;
				if (current.Int32_0 < listCount)
				{
					int num = Lists[current.Int32_0].IDs.IndexOf(current.id);
					if (num > -1)
					{
						int int32_ = current.Int32_0;
						item.Int32_1 = int32_;
						item.Int32_0 = num;
						list.Add(item);
					}
				}
			}
			while (enumerator.MoveNext());
		}
		GC.KeepAlive(this);
		return list;
	}

	public List<LISTandID> GetItemsListAndId(List<vITEMPOS> items)
	{
		List<LISTandID> list = new List<LISTandID>(items.Count);
		List<vITEMPOS>.Enumerator enumerator = items.GetEnumerator();
		if (enumerator.MoveNext())
		{
			LISTandID item = default(LISTandID);
			do
			{
				vITEMPOS current = enumerator.Current;
				if (current.Int32_1 < ListCount)
				{
					int int32_ = current.Int32_1;
					int itemCount = Lists[int32_].ItemCount;
					if (current.Int32_0 < itemCount)
					{
						int int32_2 = current.Int32_0;
						int int32_3 = current.Int32_1;
						int num = Lists[int32_3].getid(int32_2);
						GC.KeepAlive(this);
						int num2 = num;
						int int32_4 = current.Int32_1;
						item.Int32_0 = int32_4;
						num2 = ((num > 1000000) ? 100000 : num2);
						item.id = num2;
						list.Add(item);
					}
				}
			}
			while (enumerator.MoveNext());
		}
		GC.KeepAlive(this);
		return list;
	}

	public ITEMPOS GetItemPos(LISTandID item)
	{
		ITEMPOS result = null;
		int listCount = ListCount;
		if (item.Int32_0 < listCount)
		{
			int num = Lists[item.Int32_0].IDs.IndexOf(item.id);
			if (num > -1)
			{
				result = new ITEMPOS(item.Int32_0, num);
			}
		}
		GC.KeepAlive(this);
		return result;
	}

	public vITEMPOS GetItemPosV(LISTandID item)
	{
		int listCount = ListCount;
		if (item.Int32_0 < listCount)
		{
			int num = Lists[item.Int32_0].IDs.IndexOf(item.id);
			if (num > -1)
			{
				int int32_ = item.Int32_0;
				vITEMPOS result = new vITEMPOS
				{
					Int32_1 = int32_,
					Int32_0 = num
				};
				GC.KeepAlive(this);
				return result;
			}
		}
		vITEMPOS result2 = new vITEMPOS
		{
			Int32_1 = -1,
			Int32_0 = -1
		};
		GC.KeepAlive(this);
		return result2;
	}

	public string GenerateItemListHtml(List<vITEMPOS> Items, string Title, List<string> ExtraValues, [MarshalAs(UnmanagedType.U1)] bool bMany, [MarshalAs(UnmanagedType.U1)] bool bMargin, [MarshalAs(UnmanagedType.U1)] bool bViewList, HighlightInfo Highlighting, List<int> lists)
	{
		if (Items != null && (Items.Count != 0 || lists == null || lists.Count != 0))
		{
			string text = string.Empty;
			if (Title != null)
			{
				text += Class16.smethod_0(1649080952);
				text += Title;
				text += Class16.smethod_0(1648902161);
				Title = Regex.Replace(Title, Class16.smethod_0(1648979212), string.Empty);
				string text2 = ((!Title.EndsWith(Class16.smethod_0(1648924402))) ? Title : Title.Substring(0, Title.Length - 1));
				string text3 = Class16.smethod_0(1649080999);
				text = string.Concat(text, string.Concat(Class16.smethod_0(1649081003) + text2, text3));
			}
			if (lists != null && lists.Count > 0)
			{
				text += Class16.smethod_0(1649080952);
				Color gold = Color.Gold;
				string text4 = TextStorage.TEXTS.GetText(Class16.smethod_0(1649081030));
				text = string.Concat(text, Class16.smethod_0(1648958369) + HTML_HELPER.EchoTextColored(gold, bBold: true, text4));
				text += Class16.smethod_0(1648902161);
				int num = 0;
				if (0 < lists.Count)
				{
					do
					{
						int num2 = lists[num];
						HTML_HELPER hTML_HELPER = new HTML_HELPER();
						ACE.Elements.eList.eList eList2 = Lists[num2];
						string listName = ((!ACE.RSGlobal.RSGlobal.SHOW_UNIVERSAL_NAMES) ? eList2.ListName : eList2.uListName);
						hTML_HELPER.ListName = listName;
						hTML_HELPER.bMargin = bMargin;
						hTML_HELPER.bViewListIndex = true;
						hTML_HELPER.bViewListName = true;
						hTML_HELPER.bListBold = true;
						hTML_HELPER.bViewID = false;
						hTML_HELPER.ListIndex = num2;
						hTML_HELPER.bHtmlEncode = false;
						if (Highlighting != null && CommonStorage.AParams.HighlightLiveSearchMatches)
						{
							hTML_HELPER.ListName = HTML_HELPER.HighlightText(hTML_HELPER.ListName = HttpUtility.HtmlEncode(hTML_HELPER.ListName), Highlighting.highlight_text);
						}
						int num3 = num;
						byte b = ((num3 - num3 / 3 * 3 != 0) ? ((byte)1) : ((byte)0));
						string text5 = Class16.smethod_0(1648902317);
						text = string.Concat(text, EchoItem(hTML_HELPER, b != 0) + text5);
						num++;
					}
					while (num < lists.Count);
				}
			}
			if (Items.Count > 0)
			{
				if (lists != null)
				{
					if (lists.Count > 0)
					{
						text += Class16.smethod_0(1648953072);
					}
					string text6 = Items.Count.ToString();
					if (bMany)
					{
						text6 += Class16.smethod_0(1648941500);
					}
					text += Class16.smethod_0(1649080952);
					object[] vars = new object[1] { text6 };
					Color gold2 = Color.Gold;
					string text7 = TextStorage.TEXTS.GetText(Class16.smethod_0(1649081053), vars);
					text = string.Concat(text, Class16.smethod_0(1648958369) + HTML_HELPER.EchoTextColored(gold2, bBold: true, text7));
					text += Class16.smethod_0(1648902161);
				}
				text += Class16.smethod_0(1649081076);
				int num4 = 0;
				if (0 < Items.Count)
				{
					do
					{
						vITEMPOS vITEMPOS2 = Items[num4];
						HTML_HELPER hTML_HELPER2 = new HTML_HELPER(new ITEMPOS(vITEMPOS2.Int32_1, vITEMPOS2.Int32_0));
						if (!IsItemExist(hTML_HELPER2.LinkItem))
						{
							goto IL_0328;
						}
						hTML_HELPER2.bIconNecessarily = true;
						hTML_HELPER2.bMargin = bMargin;
						hTML_HELPER2.bViewReferences = true;
						if (bViewList)
						{
							hTML_HELPER2.bViewListIndex = true;
							hTML_HELPER2.bViewListName = true;
							hTML_HELPER2.bListInTheEnd = true;
						}
						hTML_HELPER2.bHtmlEncode = false;
						if (ExtraValues != null && ExtraValues.Count > 0)
						{
							hTML_HELPER2.extra1 = HttpUtility.HtmlEncode(ExtraValues[num4]);
						}
						if (Highlighting != null && CommonStorage.AParams.HighlightLiveSearchMatches)
						{
							if (Highlighting.highlight_id > 0)
							{
								int num5 = Lists[vITEMPOS2.Int32_1].IDs[vITEMPOS2.Int32_0];
								if (Highlighting.highlight_id == num5)
								{
									ref Color iDColor = ref hTML_HELPER2.IDColor;
									iDColor = Highlighting.color;
									goto IL_0449;
								}
							}
							string text8 = (hTML_HELPER2.Name = HttpUtility.HtmlEncode(GetParsedItemName(hTML_HELPER2.LinkItem)));
							string[] splitted_text = Highlighting.splitted_text;
							if (splitted_text != null)
							{
								hTML_HELPER2.Name = HTML_HELPER.HighlightText(text8, splitted_text);
							}
							else
							{
								hTML_HELPER2.Name = HTML_HELPER.HighlightText(text8, Highlighting.highlight_text);
							}
						}
						goto IL_0449;
						IL_0449:
						text += EchoItem(hTML_HELPER2, text == null);
						goto IL_0328;
						IL_0328:
						num4++;
					}
					while (num4 < Items.Count);
				}
				text += Class16.smethod_0(1648902161);
			}
			if (bMany)
			{
				text += Class16.smethod_0(1649081117);
			}
			GC.KeepAlive(this);
			return text;
		}
		GC.KeepAlive(this);
		return null;
	}

	public void MakeFieldCategories()
	{
		FieldCategories = new Dictionary<string, string>();
		string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1649081137));
		FieldCategories.Add(Class16.smethod_0(1648960646), text);
		string text2 = TextStorage.TEXTS.GetText(Class16.smethod_0(1649081160));
		FieldCategories.Add(Class16.smethod_0(1648960664), text2);
		string text3 = TextStorage.TEXTS.GetText(Class16.smethod_0(1649081191));
		FieldCategories.Add(Class16.smethod_0(1648960695), text3);
		string text4 = TextStorage.TEXTS.GetText(Class16.smethod_0(1649081214));
		FieldCategories.Add(Class16.smethod_0(1648960724), text4);
		string text5 = TextStorage.TEXTS.GetText(Class16.smethod_0(1649081237));
		FieldCategories.Add(Class16.smethod_0(1648960745), text5);
		string text6 = TextStorage.TEXTS.GetText(Class16.smethod_0(1649081260));
		FieldCategories.Add(Class16.smethod_0(1648960782), text6);
		GC.KeepAlive(this);
	}

	public Bitmap GetListIcon(int int_0, int size)
	{
		Bitmap bitmap = null;
		bitmap = ICONS.FreeItemIcon18;
		string uListName = Lists[int_0].uListName;
		string text = null;
		bool isTga = false;
		if (uListName == Class16.smethod_0(1648963546))
		{
			text = Class16.smethod_0(1648904769);
		}
		else if (uListName == Class16.smethod_0(1648960167))
		{
			text = Class16.smethod_0(1648904785);
		}
		else if (Game == GAMES.PW && uListName == Class16.smethod_0(1649081275))
		{
			text = Class16.smethod_0(1649081297);
		}
		else if (IsIconsExist(int_0) && Lists[int_0].ItemCount > 0)
		{
			int num;
			int num2;
			if (50 < GetItemsCount(int_0))
			{
				num = 50;
				num2 = 0;
			}
			else
			{
				num = GetItemsCount(int_0);
				num2 = 0;
				if (0 >= num)
				{
					goto IL_0113;
				}
			}
			do
			{
				string iconName = GetIconName(int_0, num2, ref isTga);
				if (Icons.TryGetIcon(iconName, isTga, size, ref bitmap))
				{
					break;
				}
				num2++;
			}
			while (num2 < num);
		}
		else if (int_0 == 0 || uListName.EndsWith(Class16.smethod_0(1648952691)))
		{
			text = Class16.smethod_0(1648904805);
		}
		goto IL_0113;
		IL_0113:
		if (text != null)
		{
			bitmap = Icons.GetIcon(text, isTga, size);
		}
		GC.KeepAlive(this);
		return bitmap;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsEqualFieldSuites(int int_0, int f1, int f2)
	{
		ACE.Elements.eList.eList eList2 = Lists[int_0];
		string[] elementFields = eList2.elementFields;
		string text = elementFields[f1];
		string text2 = elementFields[f2];
		if (eList2.uListName == Class16.smethod_0(1648963535) && (text.StartsWith(Class16.smethod_0(1649081326)) || text2.StartsWith(Class16.smethod_0(1649081328))))
		{
			text = Class16.smethod_0(1649080322) + text;
			text2 = Class16.smethod_0(1649080322) + text2;
		}
		char[] separator = new char[1] { '_' };
		char[] separator2 = new char[1] { '_' };
		string text3 = text2.Split(separator)[0];
		if (text.Split(separator2)[0] != text3)
		{
			GC.KeepAlive(this);
			return false;
		}
		MatchCollection matchCollection = Regex.Matches(text, Class16.smethod_0(1648902914));
		MatchCollection matchCollection2 = Regex.Matches(text2, Class16.smethod_0(1648902914));
		if (matchCollection.Count != matchCollection2.Count)
		{
			GC.KeepAlive(this);
			return false;
		}
		int num = 0;
		if (0 < matchCollection.Count)
		{
			do
			{
				if (!(matchCollection[num].Value != matchCollection2[num].Value))
				{
					num++;
					continue;
				}
				return false;
			}
			while (num < matchCollection.Count);
		}
		GC.KeepAlive(this);
		return true;
	}

	public string GetOnlyFieldCaption(int int_0, int int_1)
	{
		string fieldName = GetFieldName(int_0, int_1);
		string[] array = Regex.Split(fieldName, Class16.smethod_0(1648902914));
		int num = (int)((nint)array.LongLength - 1);
		fieldName = ((array[num].Length <= 3) ? ACE.RSGlobal.RSGlobal.WithCapitalLetter(NamesConverter.RemoveIndices(fieldName)) : ACE.RSGlobal.RSGlobal.WithCapitalLetter(array[(nint)array.LongLength - 1].Trim()));
		GC.KeepAlive(this);
		return fieldName;
	}

	public string GetFieldNameWithoutIndices(int int_0, int int_1)
	{
		string result = ACE.RSGlobal.RSGlobal.WithCapitalLetter(NamesConverter.RemoveIndices(GetFieldName(int_0, int_1)));
		GC.KeepAlive(this);
		return result;
	}

	public void CreateProbFieldsAutomatically()
	{
		List<int> list = null;
		int num = 0;
		if (0 < ListCount)
		{
			do
			{
				if (num != ConversationListIndex && Lists[num].ItemCount != 0)
				{
					list = new List<int>();
					int num2 = 2;
					if (2 < (nint)Lists[num].elementTypes.LongLength)
					{
						do
						{
							if (IsProbField(num, num2))
							{
								list.Clear();
								TryGetSimilarFields(num, num2, ref list, bCheckFieldType: true);
								if (list.Count > 1)
								{
									float num3 = 0f;
									List<int>.Enumerator enumerator = list.GetEnumerator();
									if (enumerator.MoveNext())
									{
										do
										{
											int current = enumerator.Current;
											if (IsProbField(num, current))
											{
												float valueF = Lists[num].GetValueF(0, current);
												GC.KeepAlive(this);
												num3 = (float)((double)valueF + (double)num3);
												continue;
											}
											num3 = 0f;
											break;
										}
										while (enumerator.MoveNext());
									}
									if ((double)Math.Abs((float)(1.0 - (double)num3)) < 0.01)
									{
										int[] fields = list.ToArray();
										AddProbFields(num, fields, 0, 0);
									}
									int index = list.Count - 1;
									num2 = list[index];
								}
							}
							num2++;
						}
						while (num2 < (nint)Lists[num].elementTypes.LongLength);
					}
					if (ProbFieldsSuites.ContainsKey(num))
					{
						ProbFieldsSuites[num].Reverse();
						ProbSuitesNames[num].Reverse();
					}
				}
				num++;
			}
			while (num < ListCount);
		}
		GC.KeepAlive(this);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool TryGetSimilarFields(int int_0, int int_1, string fname, ref List<int> fields, [MarshalAs(UnmanagedType.U1)] bool bCheckFieldType)
	{
		string text = Lists[int_0].elementTypes[int_1];
		string text2 = Class16.smethod_0(1648902914);
		string text3 = Regex.Replace(fname, text2, text2);
		bool flag = false;
		if (fname == text3)
		{
			if (Game != GAMES.Chibi)
			{
				return false;
			}
			flag = true;
		}
		if (fields == null)
		{
			fields = new List<int>();
		}
		int num = 1;
		string[] elementTypes = Lists[int_0].elementTypes;
		if (1 < (nint)elementTypes.LongLength)
		{
			do
			{
				if (!bCheckFieldType || text == elementTypes[num])
				{
					string text4 = Lists[int_0].elementFields[num];
					if ((!flag) ? Regex.IsMatch(text4, text3) : (text4 == fname))
					{
						fields.Add(num);
					}
				}
				num++;
				elementTypes = Lists[int_0].elementTypes;
			}
			while (num < (nint)elementTypes.LongLength);
		}
		bool result = fields.Count < 0;
		GC.KeepAlive(this);
		return result;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool TryGetSimilarFields(int int_0, int int_1, ref List<int> fields, [MarshalAs(UnmanagedType.U1)] bool bCheckFieldType)
	{
		string fname = Lists[int_0].elementFields[int_1];
		return TryGetSimilarFields(int_0, int_1, fname, ref fields, bCheckFieldType);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool TryGetSimilarFields(int int_0, string fname, ref List<int> fields)
	{
		int num = Lists[int_0].get_fields(fname);
		bool result = false;
		if (num > -1)
		{
			result = TryGetSimilarFields(int_0, num, fname, ref fields, bCheckFieldType: true);
		}
		return result;
	}

	public void ConvertItems(int int_0, ref List<object[]> Items, string[] SourceFields, string[] SourceTypes, [MarshalAs(UnmanagedType.U1)] bool IsDifferentList)
	{
		List<object[]> list = new List<object[]>(ItemCount);
		List<object[]>.Enumerator enumerator = Items.GetEnumerator();
		if (enumerator.MoveNext())
		{
			do
			{
				object[] current = enumerator.Current;
				ACE.Elements.eList.eList destList = Lists[int_0];
				list.Add(ConvertItem(destList, SourceFields, SourceTypes, current, IsDifferentList, Lists[0].IDsHashSet));
			}
			while (enumerator.MoveNext());
		}
		Items = list;
		GC.KeepAlive(this);
	}

	public unsafe int ImportElementsACE(ACE_DATA_LIST rlist, int* pInt_0, ref IMPORT_RESULT ImportResult, [MarshalAs(UnmanagedType.U1)] bool bDetailed, int* firstnewid, int intoExactList)
	{
		List<object[]> list = null;
		int num = 0;
		if (intoExactList > -1)
		{
			*pInt_0 = intoExactList;
		}
		else
		{
			int num2 = ((Game != GAMES.FW) ? this.get_LI(rlist.ListName) : rlist.ListIndex);
			if (num2 == -1 || num2 >= ListCount)
			{
				return -1;
			}
			if (num2 == 0 && Game == GAMES.PW && TextStorage.TEXTS.ShowQuestionMessage(805) == DialogResult.No)
			{
				GC.KeepAlive(this);
				return 0;
			}
			*pInt_0 = num2;
		}
		bool isDifferentList;
		int num3 = (((isDifferentList = rlist.ListName != Lists[*pInt_0].uListName) || !ACE.RSGlobal.RSGlobal.IsArraysEquals(rlist.elementTypes, Lists[*pInt_0].elementTypes)) ? 1 : 0);
		bool flag = (byte)num3 != 0;
		ITEM_REPLACE_MODE iTEM_REPLACE_MODE = (CommonStorage.AParams.PasteAutoSetUniqueID ? ((ITEM_REPLACE_MODE)4) : ITEM_REPLACE_MODE.Merge);
		ITEM_REPLACE_MODE iTEM_REPLACE_MODE2 = iTEM_REPLACE_MODE;
		if (rlist.IsSubitems)
		{
			switch (CommonStorage.AParams.PasteDependenciesMode)
			{
			case DEPENDENCIES_PASTE_MODE.REPLACE_EXISTED_DEPENDENCIES:
				iTEM_REPLACE_MODE2 = ITEM_REPLACE_MODE.ReplaceExisting;
				break;
			case DEPENDENCIES_PASTE_MODE.SKIP_EXISTED_DEPENDENCIES:
				iTEM_REPLACE_MODE2 = ITEM_REPLACE_MODE.SkipExisting;
				break;
			}
		}
		list = rlist.elementValues;
		if (flag)
		{
			ConvertItems(*pInt_0, ref list, rlist.elementFields, rlist.elementTypes, isDifferentList);
		}
		int num4 = Lists[*pInt_0].ItemCount;
		HashSet<int> hashSet = null;
		HashSet<int> hashSet2 = new HashSet<int>();
		if (iTEM_REPLACE_MODE2 == (ITEM_REPLACE_MODE)4 || iTEM_REPLACE_MODE2 == (ITEM_REPLACE_MODE)5 || iTEM_REPLACE_MODE2 == ITEM_REPLACE_MODE.ReplaceExisting || iTEM_REPLACE_MODE2 == ITEM_REPLACE_MODE.SkipExisting)
		{
			if (rlist.ItemCount > 500)
			{
				hashSet = GetCachedIDs(*pInt_0);
			}
			int num5 = 0;
			if (0 < rlist.ItemCount)
			{
				do
				{
					int num6 = rlist.IDs[num5];
					bool flag2;
					if (hashSet != null)
					{
						flag2 = hashSet.Contains(num6);
					}
					else
					{
						int current_l = *pInt_0;
						flag2 = !IsFreeID(current_l, -1, num6, null, bInAllLists: false);
					}
					if (flag2 || iTEM_REPLACE_MODE2 == (ITEM_REPLACE_MODE)5)
					{
						hashSet2.Add(num5);
						int num7 = (((iTEM_REPLACE_MODE2 == (ITEM_REPLACE_MODE)4 || iTEM_REPLACE_MODE2 == (ITEM_REPLACE_MODE)5) && !rlist.ListName.EndsWith(Class16.smethod_0(1649080343))) ? 1 : 0);
						if ((byte)num7 != 0)
						{
							if (hashSet != null)
							{
								if (hashSet.Contains(*firstnewid))
								{
									int item;
									do
									{
										(*firstnewid)++;
										item = *firstnewid;
									}
									while (hashSet.Contains(item));
								}
								hashSet.Add(*firstnewid);
							}
							else
							{
								*firstnewid = GetFreeID(*pInt_0, ref *firstnewid);
							}
							list[num5][0] = *firstnewid;
							(*firstnewid)++;
						}
					}
					num5++;
				}
				while (num5 < rlist.ItemCount);
			}
		}
		if (bDetailed)
		{
			ImportResult.ResultList = new IMPORT_RESULT_LIST(*pInt_0);
		}
		bool flag3 = false;
		switch (iTEM_REPLACE_MODE2)
		{
		case ITEM_REPLACE_MODE.Merge:
		case (ITEM_REPLACE_MODE)4:
		case (ITEM_REPLACE_MODE)5:
		{
			int[] array = new int[1];
			int num11 = (array[0] = num4 - 1);
			int endval = rlist.ItemCount + num11;
			int[] itemsindices3 = ACE.RSGlobal.RSGlobal.IntArray(num4, endval, 1);
			ActionsHistory.stAddItems(*pInt_0, itemsindices3, array, -1);
			int endval2 = Lists[*pInt_0].AddItems(list);
			ActionsHistory.Complete();
			if (rlist.IsSubitems)
			{
				ImportResult.iAddedSubitems += rlist.ItemCount;
			}
			else
			{
				ImportResult.iAddedItems += rlist.ItemCount;
			}
			if (bDetailed)
			{
				int[] collection = ACE.RSGlobal.RSGlobal.IntArray(num4, endval2, 1);
				ImportResult.ResultList.AddedItems.AddRange(collection);
			}
			num = rlist.ItemCount;
			break;
		}
		case ITEM_REPLACE_MODE.ReplaceExisting:
		case ITEM_REPLACE_MODE.SkipExisting:
		{
			if (rlist.ItemCount > 500 && (iTEM_REPLACE_MODE2 == ITEM_REPLACE_MODE.ReplaceExisting || rlist.ItemCount - hashSet2.Count > 500))
			{
				object[] vars = new object[1] { Lists[*pInt_0].ListName };
				int[] listsIndices = new int[1] { *pInt_0 };
				ActionsHistory.stChangeLists(listsIndices, 807, vars);
				flag3 = true;
			}
			Dictionary<int, int> dictionary = null;
			if (iTEM_REPLACE_MODE2 == ITEM_REPLACE_MODE.ReplaceExisting && Lists != null && Lists[*pInt_0] != null)
			{
				List<int> iDs = Lists[*pInt_0].IDs;
				dictionary = new Dictionary<int, int>(iDs.Count);
				for (int i = 0; i < iDs.Count; i++)
				{
					int key = iDs[i];
					if (!dictionary.ContainsKey(key))
					{
						dictionary.Add(key, i);
					}
				}
			}
			int num8 = 0;
			if (0 < rlist.ItemCount)
			{
				do
				{
					int num10;
					if (hashSet2.Contains(num8))
					{
						if (iTEM_REPLACE_MODE2 == ITEM_REPLACE_MODE.ReplaceExisting)
						{
							int num9 = rlist.IDs[num8];
							int value = -1;
							if (dictionary == null || !dictionary.TryGetValue(num9, out value))
							{
								value = FindItemIndexByID(*pInt_0, num9);
							}
							if (value <= -1)
							{
								goto IL_04d5;
							}
							if (!flag3)
							{
								int[] itemsindices = new int[1] { value };
								ActionsHistory.stChangeItems(*pInt_0, itemsindices, null, null, -1);
							}
							Lists[*pInt_0].elementValues[value] = list[num8];
							if (!flag3)
							{
								ActionsHistory.Complete();
							}
							ImportResult.iReplacedItems++;
							if (bDetailed)
							{
								ImportResult.ResultList.ReplacedItems.Add(value);
							}
							goto IL_0577;
						}
						num10 = 0;
					}
					else
					{
						num10 = 1;
					}
					if ((byte)num10 != 0)
					{
						goto IL_04d5;
					}
					goto IL_0577;
					IL_0586:
					num8++;
					continue;
					IL_04d5:
					if (!flag3)
					{
						int[] selecteditems_before = new int[1] { num4 - 1 };
						int[] itemsindices2 = new int[1] { num4 };
						ActionsHistory.stAddItems(*pInt_0, itemsindices2, selecteditems_before, -1);
					}
					int item2 = Lists[*pInt_0].AddItem(list[num8]);
					if (!flag3)
					{
						ActionsHistory.Complete();
					}
					if (rlist.IsSubitems)
					{
						ImportResult.iAddedSubitems++;
					}
					else
					{
						ImportResult.iAddedItems++;
					}
					if (bDetailed)
					{
						ImportResult.ResultList.AddedItems.Add(item2);
					}
					num++;
					num4++;
					goto IL_0586;
					IL_0577:
					ImportResult.iSkippedItems++;
					goto IL_0586;
				}
				while (num8 < rlist.ItemCount);
			}
			if (flag3)
			{
				ActionsHistory.Complete();
			}
			break;
		}
		}
		if (CommonStorage.AParams.PasteWithDesc)
		{
			if (Descriptions != null && rlist.Descriptions.Count > 0)
			{
				int[] iDs2 = ACE.RSGlobal.RSGlobal.IntCollectionToArray(rlist.Descriptions.Keys);
				if (iTEM_REPLACE_MODE2 == ITEM_REPLACE_MODE.Merge || iTEM_REPLACE_MODE2 == (ITEM_REPLACE_MODE)4 || iTEM_REPLACE_MODE2 == ITEM_REPLACE_MODE.ReplaceExisting)
				{
					ActionsHistory.stDesc(iDs2);
				}
				int num12 = 0;
				Dictionary<int, string>.Enumerator enumerator = rlist.Descriptions.GetEnumerator();
				if (enumerator.MoveNext())
				{
					do
					{
						ValueType valueType = enumerator.Current;
						if (iTEM_REPLACE_MODE2 == ITEM_REPLACE_MODE.SkipExisting)
						{
							byte b = (hashSet2.Contains(num12) ? ((byte)1) : ((byte)0));
							num12++;
							if (b != 0)
							{
								continue;
							}
						}
						int key2 = ((KeyValuePair<int, string>)(object)valueType).Key;
						if (iTEM_REPLACE_MODE2 == ITEM_REPLACE_MODE.SkipExisting)
						{
							ActionsHistory.stDesc(key2);
						}
						Descriptions.SetClean(key2, ((KeyValuePair<int, string>)(object)valueType).Value);
						if (iTEM_REPLACE_MODE2 == ITEM_REPLACE_MODE.SkipExisting)
						{
							ActionsHistory.Complete();
						}
					}
					while (enumerator.MoveNext());
				}
				if (iTEM_REPLACE_MODE2 == ITEM_REPLACE_MODE.Merge || iTEM_REPLACE_MODE2 == (ITEM_REPLACE_MODE)4 || iTEM_REPLACE_MODE2 == ITEM_REPLACE_MODE.ReplaceExisting)
				{
					ActionsHistory.Complete();
				}
			}
			if (Colors != null && rlist.Colors.Count > 0)
			{
				int[] iDs3 = ACE.RSGlobal.RSGlobal.IntCollectionToArray(rlist.Colors.Keys);
				if (iTEM_REPLACE_MODE2 == ITEM_REPLACE_MODE.Merge || iTEM_REPLACE_MODE2 == (ITEM_REPLACE_MODE)4 || iTEM_REPLACE_MODE2 == ITEM_REPLACE_MODE.ReplaceExisting)
				{
					ActionsHistory.stColor(iDs3);
				}
				int num13 = 0;
				Dictionary<int, int>.Enumerator enumerator2 = rlist.Colors.GetEnumerator();
				if (enumerator2.MoveNext())
				{
					do
					{
						ValueType valueType2 = enumerator2.Current;
						if (iTEM_REPLACE_MODE2 == ITEM_REPLACE_MODE.SkipExisting)
						{
							byte b2 = (hashSet2.Contains(num13) ? ((byte)1) : ((byte)0));
							num13++;
							if (b2 != 0)
							{
								continue;
							}
						}
						int key3 = ((KeyValuePair<int, int>)(object)valueType2).Key;
						if (iTEM_REPLACE_MODE2 == ITEM_REPLACE_MODE.SkipExisting)
						{
							ActionsHistory.stColor(key3);
						}
						Colors.Change(((KeyValuePair<int, int>)(object)valueType2).Key, ((KeyValuePair<int, int>)(object)valueType2).Value);
						if (iTEM_REPLACE_MODE2 == ITEM_REPLACE_MODE.SkipExisting)
						{
							ActionsHistory.Complete();
						}
					}
					while (enumerator2.MoveNext());
				}
				if (iTEM_REPLACE_MODE2 == ITEM_REPLACE_MODE.Merge || iTEM_REPLACE_MODE2 == (ITEM_REPLACE_MODE)4 || iTEM_REPLACE_MODE2 == ITEM_REPLACE_MODE.ReplaceExisting)
				{
					ActionsHistory.Complete();
				}
			}
		}
		FileChanged = true;
		return num;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsDescsLoaded()
	{
		ITEM_EXT_DESC descriptions = Descriptions;
		int num = ((descriptions != null && descriptions.FileLoaded) ? 1 : 0);
		return (byte)num != 0;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsColorsLoaded()
	{
		ITEM_EXT_COLOR colors = Colors;
		int num = ((colors != null && colors.FileLoaded) ? 1 : 0);
		return (byte)num != 0;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsColorExist(int id)
	{
		int num = ((IsColorsLoaded() && Colors.Colors.ContainsKey(id)) ? 1 : 0);
		GC.KeepAlive(this);
		return (byte)num != 0;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsDescExist(int id)
	{
		string value = null;
		if (IsDescsLoaded())
		{
			Descriptions.Descriptions.TryGetValue(id, out value);
		}
		bool result = !string.IsNullOrWhiteSpace(value);
		GC.KeepAlive(this);
		return result;
	}

	public string GetItemDesc(int id)
	{
		string value = null;
		if (IsDescsLoaded())
		{
			Descriptions.Descriptions.TryGetValue(id, out value);
		}
		GC.KeepAlive(this);
		return value;
	}

	public void ResetCachedItems(int int_0, int[] items)
	{
		if (ItemsCache[int_0] != null)
		{
			int num = 0;
			if (0 < (nint)items.LongLength)
			{
				do
				{
					ItemsCache[int_0].Remove(items[num]);
					num++;
				}
				while (num < (nint)items.LongLength);
			}
		}
		GC.KeepAlive(this);
	}

	public string[] GetCleanFieldNames(int int_0, int[] fields)
	{
		if (fields != null)
		{
			int num = fields.Length;
			if (num != 0)
			{
				string[] array = new string[num];
				int num2 = 0;
				if (0 < (nint)array.LongLength)
				{
					do
					{
						array[num2] = Lists[int_0].elementFields[fields[num2]];
						num2++;
					}
					while (num2 < (nint)array.LongLength);
				}
				return array;
			}
		}
		return null;
	}

	public ITEMPOS FindReferenceParentItem(int parent_id, REFERENCE_TYPE_EX RefType, REFERENCE_ENTRY reference)
	{
		ITEMPOS result = null;
		if (RefType.DataFileType == DATA_FILES_ENUM.ELEMENTS)
		{
			int int_ = reference.FieldPos.int_2;
			int int_2 = reference.FieldPos.int_1;
			result = FindItemPos(GetFieldLists(reference.FieldPos.int_0, int_2, int_), parent_id);
		}
		else
		{
			ItemType item_type;
			switch (RefType.SectionType)
			{
			case ReferenceType.TASKS_TITLES:
				item_type = ItemType.PW_TITLE_CONFIG;
				goto IL_00d0;
			case ReferenceType.TASKS_HOME_ITEMS:
				item_type = ItemType.PW_HOME_ITEM_ENTITY;
				goto IL_00d0;
			case ReferenceType.NPCGEN_NPCS:
			case ReferenceType.NPCGEN_MONSTERS:
				item_type = ItemType.NpcOrMobOrMine;
				goto IL_00d0;
			case ReferenceType.TASKS_MINES:
			case ReferenceType.NPCGEN_MINES:
				item_type = ItemType.PW_MINE_ESSENCE;
				goto IL_00d0;
			case ReferenceType.TASKS_MONSTERS:
			case ReferenceType.EXTRA_DROPS_MONSTERS:
				item_type = ItemType.PW_MONSTER_ESSENCE;
				goto IL_00d0;
			case ReferenceType.GSHOP_MATTERS:
			case ReferenceType.GSHOP1_MATTERS:
			case ReferenceType.GSHOP2_MATTERS:
			case ReferenceType.TASKS_MATTERS:
			case ReferenceType.EXTRA_DROPS_MATTERS:
			case ReferenceType.GSHOP3_MATTERS:
				item_type = ItemType.Matter;
				goto IL_00d0;
			case ReferenceType.GSHOP_NPCS:
			case ReferenceType.GSHOP1_NPCS:
			case ReferenceType.GSHOP2_NPCS:
			case ReferenceType.TASKS_NPCS:
			case ReferenceType.GSHOP3_NPCS:
				{
					item_type = ItemType.PW_NPC_ESSENCE;
					goto IL_00d0;
				}
				IL_00d0:
				result = FindItemPos(GetLists(item_type), parent_id);
				break;
			}
		}
		return result;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool CheckItemErrors(ITEMPOS ItemPos, [MarshalAs(UnmanagedType.U1)] bool bFast, ref List<string> details)
	{
		bool flag = false;
		if (!IsItemExist(ItemPos))
		{
			details?.Add(Class16.smethod_0(1649080347));
			GC.KeepAlive(this);
			return false;
		}
		int int_ = ItemPos.int_0;
		int int_2 = ItemPos.int_1;
		int idFast = GetIdFast(int_, int_2);
		if (Game == GAMES.PW)
		{
			ItemType listType = Lists[int_].ListType;
			if (idFast > 65534 && Version < 233)
			{
				bool flag2 = MattersListsFast != null && MattersListsFast.Contains(int_);
				GC.KeepAlive(this);
				if ((flag2 || listType == ItemType.PW_MONSTER_ESSENCE) && !CommonStorage.AParams.DisableTooHighIdErrors)
				{
					flag = AddItemError(820, bFast, ref details);
				}
			}
			bool flag3 = MattersListsFast != null && MattersListsFast.Contains(int_);
			GC.KeepAlive(this);
			if (flag3)
			{
				int num = Lists[int_].get_fields(Class16.smethod_0(1648965136));
				if (num > 0)
				{
					int valueIFast = Lists[int_].GetValueIFast(int_2, num);
					GC.KeepAlive(this);
					int gamePricePW = CStorage.GetGamePricePW(valueIFast);
					gamePricePW = ((gamePricePW >= 0) ? gamePricePW : 0);
					int valueI = GetValueI(int_, int_2, Class16.smethod_0(1648970148));
					if (gamePricePW < valueI)
					{
						if (valueI == 1 && (gamePricePW == 1 || gamePricePW == 0))
						{
							goto IL_019f;
						}
						int num2 = ((AddItemError(962, bFast, ref details) || flag) ? 1 : 0);
						flag = (byte)num2 != 0;
					}
					if (valueI > 195000000)
					{
						int num3 = ((AddItemError(963, bFast, ref details) || flag) ? 1 : 0);
						flag = (byte)num3 != 0;
					}
				}
			}
		}
		goto IL_019f;
		IL_019f:
		return flag;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool CheckItemErrors(ITEMPOS ItemPos)
	{
		List<string> details = null;
		return CheckItemErrors(ItemPos, bFast: true, ref details);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool AddItemError(int str_id, [MarshalAs(UnmanagedType.U1)] bool bFast, ref List<string> details)
	{
		if (!bFast)
		{
			if (details == null)
			{
				details = new List<string>();
			}
			string text = TextStorage.TEXTS.GetText(TextStorage.TEXTS.ResolveLegacyMessageKey(str_id, 0), null);
			details.Add(text);
		}
		GC.KeepAlive(this);
		return true;
	}

	public Color GetItemCategoryColor(LISTandID item)
	{
		ObservableCollection<ITEMS_CATEGORY> itemsCategories = CommonStorage.AParams.ItemsCategories;
		if (itemsCategories != null)
		{
			foreach (ITEMS_CATEGORY item2 in itemsCategories)
			{
				if (item2.Contains(item))
				{
					Color iDBackColor = item2.IDBackColor;
					GC.KeepAlive(this);
					return iDBackColor;
				}
			}
		}
		GC.KeepAlive(this);
		return SpecialColors.ItemDark;
	}

	public int ReplaceTaskID(int oldid, int newid)
	{
		int num = 0;
		object[] vars = new object[2] { oldid, newid };
		ActionsHistory.SubStagesBegin(-1, null, 828, vars);
		int num2 = 1;
		if (1 < ListCount)
		{
			do
			{
				if (num2 != ConversationListIndex)
				{
					int num3 = 2;
					if (2 < (nint)Lists[num2].elementTypes.LongLength)
					{
						do
						{
							if (GetFieldType(num2, num3) == FIELDTYPE.ft_quest)
							{
								int num4 = 0;
								if (0 < Lists[num2].ItemCount)
								{
									do
									{
										int valueIFast = Lists[num2].GetValueIFast(num4, num3);
										GC.KeepAlive(this);
										if (valueIFast == oldid)
										{
											int[] fieldsindices = new int[1] { num3 };
											int[] itemsindices = new int[1] { num4 };
											ActionsHistory.stChangeFields(num2, itemsindices, fieldsindices, -1, null);
											decimal dvalue = newid;
											Lists[num2].SetValue(num4, num3, dvalue);
											ActionsHistory.Complete();
											num++;
										}
										num4++;
									}
									while (num4 < Lists[num2].ItemCount);
								}
							}
							num3++;
						}
						while (num3 < (nint)Lists[num2].elementTypes.LongLength);
					}
				}
				num2++;
			}
			while (num2 < ListCount);
		}
		ActionsHistory.SubStagesComplete(-1, null);
		GC.KeepAlive(this);
		return num;
	}

	public void SaveListsOrdering()
	{
		List<string> list = new List<string>(ListCount);
		int num = 0;
		if (0 < ListCount)
		{
			do
			{
				ACE.Elements.eList.eList eList2 = Lists[num];
				string text = eList2.uListName;
				byte[] listOffsetData = eList2.listOffsetData;
				if (listOffsetData != null && (nint)listOffsetData.LongLength > 0)
				{
					if (num == Get_NPC_TALK_ListIndex())
					{
						text += Class16.smethod_0(1649080369);
					}
					else if (num == Get_talk_proc_ListIndex())
					{
						text += Class16.smethod_0(1649080392);
					}
					else
					{
						int num2 = Lists[num].listOffsetData.Length;
						text = string.Concat(text, Class16.smethod_0(1648924402) + num2);
					}
				}
				list.Add(text);
				num++;
			}
			while (num < ListCount);
		}
		ACE.RSGlobal.RSGlobal.OpenInNotepad(list);
		GC.KeepAlive(this);
	}

	public ELEMENTS_ITEM GetElementsItem(ITEMPOS ItemPos, Size IconSize)
	{
		if (ItemPos == null)
		{
			return null;
		}
		ITEMINFO itemInfo = GetItemInfo(ItemPos, bUseCache: false, bCheckIsFreeID: true, bCheckHasReferences: true);
		ELEMENTS_ITEM eLEMENTS_ITEM = new ELEMENTS_ITEM();
		eLEMENTS_ITEM.ID = itemInfo.id;
		eLEMENTS_ITEM.Name = itemInfo.name;
		ref Color itemColor = ref eLEMENTS_ITEM.ItemColor;
		itemColor = itemInfo.color;
		if (IconSize.Height > 0)
		{
			bool isTgaIcon = itemInfo.IsTgaIcon;
			string iconName = itemInfo.IconName;
			ICONS icons = Icons;
			eLEMENTS_ITEM.ItemIcon = icons.GetIcon(iconName, isTgaIcon, IconSize.Height);
		}
		eLEMENTS_ITEM.RefCount = itemInfo.RefCount;
		eLEMENTS_ITEM.bOcupiedID = itemInfo.bOcupiedID;
		eLEMENTS_ITEM.bHasErrors = itemInfo.bHasErrors;
		eLEMENTS_ITEM.CategoryName = itemInfo.CatName;
		ref Color categoryColor = ref eLEMENTS_ITEM.CategoryColor;
		categoryColor = itemInfo.CatColor;
		eLEMENTS_ITEM.bCustomItem = itemInfo.bCustomItem;
		GC.KeepAlive(this);
		return eLEMENTS_ITEM;
	}

	public ELEMENTS_ITEM GetElementsItem(ItemType item_type, int id, Size IconSize)
	{
		ITEMPOS itemPos = FindItemPos(GetLists(item_type), id);
		return GetElementsItem(itemPos, IconSize);
	}

	public string[] GetDecodedValuesArray(int int_0, int int_1, int int_2)
	{
		FIELDTYPE fieldType = GetFieldType(int_0, int_1, int_2);
		int num;
		switch (fieldType)
		{
		default:
			num = (int)fieldType;
			break;
		case FIELDTYPE.character_combo_id_jd:
			num = 4005;
			break;
		case FIELDTYPE.ft_ENUM_EXTRA:
		case FIELDTYPE.ft_MASK_EXTRA:
			num = GetExtraType(int_0, int_1, int_2);
			break;
		}
		int ftype = num;
		string[] decodedValuesArray = DecodedValues.GetDecodedValuesArray(ftype);
		GC.KeepAlive(this);
		return decodedValuesArray;
	}

	public int GetExtraType(int int_0, int int_1, int int_2)
	{
		int value = 0;
		Lists[int_0].fieldtypes_extra?.TryGetValue(int_2, out value);
		GC.KeepAlive(this);
		return value;
	}

	public int GetFieldTypeEx(int int_0, int int_1, int int_2, FIELDTYPE ftype)
	{
		switch (ftype)
		{
		default:
			return (int)ftype;
		case FIELDTYPE.character_combo_id_jd:
			return 4005;
		case FIELDTYPE.ft_ENUM_EXTRA:
		case FIELDTYPE.ft_MASK_EXTRA:
			return GetExtraType(int_0, int_1, int_2);
		}
	}

	public int GetFieldTypeEx(int int_0, int int_1, int int_2)
	{
		FIELDTYPE fieldType = GetFieldType(int_0, int_1, int_2);
		switch (fieldType)
		{
		default:
			return (int)fieldType;
		case FIELDTYPE.character_combo_id_jd:
			return 4005;
		case FIELDTYPE.ft_ENUM_EXTRA:
		case FIELDTYPE.ft_MASK_EXTRA:
			return GetExtraType(int_0, int_1, int_2);
		}
	}

	public void ParseFieldSets(StreamReader sr, [MarshalAs(UnmanagedType.U1)] bool bUser)
	{
		while (true)
		{
			switch (sr.BaseStream.ReadByte())
			{
			case 35:
			{
				Stream baseStream = sr.BaseStream;
				long position = baseStream.Position - 1L;
				baseStream.Position = position;
				ACE.Elements.eList.eList eList2 = null;
				bool bNotInterrelated = false;
				string text = sr.ReadLine();
				if (text != null)
				{
					do
					{
						if (!string.IsNullOrWhiteSpace(text))
						{
							if (text[0] == '#')
							{
								int num = text.IndexOf(Class16.smethod_0(1648924402));
								string text2 = ((num <= -1) ? text.Substring(1) : text.Substring(num + 1, text.Length - num - 1));
								string text3 = text2;
								// TODO(recovered): same comment-header guard as ParseFieldTypes: an empty
								// header token (plain comment line ending in ':') must not index text3[-1].
								if (string.IsNullOrWhiteSpace(text2))
								{
									text = sr.ReadLine();
									continue;
								}
								bool flag;
								bNotInterrelated = (flag = text3[text3.Length - 1] == '~');
								if (flag)
								{
									text2 = text2.Substring(0, text2.Length - 1);
								}
								int num2 = this.get_LI(text2);
								eList2 = ((num2 == -1) ? null : Lists[num2]);
							}
							else
							{
								try
								{
									eList2?.AddFieldSets(text, bNotInterrelated);
								}
								catch (Exception)
								{
									// TODO(recovered): skip a malformed field-set line rather than aborting.
								}
							}
						}
						text = sr.ReadLine();
					}
					while (text != null);
				}
				sr.Close();
				GC.KeepAlive(this);
				return;
			}
			case -1:
				sr.Close();
				GC.KeepAlive(this);
				return;
			}
		}
	}

	public static string DecodePriceJD(uint price)
	{
		if (price == 0)
		{
			return 0u.ToString();
		}
		uint num = price / 10000;
		price = (uint)((int)num * -10000) + price;
		uint num2 = price / 100;
		uint num3 = price - num2 * 100;
		string text = string.Empty;
		if (num != 0)
		{
			object[] vars = new object[1] { num };
			string text2 = TextStorage.TEXTS.GetText(Class16.smethod_0(1649080416), vars);
			text += text2;
		}
		if (num2 != 0)
		{
			if (text != string.Empty)
			{
				text += Class16.smethod_0(1648942920);
			}
			object[] vars2 = new object[1] { num2 };
			string text3 = TextStorage.TEXTS.GetText(Class16.smethod_0(1649080447), vars2);
			text += text3;
		}
		if (num3 != 0)
		{
			if (text != string.Empty)
			{
				text += Class16.smethod_0(1648942920);
			}
			object[] vars3 = new object[1] { num3 };
			string text4 = TextStorage.TEXTS.GetText(Class16.smethod_0(1649080470), vars3);
			text += text4;
		}
		return text;
	}

	public void UpdateFastIDs(int[] lists)
	{
		int num = 0;
		if (0 < (nint)lists.LongLength)
		{
			do
			{
				Lists[lists[num]].UpdateFastIDs();
				num++;
			}
			while (num < (nint)lists.LongLength);
		}
		GC.KeepAlive(this);
	}

	public void UpdateFastIDs(ItemType item_type)
	{
		int[] lists = GetLists(item_type);
		UpdateFastIDs(lists);
	}

	public List<IdAndNameManaged> GetIdAndNameArray(ItemType item_type, int[] IDs)
	{
		int[] lists = GetLists(item_type);
		UpdateFastIDs(lists);
		List<IdAndNameManaged> list = new List<IdAndNameManaged>(IDs.Length);
		int num = 0;
		if (0 < (nint)IDs.LongLength)
		{
			IdAndNameManaged item = default(IdAndNameManaged);
			do
			{
				int num2 = IDs[num];
				int num3 = 0;
				if (0 < (nint)lists.LongLength)
				{
					do
					{
						int num4 = lists[num3];
						int num5 = FindItemFast(num4, num2);
						if (num5 <= -1)
						{
							num3++;
							continue;
						}
						ACE.Elements.eList.eList eList2 = Lists[num4];
						int nameFieldIndex = eList2.NameFieldIndex;
						byte[] name = (byte[])eList2.elementValues[num5][nameFieldIndex];
						item.item_id = num2;
						item.name = name;
						list.Add(item);
						break;
					}
					while (num3 < (nint)lists.LongLength);
				}
				num++;
			}
			while (num < (nint)IDs.LongLength);
		}
		GC.KeepAlive(this);
		return list;
	}

	public int FindItemFast(int int_0, int id)
	{
		int value = -1;
		if (!Lists[int_0].IDsFast.TryGetValue(id, out value))
		{
			value = -1;
		}
		GC.KeepAlive(this);
		return value;
	}

	public void ParseSpacesId()
	{
		List<int> list = null;
		List<int> list2 = null;
		Spaces = new Dictionary<ID_SPACE, List<int>>();
		string text = Class16.smethod_0(1649080493);
		string gamePrefix = GamePrefix;
		string text2 = Class16.smethod_0(1648952491);
		string path = string.Concat(string.Concat(Application.StartupPath + text2, gamePrefix), text);
		if (File.Exists(path))
		{
			StreamReader streamReader = File.OpenText(path);
			string text3 = streamReader.ReadLine();
			if (text3 != null)
			{
				do
				{
					if (!string.IsNullOrWhiteSpace(text3))
					{
						int num = text3.IndexOf(Class16.smethod_0(1648905535));
						string lIST_NAME = text3.Substring(0, num);
						int num2 = this.get_LI(lIST_NAME);
						if (num2 > -1)
						{
							string value = text3.Substring(num + 1);
							ID_SPACE iD_SPACE = (ID_SPACE)Enum.Parse(typeof(ID_SPACE), value);
							list = null;
							if (!Spaces.TryGetValue(iD_SPACE, out list))
							{
								Spaces.Add(iD_SPACE, new List<int>(num2));
							}
							else
							{
								list.Add(num2);
							}
							Lists[num2].SpaceId = iD_SPACE;
						}
					}
					text3 = streamReader.ReadLine();
				}
				while (text3 != null);
			}
			streamReader.Close();
		}
		int num3 = 0;
		if (0 < ListCount)
		{
			do
			{
				if (num3 != ConversationListIndex)
				{
					ACE.Elements.eList.eList eList2 = Lists[num3];
					if (eList2.SpaceId == ID_SPACE.invalid)
					{
						ID_SPACE unknownListSpaceId = GetUnknownListSpaceId(eList2.uListName);
						if (unknownListSpaceId != ID_SPACE.invalid)
						{
							Lists[num3].SpaceId = unknownListSpaceId;
							list2 = null;
							if (!Spaces.TryGetValue(Lists[num3].SpaceId, out list2))
							{
								Spaces.Add(unknownListSpaceId, new List<int>(num3));
							}
							else
							{
								list2.Add(num3);
							}
						}
					}
				}
				num3++;
			}
			while (num3 < ListCount);
		}
		GC.KeepAlive(this);
	}

	public static ID_SPACE GetUnknownListSpaceId(string ListName)
	{
		ID_SPACE result = ID_SPACE.invalid;
		if (!ListName.EndsWith(Class16.smethod_0(1649080518)) && !ListName.StartsWith(Class16.smethod_0(1649080532)))
		{
			if (ListName.Contains(Class16.smethod_0(1649080538)))
			{
				result = ID_SPACE.face_id_index_map;
			}
			else if (ListName.EndsWith(Class16.smethod_0(1649080557)))
			{
				result = ID_SPACE.config_id_index_map;
			}
			else if (ListName.StartsWith(Class16.smethod_0(1649080563)))
			{
				result = ID_SPACE.home_id_index_map;
			}
			else if (ListName.EndsWith(Class16.smethod_0(1649080583)) || ListName.EndsWith(Class16.smethod_0(1649080598)) || ListName.EndsWith(Class16.smethod_0(1649080343)))
			{
				result = ID_SPACE.essence_id_index_map;
			}
		}
		else
		{
			result = ID_SPACE.recipe_id_index_map;
		}
		return result;
	}

	public void FillListsArrays()
	{
		if (ListCount != ListIndices.Count)
		{
			ListIndices = new Dictionary<string, int>(Lists.Length);
			int num = 0;
			if (0 < (nint)Lists.LongLength)
			{
				do
				{
					string uListName = Lists[num].uListName;
					if (!ListIndices.ContainsKey(uListName))
					{
						ListIndices.Add(uListName, num);
					}
					num++;
				}
				while (num < (nint)Lists.LongLength);
			}
			CROSS_LISTS = ListIndices;
		}
		if (Game != GAMES.Chibi)
		{
			addons_l = this.get_LI(Class16.smethod_0(1649080613));
		}
		int listCount = ListCount;
		int num2 = listCount;
		int conversationListIndex = ConversationListIndex;
		if (conversationListIndex != -1 && conversationListIndex < listCount)
		{
			num2--;
		}
		AllLists = new int[num2];
		AllListsAndCoversations = new int[listCount];
		List<int> list = new List<int>();
		int num3 = 0;
		int num4 = 0;
		if (0 < ListCount)
		{
			do
			{
				AllListsAndCoversations[num4] = num4;
				if (num4 != ConversationListIndex)
				{
					AllLists[num3] = num4;
					num3++;
					if (Lists[num4].get_fields(Class16.smethod_0(1648955728)) > -1 && Lists[num4].uListName != Class16.smethod_0(1648952558))
					{
						ACE.RSGlobal.RSGlobal.AddElementToArray(ref MattersLists, num4);
					}
					else if (Lists[num4].uListName.StartsWith(Class16.smethod_0(1649007040)) && Lists[num4].uListName.EndsWith(Class16.smethod_0(1649080627)))
					{
						list.Add(num4);
					}
				}
				num4++;
			}
			while (num4 < ListCount);
		}
		NPCServicesLists = list.ToArray();
		string lIST_NAME = Class16.smethod_0(1648963535);
		string lIST_NAME2 = Class16.smethod_0(1648960167);
		NpcMobMineLists = ACE.RSGlobal.RSGlobal.iarr(this.get_LI(Class16.smethod_0(1648963546)), this.get_LI(lIST_NAME2), this.get_LI(lIST_NAME));
		switch (Game)
		{
		case GAMES.SW:
			ACE.RSGlobal.RSGlobal.AddElementToArray(ref MattersLists, this.get_LI(Class16.smethod_0(1648962709)));
			ACE.RSGlobal.RSGlobal.AddElementToArray(ref MattersLists, this.get_LI(Class16.smethod_0(1648962685)));
			ACE.RSGlobal.RSGlobal.AddElementToArray(ref MattersLists, this.get_LI(Class16.smethod_0(1649080641)));
			break;
		case GAMES.FW:
			ACE.RSGlobal.RSGlobal.AddElementToArray(ref MattersLists, this.get_LI(Class16.smethod_0(1648962709)));
			break;
		case GAMES.PW:
			ACE.RSGlobal.RSGlobal.AddElementToArray(ref MattersLists, this.get_LI(Class16.smethod_0(1648955634)));
			if (this.get_LI(Class16.smethod_0(1648955681)) != -1)
			{
				ACE.RSGlobal.RSGlobal.AddElementToArray(ref MattersLists, this.get_LI(Class16.smethod_0(1648955681)));
			}
			break;
		}
		List<int> list2 = new List<int>();
		list2.AddRange(new int[4]
		{
			this.get_LI(Class16.smethod_0(1648923245)),
			this.get_LI(Class16.smethod_0(1648923258)),
			this.get_LI(Class16.smethod_0(1648923366)),
			this.get_LI(Class16.smethod_0(1648923391))
		});
		int num5 = this.get_LI(Class16.smethod_0(1649080677));
		if (num5 > 0)
		{
			list2.Add(num5);
		}
		int num6 = this.get_LI(Class16.smethod_0(1649080700));
		if (num6 > 0)
		{
			list2.Add(num6);
		}
		int num7 = this.get_LI(Class16.smethod_0(1649080714));
		if (num7 > 0)
		{
			list2.Add(num7);
		}
		int num8 = this.get_LI(Class16.smethod_0(1649080743));
		if (num8 > 0)
		{
			list2.Add(num8);
		}
		int num9 = this.get_LI(Class16.smethod_0(1649080764));
		if (num9 > 0)
		{
			list2.Add(num9);
		}
		int num10 = this.get_LI(Class16.smethod_0(1649080790));
		if (num10 > 0)
		{
			list2.Add(num10);
		}
		int num11 = this.get_LI(Class16.smethod_0(1648923432));
		if (num11 > 0)
		{
			list2.Add(num11);
		}
		int num12 = this.get_LI(Class16.smethod_0(1648923096));
		if (num12 > 0)
		{
			list2.Add(num12);
		}
		EquipmentLists = list2.ToArray();
		if (ACE.RSGlobal.RSGlobal.debug_show_listindex)
		{
			MattersLists = AllLists;
		}
		HashSet<int> hashSet = (MattersListsFast = new HashSet<int>());
		int[] mattersLists = MattersLists;
		if (mattersLists != null)
		{
			hashSet.UnionWith(mattersLists);
		}
		GC.KeepAlive(this);
	}

	public List<ATaskTempl> TryGetQuests(ITEMPOS ItemPos, [MarshalAs(UnmanagedType.U1)] bool bScanSubitems)
	{
		TASKS tasks = Tasks;
		if (tasks != null && tasks.FileLoaded)
		{
			List<ATaskTempl> list = null;
			int num = 1;
			int int_ = ItemPos.int_0;
			if (1 < (nint)Lists[int_].elementTypes.LongLength)
			{
				do
				{
					if (GetFieldType(int_, ItemPos.int_1, num) == FIELDTYPE.ft_quest)
					{
						int int_2 = ItemPos.int_1;
						int int_3 = ItemPos.int_0;
						int valueIFast = Lists[int_3].GetValueIFast(int_2, num);
						GC.KeepAlive(this);
						if (valueIFast > 0)
						{
							ATaskTempl quest = Tasks.GetQuest(valueIFast);
							if (quest != null)
							{
								if (list == null)
								{
									list = new List<ATaskTempl>();
								}
								list.Add(quest);
							}
						}
					}
					num++;
					int_ = ItemPos.int_0;
				}
				while (num < (nint)Lists[int_].elementTypes.LongLength);
			}
			if (list == null && bScanSubitems)
			{
				int num2 = 1;
				int int_4 = ItemPos.int_0;
				if (1 < (nint)Lists[int_4].elementTypes.LongLength)
				{
					do
					{
						if (GetFieldType(int_4, ItemPos.int_1, num2) >= FIELDTYPE.matters)
						{
							ITEMPOS iTEMPOS = FindItemPos(ItemPos.int_0, ItemPos.int_1, num2);
							if (iTEMPOS != null)
							{
								list = TryGetQuests(iTEMPOS, bScanSubitems: false);
								if (list != null)
								{
									break;
								}
							}
						}
						num2++;
						int_4 = ItemPos.int_0;
					}
					while (num2 < (nint)Lists[int_4].elementTypes.LongLength);
				}
			}
			return list;
		}
		return null;
	}

	public List<string> GetGiftItemNames(ITEMPOS ItemPos)
	{
		List<string> list = new List<string>();
		new HashSet<ITEMPOS>();
		List<ATaskTempl> list2 = TryGetQuests(ItemPos, bScanSubitems: false);
		if (list2 != null)
		{
			List<ATaskTempl>.Enumerator enumerator = list2.GetEnumerator();
			if (enumerator.MoveNext())
			{
				do
				{
					ATaskTempl current = enumerator.Current;
					if (current.m_Award_S == null)
					{
						continue;
					}
					if (current.m_Award_S.m_CandItems != null)
					{
						AWARD_ITEMS_CAND[] candItems = current.m_Award_S.m_CandItems;
						int num = 0;
						if (0 < (nint)candItems.LongLength)
						{
							do
							{
								AWARD_ITEMS_CAND aWARD_ITEMS_CAND = candItems[num];
								if (aWARD_ITEMS_CAND != null && aWARD_ITEMS_CAND.m_AwardItems != null)
								{
									ITEM_WANTED[] awardItems = aWARD_ITEMS_CAND.m_AwardItems;
									int num2 = 0;
									if (0 < (nint)awardItems.LongLength)
									{
										do
										{
											ITEM_WANTED iTEM_WANTED = awardItems[num2];
											if (iTEM_WANTED != null)
											{
												int ulItemTemplId = iTEM_WANTED.m_ulItemTemplId;
												ITEMPOS iTEMPOS = FindItemPos(MattersLists, ulItemTemplId);
												if (iTEMPOS != null)
												{
													string text = GetParsedItemName(iTEMPOS);
													if (iTEM_WANTED.m_ulItemNum > 1)
													{
														text = string.Concat(text, Class16.smethod_0(1648942627) + CommonStorage.GetPieces(iTEM_WANTED.m_ulItemNum));
													}
													list.Add(text);
												}
											}
											num2++;
										}
										while (num2 < (nint)awardItems.LongLength);
									}
								}
								num++;
							}
							while (num < (nint)candItems.LongLength);
						}
					}
					if (current.m_Award_S.m_pTitleAward == null || (nint)current.m_Award_S.m_pTitleAward.LongLength <= 0)
					{
						continue;
					}
					TITLE_AWARD[] pTitleAward = current.m_Award_S.m_pTitleAward;
					int num3 = 0;
					if (0 >= (nint)pTitleAward.LongLength)
					{
						continue;
					}
					do
					{
						TITLE_AWARD tITLE_AWARD = pTitleAward[num3];
						if (tITLE_AWARD != null)
						{
							string lIST_NAME = Class16.smethod_0(1649078729);
							ITEMPOS iTEMPOS2 = FindItemPos(ACE.RSGlobal.RSGlobal.iarr(this.get_LI(Class16.smethod_0(1649078718)), this.get_LI(lIST_NAME)), tITLE_AWARD.m_ulTitleID);
							if (iTEMPOS2 != null)
							{
								string parsedItemName = GetParsedItemName(iTEMPOS2);
								list.Add(TextStorage.TEXTS.GetText(TextStorage.TEXTS.ResolveLegacyMessageKey(874, 0), parsedItemName));
							}
						}
						num3++;
					}
					while (num3 < (nint)pTitleAward.LongLength);
				}
				while (enumerator.MoveNext());
			}
		}
		GC.KeepAlive(this);
		return list;
	}

	public int ParseList(string name)
	{
		if (string.IsNullOrWhiteSpace(name))
		{
			GC.KeepAlive(this);
			return -1;
		}
		name = name.Trim();
		int num = this.get_LI(name);
		if (num == -1)
		{
			int num2 = 0;
			if (0 < ListCount)
			{
				do
				{
					if (!(Lists[num2].ListName == name))
					{
						num2++;
						continue;
					}
					num = num2;
					break;
				}
				while (num2 < ListCount);
			}
		}
		GC.KeepAlive(this);
		return num;
	}

	public int[] ParseLists(string[] NameList)
	{
		if (NameList != null)
		{
			int num = NameList.Length;
			if (num != 0)
			{
				List<int> list = new List<int>(num);
				int num2 = 0;
				if (0 < (nint)NameList.LongLength)
				{
					do
					{
						ref string reference = ref NameList[num2];
						int num3;
						if (ACE.RSGlobal.RSGlobal.IsUIntFast(reference = reference.Trim()))
						{
							num3 = ACE.RSGlobal.RSGlobal.UIntParseFast(reference);
							if (num3 >= ListCount)
							{
								goto IL_0047;
							}
						}
						else
						{
							num3 = this.get_LI(reference);
							if (num3 == -1)
							{
								int num4 = 0;
								if (0 >= ListCount)
								{
									goto IL_0047;
								}
								while (!(Lists[num4].ListName == reference))
								{
									num4++;
									if (num4 < ListCount)
									{
										continue;
									}
									goto IL_0047;
								}
								num3 = num4;
							}
						}
						if (num3 > -1)
						{
							list.Add(num3);
						}
						goto IL_0047;
						IL_0047:
						num2++;
					}
					while (num2 < (nint)NameList.LongLength);
				}
				int[] result = list.ToArray();
				GC.KeepAlive(this);
				return result;
			}
		}
		return null;
	}

	public int[] ParseLists(string NameList)
	{
		if (string.IsNullOrWhiteSpace(NameList))
		{
			GC.KeepAlive(this);
			return null;
		}
		int[] array = null;
		if (!NameList.Contains(Class16.smethod_0(1648942211)) && NameList.Contains(Class16.smethod_0(1648941518)))
		{
			string[] array2 = NameList.Split('-');
			int num = this.get_LI(array2[0]);
			int num2 = this.get_LI(array2[1]);
			if (num > -1 && num2 > -1 && num2 > num)
			{
				array = ACE.RSGlobal.RSGlobal.IntArray(num, num2, 1);
			}
		}
		if (array == null)
		{
			string[] nameList = NameList.Split(';');
			array = ParseLists(nameList);
		}
		return array;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsSkillField(int int_0, int int_1, int int_2)
	{
		FIELDTYPE fieldType = GetFieldType(int_0, int_1, int_2);
		int num = ((fieldType == FIELDTYPE.monster_skills || fieldType == FIELDTYPE.potion_skills || fieldType == FIELDTYPE.scrolls_skills || fieldType == FIELDTYPE.skills_pw || fieldType == FIELDTYPE.ft_dyn_skills || fieldType == FIELDTYPE.ft_skills) ? 1 : 0);
		return (byte)num != 0;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsListWithSkills(int int_0)
	{
		int num = 2;
		if (2 < (nint)Lists[int_0].elementTypes.LongLength)
		{
			do
			{
				FIELDTYPE fieldType = GetFieldType(int_0, -1, num);
				int num2 = ((fieldType == FIELDTYPE.monster_skills || fieldType == FIELDTYPE.potion_skills || fieldType == FIELDTYPE.scrolls_skills || fieldType == FIELDTYPE.skills_pw || fieldType == FIELDTYPE.ft_dyn_skills || fieldType == FIELDTYPE.ft_skills) ? 1 : 0);
				if ((byte)num2 == 0)
				{
					num++;
					continue;
				}
				return true;
			}
			while (num < (nint)Lists[int_0].elementTypes.LongLength);
		}
		return false;
	}

	public List<int> GetFieldsWithSkills(int int_0)
	{
		List<int> list = new List<int>();
		int num = 2;
		if (2 < (nint)Lists[int_0].elementTypes.LongLength)
		{
			do
			{
				FIELDTYPE fieldType = GetFieldType(int_0, -1, num);
				int num2 = ((fieldType == FIELDTYPE.monster_skills || fieldType == FIELDTYPE.potion_skills || fieldType == FIELDTYPE.scrolls_skills || fieldType == FIELDTYPE.skills_pw || fieldType == FIELDTYPE.ft_dyn_skills || fieldType == FIELDTYPE.ft_skills) ? 1 : 0);
				if ((byte)num2 != 0)
				{
					list.Add(num);
				}
				num++;
			}
			while (num < (nint)Lists[int_0].elementTypes.LongLength);
		}
		GC.KeepAlive(this);
		return list;
	}

	public List<int> GetSkillsFromList(int int_0, List<int> fileds)
	{
		if (fileds != null && fileds.Count != 0)
		{
			HashSet<int> hashSet = new HashSet<int>();
			int num = Lists[int_0].elementValues.Length;
			int num2 = 0;
			if (0 < num)
			{
				do
				{
					List<int>.Enumerator enumerator = fileds.GetEnumerator();
					if (enumerator.MoveNext())
					{
						do
						{
							int current = enumerator.Current;
							if (int_0 == 0)
							{
								FIELDTYPE fieldType = GetFieldType(0, num2, current);
								int num3 = ((fieldType == FIELDTYPE.monster_skills || fieldType == FIELDTYPE.potion_skills || fieldType == FIELDTYPE.scrolls_skills || fieldType == FIELDTYPE.skills_pw || fieldType == FIELDTYPE.ft_dyn_skills || fieldType == FIELDTYPE.ft_skills) ? 1 : 0);
								if ((byte)num3 == 0)
								{
									continue;
								}
							}
							int valueIFast = Lists[int_0].GetValueIFast(num2, current);
							if (valueIFast > 0 && !hashSet.Contains(valueIFast))
							{
								hashSet.Add(valueIFast);
							}
						}
						while (enumerator.MoveNext());
					}
					num2++;
				}
				while (num2 < num);
			}
			GC.KeepAlive(this);
			return new List<int>(hashSet);
		}
		GC.KeepAlive(this);
		return null;
	}

	public List<int> GetSkillsFromList(int int_0)
	{
		return GetSkillsFromList(int_0, GetFieldsWithSkills(int_0));
	}

	public List<int> GetFields(int int_0, int int_1, params FIELDTYPE[] FieldTypes)
	{
		HashSet<int> hashSet = new HashSet<int>();
		int num = 0;
		if (0 < (nint)FieldTypes.LongLength)
		{
			do
			{
				hashSet.Add((int)FieldTypes[num]);
				num++;
			}
			while (num < (nint)FieldTypes.LongLength);
		}
		List<int> list = new List<int>();
		int num2 = 0;
		if (0 < (nint)Lists[int_0].elementTypes.LongLength)
		{
			do
			{
				if (hashSet.Contains((int)GetFieldType(int_0, int_1, num2)))
				{
					list.Add(num2);
				}
				num2++;
			}
			while (num2 < (nint)Lists[int_0].elementTypes.LongLength);
		}
		GC.KeepAlive(this);
		return list;
	}

	public string GetFieldNameRegex(int int_0, int int_1)
	{
		string input = Lists[int_0].elementFields[int_1];
		string text = Class16.smethod_0(1648902914);
		string result = Regex.Replace(input, text, text);
		GC.KeepAlive(this);
		return result;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsFieldMatch(int int_0, int int_1, string reg_ex)
	{
		bool result = Regex.IsMatch(Lists[int_0].elementFields[int_1], reg_ex);
		GC.KeepAlive(this);
		return result;
	}

	public void Close([MarshalAs(UnmanagedType.U1)] bool bCollectGarbage, [MarshalAs(UnmanagedType.U1)] bool bSafetyCleaning)
	{
		if (!bSafetyCleaning && Lists != null)
		{
			ACE.Elements.eList.eList[] lists = Lists;
			int num = 0;
			if (0 < (nint)lists.LongLength)
			{
				do
				{
					lists[num]?.Close();
					num++;
				}
				while (num < (nint)lists.LongLength);
			}
		}
		Array lists2 = Lists;
		if (lists2 != null)
		{
			Array.Clear(lists2, 0, lists2.Length);
		}
		Lists = null;
		AddonsCollection addons = Addons;
		if (addons != null)
		{
			addons.RefineAddons?.Clear();
			Addons.EquipAddons?.Clear();
			AddonsParts otherAddons = Addons.OtherAddons;
			if (otherAddons != null)
			{
				otherAddons.captions = null;
			}
			Addons = null;
		}
		Skills?.Close();
		FieldCategories?.Clear();
		ShortcutItems?.Clear();
		RecentItems?.Clear();
		ListIndices?.Clear();
		ListTranslation?.Clear();
		if (Localization_sr != null)
		{
			Localization_sr = null;
		}
		FIELDS_TRANSLATER translatedFieldsGlobal = TranslatedFieldsGlobal;
		if (translatedFieldsGlobal != null)
		{
			translatedFieldsGlobal.TranslatedFields?.Clear();
			((IDisposable)translatedFieldsGlobal.TranslatedFieldsRegEx)?.Dispose();
			TranslatedFieldsGlobal = null;
		}
		Dictionary<int, int[]> similarListsCache = SimilarListsCache;
		if (similarListsCache != null)
		{
			Dictionary<int, int[]>.ValueCollection.Enumerator enumerator = similarListsCache.Values.GetEnumerator();
			if (enumerator.MoveNext())
			{
				do
				{
					int[] current = enumerator.Current;
					if (current != null)
					{
						Array.Clear(current, 0, current.Length);
					}
				}
				while (enumerator.MoveNext());
			}
			SimilarListsCache.Clear();
			SimilarListsCache = null;
		}
		Dictionary<int, List<int[]>> probFieldsSuites = ProbFieldsSuites;
		if (probFieldsSuites != null)
		{
			Dictionary<int, List<int[]>>.ValueCollection.Enumerator enumerator2 = probFieldsSuites.Values.GetEnumerator();
			if (enumerator2.MoveNext())
			{
				do
				{
					List<int[]> current2 = enumerator2.Current;
					if (current2 == null)
					{
						continue;
					}
					List<int[]>.Enumerator enumerator3 = current2.GetEnumerator();
					if (enumerator3.MoveNext())
					{
						do
						{
							int[] current3 = enumerator3.Current;
							if (current3 != null)
							{
								Array.Clear(current3, 0, current3.Length);
							}
						}
						while (enumerator3.MoveNext());
					}
					current2.Clear();
				}
				while (enumerator2.MoveNext());
			}
			ProbFieldsSuites.Clear();
			ProbFieldsSuites = null;
		}
		Dictionary<int, List<PROB_SUITE_EXTENDED>> probFieldsSuitesEx = ProbFieldsSuitesEx;
		if (probFieldsSuitesEx != null)
		{
			probFieldsSuitesEx.Clear();
			ProbFieldsSuitesEx = null;
		}
		Dictionary<int, int[]> fieldsToEncrypt = FieldsToEncrypt;
		if (fieldsToEncrypt != null)
		{
			Dictionary<int, int[]>.ValueCollection.Enumerator enumerator4 = fieldsToEncrypt.Values.GetEnumerator();
			if (enumerator4.MoveNext())
			{
				do
				{
					_ = enumerator4.Current;
				}
				while (enumerator4.MoveNext());
			}
			FieldsToEncrypt.Clear();
			FieldsToEncrypt = null;
		}
		Dictionary<int, ITEMINFO>[] itemsCache = ItemsCache;
		if (itemsCache != null)
		{
			Dictionary<int, ITEMINFO>[] array = itemsCache;
			int num2 = 0;
			if (0 < (nint)array.LongLength)
			{
				do
				{
					ref Dictionary<int, ITEMINFO> reference = ref array[num2];
					reference?.Clear();
					reference = null;
					num2++;
				}
				while (num2 < (nint)array.LongLength);
			}
			Array itemsCache2 = ItemsCache;
			if (itemsCache2 != null)
			{
				Array.Clear(itemsCache2, 0, itemsCache2.Length);
			}
		}
		List<int>[] iDsCache = IDsCache;
		if (iDsCache != null)
		{
			List<int>[] array2 = iDsCache;
			int num3 = 0;
			if (0 < (nint)array2.LongLength)
			{
				do
				{
					array2[num3]?.Clear();
					num3++;
				}
				while (num3 < (nint)array2.LongLength);
			}
			Array iDsCache2 = IDsCache;
			if (iDsCache2 != null)
			{
				Array.Clear(iDsCache2, 0, iDsCache2.Length);
			}
			IDsCache = null;
		}
		LastAddons?.Clear();
		DecodedValues?.Close();
		DecodedValues = null;
		MattersListsFast?.Clear();
		MattersListsFast = null;
		StructChangedLists?.Clear();
		StructChangedLists = null;
		Dictionary<ID_SPACE, List<int>> spaces = Spaces;
		if (spaces != null)
		{
			Dictionary<ID_SPACE, List<int>>.ValueCollection.Enumerator enumerator5 = spaces.Values.GetEnumerator();
			if (enumerator5.MoveNext())
			{
				do
				{
					enumerator5.Current?.Clear();
				}
				while (enumerator5.MoveNext());
			}
			Spaces.Clear();
			Spaces = null;
		}
		method_34();
		if (bCollectGarbage)
		{
			GC.Collect();
			GC.WaitForPendingFinalizers();
		}
		GC.KeepAlive(this);
	}

	public int GetItemSubItemsCount(ITEMPOS ParentItem)
	{
		int item_count = 0;
		GetItemSubItems(ParentItem, ref item_count, bOnlyCount: true, bAllPossibleItems: false, bOnlyItemsAllowed: true);
		if (item_count == -1)
		{
			GetItemSubItems(ParentItem, ref item_count, bOnlyCount: true, bAllPossibleItems: false, bOnlyItemsAllowed: false);
		}
		if (item_count <= -1)
		{
			return 0;
		}
		return item_count;
	}

	public List<ITEMPOS> GetItemSubItems(ITEMPOS ParentItem, ref int item_count, [MarshalAs(UnmanagedType.U1)] bool bOnlyCount, [MarshalAs(UnmanagedType.U1)] bool bAllPossibleItems, [MarshalAs(UnmanagedType.U1)] bool bOnlyItemsAllowed)
	{
		item_count = 0;
		List<ITEMPOS> list = null;
		bool flag = false;
		string text = null;
		int num = 1;
		int int_ = ParentItem.int_0;
		ACE.Elements.eList.eList[] lists = Lists;
		ref ACE.Elements.eList.eList reference = ref lists[int_];
		switch (lists[int_].ListType)
		{
		case ItemType.PW_ENGRAVE_ESSENCE:
			num = reference.get_fields(Class16.smethod_0(1648922636));
			bAllPossibleItems = false;
			bOnlyItemsAllowed = true;
			break;
		case ItemType.PW_RECIPE_ESSENCE:
			num = reference.get_fields(Class16.smethod_0(1649080810));
			break;
		case ItemType.PW_NPC_ESSENCE:
			num = reference.get_fields(Class16.smethod_0(1649075719));
			bAllPossibleItems = true;
			bOnlyItemsAllowed = true;
			break;
		case ItemType.ESO_NPC_ESSENCE:
			num = reference.get_fields(Class16.smethod_0(1649075754));
			bAllPossibleItems = true;
			bOnlyItemsAllowed = true;
			break;
		case ItemType.FW_NPC_ESSENCE:
			num = reference.get_fields(Class16.smethod_0(1649075776));
			bAllPossibleItems = true;
			bOnlyItemsAllowed = true;
			break;
		case ItemType.JD_NPC_ESSENCE:
			num = reference.get_fields(Class16.smethod_0(1649075740));
			bAllPossibleItems = true;
			bOnlyItemsAllowed = true;
			break;
		}
		int num2 = num;
		int int_2 = ParentItem.int_0;
		if (num < (nint)Lists[int_2].elementTypes.LongLength)
		{
			do
			{
				FIELDTYPE fieldType = GetFieldType(int_2, num2);
				bool flag2;
				if (bOnlyItemsAllowed)
				{
					int num3 = ((fieldType >= FIELDTYPE.matters || fieldType == FIELDTYPE.refine_addon_pw || fieldType == FIELDTYPE.equip_addon || fieldType == FIELDTYPE.ft_quest) ? 1 : 0);
					flag2 = (byte)num3 != 0;
				}
				else
				{
					flag2 = fieldType >= FIELDTYPE.ai_id;
				}
				if (flag2)
				{
					string input = Lists[ParentItem.int_0].elementFields[num2];
					if (bAllPossibleItems)
					{
						goto IL_01b8;
					}
					if (text == null)
					{
						if (Regex.IsMatch(input, Class16.smethod_0(1649082220)))
						{
							string text2 = Class16.smethod_0(1648902914);
							text = Regex.Replace(input, text2, text2);
							goto IL_01b8;
						}
					}
					else if (Regex.IsMatch(input, text))
					{
						goto IL_01b8;
					}
				}
				goto IL_0230;
				IL_0230:
				num2++;
				int_2 = ParentItem.int_0;
				continue;
				IL_01b8:
				flag = true;
				int int_3 = ParentItem.int_1;
				int int_4 = ParentItem.int_0;
				int valueIFast = Lists[int_4].GetValueIFast(int_3, num2);
				GC.KeepAlive(this);
				if (valueIFast != 0)
				{
					item_count++;
					if (!bOnlyCount && (fieldType >= FIELDTYPE.matters || fieldType == FIELDTYPE.refine_addon_pw || fieldType == FIELDTYPE.equip_addon))
					{
						ITEMPOS iTEMPOS = FindItemPos(GetFieldLists(fieldType), valueIFast);
						if (iTEMPOS != null)
						{
							if (list == null)
							{
								list = new List<ITEMPOS>();
							}
							list.Add(iTEMPOS);
						}
					}
				}
				goto IL_0230;
			}
			while (num2 < (nint)Lists[int_2].elementTypes.LongLength);
			if (flag)
			{
				goto IL_0280;
			}
		}
		item_count = -1;
		goto IL_0280;
		IL_0280:
		GC.KeepAlive(this);
		return list;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsListContainSubItems(int int_0)
	{
		if (!CommonStorage.AParams.ShowSubitemsCountInListView)
		{
			GC.KeepAlive(this);
			return false;
		}
		if (IsListWithPages(int_0))
		{
			return true;
		}
		if (ListsWithItemsSet == null)
		{
			string[] array = new string[36]
			{
				Class16.smethod_0(1648960167),
				Class16.smethod_0(1649079261),
				Class16.smethod_0(1649079287),
				Class16.smethod_0(1649078282),
				Class16.smethod_0(1648972702),
				Class16.smethod_0(1649075810),
				Class16.smethod_0(1648952558),
				Class16.smethod_0(1648963535),
				Class16.smethod_0(1648923298),
				Class16.smethod_0(1648923326),
				Class16.smethod_0(1649075845),
				Class16.smethod_0(1648923456),
				Class16.smethod_0(1648952571),
				Class16.smethod_0(1649075871),
				Class16.smethod_0(1649080790),
				Class16.smethod_0(1649078729),
				Class16.smethod_0(1648955663),
				Class16.smethod_0(1648923338),
				Class16.smethod_0(1649075894),
				Class16.smethod_0(1649075924),
				Class16.smethod_0(1648953506),
				Class16.smethod_0(1648954354),
				Class16.smethod_0(1648955681),
				Class16.smethod_0(1648952781),
				Class16.smethod_0(1648952757),
				Class16.smethod_0(1648923432),
				Class16.smethod_0(1649075950),
				Class16.smethod_0(1648952704),
				Class16.smethod_0(1648952829),
				Class16.smethod_0(1649075991),
				Class16.smethod_0(1649076010),
				Class16.smethod_0(1649076034),
				Class16.smethod_0(1649076058),
				Class16.smethod_0(1649076095),
				Class16.smethod_0(1649076115),
				Class16.smethod_0(1649080244)
			};
			ListsWithItemsSet = new HashSet<int>();
			int num = 0;
			if (0 < (nint)array.LongLength)
			{
				do
				{
					int num2 = this.get_LI(array[num]);
					if (num2 > -1)
					{
						ListsWithItemsSet.Add(num2);
					}
					num++;
				}
				while (num < (nint)array.LongLength);
			}
		}
		bool result = ListsWithItemsSet.Contains(int_0);
		GC.KeepAlive(this);
		return result;
	}

	public List<vITEMPOS> GetListItems(int int_0, [MarshalAs(UnmanagedType.U1)] bool bFromEnd)
	{
		int itemCount = Lists[int_0].ItemCount;
		List<vITEMPOS> list = new List<vITEMPOS>(itemCount);
		if (bFromEnd)
		{
			int num = itemCount - 1;
			if (num >= 0)
			{
				vITEMPOS item = default(vITEMPOS);
				do
				{
					item.Int32_1 = int_0;
					item.Int32_0 = num;
					list.Add(item);
					num--;
				}
				while (num >= 0);
			}
		}
		else
		{
			int num2 = 0;
			if (0 < itemCount)
			{
				vITEMPOS item2 = default(vITEMPOS);
				do
				{
					item2.Int32_1 = int_0;
					item2.Int32_0 = num2;
					list.Add(item2);
					num2++;
				}
				while (num2 < itemCount);
			}
		}
		GC.KeepAlive(this);
		return list;
	}

	public void stChangeItems(ITEMS_COLLECTION Items, [MarshalAs(UnmanagedType.U1)] bool bChangeDesc)
	{
		List<LISTandID> itemsListAndId = GetItemsListAndId(Items.GetListOfItems());
		(Items.ListAndIdHashes = new HashSet<LISTandID>()).UnionWith(itemsListAndId);
		Items.bChangeDesc = true;
		ActionsHistory.stChangeItems(Items);
		GC.KeepAlive(this);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsFieldEmpty(int int_0, int int_1, int int_2)
	{
		ACE.Elements.eList.eList eList2 = Lists[int_0];
		ref object reference = ref eList2.elementValues[int_1][int_2];
		bool result;
		switch (eList2.FieldDataTypes[int_2].data_type)
		{
		case FIELD_DATA_TYPE_ENUM.Int:
			result = reference.Equals(ACE.Elements.eList.eList.i0);
			break;
		case FIELD_DATA_TYPE_ENUM.Int16:
			result = (short)reference == 0;
			break;
		case FIELD_DATA_TYPE_ENUM.UInt:
			result = (uint)reference == 0;
			break;
		case FIELD_DATA_TYPE_ENUM.Int64:
			result = (long)reference == 0L;
			break;
		case FIELD_DATA_TYPE_ENUM.UInt64:
			result = (ulong)reference == 0L;
			break;
		case FIELD_DATA_TYPE_ENUM.Float:
			result = reference.Equals(ACE.Elements.eList.eList.f0);
			break;
		case FIELD_DATA_TYPE_ENUM.Double:
			result = (double)reference == 0.0;
			break;
		default:
		{
			string empty = string.Empty;
			result = GetValue(int_0, int_1, int_2) == empty;
			break;
		}
		case FIELD_DATA_TYPE_ENUM.Bool:
		{
			result = true;
			byte[] array = (byte[])reference;
			int num = 0;
			int num2 = array.Length;
			if (0 >= num2)
			{
				break;
			}
			do
			{
				if (array[num] == 0)
				{
					num++;
					continue;
				}
				result = false;
				break;
			}
			while (num < num2);
			break;
		}
		}
		GC.KeepAlive(this);
		return result;
	}

	public List<PROB_SUITE_EXTENDED> ProbSuitesGetAllItemValues(ITEMPOS ItemPos)
	{
		if (ProbFieldsSuitesEx == null)
		{
			ProbFieldsSuitesEx = new Dictionary<int, List<PROB_SUITE_EXTENDED>>();
		}
		List<PROB_SUITE_EXTENDED> probFieldsSuitesEx = GetProbFieldsSuitesEx(ItemPos.int_0);
		List<PROB_SUITE_EXTENDED>.Enumerator enumerator = probFieldsSuitesEx.GetEnumerator();
		if (enumerator.MoveNext())
		{
			do
			{
				PROB_SUITE_EXTENDED current = enumerator.Current;
				current.ValuesList = new List<PROB_VALUES>(current.fields.Length);
				int num = 0;
				if (0 < (nint)current.fields.LongLength)
				{
					do
					{
						current.TryAddValues(ItemPos, num);
						num++;
					}
					while (num < (nint)current.fields.LongLength);
				}
			}
			while (enumerator.MoveNext());
		}
		GC.KeepAlive(this);
		return probFieldsSuitesEx;
	}

	public PROB_ONE_FIELD_SET GetSuiteByProb(ITEMPOS ItemPos, int int_0)
	{
		PROB_ONE_FIELD_SET result = null;
		if (ProbFieldsSuitesEx == null)
		{
			ProbFieldsSuitesEx = new Dictionary<int, List<PROB_SUITE_EXTENDED>>();
		}
		List<PROB_SUITE_EXTENDED> probFieldsSuitesEx = GetProbFieldsSuitesEx(ItemPos.int_0);
		if (probFieldsSuitesEx != null)
		{
			List<PROB_SUITE_EXTENDED>.Enumerator enumerator = probFieldsSuitesEx.GetEnumerator();
			if (enumerator.MoveNext())
			{
				do
				{
					PROB_SUITE_EXTENDED current = enumerator.Current;
					current.ValuesList = new List<PROB_VALUES>(current.fields.Length);
					int num = Array.IndexOf(current.fields, int_0);
					if (num > -1)
					{
						result = new PROB_ONE_FIELD_SET(current.FieldList[num], current.GetValues(ItemPos, num));
						break;
					}
				}
				while (enumerator.MoveNext());
			}
		}
		GC.KeepAlive(this);
		return result;
	}

	public List<PROB_SUITE_EXTENDED> GetProbFieldsSuitesEx(int int_0)
	{
		List<PROB_SUITE_EXTENDED> list = null;
		if (ProbFieldsSuitesEx == null)
		{
			ProbFieldsSuitesEx = new Dictionary<int, List<PROB_SUITE_EXTENDED>>();
		}
		list = null;
		if (ProbFieldsSuitesEx.TryGetValue(int_0, out list))
		{
			GC.KeepAlive(this);
			return list;
		}
		if (!GetProbFieldsSuites().ContainsKey(int_0))
		{
			GC.KeepAlive(this);
			return null;
		}
		list = new List<PROB_SUITE_EXTENDED>(ProbFieldsSuites[int_0].Count);
		List<int[]>.Enumerator enumerator = ProbFieldsSuites[int_0].GetEnumerator();
		if (enumerator.MoveNext())
		{
			do
			{
				int[] current = enumerator.Current;
				PROB_SUITE_EXTENDED pROB_SUITE_EXTENDED = new PROB_SUITE_EXTENDED(Lists[int_0]);
				pROB_SUITE_EXTENDED.fields = current;
				int id_offset = 0;
				int num = 0;
				int val2_offset = 0;
				if ((uint)((pROB_SUITE_EXTENDED.field_count = current[1] - current[0]) - 2) <= 2u)
				{
					bool flag = false;
					int num2 = current[1] - 1;
					if (num2 > current[0])
					{
						do
						{
							int num3 = current[1];
							int num4 = num2 - num3;
							if (!flag)
							{
								flag = !IsEqualFieldSuites(int_0, num2, num3);
							}
							FIELDTYPE fieldType = GetFieldType(int_0, -1, num2);
							if (!pROB_SUITE_EXTENDED.IsItemPresent && (fieldType >= FIELDTYPE.matters || fieldType == FIELDTYPE.equip_addon))
							{
								pROB_SUITE_EXTENDED.AvailableLists = GetFieldLists(int_0, -1, num2);
								pROB_SUITE_EXTENDED.IsItemPresent = true;
								id_offset = num4;
							}
							else
							{
								if (flag)
								{
									num4 = pROB_SUITE_EXTENDED.field_count + num4;
								}
								if (num == 0)
								{
									num = num4;
								}
								else
								{
									val2_offset = num4;
								}
							}
							num2--;
						}
						while (num2 > current[0]);
					}
				}
				else
				{
					pROB_SUITE_EXTENDED.IsFixedSize = true;
				}
				int num5 = 0;
				if (0 < (nint)current.LongLength)
				{
					do
					{
						PROB_FIELDS item = new PROB_FIELDS(pROB_SUITE_EXTENDED.field_count, current[num5], id_offset, num, val2_offset);
						pROB_SUITE_EXTENDED.FieldList.Add(item);
						num5++;
					}
					while (num5 < (nint)current.LongLength);
				}
				list.Add(pROB_SUITE_EXTENDED);
			}
			while (enumerator.MoveNext());
		}
		ProbFieldsSuitesEx.Add(int_0, list);
		GC.KeepAlive(this);
		return list;
	}

	public void CalculateMaxFieldsValues(int int_0)
	{
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool TryCreateNewStructureSmart(string KnownFileName, string sExcludedLists)
	{
		eListCollection eListCollection2 = new eListCollection(KnownFileName, bMultithread: true);
		List<string> list = new List<string>();
		BinaryReader binaryReader = new BinaryReader(File.OpenRead(FileName));
		int[] array = ParseLists(sExcludedLists);
		int[] allLists = AllLists;
		int num = 0;
		if (0 < (nint)allLists.LongLength)
		{
			do
			{
				int num2 = allLists[num];
				if (array == null || array.Length == 0 || Array.IndexOf(array, num2) <= -1)
				{
					string uListName = Lists[num2].uListName;
					ACE.Elements.eList.eList eList2 = eListCollection2[uListName];
					if (eList2 != null && Lists[num2].item_size != eList2.item_size)
					{
						int num3 = 0;
						num3 = ((!(uListName == Class16.smethod_0(1649076150))) ? num3 : 0);
						int listItemSize = ACE.Elements.eList.eList.GetListItemSize(Lists[num2], skipStrings: false);
						int num4 = -1;
						ACE.Elements.eList.eList eList3 = null;
						FalseOrTrueOrNotSet falseOrTrueOrNotSet = FalseOrTrueOrNotSet.NotSet;
						bool flag = false;
						while ((falseOrTrueOrNotSet == FalseOrTrueOrNotSet.NotSet || flag) && num3 < eList2.ItemCount)
						{
							falseOrTrueOrNotSet = FalseOrTrueOrNotSet.NotSet;
							flag = false;
							int id = eList2.getid(num3);
							int num5 = FindItemIndexByID(num2, id);
							if (num5 == -1)
							{
								num3++;
								continue;
							}
							ACE.Elements.eList.eList eList4 = new ACE.Elements.eList.eList();
							eList4.elementTypes = ACE.RSGlobal.RSGlobal.CloneArray(eList2.elementTypes);
							eList4.elementFields = ACE.RSGlobal.RSGlobal.CloneArray(eList2.elementFields);
							eList4._elementTypes = ACE.RSGlobal.RSGlobal.CloneArray(eList2._elementTypes);
							eList4._elementFields = ACE.RSGlobal.RSGlobal.CloneArray(eList2._elementFields);
							(eList4.elementValues = new object[1][])[0] = new object[(nint)eList4.elementTypes.LongLength + 1];
							long offset = Lists[num2].d_elementOffsets[num5];
							binaryReader.BaseStream.Seek(offset, SeekOrigin.Begin);
							_ = binaryReader.BaseStream.Position;
							int num6 = 0;
							int num7 = 0;
							int num8 = 0;
							while (true)
							{
								long num9 = binaryReader.BaseStream.Position;
								if (num8 >= (nint)eList2.elementTypes.LongLength || flag)
								{
									break;
								}
								object obj_val = ACE.Elements.eList.eList.readValue(binaryReader, eList4.elementTypes[num7]);
								if (num8 > eList2.NameFieldIndex && !((num8 <= -1) ? string.Empty : eList2.elementTypes[num8]).StartsWith(Class16.smethod_0(1648902778)))
								{
									string value = ACE.Elements.eList.eList.GetValue(obj_val, eList4.elementTypes[num7], roundTrip: false);
									string value2 = eList2.GetValue(0, num8, roundTrip: false);
									ACE.Elements.eList.eList eList5 = null;
									bool flag2;
									if (flag2 = value != value2)
									{
										eList5 = new ACE.Elements.eList.eList();
										eList5.elementTypes = ACE.RSGlobal.RSGlobal.CloneArray(eList4.elementTypes);
										eList5.elementFields = ACE.RSGlobal.RSGlobal.CloneArray(eList4.elementFields);
										eList5._elementTypes = ACE.RSGlobal.RSGlobal.CloneArray(eList4._elementTypes);
										eList5._elementFields = ACE.RSGlobal.RSGlobal.CloneArray(eList4._elementFields);
									}
									if (value != value2)
									{
										string value3;
										do
										{
											binaryReader.BaseStream.Position = num9;
											int int_ = binaryReader.ReadInt32();
											method_8(eList4, int_, num7);
											num9 += 4L;
											num7++;
											value3 = ACE.Elements.eList.eList.GetValue(ACE.Elements.eList.eList.readValue(binaryReader, eList4.elementTypes[num7]), eList4.elementTypes[num7], roundTrip: false);
											if (ACE.Elements.eList.eList.GetListItemSize(eList4, skipStrings: false) > listItemSize)
											{
												flag = true;
												eList4.elementTypes = eList5.elementTypes;
												eList4.elementFields = eList5.elementFields;
												eList4._elementTypes = eList5._elementTypes;
												eList4._elementFields = eList5._elementFields;
												break;
											}
										}
										while (value3 != value2);
									}
									if (flag2 && !flag)
									{
										num6++;
									}
								}
								num7++;
								num8++;
							}
							int listItemSize2 = ACE.Elements.eList.eList.GetListItemSize(eList4, skipStrings: false);
							int num10 = ACE.Elements.eList.eList.GetListItemSize(Lists[num2], skipStrings: false) - listItemSize2;
							if (num10 != 0)
							{
								int num11 = num10 % 4;
								if (num11 > 0)
								{
									num10 -= num11;
								}
								int num12 = num10 / 4;
								if (num12 > 0)
								{
									int num13 = num12;
									do
									{
										method_6(eList4, Class16.smethod_0(1648989776), eList4.elementTypes.Length);
										num13--;
									}
									while (num13 != 0);
								}
								else if (num12 != 0)
								{
									uint num14 = (uint)(-num12);
									do
									{
										ACE.RSGlobal.RSGlobal.RemoveArrayLastElement(ref eList4.elementTypes);
										ACE.RSGlobal.RSGlobal.RemoveArrayLastElement(ref eList4.elementFields);
										ACE.RSGlobal.RSGlobal.RemoveArrayLastElement(ref eList4._elementTypes);
										ACE.RSGlobal.RSGlobal.RemoveArrayLastElement(ref eList4._elementFields);
										num14--;
									}
									while (num14 != 0);
								}
								if (num11 > 0)
								{
									string string_ = Class16.smethod_0(1648985282) + num11;
									method_6(eList4, string_, eList4.elementTypes.Length);
								}
							}
							falseOrTrueOrNotSet = FalseOrTrueOrNotSet.True;
							if (num6 > num4)
							{
								eList3 = eList4;
								num4 = num6;
							}
							num3++;
						}
						if (falseOrTrueOrNotSet == FalseOrTrueOrNotSet.True)
						{
							Lists[num2].elementTypes = eList3.elementTypes;
							Lists[num2].elementFields = eList3.elementFields;
							Lists[num2]._elementTypes = eList3._elementTypes;
							Lists[num2]._elementFields = eList3._elementFields;
							long listOffset = Lists[num2].listOffset;
							binaryReader.BaseStream.Position = listOffset;
							ReadList(binaryReader, Game, Version, num2, ref Lists, ConversationListIndex, bReadOffset: true, domesticPW);
							bool flag3 = !flag;
							string text = Class16.smethod_0(1649008474);
							string text2 = Class16.smethod_0(1649076174);
							list.Add(string.Concat(string.Concat(string.Concat(flag3 + text2, num2), text), uListName));
						}
						else
						{
							list.Add(Class16.smethod_0(1649076176) + uListName);
						}
						string a_ = string.Format(Class16.smethod_0(1649076198), num2, ListCount);
						universalStatusHandler_0?.Invoke(a_);
					}
				}
				num++;
			}
			while (num < (nint)allLists.LongLength);
		}
		MattersReferencesBase = new Dictionary<int, List<int>>();
		int[] allLists2 = AllLists;
		int num15 = 0;
		if (0 < (nint)allLists2.LongLength)
		{
			do
			{
				int num16 = allLists2[num15];
				Lists[num16].References = null;
				Lists[num16].FieldsBindedLists = null;
				Lists[num16].CreateFastDataTypes();
				Lists[num16].UpdateIDs();
				ACE.Elements.eList.eList eList6 = Lists[num16];
				eList6.fieldtypes = new FIELDTYPE[(nint)eList6.elementFields.LongLength];
				method_4(num16, bool_1: true);
				num15++;
			}
			while (num15 < (nint)allLists2.LongLength);
		}
		binaryReader.Close();
		ResetCachedLists();
		UpdateElementsReferences();
		ACE.RSGlobal.RSGlobal.OpenInNotepad(list);
		GC.KeepAlive(this);
		return true;
	}

	public string GetClassNameJD(int ClassID)
	{
		string text = null;
		ITEMPOS classItemPos = GetClassItemPos(ClassID);
		if (classItemPos != null)
		{
			text = GetParsedItemName(classItemPos);
		}
		if (text == null)
		{
			text = TextStorage.TEXTS.GetText(Class16.smethod_0(1648924372));
		}
		GC.KeepAlive(this);
		return text;
	}

	public int GetClassItemIdByClassId(int ClassID)
	{
		int result = 0;
		ITEMPOS classItemPos = GetClassItemPos(ClassID);
		if (classItemPos != null)
		{
			result = getid(classItemPos);
		}
		return result;
	}

	public ITEMPOS GetClassItemPos(int ClassID)
	{
		int num = this.get_LI(Class16.smethod_0(1649076212));
		ITEMPOS result = null;
		int num2 = 0;
		if (0 < Lists[num].ItemCount)
		{
			do
			{
				if (GetValueI(num, num2, Class16.smethod_0(1649081596)) != ClassID)
				{
					num2++;
					continue;
				}
				result = new ITEMPOS(num, num2);
				break;
			}
			while (num2 < Lists[num].ItemCount);
		}
		return result;
	}

	public int GetClassIdByClassItem(int ItemID)
	{
		int num = this.get_LI(Class16.smethod_0(1649076212));
		int result = 0;
		ITEMPOS iTEMPOS = null;
		int num2 = FindItemIndexByID(num, ItemID);
		if (num2 > -1)
		{
			iTEMPOS = new ITEMPOS(num, num2);
		}
		if (iTEMPOS != null)
		{
			result = GetValueI(iTEMPOS, Class16.smethod_0(1649081596));
		}
		return result;
	}

	public List<EnumEntry> ParseEnumsFile()
	{
		List<EnumEntry> list = new List<EnumEntry>();
		string text = Class16.smethod_0(1649075209);
		short version = Version;
		string text2 = Class16.smethod_0(1649075218);
		string gamePrefix = GamePrefix;
		string text3 = Class16.smethod_0(1648927580);
		string text4 = Class16.smethod_0(1648960967);
		string path = string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(Application.StartupPath + text4, gamePrefix), text3), gamePrefix), text2), version), text);
		if (!File.Exists(path))
		{
			GC.KeepAlive(this);
			return null;
		}
		StreamReader streamReader = File.OpenText(path);
		string input = streamReader.ReadToEnd();
		input = RSCommon.RemoveComments(input);
		MatchCollection matchCollection = Regex.Matches(input, Class16.smethod_0(1649075233), RegexOptions.Multiline);
		streamReader.Close();
		EnumToStrId = new Dictionary<string, int>(matchCollection.Count);
		string[] searchedStrings = new string[3]
		{
			Class16.smethod_0(1649075282),
			Class16.smethod_0(1649075302),
			Class16.smethod_0(1649075307)
		};
		foreach (Match item in matchCollection)
		{
			string value = item.Groups[1].Value;
			char[] trimChars = new char[4] { ' ', '\r', '\n', '\t' };
			string text5 = item.Groups[2].Value.Trim(trimChars);
			text5 = text5.Replace(Class16.smethod_0(1648942211), string.Empty);
			string[] array = text5.Split(',');
			if (array.Length == 0)
			{
				continue;
			}
			bool flag;
			if (!(flag = value.Contains(Class16.smethod_0(1649075326))) && (nint)array.LongLength >= 3 && !value.Contains(Class16.smethod_0(1649075329)))
			{
				int num = (((array[0].EndsWith(Class16.smethod_0(1649075348)) && array[2].EndsWith(Class16.smethod_0(1649075357))) || (array[0].EndsWith(Class16.smethod_0(1649075366)) && array[2].EndsWith(Class16.smethod_0(1649075369)))) ? 1 : 0);
				flag = (byte)num != 0;
			}
			int num2 = array.Length;
			if (num2 > 1)
			{
				num2 = (string.IsNullOrWhiteSpace(array[num2 - 1]) ? (num2 - 1) : num2);
				for (int i = Math.Max((int)((nint)array.LongLength - 3), 0); i < (nint)array.LongLength; i++)
				{
					if (ACE.RSGlobal.RSGlobal.IsStringContainsAnyStringInArray(array[i], searchedStrings))
					{
						num2--;
					}
				}
			}
			if (num2 == 0)
			{
				continue;
			}
			EnumEntry enumEntry = new EnumEntry();
			enumEntry.EnumName = value;
			enumEntry.Members = new EnumMember[num2];
			decimal num3 = default(decimal);
			for (int j = 0; j < num2; j++)
			{
				string text6 = array[j].Trim();
				if (text6.Contains(Class16.smethod_0(1648908627)))
				{
					string[] array2 = text6.Split('=');
					text6 = array2[0].Trim();
					string text7 = array2[1].Trim();
					num3 = ((!text7.StartsWith(Class16.smethod_0(1648917675))) ? decimal.Parse(text7) : ((decimal)(int)new Int32Converter().ConvertFromString(text7)));
					if (!flag && j > 0)
					{
						decimal num4 = 4m;
						if (enumEntry.Members[j - 1].Value == num4)
						{
							decimal num5 = 8m;
							flag = num3 == num5 || flag;
						}
					}
				}
				enumEntry.Members[j] = new EnumMember();
				enumEntry.Members[j].Name = text6;
				enumEntry.Members[j].Value = num3;
				++num3;
			}
			enumEntry.IsMask = flag;
			list.Add(enumEntry);
		}
		GC.KeepAlive(this);
		return list;
	}

	public void CreateTranslationForEnumsAndMasks([MarshalAs(UnmanagedType.U1)] bool autoTranslate)
	{
		if (autoTranslate)
		{
			UniversalTranslator.SwitchTranslator(useOpenAi: true);
			if (!UniversalTranslator.Init())
			{
				autoTranslate = false;
			}
		}
		List<EnumEntry> list = ParseEnumsFile();
		EnumsTranslations = new Dictionary<string, Dictionary<string, Dictionary<string, string>>>(list.Count);
		TextInfo textInfo = Application.CurrentCulture.TextInfo;
		List<EnumEntry>.Enumerator enumerator = list.GetEnumerator();
		if (enumerator.MoveNext())
		{
			do
			{
				EnumEntry current = enumerator.Current;
				string text = current.EnumName.ToLowerInvariant();
				string text2 = null;
				string text3 = null;
				string text4 = null;
				int num = text.LastIndexOf(Class16.smethod_0(1648923968));
				if (num > -1)
				{
					text2 = text.Substring(0, num);
					text3 = text.Replace(Class16.smethod_0(1648923968), string.Empty);
					text4 = text2.Replace(Class16.smethod_0(1648923968), string.Empty);
				}
				List<string> list2 = new List<string>(current.Members.Length);
				EnumMember[] members = current.Members;
				int num2 = 0;
				if (0 < (nint)members.LongLength)
				{
					do
					{
						list2.Add(members[num2].Name);
						num2++;
					}
					while (num2 < (nint)members.LongLength);
				}
				string text5 = null;
				if (list2.Count > 1)
				{
					text5 = RSCommon.GetCommonPrefix(list2.ToArray(), list2.Count);
				}
				Dictionary<string, Dictionary<string, string>> dictionary = new Dictionary<string, Dictionary<string, string>>();
				int num3 = 0;
				EnumMember[] members2 = current.Members;
				if (0 < (nint)members2.LongLength)
				{
					do
					{
						string name = members2[num3].Name;
						string text6 = name;
						if (text5 != null)
						{
							text6 = name.Substring(text5.Length);
						}
						else if (name.StartsWith(text))
						{
							text6 = name.Substring(text.Length + 1);
						}
						else if (text3 != null && name.StartsWith(text3))
						{
							text6 = name.Substring(text3.Length + 1);
						}
						else if (text2 != null && name.StartsWith(text2))
						{
							text6 = name.Substring(text2.Length + 1);
						}
						else if (text4 != null && name.StartsWith(text4))
						{
							text6 = name.Substring(text4.Length + 1);
						}
						if (text6.ToUpperInvariant() == text6)
						{
							text6 = text6.ToLowerInvariant();
							string empty = string.Empty;
							string oldValue = Class16.smethod_0(1649075388);
							text6 = text6.Replace(Class16.smethod_0(1649075392), empty).Replace(oldValue, empty);
							string empty2 = string.Empty;
							string oldValue2 = Class16.smethod_0(1649075412);
							text6 = text6.Replace(Class16.smethod_0(1649075423), empty2).Replace(oldValue2, empty2);
							text6 = textInfo.ToTitleCase(text6.Replace('_', ' '));
						}
						else
						{
							string empty3 = string.Empty;
							string oldValue3 = Class16.smethod_0(1649075388);
							text6 = text6.Replace(Class16.smethod_0(1649075392), empty3).Replace(oldValue3, empty3);
							string empty4 = string.Empty;
							string oldValue4 = Class16.smethod_0(1649075412);
							text6 = text6.Replace(Class16.smethod_0(1649075423), empty4).Replace(oldValue4, empty4);
							text6 = ACE.RSGlobal.RSGlobal.ConvertTitleCasedPropToNormalEnglish(text6);
						}
						Dictionary<string, string> dictionary2 = new Dictionary<string, string>(CommonStorage.Texts.Languages.Count);
						LANG_INFO[] languages = CommonStorage.Texts.Languages.Languages;
						int num4 = 0;
						if (0 < (nint)languages.LongLength)
						{
							do
							{
								string prefix = languages[num4].Prefix;
								string value = string.Empty;
								if (prefix == Class16.smethod_0(1648931959))
								{
									value = text6;
								}
								else if (autoTranslate)
								{
									int to = UniversalTranslator.ru_index;
									if (prefix == Class16.smethod_0(1648932099))
									{
										to = UniversalTranslator.cn_index;
									}
									else if (prefix == Class16.smethod_0(1648932116))
									{
										to = UniversalTranslator.pt_index;
									}
									value = UniversalTranslator.Translate(text6, UniversalTranslator.en_index, to);
								}
								dictionary2[prefix] = value;
								num4++;
							}
							while (num4 < (nint)languages.LongLength);
						}
						dictionary.Add(name, dictionary2);
						num3++;
						members2 = current.Members;
					}
					while (num3 < (nint)members2.LongLength);
				}
				EnumsTranslations.Add(current.EnumName, dictionary);
			}
			while (enumerator.MoveNext());
		}
		string text7 = Class16.smethod_0(1649075426);
		string gamePrefix = GamePrefix;
		string text8 = Class16.smethod_0(1648927580);
		string text9 = Class16.smethod_0(1648960967);
		File.WriteAllText(string.Concat(string.Concat(string.Concat(string.Concat(Application.StartupPath + text9, gamePrefix), text8), gamePrefix), text7), EnumsTranslations.ToJsonIndented());
		GC.KeepAlive(this);
	}

	public void LoadEnumsAndMasks()
	{
		Dictionary<string, Dictionary<string, string>> dictionary = null;
		Dictionary<string, string> dictionary2 = null;
		string text = null;
		List<EnumEntry> list = ParseEnumsFile();
		if (list == null)
		{
			return;
		}
		string text2 = Class16.smethod_0(1649075426);
		string gamePrefix = GamePrefix;
		string text3 = Class16.smethod_0(1648960527);
		string path = string.Concat(string.Concat(Application.StartupPath + text3, gamePrefix), text2);
		if (!File.Exists(path))
		{
			string text4 = Class16.smethod_0(1649075426);
			string gamePrefix2 = GamePrefix;
			string text5 = Class16.smethod_0(1648927580);
			string text6 = Class16.smethod_0(1648960967);
			path = string.Concat(string.Concat(string.Concat(string.Concat(Application.StartupPath + text6, gamePrefix2), text5), gamePrefix2), text4);
		}
		if (File.Exists(path))
		{
			string text7 = File.ReadAllText(path, Encoding.UTF8);
			EnumsTranslations = text7.FromJson<Dictionary<string, Dictionary<string, Dictionary<string, string>>>>();
		}
		EnumToStrId = new Dictionary<string, int>(list.Count);
		int num = 1;
		List<EnumEntry>.Enumerator enumerator = list.GetEnumerator();
		if (enumerator.MoveNext())
		{
			do
			{
				EnumEntry current = enumerator.Current;
				dictionary = null;
				EnumsTranslations?.TryGetValue(current.EnumName, out dictionary);
				VALUES_ARRAY_PAIR vALUES_ARRAY_PAIR = new VALUES_ARRAY_PAIR(current.Members.Length);
				int num2 = 0;
				EnumMember[] members = current.Members;
				if (0 < (nint)members.LongLength)
				{
					do
					{
						EnumMember enumMember = members[num2];
						string text8 = enumMember.Name;
						dictionary2 = null;
						if (dictionary != null && dictionary.TryGetValue(enumMember.Name, out dictionary2))
						{
							text = null;
							string key = ((LANG_INFO.CurrentLang == null) ? Class16.smethod_0(1648931959) : LANG_INFO.CurrentLang.Prefix);
							if (!dictionary2.TryGetValue(key, out text) || string.IsNullOrWhiteSpace(text))
							{
								dictionary2.TryGetValue(Class16.smethod_0(1648931959), out text);
							}
							if (!string.IsNullOrWhiteSpace(text))
							{
								text8 = text;
							}
						}
						vALUES_ARRAY_PAIR.decodedvalues[num2] = text8;
						ref decimal reference = ref vALUES_ARRAY_PAIR.realvalues[num2];
						reference = enumMember.Value;
						num2++;
						members = current.Members;
					}
					while (num2 < (nint)members.LongLength);
				}
				int num3 = (current.IsMask ? 200000 : 100000) + num;
				DecodedValues.AddValues(num3, vALUES_ARRAY_PAIR);
				if (!EnumToStrId.ContainsKey(current.EnumName))
				{
					EnumToStrId.Add(current.EnumName, num3);
				}
				else
				{
					EnumToStrId[current.EnumName] = num3;
				}
				if (!StrIdToEnum.ContainsKey(num3))
				{
					StrIdToEnum.Add(num3, current.EnumName);
				}
				else
				{
					StrIdToEnum[num3] = current.EnumName;
				}
				num++;
			}
			while (enumerator.MoveNext());
		}
		GC.KeepAlive(this);
	}

	public string GetListNameFullString(int int_0)
	{
		if (Lists != null && int_0 >= 0 && int_0 < Lists.Length)
		{
			ACE.Elements.eList.eList eList2 = Lists[int_0];
			string result = string.Format(Class16.smethod_0(1649075458), int_0, eList2.uListName, eList2.ListName);
			GC.KeepAlive(this);
			return result;
		}
		return string.Format(Class16.smethod_0(1649075452), int_0);
	}

	public void LoadGameLuaScriptsDb([MarshalAs(UnmanagedType.U1)] bool fromPck)
	{
		Class132 @class = new Class132();
		@class.eListCollection_0 = this;
		GAMES game = Game;
		if (game != GAMES.FW && game != GAMES.SW)
		{
			return;
		}
		@class.string_0 = null;
		switch (game)
		{
		case GAMES.SW:
			@class.string_0 = Class16.smethod_0(1649075508);
			break;
		case GAMES.FW:
			@class.string_0 = Class16.smethod_0(1649075480);
			break;
		}
		string text = null;
		if (fromPck)
		{
			string text2 = Class16.smethod_0(1648904996);
			byte[] fileB = PCKs.GetFileB(string.Concat(Class16.smethod_0(1649075524) + @class.string_0, text2));
			if (fileB != null)
			{
				if (fileB[0] == 27)
				{
					LoadGameLuaScriptsDb(fromPck: false);
				}
				else
				{
					text = Encoding.UTF8.GetString(fileB);
				}
			}
		}
		else
		{
			string text3 = ((LANG_INFO.CurrentLang == null) ? Class16.smethod_0(1648931959) : LANG_INFO.CurrentLang.Prefix);
			if (DatabaseLocaleResolver.TryFindFirstExistingByToken(@class.method_0, out var existingPath, out var _, text3))
			{
				text = File.ReadAllText(existingPath);
			}
			else
			{
				string text4 = string.Join(Class16.smethod_0(1648928028), DatabaseLocaleResolver.GetLookupTokens(text3));
				string message = Class16.smethod_0(1649075530) + @class.string_0 + Class16.smethod_0(1649075568) + GamePrefix + Class16.smethod_0(1648962386) + text3 + Class16.smethod_0(1648962414) + text4 + Class16.smethod_0(1648962424);
				string item = Class16.smethod_0(1649075587) + @class.string_0 + Class16.smethod_0(1648923968) + GamePrefix + Class16.smethod_0(1648923968) + text3;
				if (hashSet_0.Add(item))
				{
					SentryHelper.CaptureMessage(message, (SentryLevel)1, Class16.smethod_0(1648908340));
				}
			}
		}
		if (string.IsNullOrWhiteSpace(text))
		{
			GC.KeepAlive(this);
			return;
		}
		bool_0 = true;
		Dictionary<string, List<vFIELDPOS>>.Enumerator enumerator = dictionary_0.GetEnumerator();
		if (enumerator.MoveNext())
		{
			do
			{
				ValueType valueType = enumerator.Current;
				string key = ((KeyValuePair<string, List<vFIELDPOS>>)(object)valueType).Key;
				List<vFIELDPOS> value = ((KeyValuePair<string, List<vFIELDPOS>>)(object)valueType).Value;
				if (!AddEnumFromLua(text, key, bMask: false))
				{
					continue;
				}
				List<vFIELDPOS>.Enumerator enumerator2 = value.GetEnumerator();
				if (enumerator2.MoveNext())
				{
					do
					{
						vFIELDPOS current = enumerator2.Current;
						method_1(current.int_0, current.int_2, Class16.smethod_0(1648941518) + key, bool_1: false, (Enum9)7);
					}
					while (enumerator2.MoveNext());
				}
			}
			while (enumerator.MoveNext());
		}
		GC.KeepAlive(this);
	}

	private int method_38()
	{
		if (Elements2ListStartIndex >= 0 && Elements2ListCount > 0 && Elements2ListStartIndex <= ListCount)
		{
			return Elements2ListStartIndex;
		}
		return ListCount;
	}

	private static bool smethod_13(BinaryReader binaryReader_0, out Struct57 struct57_0, out long long_0)
	{
		struct57_0 = default(Struct57);
		long_0 = 0L;
		if (binaryReader_0 != null && binaryReader_0.BaseStream != null)
		{
			try
			{
				binaryReader_0.BaseStream.Position = 0L;
				struct57_0.int_0 = binaryReader_0.ReadUInt16();
				struct57_0.int_1 = binaryReader_0.ReadUInt16();
				struct57_0.uint_0 = ((struct57_0.int_0 > 7) ? binaryReader_0.ReadUInt32() : 0u);
				long_0 = binaryReader_0.BaseStream.Position;
				if (struct57_0.int_1 == 8192 && struct57_0.int_0 >= 262 && struct57_0.int_0 < 350)
				{
					int num = binaryReader_0.ReadInt32();
					if (num > 0)
					{
						binaryReader_0.ReadBytes(num);
					}
					long_0 = binaryReader_0.BaseStream.Position;
				}
				if (struct57_0.int_0 >= 350)
				{
					long position = binaryReader_0.BaseStream.Position;
					int num2 = binaryReader_0.ReadInt32();
					if (num2 > 0)
					{
						binaryReader_0.ReadBytes(num2);
					}
					binaryReader_0.ReadUInt32();
					int num3 = binaryReader_0.ReadInt32();
					if (num3 > 0)
					{
						binaryReader_0.ReadBytes(num3);
					}
					binaryReader_0.ReadUInt32();
					binaryReader_0.ReadUInt32();
					int num4 = binaryReader_0.ReadInt32();
					if (num4 > 0)
					{
						binaryReader_0.ReadBytes(num4);
					}
					binaryReader_0.BaseStream.Position = position;
					long_0 = position;
				}
				return true;
			}
			catch
			{
				return false;
			}
		}
		return false;
	}

	private bool method_39(Struct57 struct57_0)
	{
		if (struct57_0.int_0 == Version && struct57_0.int_1 == Signature)
		{
			return struct57_0.uint_0 == TimeStamp;
		}
		return false;
	}

	private bool method_40(string string_1, out eListCollection eListCollection_0)
	{
		eListCollection_0 = null;
		if (!string.IsNullOrEmpty(string_1) && File.Exists(string_1))
		{
			eListCollection_0 = new eListCollection(Game)
			{
				bOnlyConfig = true,
				Version = Version,
				Signature = Signature,
				TimeStamp = TimeStamp,
				RealTimeStamp = RealTimeStamp,
				GamePrefix = GamePrefix,
				domesticPW = domesticPW,
				ConfigFile = string_1,
				ConfigFile2 = string_1,
				ConfigPath = ConfigPath,
				OrgData = (OrgData ?? Array.Empty<byte>()),
				tag_name = tag_name,
				tag_info = tag_info,
				ComputerName = (ComputerName ?? Array.Empty<byte>()),
				ComputerTimestamp = ComputerTimestamp,
				HardInfo = (HardInfo ?? Array.Empty<byte>())
			};
			StreamReader streamReader = new StreamReader(string_1);
			try
			{
				eListCollection_0.LoadConfig(streamReader, null, null, null, null, bSetMainFieldsTypes: true);
			}
			finally
			{
				((IDisposable)streamReader).Dispose();
			}
			if (eListCollection_0.ConversationListIndex >= 0 && eListCollection_0.ConversationListIndex < eListCollection_0.ListCount)
			{
				eListCollection_0.ConversationListIndex = -1;
				eListCollection_0.FillListsArrays();
			}
			return true;
		}
		return false;
	}

	private void method_41(eListCollection eListCollection_0)
	{
		if (eListCollection_0 == null || eListCollection_0.Lists == null || eListCollection_0.Lists.Length == 0)
		{
			return;
		}
		int num = (Elements2ListStartIndex = Lists.Length);
		Elements2ListCount = eListCollection_0.Lists.Length;
		Array.Resize(ref Lists, num + eListCollection_0.Lists.Length);
		for (int i = 0; i < eListCollection_0.Lists.Length; i++)
		{
			int num2 = num + i;
			Lists[num2] = eListCollection_0.Lists[i];
			Lists[num2].ListIndex = num2;
			Lists[num2].Game = Game;
			if (Lists[num2].elementValues == null)
			{
				Lists[num2].elementValues = Array.Empty<object[]>();
			}
			Lists[num2].CreateFastDataTypes();
		}
		ListCount = Lists.Length;
		FillListsArrays();
		ResetCachedLists();
		for (int j = Elements2ListStartIndex; j < ListCount; j++)
		{
			Lists[j].bMatters = MattersListsFast != null && MattersListsFast.Contains(j);
		}
	}

	private void method_42()
	{
		if (!HasElements2Lists || string.IsNullOrWhiteSpace(GamePrefix))
		{
			return;
		}
		string path = System.IO.Path.Combine(Application.StartupPath, Class16.smethod_0(1649075606), GamePrefix, GamePrefix + Class16.smethod_0(1648960950));
		if (File.Exists(path))
		{
			ParseFieldTypes(new StreamReader(path), bUserTypes: false);
		}
		string text = System.IO.Path.Combine(Application.StartupPath, Class16.smethod_0(1648899207), GamePrefix + Class16.smethod_0(1648960244));
		if (File.Exists(text))
		{
			UserCustomTypesFN = text;
			ParseFieldTypes(File.OpenText(text), bUserTypes: true);
		}
		int num = Elements2ListStartIndex + Elements2ListCount;
		for (int i = Elements2ListStartIndex; i < num; i++)
		{
			if (i < 0 || i >= Lists.Length)
			{
				continue;
			}
			ACE.Elements.eList.eList eList2 = Lists[i];
			if (eList2 != null)
			{
				if (eList2.fieldtypes == null || eList2.fieldtypes.Length != eList2.elementFields.Length)
				{
					eList2.fieldtypes = new FIELDTYPE[(nint)eList2.elementFields.LongLength];
				}
				method_4(i, bool_1: true);
			}
		}
	}

	public ExportedDb GetDb([MarshalAs(UnmanagedType.U1)] bool skipZero)
	{
		List<ExportedList> list = new List<ExportedList>(ListCount);
		bool disableACEwatemark = CommonStorage.AParams.DisableACEwatemark;
		CommonStorage.AParams.DisableACEwatemark = true;
		int num = 0;
		int listCount = ListCount;
		if (0 < listCount)
		{
			do
			{
				progressHandler_0?.Invoke(num + 1, listCount);
				if (num != ConversationListIndex)
				{
					ExportedList dbList = GetDbList(num, skipZero);
					list.Add(dbList);
				}
				num++;
				listCount = ListCount;
			}
			while (num < listCount);
		}
		CommonStorage.AParams.DisableACEwatemark = disableACEwatemark;
		Dictionary<string, string> dictionary = new Dictionary<string, string>(ListCount);
		int num2 = 0;
		if (0 < ListCount)
		{
			do
			{
				ACE.Elements.eList.eList eList2 = Lists[num2];
				dictionary.Add(eList2.uListName, eList2.ListName);
				num2++;
			}
			while (num2 < ListCount);
		}
		ExportedDb result = new ExportedDb(list, dictionary);
		GC.KeepAlive(this);
		return result;
	}

	public unsafe ExportedList GetDbList(int int_0, [MarshalAs(UnmanagedType.U1)] bool skipZero)
	{
		Dictionary<int, List<ELEMENTS_REFERENCES_SUITE>> dictionary = null;
		object obj = null;
		string text = null;
		string text2 = null;
		List<REFERENCE_ENTRY> list = null;
		string text3 = null;
		DESC_EX dESC_EX = null;
		ACE.Elements.eList.eList eList2 = Lists[int_0];
		List<ExportedItem> list2 = new List<ExportedItem>(eList2.ItemCount);
		int num = 0;
		string[] extraField;
		string parsedItemName;
		string areaName;
		int num6;
		bool flag;
		if (0 < eList2.ItemCount)
		{
			int num4 = default(int);
			FIELDTYPE fIELDTYPE = default(FIELDTYPE);
			ACE.Classes.ITEMDATA data = default(ACE.Classes.ITEMDATA);
			do
			{
				int num2 = Lists[int_0].getid(num);
				GC.KeepAlive(this);
				Dictionary<string, object[]> dictionary2 = new Dictionary<string, object[]>();
				Dictionary<string, object[]> dictionary3 = null;
				int num3 = 1;
				if (1 < (nint)eList2.elementTypes.LongLength)
				{
					do
					{
						if (num3 != Lists[int_0].NameFieldIndex)
						{
							object[] valueAndDecoded = GetValueAndDecoded(int_0, num, num3, skipZero);
							if (valueAndDecoded != null)
							{
								ref string reference = ref eList2.elementFields[num3];
								if (!dictionary2.ContainsKey(reference))
								{
									dictionary2.Add(reference, valueAndDecoded);
								}
								else
								{
									string text4 = Class16.smethod_0(1648894358);
									Console.WriteLine(string.Concat(Class16.smethod_0(1649075620) + reference, text4));
								}
							}
						}
						num3++;
					}
					while (num3 < (nint)eList2.elementTypes.LongLength);
				}
				List<ExportedItemUsage.Elements> list3 = new List<ExportedItemUsage.Elements>();
				List<ExportedItemUsage.Shop> list4 = new List<ExportedItemUsage.Shop>();
				List<ExportedItemUsage.Shop> list5 = new List<ExportedItemUsage.Shop>();
				List<ExportedItemUsage.Shop> list6 = new List<ExportedItemUsage.Shop>();
				List<ExportedItemUsage.Npcgen> list7 = new List<ExportedItemUsage.Npcgen>();
				List<ExportedItemUsage.Tasks> list8 = new List<ExportedItemUsage.Tasks>();
				List<ExportedItemUsage.ExtraDrops> list9 = new List<ExportedItemUsage.ExtraDrops>();
				List<ExportedItem.Monster.DropItem> list10 = null;
				List<ExportedItemUsage.Shop> list11 = new List<ExportedItemUsage.Shop>();
				dictionary = null;
				num3 = GetReferences(ref dictionary, int_0, new List<int>(new int[1] { num2 }));
				Dictionary<int, List<ELEMENTS_REFERENCES_SUITE>>.Enumerator enumerator = dictionary.GetEnumerator();
				if (enumerator.MoveNext())
				{
					do
					{
						ValueType valueType = enumerator.Current;
						KeyValuePair<int, List<ELEMENTS_REFERENCES_SUITE>> keyValuePair = (KeyValuePair<int, List<ELEMENTS_REFERENCES_SUITE>>)(object)valueType;
						List<ELEMENTS_REFERENCES_SUITE> value = ((KeyValuePair<int, List<ELEMENTS_REFERENCES_SUITE>>)(object)valueType).Value;
						ELEMENTS_REFERENCES_SUITE eLEMENTS_REFERENCES_SUITE = value[0];
						List<ELEMENTS_REFERENCES_SUITE>.Enumerator enumerator2 = value.GetEnumerator();
						if (enumerator2.MoveNext())
						{
							do
							{
								_ = enumerator2.Current.Count;
							}
							while (enumerator2.MoveNext());
						}
						switch (eLEMENTS_REFERENCES_SUITE.RefType.DataFileType)
						{
						case DATA_FILES_ENUM.ELEMENTS:
						{
							List<ExportedItemUsage.Elements.UsageEntry> list16 = new List<ExportedItemUsage.Elements.UsageEntry>(eLEMENTS_REFERENCES_SUITE.refs.Count);
							List<REFERENCE_ENTRY>.Enumerator enumerator7 = eLEMENTS_REFERENCES_SUITE.refs.GetEnumerator();
							if (enumerator7.MoveNext())
							{
								do
								{
									REFERENCE_ENTRY current5 = enumerator7.Current;
									obj = null;
									text = null;
									text2 = null;
									TryGetRefExtraVal(current5.FieldPos, ref obj, ref text2, ref text, &num4, &fIELDTYPE);
									int int_1 = current5.FieldPos.int_1;
									Color itemColor = GetItemColor(current5.FieldPos.int_0, int_1);
									string[] array2 = new string[2];
									int_1 = current5.FieldPos.int_2;
									int int_2 = current5.FieldPos.int_0;
									array2[0] = Lists[int_2].elementFields[int_1];
									int_2 = current5.FieldPos.int_2;
									int_1 = current5.FieldPos.int_0;
									string text5 = ACE.RSGlobal.RSGlobal.WithCapitalLetter(NamesConverter.RemoveIndices(GetFieldName(int_1, int_2)));
									GC.KeepAlive(this);
									array2[1] = text5;
									extraField = ((num4 <= -1) ? null : new string[2]);
									if (num4 > -1)
									{
										int_2 = num4;
										int_1 = current5.FieldPos.int_0;
										array2[0] = Lists[int_1].elementFields[int_2];
										array2[1] = text;
									}
									object[] extraVal = ((obj == null) ? null : smethod_0(obj, text2));
									Color white = Color.White;
									text5 = ((!(itemColor != white)) ? null : ACE.RSGlobal.RSGlobal.Color2HTML(itemColor));
									int_2 = current5.FieldPos.int_1;
									int_1 = current5.FieldPos.int_0;
									areaName = GetParsedItemName(int_1, int_2, bRealAddonName: true);
									list16.Add(new ExportedItemUsage.Elements.UsageEntry(current5.id, areaName, text5, array2, extraField, extraVal));
								}
								while (enumerator7.MoveNext());
							}
							ACE.Elements.eList.eList eList3 = Lists[eLEMENTS_REFERENCES_SUITE.ListIndex];
							ACE.Elements.eList.eList eList4 = eList3;
							list3.Add(new ExportedItemUsage.Elements(caption: (!ACE.RSGlobal.RSGlobal.SHOW_UNIVERSAL_NAMES) ? eList4.ListName : eList4.uListName, type: eLEMENTS_REFERENCES_SUITE.RefType.SectionType, listName: eList3.uListName, entries: list16));
							break;
						}
						case DATA_FILES_ENUM.TASKS:
						{
							List<ExportedItemUsage.Tasks.UsageEntry> list17 = new List<ExportedItemUsage.Tasks.UsageEntry>(eLEMENTS_REFERENCES_SUITE.refs.Count);
							List<REFERENCE_ENTRY>.Enumerator enumerator8 = eLEMENTS_REFERENCES_SUITE.refs.GetEnumerator();
							if (enumerator8.MoveNext())
							{
								do
								{
									REFERENCE_ENTRY current6 = enumerator8.Current;
									QUEST_INFO qUEST_INFO = (QUEST_INFO)current6.oSpecial;
									if (current6.IsValuePresented(2))
									{
										float? prob = (float)current6.extra_value2;
										Color white2 = Color.White;
										list17.Add(new ExportedItemUsage.Tasks.UsageEntry(color: (!(qUEST_INFO.color != white2)) ? null : ACE.RSGlobal.RSGlobal.Color2HTML(qUEST_INFO.color), id: qUEST_INFO.id, name: qUEST_INFO.name, image: qUEST_INFO.ImageIndex, count: (int)current6.extra_value1, prob: prob));
									}
									else if (current6.IsValuePresented(1))
									{
										Color white3 = Color.White;
										list17.Add(new ExportedItemUsage.Tasks.UsageEntry(color: (!(qUEST_INFO.color != white3)) ? null : ACE.RSGlobal.RSGlobal.Color2HTML(qUEST_INFO.color), id: qUEST_INFO.id, name: qUEST_INFO.name, image: qUEST_INFO.ImageIndex, count: (int)current6.extra_value1));
									}
									else
									{
										Color white4 = Color.White;
										list17.Add(new ExportedItemUsage.Tasks.UsageEntry(color: (!(qUEST_INFO.color != white4)) ? null : ACE.RSGlobal.RSGlobal.Color2HTML(qUEST_INFO.color), id: qUEST_INFO.id, name: qUEST_INFO.name, image: qUEST_INFO.ImageIndex));
									}
								}
								while (enumerator8.MoveNext());
							}
							ReferenceSubType subType2 = eLEMENTS_REFERENCES_SUITE.RefType.SubType;
							ReferenceType sectionType2 = eLEMENTS_REFERENCES_SUITE.RefType.SectionType;
							list8.Add(new ExportedItemUsage.Tasks(eLEMENTS_REFERENCES_SUITE.GetRefCaption(), sectionType2, subType2, list17));
							break;
						}
						case DATA_FILES_ENUM.NPCGEN:
						{
							Dictionary<string, List<REFERENCE_ENTRY>> dictionary4 = new Dictionary<string, List<REFERENCE_ENTRY>>();
							int param = eLEMENTS_REFERENCES_SUITE.RefType.param1;
							List<REFERENCE_ENTRY>.Enumerator enumerator4 = eLEMENTS_REFERENCES_SUITE.refs.GetEnumerator();
							if (enumerator4.MoveNext())
							{
								do
								{
									REFERENCE_ENTRY current2 = enumerator4.Current;
									areaName = NpcGenList.GetAreaName(param, eLEMENTS_REFERENCES_SUITE.RefType.param2, current2);
									list = null;
									if (!dictionary4.TryGetValue(areaName, out list))
									{
										list = new List<REFERENCE_ENTRY>();
										dictionary4.Add(areaName, list);
									}
									list.Add(current2);
								}
								while (enumerator4.MoveNext());
							}
							List<ExportedItemUsage.Npcgen.Area> list14 = new List<ExportedItemUsage.Npcgen.Area>();
							Dictionary<string, List<REFERENCE_ENTRY>>.Enumerator enumerator5 = dictionary4.GetEnumerator();
							if (enumerator5.MoveNext())
							{
								do
								{
									KeyValuePair<string, List<REFERENCE_ENTRY>> current3 = enumerator5.Current;
									List<ExportedItemUsage.Npcgen.Area.UsageEntry> list15 = new List<ExportedItemUsage.Npcgen.Area.UsageEntry>();
									List<REFERENCE_ENTRY>.Enumerator enumerator6 = current3.Value.GetEnumerator();
									if (enumerator6.MoveNext())
									{
										do
										{
											REFERENCE_ENTRY current4 = enumerator6.Current;
											float[] array = (float[])current4.oSpecial;
											int respawnSec = (current4.IsValuePresented(2) ? ((int)current4.extra_value2) : 0);
											byte b = ((eLEMENTS_REFERENCES_SUITE.RefType.SectionType == ReferenceType.NPCGEN_NPCS) ? ((byte)1) : ((byte)0));
											list15.Add(new ExportedItemUsage.Npcgen.Area.UsageEntry(b != 0, (int)current4.extra_value1, respawnSec, array[0], array[1], array[2]));
										}
										while (enumerator6.MoveNext());
									}
									ExportedItemUsage.Npcgen.Area item = new ExportedItemUsage.Npcgen.Area(current3.Key, list15);
									list14.Add(item);
								}
								while (enumerator5.MoveNext());
							}
							list7.Add(new ExportedItemUsage.Npcgen(NPCGEN_LIST.GetInstanceName(param), INSTANCE_LIST.GetClientTagByID(param), param, list14));
							break;
						}
						case DATA_FILES_ENUM.EXTRA_DROPS:
						{
							if (eLEMENTS_REFERENCES_SUITE.RefType.SectionType == ReferenceType.EXTRA_DROPS_MONSTERS)
							{
								list10 = new List<ExportedItem.Monster.DropItem>();
							}
							List<ExportedItemUsage.ExtraDrops.UsageEntry> list18 = new List<ExportedItemUsage.ExtraDrops.UsageEntry>(eLEMENTS_REFERENCES_SUITE.refs.Count);
							List<REFERENCE_ENTRY>.Enumerator enumerator9 = eLEMENTS_REFERENCES_SUITE.refs.GetEnumerator();
							if (enumerator9.MoveNext())
							{
								do
								{
									REFERENCE_ENTRY current7 = enumerator9.Current;
									EXTRADROPTABLE eXTRADROPTABLE = (EXTRADROPTABLE)current7.oSpecial;
									if (eLEMENTS_REFERENCES_SUITE.RefType.SectionType == ReferenceType.EXTRA_DROPS_MONSTERS)
									{
										List<DROP_ITEMS>.Enumerator enumerator10 = eXTRADROPTABLE.SortedDrop.GetEnumerator();
										if (!enumerator10.MoveNext())
										{
											continue;
										}
										do
										{
											DROP_ITEMS current8 = enumerator10.Current;
											int id = current8.id;
											if (id <= 0)
											{
												continue;
											}
											float probability = current8.probability;
											if (probability > 0f)
											{
												ITEMPOS iTEMPOS = FindItemPos(MattersLists, id);
												if (iTEMPOS != null)
												{
													Color itemColor2 = GetItemColor(int_0, num);
													Color white5 = Color.White;
													list10.Add(new ExportedItem.Monster.DropItem(color: (!(itemColor2 != white5)) ? null : ACE.RSGlobal.RSGlobal.Color2HTML(itemColor2), id: id, name: GetParsedItemName(iTEMPOS), prob: probability));
												}
											}
										}
										while (enumerator10.MoveNext());
										continue;
									}
									List<int>.Enumerator enumerator11 = eXTRADROPTABLE.id_monsters.GetEnumerator();
									if (!enumerator11.MoveNext())
									{
										continue;
									}
									do
									{
										int current9 = enumerator11.Current;
										if (current9 > 0)
										{
											int num5 = this.get_LI(Class16.smethod_0(1648963546));
											object obj2 = null;
											num6 = FindItemIndexByID(num5, current9);
											if (num6 > -1)
											{
												obj2 = new ITEMPOS(num5, num6);
											}
											if (obj2 != null)
											{
												list18.Add(new ExportedItemUsage.ExtraDrops.UsageEntry(current9, (float)current7.extra_value1));
											}
										}
									}
									while (enumerator11.MoveNext());
								}
								while (enumerator9.MoveNext());
							}
							if (eLEMENTS_REFERENCES_SUITE.RefType.SectionType == ReferenceType.EXTRA_DROPS_MATTERS)
							{
								list9.Add(new ExportedItemUsage.ExtraDrops(eLEMENTS_REFERENCES_SUITE.GetRefCaption(), list18));
							}
							break;
						}
						case DATA_FILES_ENUM.GSHOP:
						case DATA_FILES_ENUM.GSHOP1:
						case DATA_FILES_ENUM.GSHOP2:
						case DATA_FILES_ENUM.GSHOP3:
						{
							List<ExportedItemUsage.Shop.UsageEntry> list12 = new List<ExportedItemUsage.Shop.UsageEntry>(eLEMENTS_REFERENCES_SUITE.refs.Count);
							List<REFERENCE_ENTRY>.Enumerator enumerator3 = eLEMENTS_REFERENCES_SUITE.refs.GetEnumerator();
							if (enumerator3.MoveNext())
							{
								do
								{
									REFERENCE_ENTRY current = enumerator3.Current;
									if (current.IsValuePresented(2))
									{
										list12.Add(new ExportedItemUsage.Shop.UsageEntry(price: (double)current.extra_value2, id: current.id, name: current.Name, count: (int)current.extra_value1));
									}
									else
									{
										list12.Add(new ExportedItemUsage.Shop.UsageEntry(count: (!current.IsValuePresented(1)) ? 1 : ((int)current.extra_value1), id: current.id, name: current.Name));
									}
								}
								while (enumerator3.MoveNext());
							}
							List<ExportedItemUsage.Shop> list13 = list4;
							switch (eLEMENTS_REFERENCES_SUITE.RefType.DataFileType)
							{
							case DATA_FILES_ENUM.GSHOP3:
								list13 = list11;
								break;
							case DATA_FILES_ENUM.GSHOP2:
								list13 = list6;
								break;
							case DATA_FILES_ENUM.GSHOP1:
								list13 = list5;
								break;
							}
							ReferenceSubType subType = eLEMENTS_REFERENCES_SUITE.RefType.SubType;
							ReferenceType sectionType = eLEMENTS_REFERENCES_SUITE.RefType.SectionType;
							list13.Add(new ExportedItemUsage.Shop(eLEMENTS_REFERENCES_SUITE.GetRefCaption(), sectionType, subType, list12));
							break;
						}
						}
					}
					while (enumerator.MoveNext());
				}
				areaName = null;
				ExportedItemUsages usages = new ExportedItemUsages(num3, list3, list4, list5, list6, list7, list8, list9);
				flag = MattersListsFast != null && MattersListsFast.Contains(int_0);
				GC.KeepAlive(this);
				if (flag)
				{
					ACE.RSGlobal.RSGlobal.ITEMDATA(&data);
					ITEMPOS itemPos = new ITEMPOS(int_0, num);
					text3 = null;
					GenerateXML(itemPos, 1, string.Empty, &data, ref text3);
					dESC_EX = new DESC_EX(bBuild: true);
					areaName = GenerateHTMLPreview(itemPos, data, string.Empty, IsShopPrice: false, IsCleanHtml: true, bUnlimited: false, bViewIcon: false, ref dESC_EX);
					if (Game == GAMES.PW && eList2.uListName == Class16.smethod_0(1648923245))
					{
						dictionary3 = new Dictionary<string, object[]>();
						float num7 = System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, float>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(44)));
						dictionary3.Add(Class16.smethod_0(1649075650), smethod_0(System.Runtime.CompilerServices.Unsafe.As<ACE.Classes.ITEMDATA, float>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset<ACE.Classes.ITEMDATA>(ref data, new IntPtr(44))), num7.ToString(Class16.smethod_0(1648922976))));
					}
				}
				Color itemColor3 = GetItemColor(int_0, num);
				int? typeIdOrNull = GetTypeIdOrNull(int_0, num);
				int? subTypeIdOrNull = GetSubTypeIdOrNull(int_0, num);
				ExportedItem item2;
				if (int_0 == this.get_LI(Class16.smethod_0(1648963546)))
				{
					Color white6 = Color.White;
					string color = ((!(itemColor3 != white6)) ? null : ACE.RSGlobal.RSGlobal.Color2HTML(itemColor3));
					parsedItemName = GetParsedItemName(int_0, num, bRealAddonName: true);
					item2 = new ExportedItem.Monster(num2, parsedItemName, color, typeIdOrNull.Value, dictionary2, areaName, usages, list10);
				}
				else
				{
					Color white7 = Color.White;
					parsedItemName = ((!(itemColor3 != white7)) ? null : ACE.RSGlobal.RSGlobal.Color2HTML(itemColor3));
					string parsedItemName2 = GetParsedItemName(int_0, num, bRealAddonName: true);
					item2 = new ExportedItem(num2, parsedItemName2, parsedItemName, GetItemDesc(num2), typeIdOrNull, subTypeIdOrNull, dictionary2, dictionary3, areaName, usages);
				}
				list2.Add(item2);
				num++;
			}
			while (num < eList2.ItemCount);
		}
		Dictionary<string, string> dictionary5 = new Dictionary<string, string>(eList2.elementTypes.Length);
		num6 = 0;
		extraField = eList2.elementFields;
		if (0 < (nint)extraField.LongLength)
		{
			do
			{
				if (!dictionary5.ContainsKey(extraField[num6]))
				{
					bool bTranslationExist = false;
					parsedItemName = eList2.GetFieldName(num6, ref bTranslationExist);
					dictionary5.Add(eList2.elementFields[num6], parsedItemName);
				}
				num6++;
				extraField = eList2.elementFields;
			}
			while (num6 < (nint)extraField.LongLength);
		}
		parsedItemName = null;
		areaName = null;
		num6 = eList2.TypeFieldIndex;
		if (num6 > 0)
		{
			Dictionary<int, int[]> fieldsBindedLists = eList2.FieldsBindedLists;
			if (fieldsBindedLists != null)
			{
				num6 = fieldsBindedLists[num6][0];
				parsedItemName = Lists[num6].uListName;
			}
		}
		num6 = eList2.SubTypeFieldIndex;
		if (num6 > 0)
		{
			num6 = eList2.FieldsBindedLists[num6][0];
			areaName = Lists[num6].uListName;
		}
		flag = MattersListsFast != null && MattersListsFast.Contains(int_0);
		GC.KeepAlive(this);
		return new ExportedList(eList2.uListName, int_0, flag, parsedItemName, areaName, list2, dictionary5);
	}

	public object[] GetValueAndDecoded(int int_0, int int_1, int int_2, [MarshalAs(UnmanagedType.U1)] bool returnNullIfZero)
	{
		string text = DecodeValue(int_0, int_2, int_1, GetValue(int_0, int_1, int_2));
		ref FIELD_DATA_TYPE_ENUM data_type = ref Lists[int_0].FieldDataTypes[int_2].data_type;
		int num = (int)data_type;
		if (num == 9 || num == 8 || GetFieldType(int_0, int_1, int_2) == FIELDTYPE.ft_hex_color)
		{
			return new object[1] { text };
		}
		object object_;
		switch ((int)data_type)
		{
		case 6:
		{
			float valueF = Lists[int_0].GetValueF(int_1, int_2);
			GC.KeepAlive(this);
			if (valueF == 0f && returnNullIfZero)
			{
				return null;
			}
			object_ = valueF;
			break;
		}
		default:
			object_ = GetValueO(int_0, int_1, int_2, bConvertString: false, bConvertShopPrice: false, bConvertHexColor: false, bConvertFloatAddon: false);
			break;
		case 1:
		{
			int valueIFast = Lists[int_0].GetValueIFast(int_1, int_2);
			GC.KeepAlive(this);
			if (valueIFast == 0 && returnNullIfZero)
			{
				return null;
			}
			object_ = valueIFast;
			break;
		}
		}
		object[] result = smethod_0(object_, text);
		GC.KeepAlive(this);
		return result;
	}

	private void method_43()
	{
		if (TranslatedFieldsGlobal == null || string.IsNullOrWhiteSpace(GamePrefix))
		{
			return;
		}
		string prefixOrCode = ((LANG_INFO.CurrentLang == null) ? Class16.smethod_0(1648931959) : LANG_INFO.CurrentLang.Prefix);
		string text = LocalizationBridge.ResolveLocaleCodeFromLegacyPrefix(prefixOrCode);
		string string_ = System.IO.Path.Combine(Application.StartupPath, Class16.smethod_0(1648899196), text, Class16.smethod_0(1648906367), GamePrefix + Class16.smethod_0(1648899122));
		string string_2 = System.IO.Path.Combine(Application.StartupPath, Class16.smethod_0(1648899207), Class16.smethod_0(1648899196), text, Class16.smethod_0(1648906367), GamePrefix + Class16.smethod_0(1648899122));
		Dictionary<string, string> dictionary = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
		smethod_14(dictionary, string_);
		smethod_14(dictionary, string_2);
		if (dictionary.Count == 0)
		{
			return;
		}
		StringBuilder stringBuilder = new StringBuilder();
		string b = null;
		foreach (KeyValuePair<string, string> item in dictionary.OrderBy(Class131.class131_0.method_0, StringComparer.OrdinalIgnoreCase))
		{
			if (string.IsNullOrWhiteSpace(item.Key))
			{
				continue;
			}
			string key = item.Key;
			string value = item.Value ?? string.Empty;
			if (key.StartsWith(Class16.smethod_0(1649078580)))
			{
				b = null;
				stringBuilder.Append(key);
				stringBuilder.Append(';');
				stringBuilder.AppendLine(value);
				continue;
			}
			string text2 = null;
			string value2 = key;
			int num = key.IndexOf(Class16.smethod_0(1649008377), StringComparison.Ordinal);
			if (num > 0)
			{
				text2 = key.Substring(0, num);
				value2 = key.Substring(num + 2);
			}
			if (!string.IsNullOrWhiteSpace(text2) && !string.Equals(text2, b, StringComparison.Ordinal))
			{
				stringBuilder.Append('#');
				stringBuilder.AppendLine(text2);
				b = text2;
			}
			stringBuilder.Append(value2);
			stringBuilder.Append(';');
			stringBuilder.AppendLine(value);
		}
		if (stringBuilder.Length == 0)
		{
			return;
		}
		MemoryStream memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(stringBuilder.ToString()));
		try
		{
			StreamReader streamReader = new StreamReader(memoryStream, Encoding.UTF8);
			try
			{
				ParseFieldLang(streamReader, bCheckExistence: true);
			}
			finally
			{
				((IDisposable)streamReader).Dispose();
			}
		}
		finally
		{
			((IDisposable)memoryStream).Dispose();
		}
	}

	private static void smethod_14(Dictionary<string, string> dictionary_1, string string_1)
	{
		if (!File.Exists(string_1))
		{
			return;
		}
		try
		{
			JObject val = JObject.Parse(File.ReadAllText(string_1, Encoding.UTF8));
			JToken obj = val[Class16.smethod_0(1648899827)];
			JObject val2 = (JObject)(((object)((obj is JObject) ? obj : null)) ?? ((object)val));
			using IEnumerator<JProperty> enumerator = val2.Properties().GetEnumerator();
			string name;
			object obj2;
			for (; enumerator.MoveNext(); dictionary_1[name] = (string)obj2)
			{
				JProperty current = enumerator.Current;
				name = current.Name;
				JToken value = current.Value;
				if (value == null)
				{
					obj2 = null;
				}
				else
				{
					obj2 = ((object)value).ToString();
					if (obj2 != null)
					{
						continue;
					}
				}
				obj2 = string.Empty;
			}
		}
		catch
		{
		}
	}

	private void method_44()
	{
		List<string> list = new List<string>(TextStorage.TEXTS.GetTextsByPrefix(Class16.smethod_0(1649075677)) ?? Array.Empty<string>());
		string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1648952014));
		list.Insert(0, text);
		List<decimal> list2 = new List<decimal>(list.Count);
		foreach (int item2 in Enumerable.Range(-1, list.Count))
		{
			decimal item = item2;
			list2.Add(item);
		}
		DecodedValues.AddValues(FIELDTYPE.occupation, list.ToArray(), list2.ToArray());
	}

	private static int smethod_15(string string_1)
	{
		if (string.IsNullOrWhiteSpace(string_1))
		{
			return -1;
		}
		Match match = Regex.Match(System.IO.Path.GetFileName(string_1), Class16.smethod_0(1649075689), RegexOptions.IgnoreCase);
		if (!match.Success)
		{
			return -1;
		}
		if (!int.TryParse(match.Groups[Class16.smethod_0(1649074689)].Value, out var result))
		{
			return -1;
		}
		return result;
	}

	private string method_45(string string_1, int int_0)
	{
		Class130 CS_0024_003C_003E8__locals3 = new Class130();
		CS_0024_003C_003E8__locals3.int_0 = int_0;
		if (!Directory.Exists(string_1))
		{
			return null;
		}
		string searchPattern = (domesticPW ? (GamePrefix + Class16.smethod_0(1649074720)) : (GamePrefix + Class16.smethod_0(1649074711)));
		string[] files = Directory.GetFiles(string_1, searchPattern);
		if (files != null && files.Length != 0)
		{
			return (from text in files
				select _003C_003Ef__AnonymousType1.Create(
					text,
					smethod_15(text)
				) into _003C_003Ef__AnonymousType1_0
				where _003C_003Ef__AnonymousType1_0.Version > 0
				orderby Math.Abs(_003C_003Ef__AnonymousType1_0.Version - CS_0024_003C_003E8__locals3.int_0), (_003C_003Ef__AnonymousType1_0.Version >= CS_0024_003C_003E8__locals3.int_0) ? 1 : 0
				select _003C_003Ef__AnonymousType1_0.File).FirstOrDefault();
		}
		return null;
	}

	public string FindConfig()
	{
		int num = Version;
		string text3;
		if (Game != GAMES.Chibi)
		{
			string text = Class16.smethod_0(1649074749);
			string gamePrefix = GamePrefix;
			string text2 = Class16.smethod_0(1648960967);
			text3 = string.Concat(string.Concat(Application.StartupPath + text2, gamePrefix), text);
		}
		else
		{
			string text4 = ((LANG_INFO.CurrentLang == null) ? Class16.smethod_0(1648931959) : LANG_INFO.CurrentLang.Prefix);
			string text5 = Class16.smethod_0(1648960967);
			text3 = string.Concat(Application.StartupPath + text5, text4);
		}
		// TODO(recovered): the per-game config schema folder (StartupPath\Configs\<prefix>\configs\)
		// may be absent from this deployment; Directory.GetFiles on a missing folder throws
		// DirectoryNotFoundException and aborts LoadElements. Match FindConfig2's behaviour and
		// return null (caller treats it as "config not found") instead of hard-crashing.
		if (!Directory.Exists(text3))
		{
			return null;
		}
		string text6 = Class16.smethod_0(1649074765);
		uint timeStamp = TimeStamp;
		string text7 = Class16.smethod_0(1648923968);
		string[] array = Directory.GetFiles(text3, string.Concat(string.Concat(string.Concat(string.Concat(GamePrefix + Class16.smethod_0(1648951736), num), text7), timeStamp), text6));
		if (array == null || array.Length == 0)
		{
			num = Version;
			if (num > 0)
			{
				do
				{
					if (domesticPW)
					{
						string text8 = Class16.smethod_0(1649074765);
						array = Directory.GetFiles(text3, string.Concat(string.Concat(GamePrefix + Class16.smethod_0(1648951761), num), text8));
					}
					else
					{
						string text9 = Class16.smethod_0(1649074765);
						array = Directory.GetFiles(text3, string.Concat(string.Concat(GamePrefix + Class16.smethod_0(1648951736), num), text9));
					}
					if ((nint)array.LongLength > 0)
					{
						break;
					}
					num--;
				}
				while (num > 0);
			}
		}
		if ((array == null || array.Length == 0) && Version > 0)
		{
			string text10 = method_45(text3, Version);
			if (!string.IsNullOrEmpty(text10))
			{
				array = new string[1] { text10 };
				num = smethod_15(text10);
			}
		}
		int num2 = ((num != Version) ? 1 : 0);
		unkVersion = (byte)num2 != 0;
		if (array != null && array.Length != 0)
		{
			return array[0];
		}
		return null;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsProbField(int int_0, int int_1)
	{
		if (int_0 >= 0 && Lists != null && int_0 < Lists.Length && Lists[int_0] != null && int_1 >= 0)
		{
			if (Lists[int_0].fieldtypes != null && int_1 < Lists[int_0].fieldtypes.Length && Lists[int_0].FieldDataTypes != null && int_1 < Lists[int_0].FieldDataTypes.Length)
			{
				if (int_0 == ConversationListIndex)
				{
					return false;
				}
				bool flag;
				bool result = (flag = GetFieldType(int_0, int_1) == FIELDTYPE.ft_prob);
				if (!flag)
				{
					ACE.Elements.eList.eList eList2 = Lists[int_0];
					if (eList2.FieldDataTypes[int_1].data_type == FIELD_DATA_TYPE_ENUM.Float)
					{
						if (eList2.elementFields == null || int_1 >= eList2.elementFields.Length || eList2.elementFields[int_1] == null)
						{
							return false;
						}
						ref string reference = ref eList2.elementFields[int_1];
						int num = ((reference.Contains(Class16.smethod_0(1649074770)) || reference.Contains(Class16.smethod_0(1649074789)) || reference.Contains(Class16.smethod_0(1649074794)) || reference.Contains(Class16.smethod_0(1649074814)) || reference.StartsWith(Class16.smethod_0(1649074818))) ? 1 : 0);
						result = (byte)num != 0;
					}
				}
				GC.KeepAlive(this);
				return result;
			}
			return false;
		}
		return false;
	}

	public bool TryLoadElements2(string elements2Path = null)
	{
		if (HasElements2Lists)
		{
			return true;
		}
		Elements2ListStartIndex = -1;
		Elements2ListCount = 0;
		Elements2FileName = null;
		string text = FindConfig2();
		if (!string.IsNullOrEmpty(text) && File.Exists(text))
		{
			ConfigFile2 = text;
			string directoryName = System.IO.Path.GetDirectoryName(FileName);
			if (string.IsNullOrEmpty(elements2Path))
			{
				if (string.IsNullOrEmpty(directoryName))
				{
					return false;
				}
				elements2Path = System.IO.Path.Combine(directoryName, Class16.smethod_0(1649074838));
			}
			if (!File.Exists(elements2Path))
			{
				return false;
			}
			try
			{
				using FileStream fileStream = File.OpenRead(elements2Path);
				BinaryReader binaryReader = new BinaryReader(fileStream);
				try
				{
					if (!smethod_13(binaryReader, out var struct57_, out var long_))
					{
						return false;
					}
					if (!method_39(struct57_))
					{
						return false;
					}
					if (!method_40(text, out var eListCollection_))
					{
						return false;
					}
					binaryReader.BaseStream.Position = long_;
					BinaryReader br = binaryReader;
					FileStream fs = fileStream;
					bool flag = false;
					if (ACE.Elements.eList.eList.IsElementsPacked(Game, Version))
					{
						eListCollection_.isPacked = true;
						ACE.Elements.eList.eList[] lists = eListCollection_.Lists;
						int num = ((lists != null) ? lists.Length : 0);
						br = UnpackElements(ref fs, ref br, Game, Version, ref eListCollection_.Lists, ref eListCollection_.ConversationListIndex, eListCollection_.unkVersion, eListCollection_.first2IDs);
						flag = br != null && br != binaryReader;
						if (eListCollection_.Lists != null && num != eListCollection_.Lists.Length)
						{
							eListCollection_.ListCount = eListCollection_.Lists.Length;
							eListCollection_.FillListsArrays();
						}
					}
					if (br == null)
					{
						return false;
					}
					try
					{
						eListCollection_.ReadKnownVersionElements2(br, isFirstItems: false);
					}
					finally
					{
						if (flag)
						{
							br?.Close();
						}
					}
					method_41(eListCollection_);
					method_42();
					Elements2FileName = elements2Path;
					return Elements2ListCount > 0;
				}
				finally
				{
					((IDisposable)binaryReader).Dispose();
				}
			}
			catch (Exception ex)
			{
				SentryHelper.CaptureMessage(Class16.smethod_0(1649074851) + ex.GetType().Name + Class16.smethod_0(1648908709) + ex.Message, (SentryLevel)2, Class16.smethod_0(1649074881));
				return false;
			}
		}
		return false;
	}

	private bool method_46()
	{
		if (!HasElements2Lists)
		{
			return false;
		}
		int num = Elements2ListStartIndex + Elements2ListCount;
		int num2 = Elements2ListStartIndex;
		while (true)
		{
			if (num2 < num)
			{
				if (num2 != ConversationListIndex)
				{
					ACE.Elements.eList.eList eList2 = Lists[num2];
					if (eList2 != null && string.Equals(eList2.uListName, Class16.smethod_0(1648987478), StringComparison.OrdinalIgnoreCase))
					{
						break;
					}
					num2++;
					continue;
				}
				return false;
			}
			return true;
		}
		return false;
	}

	public bool SaveElements2(string elements2Path)
	{
		if (string.IsNullOrWhiteSpace(elements2Path))
		{
			return false;
		}
		string value = CommonStorage.AParams?.Cfg2DefaultPath;
		bool flag = !string.IsNullOrWhiteSpace(value);
		string text = null;
		if (!flag && !string.IsNullOrEmpty(ConfigFile2) && File.Exists(ConfigFile2))
		{
			text = ConfigFile2;
		}
		if (string.IsNullOrEmpty(text))
		{
			text = FindConfig2();
		}
		if (!string.IsNullOrEmpty(text) && File.Exists(text))
		{
			ConfigFile2 = text;
			if (HasElements2Lists)
			{
				if (!method_46())
				{
					return false;
				}
				Elements2FileName = elements2Path;
				return method_21(elements2Path, Elements2ListStartIndex, Elements2ListCount, -1, null, bool_1: false);
			}
			if (!method_40(text, out var eListCollection_))
			{
				return false;
			}
			for (int i = 0; i < eListCollection_.Lists.Length; i++)
			{
				if (eListCollection_.Lists[i].elementValues == null)
				{
					eListCollection_.Lists[i].elementValues = Array.Empty<object[]>();
				}
			}
			eListCollection_.Elements2FileName = elements2Path;
			return eListCollection_.method_21(elements2Path, 0, eListCollection_.ListCount, -1, null, bool_1: false);
		}
		return false;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool AddEnumFromLua(string content, string enumName, [MarshalAs(UnmanagedType.U1)] bool bMask)
	{
		string text = enumName;
		if (enumName[0] == '^')
		{
			text = enumName.Substring(1);
		}
		else if (Game == GAMES.SW)
		{
			text = enumName + Class16.smethod_0(1649074928);
		}
		string text2 = Class16.smethod_0(1649074937);
		MatchCollection matchCollection = Regex.Matches(content, string.Concat(Class16.smethod_0(1649074989) + text, text2));
		bool flag = false;
		if (matchCollection.Count == 0)
		{
			string text3 = Class16.smethod_0(1649075001);
			Match match = Regex.Match(content, string.Concat(Class16.smethod_0(1649074989) + text, text3), RegexOptions.Multiline);
			if (match.Success)
			{
				string value = Class16.smethod_0(1649075044);
				string groupname = Class16.smethod_0(1648905100);
				if (!match.Groups[groupname].Value.StartsWith(value))
				{
					string groupname2 = Class16.smethod_0(1649075053);
					matchCollection = Regex.Matches(match.Groups[groupname2].Value, Class16.smethod_0(1649075057));
					flag = true;
				}
			}
		}
		if (matchCollection.Count == 0)
		{
			GC.KeepAlive(this);
			return false;
		}
		bool flag2 = false;
		SortedDictionary<decimal, string> sortedDictionary = new SortedDictionary<decimal, string>();
		int num = 0;
		foreach (Match item in matchCollection)
		{
			if (!flag)
			{
				string groupname3 = Class16.smethod_0(1648905100);
				if (item.Groups[groupname3].Value[0] == '-')
				{
					continue;
				}
			}
			uint result = 0u;
			string groupname4 = Class16.smethod_0(1648905186);
			if (!uint.TryParse(item.Groups[groupname4].Value, out result))
			{
				continue;
			}
			if (num == 0 && result != 0 && (Game != GAMES.FW || !(enumName == Class16.smethod_0(1649075104))) && (Game != GAMES.SW || !(enumName == Class16.smethod_0(1649075130))))
			{
				flag2 = true;
			}
			else if (!flag2)
			{
				goto IL_01e7;
			}
			result--;
			goto IL_01e7;
			IL_01e7:
			string groupname5 = Class16.smethod_0(1649075155);
			string value2 = item.Groups[groupname5].Value;
			if (string.IsNullOrEmpty(value2))
			{
				object[] vars = new object[1] { result };
				value2 = TextStorage.TEXTS.GetText(Class16.smethod_0(1649075169), vars);
			}
			decimal key = result;
			sortedDictionary.Add(key, value2);
			num++;
		}
		VALUES_ARRAY_PAIR vALUES_ARRAY_PAIR = new VALUES_ARRAY_PAIR(sortedDictionary.Count);
		num = 0;
		SortedDictionary<decimal, string>.Enumerator enumerator2 = sortedDictionary.GetEnumerator();
		if (enumerator2.MoveNext())
		{
			do
			{
				ValueType valueType = enumerator2.Current;
				decimal key2 = ((KeyValuePair<decimal, string>)(object)valueType).Key;
				vALUES_ARRAY_PAIR.realvalues[num] = key2;
				vALUES_ARRAY_PAIR.decodedvalues[num] = ((KeyValuePair<decimal, string>)(object)valueType).Value;
				num++;
			}
			while (enumerator2.MoveNext());
		}
		int num2 = (bMask ? 200000 : 100000) + StrIdToEnum.Count + 1;
		DecodedValues.AddValues(num2, vALUES_ARRAY_PAIR);
		if (EnumToStrId.ContainsKey(enumName))
		{
			EnumToStrId[enumName] = num2;
		}
		else
		{
			EnumToStrId.Add(enumName, num2);
		}
		if (StrIdToEnum.ContainsKey(num2))
		{
			StrIdToEnum[num2] = enumName;
		}
		else
		{
			StrIdToEnum.Add(num2, enumName);
		}
		GC.KeepAlive(this);
		return true;
	}

	public List<int> FindLists(string text, int selected_list, List<int> PriorityLists)
	{
		if (string.IsNullOrWhiteSpace(text))
		{
			GC.KeepAlive(this);
			return new List<int>();
		}
		HashSet<int> hashSet = new HashSet<int>();
		if (PriorityLists != null)
		{
			hashSet.UnionWith(PriorityLists);
		}
		hashSet.UnionWith(AllLists);
		if (selected_list > -1 && hashSet.Contains(selected_list))
		{
			hashSet.Remove(selected_list);
		}
		HashSet<int> hashSet2 = new HashSet<int>();
		hashSet2.UnionWith(ParseLists(text));
		HashSet<int>.Enumerator enumerator = hashSet.GetEnumerator();
		if (enumerator.MoveNext())
		{
			do
			{
				int current = enumerator.Current;
				if (current > -1 && current < ListCount && (ACE.RSGlobal.RSGlobal.ContainsIgnoreCase(Lists[current].ListName, text) || ACE.RSGlobal.RSGlobal.ContainsIgnoreCase(Lists[current].uListName, text)) && !hashSet2.Contains(current))
				{
					hashSet2.Add(current);
				}
			}
			while (enumerator.MoveNext());
		}
		GC.KeepAlive(this);
		return new List<int>(hashSet2);
	}

	public List<int> GetPageAllFields(int int_0, int pageIndex)
	{
		pageIndex++;
		int num = Lists[int_0].get_fields(string.Format(Class16.smethod_0(1649082322), pageIndex));
		int num2 = Lists[int_0].get_fields(string.Format(Class16.smethod_0(1649082322), pageIndex + 1)) - 1;
		if (num2 < 1)
		{
			ACE.Elements.eList.eList eList2 = Lists[int_0];
			num2 = (num << 1) - eList2.get_fields(string.Format(Class16.smethod_0(1649082322), pageIndex - 1)) - 1;
		}
		List<int> result = new List<int>(Enumerable.Range(num, num2 - num + 1));
		GC.KeepAlive(this);
		return result;
	}

	public int GetPageFieldCount(int int_0)
	{
		int num = Lists[int_0].get_fields(Class16.smethod_0(1649075192));
		int num2 = Lists[int_0].get_fields(Class16.smethod_0(1649082232));
		GC.KeepAlive(this);
		return num2 - num - 1;
	}

	private string method_47(string string_1)
	{
		return System.IO.Path.Combine(Application.StartupPath, Class16.smethod_0(1648909207), GamePrefix + Class16.smethod_0(1649074193) + string_1 + Class16.smethod_0(1648997294));
	}

	private string method_48(string string_1)
	{
		return System.IO.Path.Combine(Application.StartupPath, Class16.smethod_0(1648909207), GamePrefix + Class16.smethod_0(1649074193) + string_1 + Class16.smethod_0(1648997294));
	}
}
